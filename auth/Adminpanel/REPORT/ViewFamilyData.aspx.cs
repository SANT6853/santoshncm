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
public partial class auth_Adminpanel_REPORT_ViewFamilyData :System.Web.UI.Page

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
            if (Request.QueryString["F_ID"] != null)
            {
                lblMsg.Text = string.Empty;
                if (Request.QueryString["F_ID"].ToString() != "")
                {
                    LoadInfoFamilyId(Request.QueryString["villid"].ToString(), Request.QueryString["F_ID"].ToString());

                    if (RecordChk == true)
                    {
                        DisplayHeadDetail();
                        DisplayMemberDetail();
                        display_installment();
                    }
                    else
                    {
                        lblMsg.Text = "NO RECORD FOUND!";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Font.Bold = true;
                        lblMsg.Font.Size = 12;
                    }



                }
            }
        }

    }
    public void GridveiwNumericColumnCalculation_DisplayMemberDetail(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
       // decimal InstallmentAmountRs = 0;
        int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["NoBeneficiary"]);
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["FMLY_MEMB_ANUL_INCM"]);
           // InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["CDP_AMT_USD"]);
            
        }
        //sno
        gv_FamilyMemberDetail.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gv_FamilyMemberDetail.FooterRow.Cells[0].Font.Bold = true;
        gv_FamilyMemberDetail.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilyMemberDetail.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gv_FamilyMemberDetail.FooterRow.Cells[14].Text = Total + FamilyMember.ToString();
        gv_FamilyMemberDetail.FooterRow.Cells[14].Font.Bold = true;
        gv_FamilyMemberDetail.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilyMemberDetail.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        gv_FamilyMemberDetail.FooterRow.Cells[18].Text = Total + AllottedAmountRs.ToString();
        gv_FamilyMemberDetail.FooterRow.Cells[18].Font.Bold = true;
        gv_FamilyMemberDetail.FooterRow.Cells[18].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilyMemberDetail.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember

    }
    public void GridveiwNumericColumnCalculation_display_installment(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        // decimal InstallmentAmountRs = 0;
        int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["INST_ISCM_NO"]);
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["INST_ISCM_AMT"]);
            // InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["CDP_AMT_USD"]);

        }
        //sno
        gv1B.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gv1B.FooterRow.Cells[0].Font.Bold = true;
        gv1B.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv1B.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gv1B.FooterRow.Cells[4].Text = Total + FamilyMember.ToString();
        gv1B.FooterRow.Cells[4].Font.Bold = true;
        gv1B.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        gv1B.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        gv1B.FooterRow.Cells[6].Text = Total + AllottedAmountRs.ToString();
        gv1B.FooterRow.Cells[6].Font.Bold = true;
        gv1B.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        gv1B.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember

    }
    public void display_installment()
    {
        DataSet ds = FDb.Proc_Display_IIInstallment(Request.QueryString["F_ID"].ToString(), Request.QueryString["s_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            decimal total = 0;
            gv1B.Visible = true;
            gv1B.DataSource = ds.Tables[0].DefaultView;
            gv1B.DataBind();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                total = total + decimal.Parse(ds.Tables[0].Rows[i]["INST_ISCM_AMT"].ToString());
            }

            lbltotal.Text = "Total Amount:" + total.ToString();

            GridveiwNumericColumnCalculation_display_installment(ds);
            Btngv1B.Visible = true;
            BtnExportPdf2.Visible = true;
        }
        else
        {
            BtnExportPdf2.Visible = false;
            Btngv1B.Visible = false;
            gv1B.Visible = false;
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

            GridveiwNumericColumnCalculation_DisplayMemberDetail(ds);
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
       
        if (Request.QueryString["s_ID"].ToString() == "1")
        {
            Session["ctrl"] = PRINT;

            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=600px,scrollbars=1');</script>");

        }
        else if (Request.QueryString["s_ID"].ToString() == "3")
        {
            //Session["ctrl"] = panel2;

            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");


        }
        else if (Request.QueryString["s_ID"].ToString() == "2")
        {
            //Session["ctrl"] = panel3;

            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");


        }
    }

    public void LoadInfoFamilyId(string villid,string familyid)
    {
        DataSet ds = new DataSet();

        try
        {
            if (Request.QueryString["Resv"] != "NA")
            {
                ds = FDb.Proc_DisplayFamilyById(villid, familyid, Request.QueryString["Resv"].ToString());
            }
            else
            {
                 ds = FDb.Proc_DisplayFamilyById(villid, familyid, null);
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                RecordChk = true;
                //lblcode.Text = ds.Tables[0].Rows[0][4].ToString();
                lblname.Text = ds.Tables[0].Rows[0][3].ToString();
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
                DataSet ds1 = FDb.Display_Info_Family_By_FamilyID(Request.QueryString["F_ID"].ToString());
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lblreloplace.Text = ds1.Tables[0].Rows[0]["RELOATION_PLACE"].ToString();
                    Label75.Text = ds1.Tables[0].Rows[0]["SURVEYDATE"].ToString();
                    lblfamcode.Text = ds1.Tables[0].Rows[0]["FMLY_REG_CD"].ToString();
                    string schemeid = ds1.Tables[0].Rows[0]["SCHM_ID"].ToString();
                    if (schemeid == "1")
                    {

                        lblscheme.Text = "I";

                    }
                    else if (schemeid == "2")
                    {

                        lblscheme.Text = "I";

                    }
                    else if (schemeid == "3")
                    {

                        lblscheme.Text = "II";

                    }
                    else if (schemeid == "4")
                    {

                        lblscheme.Text = "No Option";

                    }

                    DataSet ds2 = FDb.GetGroupNameByGroupId(ds1.Tables[0].Rows[0]["GROUP_NM"].ToString());
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        lblgroupname.Text = ds2.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        lblgroupname.Text = "Not Applicable";
                    }

                    lblrashan.Text = ds1.Tables[0].Rows[0]["FMLY_VALID_ID_NO"].ToString();
                    lblvalididname.Text = ds1.Tables[0].Rows[0]["FMLY_VALID_ID_NAME"].ToString();

                    lblagri.Text = ds1.Tables[0].Rows[0]["FMLY_AGRI_LND"].ToString();
                    lblres.Text = ds1.Tables[0].Rows[0]["FMLY_RESI_LND"].ToString();
                    if (lblres.Text.Equals("0"))
                    {
                        lblresland.Text = "Not Applicable";
                    }
                    else
                    {
                        string status = ds1.Tables[0].Rows[0]["RESI_LND_STS"].ToString();
                        if (status == "1")
                        {
                            lblresland.Text = "Kachcha";
                        }
                        else if (status == "2")
                        {
                            lblresland.Text = "Pakka";
                        }
                        else
                        {
                            lblresland.Text = "Not Applicable";
                        }
                    }
                    lblwells.Text = ds1.Tables[0].Rows[0]["FMLY_WELLS"].ToString();
                    lbltrees.Text = ds1.Tables[0].Rows[0]["FMLY_TREES"].ToString();
                    lblotherassets.Text = ds1.Tables[0].Rows[0]["FMLY_OTHR_ASSETS"].ToString();
                    lblstock.Text = ds1.Tables[0].Rows[0]["FMLY_LIVESTOCK"].ToString();
                    lblcownbuff.Text = ds1.Tables[0].Rows[0]["NoCows"].ToString();
                    lblfamstatus0.Text = ds1.Tables[0].Rows[0]["NoBuffalo"].ToString();
                    lblfamstatus1.Text = ds1.Tables[0].Rows[0]["NoSheep"].ToString();
                    lblsheepngoat.Text = ds1.Tables[0].Rows[0]["NoGoat"].ToString();
                    lblotheranimal.Text = ds1.Tables[0].Rows[0]["FMLY_OTHER_ANML"].ToString();
                    lblcomments.Text = ds1.Tables[0].Rows[0]["COMMENT"].ToString();
                    bool familystatus = Convert.ToBoolean(ds1.Tables[0].Rows[0]["FMLY_STAT"]);
                    if (familystatus == true)
                    {
                        lblfamstatus.Text = "Relocated";
                    }
                    else
                    {
                        lblfamstatus.Text = "Non-Relocated";
                    }

                }//end second last
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
    public void DisplayHeadDetail()
    {
        DataSet ds = FDb.Proc_DisplayHeadDetail(Request.QueryString["F_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnPrint.Visible = true;
            LblHeadName.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_NM"].ToString();

            string filename = ds.Tables[0].Rows[0]["Photo"].ToString();
            if (filename != "")
            {//NoPhoto.png
                ImgPhoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + filename;
                hypfile.NavigateUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + filename;
                hypfile.Text = filename;
            }
            else
            {
                ImgPhoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + "NoPhoto.png";

            }
            //ImgPhoto.ImageAlign = ds.Tables[0].Rows[0][0].ToString();
            lblfathername.Text = ds.Tables[0].Rows[0]["FATHER_NM"].ToString();
            LblDOB.Text = ds.Tables[0].Rows[0]["DOB1"].ToString();
            lblage.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_AGE"].ToString();
            string sex = ds.Tables[0].Rows[0]["FMLY_MEMB_SEX"].ToString();
            if (sex == "1")
            {
                lblsex.Text = "Male";
            }
            else
            {
                lblsex.Text = "Female";
            }
            // lblsex.Text = ds.Tables[0].Rows[0][0].ToString();
            string cast = ds.Tables[0].Rows[0]["FMLY_MEMB_CAST"].ToString();
            if (cast == "1")
            {
                lblcast.Text = "OBC";
            }
            else if (cast == "2")
            {
                lblcast.Text = "SC";
            }
            else if (cast == "3")
            {
                lblcast.Text = "ST";
            }
            else
            {
                lblcast.Text = "OTHER";
            }
            // lblcast.Text = ds.Tables[0].Rows[0][0].ToString();
            if (ds.Tables[0].Rows[0]["FMLY_MEMB_CONT_NO"].ToString().Equals("0"))
            {
                lblcontact.Text = "";
            }
            else
            {
                lblcontact.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_CONT_NO"].ToString();

            }
            //  lblcontact.Text = ds.Tables[0].Rows[0][0].ToString();
            LblPancard.Text = ds.Tables[0].Rows[0]["PenCard"].ToString();
            LblVoterId.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_ID_NAME"].ToString();

            if (ds.Tables[0].Rows[0]["AdhaarCard"].ToString() != "")
            {
                string s = ds.Tables[0].Rows[0]["AdhaarCard"].ToString(); // example
                LblAdhaarCard.Text = s.Substring(s.Length - 4).PadLeft(s.Length, '*');

                //LblAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
            }
            //LblAnyOtherCardDetails.Text = ds.Tables[0].Rows[0]["IdentityCardPhoto"].ToString();
            string cardphoto = ds.Tables[0].Rows[0]["IdentityCardPhoto"].ToString();
            if (cardphoto != "")
            {
                Image1.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + cardphoto;
               // Image1.ImageUrl = cardphoto;
                Label1.Text = ds.Tables[0].Rows[0]["IdentityCardPhotoTitle"].ToString();

                HyperLink1.NavigateUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + cardphoto;
                HyperLink1.Text = cardphoto;
            }
            else
            {
                Image1.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + "NoPhoto.png";
            }


            LblTotalNumberOfBeneficiaries.Text = ds.Tables[0].Rows[0]["NoBeneficiary"].ToString();
            LblMaritalStatus.Text = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();
            LblEducation.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_EDU"].ToString();
            LblOccupation.Text = ds.Tables[0].Rows[0]["OCCUPATION_NAME"].ToString();
            LblAnnualIncome.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_ANUL_INCM"].ToString();
            LblBeneficiaryNameAddressMobileNo.Text = ds.Tables[0].Rows[0]["BankNameMobile"].ToString();
            LblBankPostalAccountNo.Text = ds.Tables[0].Rows[0]["BankPostAccountNo"].ToString();
            LblBankPostOfficeName.Text = ds.Tables[0].Rows[0]["BankPostOfficeName"].ToString();
            LblIFSCPinCode.Text = ds.Tables[0].Rows[0]["IFSC"].ToString();
            LblBankPostofficeAddress.Text = ds.Tables[0].Rows[0]["BankPostOfficeAdress"].ToString();
            if (ds.Tables[0].Rows[0]["AdhaarCard"].ToString() != "")
            {
                string s = ds.Tables[0].Rows[0]["AdhaarCard"].ToString(); // example
                LblAadharNo.Text = s.Substring(s.Length - 4).PadLeft(s.Length, '*');

                //LblAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
            }
           // LblAadharNo.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
            //----------
         
        }
        else
        {
            btnPrint.Visible = false;
        }


    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {

        if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
        {
            Response.Redirect("~/AUTH/adminpanel/REPORT/Familydata.aspx?ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString(), false);
        }
        else
        {
            Response.Redirect("~/AUTH/adminpanel/REPORT/Familydata.aspx");
        }

    }

    protected void Btngv1BExcelExport_Click(object sender, EventArgs e)
    {


        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            hw.WriteLine("<h1 style=\"text-align:center;\">Installment Details</h1>");
            hw.WriteLine("<br>");

            //To Export all pages

            gv1B.AllowPaging = false;
            display_installment();
            gv1B.HeaderRow.BackColor = System.Drawing.Color.Black;
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
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
               
    //}
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
          // if (Page.IsValid)
      // {

        //try
        //{

        //    string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
        //    string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

        //    if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
        //    {
        //        if (CurrentSessionId == hdnblank)
        //        {


        //            if (Page.IsValid)
        //            {

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
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
    }
    //            }
    //        }
    //    }

    //    catch
    //    {
    //        throw;
    //    }

    //    //}
    //}
    protected void BtnExportPdf2_Click(object sender, EventArgs e)
    {
          // if (Page.IsValid)
      // {

        ////try
        ////{

        ////    string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
        ////    string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

        ////    if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
        ////    {
        ////        if (CurrentSessionId == hdnblank)
        ////        {


        ////            if (Page.IsValid)
        ////            {


                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=MIS_Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);

                        hw.WriteLine("<h1 style=\"text-align:center;\">Installment Details</h1>");
                        hw.WriteLine("<br>");

                        //    gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
                        gv1B.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        gv1B.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        gv1B.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
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
    ////            }
    ////        }
    ////    }

    ////    catch
    ////    {
    ////        throw;
    ////    }

    ////    //}
    ////}
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
}