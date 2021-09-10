using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_District_Management_AddGramPanchayat : CrsfBase
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
    CommonDB comDB_Obj = new CommonDB();
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
                DisplayDistrict();
                ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
                ddlTehshil.Enabled = false;
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
                            try
                            {
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
                                    // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                                }

                            }
                            catch (Exception e2)
                            {
                                // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
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
       // }
    }
    #region Function to bind state name in dropdownlist

    private void DisplayDistrictTehshilGrampanchayat()
    {

        obj_userOB.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.DistrictListByUserAccess(obj_userOB);
        ddlTehshil.DataSource = p_Var.dSet;
        ddlTehshil.DataTextField = "DistName";
        ddlTehshil.DataValueField = "DistID";
        ddlTehshil.DataBind();
       
            ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
           
      


    }

    #endregion

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

      
        p_Var.dSet = districtTehshilBL.DisplayDistrictTehshil(districtTehshilObject, out p_Var.k);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlTehshil.DataSource = p_Var.dSet;
            ddlTehshil.DataTextField = "Tehsil_Name";
            ddlTehshil.DataValueField = "Tehsil";
            ddlTehshil.DataBind();
            ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
            txtGramPanchayatName.Enabled = true;
        }
        else
        {
            ddlTehshil.DataSource = p_Var.dSet;
            ddlTehshil.DataTextField = "Tehsil_Name";
            ddlTehshil.DataValueField = "Tehsil";
            ddlTehshil.DataBind();
            ddlTehshil.Items.Insert(0, new ListItem("Select Tehshil", "0"));
            txtGramPanchayatName.Enabled = false;
        }
    }

    #endregion



    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTehshil.Enabled = true;
        bindDistrictTehshilName(1);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    bool check()
    {
        Label1.Text = "";
        if (ddlDistrict.SelectedItem.Text == "Select District")
        {
            Label1.Text = "Please select District!";
            return false;
        }
        if (ddlTehshil.SelectedItem.Text == "Select Tehshil")
        {
            Label1.Text = "Please select Tehshil!";
            return false;

        }
        return true;
    }
    protected void btnsave_Click(object sender, EventArgs e)
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
                        // {
                            if (Page.IsValid)
                            {
                                bool chk = check();
                                if (chk == true)
                                {
                                    districtTehshilObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.insert);
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
                            }
                          //}
       
                    }
                }
        }
         catch
        {
           throw;
        }
    }

    

    public void FillDistrict1()
    {
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
                // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }
            else
            {

                ddlDistrict.Items.Add(new ListItem("No Record", "0"));
                ddlTehshil.Items.Add(new ListItem("No Record", "0"));
                //  ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            //  lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlState.SelectedIndex != 0)
        {
           // lblmsgdt.Text = "";
           // FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
           // FillTehsil();
            FillDistrict1();
        }
        else
        {
            ddlTehshil.Items.Clear();
            ddlTehshil.Items.Add(new ListItem("No Record", "0"));
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add(new ListItem("No Record", "0"));



        }
    }
}