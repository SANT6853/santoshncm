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
using NCM.DAL;
using System.Text;
using System.IO;
using System.Drawing;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_VillagedynmicRpt : CrsfBase
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    VillageDB ObjDb_Vill = new VillageDB();
    DataSet ds = new DataSet();

    VillageDB VillDB_Obj = new VillageDB();
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    ReserveDB RDb = new ReserveDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblnodatafound.Text = "";

        Page.Title = "VILLAGES  DYNAMIC REPORT : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/adminpanel.aspx"), true);
        }

        if (!IsPostBack)
        {
            if (Session["UserType"].ToString().Equals("4"))
            {

                //FillReserve();
                btn_print.Visible = false;
                BtnPrintAll.Visible = false;
                gv_villageSearch1.Visible = false;

                displayVillage();
                Fill_VillageCode_And_Name(Convert.ToInt32(Session["User_Id"]));
                FillVillageCode();

            }
            if (Session["UserType"].ToString().Equals("3"))
            {
                BindTigerReserveName();
                //FillReserve();
                btn_print.Visible = false;
                BtnPrintAll.Visible = false;
                gv_villageSearch1.Visible = false;

                displayVillage3();
                Fill_VillageCode_And_Name3(Convert.ToInt32(Session["User_Id"]));
                FillVillageCode3();
            }
            if (Session["UserType"].ToString().Equals("2"))
            {
                BindTigerReserveName2();
                //FillReserve();
                btn_print.Visible = false;
                BtnPrintAll.Visible = false;
                gv_villageSearch1.Visible = false;

                displayVillage2();
                Fill_VillageCode_And_Name2(Convert.ToInt32(Session["User_Id"]));
                FillVillageCode2();

            }
            if (Session["UserType"].ToString().Equals("1"))
            {
                BindStateName();
                BindTigerReserveName1();
                //FillReserve();
                btn_print.Visible = false;
                BtnPrintAll.Visible = false;
                gv_villageSearch1.Visible = false;

                displayVillage1();
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                FillVillageCode1();
                if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                {//Request.QueryString["ConsoldateStateName"].ToString();
                    DdlStateName.SelectedValue = Request.QueryString["ConsoldateStateName"].ToString();
                    DdlStateName_SelectedIndexChanged(this, EventArgs.Empty);
                    displayVillage1();
                }
                else
                {

                }
                if (Request.QueryString["ModeR"] != null)
                {
                    DdlStateName.SelectedValue = Request.QueryString["ConsoldateStateName"].ToString();
                    displayVillage1();
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
        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);
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
    void GridViewNumericCalculation4(DataTable dt)
    {
        //DataSet ds
        string Total = " ";
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
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    sno = ds.Tables[0].Rows.Count;
        //    Population += Convert.ToInt32(ds.Tables[0].Rows[i]["VILL_POPU"]);
        //    TotalLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_LND_AREA"]);
        //    TotalAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
        //    TotalNonAgricultureLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
        //    OtherLandAreaHa += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_OTHER_LND_AREA"]);
        //    ValueofAgricultureland += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_VAL_AGRI"]);
        //    ValueResidentialLand += Convert.ToDecimal(ds.Tables[0].Rows[i]["VILL_VAL_RES"]);
        //    TotalCow += Convert.ToInt32(ds.Tables[0].Rows[i]["NoCows"]);
        //    TotalBuffalo += Convert.ToInt32(ds.Tables[0].Rows[i]["NoBuffalo"]);
        //    TotalSheep += Convert.ToInt32(ds.Tables[0].Rows[i]["NoSheep"]);
        //    TotalGoat += Convert.ToInt32(ds.Tables[0].Rows[i]["NoGoat"]);
        //    OtherAnimal += Convert.ToInt32(ds.Tables[0].Rows[i]["TOT_OTHR_ANML"]);
        //    RelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Relocated_Population"]);
        //    NonRelocatedFamilies += Convert.ToInt32(ds.Tables[0].Rows[i]["Total_Non_Relocated_Population"]);
        //    NGO += Convert.ToInt32(ds.Tables[0].Rows[i]["ngo"]);
        //}
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sno = dt.Rows.Count;
            Population += Convert.ToInt32(dt.Rows[i]["VILL_POPU"]);
            TotalLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_LND_AREA"]);
            TotalAgricultureLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            TotalNonAgricultureLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            OtherLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_OTHER_LND_AREA"]);
            ValueofAgricultureland += Convert.ToDecimal(dt.Rows[i]["VILL_VAL_AGRI"]);
            ValueResidentialLand += Convert.ToDecimal(dt.Rows[i]["VILL_VAL_RES"]);
            TotalCow += Convert.ToInt32(dt.Rows[i]["NoCows"]);
            TotalBuffalo += Convert.ToInt32(dt.Rows[i]["NoBuffalo"]);
            TotalSheep += Convert.ToInt32(dt.Rows[i]["NoSheep"]);
            TotalGoat += Convert.ToInt32(dt.Rows[i]["NoGoat"]);
            OtherAnimal += Convert.ToInt32(dt.Rows[i]["TOT_OTHR_ANML"]);
            RelocatedFamilies += Convert.ToInt32(dt.Rows[i]["Total_Relocated_Population"]);
            NonRelocatedFamilies += Convert.ToInt32(dt.Rows[i]["Total_Non_Relocated_Population"]);
            NGO += Convert.ToInt32(dt.Rows[i]["ngo"]);
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
    void GridViewNumericCalculation4DT(DataTable dt)
    {
       
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
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sno = dt.Rows.Count;
            Population += Convert.ToInt32(dt.Rows[i]["VILL_POPU"]);
            TotalLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_LND_AREA"]);
            TotalAgricultureLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            TotalNonAgricultureLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_TOT_AGRI_LND_AREA"]);
            OtherLandAreaHa += Convert.ToDecimal(dt.Rows[i]["VILL_OTHER_LND_AREA"]);
            ValueofAgricultureland += Convert.ToDecimal(dt.Rows[i]["VILL_VAL_AGRI"]);
            ValueResidentialLand += Convert.ToDecimal(dt.Rows[i]["VILL_VAL_RES"]);
            TotalCow += Convert.ToInt32(dt.Rows[i]["NoCows"]);
            TotalBuffalo += Convert.ToInt32(dt.Rows[i]["NoBuffalo"]);
            TotalSheep += Convert.ToInt32(dt.Rows[i]["NoSheep"]);
            TotalGoat += Convert.ToInt32(dt.Rows[i]["NoGoat"]);
            OtherAnimal += Convert.ToInt32(dt.Rows[i]["TOT_OTHR_ANML"]);
            RelocatedFamilies += Convert.ToInt32(dt.Rows[i]["Total_Relocated_Population"]);
            NonRelocatedFamilies += Convert.ToInt32(dt.Rows[i]["Total_Non_Relocated_Population"]);
            NGO += Convert.ToInt32(dt.Rows[i]["ngo"]);
        }
        gv_villageSearch1.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gv_villageSearch1.FooterRow.Cells[0].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //---------Population
        gv_villageSearch1.FooterRow.Cells[5].Text = Total + Population.ToString();
        gv_villageSearch1.FooterRow.Cells[5].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //--TotalLandAreaHa
        gv_villageSearch1.FooterRow.Cells[6].Text = Total + TotalLandAreaHa.ToString();
        gv_villageSearch1.FooterRow.Cells[6].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[6].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Agriculture Land Area(Ha)
        gv_villageSearch1.FooterRow.Cells[7].Text = Total + TotalAgricultureLandAreaHa.ToString();
        gv_villageSearch1.FooterRow.Cells[7].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Non Agriculture Land Area(Ha)
        gv_villageSearch1.FooterRow.Cells[8].Text = Total + TotalNonAgricultureLandAreaHa.ToString();
        gv_villageSearch1.FooterRow.Cells[8].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[8].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Land Area(Ha
        gv_villageSearch1.FooterRow.Cells[9].Text = Total + OtherLandAreaHa.ToString();
        gv_villageSearch1.FooterRow.Cells[9].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[9].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value of Agriculture land
        gv_villageSearch1.FooterRow.Cells[10].Text = Total + ValueofAgricultureland.ToString();
        gv_villageSearch1.FooterRow.Cells[10].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[10].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Value Residential Land
        gv_villageSearch1.FooterRow.Cells[11].Text = Total + ValueResidentialLand.ToString();
        gv_villageSearch1.FooterRow.Cells[11].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[11].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Cow
        gv_villageSearch1.FooterRow.Cells[12].Text = Total + TotalCow.ToString();
        gv_villageSearch1.FooterRow.Cells[12].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[12].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Buffalo
        gv_villageSearch1.FooterRow.Cells[13].Text = Total + TotalBuffalo.ToString();
        gv_villageSearch1.FooterRow.Cells[13].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[13].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Sheep
        gv_villageSearch1.FooterRow.Cells[14].Text = Total + TotalSheep.ToString();
        gv_villageSearch1.FooterRow.Cells[14].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[14].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Total Goat
        gv_villageSearch1.FooterRow.Cells[15].Text = Total + TotalGoat.ToString();
        gv_villageSearch1.FooterRow.Cells[15].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[15].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Other Animal
        gv_villageSearch1.FooterRow.Cells[16].Text = Total + OtherAnimal.ToString();
        gv_villageSearch1.FooterRow.Cells[16].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[16].HorizontalAlign = HorizontalAlign.Center;
        //Relocated Families
        gv_villageSearch1.FooterRow.Cells[17].Text = Total + RelocatedFamilies.ToString();
        gv_villageSearch1.FooterRow.Cells[17].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[17].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //Non- Relocated Families
        gv_villageSearch1.FooterRow.Cells[18].Text = Total + NonRelocatedFamilies.ToString();
        gv_villageSearch1.FooterRow.Cells[18].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[18].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        //NGO
        gv_villageSearch1.FooterRow.Cells[20].Text = Total + NGO.ToString();
        gv_villageSearch1.FooterRow.Cells[20].Font.Bold = true;
        gv_villageSearch1.FooterRow.Cells[20].HorizontalAlign = HorizontalAlign.Center;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;
        gv_villageSearch1.FooterRow.BackColor = System.Drawing.Color.Beige;

    } 
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
        VillageName();
      
    }
    public void displayVillage()
    {
        
        //string res_id = ddlselectreserve.SelectedValue.ToString();//Request.QueryString["RSRV_ID"].ToString();
       // string res_id = Session["RESERVEID"].ToString();//Request.QueryString["RSRV_ID"].ToString();
        //if (TxtVillageName.Text == "")
        //{
        //    TxtVillageName.Text = null;
        //}
        //if(TxtVillageCode.Text=="")
        //{
        //    TxtVillageCode.Text = null;
        //}
        string VillageName = string.Empty;
        if (ddlselectname.SelectedValue == "")
        {
            VillageName = null;
        }
        else
        {
            VillageName = ddlselectname.SelectedItem.Text.Trim();
        }
        string villcode = string.Empty;
        if (ddlselectcode.SelectedValue == "")
        {
            villcode = null;
        }
        else
        {
            villcode = ddlselectcode.SelectedItem.Text.Trim();
        }

        //---------
        string ddval = string.Empty;
        if (DDlStatus.SelectedIndex!= 0)
        {
            ddval = DDlStatus.SelectedValue;
        }
        else
        {
            ddval = null;
        }

       // DataSet ds = RDb.Proc_VillageSearchByReserve(TxtVillageName.Text, TxtVillageCode.Text, ddval);
        DataSet ds = RDb.Proc_VillageSearchByReserve(VillageName, villcode, ddval);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();

           //----18june---------
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;

            if (this.ViewState["SortExpression"] != null)
            {

                dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());

            }

            gv_villageSearch.DataSource = dt;
            ViewState["Data"] = dt;
            gv_villageSearch.DataBind();
           // GridViewNumericCalculation4(ds);
            GridViewNumericCalculation4(dt);
            //-------
            BtnPrintAll.Visible = true;
            gv_villageSearch1.DataSource = dt;
            gv_villageSearch1.DataBind();
            GridViewNumericCalculation4DT(dt);
            BtnExcelExport.Visible = true;
            BtnPdfExport.Visible = true;
            BtnPrintAll.Visible = true;
            btn_print.Visible = true;

        }
        else
        {
            BtnExcelExport.Visible = false;
            BtnPdfExport.Visible = false;
            BtnPrintAll.Visible = false;
            btn_print.Visible = false;

            BtnPrintAll.Visible = false;
            btn_print.Visible = false;
            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }

       
    }
    public void displayVillage3()
    {
        //string res_id = ddlselectreserve.SelectedValue.ToString();//Request.QueryString["RSRV_ID"].ToString();
        // string res_id = Session["RESERVEID"].ToString();//Request.QueryString["RSRV_ID"].ToString();
        //if (TxtVillageName.Text == "")
        //{
        //    TxtVillageName.Text = null;
        //}
        //if (TxtVillageCode.Text == "")
        //{
        //    TxtVillageCode.Text = null;
        //}
        string VillageName = string.Empty;
        if (ddlselectname.SelectedValue == "")
        {
            VillageName = null;
        }
        else
        {
            VillageName = ddlselectname.SelectedItem.Text.Trim();
        }
        string villcode = string.Empty;
        if (ddlselectcode.SelectedValue == "")
        {
            villcode = null;
        }
        else
        {
            villcode = ddlselectcode.SelectedItem.Text.Trim();
        }
        //-----
        string ddval = string.Empty;
        if (DDlStatus.SelectedIndex != 0)
        {
            ddval = DDlStatus.SelectedValue;
        }
        else
        {
            ddval = null;
        }
      //  DataSet ds = RDb.Proc_VillageSearchByReserve3(TxtVillageName.Text, TxtVillageCode.Text, ddval);
        DataSet ds = RDb.Proc_VillageSearchByReserve3(VillageName, villcode, ddval);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            //----18june---------
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;

            if (this.ViewState["SortExpression"] != null)
            {

                dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());

            }

            gv_villageSearch.DataSource = dt;
            ViewState["Data"] = dt;
            gv_villageSearch.DataBind();
            //GridViewNumericCalculation4(ds);
            GridViewNumericCalculation4(dt);
            //-------
            BtnPrintAll.Visible = true;
            gv_villageSearch1.DataSource = dt;
            gv_villageSearch1.DataBind();
            GridViewNumericCalculation4DT(dt);

            BtnExcelExport.Visible = true;
            BtnPdfExport.Visible = true;
            BtnPrintAll.Visible = true;
            btn_print.Visible = true;
        }
        else
        {

            BtnExcelExport.Visible = false;
            BtnPdfExport.Visible = false;
            BtnPrintAll.Visible = false;
            btn_print.Visible = false;

            BtnPrintAll.Visible = false;
            btn_print.Visible = false;
            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    public void displayVillage2()
    {
        
        //if (TxtVillageName.Text == "")
        //{
        //    TxtVillageName.Text = null;
        //}
        //if (TxtVillageCode.Text == "")
        //{
        //    TxtVillageCode.Text = null;
        //}
        string VillageName = string.Empty;
        if (ddlselectname.SelectedValue == "")
        {
            VillageName = null;
        }
        else
        {
            VillageName = ddlselectname.SelectedItem.Text.Trim();
        }
        string villcode = string.Empty;
        if (ddlselectcode.SelectedValue == "")
        {
            villcode = null;
        }
        else
        {
            villcode = ddlselectcode.SelectedItem.Text.Trim();
        }
        //---------
        string ddval = string.Empty;
        if (DDlStatus.SelectedIndex != 0)
        {
            ddval = DDlStatus.SelectedValue;
        }
        else
        {
            ddval = null;
        }
      //  DataSet ds = RDb.Proc_VillageSearchByReserve2(TxtVillageName.Text, TxtVillageCode.Text,ddval);
        DataSet ds = RDb.Proc_VillageSearchByReserve2(VillageName, villcode, ddval);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            //----18june---------
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;

            if (this.ViewState["SortExpression"] != null)
            {

                dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());

            }

            gv_villageSearch.DataSource = dt;
            ViewState["Data"] = dt;
            gv_villageSearch.DataBind();
            //GridViewNumericCalculation4(ds);
            GridViewNumericCalculation4(dt);
            //-------
            BtnPrintAll.Visible = true;
            gv_villageSearch1.DataSource = dt;
            gv_villageSearch1.DataBind();
            GridViewNumericCalculation4DT(dt);

            BtnExcelExport.Visible = true;
            BtnPdfExport.Visible = true;
            BtnPrintAll.Visible = true;
            btn_print.Visible = true;
        }
        else
        {
            BtnExcelExport.Visible = false;
            BtnPdfExport.Visible = false;
            BtnPrintAll.Visible = false;
            btn_print.Visible = false;

            BtnPrintAll.Visible = false;
            btn_print.Visible = false;
            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    public void displayVillage1()
    {
        DataSet ds = new DataSet();
        //string res_id = ddlselectreserve.SelectedValue.ToString();//Request.QueryString["RSRV_ID"].ToString();
        // string res_id = Session["RESERVEID"].ToString();//Request.QueryString["RSRV_ID"].ToString();
        string stateName = string.Empty;
        //if (TxtVillageName.Text == "")
        //{
        //    TxtVillageName.Text = null;
        //}
        //if (TxtVillageCode.Text == "")
        //{
        //    TxtVillageCode.Text = null;
        //}
        //----------------------------
        string VillageName = string.Empty;
        if (ddlselectname.SelectedValue == "")
        {
            VillageName = null;
        }
        else
        {
            VillageName = ddlselectname.SelectedItem.Text.Trim();
        }
        string villcode = string.Empty;
        if (ddlselectcode.SelectedValue == "")
        {
            villcode = null;
        }
        else
        {
            villcode = ddlselectcode.SelectedItem.Text.Trim();
        }
        //----------------
        string ddval = string.Empty;
        if (DDlStatus.SelectedIndex != 0)
        {
            ddval = DDlStatus.SelectedValue;
        }
        else
        {
            ddval = null;
        }
        if (DdlStateName.SelectedValue != "0")
        {
            stateName = DdlStateName.SelectedItem.Text;
        }
        else
        {
            stateName = null;
        }
      //  string DdlTigerVal = string.Empty;
        if (ddlselectreserve.SelectedIndex != 0)
        {
           // ds = RDb.Proc_VillageSearchByReserveRevise1(TxtVillageName.Text, TxtVillageCode.Text, ddval, ddlselectreserve.SelectedItem.Text,null);
            ds = RDb.Proc_VillageSearchByReserveRevise1(VillageName, villcode, ddval, ddlselectreserve.SelectedItem.Text, null);
        }
        else
        {
            //ds = RDb.Proc_VillageSearchByReserveRevise1(TxtVillageName.Text, TxtVillageCode.Text, ddval, null, stateName);
            ds = RDb.Proc_VillageSearchByReserveRevise1(VillageName, villcode, ddval, null, stateName);
        }
      //  DataSet ds = RDb.Proc_VillageSearchByReserve1(TxtVillageName.Text, TxtVillageCode.Text,ddval);
       // DataSet ds = RDb.Proc_VillageSearchByReserveRevise1(TxtVillageName.Text, TxtVillageCode.Text, ddval);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_villageSearch.Visible = true;
            lblnodatafound.Text = "";
            gv_villageSearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_villageSearch.DataBind();
            //----18june---------
            DataTable dt = ds.Tables[0];
            DataView dv = dt.DefaultView;

            if (this.ViewState["SortExpression"] != null)
            {

                dv.Sort = string.Format("{0} {1}", ViewState["SortExpression"].ToString(), this.ViewState["SortOrder"].ToString());

            }

            gv_villageSearch.DataSource = dt;
            ViewState["Data"] = dt;
            gv_villageSearch.DataBind();
            //GridViewNumericCalculation4(ds);
            GridViewNumericCalculation4(dt);
            //-------
            BtnPrintAll.Visible = true;
            //---------------
            gv_villageSearch1.DataSource = dt;
            gv_villageSearch1.DataBind();
            GridViewNumericCalculation4DT(dt);

            BtnExcelExport.Visible = true;
                BtnPdfExport.Visible = true;
                BtnPrintAll.Visible = true;
                btn_print.Visible = true;
        }
        else
        {

            BtnExcelExport.Visible = false;
            BtnPdfExport.Visible = false;
            BtnPrintAll.Visible = false;
            btn_print.Visible = false;

            btn_print.Visible = false;
            BtnPrintAll.Visible = false;
            gv_villageSearch.Visible = false;
            lblnodatafound.Text = "No Record Found";
        }


    }
    protected void gv_villageSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session["UserType"].ToString().Equals("4"))
        {

            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage();
        }
        if (Session["UserType"].ToString().Equals("3"))
        {

            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage3();
        }
        if (Session["UserType"].ToString().Equals("2"))
        {

            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage2();
        }
        if (Session["UserType"].ToString().Equals("1"))
        {
            gv_villageSearch.PageIndex = e.NewPageIndex;
            displayVillage1();

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
    void BindTigerReserveName2()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName2();
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
    void BindTigerReserveName()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new System.Web.UI.WebControls.ListItem("-Select-", "0"));
            DataSet ds = new VillageDB().Ds_BindTigerReserveName();
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
    void printGrid()
    {
        // GridViewgv_villageSearch = new GridView();
        gv_villageSearch1.DataSource = ViewState["Data"];
        gv_villageSearch1.AllowPaging = false;
        gv_villageSearch1.DataBind();
        //Footer rows record sum
        DataTable dt = (DataTable)ViewState["Data"];
        GridViewNumericCalculation4DT(dt);
        //GridViewNumericCalculation4(dt);

        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gv_villageSearch1.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Villages wise Dynamic Report ");
        //  sb.Append("");
        sb.Append("</font></div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gv_villageSearch1.AllowPaging = true;
        gv_villageSearch1.DataBind();


    }
    protected void btn_print_Click1(object sender, EventArgs e)
    {
        int flag = 0;

        //---------------------1---------------
        CheckBox chk1 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox1"); 
        string qurystring = "";
        if (chk1.Checked == true)
        {
            gv_villageSearch1.Columns[0].Visible = true;
            flag = 1;
          
        }
        else
        {
            gv_villageSearch1.Columns[0].Visible = false;
        }
        //---------------------1-----------
        CheckBox CheckStateName = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckStateName");

        if (CheckStateName.Checked == true)
        {
            gv_villageSearch1.Columns[1].Visible = true;
            flag = 1;

        }
        else
        {
            gv_villageSearch1.Columns[1].Visible = false;
        }
        //-----------------2-------------
        CheckBox CheckTigerReservename = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckTigerReservename");

        if (CheckTigerReservename.Checked == true)
        {
            gv_villageSearch1.Columns[2].Visible = true;
            flag = 1;

        }
        else
        {
            gv_villageSearch1.Columns[2].Visible = false;
        }
        //------------------3--------
        CheckBox chk2 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox2");
        if (chk2.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[3].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[3].Visible = false;
        }
//------------------------4-----------
        CheckBox chk3 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox3");
        if (chk3.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[4].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[4].Visible = false;
        }
        //-------------------------5-------------------
        CheckBox chk4 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox4");
        if (chk4.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[5].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[5].Visible = false;

        }
        //------------------6------------------
        CheckBox chk5 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox5");
        if (chk5.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[6].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[6].Visible = false;

        }
        //-----------------7-------------
        CheckBox chk6 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox6");
        if (chk6.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[7].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[7].Visible = false;

        }
        //-------------------8---------------------
        CheckBox chk7 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox7");
        if (chk7.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[8].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }

        else
        {
            gv_villageSearch1.Columns[8].Visible = false;

        }
        //------------9---------------------
        CheckBox chk8 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox8");
        if (chk8.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[9].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[9].Visible = false;

        }
        //-------------10-----------------
        CheckBox chk9 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox9");
        if (chk9.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[10].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[10].Visible = false;

        }
        //--------------------11------------------
        CheckBox chk10 = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox10");
        if (chk10.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[11].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[11].Visible = false;

        }
        //--------------------12--------------------
        //18june

        CheckBox ChkCow_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("ChkCow");
        if (ChkCow_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[12].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[12].Visible = false;

        }
        //-----------------13------------------------
        CheckBox ChkBuffalo_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("ChkBuffalo");
        if (ChkBuffalo_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[13].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }

        else
        {
            gv_villageSearch1.Columns[13].Visible = false;

        }
        //------------------14-----------------------
        CheckBox ChkSheep_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("ChkSheep");

        if (ChkSheep_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[14].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[14].Visible = false;

        }
        //-------------------15-------------
        CheckBox ChkGoat_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("ChkGoat");

        if (ChkGoat_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[15].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }
        else
        {
            gv_villageSearch1.Columns[15].Visible = false;

        }
        //-------------------16-------------------
        CheckBox CheckBox13_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox13");

        if (CheckBox13_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[16].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }

        else
        {
            gv_villageSearch1.Columns[16].Visible = false;

        }
        //---------------------17---------------
        CheckBox CheckBox14_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox14");

        if (CheckBox14_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[17].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }

        else
        {
            gv_villageSearch1.Columns[17].Visible = false;

        }
        //---------------------18-------------
        CheckBox CheckBox15_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox15");

        if (CheckBox15_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[18].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }

        else
        {
            gv_villageSearch1.Columns[18].Visible = false;

        }
        //--------------------19-------------
        CheckBox CheckBox16_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox16");

        if (CheckBox16_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[19].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }

        else
        {
            gv_villageSearch1.Columns[19].Visible = false;

        }
        //-------------------20--------------
        CheckBox CheckBox17_ = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckBox17");

        if (CheckBox17_.Checked == true)
        {
            flag = 1;
            gv_villageSearch1.Columns[20].Visible = true;
            //qurystring = qurystring + "a.VILL_NM" + ",";

        }

        else
        {
            gv_villageSearch1.Columns[20].Visible = false;

        }
        //--------------------21---------------------------
        CheckBox CheckGoogleMap = (CheckBox)gv_villageSearch.HeaderRow.FindControl("CheckGoogleMap");

        if (CheckGoogleMap.Checked == true)
        {
            gv_villageSearch1.Columns[21].Visible = true;
            flag = 1;

        }
        else
        {
            gv_villageSearch1.Columns[21].Visible = false;
        }
        //end 18june
        //------------------------------------------------------
        //--------------------------------------
        if (flag == 0)
        {
            gv_villageSearch1.Visible = false;

            lblnodatafound.Text = "Please Select Atleast one value";
            lblnodatafound.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            gv_villageSearch1.Visible = true;

            this.printGrid();
            gv_villageSearch1.Visible = false;
        }


       
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }  
    protected void btnback_OnClick(object sender, EventArgs e)
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
                            if (Request.QueryString["ModeR"] != null)
                            {
                                Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsoldateReport.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/AUTH/adminpanel/REPORT/VillageSearch.aspx?ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString(), false);
                            }
                        }
                        else
                        {
                            Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/VillageSearch.aspx"), true);
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
    
    protected void lnlbtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("VillageSearchII.aspx?RSRV_ID=" + Session["RESERVEID"].ToString());

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (Session["UserType"].ToString().Equals("4"))
        {

            //FillReserve();
            btn_print.Visible = false;
            gv_villageSearch1.Visible = false;

            displayVillage();
        }
        if (Session["UserType"].ToString().Equals("3"))
        {

            //FillReserve();
            btn_print.Visible = false;
            gv_villageSearch1.Visible = false;

            displayVillage3();
        }
        if (Session["UserType"].ToString().Equals("2"))
        {

            //FillReserve();
            btn_print.Visible = false;
            gv_villageSearch1.Visible = false;

            displayVillage2();
        }
        if (Session["UserType"].ToString().Equals("1"))
        {

            //FillReserve();
            btn_print.Visible = false;
            gv_villageSearch1.Visible = false;

            displayVillage1();
        }
    }
    protected void gv_villageSearch_RowCommand(object sender, GridViewCommandEventArgs e)
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

                        if (e.CommandName == "Edit")
                        {
                            // Response.Redirect(ResolveUrl("GoogleMap.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vcode=" + ddlselectcode.SelectedValue.ToString() + "&vname=" + ddlselectname.SelectedValue.ToString()), false);
                            Response.Redirect(ResolveUrl("GoogleMap.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString()), false);
                            // Response.Redirect(ResolveUrl("map.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString()), false);
                        }
                        if (e.CommandName.Equals("Sort"))
                        {

                            if (ViewState["SortExpression"] != null)
                            {

                                if (this.ViewState["SortExpression"].ToString() == e.CommandArgument.ToString())
                                {

                                    if (ViewState["SortOrder"].ToString() == "ASC")

                                        ViewState["SortOrder"] = "DESC";

                                    else

                                        ViewState["SortOrder"] = "ASC";

                                }

                                else
                                {

                                    ViewState["SortOrder"] = "ASC";

                                    ViewState["SortExpression"] = e.CommandArgument.ToString();

                                }



                            }

                            else
                            {

                                ViewState["SortExpression"] = e.CommandArgument.ToString();

                                ViewState["SortOrder"] = "ASC";

                            }

                        }

                        //Re Bind The Grid to reflect the Sort Order

                        if (Session["UserType"].ToString().Equals("4"))
                        {


                            //FillReserve();
                            btn_print.Visible = false;
                            gv_villageSearch1.Visible = false;

                            displayVillage();
                        }
                        if (Session["UserType"].ToString().Equals("3"))
                        {

                            //FillReserve();
                            btn_print.Visible = false;
                            gv_villageSearch1.Visible = false;

                            displayVillage3();
                        }
                        if (Session["UserType"].ToString().Equals("2"))
                        {

                            //FillReserve();
                            btn_print.Visible = false;
                            gv_villageSearch1.Visible = false;

                            displayVillage2();
                        }
                        if (Session["UserType"].ToString().Equals("1"))
                        {

                            //FillReserve();
                            btn_print.Visible = false;
                            gv_villageSearch1.Visible = false;

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
    protected void gv_villageSearch1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    gv_villageSearch1.Columns[21].Visible = false;
        //    if (Session["UserType"].ToString().Equals("4"))
        //    {
        //        gv_villageSearch1.Columns[1].Visible = false;
        //    }
        //    if (Session["UserType"].ToString().Equals("3"))
        //    {
        //        gv_villageSearch1.Columns[1].Visible = false;
        //    }
        //    if (Session["UserType"].ToString().Equals("2"))
        //    {
        //        gv_villageSearch1.Columns[1].Visible = false;
        //    }
        //    if (Session["UserType"].ToString().Equals("1"))
        //    {
        //        gv_villageSearch1.Columns[1].Visible = true;
        //    }
        //  //  Label lbl = (Label)e.Row.FindControl("LblStatus");

        //    ImageButton img = (ImageButton)e.Row.FindControl("ibEdit");
        //    //if (lbl.Text == "Relocated")
        //    //{
        //    //    img.Visible = true;
        //    //}
        //    //else
        //    //{ img.Visible = false; }
        //}
    }
    protected void gv_villageSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
        {
              if (Session["UserType"].ToString().Equals("4"))
              {
                gv_villageSearch.Columns[1].Visible = false;
              }
                if (Session["UserType"].ToString().Equals("3"))
               {
                  gv_villageSearch.Columns[1].Visible = false;
               }
               if (Session["UserType"].ToString().Equals("2"))
               {
                   gv_villageSearch.Columns[1].Visible = false;
               }
              if (Session["UserType"].ToString().Equals("1"))
              {
                  gv_villageSearch.Columns[1].Visible = true;
              }
                 Label lbl = (Label)e.Row.FindControl("LblStatus");

                 ImageButton img = (ImageButton)e.Row.FindControl("ibEdit");
                if (lbl.Text == "Relocated")
                {
                      img.Visible = true;
                }
               else
               {
                  img.Visible = false;
               }
         }
    }
            
   
   
    
    protected void gv_villageSearch_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gv_villageSearch_RowEditing(object sender, GridViewEditEventArgs e)
    {

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

                        //Response.Redirect("~/AUTH/adminpanel/REPORT/VillagedynmicRpt.aspx");
                        //Response.Clear();
                        //Response.Buffer = true;
                        //Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                        //Response.Charset = "UTF-8";
                        //Response.ContentType = "application/vnd.ms-excel";
                        //using (StringWriter sw = new StringWriter())
                        //{

                        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //    hw.WriteLine("<h1 style=\"text-align:center;\">Villages wise Dynamic Report</h1>");
                        //    hw.WriteLine("<br>");

                        //    //To Export all pages

                        //    gv_villageSearch1.AllowPaging = false;
                        //    if (Session["UserType"].ToString().Equals("4"))
                        //    {

                        //        displayVillage();
                        //    }
                        //    if (Session["UserType"].ToString().Equals("3"))
                        //    {

                        //        displayVillage3();
                        //    }
                        //    if (Session["UserType"].ToString().Equals("2"))
                        //    {

                        //        displayVillage2();
                        //    }
                        //    if (Session["UserType"].ToString().Equals("1"))
                        //    {

                        //        displayVillage1();

                        //    }
                        //    gv_villageSearch1.Visible = true;
                        //    this.gv_villageSearch1.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                        //    this.gv_villageSearch1.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        //    foreach (TableCell cell in gv_villageSearch1.HeaderRow.Cells)
                        //    {
                        //        cell.BackColor = gv_villageSearch1.HeaderStyle.BackColor;
                        //    }
                        //    foreach (GridViewRow row in gv_villageSearch1.Rows)
                        //    {
                        //        row.BackColor = System.Drawing.Color.White;
                        //        foreach (TableCell cell in row.Cells)
                        //        {
                        //            if (row.RowIndex % 2 == 0)
                        //            {
                        //                cell.BackColor = gv_villageSearch1.AlternatingRowStyle.BackColor;
                        //            }
                        //            else
                        //            {
                        //                cell.BackColor = gv_villageSearch1.RowStyle.BackColor;
                        //            }
                        //            cell.CssClass = "textmode";
                        //        }
                        //    }

                        //    gv_villageSearch1.RenderControl(hw);


                        //    //-------------------

                        //    string style = @"<style> .textmode { } </style>";
                        //    Response.Write(style);
                        //    Response.Output.Write(sw.ToString());
                        //    Response.Flush();
                        //    Response.End();


                        //}
                        ////-----------------------------------
                        Response.Clear();
                        Response.Buffer = true;
                        Response.AddHeader("content-disposition", "attachment;filename=" + "MIS_Report" + DateTime.Now + ".xls");
                        Response.Charset = "UTF-8";
                        Response.ContentType = "application/vnd.ms-excel";
                        using (StringWriter sw = new StringWriter())
                        {

                            HtmlTextWriter hw = new HtmlTextWriter(sw);
                            hw.WriteLine("<h1 style=\"text-align:center;\">Villages wise Dynamic Report</h1>");
                            hw.WriteLine("<br>");

                            //To Export all pages

                            gv_villageSearch.AllowPaging = false;
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
                            this.gv_villageSearch.HeaderStyle.ForeColor = System.Drawing.Color.Black;
                            this.gv_villageSearch.HeaderStyle.BackColor = System.Drawing.Color.Green;
                            foreach (TableCell cell in gv_villageSearch.HeaderRow.Cells)
                            {
                                cell.BackColor = gv_villageSearch.HeaderStyle.BackColor;
                            }
                            foreach (GridViewRow row in gv_villageSearch.Rows)
                            {
                                row.BackColor = System.Drawing.Color.White;
                                foreach (TableCell cell in row.Cells)
                                {
                                    if (row.RowIndex % 2 == 0)
                                    {
                                        cell.BackColor = gv_villageSearch.AlternatingRowStyle.BackColor;
                                    }
                                    else
                                    {
                                        cell.BackColor = gv_villageSearch.RowStyle.BackColor;
                                    }
                                    cell.CssClass = "textmode";
                                }
                            }

                            gv_villageSearch.RenderControl(hw);


                            //-------------------

                            string style = @"<style> .textmode { } </style>";
                            Response.Write(style);
                            Response.Output.Write(sw.ToString());
                            Response.Flush();
                            Response.End();

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
                        hw.WriteLine("<h1 style=\"text-align:center;\">Villages wise Dynamic Report</h1>");
                        hw.WriteLine("<br>");
                        // gv1B.Caption = "<h3 style='color:green;'>Family Code:" + "&nbsp;" + lblFamilyCode.Text + "&nbsp;&nbsp;,Head Name:&nbsp;" + lblHeadName.Text + "&nbsp;,Account Holder Name :" + "&nbsp;" + lblholname.Text + "&nbsp;&nbsp;,Bank Name:&nbsp;" + lblbank.Text + "&nbsp;,Branch Name:" + "&nbsp;" + lblbranch.Text + "&nbsp;&nbsp;,Account Number :&nbsp;" + lblacc.Text + "</h3>";
                        gv_villageSearch.HeaderStyle.ForeColor = System.Drawing.Color.White;
                        gv_villageSearch.HeaderStyle.BackColor = System.Drawing.Color.Green;
                        gv_villageSearch.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A1, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        Response.End();
                        gv_villageSearch.AllowPaging = true;
                        gv_villageSearch.DataBind();
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
    protected void BtnPrintAll_Click(object sender, EventArgs e)
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


                        gv_villageSearch1.Visible = true;

                        this.printGrid();
                        gv_villageSearch1.Visible = false;
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
    void printGridAll()
    {
        // GridViewgv_villageSearch = new GridView();
        gv_villageSearch.DataSource = ViewState["Data"];
        gv_villageSearch.AllowPaging = false;
        gv_villageSearch.DataBind();
        //Footer rows record sum
        DataTable dt = (DataTable)ViewState["Data"];
        GridViewNumericCalculation4(dt);

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
        sb.Append(" Villages wise Dynamic Report ");
      //  sb.Append("");
        sb.Append("</font></div>");
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
    public void Fill_VillageCode_And_Name1(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name1(userid);
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

                ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
                ddlselectname.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name2(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name2(userid);
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

                ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
                ddlselectname.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void Fill_VillageCode_And_Name3(int userid)
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name3(userid);
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

                ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
                ddlselectname.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            //lblMsg.ForeColor = System.Drawing.Color.Red;
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

                ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
                ddlselectname.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    void FillVillageCode1()
    {
        ddlselectcode.Items.Clear();
        ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("Select Code", "0"));
        DataSet ds = new VillageDB().FillVillageCode1(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlselectcode.DataSource = ds.Tables[0];
            ddlselectcode.DataTextField = "VILL_CD";
            ddlselectcode.DataValueField = "VILL_ID";
            ddlselectcode.DataBind();

            ddlselectcode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Code", "0"));
        }



        else
        {
            ddlselectcode.Items.Clear();
            ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
        }
    }
    void FillVillageCode2()
    {
        ddlselectcode.Items.Clear();
        ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("Select Code", "0"));
        DataSet ds = new VillageDB().FillVillageCode2(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlselectcode.DataSource = ds.Tables[0];
            ddlselectcode.DataTextField = "VILL_CD";
            ddlselectcode.DataValueField = "VILL_ID";
            ddlselectcode.DataBind();

            ddlselectcode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Code", "0"));
        }



        else
        {
            ddlselectcode.Items.Clear();
            ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
        }
    }
    void FillVillageCode3()
    {
        ddlselectcode.Items.Clear();
        ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("Select Code", "0"));
        DataSet ds = new VillageDB().FillVillageCode3(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlselectcode.DataSource = ds.Tables[0];
            ddlselectcode.DataTextField = "VILL_CD";
            ddlselectcode.DataValueField = "VILL_ID";
            ddlselectcode.DataBind();

            ddlselectcode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Code", "0"));
        }



        else
        {
            ddlselectcode.Items.Clear();
            ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
        }
    }
    void FillVillageCode()
    {
        ddlselectcode.Items.Clear();
        ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("Select Code", "0"));
        DataSet ds = new VillageDB().FillVillageCode(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {

            ddlselectcode.DataSource = ds.Tables[0];
            ddlselectcode.DataTextField = "VILL_CD";
            ddlselectcode.DataValueField = "VILL_ID";
            ddlselectcode.DataBind();

            ddlselectcode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Code", "0"));
        }



        else
        {
            ddlselectcode.Items.Clear();
            ddlselectcode.Items.Add(new System.Web.UI.WebControls.ListItem("No Record", "0"));
        }
    }
    void VillageCode()
    {
        if (ddlselectreserve.SelectedValue == "0")
        {
            if (Session["UserType"].ToString().Equals("1"))
            {


                BindStateName();
                BindTigerReserveName1();
                //FillReserve();
                btn_print.Visible = false;
                BtnPrintAll.Visible = false;
                gv_villageSearch1.Visible = false;

                displayVillage1();
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                FillVillageCode1();

            }
        }
        else
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
                ddlselectcode.DataSource = P_var.dSet.Tables[2];
                ddlselectcode.DataTextField = "VILL_CD";
                ddlselectcode.DataValueField = "VILL_ID";
                ddlselectcode.DataBind();
                ddlselectcode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Code", "0"));
            }
            else
            {
                ddlselectcode.Items.Clear();
                ddlselectcode.Items.Insert(0, new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }
        }
    }
    void VillageName()
    {
        if (ddlselectreserve.SelectedValue == "0")
        {
            if (Session["UserType"].ToString().Equals("1"))
            {
                BindStateName();
                BindTigerReserveName1();
                //FillReserve();
                btn_print.Visible = false;
                BtnPrintAll.Visible = false;
                gv_villageSearch1.Visible = false;

                displayVillage1();
                Fill_VillageCode_And_Name1(Convert.ToInt32(Session["User_Id"]));
                FillVillageCode1();

            }
        }
        else
        {
            VillageCode();
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
                ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Name", "0"));
            }
            else
            {
                ddlselectname.Items.Clear();
                ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("No Record", "0"));
            }
        }///
    }
}