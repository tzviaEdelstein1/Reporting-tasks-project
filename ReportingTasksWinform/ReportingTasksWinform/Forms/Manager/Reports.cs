using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

using Telerik.WinControls.UI;

namespace ReportingTasksWinform.Forms.Manager
{
    public partial class Reports : Form
    {
        string kind;

        static List<TreeTable> newTreeTables = new List<TreeTable>();
        static List<TreeTable> treeTables = new List<TreeTable>();
        List<DetailsWorkerInProjects> detailsByKind;
        Timer expandTimer = new Timer();
        int rowToExpand;
        VirtualGridViewInfo viewInfoToExpand;
        List<Project> allProjects;
        List<User> allWorkers;
        List<User> allTeamLeaders;
        public Reports()
        {

            InitializeComponent();
            GetTreeTable();
            radVirtualGrid1.RowCount = treeTables.Count;
            this.radVirtualGrid1.ColumnCount = Project.FieldNames.Length;
            this.radVirtualGrid1.TableElement.RowHeight = 60;
            expandTimer.Interval = 1000;
            expandTimer.Tick += expandTimer_Tick;


            allProjects = Reqests.ProjectsRequst.GetAllProjects();
            allProjects.Add(new Project() { ProjectId = 0, ProjectName = "All Projects" });

            projects_combobox.SelectedIndexChanged -= new EventHandler(projects_combobox_SelectedIndexChanged);
            projects_combobox.DataSource = allProjects;
            projects_combobox.ValueMember = "ProjectId";
            projects_combobox.DisplayMember = "ProjectName";
            projects_combobox.SelectedItem = allProjects.First(p => p.ProjectName == "All Projects");
            projects_combobox.SelectedIndexChanged += projects_combobox_SelectedIndexChanged;

            workers_combo.SelectedIndexChanged -= new EventHandler(projects_combobox_SelectedIndexChanged);
            allWorkers = Reqests.UserRequsts.GetAllUsers();
            allWorkers.Add(new User() { UserId = 0, UserName = "All Workers" });
            workers_combo.DataSource = allWorkers;
            workers_combo.ValueMember = "UserId";
            workers_combo.DisplayMember = "UserName";
            workers_combo.SelectedItem = allWorkers.First(p => p.UserName == "All Workers");
            workers_combo.SelectedIndexChanged += projects_combobox_SelectedIndexChanged;

            Teams_combo.SelectedIndexChanged -= new EventHandler(projects_combobox_SelectedIndexChanged);
            allTeamLeaders = Reqests.UserRequsts.GetAllTeamLeaders();
            allTeamLeaders.Add(new User() { UserId = 0, UserName = "All Team Leaders" });
            Teams_combo.DataSource = allTeamLeaders;
            Teams_combo.ValueMember = "UserId";
            Teams_combo.DisplayMember = "UserName";
            Teams_combo.SelectedItem = allTeamLeaders.First(y => y.UserName == "All Team Leaders");
            Teams_combo.SelectedIndexChanged += projects_combobox_SelectedIndexChanged;
        }
        private void Reports_Load(object sender, EventArgs e)
        {


        }
        #region Populate Data

        //private void LoadData()
        //{
        //    this.radVirtualGrid1.RowCount = treeTables.Count;
        //    this.radVirtualGrid1.ColumnCount = 5;
        //}

