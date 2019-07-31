using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;

namespace DXD.DTD
{
    public class CompareToFile
    {
        private static string EqualStr = "比对结果与个人报告相符。";
        public int[] NPOI_CellChange(string A1)
        {   
            int[] nCell = new int[2];
            string strSplit1, strSplit2;
            //string A2 = A1.Substring(7, 3);
            strSplit1 = Regex.Replace(A1, "[0-9]", "", RegexOptions.IgnoreCase);
            strSplit2 = Regex.Replace(A1, "[a-z]", "", RegexOptions.IgnoreCase);
            char[] A3 = strSplit1.ToCharArray();
            nCell[0] = int.Parse(strSplit2) - 1;

            int n = 0;
            for(int i=0;i<A3.Length;i++)
            {
                n += (A3[i] - 'A'+1)*Convert.ToInt32((System.Math.Pow(26,Convert.ToDouble(A3.Length-i-1))));
            }
            nCell[1] = n-1;            
            return nCell;
        }

        //导出个人比对表到文件         
        public string PersonToFile(string path,int query_id)
        {
            IWorkbook workbook;
            try
            {
                using (FileStream file = new FileStream(System.Environment.CurrentDirectory + "\\Templates\\比对表.xlsx", FileMode.Open, FileAccess.Read))
                {
                    workbook = WorkbookFactory.Create(file);
                }
                ISheet sheet = workbook.GetSheetAt(0);
                BLL.query_detail bDetail = new BLL.query_detail();
                Model.query_detail mDetail = bDetail.GetModel(query_id);

                int[] cellpos = NPOI_CellChange("B3");
                ICell cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                IRow row;
                cell.SetCellValue(mDetail.full_name);
                cellpos = NPOI_CellChange("E3");
                cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                cell.SetCellValue(mDetail.work_unit);
                cellpos = NPOI_CellChange("G3");
                cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                cell.SetCellValue(mDetail.post);

                BLL.compare_result bResult = new BLL.compare_result();

                //护照比对情况
                Model.compare_result mResult =bResult.GetModal(string.Format("query_id={0} and result_type='护照'",query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C5");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("D5");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("F5");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.compare_str.Replace("\r\n", ""));
                    if (mResult.report_str.Length < 30 && mResult.feedback_str.Length < 30 && mResult.compare_str.Length < 30)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }                

                //港澳通行证比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='港澳台通行证'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C6");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("D6");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("F6");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.compare_str.Replace("\r\n", ""));
                    if (mResult.report_str.Length < 30 && mResult.feedback_str.Length < 30 && mResult.compare_str.Length < 30)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 50 * 20;
                    }
                }

                //出国比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='出国'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C7");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("D7");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("F7");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.compare_str.Replace("\r\n", ""));
                    if (mResult.report_str.Length < 15 && mResult.feedback_str.Length < 15 && mResult.compare_str.Length < 15)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }

                //出境比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='出境'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C8");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("D8");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("F8");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.compare_str.Replace("\r\n", ""));
                    if (mResult.report_str.Length < 15 && mResult.feedback_str.Length < 15 && mResult.compare_str.Length < 15)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }

