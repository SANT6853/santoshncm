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
using System.Text;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_VILLAGE_Village_Management_Edit : CrsfBase
{
    Project_Variables p_Var = new Project_Variables();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    VillageEntity VillEntity_Obj = new VillageEntity();
    VillageDB VillDB_Obj = new VillageDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    AuditTrailDB Audit_ObjDB = new AuditTrailDB();
    public static bool check, flag = false;
    string stateid = "", reserveid = "", districtid = "", tehsilid = "";
    public static int total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        HiddenField1.Value = com_Obj.fordate();
        lblMsg.Text = "";

        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }

        if (!Page.IsPostBack)
        {
            try
            {
                LblstatusMsg.Text = "";
                if (Request.QueryString["SaveStatus"] != null)
                {
                    LblstatusMsg.Text = Request.QueryString["SaveStatus"].ToString();
                    LblstatusMsg.ForeColor = System.Drawing.Color.Green;
                }
                if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != null)
                {
                    if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != "")
                    {

                        if (Session["UserType"].ToString().Equals("4") || Session["UserType"].ToString().Equals("3") || Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("1"))
                        {
                            flag = true;
                            //FillState_District_Rerserve_Name();
                            FillDistrict();
                        }
                        Load_Village_Info();
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
            }
            catch (Exception e1)
            {
                // Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx"), true);

            }
        }//
    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {

        bool s;
        string ext1 = System.IO.Path.GetExtension(fileUpload_Menu.PostedFile.FileName);
        ext1 = ext1.ToLower();
        if (ext1 == ".pdf")
        {
            s = miscellBL.GetActualFileType_pdf(fileUpload_Menu.PostedFile.InputStream);
        }
        else if (ext1 == ".xlsx")
        {
            s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
        }
        else if (ext1 == ".docx")
        {
            s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
        }
        else if (ext1 == ".doc ")
        {
            s = miscellBL.GetActualFileType(fileUpload_Menu.PostedFile.InputStream);
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
    public void Load_Village_Info()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = null;
            VillEntity_Obj._VILL_ID = Request.QueryString["village_id"].ToString();

            ds = VillDB_Obj.Display_All_VillagesDB(VillEntity_Obj);
            if (ds.Tables[0].Rows.Count > 0)
            {

                //txtcutdate.Text =ds.Tables[0].Rows[0]["VILL_CUT_DT1"].ToString();
                txtsurdate.Text = ds.Tables[0].Rows[0]["VILL_SURVEY_DT1"].ToString();


                TxtDateMeeting.Text = ds.Tables[0].Rows[0]["DateMeeting1"].ToString();
                TxtCuttOffDate.Text = ds.Tables[0].Rows[0]["CuttOffDate1"].ToString();
                Txtadult.Text = ds.Tables[0].Rows[0]["NoAdult"].ToString();
                TxtnoTransgender.Text = ds.Tables[0].Rows[0]["NoTransGender"].ToString();
                TxtNoCow.Text = ds.Tables[0].Rows[0]["NoCows"].ToString();
                TxtBuffalo.Text = ds.Tables[0].Rows[0]["NoBuffalo"].ToString();
                TxtSheep.Text = ds.Tables[0].Rows[0]["NoSheep"].ToString();
                TxtGoat.Text = ds.Tables[0].Rows[0]["NoGoat"].ToString();
               // hypfile.Text = ds.Tables[0].Rows[0]["FileNames"].ToString();

                TxtLatitude.Text = ds.Tables[0].Rows[0]["Latitude"].ToString();
                TxtLongitude.Text = ds.Tables[0].Rows[0]["Longitude"].ToString();

                txtcode.Text = ds.Tables[0].Rows[0]["VILL_CD"].ToString();
                txtotherland.Text = ds.Tables[0].Rows[0]["VILL_OTHER_LND_AREA"].ToString();
                txtname.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                txtPop.Text = ds.Tables[0].Rows[0]["VILL_POPU"].ToString();
                txtland.Text = ds.Tables[0].Rows[0]["VILL_TOT_LND_AREA"].ToString();
                txtagri.Text = ds.Tables[0].Rows[0]["VILL_TOT_AGRI_LND_AREA"].ToString();
                txtnonagri.Text = ds.Tables[0].Rows[0]["VILL_TOT_NON_AGRI_LND_AREA"].ToString();
                txtfamilies.Text = ds.Tables[0].Rows[0]["VILL_NO_FM"].ToString();
                txtlivestock.Text = ds.Tables[0].Rows[0]["VILL_NO_LIV_STOK"].ToString();
                txtobc.Text = ds.Tables[0].Rows[0]["VILL_TOT_OBC"].ToString();
                txtst.Text = ds.Tables[0].Rows[0]["VILL_TOT_ST"].ToString();
                txtsc.Text = ds.Tables[0].Rows[0]["VILL_TOT_SC"].ToString();
                txtother.Text = ds.Tables[0].Rows[0]["VILL_TOT_OTH"].ToString();
                ddlVillageLegalStatus.SelectedValue = ds.Tables[0].Rows[0]["VILL_LGL_STAT"].ToString();
                ddlVillageStatus.SelectedValue = ds.Tables[0].Rows[0]["VILL_STAT"].ToString();
                if (ddlVillageStatus.SelectedValue == "1")
                {
                    BtnRelocationSiteDetailsEdit.Visible = true;
                }
                else
                {
                    BtnRelocationSiteDetailsEdit.Visible = false;
                }
                txtmalepop.Text = ds.Tables[0].Rows[0]["VILL_MALE"].ToString();
                txtfemalepop.Text = ds.Tables[0].Rows[0]["VILL_FEMALE"].ToString();
                txtcomments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();
                txtcnb.Text = ds.Tables[0].Rows[0]["VILL_TOT_CNB"].ToString();
                txtsng.Text = ds.Tables[0].Rows[0]["VILL_TOT_SNG"].ToString();
                txtothranml.Text = ds.Tables[0].Rows[0]["TOT_OTHR_ANML"].ToString();
                txtvalagri.Text = ds.Tables[0].Rows[0]["VILL_VAL_AGRI"].ToString();
                txtvalres.Text = ds.Tables[0].Rows[0]["VILL_VAL_RES"].ToString();
                txtlang1.Text = ds.Tables[0].Rows[0]["VILL_LNG1"].ToString();
                txtlong1.Text = ds.Tables[0].Rows[0]["VILL_LONG1"].ToString();
                string filename = ds.Tables[0].Rows[0]["FileNames"].ToString();
                if (filename != "")
                {
                    BtnDeleteAttachment.Visible = true;
                }
                else
                {
                    BtnDeleteAttachment.Visible = false;
                }
                hypfile.NavigateUrl = ResolveUrl("~/WriteReadData/" + ConfigurationManager.AppSettings["VILLAGE"] + "/") + filename;
                hypfile.Text = filename;
                ddlcorebufferstatus.SelectedValue = ds.Tables[0].Rows[0]["VILL_CR_BFFR_STS"].ToString();
                if (txtlang1.Text == null || txtlang1.Text == "")
                {
                    txtlang1.Text = null;
                }
                else
                {
                    txtlang1.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_LNG1"]).ToString();
                }

                if (txtlang2.Text == null || txtlang2.Text == "")
                {
                    txtlang2.Text = null;
                }
                else
                {
                    txtlang2.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_LNG2"]).ToString();
                }
                if (txtlang3.Text == null || txtlang3.Text == "")
                {

                    txtlang3.Text = null;
                }

                else
                {
                    txtlang3.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_LNG3"]).ToString();

                }

                if (txtlang4.Text == null || txtlang4.Text == "")
                {
                    txtlang4.Text = null;

                }
                else
                {
                    txtlang4.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_LNG4"]).ToString();

                }
                if (txtlong1.Text == null || txtlong1.Text == "")
                {
                    txtlong1.Text = null;

                }
                else
                {
                    txtlong1.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_LONG1"]).ToString();
                }
                if (txtlong2.Text == null || txtlong2.Text == "")
                {
                    txtlong2.Text = null;
                }
                else
                {
                    txtlong2.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_LONG2"]).ToString();
                }

                if (txtlong3.Text == null || txtlong3.Text == "")
                {
                    txtlong3.Text = null;
                }
                else
                {
                    txtlong3.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_LONG3"]).ToString();
                }

                if (txtlong4.Text == null || txtlong4.Text == "")
                {
                    txtlong4.Text = null;
                }
                else
                {
                    txtlong4.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_LONG4"]).ToString();
                }

                if (txtvalagri.Text == null || txtvalagri.Text == "")
                {
                    txtvalagri.Text = null;

                }
                else
                {
                    txtvalagri.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_VAL_AGRI"]).ToString();

                }

                if (txtvalres.Text == null || txtvalres.Text == "")
                {
                    txtvalres.Text = null;

                }
                else
                {
                    txtvalres.Text = Convert.ToDecimal(ds.Tables[0].Rows[0]["VILL_VAL_RES"]).ToString();


                }


                if (txtcnb.Text == null || txtcnb.Text == "")
                {
                    txtcnb.Text = null;

                }
                else
                {
                    txtcnb.Text = ds.Tables[0].Rows[0]["VILL_TOT_CNB"].ToString();

                }
                if (txtsng.Text == null || txtsng.Text == "")
                {
                    txtsng.Text = null;

                }
                else
                {
                    txtsng.Text = ds.Tables[0].Rows[0]["VILL_TOT_SNG"].ToString();

                }

                if (txtothranml.Text == null || txtothranml.Text == "")
                {
                    txtothranml.Text = null;
                }
                else
                {
                    txtothranml.Text = ds.Tables[0].Rows[0]["TOT_OTHR_ANML"].ToString();
                }

                ddlSelectDistrict.SelectedValue = ds.Tables[0].Rows[0]["DT_ID"].ToString();
                //  FillTehsil(ddlSelectDistrict.SelectedValue);
                FillTehsil();
                ddlselecttehsil.SelectedValue = ds.Tables[0].Rows[0]["TH_ID"].ToString();
                // FillGP(ddlselecttehsil.SelectedValue);
                FillGramPanchyat();
                ddlselectgp.SelectedValue = ds.Tables[0].Rows[0]["GP_ID"].ToString();


                txtlatmin1.Text = ds.Tables[0].Rows[0]["VILL_LNGMIN1"].ToString();
                txtlatmin2.Text = ds.Tables[0].Rows[0]["VILL_LNGMIN2"].ToString();
                txtlatmin3.Text = ds.Tables[0].Rows[0]["VILL_LNGMIN3"].ToString();
                txtlatmin4.Text = ds.Tables[0].Rows[0]["VILL_LNGMIN4"].ToString();

                txtlatsec1.Text = ds.Tables[0].Rows[0]["VILL_LNGSEC1"].ToString();
                txtlatsec2.Text = ds.Tables[0].Rows[0]["VILL_LNGSEC2"].ToString();
                txtlatsec3.Text = ds.Tables[0].Rows[0]["VILL_LNGSEC3"].ToString();
                txtlatsec4.Text = ds.Tables[0].Rows[0]["VILL_LNGSEC4"].ToString();

                txtlongmin1.Text = ds.Tables[0].Rows[0]["VILL_LONGMIN1"].ToString();
                txtlongmin2.Text = ds.Tables[0].Rows[0]["VILL_LONGMIN2"].ToString();
                txtlongmin3.Text = ds.Tables[0].Rows[0]["VILL_LONGMIN3"].ToString();
                txtlongmin4.Text = ds.Tables[0].Rows[0]["VILL_LONGMIN4"].ToString();


                txtlongsec1.Text = ds.Tables[0].Rows[0]["VILL_LONGSEC1"].ToString();
                txtlongsec2.Text = ds.Tables[0].Rows[0]["VILL_LONGSEC2"].ToString();
                txtlongsec3.Text = ds.Tables[0].Rows[0]["VILL_LONGSEC3"].ToString();
                txtlongsec4.Text = ds.Tables[0].Rows[0]["VILL_LONGSEC4"].ToString();

                StringBuilder sbn = new StringBuilder();
                if (ds.Tables[1].Rows.Count > 0)
                {

                    sbn.Append("<ul>");
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        string filenames = ds.Tables[1].Rows[i]["FilesName"].ToString();
                        sbn.Append("<li>");
                        sbn.Append("<a href='" + ResolveUrl("~/WriteReadData/VILLAGE/") + filenames + "' target='_blank'>" + filenames + "</a>");

                        sbn.Append("</li>");
                    }
                    sbn.Append("</ul>");
                }
                lblfile.Text = sbn.ToString();


            }

            else
            {

                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void ImgbtnBack_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ddlSelectState_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void ddlVillageLegalStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public bool ChkVillageIDExistORNOtInRelocationSiteDetailTable()
    {
        bool chk = false;
        try
        {

            DataSet ds1 = new DataSet();
            ds1 = null;
            //ChkVillageID
            ds1 = comDB_Obj.ChkVillageID(Convert.ToInt32(Request.QueryString["village_id"]));
            if (ds1.Tables[0].Rows.Count > 0)
            {
                chk = true;
            }
            else
            {

                chk = false;
                //return;
            }



        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        return chk;
    }
    protected void ddlVillageStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        LblstatusMsg.Text = "";
        if (ddlVillageStatus.SelectedValue == "1")
        {//village_id=30051&inid=0&vcode=0&vname=0
            if (Session["UserType"].ToString().Equals("4") || Session["UserType"].ToString().Equals("1"))
            {
                if (ChkVillageIDExistORNOtInRelocationSiteDetailTable() == false)
                {

                    Response.Redirect("~/AUTH/adminpanel/RELOCATIONSITE/Add_Site.aspx?VillageName=" + txtname.Text.Trim() + "&village_id=" + Request.QueryString["village_id"] + "&inid=" + Request.QueryString["inid"] + "&vcode=" + Request.QueryString["vcode"] + "&vname=" + Request.QueryString["vname"]);
                }
                else
                {
                    BtnRelocationSiteDetailsEdit.Visible = true;
                }
            }
            else
            {
                LblstatusMsg.Text = "Sorry,Relocated status will be updated by DFO members only.";
            }
        }
        else
        {
            BtnRelocationSiteDetailsEdit.Visible = false;
        }
        if (!ddlVillageStatus.SelectedValue.ToString().Equals("0"))
        {
            lblmsgvillstts.Text = "";
        }
    }
    protected void ddlSelectDistrict_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (!ddlSelectDistrict.SelectedItem.ToString().Equals("Select District"))
        {
            FillTehsil(ddlSelectDistrict.SelectedValue.ToString());
        }
        else
        {
            ddlselecttehsil.Items.Clear();
            ddlselectgp.Items.Clear();
        }
    }
    protected void ddlVillageLegalStatus_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddlVillageStatus_SelectedIndexChanged1(object sender, EventArgs e)
    {

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
            if (Session["UserType"].ToString().Equals("1"))
            {
                ds1 = comDB_Obj.GetDistrict(Convert.ToInt32(Session["NTCAStateID"]), 1);
            }
            else
            {
                ds1 = comDB_Obj.GetDistrict(Convert.ToInt32(Session["PermissionState"]), 1);
            }

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
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
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
    protected void ddlselectstate_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
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
    public void FillStates()
    {
        try
        {
            ddlselectstate.Items.Clear();
            DataSet ds = new DataSet();
            ds = comDB_Obj.FillStates_District_ReserveDB(null, null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();
                ListItem listforstate = new ListItem("Select State", "0");
                ddlselectstate.Items.Add(listforstate);

                list = com_Obj.FillDropDownList(ds, 0, "ST_NAME");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j]["ST_ID"].ToString());
                    ddlselectstate.Items.Add(li);
                    j++;


                }


                ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
                ddlSelectDistrict.Items.Add(new ListItem("No Record", "0"));
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));


            }
            else
            {

                ddlselectstate.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void FillReserve()
    {
        try
        {
            ddlselectreserve.Items.Clear();
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
                ddlselecttehsil.Items.Add(new ListItem("No Record", "0"));
                ddlselectgp.Items.Add(new ListItem("No Record", "0"));
            }
            else
            {

                ddlselectreserve.Items.Add(new ListItem("No Record", "0"));
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
    protected void ddlcorebufferstatus_SelectedIndexChanged(object sender, EventArgs e)
    {

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

                   // if (Page.IsValid)
                   // {

                        LblVpop.Text = "";
                       // try
                       // {
                            if (Page.IsValid)
                            {
                                if (Convert.ToDateTime(common.insertDate(txtsurdate.Text)) > DateTime.Now)
                                {
                                    lblMsg.Text = "Date of Survey Can Not Be Greater Than Today's Date";
                                    return;
                                }
                                if (ddlselectstate.SelectedValue.ToString().Equals("0"))
                                {
                                    lblmsgstate.Text = WebConstant.UserFriendlyMessages.selectstatename;
                                    lblmsgstate.ForeColor = System.Drawing.Color.Red;
                                    return;

                                }

                                else if (ddlselectreserve.SelectedValue.ToString().Equals("0"))
                                {

                                    lblmsgreserve.Text = WebConstant.UserFriendlyMessages.selectReservename;
                                    lblmsgreserve.ForeColor = System.Drawing.Color.Red;
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
                                string districtid = ddlSelectDistrict.SelectedValue.ToString();
                                string tehsilid = ddlselecttehsil.SelectedValue.ToString();
                                string gpid = ddlselectgp.SelectedValue.ToString();
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
                                //VillEntity_Obj._VILL_CUT_DT = Convert.ToDateTime(common.insertDate(txtcutdate.Text));

                                if (txtotherland.Text == "")
                                {
                                    VillEntity_Obj._VILL_OTHER_LND_AREA = 0;
                                }
                                else
                                {
                                    VillEntity_Obj._VILL_OTHER_LND_AREA = Convert.ToDecimal(txtotherland.Text);
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

                                    // lblMsg.Text = "Total Numbers of(SC's,OBC's,ST's and others) must be equal to (Total of Male Population+Total Female Population)";
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
                                //if (VillEntity_Obj._VILL_TOT_CNB + VillEntity_Obj._VILL_TOT_SNG + VillEntity_Obj._TOT_OTHR_ANML != VillEntity_Obj._VILL_NO_LIV_STOK)
                                //{

                                //    lblMsg.Text = "Total of(Cow & Buffalo,Sheep & Goat and Other Animal) must be equal to Total Livestocks";
                                //    lblMsg.ForeColor = System.Drawing.Color.Red;
                                //    return;
                                //}
                                VillEntity_Obj._VILL_POPU = total;

                                //naren2june update2018
                                VillEntity_Obj.DateMeeting = Convert.ToDateTime(common.insertDate(TxtDateMeeting.Text.Trim()));
                                VillEntity_Obj.CuttOffDate = Convert.ToDateTime(common.insertDate(TxtCuttOffDate.Text.Trim()));
                                VillEntity_Obj.NoAdult = Convert.ToInt32(Txtadult.Text.Trim());
                                VillEntity_Obj.NoTransGender = Convert.ToInt32(TxtnoTransgender.Text.Trim());
                                VillEntity_Obj.NoCows = Convert.ToInt32(TxtNoCow.Text.Trim());
                                VillEntity_Obj.NoBuffalo = Convert.ToInt32(TxtBuffalo.Text.Trim());
                                VillEntity_Obj.NoSheep = Convert.ToInt32(TxtSheep.Text.Trim());
                                VillEntity_Obj.NoGoat = Convert.ToInt32(TxtGoat.Text.Trim());

                                DataTable fileUpload = new DataTable();
                                DataSet dSet = new DataSet();
                                fileUpload.Columns.Add("FileName", typeof(string));
                                p_Var.url = ResolveUrl("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/VILLAGE" + "/";
                                for (int i = 0; i < Request.Files.Count; i++)
                                {
                                    string date = System.DateTime.Now.ToString("yyyymmss");



                                    HttpPostedFile PostedFile = Request.Files[i];
                                    string FileName = "";
                                    if (PostedFile.ContentLength > 0)
                                    {
                                        DataRow dr = fileUpload.NewRow();
                                        FileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                        PostedFile.SaveAs(Server.MapPath(p_Var.url) + System.DateTime.Now.ToString("yyyymmss") + FileName);
                                        dr["FileName"] = System.DateTime.Now.ToString("yyyymmss") + FileName;
                                        fileUpload.Rows.Add(dr);
                                    }

                                }

                                VillEntity_Obj.filenames = fileUpload;
                                VillEntity_Obj.UserID = Convert.ToInt32(Session["User_Id"]);
                                VillEntity_Obj._VILL_ID = Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString();
                                VillEntity_Obj.Latitude = TxtLatitude.Text.Trim();
                                VillEntity_Obj.Longitude = TxtLongitude.Text.Trim();
                                check = VillDB_Obj.UpdateVillageDB(VillEntity_Obj, stateid, reserveid, districtid, tehsilid, gpid);
                                //Check if this village has been relocated but now you select status other like non,in progress then delete this village id record in relocation site details
                                if (ddlVillageStatus.SelectedValue != "1")
                                {
                                    bool chk = VillDB_Obj.CheckAndDeleteRelocationSite(VillEntity_Obj);
                                }
                                if (check == true)
                                {
                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 2);


                                    //ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                                    //("showmessage", "<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");

                                    // Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/VILLAGE/Village_Management.aspx"), false);
                                    ////lblMsg.Text = WebConstant.UserFriendlyMessages.VillageUpdateSuccess;
                                    ////lblMsg.ForeColor = System.Drawing.Color.Green;

                                    Session["msg"] = "Your changes have been saved.";
                                    Session["BackUrl"] = "~/Auth/AdminPanel/Village/Village_Management.aspx";
                                    Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
                                }
                                else
                                {
                                    //lblMsg.Text = "error in line number 508";
                                    ////lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                    //lblMsg.ForeColor = System.Drawing.Color.Red;

                                }


                            }
                            else
                            {
                                //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                lblMsg.Text = "error in line number 521";
                                lblMsg.ForeColor = System.Drawing.Color.Red;


                            }
                        //}
                        //catch (Exception e3)
                        //{
                        //    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e3.Message.ToString();
                        //}
                    //}
                }
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
        Load_Village_Info();
    }
    protected void ImgbtnBack_Click1(object sender, EventArgs e)
    {
        if (Session["UserType"].ToString().Equals("3") || Session["UserType"].ToString().Equals("2")|| Session["UserType"].ToString().Equals("1"))
        {
            Response.Redirect(ResolveUrl("~/AUTH/adminpanel/VILLAGE/Village_Management.aspx"));
        }
        else
        {
            if (Request.QueryString["viewid"] == null)
            {
                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/VILLAGE/Village_Management.aspx?pindex=" + Request.QueryString["inid"].ToString() + "&vcode=" + Request.QueryString["vcode"].ToString() + "&vname=" + Request.QueryString["vname"].ToString()));
            }
            else
            {
                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/VILLAGE/Village_Management.aspx?pindex=" + Request.QueryString["inid"].ToString() + "&vcode=" + Request.QueryString["vcode"].ToString() + "&vname=" + Request.QueryString["vname"].ToString() + "&viewid=" + Request.QueryString["viewid"].ToString()));

            }
        }
    }
    protected void txtcode_TextChanged(object sender, EventArgs e)
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
    protected void BtnDeleteAttachment_Click(object sender, EventArgs e)
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
                            VillEntity_Obj._VILL_ID = Request.QueryString["village_id"].ToString();
                            VillEntity_Obj.Action = 1;
                            check = VillDB_Obj.AttachmentDelete(VillEntity_Obj);

                            if (check == true)
                            {
                                Load_Village_Info();
                                Response.Write("<script>alert('Attachment has deleted successfully!');</script>");
                            }
                        //}
                        //catch (Exception er)
                        //{
                        //    throw;
                        //}
                    }
                }//}
            }
        }
        catch
        {
            throw;
        }
        // }
    }
    protected void BtnRelocationSiteDetailsEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/RelocationSite/Relocation_Management.aspx?VillageName=" + txtname.Text.Trim() + "&village_id=" + Request.QueryString["village_id"] + "&inid=" + Request.QueryString["inid"] + "&vcode=" + Request.QueryString["vcode"] + "&vname=" + Request.QueryString["vname"]);
    }
}