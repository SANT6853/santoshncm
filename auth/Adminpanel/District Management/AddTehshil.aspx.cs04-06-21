using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_District_Management_AddTehshil : System.Web.UI.Page
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
                DisplayDistrict();
            }

        }
    }
    public void FillState()
    {
        try
        {
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

        }
        catch (Exception e2)
        {
           // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
           // lblMsg.ForeColor = System.Drawing.Color.Red;
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
        if (LoginUsertype == 1)
        {
            ddlDistrict.Items.Insert(0, new ListItem("Select State", "0"));

        }


    }

    #endregion
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            districtTehshilObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.insert);
            districtTehshilObject.TehshilName = HttpUtility.HtmlEncode(txtTehshilName.Text);

            districtTehshilObject.DistrictID = Convert.ToInt16(ddlDistrict.SelectedValue);
            districtTehshilObject.IPAddress = miscellBL.IpAddress();
            districtTehshilObject.UserID = Convert.ToInt16(LoginUserid);

            if (Session["UserType"].ToString().Equals("1"))
            {
                districtTehshilObject.StateID =Convert.ToInt32(DdlState.SelectedValue);
            }
            else
            {
                districtTehshilObject.StateID = Convert.ToInt16(Session["PermissionState"]);
            }

            int tempInsert = districtTehshilBL.insertUpdateTehshil(districtTehshilObject);

            if (tempInsert > 0)
            {
                Session["msg"] = "Tehshil has been submitted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewTehshil.aspx";
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }
            else
            {
                Session["msg"] = "Tehshil has not been submitted successfully.";
                Session["BackUrl"] = "~/Auth/AdminPanel/District Management/ViewTehshil.aspx";
                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            }

        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    public void FillDistrict1()
    {
        try
        {
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