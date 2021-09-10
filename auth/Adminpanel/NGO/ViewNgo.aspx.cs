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
public partial class auth_Adminpanel_DataEntry_Ngo_ViewNgo : CrsfBase
{
    Village Vill_Obj = new Village();
    VillageEntity VillEntity_Obj = new VillageEntity();
    VillageDB VillDB_Obj = new VillageDB();
    Reserve_Entity RSVR_Entity = new Reserve_Entity();
    AuditTrailDB Audit_ObjDB = new AuditTrailDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    static string name = "";
    bool flag = false;
    protected void Page_Load(object sender, EventArgs e)
    {

        lblMsg.Text = "";
        lnkrelatedlinks.Visible = false;
        gvforVillages.Columns[4].Visible = false;
        try
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["User_Id"])))
            {
                Response.Redirect(ResolveUrl("index.aspx"), true);
                return;
                //if (Session["LoginID"].ToString() == null || Session["LoginID"].ToString().Equals(""))

            }
            else
            {
                if (!IsPostBack)
                {

                    ViewState["indexpage"] = 0;
                    if (Session["UserType"].ToString().Equals("1"))
                    {
                        BindStateName();
                       // BindTigerReserveName1();  //Deepak
                        btnassociatevillage.Visible = true;
                        PageLoadFunction1();
                        
                    }
                    if (Session["UserType"].ToString().Equals("2"))
                    {
                        BindTigerReserveName2();
                        btnassociatevillage.Visible = false;
                        PageLoadFunction2();
                        
                    }

                    if (Session["UserType"].ToString().Equals("3"))
                    {
                        BindTigerReserveName();
                        PageLoadFunction3();
                        
                    }
                    if (Session["UserType"].ToString().Equals("4"))
                    {

                        PageLoadFunction();

                    }//

                }
                //
            }
        }

        catch (Exception e3)
        {//commented by naren
           // Response.Redirect("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx");
            return;
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
    // end page load
    public void PageLoadFunction()
    {
        BindVillages_For_Admin();

        Fill_VillageCode_And_Name(Convert.ToInt32(Session["User_Id"]));
        FillVillageCode(); // newly added by jitin


        if (Request.QueryString["vcode"] != null || Request.QueryString["vname"] != null)
        {
            if (Request.QueryString["vcode"].ToString().Equals("0") && Request.QueryString["vname"].ToString().Equals("0"))
            {
                if (Session["flagforsearch"] != null)
                {
                    if (Convert.ToBoolean(Session["flagforsearch"]) == true)
                    {
                        SelectedIndex();
                        BindVillages();
                        return;
                    }
                    else
                    {

                        BindVillages_For_Admin();

                        Session["flagforsearch"] = false;
                    }
                }
            }
            else
            {
                ddlselectname.SelectedValue = Request.QueryString["vname"].ToString();
                ddlselectcode.SelectedValue = Request.QueryString["vcode"].ToString();
                BindVillages();
                return;
            }
        }
        else
        {
            SelectedIndex();

            Session["flagforsearch"] = false;

        }



        if (Request.QueryString["viewid"] != null)
        {
            if (Request.QueryString["viewid"].ToString().Equals("1"))
            {
                flag = false;
                //  BindVillages_For_Deo();
                imgbtnviewall.Visible = true;
                btnviewcurrent.Visible = false;
            }
            else
            {
                SelectedIndex();
                flag = true;
                //BindVillages_For_Deo();
                imgbtnviewall.Visible = false;
                btnviewcurrent.Visible = true;
            }
        }
        else
        {
            btnviewcurrent.Visible = false;
            // BindVillages_For_Deo();
        }
    }
    public void PageLoadFunction3()
    {
        BindVillages_For_Admin3();

        Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
        FillVillageCode3(); // newly added by jitin


        if (Request.QueryString["vcode"] != null || Request.QueryString["vname"] != null)
        {
            if (Request.QueryString["vcode"].ToString().Equals("0") && Request.QueryString["vname"].ToString().Equals("0"))
            {
                if (Session["flagforsearch"] != null)
                {
                    if (Convert.ToBoolean(Session["flagforsearch"]) == true)
                    {
                        SelectedIndex();
                        BindVillages3();
                        return;
                    }
                    else
                    {

                        BindVillages_For_Admin3();

                        Session["flagforsearch"] = false;
                    }
                }
            }
            else
            {
                ddlselectname.SelectedValue = Request.QueryString["vname"].ToString();
                ddlselectcode.SelectedValue = Request.QueryString["vcode"].ToString();
                BindVillages();
                return;
            }
        }
        else
        {
            SelectedIndex();

            Session["flagforsearch"] = false;

        }



        if (Request.QueryString["viewid"] != null)
        {
            if (Request.QueryString["viewid"].ToString().Equals("1"))
            {
                flag = false;
                //  BindVillages_For_Deo();
                imgbtnviewall.Visible = true;
                btnviewcurrent.Visible = false;
            }
            else
            {
                SelectedIndex();
                flag = true;
                //BindVillages_For_Deo();
                imgbtnviewall.Visible = false;
                btnviewcurrent.Visible = true;
            }
        }
        else
        {
            btnviewcurrent.Visible = false;
            // BindVillages_For_Deo();
        }
    }
    public void PageLoadFunction2()
    {
        BindVillages_For_Admin2();

        Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
        FillVillageCode2(); // newly added by jitin


        if (Request.QueryString["vcode"] != null || Request.QueryString["vname"] != null)
        {
            if (Request.QueryString["vcode"].ToString().Equals("0") && Request.QueryString["vname"].ToString().Equals("0"))
            {
                if (Session["flagforsearch"] != null)
                {
                    if (Convert.ToBoolean(Session["flagforsearch"]) == true)
                    {
                        SelectedIndex();
                        BindVillages3();
                        return;
                    }
                    else
                    {

                        BindVillages_For_Admin2();

                        Session["flagforsearch"] = false;
                    }
                }
            }
            else
            {
                ddlselectname.SelectedValue = Request.QueryString["vname"].ToString();
                ddlselectcode.SelectedValue = Request.QueryString["vcode"].ToString();
                BindVillages();
                return;
            }
        }
        else
        {
            SelectedIndex();

            Session["flagforsearch"] = false;

        }



        if (Request.QueryString["viewid"] != null)
        {
            if (Request.QueryString["viewid"].ToString().Equals("1"))
            {
                flag = false;
                //  BindVillages_For_Deo();
                imgbtnviewall.Visible = true;
                btnviewcurrent.Visible = false;
            }
            else
            {
                SelectedIndex();
                flag = true;
                //BindVillages_For_Deo();
                imgbtnviewall.Visible = false;
                btnviewcurrent.Visible = true;
            }
        }
        else
        {
            btnviewcurrent.Visible = false;
            // BindVillages_For_Deo();
        }
    }
    public void PageLoadFunction1()
    {
        ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
        BindVillages_For_Admin1();//gvforVillages

        Fill_VillageCode_And_Name1(Convert.ToInt32(ddlselectreserve.SelectedValue));
        FillVillageCode1(); // newly added by jitin


        if (Request.QueryString["vcode"] != null || Request.QueryString["vname"] != null)
        {
            if (Request.QueryString["vcode"].ToString().Equals("0") && Request.QueryString["vname"].ToString().Equals("0"))
            {
                if (Session["flagforsearch"] != null)
                {
                    if (Convert.ToBoolean(Session["flagforsearch"]) == true)
                    {
                        SelectedIndex();
                        BindVillages1();
                        return;
                    }
                    else
                    {

                        BindVillages_For_Admin1();

                        Session["flagforsearch"] = false;
                    }
                }
            }
            else
            {
                ddlselectname.SelectedValue = Request.QueryString["vname"].ToString();
                ddlselectcode.SelectedValue = Request.QueryString["vcode"].ToString();
                BindVillages1();
                return;
            }
        }
        else
        {
            SelectedIndex();

            Session["flagforsearch"] = false;

        }



        if (Request.QueryString["viewid"] != null)
        {
            if (Request.QueryString["viewid"].ToString().Equals("1"))
            {
                flag = false;
                //  BindVillages_For_Deo();
                imgbtnviewall.Visible = true;
                btnviewcurrent.Visible = false;
            }
            else
            {
                SelectedIndex();
                flag = true;
                //BindVillages_For_Deo();
                imgbtnviewall.Visible = false;
                btnviewcurrent.Visible = true;
            }
        }
        else
        {
            btnviewcurrent.Visible = false;
            // BindVillages_For_Deo();
        }
    }
    private void SelectedIndex()
    {
        string pindex = Request.QueryString["pindex"];
        if (pindex != null)
        {
            ViewState["indexpage"] = gvforVillages.PageIndex = int.Parse(pindex);
        }
    }
    void FillVillageCode()
    {
        ddlselectcode.Items.Clear();
        ddlselectcode.Items.Add(new ListItem("Select Code", "0"));
        DataSet ds = new VillageDB().FillVillageCode(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlselectcode.DataSource = ds.Tables[0];
            ddlselectcode.DataTextField = "VILL_CD";
            ddlselectcode.DataValueField = "VILL_ID";
            ddlselectcode.DataBind();

            ddlselectcode.Items.Insert(0, new ListItem("Select Code", "0"));
        }



        else
        {
            ddlselectcode.Items.Clear();
            ddlselectcode.Items.Add(new ListItem("No Record", "0"));
        }
    }
    void FillVillageCode3()
    {
        ddlselectcode.Items.Clear();
        ddlselectcode.Items.Add(new ListItem("Select Code", "0"));
        DataSet ds = new VillageDB().FillVillageCode3(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlselectcode.DataSource = ds.Tables[0];
            ddlselectcode.DataTextField = "VILL_CD";
            ddlselectcode.DataValueField = "VILL_ID";
            ddlselectcode.DataBind();

            ddlselectcode.Items.Insert(0, new ListItem("Select Code", "0"));
        }



        else
        {
            ddlselectcode.Items.Clear();
            ddlselectcode.Items.Add(new ListItem("No Record", "0"));
        }
    }
    void FillVillageCode2()
    {
        ddlselectcode.Items.Clear();
        ddlselectcode.Items.Add(new ListItem("Select Code", "0"));
        DataSet ds = new VillageDB().FillVillageCode2(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlselectcode.DataSource = ds.Tables[0];
            ddlselectcode.DataTextField = "VILL_CD";
            ddlselectcode.DataValueField = "VILL_ID";
            ddlselectcode.DataBind();

            ddlselectcode.Items.Insert(0, new ListItem("Select Code", "0"));
        }



        else
        {
            ddlselectcode.Items.Clear();
            ddlselectcode.Items.Add(new ListItem("No Record", "0"));
        }
    }
    void FillVillageCode1()
    {
        ddlselectcode.Items.Clear();
        ddlselectcode.Items.Add(new ListItem("Select Code", "0"));
        DataSet ds = new VillageDB().FillVillageCode1(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlselectcode.DataSource = ds.Tables[0];
            ddlselectcode.DataTextField = "VILL_CD";
            ddlselectcode.DataValueField = "VILL_ID";
            ddlselectcode.DataBind();

            ddlselectcode.Items.Insert(0, new ListItem("Select Code", "0"));
        }



        else
        {
            ddlselectcode.Items.Clear();
            ddlselectcode.Items.Add(new ListItem("No Record", "0"));
        }
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            ViewState["indexpage"] = gvforVillages.PageIndex = e.NewPageIndex;
            if (flag == true)
            {
                BindVillages_For_Deo();
            }
            else
            {
                BindVillages();
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }
    protected void gvforVillages_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvforVillages_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvforVillages_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        gvforVillages.PageIndex = Convert.ToInt32(Request.QueryString["pindex"]);
      
    }
    protected void gvforVillages_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        try
                        {
                            if (e.CommandName == "Edit")
                            {
                                if (btnviewcurrent.Visible == false && imgbtnviewall.Visible == false)
                                {
                                    Response.Redirect(ResolveUrl("Village_Management_Edit.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vcode=" + ddlselectcode.SelectedValue.ToString() + "&vname=" + ddlselectname.SelectedValue.ToString()), false);
                                }
                                else
                                {
                                    if (btnviewcurrent.Visible == true)
                                    {
                                        Response.Redirect(ResolveUrl("Village_Management_Edit.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vcode=" + ddlselectcode.SelectedValue.ToString() + "&vname=" + ddlselectname.SelectedValue.ToString() + "&viewid=2"), false);
                                    }
                                    else
                                    {
                                        Response.Redirect(ResolveUrl("Village_Management_Edit.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vcode=" + ddlselectcode.SelectedValue.ToString() + "&vname=" + ddlselectname.SelectedValue.ToString() + "&viewid=1"), false);
                                    }
                                }
                            }
                            if (e.CommandName == "Delete")
                            {
                                bool check = VillDB_Obj.Delete_Village_By_ID(e.CommandArgument.ToString());


                                if (check == true)
                                {
                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "DELETE", 1);
                                    lblMsg.Text = WebConstant.UserFriendlyMessages.VillageDeactivatedSuccessfully;
                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                    if (flag == true)
                                    {
                                        BindVillages_For_Deo();
                                    }
                                    else
                                    {
                                        BindVillages();
                                    }
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
                            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
                            lblMsg.ForeColor = System.Drawing.Color.Red;

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
    
    public void BindVillages()
    {
        DataSet ds = new DataSet();
        ds = null;
     //   name = ddlselectname.SelectedItem.ToString();
    
        try
        {
           

            if (ddlselectcode.SelectedValue != "0")
            {
                VillEntity_Obj._VILL_CD = ddlselectcode.SelectedItem.ToString();
            }
           
            if (ddlselectname.SelectedValue != "0")
            {
                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
            }
            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages3()
    {
        DataSet ds = new DataSet();
        ds = null;
        //   name = ddlselectname.SelectedItem.ToString();

        try
        {


            if (ddlselectcode.SelectedValue != "0")
            {
                VillEntity_Obj._VILL_CD = ddlselectcode.SelectedItem.ToString();
            }

            if (ddlselectname.SelectedValue != "0")
            {
                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
            }
            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            ds = VillDB_Obj.Display_All_VillagesDB3(VillEntity_Obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    //public void BindVillages1()
    //{
    //    DataSet ds = new DataSet();
    //    ds = null;
    //    //   name = ddlselectname.SelectedItem.ToString();

    //    try
    //    {


    //        if (ddlselectcode.SelectedValue != "0")
    //        {
    //            VillEntity_Obj._VILL_CD = ddlselectcode.SelectedItem.ToString();
    //        }

    //        if (ddlselectname.SelectedValue != "0")
    //        {
    //            VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
    //        }
    //        VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
    //        ds = VillDB_Obj.Display_All_VillagesDB1(VillEntity_Obj);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            gvforVillages.Visible = true;
    //            gvforVillages.DataSource = ds.Tables[0];
    //            lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
    //            gvforVillages.DataBind();
    //        }
    //        else
    //        {

    //            gvforVillages.Visible = false;
    //            lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
    //            lblMsg.ForeColor = System.Drawing.Color.Red;
    //        }
    //    }
    //    catch (Exception e1)
    //    {
    //        lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
    //        lblMsg.ForeColor = System.Drawing.Color.Red;

    //    }
    //}
    public void BindVillages2()
    {
        DataSet ds = new DataSet();
        ds = null;
        //   name = ddlselectname.SelectedItem.ToString();

        try
        {


            if (ddlselectcode.SelectedValue != "0")
            {
                VillEntity_Obj._VILL_CD = ddlselectcode.SelectedItem.ToString();
            }

            if (ddlselectname.SelectedValue != "0")
            {
                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
            }
            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            ds = VillDB_Obj.Display_All_VillagesDB2(VillEntity_Obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages1()
    {
        DataSet ds = new DataSet();
        ds = null;
        //   name = ddlselectname.SelectedItem.ToString();

        try
        {


            if (ddlselectcode.SelectedValue != "0")
            {
                VillEntity_Obj._VILL_CD = ddlselectcode.SelectedItem.ToString();
            }

            if (ddlselectname.SelectedValue != "0")
            {
                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
            }
            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            ds = VillDB_Obj.Display_All_VillagesDB1(VillEntity_Obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages_For_Deo()
    {
        DataSet ds = new DataSet();
        try
        {

            if (flag == false)
            {

                VillEntity_Obj._VILL_ID = Session["VillageId"].ToString();
                name = null;
                VillEntity_Obj._VILL_CD = null;
              //  ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj, name, Session["Reserve_Id"].ToString());
            }

            else if (flag == true)
            {
                VillEntity_Obj._VILL_ID = null;
                name = null;
                VillEntity_Obj._VILL_CD = null;
              //  ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj, name, Session["Reserve_Id"].ToString());
            }
            else { }

            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages_For_Admin()
    {
        DataSet ds = new DataSet();
        ds = null;
        try
        {

            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]); 
            ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj);


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound + "For" + Session["VILLAGENAME"] + " Village";
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages_For_Admin3()
    {
        DataSet ds = new DataSet();
        ds = null;
        try
        {

            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            ds = VillDB_Obj.Display_All_VillagesDB3(VillEntity_Obj);


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound + "For" + Session["VILLAGENAME"] + " Village";
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages_For_Admin2()
    {
        DataSet ds = new DataSet();
        ds = null;
        try
        {

            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            ds = VillDB_Obj.Display_All_VillagesDB2(VillEntity_Obj);


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound + "For" + Session["VILLAGENAME"] + " Village";
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages_For_Admin1()
    {
        DataSet ds = new DataSet();
        ds = null;
        try
        {

            VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
            ds = VillDB_Obj.Display_All_VillagesDB1(VillEntity_Obj);


            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound + "For" + Session["VILLAGENAME"] + " Village";
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void Fill_VillageCode_And_Name(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name(userid);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                ddlselectname.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name3(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name3(userid);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                ddlselectname.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name2(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name2(userid);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                ddlselectname.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name1(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_AndName(userid);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                ddlselectname.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("Select Name", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void CheckForLegalForm()
    {
        DataSet ds = VillDB_Obj.CheckForLegalForm(Session["VillageId"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString().Equals("0"))
            {
                Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/LegalForm.aspx"), false);
            }
            else
            {


            }
        }

    }
    protected void btnassociatevillage_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/auth/adminpanel/NGO/Associate_Village1.aspx"));
    }
    protected void imgbtnviewall_Click(object sender, EventArgs e)
    {
        flag = true;
        BindVillages_For_Deo();
        imgbtnviewall.Visible = false;
        btnviewcurrent.Visible = true;
    }
    protected void ImgbtnAddNew_Click1(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management_Add.aspx"), false);
    }
    protected void ImageButton1_Click1(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        if (Session["UserType"].ToString().Equals("1"))
        {

            //if (ddlselectcode.SelectedItem.Text != "Select Code" || ddlselectname.SelectedItem.Text != "Select Name")
            //{
            //    if (ddlselectcode.SelectedItem.Text != "No Record" || ddlselectname.SelectedItem.Text != "No Record")
            //    {
            //        BindVillages1();
            //        village_ngo_deatil();
            //    }
            //    else
            //    {


            //        lblMsg.Text = "Please choose value as per your correct need.";
            //        lblMsg.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
            //else
            //{
               

            //    lblMsg.Text = "Please choose value as per your correct need.";
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}
            BindVillages1();
            village_ngo_deatil();
        }
        if (Session["UserType"].ToString().Equals("2"))
        {

            //if (ddlselectcode.SelectedItem.Text != "Select Code" || ddlselectname.SelectedItem.Text != "Select Name" )
            //{
               
            //    if (ddlselectcode.SelectedItem.Text != "No Record" || ddlselectname.SelectedItem.Text != "No Record")
            //    {
            //        BindVillages2();
            //        village_ngo_deatil();
            //    }
            //    else
            //    {


            //        lblMsg.Text = "Please choose value as per your correct need.";
            //        lblMsg.ForeColor = System.Drawing.Color.Red;
            //    }

            //}
            //else
            //{
               
            //    lblMsg.Text = "Please choose any one";
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}
            BindVillages2();
            village_ngo_deatil();
        }
        if (Session["UserType"].ToString().Equals("3"))
        {

            if (ddlselectcode.SelectedItem.Text != "Select Code" || ddlselectname.SelectedItem.Text != "Select Name" )
            {
               
                if (ddlselectcode.SelectedItem.Text != "No Record" || ddlselectname.SelectedItem.Text != "No Record")
                {
                   // BindVillages3();
                    //village_ngo_deatil();
                }
                else
                {


                   // lblMsg.Text = "Please choose value as per your correct need.";
                   // lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
              
               // lblMsg.Text = "Please choose any one";
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            BindVillages3();
            village_ngo_deatil();
        }
        if (Session["UserType"].ToString().Equals("4"))
        {

            if (ddlselectcode.SelectedItem.Text != "Select Code" || ddlselectname.SelectedItem.Text != "Select Name" )
            {
              
                if (ddlselectcode.SelectedItem.Text != "No Record" || ddlselectname.SelectedItem.Text != "No Record")
                {
                    BindVillages();
                    village_ngo_deatil();
                }
                else
                {


                    //lblMsg.Text = "Please choose value as per your correct need.";
                    //lblMsg.ForeColor = System.Drawing.Color.Red;
                }
               
            }
            else
            {
                //lblMsg.Text = "Please choose any one";
                //lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        BindVillages();
        village_ngo_deatil();
    }
    protected void btnviewcurrent_Click(object sender, EventArgs e)
    {
        flag = false;
        BindVillages_For_Deo();
        imgbtnviewall.Visible = true;
        btnviewcurrent.Visible = false;
    }
    protected void ddlselectcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvforVillages.Visible = false;
    }
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvforVillages.Visible = false;
    }
    protected void lnkrelatedlinks_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AUTH/TIGERRESERVEADMIN/RelatedLinks.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id;
        if (ddlselectname.SelectedValue == "0")
        {
            id = ddlselectcode.SelectedValue;
        }
        else
        {
            id = ddlselectname.SelectedValue;
        }
        string popup = "<script language='javascript'>" + "window.open('LegalFormDisplay.aspx?Vill_id=" + id + "','CustomPopUp', " + "'fullscreen=no,height=1050,width=1050,top=250,left=250,scrollbars=yes, dependant = yes, alwaysRaised = yes, menubar=no,resizable=no')" + "</script>";
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "PopupScript", popup, false);
    }
    protected void grvngo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvngo.PageIndex = e.NewPageIndex;
        village_ngo_deatil();

    }
    public void village_ngo_deatil()
    {
        int id = 0;
        string stateName = DdlStateName.SelectedValue == "0" ? null : DdlStateName.SelectedValue;
        if (String.IsNullOrEmpty(ddlselectcode.SelectedValue) && String.IsNullOrEmpty(ddlselectname.SelectedValue))
        {
            id = Int32.Parse(Session["VillageId"].ToString());
        }
        else if ((ddlselectcode.SelectedValue != "0") && (ddlselectname.SelectedValue == "0"))
        {
            id = Int32.Parse(ddlselectcode.SelectedValue);

        }
        else if ((ddlselectcode.SelectedValue == "0") && (ddlselectname.SelectedValue != "0"))
        {
            id = Int32.Parse(ddlselectname.SelectedValue);
        }
        else if ((ddlselectcode.SelectedValue == "0") && (ddlselectname.SelectedValue == "0"))
        {
           id = Convert.ToInt32(Session["VillageId"]);
        }
        else if (ddlselectcode.SelectedValue != ddlselectname.SelectedValue)
        {
            id = -1;
        }
        else if (ddlselectcode.SelectedValue == ddlselectname.SelectedValue)
        {
            id = Int32.Parse(ddlselectcode.SelectedValue);
        }
        DataSet ds = NgoDal.village_ngo_deatil(id, stateName);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvngo.DataSource = ds;
            grvngo.DataBind();
        }
        else
        {
            grvngo.DataSource = null;
            grvngo.DataBind();
        }

    }
    protected void grvngo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        village_ngo_deatil();
    }
    protected void grvngo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            NgoBal bal = new NgoBal();
            int id = Int32.Parse(e.CommandArgument.ToString());
            int i = bal.Delete_ngo_work(id);
            if (i > 0)
            {
                lblMsg.Text = "Work deleted successfuly";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMsg.Text = "Work is not deleted successfuly";
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
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
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            //Ds_BindTigerReserveName1Modified'''Ds_BindTigerReserveName1
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
    protected void grvngo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       // e.Row.Cells[6].Visible = false;
        //e.Row.Cells[7].Visible = false;
        if (Session["UserType"].ToString().Equals("1"))
        {
           // this.grvngo.Columns[6].Visible = false;
           // this.grvngo.Columns[7].Visible = false;
        }
        
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        VillageName();
    }
    void VillageCode()
    {
        if (ddlselectreserve.SelectedValue == "0")
        {
            if (Session["UserType"].ToString().Equals("1"))
            {

                btnassociatevillage.Visible = true;
                PageLoadFunction1();
              
                // BindTigerReserveName1(); //Deepak
              
            }
        }
        else
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
                ddlselectcode.DataSource = P_var.dSet.Tables[2]; 
                ddlselectcode.DataTextField = "VILL_CD";
                ddlselectcode.DataValueField = "VILL_ID";
                ddlselectcode.DataBind();
                ddlselectcode.Items.Insert(0, new ListItem("Select Code", "0"));
            }
            else
            {
                ddlselectcode.Items.Clear();
                ddlselectcode.Items.Insert(0, new ListItem("No Record", "0"));
            }
        }
    }
    void VillageName()
    {
        if (ddlselectreserve.SelectedValue == "0")
        {
            if (Session["UserType"].ToString().Equals("1"))
            {

                btnassociatevillage.Visible = true;
                PageLoadFunction1();
                BindTigerReserveName1();
               
            }
        }
        else
        {
            VillageCode();
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
                ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Name", "0"));
            }
            else
            {
                ddlselectname.Items.Clear();
                ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }
        }///
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName1();
      //  VillageName();
    }
}