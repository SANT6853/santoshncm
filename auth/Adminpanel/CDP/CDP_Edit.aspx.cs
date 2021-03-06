using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_CDP_CDP_Edit : CrsfBase

{
    VillageDB VILL_DB_Obj = new VillageDB();
    FamilyDB FMLYDB_Obj = new FamilyDB();
    CommonDB comDB_Obj = new CommonDB();
    common com_Obj = new common();
    NgoDB NDB = new NgoDB();
    AddworkEntity ADDWRKENT_Obj = new AddworkEntity();
    CDP_Info_Entity INFOEnt_Obj = new CDP_Info_Entity();
    NgoEntity NE = new NgoEntity();
    public static int rel_id, cdpwrkid, CdpPrimaryID;
    public static bool flagupdate1 = false, flaupdate2 = false;
    public static Int64 NGO_ID;
    AuditTrailDB Audit_ObjDB = new AuditTrailDB();
    protected void Page_Load(object sender, EventArgs e)
    {
       // flagupdate1 = false;
        lblMsg.Text = "";
        lblMsg1.Text = "";
        //   gvForwork.Columns[5].Visible = false;
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), false);
        }
        //if (Session["UserRole"].ToString().Equals("3"))
        //{
        //    Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/RedirectPage.aspx"), false);
        //}
        if (!Page.IsPostBack)
        {

            if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != null && !Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString().Equals(""))
            {

                FillALL(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
                //FillRelocation_Site_Address(Request.QueryString["villid"].ToString());
                  

            }

        }

    }
    protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
    {
        Miscelleneous_BL miscellBL = new Miscelleneous_BL();

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
    public void FillALL(string villid)
    {
     // if (Page.IsValid)
     //  {
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
                           //try
                           //{
                               DataSet ds = VILL_DB_Obj.Get_OthersIDs_By_VillId(villid.ToString());
                               if (ds.Tables[0].Rows.Count > 0)
                               {

                                   lblvillname.Text = ds.Tables[0].Rows[0][1].ToString();
                                   lblreaserve.Text = ds.Tables[0].Rows[0]["TigerReserveName"].ToString();
                                   DataSet ds2 = comDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(ds.Tables[0].Rows[0]["CmnStateID"].ToString(), ds.Tables[0].Rows[0][4].ToString(), ds.Tables[0].Rows[0]["CmnDataOperatorTigerReserveID"].ToString(), ds.Tables[0].Rows[0][5].ToString(), ds.Tables[0].Rows[0][6].ToString());
                                   if (ds2.Tables[0].Rows.Count > 0)
                                   {
                                       lblstatename.Text = ds2.Tables[0].Rows[0]["St_Name"].ToString();
                                       lbldistrict.Text = ds2.Tables[1].Rows[0][0].ToString();

                                       lbltehsil.Text = ds2.Tables[2].Rows[0][0].ToString();
                                       lblgp.Text = ds2.Tables[3].Rows[0][0].ToString();
                                   }
                                   DataSet ds3 = VILL_DB_Obj.Get_Relocation_Village_By_ID(villid);
                                   if (ds3.Tables[0].Rows.Count > 0)
                                   {//-----------------------
                                       rel_id = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);
                                       lblstatename1.Text = ds3.Tables[0].Rows[0]["ST_NM"].ToString();
                                       lbldistrictname.Text = ds3.Tables[0].Rows[0]["DT_NM"].ToString();
                                       //  lblteshsil.Text = ds3.Tables[0].Rows[0]["TH_NM"].ToString();
                                       lblteshsil.Text = ds3.Tables[0].Rows[0]["Tehsil_NameString"].ToString();
                                       // lblgpname.Text = ds3.Tables[0].Rows[0]["GP_NM"].ToString();
                                       lblgpname.Text = ds3.Tables[0].Rows[0]["GramPanchayatNameString"].ToString();
                                       // lblvillage.Text = ds3.Tables[0].Rows[0]["VILL_NM"].ToString();
                                       lblvillage.Text = ds3.Tables[0].Rows[0]["VILL_NMString"].ToString();
                                   }

                                   DataSet ds4 = VILL_DB_Obj.Get_CDPAmount_By_Village_ID(villid);
                                   if (ds4.Tables[0].Rows.Count > 0)
                                   {

                                       lbltotalamt.Text = ds4.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString();//Amount Allocated For CDP Rs.:
                                       lblamtused.Text = ds4.Tables[0].Rows[0]["CDP_AMT_USD"].ToString();//Amount Used(Rs):

                                       if (lbltotalamt.Text == "")
                                       {
                                           lbltotalamt.Text = "0";
                                       }
                                       if (lblamtused.Text == "")
                                       {
                                           lblamtused.Text = "0";
                                       }
                                   }
                                   DataSet ds5 = FMLYDB_Obj.Get_Data_FromCDP_Info(villid);
                                   if (ds5.Tables[0].Rows.Count > 0)
                                   {
                                       ddlselectstatus.SelectedValue = ds5.Tables[0].Rows[0]["CDP_STS_LND"].ToString();
                                       rel_id = Convert.ToInt32(ds5.Tables[0].Rows[0][1]);

                                   }
                                   BindMembers();
                               }
                           //}
                           //catch (Exception e3)
                           //{
                           //    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e3.Message.ToString();

                           //}
                           if (lbltotalamt.Text != "0" && lblamtused.Text != "0")
                           {
                               ImageButton1.Visible = true;
                           }
                           else
                           {
                               ImageButton1.Visible = false;
                           }
                       }
                   }
               }

           }
           catch
           {
               throw;
           }
           

     //  }

    }
    protected void ImgbtnCancel1_Click(object sender, EventArgs e)
    {
        ResetAllFields();
        //    ModalPopupExtender1.Hide();
    }
    protected void btnback_Click(object sender, EventArgs e)
    {

        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Management.aspx?pindex=" + Request.QueryString["inid"].ToString() + "&vid=" + Request.QueryString["vid"].ToString()), false);


    }
    public void BindMembers()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = FMLYDB_Obj.Display_All_Work_From_Original(Request.QueryString["village_id"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvForwork.Visible = true;
                //forpaging.Visible = true;
                gvForwork.DataSource = ds.Tables[0];
                gvForwork.DataBind();
            }
            else
            {

                gvForwork.Visible = false;
                // forpaging.Visible = false;

            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void ResetAllFields()
    {
        TxtAmntAllcteCdpVillRe.Text = "";
        TxtAmountCentraState.Text = "";

        Textcdpwork.Text = "";
        txtalltdamt.Text = "";
        txtamtusd.Text = "";
        txtagency.Text = "";
        txtcomment.Text = "";



    }
    protected void gvForwork_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvForwork_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Page.IsValid)
        {
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
                            if (e.CommandName == "Delete")
                            {
                                int id = Convert.ToInt32(e.CommandArgument.ToString());
                                bool val = VILL_DB_Obj.Delete_BY_CDP_WRK_INFO_ID_From_Original(Convert.ToInt32(e.CommandArgument.ToString()));
                                FillALL(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
                               // BindMembers();


                                //if (val == true)
                                //{

                                //    lblMsg.Text = "CDP work Deleted Successfully";
                                //    lblMsg.ForeColor = System.Drawing.Color.Green;
                                //    BindMembers();
                                //}
                                //else
                                //{
                                //    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                //    lblMsg.ForeColor = System.Drawing.Color.Red;


                                //}
           

                            }
                            if (e.CommandName == "Edit")
                            {
                                hypfile.Visible = true;
                                DataSet ds6 = VILL_DB_Obj.Get_CDPData_By_CDP_WRK_INFO_ID(Convert.ToInt32(e.CommandArgument.ToString()));
                                CdpPrimaryID = Convert.ToInt32(e.CommandArgument.ToString());
                                if (ds6.Tables[0].Rows.Count > 0)
                                {
                                    cdpwrkid = Convert.ToInt32(ds6.Tables[0].Rows[0][0]);
                                    Textcdpwork.Text = ds6.Tables[0].Rows[0]["CDP_WRK_NM"].ToString();
                                    txtalltdamt.Text = ds6.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString();
                                    txtamtusd.Text = ds6.Tables[0].Rows[0]["CDP_AMT_USD"].ToString();
                                    txtagency.Text = ds6.Tables[0].Rows[0]["CDP_AGENCY"].ToString();
                                    txtcomment.Text = ds6.Tables[0].Rows[0]["COMMENT"].ToString();

                                    //7june
                                    TxtAmntAllcteCdpVillRe.Text = ds6.Tables[0].Rows[0]["AmntAllcteCdpVillRe"].ToString();
                                    TxtAmountCentraState.Text = ds6.Tables[0].Rows[0]["AmountCentraState"].ToString();
                                    hypfile.Text = ds6.Tables[0].Rows[0]["FileNames"].ToString();
                                    //  filename = ds6.Tables[0].Rows[0]["FileNames"].ToString();
                                    hypfile.NavigateUrl = ResolveUrl("~/WriteReadData/CDP/") + ds6.Tables[0].Rows[0]["FileNames"].ToString(); ;
                                    //end



                                    ModalPopupExtender1.Show();
                                    flagupdate1 = true;
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
        }
    }
    protected void gvForwork_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void ImgbtnSubmitMember_Click(object sender, EventArgs e)
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
                       //{
                            if (Page.IsValid)
                            {
                                try
                                {
                                    if (ddlselectstatus.SelectedValue.ToString().Equals("0"))
                                    {
                                        lblMsg.Text = "Please Select Village Status";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                        return;
                                    }
                                    INFOEnt_Obj._CDP_STS_LND = ddlselectstatus.SelectedValue.ToString();
                                    INFOEnt_Obj._CDP_AMT_USD = Convert.ToDouble(lblamtused.Text);
                                    INFOEnt_Obj._CDP_ALLTD_AMT = Convert.ToDouble(lbltotalamt.Text);
                                    INFOEnt_Obj._CDP_Village_ID = Convert.ToInt32(Request.QueryString[WebConstant.QueryStringEnum.VillageID]);
                                    INFOEnt_Obj._CDP_RELOCATION_ID = rel_id;

                                    bool val = FMLYDB_Obj.UpdateWorkIn_CDP_Info(INFOEnt_Obj);
                                    if (val == true)
                                    {
                                        lblMsg.Text = "CDP Details  Updated Successfully";
                                        lblMsg.ForeColor = System.Drawing.Color.Green;
                                        Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 4);
                                    }
                                    else
                                    {
                                        lblMsg.Text = "Error Occur. Please Try Later";
                                    }
                                }
                                catch (Exception e4)
                                {
                                    // ResetAllFieldsOfAssets();
                                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e4.Message.ToString();
                                    lblMsg.ForeColor = System.Drawing.Color.Red;

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

        //}
    }
    public void ShowCDPWrokData(int cdpwrkid1)
    {
        DataSet ds6 = VILL_DB_Obj.Get_CDPData_By_CDP_WRK_INFO_ID(cdpwrkid1);
        if (ds6.Tables[0].Rows.Count > 0)
        {
            cdpwrkid = Convert.ToInt32(ds6.Tables[0].Rows[0][0]);
            Textcdpwork.Text = ds6.Tables[0].Rows[0]["CDP_WRK_NM"].ToString();
            txtalltdamt.Text = ds6.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString();
            txtamtusd.Text = ds6.Tables[0].Rows[0]["CDP_AMT_USD"].ToString();
            txtagency.Text = ds6.Tables[0].Rows[0]["CDP_AGENCY"].ToString();
            txtcomment.Text = ds6.Tables[0].Rows[0]["COMMENT"].ToString();
            ModalPopupExtender1.Show();
            flagupdate1 = true;
        }
    }
    protected void imgbtnpopupwork_Click(object sender, EventArgs e)
    {
        Textcdpwork.Text = "";
        txtalltdamt.Text = "";
        txtamtusd.Text = "";
        TxtAmntAllcteCdpVillRe.Text = "";
        TxtAmountCentraState.Text = "";
        txtagency.Text = "";
        txtcomment.Text = "";
        ModalPopupExtender1.Show();
    }
    protected void imgbtnaddwork_Click(object sender, EventArgs e)
    {
      if (Page.IsValid)
      {
         try
         {

            string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
            string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);
            if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
            {
                if (CurrentSessionId == hdnblank)
                {
                     //if (Page.IsValid)
                     //{

                      if (Page.IsValid)
                      {
                            if (flagupdate1 == false)
                            {
                                    #region collapse1
                                    //7june start
                                    if (TxtAmntAllcteCdpVillRe.Text != "")
                                    {
                                        INFOEnt_Obj.AmntAllcteCdpVillRe = Convert.ToDouble(TxtAmntAllcteCdpVillRe.Text.Trim()); ;
                                    }
                                    else
                                    {
                                        INFOEnt_Obj.AmntAllcteCdpVillRe = 0;
                                    }
                                    if (TxtAmountCentraState.Text != "")
                                    {
                                        INFOEnt_Obj.AmountCentraState = Convert.ToDouble(TxtAmountCentraState.Text.Trim()); ;
                                    }
                                    else
                                    {
                                        INFOEnt_Obj.AmountCentraState = 0;
                                    }
                                    Project_Variables p_Var = new Project_Variables();
                                    if (fileUpload_Menu.PostedFile != null && fileUpload_Menu.PostedFile.InputStream.Length != 0)
                                    {
                                        p_Var.ext = System.IO.Path.GetExtension(this.fileUpload_Menu.PostedFile.FileName);
                                        p_Var.ext = p_Var.ext.ToUpper();
                                        if (p_Var.ext.Equals(".PDF") || p_Var.ext.Equals(".XLSX") || p_Var.ext.Equals(".DOCX") || p_Var.ext.Equals(".DOC"))
                                        {
                                            //p_Var.Path = "~/" + ConfigurationManager.AppSettings["WriteReadData"];
                                            //p_Var.Path = p_Var.Path + "/" + ConfigurationManager.AppSettings["CDP"];
                                            //p_Var.Filename = fileUpload_Menu.FileName;
                                            //fileUpload_Menu.SaveAs(Server.MapPath(p_Var.Path + "/" + p_Var.Filename));
                                            p_Var.Path = ResolveUrl("~") + "WriteReadData/CDP";
                                            p_Var.Filename = com_Obj.getUniqueFileName(fileUpload_Menu.FileName.ToString(), Server.MapPath(p_Var.Path), System.IO.Path.GetFileNameWithoutExtension(fileUpload_Menu.PostedFile.FileName), p_Var.ext);
                                            p_Var.Path = ResolveUrl("~") + "WriteReadData/CDP/" + p_Var.Filename;
                                            fileUpload_Menu.PostedFile.SaveAs(Server.MapPath(p_Var.Path));
                                            INFOEnt_Obj.FileNames = p_Var.Filename;
                                        }
                                    }

                                    //7june end
                                    if (Convert.ToDouble(lbltotalamt.Text) < Convert.ToDouble(lblamtused.Text))
                                    {
                                        lblMsg.Text = "";
                                        return;
                                    }
                                    if (lbltotalamt.Text != "0" && lblamtused.Text != "0")
                                    {
                                        if ((Convert.ToDouble(txtalltdamt.Text) <= Convert.ToDouble(lbltotalamt.Text)) && (Convert.ToDouble(txtamtusd.Text) <= Convert.ToDouble(txtalltdamt.Text)))
                                        {
                                            try
                                            {
                                                if (txtalltdamt.Text.Trim() == "")
                                                {
                                                    INFOEnt_Obj._CDP_ALLTD_AMT = 0;
                                                }
                                                else
                                                {
                                                    INFOEnt_Obj._CDP_ALLTD_AMT = Convert.ToDouble(txtalltdamt.Text.Trim());
                                                }
                                                //INFOEnt_Obj._GRP_ID = Request.QueryString["grpid"].ToString();
                                                INFOEnt_Obj._CDP_Village_ID = Convert.ToInt32(Request.QueryString[WebConstant.QueryStringEnum.VillageID]);
                                                INFOEnt_Obj._CDP_ALLTD_AMT = Convert.ToDouble(txtalltdamt.Text);
                                                INFOEnt_Obj._CDP_AMT_USD = Convert.ToDouble(txtamtusd.Text);
                                                INFOEnt_Obj._CDP_EXECUTION_AGENCY = common.RemoveUnnecessaryHtmlTagHtml(txtagency.Text.Trim());
                                                INFOEnt_Obj._CDP_WORK = common.RemoveUnnecessaryHtmlTagHtml(Textcdpwork.Text.Trim());
                                                INFOEnt_Obj._COMMENT = common.RemoveUnnecessaryHtmlTagHtml(txtcomment.Text.Trim());
                                                INFOEnt_Obj._CDP_RELOCATION_ID = rel_id;
                                                //random number generate
                                                var random = new Random();
                                                string s = string.Empty;
                                                for (int i = 0; i < 5; i++)
                                                    s = String.Concat(s, random.Next(10).ToString());

                                                //------
                                                INFOEnt_Obj.CdpPrimaryID = Convert.ToInt32(s);
                                                //INFOEnt_Obj._CDP_STS_LND = ddlselectstatus.SelectedValue.ToString();
                                                bool check = FMLYDB_Obj.AddCDPInfo_From_Original(INFOEnt_Obj);
                                                if (check == true)
                                                {
                                                    lblMsg.Text = "New Work Inserted Successfully";
                                                    lblMsg.ForeColor = System.Drawing.Color.Green;
                                                    double total = (Convert.ToDouble(lblamtused.Text) + Convert.ToDouble(txtamtusd.Text));
                                                    lblamtused.Text = total.ToString();
                                                    ModalPopupExtender1.Hide();
                                                    BindMembers();
                                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 4);

                                                }
                                                else
                                                {
                                                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                                }
                                            }
                                            catch (Exception e4)
                                            {
                                                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e4.Message.ToString();
                                                lblMsg.ForeColor = System.Drawing.Color.Red;

                                            }
                                        }//---------------
                                    }
                                    if (lbltotalamt.Text == "0" && lblamtused.Text == "0")
                                    {
                                        try
                                        {
                                            if (txtalltdamt.Text.Trim() == "")
                                            {
                                                INFOEnt_Obj._CDP_ALLTD_AMT = 0;
                                            }
                                            else
                                            {
                                                INFOEnt_Obj._CDP_ALLTD_AMT = Convert.ToDouble(txtalltdamt.Text.Trim());
                                            }
                                            //INFOEnt_Obj._GRP_ID = Request.QueryString["grpid"].ToString();
                                            INFOEnt_Obj._CDP_Village_ID = Convert.ToInt32(Request.QueryString[WebConstant.QueryStringEnum.VillageID]);
                                            INFOEnt_Obj._CDP_ALLTD_AMT = Convert.ToDouble(txtalltdamt.Text);
                                            INFOEnt_Obj._CDP_AMT_USD = Convert.ToDouble(txtamtusd.Text);
                                            INFOEnt_Obj._CDP_EXECUTION_AGENCY = common.RemoveUnnecessaryHtmlTagHtml(txtagency.Text.Trim());
                                            INFOEnt_Obj._CDP_WORK = common.RemoveUnnecessaryHtmlTagHtml(Textcdpwork.Text.Trim());
                                            INFOEnt_Obj._COMMENT = common.RemoveUnnecessaryHtmlTagHtml(txtcomment.Text.Trim());
                                            INFOEnt_Obj._CDP_RELOCATION_ID = rel_id;
                                            //random number generate
                                            var random = new Random();
                                            string s = string.Empty;
                                            for (int i = 0; i < 5; i++)
                                                s = String.Concat(s, random.Next(10).ToString());

                                            //------
                                            INFOEnt_Obj.CdpPrimaryID = Convert.ToInt32(s);
                                            //INFOEnt_Obj._CDP_STS_LND = ddlselectstatus.SelectedValue.ToString();
                                            bool check = FMLYDB_Obj.AddCDPInfo_From_Original(INFOEnt_Obj);
                                            if (check == true)
                                            {
                                                lblMsg.Text = "New Work Inserted Successfully";
                                                lblMsg.ForeColor = System.Drawing.Color.Green;
                                                double total = (Convert.ToDouble(lblamtused.Text) + Convert.ToDouble(txtamtusd.Text));
                                                lblamtused.Text = total.ToString();
                                                ModalPopupExtender1.Hide();
                                                BindMembers();
                                                Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 4);

                                            }
                                            else
                                            {
                                                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                                lblMsg.ForeColor = System.Drawing.Color.Red;
                                            }
                                        }
                                        catch (Exception e4)
                                        {
                                            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e4.Message.ToString();
                                            lblMsg.ForeColor = System.Drawing.Color.Red;
                                            lblMsg.ForeColor = System.Drawing.Color.Red;

                                        }
                                    }
                                    if (lbltotalamt.Text != "0" && lblamtused.Text != "0")
                                    {
                                        if ((Convert.ToDouble(txtalltdamt.Text) > Convert.ToDouble(lbltotalamt.Text)))
                                        {
                                            lblMsg1.Text = "Entered allotement amount is greater than the Totol alloted amount";
                                            lblMsg1.ForeColor = System.Drawing.Color.Red;
                                            ModalPopupExtender1.Show();
                                            return;
                                        }
                                    }
                                    if (Convert.ToDouble(txtamtusd.Text) > Convert.ToDouble(txtalltdamt.Text))
                                    {

                                        lblMsg1.Text = "Amount used  can not greater than the  alloted amount";
                                        lblMsg1.ForeColor = System.Drawing.Color.Red;
                                        ModalPopupExtender1.Show();
                                        return;
                                    }
                                    #endregion
                                }

                            }

                            if (flagupdate1 == true)
                            {
                                #region collapse2
                                //7june start
                                if (TxtAmntAllcteCdpVillRe.Text != "")
                                {
                                    INFOEnt_Obj.AmntAllcteCdpVillRe = Convert.ToDouble(TxtAmntAllcteCdpVillRe.Text.Trim()); ;
                                }
                                else
                                {
                                    INFOEnt_Obj.AmntAllcteCdpVillRe = 0;
                                }
                                if (TxtAmountCentraState.Text != "")
                                {
                                    INFOEnt_Obj.AmountCentraState = Convert.ToDouble(TxtAmountCentraState.Text.Trim()); ;
                                }
                                else
                                {
                                    INFOEnt_Obj.AmountCentraState = 0;
                                }
                                hypfile.Visible = true;
                                Project_Variables p_Var = new Project_Variables();

                                string UploadFileName = fileUpload_Menu.PostedFile.FileName;
                                if (UploadFileName == "")
                                {
                                    INFOEnt_Obj.FileNames = hypfile.Text.Trim();

                                }
                                else
                                {
                                    if (fileUpload_Menu.PostedFile != null && fileUpload_Menu.PostedFile.InputStream.Length != 0)
                                    {
                                        p_Var.ext = System.IO.Path.GetExtension(this.fileUpload_Menu.PostedFile.FileName);
                                        p_Var.ext = p_Var.ext.ToUpper();
                                        if (p_Var.ext.Equals(".PDF") || p_Var.ext.Equals(".XLSX") || p_Var.ext.Equals(".DOCX") || p_Var.ext.Equals(".DOC"))
                                        {
                                            //p_Var.Path = "~/" + ConfigurationManager.AppSettings["WriteReadData"];
                                            //p_Var.Path = p_Var.Path + "/" + ConfigurationManager.AppSettings["CDP"];
                                            //p_Var.Filename = fileUpload_Menu.FileName;
                                            //fileUpload_Menu.SaveAs(Server.MapPath(p_Var.Path + "/" + p_Var.Filename));
                                            p_Var.Path = ResolveUrl("~") + "WriteReadData/CDP";
                                            p_Var.Filename = com_Obj.getUniqueFileName(fileUpload_Menu.FileName.ToString(), Server.MapPath(p_Var.Path), System.IO.Path.GetFileNameWithoutExtension(fileUpload_Menu.PostedFile.FileName), p_Var.ext);
                                            p_Var.Path = ResolveUrl("~") + "WriteReadData/CDP/" + p_Var.Filename;
                                            fileUpload_Menu.PostedFile.SaveAs(Server.MapPath(p_Var.Path));
                                            INFOEnt_Obj.FileNames = p_Var.Filename;
                                        }
                                    }
                                }
                                //7june end
                                if (Convert.ToDouble(txtamtusd.Text) < Convert.ToDouble(txtalltdamt.Text))
                                {
                                    try
                                    {
                                        if (txtalltdamt.Text.Trim() == "")
                                        {
                                            INFOEnt_Obj._CDP_ALLTD_AMT = 0;
                                        }
                                        else
                                        {
                                            INFOEnt_Obj._CDP_ALLTD_AMT = Convert.ToDouble(txtalltdamt.Text.Trim());
                                        }

                                        INFOEnt_Obj._CDP_Village_ID = Convert.ToInt32(Request.QueryString[WebConstant.QueryStringEnum.VillageID]);
                                        INFOEnt_Obj._CDP_ALLTD_AMT = Convert.ToDouble(txtalltdamt.Text);
                                        INFOEnt_Obj._CDP_AMT_USD = Convert.ToDouble(txtamtusd.Text);
                                        INFOEnt_Obj._CDP_EXECUTION_AGENCY = common.RemoveUnnecessaryHtmlTagHtml(txtagency.Text.Trim());
                                        INFOEnt_Obj._CDP_WORK = common.RemoveUnnecessaryHtmlTagHtml(Textcdpwork.Text.Trim());
                                        INFOEnt_Obj._COMMENT = common.RemoveUnnecessaryHtmlTagHtml(txtcomment.Text.Trim());
                                        INFOEnt_Obj._CDP_RELOCATION_ID = rel_id;
                                        INFOEnt_Obj.CdpPrimaryID = CdpPrimaryID;
                                        //INFOEnt_Obj._CDP_STS_LND = ddlselectstatus.SelectedValue.ToString();
                                        bool check = FMLYDB_Obj.Update_CDPInfo_Fron_Original(INFOEnt_Obj, cdpwrkid);
                                        if (check == true)
                                        {
                                            lblMsg.Text = "Work Updated Successfully";
                                            lblMsg.ForeColor = System.Drawing.Color.Green;
                                            DataSet ds4 = VILL_DB_Obj.Get_CDPAmount_By_Village_ID(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
                                            if (ds4.Tables[0].Rows.Count > 0)
                                            {
                                                lbltotalamt.Text = ds4.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString();
                                                lblamtused.Text = ds4.Tables[0].Rows[0]["CDP_AMT_USD"].ToString();
                                            }
                                            ModalPopupExtender1.Hide();
                                            BindMembers();
                                            Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 4);
                                        }
                                        else
                                        {
                                            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                            lblMsg.ForeColor = System.Drawing.Color.Red;
                                        }
                                    }
                                    catch (Exception e4)
                                    {
                                        //               ResetAllFieldsOfAssets();
                                        lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e4.Message.ToString();
                                        lblMsg.ForeColor = System.Drawing.Color.Red;

                                    }
                                }
                                flagupdate1 = false;
                                #endregion
                            }
                            FillALL(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
                            if (lbltotalamt.Text != "0" && lblamtused.Text != "0")
                            {
                                ImageButton1.Visible = true;
                            }
                            else
                            {
                                ImageButton1.Visible = false;
                            }
                        //}
                    }
                }
            }

            catch
            {
                throw;
            }
        }
    }
    protected void imgbtnreset_Click(object sender, EventArgs e)
    {
        if (flagupdate1 == false)
        {
            ResetAllFields();
        }
        else if (flagupdate1 == true)
        {
            ShowCDPWrokData(cdpwrkid);
        }
        ModalPopupExtender1.Show();
    }
    protected void imgbtncancel_Click(object sender, EventArgs e)
    {

        ResetAllFields();
        ModalPopupExtender1.Hide();
        flagupdate1 = false;
    }
    protected void Textcdpwork_TextChanged(object sender, EventArgs e)
    {

    }
}