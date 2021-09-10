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

public partial class auth_Adminpanel_FAMILYDATA_RelocationScheme_IB_Mangement : System.Web.UI.Page
{
    Relocation_InstallmentDB RI = new Relocation_InstallmentDB();
    Relocation_InstallmentEntity RI_Entity_obj = new Relocation_InstallmentEntity();
    Realocation_AreaDB ReloAreaDb = new Realocation_AreaDB();
    FamilyDB FMLYDB_Obj = new FamilyDB();
    common com_Obj = new common();
    public static Int32 fam_id, villid;
    public static Int32 scheme_id;
    FamilyAsstsEvaluationEntity FamilyAsset = new FamilyAsstsEvaluationEntity();
    public static bool flagupdate1 = false, flagupdate2 = false, flagupdate3 = false, flagupdate4 = false, flagupdate5 = false;
    public static Int64 instid;
    string holdername, holderaccno, holderbankname, holderbranchname;

    protected void Page_Load(object sender, EventArgs e)
    {
        fam_id = Int32.Parse(Request.QueryString["family_id"].ToString());
        lblMsg.Text = "";
        HiddenField4.Value = com_Obj.fordate();
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }
       
        //if (Session["UserRole"].ToString().Equals("2"))
        //{
        //    gv1B.Columns[6].Visible = false;
        //}
        //if (Session["UserRole"].ToString().Equals("1"))
        //{
        //    gv1B.Columns[6].Visible = true;
        //}

