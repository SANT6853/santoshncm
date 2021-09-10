using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for ExportToExcel
/// </summary>
public class ExportToExcel
{
   
    public ExportToExcel()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void excelImportstart(GridView gv, Action mymethod,Dictionary<string,string> Disvalue)
    {
        
        ExportToExcelMethod(gv, mymethod, Disvalue);

        
    }
    public void pdfImportstart(GridView gv, Action mymethod, Dictionary<string, string> Disvalue)
    {

        ExportToExcelMethod(gv, mymethod, Disvalue);


    }

#region Export Excel
    private static void ExportToExcelMethod( GridView gv, Action mymethod, Dictionary<string, string> Disvalue)
    {
        int count = 0;
        StringBuilder sb = new StringBuilder();
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        HttpContext.Current.Response.Charset = "";
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            try {

                hw.InnerWriter.Write("<div style='text-align:center;margin-bottom:10px;'><h3 style='color: #005529;'>" + Disvalue["HeaderName"].ToString() + "</h3></div>");

                mymethod();
                List<string> keylist = new List<string>();
                foreach (var item in Disvalue)
                {
                    if (item.Key.Contains("Hide"))
                    {
                        gv.Columns[Convert.ToInt32(item.Value)].Visible = false;
                    }
                    if (item.Key.Contains("Header")&& !item.Key.Contains("HeaderName") && !item.Key.Contains("Hide"))
                    {
                        count++;
                        keylist.Add(item.Key);
                    }
                }
                if (count > 1)
                {
                    sb.Append("<ul style=margin-bottom:10px;>");
                    foreach (var item in keylist)
                    {
                        sb.Append(string.Format("<li><b>{0}:</b>{1}</td></li>", item.Replace("Header", ""), Disvalue[item]));
                    }
                    
                    sb.Append("</ul>");
                }


                hw.InnerWriter.Write(sb.ToString());
                gv.HeaderRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gv.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gv.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gv.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                        List<Control> controls = new List<Control>();
                        foreach (Control control in cell.Controls)
                        {
                           
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    controls.Add(control);
                                    break;
                                case "TextBox":
                                    controls.Add(control);
                                    break;
                                case "LinkButton":
                                    controls.Add(control);
                                    break;
                                case "CheckBox":
                                    controls.Add(control);
                                    break;
                                case "RadioButton":
                                    controls.Add(control);
                                    break;
                            }
                        }
                        foreach (Control control in controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text==""?"N/A": (control as HyperLink).Text });
                                    break;
                                case "TextBox":
                                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                    break;
                                case "LinkButton":
                                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text == " " ? "N/A" : (control as LinkButton).Text });                                   
                                    break;
                                case "CheckBox":
                                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                    break;
                                case "RadioButton":
                                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                    break;
                            }
                            cell.Controls.Remove(control);
                           
                        }
                    }
                }
            }
            catch(Exception ex)
                {
                sb.Append(ex.Message.ToString());
                hw.InnerWriter.Write(sb.ToString());
            }
             
           



            gv.RenderControl(hw);
            
            string style = @"<style> .textmode { mso-number-format:\@; } table{border-collapse: collapse;}table, th, td {
                            border: 1px solid black;} </style>";
            HttpContext.Current.Response.Write(style);
            HttpContext.Current.Response.Output.Write(sw.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }
#endregion






}


