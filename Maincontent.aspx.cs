using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;

using System.Text.RegularExpressions;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Net;

public partial class Maincontent : BasePage
{
    public string imgSrc = "";
    string Lang_id = "";
    string pgTitle = string.Empty;
    string RootParentName = string.Empty;
    string Childname = string.Empty;
    string strbreadcrum = string.Empty;
    int RootID;
    public string ParentName = string.Empty;
    string PositionID = HttpContext.Current.Request.QueryString["position"];
    Miscelleneous_DL miscellBL = new Miscelleneous_DL();
    Menu_ManagementBL menuBL = new Menu_ManagementBL();
    Project_Variables p_var = new Project_Variables();
    LinkOB lnkObject = new LinkOB();
    DataSet ds = new DataSet();


    string MetaKeyword = string.Empty;
    string MetaDescription = string.Empty;
    string MetaLng = string.Empty;
    string MetaTitles = string.Empty;
    string Title = string.Empty;
    int lengthCounter = 0;
    string srt;
   // static string thisTitle = string.Empty;

    //EmployeeBAL objEmployeeBAL = new EmployeeBAL();
    //EmployeeOB onjempEntity = new EmployeeOB();
    Random random = new Random();

    //FeedBackBL FeedBAL = new FeedBackBL();
    //FeedbackOB FeedOB = new FeedbackOB();
    ContentOB contentObject = new ContentOB();
    MiddleContentBL MiddleContentBL = new MiddleContentBL();
    Project_Variables p_Var = new Project_Variables();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Value"] != null)
        {
            if (Request.QueryString["langId"].ToString() == "1")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN");
            }
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString() == "hi-IN")
            {
                Lang_id = "2";
            }
            else
            {
                Lang_id = "1";
            }
        }
        else
        {
            if (System.Threading.Thread.CurrentThread.CurrentUICulture.ToString() == "hi-IN")
            {
                Lang_id = "2";
            }
            else
            {
                Lang_id = "1";
            }
        }

        Page.Header.DataBind();
        //  display();
        if (!IsPostBack)
        {
           
            display();
            bindTopMiddleLower();
            //if (!string.IsNullOrWhiteSpace(thisTitle))
            //{
            //    this.Title = thisTitle;
            //}
           // Page.Title = "fdfd";

        }
    }
    public void bindTopMiddleLower()
    {
        try
        {

            contentObject.ModuleID = 6;
            contentObject.Websiteid = 1;

            p_Var.dsFileName = MiddleContentBL.bindTopMiddleLowerOnHomePage(contentObject);
            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
            {
                p_Var.sbuilder.Append("<div class=\"col-sm-3\">");
                for (p_Var.i = 0; p_Var.i < p_Var.dsFileName.Tables[0].Rows.Count; p_Var.i++)
                {


                    if (p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Details"].ToString() != string.Empty)
                    {
                        if ((p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"]).ToString() == "Contact Us")
                        {
                            p_Var.sbuilder.Append("<div id=\"look" + p_Var.i + "\" class=\"text-center selectleftmnu\" runat=\"server\">");
                            p_Var.sbuilder.Append("<a href=\"" + ResolveUrl("~/" + "Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "&bts=" + p_Var.i + "\" class=\"read_morea get12\">" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + ""));
                            p_Var.sbuilder.Append("</a>");
                            p_Var.sbuilder.Append("</div>");
                        }
                       // Convert.ToInt32(Session["menuid"])
                        //href=\"" + ResolveUrl("~/" + p_var.url + "index.aspx") + "\" title=\"Home Page\">" + Resources.NTCAResources.Home + "</a> / </strong>");
                        else
                        {
                            p_Var.sbuilder.Append("<div id=\"look" + p_Var.i + "\" class=\"text-center \" runat=\"server\">");
                            p_Var.sbuilder.Append("<a href=\"" + ResolveUrl("~/" + "Homemiddlecontent.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "&bts=" + p_Var.i + "\" class=\"read_morea get12\">" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + ""));
                            p_Var.sbuilder.Append("</a>");
                            p_Var.sbuilder.Append("</div>");
                        }

                    }
                    else
                    {

                        p_Var.sbuilder.Append("<div class=\"text-center\">");
                        p_Var.sbuilder.Append("<a href=\"" + ResolveUrl("~/"+"contactus.aspx?ModuleID=6&Websiteid=1&Link_Id=" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Link_Id"].ToString() + "\" class=\"read_morea\">" + p_Var.dsFileName.Tables[0].Rows[p_Var.i]["Name"].ToString() + ""));
                        p_Var.sbuilder.Append("</a>");
                        p_Var.sbuilder.Append("</div>");

                    }



                }
                p_Var.sbuilder.Append("</div>");
            }
            LtrLeftMenu.Text = p_Var.sbuilder.ToString();

        }


        catch
        {
            throw;
        }
    }
    private void bindBreadCrumbs(string linktype, string positionidIMDParent, string placeholeroneIMDParent, string LinkidParent, string positionidParent, string placeholeroneParent, string ParentName, int? parentIdIMD, int? ParentPos, string ParentNameIMDPARENT, String MenuName)
    {

        p_var.sbuilder.Length = 0;
        if (Resources.NTCAResources.Lang_Id == "1")
        {
            p_var.url = "content/";
        }
        else if (Resources.NTCAResources.Lang_Id == "2")
        {
            p_var.url = "content/Hindi/";

        }

        p_var.sbuilder.Append("<strong><a href=\"" + ResolveUrl("~/" + p_var.url + "index.aspx") + "\" title=\"Home Page\">" + Resources.NTCAResources.Home + "</a> / </strong>");
        if (parentIdIMD == null)
        {
            p_var.sbuilder.Append("<a href='#'> " + HttpUtility.HtmlDecode(MenuName) + "</a>");
        }


        else
        {
            if (ParentName != "")
            {

                p_var.sbuilder.Append("<strong><a   href='" + ResolveUrl("~/") + p_var.url + LinkidParent + "_" + positionidParent + "_" + placeholeroneParent.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + Server.HtmlDecode(ParentName) + "</a> / </strong>");

                // p_var.sbuilder.Append("<li><a href='#'>" + HttpUtility.HtmlDecode(ParentNamesecond) + "</a><span>&raquo;</span></li>");
            }
            if (ParentNameIMDPARENT != "")
            {
                if (linktype == "1")
                {
                    p_var.sbuilder.Append("<strong><a   href='" + ResolveUrl("~/") + p_var.url + parentIdIMD + "_" + positionidIMDParent + "_" + placeholeroneIMDParent.Replace(" ", "").Replace("&", "and").Replace("'", "").Replace("_", "") + ".aspx'>" + Server.HtmlDecode(ParentNameIMDPARENT) + "</a> / </strong>");

                }
                else
                {
                    p_var.sbuilder.Append("<strong><a href='#'>" + HttpUtility.HtmlDecode(ParentNameIMDPARENT) + "</a> /</strong>");
                }//p_var.sbuilder.Append("<li><a href='#'>" + HttpUtility.HtmlDecode(ParentName) + "</a><span>&raquo;</span></li>");
            }

            p_var.sbuilder.Append("" + HttpUtility.HtmlDecode(MenuName) + "");


        }
        bradcrumb.Text = p_var.sbuilder.ToString();


    }
    public void display()
    {
        string Title = null;
        string Menu_Name = "";
        StringBuilder strpdfPath = new StringBuilder();
        StringBuilder value = new StringBuilder();
        string[] filenameSplit = { };
        string type = "";

        p_var.LanguageID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
        if (Request.QueryString["Value"] != null)
        {

            p_var.PageID = Request.QueryString["Value"].ToString();


        }
        else
        {

            p_var.PageID = RewriteModule.RewriteContext.Current.Params["menuid"].ToString();

            lnkObject.status = 5;

        }




        if (p_var.PageID != null)
        {
            if (Lang_id.ToString() == "1")
            {
                lnkObject.linkID = Convert.ToInt16(p_var.PageID);
            }
            else
            {
                if (Request.QueryString["Value"] != null)
                {
                    lnkObject.linkID = Convert.ToInt16(p_var.PageID);
                }
                else
                {
                    lnkObject.linkID = Convert.ToInt16(p_var.PageID.Remove(0, 6));
                }
            }
            lnkObject.LangId = p_var.LanguageID;

            ds = menuBL.get_Cliked_Parent_Menu(lnkObject);


            if (ds.Tables[0].Rows.Count > 0)
            {

               Page.Title = ds.Tables[0].Rows[0]["name"].ToString() + ":National Tiger Conservation Authority";
               pgTitle = ds.Tables[0].Rows[0]["name"].ToString();


                p_var.parentID = ds.Tables[0].Rows[0]["link_parent_id"].ToString();
                lnkObject.LinkParentId = Convert.ToInt16(p_var.parentID);
                p_var.position = Convert.ToInt16(ds.Tables[0].Rows[0]["Position_Id"]);

                //--------
                if (ds.Tables[0].Rows[0]["File_name"].ToString() != "")
                {
                    string filenamedoc = string.Empty;
                    filenamedoc = ds.Tables[0].Rows[0]["File_name"].ToString();
                    hypfile.NavigateUrl = ResolveUrl("~/WriteReadData/CMS/") + filenamedoc;
                    hypfile.Text = filenamedoc;

                    //
                    string[] arr11 = filenamedoc.ToString().Split('.');
                    string srt1 = arr11[1];

                }
                else
                {
                    imgdown.Visible = false;
                }
                string strVlaue = "";
                strVlaue = HttpUtility.HtmlDecode(ds.Tables[0].Rows[0]["Details"].ToString());
                Title = ds.Tables[0].Rows[0]["Browser_Title"].ToString() +":" + Resources.NTCAResources.PPAC;
                MetaDescription = ds.Tables[0].Rows[0]["Mate_Description"].ToString() + " " + ConfigurationManager.AppSettings["Description"].ToString();
                MetaKeyword = ds.Tables[0].Rows[0]["Meta_Keywords"].ToString() + "" + ConfigurationManager.AppSettings["Keyword"].ToString();
                MetaTitles = ds.Tables[0].Rows[0]["Browser_Title"].ToString() + ":" + HttpUtility.HtmlDecode(Resources.NTCAResources.PPAC);
                Menu_Name = HttpUtility.HtmlDecode(ds.Tables[0].Rows[0]["Name"].ToString());
                // ltrlastupdated.Text = Resources.Resource.LastUpdated+" "+ ds.Tables[0].Rows[0]["LastUpdate"].ToString();
                ltrlastupdated.Text = "<span class='spanbold'> " + Resources.NTCAResources.LastUpdated + "</span>&nbsp;" + ds.Tables[0].Rows[0]["Last_update"].ToString();

                if (Resources.NTCAResources.Lang_Id == "1")
                {
                    MetaLng = "en-US";
                }
                else
                {
                    MetaLng = "hi-IN";
                }



                string[] arr1 = strVlaue.ToString().Split('<');

                for (int i = 0; i < arr1.Length; i++)
                {

                    string srt = arr1[i];
                    if (srt.StartsWith("a"))
                    {
                        string pdf = arr1[i];
                        string[] pdfSplit = pdf.Split('=');
                        for (int j = 0; j < pdfSplit.Length; j++)
                        {
                            if (pdfSplit[j].Contains(".pdf"))
                            {
                                string url = pdfSplit[j];

                                string filename = url;
                                filenameSplit = filename.Split('.');
                                // Get_FileSize(filenameSplit[0]);
                                type = "pdf";
                            }
                            else if (pdfSplit[j].Contains(".doc"))
                            {
                                string url = pdfSplit[j];

                                string filename = url;
                                filenameSplit = filename.Split('.');
                                type = "doc";
                            }
                            else if (pdfSplit[j].Contains(".docx"))
                            {
                                string url = pdfSplit[j];

                                string filename = url;
                                filenameSplit = filename.Split('.');
                                type = "docx";
                            }
                            else if (pdfSplit[j].Contains(".xls"))
                            {
                                string url = pdfSplit[j];

                                string filename = url;
                                filenameSplit = filename.Split('.');
                                type = "xls";
                            }
                            else if (pdfSplit[j].Contains(".xlsx"))
                            {
                                string url = pdfSplit[j];

                                string filename = url;
                                filenameSplit = filename.Split('.');
                                type = "xlsx";
                            }

                            else
                            {
                                strpdfPath.Append(pdfSplit[j]);
                            }
                        }
                        if (filenameSplit.Length > 0)
                        {
                            //string size = Get_FileSize(strpdfPath.ToString(), filenameSplit[0]);
                            //if (arr1[i - 1].Contains(".pdf"))
                            ////{
                            //string[] pdffilname1 = filenameSplit[0].Split ("/");
                            string filesize = "0";
                            string contentValue = filenameSplit[0].ToString();
                            string[] content = contentValue.Split('/');
                            string s = content[content.Length - 1].ToString().Replace("\r\n", "");
                            string fn = new Regex(@"\s*").Replace(s, string.Empty);
                            fn = fn.Replace("%20", " ");

                            if (content.Length > 0)
                            {
                                if (!contentValue.Contains("http"))
                                {
                                    FileInfo finfo1 = new FileInfo(Server.MapPath("~/WriteReadData/userfiles/file/") + fn + "." + type);

                                    if (finfo1.Exists)
                                    {
                                        double FileInBytes = finfo1.Length;
                                        filesize = miscellBL.fileSizeForContentPage(FileInBytes);

                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        double doublevalue = 0;
                                        using (WebClient obj = new WebClient())
                                        {
                                            using (Stream strem = obj.OpenRead(pdfSplit[1].Trim(new Char[] { ' ', ',', '\t', '\"' }).Replace("target", "").TrimStart('\"').Replace("\"", "")))
                                            {
                                                if (double.TryParse(Convert.ToString(obj.ResponseHeaders["Content-Length"]), out doublevalue))
                                                    filesize = miscellBL.fileSizeForContentPage(doublevalue);
                                            }
                                        }

                                    }
                                    catch
                                    {
                                        try
                                        {

                                            FileInfo finfo1 = new FileInfo(pdfSplit[1].Trim(new Char[] { ' ', ',', '\t', '\"' }).Replace("target", "").TrimStart('\"').Replace("\"", ""));

                                            if (finfo1.Exists)
                                            {
                                                double FileInBytes = finfo1.Length;
                                                filesize = miscellBL.fileSizeForContentPage(FileInBytes);


                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }

                                }
                                string strTest = "";

                                if (type.ToLower() == "pdf")
                                {
                                    strTest = "<img width='15' alt='View Document' height=\"15\"   src='" + ResolveUrl("~/images/pdf.png") + "'/>" + filesize.ToString();
                                }
                                else if (type == "doc")
                                {
                                    strTest = "<img width='15' alt='View Document' height=\"15\"   src='" + ResolveUrl("~/images/word.png") + "'/>" + filesize.ToString();
                                }
                                else if (type == "docx")
                                {
                                    strTest = "<img width='15' alt='View Document' height=\"15\"   src='" + ResolveUrl("~/images/word.png") + "'/>" + filesize.ToString();
                                }

                                else if (type == "xls")
                                {
                                    strTest = "<img width='15' alt='View Document' height=\"15\"   src='" + ResolveUrl("~/images/excel.png") + "'/>" + filesize.ToString();
                                }

                                else if (type == "xlsx")
                                {
                                    strTest = "<img width='15' alt='View Document' height=\"15\"   src='" + ResolveUrl("~/images/excel.png") + "'/>" + filesize.ToString();
                                }

                                if (srt.Contains(".docx") || srt.Contains(".doc") || srt.Contains(".pdf") || srt.Contains(".xlsx") || srt.Contains(".xls"))
                                {

                                    srt = srt.ToString() + "  " + strTest;
                                }
                                else
                                {
                                    srt = srt.ToString();
                                }

                            }

                        }
                        //}


                    }
                    if (i > 0)
                    {
                        value.Append("<");
                    }
                    value.Append(srt);
                }

                LitDesc.Text = value.ToString();

                //if (Convert.ToInt32(lnkObject.linkID) == (int)Module_ID_Enum.Menu_ID_Fixed.EmployeeCorner || Convert.ToInt32(lnkObject.linkID) == (int)Module_ID_Enum.Menu_ID_Fixed.EmployeeCornerleftHindi)
                //{
                //    if (!String.IsNullOrEmpty(Convert.ToString(Session["EmployeeUsername"])))
                //    {
                //        LitDesc.Text = value.ToString();
                //    }
                //}
                //else
                //{
                //    LitDesc.Text = value.ToString();
                //}







                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["parent"].ToString()))
                {
                    ParentName = ds.Tables[0].Rows[0]["parent"].ToString();
                    litPageHead.Text = Menu_Name;
                }
                else
                {
                    litPageHead.Text = Menu_Name;
                }
                
            }
            



            //  SetMetaTags(Title, MetaDescription, MetaKeywords);

            //if (p_var.parentID != "0")
            //{

            //    if (ds.Tables[1].Rows.Count > 0)
            //    {
            //        bindBreadCrumbs(ds.Tables[2].Rows[0]["Link_Type_Id"].ToString(), ds.Tables[2].Rows[0]["Position_Id"].ToString(), ds.Tables[2].Rows[0]["placeholderone"].ToString(), ds.Tables[1].Rows[0]["Link_Id"].ToString(), ds.Tables[1].Rows[0]["Position_Id"].ToString(), ds.Tables[1].Rows[0]["placeholderone"].ToString(), ds.Tables[1].Rows[0]["Name"].ToString(), Convert.ToInt16(p_var.parentID), p_var.position, ds.Tables[0].Rows[0]["parent"].ToString(), ds.Tables[0].Rows[0]["name"].ToString());
            //    }
            //    else
            //    {
            //        bindBreadCrumbs(ds.Tables[2].Rows[0]["Position_Id"].ToString(), ds.Tables[2].Rows[0]["placeholderone"].ToString(), Convert.ToInt16(p_var.parentID), p_var.position, ds.Tables[0].Rows[0]["parent"].ToString(), ds.Tables[0].Rows[0]["name"].ToString());
            //    }

            //    if (ds.Tables[0].Rows[0]["counter_Child"].ToString() != "")
            //    {
            //        LeftMenu(lnkObject.linkID, p_var.position, ds.Tables[0].Rows[0]["parent"].ToString(), lnkObject.linkID);
            //    }
            //    else
            //    {
            //        LeftMenu(lnkObject.LinkParentId, p_var.position, ds.Tables[0].Rows[0]["parent"].ToString(), lnkObject.linkID);
            //    }
            //}
            //else
            //{
            //    if (p_var.position == 2)
            //    {
            //        lnkObject.LangId = Convert.ToInt32(Resources.NTCAResources.Lang_Id);
            //        lnkObject.PositionId = p_var.position;
            //        lnkObject.StatusId = (int)Module_ID_Enum.Module_Permission_ID.Approved;
            //        p_var.position = (int)lnkObject.PositionId;
            //        lnkObject.ModuleId = (int)Module_ID_Enum.Project_Module_ID.Menu;
            //        lnkObject.LinkParentId = (int)Module_ID_Enum.Link_parentID_Footer.parent_Footer;


            //        ds = menuBL.get_Frontside_RootMenu(lnkObject);
            //        ds.Tables[0].DefaultView.RowFilter = "link_id =" + lnkObject.linkID;
            //        DataView dt = new DataView();
            //        dt = ds.Tables[0].DefaultView;
            //        if (dt[0]["counter_child"].ToString() != "")
            //        {
            //            bindBreadCrumbs(Convert.ToInt16(p_var.parentID), p_var.position, "", dt[0]["name"].ToString());
            //            LeftMenu(lnkObject.LinkParentId, 2, dt[0]["name"].ToString(), lnkObject.linkID);
            //        }
            //        else
            //        {
            //            // litleftheading.Text = Menu_Name;
            //            bindBreadCrumbs(Convert.ToInt16(p_var.parentID), p_var.position, "", dt[0]["name"].ToString());
            //        }
            //    }
            //    else
            //    {

            //        LeftMenu(lnkObject.linkID, p_var.position, ds.Tables[0].Rows[0]["Name"].ToString(), lnkObject.linkID);

            //        //-----------------------------------------------------
            //        bindBreadCrumbs(null, null, null, ds.Tables[0].Rows[0]["name"].ToString());
            //    }
            //}



        }
        //if (Convert.ToInt16(ds.Tables[0].Rows[0]["Link_Level"]) == 2)
        //{
        //    p_var.parentID = lnkObject.LinkParentId.ToString();
        //    //Get Root name of for implimenting third level breadcrum
        //    Menu_ManagementBL menuRootBL = new Menu_ManagementBL();
        //    LinkOB linkObject = new LinkOB();
        //    DataSet dDataSet = new DataSet();
        //    linkObject.linkID = Convert.ToInt16(p_var.parentID);
        //    linkObject.LangId = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
        //    dDataSet = menuRootBL.getParent_name_ofRoot(linkObject);
        //    if (dDataSet.Tables[0].Rows.Count > 0)
        //    {
        //        RootParentName = dDataSet.Tables[0].Rows[0]["name"].ToString();
        //        RootID = Convert.ToInt16(dDataSet.Tables[0].Rows[0]["link_id"]);
        //    }

        //    //End
        //    Childname = ds.Tables[0].Rows[0]["name"].ToString();

        //}
    }
	
	 protected override void PageMetaTags()
    {

        MetaTitle = pgTitle + ": National Tiger Conservation Authority";//p_var.dSet.Tables[0].Rows[0]["Page_Title"].ToString();
        MetaKeywords = "NTCA"+","+ pgTitle;//p_var.dSet.Tables[0].Rows[0]["Meta_Keywords"].ToString();
        MetaDescription = "National Tiger Conservation Authority";//p_var.dSet.Tables[0].Rows[0]["Mate_Description"].ToString();
        MetaLang = "en";
    }
}