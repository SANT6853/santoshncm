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
using System.Linq;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_VillageSearchII :CrsfBase
{
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    ReserveDB RDb = new ReserveDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblnodatafound.Text = "";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }
        if (!IsPostBack)
        {

            if (Session["UserType"].ToString().Equals("4"))
            {
                Page.Title = "VILLAGES REPORT :" + Session["sTigerReserveName"].ToString();
                displayVillage();
            }
            if (Session["UserType"].ToString().Equals("3"))
            {
                Page.Title = "VILLAGES REPORT :NTCA";
                displayVillage3();
            }
            if (Session["UserType"].ToString().Equals("2"))
            {
                Page.Title = "VILLAGES REPORT :NTCA";
                displayVillage2();
            }
            if (Session["UserType"].ToString().Equals("1"))
            {
                BindStateName();
                BindTigerReserveName1();
                Page.Title = "VILLAGES REPORT :NTCA";
                displayVillage1();
                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {//Request.QueryString["ConsoldateStateName"].ToString();
                    DdlStateName.SelectedValue = Request.QueryString["ConsoldateStateName"].ToString();
                    DdlStateName_SelectedIndexChanged(this, EventArgs.Empty);
                    displayVillage1();
                }
                else
                {
                  
                }
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
    void BindTigerReserveName1()
    {
        try
        {
            string StateName = string.Empty;
            if(DdlStateName.SelectedValue!="0")
            {
                StateName = DdlStateName.SelectedValue;
            }
            else
            {
                StateName = null;
            }
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select tiger reserve wise searching-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName1Modified(StateName);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select tiger reserve wise searching-", "0"));
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
        string Total = " ";
        int sno = 0;
        int Population = 0;
        decimal TotalLandAreaHa = 0;
        decimal TotalAgricultureLandAreaHa = 0;
        decimal TotalNonAgricultureLandAreaHa=0;
        decimal OtherLandAreaHa=0;
        decimal ValueofAgricultureland=0;
        decimal ValueResidentialLand=0;
        int TotalCow=0;
        int TotalBuffalo=0;
        int TotalSheep =0;
        int TotalGoat = 0;
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
            TotalCow += Convert.ToInt32(ds.Tables[0].Rows[i]["NoCows"]);
            TotalBuffalo += Convert.ToInt32(ds.Tables[0].Rows[i]["NoBuffalo"]);
            TotalSheep += Convert.ToInt32(ds.Tables[0].Rows[i]["NoSheep"]);
            TotalGoat += Convert.ToInt32(ds.Tables[0].Rows[i]["NoGoat"]);
            OtherAnimal += Convert.ToInt32(ds.Tables[0].Rows[i]["TOT_OTHR_ANML"]);
            RelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Relocated_Population"]);
            NonRelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Non_Relocated_Population"]);
            NGO += Convert.ToInt32(ds.Tables[0].Rows[i]["ngo"]);
        }
        //sno
        gv_villageSearch.FooterRow.Cells[0].Text = "Total";
        gv_villageSearch.FooterRow.Cells[0].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //---------Population
        gv_villageSearch.FooterRow.Cells[5].Text = Total + Population.ToString();
        gv_villageSearch.FooterRow.Cells[5].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //--TotalLandAreaHa
        gv_villageSearch.FooterRow.Cells[6].Text =Total+ TotalLandAreaHa.ToString();
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
        gv_villageSearch.FooterRow.Cells[13].Text = Total + TotalBuffalo.ToString();
        gv_villageSearch.FooterRow.Cells[13].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Sheep
        gv_villageSearch.FooterRow.Cells[14].Text = Total + TotalSheep.ToString();
        gv_villageSearch.FooterRow.Cells[14].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Goat
        gv_villageSearch.FooterRow.Cells[15].Text = Total + TotalGoat.ToString();
        gv_villageSearch.FooterRow.Cells[15].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[15].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Animal
        gv_villageSearch.FooterRow.Cells[16].Text = Total + OtherAnimal.ToString();
        gv_villageSearch.FooterRow.Cells[16].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[16].HorizontalAlign = HorizontalAlign.Center;
        //Relocated Families
        gv_villageSearch.FooterRow.Cells[17].Text = Total + RelocatedFamilies.ToString();
        gv_villageSearch.FooterRow.Cells[17].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[17].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Non- Relocated Families
        gv_villageSearch.FooterRow.Cells[18].Text = Total + NonRelocatedFamilies.ToString();
        gv_villageSearch.FooterRow.Cells[18].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[18].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        //NGO
        gv_villageSearch.FooterRow.Cells[20].Text = Total + NGO.ToString();
        gv_villageSearch.FooterRow.Cells[20].Font.Bold = true;
        gv_villageSearch.FooterRow.Cells[20].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch.FooterRow.BackColor = System.Drawing.Color.Beige;
       
    }
    void GridViewNumericCalculation4Export(DataSet ds)
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
        int TotalBuffalo = 0;
        int TotalSheep = 0;
        int TotalGoat = 0;
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
            TotalCow += Convert.ToInt32(ds.Tables[0].Rows[i]["NoCows"]);
            TotalBuffalo += Convert.ToInt32(ds.Tables[0].Rows[i]["NoBuffalo"]);
            TotalSheep += Convert.ToInt32(ds.Tables[0].Rows[i]["NoSheep"]);
            TotalGoat += Convert.ToInt32(ds.Tables[0].Rows[i]["NoGoat"]);
            OtherAnimal += Convert.ToInt32(ds.Tables[0].Rows[i]["TOT_OTHR_ANML"]);
            RelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Relocated_Population"]);
            NonRelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Non_Relocated_Population"]);
            NGO += Convert.ToInt32(ds.Tables[0].Rows[i]["ngo"]);
        }
        //sno
        GridViewExport.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        GridViewExport.FooterRow.Cells[0].Font.Bold = true;
        GridViewExport.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //---------Population
        GridViewExport.FooterRow.Cells[5].Text = Total + Population.ToString();
        GridViewExport.FooterRow.Cells[5].Font.Bold = true;
        GridViewExport.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //--TotalLandAreaHa
        GridViewExport.FooterRow.Cells[6].Text = Total + TotalLandAreaHa.ToString();
        GridViewExport.FooterRow.Cells[6].Font.Bold = true;
        GridViewExport.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Agriculture Land Area(Ha)
        GridViewExport.FooterRow.Cells[7].Text = Total + TotalAgricultureLandAreaHa.ToString();
        GridViewExport.FooterRow.Cells[7].Font.Bold = true;
        GridViewExport.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Non Agriculture Land Area(Ha)
        GridViewExport.FooterRow.Cells[8].Text = Total + TotalNonAgricultureLandAreaHa.ToString();
        GridViewExport.FooterRow.Cells[8].Font.Bold = true;
        GridViewExport.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Land Area(Ha
        GridViewExport.FooterRow.Cells[9].Text = Total + OtherLandAreaHa.ToString();
        GridViewExport.FooterRow.Cells[9].Font.Bold = true;
        GridViewExport.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value of Agriculture land
        GridViewExport.FooterRow.Cells[10].Text = Total + ValueofAgricultureland.ToString();
        GridViewExport.FooterRow.Cells[10].Font.Bold = true;
        GridViewExport.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value Residential Land
        GridViewExport.FooterRow.Cells[11].Text = Total + ValueResidentialLand.ToString();
        GridViewExport.FooterRow.Cells[11].Font.Bold = true;
        GridViewExport.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Cow
        GridViewExport.FooterRow.Cells[12].Text = Total + TotalCow.ToString();
        GridViewExport.FooterRow.Cells[12].Font.Bold = true;
        GridViewExport.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Buffalo
        GridViewExport.FooterRow.Cells[13].Text = Total + TotalBuffalo.ToString();
        GridViewExport.FooterRow.Cells[13].Font.Bold = true;
        GridViewExport.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Sheep
        GridViewExport.FooterRow.Cells[14].Text = Total + TotalSheep.ToString();
        GridViewExport.FooterRow.Cells[14].Font.Bold = true;
        GridViewExport.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Goat
        GridViewExport.FooterRow.Cells[15].Text = Total + TotalGoat.ToString();
        GridViewExport.FooterRow.Cells[15].Font.Bold = true;
        GridViewExport.FooterRow.Cells[15].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Animal
        GridViewExport.FooterRow.Cells[16].Text = Total + OtherAnimal.ToString();
        GridViewExport.FooterRow.Cells[16].Font.Bold = true;
        GridViewExport.FooterRow.Cells[16].HorizontalAlign = HorizontalAlign.Center;
        //Relocated Families
        GridViewExport.FooterRow.Cells[17].Text = Total + RelocatedFamilies.ToString();
        GridViewExport.FooterRow.Cells[17].Font.Bold = true;
        GridViewExport.FooterRow.Cells[17].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Non- Relocated Families
        GridViewExport.FooterRow.Cells[18].Text = Total + NonRelocatedFamilies.ToString();
        GridViewExport.FooterRow.Cells[18].Font.Bold = true;
        GridViewExport.FooterRow.Cells[18].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        //NGO
        GridViewExport.FooterRow.Cells[20].Text = Total + NGO.ToString();
        GridViewExport.FooterRow.Cells[20].Font.Bold = true;
        GridViewExport.FooterRow.Cells[20].HorizontalAlign = HorizontalAlign.Center;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;
        GridViewExport.FooterRow.BackColor = System.Drawing.Color.Beige;

    }
    public void displayVillage()
    {
        // string res_id = Request.QueryString["RSRV_ID"].ToString();
        DataSet ds = RDb.Proc_VillageSearchByReserve(null, null, null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            Label1.Text = "State Name";
            Label2.Text = ds.Tables[1].Rows[0][1].ToString();
            Label3.Text = "Tiger Reserve Name";
            Label4.Text = ds.Tables[1].Rows[0][0].ToString();
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            GridViewExport.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            GridViewExport.DataBind();
           // gv_villageSearch.Columns[19].Visible = false;

            GridViewNumericCalculation4(ds);
            GridViewNumericCalculation4Export(ds);
            BtnExcelExport.Visible = true;
            BtnExportPDF.Visible = true;
            BtnExcelExport.Visible = true;
            btn_print.Visible = true;
            BtnExcelExport.Visible = true;
        }
        else
        {
            BtnExportPDF.Visible = false;
            BtnExcelExport.Visible = false;
            btn_print.Visible = false;
            BtnExcelExport.Visible = false;

            BtnExcelExport.Visible = false;
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
        DataSet ds = RDb.Proc_VillageSearchByReserve3(null, null, null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            GridViewExport.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            GridViewExport.DataBind();
          //  gv_villageSearch.Columns[19].Visible = false;
            GridViewNumericCalculation4(ds);
            GridViewNumericCalculation4Export(ds);
            BtnExcelExport.Visible = true;

            BtnExportPDF.Visible = true;
            BtnExcelExport.Visible = true;
            btn_print.Visible = true;
            BtnExcelExport.Visible = true;
        }
        else
        {
            BtnExportPDF.Visible = false;
            BtnExcelExport.Visible = false;
            btn_print.Visible = false;
            BtnExcelExport.Visible = false;

            BtnExcelExport.Visible = false;
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            btn_print.Visible = false;

            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    public void displayVillage2()
    {


        DataSet ds = RDb.Proc_VillageSearchByReserve2(null, null, null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;

            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            GridViewExport.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            GridViewExport.DataBind();
        //    gv_villageSearch.Columns[19].Visible = false;
            GridViewNumericCalculation4(ds);
            GridViewNumericCalculation4Export(ds);
            BtnExcelExport.Visible = true;

            BtnExportPDF.Visible = true;
            BtnExcelExport.Visible = true;
            btn_print.Visible = true;
            BtnExcelExport.Visible = true;
        }
        else
        {
            BtnExportPDF.Visible = false;
            BtnExcelExport.Visible = false;
            btn_print.Visible = false;
            BtnExcelExport.Visible = false;

            BtnExcelExport.Visible = false;
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            btn_print.Visible = false;

            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    public void displayVillage1()
    {

        DataSet ds = new DataSet();
       
        //if (ddlselectreserve.SelectedValue != "0")
        //{
        //    ds = RDb.Proc_VillageSearchByReserveRevise1(null, null, null, ddlselectreserve.SelectedItem.Text);
        //}
        //else
        //{
        //    ds = RDb.Proc_VillageSearchByReserveRevise1(null, null, null, null);
        //}

        string tigerReserve = string.Empty;
        string stateName = string.Empty;
        if (ddlselectreserve.SelectedValue != "0")
        {
            tigerReserve = ddlselectreserve.SelectedItem.Text;
        }
        else
        {
            tigerReserve = null;
        }
        if (DdlStateName.SelectedValue != "0")
        {
            stateName = DdlStateName.SelectedItem.Text;
        }
        else
        {
            stateName=null;
        }
        ds = RDb.Proc_VillageSearchByReserveRevise1(null, null, null, tigerReserve, stateName);
        //  DataSet ds = RDb.Proc_VillageSearchByReserveRevise1(null, null, null, null);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;

            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            GridViewExport.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            GridViewExport.DataBind();
            GridViewExport.Columns[1].Visible = false;
            gv_villageSearch.Columns[1].Visible = false;
            GridViewNumericCalculation4(ds);
            GridViewNumericCalculation4Export(ds);
            BtnExcelExport.Visible = true;

            BtnExportPDF.Visible = true;
            BtnExcelExport.Visible = true;
            btn_print.Visible = true;
            BtnExcelExport.Visible = true;
        }
        else
        {
            BtnExportPDF.Visible = false;
                BtnExcelExport.Visible = false;
                btn_print.Visible = false;
            BtnExcelExport.Visible = false;

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
        if (Session["UserType"].ToString().Equals("1"))
        {
            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage1();
        }
        if (Session["UserType"].ToString().Equals("2"))
        {
            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage2();
        }
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
        GridViewExport.Visible = true;
        // GridView GridView1 = new GridView();
        GridViewExport.DataSource = ViewState["Data"];
        GridViewExport.AllowPaging = false;
        GridViewExport.DataBind();

        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridViewNumericCalculation4Export(Ds);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridViewExport.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Tiger Reserve Village Relocation Program at a Glance ");
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
        GridViewExport.AllowPaging = true;
        GridViewExport.DataBind();
        GridViewExport.Visible = false;
    }
    protected void btn_print_Click1(object sender, EventArgs e)
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
                        this.printGrid();
                        if (Session["UserType"].ToString().Equals("4"))
                        {
                            Page.Title = "VILLAGES REPORT :" + Session["sTigerReserveName"].ToString();
                            displayVillage();
                        }
                        if (Session["UserType"].ToString().Equals("3"))
                        {
                            Page.Title = "VILLAGES REPORT :NTCA";
                            displayVillage3();
                        }
                        if (Session["UserType"].ToString().Equals("2"))
                        {
                            Page.Title = "VILLAGES REPORT :NTCA";
                            displayVillage2();
                        }
                        if (Session["UserType"].ToString().Equals("1"))
                        {
                            BindTigerReserveName1();
                            Page.Title = "VILLAGES REPORT :NTCA";
                            displayVillage1();
                        }
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void ImageButton1_Click(object sender, EventArgs e)
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
                        if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                        {
                            Response.Redirect("VillageSearch.aspx?ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString(), false);
                        }
                        else
                        {
                            Response.Redirect("VillageSearch.aspx");
                        }

                    }
                }
            }

        }

        catch
        {
            throw;
        }

        //}
    }
       
    
    protected void gv_villageSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label1.Text = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hidden1 = e.Row.FindControl("villid") as HiddenField;
            HyperLink hyper = e.Row.FindControl("hyperngo") as HyperLink;
         //   HyperLink hyper1a = e.Row.FindControl("hyperngo1a") as HyperLink;
            if (hyper.Text.Equals("0"))
            {
                
                hyper.NavigateUrl = "#";
                hyper.Attributes.Add("target", "");
                // hyper.Text = "NA";
                hyper.Text = "0";
                Label1.Text = "Record not found!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                hyper.NavigateUrl = ResolveUrl("~/AUTH/adminpanel/REPORT/View_NGO_Details.aspx?V_ID= " + hidden1.Value + " ");
                hyper.Attributes.Add("target", "_blank");
            }
            //if (hyper1a.Text.Equals("0"))
            //{
            //    hyper1a.NavigateUrl = "#";
            //    hyper1a.Attributes.Add("target", "");
            //    hyper1a.Text = "No Record";
            //}
            //else
            //{

            //    hyper1a.NavigateUrl = ResolveUrl("~/AUTH/adminpanel/REPORT/View_NGO_1A_VillWise.aspx?V_ID= " + hidden1.Value + " ");
            //    hyper1a.Attributes.Add("target", "_blank");
            //}
            if (Session["UserType"].ToString().Equals("4"))
            {
                gv_villageSearch.Columns[1].Visible = false;
            }
            if (Session["UserType"].ToString().Equals("3"))
            {
               // gv_villageSearch.Columns[21].Visible = false;
            }
            if (Session["UserType"].ToString().Equals("2"))
            {
               // gv_villageSearch.Columns[21].Visible = false;
            }
            if (Session["UserType"].ToString().Equals("1"))
            {
                //gv_villageSearch.Columns[1].Visible = true;
            }
        }
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {

       // displayVillage1();

    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName1();
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

                        displayVillage1();
                    }
                }
            }
        }
        catch
        {
            throw;
        }

        //}
    }  
    protected void BtnExcelExport_Click(object sender, EventArgs e)
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


                        GridViewExport.Visible = true;
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                        Response.Charset = "UTF-8";
                        Response.ContentType = "application/vnd.ms-excel";
                        using (StringWriter sw = new StringWriter())
                        {
                            HtmlTextWriter hw = new HtmlTextWriter(sw);

                            //To Export all pages
                            GridViewExport.Caption = "<h1>Village-Wise Report</h1>";
                            GridViewExport.AllowPaging = false;
                            if (Session["UserType"].ToString().Equals("4"))
                            {

                                displayVillage();
                            }
                            if (Session["UserType"].ToString().Equals("3"))
                            {

                                displayVillage3();
                            }
                            if (Session["UserType"].ToString().Equals("2"))
                            {

                                displayVillage2();
                            }
                            if (Session["UserType"].ToString().Equals("1"))
                            {

                                displayVillage1();
                            }
                            // gv_villageSearch.HeaderRow.BackColor = System.Drawing.Color.Black;
                            this.GridViewExport.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                            this.GridViewExport.HeaderStyle.BackColor = System.Drawing.Color.Green;
                            foreach (TableCell cell in GridViewExport.HeaderRow.Cells)
                            {
                                cell.BackColor = GridViewExport.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in GridViewExport.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = GridViewExport.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = GridViewExport.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            GridViewExport.RenderControl(hw);

                            //style to format numbers to string
                            //   string style = @"<style> .textmode { } </style>";
                            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                            Response.Write(style);
                            Response.Output.Write(sw.ToString());
                            Response.Flush();
                            Response.End();
                            GridViewExport.Visible = false;
                        }
                    }
                }
            }
        }
        catch
        {
            throw;
        }

        //}
    }  
    
    protected void BtnExportPDF_Click(object sender, EventArgs e)
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



                        ExportGridToPDF();
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    } 
    private void ExportGridToPDF()
    {
        GridViewExport.Visible = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Village-Wise Report.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        hw.WriteLine("<h1 style=\"text-align:center;\">Village-Wise Report</h1>");
        hw.WriteLine("<br>");

        GridViewExport.HeaderStyle.ForeColor = System.Drawing.Color.White;
        GridViewExport.HeaderStyle.BackColor = System.Drawing.Color.Green;
        GridViewExport.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
      
        Response.End();
        GridViewExport.AllowPaging = true;

        GridViewExport.DataBind();
        GridViewExport.Visible = false;
    }
    protected void GridViewExport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //if (Session["UserType"].ToString().Equals("1"))
        //{
        //    gv_villageSearch.PageIndex = e.NewPageIndex;
        //    displayVillage1();
        //}
        //if (Session["UserType"].ToString().Equals("2"))
        //{
        //    gv_villageSearch.PageIndex = e.NewPageIndex;
        //    displayVillage2();
        //}
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
    protected void GridViewExport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label1.Text = "";
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hidden1 = e.Row.FindControl("villid") as HiddenField;
            HyperLink hyper = e.Row.FindControl("hyperngo") as HyperLink;
            //   HyperLink hyper1a = e.Row.FindControl("hyperngo1a") as HyperLink;
            if (hyper.Text.Equals("0"))
            {

                hyper.NavigateUrl = "#";
                hyper.Attributes.Add("target", "");
                // hyper.Text = "NA";
                hyper.Text = "0";
                Label1.Text = "Record not found!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                hyper.NavigateUrl = ResolveUrl("~/AUTH/adminpanel/REPORT/View_NGO_Details.aspx?V_ID= " + hidden1.Value + " ");
                hyper.Attributes.Add("target", "_blank");
            }
            
            if (Session["UserType"].ToString().Equals("4"))
            {
                gv_villageSearch.Columns[1].Visible = false;
            }
            if (Session["UserType"].ToString().Equals("3"))
            {
                // gv_villageSearch.Columns[21].Visible = false;
            }
            if (Session["UserType"].ToString().Equals("2"))
            {
                // gv_villageSearch.Columns[21].Visible = false;
            }
            if (Session["UserType"].ToString().Equals("1"))
            {
                //gv_villageSearch.Columns[1].Visible = true;
            }
        }
    }
}