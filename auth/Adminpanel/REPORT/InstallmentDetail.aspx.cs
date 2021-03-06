using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NCM.DAL;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_InstallmentDetail : CrsfBase
{
    FamilyDB FMLYDB_Obj = new FamilyDB();
    common com_Obj = new common();
    public Int32 fam_id, villid;
    public Int32 scheme_id;
    double totalamount = 0;
    Relocation_InstallmentDB RI = new Relocation_InstallmentDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }
        fam_id = Int32.Parse(Request.QueryString["F_ID"].ToString());
        scheme_id = Int32.Parse(Request.QueryString["s_ID"].ToString());
        if (scheme_id == 3)
        {
            I.Visible = false;
            II.Visible = true;
        }
        else
        {
            I.Visible = true;
            II.Visible = false;
        }
        displayInstallment();

    }
    public void displayInstallment()
    {
       DataSet ds = RI.Proc_Display_InstallmentINFO(Request.QueryString["s_ID"].ToString(), Request.QueryString["F_ID"].ToString());
       DataSet ds1 = FMLYDB_Obj.Proc_Display_IIInstallment(Request.QueryString["F_ID"].ToString(), Request.QueryString["s_ID"].ToString());
       if (ds.Tables[0].Rows.Count > 0)
       {
         lblFamilyCode.Text = ds.Tables[0].Rows[0]["FMLY_REG_CD"].ToString();
        lblHeadName.Text = ds.Tables[0].Rows[0]["a"].ToString();
        lblholname.Text = ds.Tables[0].Rows[0]["INST_ISCM_HOLD_NM"].ToString();


          lblbank.Text = ds.Tables[0].Rows[0]["BANK_NAME"].ToString();
          lblbranch.Text = ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString();
          lblacc.Text = ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString();

          if (ds1.Tables[0].Rows.Count > 0)
          {
             gv1B.DataSource = ds1;
             gv1B.DataBind();
          }

       }
       for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
       {
          if (string.IsNullOrEmpty(ds.Tables[0].Rows[i]["INST_ISCM_AMT"].ToString()) == false)
          {
               totalamount = totalamount + Double.Parse(ds.Tables[0].Rows[i]["INST_ISCM_AMT"].ToString());
          }
             lblamount.Text = "Total Amount:" + totalamount.ToString();
       }
    }
               

    protected void BtnPdfExport_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{

        try
        {
            string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
            string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

            if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {
                    if (Page.IsValid)
                    {

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=MIS_Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        hw.WriteLine("<h1 style=\"text-align:center;\">Option I (Family Installment Details)</h1>");
                        hw.WriteLine("<br>");
                        hw.WriteLine("<h3 style='color:green;text-align:center;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>");
                        hw.WriteLine("<br>");
                        // gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
                        gv1B.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        gv1B.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        gv1B.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
                        gv1B.AllowPaging = true;
                        gv1B.DataBind();
                    }
                }
            }
        }
        
        catch
        {
            throw;
        }
    }

    protected void BtnExcelExport_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{

        try
        {
            string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
            string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

            if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {
                    if (Page.IsValid)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                        Response.Charset = "UTF-8";
                        Response.ContentType = "application/vnd.ms-excel";
                        using (StringWriter sw = new StringWriter())
                        {
                            HtmlTextWriter hw = new HtmlTextWriter(sw);
                            hw.WriteLine("<h1 style=\"text-align:center;\">Option I (Family Installment Details)</h1>");
                            hw.WriteLine("<br>");

                            gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";

                            //To Export all pages

                            gv1B.AllowPaging = false;
                            displayInstallment();
                            gv1B.HeaderRow.BackColor = System.Drawing.Color.Black;
                            gv1B.HeaderRow.ForeColor = System.Drawing.Color.White;
                            foreach (TableCell cell in gv1B.HeaderRow.Cells)
                            {
                                cell.BackColor = gv1B.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in gv1B.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = gv1B.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = gv1B.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            gv1B.RenderControl(hw);

                            //style to format numbers to string
                            //string style = @"<h2 style='color:green;'>Receipt & Challan Report From:" + " &nbsp;" + lblstatename.Text + "&nbsp;&nbsp; To&nbsp;" + lbldistrict.Text + "</h2>" + "</br>" + "<h2 style='color:green;'>Receipt & Challan Report From:" + " &nbsp;" + lblstatename.Text + "&nbsp;&nbsp; To&nbsp;" + lbldistrict.Text + "</h2>";
                            string style = @"<style> .textmode { } </style>";
                            Response.Write(style);
                            Response.Output.Write(sw.ToString());
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
            }
        }

        catch
        {
            throw;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
}