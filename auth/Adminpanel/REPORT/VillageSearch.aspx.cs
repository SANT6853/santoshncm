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
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_VillageSearch : CrsfBase
{
    common com_Obj = new common();
    CommonDB comDB_Obj = new CommonDB();
    ReserveDB RDb = new ReserveDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblnodatafound.Text = "";
        Page.Title = "VILLAGES REPORT : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }

        if (!IsPostBack)
        {

            if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
            {
                BtnBackConsoldateReport.Visible = true;
            }
            else
            {
                BtnBackConsoldateReport.Visible = false;
            }


        }

    }
  

    protected void LinkButton1_Click(object sender, EventArgs e)
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

                        if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                        {
                            Response.Redirect("~/AUTH/adminpanel/REPORT/VillagedynmicRpt.aspx?ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString(), false);
                        }
                        else
                        {
                            Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/VillagedynmicRpt.aspx"), false);
                        }
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }  
    
    protected void lnlbtn_Click(object sender, EventArgs e)
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
                    {//?ConsoldateStateName=Bihar&ConsoldateMode=Creport
                        if (Request.QueryString["ConsoldateStateName"] != null && Request.QueryString["ConsoldateMode"] != null)
                        {
                            Response.Redirect("VillageSearchII.aspx?ConsoldateStateName=" + Request.QueryString["ConsoldateStateName"].ToString() + "&ConsoldateMode=" + Request.QueryString["ConsoldateMode"].ToString(), false);
                        }
                        else
                        {
                            Response.Redirect("VillageSearchII.aspx", false);
                        }
                    }

                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }  
    protected void BtnBackConsoldateReport_Click(object sender, EventArgs e)
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
                        Response.Redirect("~/auth/adminpanel/Report/ConsoldateReport/ConsoldateReport.aspx");
                    }
                }
            }
        }

        catch
        {
            throw;
        }

        //}
    }  
}