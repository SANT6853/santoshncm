using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Map_Pre : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindMap();
        }
    }
    public void  BindMap()
    {
        NgoDal MapDL = new NgoDal();
        if(Request.QueryString["id"]!=null)
        {
            int VillageID =Convert.ToInt32(Request.QueryString["id"].ToString());
            DataSet ds = MapDL.PreMapDetail(VillageID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptMarkers.DataSource = ds;
                rptMarkers.DataBind();
            }
        }
    }
}