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

public partial class auth_Adminpanel_REPORT_OptionWiseFamilyRpt : CrsfBase
{
    FamilyDB FMLYDB_Obj = new FamilyDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    VillageDB VillDB_Obj = new VillageDB();
    static string vill_id = "", scheme_id = "", reserve_id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "OPTION WISE REPORT : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }

        lblMsg.Text = "";
       

        if (!Page.IsPostBack)
        {

            Page.Title = "Family Management Page";

            
            if (Session["UserType"].ToString() == "1")
            {
                BindStateName();
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                BindTigerReserveName1();
            }
            if (Session["UserType"].ToString() == "2")
            {
                Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
            }
            if (Session["UserType"].ToString() == "3")
            {
                Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
            }
            if (Session["UserType"].ToString() == "4")
            {
                Fill_VillageCode_And_Name();
            }
           

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
                    ListItem liforname = new ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
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

    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        VillageName();
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

                        try
                        {
                            if (!ddlselectscheme.SelectedValue.ToString().Equals("0") && !ddlselectname.SelectedValue.ToString().Equals("0"))
                            {

                                scheme_id = ddlselectscheme.SelectedValue.ToString();
                                vill_id = ddlselectname.SelectedValue.ToString();
                                if (Session["UserType"].ToString().Equals("1"))
                                {
                                    reserve_id = "";
                                }
                                else
                                {
                                    reserve_id = Session["sTigerReserveid"].ToString();
                                }

                                if (Session["UserType"].ToString() == "1")
                                {

                                    if (ddlselectreserve.SelectedValue != "0")
                                    {
                                        Response.Redirect("OptionWiseFamilyRptII.aspx?S_id=" + scheme_id.ToString() + "&V_ID=" + vill_id.ToString() + "&R_ID=" + reserve_id.ToString() + "&Reservename=" + ddlselectreserve.SelectedItem.Text, false);
                                    }
                                    else
                                    {
                                        Response.Redirect("OptionWiseFamilyRptII.aspx?S_id=" + scheme_id.ToString() + "&V_ID=" + vill_id.ToString() + "&R_ID=" + reserve_id.ToString() + "&Reservename=NA", false);
                                    }
                                }
                                if (Session["UserType"].ToString() == "4" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
                                {
                                    Response.Redirect("OptionWiseFamilyRptII.aspx?S_id=" + scheme_id.ToString() + "&V_ID=" + vill_id.ToString() + "&R_ID=" + reserve_id.ToString() + "&Reservename=NA", false);
                                }

                            }
                            else if (ddlselectscheme.SelectedValue.ToString().Equals("0"))
                            {

                                // gvForFamily.Visible = false;
                                lblMsg.Text = "Please Select Option";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                return;
                            }
                            else if (ddlselectname.SelectedValue.ToString().Equals("0"))
                            {

                                // gvForFamily.Visible = false;
                                lblMsg.Text = "Please Select Village Name";
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                return;
                            }



                        }
                        catch (Exception e1)
                        {
                            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
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
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName1();
    }
}