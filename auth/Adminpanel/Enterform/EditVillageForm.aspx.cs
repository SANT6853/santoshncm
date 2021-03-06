using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_Enterform_EditVillageForm : CrsfBase
{
    #region Data declaration zone
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    VillageOB villageObject = new VillageOB();
    VillageBL villageBL = new VillageBL();
    Project_Variables p_Var = new Project_Variables();
    string LoginUserid;
    int LoginUsertype;
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Commanfuction _commanfucation = new Commanfuction();
    #endregion

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
            hydvillageid.Value = Request.QueryString["id"].ToString();
            hydstatus.Value = Request.QueryString["Status"].ToString();
            
            villageObject.Villageid = Convert.ToInt32(Request.QueryString["id"].ToString());
         //   villageObject.StatusID= Convert.ToInt32(Request.QueryString["Status"].ToString());
            Bind_VillageForEdit(villageObject);

        }
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_TigerReserveUserAccess();
        BindDistrict();
    }
    void Bind_TigerReserveUserAccess()
    {

        //p_Var.dSet = _tigerReserverBl.GetTigerReserverByState(2, Convert.ToInt32(LoginUserid));
        objntcauser.UserType = LoginUsertype;
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        p_Var.dSetChildData = _commanfucation.Get_TigerReserve_state_Permission(objntcauser);
        ddltigerreserve.DataSource = p_Var.dSetChildData;
        ddltigerreserve.DataTextField = "TigerReserveName";
        ddltigerreserve.DataValueField = "TigerReserveid";
        ddltigerreserve.DataBind();
        ddltigerreserve.Items.Insert(0, new ListItem("Select", "0"));
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

                        UpdateVillageEntry();
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
    void Bind_VillageForEdit(VillageOB obj_village)
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
                                   p_Var.dSet = villageBL.Get_VillageDetialsForEdit(obj_village);
                        if (p_Var.dSet.Tables[0].Rows.Count>0)
                        {
                            ddlstate.SelectedValue= p_Var.dSet.Tables[0].Rows[0]["stateid"].ToString();
                            Bind_TigerReserveUserAccess();
           
                            ddltigerreserve.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["TigerReserveID"].ToString();
                            BindDistrict();
                            if (p_Var.dSet.Tables[0].Rows[0]["DistID"] != DBNull.Value)
                            {
                                ddlDistrict.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["DistID"].ToString();
                            }
          
                            BindTehshil();
                            if (p_Var.dSet.Tables[0].Rows[0]["Tehsilid"] != DBNull.Value)
                            {
                                ddlTehshiil.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["Tehsilid"].ToString();
                            }
           
                            BindGramPanchayat();
                            if (p_Var.dSet.Tables[0].Rows[0]["Tehsilid"] != DBNull.Value)
                            {
                                ddlGramPanchayat.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["GramPanchayatID"].ToString();
                            }
          
                            ddlLegalStatus.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["LegalStatus"].ToString();
                            ddlStatus.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["RelocationStatusID"].ToString();
                            ddlArea.SelectedValue = p_Var.dSet.Tables[0].Rows[0]["AreaType"].ToString();
                            if (p_Var.dSet.Tables[0].Rows[0]["DateofSurvey"] != DBNull.Value)
                            {
                                txtsurdate.Text = p_Var.dSet.Tables[0].Rows[0]["DateofSurvey"].ToString();
                            }
                            else
                            {
                                txtsurdate.Text = string.Empty;
                            }
                            if (p_Var.dSet.Tables[0].Rows[0]["DateofConcenment"] != DBNull.Value)
                            {
                                txtConcenmentDate.Text =p_Var.dSet.Tables[0].Rows[0]["DateofConcenment"].ToString();
                            }
                            else
                            {
                                txtConcenmentDate.Text = string.Empty;
                            }
                            txtvillagename.Text= p_Var.dSet.Tables[0].Rows[0]["Village_Name"].ToString();
                            txtagricultureland.Text = p_Var.dSet.Tables[0].Rows[0]["Agriculture_Land"].ToString();
                            txtresidentialpropery.Text = p_Var.dSet.Tables[0].Rows[0]["Residential_property"].ToString();
                            txttotalstandingtrees.Text = p_Var.dSet.Tables[0].Rows[0]["Total_Standing_Trees"].ToString();
                            txttotallivestock.Text = p_Var.dSet.Tables[0].Rows[0]["Total_Livestock"].ToString();
                            txtRelocaedfrom.Text = p_Var.dSet.Tables[0].Rows[0]["Relocated_from"].ToString();
                            txtrelocateTo.Text = p_Var.dSet.Tables[0].Rows[0]["Relocated_place"].ToString();
                            txttotalwell.Text = p_Var.dSet.Tables[0].Rows[0]["Total_well"].ToString();
                            txtotherAssets.Text = p_Var.dSet.Tables[0].Rows[0]["Other_Assets"].ToString();
                            txtLatitudeCurrent.Text = p_Var.dSet.Tables[0].Rows[0]["Current_location_Latitude"].ToString();
                            txtLongitudecurrent.Text = p_Var.dSet.Tables[0].Rows[0]["Current_location_Longitude"].ToString();
                            txtLatitudefrom.Text = p_Var.dSet.Tables[0].Rows[0]["location_Latitude_From"].ToString();
                            txtLongitudefrom.Text = p_Var.dSet.Tables[0].Rows[0]["location_Longitude_From"].ToString();
                        }
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


    private void UpdateVillageEntry()
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
                            villageObject.StateID = Convert.ToInt32(ddlstate.SelectedValue);
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

                            //new fields added on date 17-12-2017

                            villageObject.DistrictID = Convert.ToInt16(ddlDistrict.SelectedValue);
                            villageObject.TehshilID = Convert.ToInt16(ddlTehshiil.SelectedValue);
                            villageObject.AreaType = Convert.ToInt16(ddlArea.SelectedValue);
                            villageObject.RelocationStatus = Convert.ToInt16(ddlStatus.SelectedValue);
                            villageObject.GrampanchayatID = Convert.ToInt16(ddlGramPanchayat.SelectedValue);
                            villageObject.LegalStatus = Convert.ToInt16(ddlLegalStatus.SelectedValue);
                            villageObject.DateofSurvey = miscellBL.getDateFormat(txtsurdate.Text);
                            villageObject.DateofConcenment = miscellBL.getDateFormat(txtConcenmentDate.Text);

                            if (Convert.ToInt16(Request.QueryString["Status"].ToString()) == 3)
                            {
                                villageObject.TempVillageID = Convert.ToInt16(Request.QueryString["id"].ToString());
                            }
                            else
                            {
                                villageObject.Villageid = Convert.ToInt16(Request.QueryString["id"].ToString());
                            }

                            villageObject.StatusID = Convert.ToInt16(Request.QueryString["Status"].ToString());
                            //villageObject.Population=
                            //string stranimallist = hydanimallist.Value;

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



                                p_Var.Result = villageBL.Update_VillageDetails(villageObject);
                                Session["msg"] = "Village Details has been Updated successfully.";
                                Session["BackUrl"] = "~/auth/adminpanel/Enterform/VillageAreaDisplay.aspx";
                        //}
                        //    catch
                        //    {
                        //        Session["msg"] = "Village Details has been not Updated. Try again";
                        //        Session["BackUrl"] = "~/auth/adminpanel/Enterform/VillageAreaDisplay.aspx";
                        //    }
                        //    Response.Redirect("~/auth/adminpanel/ConfirmationPage.aspx");
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
    //}


    void BindDistrict()
    {
        ddlDistrict.Items.Clear();

        objntcauser.State = Convert.ToInt32(ddlstate.SelectedValue);
        p_Var.dSetChildData = _commanfucation.GetDistrict(objntcauser);
        ddlDistrict.DataSource = p_Var.dSetChildData;
        ddlDistrict.DataTextField = "DistName";
        ddlDistrict.DataValueField = "DistID";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
    }

    void BindTehshil()
    {

        ddlTehshiil.Items.Clear();
        objntcauser.Dist = Convert.ToInt32(ddlDistrict.SelectedValue);
        p_Var.dSetChildData = _commanfucation.GetTehshil(objntcauser);
        ddlTehshiil.DataSource = p_Var.dSetChildData;
        ddlTehshiil.DataTextField = "Tehsil_Name";
        ddlTehshiil.DataValueField = "Tehsil";
        ddlTehshiil.DataBind();
        ddlTehshiil.Items.Insert(0, new ListItem("Select", "0"));
    }
    void BindGramPanchayat()
    {
        ddlGramPanchayat.Items.Clear();
        objntcauser.TehshilID = Convert.ToInt32(ddlDistrict.SelectedValue);
        p_Var.dSetChildData = _commanfucation.GetGramPanchayat(objntcauser);
        ddlGramPanchayat.DataSource = p_Var.dSetChildData;
        ddlGramPanchayat.DataTextField = "GramPanchayatName";
        ddlGramPanchayat.DataValueField = "GramPanchayatID";
        ddlGramPanchayat.DataBind();
        ddlGramPanchayat.Items.Insert(0, new ListItem("Select", "0"));
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