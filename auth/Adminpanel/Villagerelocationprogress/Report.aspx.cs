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
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;

    
public partial class auth_Adminpanel_Villagerelocationprogress_Report : CrsfBase
{
    relocationprogress del = new relocationprogress();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }


        if (!IsPostBack)
        {
            if (Session["UserType"].ToString() == "1")
            {
                BindTigerReserveName1();
                bindgrid1();
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
                bindgrid2();
            }
            if (Session["UserType"].ToString() == "3")
            {
                bindgrid3();
            }
            if (Session["UserType"].ToString() == "4")
            {

                bindgrid();
            }
          
        }
    }
    void BindTigerReserveName1()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select tiger reserve-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName1Modified(null);
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
    public void bindgrid1()
    {
        DataSet ds = new DataSet();
        if (ddlselectreserve.SelectedValue == "0" && txtdate.Text==string.Empty)
        {
            ds = del.SelectRecordForeGrid11(null, null);
        }
        if (ddlselectreserve.SelectedValue != "0")
        {
            ds = del.SelectRecordForeGrid11(txtdate.Text, ddlselectreserve.SelectedItem.Text);
        }
        else
        {
             ds = del.SelectRecordForeGrid11(txtdate.Text, null);
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.DataSource = ds;
            ViewState["Data"] = ds;
            gvforVillages.DataBind();
            btnprint.Visible = true;
            btnexporet.Visible = true;
            GridveiwNumericColumnCalculation(ds);
            BtnPdfExport.Visible = true;

           btnprint.Visible = true;
                BtnPdfExport.Visible = true;
                btnexporet.Visible = true;
        }
        else
        {
            btnprint.Visible = false;
            BtnPdfExport.Visible = false;
            btnexporet.Visible = false;

            BtnPdfExport.Visible = false;
            gvforVillages.DataSource = null;
            gvforVillages.DataBind();
            btnexporet.Visible = false;
            btnprint.Visible = false;
        }

    }
    public void bindgrid3()
    {
        DataSet ds = del.SelectRecordForeGrid33(txtdate.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.DataSource = ds;
            ViewState["Data"] = ds;
            gvforVillages.DataBind();
            btnprint.Visible = true;
            btnexporet.Visible = true;
            GridveiwNumericColumnCalculation(ds);
            BtnPdfExport.Visible = true;
        }
        else
        {
            BtnPdfExport.Visible = false;
            gvforVillages.DataSource = null;
            gvforVillages.DataBind();
            btnexporet.Visible = false;
            btnprint.Visible = false;
        }

    }
    public void bindgrid2()
    {
        DataSet ds = del.SelectRecordForeGrid22(txtdate.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.DataSource = ds;
            ViewState["Data"] = ds;
            gvforVillages.DataBind();
            btnprint.Visible = true;
            btnexporet.Visible = true;
            GridveiwNumericColumnCalculation(ds);
            BtnPdfExport.Visible = true;
        }
        else
        {
            BtnPdfExport.Visible = false;
            gvforVillages.DataSource = null;
            gvforVillages.DataBind();
            btnexporet.Visible = false;
            btnprint.Visible = false;
        }

    }
    public void bindgrid()
    {
        DataSet ds = del.SelectRecordForeGrid(txtdate.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvforVillages.DataSource = ds;
            ViewState["Data"] = ds;
            gvforVillages.DataBind();
            btnprint.Visible = true;
            btnexporet.Visible = true;
            GridveiwNumericColumnCalculation(ds);
            BtnPdfExport.Visible = true;
        }
        else
        {
            BtnPdfExport.Visible = false;
            gvforVillages.DataSource = null;
            gvforVillages.DataBind();
            btnexporet.Visible = false;
            btnprint.Visible = false;
        }

    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvforVillages.PageIndex = e.NewPageIndex;
      //  bindgrid();
        if (Session["UserType"].ToString() == "1")
        {
            bindgrid1();
        }
        if (Session["UserType"].ToString() == "2")
        {
            bindgrid2();
        }
        if (Session["UserType"].ToString() == "3")
        {
            bindgrid3();
        }
        if (Session["UserType"].ToString() == "4")
        {

            bindgrid();
        }


    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
      //  bindgrid();
        if (Session["UserType"].ToString() == "1")
        {
            bindgrid1();
        }
        if (Session["UserType"].ToString() == "2")
        {
            bindgrid2();
        }
        if (Session["UserType"].ToString() == "3")
        {
            bindgrid3();
        }
        if (Session["UserType"].ToString() == "4")
        {

            bindgrid();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
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

                    if (Session["UserType"].ToString() == "1")
                    {
                        // BindTigerReserveName1();
                        bindgrid1();
                    }
                    if (Session["UserType"].ToString() == "2")
                    {
                        bindgrid2();
                    }
                    if (Session["UserType"].ToString() == "3")
                    {
                        bindgrid3();
                    }
                    if (Session["UserType"].ToString() == "4")
                    {

                        bindgrid();
                    }

                    //// bindgrid();
                    // if (Session["UserType"].ToString() == "1")
                    // {
                    //     bindgrid1();
                    // }
                    // if (Session["UserType"].ToString() == "2")
                    // {
                    //     bindgrid2();
                    // }
                    // if (Session["UserType"].ToString() == "3")
                    // {
                    //     bindgrid3();
                    // }
                    // if (Session["UserType"].ToString() == "4")
                    // {

                    //     bindgrid();
                   }
                }
            }
        }
        catch
        {
            throw;
        }
    }

    //}

    
    protected void btnprint_Click(object sender, EventArgs e)
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

                        printGrid();
                        if (Session["UserType"].ToString() == "1")
                        {
                            BindTigerReserveName1();
                            bindgrid1();
                        }
                        if (Session["UserType"].ToString() == "2")
                        {
                            bindgrid2();
                        }
                        if (Session["UserType"].ToString() == "3")
                        {
                            bindgrid3();
                        }
                        if (Session["UserType"].ToString() == "4")
                        {

                            bindgrid();
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

    //}
    void printGrid()
    {

        gvforVillages.DataSource = ViewState["Data"];
        gvforVillages.AllowPaging = false;
        gvforVillages.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculation(Ds);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvforVillages.RenderControl(hw);
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
        gvforVillages.AllowPaging = true;
        gvforVillages.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void btnexporet_Click(object sender, EventArgs e)
    {
        gvforVillages.AllowPaging = false;
        btnexporet.Visible = false;
        gvforVillages.DataSource = ViewState["Data"];
        gvforVillages.AllowPaging = false;
        gvforVillages.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculation(Ds);


        Realocation_AreaDB.ExportToExcel(ref panelprint, "Relocation site");
        gvforVillages.AllowPaging = true;
        gvforVillages.AllowPaging = true;
        gvforVillages.DataBind();
        //btnprint.Visible = true;
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
     
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            Population += Convert.ToInt32(ds.Tables[0].Rows[i]["Village"]);
            TotalLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["family"]);
            TotalAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["relocatedvill"]);
            TotalNonAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["relocatefam"]);
            OtherLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["remainvill"]);
            ValueofAgricultureland += Convert.ToDecimal(ds.Tables[0].Rows[i]["remainfam"]);
            ValueResidentialLand += Convert.ToDecimal(ds.Tables[0].Rows[i]["moneyperfam"]);
            TotalCow += Convert.ToInt32(ds.Tables[0].Rows[i]["landpackge"]);
            TotalBuffalo += Convert.ToInt32(ds.Tables[0].Rows[i]["landandmoney"]);
            TotalSheep += Convert.ToInt32(ds.Tables[0].Rows[i]["villrelocotherpack"]);
            //TotalGoat += Convert.ToInt32(ds.Tables[0].Rows[i]["NoGoat"]);
          //  OtherAnimal += Convert.ToInt32(ds.Tables[0].Rows[i]["TOT_OTHR_ANML"]);
           // RelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Relocated_Population"]);
           // NonRelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Non_Relocated_Population"]);
           // NGO += Convert.ToInt32(ds.Tables[0].Rows[i]["ngo"]);
        }
        //sno
        gvforVillages.FooterRow.Cells[0].Text = "Total ";
        gvforVillages.FooterRow.Cells[0].Font.Bold = true;
        gvforVillages.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //---------Population
        gvforVillages.FooterRow.Cells[4].Text = Total + Population.ToString();
        gvforVillages.FooterRow.Cells[4].Font.Bold = true;
        gvforVillages.FooterRow.Cells[4].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //--TotalLandAreaHa
        gvforVillages.FooterRow.Cells[5].Text = Total + TotalLandAreaHa.ToString();
        gvforVillages.FooterRow.Cells[5].Font.Bold = true;
        gvforVillages.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Agriculture Land Area(Ha)
        gvforVillages.FooterRow.Cells[6].Text = Total + TotalAgricultureLandAreaHa.ToString();
        gvforVillages.FooterRow.Cells[6].Font.Bold = true;
        gvforVillages.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Non Agriculture Land Area(Ha)
        gvforVillages.FooterRow.Cells[7].Text = Total + TotalNonAgricultureLandAreaHa.ToString();
        gvforVillages.FooterRow.Cells[7].Font.Bold = true;
        gvforVillages.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Land Area(Ha
        gvforVillages.FooterRow.Cells[8].Text = Total + OtherLandAreaHa.ToString();
        gvforVillages.FooterRow.Cells[8].Font.Bold = true;
        gvforVillages.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value of Agriculture land
        gvforVillages.FooterRow.Cells[9].Text = Total + ValueofAgricultureland.ToString();
        gvforVillages.FooterRow.Cells[9].Font.Bold = true;
        gvforVillages.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value Residential Land
        gvforVillages.FooterRow.Cells[10].Text = Total + ValueResidentialLand.ToString();
        gvforVillages.FooterRow.Cells[10].Font.Bold = true;
        gvforVillages.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Cow
        gvforVillages.FooterRow.Cells[11].Text = Total + TotalCow.ToString();
        gvforVillages.FooterRow.Cells[11].Font.Bold = true;
        gvforVillages.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Buffalo
        gvforVillages.FooterRow.Cells[12].Text = Total + TotalBuffalo.ToString();
        gvforVillages.FooterRow.Cells[12].Font.Bold = true;
        gvforVillages.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Sheep
        gvforVillages.FooterRow.Cells[13].Text = Total + TotalSheep.ToString();
        gvforVillages.FooterRow.Cells[13].Font.Bold = true;
        gvforVillages.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        gvforVillages.FooterRow.BackColor = System.Drawing.Color.Beige;
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
    protected void BtnPdfExport_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=MIS_Report.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.WriteLine("<h1 style=\"text-align:center;\">Village Relocation Progress Report</h1>");
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
    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsoldateReport.aspx");
    }
}