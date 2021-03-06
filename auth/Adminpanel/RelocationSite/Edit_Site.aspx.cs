using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_RelocationSite_Edit_Site : CrsfBase
{
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    VillageDB VillDB_Obj = new VillageDB();



    Realocation_AreaEntiry RELO_ENT_Obj = new Realocation_AreaEntiry();
    Realocation_AreaDB RELODB_Obj = new Realocation_AreaDB();


    static bool check = false, flag = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {


            lblMsg.Text = "";
            // GenerateCodeForVillage();
            if (Session["User_Id"].ToString() == null)
            {
                Response.Redirect(ResolveUrl("~/home.aspx"), true);
                return;
            }
           
            if (!IsPostBack)
            {

                if (Session["UserType"].ToString().Equals("4") || Session["UserType"].ToString().Equals("3") || Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("1"))
                {


                    FillStates();
                    if (Request.QueryString[WebConstant.QueryStringEnum.RELO_ID] != null)
                    {
                        if (Request.QueryString[WebConstant.QueryStringEnum.RELO_ID] != "")
                        {
                            if (Session["UserType"].ToString().Equals("4"))
                            {
                                GetVillageRelocation(Convert.ToInt32(Session["User_Id"]));
                               

                            }
                            if (Session["UserType"].ToString().Equals("1"))
                            {
                                GetVillageRelocationSuperAdmin(Convert.ToInt32(Session["User_Id"]));
                               
                            }
                            Load_Village_Info(Request.QueryString[WebConstant.QueryStringEnum.RELO_ID].ToString().Trim());

                            if (Session["UserType"].ToString().Equals("1"))
                            {
                                //FillVillage11();
                            }
                            else
                            {
                                ddlselectstate1.SelectedValue = Session["PermissionState"].ToString();
                                ddlselectstate1.Enabled = false;
                            }
                        }
                        else
                        {
                            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }

                  
                    //BindVillages();
                }

                

                //
            }
        }
        catch (Exception e3)
        {
           // Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx"), true);
            return;
        }

    }
   
    public void GetVillageRelocationSuperAdmin(int CmnStateUserID)
    {
        try
        {

            DdlRelocatedVillageName.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.GetVillageNotRelocatedSuper(CmnStateUserID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                DdlRelocatedVillageName.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    DdlRelocatedVillageName.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                DdlRelocatedVillageName.Items.Add(new ListItem("No Record", "0"));
                // ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void GetVillageRelocation(int userid)
    {
        try
        {

            DdlRelocatedVillageName.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.GetVillageNotRelocated(userid);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                DdlRelocatedVillageName.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    DdlRelocatedVillageName.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                //ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                DdlRelocatedVillageName.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Load_Village_Info(string reloid)
    {
        try
        {
            DataSet ds = new DataSet();
            RELO_ENT_Obj._VILL_ID = null;
            ds = RELODB_Obj.Display_All_Relocation_Area(RELO_ENT_Obj, reloid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                LblFromVillageHeader.Text = ds.Tables[0].Rows[0]["tvillage"].ToString();

                ddlselectstate1.SelectedValue = ds.Tables[0].Rows[0]["ST_NM"].ToString();
                GetVillageRelocationSuperAdmin();
                FillDistrict1(null);
                ddlselectdistrict1.SelectedValue = ds.Tables[0].Rows[0]["DT_NM"].ToString();
                FillTehsil();
                ddlselecttehsil.SelectedValue = ds.Tables[0].Rows[0]["TH_NM"].ToString();
                FillGramPanchyat();
                DDlRelocatedGrampanChyat.SelectedValue = ds.Tables[0].Rows[0]["GP_NM"].ToString();
                DdlRelocatedVillageName.SelectedValue = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                txraddress.Text = ds.Tables[0].Rows[0]["RELOC_SITE_ADD"].ToString();
                txtcomment.Text = ds.Tables[0].Rows[0]["COMMENT"].ToString();
                TxtLatitude.Text = ds.Tables[0].Rows[0]["Latitude"].ToString();
                TxtLongitude.Text = ds.Tables[0].Rows[0]["Longitude"].ToString();
               
                
                string vill_id = ds.Tables[0].Rows[0]["VILL_ID"].ToString();
                DataSet ds2 = VillDB_Obj.Get_OthersIDs_By_VillId(vill_id);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    // ds2.Tables[0].Rows[0]["CmnStateID"].ToString();
                   // ddlselectstate.SelectedValue = Session["sStateID"].ToString(); 
                    ddlselectstate.SelectedValue = ds2.Tables[0].Rows[0]["CmnStateID"].ToString(); 
                    FillReserve();
                    ddlselectreserve.SelectedValue = ds2.Tables[0].Rows[0]["CmnDataOperatorTigerReserveID"].ToString();
                    FillDistrict(ddlselectreserve.SelectedValue.ToString());
                    ddlSelectDistrict.SelectedValue = ds2.Tables[0].Rows[0]["DT_ID"].ToString();
                    //FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
                    ddlselecttehsil.SelectedValue = ds2.Tables[0].Rows[0]["TH_ID"].ToString();
                   // FillGP(ddlselecttehsil.SelectedValue.ToString());
                   // ddlselectgp.SelectedValue = ds2.Tables[0].Rows[0]["GP_ID"].ToString();
                    FillVillage(ddlselectgp.SelectedValue.ToString());
                    ddlselectname.SelectedValue = vill_id;


                }


                else
                {
                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }

    public void FillStates()
    {
        try
        {
            ddlselectstate.Items.Clear();
            ddlselectstate1.Items.Clear();
            DataSet ds = new DataSet();
            ds = comDB_Obj.FillStates_District_ReserveDB(null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();

                ddlselectstate.Items.Add(new ListItem("Select State", "0"));
                ddlselectstate1.Items.Add(new ListItem("Select State", "0"));

                list = com_Obj.FillDropDownList(ds, 0, "ST_NAME");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {

                    ddlselectstate.Items.Add(new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["ST_ID"].ToString()));
                    ddlselectstate1.Items.Add(new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["ST_ID"].ToString()));
                    j++;

                }


                ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));


            }
            else
            {

                ddlselectstate.Items.Add(new ListItem("No Record", "0"));
                ddlselectstate1.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void ddlselectstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlselectreserve.Items.Clear();
        ddlSelectDistrict.Items.Clear();
        ddlselecttehsil.Items.Clear();
        ddlselectgp.Items.Clear();
        ddlselectname.Items.Clear();
        if (ddlselectstate.SelectedValue.ToString().Equals("0"))
        {
            ddlselectreserve.Items.Clear();
            ddlSelectDistrict.Items.Clear();
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
            ddlselectname.Items.Clear();

            ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
            ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
            ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            ddlselectname.Items.Add(new ListItem("No Record", "0"));
        }
        else
        {
            FillReserve();

        }
    }
    public void FillReserve()
    {
        try
        {
            string stateid = ddlselectstate.SelectedValue.ToString();
            ddlselectreserve.Items.Clear();
            DataSet ds = new DataSet();
            ds = comDB_Obj.FillStates_District_ReserveDB(stateid, null);

            if (ds.Tables[2].Rows.Count > 0)
            {
                List<string> list = new List<string>();
                ListItem listforreserve = new ListItem("Select Reserve", "0");
                ddlselectreserve.Items.Add(listforreserve);
                list = com_Obj.FillDropDownList(ds, 2, "RSRV_AREA_NM");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[2].Rows[j][0].ToString());
                    ddlselectreserve.Items.Add(li);
                    j++;

                }

                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
                //ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                //ddlselectgp.Items.Add(new ListItem("No Record", "0"));
               // ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }
            else
            {

                ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
               // ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
               // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
               // ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSelectDistrict.Items.Clear();
        ddlselecttehsil.Items.Clear();
        ddlselectgp.Items.Clear();
        ddlselectname.Items.Clear();

        if (ddlselectreserve.SelectedValue.ToString().Equals("0"))
        {

            ddlSelectDistrict.Items.Clear();
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
            ddlselectname.Items.Clear();

            ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
            ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            ddlselectname.Items.Add(new ListItem("No Record", "0"));

        }
        else
        {
            FillDistrict(ddlselectreserve.SelectedValue.ToString());

        }
    }
    public void FillDistrict(string reserveid)
    {
        try
        {
            ddlSelectDistrict.Items.Clear();
          //  ddlselecttehsil.Items.Clear();
          //  ddlselectgp.Items.Clear();
          //  ddlselectname.Items.Clear();
            DataSet ds1 = new DataSet();
            if (flag == false)
            {
                ds1 = comDB_Obj.FillStates_District_ReserveDB(null, ddlselectreserve.SelectedValue.ToString());
            }
            else
            {
                ds1 = comDB_Obj.FillStates_District_ReserveDB(null, Session["Reserve_Id"].ToString());
            }

            if (ds1.Tables[1].Rows.Count > 0)
            {
                ListItem listfordistrict = new ListItem("Select District", "0");
                ddlSelectDistrict.Items.Add(listfordistrict);
                List<string> list = new List<string>();

                list = com_Obj.FillDropDownList(ds1, 1, "DT_NAME");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds1.Tables[1].Rows[j][0].ToString());
                    ddlSelectDistrict.Items.Add(li);
                    j++;

                }


              //  ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
               // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
               // ddlselectname.Items.Add(new ListItem("No Record", "0"));

            }
            else
            {

                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
               // ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
               // ddlselectgp.Items.Add(new ListItem("No Record", "0"));
               // ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void FillDistrict1(string reserveid)
    {
        try
        {
            ddlselectdistrict1.Items.Clear();

            DataSet ds1 = new DataSet();

            ds1 = comDB_Obj.FillStates_District_ReserveDB(ddlselectstate1.SelectedValue.ToString(), null);


            if (ds1.Tables[1].Rows.Count > 0)
            {
                ListItem listfordistrict = new ListItem("Select District", "0");
                ddlselectdistrict1.Items.Add(listfordistrict);
                List<string> list = new List<string>();

                list = com_Obj.FillDropDownList(ds1, 1, "DT_NAME");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds1.Tables[1].Rows[j][0].ToString());
                    ddlselectdistrict1.Items.Add(li);
                    j++;

                }



            }
            else
            {

                ddlselectdistrict1.Items.Add(new ListItem("No Record", "0"));

            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlSelectDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlSelectDistrict.SelectedValue.ToString().Equals("0"))
        {
            FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
        }
        else
        {
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
            ddlselectname.Items.Clear();

            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
            ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            ddlselectname.Items.Add(new ListItem("No Record", "0"));

        }
    }
    public void FillTehsil(string districtid)
    {
        try
        {
            ddlselecttehsil.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = comDB_Obj.Fill_Tehsil_Name_By_District_ID(districtid);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();
                ListItem listforstate = new ListItem("Select Tehsil", "0");
                ddlselecttehsil.Items.Add(listforstate);
                list = com_Obj.FillDropDownList(ds1, 0, "TH_NAME");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds1.Tables[0].Rows[j][0].ToString());
                    ddlselecttehsil.Items.Add(li);
                    j++;

                }

            }
            else
            {


                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void FillTehsil()
    {
        try
        {
            ddlselecttehsil.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = null;
            if (ddlselectdistrict1.SelectedIndex != 0)
            {
                ds1 = comDB_Obj.GetTehsil(Convert.ToInt32(ddlselectdistrict1.SelectedValue), 2);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ddlselecttehsil.DataSource = ds1;
                    ddlselecttehsil.DataTextField = "Tehsil_Name";
                    ddlselecttehsil.DataValueField = "Tehsil";
                    ddlselecttehsil.DataBind();
                    ddlselecttehsil.Items.Insert(0, "Select Tehsil");
                }
                else
                {

                    ddlselecttehsil.Items.Clear();
                    ddlselectgp.Items.Clear();
                    ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                    ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                    //return;
                }

            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void FillGramPanchyat()
    {
        try
        {
            DDlRelocatedGrampanChyat.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = null;
            if (DDlRelocatedGrampanChyat.SelectedIndex != 0)
            {
                ds1 = comDB_Obj.GetGramPanchyat(Convert.ToInt32(ddlselecttehsil.SelectedValue), 3);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    DDlRelocatedGrampanChyat.DataSource = ds1;
                    DDlRelocatedGrampanChyat.DataTextField = "GramPanchayatName";
                    DDlRelocatedGrampanChyat.DataValueField = "GramPanchayatID";
                    DDlRelocatedGrampanChyat.DataBind();
                    //Select Grampanchayat
                    DDlRelocatedGrampanChyat.Items.Insert(0, "Select Grampanchayat");
                }
                else
                {

                    DDlRelocatedGrampanChyat.Items.Add(new ListItem("No Record", "0"));
                }

            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlselecttehsil_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlselecttehsil.SelectedIndex != 0)
        {
           // lblmsgth.Text = "";
            // FillGP(ddlselecttehsil.SelectedValue.ToString());
            FillGramPanchyat();
        }
        else
        {
            ddlselectgp.Items.Clear();

            ddlselectgp.Items.Add(new ListItem("No Record", "0"));
        }
        if (ddlselecttehsil.SelectedValue.ToString().Equals("0"))
        {
            DDlRelocatedGrampanChyat.Items.Clear();
            DDlRelocatedGrampanChyat.Items.Add(new ListItem("No Record", "0"));
        }
        if (ddlselecttehsil.SelectedValue.ToString().Equals("Select Tehsil"))
        {
            DDlRelocatedGrampanChyat.Items.Clear();
            DDlRelocatedGrampanChyat.Items.Add(new ListItem("Select Grampanchayat", "0"));
        }
    }
    public void FillGP(string tehsilid)
    {
        try
        {
            ddlselectgp.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = comDB_Obj.Fill_GP_Name_By_Tehsil_ID(tehsilid);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();
                ListItem listforstate = new ListItem("Select Grampanchayat", "0");
                ddlselectgp.Items.Add(listforstate);
                list = com_Obj.FillDropDownList(ds1, 0, "GP_NAME");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds1.Tables[0].Rows[j][0].ToString());
                    ddlselectgp.Items.Add(li);
                    j++;

                }

            }
            else
            {

                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }


        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlselectgp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlselectgp.SelectedValue.ToString().Equals("0"))
        {
            //lblmsggp.Text = "";
        }
    }
    public void FillVillage(string gp)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = comDB_Obj.Fill_Village_By_GP_ID(gp);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();
                ListItem li2 = new ListItem("Select Name", "0");
                ddlselectname.Items.Add(li2);
                list = com_Obj.FillDropDownList(ds, 0, "VILL_NM");
                int i = list.Count - 1;
                int j = 0;
                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j][0].ToString());

                    ddlselectname.Items.Add(li);
                    ++j;

                }


            }
            else
            {


                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void ImgbtnSubmit_Click(object sender, EventArgs e)
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

                        //if (Page.IsValid)
                        //{
                        //    try
                        //    {
                                RELO_ENT_Obj._RELOC_AREA_ID = Request.QueryString[WebConstant.QueryStringEnum.RELO_ID].ToString();
                                RELO_ENT_Obj._VILL_ID = Request.QueryString["village_id"].ToString();
                                RELO_ENT_Obj._ST_NM = ddlselectstate1.SelectedValue.ToString();
                                RELO_ENT_Obj._DT_NM = ddlselectdistrict1.SelectedValue.ToString();
                                RELO_ENT_Obj._TH_NM = ddlselecttehsil.SelectedValue.ToString();
                                RELO_ENT_Obj._GP_NM = DDlRelocatedGrampanChyat.SelectedValue.ToString();
                                RELO_ENT_Obj._VILL_NM = DdlRelocatedVillageName.SelectedValue.ToString();
                                RELO_ENT_Obj._RELOC_SITE_ADD = common.RemoveUnnecessaryHtmlTagHtml(txraddress.Text.Trim());
                                RELO_ENT_Obj._COMMENT = common.RemoveUnnecessaryHtmlTagHtml(txtcomment.Text.Trim());
                                RELO_ENT_Obj.Latitude = HttpUtility.HtmlEncode(TxtLatitude.Text.Trim());
                                RELO_ENT_Obj.Longitude = HttpUtility.HtmlEncode(TxtLongitude.Text.Trim());

                                check = RELODB_Obj.Update_Relocation_Site(RELO_ENT_Obj);
                                lblMsg.Text = "";
                                if (check == true)
                                {
                                    // Session["msg"] = "Your changes have been saved.";
                                    //  Session["BackUrl"] = "~/Auth/AdminPanel/RELOCATIONSITE/Relocation_Management.aspx";
                                    //  Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                    //      RegisterClientScriptBlock("showmessage",
                                    //"<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                                    lblMsg.Text = "Your changes have been saved.";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;

                                    new AuditTrailDB().AUDIT_TRAIL(Session["LoginID"].ToString(), "Edit", 10);
                                }
                                else
                                {
                                    lblMsg.Text = "error";

                                }

                        //    }

                        //    catch (Exception e4)
                        //    {

                        //    }
                        //}
                    }
                }
                //}
            }
        }
        catch
        {
            throw;
        }
        // }
    }
    
    
    protected void ImgbtnCancel_Click(object sender, EventArgs e)
    {
        Load_Village_Info(Request.QueryString[WebConstant.QueryStringEnum.RELO_ID].ToString().Trim());
    }
    protected void ImgbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/RelocationSite/Relocation_Management.aspx?village_id=" + Request.QueryString["village_id"] + "&inid=" + Request.QueryString["inid"] + "&vcode=" + Request.QueryString["vcode"] + "&vname=" + Request.QueryString["vname"]);
       // Response.Redirect(ResolveUrl("~/AUTH/adminpanel/RELOCATIONSITE/Relocation_Management.aspx?vid=" + Request.QueryString["vid"].ToString()), false);
    }
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void GetVillageRelocationSuperAdmin()
    {
        try
        {//ddlselectstate1

            DdlRelocatedVillageName.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.GetVillageNotRelocatedSuper(Convert.ToInt32(ddlselectstate1.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                DdlRelocatedVillageName.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    DdlRelocatedVillageName.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                DdlRelocatedVillageName.Items.Add(new ListItem("No Record", "0"));
                // ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlselectstate1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["UserType"].ToString().Equals("1"))
        {
            GetVillageRelocationSuperAdmin();
            if (!ddlselectstate1.SelectedValue.ToString().Equals("0"))
            {
                FillDistrict(null);
            }
            else
            {
                ddlselectdistrict1.Items.Clear();
                ddlselectdistrict1.Items.Add(new ListItem("No Record", "0"));
            }
        }
        else
        {

            if (!ddlselectstate1.SelectedValue.ToString().Equals("0"))
            {
                FillDistrict1(null);
            }
            else
            {
                ddlselectdistrict1.Items.Clear();
                ddlselectdistrict1.Items.Add(new ListItem("No Record", "0"));
            }
        }
    }
   
    protected void ddlselectdistrict1_SelectedIndexChanged(object sender, EventArgs e)
    {//ddlselectstate1_SelectedIndexChanged
        if (ddlselectdistrict1.SelectedIndex != 0)
        {
            //lblmsgdt.Text = "";
            // FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
            FillTehsil();
        }
        else
        {
            

            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
            DDlRelocatedGrampanChyat.Items.Add(new ListItem("No Record", "0"));

        }
        if (ddlselectdistrict1.SelectedValue.ToString().Equals("0"))
        {
            ddlselecttehsil.Items.Clear();
            DDlRelocatedGrampanChyat.Items.Clear();

            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
            DDlRelocatedGrampanChyat.Items.Add(new ListItem("No Record", "0"));
        }
    }
}