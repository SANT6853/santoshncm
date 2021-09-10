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

public partial class auth_Adminpanel_FAMILYDATA_View_Installment_II : System.Web.UI.Page
{
    FamilyDB FMLYDB_Obj = new FamilyDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        }
        //if (Session["UserRole"].ToString().Equals("3"))
        //{
        //    Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/RedirectPage.aspx"), false);
        //}
        if (!Page.IsPostBack)
        {


            if (Request.QueryString[WebConstant.QueryStringEnum.INSTID] != null && !Request.QueryString[WebConstant.QueryStringEnum.INSTID].Equals(""))
            {
                LoadInfoFamilyId(Request.QueryString[WebConstant.QueryStringEnum.INSTID].ToString());
            }
        }
    }
    public void LoadInfoFamilyId(string familyid)
    {

        try
        {
            DataSet ds = FMLYDB_Obj.DisplayInstallment(Request.QueryString[WebConstant.QueryStringEnum.INSTID].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblholname.Text = ds.Tables[0].Rows[0]["INST_ISCM_HOLD_NM"].ToString();
                lblamount.Text = ds.Tables[0].Rows[0]["INST_ISCM_AMT"].ToString();
                lblbank.Text = ds.Tables[0].Rows[0]["BANK_NAME"].ToString();
                lblbranch.Text = ds.Tables[0].Rows[0]["BRANCH_NAME"].ToString();
                lblacc.Text = ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString();
                lblinstno.Text = Request.QueryString["no"].ToString();
                lblckbankname.Text = ds.Tables[0].Rows[0]["CHK_BANK_NM"].ToString();
                lblckbranch.Text = ds.Tables[0].Rows[0]["CHK_BRANCH_NM"].ToString();
                lblcheque.Text = ds.Tables[0].Rows[0]["INST_ISCM_CHK_NO"].ToString();
                lbldate.Text = ds.Tables[0].Rows[0]["INST_ISCM_CHK_DT1"].ToString();
            }






        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }
}