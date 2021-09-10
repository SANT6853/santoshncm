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

public partial class auth_Adminpanel_CDP_CDP_Add : CrsfBase
{
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    VillageDB VILL_DB_Obj = new VillageDB();
    FamilyDB FMLYDB_Obj = new FamilyDB();
    CommonDB comDB_Obj = new CommonDB();
    common com_Obj = new common();
    AddworkEntity ADDWRKENT_Obj = new AddworkEntity();
    CDP_Info_Entity INFOEnt_Obj = new CDP_Info_Entity();
    public static int rel_id, cdpwrkid, CdpPrimaryID;
    public static bool flagupdate1 = false;
    int R, Q, T = 0;
    AuditTrailDB Audit_ObjDB = new AuditTrailDB();
    public string mime = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        lblMsg.Text = "";
        lblMsg1.Text = "";

        // gvForwork.Columns[5].Visible = false;
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), false);

        }

        if (!Page.IsPostBack)
        {
            gvForwork.Visible = false;
            flagupdate1 = false;

            if (Session["UserType"].ToString().Equals("4"))
            {
                if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != null && !Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString().Equals(""))
                {
                    ModalPopupExtender1.Hide();
                    FillALL(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
                    BindMembers();
                }
            }
            if (Session["UserType"].ToString().Equals("1"))
            {
                if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != null && !Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString().Equals(""))
                {
                    ModalPopupExtender1.Hide();
                    FillALL1(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
                    BindMembers();
                }
            }

        }

    }
    public void FillALL(string villid)
    {
        // if (Page.IsValid)
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
                            //  try
                            // {
                            DataSet ds = VILL_DB_Obj.Get_OthersIDs_By_VillId(villid.ToString());
                            if (ds.Tables[0].Rows.Count > 0)
                            {

                                lblvillname.Text = ds.Tables[0].Rows[0][1].ToString();
                                DataSet ds2 = comDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(Session["sStateID"].ToString(), ds.Tables[0].Rows[0][4].ToString(), Session["sTigerReserveid"].ToString(), ds.Tables[0].Rows[0][5].ToString(), ds.Tables[0].Rows[0][6].ToString());
                                if (ds2.Tables[0].Rows.Count > 0)
                                {
                                    lblstatename.Text = Session["sStateName"].ToString();
                                    lbldistrict.Text = ds2.Tables[1].Rows[0][0].ToString();
                                    lblreaserve.Text = Session["sTigerReserveName"].ToString();
                                    lbltehsil.Text = ds2.Tables[2].Rows[0][0].ToString();
                                    lblgp.Text = ds2.Tables[3].Rows[0][0].ToString();
                                }
                                DataSet ds3 = VILL_DB_Obj.Get_Relocation_Village_By_ID(villid);
                                if (ds3.Tables[0].Rows.Count > 0)
                                {
                                    rel_id = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);
                                    lblstatename1.Text = ds3.Tables[0].Rows[0]["ST_NM"].ToString();
                                    lbldistrictname.Text = ds3.Tables[0].Rows[0]["DT_NM"].ToString();
                                    lblteshsil.Text = ds3.Tables[0].Rows[0]["Tehsil_NameString"].ToString();
                                    lblgpname.Text = ds3.Tables[0].Rows[0]["GramPanchayatNameString"].ToString();
                                    lblvillage.Text = ds3.Tables[0].Rows[0]["VILL_NMString"].ToString();
                                }
                                else
                                {
                                    imgbtnpopupwork.Visible = false;
                                    lblMsg.Text = "Please Insert Relocation Site Details First";
                                    lblMsg.ForeColor = System.Drawing.Color.Red;
                                    ImageButton1.Enabled = false;
                                    ImageButton2.Enabled = false;
                                    btnback.Enabled = true;

                                    return;

                                }
                                DataSet ds4 = VILL_DB_Obj.Get_CDPAmount_By_Village_ID(villid);
                                if (ds4.Tables[0].Rows.Count > 0)
                                {
                                    if (!ds4.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString().Equals("0"))
                                    {
                                        lbltotalamt.Text = ds4.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString();
                                        //lblamtused.Text = ds4.Tables[0].Rows[0]["CDP_AMT_USD"].ToString();
                                        lblamtused.Text = "0.0";

                                    }
                                    else
                                    {
                                        imgbtnpopupwork.Visible = false;
                                        lblMsg.Text = "Not Applicable for This Village Because There Is No Family Who Opt Option II";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                        ImageButton1.Enabled = false;
                                        ImageButton2.Enabled = false;
                                        btnback.Enabled = true;

                                        return;
                                    }
                                }

                            }
                            // }
                            //catch (Exception e3)
                            //{
                            //    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e3.Message.ToString();
                            //    lblMsg.ForeColor = System.Drawing.Color.Red;
                            //}
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
    }

    public void FillALL1(string villid)
    {
        try
        {
            DataSet ds = VILL_DB_Obj.Get_OthersIDs_By_VillId(villid.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {

                lblvillname.Text = ds.Tables[0].Rows[0][1].ToString();

                DataSet ds2 = comDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(ds.Tables[0].Rows[0]["CmnStateID"].ToString(), ds.Tables[0].Rows[0][4].ToString(), ds.Tables[0].Rows[0]["CmnDataOperatorTigerReserveID"].ToString(), ds.Tables[0].Rows[0][5].ToString(), ds.Tables[0].Rows[0][6].ToString());
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    lblstatename.Text = ds2.Tables[0].Rows[0]["ST_NAME"].ToString();
                    lbldistrict.Text = ds2.Tables[1].Rows[0]["DT_NAME"].ToString();
                    lblreaserve.Text = ds2.Tables[4].Rows[0]["TigerReserveName"].ToString();
                    lbltehsil.Text = ds2.Tables[2].Rows[0][0].ToString();
                    lblgp.Text = ds2.Tables[3].Rows[0][0].ToString();
                }
                DataSet ds3 = VILL_DB_Obj.Get_Relocation_Village_By_ID(villid);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    rel_id = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);
                    lblstatename1.Text = ds3.Tables[0].Rows[0]["ST_NM"].ToString();
                    lbldistrictname.Text = ds3.Tables[0].Rows[0]["DT_NM"].ToString();
                    lblteshsil.Text = ds3.Tables[0].Rows[0]["Tehsil_NameString"].ToString();
                    lblgpname.Text = ds3.Tables[0].Rows[0]["GramPanchayatNameString"].ToString();
                    lblvillage.Text = ds3.Tables[0].Rows[0]["VILL_NMString"].ToString();

                    //rel_id = Convert.ToInt32(ds3.Tables[0].Rows[0][0]);
                    //lblstatename1.Text = ds3.Tables[0].Rows[0]["ST_NM"].ToString();
                    //lbldistrictname.Text = ds3.Tables[0].Rows[0]["DT_NM"].ToString();
                    //lblteshsil.Text = ds3.Tables[0].Rows[0]["TH_NM"].ToString();
                    //lblgpname.Text = ds3.Tables[0].Rows[0]["GP_NM"].ToString();
                    //lblvillage.Text = ds3.Tables[0].Rows[0]["VILL_NM"].ToString();
                }
                else
                {
                    imgbtnpopupwork.Visible = false;
                    lblMsg.Text = "Please Insert Relocation Site Details First";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    ImageButton1.Enabled = false;
                    ImageButton2.Enabled = false;
                    btnback.Enabled = true;

                    return;

                }
                DataSet ds4 = VILL_DB_Obj.Get_CDPAmount_By_Village_ID(villid);
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    if (!ds4.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString().Equals("0"))
                    {
                        lbltotalamt.Text = ds4.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString();
                        //lblamtused.Text = ds4.Tables[0].Rows[0]["CDP_AMT_USD"].ToString();
                        lblamtused.Text = "0.0";

                    }
                    else
                    {
                        imgbtnpopupwork.Visible = false;
                        lblMsg.Text = "Not Applicable for This Village Because There Is No Family Who Opt Option II";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        ImageButton1.Enabled = false;
                        ImageButton2.Enabled = false;
                        btnback.Enabled = true;

                        return;
                    }
                }

            }
        }
        catch (Exception e3)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e3.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    public void BindMembers()
    {
        try
        {
            DataSet ds = new DataSet();
            //  ds = FMLYDB_Obj.Display_All_Work();
            ds = FMLYDB_Obj.Display_All_Work1(Convert.ToInt32(Request.QueryString["village_id"]));
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
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    public void ResetAllFields()
    {
        Textcdpwork.Text = "";
        txtalltdamt.Text = "";
        txtamtusd.Text = "";
        txtagency.Text = "";
        txtcomment.Text = "";
        //txtsite.Text = "";


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
                                bool check = FMLYDB_Obj.AddDelete(id);
                                BindMembers();
                            }
                            if (e.CommandName == "Edit")
                            {
                                hypfile.Visible = true;
                                //int aa = Convert.ToInt32(e.CommandArgument);
                                DataSet ds6 = VILL_DB_Obj.Get_CDPTempData_By_CDP_WRK_INFO_ID1(Convert.ToInt32(e.CommandArgument.ToString()));
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

    public void ShowCDPWrokData(int cdpwrkid1)
    {
            DataSet ds6 = VILL_DB_Obj.Get_CDPTempData_By_CDP_WRK_INFO_ID(cdpwrkid1);
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
    void BindCdpAmountandUsedAmountTimeOfAdd()
    {

        try
        {
            DataSet ds = new DataSet();
            ds = FMLYDB_Obj.BindAmountUsedAmountOFCDPAddtime(Convert.ToInt32(Request.QueryString["village_id"]), Convert.ToInt32(rel_id));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbltotalamt.Text = ds.Tables[0].Rows[0]["CDP_ALLTD_AMT"].ToString();
                lblamtused.Text = ds.Tables[0].Rows[0]["CDP_AMT_USD"].ToString();
            }
            else
            {



            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
   
   // #region Custom validator to validate extension of upload pdf files
    [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
    private extern static System.UInt32 FindMimeFromData(System.UInt32 pBC,
    [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
    [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
    System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
    System.UInt32 dwMimeFlags,
    out System.UInt32 ppwzMimeOut,
    System.UInt32 dwReserverd);  


   protected void imgbtnaddwork_Click(object sender, EventArgs e)
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
                         // if(Page.IsValid)
                          //{
                        
                            if (lbltotalamt.Text == string.Empty)
                            {
                                lbltotalamt.Text = "0";
                            }
                          //  if (Page.IsValid)
                         //   {

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
				 Miscelleneous_DL dl = new Miscelleneous_DL();
                                HttpPostedFile file = fileUpload_Menu.PostedFile;
                                byte[] document = new byte[file.ContentLength];
                                file.InputStream.Read(document, 0, file.ContentLength);
                                System.UInt32 mimetype;
                                FindMimeFromData(0, null, document, 256, null, 0, out mimetype, 0);
                                System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                                mime = Marshal.PtrToStringUni(mimeTypePtr);
                                Marshal.FreeCoTaskMem(mimeTypePtr);
                                    if (fileUpload_Menu.PostedFile != null && fileUpload_Menu.PostedFile.InputStream.Length != 0)
                                    {
                                        p_Var.ext = System.IO.Path.GetExtension(this.fileUpload_Menu.PostedFile.FileName);
                                        p_Var.ext = p_Var.ext.ToUpper();
				 int count = fileUpload_Menu.PostedFile.FileName.Split('.').Length - 1;
                                    string contenttype = fileUpload_Menu.PostedFile.ContentType.ToString();
                                    if (count >= 2)
                                    {
                                        ClientScript.RegisterClientScriptBlock(this.GetType(), "showmessage", "<script language=\"JavaScript\"> alert('Double extension not allowed.') </script>");
                                        return;
                                    }

                                        
                                   // if ((p_Var.ext.Equals(".PDF") && mime.ToString().Equals("application/pdf")) || (p_Var.ext.Equals(".XLSX") && mime.ToString().Equals("application/x-zip-compressed")) || p_Var.ext.Equals(".DOCX") && mime.ToString().Equals("application/x-zip-compressed") || (p_Var.ext.Equals(".DOC") && mime.ToString().Equals("application/x-zip-compressed")) || (p_Var.ext.Equals(".jpg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".jpeg") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".JPEG") && mime.ToString().Equals("image/pjpeg")) || (p_Var.ext.Equals(".png") && mime.ToString().Equals("image/x-png")) || (p_Var.ext.Equals(".PNG") && mime.ToString().Equals("image/x-png")))
                                   
                                        if (p_Var.ext.Equals(".PDF")&& mime.ToString().Equals("application/pdf") || p_Var.ext.Equals(".XLSX")&& mime.ToString().Equals("application/x-zip-compressed") || p_Var.ext.Equals(".DOCX") && mime.ToString().Equals("application/x-zip-compressed")|| p_Var.ext.Equals(".DOC")&& mime.ToString().Equals("application/x-zip-compressed"))
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
                                        lblMsg1.Text = "";
                                        ModalPopupExtender1.Show();
                                        return;
                                    }
                                    if (lbltotalamt.Text == "0")
                                    {
                                        if ((Convert.ToDouble(txtalltdamt.Text) >= Convert.ToDouble(lbltotalamt.Text)) && (Convert.ToDouble(txtamtusd.Text) <= Convert.ToDouble(txtalltdamt.Text)))
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

                                                if (Session["UserType"].ToString().Equals("4"))
                                                {
                                                    if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != null && !Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString().Equals(""))
                                                    {
                                                        // ModalPopupExtender1.Hide();
                                                        FillALL(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());

                                                    }
                                                }
                                                if (Session["UserType"].ToString().Equals("1"))
                                                {
                                                    if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != null && !Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString().Equals(""))
                                                    {
                                                        // ModalPopupExtender1.Hide();
                                                        FillALL1(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());

                                                    }
                                                }
                                                INFOEnt_Obj._CDP_RELOCATION_ID = rel_id;


                                                //INFOEnt_Obj._CDP_STS_LND = ddlselectstatus.SelectedValue.ToString();
                                                bool check = FMLYDB_Obj.AddCDPInfo(INFOEnt_Obj);
                                                if (check == true)
                                                {

                                                    double total = (Convert.ToDouble(lblamtused.Text) + Convert.ToDouble(txtamtusd.Text));
                                                    lblamtused.Text = total.ToString();
                                                    ModalPopupExtender1.Hide();

                                                    BindMembers();
                                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 4);
                                                }
                                                else
                                                {
                                                    ModalPopupExtender1.Show();
                                                    lblMsg1.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                                    lblMsg1.ForeColor = System.Drawing.Color.Red;
                                                }
                                            }




                                            catch (Exception e4)
                                            {
                                                //               ResetAllFieldsOfAssets();
                                                ModalPopupExtender1.Show();
                                                lblMsg1.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e4.Message.ToString();
                                                lblMsg1.ForeColor = System.Drawing.Color.Red;

                                            }
                                        }//end of if
                                    }//end of if
                                    if (lbltotalamt.Text != "0")
                                    {
                                        if (lbltotalamt.Text == "")
                                        {
                                            lbltotalamt.Text = "0";
                                        }
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

                                                //INFOEnt_Obj._CDP_STS_LND = ddlselectstatus.SelectedValue.ToString();
                                                bool check = FMLYDB_Obj.AddCDPInfo(INFOEnt_Obj);
                                                if (check == true)
                                                {

                                                    double total = (Convert.ToDouble(lblamtused.Text) + Convert.ToDouble(txtamtusd.Text));
                                                    lblamtused.Text = total.ToString();
                                                    ModalPopupExtender1.Hide();

                                                    BindMembers();
                                                    Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 4);
                                                }
                                                else
                                                {
                                                    ModalPopupExtender1.Show();
                                                    lblMsg1.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                                    lblMsg1.ForeColor = System.Drawing.Color.Red;
                                                }
                                            }




                                            catch (Exception e4)
                                            {
                                                //               ResetAllFieldsOfAssets();
                                                ModalPopupExtender1.Show();
                                                lblMsg1.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e4.Message.ToString();
                                                lblMsg1.ForeColor = System.Drawing.Color.Red;

                                            }
                                        }//end of if
                                    }//end of if
                                    else if (lbltotalamt.Text != "0")
                                    {
                                        if ((Convert.ToDouble(txtalltdamt.Text) > Convert.ToDouble(lbltotalamt.Text)))
                                        {
                                            lblMsg1.Text = "Enteted allotement amount is greater than the Totol alloted amount";
                                            ModalPopupExtender1.Show();
                                            return;
                                        }
                                    }

                                    else if (Convert.ToDouble(txtamtusd.Text) > Convert.ToDouble(txtalltdamt.Text))
                                    {

                                        lblMsg1.Text = "Amount used  can not greater than the  alloted amount";
                                        ModalPopupExtender1.Show();
                                        return;
                                    }
                                    BindCdpAmountandUsedAmountTimeOfAdd();//18may2018 update
                                    #endregion
                                }//end of false flag

                            }

                            if (flagupdate1 == true)
                            {
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
                                    INFOEnt_Obj._CDP_EXECUTION_AGENCY = txtagency.Text;
                                    INFOEnt_Obj._CDP_WORK = Textcdpwork.Text;
                                    INFOEnt_Obj._COMMENT = txtcomment.Text;
                                    INFOEnt_Obj._CDP_RELOCATION_ID = rel_id;
                                    INFOEnt_Obj.CdpPrimaryID = CdpPrimaryID;
                                    //INFOEnt_Obj._CDP_STS_LND = ddlselectstatus.SelectedValue.ToString();
                                    bool check = FMLYDB_Obj.Update_CDPInfo1(INFOEnt_Obj, cdpwrkid);
                                    if (check == true)
                                    {
                                        //    RegisterClientScriptBlock("showmessage",
                                        //"<script language=\"JavaScript\"> alert('Your changes have been saved.') </script>");
                                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Your changes have been saved.');", true);
                                        double total = (Convert.ToDouble(lblamtused.Text) + Convert.ToDouble(txtamtusd.Text));
                                        lblamtused.Text = total.ToString();
                                        ModalPopupExtender1.Hide();

                                        BindMembers();
                                        Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 4);

                                    }
                                    else
                                    {
                                        ModalPopupExtender1.Show();
                                        lblMsg1.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                                        lblMsg1.ForeColor = System.Drawing.Color.Red;
                                    }
                                }
                                catch (Exception e4)
                                {
                                    //               ResetAllFieldsOfAssets();
                                    ModalPopupExtender1.Show();
                                    lblMsg1.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e4.Message.ToString();
                                    lblMsg1.ForeColor = System.Drawing.Color.Red;

                                }
                               }

                            }
                            BindCdpAmountandUsedAmountTimeOfAdd();
                         // }
                      }
                  // }
              }
            catch
            {
                throw;
            }
       // }
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



        //// Get file name
        //string UploadFileName = fileUpload_Menu.PostedFile.FileName;

        //if (UploadFileName == "")
        //{
        //    // There is no file selected
        //    args.IsValid = false;
        //}
        //else
        //{
        //    string Extension = UploadFileName.Substring(UploadFileName.LastIndexOf('.') + 1).ToLower();

        //    if (Extension == "pdf" || Extension == ".xlsx" || Extension == "docx" || Extension == "doc")
        //    {
        //        args.IsValid = true; // Valid file type
        //    }
        //    else
        //    {
        //        args.IsValid = false; // Not valid file type
        //    }
        //}
    }
    protected void imgbtncancel_Click(object sender, EventArgs e)
    {
        ResetAllFields();
        ModalPopupExtender1.Hide();
    }
    protected void imgbtnreset_Click(object sender, EventArgs e)
    {
        if (flagupdate1 == false)
        {
            ResetAllFields();
            ModalPopupExtender1.Show();
        }
        else if (flagupdate1 == true)
        {
            ShowCDPWrokData(cdpwrkid);
        }
        ModalPopupExtender1.Show();
    }
    protected void ImgbtnSubmitMember_Click(object sender, EventArgs e)
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


                       // if (Page.IsValid)
                       // {
                            if (Page.IsValid)
                            {
                                try
                                {
                                    if (ddlselectstatus.SelectedValue.ToString().Equals("0"))
                                    {
                                        lblMsg.Text = "Please Status Of Land of Village";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                        return;


                                    }
                                    if (gvForwork.Visible == false)
                                    {

                                        lblMsg.Text = "Please Add Atleast One Work";
                                        lblMsg.ForeColor = System.Drawing.Color.Red;
                                        return;
                                    }

                                    INFOEnt_Obj._CDP_STS_LND = ddlselectstatus.SelectedValue.ToString();
                                    INFOEnt_Obj._CDP_AMT_USD = Convert.ToDouble(lblamtused.Text);
                                    //INFOEnt_Obj._CDP_AMT_USD = 0.0;
                                    INFOEnt_Obj._CDP_ALLTD_AMT = Convert.ToDouble(lbltotalamt.Text);
                                    INFOEnt_Obj._CDP_Village_ID = Convert.ToInt32(Request.QueryString[WebConstant.QueryStringEnum.VillageID]);
                                    INFOEnt_Obj._CDP_RELOCATION_ID = rel_id;
                                    bool val = FMLYDB_Obj.AddWorkIn_CDP_Info(INFOEnt_Obj);
                                    if (val == true)
                                    {

                                        FMLYDB_Obj.Delete_All_work(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
                                        gvForwork.Visible = false;
                                        Audit_ObjDB.AUDIT_TRAIL(Session["User_Id"].ToString(), "ADD", 4);
                                        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/Message.aspx?mid=11"), false);


                                    }
                                    else
                                    {
                                        lblMsg.Text = "Error Occur.Please Try Again Later" + WebConstant.UserFriendlyMessages.ExceptionError;
                                        lblMsg.ForeColor = System.Drawing.Color.Red;

                                    }

                                }
                                catch (Exception e4)
                                {
                                    // ResetAllFieldsOfAssets();
                                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// +e4.Message.ToString();
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
        }

    }
    

    protected void ImgbtnCancel1_Click(object sender, EventArgs e)
    {
        ddlselectstatus.SelectedValue = "0";
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        FMLYDB_Obj.Delete_All_work(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
        if (Request.QueryString["viewid"] == null)
        {
            Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Management.aspx?pindex=" + Request.QueryString["inid"].ToString() + "&vid=" + Request.QueryString["vid"].ToString()), false);


        }
        else
        {
            Response.Redirect(ResolveUrl("~/AUTH/adminpanel/CDP/CDP_Management.aspx?pindex=" + Request.QueryString["inid"].ToString() + "&vid=" + Request.QueryString["vid"].ToString() + "&viewid=" + Request.QueryString["viewid"].ToString()), false);



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
     //   fileUpload_Menu.FileName = "";
        ModalPopupExtender1.Show();
    }
    protected void gvForwork_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    TextBox txtRate = (TextBox)e.Row.FindControl("lblname");
        //    //TextBox txtQuantity = (TextBox)e.Row.FindControl("txtQuantity");
        //    //TextBox txtTotal = (TextBox)e.Row.FindControl("txtTotal");
        //    //R = int.Parse(txtRate.Text);
        //    //Q = int.Parse(txtQuantity.Text);

        //    //T += Convert.ToInt32(R * Q);
        //    //txtTotal.Text = T.ToString();
        //    R = int.Parse(txtRate.Text);
        //    R += Convert.ToInt32(R);
        //}
        //lblMsg.Text =R.ToString();
    }
    protected void gvForwork_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvForwork.PageIndex = e.NewPageIndex;
        // FillALL(Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString());
        BindCdpAmountandUsedAmountTimeOfAdd();
        BindMembers();
    }
}