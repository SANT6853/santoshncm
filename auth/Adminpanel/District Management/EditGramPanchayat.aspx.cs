using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;


public partial class auth_Adminpanel_District_Management_EditGramPanchayat : CrsfBase
{
    #region DAta declaration zone

    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    UserBL userBL = new UserBL();
    NtcaUserOB obj_userOB = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    DistrictTehshilBL districtTehshilBL = new DistrictTehshilBL();
    DistrictTehshilOB districtTehshilObject = new DistrictTehshilOB();
    string LoginUserid;
    int LoginUsertype;

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/auth/Adminpanel/login.aspx");
        }
        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;

        LoginUserid = m.Id;
        LoginUsertype = m.UserType;
        if (!IsPostBack)
        {

            DisplayDistrict();
            displayGrampanchayatinUpdateMode();

        }
    }

    #region Function to bind state name in dropdownlist

    private void DisplayDistrict()
    {

        obj_userOB.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.DistrictListByUserAccess(obj_userOB);

        ddlDistrict.DataSource = p_Var.dSet;
        ddlDistrict.DataTextField = "DistName";
        ddlDistrict.DataValueField = "DistID";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));



    }

    #endregion

    #region Function to display the tehshil in a gridview

    public void bindDistrictTehshilName(int pageIndex)
    {

        districtTehshilObject.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);


        p_Var.dSetChildData = districtTehshilBL.DisplayDistrictTehshil(districtTehshilObject, out p_Var.k);
        if (p_Var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            ddlTehshil.DataSource = p_Var.dSetChildData;
            ddlTehshil.DataTextField = "Tehsil_Name";
            ddlTehshil.DataValueField = "Tehsil";
            ddlTehshil.DataBind();
            ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
            txtGramPanchayatName.Enabled = true;
        }
        else
        {
            ddlTehshil.DataSource = p_Var.dSetChildData;
            ddlTehshil.DataTextField = "Tehsil_Name";
            ddlTehshil.DataValueField = "Tehsil";
            ddlTehshil.DataBind();
            ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
            txtGramPanchayatName.Enabled = false;
        }
    }

    #endregion

    #region Function to display record in edit mode

    public void displayGrampanchayatinUpdateMode()
    {
        if (Page.IsValid)
        {

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
                            districtTehshilObject.GrampanchayatID = Convert.ToInt32(Request.QueryString["id"]);
                            p_Var.dSet = districtTehshilBL.DisplayDistrictTehshilGramPanchayatInEdit(districtTehshilObject);
                            if (p_Var.dSet.Tables[0].Rows.Count > 0)
                            {
                                txtGramPanchayatName.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["GramPanchayatName"].ToString());

                                ddlDistrict.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["DistrictID"].ToString();
                                bindDistrictTehshilName(1);
                                ddlTehshil.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["Tehsilid"].ToString();
                                ddlTehshil.Enabled = false;
                                ddlDistrict.Enabled = false;
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
    }
    

    #endregion

    protected void btnsave_Click(object sender, EventArgs e)
    {
         if (Page.IsValid)
         {

            try
            {

                string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
                string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);

                if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
                {
                    if (CurrentSessionId == hdnblank)
                    {


                        //if (Page.IsValid)
                        //  {
                        if (Page.IsValid)
                        {
                            districtTehshilObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.update);
                            districtTehshilObject.GrampanchayatID = Convert.ToInt32(Request.QueryString["id"]);
                            districtTehshilObject.Grampanchayatname = HttpUtility.HtmlEncode(txtGramPanchayatName.Text);
                            districtTehshilObject.TehsilID = Convert.ToInt16(ddlTehshil.SelectedValue);
                            districtTehshilObject.DistrictID = Convert.ToInt16(ddlDistrict.SelectedValue);
                            districtTehshilObject.IPAddress = miscellBL.IpAddress();
                            districtTehshilObject.UserID = Convert.ToInt16(LoginUserid);
                            int tempInsert = districtTehshilBL.insertUpdateTehshilGrampanchayat(districtTehshilObject);

                            if (tempInsert > 0)
                            {
                                Session["msg"] = "Grampanchayat has been submitted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewGramPanchayat.aspx";
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Grampanchayat has not been submitted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewGramPanchayat.aspx";
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                        }
                        // }

                    }
                }


            }
            catch
            {
                throw;
            }

        }
    }
        
    

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/District Management/ViewGramPanchayat.aspx", false);
    }
}