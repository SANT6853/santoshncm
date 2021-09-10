using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrontPage : System.Web.UI.MasterPage
{
    ContentOB contentObject = new ContentOB();
    MiddleContentBL MiddleContentBL = new MiddleContentBL();
    Project_Variables p_Var = new Project_Variables();
    //naren 
    BannerManagementBL menuBL = new BannerManagementBL();
    Project_Variables p_var = new Project_Variables();
   // ContentOB contentObject = new ContentOB();
    public static int GetReserveID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       // GetReserveID = Convert.ToInt32(Session["sTigerReserveID"]);
        if (Request.QueryString["StateID"] != "0")
        {
            GetReserveID = Convert.ToInt32(Session["sTigerReserveID"]);
        }
        else
        {
            GetReserveID = 0;
        }
        if (!IsPostBack)
        {
            Page.Header.DataBind();
            if (Request.QueryString["StateID"] != "0")
            {
                GetReserveID = Convert.ToInt32(Session["sTigerReserveID"]);
            }
            else
            {
                GetReserveID = 0;
            }
           // GetReserveID = Convert.ToInt32(Session["sTigerReserveID"]);
           // getReserveIDbyRname();
           // DisplayTigerReserver();
            BindBottomThumnailMarquee();
        }
    }
    public void getReserveIDbyRname()
    {
        try
        {
            if (Session["sTreserveName"] != null)
            {
                contentObject.TigerReserveName = Session["sTreserveName"].ToString();
            }
            else
            {
                contentObject.TigerReserveName = Request.QueryString["trname"].ToString();
            }
                
               
            p_var.dsFileName = menuBL.getTigerReserveIdByTname(contentObject);
            if (p_var.dsFileName.Tables[0].Rows.Count > 0)
            {
                GetReserveID = (int)p_var.dsFileName.Tables[0].Rows[0]["TigerReserveid"];
                Session["sTigerReserveID"] = GetReserveID;
            }
        }
        catch
        {
            throw;
        }
    }
    public void BindBottomThumnailMarquee()
    {
        try
        {
            p_Var.sbuilder.Clear();
            p_Var.dsFileName = null;

            contentObject.ModuleID = 7;
            contentObject.Websiteid = 2;
            contentObject.TigerReserveid = GetReserveID;

            p_Var.dsFileName = MiddleContentBL.bindTopMiddleLowerOnHomePageTreserve(contentObject);
            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {
                for (p_Var.i = 0; p_Var.i < p_Var.dsFileName.Tables[0].Rows.Count; p_Var.i++)
                {
                    p_Var.sbuilder.Append("<li>");

                   // p_Var.sbuilder.Append(" <img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' />");
                  //  p_Var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString()) + "'     href='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "'> <img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' /> </a>");
                    p_Var.sbuilder.Append("<a target='_blank' title='" + HttpUtility.HtmlDecode(p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString()) + "' onclick=\"javascript:return confirm('" + Resources.NTCAResources.externallink + "');\"   href='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["UrlName"].ToString() + "'> <img width=\"113\" height=\"100\"  alt='" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["alt_tag"].ToString() + "'" + " src='" + ResolveUrl("~\\WriteReadData\\BannerImages\\" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Image_Name"].ToString() + " ") + "' /> </a>");
                    p_Var.sbuilder.Append("</li>");
                }
            }
            LtrBottomMarquee.Text = p_Var.sbuilder.ToString();

        }


        catch (Exception er)
        {
            throw;
        }
    }
    #region Function to display tiger reserve

    //private void DisplayTigerReserver()
    //{
    //    Project_Variables p_var = new Project_Variables();
    //    TigerReserveOB tigerObject = new TigerReserveOB();
    //    if (Request.QueryString["Tid"] != null && Request.QueryString["Tid"]!="")
    //    {
    //        tigerObject.TigerReserveid = Convert.ToInt16(Request.QueryString["Tid"]);
    //        Session["Tid"] = Convert.ToInt16(Request.QueryString["Tid"]);
    //    }
    //    else
    //    {
    //        tigerObject.TigerReserveid = Convert.ToInt16(Session["Tid"]);
    //        Session["Tid"] = Convert.ToInt16(Session["Tid"]);
    //    }
    //    Commanfuction cf = new Commanfuction();
    //    p_var.dSet = cf.getTigerReserveName(tigerObject);
    //    if (p_var.dSet.Tables[0].Rows.Count > 0)
    //    {
    //        ltrlTigerReserveName.Text = p_var.dSet.Tables[0].Rows[0]["TigerReserveName"].ToString();
    //    }
    //}

    #endregion
}
