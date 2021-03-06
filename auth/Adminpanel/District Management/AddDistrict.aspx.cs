using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;  


public partial class auth_Adminpanel_District_Management_AddDistrict : CrsfBase
{
    #region DAta declaration zone

    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    UserBL userBL = new UserBL();
    NtcaUserOB obj_userOB = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    DistrictTehshilBL districtTehshilBL=new DistrictTehshilBL();
    DistrictTehshilOB districtTehshilObject=new DistrictTehshilOB();
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
    protected void btnsave_Click(object sender, EventArgs e)
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


                        //if (Page.IsValid)
                        //{



                          if (Page.IsValid)
                            {

                                districtTehshilObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.insert);
                                districtTehshilObject.DistrictName = HttpUtility.HtmlEncode(txtDistrictName.Text);

                                districtTehshilObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
                                districtTehshilObject.IPAddress = miscellBL.IpAddress();
                                districtTehshilObject.UserID = Convert.ToInt16(LoginUserid);
                                int tempInsert = districtTehshilBL.insertUpdateDistrict(districtTehshilObject);

                                if (tempInsert > 0)
                                {
                                    Session["msg"] = "District has been submitted successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewDistrict.aspx";
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                                else
                                {
                                    Session["msg"] = "District has not been submitted successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewDistrict.aspx";
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                            }
                        //}
                    }
                }
           }
       

            catch
            {
                throw;
            }
       // }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
}