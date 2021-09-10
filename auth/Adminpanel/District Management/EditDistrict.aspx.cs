using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;


public partial class auth_Adminpanel_District_Management_EditDistrict : CrsfBase
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
            DisplayStateName();
            display_District_in_UpdateMode();
            if (Session["UserType"].ToString() == "4")
            {
                ddlState.Enabled = false;
            }
        }
    }

    #region Function to bind state name in dropdownlist

    private void DisplayStateName()
    {

        obj_userOB.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(obj_userOB);
        ddlState.DataSource = p_Var.dSet;
        ddlState.DataTextField = "StateName";
        ddlState.DataValueField = "id";
        ddlState.DataBind();
        if (LoginUsertype == 1)
        {
            ddlState.Items.Insert(0, new ListItem("Select State", "0"));

        }


    }

    #endregion

    #region Function to display record in edit mode

    public void display_District_in_UpdateMode()
    {
        districtTehshilObject.DistrictID = Convert.ToInt32(Request.QueryString["id"]);
        p_Var.dSet = districtTehshilBL.DisplayDistrictInEdit(districtTehshilObject);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            txtDistrictName.Text = HttpUtility.HtmlDecode(p_Var.dSet.Tables[0].Rows[0]["DistName"].ToString());
          
            ddlState.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["StateID"].ToString();
           

        }
    }

    #endregion
    protected void btnsave_Click(object sender, EventArgs e)
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

                            districtTehshilObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.update);
                            districtTehshilObject.DistrictName = HttpUtility.HtmlEncode(txtDistrictName.Text);
                            districtTehshilObject.DistrictID = Convert.ToInt32(Request.QueryString["id"]);
                            districtTehshilObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                            districtTehshilObject.IPAddress = miscellBL.IpAddress();
                            districtTehshilObject.UserID = Convert.ToInt16(LoginUserid);
                            int tempInsert = districtTehshilBL.insertUpdateDistrict(districtTehshilObject);

                            if (tempInsert > 0)
                            {
                                Session["msg"] = "District has been udpated successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewDistrict.aspx";
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "District has not been udpated successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewDistrict.aspx";
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                        }

                    }
                }
            }
            catch
            {
                throw;
            }
      //  }
    }
    
    
    

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/District Management/ViewDistrict.aspx", false);
    }
}