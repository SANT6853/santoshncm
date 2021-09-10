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

public partial class auth_Adminpanel_Message : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  Page.Master.FindControl("left").Visible = false;


        if (!Page.IsPostBack)
        {
            ImageButton1.Visible = true;


            try
            {
                if (!Request.QueryString["mid"].ToString().Equals(" "))
                {
                    if (Request.QueryString["mid"].ToString().Equals("1"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.AccountCreationSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Green;

                    }
                    else if (Request.QueryString["mid"].ToString().Equals("2"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.PasswordChangeSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;


                    }
                    else if (Request.QueryString["mid"].ToString().Equals("3"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.ReserveCreatedSuccessfully;
                        lblMsg.ForeColor = System.Drawing.Color.Green;

                    }
                    else if (Request.QueryString["mid"].ToString().Equals("4"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.VillageCreatedSuccessfully;
                        lblMsg.ForeColor = System.Drawing.Color.Green;

                    }
                    else if (Request.QueryString["mid"].ToString().Equals("5"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.FamilyCreatedSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Green;

                    }
                    else if (Request.QueryString["mid"].ToString().Equals("6"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.PasswordResetSuccess;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;


                    }
                    else if (Request.QueryString["mid"].ToString().Equals("7"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.InstallmentAdded;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("8"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.FDDetails;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("9"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.SellerDetail;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("10"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.UpdatedINST;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("11"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.CDP;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }

                    else if (Request.QueryString["mid"].ToString().Equals("12"))
                    {
                        lblMsg.Text = "Family Created Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }


                    else if (Request.QueryString["mid"].ToString().Equals("13"))
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.LegalFormAdded;
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("14"))
                    {
                        lblMsg.Text = "Relocation Site Inserted Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("15"))
                    {
                        lblMsg.Text = "NGO Details Inserted Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }

                    else if (Request.QueryString["mid"].ToString().Equals("16"))
                    {
                        lblMsg.Text = "Adhikar Patra Inserted Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("17"))
                    {
                        lblMsg.Text = "Relocation Details Inserted Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("18"))
                    {
                        lblMsg.Text = "NGO Details Inserted Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }
                    else if (Request.QueryString["mid"].ToString().Equals("19"))
                    {
                        lblMsg.Text = "Your Profile Updated Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        ImageButton1.Visible = false;
                    }

                }

                else
                {
                    Response.Redirect(ResolveUrl("~/Home.aspx"), true);
                }
            }
            catch (Exception e3)
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"), true);
            }
        }
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["mid"].ToString() != "")
            {
                if (Request.QueryString["mid"].ToString().Equals("1"))
                {

                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/NTCAUSER/UserRegistration.aspx"), false);
                }

                else if (Request.QueryString["mid"].ToString() == "3")
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/RESERVE/Reserve_Management_Add.aspx"), false);
                }
                else if (Request.QueryString["mid"].ToString().Equals("4"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/VILLAGE/Village_Management_Add.aspx"), false);

                }
                else if (Request.QueryString["mid"].ToString().Equals("5"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Add_Family.aspx"), false);

                }


            }
            else
            {
                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/User_Login.aspx"), true);
            }
        }
        catch (Exception e3)
        {

            Response.Redirect(ResolveUrl("~/AUTH/adminpanel/User_Login.aspx"), true);
        }

    }

    protected void ImageButton2_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["mid"].ToString() != "")
            {
                if (Request.QueryString["mid"].ToString().Equals("1"))
                {

                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/NTCAUSER/User_Management.aspx"), false);
                }
                else if (Request.QueryString["mid"].ToString().Equals("2"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/NTCAUSER/User_Change_Password.aspx"), false);

                }
                else if (Request.QueryString["mid"].ToString() == "3")
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/RESERVE/Reserve_Management.aspx"), false);
                }
                else if (Request.QueryString["mid"].ToString().Equals("4"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/VILLAGE/Village_Management.aspx"), false);

                }
                else if (Request.QueryString["mid"].ToString().Equals("5"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"), false);

                }
                else if (Request.QueryString["mid"].ToString().Equals("6"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/User_Login.aspx"), true);

                }
                else if (Request.QueryString["mid"].ToString().Equals("7"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"), false);

                }
                else if (Request.QueryString["mid"].ToString().Equals("8"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"), false);

                }

                else if (Request.QueryString["mid"].ToString().Equals("9"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"), false);

                }
                else if (Request.QueryString["mid"].ToString().Equals("10"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"), false);


                }

                else if (Request.QueryString["mid"].ToString().Equals("11"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Management.aspx"), false);


                }

                else if (Request.QueryString["mid"].ToString().Equals("12"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"), false);


                }
                else if (Request.QueryString["mid"].ToString().Equals("13"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/ReserveMap.aspx"), false);

                }

                else if (Request.QueryString["mid"].ToString().Equals("14"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/RELOCATIONSITE/Relocation_Management.aspx"), false);


                }
                else if (Request.QueryString["mid"].ToString().Equals("15"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/NGO/NGO_Management.aspx"), false);

                }
                else if (Request.QueryString["mid"].ToString().Equals("16"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"), false);


                }
                else if (Request.QueryString["mid"].ToString().Equals("17"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"), false);


                }
                else if (Request.QueryString["mid"].ToString().Equals("18"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/NGO1A/NGO_Management.aspx"), false);



                }

                else if (Request.QueryString["mid"].ToString().Equals("19"))
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/EditProfile.aspx"), false);



                }

            }
            else
            {
                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/User_Login.aspx"), true);
            }
        }
        catch (Exception e3)
        {

            Response.Redirect(ResolveUrl("~/AUTH/adminpanel/NTCAUSER/User_Login.aspx"), false);
        }
    }
}