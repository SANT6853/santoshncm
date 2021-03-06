using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_NGO_Management_ViewNGODetails : CrsfBase
{
    #region Data declaration zone

    Project_Variables p_Var = new Project_Variables();
    string filePath = ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/NGOAttachments/";
    NgoBL ngoBL = new NgoBL();
    NgoOB ngoObject = new NgoOB();
    Miscelleneous_BL miscellBL = new Miscelleneous_BL();
    Content_ManagementBL contentBL = new Content_ManagementBL();
    ContentOB contentObject = new ContentOB();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayStateName(Convert.ToInt16(Module_ID_Enum.Language_ID.English));
            //bindStatusInDropdownlist();
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



    #region Function to bind approve and pending records in gridView

    private void bindPendingApproveGridView(int pageIndex)
    {


            ngoObject.StatusID = Convert.ToInt32(3);
            ngoObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.NGO);
            ngoObject.StateID = Convert.ToInt32(ddlState.SelectedValue);
           
          
                p_Var.dSet = ngoBL.NGODetailsDisplay(ngoObject, out p_Var.k);
           

            if (p_Var.dSet.Tables[0].Rows.Count > 0)
            {
               
                divGrid.Visible = true;
                grdNGODetails.Visible = true;
                grdNGODetails.DataSource = p_Var.dSet;
                grdNGODetails.DataBind();
                p_Var.dSet = null;
                //code for checking category is present in temp table or not

                grdNGODetails.Columns[0].Visible = false;

                    foreach (GridViewRow row in grdNGODetails.Rows)
                    {

                        Image imgedit = (Image)row.FindControl("imgEdit");
                        Image imgnotedit = (Image)row.FindControl("imgnotedit");
                        Label lblNgoIDTemp = (Label)row.FindControl("lblNgoIDTemp");

                        ngoObject.NgoID = Convert.ToInt16(lblNgoIDTemp.Text);

                        p_Var.dSetCompare = ngoBL.NGOIDForComparison(ngoObject);
                        for (p_Var.i = 0; p_Var.i < p_Var.dSetCompare.Tables[0].Rows.Count; p_Var.i++)
                        {
                            if (p_Var.dSetCompare.Tables[0].Rows[p_Var.i]["NgoID"] != DBNull.Value)
                            {
                                if (Convert.ToInt16(lblNgoIDTemp.Text) == Convert.ToInt16(p_Var.dSetCompare.Tables[0].Rows[p_Var.i]["NgoID"]))
                                {
                                    imgnotedit.Visible = true;
                                    imgedit.Visible = false;
                                    //18 Aug


                                }
                                else
                                {
                                    imgnotedit.Visible = false;
                                    imgedit.Visible = true;

                                }
                            }
                        }
                    }
              

              
                p_Var.dSet = null;
                // lblmsg.Visible = false;
            }


            else
            {
                divGrid.Visible = false;
              
            }
       

        p_Var.Result = p_Var.k;
     
    }

    #endregion

    #region Function to approve the photo record

    public void ChkApprove_Disapprove()
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

                        foreach (GridViewRow row in grdNGODetails.Rows)
                        {
                            CheckBox selCheck = (CheckBox)row.FindControl("chkSelect");
                            if ((selCheck.Checked == true))
                            {
                                int ANCMNT_ID = Convert.ToInt32(grdNGODetails.DataKeys[row.RowIndex].Value);

                                ngoObject.NgoIDTemp = ANCMNT_ID;
                                ngoObject.UserID = Convert.ToInt16(Session["User_Id"]);
                                ngoObject.IpAddress = miscellBL.IpAddress();

                                p_Var.Result = ngoBL.InsertUpdateNGOInFinal(ngoObject);
                            }


                        }

                        if (p_Var.Result > 0)
                        {
                            Session["msg"] = "NGO details has been approved successfully.";
                            Session["BackUrl"] = "~/Auth/AdminPanel/NGO Management/ViewNGODetails.aspx?ModuleID=" + Request.QueryString["ModuleID"];
                            Response.Redirect("~/Auth/AdminPanel/ConfirmationPage.aspx");
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
    #endregion


    protected void grdNGODetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdNGODetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void grdNGODetails_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void grdNGODetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow & (e.Row.RowState == DataControlRowState.Normal | e.Row.RowState == DataControlRowState.Alternate))
        {
            CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkSelect");
            CheckBox chkBxHeader = (CheckBox)this.grdNGODetails.HeaderRow.FindControl("chkSelectAll");
            //Add client side function childclick on check boxes
            chkBxSelect.Attributes.Add("onclick", string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID));

        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindPendingApproveGridView(1);
    }


}