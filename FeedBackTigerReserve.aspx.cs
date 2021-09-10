using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;

public partial class FeedBackTigerReserve : BasePage
{
    UserBL _Userbl = new UserBL();
    NtcaUserOB objntcauser = new NtcaUserOB();
    Project_Variables Pvar = new Project_Variables();
    Commanfuction _commanfucation = new Commanfuction();
    ContentOB contentObject = new ContentOB();
    FeedBackBL objfeedBackBL = new FeedBackBL();
    string LoginUserid;
    int LoginUsertype;
    //below naren
   

    Content_ManagementBL footerMenuBL = new Content_ManagementBL();
    Project_Variables p_var = new Project_Variables();
    ContentOB lnkObject = new ContentOB();
    // BreadcrumDL brdl = new BreadcrumDL();
    
    public int Websiteid { get; set; }
   
    static string strlatestdate;
    //naren
    BannerManagementBL menuBL1 = new BannerManagementBL();
    public static int GetReserveID = 0;
    public static string url = string.Empty;
  //  ContentOB contentObject = new ContentOB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Title = "Feedback:NTCA";
            Bind_State();
            if (Session["Strname"] != string.Empty && Session["Strname"] != null)
            {

                getReserveIDbyRname();
                url = "?trname=" + Session["Strname"].ToString() + "&stateIDq=" + Session["SstateIDq"].ToString() + "&statename=" + Session["Sstatename"].ToString() + "&hckey=" + Session["SHcKey"].ToString();
            }
            BindFooterMenu();
        }
    }
    public void getReserveIDbyRname()
    {
        try
        {
            contentObject.TigerReserveName = Session["Strname"].ToString();
            p_var.dsFileName = menuBL1.getTigerReserveIdByTname(contentObject);
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
    void Bind_State()
    {
        objntcauser.UserID = Convert.ToInt32(LoginUserid);
        Pvar.dSet = _commanfucation.StateListByUserAccess(objntcauser);
        ddlstate.DataSource = Pvar.dSet;
        ddlstate.DataTextField = "StateName";
        ddlstate.DataValueField = "id";
        ddlstate.DataBind();

        ddlstate.Items.Insert(0, new ListItem("Select State", "0"));

    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            recaptcha.ValidateCaptcha(txtcaptcha.Text);
            if (recaptcha.UserValidated)
            {
                string hostName = Dns.GetHostName();
                string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

                contentObject.Name = HttpUtility.HtmlEncode(TxtName.Text.Trim());
                contentObject.EmailID = HttpUtility.HtmlEncode(TxtEmail.Text.Trim());
                contentObject.Phone = HttpUtility.HtmlEncode(TxtPhone.Text.Trim());
                contentObject.Address = HttpUtility.HtmlEncode(TxtAddress.Text.Trim());
                contentObject.StateID = Convert.ToInt32(ddlstate.SelectedValue);
                contentObject.StateName = ddlstate.SelectedItem.Text;
                contentObject.details = HttpUtility.HtmlEncode(TxtMessage.Text.Trim());
                contentObject.IpAddress = myIP;
                contentObject.ModuleID = Convert.ToInt16(Module_ID_Enum.Project_Module_ID.FeedBackTigerReserve);
                contentObject.FeedBackFrom = Convert.ToInt32(DdlFeedBackFrom.SelectedValue);
                int insertdata = objfeedBackBL.insertFeedBack(contentObject);
                if (insertdata > 0)
                {
                    Response.Redirect("~/FeedBackThankYoutr.aspx");
                }


            }
            else
            {
                Response.Write("<script>alert('Enter captcha code is incorrect!!');</script>");
            }
        }
    }
    public void BindFooterMenu()
    {
        try
        {
            p_var.sbuilder.Remove(0, p_var.sbuilder.Length);
            lnkObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
            lnkObject.PositionID = (int)Module_ID_Enum.Menu_Position.footer;
            p_var.position = (int)lnkObject.PositionID;
            lnkObject.ModuleID = (int)Module_ID_Enum.Project_Module_ID.cms;
            lnkObject.LinkParentID = (int)Module_ID_Enum.Link_parentID_Footer.parent_Footer;
            lnkObject.StateID = 1;
            if (GetReserveID == 0)
            {
                lnkObject.TigerReserveid = 0;
            }
            else
            {
                lnkObject.TigerReserveid = GetReserveID;
            }
            //lnkObject.TigerReserveid = Convert.ToInt16(Session["Tid"]);
            lnkObject.Websiteid = 2;

            p_var.dSet = footerMenuBL.getFrontRootMenu(lnkObject);
            p_var.sbuilder.Append("<div class=\"col-md-3\">");

            if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
            {

                if (GetReserveID == 0)
                {
                    //p_var.sbuilder.Append("<li>");
                    //p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "home.aspx'> Home </a>");
                    //p_var.sbuilder.Append("</li>");

                    //p_var.sbuilder.Append("<li>");
                    //p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "feedback.aspx'> feedback </a>");
                    //p_var.sbuilder.Append("</li>");
                }
                else
                {
                    p_var.sbuilder.Append("<li>");
                    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "index.aspx" + url + "'> Home </a>");
                    p_var.sbuilder.Append("</li>");

                    p_var.sbuilder.Append("<li>");
                    p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "'     href='" + ResolveUrl("~/") + "FeedBackTigerReserve.aspx'> feedback </a>");
                    p_var.sbuilder.Append("</li>");
                }

            }

            for (int i = 0; i < p_var.dSet.Tables[0].Rows.Count; i++)
            {

                p_var.menu_name = HttpUtility.HtmlDecode(p_var.dSet.Tables[0].Rows[i]["name"].ToString());
                p_var.menuid = Convert.ToInt16(p_var.dSet.Tables[0].Rows[i]["link_id"]);
                p_var.urlname = p_var.dSet.Tables[0].Rows[i]["UrlName"].ToString();

                if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == (int)Module_ID_Enum.Language_ID.English)
                {

                    //Code to remove 
                    ContentOB _lnkSubmenuObject = new ContentOB();
                    DataSet ds = new DataSet();
                    _lnkSubmenuObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
                    _lnkSubmenuObject.PositionID = (int)Module_ID_Enum.Menu_Position.footer;
                    _lnkSubmenuObject.LinkParentID = p_var.menuid;
                    ds = footerMenuBL.getSubmenuofRootMenu(_lnkSubmenuObject);

                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        p_var.sbuilder.Append("<li>");

                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href=" + ResolveUrl("~/content/") + p_var.url + ds.Tables[0].Rows[0]["link_id"] + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + p_var.menu_name + "</a>");
                        p_var.sbuilder.Append("</li>");
                    }

                    else
                    {
                        p_var.sbuilder.Append("<li>");
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href='" + ResolveUrl("~/content/") + p_var.url + p_var.menuid + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                        p_var.sbuilder.Append("</li>");
                    }

                }
                else
                {
                    //Code to remove 
                    ContentOB _lnkSubmenuObject = new ContentOB();
                    DataSet ds = new DataSet();
                    _lnkSubmenuObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
                    _lnkSubmenuObject.PositionID = (int)Module_ID_Enum.Menu_Position.footer;
                    _lnkSubmenuObject.LinkParentID = p_var.menuid;
                    ds = footerMenuBL.getSubmenuofRootMenu(_lnkSubmenuObject);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        p_var.sbuilder.Append("<li>");
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href=" + ResolveUrl("~/content/") + p_var.url + ds.Tables[0].Rows[0]["link_id"] + "_" + Convert.ToInt16(p_var.position) + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx>" + p_var.menu_name + "</a>");
                        p_var.sbuilder.Append("</li>");
                    }

                    else
                    {
                        p_var.sbuilder.Append("<li>");
                        p_var.sbuilder.Append("<a title='" + HttpUtility.HtmlDecode(p_var.menu_name) + "' href='" + ResolveUrl("~/content/") + p_var.url + p_var.menuid + "_" + p_var.position + "_" + p_var.urlname.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + HttpUtility.HtmlDecode(p_var.menu_name) + "</a>");
                        p_var.sbuilder.Append("</li>");
                    }

                }



            }
            p_var.sbuilder.Append("</div>");
            LtrLeftMenu.Text = p_var.sbuilder.ToString();
        }
        catch
        {
            throw;
        }
    }

}