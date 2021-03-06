using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;



public partial class auth_Adminpanel_District_Management_ViewTehshil : CrsfBase
{
    #region DAta declaration zone
    CommonDB comDB_Obj = new CommonDB();
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
            if (Session["UserType"].ToString().Equals("1"))
            {
                dvstate.Visible = true;
                FillState();
            }
            else
            {
                DisplayDistrictTehshil();
                bindDistrictTehshilName(1);
            }
        }
    }
    public void FillState()
    {
      // if (Page.IsValid)
      //  {

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
                            //
                            //{
                                DdlState.Items.Clear();
                                ddlDistrict.Items.Clear();
                                //  ddlselecttehsil.Items.Clear();
                                //  ddlselectgp.Items.Clear();
                                DataSet ds1 = new DataSet();
                                ds1 = null;
                                ds1 = comDB_Obj.GetState(0);

                                if (ds1.Tables[0].Rows.Count > 0)
                                {

                                    DdlState.DataSource = ds1;
                                    DdlState.DataTextField = "StateName";
                                    DdlState.DataValueField = "id";
                                    DdlState.DataBind();

                                    DdlState.Items.Insert(0, "Select State");
                                    ddlDistrict.Items.Add(new ListItem("No Record", "0"));
                                    // ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                                    // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                                }
                                else
                                {
                                    DdlState.Items.Add(new ListItem("No Record", "0"));
                                    ddlDistrict.Items.Add(new ListItem("No Record", "0"));
                                    // ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                                    // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                                }

                            //}
                            //catch (Exception e2)
                            //{
                            //    // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
                            //    // lblMsg.ForeColor = System.Drawing.Color.Red;
                            //}

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
    
    #region Function to bind district name in dropdownlist

    private void DisplayDistrictTehshil()
    {

        obj_userOB.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.DistrictListByUserAccess(obj_userOB);
        ddlDistrict.DataSource = p_Var.dSet;
        ddlDistrict.DataTextField = "DistName";
        ddlDistrict.DataValueField = "DistID";
        ddlDistrict.DataBind();
        if (LoginUsertype == 1)
        {
            ddlDistrict.Items.Insert(0, new ListItem("Select State", "0"));

        }


    }

    #endregion

    #region Function to display the tehshil in a gridview

    public void bindDistrictTehshilName(int pageIndex)
    {
        Label1.Text = "";

        districtTehshilObject.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);

       
        p_Var.dSet = districtTehshilBL.DisplayDistrictTehshil(districtTehshilObject, out p_Var.k);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
           
            divGrid.Visible = true;
            grdTehsil.DataSource = p_Var.dSet;
            grdTehsil.DataBind();
            p_Var.dSet = null;
           

        }
        else
        {
            divGrid.Visible = false;
            Label1.Text = "No record found!";

        }

        p_Var.Result = p_Var.k;
       
    }

    #endregion

    protected void grdTehsil_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if (Page.IsValid)
      //  {

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
                        int tehsilid = Convert.ToInt32(e.CommandArgument);
                        if (e.CommandName == "Delete")
                        {

                            int del = districtTehshilBL.DeleteTehshil(tehsilid, 2);
                            if (del > 0)
                            {
                                Session["msg"] = "Tehshil has been deleted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewTehshil.aspx";
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                Session["msg"] = "Tehshil has not been deleted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewTehshil.aspx";
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
    

    protected void grdTehsil_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdTehsil_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (ddlDistrict.SelectedItem.Text != "Select District")
        {
            bindDistrictTehshilName(1);
        }
        else
        {
            p_Var.dSet = null;
            grdTehsil.DataSource = p_Var.dSet;
            grdTehsil.DataBind();
        }
    }
    public void FillDistrict1()
    {
    
        // if (Page.IsValid)
      //  {

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
                        //try
                        //{
                            ddlDistrict.Items.Clear();
                            //ddlselecttehsil.Items.Clear();
                            // ddlselectgp.Items.Clear();
                            DataSet ds1 = new DataSet();
                            ds1 = null;
                            ds1 = comDB_Obj.GetDistrict1(Convert.ToInt32(DdlState.SelectedValue), 1);

                            if (ds1.Tables[0].Rows.Count > 0)
                            {

                                ddlDistrict.DataSource = ds1;
                                ddlDistrict.DataTextField = "DistName";
                                ddlDistrict.DataValueField = "DistID";
                                ddlDistrict.DataBind();

                                ddlDistrict.Items.Insert(0, "Select District");
                                //  ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                                // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                            }
                            else
                            {

                                ddlDistrict.Items.Add(new ListItem("No Record", "0"));
                                // ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                                //  ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                            }

                      // }
                        //catch (Exception e2)
                        //{
                        //    // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
                        //    //  lblMsg.ForeColor = System.Drawing.Color.Red;
                        //}
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
    
    protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlState.SelectedIndex != 0)
        {
            // lblmsgdt.Text = "";
            // FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
            //  FillTehsil();
            FillDistrict1();
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add(new ListItem("No Record", "0"));



        }
    }
}