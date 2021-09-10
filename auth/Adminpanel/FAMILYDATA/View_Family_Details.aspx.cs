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
public partial class auth_Adminpanel_FAMILYDATA_View_Family_Details : System.Web.UI.Page
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
        ////if (Session["UserRole"].ToString().Equals("3"))
        ////{
        ////    Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/RedirectPage.aspx"), false);
        ////}
        if (!Page.IsPostBack)
        {

            if (Request.QueryString[WebConstant.QueryStringEnum.Familyid] != null && !Request.QueryString[WebConstant.QueryStringEnum.Familyid].Equals(""))
            {
                LoadInfoFamilyId(Request.QueryString[WebConstant.QueryStringEnum.Familyid].ToString());
            }
        }
    }
    public void LoadInfoFamilyId(string familyid)
    {

        try
        {
            DataSet ds = FMLYDB_Obj.Proc_DisplayFamilyById(Request.QueryString["VillId"].ToString(), Request.QueryString["family_id"].ToString(),null);
            if (ds.Tables[0].Rows.Count > 0)
            {
               // lblcode.Text = ds.Tables[0].Rows[0][4].ToString();
                lblname.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
//lblstateName.Text = ds.Tables[0].Rows[0][5].ToString();
                lbldtname.Text = ds.Tables[0].Rows[0]["DistName"].ToString();
               // lblrsname.Text = ds.Tables[0].Rows[0][6].ToString();
                lbltehsil.Text = ds.Tables[0].Rows[0]["Tehsil_Name"].ToString();
                lblgp.Text = ds.Tables[0].Rows[0]["GramPanchayatName"].ToString();
            }
            DataSet ds1 = FMLYDB_Obj.Display_Info_Family_By_FamilyID(Request.QueryString[WebConstant.QueryStringEnum.Familyid].ToString());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblreloplace.Text = ds1.Tables[0].Rows[0]["RELOATION_PLACE"].ToString();
                lbldate.Text = ds1.Tables[0].Rows[0]["SURVEYDATE"].ToString();
                lblfamcode.Text = ds1.Tables[0].Rows[0]["FMLY_REG_CD"].ToString();
                string schemeid = ds1.Tables[0].Rows[0]["SCHM_ID"].ToString();
                if (schemeid == "1")
                {

                    lblscheme.Text = "1";

                }

                else if (schemeid == "3")
                {

                    lblscheme.Text = "II";

                }
                else if (schemeid == "4")
                {

                    lblscheme.Text = "No Option";

                }

                DataSet ds2 = FMLYDB_Obj.GetGroupNameByGroupId(ds1.Tables[0].Rows[0]["GROUP_NM"].ToString());
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    lblgroupname.Text = ds2.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    lblgroupname.Text = "Not Applicable";
                }

                lblrashan.Text = ds1.Tables[0].Rows[0]["FMLY_VALID_ID_NO"].ToString();
                lblvalididname.Text = ds1.Tables[0].Rows[0]["FMLY_VALID_ID_NAME"].ToString();

                lblagri.Text = ds1.Tables[0].Rows[0]["FMLY_AGRI_LND"].ToString();
                lblres.Text = ds1.Tables[0].Rows[0]["FMLY_RESI_LND"].ToString();
                if (lblres.Text.Equals("0"))
                {
                    lblresland.Text = "Not Applicable";
                }
                else
                {
                    string status = ds1.Tables[0].Rows[0]["RESI_LND_STS"].ToString();
                    if (status == "1")
                    {
                        lblresland.Text = "Kachcha";
                    }
                    else if (status == "2")
                    {
                        lblresland.Text = "Pakka";
                    }
                    else
                    {
                        lblresland.Text = "Not Applicable";
                    }
                }
                lblwells.Text = ds1.Tables[0].Rows[0]["FMLY_WELLS"].ToString();
                lbltrees.Text = ds1.Tables[0].Rows[0]["FMLY_TREES"].ToString();
                lblotherassets.Text = ds1.Tables[0].Rows[0]["FMLY_OTHR_ASSETS"].ToString();
                lblstock.Text = ds1.Tables[0].Rows[0]["FMLY_LIVESTOCK"].ToString();
                lblstock0.Text = ds1.Tables[0].Rows[0]["NoBuffalo"].ToString();
                lblcownbuff.Text = ds1.Tables[0].Rows[0]["NoCows"].ToString();
                lblcownbuff0.Text = ds1.Tables[0].Rows[0]["NoGoat"].ToString();

                lblsheepngoat.Text = ds1.Tables[0].Rows[0]["NoSheep"].ToString();
                lblotheranimal.Text = ds1.Tables[0].Rows[0]["FMLY_OTHER_ANML"].ToString();
                lblcomments.Text = ds1.Tables[0].Rows[0]["COMMENT"].ToString();
                bool familystatus = Convert.ToBoolean(ds1.Tables[0].Rows[0]["FMLY_STAT"]);
                if (familystatus == true)
                {
                    lblfamstatus.Text = "Relocated";
                }
                else
                {
                    lblfamstatus.Text = "Non-Relocated";
                }

            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;// + e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }
}