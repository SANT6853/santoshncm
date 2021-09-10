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
using System.Drawing;
using System.Linq;

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
            BindStateName();
            BindTigerReserveName1();
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
            string vil_id=string.Empty;
          //  string vil_id = ddlselectname.SelectedValue.ToString();
            if(ddlselectname.SelectedValue=="0")
            {
                 vil_id = null;
            }
            else
            {
                vil_id = ddlselectname.SelectedValue.ToString();
            }
           // string sch_id = ddlselectscheme.SelectedValue.ToString();
            string sch_id = string.Empty;
            if (ddlselectscheme.SelectedValue == "0")
            {
                sch_id = null;
            }
            else
            {
                sch_id = ddlselectscheme.SelectedValue.ToString();
            }
            string StateName = string.Empty;
            if (DdlStateName.SelectedValue == "0")
            {
                StateName = null;
            }
            else
            {
                StateName = DdlStateName.SelectedValue.ToString();
            }
            string ReserName = string.Empty;
            if (ddlselectreserve.SelectedValue == "0")
            {
                ReserName = null;
            }
            else
            {
                ReserName = ddlselectreserve.SelectedItem.Text.Trim();
            }
            //  string res_id = Request.QueryString["R_ID"].ToString();
            ds = VillDB_Obj.Proc_DisplayFamilyByVillageSchme(vil_id, null, sch_id, ReserName, StateName);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTotal = 0; allotedamount = 0; i = 0;
                BtnPrintOption.Visible = true;
                gvForFamily.Visible = true;
                gvForFamily.AllowPaging = true;
                gvForFamily.DataSource = ds.Tables[0].DefaultView;
                ViewState["Data"] = ds;
                //   grandtotalnew.Text = ds.Tables[0].Rows[0]["grandtotol"].ToString();
                gvForFamily.DataBind();
                GridveiwNumericColumnCalculationOptionWise(ds);
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
            string Statename = string.Empty;
            if (DdlStateName.SelectedValue != "0")
            {
                Statename = DdlStateName.SelectedValue;
            }
            else
            {
                Statename = null;
            }

            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveNameRPG1(Statename);
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
        string StateName = string.Empty;
        // string res_id = Request.QueryString["RSRV_ID"].ToString();
        if (ddlselectreserve.SelectedItem.Text == "-Select-")
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
        if (DdlStateName.SelectedItem.Text == "--Select--")
        {
            StateName = null;
        }
        else
        {
            StateName = DdlStateName.SelectedValue;
        }
        DataSet ds = RDb.Proc_VillageSearchByReserveRGP(sTigerReserveName, catType, StateName,null);
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
            GridViewNumericCalculation4(ds);

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

        DataSet ds = RDb.Proc_VillageSearchByReserve3(null, null, null);
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
        if (DdlCat.SelectedValue == "1")
        {
            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage();
        }

        if (DdlCat.SelectedValue == "22")
        {
            gv_villageSearch.PageIndex = e.NewPageIndex;

            bindgrid();
        }

        //if (Session["UserType"].ToString().Equals("3"))
        //{
        //    gv_villageSearch.PageIndex = e.NewPageIndex;
        //    displayVillage3();
        //}
        //if (Session["UserType"].ToString().Equals("4"))
        //{
        //    gv_villageSearch.PageIndex = e.NewPageIndex;
        //    displayVillage();
        //}
    }
    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gv_villageSearch.DataSource = ViewState["Data"];
        gv_villageSearch.AllowPaging = false;
        gv_villageSearch.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridViewNumericCalculation4(Ds);

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
            GVSurvey_Details.Visible = true;
            btnprint.Visible = true;
            //------------
            btn_print.Visible = false;
            gv_villageSearch.Visible = false;

            bindgrid();
        }
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
                hyper.NavigateUrl = ResolveUrl("~/ReportGPAdminMaster/View_NGO_Details.aspx?V_ID= " + hidden1.Value + " ");
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
    public bool boolChk()
    {
        bool chking = true;
        if (DdlStateName.SelectedValue == "0" && ddlselectreserve.SelectedValue == "0")
        {
            if (DdlCat.SelectedValue == "00")
            {
                DdlCat.BorderColor = System.Drawing.Color.Red;
               // Response.Write("<script>alert('Please select Category!');</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Category!');", true);
                DdlCat.Focus();
                DdlCat.BorderColor = System.Drawing.Color.Red;
              //  DdlCat.Attributes.Add("onfocus", "var elem=this;setTimeout(function(){elem.select();},0);");
                return chking = false;
            }

        }
        else
        {
            if (DdlStateName.SelectedValue != "0")
            {
                //if (ddlselectreserve.SelectedValue == "0")
                //{
                //    Response.Write("<script>alert('Please select Tiger Reserve!');</script>");
                //    ddlselectreserve.Focus();
                //    return chking = false;
                //}
                if (DdlCat.SelectedValue == "00")
                {
                   // Response.Write("<script>alert('Please select Category!');</script>");
                    DdlCat.BorderColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Category!');", true);
                    DdlCat.Focus();
                    DdlCat.BorderColor = System.Drawing.Color.Red;
                    return chking = false;
                }

            }
            if (ddlselectreserve.SelectedValue != "0")
            {
                //if (DdlStateName.SelectedValue == "0")
                //{
                //    Response.Write("<script>alert('Please select State Name!');</script>");
                //    DdlStateName.Focus();
                //    return chking = false;
                //}
                if (DdlCat.SelectedValue == "00")
                {
                  //  Response.Write("<script>alert('Please select Category!');</script>");
                    DdlCat.BorderColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Category!');", true);
                    DdlCat.Focus();
                    DdlCat.BorderColor = System.Drawing.Color.Red;
                    return chking = false;
                }
            }
            //if (DdlCat.SelectedValue != "00")
            //{
            //    if (DdlStateName.SelectedValue == "0")
            //    {
            //        Response.Write("<script>alert('Please select State Name!');</script>");
            //        DdlStateName.Focus();
            //        return chking = false;
            //    }
            //    if (ddlselectreserve.SelectedValue == "0")
            //    {
            //        Response.Write("<script>alert('Please select Tiger Reserve!');</script>");
            //        ddlselectreserve.Focus();
            //        return chking = false;
            //    }

            //}
        }


        return chking = true;

    }
    public void GridveiwNumericColumnCalculation(DataSet ds)
    {
        string Total = "";
        int sno = 0;
        int Population = 0;
        decimal TotalLandAreaHa = 0;
        decimal TotalAgricultureLandAreaHa = 0;
        decimal TotalNonAgricultureLandAreaHa = 0;
        decimal OtherLandAreaHa = 0;
        decimal ValueofAgricultureland = 0;
        decimal ValueResidentialLand = 0;
        int TotalCow = 0;
        int TotalBuffalo = 0;
        int TotalSheep = 0;
        //  int TotalGoat = 0;
        // int OtherAnimal = 0;
        // int RelocatedFamilies = 0;
        // int NonRelocatedFamilies = 0;
        //int NGO = 0;
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    sno = ds.Tables[0].Rows.Count;
        //    Population += Convert.ToInt32(ds.Tables[0].Rows[i]["Village"]);
        //    TotalLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["family"]);
        //    TotalAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["relocatedvill"]);
        //    TotalNonAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["relocatefam"]);
        //    OtherLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["remainvill"]);
        //    ValueofAgricultureland += Convert.ToDecimal(ds.Tables[0].Rows[i]["remainfam"]);
        //    ValueResidentialLand += Convert.ToDecimal(ds.Tables[0].Rows[i]["moneyperfam"]);
        //    TotalCow += Convert.ToInt32(ds.Tables[0].Rows[i]["landpackge"]);
        //    TotalBuffalo += Convert.ToInt32(ds.Tables[0].Rows[i]["landandmoney"]);
        //    TotalSheep += Convert.ToInt32(ds.Tables[0].Rows[i]["villrelocotherpack"]);
        //    //TotalGoat += Convert.ToInt32(ds.Tables[0].Rows[i]["NoGoat"]);
        //    //  OtherAnimal += Convert.ToInt32(ds.Tables[0].Rows[i]["TOT_OTHR_ANML"]);
        //    // RelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Relocated_Population"]);
        //    // NonRelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Non_Relocated_Population"]);
        //    // NGO += Convert.ToInt32(ds.Tables[0].Rows[i]["ngo"]);
        //}
        //sno
        //GVSurvey_Details.FooterRow.Cells[0].Text = "Total ";
        //GVSurvey_Details.FooterRow.Cells[0].Font.Bold = true;
        //GVSurvey_Details.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //GVSurvey_Details.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////---------Population
        //GVSurvey_Details.FooterRow.Cells[4].Text = Total + Population.ToString();
        //GVSurvey_Details.FooterRow.Cells[4].Font.Bold = true;
        //GVSurvey_Details.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        //GVSurvey_Details.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////--TotalLandAreaHa
        //GVSurvey_Details.FooterRow.Cells[5].Text = Total + TotalLandAreaHa.ToString();
        //GVSurvey_Details.FooterRow.Cells[5].Font.Bold = true;
        //GVSurvey_Details.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        //GVSurvey_Details.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Total Agriculture Land Area(Ha)
        //GVSurvey_Details.FooterRow.Cells[6].Text = Total + TotalAgricultureLandAreaHa.ToString();
        //GVSurvey_Details.FooterRow.Cells[6].Font.Bold = true;
        //GVSurvey_Details.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        //GVSurvey_Details.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Total Non Agriculture Land Area(Ha)
        //GVSurvey_Details.FooterRow.Cells[7].Text = Total + TotalNonAgricultureLandAreaHa.ToString();
        //GVSurvey_Details.FooterRow.Cells[7].Font.Bold = true;
        //GVSurvey_Details.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        //GVSurvey_Details.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Other Land Area(Ha
        //GVSurvey_Details.FooterRow.Cells[8].Text = Total + OtherLandAreaHa.ToString();
        //GVSurvey_Details.FooterRow.Cells[8].Font.Bold = true;
        //GVSurvey_Details.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        //GVSurvey_Details.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Value of Agriculture land
        //gvforVillages.FooterRow.Cells[9].Text = Total + ValueofAgricultureland.ToString();
        //gvforVillages.FooterRow.Cells[9].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Value Residential Land
        //gvforVillages.FooterRow.Cells[10].Text = Total + ValueResidentialLand.ToString();
        //gvforVillages.FooterRow.Cells[10].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Total Cow
        //gvforVillages.FooterRow.Cells[11].Text = Total + TotalCow.ToString();
        //gvforVillages.FooterRow.Cells[11].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Total Buffalo
        //gvforVillages.FooterRow.Cells[12].Text = Total + TotalBuffalo.ToString();
        //gvforVillages.FooterRow.Cells[12].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Total Sheep
        //gvforVillages.FooterRow.Cells[13].Text = Total + TotalSheep.ToString();
        //gvforVillages.FooterRow.Cells[13].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Goat
        //gvforVillages.FooterRow.Cells[14].Text = Total + TotalGoat.ToString();
        //gvforVillages.FooterRow.Cells[14].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Animal
        //gvforVillages.FooterRow.Cells[14].Text = Total + OtherAnimal.ToString();
        //gvforVillages.FooterRow.Cells[14].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        ////Relocated Families
        //gvforVillages.FooterRow.Cells[15].Text = Total + RelocatedFamilies.ToString();
        //gvforVillages.FooterRow.Cells[15].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[15].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////Non- Relocated Families
        //gvforVillages.FooterRow.Cells[16].Text = Total + NonRelocatedFamilies.ToString();
        //gvforVillages.FooterRow.Cells[16].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[16].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////NGO
        //gvforVillages.FooterRow.Cells[18].Text = Total + NGO.ToString();
        //gvforVillages.FooterRow.Cells[18].Font.Bold = true;
        //gvforVillages.FooterRow.Cells[18].HorizontalAlign = HorizontalAlign.Center;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;

    }
    void GridViewNumericCalculation4(DataSet ds)
    {
        //Grd calculation
        //here add code for column total sum and show in footer  

        //gv_villageSearch.FooterRow.Cells[1].Text = "Total";
        //gv_villageSearch.FooterRow.Cells[1].Font.Bold = true;
        //gv_villageSearch.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
        //  gv_villageSearch.Columns[2].FooterText = ds.Tables[0].AsEnumerable().Select(x => x.Field<Int32>("VILL_POPU")).Sum().ToString();

        //Population
        //gv_villageSearch.FooterRow.Cells[3].Text = ds.Tables[0].AsEnumerable().Select(x => x.Field<Int32>("VILL_POPU")).Sum().ToString();
        //gv_villageSearch.FooterRow.Cells[3].Font.Bold = true;
        //gv_villageSearch.FooterRow.Cells[3].HorizontalAlign = HorizontalAlign.Center;
        //gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        string Total = "Total=";
        int sno = 0;
        int Population = 0;
        decimal TotalLandAreaHa = 0;
        decimal TotalAgricultureLandAreaHa = 0;
        decimal TotalNonAgricultureLandAreaHa = 0;
        decimal OtherLandAreaHa = 0;
        decimal ValueofAgricultureland = 0;
        decimal ValueResidentialLand = 0;
        int TotalCow = 0;
       // int TotalBuffalo = 0;
        int TotalSheep = 0;
     //   int TotalGoat = 0;
        int OtherAnimal = 0;
        int RelocatedFamilies = 0;
        int NonRelocatedFamilies = 0;
        int NGO = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            Population += Convert.ToInt32(ds.Tables[0].Rows[i]["VILL_POPU"]);
            TotalLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_LND_AREA"]);
            TotalAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            TotalNonAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            OtherLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_OTHER_LND_AREA"]);
            ValueofAgricultureland += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_VAL_AGRI"]);
            ValueResidentialLand += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_VAL_RES"]);

            TotalCow += Convert.ToInt32(ds.Tables[0].Rows[i]["VILL_TOT_CNB"]);
           // TotalBuffalo += Convert.ToInt32(ds.Tables[0].Rows[i]["NoBuffalo"]);

            TotalSheep += Convert.ToInt32(ds.Tables[0].Rows[i]["VILL_TOT_SNG"]);
          //  TotalGoat += Convert.ToInt32(ds.Tables[0].Rows[i]["NoGoat"]);

            OtherAnimal += Convert.ToInt32(ds.Tables[0].Rows[i]["TOT_OTHR_ANML"]);
            RelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Relocated_Population"]);
            NonRelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Non_Relocated_Population"]);
            NGO += Convert.ToInt32(ds.Tables[0].Rows[i]["ngo"]);
        }
        //sno
        gv_villageSearch.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gv_villageSearch.FooterRow.Cells[0].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //---------Population
        gv_villageSearch.FooterRow.Cells[5].Text = Total + Population.ToString();
        gv_villageSearch.FooterRow.Cells[5].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //--TotalLandAreaHa
        gv_villageSearch.FooterRow.Cells[6].Text = Total + TotalLandAreaHa.ToString();
        gv_villageSearch.FooterRow.Cells[6].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Agriculture Land Area(Ha)
        gv_villageSearch.FooterRow.Cells[7].Text = Total + TotalAgricultureLandAreaHa.ToString();
        gv_villageSearch.FooterRow.Cells[7].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Non Agriculture Land Area(Ha)
        gv_villageSearch.FooterRow.Cells[8].Text = Total + TotalNonAgricultureLandAreaHa.ToString();
        gv_villageSearch.FooterRow.Cells[8].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Land Area(Ha
        gv_villageSearch.FooterRow.Cells[9].Text = Total + OtherLandAreaHa.ToString();
        gv_villageSearch.FooterRow.Cells[9].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value of Agriculture land
        gv_villageSearch.FooterRow.Cells[10].Text = Total + ValueofAgricultureland.ToString();
        gv_villageSearch.FooterRow.Cells[10].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value Residential Land
        gv_villageSearch.FooterRow.Cells[11].Text = Total + ValueResidentialLand.ToString();
        gv_villageSearch.FooterRow.Cells[11].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Cow
        gv_villageSearch.FooterRow.Cells[12].Text = Total + TotalCow.ToString();
        gv_villageSearch.FooterRow.Cells[12].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Buffalo
        //gv_villageSearch.FooterRow.Cells[11].Text = Total + TotalBuffalo.ToString();
        //gv_villageSearch.FooterRow.Cells[11].Font.Bold = true;
        //gv_villageSearch.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        //gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Sheep
        gv_villageSearch.FooterRow.Cells[13].Text = Total + TotalSheep.ToString();
        gv_villageSearch.FooterRow.Cells[13].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Goat
        //gv_villageSearch.FooterRow.Cells[13].Text = Total + TotalGoat.ToString();
        //gv_villageSearch.FooterRow.Cells[13].Font.Bold = true;
        //gv_villageSearch.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        //gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Animal
        gv_villageSearch.FooterRow.Cells[14].Text = Total + OtherAnimal.ToString();
        gv_villageSearch.FooterRow.Cells[14].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        //Relocated Families
        gv_villageSearch.FooterRow.Cells[15].Text = Total + RelocatedFamilies.ToString();
        gv_villageSearch.FooterRow.Cells[15].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[15].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Non- Relocated Families
        gv_villageSearch.FooterRow.Cells[16].Text = Total + NonRelocatedFamilies.ToString();
        gv_villageSearch.FooterRow.Cells[16].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[16].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //NGO
        gv_villageSearch.FooterRow.Cells[17].Text = Total + NGO.ToString();
        gv_villageSearch.FooterRow.Cells[17].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[17].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;

    }
    public void GridveiwNumericColumnCalculationOptionWise(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        decimal InstallmentAmountRs = 0;
        //int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["allotedamount"]);
            InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["fmly_no_memb"]);
            // FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        gvForFamily.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gvForFamily.FooterRow.Cells[0].Font.Bold = true;
        gvForFamily.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gvForFamily.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gvForFamily.FooterRow.Cells[5].Text = Total + AllottedAmountRs.ToString();
        gvForFamily.FooterRow.Cells[5].Font.Bold = true;
        gvForFamily.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gvForFamily.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        gvForFamily.FooterRow.Cells[7].Text = Total + InstallmentAmountRs.ToString();
        gvForFamily.FooterRow.Cells[7].Font.Bold = true;
        gvForFamily.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gvForFamily.FooterRow.BackColor = System.Drawing.Color.Beige;
        //FamilyMember

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (boolChk() == true)
        {
            if (DdlCat.SelectedValue == "1")
            {
                btn_print.Visible = true;
                gv_villageSearch.Visible = false;
                //--------------
                GVSurvey_Details.Visible = false;
                btnprint.Visible = false;

                displayVillage();
            }

            if (DdlCat.SelectedValue == "22")
            {
                GVSurvey_Details.Visible = true;
                btnprint.Visible = true;
                //------------
                btn_print.Visible = false;
                gv_villageSearch.Visible = false;

                bindgrid();
            }
        }
        //if (DdlStateName.SelectedValue == "0" && ddlselectreserve.SelectedValue=="0")
        //{
        //    if(DdlCat.SelectedValue=="00")
        //    {
        //        Response.Write("<script>alert('Please select Category!');</script>");
        //        return;
        //    }
        //    else
        //    {

        //    }
        //}
        //if (DdlStateName.SelectedValue != "0")
        //{
        //    if(ddlselectreserve.SelectedValue =="0")
        //    {
        //        Response.Write("<script>alert('Please select Tiger Reserve!');</script>");
        //        ddlselectreserve.Focus();

        //        if(DdlCat.SelectedValue =="00")
        //        {
        //            Response.Write("<script>alert('Please select Category!');</script>");
        //            DdlCat.Focus();
        //            return;
        //        }
        //    }
        //}



        //if (DdlCat.SelectedValue == "1")
        //{
        //    btn_print.Visible = true;
        //    gv_villageSearch.Visible = true;
        //    //--------------
        //    gvforVillages.Visible = false;
        //    btnprint.Visible = false;

        //    displayVillage();
        //}

        //if (DdlCat.SelectedValue == "22")
        //{
        //    gvforVillages.Visible = true;
        //    btnprint.Visible = true;
        //    //------------
        //    btn_print.Visible = false;
        //    gv_villageSearch.Visible = false;

        //    bindgrid();
        //}


    }
    public void bindgrid()
    {
        string sTigerReserveName = string.Empty;
        string StateName = string.Empty;
        // string res_id = Request.QueryString["RSRV_ID"].ToString();
        if (ddlselectreserve.SelectedItem.Text == "-Select-")
        {
            sTigerReserveName = null;
        }
        else
        {
            sTigerReserveName = ddlselectreserve.SelectedItem.Text;
        }
        if (DdlStateName.SelectedItem.Text == "--Select--")
        {
            StateName = null;
        }
        else
        {
            StateName = DdlStateName.SelectedItem.Text;
        }
        DataSet ds = del.SelectRecordForeGridRGP(sTigerReserveName, StateName);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GVSurvey_Details.Visible = true;
            GVSurvey_Details.DataSource = ds;
            ViewState["Data"] = ds;
            GVSurvey_Details.DataBind();
            btnprint.Visible = true;
            //  btnexporet.Visible = true;
            GridveiwNumericColumnCalculation(ds);
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
            GVSurvey_Details.Visible = true;
            btnprint.Visible = true;
            //------------
            btn_print.Visible = false;
            gv_villageSearch.Visible = false;

            bindgrid();
        }
    }
    void printGrid1()
    {

        GVSurvey_Details.DataSource = ViewState["Data"];
        GVSurvey_Details.AllowPaging = false;
        GVSurvey_Details.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculation(Ds);

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
        //string BaseUrl = Session["Burl"].ToString();
        // Response.Redirect("~/ReportGP/ReportsGp.aspx" + BaseUrl, false);
        Response.Redirect("~/ReportGPAdminMaster/reportsgp.aspx");
    }
    public bool boolChkNew()
    {
        bool chking = true;
        if (DdlStateName.SelectedValue == "0" && ddlselectreserve.SelectedValue == "0")
        {
            if (ddlselectscheme.SelectedValue == "0")
            {
               // Response.Write("<script>alert('Please select Option!');</script>");
                ddlselectscheme.BorderColor = System.Drawing.Color.Red;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Option!');", true);
                ddlselectscheme.Focus();
                ddlselectscheme.BorderColor = System.Drawing.Color.Red;
              //  ddlselectscheme.BorderStyle = BorderStyle.Groove;
                return chking = false;
            }

        }
        else
        {
            if (DdlStateName.SelectedValue != "0")
            {
                //if (ddlselectname.SelectedValue == "0")
                //{
                //    Response.Write("<script>alert('Please select Village name!');</script>");
                //    ddlselectname.Focus();
                //    return chking = false;
                //}
                if (ddlselectscheme.SelectedValue == "0")
                {
                   // Response.Write("<script>alert('Please select option!');</script>");
                    ddlselectscheme.BorderColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Option!');", true);
                    ddlselectscheme.Focus();
                    ddlselectscheme.BorderColor = System.Drawing.Color.Red;
                    return chking = false;
                }

            }
            if (ddlselectname.SelectedValue != "0")
            {
                //if (DdlStateName.SelectedValue == "0")
                //{
                //    Response.Write("<script>alert('Please select State Name!');</script>");
                //    DdlStateName.Focus();
                //    return chking = false;
                //}
                if (ddlselectscheme.SelectedValue == "0")
                {
                   // Response.Write("<script>alert('Please select option!');</script>");
                    ddlselectscheme.BorderColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Option!');", true);
                    ddlselectscheme.Focus();
                    ddlselectscheme.BorderColor = System.Drawing.Color.Red;
                    return chking = false;
                }
            }
            if (ddlselectreserve.SelectedValue != "0")
            {
                //if (DdlStateName.SelectedValue == "0")
                //{
                //    Response.Write("<script>alert('Please select State Name!');</script>");
                //    DdlStateName.Focus();
                //    return chking = false;
                //}
                if (ddlselectscheme.SelectedValue == "0")
                {
                   // Response.Write("<script>alert('Please select option!');</script>");
                    ddlselectscheme.BorderColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Option!');", true);
                    ddlselectscheme.Focus();
                    ddlselectscheme.BorderColor = System.Drawing.Color.Red;
                    return chking = false;
                }

            }

        }

        return chking = true;

    }
    protected void ImageButton12_Click(object sender, EventArgs e)
    {
        if (boolChkNew() == true)
        {
            //if (ddlselectname.SelectedItem.Text != "Select Name" && ddlselectscheme.SelectedItem.Text != "Select Option")
            //{
                gvForFamily.Visible = true;
                BindfamilyByOptions();
                btnprint.Visible = false;
                btn_print.Visible = false;
                OptionWise.Visible = true;
           // }
            //else
            //{

                //OptionWise.Visible = false;
           // }
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
        if (ddlselectname.SelectedItem.Text != "Select Name" && ddlselectscheme.SelectedItem.Text != "Select Option")
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
    void printGridOption()
    {
        DataSet ds1 = ViewState["Data"] as DataSet;
        // GridView GridView1 = new GridView();
        gvForFamily.DataSource = ViewState["Data"];
        gvForFamily.AllowPaging = false;
        gvForFamily.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculationOptionWise(Ds);

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
    void BindStateName()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        P_var.dSet = _commanfuction.BindDdlStateBarChart1(_objNtcauser);

        DdlStateName.Items.Clear();
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            int[] arrayId = { 2, 3, 4, 5, 6, 16, 18, 17, 23, 21, 24, 26, 29, 31, 36, 34, 33, 35 };
            var datarow = from d in P_var.dSet.Tables[0].AsEnumerable()
                          where arrayId.Contains(Convert.ToInt32(d[0]))
                          select new { StateName = d[1],Id=d[0] };
            DdlStateName.DataSource = datarow;// P_var.dSet.Tables[0];
            DdlStateName.DataTextField = "StateName";
            DdlStateName.DataValueField = "StateName";
            DdlStateName.DataBind();
            DdlStateName.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName1();
    }

    protected void linkFamily_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/survey.aspx?id=" + Vill_ID + "&p=2");
    }
    protected void btnScheme_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/ConversionScheme.aspx?id=" + Vill_ID);
    }

    protected void btnWorkperform_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/workperformlist.aspx?id=" + Vill_ID);
    }
    protected void btnNGO_Click(object sender, EventArgs e)
    {
        LinkButton btnStatus = (LinkButton)sender;
        string Vill_ID = btnStatus.CommandArgument;
        Response.Redirect("~/auth/Adminpanel/Post/postngodetail.aspx?id=" + Vill_ID);
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