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
using System.Text;
using System.IO;
using System.Collections.Generic;

public partial class ReportsGP : System.Web.UI.Page
{
    VillageDB VillDB_Obj = new VillageDB();
    relocationprogress del = new relocationprogress();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    ReserveDB RDb = new ReserveDB();

    decimal grdTotal = 0, allotedamount = 0;
    int i = 0;
    FamilyDB FMLYDB_Obj = new FamilyDB();
   // common com_Obj = new common();
   // CommonDB comDB_Obj = new CommonDB();
   // VillageDB VillDB_Obj = new VillageDB();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        lblnodatafound.Text = "";
      
        if (!IsPostBack)
        {
            Page.Title = "Reports:NTCA";
            BindTigerReserveName1();
            VillProgresss.Visible = false;
            GrdNumberOfVillages.Visible = false;
            OptionWise.Visible = false;
           // bindgrid();
           //if (Session["UserType"].ToString().Equals("4"))
           //{
           //    Page.Title = "VILLAGES REPORT :" + Session["sTigerReserveName"].ToString();

            //}
            //if (Session["UserType"].ToString().Equals("3"))
            //{
            //    Page.Title = "VILLAGES REPORT :NTCA";
            //    displayVillage3();
            //}

        }
    }
    public void BindfamilyByOptions()
    {

        try
        {
            string vil_id = ddlselectname.SelectedValue.ToString();
            string sch_id = ddlselectscheme.SelectedValue.ToString();
          //  string res_id = Request.QueryString["R_ID"].ToString();
            ds = VillDB_Obj.Proc_DisplayFamilyByVillageSchme(vil_id,null, sch_id,null,null);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTotal = 0; allotedamount = 0; i = 0;
                BtnPrintOption.Visible = true;
                gvForFamily.Visible = true;
                gvForFamily.AllowPaging = true;
                gvForFamily.DataSource = ds.Tables[0].DefaultView;
                ViewState["Data"] = ds;
             // grandtotalnew.Text = ds.Tables[0].Rows[0]["grandtotol"].ToString();
                gvForFamily.DataBind();
            }
            else
            {

                gvForFamily.Visible = false;
              //  lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
              //  lblMsg.ForeColor = System.Drawing.Color.Red;
                BtnPrintOption.Visible = false;
            }
        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
           // lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    void BindTigerReserveName1()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveNameRPG(Convert.ToInt32(Request.QueryString["StateID"]));
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
    public void displayVillage()
    {
        string sTigerReserveName = string.Empty;
        string catType = string.Empty;
        // string res_id = Request.QueryString["RSRV_ID"].ToString();
        if(ddlselectreserve.SelectedItem.Text=="-Select-")
        {
            sTigerReserveName = null;
        }
        else
        {
            sTigerReserveName = ddlselectreserve.SelectedItem.Text;
        }
        if (DdlCat.SelectedItem.Text == "-Select-")
        {
            catType = null;
        }
        else
        {
            catType = DdlCat.SelectedValue;
        }

        DataSet ds = RDb.Proc_VillageSearchByReserveRGP(sTigerReserveName, catType,null,null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
           // Label1.Text = "State Name";
           // Label2.Text = ds.Tables[1].Rows[0][1].ToString();
           // Label3.Text = "Tiger Reserve Name";
           // Label4.Text = ds.Tables[1].Rows[0][0].ToString();
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            gv_villageSearch.Columns[17].Visible = false;

        }
        else
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            btn_print.Visible = false;

            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    public void displayVillage3()
    {
        // string res_id = Request.QueryString["RSRV_ID"].ToString();

        DataSet ds = RDb.Proc_VillageSearchByReserve3(null,null,null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            // Label1.Text = "State Name";
            // Label2.Text = ds.Tables[1].Rows[0][1].ToString();
            // Label3.Text = "Tiger Reserve Name";
            // Label4.Text = ds.Tables[1].Rows[0][0].ToString();
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            gv_villageSearch.Columns[17].Visible = false;

        }
        else
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            btn_print.Visible = false;

            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    protected void gv_villageSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["UserType"].ToString().Equals("3"))
        {
            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage3();
        }
        if (Session["UserType"].ToString().Equals("4"))
        {
            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage();
        }
    }
    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gv_villageSearch.DataSource = ViewState["Data"];
        gv_villageSearch.AllowPaging = false;
        gv_villageSearch.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gv_villageSearch.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Sariska Tiger Reserve Village Relocation Program at a Glance ");
        sb.Append("</font></div>");
        sb.Append("<div style='text-align:center'> ");
        sb.Append(Label1.Text + "&nbsp;:&nbsp;" + Label2.Text + "&nbsp;|&nbsp;" + Label3.Text + "&nbsp;:&nbsp;" + Label4.Text);
        sb.Append("</div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gv_villageSearch.AllowPaging = true;
        gv_villageSearch.DataBind();
    }
    protected void btn_print_Click1(object sender, EventArgs e)
    {
        this.printGrid();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("VillageSearch.aspx");
    }
    protected void gv_villageSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hidden1 = e.Row.FindControl("villid") as HiddenField;
            HyperLink hyper = e.Row.FindControl("hyperngo") as HyperLink;
            HyperLink hyper1a = e.Row.FindControl("hyperngo1a") as HyperLink;
            if (hyper.Text.Equals("0"))
            {
                hyper.NavigateUrl = "#";
                hyper.Attributes.Add("target", "");
                hyper.Text = "NA";
            }
            else
            {
                hyper.NavigateUrl = ResolveUrl("~/ReportGP/View_NGO_Details.aspx?V_ID= " + hidden1.Value + " ");
                hyper.Attributes.Add("target", "_blank");
            }
            if (hyper1a.Text.Equals("0"))
            {
                hyper1a.NavigateUrl = "#";
                hyper1a.Attributes.Add("target", "");
                hyper1a.Text = "No Record";
            }
            else
            {

                hyper1a.NavigateUrl = ResolveUrl("~/ReportGP/View_NGO_1A_VillWise.aspx?V_ID= " + hidden1.Value + " ");
                hyper1a.Attributes.Add("target", "_blank");
            }
        }
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (DdlCat.SelectedValue == "1")
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            //--------------
            GVSurvey_Details.Visible = false;
            btnprint.Visible = false;

            displayVillage();
        }
       
        if (DdlCat.SelectedValue == "22")
        {
            GVSurvey_Details.Visible=true;
            btnprint.Visible = true;
            //------------
            btn_print.Visible = false;
            gv_villageSearch.Visible = false;

            bindgrid();
        }
       
       
    }
    public void bindgrid()
    {
        string sTigerReserveName = string.Empty;
        
        // string res_id = Request.QueryString["RSRV_ID"].ToString();
        if (ddlselectreserve.SelectedItem.Text == "-Select-")
        {
            sTigerReserveName = null;
        }
        else
        {
            sTigerReserveName = ddlselectreserve.SelectedItem.Text;
        }

        DataSet ds = del.SelectRecordForeGridRGP(sTigerReserveName,null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GVSurvey_Details.Visible = true;
            GVSurvey_Details.DataSource = ds;
            ViewState["Data"] = ds;
            GVSurvey_Details.DataBind();
           btnprint.Visible = true;
          //  btnexporet.Visible = true;
        }
        else
        {
            GVSurvey_Details.DataSource = null;
            GVSurvey_Details.DataBind();
           // btnexporet.Visible = false;
           btnprint.Visible = false;
        }

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        printGrid1();
    }
    void printGrid1()
    {

        GVSurvey_Details.DataSource = ViewState["Data"];
        GVSurvey_Details.AllowPaging = false;
        GVSurvey_Details.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GVSurvey_Details.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Sariska Tiger Reserve Report ");
        sb.Append("</font></div>");
        sb.Append("<div style='text-align:center'> ");
        //sb.Append(Label1.Text + "&nbsp;:&nbsp;" + Label2.Text + "&nbsp;|&nbsp;" + Label3.Text + "&nbsp;:&nbsp;" + Label4.Text);
        sb.Append("</div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        GVSurvey_Details.AllowPaging = true;
        GVSurvey_Details.DataBind();
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVSurvey_Details.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void DdlCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlCat.SelectedValue == "33")
        {
            BtnCancel.Visible = true;
            DvOpt.Visible = true;
            DVCat.Visible = false;
            DVTr.Visible = true;//-----------
            Fill_VillageCode_And_Name();
            BtnSearch.Visible = false;
            GrdNumberOfVillages.Visible = false;
            VillProgresss.Visible = false;
            btn_print.Visible = false;
            btnprint.Visible = false;
        }
        else
        {
            GrdNumberOfVillages.Visible = true;
            VillProgresss.Visible = true;
            BtnSearch.Visible = true;
            DVCat.Visible = true;
            DVTr.Visible = true;//--------------
            DvOpt.Visible = false;
            BtnCancel.Visible = false;


        }
    }
    public void Fill_VillageCode_And_Name()
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name1(0);
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
           // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
           // lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        string BaseUrl = Session["Burl"].ToString();
        Response.Redirect("~/ReportGP/ReportsGp.aspx" + BaseUrl, false);
    }
    protected void ImageButton12_Click(object sender, EventArgs e)
    {
        if(ddlselectname.SelectedItem.Text!="Select Name" && ddlselectscheme.SelectedItem.Text!="Select Option")
        {
            gvForFamily.Visible = true;
            BindfamilyByOptions();           
            btnprint.Visible = false;
            btn_print.Visible = false;
            OptionWise.Visible = true;
        }
        else
        {

            OptionWise.Visible = false;
        }
    }
    protected void gvForFamily_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTotal = 0;
        allotedamount = 0;
        i = 0;
        gvForFamily.PageIndex = e.NewPageIndex;
        BindfamilyByOptions();
    }
    protected void gvForFamily_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //decimal unitPrice = view.GetListSourceRowCellValue(listSourceRowIndex, "Each") == DBNull.Value
                //                 ? 0
                //                 : Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "Each"));

                // decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "installment"));
                decimal rowTotal = DataBinder.Eval(e.Row.DataItem, "installment") == DBNull.Value ? 0 : Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "installment"));
                grdTotal = grdTotal + rowTotal;
                allotedamount = 1000000 * i;


            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lblTotal");
                lbl.Text = grdTotal.ToString();
                //Label lbl1= (Label)e.Row.FindControl("lbltotalalloted");
                //lbl1.Text = allotedamount.ToString() +".00" ;


            }
            ++i;



            //   }


        }
        catch (Exception e1)
        {
          //  lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
          //  lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void BtnPrintOption_Click(object sender, EventArgs e)
    {
        this.printGridOption();
    }
    void printGridOption()
    {
        DataSet ds1 = ViewState["Data"] as DataSet;
        // GridView GridView1 = new GridView();
        gvForFamily.DataSource = ViewState["Data"];
        gvForFamily.AllowPaging = false;
        gvForFamily.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvForFamily.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div>");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Option wise Family Details ");
        sb.Append("</font></div>");
        sb.Append("<div style='text-align:right; color:#743D02; font-weight:bold;'><font size=3px > ");
        sb.Append(" Grand Total : -  ");

        sb.Append(ds1.Tables[0].Rows[0]["grandtotol"].ToString());
        sb.Append("</font></div>");
        sb.Append("</div>");





        sb.Append(gridHTML);

        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        BindfamilyByOptions();
    }

    protected void GVSurvey_Details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Map")
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            Response.Redirect("~/auth/Adminpanel/Map/Post.aspx?id=" + id);
        }
    }
    protected void GVSurvey_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblAction = (Label)e.Row.FindControl("lblAction");
        ImageButton ibEdit = (ImageButton)e.Row.FindControl("ibEdit");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


        }
    }
}