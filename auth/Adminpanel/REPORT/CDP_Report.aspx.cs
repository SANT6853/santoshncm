using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_CDP_Report : CrsfBase
{
    public string Village_id = "";
    DataSet ds = new DataSet();
    FamilyDB obj = new FamilyDB();
    CommonDB comDB_Obj = new CommonDB();
    common com_Obj = new common();
    VillageDB VillDB_Obj = new VillageDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "CDP REPORT : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }


        lblMsg.Text = "";

        if (!Page.IsPostBack)
        {
            
            if (Session["UserType"].ToString() == "1")
            {
                BindStateName();
                BindTigerReserveName1();
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                btn_print.Visible = false;
               
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
                    Bind();
                }
                else
                {
                    Bind();
                }
            }
            if (Session["UserType"].ToString() == "2")
            {
                Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                btn_print.Visible = false;
                Bind();
            }
            if (Session["UserType"].ToString() == "3")
            {
                Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                btn_print.Visible = false;
                Bind();
            }
            if (Session["UserType"].ToString() == "4")
            {
               
                FillVillage();
                btn_print.Visible = false;
                Bind();
            }

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
                    System.Web.UI.WebControls.ListItem liforname = new System.Web.UI.WebControls.ListItem(list1[j].ToString(), ds.Tables[0].Rows[j][2].ToString());
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
    protected void Bind()
    {
        if (ddlselectname.SelectedValue != "0" && ddlselectreserve.SelectedValue != "0")
        {
            if (Session["UserType"].ToString() == "1")
            {
                ds = obj.Proc_Display_CDPINFO(ddlselectname.SelectedValue, ddlselectreserve.SelectedItem.Text);
            }
            if (Session["UserType"].ToString() == "4" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
            {
                string vill_id = ddlselectname.SelectedValue.ToString();
                ds = obj.Proc_Display_CDPINFO(vill_id, null);
            }
        }
        else
        {
            if (ddlselectname.SelectedValue != "0")
            {
                string vill_id = ddlselectname.SelectedValue.ToString();
                ds = obj.Proc_Display_CDPINFO(vill_id, null);
            }

            if (ddlselectreserve.SelectedValue != "0")
            {
                if (Session["UserType"].ToString() == "1")
                {
                    ds = obj.Proc_Display_CDPINFO(null, ddlselectreserve.SelectedItem.Text);
                }
            }

            if (ddlselectname.SelectedValue == "0" && ddlselectreserve.SelectedValue == "0")
            {
                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {
                    ds = obj.Proc_Display_CDPINFOCdReport(null, null,DdlStateName.SelectedValue);
                }
                else
                {
                    ds = obj.Proc_Display_CDPINFO(null, null);
                }
            }
            if (Session["UserType"].ToString() == "4" || Session["UserType"].ToString() == "3" || Session["UserType"].ToString() == "2")
            {
                if (ddlselectname.SelectedValue != "0")
                {
                    string vill_id = ddlselectname.SelectedValue.ToString();
                    ds = obj.Proc_Display_CDPINFO(vill_id, null);
                }
                else
                {
                    if (Session["UserType"].ToString() == "4")
                    {
                        ds = obj.Proc_Display_CDPINFO(null, Session["sTigerReserveName"].ToString());
                    }

                }
            }
        }
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                line.Visible = true;
                btn_print.Visible = true;
                gvwork.Visible = true;
                gvwork.DataSource = ds.Tables[0];
                ViewState["Data"] = ds;
                gvwork.DataBind();
                Label1.Text = "Total Amount Allotted :";
                Label2.Text = "";
                lblamttotal.Text = ds.Tables[1].Rows[0]["CDP_ALLTD_AMT"].ToString();
                double amountused = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    amountused = amountused + Convert.ToDouble(ds.Tables[0].Rows[i]["CDP_AMT_USD"]);

                }
                lblamtused.Text = "Total Amount Used :" + amountused.ToString();

                GridveiwNumericColumnCalculation(ds);
                BtnExcelExport.Visible = true;

                BtnExcelExport.Visible = true;
                BtnPdfExport.Visible = true;
                btn_print.Visible = true;
            }
            else
            {//gvwork.Visible = true;
                BtnExcelExport.Visible = false;
                BtnPdfExport.Visible = false;
                btn_print.Visible = false;

                BtnExcelExport.Visible = false;
                btn_print.Visible = false;
                gvwork.Visible = false;
                Label1.Text = "";
                Label2.Text = "";
                lblamttotal.Text = "";
                line.Visible = false;
                lblamtused.Text = "";
                lblMsg.Text = "No Record Found";

                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            BtnExcelExport.Visible = false;
            BtnPdfExport.Visible = false;
            btn_print.Visible = false;
            gvwork.Visible = false;
            lblMsg.Text = "No Record Found";

            lblMsg.ForeColor = System.Drawing.Color.Red;
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
            ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName1Modified(StateName);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select-", "0"));
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
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {

        Bind();
        VillageName();
    }
    public void FillVillage()
    {

        try
        {


            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = comDB_Obj.Fill_Villlage_Name_By_Reserve_ID();

            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();
                System.Web.UI.WebControls.ListItem listforreserve = new System.Web.UI.WebControls.ListItem("Select Village", "0");
                ddlselectname.Items.Add(listforreserve);
                list = com_Obj.FillDropDownList(ds, 0, "VILL_NM");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem(list[j].ToString(), ds.Tables[0].Rows[j][0].ToString());
                    ddlselectname.Items.Add(li);
                    j++;

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
                
           

    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind();
    }  
    protected void gvwork_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvwork.PageIndex = e.NewPageIndex;
        Bind();
    }
    public void GridveiwNumericColumnCalculation(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        decimal InstallmentAmountRs = 0;
        //int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["CDP_ALLTD_AMT"]);
            InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["CDP_AMT_USD"]);
            // FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        gvwork.FooterRow.Cells[0].Text = "";
        gvwork.FooterRow.Cells[0].Font.Bold = true;
        gvwork.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gvwork.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gvwork.FooterRow.Cells[4].Text = Total + AllottedAmountRs.ToString();
        gvwork.FooterRow.Cells[4].Font.Bold = true;
        gvwork.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        gvwork.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        gvwork.FooterRow.Cells[5].Text = Total + InstallmentAmountRs.ToString();
        gvwork.FooterRow.Cells[5].Font.Bold = true;
        gvwork.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gvwork.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember

    }
    #region[Start Export section]   
    protected void btn_print_Click(object sender, EventArgs e)
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

                        // btn_print.Attributes.Add("Onclick", "getPrint('print_area');");
                        printGrid();
                        if (Session["UserType"].ToString() == "1")
                        {
                            BindTigerReserveName1();
                            Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                            btn_print.Visible = false;
                            Bind();
                        }
                        if (Session["UserType"].ToString() == "2")
                        {
                            Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                            btn_print.Visible = false;
                            Bind();
                        }
                        if (Session["UserType"].ToString() == "3")
                        {
                            Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                            btn_print.Visible = false;
                            Bind();
                        }
                        if (Session["UserType"].ToString() == "4")
                        {

                            FillVillage();
                            btn_print.Visible = false;
                            Bind();
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
    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gvwork.DataSource = ViewState["Data"];
        gvwork.AllowPaging = false;
        gvwork.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculation(Ds);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvwork.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" CDP Report for a Village ");
        sb.Append("</font></div>");
        sb.Append(gridHTML);
        sb.Append("<div>");
        //  sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Label1.Text + "&nbsp; &nbsp;");
        //  sb.Append("<strong>" + lblamttotal.Text + "</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
        // sb.Append(Label2.Text + "&nbsp; &nbsp;");
        // sb.Append("<strong>" + lblamtused.Text + "</strong>");


        sb.Append("</div>");
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gvwork.AllowPaging = true;
        gvwork.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void BtnExcelExport_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            hw.WriteLine("<h1 style=\"text-align:center;\">Progress of work as per Community Development Program(Option II)</h1>");
            hw.WriteLine("<br>");
            //To Export all pages

            gvwork.AllowPaging = false;
            Bind();
            gvwork.HeaderRow.BackColor = System.Drawing.Color.Black;
            foreach (TableCell cell in gvwork.HeaderRow.Cells)
            {
                cell.BackColor = gvwork.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in gvwork.Rows)
            {
                row.BackColor = System.Drawing.Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = gvwork.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = gvwork.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }

            gvwork.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
    protected void BtnPdfExport_Click(object sender, EventArgs e)
    {

        //  Response.ContentType = "application/pdf";
        //  Response.AddHeader("content-disposition", "attachment;filename=Village-Wise Report.pdf");
        //  Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //  StringWriter sw = new StringWriter();
        //  HtmlTextWriter hw = new HtmlTextWriter(sw);

        //  hw.WriteLine("<h1 style=\"text-align:center;\">Village-Wise Report</h1>");
        //  hw.WriteLine("<br>");

        //  gvwork.HeaderStyle.ForeColor = System.Drawing.Color.White;
        //  gvwork.HeaderStyle.BackColor = System.Drawing.Color.Green;
        //  gvwork.RenderControl(hw);
        //  StringReader sr = new StringReader(sw.ToString());
        //  Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
        //  HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //  PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //  pdfDoc.Open();
        //  htmlparser.Parse(sr);
        //  pdfDoc.Close();
        //  Response.Write(pdfDoc);
        ////  gvwork.AllowPaging = true;
        //  Response.End();
        //  gvwork.AllowPaging = true;

        //  gvwork.DataBind();
        //  gvwork.Visible = false;
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            {
                hw.WriteLine("<h1 style=\"text-align:center;\">Village-Wise Report</h1>");
                hw.WriteLine("<br>");
                //To Export all pages
                gvwork.AllowPaging = false;
                //  this.BindGrid();
                if (Session["UserType"].ToString() == "1")
                {
                    //  BindStateName();
                    //  BindTigerReserveName1();
                    // Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                    // btn_print.Visible = false;
                    this.Bind();
                }
                if (Session["UserType"].ToString() == "2")
                {
                    // Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                    // btn_print.Visible = false;
                    this.Bind();
                }
                if (Session["UserType"].ToString() == "3")
                {
                    // Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                    // btn_print.Visible = false;
                    this.Bind();
                }
                if (Session["UserType"].ToString() == "4")
                {

                    ///  FillVillage();
                    //  btn_print.Visible = false;
                    this.Bind();
                }
                gvwork.HeaderStyle.ForeColor = System.Drawing.Color.White;
                gvwork.HeaderStyle.BackColor = System.Drawing.Color.Green;
                gvwork.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Village-Wise Report.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
        }
    }
    #endregion[End Export section]
   
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName1();
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