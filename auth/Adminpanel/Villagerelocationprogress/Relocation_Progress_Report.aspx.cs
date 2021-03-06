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
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_Villagerelocationprogress_Relocation_Progress_Report :CrsfBase
{
    RelocationProgresEntity objEntity = new RelocationProgresEntity();
    relocationprogress dal = new relocationprogress();
    common com_Obj = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        string operations = Request.QueryString["Operation"];

        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }

        if (!IsPostBack)
        {

            HiddenField1.Value = com_Obj.fordate();
            if (Session["UserType"].ToString().Equals("1"))
            {
                //  txtReserve.Text = Session["sTigerReserveName"].ToString();
                txtReserve.Enabled = false;
                fillstate();
                // ddlstate.SelectedValue = Session["sStateID"].ToString();
                ddlstate.Enabled = true;
                if (operations == "2")
                {
                    // txtReserve.Text = Session["sTigerReserveName"].ToString();
                    txtReserve.Enabled = false;
                    // ddlstate.SelectedValue = Session["sStateID"].ToString();
                    ddlstate.Enabled = false;
                    filldeatil();
                }
            }
            if (Session["UserType"].ToString().Equals("2"))
            {
                //  txtReserve.Text = Session["sTigerReserveName"].ToString();
                txtReserve.Enabled = false;
                fillstate();
                // ddlstate.SelectedValue = Session["sStateID"].ToString();
                ddlstate.Enabled = false;
                if (operations == "2")
                {
                    // txtReserve.Text = Session["sTigerReserveName"].ToString();
                    txtReserve.Enabled = false;
                    // ddlstate.SelectedValue = Session["sStateID"].ToString();
                    ddlstate.Enabled = false;
                    filldeatil();
                }
            }
            if (Session["UserType"].ToString().Equals("3"))
            {
                //  txtReserve.Text = Session["sTigerReserveName"].ToString();
                txtReserve.Enabled = false;
                fillstate();
                // ddlstate.SelectedValue = Session["sStateID"].ToString();
                ddlstate.Enabled = false;
                if (operations == "2")
                {
                    // txtReserve.Text = Session["sTigerReserveName"].ToString();
                    txtReserve.Enabled = false;
                    // ddlstate.SelectedValue = Session["sStateID"].ToString();
                    ddlstate.Enabled = false;
                    filldeatil();
                }
            }
            if (Session["UserType"].ToString().Equals("4"))
            {
                if (Request.QueryString["id"] != null)
                {

                }
                else
                {
                    CheckRecordExistenceAfterSave();
                }
                // CheckRecordExistenceAfterSave();
                txtReserve.Text = Session["sTigerReserveName"].ToString();
                txtReserve.Enabled = false;
                fillstate();
                ddlstate.SelectedValue = Session["sStateID"].ToString();
                ddlstate.Enabled = false;
                if (operations == "2")
                {
                    txtReserve.Text = Session["sTigerReserveName"].ToString();
                    txtReserve.Enabled = false;
                    ddlstate.SelectedValue = Session["sStateID"].ToString();
                    ddlstate.Enabled = false;
                    filldeatil();
                }
            }

        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string operation = Request.QueryString["Operation"];
            if (operation == "1")
            {
                Submit_deatils();
            }
            if (operation == "2")
            {
                update_deatil();
            }
        }
    }
    protected void Btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("RelocationProgresManagement.aspx");
    }
    public void Submit_deatils()
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

                    //if (Page.IsValid)
                   // {

                        if (Page.IsValid)
                        {
                            objEntity.UserID = Convert.ToInt32(Session["User_Id"]);
                            objEntity._DATE = txtDate.Text;
                            if (string.IsNullOrEmpty(Convert.ToString(txtNooffamily.Text)))
                            {
                                objEntity._FAMILY = 0;
                            }
                            else
                            {
                                objEntity._FAMILY = Int32.Parse(txtNooffamily.Text);
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(txtnooffamilyreaming.Text)))
                            {
                                objEntity._REMAINFAMILY = 0;
                            }
                            else
                            {
                                objEntity._REMAINFAMILY = Int32.Parse(txtnooffamilyreaming.Text);
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(txtnoofRelocatedFamily.Text)))
                            {
                                objEntity._RELOCFAMILY = 0;
                            }
                            else
                            {
                                objEntity._RELOCFAMILY = Int32.Parse(txtnoofRelocatedFamily.Text);
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(txtNovillage.Text)))
                            {
                                objEntity._VILLAGE = 0;
                            }
                            else
                            {
                                objEntity._VILLAGE = Int32.Parse(txtNovillage.Text);
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(txtnoofRelocatevillage.Text)))
                            {
                                objEntity._RELOCVILLAGE = 0;
                            }
                            else
                            {
                                objEntity._RELOCVILLAGE = Int32.Parse(txtnoofRelocatevillage.Text);
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(txtnoofVilageremaining.Text)))
                            {
                                objEntity._REMAININGVILLAGE = 0;
                            }
                            else
                            {
                                objEntity._REMAININGVILLAGE = Int32.Parse(txtnoofVilageremaining.Text);
                            }
                            objEntity._STATENAME = ddlstate.SelectedValue;
                            objEntity._RESERVNAME = txtReserve.Text;
                            objEntity._REMARKS = txtremarks.Text;
                            if (string.IsNullOrEmpty(Convert.ToString(txtlandmoneyperfamily.Text)))
                            {
                                objEntity._MONEYANDLAND = 0;
                            }
                            else
                            {
                                objEntity._MONEYANDLAND = Int32.Parse(txtlandmoneyperfamily.Text);
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(txtAmountperfamily.Text)))
                            {
                                objEntity._MONEYPERFAMILY = 0;
                            }
                            else
                            {
                                objEntity._MONEYPERFAMILY = Int32.Parse(txtAmountperfamily.Text);
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(txtlandmoneyperfamily.Text)))
                            {
                                objEntity._LANDPACKAGE = 0;
                            }
                            else
                            {
                                objEntity._LANDPACKAGE = Int32.Parse(txtlandmoneyperfamily.Text);
                            }
                            if (string.IsNullOrEmpty(Convert.ToString(txtvillageReAnyotherpackge.Text)))
                            {
                                objEntity._RELOCOTHERPCK = 0;
                            }
                            else
                            {
                                objEntity._RELOCOTHERPCK = Int32.Parse(txtvillageReAnyotherpackge.Text);
                            }
                            if (chkCondition1() == true)
                            {
                                int i = dal.Insert_Relocation_Progress_Deatil(objEntity);
                                if (i > 0)
                                {
                                    lblmsg.Text = "Record Insert Successfuly";
                                    lblmsg.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    lblmsg.Text = "Please try! later.";
                                    lblmsg.ForeColor = System.Drawing.Color.Red;
                                }
                            }

                        }
                   // }
                }
            }
        }
        catch
        {
            throw;
        }
        // }
    }

    
    bool chkCondition1()
    {
        LbltxtnoofRelocatevillage.Text = "";
        LbltxtnoofRelocatedFamily.Text = "";
        LbltxtAmountperfamily.Text = "";
        Lbltxtlandpackage.Text = "";
        Lbltxtlandmoneyperfamily.Text = "";
        bool chk = true;
        try
        {
            //'No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger' ->
            //-> value not greater but value can be equal of 'No. of the villages in the notified Core (CTH)'
            //int txtnoofRelocatevillage=txtnoofRelocatevillage.tex
           int noofRelocatevillage =Convert.ToInt32(txtnoofRelocatevillage.Text.Trim());
           int Novillage =Convert.ToInt32(txtNovillage.Text.Trim());
          //  5 8
            if(Novillage < noofRelocatevillage)
            {
                LbltxtnoofRelocatevillage.Text = "[No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger] value not be greater but value can be equal of [No. of the villages in the notified Core (CTH)]";
                LbltxtnoofRelocatevillage.ForeColor = System.Drawing.Color.Red;
                txtnoofRelocatevillage.Focus();
                return false;
            }
            //--------------------------
            //No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger
            //value not be greater but value can be equal of
            //No. of the families in the notified Core (CTH)

            int noofRelocatedFamily = Convert.ToInt32(txtnoofRelocatedFamily.Text.Trim());
           int Nooffamily=Convert.ToInt32(txtNooffamily.Text.Trim());
           if (Nooffamily < noofRelocatedFamily)
           {
               LbltxtnoofRelocatedFamily.Text = "[No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger] value not be greater but value can be equal of [No. of the families in the notified Core (CTH)]";
               LbltxtnoofRelocatevillage.ForeColor = System.Drawing.Color.Red;
               txtnoofRelocatedFamily.Focus();
               return false;
           }
            //----------------------
            //10 Lakh per Family  
            //Land Packageable 
            //1 Lakh per Family & Landable  
            //all 3 labels above each value shouldn't be greater but value can be equal of
            //No. of the families in the notified Core (CTH)  

           int contentbodytxtAmountperfamily = Convert.ToInt32(txtAmountperfamily.Text.Trim());
           int contentbodytxtlandpackage = Convert.ToInt32(txtlandpackage.Text.Trim());
           int contentbodytxtlandmoneyperfamily = Convert.ToInt32(txtlandmoneyperfamily.Text.Trim());

           int contentbodytxtNooffamily = Convert.ToInt32(txtNooffamily.Text.Trim());
           
            if(contentbodytxtNooffamily < contentbodytxtAmountperfamily)
            {
                LbltxtAmountperfamily.Text = "[10 Lakh per Family] value shouldn't be greater but value can be equal of [No. of the families in the notified Core (CTH)]";
                LbltxtAmountperfamily.ForeColor = System.Drawing.Color.Red;
                txtAmountperfamily.Focus();
                return false;
            }
            if (contentbodytxtNooffamily < contentbodytxtlandpackage)
            {
                Lbltxtlandpackage.Text = "[Land Packageable] value shouldn't be greater but value can be equal of [No. of the families in the notified Core (CTH)]";
                Lbltxtlandpackage.ForeColor = System.Drawing.Color.Red;
                txtlandpackage.Focus();
                return false;
            }
            if (contentbodytxtNooffamily < contentbodytxtlandmoneyperfamily)
            {
                Lbltxtlandmoneyperfamily.Text = "[1 Lakh per Family & Landable] value shouldn't be greater but value can be equal of [No. of the families in the notified Core (CTH)]";
                Lbltxtlandmoneyperfamily.ForeColor = System.Drawing.Color.Red;
                txtlandmoneyperfamily.Focus();
                return false;
            }
        }
        catch (Exception er)
        {
           
        }
        return chk;
    }
    public void update_deatil()
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

                        if (chkCondition1() == true)
                        {
                            int id = Int32.Parse(Request.QueryString["id"]);
                            objEntity._DATE = txtDate.Text;
                            objEntity._FAMILY = Int32.Parse(txtNooffamily.Text);
                            objEntity._REMAINFAMILY = Int32.Parse(txtnooffamilyreaming.Text);
                            objEntity._RELOCFAMILY = Int32.Parse(txtnoofRelocatedFamily.Text);
                            objEntity._VILLAGE = Int32.Parse(txtNovillage.Text);
                            objEntity._RELOCVILLAGE = Int32.Parse(txtnoofRelocatevillage.Text);
                            objEntity._REMAININGVILLAGE = Int32.Parse(txtnoofVilageremaining.Text);
                            objEntity._STATENAME = ddlstate.SelectedValue;
                            objEntity._RESERVNAME = txtReserve.Text;
                            objEntity._REMARKS = txtremarks.Text;
                            objEntity._MONEYANDLAND = Int32.Parse(txtlandmoneyperfamily.Text);
                            objEntity._MONEYPERFAMILY = Int32.Parse(txtAmountperfamily.Text);
                            objEntity._LANDPACKAGE = Int32.Parse(txtlandpackage.Text);
                            objEntity._RELOCOTHERPCK = Int32.Parse(txtvillageReAnyotherpackge.Text);
                            int i = dal.Update_Relocation_Progress_Deatil(objEntity, id);
                            if (i > 0)
                            {
                                lblmsg.Text = "Record Update Successly";
                                lblmsg.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            throw;
        }
        // }
    }
    

    public void reset()
    {
        if (Request.QueryString["Operation"].ToString() == "1")
        {
            Response.Redirect(ResolveUrl("~/auth/adminpanel/Villagerelocationprogress/Relocation_Progress_Report.aspx?Operation=1"));
        }
        else
        {
            //txtDate.Text = "";
            //ddlstate.SelectedValue = "0";
            txtAmountperfamily.Text = "";
            txtlandmoneyperfamily.Text = "";
            txtlandpackage.Text = "";
            txtNooffamily.Text = "";
            txtNovillage.Text = "";
            txtnoofRelocatedFamily.Text = "";
            txtnoofRelocatevillage.Text = "";
            txtnoofVilageremaining.Text = "";
            txtnooffamilyreaming.Text = "";
            txtremarks.Text = "";
            txtvillageReAnyotherpackge.Text = "";
            //txtReserve.Text = "";
        }
    }

    public void fillstate()
    {
        DataSet ds = relocationprogress.statefordropedown();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlstate.Items.Clear();
            ddlstate.DataSource = ds.Tables[0];
            ddlstate.DataTextField = "st_name";
            ddlstate.DataValueField = "st_id";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void CheckRecordExistenceAfterSave()
    {
        lblmsg.Text = string.Empty;
        DataSet ds = relocationprogress.CheckRecordExistenceAfterSaveM(Convert.ToInt32(Session["User_Id"]));
        if (ds.Tables[0].Rows.Count > 0)
        {
            TblForm.Visible = false;
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Text = "Already you have added record.you can only do update,delete!.";
        }
        else
        {
            TblForm.Visible = true;
        }
    }
    public void filldeatil()
    {
        int id = Int32.Parse(Request.QueryString["id"]);
        DataSet ds = dal.select_record_for_update(id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
            ddlstate.SelectedValue = ds.Tables[0].Rows[0]["StateName"].ToString();
            txtAmountperfamily.Text = ds.Tables[0].Rows[0]["MoneyPerfam"].ToString();
            txtlandmoneyperfamily.Text = ds.Tables[0].Rows[0]["landAndMoney"].ToString();
            txtlandpackage.Text = ds.Tables[0].Rows[0]["LandPackge"].ToString();
            txtNooffamily.Text = ds.Tables[0].Rows[0]["Family"].ToString();
            txtNovillage.Text = ds.Tables[0].Rows[0]["Village"].ToString();
            txtnoofRelocatedFamily.Text = ds.Tables[0].Rows[0]["RelocateFam"].ToString();
            txtnoofRelocatevillage.Text = ds.Tables[0].Rows[0]["RelocatedVill"].ToString();
            txtnoofVilageremaining.Text = ds.Tables[0].Rows[0]["RemainVill"].ToString();
            txtnooffamilyreaming.Text = ds.Tables[0].Rows[0]["RemainFam"].ToString();
            txtremarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            txtvillageReAnyotherpackge.Text = ds.Tables[0].Rows[0]["VillRelocOtherPack"].ToString();
            txtReserve.Text = ds.Tables[0].Rows[0]["ReserveId"].ToString();
            txtReserve.Text = ds.Tables[0].Rows[0]["TigerReserveName"].ToString();
            ddlstate.SelectedValue = ds.Tables[0].Rows[0]["StateID"].ToString();



        }
    }
}