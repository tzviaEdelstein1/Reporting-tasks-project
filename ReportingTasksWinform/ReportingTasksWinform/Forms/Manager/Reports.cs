using Newtonsoft.Json;
using ReportingTasksWinform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls.UI;

namespace ReportingTasksWinform.Forms.Manager
{
    public partial class Reports : Form
    {
        string kind;

        List<TreeTable> newTreeTables = new List<TreeTable>();
        static List<TreeTable> treeTables = new List<TreeTable>();
        Timer expandTimer = new Timer();
        int rowToExpand;
        VirtualGridViewInfo viewInfoToExpand;
        public Reports()
        {

            InitializeComponent();
            GetTreeTable();
            radVirtualGrid1.RowCount = treeTables.Count;
            this.radVirtualGrid1.ColumnCount = Project.FieldNames.Length;
            this.radVirtualGrid1.TableElement.RowHeight = 120;
            expandTimer.Interval = 1000;
            expandTimer.Tick += expandTimer_Tick;
        }
        private void Reports_Load(object sender, EventArgs e)
        {


        }
        #region Populate Data

        private void LoadData()
        {

            //Random random = new Random();

            //for (int i = 0; i < treeTables.Count; i++)
            //{
            //    TreeTable treeTable = new TreeTable();
            //    treeTable.Project.ProjectName = treeTables[i].Project.ProjectName;
            //    treeTable.Project.ClientName = treeTables[i].Project.ClientName;
            //    treeTable.Project.User.UserName = treeTables[i].Project.User.UserName;
            //    treeTable.Project.QaHours = treeTables[i].Project.QaHours;
            //    treeTable.Project.UiUxHours = treeTables[i].Project.UiUxHours;
            //    treeTable.Project.DevelopersHours = treeTables[i].Project.DevelopersHours;
            //    for (int j = 0; j < treeTables[i].DetailsWorkerInProjects.Count; j++)
            //    {
            //        DetailsWorkerInProjects detailsWorkerInProjects = new DetailsWorkerInProjects()
            //        {
            //            ActualHours = treeTables[i].DetailsWorkerInProjects[j].ActualHours,
            //            Hours = treeTables[i].DetailsWorkerInProjects[j].Hours,
            //            Kind = treeTables[i].DetailsWorkerInProjects[j].Kind,
            //            Name = treeTables[i].DetailsWorkerInProjects[j].Name,

            //        };

            //        for (int k = 0; k < treeTables[i].DetailsWorkerInProjects[j].ActualHours.Count; k++)
            //        {
            //            detailsWorkerInProjects.ActualHours.Add(new ActualHours()
            //            {
            //                CountHours = treeTables[i].DetailsWorkerInProjects[j].ActualHours[k].CountHours,
            //                date = treeTables[i].DetailsWorkerInProjects[j].ActualHours[k].date

            //            });
            //        }

            //        treeTable.DetailsWorkerInProjects.Add(detailsWorkerInProjects);
            //    }

            //    data.Add(employee);
            //}

            this.radVirtualGrid1.RowCount = treeTables.Count;
            this.radVirtualGrid1.ColumnCount = 5;
        }

        private void radVirtualGrid1_CellValueNeeded(object sender, Telerik.WinControls.UI.VirtualGridCellValueNeededEventArgs e)
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
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = treeTables[e.RowIndex].Project.ProjectName;
                            break;
                        case 1:
                            e.Value += treeTables[e.RowIndex].Project.ClientName;
                            break;
                        case 2:


                            e.Value += treeTables[e.RowIndex].Project.User.UserName;
                            break;
                        case 3:
                            e.Value += treeTables[e.RowIndex].Project.DevelopersHours.ToString();
                            break;
                        case 4:
                            e.Value += treeTables[e.RowIndex].Project.QaHours.ToString();
                            break;
                        case 5:
                            e.Value += treeTables[e.RowIndex].Project.UiUxHours.ToString();
                            break;
                        default:
                            break;
                    }
                    // e.Value = treeTables[e.RowIndex].Project;


