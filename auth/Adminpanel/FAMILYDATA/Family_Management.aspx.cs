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

public partial class auth_Adminpanel_FAMILYDATA_Family_Management : System.Web.UI.Page
{
    FamilyDB FMLYDB_Obj = new FamilyDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    VillageDB VillDB_Obj = new VillageDB();
    string vill_id = "", scheme_id = "", relocation_status = "", fid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblMsg.Text = "";
        //gvForFamily.Columns[6].Visible = true;
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }
       if(string.IsNullOrEmpty(Request.QueryString["id"]))
        {
            ddlselectheadnameRequest.Visible = false;
        }

        if (!Page.IsPostBack)
        {
             Bindfamily();
            if (Session["UserType"].ToString().Equals("1"))
            {
                BindStateName();
                td.Visible = true;
                BindTigerReserveName1();
                ddlselectreserve.Visible = true;

                ImgbtnAddNew.Visible = true;
                if (ddlselectreserve.SelectedItem.Text != "-Select-")
                {
                    Fill_VillageCode_And_Name1(Session["User_Id"].ToString());

                }
                else
                {
                    ddlselectname.Items.Add(new ListItem("No Record", "0"));
                }
               // VillageName();
                SelectedIndex();
                //  Bindfamily();
                if (ViewState["indexpage"] == null)
                {
                    bindfamilyheadname();
                    ViewState["indexpage"] = 0;
                }
                else
                {

                }
                pageLoadDefaultPopulateAllRecord();
            }
        
            if (Session["UserType"].ToString().Equals("2"))
            {
                td.Visible = true;
                BindTigerReserveName2();
                ddlselectreserve.Visible = true;

                ImgbtnAddNew.Visible = true;
                if (ddlselectreserve.SelectedItem.Text != "-Select-")
                {
                    Fill_VillageCode_And_Name2(Session["User_Id"].ToString());

                }
                else
                {
                    ddlselectname.Items.Add(new ListItem("No Record", "0"));
                }
              
                //VillageName();
                SelectedIndex();
                //  Bindfamily();
                if (ViewState["indexpage"] == null)
                {
                    bindfamilyheadname();
                    ViewState["indexpage"] = 0;
                }
                else
                {

                }
            }
            if (Session["UserType"].ToString().Equals("3"))
            {
                td.Visible = true;
                BindTigerReserveName();
                ddlselectreserve.Visible = true;

                ImgbtnAddNew.Visible = true;
                if (ddlselectreserve.SelectedItem.Text != "-Select-")
                {
                    Fill_VillageCode_And_Name3(Session["User_Id"].ToString());

                }
                else
                {
                    ddlselectname.Items.Add(new ListItem("No Record", "0"));
                }
                
              //  VillageName();
                SelectedIndex();
                //  Bindfamily();
                if (ViewState["indexpage"] == null)
                {
                    bindfamilyheadname();
                    ViewState["indexpage"] = 0;
                }
                else
                {

                }
            }
            if (Session["UserType"].ToString().Equals("4"))
            {


                Fill_VillageCode_And_Name(Session["User_Id"].ToString());

              
                SelectedIndex();
                 Bindfamily();
                if (ViewState["indexpage"] == null)
                {
                    bindfamilyheadname();
                    ViewState["indexpage"] = 0;
                }
                else
                {

                }
            }

            pageLoadDefaultPopulateAllRecord();
        }
    }
    void pageLoadDefaultPopulateAllRecord()
    {
        if (Session["UserType"].ToString().Equals("1"))
        {

            gvForFamily.Visible = true;

            BindfamilyByOptions1();
        }
        if (Session["UserType"].ToString().Equals("2"))
        {

            gvForFamily.Visible = true;

            BindfamilyByOptions2();
        }
        if (Session["UserType"].ToString().Equals("3"))
        {

            gvForFamily.Visible = true;

            BindfamilyByOptions3();
        }
        if (Session["UserType"].ToString().Equals("4"))
        {

            gvForFamily.Visible = true;
            //if (ddlselectname.SelectedValue.ToString().Equals("0"))
            //{
            //    lblMsg.Text = "Please Select Village Name";
            //    return;
            //}

            BindfamilyByOptions();
        }
    }
    void BindTigerReserveName1()
    {
        try
        {
            string StateName = string.Empty;
            if (DdlStateName.SelectedValue != "0")
            {
                StateName = DdlStateName.SelectedValue;
            }
            else
            {
                StateName = null;
            }
            // ddlselectreserve.Items.Clear();
            // ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select tiger reserve wise searching-", "0"));
            ddlselectreserve.Items.Clear();
           // ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select tiger reserve-", "0"));
           // ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            //DataSet ds = new VillageDB().Ds_BindTigerReserveName1();Ds_BindTigerReserveName1Modified
            DataSet ds = new VillageDB().Ds_BindTigerReserveName1Modified(StateName);
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
    void BindTigerReserveName2()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName2();
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
    void BindTigerReserveName()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName();
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
    void bindfamilyheadname()
    {
        //ddlselectheadname.Items.Clear();
        //if (ddlselectname.SelectedValue.ToString().Equals("0"))
        //{

        //    ddlselectheadname.Items.Insert(0, new ListItem("No Record", "0"));
        //}
        string VillageID = Convert.ToString(Request.QueryString["id"]);
        int userid = Convert.ToInt32(Session["User_Id"].ToString());
        DataTable dt = FMLYDB_Obj.GetFamilyHeadNamenew(VillageID, userid);
        if (dt.Rows.Count > 0)
        {
            ddlselectheadname.DataSource = dt;
            ddlselectheadname.DataTextField = "FMLY_MEMB_NM";
            ddlselectheadname.DataValueField = "FMLY_ID";
            ddlselectheadname.DataBind();
            ddlselectheadname.Items.Insert(0, new ListItem("Select Name", "0"));
        }
        else
        {
            ddlselectheadname.Items.Insert(0, new ListItem("No Record", "0"));
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void Bindfamily()
    {


        DataSet ds = new DataSet();
        try
        {

            if (Request.QueryString["vid"] != null)
            {
                if (!Request.QueryString["vid"].ToString().Equals("0"))
                {


                    ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    ddlselectscheme.SelectedValue = Request.QueryString["sid"].ToString();
                    ddlselectRelocation.SelectedValue = Request.QueryString["rid"].ToString();
                    bindfamilyheadname();
                    ddlselectheadname.SelectedValue = Request.QueryString["fid"].ToString();
                    BindfamilyByOptions();
                    return;

                }
                else
                {
                    ddlselectname.SelectedValue = Session["VillageId"].ToString();
                    BindfamilyByOptions();
                    ds = FMLYDB_Obj.Display_Info_Family(Convert.ToInt32(Session["User_Id"]),Session["VillageId"].ToString());
                }

            }
            else
            {
                // ddlselectname.SelectedValue = Session["VillageId"].ToString();
                if (Request.QueryString["id"] != "0")
                {
                    ds = FMLYDB_Obj.Display_Info_Family(Convert.ToInt32(Session["User_Id"]),Request.QueryString["id"]);
                }



                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvForFamily.Visible = true;
                    gvForFamily.DataSource = ds.Tables[0].DefaultView;
                    gvForFamily.DataBind();
                }
                else
                {
                    gvForFamily.Visible = true;
                    gvForFamily.DataSource = ds.Tables[0].DefaultView;
                    gvForFamily.DataBind();
                     //change
                    //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound + " For " + Session["VILLAGENAME"].ToString() + " Village";
                    //lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    private void SelectedIndex()
    {
        string pindex = Request.QueryString["pindex"];
        if (pindex != null)
        {
            ViewState["indexpage"] = gvForFamily.PageIndex = int.Parse(pindex);
        }
    }
    public void BindfamilyByOptions()
    {
        DataSet ds = new DataSet();
        try
        {      

            vill_id = Request.QueryString["id"];

            if (ddlselectscheme.SelectedValue.ToString().Equals("0"))
            {
                scheme_id = null;
            }
            else
            {
                scheme_id = ddlselectscheme.SelectedValue.ToString();
            }
            if (ddlselectRelocation.SelectedValue.ToString().Equals("-1"))
            {
                relocation_status = null;
            }
            else
            {
                relocation_status = ddlselectRelocation.SelectedValue.ToString();
            }
            if (ddlselectheadname.SelectedValue.ToString().Equals("0"))
            {
                fid = null;
            }
            else
            {
                fid = ddlselectheadname.SelectedValue.ToString();
            }


            //if (ddlselectname.SelectedItem.Text!="Select Name")
            //{
                ds = FMLYDB_Obj.Display_Info_FamilyByOption1(vill_id, scheme_id, relocation_status, fid, Convert.ToInt32(Session["User_Id"]));
            //}
          

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvForFamily.Visible = true;
                gvForFamily.DataSource = ds;
                gvForFamily.DataBind();
            }
            else
            {

                gvForFamily.Visible = true;
                //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindfamilyByOptions3()
    {
        DataSet ds = new DataSet();
        try
        {

            vill_id = ddlselectname.SelectedValue.ToString();


            if (ddlselectscheme.SelectedValue.ToString().Equals("0"))
            {
                scheme_id = null;
            }
            else
            {
                scheme_id = ddlselectscheme.SelectedValue.ToString();
            }
            if (ddlselectRelocation.SelectedValue.ToString().Equals("-1"))
            {
                relocation_status = null;
            }
            else
            {
                relocation_status = ddlselectRelocation.SelectedValue.ToString();
            }
            if (ddlselectheadname.SelectedValue.ToString().Equals("0"))
            {
                fid = null;
            }
            else
            {
                fid = ddlselectheadname.SelectedValue.ToString();
            }


            //if (ddlselectname.SelectedItem.Text != "Select Name")
            //{
                ds = FMLYDB_Obj.Display_Info_FamilyByOption13(ddlselectname.SelectedValue, scheme_id, relocation_status, fid,Convert.ToInt32(ddlselectreserve.SelectedValue));
           // }


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvForFamily.Visible = true;
                gvForFamily.DataSource = ds.Tables[0];
                gvForFamily.DataBind();
            }
            else
            {

                gvForFamily.Visible = true;
                //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindfamilyByOptions2()
    {
        DataSet ds = new DataSet();
        try
        {

            vill_id = ddlselectname.SelectedValue.ToString();


            if (ddlselectscheme.SelectedValue.ToString().Equals("0"))
            {
                scheme_id = null;
            }
            else
            {
                scheme_id = ddlselectscheme.SelectedValue.ToString();
            }
            if (ddlselectRelocation.SelectedValue.ToString().Equals("-1"))
            {
                relocation_status = null;
            }
            else
            {
                relocation_status = ddlselectRelocation.SelectedValue.ToString();
            }
            if (ddlselectheadname.SelectedValue.ToString().Equals("0"))
            {
                fid = null;
            }
            else
            {
                fid = ddlselectheadname.SelectedValue.ToString();
            }

        
            //if (ddlselectname.SelectedItem.Text != "Select Name")
            //{
            ds = FMLYDB_Obj.Display_Info_FamilyByOption12(ddlselectname.SelectedValue, scheme_id, relocation_status, fid, Convert.ToInt32(ddlselectreserve.SelectedValue));
            // }


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvForFamily.Visible = true;
                gvForFamily.DataSource = ds.Tables[0].DefaultView;
                gvForFamily.DataBind();
            }
            else
            {

                gvForFamily.Visible = true;
                gvForFamily.DataSource = null;
                gvForFamily.DataBind();
                //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindfamilyByOptions1()
    {
        DataSet ds = new DataSet();
        ds = null;
        try
        {

            vill_id = ddlselectname.SelectedValue.ToString();


            if (ddlselectscheme.SelectedValue.ToString().Equals("0"))
            {
                scheme_id = null;
            }
            else
            {
                scheme_id = ddlselectscheme.SelectedValue.ToString();
            }
            if (ddlselectRelocation.SelectedValue.ToString().Equals("-1"))
            {
                relocation_status = null;
            }
            else
            {
                relocation_status = ddlselectRelocation.SelectedValue.ToString();
            }
            if (ddlselectheadname.SelectedValue.ToString().Equals("0"))
            {
                fid = null;
            }
            else
            {
                fid = ddlselectheadname.SelectedValue.ToString();
            }
            string stateName = DdlStateName.SelectedValue == "0" ? null : DdlStateName.SelectedValue;

            //if (ddlselectname.SelectedItem.Text != "Select Name")
            //{
            ds = FMLYDB_Obj.Display_Info_FamilyByOption11(ddlselectname.SelectedValue, scheme_id, relocation_status, fid, Convert.ToInt32(ddlselectreserve.SelectedValue), stateName);
            // }


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvForFamily.Visible = true;
                gvForFamily.DataSource = ds.Tables[0].DefaultView;
                gvForFamily.DataBind();
            }
            else
            {

                gvForFamily.Visible = true;
                gvForFamily.DataSource =null;
                gvForFamily.DataBind();
                //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }


        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void Fill_VillageCode_And_Name(string reserveid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            int id =Convert.ToInt32(Request.QueryString["id"]);
            ds = VillDB_Obj.Fill_Name(Convert.ToInt32(Session["User_Id"]), id);
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
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["VILL_ID"].ToString());
                    ++j;
                    ddlselectname.Items.Add(li);

                }


            }
            else
            {
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name3(string CmnTigerReserveUserID)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
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
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["VILL_ID"].ToString());
                    ++j;
                    ddlselectname.Items.Add(li);

                }


            }
            else
            {
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name2(string CmnStateUserID)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
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
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["VILL_ID"].ToString());
                    ++j;
                    ddlselectname.Items.Add(li);

                }


            }
            else
            {
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name1(string CmnStateUserID)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
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
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["VILL_ID"].ToString());
                    ++j;
                    ddlselectname.Items.Add(li);

                }


            }
            else
            {
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void gvForFamily_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ViewState["indexpage"] = gvForFamily.PageIndex = e.NewPageIndex;
        gvForFamily.PageIndex = e.NewPageIndex;
        if (Session["UserType"].ToString().Equals("1"))
        {
            BindfamilyByOptions1();
        }
        if (Session["UserType"].ToString().Equals("2"))
        {
            BindfamilyByOptions2();
        }
        if (Session["UserType"].ToString().Equals("3"))
        {
            BindfamilyByOptions3();
        }
        if (Session["UserType"].ToString().Equals("4"))
        {
            BindfamilyByOptions();
        }

    }
    protected void gvForFamily_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        //HiddenField FmailyRCD = row.FindControl("HFamilyCode") as HiddenField;
        //string ss = FmailyRCD.Value;

      
        try
        {
            if (e.CommandName == "EditFamilyDetails")
            {//31079
                //string ss = e.CommandArgument.ToString();
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string FamilyID = commandArgs[0];
                string VillageID = commandArgs[1];
                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Edit_Family.aspx?" + WebConstant.QueryStringEnum.Familyid + "=" + FamilyID + "&pindex=" + ViewState["indexpage"].ToString() + "&vid=" + VillageID + "&sid=" + ddlselectscheme.SelectedValue.ToString() + "&rid=" + ddlselectRelocation.SelectedValue.ToString() + "&fid=" + ddlselectheadname.SelectedValue.ToString()), false);
                //Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Edit_Family.aspx?" + WebConstant.QueryStringEnum.Familyid + "=" + e.CommandArgument.ToString() + "&pindex=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&sid=" + ddlselectscheme.SelectedValue.ToString() + "&rid=" + ddlselectRelocation.SelectedValue.ToString() + "&fid=" + ddlselectheadname.SelectedValue.ToString()), false);
            }
            if (e.CommandName == "EditRelocationDetails")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string FamilyID = commandArgs[0];
                string VillageID = commandArgs[1];

              //  DataSet ds = FMLYDB_Obj.GetSchemeIdByFamilyID(e.CommandArgument.ToString());
                DataSet ds = FMLYDB_Obj.GetSchemeIdByFamilyID(FamilyID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
                    {
                        //Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/FAMILYDATA/RelocationScheme_IA_Mangement.aspx?" + WebConstant.QueryStringEnum.Familyid + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&sid=" + ddlselectscheme.SelectedValue.ToString() + "&rid=" + ddlselectRelocation.SelectedValue.ToString() + "&fid=" + ddlselectheadname.SelectedValue.ToString()), false);
                        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/RelocationScheme_IB_Mangement.aspx?" + WebConstant.QueryStringEnum.Familyid + "=" + FamilyID + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + VillageID + "&sid=" + ddlselectscheme.SelectedValue.ToString() + "&rid=" + ddlselectRelocation.SelectedValue.ToString() + "&fid=" + ddlselectheadname.SelectedValue.ToString()), false);

                    }

                    //else if (ds.Tables[0].Rows[0][0].ToString().Equals("2"))
                    {
                        //Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/FAMILYDATA/RelocationScheme_IB_Mangement.aspx?" + WebConstant.QueryStringEnum.Familyid + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&sid=" + ddlselectscheme.SelectedValue.ToString() + "&rid=" + ddlselectRelocation.SelectedValue.ToString() + "&fid=" + ddlselectheadname.SelectedValue.ToString()), false);
                    }

                    // else if (ds.Tables[0].Rows[0][0].ToString().Equals("3"))
                    {
                        //Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/FAMILYDATA/RelocationScheme_II_Mangement.aspx?" + WebConstant.QueryStringEnum.Familyid + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&sid=" + ddlselectscheme.SelectedValue.ToString() + "&rid=" + ddlselectRelocation.SelectedValue.ToString() + "&fid=" + ddlselectheadname.SelectedValue.ToString()), false);
                    }

                    //else if (ds.Tables[0].Rows[0][0].ToString().Equals("4"))
                    {
                        //Response.Redirect("RelocationScheme_II_Mangement.aspx?" + WebConstant.QueryStringEnum.UserID + "=" + e.CommandArgument.ToString());
                    }

                }
                // else 
                {

                }

            }
            if (e.CommandName == "Delete")
            {
                FMLYDB_Obj.Delete_Family(e.CommandArgument.ToString());
                // Audit_ObjDB.AUDIT_TRAIL(Session["LoginID"].ToString(), "DELETE", 1);
                Bindfamily();
            }

            if (e.CommandName == "FamilyMember")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string FMLY_ID = commandArgs[0];
                string vill_id = commandArgs[1];
                //------------


                //----------------

                Response.Redirect("~/AUTH/adminpanel/FamilyData/ViewFamilyMemberDetails.aspx?F_ID=" + FMLY_ID.ToString()+"&vill_id="+ vill_id.ToString());

            }

        }

        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void gvForFamily_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvForFamily_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvForFamily_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        gvForFamily.PageIndex = Convert.ToInt32(Request.QueryString["pindex"]);
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ibEditfamilydetails = (ImageButton)e.Row.FindControl("ibEditfamilydetails");
               // ImageButton ibEditrelocation = (ImageButton)e.Row.FindControl("ibEditrelocation");
                ImageButton imgDelete = (ImageButton)e.Row.FindControl("imgDelete");
                HiddenField hddnFinalSubmit = (HiddenField)e.Row.FindControl("hddnFinalSubmit");
                if (hddnFinalSubmit.Value == "1")
                {
                    ibEditfamilydetails.Visible = true;
                  //  ibEditrelocation.Visible = false;
                    imgDelete.Visible = true;
                    //gvForFamily.Columns[6].Visible = false;
                    //gvForFamily.Columns[5].Visible = false;
                }
               
                
            }

            foreach (GridViewRow row in gvForFamily.Rows)
            {
                string t = row.Cells[5].Text;


                Label schemename = row.FindControl("lblscheme") as Label;
                if (schemename.Text == "1")
                {
                    Label schemename1 = row.FindControl("lblscheme") as Label;
                    schemename1.Text = "I";
                    ImageButton ib = (ImageButton)e.Row.FindControl("ibEditrelocation");
                    ib.Visible = true;
                    


                }
                if (schemename.Text == "2")
                {
                    Label schemename1 = row.FindControl("lblscheme") as Label;
                    schemename1.Text = "IB";
                    ImageButton ib = (ImageButton)e.Row.FindControl("ibEditrelocation");
                    ib.Visible = true;
                  

                }
                if (schemename.Text == "3")
                {
                    Label schemename1 = row.FindControl("lblscheme") as Label;
                    schemename1.Text = "II";
                    ImageButton ib = (ImageButton)e.Row.FindControl("ibEditrelocation");
                    ib.Visible = true;
                    

                }
                if (schemename.Text == "4")
                {
                    Label schemename1 = row.FindControl("lblscheme") as Label;
                    schemename1.Text = "Any Other";
                    ImageButton ib = (ImageButton)e.Row.FindControl("ibEditrelocation");
                    ib.Visible = false;
                    

                }



            }

        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();

            //lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        if (Session["UserType"].ToString().Equals("1"))
        {

            gvForFamily.Visible = true;

            BindfamilyByOptions1();
        }
        if (Session["UserType"].ToString().Equals("2"))
        {

            gvForFamily.Visible = true;

            BindfamilyByOptions2();
        }
        if (Session["UserType"].ToString().Equals("3"))
        {

            gvForFamily.Visible = true;
           
            BindfamilyByOptions3();
        }
        if (Session["UserType"].ToString().Equals("4"))
        {

            gvForFamily.Visible = true;
          

            BindfamilyByOptions();
        }
    }
    protected void ImgbtnAddNew_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Request.QueryString["id"]) != null )
        {
            Int32 ID = Convert.ToInt32(Request.QueryString["id"]);
            Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Add_Family.aspx?id="+ID));
        }
       
    }
    protected void ddlselectscheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        //gvForFamily.Visible = false;
    }
    protected void ddlselectRelocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        //gvForFamily.Visible = false;
      

    }
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
      //  gvForFamily.Visible = false;
        gvForFamily.PageIndex = 0;
        ddlselectscheme.SelectedValue = "0";
        ddlselectRelocation.SelectedValue = "-1";

        if (ddlselectname.SelectedValue.ToString().Equals("0"))
        {

            ddlselectheadname.Items.Clear();
            ddlselectheadname.Items.Insert(0, new ListItem("No Record", "0"));

        }
        else
        {

            bindfamilyheadname();



        }
       
    }
    void BindStateName()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        // P_var.dSet = _commanfuction.BindDdlStateBarChart(_objNtcauser);
        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);
        //if (P_var.dSet.Tables[3].Rows.Count > 0)
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            DdlStateName.DataSource = P_var.dSet.Tables[0];
            DdlStateName.DataTextField = "StateName";
            DdlStateName.DataValueField = "StateName";
            DdlStateName.DataBind();
            DdlStateName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }
    }
    protected void ddlselectheadname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlselectheadname_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //gvForFamily.Visible = false;
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        VillageName();
      // ddlselectname_SelectedIndexChanged(null, null);
        
    }
    void VillageName()
    {
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        _objNtcauser.VillageName = null;
        _objNtcauser.sAction = "ReserveID";
       
            _objNtcauser.TigerReserveName = ddlselectreserve.SelectedItem.Text;
        

        P_var.dSet = _commanfuction.BindVillagenameChart(_objNtcauser);
        if (P_var.dSet.Tables[2].Rows.Count > 0)
        {
            ddlselectname.DataSource = P_var.dSet.Tables[2];
            ddlselectname.DataTextField = "VILL_NM";
            ddlselectname.DataValueField = "VILL_ID";
            ddlselectname.DataBind();
            ddlselectname.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            ddlselectname.Items.Clear();
            ddlselectname.Items.Insert(0, new ListItem("No Record", "0"));
        }
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName1();
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/ProcessManegment/DfoUser/AddProcessDFO.aspx?id=" + Request.QueryString["id"]);
    }

    protected void famback_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/VILLAGE/Village_Management.aspx");
    }
}