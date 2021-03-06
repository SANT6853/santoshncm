using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Map_Post : System.Web.UI.Page
{
    
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
        LblFromVillage.Text = "";
        LblFromLong.Text = "";
        LblFromLat.Text = "";

        LblToVillage.Text = "";
        LblToLong.Text = "";
        LbltoLat.Text = "";

        DataTable dtt = new DataTable();
        DataTable dsChartData = new DataTable();
        try
        {
            // P_var.dSet = null;

            // dtt = null;
            //  _objNtcauser = null;
            _objNtcauser.FromVill_ID = Convert.ToInt32(Request.QueryString["id"]);
          
            P_var.dSet = _commanfuction.PostGoogleMap(_objNtcauser);
            dtt = P_var.dSet.Tables[0];
            //------------------

            dsChartData.Columns.Add("Name", typeof(string));
            dsChartData.Columns.Add("Latitude", typeof(string));
            dsChartData.Columns.Add("Longitude", typeof(string));
            dsChartData.Columns.Add("Description", typeof(string));
            dsChartData.Columns.Add("type", typeof(string));
            if (P_var.dSet.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    if (dtt.Rows[i]["ToLatitude"].ToString() == "" || dtt.Rows[i]["ToLatitude"] == null)
                    {
                        if (i == 0)
                        {
                            Response.Redirect("~/AUTH/adminpanel/REPORT/GoogleMapFromOnly.aspx?village_id=" + Request.QueryString["village_id"].ToString());
                            // dsChartData.Rows.Add("From:" + dtt.Rows[i]["fromVILL_NM"].ToString() + " click notification to veiw details", dtt.Rows[i]["fromLatitude"].ToString(), dtt.Rows[i]["fromLongitude"].ToString(), dtt.Rows[i]["FromAddress"].ToString(), "to");
                        }
                        else
                        {
                            // dsChartData.Rows.Add("From:" + dtt.Rows[i]["fromVILL_NM"].ToString() + " click notification to veiw details", dtt.Rows[i]["fromLatitude"].ToString(), dtt.Rows[i]["fromLongitude"].ToString(), dtt.Rows[i]["FromAddress"].ToString(), "from");
                            // dsChartData.Rows.Add("From:" + dtt.Rows[i]["fromVILL_NM"].ToString() + " click notification to veiw details", dtt.Rows[i]["fromLatitude"].ToString(), dtt.Rows[i]["fromLongitude"].ToString(), dtt.Rows[i]["FromAddress"].ToString(), "to");
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            dsChartData.Rows.Add("From:" + dtt.Rows[i]["fromVILL_NM"].ToString() + " click notification to veiw details", dtt.Rows[i]["fromLatitude"].ToString(), dtt.Rows[i]["fromLongitude"].ToString(), dtt.Rows[i]["FromAddress"].ToString(), "from");
                            dsChartData.Rows.Add("Relocated to:" + dtt.Rows[i]["ToVILL_NM"].ToString() + " click notification to veiw details", dtt.Rows[i]["ToLatitude"].ToString(), dtt.Rows[i]["ToLongitude"].ToString(), dtt.Rows[i]["ToAddress"].ToString(), "to");

                            LblFromVillage.Text = dtt.Rows[i]["fromVILL_NM"].ToString();
                            LblToVillage.Text = dtt.Rows[i]["ToVILL_NM"].ToString();
                            LblFromLat.Text = dtt.Rows[i]["fromLatitude"].ToString();
                            LblFromLong.Text = dtt.Rows[i]["fromLongitude"].ToString();
                            LbltoLat.Text = dtt.Rows[i]["ToLatitude"].ToString();
                            LblToLong.Text = dtt.Rows[i]["ToLongitude"].ToString();
                        }
                        else
                        {
                            dsChartData.Rows.Add("From:" + dtt.Rows[i]["fromVILL_NM"].ToString() + " click notification to veiw details", dtt.Rows[i]["fromLatitude"].ToString(), dtt.Rows[i]["fromLongitude"].ToString(), dtt.Rows[i]["FromAddress"].ToString(), "from");
                            dsChartData.Rows.Add("Relocated to:" + dtt.Rows[i]["ToVILL_NM"].ToString() + " click notification to veiw details", dtt.Rows[i]["ToLatitude"].ToString(), dtt.Rows[i]["ToLongitude"].ToString(), dtt.Rows[i]["ToAddress"].ToString(), "to");
                            LblFromLat.Text = dtt.Rows[i]["fromVILL_NM"].ToString();
                            LblToVillage.Text = dtt.Rows[i]["ToVILL_NM"].ToString();
                            LblFromLat.Text = dtt.Rows[i]["fromLatitude"].ToString();
                            LblFromLong.Text = dtt.Rows[i]["fromLongitude"].ToString();
                            LbltoLat.Text = dtt.Rows[i]["ToLatitude"].ToString();
                            LblToLong.Text = dtt.Rows[i]["ToLongitude"].ToString();
                        }
                    }
                    // dsChartData.Rows.Add( dtt.Rows[i]["fromLatitude"].ToString());
                    // dsChartData.Rows.Add("Longitude", dtt.Rows[i]["fromLongitude"].ToString());
                    //dsChartData.Rows.Add("Description", dtt.Rows[i]["FromAddress"].ToString());
                }
                rptMarkers.DataSource = dsChartData;
                rptMarkers.DataBind();
            }
        }
        catch (Exception er)
        {

        }
        finally
        {
            dtt.Dispose();
            P_var.dSet.Dispose();
            dsChartData.Dispose();
        }
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
      
        Response.Redirect("~/auth/adminpanel/Post/survey-details.aspx");
    }
}