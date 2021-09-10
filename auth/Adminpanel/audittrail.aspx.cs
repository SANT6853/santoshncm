using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Default : System.Web.UI.Page
{
    Project_Variables p_var = new Project_Variables();
    PaginationBL pagingBL = new PaginationBL();
    Miscelleneous_DL objMisDal = new Miscelleneous_DL();
    AuditTrail objAudit = new AuditTrail();
    AuditOB onjAuditOb = new AuditOB();
    protected void Page_Load(object sender, EventArgs e)
    {
        auditTrail(1);
    }
    public void auditTrail(int Userid)
    {
        onjAuditOb.ID = Userid;
        p_var.dSet = objAudit.GetAuditTrailAll(onjAuditOb);
        GridView1.DataSource = p_var.dSet;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex= e.NewPageIndex;
        auditTrail(1);

    }
}