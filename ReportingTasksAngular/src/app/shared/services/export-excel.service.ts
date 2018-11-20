import { Injectable } from '@angular/core';
// import * as Excel from "exceljs/dist/exceljs.min.js";
// import * as ExcelProper from "exceljs";
// import * as FileSaver from 'file-saver';
import * as XLSX from 'xlsx';
const EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
const EXCEL_EXTENSION = '.xlsx';
@Injectable({
  providedIn: 'root'
})
export class ExportExcelService {

 export(readyToExport:any[]) {
   debugger;

  const workBook = XLSX.utils.book_new(); // create a new blank book
  const workSheet = XLSX.utils.json_to_sheet(readyToExport);

  XLSX.utils.book_append_sheet(workBook, workSheet, 'data'); // add the worksheet to the book
  XLSX.writeFile(workBook, 'temp.xlsx'); // initiate a file download in browser
}
  constructor() { }
}
