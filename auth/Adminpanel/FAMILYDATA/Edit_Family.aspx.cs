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
using System.Globalization;
using System.Text.RegularExpressions;

public partial class auth_Adminpanel_FAMILYDATA_Edit_Family : System.Web.UI.Page
{
    FamilyDB FMLYDB_Obj = new FamilyDB();
    FamilyEntity FMLY_ENT_Obj = new FamilyEntity();
    Family_DetailEntity FMLYMEM_ENT_Obj = new Family_DetailEntity();
    CommonDB COMMDB_Obj = new CommonDB();
    common com_Obj = new common();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    public static bool check = false;
    static int FMLY_MEMB_IDstatic = 0;
    static string schemeid = "", villid = "";
    static int FinalMemeberyear = 0;
    public static bool flagupdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        CalendarExtender2.EndDate = DateTime.Now;
        CalendarTxtDOB.EndDate = DateTime.Now;
        lblMsg.Text = "";
        lblMsg1.Text = "";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }

        HiddenField2.Value = com_Obj.fordate();
        if (!Page.IsPostBack)
        {
            Filloccupation();
            FillRelation();



            if (Request.QueryString[WebConstant.QueryStringEnum.Familyid] != null && !Request.QueryString[WebConstant.QueryStringEnum.Familyid].Equals(""))
            {

                LoadInfoFamilyId(Request.QueryString[WebConstant.QueryStringEnum.Familyid].ToString());
                BindMembers();

            }
            else
            {
                // Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx"), true);
            }

        }

    }
    public void FillGroup()
    {
        try
        {
            ddlselectrelation.Items.Clear();
            DataSet ds1 = COMMDB_Obj.FillRelation();

            DataTable dt = ds1.Tables[0];
            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddlselectrelation.DataSource = dt;
                ddlselectrelation.DataTextField = "RELATION_NAME";
                ddlselectrelation.DataValueField = "RELATION_ID";
                ddlselectrelation.DataBind();
                ddlselectrelation.Items.Insert(0, new ListItem("Select", "0"));

            }


        }
        catch (Exception e2)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void ddlSelectVillage_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/FAMILYDATA/Edit_Family_Members.aspx?mid=40"));
    }
    public void FieldEmpty18above()
    {
        TxtBnameMobile.Text = string.Empty;
        TxtBankPostAccountNo.Text = string.Empty;
        TxtBankPostOfficeName.Text = string.Empty;
        TxtIFSC.Text = string.Empty;
        TxtBankPostOfficeAdress.Text = string.Empty;
        TxtAadharNo.Text = string.Empty;
    }
    public void FieldEmpty()
    {
        DvPhoto.Visible = false;
        Div1.Visible = false;
        HyperLink1.Text = string.Empty;
        hypfile.Text = string.Empty;
        TxtDOB.Text = string.Empty;
        LblTxtBnameMobile.Text = "";
        lblTxtBankPostAccountNo.Text = "";
        lblTxtBankPostOfficeName.Text = "";
        lblTxtIFSC.Text = "";
        lblTxtBankPostOfficeAdress.Text = "";
        lblTxtAadharNo.Text = "";

        TxtBnameMobile.Text = string.Empty;
        TxtBankPostAccountNo.Text = string.Empty;
        TxtBankPostOfficeName.Text = string.Empty;
        TxtIFSC.Text = string.Empty;
        TxtBankPostOfficeAdress.Text = string.Empty;
        TxtAadharNo.Text = string.Empty;




        txtname.Text = "";
        txtfathername.Text = "";
        txtage.Text = "";
        ddlselectsex.SelectedIndex = 0;

        ddlselectcast.SelectedIndex = 0;
        txtvalidcardnumber.Text = "";
        txtvoter.Text = "";
        txtcontact.Text = "";
        txtpencard.Text = "";
        TxtAdhaarCard.Text = "";
        txtothers.Text = "";
        TxtTransgender.Text = "";
        DdlMaritalStatus.SelectedIndex = 0;
        txtedu.Text = "";
        txtincome.Text = "";
        TxtNoBeneficiary.Text = "";
    }
    public string GetCuttOffDateofVillage(int VillageID)
    {
        string cuttoffdate = string.Empty;
        try
        {


            DataSet ds = new DataSet();
            ds = new VillageDB().GetCuttOffDate(VillageID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cuttoffdate = ds.Tables[0].Rows[0]["CuttOffDate1"].ToString();

            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
        return cuttoffdate;
    }
    public int calculateAge(int Dobyear, int Dobmonth, int Dobday, int CuttoffYear, int cuttoffmonth, int cuttoffday)
    {
        int Years = 0;

        DateTime Birth = new DateTime(Dobyear, Dobmonth, Dobday);
        DateTime Today = new DateTime(CuttoffYear, cuttoffmonth, cuttoffday);
        //TimeSpan Span = Today - Birth;
        //DateTime Age = DateTime.MinValue + Span;
        //// note: MinValue is 1/1/1 so we have to subtract...
        //Years = Age.Year - 1;
        //int Months = Age.Month - 1;
        //int Days = Age.Day - 1;
        //--------------------------------
        //int age = 0;Cutt-off Date
        LblCuttoffDateShow.Text = "On the basis of Cutt-off Date :[" + Today.ToString() + "] Age will be calculated: ";
        Years = Today.Year - Birth.Year;
        if (Today.DayOfYear < Birth.DayOfYear)
            Years = Years - 1;
        //--------------------------------
        return Years;
    }
    protected void TxtDOB_TextChanged(object sender, EventArgs e)
    {
        FieldEmpty18above();

        DvValidAgePanel.Visible = false;
        LblMsgDbo.Text = string.Empty;
        string DobAge = string.Empty;
        DobAge = common.insertDate(TxtDOB.Text.Trim()).ToString();
        string[] words1 = DobAge.Split('/');

        string dd1 = null;
        string MM1 = null;
        string yyyy1 = null;
        yyyy1 = words1[0];
        MM1 = words1[1];
        dd1 = words1[2];

        string MMddyyyy = MM1 + "/" + dd1 + "/" + yyyy1;
        var parameterDate = DateTime.ParseExact(MMddyyyy, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        var todaysDate = DateTime.Today;

        if (parameterDate < todaysDate)
        {


            int Dobyear = 0;
            int Dobmonth = 0;
            int Dobday = 0;

            int CuttoffYear = 0;
            int cuttoffmonth = 0;
            int cuttoffday = 0;
            string cuttoffdate = string.Empty;
            cuttoffdate = GetCuttOffDateofVillage(Convert.ToInt32(Request.QueryString["vid"].ToString()));

            if (cuttoffdate != string.Empty)
            {
                string[] words = cuttoffdate.Split('/');

                string dd = null;
                string MM = null;
                string yyyy = null;
                dd = words[0];
                MM = words[1];
                yyyy = words[2];

                cuttoffday = Convert.ToInt32(dd);
                cuttoffmonth = Convert.ToInt32(MM);
                CuttoffYear = Convert.ToInt32(yyyy);
            }

            if (TxtDOB.Text.Trim() != "")
            {
                DobAge = common.insertDate(TxtDOB.Text.Trim()).ToString();
            }
            if (DobAge != string.Empty)
            {//2018/06/01
                string[] words = DobAge.Split('/');

                string dd = null;
                string MM = null;
                string yyyy = null;
                yyyy = words[0];
                MM = words[1];
                dd = words[2];

                Dobday = Convert.ToInt32(dd);
                Dobmonth = Convert.ToInt32(MM);
                Dobyear = Convert.ToInt32(yyyy);
                //txtage.Text = year.ToString();
            }
            if (cuttoffdate != string.Empty && DobAge != string.Empty)
            {
                FinalMemeberyear = calculateAge(Dobyear, Dobmonth, Dobday, CuttoffYear, cuttoffmonth, cuttoffday);
                txtage.Text = FinalMemeberyear.ToString();
                if (FinalMemeberyear >= 18)
                {
                    DvValidAgePanel.Visible = true;
                    FieldEmpty18above();
                }
                else
                {
                    if (FinalMemeberyear >= 1)
                    {

                    }
                    else
                    {

                        LblMsgDbo.Text = "Age should not be less then 1 year!";
                        //  return;
                    }
                    DvValidAgePanel.Visible = false;
                    FieldEmpty18above();
                }
            }

        }
        else
        {
            // Response.Write("<script>alert('DOB Should Be Less Than Or Equal to Today's Date!!');</script>");
            LblMsgDbo.Text = "DOB Should Be Less Than Or Equal to Today's Date!!";
        }

        ModalPopupExtender1.Show();

    }
    public void LoadInfoFamilyId(string familyid)
    {

        try
        {
            ViewState["fid"] = familyid;

            DataSet ds = FMLYDB_Obj.Proc_DisplayFamilyById(Request.QueryString["vid"].ToString(), Request.QueryString["family_id"].ToString(),null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblvillcode.Text = ds.Tables[0].Rows[0]["VILL_CD"].ToString();
                lblvillname.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();

                // lblstatename.Text = ds.Tables[0].Rows[0][5].ToString();
                lbldistrict.Text = ds.Tables[0].Rows[0]["DistName"].ToString();
                // lblreaserve.Text = ds.Tables[0].Rows[0][6].ToString();
                lbltehsil.Text = ds.Tables[0].Rows[0]["Tehsil_Name"].ToString();
                lblgp.Text = ds.Tables[0].Rows[0]["GramPanchayatName"].ToString();
            }
            DataSet ds1 = FMLYDB_Obj.Display_Info_Family_By_FamilyID(ViewState["fid"].ToString());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                txtrashancard.Text = ds1.Tables[0].Rows[0]["FMLY_VALID_ID_NAME"].ToString();
                txtreloplace.Text = ds1.Tables[0].Rows[0]["RELOATION_PLACE"].ToString();
                txtsurdate.Text = ds1.Tables[0].Rows[0]["SURVEYDATE"].ToString();
                lblcode.Text = ds1.Tables[0].Rows[0]["FMLY_REG_CD"].ToString();
                schemeid = ds1.Tables[0].Rows[0]["SCHM_ID"].ToString();
                DDLSchemeopted.SelectedValue = schemeid;
                if (DDLSchemeopted.SelectedValue == "4")
                {
                    dvOtherOption.Visible = true;
                    txtOtherOption.Text = ds1.Tables[0].Rows[0]["Scheme_ID_Other_Details"].ToString();
                }
                else
                {
                    dvOtherOption.Visible = false;
                    txtOtherOption.Text = string.Empty;
                }
                    villid = ds1.Tables[0].Rows[0]["VILL_ID"].ToString(); ;

                if (schemeid == "1")
                {
                    ListItem li = new ListItem("Not Applicable", "-1");
                    ddlselectgroupname.Items.Add(li);
                    ddlselectgroupname.SelectedValue = "-1";
                    ddlselectgroupname.Enabled = false;


                }
                else if (schemeid == "2")
                {

                    FillGroup();
                    ddlselectgroupname.Enabled = true;
                    ddlselectgroupname.SelectedValue = ds1.Tables[0].Rows[0]["GROUP_NM"].ToString();


                }
                else if (schemeid == "3")
                {

                    ListItem li = new ListItem("Not Applicable", "-1");
                    ddlselectgroupname.Items.Add(li);
                    ddlselectgroupname.SelectedValue = "-1";
                    ddlselectgroupname.Enabled = false;

                }
                else if (schemeid == "4")
                {
                    ListItem li = new ListItem("Not Applicable", "-1");
                    ddlselectgroupname.Items.Add(li);
                    ddlselectgroupname.SelectedValue = "-1";
                    ddlselectgroupname.Enabled = false;

                }

                //DataSet ds2 = FMLYDB_Obj.GetGroupNameByGroupId(ds1.Tables[0].Rows[0]["GROUP_NM"].ToString());
                //if (ds2.Tables[0].Rows.Count > 0)
                //{
                //    //lblgroupname.Text = ds2.Tables[0].Rows[0][0].ToString();
                //}
                //else {
                //    //lblgroupname.Text = "Not Applicable";
                //}

                txtrashan.Text = ds1.Tables[0].Rows[0]["FMLY_VALID_ID_NO"].ToString();
                txtagri.Text = ds1.Tables[0].Rows[0]["FMLY_AGRI_LND"].ToString();
                txtresland.Text = ds1.Tables[0].Rows[0]["FMLY_RESI_LND"].ToString();
                if (txtresland.Text.Equals("0"))
                {
                    ddlselectstatusresland.SelectedValue = "0";
                }
                else
                {
                    ddlselectstatusresland.SelectedValue = ds1.Tables[0].Rows[0]["RESI_LND_STS"].ToString();
                }
                txtwells.Text = ds1.Tables[0].Rows[0]["FMLY_WELLS"].ToString();
                txttrees.Text = ds1.Tables[0].Rows[0]["FMLY_TREES"].ToString();
                txtotherassets.Text = ds1.Tables[0].Rows[0]["FMLY_OTHR_ASSETS"].ToString();
                txtlivestock.Text = ds1.Tables[0].Rows[0]["FMLY_LIVESTOCK"].ToString();
                txtcownbuff.Text = ds1.Tables[0].Rows[0]["FMLY_COW_BUFF"].ToString();
                txtsheepngoat.Text = ds1.Tables[0].Rows[0]["FMLY_SHEEP_GOAT"].ToString();
                txtotheranimal.Text = ds1.Tables[0].Rows[0]["FMLY_OTHER_ANML"].ToString();
                txtcomments.Text = ds1.Tables[0].Rows[0]["COMMENT"].ToString();

                //5june naren
                TxtNoCow.Text = ds1.Tables[0].Rows[0]["NoCows"].ToString();
                TxtBuffalo.Text = ds1.Tables[0].Rows[0]["NoBuffalo"].ToString();
                TxtGoat.Text = ds1.Tables[0].Rows[0]["NoGoat"].ToString();
                TxtSheep.Text = ds1.Tables[0].Rows[0]["NoSheep"].ToString();

                bool relo_status = Convert.ToBoolean(ds1.Tables[0].Rows[0]["FMLY_STAT"]);
                if (relo_status == false)
                {
                    ddlselectRelocation.SelectedValue = "0";
                }
                else
                {
                    ddlselectRelocation.SelectedValue = "1";
                }
            }
        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }


    protected void gvFormembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFormembers.PageIndex = e.NewPageIndex;
        BindMembers();

    }
    protected void gvFormembers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Edit_Family_Members.aspx?" + WebConstant.QueryStringEnum.FamilyMemberID + "=" + e.CommandArgument.ToString() + "&fmid=" + Request.QueryString[WebConstant.QueryStringEnum.Familyid].ToString() + "&pindex=" + Request.QueryString["pindex"].ToString() + "&vid=" + Request.QueryString["vid"].ToString() + "&sid=" + Request.QueryString["sid"].ToString() + "&rid=" + Request.QueryString["rid"].ToString() + "&fid=" + Request.QueryString["fid"].ToString()), false);



            }
            if (e.CommandName == "Delete")
            {
                DataSet dsforcheckdelete = FMLYDB_Obj.CheckMemberID(e.CommandArgument.ToString());
                if (dsforcheckdelete.Tables[0].Rows.Count > 0)
                {
                    if (dsforcheckdelete.Tables[0].Rows[0][0].ToString().Equals("1"))
                    {
                        lblMsg.Text = "You Can Not Delete Head Of The Family Details";
                        return;
                    }

                }
                int i = FMLYDB_Obj.Delete_All_Members_For_Edit(e.CommandArgument.ToString());
                if (i > 0)
                {
                    //Audit_ObjDB.AUDIT_TRAIL(Session["LoginID"].ToString(), "DELETE", 1);
                    RegisterClientScriptBlock("showmessage",
          "<script language=\"JavaScript\"> alert('Member Deleted Successfully.') </script>");
                    lblMsg.Text = "Member Deleted Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;

                    BindMembers();
                }
                else
                {
                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                    //lblMsg.Text = e1.Message.ToString();
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void gvFormembers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvFormembers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ib = (ImageButton)e.Row.FindControl("imgDelete");
                ib.CommandName = "Delete";
                ib.CommandArgument = DataBinder.Eval(e.Row.DataItem, "FMLY_MEMB_ID").ToString();

                ImageButton ibe = (ImageButton)e.Row.FindControl("ibEdit");
                ibe.CommandName = "Edit";
                ibe.CommandArgument = DataBinder.Eval(e.Row.DataItem, "FMLY_MEMB_ID").ToString();
            }
            foreach (GridViewRow row in gvFormembers.Rows)
            {

                Label relationwithhead = row.FindControl("lblrelation") as Label;
                if (relationwithhead.Text == "1")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Head of the Family";

                }
                if (relationwithhead.Text == "2")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Father";

                }
                if (relationwithhead.Text == "3")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Mother";

                }
                if (relationwithhead.Text == "4")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Brother";

                }
                if (relationwithhead.Text == "5")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Sister";

                }
                if (relationwithhead.Text == "6")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Wife";

                }
                if (relationwithhead.Text == "7")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Other";

                }
                if (relationwithhead.Text == "8")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Son";


                }
                if (relationwithhead.Text == "9")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Daughter";


                }
                if (relationwithhead.Text == "10")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Daughter In Law";


                }
                if (relationwithhead.Text == "11")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Grand Son";


                }
                if (relationwithhead.Text == "12")
                {
                    Label relationwithhead1 = row.FindControl("lblrelation") as Label;
                    relationwithhead1.Text = "Grand Daughter";


                }


            }

        }
        catch (Exception e1)
        {
            //lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }

    protected void gvFormembers_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    public void BindMembers()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = FMLYDB_Obj.Display_All_Members_ForEdit(null, Request.QueryString[WebConstant.QueryStringEnum.Familyid].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvFormembers.Visible = true;
                //forpaging.Visible = true;
                gvFormembers.DataSource = ds.Tables[0].DefaultView;
                gvFormembers.DataBind();
            }
            else
            {

                gvFormembers.Visible = false;
                // forpaging.Visible = false;

            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
            // lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void DDLSchemeopted_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(DDLSchemeopted.SelectedValue) == 4)
        {
            dvOtherOption.Visible = true;
        }
        else
        {
            dvOtherOption.Visible = false;
        }

        //if (DDLSchemeopted.SelectedValue == "1")
        //{
        //    ListItem li = new ListItem("Not Applicable", "-1");
        //    ddlselectgroupname.Items.Add(li);
        //    ddlselectgroupname.SelectedValue = "-1";
        //    ddlselectgroupname.Enabled = false;
        //}
        //else if (DDLSchemeopted.SelectedValue == "2")
        //{
        //    FillGroup();
        //    ddlselectgroupname.Enabled = true;

        //}
        //else if (DDLSchemeopted.SelectedValue == "3")
        //{

        //    ListItem li = new ListItem("Not Applicable", "-1");
        //    ddlselectgroupname.Items.Add(li);
        //    ddlselectgroupname.SelectedValue = "-1";
        //    ddlselectgroupname.Enabled = false;
        //}
        //else if (DDLSchemeopted.SelectedValue == "4")
        //{

        //    ListItem li = new ListItem("Not Applicable", "-1");
        //    ddlselectgroupname.Items.Add(li);
        //    ddlselectgroupname.SelectedValue = "-1";
        //    ddlselectgroupname.Enabled = false;
        //}
    }



        public void ResetAllFields()
    {
        txtname.Text = "";
        ddlselectrelation.SelectedValue = "0";
        txtage.Text = "";

        //txtfathername.Text = "";

        ddlselectsex.SelectedValue = "0";
        ddlselectcast.SelectedValue = "0";
        txtvoter.Text = "";
        txtcontact.Text = "";
        txtedu.Text = "";
        ddlselectoccupation.SelectedValue = "0";
        txtincome.Text = "";
    }

    protected void ddlselectsex_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlselectoccupation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
    }
    protected void ddlselectrelation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
    }

    public void Filloccupation()
    {
        try
        {
            ddlselectoccupation.Items.Clear();
            DataSet ds = COMMDB_Obj.FillOccupations();
            if (ds.Tables[0].Rows.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                ListItem list = new ListItem("Select Occupation", "0");
                ddlselectoccupation.Items.Add(list);
                int i = 0;
                while (count > 0)
                {
                    ListItem list1 = new ListItem(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
                    ddlselectoccupation.Items.Add(list1);
                    count--;
                    i++;
                }
            }
        }
        catch (Exception e4)
        { }
    }

    public void FillRelation()
    {
        ddlselectrelation.Items.Clear();
        try
        {
            DataSet ds = COMMDB_Obj.FillRelation();
            if (ds.Tables[0].Rows.Count > 0)
            {
                int count = ds.Tables[0].Rows.Count;
                ListItem list = new ListItem("Select Relation", "0");
                ddlselectrelation.Items.Add(list);
                int i = 1;
                while (count > 0)
                {
                    ListItem list1 = new ListItem(ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][0].ToString());
                    ddlselectrelation.Items.Add(list1);
                    count--;
                    i++;
                }
            }
        }
        catch (Exception e4)
        { }
    }
    bool checkValidation8Above()
    {//Regex(@"^[a-zA-Z0-9_@.-]*$");
        Regex objAlphaPattern = new Regex(@"^[a-zA-Z0-9 ]*$");


        lblTxtBankPostAccountNo.Text = "";
        bool chk = false;

        if (TxtBnameMobile.Text == "")
        {
            LblTxtBnameMobile.Text = "Please enter Beneficiary's .";
            return false;
        }
        else
        {
            bool sts = objAlphaPattern.IsMatch(TxtBnameMobile.Text);
            if (sts == false)
            {
                LblTxtBnameMobile.Text = "Don't use special character.";
                return false;
            }
            else
            {
                LblTxtBnameMobile.Text = "";
            }
        }
        if (TxtBankPostAccountNo.Text == "")
        {
            lblTxtBankPostAccountNo.Text = "Please enter bank post office account no.";
            return false;
        }
        else
        {
            bool sts = objAlphaPattern.IsMatch(TxtBankPostAccountNo.Text);
            if (sts == false)
            {
                lblTxtBankPostAccountNo.Text = "Don't use special character.";
                return false;
            }
            else
            {
                lblTxtBankPostAccountNo.Text = "";
            }
        }
        if (TxtBankPostOfficeName.Text == "")
        {
            lblTxtBankPostOfficeName.Text = "Please enter post office name.";
            return false;
        }
        else
        {
            bool sts = objAlphaPattern.IsMatch(TxtBankPostOfficeName.Text);
            if (sts == false)
            {
                lblTxtBankPostOfficeName.Text = "Don't use special character.";
                return false;
            }
            else
            {
                lblTxtBankPostOfficeName.Text = "";
            }
        }
        if (TxtIFSC.Text == "")
        {
            lblTxtIFSC.Text = "Please enter ifsc code.";
            return false;
        }
        else
        {
            bool sts = objAlphaPattern.IsMatch(TxtIFSC.Text);
            if (sts == false)
            {
                lblTxtIFSC.Text = "Don't use special character.";
                return false;
            }
            else
            {
                lblTxtIFSC.Text = "";
            }
        }
        if (TxtBankPostOfficeAdress.Text == "")
        {
            lblTxtBankPostOfficeAdress.Text = "Please enter bank post office number.";
            return false;
        }
        else
        {
            bool sts = objAlphaPattern.IsMatch(TxtBankPostOfficeAdress.Text);
            if (sts == false)
            {
                lblTxtBankPostOfficeAdress.Text = "Don't use special character.";
                return false;
            }
            else
            {
                lblTxtBankPostOfficeAdress.Text = "";
            }
        }
        if (TxtAadharNo.Text == "")
        {
            lblTxtAadharNo.Text = "Please enter aadhar no.";
            return false;
        }
        else
        {
            bool sts = objAlphaPattern.IsMatch(TxtAadharNo.Text);
            if (sts == false)
            {
                lblTxtAadharNo.Text = "Don't use special character.";
                return false;
            }
            else
            {
                lblTxtAadharNo.Text = "";
            }
        }
        return true;

    }
    protected void ImgbtnSubmitMember_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            if (FinalMemeberyear >= 1)
            {
                try
                {

                    #region collapse1
                    ViewState["fid"] = Request.QueryString[WebConstant.QueryStringEnum.Familyid].ToString();
                    FMLYMEM_ENT_Obj._FMLY_MEMB_NM = txtname.Text.Trim();
                    if (ddlselectrelation.SelectedValue.Equals(0))
                    {
                        FMLYMEM_ENT_Obj._FMLY_MEMB_REL = 0;
                    }
                    else
                    {
                        FMLYMEM_ENT_Obj._FMLY_MEMB_REL = Convert.ToInt32(ddlselectrelation.SelectedValue);
                    }
                    FMLYMEM_ENT_Obj._FATHER_NM = "Not Applicable";
                    if (txtage.Text.Trim() != "")
                    {
                        FMLYMEM_ENT_Obj._FMLY_MEMB_AGE = Convert.ToInt32(txtage.Text.Trim());
                    }
                    else
                    {
                        FMLYMEM_ENT_Obj._FMLY_MEMB_AGE = 0;
                    }

                    FMLYMEM_ENT_Obj._FMLY_MEMB_SEX = Convert.ToInt32(ddlselectsex.SelectedValue);
                    FMLYMEM_ENT_Obj._FMLY_MEMB_CAST = Convert.ToInt32(ddlselectcast.SelectedValue);
                    FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NO = common.RemoveUnnecessaryHtmlTagHtml(txtvoter.Text.Trim());
                    FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NAME = common.RemoveUnnecessaryHtmlTagHtml(txtvalidcardnumber.Text.Trim());
                    FMLYMEM_ENT_Obj._FMLY_MEMB_CONT_NO = txtcontact.Text.Trim();
                    FMLYMEM_ENT_Obj._FMLY_MEMB_EDU = common.RemoveUnnecessaryHtmlTagHtml(txtedu.Text.Trim());
                    FMLYMEM_ENT_Obj._FMLY_MEMB_OCC = Convert.ToInt32(ddlselectoccupation.SelectedValue);
                    if (txtincome.Text.Trim() == "")
                    {
                        FMLYMEM_ENT_Obj._FMLY_MEMB_ANUL_INCM = 0;
                    }
                    else
                    {
                        FMLYMEM_ENT_Obj._FMLY_MEMB_ANUL_INCM = Convert.ToDouble(txtincome.Text);
                    }
                    //6june
                    FMLYMEM_ENT_Obj.DOB = common.insertDate(TxtDOB.Text.Trim()).ToString();
                    FMLYMEM_ENT_Obj.PenCard = txtpencard.Text.Trim();
                    FMLYMEM_ENT_Obj.AdhaarCard = TxtAdhaarCard.Text.Trim();
                    FMLYMEM_ENT_Obj.Others = txtothers.Text.Trim();
                    FMLYMEM_ENT_Obj.Transgender = TxtTransgender.Text.Trim();
                    FMLYMEM_ENT_Obj.NoBeneficiary = TxtNoBeneficiary.Text.Trim();

                    if (DdlMaritalStatus.SelectedValue != "0")
                    {
                        FMLYMEM_ENT_Obj.MaritalStatus = DdlMaritalStatus.SelectedValue;
                    }


                    FMLYMEM_ENT_Obj.BankNameMobile = TxtBnameMobile.Text.Trim();
                    FMLYMEM_ENT_Obj.BankPostAccountNo = TxtBankPostAccountNo.Text.Trim();
                    FMLYMEM_ENT_Obj.BankPostOfficeName = TxtBankPostOfficeName.Text.Trim();
                    FMLYMEM_ENT_Obj.IFSC = TxtIFSC.Text.Trim();
                    FMLYMEM_ENT_Obj.BankPostOfficeAdress = TxtBankPostOfficeAdress.Text.Trim();
                    FMLYMEM_ENT_Obj.AadharNo = TxtAadharNo.Text.Trim();
                    FMLYMEM_ENT_Obj.IdentityCardPhotoTitle = TxtCardFile.Text.Trim();
                    //end 6june
                    //---------self profile pic only for self not for other----------------
                    if (hypfile.Text != string.Empty)
                    {
                        FMLYMEM_ENT_Obj.Photo = hypfile.Text.Trim();
                    }
                    else
                    {
                        if (fileUpload_Menu.PostedFile != null && fileUpload_Menu.PostedFile.InputStream.Length != 0)
                        {
                            p_Var.ext = System.IO.Path.GetExtension(this.fileUpload_Menu.PostedFile.FileName);
                            p_Var.ext = p_Var.ext.ToUpper();
                            if (p_Var.ext.Equals(".jpg") || p_Var.ext.Equals(".JPG") || p_Var.ext.Equals(".jpeg") || p_Var.ext.Equals(".JPEG") || p_Var.ext.Equals(".png") || p_Var.ext.Equals(".PNG"))
                            {

                                p_Var.Path = ResolveUrl("~") + "WriteReadData/Familyaadhar";
                                p_Var.Filename = com_Obj.getUniqueFileName(fileUpload_Menu.FileName.ToString(), Server.MapPath(p_Var.Path), System.IO.Path.GetFileNameWithoutExtension(fileUpload_Menu.PostedFile.FileName), p_Var.ext);
                                p_Var.Path = ResolveUrl("~") + "WriteReadData/Familyaadhar/" + p_Var.Filename;
                                fileUpload_Menu.PostedFile.SaveAs(Server.MapPath(p_Var.Path));
                                FMLYMEM_ENT_Obj.Photo = p_Var.Filename;
                            }
                        }
                    }
                    //---------------------------------
                    //---------Card details photo----------------
                    if (HyperLink1.Text != string.Empty)
                    {
                        FMLYMEM_ENT_Obj.IdentityCardPhoto = HyperLink1.Text.Trim();
                    }
                    else
                    {
                        if (fileUploadCardDetails.PostedFile != null && fileUploadCardDetails.PostedFile.InputStream.Length != 0)
                        {
                            p_Var.ext = System.IO.Path.GetExtension(this.fileUploadCardDetails.PostedFile.FileName);
                            p_Var.ext = p_Var.ext.ToUpper();
                            if (p_Var.ext.Equals(".jpg") || p_Var.ext.Equals(".JPG") || p_Var.ext.Equals(".jpeg") || p_Var.ext.Equals(".JPEG") || p_Var.ext.Equals(".png") || p_Var.ext.Equals(".PNG"))
                            {

                                p_Var.Path = ResolveUrl("~") + "WriteReadData/Familyaadhar";
                                p_Var.Filename = com_Obj.getUniqueFileName(fileUploadCardDetails.FileName.ToString(), Server.MapPath(p_Var.Path), System.IO.Path.GetFileNameWithoutExtension(fileUploadCardDetails.PostedFile.FileName), p_Var.ext);
                                p_Var.Path = ResolveUrl("~") + "WriteReadData/Familyaadhar/" + p_Var.Filename;
                                fileUploadCardDetails.PostedFile.SaveAs(Server.MapPath(p_Var.Path));
                                FMLYMEM_ENT_Obj.IdentityCardPhoto = p_Var.Filename;
                            }
                        }
                    }
                    //---------------------------------
                    #endregion
                    if (chkCardPhoto() == true)
                    {
                        if (FinalMemeberyear >= 18)
                        {
                            #region collaspse
                            if (checkValidation8Above() == true)
                            {
                                bool check = FMLYDB_Obj.Add_Family_Members_From_Original(FMLYMEM_ENT_Obj, ViewState["fid"].ToString());
                                if (check == true)
                                {
                                    ResetAllFields();
                       //             RegisterClientScriptBlock("showmessage",
                       //"<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                                  
                                    lblMsg.Text = "New Member Inserted Successfully";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                    BindMembers();

                                    ModalPopupExtender1.Hide();
                                    new AuditTrailDB().AUDIT_TRAIL(Session["LoginID"].ToString(), "ADD", 3);

                                }
                                else
                                {
                                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                    lblMsg.ForeColor = System.Drawing.Color.Red;

                                }
                            }
                            else
                            {
                                ModalPopupExtender1.Show();
                            }
                            #endregion
                        }

                        else
                        {
                            #region collapse1
                            bool check = FMLYDB_Obj.Add_Family_Members_From_Original(FMLYMEM_ENT_Obj, ViewState["fid"].ToString());
                            if (check == true)
                            {
                                ResetAllFields();
                             //   RegisterClientScriptBlock("showmessage", "<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                               // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);

                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                                lblMsg.Text = "New Member Inserted Successfully";
                                lblMsg.ForeColor = System.Drawing.Color.Green;
                                BindMembers();

                                ModalPopupExtender1.Hide();
                                new AuditTrailDB().AUDIT_TRAIL(Session["LoginID"].ToString(),

            "ADD", 3);

                            }
                            else
                            {
                                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                lblMsg.ForeColor = System.Drawing.Color.Red;

                            }
                            #endregion
                        }
                    }
                    else
                    {

                        ModalPopupExtender1.Show();
                    }
                }
                catch (Exception e4)
                {
                }
            }
            else
            {
                ModalPopupExtender1.Show();
                LblMsgDbo.Text = "Age should not be less then 1 year!";
                //  return;
            }

            //------------------       

        }
    }
    protected void imgbtnreset_Click(object sender, EventArgs e)
    {
        ResetAllFields();
        ModalPopupExtender1.Show();
    }
    protected void imgbtncancel1_Click(object sender, EventArgs e)
    {
        ResetAllFields();
        ModalPopupExtender1.Hide();
    }

    protected void ImgbtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {

                if (!txtsurdate.Text.Equals(""))
                {

                    //if (Convert.ToDateTime(common.insertDate(txtsurdate.Text)) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                    //{
                    //    lblMsg.Text = "Date of Survey Can Not Be Greater Than Today's Date";
                    //    return;
                    //}
                    FMLY_ENT_Obj._SURVEY_DT = common.insertDate(txtsurdate.Text.Trim()).ToString();
                }
                else
                {
                    FMLY_ENT_Obj._SURVEY_DT = null;
                }
                if (DDLSchemeopted.SelectedValue.ToString().Equals("0"))
                {
                    lblMsg.Text = "Please Select Scheme";
                    return;
                }
                if (DDLSchemeopted.SelectedValue.ToString().Equals("2"))
                {
                    if (ddlselectgroupname.SelectedValue.ToString().Equals("0"))
                    {
                        lblMsg.Text = "Please Select Group";
                        return;
                    }

                }

                FMLY_ENT_Obj._FMLY_VALID_ID_NO = common.RemoveUnnecessaryHtmlTagHtml(txtrashan.Text.Trim());
                FMLY_ENT_Obj._FMLY_VALID_ID_NAME = common.RemoveUnnecessaryHtmlTagHtml(txtrashancard.Text.Trim());
                if (txtagri.Text.Trim() == "")
                {
                    FMLY_ENT_Obj._FMLY_AGRI_LND = 0;
                }
                else
                {
                    FMLY_ENT_Obj._FMLY_AGRI_LND = Convert.ToDouble(txtagri.Text);
                }
                if (txtresland.Text.Trim() == "")
                {

                    FMLY_ENT_Obj._FMLY_RESI_LND = 0;
                    FMLY_ENT_Obj._RESI_LND_STS = 0;
                }
                else
                {

                    FMLY_ENT_Obj._FMLY_RESI_LND = Convert.ToDouble(txtresland.Text.Trim());
                    if (ddlselectstatusresland.SelectedValue.ToString().Equals("0"))
                    {
                        if (FMLY_ENT_Obj._FMLY_RESI_LND == 0)
                        {

                        }
                        else
                        {

                            lblMsg.Text = "Please Select Residential Property Status";
                            lblMsg.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                    else
                    {
                        FMLY_ENT_Obj._RESI_LND_STS = Convert.ToInt32(ddlselectstatusresland.SelectedValue);
                    }
                }
                if (txtwells.Text.Trim() == "")
                {
                    FMLY_ENT_Obj._FMLY_WELLS = 0;
                }
                else
                {
                    FMLY_ENT_Obj._FMLY_WELLS = Convert.ToInt32(txtwells.Text.Trim());
                }
                if (txttrees.Text.Trim() == "")
                {
                    FMLY_ENT_Obj._FMLY_TREES = 0;
                }
                else
                {
                    FMLY_ENT_Obj._FMLY_TREES = Convert.ToInt32(txttrees.Text.Trim());
                }

                if (txtotherassets.Text.Trim() == "")
                {
                    FMLY_ENT_Obj._FMLY_OTHR_ASSETS = 0;
                }
                else
                {
                    FMLY_ENT_Obj._FMLY_OTHR_ASSETS = Convert.ToInt32(txtotherassets.Text.Trim());
                }

                if (txtlivestock.Text.Trim() == "")
                {
                    FMLY_ENT_Obj._FMLY_LIVESTOCK = 0;
                }
                else
                {
                    FMLY_ENT_Obj._FMLY_LIVESTOCK = Convert.ToInt32(txtlivestock.Text.Trim());
                }
                if (txtcownbuff.Text.Trim() == "")
                {
                    FMLY_ENT_Obj._FMLY_COW_BUFF = 0;
                }
                else
                {
                    FMLY_ENT_Obj._FMLY_COW_BUFF = Convert.ToInt32(txtcownbuff.Text.Trim());
                }
                if (txtsheepngoat.Text.Trim() == "")
                {
                    FMLY_ENT_Obj._FMLY_SHEEP_GOAT = 0;
                }
                else
                {
                    FMLY_ENT_Obj._FMLY_SHEEP_GOAT = Convert.ToInt32(txtsheepngoat.Text.Trim());
                }
                if (txtotheranimal.Text.Trim() == "")
                {
                    FMLY_ENT_Obj._FMLY_OTHER_ANML = 0;
                }
                else
                {
                    FMLY_ENT_Obj._FMLY_OTHER_ANML = Convert.ToInt32(txtotheranimal.Text.Trim());
                }
                //if (FMLY_ENT_Obj._FMLY_LIVESTOCK != FMLY_ENT_Obj._FMLY_SHEEP_GOAT + FMLY_ENT_Obj._FMLY_COW_BUFF + FMLY_ENT_Obj._FMLY_OTHER_ANML)
                //{
                //    lblMsg.Text = "Total Livestock Must Be Equal to Total OF(Cow&Buffalio,Sheep&Goat or Other Animal)";
                //    lblMsg.ForeColor = System.Drawing.Color.Red;
                //    return;
                //}
                FMLY_ENT_Obj._COMMENT = common.RemoveUnnecessaryHtmlTagHtml(txtcomments.Text.Trim());
                FMLY_ENT_Obj._RELOATION_PLACE = txtreloplace.Text.Trim();
                if (ddlselectRelocation.SelectedValue.ToString().Equals("-1"))
                {
                    lblMsg.Text = "Please Select Relocation Status ";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {


                    FMLY_ENT_Obj._FMLY_STAT = Convert.ToInt32(ddlselectRelocation.SelectedValue);
                }



                FMLY_ENT_Obj._SCHM_ID = Convert.ToInt32(DDLSchemeopted.SelectedValue);
                if (DDLSchemeopted.SelectedValue == "4")
                {
                    FMLY_ENT_Obj.OtherOptions = txtOtherOption.Text.Trim();
                }
                else
                {
                    FMLY_ENT_Obj.OtherOptions = string.Empty;
                }
                
                if (ddlselectgroupname.SelectedValue.ToString().Equals("0"))
                {
                    lblMsg.Text = "Please Select Group Name";
                    return;

                }
                FMLY_ENT_Obj._GROUP_NM = Convert.ToInt32(ddlselectgroupname.SelectedValue);
                //5june2018
                if (TxtNoCow.Text.Trim() == "")
                {
                    FMLY_ENT_Obj.NoCows = 0;

                }
                else
                {
                    FMLY_ENT_Obj.NoCows = Convert.ToInt32(TxtNoCow.Text.Trim());
                }
                if (TxtBuffalo.Text.Trim() == "")
                {
                    FMLY_ENT_Obj.NoBuffalo = 0;

                }
                else
                {
                    FMLY_ENT_Obj.NoBuffalo = Convert.ToInt32(TxtBuffalo.Text.Trim());
                }
                if (TxtSheep.Text.Trim() == "")
                {
                    FMLY_ENT_Obj.NoSheep = 0;
                }
                else
                {
                    FMLY_ENT_Obj.NoSheep = Convert.ToInt32(TxtSheep.Text.Trim());
                }
                if (TxtGoat.Text.Trim() == "")
                {
                    FMLY_ENT_Obj.NoGoat = 0;
                }
                else
                {
                    FMLY_ENT_Obj.NoGoat = Convert.ToInt32(TxtGoat.Text.Trim());
                }

                bool check = FMLYDB_Obj.Update_Family(FMLY_ENT_Obj, ViewState["fid"].ToString());
                if (check == true)
                {
                    //RegisterClientScriptBlock("showmessage",
                    //"<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                    
                    lblMsg.Text = "Changes Updated Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);

                }
                else
                {
                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                    //lblMsg.Text = e1.Message.ToString() + "LoadInfoFamilyId";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }


            }




        }


        catch (Exception e4)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e4.Message.ToString();

            //lblMsg.Text = e1.Message.ToString() + "LoadInfoFamilyId";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }




    }
    protected void ImgbtnCancel_Click(object sender, EventArgs e)
    {
        LoadInfoFamilyId(Request.QueryString[WebConstant.QueryStringEnum.Familyid].ToString());
        BindMembers();
    }
    protected void ImgbtnBack_Click(object sender, EventArgs e)
    {
      // Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx?pindex=" + Request.QueryString["pindex"].ToString() + "&vid=" + Request.QueryString["vid"].ToString() + "&sid=" + Request.QueryString["sid"].ToString() + "&rid=" + Request.QueryString["rid"].ToString() + "&fid=" + Request.QueryString["fid"].ToString()));
        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx?id=" + Convert.ToInt32(Request.QueryString["vid"])));
    }

    protected void btnAddmember_Click(object sender, EventArgs e)
    {
        LblMsgDbo.Text = "";
        TxtDOB.Text = "";
        FieldEmpty();
        ModalPopupExtender1.Show();
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

    protected void ValidateFileSize1(object source, ServerValidateEventArgs args)
    {
        string data = args.Value;
        args.IsValid = false;
        double filesize = fileUploadCardDetails.FileContent.Length;
        if (filesize > 3145728)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
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
    protected void CustomValidator3_ServerValidate1(object source, ServerValidateEventArgs args)
    {

        bool s;
        string ext1 = System.IO.Path.GetExtension(fileUploadCardDetails.PostedFile.FileName);
        ext1 = ext1.ToLower();
        if (ext1 == ".pdf")
        {
            s = miscellBL.GetActualFileType_pdf(fileUploadCardDetails.PostedFile.InputStream);
        }
        else
        {
            s = miscellBL.GetActualFileType(fileUploadCardDetails.PostedFile.InputStream);
        }
        if (fileUploadCardDetails.PostedFile.ContentLength == 0)
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
    bool chkHeadPhoto()
    {
        LblfileUpload_Menu.Text = "";
        bool chk = false;
        if (!fileUpload_Menu.HasFile)
        {
            if (hypfile.Text != string.Empty)
            {
                LblfileUpload_Menu.Text = "";
                return true;
            }
            else
            {
                LblfileUpload_Menu.Text = "Please upload your photo.";
                return false;
            }
        }

        return true;
    }
    bool chkCardPhoto()
    {
        LblCardMsge.Text = "";
        bool chk = false;
        if (fileUploadCardDetails.HasFile)
        {
            if (TxtCardFile.Text == string.Empty)
            {
                LblCardMsge.Text = "Please enter card detail title.";
                return false;
            }

        }

        return true;
    }
    protected void BtnDeleteAttachment_Click(object sender, EventArgs e)
    {
        try
        {
            if (FMLY_MEMB_IDstatic != 0)
            {
                FMLYMEM_ENT_Obj.FMLY_MEMB_IDs = FMLY_MEMB_IDstatic;
                FMLYMEM_ENT_Obj.Action = 1;
                check = FMLYDB_Obj.AttachmentDeletePhoto(FMLYMEM_ENT_Obj);

                if (check == true)
                {
                    // LoadInfoMemberId(FMLY_MEMB_IDstatic.ToString());
                    ModalPopupExtender1.Show();
                    // Response.Write("<script>alert('Attachment has deleted successfully!');</script>");
                }
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }
    protected void BtnDeleteAttachment_Click1(object sender, EventArgs e)
    {
        try
        {
            if (FMLY_MEMB_IDstatic != 0)
            {
                FMLYMEM_ENT_Obj.FMLY_MEMB_IDs = FMLY_MEMB_IDstatic;
                FMLYMEM_ENT_Obj.Action = 1;
                check = FMLYDB_Obj.AttachmentDeleteCardPhoto(FMLYMEM_ENT_Obj);

                if (check == true)
                {
                    // LoadInfoMemberId(FMLY_MEMB_IDstatic.ToString());
                    ModalPopupExtender1.Show();
                    // Response.Write("<script>alert('Attachment has deleted successfully!');</script>");
                }
            }
        }
        catch (Exception er)
        {
            throw;
        }
    }

}