        private void loadTable(Telerik.WinControls.UI.VirtualGridCellValueNeededEventArgs e)
        {
            if (e.ViewInfo == this.radVirtualGrid1.MasterViewInfo)
            {
                if (e.ColumnIndex < 0)
                {
                    return;
                }
                e.FieldName = Project.FieldNames[e.ColumnIndex];

                if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
                {
                    e.Value = e.FieldName;
                }
                else if (e.RowIndex >= 0)
                {
                    double all = 5;
                    double sum = 0;
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = treeTables[e.RowIndex].Project.ProjectName;
                            break;
                        case 1:
                            e.Value = treeTables[e.RowIndex].Project.ClientName;
                            break;
                        case 2:
                            e.Value = treeTables[e.RowIndex].Project.User.UserName;
                            break;

                        case 3:
                            all = treeTables[e.RowIndex].Project.DevelopersHours + treeTables[e.RowIndex].Project.QaHours + treeTables[e.RowIndex].Project.UiUxHours;
                            e.Value = all;
                            break;
                        case 4:
                            sum = 0;
                            foreach (var item in treeTables[e.RowIndex].DetailsWorkerInProjects)
                            {
                                foreach (var item2 in item.ActualHours)
                                {
                                    sum += item2.CountHours;
                                }
                            }

                            e.Value = sum;
                            break;
                        case 5:
                            all = treeTables[e.RowIndex].Project.DevelopersHours + treeTables[e.RowIndex].Project.QaHours + treeTables[e.RowIndex].Project.UiUxHours;

                            sum = 0;
                            foreach (var item in treeTables[e.RowIndex].DetailsWorkerInProjects)
                            {
                                foreach (var item2 in item.ActualHours)
                                {
                                    sum += item2.CountHours;
                                }
                            }
                            double precent = sum / all * 100;

                            if (precent == 0)
                                e.Value = "0%";
                            else
                                e.Value = precent.ToString() + "%";
                            break;
                        case 6:
                            e.Value = treeTables[e.RowIndex].Project.StartDate.ToString();
                            break;
                        case 7:
                            e.Value = treeTables[e.RowIndex].Project.FinishDate.ToString();
                            break;
                        case 8:
                            e.Value = treeTables[e.RowIndex].Project.IsActive.ToString();
                            break;
                        default:
                            break;
                    }

                }
            }
            else if (e.ViewInfo.HierarchyLevel == 2)
            {
                if (e.ColumnIndex < 0)
                {
                    return;
                }

                e.FieldName = DetailsWorkerInProjects.FieldNames[e.ColumnIndex];

                if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
                {
                    e.Value = e.FieldName;
                }
                else if (e.RowIndex >= 0)
                {
                    var w = e.ViewInfo.ParentViewInfo.ParentRowIndex;
                    switch (e.ViewInfo.ParentRowIndex)
                    {
                        case 0:
                            detailsByKind = treeTables[w].DetailsWorkerInProjects.Where(d => d.Kind == "Developers").ToList();
                            break;
                        case 1:
                            detailsByKind = treeTables[w].DetailsWorkerInProjects.Where(d => d.Kind == "QA").ToList();
                            break;
                        case 2:
                            detailsByKind = treeTables[w].DetailsWorkerInProjects.Where(d => d.Kind == "UI/UX").ToList();
                            break;
                        default:

                            break;
                    }




                    if (detailsByKind.Count > 0)
                    {
                        if (e.RowIndex < detailsByKind.Count)
                        {
                            switch (e.ColumnIndex)
                            {
                                case 0:
                                    e.Value = detailsByKind[e.RowIndex].TeamLeaderName;
                                    break;
                                case 1:
                                    e.Value = detailsByKind[e.RowIndex].Name;
                                    break;

                                case 2:
                                    e.Value = detailsByKind[e.RowIndex].Hours.ToString();
                                    break;
                                case 3:
                                    var list = detailsByKind[e.RowIndex].ActualHours;
                                    double sum = 0;
                                    foreach (var item in list)
                                    {
                                        sum += item.CountHours;
                                    }
                                    e.Value = sum.ToString();
                                    break;
                                case 4:
                                    double all = detailsByKind[e.RowIndex].Hours;
                                    list = detailsByKind[e.RowIndex].ActualHours;
                                    sum = 0;
                                    foreach (var item in list)
                                    {
                                        sum += item.CountHours;
                                    }
                                    double precent = sum / all * 100;
                                    if (precent > 0)
                                        e.Value = precent.ToString() + "%";

                                    else
                                        e.Value = "0%";


                                    break;
                                default:
                                    break;
                            }
                        }

                    }



                }
            }


