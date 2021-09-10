using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NCM.DAL;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_perticular_village_report : CrsfBase
{
    NgoBal bal = new NgoBal();
    DataSet ds = new DataSet();
    FamilyDB obj = new FamilyDB();
    CommonDB comDB_Obj = new CommonDB();
    common com_Obj = new common();
    VillageDB VillDB_Obj = new VillageDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);

        }
        if (!IsPostBack)
        {
            if (Session["UserType"].ToString() == "1")
            {
                BindTigerReserveName1();
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
               // btn_print.Visible = false;
            }
            if (Session["UserType"].ToString() == "2")
            {
                Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                //btn_print.Visible = false;
            }
            if (Session["UserType"].ToString() == "3")
            {
                Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                
            }
            if (Session["UserType"].ToString() == "4")
            {

                filldropedownvillage();
            }          

        }
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
            ddlvillage.DataSource = P_var.dSet.Tables[2];
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            ddlvillage.Items.Clear();
            ddlvillage.Items.Insert(0, new ListItem("No Record", "0"));
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
    public void Fill_VillageCode_And_Name1(int CmnStateUserID)
    {
        try
        {

            ddlvillage.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name1(CmnStateUserID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                ddlvillage.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlvillage.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                // ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlvillage.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
           // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
           // lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name2(int CmnStateUserID)
    {
        try
        {

            ddlvillage.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name2(CmnStateUserID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                ddlvillage.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlvillage.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlvillage.Items.Add(new ListItem("No Record", "0"));
                //  ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name3(int CmnTigerReserveUserID)
    {
        try
        {

            ddlvillage.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name3(CmnTigerReserveUserID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                ListItem li2 = new ListItem("Select Name", "0");

                ddlvillage.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlvillage.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlvillage.Items.Add(new ListItem("No Record", "0"));
                //ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void filldropedownvillage()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.Proc_Get_All_Villages(Convert.ToInt32(Session["User_Id"]));
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
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
                        if (ddlvillage.SelectedValue == "0")
                        {
                            lblmsg.Text = "Please select village";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            if (Session["UserType"].ToString() == "1")
                            {

                                if (ddlselectreserve.SelectedValue != "0")
                                {
                                    //Response.Redirect("~/AUTH/adminpanel/REPORT/ViewFamilyData.aspx?F_ID=" + ddlselectheadname.SelectedValue.ToString() + "&s_ID=1" + "&villid=" + ddlselectname.SelectedValue+"&Resv="+ddlselectreserve.SelectedItem.Text);
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/perticularreportprint.aspx?villageid=" + ddlvillage.SelectedValue + "&Resv=" + ddlselectreserve.SelectedItem.Text));
                                }
                                else
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/perticularreportprint.aspx?villageid=" + ddlvillage.SelectedValue + "&Resv=NA"));
                                    //Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/perticularreportprint.aspx?villageid=" + ddlvillage.SelectedValue + ""));
                                }
                            }
                            if (Session["UserType"].ToString() == "4" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
                            {
                                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/perticularreportprint.aspx?villageid=" + ddlvillage.SelectedValue + "&Resv=NA"));
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
    }


protected void btnviewimg_Click(object sender, EventArgs e)
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
                        if (ddlvillage.SelectedValue == "0")
                        {
                            lblmsg.Text = "Please select village";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            if (Session["UserType"].ToString() == "1")
                            {

                                if (ddlselectreserve.SelectedValue != "0")
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Releted_Imege.aspx?villageid=" + ddlvillage.SelectedValue + "&type=" + 1 + "&Resv=" + ddlselectreserve.SelectedItem.Text));
                                }
                                else
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Releted_Imege.aspx?villageid=" + ddlvillage.SelectedValue + "&type=" + 1 + "&Resv=NA"));
                                }
                            }
                            if (Session["UserType"].ToString() == "4" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
                            {
                                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Releted_Imege.aspx?villageid=" + ddlvillage.SelectedValue + "&type=" + 1 + "&Resv=NA"));
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
    }

    protected void btnfile_Click(object sender, EventArgs e)
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
                        if (ddlvillage.SelectedValue == "0")
                        {
                            lblmsg.Text = "Please select village";
                            lblmsg.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            if (Session["UserType"].ToString() == "1")
                            {
                                if (ddlselectreserve.SelectedValue != "0")
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Releted_Imege.aspx?villageid=" + ddlvillage.SelectedValue + "&type=" + 2 + "&Resv=" + ddlselectreserve.SelectedItem.Text));
                                }
                                else
                                {
                                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Releted_Imege.aspx?villageid=" + ddlvillage.SelectedValue + "&type=" + 2 + "&Resv=NA"));
                                }
                            }
                            if (Session["UserType"].ToString() == "4" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
                            {
                                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Releted_Imege.aspx?villageid=" + ddlvillage.SelectedValue + "&type=" + 2 + "&Resv=NA"));
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
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        VillageName();
      
    }
}