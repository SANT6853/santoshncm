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
public partial class auth_Adminpanel_VILLAGE_Village_Management_Add : System.Web.UI.Page
{
    public String characters = "abcdeCDEfghijkzMABFHIJKLNOlmnopqrPQRSTstuvwxyUVWXYZ";

    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Village Vill_Obj = new Village();
    VillageEntity VillEntity_Obj = new VillageEntity();
    VillageDB VillDB_Obj = new VillageDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    StateEntity State_Entity = new StateEntity();
    StateDB STDB_Obj = new StateDB();
    Reserve_Entity RSVREntity_Obj = new Reserve_Entity();
    DistrictEntity Dist_Ent_Obj = new DistrictEntity();
    Tehsil_Entity TH_EN_Obj = new Tehsil_Entity();
    Grampanchayat_Entity GP_EN_Obj = new Grampanchayat_Entity();
    AuditTrailDB Audit_ObjDB = new AuditTrailDB();
    Project_Variables p_Var = new Project_Variables();
    public static string stateid;
    static bool check, flag = false;
    public static int total = 0;
    DataSet ds = new DataSet();
    public string mime = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CalendarExtender1.EndDate = DateTime.Now;
        CaleTxtDateMeeting.EndDate = DateTime.Now;
        CalendarTxtCuttOffDate.EndDate = DateTime.Now;
        if (Session["User_Id"] == null || Session["User_Id"].ToString() == "")
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }

        try
        {
            HiddenField1.Value = com_Obj.fordate();

            lblMsg.Text = "";

            if (Session["User_Id"].ToString() == null || Session["User_Id"].ToString().Equals(""))
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"), true);
                return;
            }
            if (!IsPostBack)
            {
                String p = UniqueNumber();
                txtcode.Text = p;
                txtcode.Enabled = false;
                //GenerateCodeForVillage();
                if (Session["UserType"].ToString().Equals("1"))
                {
                    ddlselectreserve.Visible = true;
                    ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
                    TdState.Visible = true;
                    TdddlState.Visible = true;
                    LblStatedv.Visible = true;
                    Td1.Visible = true;
                    FillState();
                    //FillDistrict1();
                }
                if (Session["UserType"].ToString().Equals("4"))
                {

                    FillDistrict();
                }

            }
        }
        catch (Exception e3)
        {
            //Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx"), true);
            //return;
        }

    }

    public string UniqueNumber()
    {
        Random unique1 = new Random();
        string s = "V";
        int unique;
        int n = 0;
        while (n < 10)
        {
            if (n % 2 == 0)
            {
                s += unique1.Next(10).ToString();

            }
            else
            {
                unique = unique1.Next(52);
                if (unique < this.characters.Length)
                    s = String.Concat(s, this.characters[unique]);
            }
            //Label2.Text = s.ToString();
            n++;
        }
        return s;
    }
    public void FillDistrict()
    {
        try
        {
            ddlSelectDistrict.Items.Clear();
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = null;
            ds1 = comDB_Obj.GetDistrict(Convert.ToInt32(Session["PermissionState"]), 1);

            if (ds1.Tables[0].Rows.Count > 0)
            {

                ddlSelectDistrict.DataSource = ds1;
                ddlSelectDistrict.DataTextField = "DistName";
                ddlSelectDistrict.DataValueField = "DistID";
                ddlSelectDistrict.DataBind();

                ddlSelectDistrict.Items.Insert(0, "Select District");
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }
            else
            {

                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void FillState()
    {
        try
        {
            DdlState.Items.Clear();
            ddlSelectDistrict.Items.Clear();
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
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
                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }
            else
            {
                DdlState.Items.Add(new ListItem("No Record", "0"));
                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void FillDistrict1()
    {
        try
        {
            ddlSelectDistrict.Items.Clear();
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
            DataSet ds1 = new DataSet();
            ds1 = null;
            ds1 = comDB_Obj.GetDistrict1(Convert.ToInt32(DdlState.SelectedValue), 1);

            if (ds1.Tables[0].Rows.Count > 0)
            {

                ddlSelectDistrict.DataSource = ds1;
                ddlSelectDistrict.DataTextField = "DistName";
                ddlSelectDistrict.DataValueField = "DistID";
                ddlSelectDistrict.DataBind();

                ddlSelectDistrict.Items.Insert(0, "Select District");
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }
            else
            {

                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
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
            if (ddlSelectDistrict.SelectedIndex != 0)
            {
                ds1 = comDB_Obj.GetTehsil(Convert.ToInt32(ddlSelectDistrict.SelectedValue), 2);
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
    public void FillState_District_Rerserve_Name()
    {
        try
        {
            DataSet ds1 = new DataSet();
            ds1 = comDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(Session["State_Id"].ToString(), null, Session["Reserve_Id"].ToString(), null, null);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                //txtStateName.Text = ds1.Tables[0].Rows[0][0].ToString();
                //txtReserveName.Text = ds1.Tables[2].Rows[0][0].ToString();
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void FillDistrict(string reserveid)
    {
        try
        {
            ddlSelectDistrict.Items.Clear();
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
            DataSet ds1 = new DataSet();
            if (flag == false)
            {
                //ds1 = comDB_Obj.FillStates_District_ReserveDB(null, ddlselectreserve.SelectedValue.ToString());
                ds1 = comDB_Obj.FillStates_District_ReserveDB(Session["STATEID"].ToString(), Session["RESERVEID"].ToString());

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


                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));

            }
            else
            {

                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    void GenerateCodeForVillage()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = VillDB_Obj.GenerateCodeForVillageDB();
            if (ds.Tables[0].Rows.Count > 0)
            {

                int vill_code = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                if (vill_code < 9)
                {
                    ViewState["VillageCode"] = "00" + Convert.ToString(vill_code + 1);
                }
                else if (vill_code < 100)
                {
                    ViewState["VillageCode"] = "0" + Convert.ToString(vill_code + 1);
                }
                else
                {
                    ViewState["VillageCode"] = Convert.ToString(vill_code + 1);
                }
                txtcode.Text = ViewState["VillageCode"].ToString();
            }
        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlSelectReserve_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlSelectDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSelectDistrict.SelectedIndex != 0)
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

                ddlselecttehsil.Items.Clear();
                ddlselectgp.Items.Clear();
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
                //return;
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
            }


        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlselectgp_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlselectgp.SelectedValue.ToString().Equals("0"))
        {
            lblmsggp.Text = "";
        }
    }
    //public void FillStates()
    //{
    //    try
    //    {
    //        ddlselectstate.Items.Clear();
    //        DataSet ds = new DataSet();
    //        ds = comDB_Obj.FillStates_District_ReserveDB(null, null);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            List<string> list = new List<string>();
    //            ListItem listforstate = new ListItem("Select State", "0");
    //            ddlselectstate.Items.Add(listforstate);

    //            list = com_Obj.FillDropDownList(ds, 0, "ST_NAME");
    //            int i = list.Count - 1;
    //            int j = 0;

    //            while (j <= i)
    //            {
    //                ListItem li = new ListItem(list[j].ToString(),  ds.Tables[0].Rows[j]["ST_ID"].ToString());
    //                ddlselectstate.Items.Add(li);
    //                j++;


    //            }


    //            ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
    //            ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
    //            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
    //            ddlselectgp.Items.Add(new ListItem("No Record", "0"));


    //        }
    //        else
    //        {

    //            ddlselectstate.Items.Add(new ListItem("No Record", "0"));
    //        }

    //    }
    //    catch (Exception e2)
    //    {
    //        lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
    //        lblMsg.ForeColor = System.Drawing.Color.Red;
    //    }
    //}
    //protected void ddlselectstate_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    ddlselectreserve.Items.Clear();
    //    ddlSelectDistrict.Items.Clear();
    //    ddlselecttehsil.Items.Clear();
    //    ddlselectgp.Items.Clear();
    //    if (ddlselectstate.SelectedValue.ToString().Equals("0"))
    //    {

    //        ddlselectreserve.Items.Clear();
    //        ddlSelectDistrict.Items.Clear();
    //        ddlselecttehsil.Items.Clear();
    //        ddlselectgp.Items.Clear();

    //        ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
    //        ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
    //        ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
    //        ddlselectgp.Items.Add(new ListItem("No Record", "0"));
    //    }
    //    else
    //    {
    //        lblmsgstate.Text = "";

    //        FillReserve();

    //    }

    //}
    //public void FillReserve()
    //{
    //    try
    //    {
    //        ddlselectreserve.Items.Clear();
    //        string stateid = ddlselectstate.SelectedValue.ToString();
    //        ddlselectreserve.Items.Clear();
    //        DataSet ds = new DataSet();
    //        ds = comDB_Obj.FillStates_District_ReserveDB(stateid, null);

    //        if (ds.Tables[2].Rows.Count > 0)
    //        {
    //            List<string> list = new List<string>();
    //            ListItem listforreserve = new ListItem("Select Reserve", "0");
    //            ddlselectreserve.Items.Add(listforreserve);
    //            list = com_Obj.FillDropDownList(ds, 2, "RSRV_AREA_NM");
    //            int i = list.Count - 1;
    //            int j = 0;

    //            while (j <= i)
    //            {
    //                ListItem li = new ListItem(list[j].ToString(), ds.Tables[2].Rows[j][0].ToString());
    //                ddlselectreserve.Items.Add(li);
    //                j++;

    //            }

    //            ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
    //            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
    //            ddlselectgp.Items.Add(new ListItem("No Record", "0"));
    //        }
    //        else
    //        {

    //            ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
    //            ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
    //            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
    //            ddlselectgp.Items.Add(new ListItem("No Record", "0"));
    //        }

    //    }
    //    catch (Exception e2)
    //    {
    //        lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
    //        lblMsg.ForeColor = System.Drawing.Color.Red;
    //    }
    //}
    //protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    ddlSelectDistrict.Items.Clear();
    //    ddlselecttehsil.Items.Clear();
    //    ddlselectgp.Items.Clear();
    //    if (ddlselectreserve.SelectedValue.ToString().Equals("0"))
    //    {

    //        ddlSelectDistrict.Items.Clear();
    //        ddlselecttehsil.Items.Clear();
    //        ddlselectgp.Items.Clear();


    //        ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
    //        ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
    //        ddlselectgp.Items.Add(new ListItem("No Record", "0"));
    //    }
    //    else
    //    {
    //        lblmsgreserve.Text = "";
    //        FillDistrict(ddlselectreserve.SelectedValue.ToString());

    //    }
    //}
    protected void ddlVillageLegalStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlVillageLegalStatus.SelectedValue.ToString().Equals("0"))
        {
            lblmsglglstts.Text = "";
        }
        else if (ddlVillageLegalStatus.SelectedValue.ToString().Equals("0"))
        {

            lblmsglglstts.Text = WebConstant.UserFriendlyMessages.selectvilllglstts;
            lblmsglglstts.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }
    protected void ddlVillageStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlVillageStatus.SelectedValue.ToString().Equals("0"))
        {
            lblmsgvillstts.Text = "";
        }
        else if (ddlVillageStatus.SelectedValue.ToString().Equals("0"))
        {

            lblmsgvillstts.Text = WebConstant.UserFriendlyMessages.selectvillstts;
            lblmsgvillstts.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }
    protected void ddlcorebufferstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlcorebufferstatus.SelectedValue.ToString().Equals("0"))
        {
            lblmsgcrbuffstts.Text = "fdsf";

        }
        else if (ddlcorebufferstatus.SelectedValue.ToString().Equals("0"))
        {

            lblmsgcrbuffstts.Text = WebConstant.UserFriendlyMessages.selectviilcrbuffstts;
            lblmsgcrbuffstts.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }
    #region Custom validator to validate extension of upload pdf files
    [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
    private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
    [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
    [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
    System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
    System.UInt32 dwMimeFlags,
    out System.UInt32 ppwzMimeOut,
    System.UInt32 dwReserverd);  
   protected void ImgbtnSubmit_Click(object sender, EventArgs e)
    {
        LblVpop.Text = "";
        
        #region Control Values assigned
        if (Convert.ToDateTime(common.insertDate(txtsurdate.Text)) > DateTime.Now)
        {
            lblMsg.Text = "Date of Survey Can Not Be Greater Than Today's Date";
            return;
        }


        else if (ddlSelectDistrict.SelectedValue.ToString().Equals("0"))
        {

            lblmsgdt.Text = WebConstant.UserFriendlyMessages.selectDistrictname;
            lblmsgdt.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else if (ddlselecttehsil.SelectedValue.ToString().Equals("0"))
        {

            lblmsgth.Text = WebConstant.UserFriendlyMessages.selectTehsilname;
            lblmsgth.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else if (ddlselectgp.SelectedValue.ToString().Equals("0"))
        {

            lblmsggp.Text = WebConstant.UserFriendlyMessages.selectGrampanchayatname;
            lblmsggp.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else if (ddlVillageLegalStatus.SelectedValue.ToString().Equals("0"))
        {

            lblmsglglstts.Text = WebConstant.UserFriendlyMessages.selectvilllglstts;
            lblmsglglstts.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else if (ddlVillageStatus.SelectedValue.ToString().Equals("0"))
        {

            lblmsgvillstts.Text = WebConstant.UserFriendlyMessages.selectvillstts;
            lblmsgvillstts.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else if (ddlcorebufferstatus.SelectedValue.ToString().Equals("0"))
        {

            //lblmsgcrbuffstts.Text = WebConstant.UserFriendlyMessages.selectviilcrbuffstts;
            // lblmsgcrbuffstts.ForeColor = System.Drawing.Color.Red;
            // return;
        }


        VillEntity_Obj._VILL_CD = txtcode.Text;

        if (State_Entity._ST_ID < 10)
        {
            VillEntity_Obj._ST_VILL_CD = "0" + State_Entity._ST_ID + VillEntity_Obj._VILL_CD;
        }
        else
        {
            VillEntity_Obj._ST_VILL_CD = State_Entity._ST_ID + VillEntity_Obj._VILL_CD;
        }

        Dist_Ent_Obj._DT_ID = Convert.ToInt32(ddlSelectDistrict.SelectedValue);

        TH_EN_Obj._TH_ID = Convert.ToInt32(ddlselecttehsil.SelectedValue.ToString());
        GP_EN_Obj._GP_ID = Convert.ToInt32(ddlselectgp.SelectedValue.ToString());
        VillEntity_Obj._VILL_NM = txtname.Text;


        if (txtland.Text == "")
        {
            VillEntity_Obj._VILL_TOT_LND_AREA = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_LND_AREA = Convert.ToDecimal(txtland.Text);
        }

        if (txtagri.Text == "")
        {
            VillEntity_Obj._VILL_TOT_AGRI_LND_AREA = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_AGRI_LND_AREA = Convert.ToDecimal(txtagri.Text);
        }
        if (txtnonagri.Text == "")
        {
            VillEntity_Obj._VILL_TOT_NON_AGRI_LND_AREA = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_NON_AGRI_LND_AREA = Convert.ToDecimal(txtnonagri.Text);
        }
        if (ddlVillageLegalStatus.SelectedValue.ToString().Equals("0"))
        {
            lblMsg.Text = "Please Select Village Legal Status";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        VillEntity_Obj._VILL_LGL_STAT = ddlVillageLegalStatus.SelectedValue.ToString();
        if (txtfamilies.Text == "")
        {
            VillEntity_Obj._VILL_NO_FM = 0;
        }
        else
        {
            VillEntity_Obj._VILL_NO_FM = Convert.ToInt64(txtfamilies.Text);
        }
        if (txtlivestock.Text == "")
        {
            VillEntity_Obj._VILL_NO_LIV_STOK = 0;
        }
        else
        {
            VillEntity_Obj._VILL_NO_LIV_STOK = Convert.ToInt32(txtlivestock.Text);
        }

        if (ddlVillageStatus.SelectedValue.ToString().Equals("0"))
        {
            lblMsg.Text = "Please Select Village Status";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        VillEntity_Obj._VILL_STAT = ddlVillageStatus.SelectedValue.ToString();

        if (txtmalepop.Text == "")
        {
            VillEntity_Obj._VILL_MALE = 0;
        }
        else
        {
            VillEntity_Obj._VILL_MALE = Convert.ToInt32(txtmalepop.Text);
        }

        if (txtfemalepop.Text == "")
        {
            VillEntity_Obj._VILL_FEMALE = 0;
        }
        else
        {
            VillEntity_Obj._VILL_FEMALE = Convert.ToInt32(txtfemalepop.Text);
        }
        // VillEntity_Obj._VILL_CUT_DT = Convert.ToDateTime(common.insertDate(txtcutdate.Text));

        if (txtotherland.Text == "")
        {
            VillEntity_Obj._VILL_OTHER_LND_AREA = 0;
        }
        else
        {
            VillEntity_Obj._VILL_OTHER_LND_AREA = Convert.ToDecimal(txtotherland.Text);
        }

        if (txtlivestock.Text == "")
        {
            VillEntity_Obj._VILL_NO_LIV_STOK = 0;
        }
        else
        {
            // VillEntity_Obj._VILL_SURVEY_DT = Convert.ToDateTime(common.insertDate(txtsurdate.Text));
            VillEntity_Obj._VILL_NO_LIV_STOK = Convert.ToInt32(txtlivestock.Text);
        }
        VillEntity_Obj._VILL_SURVEY_DT = Convert.ToDateTime(common.insertDate(txtsurdate.Text));
        VillEntity_Obj._COMMENT = common.RemoveUnnecessaryHtmlTagHtml(txtcomments.Text.Trim());
        VillEntity_Obj._VILL_CR_BFFR_STS = Convert.ToInt32(ddlcorebufferstatus.SelectedValue);

        if (txtlang1.Text == "")
        {
            VillEntity_Obj._VILL_LNG1 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNG1 = Convert.ToDecimal(txtlang1.Text);
        }

        if (txtlang2.Text == "")
        {
            VillEntity_Obj._VILL_LNG2 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNG2 = Convert.ToDecimal(txtlang2.Text);
        }

        if (txtlang3.Text == "")
        {
            VillEntity_Obj._VILL_LNG3 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNG3 = Convert.ToDecimal(txtlang3.Text);
        }

        if (txtlang4.Text == "")
        {
            VillEntity_Obj._VILL_LNG4 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNG4 = Convert.ToDecimal(txtlang4.Text);
        }

        if (txtlong1.Text == "")
        {
            VillEntity_Obj._VILL_LONG1 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONG1 = Convert.ToDecimal(txtlong1.Text);
        }

        if (txtlong2.Text == "")
        {
            VillEntity_Obj._VILL_LONG2 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONG2 = Convert.ToDecimal(txtlong2.Text);
        }

        if (txtlong3.Text == "")
        {
            VillEntity_Obj._VILL_LONG3 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONG3 = Convert.ToDecimal(txtlong3.Text);
        }

        if (txtlong4.Text == "")
        {
            VillEntity_Obj._VILL_LONG4 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONG4 = Convert.ToDecimal(txtlong4.Text);
        }

        if (txtobc.Text == "")
        {
            VillEntity_Obj._VILL_TOT_OBC = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_OBC = Convert.ToInt32(txtobc.Text);
        }


        if (txtother.Text == "")
        {
            VillEntity_Obj._VILL_TOT_OTH = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_OTH = Convert.ToInt32(txtother.Text);
        }


        if (txtsc.Text == "")
        {
            VillEntity_Obj._VILL_TOT_SC = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_SC = Convert.ToInt32(txtsc.Text);
        }


        if (txtst.Text == "")
        {
            VillEntity_Obj._VILL_TOT_ST = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_ST = Convert.ToInt32(txtst.Text);
        }


        if (txtcnb.Text == "")
        {
            VillEntity_Obj._VILL_TOT_CNB = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_CNB = Convert.ToInt32(txtcnb.Text);
        }

        if (txtsng.Text == "")
        {
            VillEntity_Obj._VILL_TOT_SNG = 0;
        }
        else
        {
            VillEntity_Obj._VILL_TOT_SNG = Convert.ToInt32(txtsng.Text);
        }

        if (txtothranml.Text == "")
        {
            VillEntity_Obj._TOT_OTHR_ANML = 0;
        }
        else
        {
            VillEntity_Obj._TOT_OTHR_ANML = Convert.ToInt32(txtothranml.Text);
        }
        if (txtlatmin1.Text == "")
        {
            VillEntity_Obj._VILL_LNGMIN1 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNGMIN1 = Convert.ToInt32(txtlatmin1.Text);
        }
        if (txtlatmin2.Text == "")
        {
            VillEntity_Obj._VILL_LNGMIN2 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNGMIN2 = Convert.ToInt32(txtlatmin2.Text);
        }

        if (txtlatmin3.Text == "")
        {
            VillEntity_Obj._VILL_LNGMIN3 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNGMIN3 = Convert.ToInt32(txtlatmin3.Text);
        }
        if (txtlatmin4.Text == "")
        {
            VillEntity_Obj._VILL_LNGMIN4 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNGMIN4 = Convert.ToInt32(txtlatmin4.Text);
        }
        if (txtlatsec1.Text == "")
        {
            VillEntity_Obj._VILL_LNGSEC1 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNGSEC1 = Convert.ToInt32(txtlatsec1.Text);
        }


        if (txtlatsec2.Text == "")
        {
            VillEntity_Obj._VILL_LNGSEC2 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNGSEC2 = Convert.ToInt32(txtlatsec2.Text);
        }
        if (txtlatsec3.Text == "")
        {
            VillEntity_Obj._VILL_LNGSEC3 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNGSEC3 = Convert.ToInt32(txtlatsec3.Text);
        }
        if (txtlatsec4.Text == "")
        {
            VillEntity_Obj._VILL_LNGSEC4 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LNGSEC4 = Convert.ToInt32(txtlatsec4.Text);
        }


        if (txtlongmin1.Text == "")
        {
            VillEntity_Obj._VILL_LONGMIN1 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONGMIN1 = Convert.ToInt32(txtlongmin1.Text);
        }
        if (txtlongmin2.Text == "")
        {
            VillEntity_Obj._VILL_LONGMIN2 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONGMIN2 = Convert.ToInt32(txtlongmin2.Text);
        }

        if (txtlongmin3.Text == "")
        {
            VillEntity_Obj._VILL_LONGMIN3 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONGMIN3 = Convert.ToInt32(txtlongmin3.Text);
        }

        if (txtlongmin4.Text == "")
        {
            VillEntity_Obj._VILL_LONGMIN4 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONGMIN4 = Convert.ToInt32(txtlongmin4.Text);
        }


        if (txtlongsec1.Text == "")
        {
            VillEntity_Obj._VILL_LONGSEC1 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONGSEC1 = Convert.ToInt32(txtlongsec1.Text);
        }
        if (txtlongsec2.Text == "")
        {
            VillEntity_Obj._VILL_LONGSEC2 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONGSEC2 = Convert.ToInt32(txtlongsec2.Text);
        }
        if (txtlongsec3.Text == "")
        {
            VillEntity_Obj._VILL_LONGSEC3 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONGSEC3 = Convert.ToInt32(txtlongsec3.Text);
        }
        if (txtlongsec4.Text == "")
        {
            VillEntity_Obj._VILL_LONGSEC4 = 0;
        }
        else
        {
            VillEntity_Obj._VILL_LONGSEC4 = Convert.ToInt32(txtlongsec4.Text);
        }


        if (txtvalagri.Text == "")
        {
            VillEntity_Obj._VILL_VAL_AGRI = 0;
        }
        else
        {
            VillEntity_Obj._VILL_VAL_AGRI = Convert.ToDecimal(txtvalagri.Text);
        }
        if (txtvalres.Text == "")
        {
            VillEntity_Obj._VILL_VAL_RES = 0;
        }
        else
        {
            VillEntity_Obj._VILL_VAL_RES = Convert.ToDecimal(txtvalres.Text);
        }

        //update naren 14june
        if (TxtnoTransgender.Text == "")
        {
            VillEntity_Obj.NoTransGender = 0;
        }
        else
        {
            VillEntity_Obj.NoTransGender = Convert.ToInt32(TxtnoTransgender.Text.Trim());
        }


        total = VillEntity_Obj._VILL_FEMALE + VillEntity_Obj._VILL_MALE + Convert.ToInt32(VillEntity_Obj.NoTransGender);

        if (VillEntity_Obj._VILL_TOT_SC + VillEntity_Obj._VILL_TOT_ST + VillEntity_Obj._VILL_TOT_OBC + VillEntity_Obj._VILL_TOT_OTH != total)
        {


            LblVpop.Text = "Total Numbers of  Village Population must be equal to (Total of Male Population+Total Female Population+Total number of transgender)";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (VillEntity_Obj._VILL_TOT_AGRI_LND_AREA + VillEntity_Obj._VILL_TOT_NON_AGRI_LND_AREA + VillEntity_Obj._VILL_OTHER_LND_AREA != VillEntity_Obj._VILL_TOT_LND_AREA)
        {

            lblMsg.Text = "Total of(Agricultural land,Residentail land and others land Area) must be equal to Total Land Area";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        VillEntity_Obj._VILL_POPU = total;
        VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);

        //naren2june update2018
        VillEntity_Obj.DateMeeting = Convert.ToDateTime(common.insertDate(TxtDateMeeting.Text.Trim()));
        VillEntity_Obj.CuttOffDate = Convert.ToDateTime(common.insertDate(TxtCuttOffDate.Text.Trim()));
        VillEntity_Obj.NoAdult = Convert.ToInt32(Txtadult.Text.Trim());
        //VillEntity_Obj.NoTransGender =Convert.ToInt32(TxtnoTransgender.Text.Trim()) ;
        VillEntity_Obj.NoCows = Convert.ToInt32(TxtNoCow.Text.Trim());
        VillEntity_Obj.NoBuffalo = Convert.ToInt32(TxtBuffalo.Text.Trim());
        VillEntity_Obj.NoSheep = Convert.ToInt32(TxtSheep.Text.Trim());
        VillEntity_Obj.NoGoat = Convert.ToInt32(TxtGoat.Text.Trim());


        // if (FileUploadContai.PostedFile != null && FileUploadContainer.PostedFile.InputStream.Length != 0)
        Miscelleneous_DL dl = new Miscelleneous_DL();
       
        string FileName = "";
        HttpFileCollection hfc = Request.Files;

        //for (int i = 0; i < hfc.Count; i++)
        for (int i = 0; i < Request.Files.Count; i++)
        {

            HttpPostedFile hpf = hfc[i];
            // HttpPostedFile hpf = Request.Files[i];
            FileName = System.IO.Path.GetFileName(hpf.FileName);
            int filelength = hpf.ContentLength;
            // HttpPostedFile file = fileUpload.PostedFile;
            byte[] document = new byte[filelength];
            hpf.InputStream.Read(document, 0, filelength);
            System.UInt32 mimetype;
            FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
            System.IntPtr mimeTypePtr = new IntPtr(mimetype);
            mime = Marshal.PtrToStringUni(mimeTypePtr);
            Marshal.FreeCoTaskMem(mimeTypePtr);
            // {
            if (hpf.ContentLength > 0)
            {

                // if (hpf.ContentLength < 307200)
                //{


                //   p_Var.ext = System.IO.Path.GetExtension(this.fileUpload_Menu.PostedFile.FileName);
                p_Var.ext = System.IO.Path.GetExtension(hpf.FileName);
                p_Var.ext = p_Var.ext.ToUpper();
                 int count =hpf.FileName.Split('.').Length - 1;
                        string contenttype =hpf.ContentType.ToString();
                        if (count >= 2)
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
                            return;
                        }
                //  if ((Extension == "pdf" && mime.ToString().Equals("application/pdf")) || (Extension == "xlsx" && mime.ToString().Equals("application/x-zip-compressed")) || (Extension == "docx" && mime.ToString().Equals("application/x-zip-compressed")))
                if ((p_Var.ext.Equals(".PDF") && mime.ToString().Equals("application/pdf")) || (p_Var.ext.Equals(".XLSX") && mime.ToString().Equals("application/x-zip-compressed")) || p_Var.ext.Equals(".DOCX") && mime.ToString().Equals("application/x-zip-compressed") || (p_Var.ext.Equals(".DOC") && mime.ToString().Equals("application/x-zip-compressed")) || (p_Var.ext.Equals(".jpg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".png") && mime.ToString().Equals("image/x-png")) || (p_Var.ext.Equals(".PNG") && mime.ToString().Equals("image/x-png")))
                {
                    lblmenuMsg.Visible = false;

                    p_Var.Path = ResolveUrl("~") + "WriteReadData/VILLAGE";
                    //  p_Var.Filename = com_Obj.getUniqueFileName(fileUpload_Menu.FileName.ToString(), Server.MapPath(p_Var.Path), System.IO.Path.GetFileNameWithoutExtension(fileUpload_Menu.PostedFile.FileName), p_Var.ext);
                    // p_Var.Filename = com_Obj.getUniqueFileName(FileName, Server.MapPath(p_Var.Path), FileName, p_Var.ext);
                    p_Var.Path = ResolveUrl("~") + "WriteReadData/VILLAGE/" + FileName;

                    hpf.SaveAs(Server.MapPath(p_Var.Path));
                    VillEntity_Obj.FileName = p_Var.Filename;
                }
                else
                {
                    lblmenuMsg.Visible = true;
                    lblmenuMsg.Text = "Not a valid file";
                    //   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Not a Valid file');", true);
                    string message = "Not a Valid file";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                    return;
                }
            }
        }
          //  }
      //  }
        if (fileKML.PostedFile != null && fileKML.PostedFile.InputStream.Length != 0)
        {
            p_Var.ext = System.IO.Path.GetExtension(this.fileKML.PostedFile.FileName);
            p_Var.ext = p_Var.ext.ToUpper();
            if (p_Var.ext.Equals(".KML") || p_Var.ext.Equals(".KMZ"))
            {

                p_Var.Path = ResolveUrl("~") + "WriteReadData/VILLAGE";
                p_Var.Filename = com_Obj.getUniqueFileName(fileKML.FileName.ToString(), Server.MapPath(p_Var.Path), System.IO.Path.GetFileNameWithoutExtension(fileKML.PostedFile.FileName), p_Var.ext);
                p_Var.Path = ResolveUrl("~") + "WriteReadData/VILLAGE/" + p_Var.Filename;
                fileKML.PostedFile.SaveAs(Server.MapPath(p_Var.Path));
                VillEntity_Obj.KMLFile = p_Var.Filename;
            }
        }
        // Add option to multiple file
        DataTable fileUpload = new DataTable();
        DataSet dSet = new DataSet();
        fileUpload.Columns.Add("FileName", typeof(string));
        p_Var.url = ResolveUrl("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/VILLAGE" + "/";
        for (int i = 0; i < Request.Files.Count; i++)
        {
            string date = System.DateTime.Now.ToString("yyyymmss");



            HttpPostedFile PostedFile = Request.Files[i];
            string FileName1 = "";
            if (PostedFile.ContentLength > 0)
            {
                DataRow dr = fileUpload.NewRow();
                FileName1 = System.IO.Path.GetFileName(PostedFile.FileName);
                PostedFile.SaveAs(Server.MapPath(p_Var.url) + System.DateTime.Now.ToString("yyyymmss") + FileName);
                dr["FileName"] = System.DateTime.Now.ToString("yyyymmss") + FileName;
                fileUpload.Rows.Add(dr);
            }

        }

        //end naren2june update2018
        #endregion
        VillEntity_Obj.filenames = fileUpload;
        VillEntity_Obj.Latitude = HttpUtility.HtmlEncode(TxtLatitude.Text.Trim());
        VillEntity_Obj.Longitude = HttpUtility.HtmlEncode(TxtLongitude.Text.Trim());

        if (Session["UserType"].ToString().Equals("4"))
        {
            check = VillDB_Obj.AddVillageDB(VillEntity_Obj, State_Entity, Dist_Ent_Obj, RSVREntity_Obj, TH_EN_Obj, GP_EN_Obj);
        }
        else
        {
            //for super admin
            VillEntity_Obj.StateID = Convert.ToInt32(DdlState.SelectedValue);
            VillEntity_Obj.CmnDataOperatorTigerReserveID = Convert.ToInt32(ddlselectreserve.SelectedValue);
            check = VillDB_Obj.AddVillageDB1(VillEntity_Obj, State_Entity, Dist_Ent_Obj, RSVREntity_Obj, TH_EN_Obj, GP_EN_Obj);
        }




        if (check == true)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "$('#myModal').show(); $('#myModal').modal('show');", true);
            //Session["msg"] = "Village has been submitted successfully.";
            //Session["BackUrl"] = "~/Auth/AdminPanel/Village/Village_Management.aspx";
            //Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
        }
        else
        {
            //Session["msg"] = "Server busy please try later!!.";
            //Session["BackUrl"] = "~/Auth/AdminPanel/Village/Village_Management.aspx";
            //Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }


    protected void ImgbtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Village_Management_Add.aspx");
    }
    protected void ImgbtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx"), false);
    }
    protected void txtlatmin2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtlongmin2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtst_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtland_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtobc_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtvalagri_TextChanged(object sender, EventArgs e)
    {

    }
    protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTIgerReserve();

    }
    protected void TxtDateMeeting_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ValidateFileSize(object source, ServerValidateEventArgs args)
    {
        string data = args.Value;
        args.IsValid = false;
        double filesize = fileUpload_Menu.FileContent.Length;
        if (filesize > 3145728)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

   // #region Custom validator to validate extension of upload pdf files
 //   [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
   // private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
//    [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
  //  [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
  //  System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
  //  System.UInt32 dwMimeFlags,
  //  out System.UInt32 ppwzMimeOut,
    //System.UInt32 dwReserverd);

    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //Miscelleneous_DL dl = new Miscelleneous_DL();
      //  HttpPostedFile file = fileUpload_Menu.PostedFile;
      //  byte[] document = new byte[file.ContentLength];
     //   file.InputStream.Read(document, 0, file.ContentLength);
     //   System.UInt32 mimetype;
     //   FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
       // System.IntPtr mimeTypePtr = new IntPtr(mimetype);
      //  mime = Marshal.PtrToStringUni(mimeTypePtr);

       // Marshal.FreeCoTaskMem(mimeTypePtr);
        //View

        bool s;
        string Extension = System.IO.Path.GetExtension(fileUpload_Menu.PostedFile.FileName);
        Extension = Extension.ToLower();
        //  if (ext1 == ".pdf")
        if ((Extension == "pdf" && mime.ToString().Equals("application/pdf")) || (Extension == "xlsx" && mime.ToString().Equals("application/x-zip-compressed")) || (Extension == "docx" && mime.ToString().Equals("application/x-zip-compressed")))
        {
            s = miscellBL.GetActualFileType_pdf(fileUpload_Menu.PostedFile.InputStream);
        }
        else
        {
            s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
        }
        if (fileUpload_Menu.PostedFile.ContentLength == 0)
        {
            s = true;
        }
        if (s == false)
        {
            // There is no file selected
            args.IsValid = false;
            // CustomValidator1.Text = "This file extension has been changed, file is of another type.";

        }
        else
        {
            args.IsValid = true;

        }
    }
    #endregion
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["villageID"] == null)
        {
            VillEntity_Obj.StateID = Convert.ToInt32(ddlselectgp.SelectedValue);
            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            p_Var.dSet = VillDB_Obj.GetVillageID(VillEntity_Obj);
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                string ID = p_Var.dSet.Tables[0].Rows[0]["VILL_ID"].ToString();

                Response.Redirect("~/auth/adminpanel/FamilyData/Family_Management.aspx?id=" + ID);
            }
            else
            {
                Response.Redirect("~/auth/adminpanel/FamilyData/Family_Management.aspx?id=0");
            }

        }



    }
    protected void btnnextstep_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["villageID"] == null)
        {
            VillEntity_Obj.StateID = Convert.ToInt32(ddlselectgp.SelectedValue);
            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            p_Var.dSet = VillDB_Obj.GetVillageID(VillEntity_Obj);
            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
                string ID = p_Var.dSet.Tables[0].Rows[0]["VILL_ID"].ToString();

                Response.Redirect("~/auth/adminpanel/FamilyData/Family_Management.aspx?id=" + ID);
            }
            else
            {
                Response.Redirect("~/auth/adminpanel/FamilyData/Family_Management.aspx?id=0");
            }
        }
    }
    public void BindTIgerReserve()
    {

        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            string StateID = DdlState.SelectedValue.ToString();

            DataSet ds = new VillageDB().BindTigerReserveName(StateID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
            }



            else
            {
                ddlselectreserve.Items.Clear();
                ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
            }
        }
        catch (Exception er)
        {
        }
    }

    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlselectreserve.SelectedIndex != 0)
        {
            lblmsgdt.Text = "";
            // FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
            //  FillTehsil();
            FillDistrict1();
        }
        else
        {
            ddlSelectDistrict.Items.Clear();
            ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));

            ddlselecttehsil.Items.Clear();
            ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));

            ddlselectgp.Items.Clear();
            ddlselectgp.Items.Add(new ListItem("No Record", "0"));

        }
    }
    protected void ImgbtnBack_ClickNew(object sender, EventArgs e)
    {

        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/VILLAGE/Village_Management.aspx"));
    }

    protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
    {
        bool s;
        string ext1 = System.IO.Path.GetExtension(fileKML.PostedFile.FileName);
        ext1 = ext1.ToLower();
        if (ext1 == ".kml" || ext1 == ".kmz")
        {
            //s = miscellBL.GetActualFileType_pdf(fileUpload_Menu.PostedFile.InputStream);
            s = true;
        }
        else
        {
            // s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
            s = false;
        }
        if (fileKML.PostedFile.ContentLength == 0)
        {
            s = true;
        }
        if (s == false)
        {
            // There is no file selected
            args.IsValid = false;
            // CustomValidator1.Text = "This file extension has been changed, file is of another type.";

        }
        else
        {
            args.IsValid = true;

        }
    }
}