            else if (e.ViewInfo.HierarchyLevel == 1)
            {
                List<string> kinds = new List<string>() { "Kind Name", "Hours", "Actual Hours", "Precent" };
                List<string> kindsNames = new List<string>() { "Developers", "QA", "UI/UX" };
                if (e.ColumnIndex < 0)
                {
                    return;
                }

                e.FieldName = kinds[e.ColumnIndex];

                if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
                {
                    e.Value = e.FieldName;
                }
                else
                {


                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = kindsNames[e.RowIndex];
                            break;
                        case 1:
                            switch (e.RowIndex)
                            {
                                case 0:
                                    e.Value = treeTables[e.ViewInfo.ParentRowIndex].Project.DevelopersHours;
                                    break;
                                case 1:
                                    e.Value = treeTables[e.ViewInfo.ParentRowIndex].Project.QaHours;
                                    break;
                                case 2:
                                    e.Value = treeTables[e.ViewInfo.ParentRowIndex].Project.UiUxHours;
                                    break;
                                default:
                                    break;
                            }
                            kind = e.Value.ToString();
                            break;
                        case 2:
                            List<DetailsWorkerInProjects> actuals = new List<DetailsWorkerInProjects>();
                            switch (e.RowIndex)
                            {
                                case 0:
                                    actuals = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects.Where(t => t.Kind == "Developers").ToList();
                                    break;
                                case 1:
                                    actuals = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects.Where(t => t.Kind == "QA").ToList();
                                    break;
                                case 2:
                                    actuals = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects.Where(t => t.Kind == "UI/UX").ToList();
                                    break;
                                default:
                                    break;
                            }
                            double sumActual = 0;
                            foreach (var item in actuals)
                            {
                                foreach (var h in item.ActualHours)
                                {
                                    sumActual += h.CountHours;
                                }

                            }
                            e.Value = sumActual;
                            break;
                        case 3:

                            actuals = new List<DetailsWorkerInProjects>();
                            double all = 0, sum = 0;
                            switch (e.RowIndex)
                            {
                                case 0:
                                    all = treeTables[e.ViewInfo.ParentRowIndex].Project.DevelopersHours;
                                    actuals = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects.Where(t => t.Kind == "Developers").ToList();
                                    break;
                                case 1:
                                    all = treeTables[e.ViewInfo.ParentRowIndex].Project.QaHours;
                                    actuals = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects.Where(t => t.Kind == "QA").ToList();
                                    break;
                                case 2:
                                    all = treeTables[e.ViewInfo.ParentRowIndex].Project.UiUxHours;
                                    actuals = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects.Where(t => t.Kind == "UI/UX").ToList();
                                    break;
                                default:
                                    break;
                            }

                            foreach (var item in actuals)
                            {
                                foreach (var h in item.ActualHours)
                                {
                                    sum += h.CountHours;
                                }

                            }
                            double precent = sum / all * 100;

                            if (precent == 0)
                                e.Value = "0%";
                            else
                                e.Value = precent.ToString() + "%";

                            break;
                        default:
                            break;
                    }


                }
            }

