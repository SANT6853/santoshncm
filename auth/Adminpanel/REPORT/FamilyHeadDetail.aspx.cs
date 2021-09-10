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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_FamilyHeadDetail : CrsfBase
{
    FamilyDB FDB = new FamilyDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "FAMILY HEAD DETAIL REPORT : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["F_ID"] != null)
            {

                if (Request.QueryString["F_ID"].ToString() != "")
                {

                    DisplayHeadDetail();
                }
            }

        }

    }
    public void DisplayHeadDetail()
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

                        DataSet ds = FDB.Proc_DisplayHeadDetail(Request.QueryString["F_ID"].ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            btnPrint.Visible = true;
                            //-----------
                            LblHeadName.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_NM"].ToString();

                            string filename = ds.Tables[0].Rows[0]["Photo"].ToString();
                            if (filename != "")
                            {//NoPhoto.pnghttp://45.115.99.199/ntca_mis
                             //ImgPhoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + filename;

                                ImgPhoto.Attributes.Add("width", "100");
                                ImgPhoto.ImageUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + filename;
                                //ImgPhoto.ImageUrl = "http://localhost:2429/WriteReadData/Familyaadhar/" + filename;

                            }
                            else
                            {
                                ImgPhoto.Attributes.Add("width", "100");
                                //ImgPhoto.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + "NoPhoto.png";
                                ImgPhoto.ImageUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + "NoPhoto.png";
                                // ImgPhoto.ImageUrl = "http://localhost:2429/WriteReadData/Familyaadhar/" + "NoPhoto.png";

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
                                // LblAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                                string s = ds.Tables[0].Rows[0]["AdhaarCard"].ToString(); // example
                                LblAdhaarCard.Text = s.Substring(s.Length - 3).PadLeft(s.Length, '*');
                            }

                            //LblAnyOtherCardDetails.Text = ds.Tables[0].Rows[0]["IdentityCardPhoto"].ToString();
                            string cardphoto = ds.Tables[0].Rows[0]["IdentityCardPhoto"].ToString();
                            if (cardphoto != "")
                            {
                                Image1.Attributes.Add("width", "100");
                                // Image1.ImageUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + cardphoto;
                                // Image1.ImageUrl = cardphoto;
                                Image1.ImageUrl = "http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/" + cardphoto;
                                //Image1.ImageUrl = "http://localhost:2429/WriteReadData/Familyaadhar/" + cardphoto;
                                Label1.Text = ds.Tables[0].Rows[0]["IdentityCardPhotoTitle"].ToString();
                            }
                            else
                            {

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
                            if (ds.Tables[0].Rows[0]["AadharNo"].ToString() != "")
                            {
                                // LblAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                                string s = ds.Tables[0].Rows[0]["AadharNo"].ToString(); // example
                                LblAadharNo.Text = s.Substring(s.Length - 3).PadLeft(s.Length, '*');
                            }
                            // LblAadharNo.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
                            //----------



                        }
                        else
                        {
                            btnPrint.Visible = false;
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


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["ctrl"] = panel1;
        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=600px,scrollbars=1');</script>");
    }
  
    protected void BtnPdfExport_Click1(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Report.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.WriteLine("<h1 style=\"text-align:center;\">Familiy Head Details</h1>");
        hw.WriteLine("<br>");

        tbpanel.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();



        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        htmlWrite.WriteLine("<h1 style=\"text-align:center;\">Familiy Head Details</h1>");
        htmlWrite.WriteLine("<br>");
        tbpanel.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();  
       

    }
}