                //在国外连续生活一年以上比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='国外生活'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C9");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("D9");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str.Replace("\r\n", ""));
                    cellpos = NPOI_CellChange("F9");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);                    
                    cell.SetCellValue(mResult.compare_str.Split('|')[0].Replace("\r\n", ""));
                    if (mResult.report_str.Length < 15 && mResult.feedback_str.Length < 15 && mResult.compare_str.Length < 15)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }

                //房产比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='房产'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C10");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str);
                    cellpos = NPOI_CellChange("D10");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str);
                    cellpos = NPOI_CellChange("F10");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.compare_str);
                    if (mResult.report_str.Length < 15 && mResult.feedback_str.Length < 15 && mResult.compare_str.Length < 15)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }

                //股票比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='股票'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C11");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str);
                    cellpos = NPOI_CellChange("D11");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str);
                    cellpos = NPOI_CellChange("F11");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.compare_str);
                    if (mResult.report_str.Length < 15 && mResult.feedback_str.Length < 15 && mResult.compare_str.Length < 15)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }

                //基金比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='基金'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C11");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(cell.StringCellValue+"\r\n"+ mResult.report_str);
                    cellpos = NPOI_CellChange("D11");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(cell.StringCellValue + "\r\n" + mResult.feedback_str);
                    cellpos = NPOI_CellChange("F11");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    if (!mResult.compare_str.Contains("基本一致"))
                    {
                        if (cell.StringCellValue.Contains("基本一致"))
                        {
                            cell.SetCellValue(mResult.compare_str);
                        }
                        else
                        {
                            cell.SetCellValue(cell.StringCellValue + "\r\n" + mResult.compare_str);
                        }
                    }
                    
                    if (mResult.report_str.Length < 15 && mResult.feedback_str.Length < 15 && 
                        mResult.compare_str.Length < 15)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }

                //保险比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='保险'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C12");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str);
                    cellpos = NPOI_CellChange("D12");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str);
                    cellpos = NPOI_CellChange("F12");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.compare_str);
                    if (mResult.report_str.Length < 15 && mResult.feedback_str.Length < 15 && mResult.compare_str.Length < 15)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }

                //工商比对情况
                mResult = bResult.GetModal(string.Format("query_id={0} and result_type='工商'", query_id));
                if (mResult != null)
                {
                    cellpos = NPOI_CellChange("C13");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.report_str);
                    cellpos = NPOI_CellChange("D13");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.feedback_str);
                    cellpos = NPOI_CellChange("F13");
                    cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                    cell.SetCellValue(mResult.compare_str);
                    if (mResult.report_str.Length < 15 && mResult.feedback_str.Length < 15 && mResult.compare_str.Length < 15)
                    {
                        row = sheet.GetRow(cellpos[0]);
                        row.Height = 25 * 20;
                    }
                }

                //认定比对结果
                cellpos = NPOI_CellChange("C14");
                cell = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);
                cellpos = NPOI_CellChange("C15");
                ICell cell2 = sheet.GetRow(cellpos[0]).GetCell(cellpos[1]);

                if (!mDetail.is_match)
                {
                    DataSet ds = bResult.GetList(string.Format("query_id={0} and compare_str not like ('%基本一致%')", query_id));                                        
                    cell.SetCellValue("比对结果不一致：\r\n");
                    string cellValue = "";
                    int rowcount = 6;//单元格字符行数，用于估算行高
                    for (int i=0;i<ds.Tables[0].Rows.Count;i++)
                    {
                        cellValue += (i+1).ToString()+"、"+ds.Tables[0].Rows[i]["compare_str"].ToString().Replace("\r\n","")+"\r\n";
                    }                    
                    cell2.SetCellValue(cell2.StringCellValue.Replace("{MatchStr}", cellValue));
                }
                else
                {                    
                    cell.SetCellValue(EqualStr);                 
                    cell2.SetCellValue(cell2.StringCellValue.Replace("{MatchStr}", ""));
                }
                cell2.SetCellValue(cell2.StringCellValue.Replace("{CompareDate}", 
                    DateTime.Now.ToLongDateString()));

                using (FileStream fileStream = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);
                    fileStream.Close();
                }
                return "OK";
            }
            catch(Exception e)
            {
                return e.Message;
            }            
        }

        //将比对结果添加到汇总表         
        public string CollectToFile(string path,int list_id)
        {
            int rowIndex=0;   //excel新建行的行号
            IWorkbook workbook;
            IRow row;
            ICell cell;
            ICellStyle style,style2;
            //HSSFCellStyle celStyle = getCellStyle();
            
            try
            {
                using (FileStream file = new FileStream(System.Environment.CurrentDirectory + "\\Templates\\汇总表.xlsx", FileMode.Open, FileAccess.Read))
                {
                    workbook = WorkbookFactory.Create(file);
                }

                if(workbook is HSSFWorkbook)
                {
                    style = ((HSSFWorkbook)workbook).CreateCellStyle();
                    style2 = ((HSSFWorkbook)workbook).CreateCellStyle();
                }
                else
                {
                    style = ((XSSFWorkbook)workbook).CreateCellStyle();
                    style2 = ((XSSFWorkbook)workbook).CreateCellStyle();
                }
                
                style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BottomBorderColor = 128;
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.WrapText = true;
                style2.CloneStyleFrom(style);
                style2.Alignment = HorizontalAlignment.Left;
                ISheet sheet = workbook.GetSheetAt(0);

                BLL.query_detail bDetail = new BLL.query_detail();
                List<Model.query_detail> list = bDetail.GetModelList(String.Format("where list_id={0} and parent_id=0", list_id));
                BLL.compare_result bResult = new BLL.compare_result();

                for (int i=0;i<list.Count;i++)
                {
                    if (list[i].is_compare)
                    {                           
                        style.FillBackgroundColor = 128;
                    }
                    else
                    {
                        style.FillBackgroundColor = 10;
                    }


                    rowIndex = 3 + i;
                    row = sheet.CreateRow(rowIndex);
                    for (int j = 0; j < 17; j++)
                    {
                        cell = row.CreateCell(j);
                        cell.CellStyle = style;
                    }
                    sheet.GetRow(rowIndex).GetCell(6).CellStyle = style2;
                    sheet.GetRow(rowIndex).GetCell(8).CellStyle = style2;
                    sheet.GetRow(rowIndex).GetCell(10).CellStyle = style2;
                    sheet.GetRow(rowIndex).GetCell(12).CellStyle = style2;
                    sheet.GetRow(rowIndex).GetCell(14).CellStyle = style2;


                    cell = sheet.GetRow(rowIndex).GetCell(0);
                    cell.SetCellValue(i + 1);

                    cell = sheet.GetRow(rowIndex).GetCell(2);
                    cell.SetCellValue(list[i].full_name);
                    cell = sheet.GetRow(rowIndex).GetCell(3);
                    cell.SetCellValue(list[i].work_unit);
                    cell = sheet.GetRow(rowIndex).GetCell(4);
                    cell.SetCellValue(list[i].post);

                    List<Model.compare_result> mResult = bResult.GetModelList(string.Format("query_id={0}", list[i].id));
                    foreach(Model.compare_result item in mResult)
                    {
                        switch (item.result_type)
                        {
                            case "护照":
                            case "港澳台通行证":
                            case "出国":
                            case "出境":
                            case "国外生活":
                                if (0 <= item.compare_str.IndexOf("基本一致")){
                                    cell = sheet.GetRow(rowIndex).GetCell(6);
                                    if ("" == cell.StringCellValue)
                                    {
                                        cell = sheet.GetRow(rowIndex).GetCell(5);
                                        cell.SetCellValue("√");
                                    }                                    
                                }
                                else
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(5);
                                    if ("√" == cell.StringCellValue)
                                    {
                                        cell.SetCellValue("");
                                    }
                                    cell = sheet.GetRow(rowIndex).GetCell(6);
                                    if ("" == cell.StringCellValue)
                                    {
                                        cell.SetCellValue(item.compare_str); 
                                    }
                                    else
                                    {                                        
                                        cell.SetCellValue(cell.StringCellValue + "\r\n" + item.compare_str);
                                    }                                    
                                }
                                break;
                            case "房产":                            
                                if (0 <= item.compare_str.IndexOf("基本一致"))
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(7);
                                    cell.SetCellValue("√");
                                }
                                else
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(8);
                                    cell.SetCellValue(item.compare_str);                                    
                                }
                                break;
                            case "股票":
                            case "基金":
                                if (0 <= item.compare_str.IndexOf("基本一致"))
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(10);
                                    if ("" == cell.StringCellValue)
                                    {
                                        cell = sheet.GetRow(rowIndex).GetCell(9);
                                        cell.SetCellValue("√");
                                    }                                    
                                }
                                else
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(9);
                                    if ("√" == cell.StringCellValue)
                                    {
                                        cell.SetCellValue("");
                                    }
                                    cell = sheet.GetRow(rowIndex).GetCell(10);
                                    if ("" == cell.StringCellValue)
                                    {
                                        cell.SetCellValue(item.compare_str);                                        
                                    }
                                    else
                                    {
                                        cell.SetCellValue(cell.StringCellValue + "\r\n" + item.compare_str);
                                    }
                                }
                                break;
                            case "保险":
                                if (0 <= item.compare_str.IndexOf("基本一致"))
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(11);
                                    cell.SetCellValue("√");
                                }
                                else
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(12);
                                    cell.SetCellValue(item.compare_str);                                    
                                }
                                break;
                            case "工商":
                                if (0 <= item.compare_str.IndexOf("基本一致"))
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(13);
                                    cell.SetCellValue("√");
                                }
                                else
                                {
                                    cell = sheet.GetRow(rowIndex).GetCell(14);
                                    cell.SetCellValue(item.compare_str);
                                }
                                break;
                        }
                    }
                }
                using (FileStream fileStream = File.Open(path+"\\汇总表.xlsx", FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fileStream);
                    fileStream.Close();
                }
                workbook.Close();
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        
    }
}
