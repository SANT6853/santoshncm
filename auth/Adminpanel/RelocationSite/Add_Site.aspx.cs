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

public partial class auth_Adminpanel_RelocationSite_Add_Site : CrsfBase
{
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    VillageDB VILL_DB_Obj = new VillageDB();

    Realocation_AreaEntiry RELO_ENT_Obj = new Realocation_AreaEntiry();
    Realocation_AreaDB RELODB_Obj = new Realocation_AreaDB();
    VillageDB VillDB_Obj = new VillageDB();
    static bool check = false, flag = false;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {


            lblMsg.Text = "";
            // GenerateCodeForVillage();
            if (Session["UserType"].ToString() == null)
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"), true);
                return;
            }
           
            if (!IsPostBack)
            {
                ddlselectname.Enabled = false;
                FillStates(); 
                if (Session["UserType"].ToString().Equals("4"))
                {
                    FillVillage(Convert.ToInt32(Session["User_Id"]));
                    ddlselectname.SelectedItem.Text = Request.QueryString["VillageName"].ToString();
                    GetVillageRelocation(Convert.ToInt32(Session["User_Id"]));
                    ddlselectstate1.SelectedValue = Session["PermissionState"].ToString();
                    ddlselectstate1.Enabled = false;
                    if (!ddlselectstate1.SelectedValue.ToString().Equals("0"))
                    {
                        FillDistrict(null);
                    }
                    else
                    {
                        ddlselectdistrict.Items.Clear();
                        ddlselectdistrict.Items.Add(new ListItem("No Record", "0"));
                    }
                    if (ddlselectdistrict.SelectedValue.ToString().Equals("0"))
                    {
                       
                        ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                        ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                    }
                  
                }
                if (Session["UserType"].ToString().Equals("1"))
                {
                    FillVillage1();
                    ddlselectname.SelectedItem.Text = Request.QueryString["VillageName"].ToString();
                    //GetVillageRelocationSuperAdmin(Convert.ToInt32(Session["User_Id"]));
                    if (ddlselectdistrict.SelectedValue.ToString().Equals("0"))
                    {

                        ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                        ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                    }
                   
                }
              
                                 
                  //  FillStates();
                   // FillAll();
                   
                
            }
        }
        catch (Exception e3)
        {
           // Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx"), true);
            return;
        }

    }
    public void GetVillageRelocationSuperAdmin()
    {
        try
        {

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
    //public void FillAll()
    //{
    //    DataSet ds = VILL_DB_Obj.Get_OthersIDs_By_VillId(Session["VillageId"].ToString());
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        lblvillcode.Text = ds.Tables[0].Rows[0][0].ToString();
    //        lblvillname.Text = ds.Tables[0].Rows[0][1].ToString();
    //        DataSet ds1 = comDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(ds.Tables[0].Rows[0][2].ToString(), ds.Tables[0].Rows[0][4].ToString(), ds.Tables[0].Rows[0][3].ToString(), ds.Tables[0].Rows[0][5].ToString(), ds.Tables[0].Rows[0][6].ToString());
    //        if (ds1.Tables[0].Rows.Count > 0)
    //        {
    //            lblstatename.Text = ds1.Tables[0].Rows[0][0].ToString();
    //            lbldistrict.Text = ds1.Tables[1].Rows[0][0].ToString();
    //            lblreaserve.Text = ds1.Tables[2].Rows[0][0].ToString();
    //            lbltehsil.Text = ds1.Tables[3].Rows[0][0].ToString();
    //            lblgp.Text = ds1.Tables[4].Rows[0][0].ToString();
    //            //reservecode = ds1.Tables[2].Rows[0][1].ToString();



    //        }

    //    }
    //}
    public void FillStates()
    {
        try
        {
            //ddlselectstate.Items.Clear();
            ddlselectstate1.Items.Clear();
            DataSet ds = new DataSet();
            ds = comDB_Obj.FillStates_District_ReserveDB(null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();

                //ddlselectstate.Items.Add(new ListItem("Select State", "0"));
                ddlselectstate1.Items.Add(new ListItem("Select State", "0"));

                list = com_Obj.FillDropDownList(ds, 0, "ST_NAME");
                int i = list.Count - 1;
                int j = 0;


                while (j <= i)
                {
                    //ddlselectstate.Items.Add(new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["ST_ID"].ToString()));
                    ddlselectstate1.Items.Add(new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["ST_ID"].ToString()));
                    j++;
                }


                //ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
                ddlselectdistrict.Items.Add(new ListItem("No Record", "0"));
                //ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                //ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                //ddlselectname.Items.Add(new ListItem("No Record", "0"));


            }
            else
            {

                // ddlselectstate.Items.Add(new ListItem("No Record", "0"));
                ddlselectstate1.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void FillVillage(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            //ds = comDB_Obj.Fill_Village_By_GP_ID(gp);
            ds = new VillageDB().Fill_VillageCode_And_Name(userid);
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
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j][2].ToString());

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
    public void FillVillage1()
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            //ds = comDB_Obj.Fill_Village_By_GP_ID(gp);
           // ds = new VillageDB().Fill_VillageCode_And_Name1(userid);
            ds = new VillageDB().GetAllvillage();
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
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j][2].ToString());

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
                            //{


                                if (Session["UserType"].ToString().Equals("4") || Session["UserType"].ToString().Equals("1"))
                                {
                                    RELO_ENT_Obj._VILL_ID = Request.QueryString["village_id"].ToString();
                                }

                                if (ddlselectstate1.SelectedValue.ToString().Equals("0"))
                                {
                                    lblMsg.Text = "Please Select State Name";
                                    return;
                                }
                                if (ddlselectdistrict.SelectedValue.ToString().Equals("0"))
                                {
                                    lblMsg.Text = "Please Select District Name";
                                    return;
                                }
                                RELO_ENT_Obj._ST_NM = ddlselectstate1.SelectedValue.ToString();
                                RELO_ENT_Obj._DT_NM = ddlselectdistrict.SelectedValue.ToString();
                                RELO_ENT_Obj._TH_NM = ddlselecttehsil.SelectedValue.ToString();
                                RELO_ENT_Obj._GP_NM = ddlselectgp.SelectedValue.ToString();
                                RELO_ENT_Obj._VILL_NM = DdlRelocatedVillageName.SelectedValue.ToString();
                                RELO_ENT_Obj._RELOC_SITE_ADD = common.RemoveUnnecessaryHtmlTagHtml(txraddress.Text.Trim());
                                RELO_ENT_Obj._COMMENT = common.RemoveUnnecessaryHtmlTagHtml(txtcomment.Text.Trim());
                                RELO_ENT_Obj.Userid = Convert.ToInt32(Session["User_Id"]);

                                RELO_ENT_Obj.Latitude = HttpUtility.HtmlEncode(TxtLatitude.Text.Trim());
                                RELO_ENT_Obj.Longitude = HttpUtility.HtmlEncode(TxtLongitude.Text.Trim());
                                check = RELODB_Obj.Add_Relocation_Site(RELO_ENT_Obj);
                                if (check == true)
                                {
                                    new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 10);


                                    // Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Message.aspx?mid=14"), false);
                                    Response.Redirect(ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management_Edit.aspx?village_id=" + Request.QueryString["village_id"] + "&inid=" + Request.QueryString["inid"] + "&vcode=" + Request.QueryString["vcode"] + "&vname=" + Request.QueryString["vname"] + "&SaveStatus=" + "Village has been relocated successfully."), false);
                                }
                                else
                                {
                                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }

                            //}

                            //catch (Exception e4)
                            //{
                            //    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                            //    lblMsg.ForeColor = System.Drawing.Color.Red;
                            //}
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
        txraddress.Text = "";
        txtcomment.Text = "";

        txtgp.Text = "";
        ddlselectstate1.SelectedValue = "0";
        txttehsil.Text = "";
        //txtvillage.Text = "";
        //ddlSelectDistrict.Items.Clear();
        //ddlselectgp.Items.Clear();
        //ddlselecttehsil.Items.Clear();
        ddlselectname.Items.Clear();
        ddlselectdistrict.Items.Clear();
        //ddlselectreserve.Items.Clear();
        //ddlselectstate.SelectedValue = "0";

        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/RELOCATIONSITE/Add_Site.aspx"), false);

    }
    protected void ImgbtnBack_Click(object sender, EventArgs e)
    {
        //auth/adminpanel/VILLAGE/Village_Management.aspx Response.Redirect(ResolveUrl("~/AUTH/adminpanel/RELOCATIONSITE/Relocation_Management.aspx"), false);
       // Response.Redirect(ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx"), false);
        Response.Redirect(ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management_Edit.aspx?village_id=" + Request.QueryString["village_id"] + "&inid=" + Request.QueryString["inid"] + "&vcode=" + Request.QueryString["vcode"] + "&vname=" + Request.QueryString["vname"]), false);
    }
    
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {

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
                ddlselectdistrict.Items.Clear();
                ddlselectdistrict.Items.Add(new ListItem("No Record", "0"));
            }
        }
        else
        {
            if (!ddlselectstate1.SelectedValue.ToString().Equals("0"))
            {
                FillDistrict(null);
            }
            else
            {
                ddlselectdistrict.Items.Clear();
                ddlselectdistrict.Items.Add(new ListItem("No Record", "0"));
            }
        }
    }
    public void FillDistrict(string reserveid)
    {
        try
        {
            ddlselectdistrict.Items.Clear();

            DataSet ds1 = new DataSet();

            ds1 = comDB_Obj.FillStates_District_ReserveDB(ddlselectstate1.SelectedValue.ToString(), null);


            if (ds1.Tables[1].Rows.Count > 0)
            {
                ListItem listfordistrict = new ListItem("Select District", "0");
                ddlselectdistrict.Items.Add(listfordistrict);
                List<string> list = new List<string>();

                list = com_Obj.FillDropDownList(ds1, 1, "DT_NAME");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds1.Tables[1].Rows[j][0].ToString());
                    ddlselectdistrict.Items.Add(li);
                    j++;

                }




            }
            else
            {

                ddlselectdistrict.Items.Add(new ListItem("No Record", "0"));

            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlselectdistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlselectdistrict.SelectedIndex != 0)
        {
            lblmsgdt.Text = "";
            // FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
            FillTehsil();
        }
        else
        {
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
          
            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
            ddlselectgp.Items.Add(new ListItem("No Record", "0"));

        }
    }
    public void FillTehsil()
    {
        try
        {
            ddlselecttehsil.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = null;
            if (ddlselectdistrict.SelectedIndex != 0)
            {
                ds1 = comDB_Obj.GetTehsil(Convert.ToInt32(ddlselectdistrict.SelectedValue), 2);
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
            ddlselectgp.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = null;
            if (ddlselectgp.SelectedIndex != 0)
            {
                ds1 = comDB_Obj.GetGramPanchyat(Convert.ToInt32(ddlselecttehsil.SelectedValue), 3);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    ddlselectgp.DataSource = ds1;
                    ddlselectgp.DataTextField = "GramPanchayatName";
                    ddlselectgp.DataValueField = "GramPanchayatID";
                    ddlselectgp.DataBind();
                    //Select Grampanchayat
                    ddlselectgp.Items.Insert(0, "Select Grampanchayat");
                }
                else
                {

                    ddlselectgp.Items.Add(new ListItem("No Record", "0"));
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
            lblmsgth.Text = "";
            // FillGP(ddlselecttehsil.SelectedValue.ToString());
            FillGramPanchyat();
        }
        else
        {
            ddlselectgp.Items.Clear();

            ddlselectgp.Items.Add(new ListItem("No Record", "0"));
        }
    }
    protected void ddlselectgp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlselectgp.SelectedValue.ToString().Equals("0"))
        {
            lblmsggp.Text = "";
        }
    }
}