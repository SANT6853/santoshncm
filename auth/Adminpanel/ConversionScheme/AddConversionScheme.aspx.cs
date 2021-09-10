using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_ConversionScheme_AddConversionScheme : CrsfBase
{
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    string LoginUserid;
    int LoginUsertype;
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    public static string HeaderTitle = string.Empty;
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
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["tid"] != null)
            {
                BtnBack.Visible = true;
                HeaderTitle = "Convergence with others central/state Government Scheme";
                TxtSNo.Enabled = false;
                BindDetials();
                btnsave.Text = "Update";
                ddlselectname.Enabled = false;
                DdlStateCentral.Enabled = false;
            }
            else
            {
                GenerateSerialNO();
                BtnBack.Visible = false;
                TxtSNo.Enabled = true;
                HeaderTitle = "Convergence with others central/state Government Scheme";
                //ddlcity.Items.Insert(0, new ListItem("Select", "0"));

            }
            BindVillagename();
        }
    }
    public void BindVillagename()
    {
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        _objNtcauser.VillageName = null;
        _objNtcauser.sAction = "ReserveID";

        //  _objNtcauser.TigerReserveName = ddlselectreserve.SelectedItem.Text;


        P_var.dSet = _commanfuction.BindVillagenameChart(_objNtcauser);
        if (P_var.dSet.Tables[2].Rows.Count > 0)
        {
            ddlselectname.DataSource = P_var.dSet.Tables[2];
            ddlselectname.DataTextField = "VILL_NM";
            ddlselectname.DataValueField = "VILL_ID";
            ddlselectname.DataBind();
            ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select-", "0"));
        }
        else
        {
            ddlselectname.Items.Clear();
            ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("No Record", "0"));
        }

    }
    void BindDetials()
    {
        TigerReserveOB tob = new TigerReserveOB();
        tob.Action = 1;
        tob.ConversionID = Convert.ToInt32(Request.QueryString["tid"].ToString());
        P_var.dSetChildData = _tigerReserverBl.Get_CrudOperation(tob);
        if (P_var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            TxtSNo.Text = P_var.dSetChildData.Tables[0].Rows[0]["SNo"].ToString();
            TxtSchemeName.Text = P_var.dSetChildData.Tables[0].Rows[0]["SchemeName"].ToString();
            DdlStateCentral.SelectedValue = P_var.dSetChildData.Tables[0].Rows[0]["StateCentralType"].ToString();
            TxtBenfitExt.Text = P_var.dSetChildData.Tables[0].Rows[0]["BenfitExten"].ToString();
            TxtAmountSpent.Text =Convert.ToInt32(P_var.dSetChildData.Tables[0].Rows[0]["AmountSpent"]).ToString();
            ddlselectname.SelectedValue = P_var.dSetChildData.Tables[0].Rows[0]["VillageID"].ToString();


        }
    }
    void GenerateSerialNO()
    {
        P_var.dSetChildData = null;
        TigerReserveOB tob = new TigerReserveOB();

        P_var.dSetChildData = _tigerReserverBl.AutoGenerateSerialNumber(tob);
        if (P_var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            TxtSNo.Text = P_var.dSetChildData.Tables[0].Rows[0]["SNo"].ToString();


        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {

    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
    bool ChkSchemName()
    {
        bool chk = false;

        _objNtcauser.SNo = TxtSNo.Text.Trim();
        P_var.dSet = _commanfuction.CheckSchemeName(_objNtcauser);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            return chk = true;
        }

        return chk;

    }
    bool ChkAlreadyExistVillageId()
    {
        bool chk = true;

        TigerReserveOB tob = new TigerReserveOB();

        tob.VillageID = Convert.ToInt32(ddlselectname.SelectedValue.Trim());
        tob.StateCentralType = DdlStateCentral.SelectedValue.Trim();
        P_var.dSetChildData = _tigerReserverBl.GetCheckVillageIDExist(tob);
        if (P_var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            chk = true;
        }
        else
        {
            chk = false;
        }
        return chk;

    }
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

                    //if (Page.IsValid)
                    //{
                    if (Page.IsValid)
                    {
                        //bool chk = check();
                        _TigerReserveOB.SchemeName = HttpUtility.HtmlEncode(TxtSchemeName.Text.Trim());

                        _TigerReserveOB.StateCentralType = DdlStateCentral.SelectedValue;
                        _TigerReserveOB.BenfitExten = HttpUtility.HtmlEncode(TxtBenfitExt.Text.Trim());
                        if (TxtAmountSpent.Text.Trim() == "")
                        {
                            TxtAmountSpent.Text = "0";
                        }

                        _TigerReserveOB.AmountSpent = Convert.ToDouble(TxtAmountSpent.Text.Trim());

                        _TigerReserveOB.CreatedUserID = Convert.ToInt32(Session["User_Id"]);// Convert.ToInt32(ddlcity.SelectedValue);
                        _TigerReserveOB.EditedUserID = Convert.ToInt32(Session["User_Id"]);
                        _TigerReserveOB.SNo = HttpUtility.HtmlEncode(TxtSNo.Text.Trim());
                        _TigerReserveOB.VillageID = Convert.ToInt32(ddlselectname.SelectedValue.Trim());


                        if (Request.QueryString["tid"] != null)
                        {
                            _TigerReserveOB.ConversionID = Convert.ToInt32(Request.QueryString["tid"].ToString());
                            _tigerReserverBl.Insert_UpdateConversionScheme(_TigerReserveOB);
                            if (Request.QueryString["tid"] != null)
                            {
                                Session["msg"] = "Conversion with Central/state Government Scheme has been Updated successfully.";
                            }
                            else
                            {
                                Session["msg"] = "Conversion with Central/state Government Scheme has been added successfully.";
                            }
                            //ConversionScheme_AddConversionScheme
                            Session["BackUrl"] = "~/Auth/AdminPanel/ConversionScheme/ConversionScheme.aspx";
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                        }
                        else
                        {
                            //if (ChkSchemName() == false)
                            //{
                            if (ChkAlreadyExistVillageId() == false)
                            {
                                _tigerReserverBl.Insert_UpdateConversionScheme(_TigerReserveOB);
                                if (Request.QueryString["tid"] != null)
                                {
                                    Session["msg"] = "Conversion with Central/state Government Scheme has been Updated successfully.";
                                }
                                else
                                {
                                    Session["msg"] = "Conversion with Central/state Government Scheme has been added successfully.";
                                }
                                //ConversionScheme_AddConversionScheme
                                Session["BackUrl"] = "~/Auth/AdminPanel/ConversionScheme/ConversionScheme.aspx";
                                Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('This village of State/Central  entry has already added!');", true);
                                // Response.Redirect("~/auth/adminpanel/ConversionScheme/ConversionScheme.aspx");
                            }
                            //}
                            //else
                            //{
                            //    Response.Write("<script>alert('Already exist S.No !!');</script>");
                            //}
                        }

                        //if (chk == true)
                        //{

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


       
  
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/ConversionScheme/ConversionScheme.aspx");
    }
}