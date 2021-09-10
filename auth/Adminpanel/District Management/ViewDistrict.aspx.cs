using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_District_Management_ViewDistrict : CrsfBase
{
    #region Data declaration zone
    Project_Variables p_Var = new Project_Variables();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    DistrictTehshilOB districtTehshilObject =new DistrictTehshilOB();
    DistrictTehshilBL districtTehshilBL=new DistrictTehshilBL();
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
            bindDistrictName(1);
            if (Session["UserType"].ToString() == "4")
            {
                ddlState.Enabled = false;
            }
        }
    }

    #region Function to bind state name in dropdownlist

    private void DisplayStateName()
    {

        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(objntcauser);
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

    #region Function to display the category in a gridview

    public void bindDistrictName(int pageIndex)
    {
            
            districtTehshilObject.StateID = Convert.ToInt32(ddlState.SelectedValue);
           
            p_Var.dSet = districtTehshilBL.DisplayDistrict(districtTehshilObject, out p_Var.k);
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
               
                divGrid.Visible = true;
            grdDistrict.DataSource = p_Var.dSet;
            grdDistrict.DataBind();
                p_Var.dSet = null;
               

              
            }
            else
            {
                
             
            }
       
        p_Var.Result = p_Var.k;
       
       
    }

    #endregion

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindDistrictName(1);
    }

    protected void grdDistrict_RowCommand(object sender, GridViewCommandEventArgs e)
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
                            int districID = Convert.ToInt32(e.CommandArgument);
                            if (e.CommandName == "Delete")
                            {

                                int del = districtTehshilBL.DeleteDistrict(districID, 1);
                                if (del > 0)
                                {
                                    Session["msg"] = "District has been deleted successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewDistrict.aspx";
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                                else
                                {
                                    Session["msg"] = "District has not been deleted successfully.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewDistrict.aspx";
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                            }


                        }
                    }
                }
            }
            catch
            {
                throw;
            }
       // }
    }
    

        
    

    protected void grdDistrict_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
      
       
            //districtTehshilBL.DeleteDistrict(id,1);

           
        
    }

    protected void grdDistrict_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
    }
}