using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Post_survey : System.Web.UI.Page
{
    #region function for Declaration
    Project_Variables P_var = new Project_Variables();
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    VillageDB Vill_BL = new VillageDB();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    #endregion
    #region Function for Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null || Session["User_Id"].ToString() == "0" || Session["User_Id"].ToString() == "")
        {
            Session.Abandon();
            Response.Redirect("~/Home.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                CheckStatus();
                BindPostStateName();
                BindStateName();
                ddlTigerReserve.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlVillage.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlDistric.Items.Insert(0, new ListItem("-Select-", "0"));
                ddlGramPanchayat.Items.Insert(0, new ListItem("-Select-", "0"));
                EditSurveyform();
                bindDefault(call:1);
            }
        }
    }
    #endregion
    #region Function for Checked Unchecked Radio Button
    protected void RdbPanchayatOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPanchayatOffice.SelectedValue == "Yes")
        {
            TxtRdbPanchayatOffice.Visible = true;
        }
        else
        {
            TxtRdbPanchayatOffice.Visible = false;
        }
    }
    protected void RdbAnganwadi_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAnganwadi.SelectedValue == "Yes")
        {
            TxtRdbAnganwadi.Visible = true;
        }
        else
        {
            TxtRdbAnganwadi.Visible = false;
        }
    }
    protected void RdbAllWeatherRoad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAllWeatherRoad.SelectedValue == "Yes")
        {
            TxtRdbAllWeatherRoad.Visible = true;
        }
        else
        {
            TxtRdbAllWeatherRoad.Visible = false;
        }
    }
    protected void RdbPostOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPostOffice.SelectedValue == "Yes")
        {
            TxtRdbPostOffice.Visible = true;
        }
        else
        {
            TxtRdbPostOffice.Visible = false;
        }
    }
    protected void RdbBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbBank.SelectedValue == "Yes")
        {
            TxtRdbBank.Visible = true;
        }
        else
        {
            TxtRdbBank.Visible = false;
        }
    }
    protected void RdbPDSShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPDSShop.SelectedValue == "Yes")
        {
            TxtRdbPDSShop.Visible = true;
        }
        else
        {
            TxtRdbPDSShop.Visible = false;
        }
    }
    protected void RdbPublicTelephonePCo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbPublicTelephonePCo.SelectedValue == "Yes")
        {
            TxtRdbPublicTelephonePCo.Visible = true;
        }
        else
        {
            TxtRdbPublicTelephonePCo.Visible = false;
        }
    }
    protected void RdbMobileSignal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbMobileSignal.SelectedValue == "Yes")
        {
            TxtRdbMobileSignal.Visible = true;
        }
        else
        {
            TxtRdbMobileSignal.Visible = false;
        }
    }
    protected void RdbAccessibiliythealthCare_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessibiliythealthCare.SelectedValue == "Yes")
        {
            TxtAccessibiliythealthCare.Visible = true;
        }
        else
        {
            TxtAccessibiliythealthCare.Visible = false;
        }
    }
    protected void RdbAccessibiliyRoad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessibiliyRoad.SelectedValue == "Yes")
        {
            TxtAccessibiliyRoad.Visible = true;
        }
        else
        {
            TxtAccessibiliyRoad.Visible = false;
        }
    }
    protected void RdbAccessbilitySchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessbilitySchool.SelectedValue == "Yes")
        {

            TxtAccessbilitySchoolPrimary.Visible = true;
            TxtAccessbilitySchool_Secondary.Visible = true;
            TxtAccessbilitySchool_HighSchool.Visible = true;
            TxtAccessbilitySchool_College.Visible = true;
        }
        else
        {
            TxtAccessbilitySchoolPrimary.Visible = false;
            TxtAccessbilitySchool_Secondary.Visible = false;
            TxtAccessbilitySchool_HighSchool.Visible = false;
            TxtAccessbilitySchool_College.Visible = false;
        }
    }
    protected void RdbAccessbilityElectrif_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessbilityElectrif.SelectedValue == "Yes")
        {
            TxtAccessbilityElectrif_DurationElectricityVillages.Visible = true;
            // TxtAccessbilityElectrif_households.Visible = true;
            lblRdbAccessbilityElectrif.Visible = true;
        }
        else
        {
            TxtAccessbilityElectrif_DurationElectricityVillages.Visible = false;
            // TxtAccessbilityElectrif_households.Visible = false;
            lblRdbAccessbilityElectrif.Visible = false;
        }
    }
    protected void RdbAccessiblityVeterinary_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessiblityVeterinary.SelectedValue == "Yes")
        {
            TxtAccessiblityVeterinary.Visible = true;

        }
        else
        {
            TxtAccessiblityVeterinary.Visible = false;

        }
    }
    protected void RdbAvenuesEmployment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAvenuesEmployment.SelectedValue == "Yes")
        {
            TxtAvenuesEmployment_Primary.Visible = true;
            TxtAvenuesEmployment_Secondary.Visible = true;
            lblRdbAvenuesEmployment1.Visible = true;
            lblRdbAvenuesEmployment2.Visible = true;
        }
        else
        {
            TxtAvenuesEmployment_Primary.Visible = false;
            TxtAvenuesEmployment_Secondary.Visible = false;
            lblRdbAvenuesEmployment1.Visible = false;
            lblRdbAvenuesEmployment2.Visible = false;
        }
    }
    protected void RdbHumanWildlifecon_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbHumanWildlifecon.SelectedValue == "Yes")
        {
            TxtRdbHumanWildlifecon.Visible = true;
            lblRdbHumanWildlifecon.Visible = true;
        }
        else
        {
            TxtRdbHumanWildlifecon.Visible = false;
            lblRdbHumanWildlifecon.Visible = false;

        }
    }
    protected void RdbAccessFireFodNwfps_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RdbAccessFireFodNwfps.SelectedValue == "Yes")
        {
            TXTAccessFireFodNwfps.Visible = true;
            lblRdbAccessFireFodNwfps.Visible = true;
        }
        else
        {
            TXTAccessFireFodNwfps.Visible = false;
            lblRdbAccessFireFodNwfps.Visible = false;

        }
    }
    #endregion
    #region Function for Bind State
    void BindStateName()
    {


        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);
        //if (P_var.dSet.Tables[3].Rows.Count > 0)
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlState.DataSource = P_var.dSet.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "id";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));

        }
    }
    #endregion
    #region Function for State Index Changed
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindTigerReserveName();
    }
    #endregion
    #region Function for Bind Tiger Reserve
    void BindTigerReserveName()
    {
        int ID = Convert.ToInt32(ddlState.SelectedValue);
        P_var.dSet = Vill_BL.BindTigerReservePost(ID);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlTigerReserve.DataSource = P_var.dSet.Tables[0];
            ddlTigerReserve.DataTextField = "TigerReserveName";
            ddlTigerReserve.DataValueField = "TigerReserveid";
            ddlTigerReserve.DataBind();

            ddlTigerReserve.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        else
        {
            ddlTigerReserve.Items.Clear();
            ddlTigerReserve.Items.Add(new ListItem("No Record", "0"));
        }
    }
    #endregion
    #region Function for Bind Distric
    public void FillDistrict()
    {
        int ID = Convert.ToInt32(ddlPostState.SelectedValue);
        P_var.dSetChildData = Vill_BL.BindDistricPost(ID);
        if (P_var.dSetChildData.Tables[0].Rows.Count > 0)
        {
            ddlDistric.DataSource = P_var.dSetChildData.Tables[0];
            ddlDistric.DataTextField = "DistName";
            ddlDistric.DataValueField = "DistID";
            ddlDistric.DataBind();

            ddlDistric.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        else
        {
            ddlDistric.Items.Clear();
            ddlDistric.Items.Add(new ListItem("No Record", "0"));
        }
    }
    #endregion
    #region Function for Distric Select Index Changed
    protected void ddlDistric_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName();
        FillGramPanchyat();
        bindDefault(call: 2);
       


    }
    #endregion
    #region Function for Tiger reserve Changed
    protected void ddlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVillage();
    }
    #endregion
    #region Function for Bind Village
    public void BindVillage()
    {
        int p = 1;
        if (Request.QueryString["p"] == "2")
        {
            p = 2;
        }
        else
        {
            p = 1;
        }
        int ID = Convert.ToInt32(ddlTigerReserve.SelectedValue);
        P_var.dSet = Vill_BL.BindVillagePost(ID,p);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlVillage.DataSource = P_var.dSet.Tables[0];
            ddlVillage.DataTextField = "VILL_NM";
            ddlVillage.DataValueField = "VILL_ID";
            ddlVillage.DataBind();

            ddlVillage.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        else
        {
            ddlVillage.Items.Clear();
            ddlVillage.Items.Add(new ListItem("No Record", "0"));
        }
    }
    #endregion
    #region Function for Save Data
    protected void btnSave_Click(object sender, EventArgs e)
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

                        if (Request.QueryString["p"] == "2")
                        {
                            _TigerReserveOB.Action = 2;
                            _TigerReserveOB.EditedUserID = Convert.ToInt32(Request.QueryString["id"]);
                        }
                        else
                        {
                            _TigerReserveOB.Action = 1;
                            _TigerReserveOB.EditedUserID = 0;
                        }
                        _TigerReserveOB.SurveyDate = DateTime.ParseExact(txtSurveyDate.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                        _TigerReserveOB.Surveyor = txtNameofSurveyor.Text.Trim();
                        _TigerReserveOB.DesignationSurveyor = txtDesignation.Text.Trim();
                        _TigerReserveOB.StateID = Convert.ToInt32(ddlState.SelectedValue);
                        _TigerReserveOB.Dist = Convert.ToInt32(ddlDistric.SelectedValue);
                        _TigerReserveOB.TigerReserveid = Convert.ToInt32(ddlTigerReserve.SelectedValue);
                        _TigerReserveOB.VillageID = Convert.ToInt32(ddlVillage.SelectedValue);
                        _TigerReserveOB.latitude = txtLatitude.Text.Trim();
                        _TigerReserveOB.longitude = txtLongitude.Text.Trim();
                        _TigerReserveOB.PostStateID = Convert.ToInt32(ddlPostState.SelectedValue);
                        _TigerReserveOB.PostReserveID = Convert.ToInt32(ddlGramPanchayat.SelectedValue);//grampanchayt
                        //_TigerReserveOB.PostVillageID = Convert.ToInt32(ddlPostVillgae.SelectedValue);
                        _TigerReserveOB.postVillageName = txtPostvillage.Text;
                        _TigerReserveOB.LegalStatus = ddlVillageLegalStatus.SelectedValue.ToString();
                        if (RdbAnganwadi.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbAnganwadi = RdbAnganwadi.SelectedValue.ToString();
                            _TigerReserveOB.Anganwadi = TxtRdbAnganwadi.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbAnganwadi = null;
                            _TigerReserveOB.Anganwadi = null;
                        }
                        if (RdbPanchayatOffice.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbPanchayatOffice = RdbPanchayatOffice.SelectedValue.ToString();
                            _TigerReserveOB.PanchayatOffice = TxtRdbPanchayatOffice.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbPanchayatOffice = null;
                            _TigerReserveOB.PanchayatOffice = null;
                        }
                        if (RdbAllWeatherRoad.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbAllWeatherRoad = RdbAllWeatherRoad.SelectedValue.ToString();
                            _TigerReserveOB.AllWeatherRoad = TxtRdbAllWeatherRoad.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbAllWeatherRoad = null;
                            _TigerReserveOB.AllWeatherRoad = null;
                        }
                        if (RdbPostOffice.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbPostOffice = RdbPostOffice.SelectedValue.ToString();
                            _TigerReserveOB.PostOffice = TxtRdbPostOffice.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbPostOffice = null;
                            _TigerReserveOB.PostOffice = null;
                        }
                        if (RdbBank.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbBank = RdbBank.SelectedValue.ToString();
                            _TigerReserveOB.Bank = TxtRdbBank.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbBank = null;
                            _TigerReserveOB.Bank = null;
                        }
                        if (RdbPDSShop.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbPDSShop = RdbPDSShop.SelectedValue.ToString();
                            _TigerReserveOB.PDSShop = TxtRdbPDSShop.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbPDSShop = null;
                            _TigerReserveOB.PDSShop = null;
                        }
                        if (RdbPublicTelephonePCo.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbPublicTelephonePCo = RdbPublicTelephonePCo.SelectedValue.ToString();
                            _TigerReserveOB.PublicTelephonePCo = TxtRdbPublicTelephonePCo.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbPublicTelephonePCo = null;
                            _TigerReserveOB.PublicTelephonePCo = null;
                        }
                        if (RdbMobileSignal.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbMobileSignal = RdbMobileSignal.SelectedValue.ToString();
                            _TigerReserveOB.MobileSignal = TxtRdbMobileSignal.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbMobileSignal = null;
                            _TigerReserveOB.MobileSignal = null;
                        }
                        if (RdbAccessibiliythealthCare.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbAccessibiliythealthCare = RdbAccessibiliythealthCare.SelectedValue.ToString();
                            _TigerReserveOB.AccessibiliythealthCare = TxtAccessibiliythealthCare.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbAccessibiliythealthCare = null;
                            _TigerReserveOB.AccessibiliythealthCare = null;
                        }
                        if (RdbAccessibiliyRoad.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbAccessibiliyRoad = RdbAccessibiliyRoad.SelectedValue.ToString();
                            _TigerReserveOB.AccessibiliyRoad = TxtAccessibiliyRoad.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbAccessibiliyRoad = null;
                            _TigerReserveOB.AccessibiliyRoad = null;
                        }
                        if (RdbAccessbilitySchool.SelectedValue == "Yes")
                        {

                            _TigerReserveOB.RdbAccessbilitySchool = RdbAccessbilitySchool.SelectedValue.ToString();
                            _TigerReserveOB.Primary = TxtAccessbilitySchoolPrimary.Text;
                            _TigerReserveOB.Secondary = TxtAccessbilitySchool_Secondary.Text;
                            _TigerReserveOB.HighSchool = TxtAccessbilitySchool_HighSchool.Text;
                            _TigerReserveOB.College = TxtAccessbilitySchool_College.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbAccessbilitySchool = null;
                            _TigerReserveOB.Primary = null;
                            _TigerReserveOB.Secondary = null;
                            _TigerReserveOB.HighSchool = null;
                            _TigerReserveOB.College = null;
                        }
                        if (RdbAccessbilityElectrif.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbAccessbilityElectrif = RdbAccessbilityElectrif.SelectedValue.ToString();
                            _TigerReserveOB.AccessbilityElectrif = TxtAccessbilityElectrif_DurationElectricityVillages.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbAccessbilityElectrif = null;
                            _TigerReserveOB.AccessbilityElectrif = null;
                        }
                        if (RdbAccessiblityVeterinary.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbAccessiblityVeterinary = RdbAccessiblityVeterinary.SelectedValue.ToString();
                            _TigerReserveOB.AccessiblityVeterinary = TxtAccessiblityVeterinary.Text;

                        }
                        else
                        {
                            _TigerReserveOB.RdbAccessiblityVeterinary = null;
                            _TigerReserveOB.AccessiblityVeterinary = null;
                        }
                        if (RdbAvenuesEmployment.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbAvenuesEmployment = RdbAvenuesEmployment.SelectedValue.ToString();
                            _TigerReserveOB.EmploymentPrimary = TxtAvenuesEmployment_Primary.Text;
                            _TigerReserveOB.EmploymentSecondary = TxtAvenuesEmployment_Secondary.Text;

                        }
                        else
                        {
                            _TigerReserveOB.RdbAvenuesEmployment = null;
                            _TigerReserveOB.EmploymentPrimary = null;
                            _TigerReserveOB.EmploymentSecondary = null;

                        }
                        if (RdbHumanWildlifecon.SelectedValue == "Yes")
                        {

                            _TigerReserveOB.RdbHumanWildlifecon = RdbHumanWildlifecon.SelectedValue.ToString();
                            _TigerReserveOB.HumanWildlifecon = TxtRdbHumanWildlifecon.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbHumanWildlifecon = null;
                            _TigerReserveOB.HumanWildlifecon = null;
                        }
                        if (RdbAccessFireFodNwfps.SelectedValue == "Yes")
                        {
                            _TigerReserveOB.RdbAccessFireFodNwfps = RdbAccessFireFodNwfps.SelectedValue.ToString();
                            _TigerReserveOB.AccessFireFodNwfps = TXTAccessFireFodNwfps.Text;
                        }
                        else
                        {
                            _TigerReserveOB.RdbAccessFireFodNwfps = null;
                            _TigerReserveOB.AccessFireFodNwfps = null;
                        }
                        _TigerReserveOB.CreatedByUserID = Convert.ToInt32(Session["User_Id"]);

                        P_var.Result = Vill_BL.SaveSurvey_Details(_TigerReserveOB);




                        if (P_var.Result > 0)
                        {
                            if (Request.QueryString["p"] == "2")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "$('#myModals').modal('show');", true);
                            }
                            else
                            {
                                ViewState["villageIdNext"] = P_var.Result;
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "$('#myModal').modal('show');", true);
                            }

                        }
                        else
                        {
                            ViewState["villageIdNext"] = P_var.Result;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "$('#myModal').modal('show');", true);
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
    
    #endregion
    #region Function For BTN Next Step
    protected void btnnextstep_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/Post/ConversionScheme.aspx?id=" + ViewState["villageIdNext"].ToString());
    }
    #endregion
    #region Function for Edit Survey Form
    public void EditSurveyform()
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

                        Project_Variables p_Val = new Project_Variables();
                        if (Request.QueryString["p"] == "2")
                        {
                            _TigerReserveOB.VillageID = Convert.ToInt32(Request.QueryString["id"]);
                            p_Val.dSet = Vill_BL.GetPostformrecord(_TigerReserveOB);
                            if (p_Val.dSet.Tables[0].Rows.Count > 0)
                            {
                                ddlVillageLegalStatus.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["LegalStatus"].ToString();
                                txtSurveyDate.Text = p_Val.dSet.Tables[0].Rows[0]["SurveyDate"].ToString();
                                txtNameofSurveyor.Text = p_Val.dSet.Tables[0].Rows[0]["SurveyorName"].ToString();
                                txtDesignation.Text = p_Val.dSet.Tables[0].Rows[0]["DesignationSurveyor"].ToString();
                                ddlState.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["StateID"].ToString();
                                ddlPostState.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["PostStateID"].ToString();
                                FillDistrict();
                                ddlDistric.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["DistID"].ToString();
                                FillGramPanchyat();
                                BindTigerReserveName();
                                ddlTigerReserve.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["TigerReserveID"].ToString();
                                BindVillage();
                                ddlVillage.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["VilageID"].ToString();
                                txtLatitude.Text = p_Val.dSet.Tables[0].Rows[0]["Latitude"].ToString();
                                txtLongitude.Text = p_Val.dSet.Tables[0].Rows[0]["Longitude"].ToString();

                                BindPostTigerReserveName();
                                ddlGramPanchayat.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["gramPanchayt"].ToString();
                                BindPostVillage();
                                ddlPostVillgae.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["PostVill_ID"].ToString();
                                txtPostvillage.Text = p_Val.dSet.Tables[0].Rows[0]["PostVillageName"].ToString();


                                if (p_Val.dSet.Tables[0].Rows[0]["RdbPanchayatOffice"].ToString() == "Yes")
                                {
                                    TxtRdbPanchayatOffice.Visible = true;
                                    RdbPanchayatOffice.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbPanchayatOffice"].ToString();
                                    TxtRdbPanchayatOffice.Text = p_Val.dSet.Tables[0].Rows[0]["PanchayatOffice"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAnganwadi"].ToString() == "Yes")
                                {
                                    TxtRdbAnganwadi.Visible = true;
                                    RdbPanchayatOffice.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAnganwadi"].ToString();
                                    TxtRdbAnganwadi.Text = p_Val.dSet.Tables[0].Rows[0]["Anganwadi"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAllWeatherRoad"].ToString() == "Yes")
                                {
                                    TxtRdbAllWeatherRoad.Visible = true;
                                    RdbPanchayatOffice.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAllWeatherRoad"].ToString();
                                    TxtRdbAllWeatherRoad.Text = p_Val.dSet.Tables[0].Rows[0]["AllWeatherRoad"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbPostOffice"].ToString() == "Yes")
                                {
                                    TxtRdbPostOffice.Visible = true;
                                    RdbPostOffice.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbPostOffice"].ToString();
                                    TxtRdbPostOffice.Text = p_Val.dSet.Tables[0].Rows[0]["PostOffice"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbBank"].ToString() == "Yes")
                                {
                                    TxtRdbBank.Visible = true;
                                    RdbBank.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbBank"].ToString();
                                    TxtRdbBank.Text = p_Val.dSet.Tables[0].Rows[0]["Bank"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbPDSShop"].ToString() == "Yes")
                                {
                                    TxtRdbPDSShop.Visible = true;
                                    RdbPDSShop.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbPDSShop"].ToString();
                                    TxtRdbPDSShop.Text = p_Val.dSet.Tables[0].Rows[0]["Bank"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbPublicTelephonePCo"].ToString() == "Yes")
                                {
                                    TxtRdbPublicTelephonePCo.Visible = true;
                                    RdbPublicTelephonePCo.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbPublicTelephonePCo"].ToString();
                                    TxtRdbPublicTelephonePCo.Text = p_Val.dSet.Tables[0].Rows[0]["PublicTelephonePCo"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbMobileSignal"].ToString() == "Yes")
                                {
                                    TxtRdbMobileSignal.Visible = true;
                                    RdbPDSShop.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbMobileSignal"].ToString();
                                    TxtRdbMobileSignal.Text = p_Val.dSet.Tables[0].Rows[0]["MobileSignal"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessibiliythealthCare"].ToString() == "Yes")
                                {
                                    TxtAccessibiliythealthCare.Visible = true;
                                    RdbAccessibiliythealthCare.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessibiliythealthCare"].ToString();
                                    TxtAccessibiliythealthCare.Text = p_Val.dSet.Tables[0].Rows[0]["AccessibiliythealthCare"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessibiliyRoad"].ToString() == "Yes")
                                {
                                    TxtAccessibiliyRoad.Visible = true;
                                    RdbAccessibiliyRoad.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessibiliyRoad"].ToString();
                                    TxtAccessibiliyRoad.Text = p_Val.dSet.Tables[0].Rows[0]["AccessibiliyRoad"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessbilitySchool"].ToString() == "Yes")
                                {
                                    TxtAccessbilitySchoolPrimary.Visible = true;
                                    TxtAccessbilitySchool_Secondary.Visible = true;
                                    TxtAccessbilitySchool_HighSchool.Visible = true;
                                    TxtAccessbilitySchool_College.Visible = true;
                                    RdbAccessbilitySchool.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessbilitySchool"].ToString();
                                    TxtAccessbilitySchoolPrimary.Text = p_Val.dSet.Tables[0].Rows[0]["PrimarySchool"].ToString();
                                    TxtAccessbilitySchool_Secondary.Text = p_Val.dSet.Tables[0].Rows[0]["SecondarySchool"].ToString();
                                    TxtAccessbilitySchool_HighSchool.Text = p_Val.dSet.Tables[0].Rows[0]["HighSchool"].ToString();
                                    TxtAccessbilitySchool_College.Text = p_Val.dSet.Tables[0].Rows[0]["College"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessbilityElectrif"].ToString() == "Yes")
                                {
                                    TxtAccessbilityElectrif_DurationElectricityVillages.Visible = true;
                                    lblRdbAccessbilityElectrif.Visible = true;
                                    RdbAccessbilityElectrif.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessbilityElectrif"].ToString();
                                    TxtAccessbilityElectrif_DurationElectricityVillages.Text = p_Val.dSet.Tables[0].Rows[0]["AccessbilityElectrif"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessiblityVeterinary"].ToString() == "Yes")
                                {
                                    TxtAccessiblityVeterinary.Visible = true;
                                    RdbAccessiblityVeterinary.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessiblityVeterinary"].ToString();
                                    TxtAccessiblityVeterinary.Text = p_Val.dSet.Tables[0].Rows[0]["AccessiblityVeterinary"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAvenuesEmployment"].ToString() == "Yes")
                                {
                                    TxtAvenuesEmployment_Primary.Visible = true;
                                    TxtAvenuesEmployment_Secondary.Visible = true;
                                    lblRdbAvenuesEmployment1.Visible = true;
                                    lblRdbAvenuesEmployment2.Visible = true;
                                    RdbAvenuesEmployment.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAvenuesEmployment"].ToString();
                                    TxtAvenuesEmployment_Primary.Text = p_Val.dSet.Tables[0].Rows[0]["EmploymentPrimary"].ToString();
                                    TxtAvenuesEmployment_Secondary.Text = p_Val.dSet.Tables[0].Rows[0]["EmploymentSecondary"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbHumanWildlifecon"].ToString() == "Yes")
                                {
                                    lblRdbHumanWildlifecon.Visible = true;
                                    TxtRdbHumanWildlifecon.Visible = true;
                                    RdbHumanWildlifecon.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbHumanWildlifecon"].ToString();
                                    TxtRdbHumanWildlifecon.Text = p_Val.dSet.Tables[0].Rows[0]["HumanWildlifecon"].ToString();
                                }
                                if (p_Val.dSet.Tables[0].Rows[0]["RdbAccessFireFodNwfps"].ToString() == "Yes")
                                {
                                    TXTAccessFireFodNwfps.Visible = true;
                                    lblRdbAccessFireFodNwfps.Visible = true;
                                    RdbAccessFireFodNwfps.SelectedValue = p_Val.dSet.Tables[0].Rows[0]["RdbAccessFireFodNwfps"].ToString();
                                    TXTAccessFireFodNwfps.Text = p_Val.dSet.Tables[0].Rows[0]["AccessFireFodNwfps"].ToString();
                                }
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
    
        
    
    #endregion
   
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/Adminpanel/Post/survey-details.aspx");
    }
    //Tiger Reserve Post State Name
    #region Function for Bind Post State
    void BindPostStateName()
    {


        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);
        //if (P_var.dSet.Tables[3].Rows.Count > 0)
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlPostState.DataSource = P_var.dSet.Tables[0];
            ddlPostState.DataTextField = "StateName";
            ddlPostState.DataValueField = "id";
            ddlPostState.DataBind();
            ddlPostState.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
            ddlPostVillgae.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        ddlPostReserve.Items.Insert(0, new ListItem("-Select-", "0"));
        ddlPostVillgae.Items.Insert(0, new ListItem("-Select-", "0"));

    }
    #endregion
    protected void ddlPostReserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPostVillage();
    }
    protected void ddlPostState_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindPostTigerReserveName();
        FillDistrict();


    }
    #region Function for Bind Tiger Reserve
    void BindPostTigerReserveName()
    {
        int ID = Convert.ToInt32(ddlPostState.SelectedValue);
        P_var.dSetCompare = Vill_BL.BindTigerReservePost(ID);
        if (P_var.dSetCompare.Tables[0].Rows.Count > 0)
        {
            ddlPostReserve.DataSource = P_var.dSetCompare.Tables[0];
            ddlPostReserve.DataTextField = "TigerReserveName";
            ddlPostReserve.DataValueField = "TigerReserveid";
            ddlPostReserve.DataBind();

            ddlPostReserve.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        else
        {
            ddlPostReserve.Items.Clear();
            ddlPostReserve.Items.Add(new ListItem("No Record", "0"));
        }
    }
    #endregion
    #region Function for Bind Village
    public void BindPostVillage()
    { 
        int p=1;
        if(Request.QueryString["p"]=="2")
        {
            p = 2;
        }
        else
        {
            p = 1;
        }
        
        int ID = Convert.ToInt32(ddlTigerReserve.SelectedValue);
        P_var.dSet = Vill_BL.BindVillagePost(ID,p);
        if (P_var.dSet.Tables[1].Rows.Count > 0)
        {
            ddlPostVillgae .DataSource = P_var.dSet.Tables[1];
            ddlPostVillgae.DataTextField = "VILL_NM";
            ddlPostVillgae.DataValueField = "VILL_ID";
            ddlPostVillgae.DataBind();

            ddlPostVillgae.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        else
        {
            ddlPostVillgae.Items.Clear();
            ddlPostVillgae.Items.Add(new ListItem("No Record", "0"));
        }
    }
    #endregion
    public void CheckStatus()
    {
        _TigerReserveOB.VillageID = Convert.ToInt32(Request.QueryString["id"]);
        P_var.dSet = Vill_BL.CheckfinalStatus(_TigerReserveOB);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(P_var.dSet.Tables[0].Rows[0]["FinalSubmit"]) == 1)
            {
                divfinal.Visible = true;
            }
            else
            {
                divfinal.Visible = true;
            }

        }
    }


    private void bindDefault(int call)
    {
        if(Session["UserType"] !=null)
        {
            if(Convert.ToInt32(Session["UserType"])==4)
            {
                if (call == 1)
                {
                    ddlState.SelectedValue = Session["ntca_StateID"].ToString();
                    ddlState.Attributes.Add("disabled", "disabled");

                    BindTigerReserveName();
                    ddlTigerReserve.SelectedValue = Session["1ntca_TigerReserveid"].ToString();
                    ddlTigerReserve.Attributes.Add("disabled", "disabled");
                    BindVillage();
                    ddlPostState.SelectedValue = Session["ntca_StateID"].ToString();
                    ddlPostState.Attributes.Add("disabled", "disabled");
                    FillDistrict();
                    FillGramPanchyat();

                }
                else
                {
                    ddlTigerReserve.SelectedValue = Session["1ntca_TigerReserveid"].ToString();
                    ddlTigerReserve.Attributes.Add("disabled", "disabled");
                }


            }
        }
        else
        {
            Response.Redirect(ResolveUrl("~/home.aspx"));
        }
       
    }


    public void FillGramPanchyat()
    {
        try
        {
            ddlGramPanchayat.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = null;
            if (ddlGramPanchayat.SelectedIndex != 0)
            {
                _TigerReserveOB.Dist = Convert.ToInt32(ddlDistric.SelectedValue);
                ds1 = Vill_BL.GetPostGram(_TigerReserveOB);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ddlGramPanchayat.DataSource = ds1;
                    ddlGramPanchayat.DataTextField = "GramPanchayatName";
                    ddlGramPanchayat.DataValueField = "GramPanchayatID";
                    ddlGramPanchayat.DataBind();
                    //Select Grampanchayat
                    ddlGramPanchayat.Items.Insert(0, "-Select-");
                }
                else
                {

                    ddlGramPanchayat.Items.Add(new ListItem("-Select-", "0"));
                }

            }

        }
        catch (Exception e2)
        {
           
        }
    }
}