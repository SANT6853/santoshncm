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

public partial class auth_Adminpanel_RelocationSite_Relocation_Management : CrsfBase
{
    Realocation_AreaEntiry RELO_ENT_Obj = new Realocation_AreaEntiry();
    Realocation_AreaDB RELODB_Obj = new Realocation_AreaDB();
    VillageDB VillDB_Obj = new VillageDB();
    Reserve_Entity RSVR_Entity = new Reserve_Entity();
    AuditTrailDB Audit_ObjDB = new AuditTrailDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    static string name = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        lblMsg.Text = "";
        //gvforVillages.Columns[5].Visible = false;
        try
        {
            if (Session["UserType"].ToString() == null)
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"), true);
                return;
            }
           
            if (!IsPostBack)
            {
                BindVillages();
                if (Session["UserType"].ToString().Equals("1"))
                {

                    ImgbtnAddNew.Visible = true;
                    Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                }
                if (Session["UserType"].ToString().Equals("2"))
                {

                    ImgbtnAddNew.Visible = false;
                    Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                }
                if (Session["UserType"].ToString().Equals("3"))
                {

                    ImgbtnAddNew.Visible = false;
                    Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                }
                if (Session["UserType"].ToString().Equals("4"))
                {

                    Fill_VillageCode_And_Name(Convert.ToInt32(Session["User_Id"]));
                }
                  
            }
        }
        catch (Exception e3)
        {
            Response.Redirect(ResolveUrl("~/HOME.aspx"), true);
            return;
        }
    }
    protected void ImgbtnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/RELOCATIONSITE/Add_Site.aspx"), false);
    }
    protected void ImgbtnGo_Click(object sender, EventArgs e)
    {
        BindVillages();
       
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvforVillages.PageIndex = e.NewPageIndex;

            BindVillages();

        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
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
                                Response.Redirect(ResolveUrl("Edit_Site.aspx?" + WebConstant.QueryStringEnum.RELO_ID + "=" + e.CommandArgument.ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&village_id=" + Request.QueryString["village_id"] + "&inid=" + Request.QueryString["inid"] + "&vcode=" + Request.QueryString["vcode"] + "&vname=" + Request.QueryString["vname"]), false);
                            }
                            if (e.CommandName == "Delete")
                            {
                                bool check = RELODB_Obj.Delete_Relocation_Site(Int32.Parse(e.CommandArgument.ToString()));
                                if (check == true)
                                {
                                    lblMsg.Text = "Record Deleted Successly";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                    BindVillages();
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
                }

            }//}
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
        try
        {
           

            RELO_ENT_Obj._VILL_ID = Request.QueryString["village_id"].ToString();
               // ds = RELODB_Obj.Display_All_Relocation_Area(RELO_ENT_Obj, null);
            ds = RELODB_Obj.Display_All_Relocation_AreaNew(RELO_ENT_Obj, null);
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
           // }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
   
    public void BindVillages_for_Deo()
    {
        DataSet ds = new DataSet();
        try
        {
            ddlselectname.SelectedValue = Session["VillageId"].ToString();
            RELO_ENT_Obj._VILL_ID = Session["VillageId"].ToString();
            ds = RELODB_Obj.Display_All_Relocation_Area(RELO_ENT_Obj, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                gvforVillages.DataBind();
            }
            else
            {

                gvforVillages.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound + "for " + Session["VILLAGENAME"].ToString() + " ";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void Fill_VillageCode_And_Name(int Userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name(Userid);
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
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    public void Fill_VillageCode_And_Name3(int Userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name3(Userid);
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
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name2(int Userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name2(Userid);
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
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name1(int Userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name1(Userid);
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
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ImgbtnBack_Click(object sender, EventArgs e)
    {
        //auth/adminpanel/VILLAGE/Village_Management.aspx Response.Redirect(ResolveUrl("~/AUTH/adminpanel/RELOCATIONSITE/Relocation_Management.aspx"), false);
        // Response.Redirect(ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx"), false);
        Response.Redirect(ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management_Edit.aspx?village_id=" + Request.QueryString["village_id"] + "&inid=" + Request.QueryString["inid"] + "&vcode=" + Request.QueryString["vcode"] + "&vname=" + Request.QueryString["vname"]), false);
    }
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvforVillages.Visible = false;
    }
}