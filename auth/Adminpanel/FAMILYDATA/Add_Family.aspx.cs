using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Text.RegularExpressions;

public partial class auth_Adminpanel_FAMILYDATA_Add_Family : System.Web.UI.Page
{
    public String characters = "abcdeCDEfghijkzMABFHIJKLNOlmnopqrPQRSTstuvwxyUVWXYZ";
    FamilyDB FMLYDB_Obj = new FamilyDB();
    GroupDB GRPDB_Obj = new GroupDB();
    Family_DetailEntity FMLYMEM_ENT_Obj = new Family_DetailEntity();
    FamilyEntity FMLY_ENT_Obj = new FamilyEntity();
    FamilyAsstsEvaluationEntity FMLYASSTEVA_ENT_Obj = new FamilyAsstsEvaluationEntity();
    VillageDB VILL_DB_Obj = new VillageDB();
    CommonDB COMMDB_Obj = new CommonDB();
    common com_Obj = new common();
    AuditTrailDB Audit_ObjDB = new AuditTrailDB();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Project_Variables p_Var = new Project_Variables();
    public static string CheckHeadMember = string.Empty;
    public static bool check = false;
    static int FMLY_MEMB_IDstatic = 0;
    static bool flag = false;
    static string reservecode = "", mid = "", villcode = "";
    static int relation = 0;
    static bool flagupdate = false, flagself = false;
    static double val = 0.0;
    static int FinalMemeberyear = 0;
    int resultfamily = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LblCuttoffDateShow.Text = "";
        CalendarExtender2.EndDate = DateTime.Now;
        CalendarTxtDOB.EndDate = DateTime.Now;
        lblMsg.Text = "";
        lblMsg1.Text = "";
        
