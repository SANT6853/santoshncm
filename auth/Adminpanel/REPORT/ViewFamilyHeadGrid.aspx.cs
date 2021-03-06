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
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_ViewFamilyHeadGrid : CrsfBase
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
                        //  display_installment();
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
    public void DisplayMemberDetail()
    {
        DataSet ds = FDb.Proc_DisplayFamilyMemberDetail(Request.QueryString["F_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {


        }
        else
        {

        }

    }
    public void LoadInfoFamilyId(string villid, string familyid)
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
                            lblresland.Text = "Kacha";
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
            //   btnPrint.Visible = true;
            LblHeadName.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_NM"].ToString();
            //----------------------------------
            string filename = ds.Tables[0].Rows[0]["Photo"].ToString();
            if (filename != "")
            {
                //
                //ImgPhoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + filename;
                //hypfile.NavigateUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + filename;
                ImgPhoto.Attributes.Add("width", "100");
                ImgPhoto.ImageUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + filename;
               // ImgPhoto.ImageUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + "NoPhoto.png";

                hypfile.NavigateUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + filename;
                hypfile.Text = filename;

            }
            else
            {
                ImgPhoto.Attributes.Add("width", "100");
                // ImgPhoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + "NoPhoto.png";
                ImgPhoto.ImageUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + "NoPhoto.png";
            }

            //-------------------------------
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
               // LblAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                string s = ds.Tables[0].Rows[0]["AdhaarCard"].ToString(); // example
                LblAdhaarCard.Text = s.Substring(s.Length - 4).PadLeft(s.Length, '*');
            }
            //LblAnyOtherCardDetails.Text = ds.Tables[0].Rows[0]["IdentityCardPhoto"].ToString();
            string cardphoto = ds.Tables[0].Rows[0]["IdentityCardPhoto"].ToString();
            //-------------------------------------
            if (cardphoto != "")
            {
                Image1.Attributes.Add("width", "100");
                // Image1.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + cardphoto;
                Image1.ImageUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + cardphoto;
                Label1.Text = ds.Tables[0].Rows[0]["IdentityCardPhotoTitle"].ToString();

                // HyperLink1.NavigateUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + cardphoto;
                HyperLink1.NavigateUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + cardphoto;
                HyperLink1.Text = cardphoto;
            }
            else
            {
                Image1.Attributes.Add("width", "100");
                //Image1.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + "NoPhoto.png";
                Image1.ImageUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + "NoPhoto.png";
            }

            //------------------------------------------
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
                // LblAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                string s = ds.Tables[0].Rows[0]["AdhaarCard"].ToString(); // example
                LblAadharNo.Text = s.Substring(s.Length - 4).PadLeft(s.Length, '*');
            }
           // LblAadharNo.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
            //----------

        }
        else
        {
            //   btnPrint.Visible = false;
        }


    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
      // {

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

                        string sUrlConsoldateStateName = Request.QueryString["ConsoldateStateName"].ToString();
                        string sUrlConsoldateMode = Request.QueryString["ConsoldateMode"].ToString();
                        string sUrlReserveID = Request.QueryString["ReserveID"].ToString();
                        string sUrlVillageID = Request.QueryString["VillageID"].ToString();
                        string sUrlStateID = Request.QueryString["StateID"].ToString();
                        string sUrlVillageName = Request.QueryString["VillageName"].ToString();
                        string sUrlReserveName = Request.QueryString["ReserveName"].ToString();
                        Response.Redirect("~/AUTH/adminpanel/REPORT/FamilyHead.aspx?&ConsoldateStateName=" + sUrlConsoldateStateName + "&ConsoldateMode=" + sUrlConsoldateMode + "&ReserveID=" + sUrlReserveID + "&VillageID=" + sUrlVillageID + "&StateID=" + sUrlStateID + "&VillageName=" + sUrlVillageName + "&ReserveName=" + sUrlVillageName);
                        //if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                        //{
                        //    Response.Redirect("~/AUTH/adminpanel/REPORT/Familydata.aspx?ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString(), false);
                        //}
                        //else
                        //{
                        //    Response.Redirect("~/AUTH/adminpanel/REPORT/Familydata.aspx");
                        //}
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
    }
    protected void BtnPdfHeadDetails_Click(object sender, EventArgs e)
    {
          // if (Page.IsValid)
      // {

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
                        Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        hw.WriteLine("<h1 style=\"text-align:center;\">Familiy Details</h1>");
                        hw.WriteLine("<br>");

                        PnlFamiyDetails.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 100f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();

                        //using (StringWriter sw = new StringWriter())
                        //{
                        //    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        //    {
                        //        hw.WriteLine("<h1 style=\"text-align:center;\">Family Details</h1>");
                        //        hw.WriteLine("<br>");

                        //        panel4.RenderControl(hw);


                        //        StringReader sr = new StringReader(sw.ToString());
                        //        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                        //        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        //        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        //        pdfDoc.Open();

                        //        htmlparser.Parse(sr);
                        //        pdfDoc.Close();
                        //        Response.ContentType = "application/pdf";
                        //        Response.AddHeader("content-disposition", "attachment;filename=FamilyDetailsReport.pdf");
                        //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        //        Response.Write(pdfDoc);
                        //        Response.End();
                        //    }
                        //}

                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }
    protected void btn_print_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
      // {

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

                           // GridView GridView1 = new GridView();

                           StringWriter sw = new StringWriter();
                           HtmlTextWriter hw = new HtmlTextWriter(sw);
                           dvall.RenderControl(hw);
                           string gridHTML = sw.ToString().Replace("\"", "'")
                               .Replace(System.Environment.NewLine, "");
                           StringBuilder sb = new StringBuilder();
                           sb.Append("<script type = 'text/javascript'>");
                           sb.Append("window.onload = new function(){");
                           sb.Append("var printWin = window.open('', '', 'left=0");
                           sb.Append(",top=0,width=1000,height=600,status=0');");
                           sb.Append("printWin.document.write(\"");
                           sb.Append("<div style='text-align:center'><font size=5px > ");
                           //  sb.Append(" Fmaily details ");
                           sb.Append("</font></div>");
                           sb.Append(gridHTML);
                           sb.Append("<div>");
                           //  sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Label1.Text + "&nbsp; &nbsp;");
                           //  sb.Append("<strong>" + lblamttotal.Text + "</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                           // sb.Append(Label2.Text + "&nbsp; &nbsp;");
                           // sb.Append("<strong>" + lblamtused.Text + "</strong>");


                           sb.Append("</div>");
                           sb.Append("\");");
                           sb.Append("printWin.document.close();");
                           sb.Append("printWin.focus();");
                           sb.Append("printWin.print();");
                           sb.Append("printWin.close();};");
                           sb.Append("</script>");
                           ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
                       }
                   }
               }
           }

        catch
        {
            throw;
        }

        //}
    }

    
    protected void BtnFamilyImagesHdtails_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
      // {

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
                        hypfile.Visible = false;
                        HyperLink1.Visible = false;
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        hw.WriteLine("<h1 style=\"text-align:center;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Familiy Head Details</h1>");
                        hw.WriteLine("<br>");

                        PnlHeadDetails.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 100f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
                    }
                }
            }
        }
        catch
        {
            throw;
        }

        //}
    }
}