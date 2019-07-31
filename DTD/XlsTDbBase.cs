using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DXD.DTD
{
    /// <summary>
    /// 数据导入导出接口基类，提供子类通用的函数和常量
    /// </summary>
    public abstract class XlsTDbBase:IXlsTDb
    {
        public static string connectionString = DXD.DBUtility.PubConstant.ConnectionString;
        protected DataTable ConvertToDataTable(string path)
        {
            IWorkbook hssfworkbook;

            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = WorkbookFactory.Create(file);
            }

            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();


            while (rows.MoveNext())
            {

                IRow row = (IRow)rows.Current;

                if (dt.Columns.Count == 0)
                {
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                    }
                }

                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = (ICell)row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        object cellValue=null;
                        switch (cell.CellType)
                        {
                            case CellType.Blank:
                                cellValue = "";
                                break;
                            case CellType.Numeric:
                                short format = cell.CellStyle.DataFormat;
                                //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理
                                if (format == 14 || format == 31 || format == 57 || format == 58 || format == 20)
                                    cellValue = cell.DateCellValue.ToString("yyyy-MM-dd");
                                else
                                    cellValue = cell.NumericCellValue;
                                break;
                            case CellType.String:
                                cellValue = cell.StringCellValue;
                                break;
                        }
                        dr[i] =cellValue;
                    }
                }
                dt.Rows.Add(dr);
            }            
            return dt;
        }
        public abstract string FileToDb(DTDParameter parameter);
        public abstract string DbToFile(DTDParameter parameter);
    }
}
