using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;



public partial class auth_Adminpanel_District_Management_ViewGramPanchayat : CrsfBase
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
                ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
                //bindDistrictTehshilName(1);
            }

        }
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
       
            ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));

       


    }

    #endregion

    #region Function to display the tehshil in a gridview

    public void bindDistrictTehshilName(int pageIndex)
    {

        districtTehshilObject.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);


        p_Var.dSet = districtTehshilBL.DisplayDistrictTehshil(districtTehshilObject, out p_Var.k);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlTehshil.DataSource = p_Var.dSet;
            ddlTehshil.DataTextField = "Tehsil_Name";
            ddlTehshil.DataValueField = "Tehsil";
            ddlTehshil.DataBind();
            ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
        }
        else
        {
            ddlTehshil.DataSource = p_Var.dSet;
            ddlTehshil.DataTextField = "Tehsil_Name";
            ddlTehshil.DataValueField = "Tehsil";
            ddlTehshil.DataBind();
            ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
        }
    }

    #endregion

    #region Function to display the tehshil in a gridview

    public void bindDistrictTehshilGrampanchayatName(int pageIndex)
    {

       
        districtTehshilObject.TehsilID = Convert.ToInt32(ddlTehshil.SelectedValue);
        //districtTehshilObject.PageIndex = pageIndex;
        //districtTehshilObject.PageSize = Convert.ToInt16(ddlPageSize.SelectedValue);
        //districtTehshilObject.LangID = Convert.ToInt32(ddlLanguage.SelectedValue);
        p_Var.dSet = districtTehshilBL.DisplayDistrictTehshilGrampanchayat(districtTehshilObject, out p_Var.k);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            //rptPager.Visible = true;
            //ddlPageSize.Visible = true;
            //lblPageSize.Visible = true;
            //grdCategory.Visible = true;
            //spanPazeSize.Visible = true;
            divGrid.Visible = true;
            grdGrampanchayat.DataSource = p_Var.dSet;
            grdGrampanchayat.DataBind();
            p_Var.dSet = null;
            //code for checking category is present in temp table or not

            //if (Convert.ToInt16(ddlStatus.SelectedValue) == Convert.ToInt16(Module_ID_Enum.Module_Status_ID.Approved))
            //{
            //    grdCategory.Columns[0].Visible = false;
            //    foreach (GridViewRow row in grdCategory.Rows)
            //    {
            //        Image imgedit = (Image)row.FindControl("imgEdit");
            //        Image imgnotedit = (Image)row.FindControl("imgnotedit");
            //        Label lblMCategoryID = (Label)row.FindControl("lblMCategory_ID");
            //        districtTehshilObject.MCategoryID = Convert.ToInt16(lblMCategoryID.Text);

            //    }
            //}

            //end


        }
        else
        {
            divGrid.Visible = false;
            //rptPager.Visible = false;
            //ddlPageSize.Visible = false;
            //lblPageSize.Visible = false;

        }

        p_Var.Result = p_Var.k;
        //if (p_Var.Result > Convert.ToInt16(ddlPageSize.SelectedValue))
        //{
        //    pagingBL.Paging_Show(p_Var.Result, pageIndex, ddlPageSize, rptPager);
        //    rptPager.Visible = true;
        //}
        //else
        //{
        //    rptPager.Visible = false;
        //}

    }

    #endregion

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        divGrid.Visible = false;
        bindDistrictTehshilName(1);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Lblmsg.Text = "";
        if (ddlDistrict.SelectedValue == "0" || ddlTehshil.SelectedValue == "0")
        {
            Lblmsg.Text = "Please select both values";
            Lblmsg.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            bindDistrictTehshilGrampanchayatName(1);
        }
    }

    protected void grdGrampanchayat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName == "Delete")
        {

            int del = districtTehshilBL.DeleteGramPanchyat(id, 3);
            if (del > 0)
            {
                Session["msg"] = "GramPanchayat has been deleted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewGramPanchayat.aspx";
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
            else
            {
                Session["msg"] = "GramPanchayat has not been deleted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewGramPanchayat.aspx";
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
        }
    }

    protected void grdGrampanchayat_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdGrampanchayat_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    public void FillState()
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
                            // try
                            // {
                                DdlState.Items.Clear();
                                ddlDistrict.Items.Clear();
                                ddlTehshil.Items.Clear();
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
                                    ddlTehshil.Items.Add(new ListItem("No Record", "0"));
                                   // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                                }
                                 else
                                {
                                    DdlState.Items.Add(new ListItem("No Record", "0"));
                                    ddlDistrict.Items.Add(new ListItem("No Record", "0"));
                                    ddlTehshil.Items.Add(new ListItem("No Record", "0"));
                                    //ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                                }

                            //}
                            //catch (Exception e2)
                            //{
                               // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
                               // lblMsg.ForeColor = System.Drawing.Color.Red;
                            //}
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
    
    public void FillDistrict1()
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
                        // try
                        // {  
                        try
                        {
                            ddlDistrict.Items.Clear();
                            ddlTehshil.Items.Clear();
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
                                ddlTehshil.Items.Add(new ListItem("No Record", "0"));
                                //ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                            }
                            else
                            {

                                ddlDistrict.Items.Add(new ListItem("No Record", "0"));
                                ddlTehshil.Items.Add(new ListItem("No Record", "0"));
                                // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                            }

                        }
                        catch (Exception e2)
                        {
                            //  lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
                            // lblMsg.ForeColor = System.Drawing.Color.Red;
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
    
    protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlState.SelectedIndex != 0)
        {
            //lblmsgdt.Text = "";
            // FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
            //  FillTehsil();
            FillDistrict1();
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add(new ListItem("No Record", "0"));

            ddlTehshil.Items.Clear();
            ddlTehshil.Items.Add(new ListItem("No Record", "0"));

           // ddlselectgp.Items.Clear();
           // ddlselectgp.Items.Add(new ListItem("No Record", "0"));

        }
    }
}