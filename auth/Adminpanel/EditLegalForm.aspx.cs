using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class auth_Adminpanel_EditLegalForm : System.Web.UI.Page
{
    CommonDB COMMDB_Obj = new CommonDB();

    common com_Obj = new common();
    Legalnfo_I_Entity LeglI_Obj = new Legalnfo_I_Entity();

    LegalFormDB LglFrmDB_Obj = new LegalFormDB();
    bool check1 = false;
    bool check2 = false;
    string newfilename1;
    string newfilename2;
    public static string previousfile2name;
    public static string previousfile3name;
    public static string path = "", filename = "";
    protected void Page_Load(object sender, EventArgs e)
    {


        lblMsg.Text = "";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), false);
            return;
        }
        ////if (Session["UserRole"].ToString().Equals("3"))
        ////{
        ////    Response.Redirect(ResolveUrl("~/auth/TIGERRESERVEADMIN/RedirectPage.aspx"), false);
        ////    return;
        ////}
        if (!Page.IsPostBack)
        {

            try
            {
                int VILLl_ID = Convert.ToInt32(Session["VillageId"]);
                Fill_VillageCode_And_Name(Convert.ToInt32(Session["User_Id"]));
                if (ddlselectname.SelectedItem.Text != "Select Name")
                {
                    showdata(ddlselectname.SelectedValue);
                }

            }
            catch (Exception eshow)
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void ImgbtnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (ddlselectname.SelectedItem.Text != "Select Name")
            {
                try
                {
                    if (FileUpload1.HasFile)
                    {
                        bool f1 = Upload_Pdf1();
                        if (f1)
                        {
                            LeglI_Obj._LEGL_MAP_SECOND = newfilename1;
                        }
                    }
                    else
                    {
                        LeglI_Obj._LEGL_MAP_SECOND = previousfile2name;
                    }
                    if (FileUpload2.HasFile)
                    {
                        bool f2 = Upload_Pdf2();
                        if (f2)
                        {
                            LeglI_Obj._LEGL_MAP_THIRD = newfilename2;
                        }
                    }
                    else
                    {
                        LeglI_Obj._LEGL_MAP_THIRD = previousfile3name;
                    }
                    if (FUForImage.FileName.Equals(""))
                    {
                        LeglI_Obj._LGL_MAP_MG = filename;
                    }
                    else if (!FUForImage.PostedFile.FileName.Equals(""))
                    {
                        string ext = System.IO.Path.GetExtension(this.FUForImage.FileName.ToString());
                        // Response.Write(ext.ToString());

                        if (ext.Equals(".pdf") || ext.Equals(".PDF") || ext.Equals(".jpg") || ext.Equals(".JPG") || ext.Equals(".jpeg") || ext.Equals(".JPEG"))
                        {
                            bool s = UploadFile.GetActualFileType(FUForImage.PostedFile.InputStream);
                            if (s == true)
                            {

                                path = ResolveUrl("~") + "WriteReadData/UserFiles";
                                string newfilename = com_Obj.getUniqueFileName(FUForImage.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FUForImage.FileName.ToString()), ext);
                                path = ResolveUrl("~") + "WriteReadData/UserFiles/" + newfilename;
                                FUForImage.PostedFile.SaveAs(Server.MapPath(path));
                                LeglI_Obj._LGL_MAP_MG = newfilename;
                            }
                        }
                        else
                        {
                            lblMsg.Text = "Please Upload Only Valid Files";
                            return;
                        }
                    }


                    LeglI_Obj._DontDrpList1 = Convert.ToBoolean(DontDrpList1.SelectedValue);
                    LeglI_Obj._DontDrpList2 = Convert.ToBoolean(DontDrpList2.SelectedValue);
                    LeglI_Obj._DontDrpList3 = Convert.ToBoolean(DontDrpList3.SelectedValue);
                    LeglI_Obj._DontDrpList4 = Convert.ToBoolean(DontDrpList4.SelectedValue);
                    LeglI_Obj._DontDrpList5 = Convert.ToBoolean(DontDrpList5.SelectedValue);
                    LeglI_Obj._DontDrpList6 = Convert.ToBoolean(DontDrpList6.SelectedValue);
                    LeglI_Obj._DontDrpList7 = Convert.ToBoolean(DontDrpList7.SelectedValue);
                    LeglI_Obj._DontDrpList8 = Convert.ToBoolean(DontDrpList8.SelectedValue);
                    LeglI_Obj._DontDrpList9 = Convert.ToBoolean(DontDrpList9.SelectedValue);
                    LeglI_Obj._DontDrpList10 = Int32.Parse(DontDrpList10.SelectedValue);
                    LeglI_Obj._DontDrpList11 = Int32.Parse(DontDrpList11.SelectedValue);
                    LeglI_Obj._DontDrpList12 = Int32.Parse(DontDrpList12.SelectedValue);
                    if (DontDrpList1.SelectedValue.ToString().Equals("False"))
                        LeglI_Obj._txtdate1 = null;
                    else
                    {
                        if (txtdate1.Text != "")
                            LeglI_Obj._txtdate1 = common.insertDate(txtdate1.Text).ToString();
                        else
                        {
                            lblMsg.Text = "Please Enter Date";
                            return;
                        }
                    }
                    if (DontDrpList2.SelectedValue.ToString().Equals("False"))
                        LeglI_Obj._txtdate2 = null;
                    else
                    {
                        if (txtdate2.Text != "")
                            LeglI_Obj._txtdate2 = common.insertDate(txtdate2.Text).ToString();
                        else
                        {
                            lblMsg.Text = "Please Enter Date";
                            return;
                        }
                    }
                    if (DontDrpList3.SelectedValue.ToString().Equals("False"))
                        LeglI_Obj._txtdate3 = null;
                    else
                    {
                        if (txtdate3.Text != "")
                            LeglI_Obj._txtdate3 = common.insertDate(txtdate3.Text).ToString();
                        else
                        {
                            lblMsg.Text = "Please Enter Date";
                            return;
                        }
                    }

                    if (DontDrpList4.SelectedValue.ToString().Equals("False"))
                        LeglI_Obj._textbox5 = "";
                    else
                    {
                        if (textbox5.Text != "")
                            LeglI_Obj._textbox5 = textbox5.Text;
                        else
                        {
                            lblMsg.Text = "Please Enter Gram Sabha Name";
                            //return;
                        }
                    }


                    if (DontDrpList10.SelectedValue == "0" || DontDrpList10.SelectedValue == "2")
                        LeglI_Obj._txtdate4 = null;
                    else
                    {
                        if (txtdate4.Text != "")
                            LeglI_Obj._txtdate4 = common.insertDate(txtdate4.Text).ToString();
                        else
                        {
                            lblMsg.Text = "Please Enter Date";
                            //return;
                        }
                    }
                    if (DontDrpList11.SelectedValue == "0" || DontDrpList11.SelectedValue == "2")
                        LeglI_Obj._txtdate5 = null;
                    else
                    {
                        if (txtdate5.Text != "")
                            LeglI_Obj._txtdate5 = common.insertDate(txtdate5.Text).ToString();
                        else
                        {
                            lblMsg.Text = "Please Enter Date";
                            //return;
                        }
                    }

                    if (DontDrpList12.SelectedValue == "0" || DontDrpList12.SelectedValue == "2")
                        LeglI_Obj._txtdate6 = null;
                    else
                    {
                        if (txtdate6.Text != "")
                            LeglI_Obj._txtdate6 = common.insertDate(txtdate6.Text).ToString();
                        else
                        {
                            lblMsg.Text = "Please Enter Date";
                            //return;
                        }

                    }
                    LeglI_Obj._textbox1 = Convert.ToDecimal(textbox1.Text);
                    LeglI_Obj._textbox3 = Convert.ToDecimal(textbox3.Text);

                    LeglI_Obj._textbox2 = textbox2.Text;

                    LeglI_Obj._textbox5 = textbox5.Text;
                    //LeglI_Obj._VILL_ID = Convert.ToInt32(Session["VillageId"]);
                    LeglI_Obj._VILL_ID = Convert.ToInt32(ddlselectname.SelectedValue);
                    check2 = LglFrmDB_Obj.Update_LegalForm(LeglI_Obj);
                    if (check2 == true)
                    {
                        new AuditTrailDB().AUDIT_TRAIL(Session["User_Id"].ToString(), "Edit", 11);
                        string strMSG = "Some Changes has been done by User id = " + Session["User_Id"] + " on Village ID Number " + ddlselectname.SelectedValue + "";

                        //if ((COMMDB_Obj.SendEmail("jitin.purwal@netcreativemind.co.in", "", "", "Changes in Legal form ", "Edit Legal Page<" + System.Configuration.ConfigurationManager.AppSettings["ADMIN_MAIL"].ToString() + ">", strMSG)))
                        //{

                        lblMsg.Text = "Legal form Updated Successfully";
                        lblMsg.ForeColor = System.Drawing.Color.Green;


                        //}
                        //else
                        //{
                        //    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                        //    lblMsg.ForeColor = System.Drawing.Color.Red;
                        //}
                    }
                }
                catch (Exception eedit)
                {
                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please select village name!!";
            }
        }

    }

    protected void imgbtnreset_Click(object sender, EventArgs e)
    {
        showdata(Session["VillageID"].ToString());
    }

    protected void imgbtnback_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/TIGERRESERVEADMIN/VILLAGE/Village_Management.aspx"), false);
    }
    public void Fill_VillageCode_And_Name(int userid)
    {
        try
        {
            Village Vill_Obj = new Village();
            VillageDB VillDB_Obj = new VillageDB();
            ddlselectname.Items.Clear();
            DataSet ds = new DataSet();
            ds = VillDB_Obj.Fill_VillageCode_And_Name(userid);
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

                // ddlselectcode.Items.Add(new ListItem("No Record", "0"));
                ddlselectname.Items.Add(new ListItem("No Record", "0"));
            }

        }
        catch (Exception e2)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e2.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }
    void showdata(string VILLl_ID)
    {
        DataSet ds = LglFrmDB_Obj.Edit_LegalForm(ddlselectname.SelectedValue);

        //DontDrpList1.SelectedValue=
        if (ds.Tables[0].Rows.Count > 0)
        {
            DontDrpList1.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList1"].ToString();
            DontDrpList2.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList2"].ToString();
            DontDrpList3.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList3"].ToString();
            DontDrpList4.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList4"].ToString();
            DontDrpList5.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList5"].ToString();
            DontDrpList6.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList6"].ToString();
            DontDrpList7.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList7"].ToString();
            DontDrpList8.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList8"].ToString();
            DontDrpList9.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList9"].ToString();
            DontDrpList10.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList10"].ToString();
            DontDrpList11.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList11"].ToString();
            DontDrpList12.SelectedValue = ds.Tables[0].Rows[0]["DontDrpList12"].ToString();


            textbox1.Text = ds.Tables[0].Rows[0]["textbox1"].ToString();
            textbox2.Text = ds.Tables[0].Rows[0]["textbox2"].ToString();
            textbox3.Text = ds.Tables[0].Rows[0]["textbox3"].ToString();

            textbox5.Text = ds.Tables[0].Rows[0]["textbox5"].ToString();
            filename = ds.Tables[0].Rows[0]["LGL_MAP_MG"].ToString();
            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["LGL_MAP_MG"].ToString()) == false)
            {
                map1.Visible = true;
                map1.NavigateUrl = "~/WriteReadData/UserFiles/" + ds.Tables[0].Rows[0]["LGL_MAP_MG"].ToString();
                //lblfileupoloadArea.Text = ds.Tables[0].Rows[0]["LGL_MAP_MG"].ToString();
            }
            previousfile2name = ds.Tables[0].Rows[0]["LGL_MAP_SECOND"].ToString();
            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["LGL_MAP_SECOND"].ToString()) == false)
            {
                map2.Visible = true;

                map2.NavigateUrl = "~/WriteReadData/UserFiles/" + ds.Tables[0].Rows[0]["LGL_MAP_SECOND"].ToString();
                //lblfileupoloadArea.Text = ds.Tables[0].Rows[0]["LGL_MAP_MG"].ToString();
            }
            previousfile3name = ds.Tables[0].Rows[0]["LGL_MAP_THIRD"].ToString();
            if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["LGL_MAP_THIRD"].ToString()) == false)
            {
                map3.Visible = true;
                map3.NavigateUrl = "~/WriteReadData/UserFiles/" + ds.Tables[0].Rows[0]["LGL_MAP_THIRD"].ToString();
                //lblfileupoloadArea.Text = ds.Tables[0].Rows[0]["LGL_MAP_MG"].ToString();
            }
            //string map1 =  ds.Tables[0].Rows[0]["LGL_MAP_MG"].ToString();
            //string map2 = ds.Tables[0].Rows[0]["LGL_MAP_SECOND"].ToString();
            //string map3 = ds.Tables[0].Rows[0]["LGL_MAP_THIRD"].ToString();

            txtdate1.Text = ds.Tables[0].Rows[0]["txtdate1"].ToString();
            txtdate2.Text = ds.Tables[0].Rows[0]["txtdate2"].ToString();
            txtdate3.Text = ds.Tables[0].Rows[0]["txtdate3"].ToString();
            txtdate4.Text = ds.Tables[0].Rows[0]["txtdate4"].ToString();
            txtdate5.Text = ds.Tables[0].Rows[0]["txtdate5"].ToString();
            txtdate6.Text = ds.Tables[0].Rows[0]["txtdate6"].ToString();

            if (DontDrpList1.SelectedValue.ToString().Equals("False"))
                checkdate1.Visible = false;

            else
                checkdate1.Visible = true;

            if (DontDrpList11.SelectedValue == "0" || DontDrpList11.SelectedValue == "2")
                checkdate6.Visible = false;

            else
                checkdate6.Visible = true;
            if (DontDrpList2.SelectedValue.ToString().Equals("False"))
                checkdate2.Visible = false;

            else
                checkdate2.Visible = true;
            if (DontDrpList3.SelectedValue.ToString().Equals("False"))
                checkdate3.Visible = false;

            else
                checkdate3.Visible = true;
            if (DontDrpList4.SelectedValue.ToString().Equals("False"))
                checkdate4.Visible = false;

            else
                checkdate4.Visible = true;
            if (DontDrpList10.SelectedValue == "0" || DontDrpList10.SelectedValue == "2")
                checkdate5.Visible = false;

            else
                checkdate5.Visible = true;
            if (DontDrpList10.SelectedValue == "0" || DontDrpList10.SelectedValue == "2")
                checkdate7.Visible = false;

            else
                checkdate7.Visible = true;




        }
        else
        {
            Response.Redirect("~/auth/adminpanel/EditLegalForm.aspx", false);
        }

    }
    protected void DontDrpList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList1.SelectedValue.ToString().Equals("False"))
            checkdate1.Visible = false;

        else
            checkdate1.Visible = true;
    }
    protected void DontDrpList11_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList11.SelectedValue == "0" || DontDrpList11.SelectedValue == "2")
            checkdate6.Visible = false;

        else
            checkdate6.Visible = true;

        if (DontDrpList11.SelectedValue == "1")
        {
            FileUpConstitutedB.Visible = true;
        }
        if (DontDrpList11.SelectedValue == "2" || DontDrpList11.SelectedValue == "0")
        {
            FileUpConstitutedB.Visible = false;
        }
    }
    protected void DontDrpList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList2.SelectedValue.ToString().Equals("False"))
            checkdate2.Visible = false;

        else
            checkdate2.Visible = true;
    }
    protected void DontDrpList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList3.SelectedValue.ToString().Equals("False"))
            checkdate3.Visible = false;

        else
            checkdate3.Visible = true;
    }
    protected void DontDrpList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList4.SelectedValue.ToString().Equals("False"))
            checkdate4.Visible = false;

        else
            checkdate4.Visible = true;
    }
    protected void DontDrpList10_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList10.SelectedValue == "0" || DontDrpList10.SelectedValue == "2")
            checkdate5.Visible = false;

        else
            checkdate5.Visible = true;

        //if (DontDrpList11.SelectedValue == "0")
        //{
        //    FileUpConstitutedB.Visible = true;
        //}
        //else
        //{
        //    FileUpConstitutedB.Visible = false;
        //}
        if (DontDrpList10.SelectedValue == "1")
        {
            FileUpConstitutedA.Visible = true;
        }
        if (DontDrpList10.SelectedValue == "2" || DontDrpList10.SelectedValue == "0")
        {
            FileUpConstitutedA.Visible = false;
        }
    }
    protected void DontDrpList12_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList12.SelectedValue == "0" || DontDrpList12.SelectedValue == "2")
            checkdate7.Visible = false;

        else
            checkdate7.Visible = true;

        if (DontDrpList12.SelectedValue == "1")
        {
            FileUPConstitutedC.Visible = true;
        }
        if (DontDrpList12.SelectedValue == "2" || DontDrpList12.SelectedValue == "0")
        {
            FileUPConstitutedC.Visible = false;
        }
       
    }
    public bool Upload_Pdf1()
    {

        string path;
        string fext1 = "";
        if (FileUpload1.PostedFile != null)
        {
            fext1 = System.IO.Path.GetExtension(this.FileUpload1.FileName.ToString());
            bool s = UploadFile.GetActualFileType(FileUpload1.PostedFile.InputStream);
            if (fext1.Equals(".pdf") || fext1.Equals(".PDF") || fext1.Equals(".jpg") || fext1.Equals(".JPG") || fext1.Equals(".jpeg") || fext1.Equals(".JPEG"))
            {



                path = ResolveUrl("~") + "WriteReadData/UserFiles";
                newfilename1 = com_Obj.getUniqueFileName(FileUpload1.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName), fext1);
                path = ResolveUrl("~") + "WriteReadData/UserFiles/" + newfilename1;
                FileUpload1.PostedFile.SaveAs(Server.MapPath(path));
                ViewState["newfilename"] = newfilename1;
                //LeglI_Obj._LGL_MAP_MG = ViewState["newfilename"].ToString();
                string lbldisplay = ViewState["newfilename"].ToString();

                return true;

            }
            else
            {
                string msg = "Image is in incorrect formate ";
                lbl1.Visible = true;
                lbl1.Text = msg;
                return false;
                //put the validation for wrong file 
            }
        }
        else
        {
            return false;
        }
    }
    public bool Upload_Pdf2()
    {

        string path;
        string fext1 = "";
        if (FileUpload2.PostedFile != null)
        {
            fext1 = System.IO.Path.GetExtension(this.FileUpload2.FileName.ToString());
            bool s = UploadFile.GetActualFileType(FileUpload2.PostedFile.InputStream);
            if (fext1.Equals(".pdf") || fext1.Equals(".PDF") || fext1.Equals(".jpg") || fext1.Equals(".JPG") || fext1.Equals(".jpeg") || fext1.Equals(".JPEG"))
            {



                path = ResolveUrl("~") + "WriteReadData/UserFiles";
                newfilename2 = com_Obj.getUniqueFileName(FileUpload2.FileName.ToString(), Server.MapPath(path), System.IO.Path.GetFileNameWithoutExtension(FileUpload2.PostedFile.FileName), fext1);
                path = ResolveUrl("~") + "WriteReadData/UserFiles/" + newfilename2;
                FileUpload2.PostedFile.SaveAs(Server.MapPath(path));
                ViewState["newfilename"] = newfilename2;
                //LeglI_Obj._LGL_MAP_MG = ViewState["newfilename"].ToString();
                string lbldisplay = ViewState["newfilename"].ToString();

                return true;

            }
            else
            {
                string msg = "Image is in incorrect formate ";
                lbl2.Visible = true;
                lbl2.Text = msg;
                return false;
                //put the validation for wrong file 
            }
        }
        else
        {
            return false;
        }
    }

    protected void ddlselectname_SelectedIndexChanged(object sender, EventArgs e)
    {
        //showdata(ddlselectname.SelectedValue);
    }
    protected void DontDrpList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList5.SelectedValue == "True")
        {
            FileUploadCompleted.Visible = true;
        }
        else
        {
            FileUploadCompleted.Visible = false;
        }
    }
    protected void DontDrpList8_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList8.SelectedItem.Value == "True")
        {
            FileupObtained.Visible = true;
        }
        else
        {
            FileupObtained.Visible = false;
        }
    }
    protected void DontDrpList9_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DontDrpList9.SelectedValue == "True")
        {
            FileUpProvided.Visible = true;
        }
        else
        {
            FileUpProvided.Visible = false;
        }
    }
}