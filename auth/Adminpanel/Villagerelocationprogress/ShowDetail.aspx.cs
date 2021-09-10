using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Runtime.InteropServices;
public partial class auth_Adminpanel_Villagerelocationprogress_ShowDetail : CrsfBase
{
    relocationprogress dal = new relocationprogress();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/home.aspx"), true);
        }
        filldeatil();
    }
    public void filldeatil()
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

                        int id = Int32.Parse(Request.QueryString["id"]);
                        DataSet ds = dal.select_record_for_update(id);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
                            txtDate0.Text = ds.Tables[0].Rows[0]["ST_NAME"].ToString();
                            txtAmountperfamily.Text = ds.Tables[0].Rows[0]["MoneyPerfam"].ToString();
                            txtlandmoneyperfamily.Text = ds.Tables[0].Rows[0]["landAndMoney"].ToString();
                            txtlandpackage.Text = ds.Tables[0].Rows[0]["LandPackge"].ToString();
                            txtNooffamily.Text = ds.Tables[0].Rows[0]["Family"].ToString();
                            txtNovillage.Text = ds.Tables[0].Rows[0]["Village"].ToString();
                            txtnoofRelocatedFamily.Text = ds.Tables[0].Rows[0]["RelocateFam"].ToString();
                            txtnoofRelocatevillage.Text = ds.Tables[0].Rows[0]["RelocatedVill"].ToString();
                            txtnoofVilageremaining.Text = ds.Tables[0].Rows[0]["RemainVill"].ToString();
                            txtnooffamilyreaming.Text = ds.Tables[0].Rows[0]["RemainFam"].ToString();
                            txtremarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                            txtvillageReAnyotherpackge.Text = ds.Tables[0].Rows[0]["VillRelocOtherPack"].ToString();
                            txtReserve.Text = ds.Tables[0].Rows[0]["ReserveId"].ToString();

                        }
                    }
                }
            }
        }
        catch
        {
            throw;
        }
    }


    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("RelocationProgresManagement.aspx");
    }
}