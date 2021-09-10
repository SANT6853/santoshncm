using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_Enterform_village_area_form : CrsfBase
{
    #region Data declaration zone
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    VillageOB villageObject = new VillageOB();
    VillageBL villageBL = new VillageBL();
    Project_Variables p_Var =new Project_Variables();
    string LoginUserid;
    int LoginUsertype;
    NtcaUserOB objntcauser = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    #endregion


    #region Page load event zone
    protected void Page_Load(object sender, EventArgs e)
    {
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
            Bind_State();
            Bind_TigerReserveUserAccess();
            BindDistrict();
         
            ddlTehshiil.Items.Insert(0, new ListItem("Select", "0"));
            ddlGramPanchayat.Items.Insert(0, new ListItem("Select", "0"));
        }
    }

    #endregion



    #region Function to insert village entry

    private void insertVillageEntry()
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
                            villageObject.TigerReserveid = Convert.ToInt16(ddltigerreserve.SelectedValue);
                            villageObject.Village_Name = txtvillagename.Text;
                            villageObject.Agriculture_Land = Convert.ToDecimal(txtagricultureland.Text);
                            villageObject.Residential_property = Convert.ToDecimal(txtresidentialpropery.Text);
                            villageObject.Total_Standing_Trees = Convert.ToInt16(txttotalstandingtrees.Text);
                            villageObject.Total_Livestock = Convert.ToInt16(txttotallivestock.Text);
                            villageObject.Relocated_from = txtRelocaedfrom.Text;
                            villageObject.Relocated_place = txtrelocateTo.Text;
                            villageObject.Total_well = Convert.ToInt16(txttotalwell.Text);
                            villageObject.Other_Assets = txtotherAssets.Text;
                            villageObject.Current_location_Latitude = txtLatitudeCurrent.Text;
                            villageObject.Current_location_Longitude = txtLongitudecurrent.Text;
                            villageObject.location_Latitude_From = txtLatitudefrom.Text;
                            villageObject.location_Longitude_From = txtLongitudefrom.Text;
                            villageObject.Submitedby = Convert.ToInt16(LoginUserid);
                            villageObject.StateID = Convert.ToInt32(ddlstate.SelectedValue);

                            //new fields added on date 17-12-2017

                            villageObject.DistrictID = Convert.ToInt16(ddlDistrict.SelectedValue);
                            villageObject.TehshilID = Convert.ToInt16(ddlTehshiil.SelectedValue);
                            villageObject.AreaType = Convert.ToInt16(ddlArea.SelectedValue);
                            villageObject.RelocationStatus = Convert.ToInt16(ddlStatus.SelectedValue);
                            villageObject.GrampanchayatID = Convert.ToInt16(ddlGramPanchayat.SelectedValue);
                            villageObject.LegalStatus = Convert.ToInt16(ddlLegalStatus.SelectedValue);
                            villageObject.DateofSurvey = miscellBL.getDateFormat(txtsurdate.Text);
                            villageObject.DateofConcenment = miscellBL.getDateFormat(txtConcenmentDate.Text);
                            string stranimallist = hydanimallist.Value;

                            //stranimallist = stranimallist.Remove(stranimallist.Length - 1);
                            //char[] sepratior = { '^' };

                            //string[] Animallist = stranimallist.Split(sepratior);
                            //DataTable dtanimal = new DataTable();
                            //dtanimal.Columns.AddRange(new DataColumn[2] {
                            //                new DataColumn("Animalid", typeof(int)),
                            //                new DataColumn("TotalAnimal",typeof(int)) });

                            //foreach (string strrecord in Animallist)
                            //{
                            //    char[] sepratior1 = { '~' };
                            //    string[] _anidetail = strrecord.Split(sepratior1);
                            //    dtanimal.Rows.Add(Convert.ToInt32(_anidetail[0]), Convert.ToInt32(_anidetail[1]));
                            //}



                            // p_Var.Result = villageBL.Insert_VillageDetails(villageObject, dtanimal);
                            p_Var.Result = villageBL.Insert_VillageDetails(villageObject);
                            Session["msg"] = "Village Details has been Saved successfully.";
                            Session["BackUrl"] = "~/auth/adminpanel/Enterform/VillageAreaDisplay.aspx";
                        //}
                        //catch
                        //{
                        //    Session["msg"] = "Village Details has not been Saved. Try again";
                        //    Session["BackUrl"] = "~/auth/adminpanel/Enterform/VillageAreaDisplay.aspx";
                        //}
                        Response.Redirect("~/auth/adminpanel/ConfirmationPage.aspx");
                     }
                }
            }
            //}
        }
        catch
        {
            throw;
        }
     // }
    }



    #endregion
    void Bind_State()
    {
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        p_Var.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        ddlstate.DataSource = p_Var.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();
        if (LoginUsertype == 1)
        {
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));

        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
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

                        insertVillageEntry();
                    }
                }
            }
        }
        //}

        catch
        {
            throw;
        }
        // }
    }
    







    void Bind_TigerReserveUserAccess()
    {

        // p_Var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(LoginUserid));
        objntcauser.UserType = LoginUsertype;
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        p_Var.dSet = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
        ddltigerreserve.DataSource = p_Var.dSet;
        ddltigerreserve.DataTextField = "TigerReserveName";
        ddltigerreserve.DataValueField = "TigerReserveid";
        ddltigerreserve.DataBind();
        ddltigerreserve.Items.Insert(0, new ListItem("Select","0"));
    }

    void BindDistrict()
    {

        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        p_Var.dSet = _commanfucation.GetDistrict(objntcauser);
        ddlDistrict.DataSource = p_Var.dSet;
        ddlDistrict.DataTextField = "DistName";
        ddlDistrict.DataValueField = "DistID";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
    }

    void BindTehshil()
    {

        objntcauser.Dist = Convert.ToInt32(ddlDistrict.SelectedValue);
        p_Var.dSet = _commanfucation.GetTehshil(objntcauser);
        ddlTehshiil.DataSource = p_Var.dSet;
        ddlTehshiil.DataTextField = "Tehsil_Name";
        ddlTehshiil.DataValueField = "Tehsil";
        ddlTehshiil.DataBind();
        ddlTehshiil.Items.Insert(0, new ListItem("Select", "0"));
    }
    void BindGramPanchayat()
    {

        objntcauser.TehshilID = Convert.ToInt32(ddlTehshiil.SelectedValue);
        p_Var.dSet = _commanfucation.GetGramPanchayat(objntcauser);
        ddlGramPanchayat.DataSource = p_Var.dSet;
        ddlGramPanchayat.DataTextField = "GramPanchayatName";
        ddlGramPanchayat.DataValueField = "GramPanchayatID";
        ddlGramPanchayat.DataBind();
        ddlGramPanchayat.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
        BindDistrict();
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTehshil();
    }

    protected void ddlTehshiil_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGramPanchayat();
    }

    protected void ddlGramPanchayat_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}