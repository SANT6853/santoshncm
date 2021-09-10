using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_Familydata : CrsfBase
{
    FamilyDB FMLYDB_Obj = new FamilyDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    VillageDB VillDB_Obj = new VillageDB();
    static string vill_id = "", scheme_id = "", reserve_id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Family Report By Head Name : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }

        lblMsg.Text = "";
       
        if (!Page.IsPostBack)
        {

            Page.Title = "Family Management Page";


            if (Session["UserType"].ToString() == "1")
            {
                BindTigerReserveName1();
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                bindfamilyheadname();
                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {
                    BtnBackConsoldateReport.Visible = true;
                }
                else
                {
                    BtnBackConsoldateReport.Visible = false;
                }
            }
            if (Session["UserType"].ToString() == "2")
            {
                Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                bindfamilyheadname();
            }
            if (Session["UserType"].ToString() == "3")
            {
                Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                bindfamilyheadname();
            }
            if (Session["UserType"].ToString() == "4")
            {

                Fill_VillageCode_And_Name();

                bindfamilyheadname();
            }

        }
    }
    public void Fill_VillageCode_And_Name2(int CmnStateUserID)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name2(CmnStateUserID);
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
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][3].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlselectname.Items.Add(new ListItem("No Record", "0"));
                //  ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name1(int CmnStateUserID)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name1(CmnStateUserID);
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

                // ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name3(int CmnTigerReserveUserID)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name3(CmnTigerReserveUserID);
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
                //ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name()
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name(Convert.ToInt32(Session["User_Id"]));
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
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{

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

                        //try
                        //{
                            if (ddlselectname.SelectedValue.ToString().Equals("0") || ddlselectheadname.SelectedValue.ToString().Equals("0"))
                            {

                                lblMsg.Text = "Please Select Values From the List";

                            }
                            else
                            {
                                if (Session["UserType"].ToString() == "1")
                                {
                                    if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                                    {
                                        if (ddlselectreserve.SelectedValue != "0")
                                        {
                                            Response.Redirect("~/AUTH/adminpanel/REPORT/ViewFamilyData.aspx?F_ID=" + ddlselectheadname.SelectedValue.ToString() + "&s_ID=1" + "&villid=" + ddlselectname.SelectedValue + "&Resv=" + ddlselectreserve.SelectedItem.Text + "&ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString());
                                        }
                                        else
                                        {
                                            Response.Redirect("~/AUTH/adminpanel/REPORT/ViewFamilyData.aspx?F_ID=" + ddlselectheadname.SelectedValue.ToString() + "&s_ID=1" + "&villid=" + ddlselectname.SelectedValue + "&Resv=NA" + "&ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (ddlselectreserve.SelectedValue != "0")
                                        {
                                            Response.Redirect("~/AUTH/adminpanel/REPORT/ViewFamilyData.aspx?F_ID=" + ddlselectheadname.SelectedValue.ToString() + "&s_ID=1" + "&villid=" + ddlselectname.SelectedValue + "&Resv=" + ddlselectreserve.SelectedItem.Text);
                                        }
                                        else
                                        {
                                            Response.Redirect("~/AUTH/adminpanel/REPORT/ViewFamilyData.aspx?F_ID=" + ddlselectheadname.SelectedValue.ToString() + "&s_ID=1" + "&villid=" + ddlselectname.SelectedValue + "&Resv=NA");
                                        }
                                    }

                                }
                                if (Session["UserType"].ToString() == "4" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
                                {
                                    Response.Redirect("~/AUTH/adminpanel/REPORT/ViewFamilyData.aspx?F_ID=" + ddlselectheadname.SelectedValue.ToString() + "&s_ID=1" + "&villid=" + ddlselectname.SelectedValue + "&Resv=NA");
                                }
                            }

                        //}
                        //catch (Exception e1)
                        //{
                        //    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
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
    }
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlselectname.SelectedValue.ToString().Equals("0"))
        { 
        }
        else
        {
            ddlselectheadname.Items.Clear();
            bindfamilyheadname();



        }
    }
    void bindfamilyheadname()
    {
        DataTable dt = FMLYDB_Obj.FillFamilyHeadName(ddlselectname.SelectedValue);
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
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        VillageName();
        ddlselectheadname.Items.Clear();
        bindfamilyheadname();
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
    void BindTigerReserveName1()
    {

        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select tiger reserve-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName1Modified(null);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new ListItem("-Select tiger reserve-", "0"));
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

    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{

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

                        Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsoldateReport.aspx");
                    }
                }
            }

        }
        

        catch
        {
            throw;
        }
    }
}