        if (!Page.IsPostBack)
        {
            //CheckForRelocationDetails(Request.QueryString["family_id"].ToString());
            flagupdate1 = false;
            flagupdate2 = false;
            flagupdate3 = false;
            flagupdate4 = false;
            display_installment();
            btnsecond.Visible = false;

            DataSet ds = FMLYDB_Obj.Proc_DisplayFamilyById(Request.QueryString["vid"].ToString(), Request.QueryString["family_id"].ToString(),null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblvillcode.Text = ds.Tables[0].Rows[0]["VILL_CD"].ToString();
                lblvillname.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                villid = Convert.ToInt32(Request.QueryString["vid"].ToString());
             //   lblstatename.Text = ds.Tables[0].Rows[0][5].ToString();
                lbldistrict.Text = ds.Tables[0].Rows[0]["DistName"].ToString();
              //  lblreaserve.Text = ds.Tables[0].Rows[0][6].ToString();
                lbltehsil.Text = ds.Tables[0].Rows[0]["Tehsil_Name"].ToString();

                if (ds.Tables[2].Rows.Count > 0)
                {
                    Lblgpname.Text = ds.Tables[2].Rows[0]["GRP_NM"].ToString();
                }
                else
                {
                    Lblgpname.Text = "not applicable";

                }
                Lblfamilycode.Text = ds.Tables[1].Rows[0]["FMLY_REG_CD"].ToString();
                lblgp.Text = ds.Tables[0].Rows[0]["GramPanchayatName"].ToString();
                Lblheadname.Text = ds.Tables[1].Rows[0]["FMLY_MEMB_NM"].ToString();
                if (ds.Tables[1].Rows[0]["SCHM_ID"].ToString() == "2")
                {
                    Lblscheme.Text = "I";
                }
                else if (ds.Tables[1].Rows[0]["SCHM_ID"].ToString() == "1")
                {
                    Lblscheme.Text = "I";
                }
                else if (ds.Tables[1].Rows[0]["SCHM_ID"].ToString() == "3")
                {
                    Lblscheme.Text = "II";
                }
                else if (ds.Tables[1].Rows[0]["SCHM_ID"].ToString() == "4")
                {
                    Lblscheme.Text = "No Option";
                }

                fam_id = Convert.ToInt32(ds.Tables[1].Rows[0]["FMLY_ID"]);
                scheme_id = Convert.ToInt32(ds.Tables[1].Rows[0]["SCHM_ID"]);
                DataSet ds11 = FMLYDB_Obj.Display_Info_Family_By_FamilyID(fam_id.ToString());
                if (ds11.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = ds11.Tables[0].Rows[0]["FMLY_AGRI_LND"].ToString();
                    Label2.Text = ds11.Tables[0].Rows[0]["FMLY_RESI_LND"].ToString();
                    Label3.Text = ds11.Tables[0].Rows[0]["FMLY_WELLS"].ToString();
                    Label4.Text = ds11.Tables[0].Rows[0]["FMLY_TREES"].ToString();
                    Label5.Text = ds11.Tables[0].Rows[0]["FMLY_OTHR_ASSETS"].ToString();
                    if (Label1.Text.Equals("0.00"))
                    {
                        TextAgrivalue.Enabled = false;
                    }
                    if (Label2.Text.Equals("0.00"))
                    {
                        Textresvalue.Enabled = false;
                    }
                    if (Label3.Text.Equals("0"))
                    {
                        Textwellsvalue.Enabled = false;
                    }
                    if (Label4.Text.Equals("0"))
                    {
                        Texttreesvalue.Enabled = false;
                    }
                    if (Label5.Text.Equals("0"))
                    {
                        Textothervalue.Enabled = false;
                    }
                    if (Label5.Text.Equals("0") && Label4.Text.Equals("0") && Label3.Text.Equals("0") && Label2.Text.Equals("0.00") && Label1.Text.Equals("0.00"))
                    {
                        btn_saveAssets.Enabled = false;

                    }
                    else
                    {
                        btn_saveAssets.Enabled = true;

                    }
                }

                //lblid.Text = ds.Tables[0].Rows[0][11].ToString();
                DataSet ds1 = RI.ProcCheckSchemeNo(scheme_id.ToString(), fam_id.ToString());
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    display_installment();
                    btneditAssets.Visible = true;
                    if (ds1.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        DataSet dsn = RI.Proc_SubInst(scheme_id.ToString(), fam_id.ToString());
                        if (dsn.Tables[0].Rows.Count > 0)
                        {
                            string instalamet = dsn.Tables[0].Rows[0][0].ToString();

                            {
                                display_Asset();

                                btn_saveAssets.Visible = false;
                                display_installment();


                            }

                            {
                                display_Asset();

                                btn_saveAssets.Visible = true;
                                btnsecond.Visible = false;



                            }


                        }
                    }
                    else if (ds1.Tables[0].Rows[0][0].ToString() == "2")
                    {
                        display_Asset();
                        //btnfirst.Visible = false;
                        btnsecond.Visible = false;
                        btn_saveAssets.Visible = false;

                        display_installment();
                        lblMsg.Text = "All Installment has been done";
                        lblMsg.ForeColor = System.Drawing.Color.Green;



                    }
                }
                else
                {
                    DataSet dsforvalue = new DataSet();
                    dsforvalue = RI.CalculateValueforland(villid);
                    if (dsforvalue.Tables[0].Rows.Count > 0)
                    {
                        if (Label1.Text != string.Empty)
                        {



                            TextAgrivalue.Text = Convert.ToString(System.Math.Round((Convert.ToDecimal(Label1.Text) * Convert.ToDecimal(dsforvalue.Tables[0].Rows[0][0])), 2));
                        }
                        if (Label2.Text != string.Empty)
                        {
                            Textresvalue.Text = Convert.ToString(System.Math.Round((Convert.ToDecimal(Label2.Text) * Convert.ToDecimal(dsforvalue.Tables[0].Rows[0][1])), 2));
                        }
                        }
                    flagupdate5 = false;
                    btn_saveAssets.Visible = true;
                    btneditAssets.Visible = false;
                    //btnfirst.Visible = false;
                    btnsecond.Visible = false;
                    display_Asset();
                }

            }


        }
    }



    public void CheckForRelocationDetails(string famid)
    {
        DataSet ds = ReloAreaDb.CheckForRelocationDetails(famid.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
            {
                btnaddrelocation.Visible = false;
                //  btneditrelocation.Visible = true;
            }
            else
            {
                btnaddrelocation.Visible = true;
                // btneditrelocation.Visible = false;
            }
        }
        else
        {

            gv1B.Visible = false;
        }


    }
    public void display_installment()
    {
        DataSet ds = FMLYDB_Obj.Proc_Display_IIInstallment(fam_id.ToString(), scheme_id.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv1B.Visible = true;
            gv1B.DataSource = ds.Tables[0].DefaultView;
            gv1B.DataBind();
            //gv1A.Rows[0].Visible = true;




        }
        else
        {

            gv1B.Visible = false;
        }


    }

    protected void ImgbtnSubmitMember_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            try
            {
                if (fam_id == 0)
                {
                    Response.Redirect(ResolveUrl("~/Home.aspx"), true);
                    return;
                }
               
                if (instid == 0)
                {
                    Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx"), true);
                    return;
                }
                RI_Entity_obj._INST_ISCM_ID = instid.ToString();
                RI_Entity_obj._BANK_NAME = txtbankname.Text;
                RI_Entity_obj._INST_ISCM_AMT = Convert.ToDouble(txtamount.Text);
                if (!txtsurdate.Text.Equals(""))
                {
                    RI_Entity_obj._INST_ISCM_CHK_DT = common.insertDate(txtsurdate.Text).ToString();
                }
                else
                {
                    RI_Entity_obj._INST_ISCM_CHK_DT = null;
                }

                RI_Entity_obj._INST_ISCM_CHK_NO = common.RemoveUnnecessaryHtmlTagHtml(txtchkno.Text.Trim());
                RI_Entity_obj._INST_ISCM_HOLD_NM = txtholdername.Text;
                RI_Entity_obj._ACCOUNT_NO = txtaccountno.Text;
                RI_Entity_obj._BRANCH_NAME = txtbranchname.Text;
                RI_Entity_obj._CHK_BANK_NM = txtckbankname.Text;
                RI_Entity_obj._CHK_BRANCH_NM = txtckBranch.Text;

                bool check = RI.Proc_Update_IScheme_For_Others(RI_Entity_obj, fam_id.ToString(), scheme_id.ToString());
                if (check == true)
                {
                    
                    display_installment();
                   
                    RegisterClientScriptBlock("showmessage", "<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                    //Convert.Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/Message.aspx?mid=10"), false);
                    lblMsg.Text = WebConstant.UserFriendlyMessages.UpdatedINST;
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);

                }
                
            }
            catch (Exception e3)
            {
                poUpEx1.Show();
                lblMsg1a.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e3.Message.ToString();
                lblMsg1a.ForeColor = System.Drawing.Color.Red;

            }
        }

    }
    public void ResetFieldsfirstInstallment()
    {

        txtbankname.Text = "";
        txtbranchname.Text = "";
        txtholdername.Text = "";
        txtamount.Text = "";
        txtbankname.Text = "";
        txtchkno.Text = "";
        txtsurdate.Text = "";
        txtaccountno.Text = "";
        txtckbankname.Text = "";
        txtckBranch.Text = "";

    }

    protected void ImgbtnCancel1_Click(object sender, EventArgs e)
    {
        btnresetinstalment.Visible = false;
        btnaddinstalment.Visible = false;
        if (flagupdate1 == false)
        {
            ResetFieldsfirstInstallment();
        }
        else
        {
            ShowDataOnResetButton(instid);
        }

        poUpEx1.Show();

    }


    protected void ImgbtnBack_Click(object sender, EventArgs e)
    {
       // Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx?pindex=" + Request.QueryString["inid"].ToString() + "&vid=" + Request.QueryString["vid"].ToString() + "&sid=" + Request.QueryString["sid"].ToString() + "&rid=" + Request.QueryString["rid"].ToString() + "&fid=" + Request.QueryString["fid"].ToString()));
       Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Family_Management.aspx"));
    }



    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        ResetFieldsfirstInstallment();

        //poUpEx1.Hide();

    }

    public void display_Asset()
    {
        DataSet ds = FMLYDB_Obj.Proc_Display_Asset(fam_id.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {

            Lblagri.Visible = true;
            Lblresland.Visible = true;
            Lblwells.Visible = true;

            Lbltress.Visible = true;
            Lblother.Visible = true;
            Lblagri.Text = ds.Tables[0].Rows[0][0].ToString();
            Lblresland.Text = ds.Tables[0].Rows[0][1].ToString();
            Lblwells.Text = ds.Tables[0].Rows[0][3].ToString();
            Lbltress.Text = ds.Tables[0].Rows[0][2].ToString();
            Lblother.Text = ds.Tables[0].Rows[0][4].ToString();
            TextAgrivalue.Visible = false;
            Textothervalue.Visible = false;
            Textresvalue.Visible = false;
            Texttreesvalue.Visible = false;
            Textwellsvalue.Visible = false;
            btn_saveAssets.Visible = false;
            //btnfirst.Visible = true;
            btnsecond.Visible = false;            //btnfirst2A.Visible = false;
            //btnfirst2B.Visible = false;


        }
        else
        {
            TextAgrivalue.Visible = true;
            Textothervalue.Visible = true;
            Textresvalue.Visible = true;
            Texttreesvalue.Visible = true;
            Textwellsvalue.Visible = true;
            Lblagri.Visible = false;
            Lblresland.Visible = false;
            Lblwells.Visible = false;

            Lbltress.Visible = false;
            Lblother.Visible = false;
            btn_saveAssets.Visible = true;
            //btnfirst.Visible = false;
            btnsecond.Visible = false;
            //btnfirst2A.Visible = false;
            //btnfirst2B.Visible = false;


        }



    }

    protected void gv1B_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ImageButton ibe = (ImageButton)e.Row.FindControl("ibEdit");
                ibe.CommandName = "Edit";
                ibe.CommandArgument = DataBinder.Eval(e.Row.DataItem, "INST_ISCM_ID").ToString();
            }


        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }


    }
    protected void gv1B_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }
    protected void gv1B_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }




    protected void gv1B_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Delete")
            {
                fam_id = Int32.Parse(Request.QueryString["family_id"].ToString());
                int instalment_id = Int32.Parse(e.CommandArgument.ToString());
                int i = FMLYDB_Obj.delete_instalment(fam_id, instalment_id);
                if (i > 0)
                {
                    lblMsg.Text = "Record is Deleted Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMsg.Text = "Record is not Deleted Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            if (e.CommandName == "Edit")
            {

                DataSet ds = FMLYDB_Obj.DisplayInstallment(e.CommandArgument.ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    instid = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
                    //if (ds.Tables[0].Rows[0]["SUB_INST_ISCM_NO"].ToString().Equals("1.1"))
                    //{
                    btnaddinstalment.Visible = false;
                    btnresetinstalment.Visible = false;
                    ImgbtnCancel1.Visible = true;
                    ImgbtnSubmitMember.Visible = true;
                    Panel1.Visible = true;
                    poUpEx1.Show();

                    txtholdername.Text = ds.Tables[0].Rows[0]["INST_ISCM_HOLD_NM"].ToString();
                    holdername = ds.Tables[0].Rows[0]["INST_ISCM_HOLD_NM"].ToString();
                    txtamount.Text = ds.Tables[0].Rows[0]["INST_ISCM_AMT"].ToString();

                    txtchkno.Text = ds.Tables[0].Rows[0]["INST_ISCM_CHK_NO"].ToString();
                    txtsurdate.Text = ds.Tables[0].Rows[0]["INST_ISCM_CHK_DT1"].ToString();
                    txtbankname.Text = ds.Tables[0].Rows[0]["BANK_NAME"].ToString();
                    txtbranchname.Text = ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString();
                    txtaccountno.Text = ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString();
                    holderaccno = ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString();
                    txtckbankname.Text = ds.Tables[0].Rows[0]["CHK_BANK_NM"].ToString();
                    txtckBranch.Text = ds.Tables[0].Rows[0]["CHK_BRANCH_NM"].ToString();

                    flagupdate1 = true;



                }

            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }



    }
    public void ShowDataOnResetButton(long instid)
    {
        if (instid == 0)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
            return;
        }
        DataSet ds = FMLYDB_Obj.DisplayInstallment(instid.ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            instid = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());



            txtholdername.Text = ds.Tables[0].Rows[0]["INST_ISCM_HOLD_NM"].ToString();
            txtamount.Text = ds.Tables[0].Rows[0]["INST_ISCM_AMT"].ToString();
            txtchkno.Text = ds.Tables[0].Rows[0]["INST_ISCM_CHK_NO"].ToString();
            txtsurdate.Text = ds.Tables[0].Rows[0]["INST_ISCM_CHK_DT1"].ToString();
            txtbankname.Text = ds.Tables[0].Rows[0]["BANK_NAME"].ToString();
            txtbranchname.Text = ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString();
            txtaccountno.Text = ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString();
            txtckbankname.Text = ds.Tables[0].Rows[0]["CHK_BANK_NM"].ToString();
            txtckBranch.Text = ds.Tables[0].Rows[0]["CHK_BRANCH_NM"].ToString();
            poUpEx1.Show();
            flagupdate1 = true;



        }
    }

    protected void btn_saveAssets_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (TextAgrivalue.Text!=string.Empty)
                {
                    FamilyAsset._AGRI_LND_VAL = Convert.ToDouble(TextAgrivalue.Text);
                }
                else
                {
                    FamilyAsset._AGRI_LND_VAL = 0;
                }
                if (Textothervalue.Text != string.Empty)
                {
                    FamilyAsset._OTHERS_VAL = Convert.ToDouble(Textothervalue.Text);
                }
                else
                {
                    FamilyAsset._OTHERS_VAL = 0;
                }
                if (Textresvalue.Text != string.Empty)
                { FamilyAsset._RES_LND_VAL = Convert.ToDouble(Textresvalue.Text); }
                else
                { FamilyAsset._RES_LND_VAL = 0; }
               
                if (Texttreesvalue.Text != string.Empty)
                {FamilyAsset._TREES_VAL = Convert.ToDouble(Texttreesvalue.Text);}
                else{FamilyAsset._TREES_VAL = 0;}

                if (Textwellsvalue.Text != string.Empty)
                { FamilyAsset._WELLS_VAL = Convert.ToDouble(Textwellsvalue.Text); }
                else { FamilyAsset._WELLS_VAL = 0; }
                
                if (flagupdate5 == false)
                {
                    bool check = FMLYDB_Obj.Add_Family_Assets(FamilyAsset, fam_id.ToString());
                    if (check == true)
                    {


                        new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 3);
                        display_Asset();


                    }
                    else
                    {

                        lblMsg.Text = "Try Again";
                    }
                }
                else if (flagupdate5 == true)
                {
                    bool check = FMLYDB_Obj.Update_Family_Assets(FamilyAsset, fam_id.ToString());
                    if (check == true)
                    {


                        new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 3);
                        display_Asset();


                    }
                    else
                    {

                        lblMsg.Text = "Try Again";
                    }
                }
            }
            catch (Exception e3)
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+  e3.Message.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
    protected void btnfirst_Click(object sender, EventArgs e)
    {
        ResetFieldsfirstInstallment();
        poUpEx1.Show();
    }


    protected void btnsecond_Click(object sender, EventArgs e)
    {
        //ResetFieldsSecondInstallment();
        DataSet ds = RI.DisplayDatainPOPUP(fam_id, 1);
        btnresetinstalment.Visible = true;
        ImgbtnCancel1.Visible = false;
        Panel1.Visible = true;
        poUpEx1.Show();
        btnaddinstalment.Visible = true;
        ImgbtnSubmitMember.Visible = false;
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtholdername.Text = ds.Tables[0].Rows[0]["INST_ISCM_HOLD_NM"].ToString();
            txtbankname.Text = ds.Tables[0].Rows[0]["BANK_NAME"].ToString();
            txtbranchname.Text = ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString();
            txtaccountno.Text = ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString();
            Panel1.Visible = true;
            poUpEx1.Show();
            // btnaddinstalment.Visible = true;
            //ImgbtnSubmitMember.Visible = false;
        }
        else
        {

        }

    }


    protected void btnaddrelocation_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Relocation1B.aspx?fam_id=" + Request.QueryString["family_id"].ToString()), false);
    }
    protected void btneditrelocation_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/FAMILYDATA/Edit_Relocation1B.aspx?fam_id=" + Request.QueryString["family_id"].ToString()), false);
    }
    protected void btneditAssets_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = FMLYDB_Obj.Proc_Display_Asset(fam_id.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {

                Lblagri.Visible = false;
                Lblresland.Visible = false;
                Lblwells.Visible = false;

                Lbltress.Visible = false;
                Lblother.Visible = false;
                TextAgrivalue.Text = ds.Tables[0].Rows[0][0].ToString();
                Textresvalue.Text = ds.Tables[0].Rows[0][1].ToString();
                Textwellsvalue.Text = ds.Tables[0].Rows[0][3].ToString();
                Texttreesvalue.Text = ds.Tables[0].Rows[0][2].ToString();
                Textothervalue.Text = ds.Tables[0].Rows[0][4].ToString();
                TextAgrivalue.Visible = true;
                Textothervalue.Visible = true;
                Textresvalue.Visible = true;
                Texttreesvalue.Visible = true;
                Textwellsvalue.Visible = true;
                btn_saveAssets.Visible = true;
                btneditAssets.Visible = false;
                flagupdate5 = true;


            }

        }
        catch (Exception e3)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError + e3.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void txtbankname_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnaddinstalment_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (fam_id == 0)
                {
                    Response.Redirect(ResolveUrl("~/AUTH/adminpanel/User_Login.aspx"), true);
                    return;
                }
                if (flagupdate1 == false)
                {
                    RI_Entity_obj._BANK_NAME = txtbankname.Text;
                    RI_Entity_obj._INST_ISCM_AMT = Convert.ToDouble(txtamount.Text);
                    if (!txtsurdate.Text.Equals(""))
                    {
                        RI_Entity_obj._INST_ISCM_CHK_DT = common.insertDate(txtsurdate.Text).ToString();
                    }
                    else
                    {
                        RI_Entity_obj._INST_ISCM_CHK_DT = null;
                    }

                    RI_Entity_obj._INST_ISCM_CHK_NO = common.RemoveUnnecessaryHtmlTagHtml(txtchkno.Text.Trim());
                    RI_Entity_obj._INST_ISCM_HOLD_NM = txtholdername.Text;
                    RI_Entity_obj._ACCOUNT_NO = txtaccountno.Text;
                    RI_Entity_obj._BRANCH_NAME = txtbranchname.Text;
                    RI_Entity_obj._SUB_INST_ISCM_NO = 1.1;
                    RI_Entity_obj._INST_ISCM_NO = 1;
                    RI_Entity_obj._CHK_BANK_NM = txtckbankname.Text;
                    RI_Entity_obj._CHK_BRANCH_NM = txtckBranch.Text;


                    bool check = RI.Proc_Insert_IIScheme(RI_Entity_obj, fam_id.ToString(), scheme_id.ToString());
                    if (check == true)
                    {
                        new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 3);

                        // poUpEx1.Hide();
                        btnsecond.Visible = false;
                        //btnfirst.Visible = false;
                        //btnfirst2A.Visible = true;
                        //btnfirst2B.Visible = false;
                        display_installment();
                        lblMsg.Text = "Installment Inserted successfully.";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        //Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/Message.aspx?mid=7"), false);
                    }
                }



                else
                {
                    poUpEx1.Show();
                    lblMsg1a.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                    lblMsg1a.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception e3)
            {
                poUpEx1.Show();
                lblMsg1a.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e3.Message.ToString();
                lblMsg1a.ForeColor = System.Drawing.Color.Red;

            }
        }


    }
    protected void btnresetinstalment_Click(object sender, EventArgs e)
    {
        poUpEx1.Show();
        ResetFieldsfirstInstallment();
        btnresetinstalment.Visible = true;
        btnaddinstalment.Visible = true;
        ImgbtnCancel1.Visible = false;
        ImgbtnSubmitMember.Visible = false;

    }
    protected void gv1B_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        display_installment();
    }
}