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

public partial class auth_Adminpanel_FAMILYDATA_View_FamilyMember_Details : System.Web.UI.Page
{
    FamilyDB FMLYDB_Obj = new FamilyDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        lblMsg.Text = "";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }
        //if (Session["UserRole"].ToString().Equals("3"))
        //{
        //    Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/RedirectPage.aspx"), false);
        //}
        if (!Page.IsPostBack)
        {
            if (Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID] != null && !Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID].Equals(""))
            {
                LoadInfoMemberId(Request.QueryString[WebConstant.QueryStringEnum.FamilyMemberID].ToString());
            }
        }
    }
    public void LoadInfoMemberId(string memberid)
    {
        try
        {
            FamilyMemberOB familyObject = new FamilyMemberOB();
            familyObject.MemberID = Convert.ToInt32(memberid);
            DataSet ds = FMLYDB_Obj.Display_All_Members_From_Original_Table(familyObject);
            if (ds.Tables[0].Rows.Count > 0)
            {
               // btnPrint.Visible = true;
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
                if (sex == "2")
                {
                    lblsex.Text = "Female";
                }
                if (sex == "3")
                {
                    lblsex.Text = "Transgender";
                }
                //else
                //{
                //    lblsex.Text = "Female";
                //}
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
              //  LblAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                string straadhar = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                //  string strshortaadhar = straadhar.Substring(0, 4);
                string strshortaadhar = straadhar.Substring(straadhar.Length - 4);


                LblAdhaarCard.Text = strshortaadhar.PadLeft(12, '*'); //ds.Tables[0].Rows[0]["AadharNo"].ToString();

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
              //  LblAadharNo.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();
                 string straadhar1 = ds.Tables[0].Rows[0]["AadharNo"].ToString();
                //  string strshortaadhar = straadhar.Substring(0, 4);
                string strshortaadhar1 = straadhar1.Substring(straadhar1.Length - 4);


                LblAadharNo.Text = strshortaadhar1.PadLeft(12, '*'); //ds.Tables[0].Rows[0]["AadharNo"].ToString();


                lblBenAddress.Text = ds.Tables[0].Rows[0]["BenAddress"].ToString();
                lblBenMobile.Text = ds.Tables[0].Rows[0]["BenMobile"].ToString();
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
}