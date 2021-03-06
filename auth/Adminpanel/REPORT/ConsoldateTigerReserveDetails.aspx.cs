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
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;


public partial class auth_Adminpanel_REPORT_ConsoldateTigerReserveDetails : CrsfBase
{
    Project_Variables P_var = new Project_Variables();
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ConsolDateReport();

        }
    }
    void ConsolDateReport()
    {
         if (Request.QueryString["ConsoldateStateID"] != null)
         {
            _objNtcauser.StateID = Convert.ToInt32(Request.QueryString["ConsoldateStateID"]);
                        }
                        else
                        {
                            _objNtcauser.StateID = null;
                        }
                        P_var.dSet = _commanfuction.ConsoldateReportTigerReserveName(_objNtcauser);
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            GridViewNarenConsoldateReport.Visible = true;
            GridViewNarenConsoldateReport.DataSource = P_var.dSet.Tables[0];
            //lblvillagename.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();

            GridViewNarenConsoldateReport.DataBind();
            NarenDivMessageError.Visible = false;
            GridViewNarenConsoldateReport.Caption = "Total State count:" + P_var.dSet.Tables[0].Rows.Count.ToString();
            // Naren_GridViewParentStateName.ForeColor = System.Drawing.Color.Green;

        }
        else
        {
            NarenDivMessageError.Visible = true;
            GridViewNarenConsoldateReport.Visible = false;
            //lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
            //lblMsg.ForeColor = System.Drawing.Color.Red;
        }
    }

                
            
    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
    {
        //if (Page.IsValid)
        //{

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
                        Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsoldateReport.aspx");
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