                    //if (e.ColumnIndex == 2)
                    //{
                    //    e.FormatString = "${0:#,###}";
                    //}
                    //else if (e.ColumnIndex == 3)
                    //{
                    //    e.FormatString = "{0:MM/dd/yy}";
                    //}
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
                    var tree = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects.Where(t => t.Kind == kind);

                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects[e.RowIndex].TeamLeaderName;
                            break;
                        case 1:
                            e.Value = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects[e.RowIndex].Name;
                            break;
                        case 2:
                            e.Value = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects[e.RowIndex].Kind;
                            break;
                        case 3:
                            e.Value = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects[e.RowIndex].Hours.ToString();
                            break;
                        case 4:
                            var list = treeTables[e.ViewInfo.ParentRowIndex].DetailsWorkerInProjects[e.RowIndex].ActualHours;
                            double sum = 0;
                            foreach (var item in list)
                            {
                                sum += item.CountHours;
                            }
                            e.Value = sum.ToString();
                            break;
                        default:
                            break;
                    }


                }
            }


            else if (e.ViewInfo.HierarchyLevel == 1)
            {
                List<string> kinds = new List<string>() { "Kind Name", "Hours", "Actual Hours" };
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
                            switch(e.RowIndex)
                            {
                                case 0:
                                    e.Value = treeTables[e.RowIndex].Project.DevelopersHours;
                                    break;
                                case 1:
                                    e.Value = treeTables[e.RowIndex].Project.QaHours;
                                    break;
                                case 2:
                                    e.Value = treeTables[e.RowIndex].Project.UiUxHours;
                                    break;
                                default:
                                    break;
                            }
                            kind = e.Value.ToString();
                            break;
                        case 2:
                            e.Value = 0;
                            break;
                        default:
                            break;
                    }


                }
            }

            else
            {
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
                    switch (e.ColumnIndex)
                    {
                        case 0:
                            e.Value = treeTables[e.ViewInfo.ParentViewInfo.ParentRowIndex].DetailsWorkerInProjects[e.ViewInfo.ParentRowIndex].ActualHours[e.RowIndex].CountHours.ToString();
                            break;
                        case 1:
                            e.Value += treeTables[e.ViewInfo.ParentViewInfo.ParentRowIndex].DetailsWorkerInProjects[e.ViewInfo.ParentRowIndex].ActualHours[e.RowIndex].date.ToString();

                            break;

                        default:
                            break;
                    }



                    //if (e.ColumnIndex == 0)
                    //{
                    //    e.FormatString = "#{0}";
                    //}
                    //else if (e.ColumnIndex == 2)
                    //{
                    //    e.FormatString = "{0:F2}%";
                    //}
                    //else if (e.ColumnIndex == 3)
                    //{
                    //    e.FormatString = "${0}";
                    //}
                }
            }
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
            //else if (e.ViewInfo.HierarchyLevel == 2)
            //{
            //    e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            //}
            else
            {
                e.CellElement.ResetValue(LightVisualElement.TextAlignmentProperty);
            }
        }

        #endregion
        #region Hierarchy

        private void radVirtualGrid1_QueryHasChildRows(object sender, Telerik.WinControls.UI.VirtualGridQueryHasChildRowsEventArgs e)
        {
            e.HasChildRows = (e.RowIndex >= 0 && e.ViewInfo.HierarchyLevel < 3);//
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
                    if (e.ChildViewInfo.HierarchyLevel ==2)
                    {
                        e.ChildViewInfo.ColumnCount = DetailsWorkerInProjects.FieldNames.Length;
                        e.ChildViewInfo.RowCount = treeTables[e.ChildViewInfo.ParentRowIndex].DetailsWorkerInProjects.Count;
                    }
                    //
                    else if (e.ChildViewInfo.HierarchyLevel ==1)
                    {
                        e.ChildViewInfo.ColumnCount = 3;
                        e.ChildViewInfo.RowCount = 3;
                    }
                    //
                    else
                    {
                        e.ChildViewInfo.ColumnCount = ActualHours.FieldNames.Length;
                        e.ChildViewInfo.RowCount = treeTables[e.ChildViewInfo.ParentViewInfo.ParentRowIndex].DetailsWorkerInProjects[e.ChildViewInfo.ParentRowIndex].ActualHours.Count;
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

            }
            else MessageBox.Show("error");


        }

        private void Reports_Load_1(object sender, EventArgs e)
        {

        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Text;
//using System.Windows.Forms;
//using Telerik.QuickStart.WinControls;
//using Telerik.WinControls.UI;

//namespace Telerik.Examples.WinControls.VirtualGrid.Hierarchy
//{
//    public partial class Form1 : ExamplesForm
//    {
//        #region Initialization

//        List<Employee> data = new List<Employee>();
//        Timer expandTimer = new Timer();
//        int rowToExpand;
//        VirtualGridViewInfo viewInfoToExpand;

//        public Form1()
//        {
//            InitializeComponent();
//            LoadData();
//            this.radVirtualGrid1.TableElement.RowHeight = 120;

//            expandTimer.Interval = 1000;
//            expandTimer.Tick += expandTimer_Tick;
//        }

//        #endregion

//        #region Populate Data

//        private void LoadData()
//        {
//            employeesTableAdapter.Fill(northwindDataSet.Employees);
//            customersTableAdapter.Fill(northwindDataSet.Customers);
//            Random random = new Random();

//            for (int i = 0; i < northwindDataSet.Employees.Count; i++)
//            {
//                Telerik.Examples.WinControls.DataSources.NorthwindDataSet.EmployeesRow row = northwindDataSet.Employees[i];
//                Employee employee = new Employee();
//                employee.Name = row.FirstName + " " + row.LastName;
//                employee.Photo = GetImageFromBytes(row.Photo);
//                employee.Salary = random.Next(45000);
//                employee.HireDate = row.HireDate;
//                employee.Title = row.Title;

//                int rowCount = random.Next(3, 10);

//                for (int j = 0; j < rowCount; j++)
//                {
//                    int customerIndex = random.Next(0, northwindDataSet.Customers.Count);
//                    Telerik.Examples.WinControls.DataSources.NorthwindDataSet.CustomersRow customerRow = northwindDataSet.Customers[customerIndex];

//                    Customer customer = new Customer()
//                    {
//                        CompanyName = customerRow.CompanyName,
//                        Country = customerRow.Country,
//                        City = customerRow.City,
//                        ContactName = customerRow.ContactName
//                    };

//                    int salesCount = random.Next(2, 6);

//                    for (int k = 0; k < salesCount; k++)
//                    {
//                        customer.Sales.Add(new Sale()
//                        {
//                            ProductNumber = random.Next(1000),
//                            Quantity = random.Next(50),
//                            Discount = random.Next(100),
//                            Total = random.Next(10000)
//                        });
//                    }

//                    employee.Customers.Add(customer);
//                }

//                data.Add(employee);
//            }

//            this.radVirtualGrid1.RowCount = data.Count;
//            this.radVirtualGrid1.ColumnCount = Employee.FieldNames.Length;
//        }

//        private void radVirtualGrid1_CellValueNeeded(object sender, Telerik.WinControls.UI.VirtualGridCellValueNeededEventArgs e)
//        {
//            if (e.ViewInfo == this.radVirtualGrid1.MasterViewInfo)
//            {
//                if (e.ColumnIndex < 0)
//                {
//                    return;
//                }

//                e.FieldName = Employee.FieldNames[e.ColumnIndex];

//                if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
//                {
//                    e.Value = e.FieldName;
//                }
//                else if (e.RowIndex >= 0)
//                {
//                    e.Value = data[e.RowIndex][e.ColumnIndex];
//                    if (e.ColumnIndex == 2)
//                    {
//                        e.FormatString = "${0:#,###}";
//                    }
//                    else if (e.ColumnIndex == 3)
//                    {
//                        e.FormatString = "{0:MM/dd/yy}";
//                    }
//                }
//            }
//            else if (e.ViewInfo.HierarchyLevel == 1)
//            {
//                if (e.ColumnIndex < 0)
//                {
//                    return;
//                }

//                e.FieldName = Customer.FieldNames[e.ColumnIndex];

//                if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
//                {
//                    e.Value = e.FieldName;
//                }
//                else if (e.RowIndex >= 0)
//                {
//                    e.Value = data[e.ViewInfo.ParentRowIndex].Customers[e.RowIndex][e.ColumnIndex];
//                }
//            }
//            else
//            {
//                if (e.ColumnIndex < 0)
//                {
//                    return;
//                }

//                e.FieldName = Sale.FieldNames[e.ColumnIndex];

//                if (e.RowIndex == RadVirtualGrid.HeaderRowIndex)
//                {
//                    e.Value = e.FieldName;
//                }
//                else if (e.RowIndex >= 0)
//                {
//                    e.Value = data[e.ViewInfo.ParentViewInfo.ParentRowIndex].Customers[e.ViewInfo.ParentRowIndex].Sales[e.RowIndex][e.ColumnIndex];

//                    if (e.ColumnIndex == 0)
//                    {
//                        e.FormatString = "#{0}";
//                    }
//                    else if (e.ColumnIndex == 2)
//                    {
//                        e.FormatString = "{0:F2}%";
//                    }
//                    else if (e.ColumnIndex == 3)
//                    {
//                        e.FormatString = "${0}";
//                    }
//                }
//            }
//        }

//        private void radVirtualGrid1_CellFormatting(object sender, VirtualGridCellElementEventArgs e)
//        {
//            if (e.CellElement.ColumnIndex < 0)
//            {
//                return;
//            }

//            if (e.CellElement.Value is Image)
//            {
//                e.CellElement.Image = (Image)e.CellElement.Value;
//                e.CellElement.ImageLayout = ImageLayout.Zoom;
//                e.CellElement.Text = "";
//            }
//            else
//            {
//                e.CellElement.ResetValue(LightVisualElement.ImageProperty, Telerik.WinControls.ValueResetFlags.Local);
//            }

//            if (e.ViewInfo.HierarchyLevel == 1)
//            {
//                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
//            }
//            else
//            {
//                e.CellElement.ResetValue(LightVisualElement.TextAlignmentProperty);
//            }
//        }

//        #endregion

//        #region Hierarchy

//        private void radVirtualGrid1_QueryHasChildRows(object sender, Telerik.WinControls.UI.VirtualGridQueryHasChildRowsEventArgs e)
//        {
//            e.HasChildRows = (e.RowIndex >= 0 && e.ViewInfo.HierarchyLevel < 2);
//        }

//        void expandTimer_Tick(object sender, EventArgs e)
//        {
//            expandTimer.Stop();
//            viewInfoToExpand.StopRowWaiting(rowToExpand);
//            viewInfoToExpand.ExpandRow(rowToExpand);
//            viewInfoToExpand = null;
//        }

//        private void radVirtualGrid1_RowExpanding(object sender, Telerik.WinControls.UI.VirtualGridRowExpandingEventArgs e)
//        {
//            if (viewInfoToExpand == null)
//            {
//                e.Cancel = true;
//                e.ViewInfo.StartRowWaiting(e.RowIndex);
//                viewInfoToExpand = e.ViewInfo;
//                rowToExpand = e.RowIndex;
//                expandTimer.Start();
//            }
//            else
//            {
//                if (rowToExpand != e.RowIndex)
//                {
//                    e.Cancel = true;
//                }
//                else
//                {
//                    if (e.ChildViewInfo.HierarchyLevel == 1)
//                    {
//                        e.ChildViewInfo.ColumnCount = Customer.FieldNames.Length;
//                        e.ChildViewInfo.RowCount = data[e.ChildViewInfo.ParentRowIndex].Customers.Count;
//                    }
//                    else
//                    {
//                        e.ChildViewInfo.ColumnCount = Sale.FieldNames.Length;
//                        e.ChildViewInfo.RowCount = data[e.ChildViewInfo.ParentViewInfo.ParentRowIndex].Customers[e.ChildViewInfo.ParentRowIndex].Sales.Count;
//                    }
//                }
//            }
//        }

//        #endregion

//        #region Helper Methods

//        private Image GetImageFromBytes(byte[] bytes)
//        {
//            Image result = null;
//            MemoryStream stream = null;

//            try
//            {
//                stream = new MemoryStream(bytes, 78, bytes.Length - 78);
//                result = Image.FromStream(stream);
//            }
//            catch
//            {
//                try
//                {
//                    stream = new MemoryStream(bytes, 0, bytes.Length);
//                    result = Image.FromStream(stream);
//                }
//                catch
//                {
//                    result = null;
//                }
//            }
//            finally
//            {
//                if (stream != null)
//                    stream.Close();
//            }

//            return result;
//        }

//        #endregion
//    }
//}


