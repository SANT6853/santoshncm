using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class auth_Adminpanel_FamiliyData_ViewFamilyMemberDetails : System.Web.UI.Page
{
    Relocation_InstallmentDB RI = new Relocation_InstallmentDB();
    FamilyDB FDb = new FamilyDB();

    static public bool incen = false, cons = false, sett = false;
    static public bool FD = false;
    static public bool RecordChk = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "FAMILY REPORT :NTCA";
        if (Session["User_Id"] == null || Session["User_Id"].ToString() == "")
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }

        if (!IsPostBack)
        {
            sett = true;
            cons = true;
            incen = true;
            FD = true;
            if (Request.QueryString["F_ID"] != null || Request.QueryString["vill_id"] != null)
            {
                DisplayMemberDetail();
                LoadInfoFamilyId(Request.QueryString["vill_id"], Request.QueryString["F_ID"]);
                if (Request.QueryString["F_ID"].ToString() != "")
                {
                    
                    
                    if (RecordChk == true)
                    {

                        

                    }
                    else
                    {
                        //lblMsg.Text = "NO RECORD FOUND!";
                        //lblMsg.ForeColor = System.Drawing.Color.Red;
                        //lblMsg.Font.Bold = true;
                        //lblMsg.Font.Size = 12;
                    }



                }
            }
        }

    }
 
    public void DisplayMemberDetail()
    {
        DataSet ds = FDb.Proc_DisplayFamilyMemberDetail(Request.QueryString["F_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {

            gv_FamilyMemberDetail.Visible = true;

            gv_FamilyMemberDetail.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_FamilyMemberDetail.DataBind();

          
            BtnExcelExport.Visible = true;
            BtnExcelExport.Visible = true;
            BtnPDFexport.Visible = true;
        }
        else
        {
            BtnExcelExport.Visible = false;
            BtnPDFexport.Visible = false;
            BtnExcelExport.Visible = false;
        }

    }

   
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["ctrl"] = PRINT;

        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=600px,scrollbars=1');</script>");



    }
   
    protected void ImageButton1_Click(object sender, EventArgs e)       
    {
        
        Response.Redirect("~/AUTH/adminpanel/FamilyData/Family_Management.aspx?id="+Request.QueryString["F_ID"]);
        
        
    }
    
    //Btngv1BExcelExport_Click

    protected void BtnExcelExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            hw.WriteLine("<h1 style=\"text-align:center;\">Family Member Details</h1>");
            hw.WriteLine("<br>");

            //To Export all pages

            gv_FamilyMemberDetail.AllowPaging = false;
            DisplayMemberDetail();
            gv_FamilyMemberDetail.HeaderRow.BackColor = System.Drawing.Color.Black;
            foreach (TableCell cell in gv_FamilyMemberDetail.HeaderRow.Cells)
            {
                cell.BackColor = gv_FamilyMemberDetail.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gv_FamilyMemberDetail.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gv_FamilyMemberDetail.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gv_FamilyMemberDetail.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gv_FamilyMemberDetail.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
  
    protected void BtnPDFexport_Click(object sender, EventArgs e)
    {

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        hw.WriteLine("<h1 style=\"text-align:center;\">Family Member Details</h1>");
        hw.WriteLine("<br>");
        gv_FamilyMemberDetail.HeaderStyle.ForeColor = System.Drawing.Color.White;
        gv_FamilyMemberDetail.HeaderStyle.BackColor = System.Drawing.Color.Green;
        this.gv_FamilyMemberDetail.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 100f, 0.0f);
       // Document pdfDoc = new Document(PageSize.A3, 1f, 1f, 100f, 0.0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }

  
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void gv_FamilyMemberDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblLblAdharCard = (Label)e.Row.FindControl("LblAdharCard");
            Label lblLblAdharCardlast = (Label)e.Row.FindControl("LblAdharCardLast");
            if (lblLblAdharCard.Text != "")
            {
                string s = lblLblAdharCard.Text; // example
                lblLblAdharCard.Text = s.Substring(s.Length - 4).PadLeft(s.Length, '*');

            }
            if (lblLblAdharCardlast.Text != "")
            {
                string s = lblLblAdharCardlast.Text; // example
                lblLblAdharCardlast.Text = s.Substring(s.Length - 4).PadLeft(s.Length, '*');

            }
        }
    }

    public void LoadInfoFamilyId(string villid, string familyid)
    {
        DataSet ds = new DataSet();

        try
        {
           
                ds = FDb.Proc_DisplayFamilyById(villid, familyid, null);
          
            if (ds.Tables[0].Rows.Count > 0)
            {
                RecordChk = true;
                //lblcode.Text = ds.Tables[0].Rows[0][4].ToString();
                lblname.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                if (Session["UserType"].ToString().Equals("1"))
                {
                    lblstateName.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
                }
                else
                {
                    lblstateName.Text = Session["sStateName"].ToString();
                }
                lbldtname.Text = ds.Tables[0].Rows[0]["DistName"].ToString();
                if (Session["UserType"].ToString().Equals("1"))
                {
                    lblrsname.Text = ds.Tables[0].Rows[0]["TigerReserveName"].ToString();
                }
                else
                {
                    lblrsname.Text = Session["sTigerReserveName"].ToString();
                }
                lbltehsil.Text = ds.Tables[0].Rows[0]["Tehsil_Name"].ToString();
                lblgp.Text = ds.Tables[0].Rows[0]["GramPanchayatName"].ToString();
               
            }//end of main
            else
            {
                RecordChk = false;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }
}