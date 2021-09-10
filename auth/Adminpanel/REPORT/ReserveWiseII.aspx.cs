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
using NCM.DAL;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class auth_Adminpanel_REPORT_ReserveWiseII : System.Web.UI.Page
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    CommonDB comDB_Obj = new CommonDB();
    common com_Obj = new common();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "VILLAGES REPORT : NTCA";
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }

        if (!IsPostBack)
        {

            ReportViewer1.LocalReport.DataSources.Clear();
            DataSet dsreserve = new DataSet();
            //dsreserve=comDB_Obj.SelectReserve_ID(ddlselectreserve.SelectedValue.ToString());
            // int resid=Convert.ToInt32(ddlselectreserve.SelectedValue.ToString());//Convert.ToInt32(dsreserve.Tables[0].Rows[0].ToString());
            int resid = Convert.ToInt32(Request.QueryString["VILL_ID"]);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            //ReportViewer1.LocalReport.ReportPath = @"C:\inetpub\wwwroot\TIGER_RESERVE\TIGERRESERVEADMIN\REPORT\Report.rdlc";
            ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/AUTH/adminpanel\REPORT\Report.rdlc");

            ObjDB.AddParameter("@UserID", Session["User_Id"].ToString());
            ds = ObjDB.ExecuteDataSet("Proc_Display_VillageWiseSearch");
            ReportDataSource datasource = new ReportDataSource("DataSet1_Proc_Display_VillageWiseSearch", ds.Tables[0]);

            //ReportViewer1.LocalReport.DataSources.Clear();

            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (ds.Tables[0].Rows.Count == 0)
            {
                //  lblMessage.Text = "Sorry, no products under this category!";
            }

            ReportViewer1.LocalReport.Refresh();
        }


    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/AUTH/adminpanel/REPORT/Reservewisevillege.aspx"));
    }
}