using System;

using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_NGO_Management_AddNGO : CrsfBase
{

    #region Data declaration zone

    Project_Variables p_Var = new Project_Variables();
    string filePath = ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/" + ConfigurationManager.AppSettings["NGOAttachments"].ToString() + "/";
    NgoBL ngoBL=new NgoBL();
    NgoOB ngoObject=new NgoOB();
    Miscelleneous_BL miscellBL=new Miscelleneous_BL();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    ContentOB contentObject=new ContentOB();
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayStateName(Convert.ToInt16(Module_ID_Enum.Language_ID.English));
        }
    }

    #region Function to bind state name in dropdownlist

    private void DisplayStateName(int langID)
    {
        contentObject.LangID = langID;
        p_Var.dSet = contentBL.getStateName(contentObject);
        if (p_Var.dSet != null)
        {
            ddlState.DataSource = p_Var.dSet;
            ddlState.DataTextField = "statename";
            ddlState.DataValueField = "ID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("Select State", "0"));
        }

    }

    #endregion

  

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }

    protected void btnsave_Click(object sender, EventArgs e)
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

                       // try
                      //  {

                            ngoObject.ActionType = Convert.ToInt16(Module_ID_Enum.Project_Action_Type.insert);
                            ngoObject.NgoName = HttpUtility.HtmlEncode(txtNGOName.Text);
                            ngoObject.StateID = Convert.ToInt32(ddlState.SelectedValue);
                            ngoObject.NgoAddress = HttpUtility.HtmlEncode(txtAddress.Text);
                            ngoObject.PhoneNumber = HttpUtility.HtmlEncode(txtPhoneNumber.Text);
                            ngoObject.MobileNumber = HttpUtility.HtmlEncode(txtMobileNumber.Text);
                            ngoObject.WorkDoneByNGO = HttpUtility.HtmlEncode(txtWorkDonebyNGO.Text);
                            ngoObject.Remarks = HttpUtility.HtmlEncode(txtWorkDonebyNGO.Text);

                            ngoObject.StatusID = Convert.ToInt16(Module_ID_Enum.Module_Status_ID.draft);
                            ngoObject.IpAddress = miscellBL.IpAddress();
                            ngoObject.UserID = Convert.ToInt16(Session["User_Id"]);

                            if (FileUploader.PostedFile != null && FileUploader.PostedFile.ContentLength > 0)
                            {
                                p_Var.ext = System.IO.Path.GetExtension(this.FileUploader.PostedFile.FileName);
                                p_Var.ext = p_Var.ext.ToUpper();
                                if (p_Var.ext.Equals(".PDF"))
                                {

                                    p_Var.Path = p_Var.imageUrl;
                                    p_Var.Filename = FileUploader.FileName;
                                    p_Var.filenamewithout_Ext = Path.GetFileNameWithoutExtension(FileUploader.FileName);
                                    //  p_Var.ext = Path.GetExtension(FileUploader.FileName);

                                    p_Var.Filename = miscellBL.getUniqueFileName(p_Var.Filename, Server.MapPath(ResolveUrl("~/") + filePath), p_Var.filenamewithout_Ext, p_Var.ext);
                                    FileUploader.SaveAs(Server.MapPath(ResolveUrl("~/") + filePath + p_Var.Filename));

                                    ngoObject.Attachment = p_Var.Filename;
                                }

                            }


                            else
                            {
                                ngoObject.Attachment = "";
                            }


                            p_Var.Result = ngoBL.InsertUpdateNGODetails(ngoObject);
                            if (p_Var.Result > 0)
                            {
                                Session["msg"] = "NGO details has been submitted successfully.";
                                Session["BackUrl"] = "~/Auth/AdminPanel/NGO Management/ViewNGODetails.aspx?ModuleID=" + Convert.ToInt16(Module_ID_Enum.Project_Module_ID.NGO);
                                Miscelleneous_BL.RedirectPermanent(ResolveUrl("~/Auth/AdminPanel/ConfirmationPage.aspx"));


                            }



                        //}

                        //catch (Exception e1)
                        //{
                        //    throw;
                        //}
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
    

    protected void btnBack_Click(object sender, EventArgs e)
    {
       
    }
}