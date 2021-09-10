using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NCM.DAL;
//using Microsoft.Reporting.WebForms;
using System.Collections.Generic;

public partial class auth_Adminpanel_REPORT_Reservewisevillege : System.Web.UI.Page
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

            
        }
      
    }

    
    protected void lnlbtn_Click(object sender, EventArgs e)
    {
        //int villgidgo = Convert.ToInt32(Session["RESERVEID"].ToString());
       // Response.Redirect("ReserveWiseII.aspx?VILL_ID=" + villgidgo);
        Response.Redirect("ReserveWiseII.aspx",false);
    }
}