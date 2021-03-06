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

public partial class auth_Adminpanel_CDP_CDP_Management : CrsfBase
{
    Village Vill_Obj = new Village();
    VillageEntity VillEntity_Obj = new VillageEntity();
    VillageDB VillDB_Obj = new VillageDB();
    Reserve_Entity RSVR_Entity = new Reserve_Entity();
    AuditTrailDB Audit_ObjDB = new AuditTrailDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    bool flag = false;
    NgoDB Obj_NgoDb = new NgoDB();
    NgoEntity Obj_NgoEnt = new NgoEntity();
    static string name = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        gvforVillages.Columns[5].Visible = false;
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }

        try
        {


            if (!IsPostBack)
            {
                ViewState["indexpage"] = 0;
                if (Session["UserType"].ToString().Equals("1"))
                {
                    ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
                    PageLoadFunction1();
                    BindStateName();

                  
                }//
                if (Session["UserType"].ToString().Equals("2"))
                {
                    ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
                    PageLoadFunction2();
                    BindTigerReserveName();
                    ddlState.Visible = false;
                }//
                if (Session["UserType"].ToString().Equals("3"))
                {
                    ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
                    PageLoadFunction3();
                    BindTigerReserveName();
                    ddlState.Visible = false;
                }//
                if (Session["UserType"].ToString().Equals("4"))
                {
                    ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
                    PageLoadFunction();
                    BindTigerReserveName();
                    ddlState.Visible = false;
                }//

            }
        }
        catch (Exception e3)
        {
            // Response.Redirect(ResolveUrl("~/User_Login.aspx"), false);
            return;
        }
    }
    public void PageLoadFunction()
    {
        Fill_VillageCode_And_Name(Convert.ToInt32(Session["User_Id"]));
        if (Request.QueryString["vid"] != null)
        {
            ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
            SelectedIndex();
            BindVillages();

        }
        else
        {
            BindVillagesforadmin();
        }

        if (Request.QueryString["viewid"] != null)
        {
            if (Request.QueryString["viewid"].ToString().Equals("1"))
            {
                flag = false;
                //  BindVillages_For_Deo();
                imgbtnviewall.Visible = true;
                btnviewcurrent.Visible = false;
                ddlState.Visible = true;

            }
            else
            {
                SelectedIndex();
                flag = true;
                //  BindVillages_For_Deo();
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
        Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
        if (Request.QueryString["vid"] != null)
        {
            ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
            SelectedIndex();
            BindVillages3();

        }
        else
        {
            BindVillagesforadmin3();
        }

        if (Request.QueryString["viewid"] != null)
        {
            if (Request.QueryString["viewid"].ToString().Equals("1"))
            {
                flag = false;
                //  BindVillages_For_Deo();
                imgbtnviewall.Visible = true;
                btnviewcurrent.Visible = false;
                ddlState.Visible = true;
            }
            else
            {
                SelectedIndex();
                flag = true;
                //  BindVillages_For_Deo();
                imgbtnviewall.Visible = false;
                btnviewcurrent.Visible = true;
                ddlState.Visible = true;
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
        Fill_VillageCode_And_Name2(Convert.ToInt32(ddlselectreserve.SelectedValue));
        if (Request.QueryString["vid"] != null)
        {
            ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
            SelectedIndex();
            BindVillages2();

        }
        else
        {
            BindVillagesforadmin2();
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
                //  BindVillages_For_Deo();
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
        if (ddlselectreserve.SelectedValue !="0")
        {
            Fill_VillageCode_And_Name1(Convert.ToInt32(ddlselectreserve.SelectedValue));
        }
        else
        {
            ddlselectname.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        if (Request.QueryString["vid"] != null)
        {
            ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
            SelectedIndex();
            BindVillages1();

        }
        else
        {
            BindVillagesforadmin1();
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
                //  BindVillages_For_Deo();
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
    public void BindVillagesforadmin()
    {
        if (!ddlselectname.SelectedValue.ToString().Equals("0"))
        {
            DataSet ds = new DataSet();
            try
            {
                // ddlselectname.SelectedValue = Session["VILLAGEID"].ToString();

                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
                name = ddlselectname.SelectedItem.ToString();
                VillEntity_Obj._VILL_CD = null;
                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);


                // ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj, name, ddlselectreserve.SelectedValue.ToString());
                ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj);

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
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
    public void BindVillagesforadmin3()
    {
        if (!ddlselectname.SelectedValue.ToString().Equals("0"))
        {
            DataSet ds = new DataSet();
            try
            {
                // ddlselectname.SelectedValue = Session["VILLAGEID"].ToString();

                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
                name = ddlselectname.SelectedItem.ToString();
                VillEntity_Obj._VILL_CD = null;
                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);


                // ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj, name, ddlselectreserve.SelectedValue.ToString());
                ds = VillDB_Obj.Display_All_VillagesDB3(VillEntity_Obj);

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
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
    public void BindVillagesforadmin2()
    {
        if (!ddlselectname.SelectedValue.ToString().Equals("0"))
        {
            DataSet ds = new DataSet();
            try
            {
                // ddlselectname.SelectedValue = Session["VILLAGEID"].ToString();

                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
                name = ddlselectname.SelectedItem.ToString();
                VillEntity_Obj._VILL_CD = null;
                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);


                // ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj, name, ddlselectreserve.SelectedValue.ToString());
                ds = VillDB_Obj.Display_All_VillagesDB2(VillEntity_Obj);

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
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
    public void BindVillagesforadmin1()
    {
        if (!ddlselectname.SelectedValue.ToString().Equals("0"))
        {
            DataSet ds = new DataSet();
            try
            {
                // ddlselectname.SelectedValue = Session["VILLAGEID"].ToString();

                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
                name = ddlselectname.SelectedItem.ToString();
                VillEntity_Obj._VILL_CD = null;
                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);


                // ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj, name, ddlselectreserve.SelectedValue.ToString());
                ds = VillDB_Obj.Display_All_VillagesDB1(VillEntity_Obj);

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
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
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
    protected void ImgbtnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/CDP/CDP_Add.aspx"), false);
    }
    protected void ImgbtnGo_Click(object sender, EventArgs e)
    {
        lblMsg.Text = string.Empty;
        if (Session["UserType"].ToString().Equals("4"))
        {

            try
            {
                if (ddlselectname.SelectedItem.Text == "Select Name")
                {
                    lblMsg.Text = "Please choose village name.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (ddlselectname.SelectedValue.ToString().Equals("0"))
                    {

                        BindVillages();
                        return;
                    }
                    else if (!ddlselectname.SelectedValue.ToString().Equals("0"))
                    {
                        VillEntity_Obj._VILL_ID = null;
                        //RSVR_Entity._RSRV_AREA_NM = txtName.Text.Trim();
                        name = ddlselectname.SelectedItem.ToString();

                        BindVillages();
                        return;
                    }
                }


            }
            catch (Exception e1)
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
        if (Session["UserType"].ToString().Equals("1"))
        {

            try
            {
                if (ddlselectname.SelectedItem.Text == "Select Name")
                {
                    lblMsg.Text = "Please choose village name.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (ddlselectname.SelectedValue.ToString().Equals("0"))
                    {

                        BindVillages1();
                        return;
                    }
                    else if (!ddlselectname.SelectedValue.ToString().Equals("0"))
                    {
                        VillEntity_Obj._VILL_ID = null;
                        //RSVR_Entity._RSRV_AREA_NM = txtName.Text.Trim();
                        name = ddlselectname.SelectedItem.ToString();

                        BindVillages1();
                        return;
                    }
                }


            }
            catch (Exception e1)
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }//
        if (Session["UserType"].ToString().Equals("2"))
        {

            try
            {
                if (ddlselectname.SelectedItem.Text == "Select Name")
                {
                    lblMsg.Text = "Please choose village name.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (ddlselectname.SelectedValue.ToString().Equals("0"))
                    {

                        BindVillages2();
                        return;
                    }
                    else if (!ddlselectname.SelectedValue.ToString().Equals("0"))
                    {
                        VillEntity_Obj._VILL_ID = null;
                        //RSVR_Entity._RSRV_AREA_NM = txtName.Text.Trim();
                        name = ddlselectname.SelectedItem.ToString();

                        BindVillages2();
                        return;
                    }

                }
            }
            catch (Exception e1)
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }//
        if (Session["UserType"].ToString().Equals("3"))
        {

            try
            {
                if (ddlselectname.SelectedItem.Text == "Select Name")
                {
                    lblMsg.Text = "Please choose village name.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (ddlselectname.SelectedValue.ToString().Equals("0"))
                    {

                        BindVillages3();
                        return;
                    }
                    else if (!ddlselectname.SelectedValue.ToString().Equals("0"))
                    {
                        VillEntity_Obj._VILL_ID = null;
                        //RSVR_Entity._RSRV_AREA_NM = txtName.Text.Trim();
                        name = ddlselectname.SelectedItem.ToString();

                        BindVillages3();
                        return;
                    }
                }

            }
            catch (Exception e1)
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }//
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            ViewState["indexpage"] = gvforVillages.PageIndex = e.NewPageIndex;
            if (flag == true)
            {
                //BindVillages_For_Deo();
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
        if (Session["UserType"].ToString().Equals("3") || Session["UserType"].ToString().Equals("2"))
        {

            this.gvforVillages.Columns[3].Visible = false;
        }

        foreach (GridViewRow row in gvforVillages.Rows)
        {

            string t = row.Cells[3].Text;
            string villid = gvforVillages.DataKeys[row.RowIndex].Value.ToString();
            DataSet ds = VillDB_Obj.CheckCDP_details(villid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
                {

                    ImageButton ib = (ImageButton)row.FindControl("ibEdit");
                    ib.Visible = true;

                }
                else if (ds.Tables[0].Rows[0][0].ToString().Equals("0"))
                {
                    ImageButton ib = (ImageButton)row.FindControl("ibAdd");
                    ib.Visible = true;
                }
            }
        }
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
                        // try
                        // {
                        if (e.CommandName == "Edit")
                        {
                            if (btnviewcurrent.Visible == false && imgbtnviewall.Visible == false)
                            {
                                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Edit.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString()), false);

                            }
                            else
                            {
                                if (btnviewcurrent.Visible == true)
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Edit.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&viewid=2"), false);
                                }
                                else
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Edit.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&viewid=1"), false);
                                }
                            }



                        }
                        if (e.CommandName == "Add")
                        {
                            if (btnviewcurrent.Visible == false && imgbtnviewall.Visible == false)
                            {
                                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Add.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString()), false);

                            }
                            else
                            {
                                if (btnviewcurrent.Visible == true)
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Add.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&viewid=2"), false);
                                }
                                else
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Add.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&viewid=1"), false);
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
                                    //BindVillages_For_Deo();
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
                        //}
                        //catch (Exception e1)
                        //{
                        //    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
                        //    lblMsg.ForeColor = System.Drawing.Color.Red;

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
   // }
    public void BindVillages()
    {
        if (!ddlselectname.SelectedValue.ToString().Equals("0"))
        {
            DataSet ds = new DataSet();
            try
            {
                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);

                ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj);

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
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
    public void BindVillages3()
    {
        if (!ddlselectname.SelectedValue.ToString().Equals("0"))
        {
            DataSet ds = new DataSet();
            try
            {
                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);

                ds = VillDB_Obj.Display_All_VillagesDB3(VillEntity_Obj);

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
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
    public void BindVillages2()
    {
        if (!ddlselectname.SelectedValue.ToString().Equals("0"))
        {
            DataSet ds = new DataSet();
            try
            {
                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
                VillEntity_Obj.CmnTigerReserveUserID = Convert.ToInt32(ddlselectreserve.SelectedValue);
                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);

                ds = VillDB_Obj.Display_All_VillagesDB2(VillEntity_Obj);

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
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
    public void BindVillages1()
    {
        
            DataSet ds = new DataSet();
            try
            {

                VillEntity_Obj._VILL_ID = ddlselectname.SelectedValue;
                VillEntity_Obj.CmnTigerReserveUserID = Convert.ToInt32(ddlselectreserve.SelectedValue);
                VillEntity_Obj.CmnStateID = Convert.ToInt32(DdlStateName.SelectedValue);
                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);

                //ds = VillDB_Obj.Display_All_VillagesDB1(VillEntity_Obj);
                ds = VillDB_Obj.Display_All_Villages(VillEntity_Obj);

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
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
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

                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
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

                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name2(int userid=0)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            
            ds = VillDB_Obj.Fill_VillageCodes(userid);
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

                ddlselectname.Items.Add(new ListItem("Select Name", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
       
    }
    public void Fill_VillageCode_And_Name1(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode(userid);
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

                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void imgbtnviewall_Click(object sender, EventArgs e)
    {
        flag = true;
        //  BindVillages_For_Deo();
        imgbtnviewall.Visible = false;
        btnviewcurrent.Visible = true;
    }
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvforVillages.Visible = false;

    }
    protected void ImageButton2_Click(object sender, EventArgs e)
    {
        //ModalPopupExtender2.Show();
    }
    protected void btnviewcurrent_Click(object sender, EventArgs e)
    {
        flag = false;
        // BindVillages_For_Deo();
        imgbtnviewall.Visible = true;
        btnviewcurrent.Visible = false;
    }
    protected void ImageButton2_Click1(object sender, EventArgs e)
    {
        //ModalPopupExtender2.Show();
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
     //  {
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

                           lblMsg.Text = string.Empty;
                           if (Session["UserType"].ToString().Equals("4"))
                           {

                               try
                               {
                                   if (ddlselectname.SelectedItem.Text == "Select Name")
                                   {
                                       lblMsg.Text = "Please choose village name.";
                                       lblMsg.ForeColor = System.Drawing.Color.Red;
                                   }
                                   else
                                   {
                                       if (ddlselectname.SelectedValue.ToString().Equals("0"))
                                       {

                                           BindVillages();
                                           return;
                                       }
                                       else if (!ddlselectname.SelectedValue.ToString().Equals("0"))
                                       {
                                           VillEntity_Obj._VILL_ID = null;
                                           //RSVR_Entity._RSRV_AREA_NM = txtName.Text.Trim();
                                           name = ddlselectname.SelectedItem.ToString();

                                           BindVillages();
                                           return;
                                       }
                                   }


                               }
                               catch (Exception e1)
                               {
                                   lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                                   lblMsg.ForeColor = System.Drawing.Color.Red;

                               }
                           }
                           if (Session["UserType"].ToString().Equals("1"))
                           {

                               try
                               {
                                   if (ddlselectname.SelectedItem.Text == "Select Name")
                                   {
                                       lblMsg.Text = "Please choose village name.";
                                       lblMsg.ForeColor = System.Drawing.Color.Red;
                                   }
                                   else
                                   {
                                       if (ddlselectname.SelectedValue.ToString().Equals("0"))
                                       {

                                           BindVillages1();
                                           return;
                                       }
                                       else if (!ddlselectname.SelectedValue.ToString().Equals("0"))
                                       {
                                           VillEntity_Obj._VILL_ID = null;
                                           //RSVR_Entity._RSRV_AREA_NM = txtName.Text.Trim();
                                           name = ddlselectname.SelectedItem.ToString();

                                           BindVillages1();
                                           return;
                                       }
                                   }


                               }
                               catch (Exception e1)
                               {
                                   lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                                   lblMsg.ForeColor = System.Drawing.Color.Red;

                               }
                           }//
                           if (Session["UserType"].ToString().Equals("2"))
                           {

                               try
                               {
                                   if (ddlselectname.SelectedItem.Text == "Select Name")
                                   {
                                       lblMsg.Text = "Please choose village name.";
                                       lblMsg.ForeColor = System.Drawing.Color.Red;
                                   }
                                   else
                                   {
                                       if (ddlselectname.SelectedValue.ToString().Equals("0"))
                                       {

                                           BindVillages2();
                                           return;
                                       }
                                       else if (!ddlselectname.SelectedValue.ToString().Equals("0"))
                                       {
                                           VillEntity_Obj._VILL_ID = null;
                                           //RSVR_Entity._RSRV_AREA_NM = txtName.Text.Trim();
                                           name = ddlselectname.SelectedItem.ToString();

                                           BindVillages2();
                                           return;
                                       }

                                   }
                               }
                               catch (Exception e1)
                               {
                                   lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                                   lblMsg.ForeColor = System.Drawing.Color.Red;

                               }
                           }//
                           if (Session["UserType"].ToString().Equals("3"))
                           {

                               try
                               {
                                   if (ddlselectname.SelectedItem.Text == "Select Name")
                                   {
                                       lblMsg.Text = "Please choose village name.";
                                       lblMsg.ForeColor = System.Drawing.Color.Red;
                                   }
                                   else
                                   {
                                       if (ddlselectname.SelectedValue.ToString().Equals("0"))
                                       {

                                           BindVillages3();
                                           return;
                                       }
                                       else if (!ddlselectname.SelectedValue.ToString().Equals("0"))
                                       {
                                           VillEntity_Obj._VILL_ID = null;
                                           //RSVR_Entity._RSRV_AREA_NM = txtName.Text.Trim();
                                           name = ddlselectname.SelectedItem.ToString();

                                           BindVillages3();
                                           return;
                                       }
                                   }

                               }
                               catch (Exception e1)
                               {
                                   lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
                                   lblMsg.ForeColor = System.Drawing.Color.Red;

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
           

     //  }

    }
    protected void ddlselectcode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        if (Session["UserType"].ToString().Equals("1"))
        {
            PageLoadFunction1();
        }
        else
        {

            PageLoadFunction2();
        }
       
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName();
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
            DdlStateName.DataValueField = "id";
            DdlStateName.DataBind();
            DdlStateName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }
    }
    void BindTigerReserveName()
    {
        try
        {
            int State=0;
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            if(!string.IsNullOrEmpty(DdlStateName.SelectedValue) && Convert.ToInt32(DdlStateName.SelectedValue) !=0)
            {
                State = Convert.ToInt32(DdlStateName.SelectedValue);
            }
            else
            {
                State = Convert.ToInt32(Session["sStateID"]);
            }
            DataSet ds = new VillageDB().BindTigerReserve(State);
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
}