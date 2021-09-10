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
using System.Text;
using System.IO;

public partial class auth_Adminpanel_REPORT_map : System.Web.UI.Page
{
    NCMdbAccess ObjDB = new NCMdbAccess();
    Project_Variables P_var = new Project_Variables();
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (Session["UserType"].ToString().Equals("4"))
            //{
            //}
            GoogeMapShow();
        }
    }
    void GoogeMapShow()
    {
        DataTable dtt = new DataTable();
        _objNtcauser.FromVill_ID = Convert.ToInt32(Request.QueryString["village_id"]);
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        P_var.dSet = _commanfuction.GoogleMap(_objNtcauser);
        dtt = P_var.dSet.Tables[0];
        //------------------
        DataTable dsChartData = new DataTable();
        dsChartData.Columns.Add("Name", typeof(string));
        dsChartData.Columns.Add("Latitude", typeof(string));
        dsChartData.Columns.Add("Longitude", typeof(string));
        dsChartData.Columns.Add("Description", typeof(string));

        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                dsChartData.Rows.Add(dtt.Rows[i]["fromVILL_NM"].ToString(), dtt.Rows[i]["fromLatitude"].ToString(), dtt.Rows[i]["fromLongitude"].ToString(), dtt.Rows[i]["FromAddress"].ToString());
                dsChartData.Rows.Add(dtt.Rows[i]["ToVILL_NM"].ToString(), dtt.Rows[i]["ToLatitude"].ToString(), dtt.Rows[i]["ToLongitude"].ToString(), dtt.Rows[i]["ToAddress"].ToString());
                // dsChartData.Rows.Add( dtt.Rows[i]["fromLatitude"].ToString());
                // dsChartData.Rows.Add("Longitude", dtt.Rows[i]["fromLongitude"].ToString());
                //dsChartData.Rows.Add("Description", dtt.Rows[i]["FromAddress"].ToString());
            }
            rptMarkers.DataSource = dsChartData;
            rptMarkers.DataBind();
        }
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("VillagedynmicRpt.aspx?"), false);
    }
}