            else if (e.ViewInfo.HierarchyLevel == 3)
            {
                var w = e.ViewInfo.ParentViewInfo.ParentViewInfo.ParentRowIndex;
                var i = e.ViewInfo.ParentRowIndex;

                switch (e.ViewInfo.ParentViewInfo.ParentRowIndex)
                {
                    case 0:
                        detailsByKind = treeTables[w].DetailsWorkerInProjects.Where(d => d.Kind == "Developers").ToList();
                        break;
                    case 1:
                        detailsByKind = treeTables[w].DetailsWorkerInProjects.Where(d => d.Kind == "QA").ToList();
                        break;
                    case 2:
                        detailsByKind = treeTables[w].DetailsWorkerInProjects.Where(d => d.Kind == "UI/UX").ToList();
                        break;
                    default:

                        break;
                }
                if (e.ColumnIndex < 0)
                {
                    return;
                }

                e.FieldName = ActualHours.FieldNames[e.ColumnIndex];

                if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
                {
                    e.Value = e.FieldName;
                }
                else if (e.RowIndex >= 0)
                {
                    try
                    {
                        switch (e.ColumnIndex)
                        {
                            case 0:
                                e.Value = detailsByKind[i].ActualHours[e.RowIndex].CountHours.ToString();
                                break;
                            case 1:
                                e.Value = detailsByKind[i].ActualHours[e.RowIndex].date.ToString();

                                break;

                            default:
                                break;
                        }
                    }

                    catch (Exception ex)
                    {

                    }

                }
            }
        }

        private void radVirtualGrid1_CellValueNeeded(object sender, Telerik.WinControls.UI.VirtualGridCellValueNeededEventArgs e)
        {
            loadTable(e);
        }

        private void radVirtualGrid1_CellFormatting(object sender, VirtualGridCellElementEventArgs e)
        {
            if (e.CellElement.ColumnIndex < 0)
            {
                return;
            }

            if (e.CellElement.Value is Image)
            {
                e.CellElement.Image = (Image)e.CellElement.Value;
                e.CellElement.ImageLayout = ImageLayout.Zoom;
                e.CellElement.Text = "";
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.ImageProperty, Telerik.WinControls.ValueResetFlags.Local);
            }

            if (e.ViewInfo.HierarchyLevel == 1)
            {
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
            else if (e.ViewInfo.HierarchyLevel == 2)
            {
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
            else if (e.ViewInfo.HierarchyLevel == 3)
            {
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.TextAlignmentProperty);
            }
        }

        #endregion
        #region Hierarchy

        private void radVirtualGrid1_QueryHasChildRows(object sender, Telerik.WinControls.UI.VirtualGridQueryHasChildRowsEventArgs e)
        {
            e.HasChildRows = (e.RowIndex >= 0 && e.ViewInfo.HierarchyLevel < 4);//
        }

        void expandTimer_Tick(object sender, EventArgs e)
        {
            expandTimer.Stop();
            viewInfoToExpand.StopRowWaiting(rowToExpand);
            viewInfoToExpand.ExpandRow(rowToExpand);
            viewInfoToExpand = null;
        }

        private void radVirtualGrid1_RowExpanding(object sender, Telerik.WinControls.UI.VirtualGridRowExpandingEventArgs e)
        {
            if (viewInfoToExpand == null)
            {
                e.Cancel = true;
                e.ViewInfo.StartRowWaiting(e.RowIndex);
                viewInfoToExpand = e.ViewInfo;
                rowToExpand = e.RowIndex;
                expandTimer.Start();
            }
            else
            {
                if (rowToExpand != e.RowIndex)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (e.ChildViewInfo.HierarchyLevel == 2)
                    {
                        e.ChildViewInfo.ColumnCount = DetailsWorkerInProjects.FieldNames.Length;
                        e.ChildViewInfo.RowCount = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects.Count;
                    }
                    //
                    else if (e.ChildViewInfo.HierarchyLevel == 1)
                    {
                        e.ChildViewInfo.ColumnCount = 4;
                        e.ChildViewInfo.RowCount = 3;
                    }
                    else if (e.ChildViewInfo.HierarchyLevel == 3)
                    {
                        e.ChildViewInfo.ColumnCount = 2;
                        e.ChildViewInfo.RowCount = 3;
                    }

                    else
                    {
                        e.ChildViewInfo.ColumnCount = 0;
                        e.ChildViewInfo.RowCount = 0;
                    }
                }
            }
        }

        #endregion


        public static void GetTreeTable()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            string content;
            request = (HttpWebRequest)WebRequest.Create(@"http://localhost:56028/api/TreeTable");
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                content = new StreamReader(response.GetResponseStream()).ReadToEnd();
                treeTables = JsonConvert.DeserializeObject<List<TreeTable>>(content);
                newTreeTables = JsonConvert.DeserializeObject<List<TreeTable>>(content);

            }
            else MessageBox.Show("error");


        }

        private void Reports_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        Project selectedProject = null;
        User selectedWorker = null;
        User selectedTeam = null;
        DateTime selectedStartDate;
        DateTime selectedFinishDate;
        DateTime date;
        //להעלות למעלה
        private void projects_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProject = projects_combobox.SelectedItem as Project;
            selectedWorker = workers_combo.SelectedItem as User;
            selectedTeam = Teams_combo.SelectedItem as User;
            filter();

        }

        private void monthCalendar_start_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedStartDate = monthCalendar_start.SelectionRange.Start;
            filter();
        }

        private void monthCalendar_finish_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedFinishDate = monthCalendar_finish.SelectionRange.Start;
            filter();
        }

        private void filter()
        {

            if (selectedProject != null && selectedProject.ProjectName != "All Projects")
                treeTables = newTreeTables.Where(p => p.Project.ProjectId.Equals(selectedProject.ProjectId)).ToList();
            else
                treeTables = newTreeTables;
            if (selectedTeam != null && selectedTeam.UserName != "All Team Leaders")
                treeTables = treeTables.Where(p => p.Project.TeamLeaderId == selectedTeam.UserId).ToList();
            if (selectedWorker != null && selectedWorker.UserName != "All Workers")
                treeTables = treeTables.Where(p => p.DetailsWorkerInProjects.Any(d => d.UserId == selectedWorker.UserId)).ToList();
            if (selectedStartDate != date)
                treeTables = treeTables.Where(p => p.Project.StartDate.Month == selectedStartDate.Month && p.Project.StartDate.Year == selectedStartDate.Year).ToList();
            if (selectedFinishDate != date)
                treeTables = treeTables.Where(p => p.Project.FinishDate.Month == selectedFinishDate.Month && p.Project.FinishDate.Year == selectedFinishDate.Year).ToList();

            radVirtualGrid1.RowCount = treeTables.Count;

            this.radVirtualGrid1.TableElement.SynchronizeRows();
        }
    }
}