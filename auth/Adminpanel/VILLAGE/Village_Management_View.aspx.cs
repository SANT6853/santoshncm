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
using System.IO;
using System.Text;

public partial class auth_Adminpanel_VILLAGE_Village_Management_View : System.Web.UI.Page
{
    VillageDB VillDB_Obj = new VillageDB();
    CommonDB comDB_Obj = new CommonDB();
    VillageEntity VillEntity_Obj = new VillageEntity();
    public string lat1 = "";
    string legalstatus = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        Response.Cache.SetExpires(System.DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        if (!Page.IsPostBack)
        {


            lblMsg.Text = "";
            if (Session["User_Id"] == null || Session["User_Id"].ToString() == "")
            {
                Response.Redirect(ResolveUrl("~/Home.aspx"), true);
            }
            ////if (Session["UserRole"].ToString().Equals("3"))
            ////{
            ////    Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/RedirectPage.aspx"), false);
            ////}
            if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != null)
            {
                if (Request.QueryString[WebConstant.QueryStringEnum.VillageID] != "")
                {



                    Load_Village_Info();
                }
                else
                {
                    lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    public void Load_Village_Info()
    {
        try
        {
            DataSet ds = new DataSet();
            ds=null;
            VillEntity_Obj._VILL_ID = Request.QueryString[WebConstant.QueryStringEnum.VillageID].ToString().Trim();


            ds = VillDB_Obj.PopUpDisplay_All_VillagesDB(VillEntity_Obj);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblsurdate.Text = ds.Tables[0].Rows[0]["VILL_SURVEY_DT1"].ToString().ToString();
                lblcode.Text = ds.Tables[0].Rows[0]["VILL_CD"].ToString();
                lblname.Text = ds.Tables[0].Rows[0]["VILL_NM"].ToString();
                lblpop.Text = ds.Tables[0].Rows[0]["VILL_POPU"].ToString();
                LblLatitude.Text = ds.Tables[0].Rows[0]["Latitude"].ToString();
                LblLagituted.Text = ds.Tables[0].Rows[0]["Longitude"].ToString();
                if (ds.Tables[0].Rows[0]["VILL_TOT_LND_AREA"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_TOT_LND_AREA"].ToString().Equals("0"))
                {
                    lblland.Text = "0";
                }
                else
                {
                    lblland.Text = ds.Tables[0].Rows[0]["VILL_TOT_LND_AREA"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VILL_TOT_AGRI_LND_AREA"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_TOT_AGRI_LND_AREA"].ToString().Equals("0"))
                {
                    lblagri.Text = "0";
                }
                else
                {
                    lblagri.Text = ds.Tables[0].Rows[0]["VILL_TOT_AGRI_LND_AREA"].ToString();
                }

                if (ds.Tables[0].Rows[0]["VILL_TOT_NON_AGRI_LND_AREA"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_TOT_NON_AGRI_LND_AREA"].ToString().Equals("0"))
                {
                    lblnonagri.Text = "0";
                }
                else
                {
                    lblnonagri.Text = ds.Tables[0].Rows[0]["VILL_TOT_NON_AGRI_LND_AREA"].ToString();
                }


                if (ds.Tables[0].Rows[0]["VILL_OTHER_LND_AREA"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_OTHER_LND_AREA"].ToString().Equals("0"))
                {
                    lblotherland.Text = "0";
                }

                else
                {
                    lblotherland.Text = ds.Tables[0].Rows[0]["VILL_OTHER_LND_AREA"].ToString();
                }


                if (ds.Tables[0].Rows[0]["VILL_NO_FM"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_NO_FM"].ToString().Equals("0"))
                {
                    lblfamilies.Text = "0";
                }
                else
                {
                    lblfamilies.Text = ds.Tables[0].Rows[0]["VILL_NO_FM"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VILL_MALE"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_MALE"].ToString().Equals("0"))
                {
                    lblmalepop.Text = "0";
                }
                else
                {
                    lblmalepop.Text = ds.Tables[0].Rows[0]["VILL_MALE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VILL_FEMALE"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_FEMALE"].ToString().Equals("0"))
                {
                    lblfemalepop.Text = "0";
                }
                else
                {

                    lblfemalepop.Text = ds.Tables[0].Rows[0]["VILL_FEMALE"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VILL_NO_LIV_STOK"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_NO_LIV_STOK"].ToString().Equals("0"))
                {
                    lbllivestocks.Text = "0";
                }
                else
                {
                    lbllivestocks.Text = ds.Tables[0].Rows[0]["VILL_NO_LIV_STOK"].ToString();
                }

                if (ds.Tables[0].Rows[0]["VILL_TOT_OBC"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_TOT_OBC"].ToString().Equals("0"))
                {
                    lblobc.Text = "0";
                }
                else
                {
                    lblobc.Text = ds.Tables[0].Rows[0]["VILL_TOT_OBC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VILL_TOT_ST"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_TOT_ST"].ToString().Equals("0"))
                {
                    lblst.Text = "0";
                }
                else
                {
                    lblst.Text = ds.Tables[0].Rows[0]["VILL_TOT_ST"].ToString();
                }

                if (ds.Tables[0].Rows[0]["VILL_TOT_SC"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_TOT_SC"].ToString().Equals("0"))
                {
                    lblsc.Text = "0";
                }
                else
                {
                    lblsc.Text = ds.Tables[0].Rows[0]["VILL_TOT_SC"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VILL_TOT_OTH"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_TOT_OTH"].ToString().Equals("0"))
                {
                    lblother.Text = "0";
                }
                else
                {
                    lblother.Text = ds.Tables[0].Rows[0]["VILL_TOT_OTH"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ST_VILL_CD"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["ST_VILL_CD"].ToString().Equals("0"))
                {
                    lblstvillcode.Text = "0";
                }
                else
                {
                    lblstvillcode.Text = ds.Tables[0].Rows[0]["ST_VILL_CD"].ToString();
                }

                if (ds.Tables[0].Rows[0]["VILL_LGL_STAT"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_LGL_STAT"].ToString().Equals("0"))
                {
                    legalstatus = "0";
                }
                else
                {
                    legalstatus = ds.Tables[0].Rows[0]["VILL_LGL_STAT"].ToString();
                }
                lblcomments.Text = ds.Tables[0].Rows[0]["Comments"].ToString();

                string villcnbsts = ds.Tables[0].Rows[0]["VILL_CR_BFFR_STS"].ToString();
                if (villcnbsts == "1")
                {
                    lblcorebuffstatus.Text = "Core Area";
                }
                else
                {
                    lblcorebuffstatus.Text = "Buffer Area";
                }



                if (ds.Tables[0].Rows[0]["VILL_LNG1"].ToString().Equals("0.00") && ds.Tables[0].Rows[0]["VILL_LNGMIN1"].ToString().Equals("0") && ds.Tables[0].Rows[0]["VILL_LNGSEC1"].ToString().Equals("0"))
                {
                   // ltllat1.Text = "";
                }
                else
                {
                   // ltllat1.Text = ds.Tables[0].Rows[0]["VILL_LNG1"].ToString() + "<span>&#176</span>&nbsp;" + ds.Tables[0].Rows[0]["VILL_LNGMIN1"].ToString() + "\"&nbsp;" + ds.Tables[0].Rows[0]["VILL_LNGSEC1"].ToString() + "'";

                }
                if (ds.Tables[0].Rows[0]["VILL_LONG1"].ToString().Equals("0.00") && ds.Tables[0].Rows[0]["VILL_LONGMIN1"].ToString().Equals("0") && ds.Tables[0].Rows[0]["VILL_LONGSEC1"].ToString().Equals("0"))
                {
                  //  ltllong1.Text = "";
                }
                else
                {
                   // ltllong1.Text = ds.Tables[0].Rows[0]["VILL_LONG1"].ToString() + "<span>&#176</span>&nbsp;" + ds.Tables[0].Rows[0]["VILL_LONGMIN1"].ToString() + "\"&nbsp;" + ds.Tables[0].Rows[0]["VILL_LONGSEC1"].ToString() + "'";
                }



                if (ds.Tables[0].Rows[0]["VILL_LNG2"].ToString().Equals("0.00") && ds.Tables[0].Rows[0]["VILL_LNGMIN2"].ToString().Equals("0") && ds.Tables[0].Rows[0]["VILL_LNGSEC2"].ToString().Equals("0"))
                {
                  //  ltllat2.Text = "";
                }
                else
                {
                   // ltllat2.Text = ds.Tables[0].Rows[0]["VILL_LNG2"].ToString() + "<span>&#176</span>&nbsp;" + ds.Tables[0].Rows[0]["VILL_LNGMIN2"].ToString() + "\"&nbsp;" + ds.Tables[0].Rows[0]["VILL_LNGSEC2"].ToString() + "'";
                }
                if (ds.Tables[0].Rows[0]["VILL_LONG2"].ToString().Equals("0.00") && ds.Tables[0].Rows[0]["VILL_LONGMIN2"].ToString().Equals("0") && ds.Tables[0].Rows[0]["VILL_LONGSEC2"].ToString().Equals("0"))
                {
                  //  ltllong2.Text = "";
                }
                else
                {
                    //ltllong2.Text = ds.Tables[0].Rows[0]["VILL_LONG2"].ToString() + "<span>&#176</span>&nbsp;" + ds.Tables[0].Rows[0]["VILL_LONGMIN2"].ToString() + "\"&nbsp;" + ds.Tables[0].Rows[0]["VILL_LONGSEC2"].ToString() + "'";
                }



                if (ds.Tables[0].Rows[0]["VILL_LNG3"].ToString().Equals("0.00") && ds.Tables[0].Rows[0]["VILL_LNGMIN3"].ToString().Equals("0") && ds.Tables[0].Rows[0]["VILL_LNGSEC3"].ToString().Equals("0"))
                {
                   // ltllat3.Text = "";
                }
                else
                {
                   // ltllat3.Text = ds.Tables[0].Rows[0]["VILL_LNG3"].ToString() + "<span>&#176</span>&nbsp;" + ds.Tables[0].Rows[0]["VILL_LNGMIN3"].ToString() + "\"&nbsp;" + ds.Tables[0].Rows[0]["VILL_LNGSEC3"].ToString() + "'";
                }
                if (ds.Tables[0].Rows[0]["VILL_LONG3"].ToString().Equals("0.00") && ds.Tables[0].Rows[0]["VILL_LONGMIN3"].ToString().Equals("0") && ds.Tables[0].Rows[0]["VILL_LONGSEC3"].ToString().Equals("0"))
                {
                   // ltllong3.Text = "";
                }
                else
                {
                  //  ltllong3.Text = ds.Tables[0].Rows[0]["VILL_LONG3"].ToString() + "<span>&#176</span>&nbsp;" + ds.Tables[0].Rows[0]["VILL_LONGMIN3"].ToString() + "\"&nbsp;" + ds.Tables[0].Rows[0]["VILL_LONGSEC3"].ToString() + "'";
                }



                if (ds.Tables[0].Rows[0]["VILL_LNG4"].ToString().Equals("0.00") && ds.Tables[0].Rows[0]["VILL_LNGMIN4"].ToString().Equals("0") && ds.Tables[0].Rows[0]["VILL_LNGSEC4"].ToString().Equals("0"))
                {
                   // ltllat4.Text = "";
                }
                else
                {
                   // ltllat4.Text = ds.Tables[0].Rows[0]["VILL_LNG4"].ToString() + "<span>&#176</span>&nbsp;" + ds.Tables[0].Rows[0]["VILL_LNGMIN4"].ToString() + "\"&nbsp;" + ds.Tables[0].Rows[0]["VILL_LNGSEC4"].ToString() + "'";
                }
                if (ds.Tables[0].Rows[0]["VILL_LONG4"].ToString().Equals("0.00") && ds.Tables[0].Rows[0]["VILL_LONGMIN4"].ToString().Equals("0") && ds.Tables[0].Rows[0]["VILL_LONGSEC4"].ToString().Equals("0"))
                {
                   // ltllong4.Text = "";
                }
                else
                {
                   // ltllong4.Text = ds.Tables[0].Rows[0]["VILL_LONG4"].ToString() + "<span>&#176</span>&nbsp;" + ds.Tables[0].Rows[0]["VILL_LONGMIN4"].ToString() + "\"&nbsp;" + ds.Tables[0].Rows[0]["VILL_LONGSEC4"].ToString() + "'";
                }
                if (ds.Tables[0].Rows[0]["NoCows"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["NoCows"].ToString().Equals("0"))
                {
                    lblcnb.Text = "0";
                }
                else
                {
                    lblcnb.Text = ds.Tables[0].Rows[0]["NoCows"].ToString();
                }
                lblcnb0.Text = ds.Tables[0].Rows[0]["NoSheep"].ToString();
                lblsng0.Text = ds.Tables[0].Rows[0]["NoBuffalo"].ToString();
                if (ds.Tables[0].Rows[0]["NoGoat"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["NoGoat"].ToString().Equals("0"))
                {
                    lblsng.Text = "0";
                }
                else
                {
                    lblsng.Text = ds.Tables[0].Rows[0]["NoGoat"].ToString();
                }

                if (ds.Tables[0].Rows[0]["TOT_OTHR_ANML"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["TOT_OTHR_ANML"].ToString().Equals("0"))
                {
                    lblothranml.Text = "0";
                }
                else
                {
                    lblothranml.Text = ds.Tables[0].Rows[0]["TOT_OTHR_ANML"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VILL_VAL_AGRI"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_VAL_AGRI"].ToString().Equals("0"))
                {
                    lblvalagri.Text = "0";

                }
                else
                {
                    lblvalagri.Text = ds.Tables[0].Rows[0]["VILL_VAL_AGRI"].ToString();
                }

                if (ds.Tables[0].Rows[0]["VILL_VAL_RES"].ToString().Equals("0.00") || ds.Tables[0].Rows[0]["VILL_VAL_RES"].ToString().Equals("0"))
                {
                    lblvalres.Text = "0";

                }
                else
                {
                    lblvalres.Text = ds.Tables[0].Rows[0]["VILL_VAL_RES"].ToString();
                }
                if (legalstatus.Equals("1"))
                {
                    lbllegstatus.Text = "Revenue";
                }
                else if (legalstatus.Equals("2"))
                {
                    lbllegstatus.Text = "Forest";
                }
                else
                {
                    lbllegstatus.Text = "Other_Category";
                }
                string status = ds.Tables[0].Rows[0]["VILL_STAT"].ToString();
                if (status.Equals("1"))
                {
                    lblstatus.Text = "Relocated";
                }
                else if (status.Equals("2"))
                {
                    lblstatus.Text = "Non-Relocated";
                }
                else
                {
                    lblstatus.Text = "In-Progress";
                }
                string stateid = string.Empty;
                string districtid = string.Empty;
                string reserveid = string.Empty;
                string tehsilid = string.Empty;

                string gpid = string.Empty;

                if (ds.Tables[0].Rows[0]["ST_ID"].ToString() != "")
                {
                    stateid = ds.Tables[0].Rows[0]["ST_ID"].ToString();
                }
                else
                {
                    stateid = null;
                }
                if (ds.Tables[0].Rows[0]["DT_ID"].ToString() != "")
                {
                    lbldtname.Text = ds.Tables[0].Rows[0]["DistName"].ToString();
                }
                else
                {
                    districtid = null;
                }
                if (ds.Tables[0].Rows[0]["RSRV_ID"].ToString() != "")
                {
                    reserveid = ds.Tables[0].Rows[0]["RSRV_ID"].ToString();
                }
                else
                {
                    reserveid = null;
                }

                if (ds.Tables[0].Rows[0]["TH_ID"].ToString() != "")
                {
                    lbltehsil.Text = ds.Tables[0].Rows[0]["Tehsil_Name"].ToString();
                }
                else
                {
                    tehsilid = null;
                }
                if (ds.Tables[0].Rows[0]["GP_ID"].ToString() != "")
                {
                    lblgp.Text = ds.Tables[0].Rows[0]["GramPanchayatName"].ToString();
                }
                else
                {
                    gpid = null;
                }

                lbldtname0.Text = ds.Tables[0].Rows[0]["DateMeeting1"].ToString();
                lbldtname1.Text = ds.Tables[0].Rows[0]["CuttOffDate1"].ToString();
                StringBuilder sb = new StringBuilder();
                if (ds.Tables[1].Rows.Count > 0)
                {
                   
                    sb.Append("<ul>");
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        string filename = ds.Tables[1].Rows[i]["FilesName"].ToString();
                        sb.Append("<li>");
                        sb.Append("<a href='"+ResolveUrl("~/WriteReadData/" + ConfigurationManager.AppSettings["VILLAGE"] + "/") + filename +"' target='_blank'>Village File"+(i+1)+"</a>");

                        sb.Append("</li>");
                    }
                    sb.Append("</ul>");
                }
                lblfile.Text = sb.ToString();
                lblmalepop1.Text = ds.Tables[0].Rows[0]["NoAdult"].ToString();
                lblmalepop0.Text = ds.Tables[0].Rows[0]["NoTransGender"].ToString();
            }

            else
            {
                lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
}