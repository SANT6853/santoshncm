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

public partial class auth_Adminpanel_RelocationSite_Relocation_Site_View : System.Web.UI.Page
{
    VillageDB VillDB_Obj = new VillageDB();
    Realocation_AreaEntiry RELO_ENT_Obj = new Realocation_AreaEntiry();
    Realocation_AreaDB RELODB_Obj = new Realocation_AreaDB();
    CommonDB comDB_Obj = new CommonDB();
    VillageEntity VillEntity_Obj = new VillageEntity();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (!Page.IsPostBack)
        {
            lblMsg.Text = "";
            if (Session["User_Id"] == null)
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"), true);
            }
            Load_Village_Info(Request.QueryString[WebConstant.QueryStringEnum.RELO_ID].ToString().Trim());
           
        }
    }
    public void Load_Village_Info(string reloid)
    {
        try
        {
            DataSet ds = new DataSet();
            RELO_ENT_Obj._VILL_ID = null;
            //ds = RELODB_Obj.Display_All_Relocation_Area(RELO_ENT_Obj, reloid);
            ds = RELODB_Obj.Display_All_Relocation_AreaTo(RELO_ENT_Obj, reloid);
            if (ds.Tables[0].Rows.Count > 0)
            {


                lblstname1.Text = ds.Tables[0].Rows[0]["statename"].ToString();
                lbldtname1.Text = ds.Tables[0].Rows[0]["District_name"].ToString();
                lblthname1.Text = ds.Tables[0].Rows[0]["FromTehSilName"].ToString();
                lblgpname1.Text = ds.Tables[0].Rows[0]["FromGrampanChyatname"].ToString();
                lblvillname1.Text = ds.Tables[0].Rows[0]["tvillage"].ToString();
                lbladdress.Text = ds.Tables[0].Rows[0]["RELOC_SITE_ADD"].ToString();
                lblcomments.Text = ds.Tables[0].Rows[0]["COMMENT"].ToString();
                LbLatitude.Text = ds.Tables[0].Rows[0]["Latitude"].ToString();
                LblLongitutde.Text = ds.Tables[0].Rows[0]["Longitude"].ToString();

                string vill_id = ds.Tables[0].Rows[0]["VILL_ID"].ToString();
                DataSet ds2 = VillDB_Obj.Get_OthersIDs_By_VillId(vill_id);
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    string stateid = ds2.Tables[0].Rows[0]["CmnStateID"].ToString();
                   // string stateid = Session["PermissionState"].ToString();
                    string districtid = ds2.Tables[0].Rows[0]["DT_ID"].ToString();
                    string reserveid = ds2.Tables[0].Rows[0]["CmnDataOperatorTigerReserveID"].ToString();
                    string tehsilid = ds2.Tables[0].Rows[0]["TH_ID"].ToString();
                    string gpid = ds2.Tables[0].Rows[0]["GP_ID"].ToString();
                    lblname.Text = ds2.Tables[0].Rows[0]["VILL_NM"].ToString();
                    lblrsname.Text = ds2.Tables[0].Rows[0]["TigerReserveName"].ToString();
                    DataSet ds1 = new DataSet();
                    ds1 = comDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(stateid, districtid, reserveid, tehsilid, gpid);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {

                        lblstateName.Text = ds1.Tables[0].Rows[0]["ST_NAME"].ToString();
                        lbldtname.Text = ds1.Tables[1].Rows[0]["DT_NAME"].ToString();
                        
                        lbltehsil.Text = ds1.Tables[2].Rows[0]["TH_NAME"].ToString();
                        lblgp.Text = ds1.Tables[3].Rows[0]["GP_NAME"].ToString();

                    }
                    else
                    {
                        lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }

            else
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
}