        HiddenField2.Value = com_Obj.fordate();
        try
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"), true);
                return;
            }
            //if (Session["VillageId"] != null && !(Session["VillageId"].ToString().Equals("")))
            //{


            if (!Page.IsPostBack)
            {


                Random rand = new Random();
                ViewState["randnumber"] = rand.Next(000001, 999999);

                ViewState["fid"] = ViewState["randnumber"].ToString();
                HiddenField1.Value = DateTime.Now.ToString();
                Filloccupation();

                flagupdate = false;
                // txtcode.Text = "";
                if (Session["UserType"].ToString().Equals("4") || Session["UserType"].ToString().Equals("1"))
                {

                    BindStateName();
                    //  ddlselectgroupname.Enabled = false;
                    flag = false;
                    if (Session["UserType"].ToString().Equals("1") || Session["UserType"].ToString().Equals("4") )
                    {
                        DataSet ds = new DataSet();
                        int VillageID = Convert.ToInt32(Request.QueryString["id"]);
                        ds = new VillageDB().Fill_StateVillage(VillageID);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DdlStateName.SelectedValue = ds.Tables[0].Rows[0]["id"].ToString();
                            BindTigerReserveName(); 
                            FillVillage();
                            
                            ddlselectreserve.SelectedValue = ds.Tables[0].Rows[0]["TigerReserveid"].ToString();
                            ddlselectname.SelectedValue = Convert.ToInt32(Request.QueryString["id"]).ToString();
                           
                        }
                       
                        //ddlselectreserve.Items.Add(new ListItem("Select", "0"));
                        //ddlselectname.Items.Add(new ListItem("Select", "0"));

                        // Fill_VillageCode_And_Name1(0);
                    }
                    else
                    {
                        FillVillage();
                    }
                    if (ddlselectname.SelectedItem.Text != "Select Name")
                    {
                        String p = UniqueNumber();
                        txtcode.Text = p;
                        FMLY_ENT_Obj._FMLY_REG_CD = txtcode.Text.Trim();
                    }
                    else
                    {
                        txtcode.Text = "";
                    }
                    txtcode.Enabled = false;
                    flag = true;
                    FillAll();

                    GenerateFamilyCode();
                }
                if (Session["UserType"].ToString().Equals("4"))
                {
                    VillageDB VillDB_Obj = new VillageDB();
                    DataSet ds = new DataSet();

                    DdlStateName.SelectedValue = Convert.ToInt32(Session["sStateID"]).ToString();
                    BindTigerReserveName();
                   
                    ddlselectname.SelectedValue = Convert.ToString(Session["sTreserveID"]);
                    DdlStateName.Enabled = false;
                    ddlselectname.Enabled = false;
                    ddlselectreserve.Enabled = false;
                    int ID = Convert.ToInt32(Request.QueryString["id"]);
                    ddlselectreserve.SelectedValue = Convert.ToString(ID);
                    ddlselectname.SelectedValue = Convert.ToInt32(Session["Vill"]).ToString(); 
                }

                FMLYDB_Obj.Delete_All_Members_Via_Family_Id_From_Temp(Convert.ToInt64(ViewState["randnumber"]));
                //--------------
                //fileUpload_Menu

            }

            //}//
        }
        catch (Exception e4)
        {

        }

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
    public void Fill_VillageCode_And_Name1()
    {
        try
        {
            VillageDB VillDB_Obj = new VillageDB();
            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ddlselectname.Items.Add(new ListItem("Select Name", "0"));
            int CmnStateUserID = Convert.ToInt32(ddlselectreserve.SelectedValue);
            ds = VillDB_Obj.Fill_VillageCode_TigerReserve(CmnStateUserID);
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

                //ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public string UniqueNumber()
    {
        Random unique1 = new Random();
        string s = "FC";
        int unique;
        int n = 0;
        while (n < 10)
        {
            if (n % 2 == 0)
            {
                s += unique1.Next(10).ToString();

            }
            else
            {
                unique = unique1.Next(52);
                if (unique < this.characters.Length)
                    s = String.Concat(s, this.characters[unique]);
            }
            //Label2.Text = s.ToString();
            n++;
        }
        return s;
    }
    public void FillAll()
    {
        if(Convert.ToInt32(Session["VillageId"]) !=0)
        {
            DataSet ds = VILL_DB_Obj.Get_OthersIDs_By_VillId(Session["VillageId"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblvillcode.Text = ds.Tables[0].Rows[0][0].ToString();
                lblvillname.Text = ds.Tables[0].Rows[0][1].ToString();
                DataSet ds1 = COMMDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(ds.Tables[0].Rows[0][2].ToString(), ds.Tables[0].Rows[0][4].ToString(), ds.Tables[0].Rows[0][3].ToString(), ds.Tables[0].Rows[0][5].ToString(), ds.Tables[0].Rows[0][6].ToString());
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lblstatename.Text = ds1.Tables[0].Rows[0][0].ToString();
                    lbldistrict.Text = ds1.Tables[1].Rows[0][0].ToString();
                    lblreaserve.Text = ds1.Tables[2].Rows[0][0].ToString();
                    lbltehsil.Text = ds1.Tables[3].Rows[0][0].ToString();
                    lblgp.Text = ds1.Tables[4].Rows[0][0].ToString();
                    reservecode = ds1.Tables[2].Rows[0][1].ToString();
                }

            }
        }
       
    }
    #region Function for Village Bind
    public void FillVillage()
    {
        try
        {

            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            int ID = Convert.ToInt32(Request.QueryString["id"]);
            ds = new VillageDB().Fill_Names(Convert.ToInt32(Session["User_Id"]), ID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //List<string> list = new List<string>();
                //ListItem li2 = new ListItem("Select Name", "0");
                //ddlselectname.Items.Add(li2);
                //list = com_Obj.FillDropDownList(ds, 0, "VILL_NM");
                //int i = list.Count - 1;
                //int j = 0;
                //while (j <= i)
                //{
                //    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j][2].ToString());

                //    ddlselectname.Items.Add(li);
                //    ++j;

                //}
                ddlselectname.DataSource =ds.Tables[0];
                ddlselectname.DataTextField = "VILL_NM";
                ddlselectname.DataValueField = "VILL_ID";
                ddlselectname.DataBind();
                ddlselectname.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
                Session["Vill"] = ds.Tables[0].Rows[0]["VILL_ID"].ToString();
                ddlselectname.SelectedValue = Session["Vill"].ToString();

            }
            else
            {
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }
        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    #endregion
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
    protected void ddlselectrelation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
        if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
        {
            flagself = true;
            trPhoto.Visible = true;
        }
        else
        {
            flagself = false;
            trPhoto.Visible = false;
        }
    }
    protected void ImgbtnCancel1_Click(object sender, ImageClickEventArgs e)
    {
        txtname.Text = "";
        ModalPopupExtender1.Show();
    }
    protected void ddlselectsex_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void Filloccupation()
    {
        try
        {
            ddlselectoccupation.Items.Clear();
            DataSet ds = COMMDB_Obj.FillOccupations();
            int[] idarray = { 1, 2, 3, 5, 6, 7, 4, 0 };
            var abc = from rowdata in ds.Tables[0].AsEnumerable()
                      where idarray.Contains(Convert.ToInt32(rowdata[0]))
                      select rowdata;
            DataTable dt = new DataTable();
            dt.Columns.Add("OCCUPATION_ID",typeof(int));
            dt.Columns.Add("OCCUPATION_NAME",typeof(string));

            foreach (var ab in idarray)
            {

                
                    DataRow result = (from temp in ds.Tables[0].AsEnumerable()
                                      where Convert.ToInt32(temp[0])==ab
                                      select temp).FirstOrDefault();

                    if (result != null) { dt.Rows.Add(result.ItemArray); }
               

               

            }
            
            
            if (dt.Rows.Count > 0)
            {
                
                int count = dt.Rows.Count;
                ListItem list = new ListItem("Select Occupation", "0");
                ddlselectoccupation.Items.Add(list);
                int i = 0;
                while (count > 0)
                {
                    ListItem list1 = new ListItem(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
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
                int i = 0;
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
        {
        }
    }
    protected void txtfathername_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlselectscheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlselectscheme.SelectedValue) == 4)
        {
            dvOtherOption.Visible = true;
        }
        else
        {
            dvOtherOption.Visible = false;
        }

        //if (ddlselectscheme.SelectedValue.ToString().Equals("0"))
        //{
        //    ddlselectgroupname.Items.Clear();

        //}
        //if (ddlselectscheme.SelectedValue.ToString().Equals("2"))
        //{

        //    FillGroup();


        //}
        //else
        //{
        //    ddlselectgroupname.Items.Clear();
        //    ddlselectgroupname.Items.Add(new ListItem("Not Applicable ", "0"));
        //}
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {

    }
    public void ResetAllFields()
    {
        txtname.Text = "";

        txtage.Text = "";

        txtfathername.Text = "";
        txtvalidcardnumber.Text = "";
        ddlselectsex.SelectedValue = "0";
        ddlselectcast.SelectedValue = "0";
        txtvoter.Text = "";
        txtcontact.Text = "";
        txtedu.Text = "";
        ddlselectoccupation.SelectedValue = "0";
        txtincome.Text = "";
        DdlStateName.SelectedValue = "0";
    }
    public void GenerateFamilyId()
    {
        DataSet ds = new DataSet();
        ds = FMLYDB_Obj.GenerateFamilyId();
        if (ds.Tables[0].Rows.Count > 0)
        {
            int id = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + 1;
            if (id > 9)
            {
                ViewState["fid"] = FMLY_ENT_Obj._FMLY_ID = "0" + id.ToString();
            }
            else if (id < 10)
            {
                ViewState["fid"] = FMLY_ENT_Obj._FMLY_ID = "00" + id.ToString();
            }
            else
            {
                ViewState["fid"] = FMLY_ENT_Obj._FMLY_ID = id.ToString();
            }



        }
    }
    public void GenerateFamilyCode()
    {
        DataSet ds = new DataSet();
        if (Session["UserType"].ToString().Equals("4"))
        {
            GetReserve_and_Village_Code();
            ds = FMLYDB_Obj.GenerateFamilyCode(reservecode + villcode);
        }
        else
        {
            ds = FMLYDB_Obj.GenerateFamilyCode(reservecode + lblvillcode.Text.Trim());
        }
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (!ds.Tables[0].Rows[0][0].ToString().Equals(""))
            {
                int code = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString().Substring(5, 3)) + 1;
                if (code < 10)
                {
                    txtcode.Text = "00" + code.ToString();
                }
                else if (code < 100)
                {
                    txtcode.Text = "0" + code.ToString();
                }
                else
                {
                    txtcode.Text = code.ToString();
                }



            }
            else
            {
                txtcode.Text = "001";
            }
        }
        else
        {
            txtcode.Text = "001";
        }

    }
    public void GetReserve_and_Village_Code()
    {
        DataSet ds = new DataSet();
        //ds = FMLYDB_Obj.GetReserveCode(ddlselectreserve.SelectedValue.ToString());
        if (Convert.ToInt32(Session["RESERVEID"]) != 0)
        {
            ds = FMLYDB_Obj.GetReserveCode(Session["RESERVEID"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                reservecode = ds.Tables[0].Rows[0][0].ToString();
                DataSet ds1 = new DataSet();
                ds1 = FMLYDB_Obj.GetVillageCode(ddlselectname.SelectedValue.ToString());
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    villcode = ds1.Tables[0].Rows[0][0].ToString();
                }
            }
        }
      
    }
    public bool CheckDuplicacyFor_Family_Code()
    {
        DataSet ds = new DataSet();
        if (Session["UserRole"].ToString().Equals("1"))
        {
            ds = FMLYDB_Obj.CheckDuplicacyFor_Family_Code(reservecode + villcode + txtcode.Text.Trim());
        }
        else
        {
            ds = FMLYDB_Obj.CheckDuplicacyFor_Family_Code(reservecode + lblvillcode.Text.Trim() + txtcode.Text.Trim());
        }
        if (ds.Tables[0].Rows.Count > 0)
        {

            return false;

        }
        else
        {
            if (Session["UserRole"].ToString().Equals("1"))
            {
                FMLY_ENT_Obj._FMLY_REG_CD = reservecode + villcode + txtcode.Text.Trim();
                return true;
            }
            else
            {
                FMLY_ENT_Obj._FMLY_REG_CD = reservecode + lblvillcode.Text.Trim() + txtcode.Text.Trim();
                return true;
            }
        }

    }
    public void BindMembers()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = FMLYDB_Obj.Display_All_Members_For_Add_new(Convert.ToInt64(ViewState["randnumber"]));
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
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
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
                FMLY_MEMB_IDstatic = Convert.ToInt32(e.CommandArgument);
                LoadInfoMemberId(e.CommandArgument.ToString());

                // Response.Redirect("User_Edit.aspx?" + WebConstant.QueryStringEnum.UserID + "=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Delete")
            {
                FMLYDB_Obj.Delete_All_Members(e.CommandArgument.ToString());
                //Audit_ObjDB.AUDIT_TRAIL(Session["LoginID"].ToString(), "DELETE", 1);
                BindMembers();
            }

        }

        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
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
                    relationwithhead1.Text = "Head Of Family";

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
                    relationwithhead1.Text = "Daughter in Law";

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
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }
    public void LoadInfoMemberId(string memberid)
    {
        LblHeadingPopUp.Text = "";
        try
        {
            mid = memberid;
            DataSet ds = new DataSet();
            ds = FMLYDB_Obj.Display_All_Members(memberid);
            if (ds.Tables[0].Rows.Count > 0)
            {//FillRelation()
                ResetAllFields();
                txtname.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_NM"].ToString();
                if (ds.Tables[0].Rows[0]["FMLY_MEMB_REL"].ToString() == "1")
                {
                    CheckHeadMember = "headexist";
                    LblHeadingPopUp.Text = "Please Enter Family Head Details";
                    DvPhoto.Visible = true;
                    string filename = ds.Tables[0].Rows[0]["Photo"].ToString();
                    if (filename != "")
                    {
                        BtnDeleteAttachment.Visible = true;
                    }
                    else
                    {
                        BtnDeleteAttachment.Visible = false;
                    }
                    hypfile.NavigateUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + filename;
                    hypfile.Text = filename;
                    FillRelation();
                    ddlselectrelation.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_REL"].ToString();
                }
                else
                {
                    CheckHeadMember = "memberexist";
                    LblHeadingPopUp.Text = "Please Enter Family Member Details";
                    DvPhoto.Visible = false;
                    ddlselectrelation.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_REL"].ToString();
                }
                //---------------
                //card details photo
                string cardphoto = ds.Tables[0].Rows[0]["IdentityCardPhoto"].ToString();
                if (cardphoto != "")
                {
                    Div1.Visible = true;
                    BtnDeleteAttachmentCard.Visible = true;
                }
                else
                {
                    Div1.Visible = false;
                    BtnDeleteAttachmentCard.Visible = false;
                }
                HyperLink1.NavigateUrl = ResolveUrl("~/WriteReadData/Familyaadhar/") + cardphoto;
                HyperLink1.Text = cardphoto;
                //------------------
                TxtCardFile.Text = ds.Tables[0].Rows[0]["IdentityCardPhotoTitle"].ToString();
                //--------------
                txtage.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_AGE"].ToString();
                if (!ds.Tables[0].Rows[0]["FATHER_NM"].ToString().Equals("NULL"))//9
                {

                    txtfathername.Text = ds.Tables[0].Rows[0]["FATHER_NM"].ToString();
                }
                else
                {

                }
                txtvalidcardnumber.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_ID_NAME"].ToString();
                ddlselectsex.SelectedValue =
                ddlselectcast.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_CAST"].ToString();
                txtvoter.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_ID_NO"].ToString();
                if (ds.Tables[0].Rows[0]["FMLY_MEMB_CONT_NO"].ToString() == "0")
                {
                    txtcontact.Text = "";

                }
                else
                {
                    txtcontact.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_CONT_NO"].ToString();
                }

                txtedu.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_EDU"].ToString();
                ddlselectoccupation.SelectedValue = ds.Tables[0].Rows[0]["FMLY_MEMB_OCC"].ToString();
                txtincome.Text = (Convert.ToDouble(ds.Tables[0].Rows[0]["FMLY_MEMB_ANUL_INCM"])).ToString();

                //-------------------
                TxtDOB.Text = ds.Tables[0].Rows[0]["DOB1"].ToString();
                TxtBnameMobile.Text = ds.Tables[0].Rows[0]["BankNameMobile"].ToString();
                txtBeniAddress.Text = ds.Tables[0].Rows[0]["BenAddress"].ToString();
                txtBeniMobile.Text = ds.Tables[0].Rows[0]["BenMobile"].ToString();
                TxtBankPostAccountNo.Text = ds.Tables[0].Rows[0]["BankPostAccountNo"].ToString();
                TxtBankPostOfficeName.Text = ds.Tables[0].Rows[0]["BankPostOfficeName"].ToString();
                TxtIFSC.Text = ds.Tables[0].Rows[0]["IFSC"].ToString();
                TxtBankPostOfficeAdress.Text = ds.Tables[0].Rows[0]["BankPostOfficeAdress"].ToString();
                TxtAadharNo.Text = ds.Tables[0].Rows[0]["AadharNo"].ToString();

                txtpencard.Text = ds.Tables[0].Rows[0]["PenCard"].ToString();
                TxtAdhaarCard.Text = ds.Tables[0].Rows[0]["AdhaarCard"].ToString();
                txtothers.Text = ds.Tables[0].Rows[0]["Others"].ToString();
                TxtTransgender.Text = ds.Tables[0].Rows[0]["Transgender"].ToString();
                DdlMaritalStatus.SelectedValue = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();

                TxtNoBeneficiary.Text = ds.Tables[0].Rows[0]["NoBeneficiary"].ToString();
                //------------------------------------
                ModalPopupExtender1.Show();
                flagupdate = true;

            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void gvFormembers_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    public void ResetAllFieldsOfFamily()
    {
        txtsurdate.Text = "";
        ddlselectstatusresland.SelectedValue = "0";
        txtrashancard.Text = "";
        txtagri.Text = "";
        ddlselectscheme.SelectedValue = "0";
        if (ddlselectname.SelectedValue == "0")
        {
            txtOtherOption.Text = string.Empty;
        }
        txtresland.Text = "";
        txtwells.Text = "";
        txttrees.Text = "";
        txtotherassets.Text = "";
        txtlivestock.Text = "";
        txtcownbuff.Text = "";
        txtsheepngoat.Text = "";
        txtotheranimal.Text = "";
        txtcomments.Text = "";
        ddlselectgroupname.Items.Clear();
        GenerateFamilyCode();

        //if (!ddlselectreserve.SelectedValue.ToString().Equals("0"))
        //{
        //    GenerateFamilyCode();
        //}

        //if (Session["UserRole"].ToString().Equals("1"))
        //{
        //    FillStates();

        //}




    }
    protected void ddlselectgroupname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void FillGroup()
    {
        try
        {
            ddlselectgroupname.Items.Clear();
            DataSet ds = new DataSet();
            if (Session["UserRole"].ToString().Equals("1"))
            {
                ds = COMMDB_Obj.Fill_Group_Name(ddlselectname.SelectedValue.ToString());
            }
            else
            {
                ds = COMMDB_Obj.Fill_Group_Name(Session["VillageId"].ToString());
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                List<string> list = new List<string>();
                ListItem listforstate = new ListItem("Select GROUP", "0");
                ddlselectgroupname.Items.Add(listforstate);

                list = com_Obj.FillDropDownList(ds, 0, "GRP_NM");
                int i = list.Count - 1;
                int j = 0;

                while (j <= i)
                {
                    ListItem li = new ListItem(list[j].ToString(), ds.Tables[0].Rows[j++][0].ToString());
                    ddlselectgroupname.Items.Add(li);
                }
            }
            else
            {
                ListItem li = new ListItem("No Record", "0");
                ddlselectgroupname.Items.Add(li);
                lblMsg.Text = "Please Enter Group Details first For The Selected Village";
                return;

            }
        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlselectscheme.SelectedValue = "0";
        ddlselectgroupname.SelectedValue = "0";
        if (ddlselectname.SelectedItem.Text != "Select Name")
        {
            String p = UniqueNumber();
            txtcode.Text = p;
            txtcode.Enabled = false;
            FMLY_ENT_Obj._FMLY_REG_CD = txtcode.Text.Trim();

        }
        else
        {

            txtcode.Text = "";

            //ddlselectscheme.Enabled = false;
            //ddlselectgroupname.Enabled = false;

            //txtcode.Text = "";
        }
    }
    protected void ddlselectoccupation_SelectedIndexChanged(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
    }
    public int calculateAge(int Dobyear, int Dobmonth, int Dobday, int CuttoffYear, int cuttoffmonth, int cuttoffday)
    {
        LblCuttoffDateShow.Text = "";
        int Years = 0;

        DateTime Birth = new DateTime(Dobyear, Dobmonth, Dobday);
        DateTime Today = new DateTime(CuttoffYear, cuttoffmonth, cuttoffday);//CUtt of date mention in Already
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

        //if (parameterDate < todaysDate)
        //{


        int Dobyear = 0;
        int Dobmonth = 0;
        int Dobday = 0;

        int CuttoffYear = 0;
        int cuttoffmonth = 0;
        int cuttoffday = 0;
        string cuttoffdate = string.Empty;
        cuttoffdate = GetCuttOffDateofVillage(Convert.ToInt32(ddlselectname.SelectedValue));

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
                if (CheckHeadMember == "headexist")
                {
                    if (FinalMemeberyear >= 18)
                    {

                    }
                    else
                    {

                        LblMsgDbo.Text = "Age should not be less then 18!";
                        //  return;
                    }
                }
                if (CheckHeadMember == "memberexist")
                {
                    if (FinalMemeberyear >= 1)
                    {

                    }
                    else
                    {

                        LblMsgDbo.Text = "Age should not be less then 1!";
                        //  return;
                    }
                }
                DvValidAgePanel.Visible = false;
                FieldEmpty18above();
            }
        }

        ModalPopupExtender1.Show();

    }
    bool checkValidation8Above()
    {//Regex(@"^[a-zA-Z0-9_@.-]*$");
        Regex objAlphaPattern = new Regex(@"^[a-zA-Z0-9 ]*$");


        lblTxtBankPostAccountNo.Text = "";
        bool chk = false;

        if (TxtBnameMobile.Text == "")
        {
            LblTxtBnameMobile.Text = "Please enter Beneficiary's Name.";
            return false;
        }

        else
        {
            //bool sts = objAlphaPattern.IsMatch(TxtBnameMobile.Text);
            //if (sts == false)
            //{
            //    LblTxtBnameMobile.Text = "Don't use special character.";
            //    return false;
            //}
            //else
            //{
            //    LblTxtBnameMobile.Text = "";
            //}
        }
        if (txtBeniAddress.Text == "")
        {
            lblBeniAddress.Text = "Please enter Beneficiary Address.";
            return false;
        }
        if (txtBeniMobile.Text == "")
        {
            lblBeniMobile.Text = "Please enter Mobile Number.";
            return false;
        }
        else
        {
            bool sts = objAlphaPattern.IsMatch(txtBeniMobile.Text);
            if (sts == false)
            {
                lblBeniMobile.Text = "Don't use special character.";
                return false;
            }
            else
            {
                lblBeniMobile.Text = "";
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
                fileUpload_Menu.Focus();
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
    public void FieldEmpty18above()
    {
        TxtBnameMobile.Text = string.Empty;
        txtBeniAddress.Text = string.Empty;
        txtBeniMobile.Text = string.Empty;
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
        txtBeniAddress.Text = "";
        txtBeniMobile.Text = "";
        lblTxtBankPostAccountNo.Text = "";
        lblTxtBankPostOfficeName.Text = "";
        lblTxtIFSC.Text = "";
        lblTxtBankPostOfficeAdress.Text = "";
        lblTxtAadharNo.Text = "";

        TxtBnameMobile.Text = string.Empty;
        txtBeniAddress.Text = string.Empty;
        txtBeniMobile.Text = string.Empty;
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
                    LoadInfoMemberId(FMLY_MEMB_IDstatic.ToString());
                    ModalPopupExtender1.Show();
                   
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
                    LoadInfoMemberId(FMLY_MEMB_IDstatic.ToString());
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
    bool ChkWhenClickPopUP()
    {

        bool chk = true;
        if (ddlselectname.SelectedItem.Text == "Select Name")
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Village!');", true);
            ddlselectname.Focus();
            // MaintainScrollPositionOnPostBack = true;
            return chk = false;
        }
        if (txtvalididname.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Name (Valid ID Proof)!');", true);
           txtvalididname.Focus();
           return chk = false;
        }
        if (txtrashancard.Text == "")
        {
           // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Valid Id Number(Pen card)!');", true);
            //txtrashancard.Focus();
           // return chk = false;
        }
        return chk;
    }
    protected void btnAddmember_Click(object sender, EventArgs e)
    {
        flagupdate = false;
        LblHeadingPopUp.Text = "";
        FieldEmpty();

        // bool Chk = ChkWhenClickPopUP();
        if (ChkWhenClickPopUP() == true)
        {
            if (txtage.Text != "")
            {
                if (FinalMemeberyear >= 18)
                {
                    DvValidAgePanel.Visible = true;

                }
                else
                {
                    DvValidAgePanel.Visible = false;
                }
            }
            else
            {
                DvValidAgePanel.Visible = false;
            }

            #region functionCode
            try
            {
                FillRelation();
                DataSet ds = FMLYDB_Obj.CheckDetailsof_FamilyHead(Convert.ToInt64(ViewState["randnumber"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString().Equals("0"))
                    {
                        ddlselectrelation.SelectedValue = "1";
                        ddlselectrelation.Enabled = false;
                        trPhoto.Visible = true;
                        TrRelationHead.Visible = false;
                        CheckHeadMember = "headexist";
                        LblHeadingPopUp.Text = "Please Enter Family Head Details";
                        txtname.Text = txtvalididname.Text.Trim();
                        txtname.Enabled = false;
                        txtpencard.Text = txtrashancard.Text.Trim();
                        //txtpencard.Enabled = false;
                        //benifi.Visible = false;
                    }
                    else
                    {
                        txtname.Enabled = true;
                        txtpencard.Enabled = true;
                        LblHeadingPopUp.Text = "Please Enter Family Member Details";
                        CheckHeadMember = "memberexist";
                        ddlselectrelation.Items.RemoveAt(1);
                        ddlselectrelation.Enabled = true;
                        trPhoto.Visible = false;
                        btnAddmember.Text = "Add Family Member Details";
                        TrRelationHead.Visible = true;
                        benifi.Visible = false;
                    }
                }
            }
            catch (Exception e2)
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            ModalPopupExtender1.Show();
            #endregion
        }
        //else
        //{
        //    ddlselectname.Focus();
        //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Village!');", true);
        //    ddlselectname.Focus();
        //   // return;
        //    //Response.Write("<script>alert('Please select Village!!');</script>");
        //    //return;
        //}
    }
    protected void ImgbtnSubmitMember_Click(object sender, EventArgs e)
    {

        LblfileUpload_Menu.Text = "";
        LblMsgDbo.Text = string.Empty;
        if (Page.IsValid)
        {
            if (CheckHeadMember == "headexist")
            {
                if (FinalMemeberyear >= 18)
                {
                    PopUpRecordFamilyheadMemberSave();
                }
                else
                {
                    ModalPopupExtender1.Show();
                    LblMsgDbo.Text = "Age should not be less then 18!";
                    //  return;
                }
            }
            if (CheckHeadMember == "memberexist")
            {
                if (FinalMemeberyear >= 1)
                {
                    PopUpRecordFamilyheadMemberSave();
                }
                else
                {
                    ModalPopupExtender1.Show();
                    LblMsgDbo.Text = "Age should not be less then 1!";
                    //  return;
                }
            }
            //--------------------------------------

        }///
        else
        {
            ModalPopupExtender1.Show();
        }

    }
    public void PopUpRecordFamilyheadMemberSave()
    {
        #region[TryCollapse]
        try
        {
            #region functionCollapse1
            if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
            {
                flagself = true;
            }

            FMLYMEM_ENT_Obj._FMLY_MEMB_NM = txtname.Text.Trim();
            FMLYMEM_ENT_Obj._FMLY_MEMB_REL = Convert.ToInt32(ddlselectrelation.SelectedValue);
            if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
            {
                trPhoto.Visible = true;
                FMLYMEM_ENT_Obj._FATHER_NM = txtfathername.Text.Trim();
            }
            else
            {
                trPhoto.Visible = false;
                FMLYMEM_ENT_Obj._FATHER_NM = null;
            }

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
            FMLYMEM_ENT_Obj._RANDOM_NO = Convert.ToInt64(ViewState["randnumber"]);
            //6june
            FMLYMEM_ENT_Obj.DOB = common.insertDate(TxtDOB.Text.Trim()).ToString();

            FMLYMEM_ENT_Obj.PenCard = null;
            FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NAME = null;
            FMLYMEM_ENT_Obj.AdhaarCard = null;
            FMLYMEM_ENT_Obj.Others = null;
            if (DropDownvalidId.SelectedValue == "1")
            {
                FMLYMEM_ENT_Obj.PenCard = txtpencard.Text.Trim();

            }
            else if (DropDownvalidId.SelectedValue == "2")
            {
                FMLYMEM_ENT_Obj._FMLY_MEMB_ID_NAME = common.RemoveUnnecessaryHtmlTagHtml(txtpencard.Text.Trim());
            }
            else if (DropDownvalidId.SelectedValue == "3")
            {
                 FMLYMEM_ENT_Obj.AdhaarCard = txtpencard.Text.Trim();
            }
            else if (DropDownvalidId.SelectedValue == "4")
            {
                FMLYMEM_ENT_Obj.Others = txtpencard.Text.Trim();
            }




            FMLYMEM_ENT_Obj.Transgender = TxtTransgender.Text.Trim();
            FMLYMEM_ENT_Obj.NoBeneficiary = TxtNoBeneficiary.Text.Trim();

            if (DdlMaritalStatus.SelectedValue != "0")
            {
                FMLYMEM_ENT_Obj.MaritalStatus = DdlMaritalStatus.SelectedValue;
            }


            FMLYMEM_ENT_Obj.BankNameMobile = TxtBnameMobile.Text.Trim();
            FMLYMEM_ENT_Obj.BenAddress = txtBeniAddress.Text.Trim();
            FMLYMEM_ENT_Obj.BenMobile = txtBeniMobile.Text.Trim();
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
                //Not in USe 
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
                //End Not in Use file
                // Start add more file uses Develop By Deepak 7/01/2018
                DataTable fileUpload = new DataTable();
                DataSet dSet = new DataSet();
                fileUpload.Columns.Add("FileName", typeof(string));
                p_Var.url = ResolveUrl("~/") + ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/Familyaadhar" + "/";
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

                FMLYMEM_ENT_Obj.IdentityCard = fileUpload;
            }
            //---------------------------------
            #endregion
            if (chkCardPhoto() == true)
            {
                if (FinalMemeberyear >= 18)
                {
                    if (checkValidation8Above() == true)
                    {
                        #region funCollapse
                        if (flagupdate == false)
                        {
                            #region collapseddlselectrelation
                            if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
                            {
                                if (chkHeadPhoto() == true)
                                {
                                    //-----------------------------------------
                                    bool check = FMLYDB_Obj.Add_Family_Members(FMLYMEM_ENT_Obj, ViewState["fid"].ToString());
                                    //---------------------
                                    if (check == true)
                                    {
                                        ResetAllFields();
                                        ModalPopupExtender1.Hide();
                                        lblMsg.Text = "New Family Member Created";
                                        lblMsg.ForeColor = System.Drawing.Color.Green;
                                        btnAddmember.Text = "Add Family Member Details";

                                        BindMembers();
                                        //---------------
                                        Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 3);
                                        //-----------------------------
                                    }
                                    else
                                    {
                                        lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                        lblMsg.ForeColor = System.Drawing.Color.Red;

                                    }
                                }
                                else
                                {
                                    LblfileUpload_Menu.Text = "Please upload your photo.";
                                    fileUpload_Menu.Focus();
                                    ModalPopupExtender1.Show();
                                    LblfileUpload_Menu.Text = "Please upload your photo.";
                                    fileUpload_Menu.Focus();
                                }
                            }
                            else
                            {
                                //-----------------------------------------
                                bool check = FMLYDB_Obj.Add_Family_Members(FMLYMEM_ENT_Obj, ViewState["fid"].ToString());
                                //---------------------
                                if (check == true)
                                {
                                    ResetAllFields();
                                    ModalPopupExtender1.Hide();
                                    lblMsg.Text = "New Family Member Created";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                    btnAddmember.Text = "Add Family Member Details";

                                    BindMembers();
                                    //---------------
                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 3);
                                    //-----------------------------
                                }
                                else
                                {
                                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                    lblMsg.ForeColor = System.Drawing.Color.Red;

                                }
                            }
                            #endregion
                        }
                        else if (flagupdate == true)
                        {
                            #region collapseddlselectrelation2
                            if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
                            {
                                if (chkHeadPhoto() == true)
                                {


                                    //------------------------------------
                                    bool check = FMLYDB_Obj.Update_Family_Member(FMLYMEM_ENT_Obj, mid);
                                    //----------------------------------
                                    if (check == true)
                                    {
                                        //              RegisterClientScriptBlock("showmessage",
                                        //"<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                                        ResetAllFields();
                                        lblMsg.Text = " Family Member Updated";
                                        lblMsg.ForeColor = System.Drawing.Color.Green;

                                        flagupdate = false;
                                        //-----------------------
                                        BindMembers();
                                        //--------------------
                                        Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);
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
                            }
                            else
                            {
                                //------------------------------------
                                bool check = FMLYDB_Obj.Update_Family_Member(FMLYMEM_ENT_Obj, mid);
                                //----------------------------------
                                if (check == true)
                                {
                                    //              RegisterClientScriptBlock("showmessage",
                                    //"<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                                    ResetAllFields();
                                    lblMsg.Text = " Family Member Updated";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;

                                    flagupdate = false;
                                    //-----------------------
                                    BindMembers();
                                    //--------------------
                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);
                                }
                                else
                                {
                                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                }

                            }

                            #endregion
                        }
                        ///--------------
                        #endregion
                    }
                    else
                    {
                        ModalPopupExtender1.Show();
                    }

                }
                else
                {
                    #region funCollapse
                    if (flagupdate == false)
                    {
                        if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
                        {
                            if (chkHeadPhoto() == true)
                            {
                                //-----------------------------------------
                                bool check = FMLYDB_Obj.Add_Family_Members(FMLYMEM_ENT_Obj, ViewState["fid"].ToString());
                                //---------------------
                                if (check == true)
                                {
                                    ResetAllFields();
                                    ModalPopupExtender1.Hide();
                                    lblMsg.Text = "New Family Member Created";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                    btnAddmember.Text = "Add Family Member Details";

                                    BindMembers();
                                    //---------------
                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 3);
                                    //-----------------------------
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
                        }
                        else
                        {
                            //-----------------------------------------
                            bool check = FMLYDB_Obj.Add_Family_Members(FMLYMEM_ENT_Obj, ViewState["fid"].ToString());
                            //---------------------
                            if (check == true)
                            {
                                ResetAllFields();
                                ModalPopupExtender1.Hide();
                                lblMsg.Text = "New Family Member Created";
                                lblMsg.ForeColor = System.Drawing.Color.Green;
                                btnAddmember.Text = "Add Family Member Details";

                                BindMembers();
                                //---------------
                                Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 3);
                                //-----------------------------
                            }
                            else
                            {
                                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                lblMsg.ForeColor = System.Drawing.Color.Red;

                            }

                        }
                    }
                    else if (flagupdate == true)//------update case-------------
                    {
                        if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
                        {
                            if (chkHeadPhoto() == true)
                            {
                                //------------------------------------
                                bool check = FMLYDB_Obj.Update_Family_Member(FMLYMEM_ENT_Obj, mid);
                                //----------------------------------
                                if (check == true)
                                {
                                    //              RegisterClientScriptBlock("showmessage",
                                    //"<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                                    ResetAllFields();
                                    lblMsg.Text = " Family Member Updated";
                                    lblMsg.ForeColor = System.Drawing.Color.Green;

                                    flagupdate = false;
                                    //-----------------------
                                    BindMembers();
                                    //--------------------
                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);
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
                        }
                        else
                        {

                            //------------------------------------
                            bool check = FMLYDB_Obj.Update_Family_Member(FMLYMEM_ENT_Obj, mid);
                            //----------------------------------
                            if (check == true)
                            {
                                //              RegisterClientScriptBlock("showmessage",
                                //"<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                                ResetAllFields();
                                lblMsg.Text = " Family Member Updated";
                                lblMsg.ForeColor = System.Drawing.Color.Green;

                                flagupdate = false;
                                //-----------------------
                                BindMembers();
                                //--------------------
                                Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);
                            }
                            else
                            {
                                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                lblMsg.ForeColor = System.Drawing.Color.Red;
                            }
                        }

                    }
                    ///--------------
                    #endregion
                }
            }
            else
            {

                ModalPopupExtender1.Show();
            }
            ///-----------------

        }
        catch (Exception e3)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e3.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
        #endregion
    }
    protected void imgbtnreset_Click(object sender, EventArgs e)
    {
        flagself = false;

        if (flagupdate == false)
        {
            ResetAllFields();
        }
        else
        {
            LoadInfoMemberId(mid);
        }
        ModalPopupExtender1.Show();
    }
    protected void imgbtncancel1_Click(object sender, EventArgs e)
    {
        ResetAllFields();
        ModalPopupExtender1.Hide();
        flagself = false;
    }
    protected void ImgbtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                #region collapse1
                FMLY_ENT_Obj._FMLY_REG_CD = txtcode.Text.Trim();
                if (!txtsurdate.Text.Equals(""))
                {

                    FMLY_ENT_Obj._SURVEY_DT = common.insertDate(txtsurdate.Text.Trim()).ToString();
                }
                else
                {
                    FMLY_ENT_Obj._SURVEY_DT = null;
                }

                if (ddlselectname.SelectedValue.ToString().Equals("0"))
                {
                    lblMsg.Text = "Please Select Village Name";
                    return;

                }
                DataSet ds = FMLYDB_Obj.CheckDetailsof_FamilyHead(Convert.ToInt64(ViewState["randnumber"]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString().Equals("0"))
                    {
                        lblMsg.Text = "Please Enter The Details of Family Head First";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        return;

                    }

                }

                FMLY_ENT_Obj._FMLY_VALID_ID_NO = common.RemoveUnnecessaryHtmlTagHtml(txtrashancard.Text.Trim());
                FMLY_ENT_Obj._FMLY_VALID_ID_NAME = common.RemoveUnnecessaryHtmlTagHtml(txtvalididname.Text.Trim());
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
                        lblMsg.Text = "Please Select Home Status";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
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
                FMLY_ENT_Obj._COMMENT = common.RemoveUnnecessaryHtmlTagHtml(txtcomments.Text.Trim());
               
                if (ddlselectscheme.SelectedValue.ToString().Equals("0"))
                {
                    lblMsg.Text = "Please Select Options";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    return;

                }
                else
                {
                    FMLY_ENT_Obj._SCHM_ID = Convert.ToInt32(ddlselectscheme.SelectedValue);
                    if (ddlselectscheme.SelectedValue == "4")
                    {
                        FMLY_ENT_Obj.OtherOptions = txtOtherOption.Text.Trim();
                    }
                    else
                    {
                        FMLY_ENT_Obj.OtherOptions = null;
                    }
                    //if (ddlselectscheme.SelectedValue.ToString().Equals("2"))
                    //{
                    //    if (ddlselectgroupname.SelectedValue.ToString().Equals("0"))
                    //    {
                    //        lblMsg.Text = "Please Select Group Name";
                    //        lblMsg.ForeColor = System.Drawing.Color.Red;
                    //        return;
                    //    }
                    //    FMLY_ENT_Obj._GROUP_NM = Convert.ToInt32(ddlselectgroupname.SelectedValue);
                    //}
                    //else
                    //{
                    //    FMLY_ENT_Obj._GROUP_NM = 0;
                    //}
                }


                bool check1 = false;
                FMLY_ENT_Obj._RANDOM_NO = Convert.ToInt64(ViewState["randnumber"]);
               // FMLY_ENT_Obj._RELOATION_PLACE = txtrelocationplace.Text.Trim();
                FMLY_ENT_Obj._RELOATION_PLACE = null;

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

                string VillagesID = Request.QueryString["id"];
                #endregion
                if (Session["UserType"].ToString().Equals("4"))
                {
                    //----------------
                    resultfamily = FMLYDB_Obj.Add_Family(FMLY_ENT_Obj, ddlselectname.SelectedValue.ToString());
                    if(resultfamily!=100)
                    {
                        if(resultfamily>0)
                        {
                            check1 = false;
                        }
                        else
                        {
                            check1 = true;
                        }
                        
                    }
                    else
                    {
                        check1 = false;
                    }
                     
                    //-----------------------
                }
                if (Session["UserType"].ToString().Equals("1"))
                {
                    resultfamily = FMLYDB_Obj.Add_Family1(FMLY_ENT_Obj, ddlselectname.SelectedValue.ToString());
                    if (resultfamily != 100)
                    {
                        if (resultfamily > 0)
                        {
                            check1 = false;
                        }
                        else
                        {
                            check1 = true;
                        }

                    }
                    else
                    {
                        check1 = false;
                    }

                }


                if (check1 == true)
                {
                    new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 3);
                    //-------------------------------
                    FMLYDB_Obj.Delete_All_Members_Via_Family_Id_From_Temp(Convert.ToInt64(ViewState["randnumber"]));
                   
                    //--------------------------------
                    Response.Redirect(ResolveUrl("~/auth/adminpanel/FamilyData/Family_Management.aspx?id=" + VillagesID), false);
                   
                }
                else
                {
                    if (resultfamily > 0 && resultfamily != 100)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only " + resultfamily + " family Member should be add');", true);
                    }
                    else
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                    }
                    
                }
                // }


            }
        }

   //}
        catch (Exception e4)
        {
        }


    }
    protected void ImgbtnCancel_Click(object sender, EventArgs e)
    {
        ResetAllFieldsOfFamily();
        FMLYDB_Obj.Delete_All_Members_Via_Family_Id_From_Temp(Convert.ToInt64(ViewState["randnumber"]));
        BindMembers();
    }
    protected void ImgbtnBack_Click(object sender, EventArgs e)
    {
        FMLYDB_Obj.Delete_All_Members_Via_Family_Id_From_Temp(Convert.ToInt64(ViewState["randnumber"]));
        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"));
    }
    protected void ddlselectstatusresland_SelectedIndexChanged(object sender, EventArgs e)
    {

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
            DdlStateName.DataValueField = "id";
            DdlStateName.DataBind();
            DdlStateName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
        }
    }
    void BindTigerReserveName()
    {
        try
        {
            int StateID = 0;
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("Select", "0"));
             StateID = Convert.ToInt32(DdlStateName.SelectedValue);
            if(StateID==0)
            {
                StateID = Convert.ToInt32(Session["ntca_StateID"]);
            }
            DataSet ds = new VillageDB().BindTigerReservefile(StateID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new ListItem("Select", "0"));
            }



            else
            {
                ddlselectreserve.Items.Clear();
                ddlselectreserve.Items.Add(new ListItem("Select", "0"));
            }
        }
        catch (Exception er)
        {
        }
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName();
    }
    protected void ddlTiger_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_VillageCode_And_Name1();
    }

}