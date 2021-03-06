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
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_RelocationSite_Relocation_Site_Report : CrsfBase
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
        if (string.IsNullOrEmpty(Convert.ToString(Session["User_Id"])))
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
            return;
        }
       
        if (!IsPostBack)
        {
            btnexporttoexel.Visible = false;
            btnprint.Visible = false;
            t1.Visible = false;

            if (Session["UserType"].ToString() == "1")
            {
                BindStateName();
                BindTigerReserveName1();
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                if (Request.QueryString["vid"] != null)
                {
                    ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    BindVillages();
                }
                else
                {
                    BtnPdfExport.Visible = false;
                }
                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {
                    BtnBackConsoldateReport.Visible = true;
                }
                else
                {
                    BtnBackConsoldateReport.Visible = false;
                }
                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {//Request.QueryString["ConsoldateStateName"].ToString();
                    DdlStateName.SelectedValue = Request.QueryString["ConsoldateStateName"].ToString();
                    DdlStateName_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else
                {

                }
            }
            if (Session["UserType"].ToString() == "2")
            {
                Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                if (Request.QueryString["vid"] != null)
                {
                    ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    BindVillages();
                }
                else
                {
                    BtnPdfExport.Visible = false;
                }
            }
            if (Session["UserType"].ToString() == "3")
            {
                Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                if (Request.QueryString["vid"] != null)
                {
                    ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    BindVillages();
                }
                else
                {
                    BtnPdfExport.Visible = false;
                }
            }
            if (Session["UserType"].ToString() == "4")
            {
                Fill_VillageCode_And_Name(Convert.ToInt32(Session["User_Id"]));
                //BindVillages();
                if (Request.QueryString["vid"] != null)
                {
                    ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    BindVillages();
                }
                else
                {
                    BtnPdfExport.Visible = false;
                }
               
            }
            //-------------------
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
            ddlselectname.DataSource = P_var.dSet.Tables[2];
            ddlselectname.DataTextField = "VILL_NM";
            ddlselectname.DataValueField = "VILL_ID";
            ddlselectname.DataBind();
            ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }
        else
        {
            ddlselectname.Items.Clear();
            ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("No Record", "0"));
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
            ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select tiger reserve-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName1Modified(StateName);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select tiger reserve-", "0"));
            }

            else
            {
                ddlselectreserve.Items.Clear();
                ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
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

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name1(CmnStateUserID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                List<string> list1 = new List<string>();

                System.Web.UI.WebControls.ListItem li2 = new System.Web.UI.WebControls.ListItem("Select Name", "0");

                ddlselectname.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    System.Web.UI.WebControls.ListItem liforname = new System.Web.UI.WebControls.ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                // ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
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

                System.Web.UI.WebControls.ListItem li2 = new System.Web.UI.WebControls.ListItem("Select Name", "0");

                ddlselectname.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    System.Web.UI.WebControls.ListItem liforname = new System.Web.UI.WebControls.ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][3].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlselectname.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
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

                System.Web.UI.WebControls.ListItem li2 = new System.Web.UI.WebControls.ListItem("Select Name", "0");

                ddlselectname.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    System.Web.UI.WebControls.ListItem liforname = new System.Web.UI.WebControls.ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {

                ddlselectname.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
                //ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvforVillages.PageIndex = e.NewPageIndex;

           // BindVillages();
            if (Session["UserType"].ToString() == "1")
            {
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                if (Request.QueryString["vid"] != null)
                {
                  //  ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    
                    BindVillages();
                }
            }
            if (Session["UserType"].ToString() == "2")
            {
                Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                if (Request.QueryString["vid"] != null)
                {
                  //  ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    BindVillages();
                }
            }
            if (Session["UserType"].ToString() == "3")
            {
                Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                if (Request.QueryString["vid"] != null)
                {
                  //  ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    BindVillages();
                }
            }
            if (Session["UserType"].ToString() == "4")
            {
                Fill_VillageCode_And_Name(Convert.ToInt32(Session["User_Id"]));
                //BindVillages();
                if (Request.QueryString["vid"] != null)
                {
                    //ddlselectname.SelectedValue = Request.QueryString["vid"].ToString();
                    BindVillages();
                }

            }

        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void BindVillages()
    {
        DataSet ds = new DataSet();
        try
        {
           
            if (ddlselectreserve.SelectedValue == "0" && ddlselectname.SelectedValue == "0")
            {
                if (Session["UserType"].ToString() == "1")
                {

                    RELO_ENT_Obj._VILL_ID = null;
                    RELO_ENT_Obj.TigerReserveName = null;
                    ds = RELODB_Obj.relocation_site_reportNew(RELO_ENT_Obj);
                }
            }
            else
            {
                if (Session["UserType"].ToString() == "1")
                {
                    RELO_ENT_Obj._VILL_ID = ddlselectname.SelectedValue.ToString();
                    RELO_ENT_Obj.TigerReserveName = ddlselectreserve.SelectedValue;
                    ds = RELODB_Obj.relocation_site_reportNew(RELO_ENT_Obj);
                }
            }
            if (Session["UserType"].ToString() == "4" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
            {
                if (ddlselectname.SelectedValue!= "0")
                {
                    RELO_ENT_Obj._VILL_ID = ddlselectname.SelectedValue.ToString();
                    //RELO_ENT_Obj.TigerReserveName = ddlselectreserve.SelectedItem.Text;
                    ds = RELODB_Obj.relocation_site_reportNew(RELO_ENT_Obj);
                }
                else
                {//relocation_site_reportNew
                    //relocation_site_report
                    ds = RELODB_Obj.relocation_site_reportNew(RELO_ENT_Obj);
                }
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds.Tables[0];
                gvforVillages.DataBind();
                t1.Visible = true;
                btnexporttoexel.Visible = true;
                btnprint.Visible = true;
                lblMsg.Text = "";
                BtnPdfExport.Visible = true;

                btnprint.Visible = true;
                    btnexporttoexel.Visible = true;
                    BtnPdfExport.Visible = true;
            }
            else
            {
                btnprint.Visible = false;
                btnexporttoexel.Visible = false;
                BtnPdfExport.Visible = false;

                BtnPdfExport.Visible = false;
                btnexporttoexel.Visible = false;
                btnprint.Visible = false;
                gvforVillages.Visible = false;
                t1.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

            //if (ddlselectname.SelectedValue.ToString().Equals("0"))
            //{
            //    RELO_ENT_Obj._VILL_ID = null;
            //    ds = RELODB_Obj.relocation_site_report(RELO_ENT_Obj);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        gvforVillages.Visible = true;
            //        gvforVillages.DataSource = ds.Tables[0];
            //        gvforVillages.DataBind();
            //        t1.Visible = true;
            //        btnexporttoexel.Visible = true;
            //        btnprint.Visible = true;
            //        lblMsg.Text = "";
            //    }
            //    else
            //    {

            //        gvforVillages.Visible = false;
            //        t1.Visible = false;
            //        btnexporttoexel.Visible = false;
            //        btnprint.Visible = false;
            //        lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
            //        lblMsg.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
            //else
            //{
            //    //RELO_ENT_Obj._ST_NM = ddlselectstate.SelectedValue.ToString();
                
            //    RELO_ENT_Obj._VILL_ID = ddlselectname.SelectedValue.ToString();
            //    RELO_ENT_Obj.TigerReserveName = ddlselectreserve.SelectedItem.Text;
            //    ds = RELODB_Obj.relocation_site_report(RELO_ENT_Obj);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        gvforVillages.Visible = true;
            //        gvforVillages.DataSource = ds.Tables[0];
            //        gvforVillages.DataBind();
            //        t1.Visible = true;
            //        btnexporttoexel.Visible = true;
            //        btnprint.Visible = true;
            //        lblMsg.Text = "";
            //    }
            //    else
            //    {
            //        btnexporttoexel.Visible = false;
            //        btnprint.Visible = false;
            //        gvforVillages.Visible = false;
            //        t1.Visible = false;
            //        lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
            //        lblMsg.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
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

                System.Web.UI.WebControls.ListItem li2 = new System.Web.UI.WebControls.ListItem("Select Name", "0");

                ddlselectname.Items.Add(li2);

                list1 = com_Obj.FillDropDownList(ds, 0, "VILL_NM");

                int i1 = list1.Count - 1;
                int j = 0;


                while (j <= i1)
                {
                    System.Web.UI.WebControls.ListItem liforname = new System.Web.UI.WebControls.ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
                    ddlselectname.Items.Add(liforname);
                    ++j;
                }

            }
            else
            {


                ddlselectname.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
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
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVillages();
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        VillageName();
    }
    protected void btnexporttoexel_Click(object sender, EventArgs e)
    {
        gvforVillages.AllowPaging = false;
        btnexporttoexel.Visible = false;
        btnprint.Visible = false;
        BindVillages();

        Realocation_AreaDB.ExportToExcel(ref panel, "Relocation site");
        gvforVillages.AllowPaging = true;
        BindVillages();
        btnexporttoexel.Visible = true;
        btnprint.Visible = true;
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        gvforVillages.AllowPaging = false;
        BindVillages();
        btnexporttoexel.Visible = false;
        btnprint.Visible = false;
        printGrid();
        gvforVillages.AllowPaging = true;
        BindVillages();
        btnexporttoexel.Visible = true;
        btnprint.Visible = true;

    }
    void printGrid()
    {
        // GridViewgv_villageSearch = new GridView();
        gvforVillages.AllowPaging = false;

        BindVillages();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        panel.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());

        //     gv_villageSearch1.DataBind();


    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void ddlselectname_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //gvforVillages.AllowPaging = false;
        //btnexporttoexel.Visible = false;
        //btnprint.Visible = false;
        //BindVillages();
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

                        gvforVillages.AllowPaging = false;
                        btnexporttoexel.Visible = false;
                        btnprint.Visible = false;
                        BindVillages();
                    }
                }
            }
            //}
        }
        catch
        {
            throw;
        }
        // }
    }
    protected void BtnPdfExport_Click(object sender, EventArgs e)
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

                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=MIS_Report.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        hw.WriteLine("<h1 style=\"text-align:center;\">Relocation Site Report</h1>");
                        hw.WriteLine("<br>");

                        // gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
                        gvforVillages.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        gvforVillages.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        gvforVillages.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
                        gvforVillages.AllowPaging = true;
                        gvforVillages.DataBind();

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
    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsoldateReport.aspx");
    }
}