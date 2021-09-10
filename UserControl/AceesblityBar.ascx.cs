using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
public partial class UserControl_AceesblityBar : System.Web.UI.UserControl
{
    #region declaration zone
    string strtextsize;
    string strtheme;
    HttpCookie aCookie;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {
            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            SetCSS(aCookie.Values["textSize"]);
        }
        else
        {
            setCookies("Normal", "Blue");
            SetCSS("Normal");
        }
        //ibtnGreenTheme.ToolTip = ibtnGreenTheme.AlternateText = Resources.CRCL_Resource.Theme_Green;

        //ibtnDecreaseFont.ToolTip = ibtnDecreaseFont.AlternateText = Resources.CRCL_Resource.Font_Decrease;
        //ibtnIncreaseFont.ToolTip = ibtnIncreaseFont.AlternateText = Resources.CRCL_Resource.Font_Increase;
        //ibtnNormalFont.ToolTip = ibtnNormalFont.AlternateText = Resources.CRCL_Resource.Font_Normal;
        //ibtnBlueTheme.ToolTip = ibtnBlueTheme.AlternateText = Resources.CRCL_Resource.Theme_Blue;
        //ibtnHighTheme.ToolTip = ibtnHighTheme.AlternateText = Resources.CRCL_Resource.HightContrast;
        //ibtnYelloTheme.ToolTip = ibtnYelloTheme.AlternateText = Resources.CRCL_Resource.Theme_Orange;
       // ibtnStanderd.ToolTip = ibtnStanderd.AlternateText = Resources.CRCL_Resource.StandardContrast;
    }
	
	    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Resources.NTCAResources.Lang_Id == "1")
            {
                Response.Redirect(String.Format("~/Result.aspx?q={0}&cx={1}&cof={2}", HttpUtility.UrlEncode(SanitizeUserInput(txtsearch.Text.Trim())), HttpUtility.UrlEncode(cx.Value), HttpUtility.UrlEncode(cof.Value)), false);
            }
            else
            {
                Response.Redirect(String.Format("~/content/Hindi/Result.aspx?q={0}&cx={1}&cof={2}", HttpUtility.UrlEncode(SanitizeUserInput(txtsearch.Text.Trim())), HttpUtility.UrlEncode(cx.Value), HttpUtility.UrlEncode(cof.Value)), false);
            }
        }
    }
	
	    private String SanitizeUserInput(String text)
    {
        if (String.IsNullOrEmpty(text))
        {
            return String.Empty;
        }

        String rxPattern = "<(?>\"[^\"]*\"|'[^']*'|[^'\">])*>";
        Regex rx = new Regex(rxPattern);
        String output = rx.Replace(text, String.Empty);

        return output;
    }
    protected void ibtnBlueTheme_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {
            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            strtextsize = aCookie.Values["textSize"].ToString();
            setCookies(strtextsize, "Blue");
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

            //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
        }
    }

    protected void ibtnHighTheme_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {
            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            strtextsize = aCookie.Values["textSize"].ToString();
            setCookies(strtextsize, "High");
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

            //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
        }
    }


    protected void ibtnStanderd_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {
            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            strtextsize = aCookie.Values["textSize"].ToString();
            setCookies(strtextsize, "Blue");
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

            //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
        }
    }

    protected void ibtnYelloTheme_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {
            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            strtextsize = aCookie.Values["textSize"].ToString();
            setCookies(strtextsize, "Red");
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

            //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
        }
    }
    protected void ibtnGreenTheme_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {
            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            strtextsize = aCookie.Values["textSize"].ToString();
            setCookies(strtextsize, "Green");
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

            //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
        }
    }



    protected void ibtnDecreaseFont_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {

            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            strtheme = aCookie.Values["Theme"].ToString();
            setCookies("Smaller", strtheme);
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            //Response.Redirect(Request.Url.ToString());
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);
            //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";

        }
    }


    protected void ibtnNormalFont_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {

            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            strtheme = aCookie.Values["Theme"].ToString();
            setCookies("Normal", strtheme);
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            // Response.Redirect(Request.Url.ToString());
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

            //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
        }
    }



    //protected void ibtnNormalFont_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (Request.Cookies["CRCL_Accessibility"] != null)
    //    {

    //        HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
    //        strtheme = aCookie.Values["Theme"].ToString();
    //        setCookies("Normal", strtheme);
    //        HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
    //        // Response.Redirect(Request.Url.ToString());
    //    }
    //    else
    //    {

    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

    //        //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
    //    }
    //}

    //protected void ibtnIncreaseFont_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (Request.Cookies["CRCL_Accessibility"] != null)
    //    {

    //        HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
    //        strtheme = aCookie.Values["Theme"].ToString();
    //        setCookies("Larger", strtheme);
    //        HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
    //        //Response.Redirect(Request.Url.ToString());
    //    }
    //    else
    //    {

    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

    //        //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
    //    }
    //}

    protected void ibtnIncreaseFont_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {

            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            strtheme = aCookie.Values["Theme"].ToString();
            setCookies("Larger", strtheme);
            HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            //Response.Redirect(Request.Url.ToString());
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "javascript:alert('Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality ! ');", true);

            //lblCookiestxt.Text = "<br/>Cookies is currently not supported/disabled by this browser. Please enable Cookies for full functionality";
        }
    }
    public void setCookies(string textSize, string theme)
    {
        HttpCookie aCookie = new HttpCookie("CRCL_Accessibility");
        aCookie.Values["textSize"] = textSize;
        if (theme != "")
        {
            aCookie.Values["Theme"] = theme;
        }
        else
        {

            if (theme == "")
            {
                theme = "Default";
            }
            aCookie.Values["Theme"] = theme;
        }
        aCookie.Expires = DateTime.Now.AddDays(365);
        Response.Cookies.Add(aCookie);
    }

    public void SetCSS(string txtSize)
    {
        //SET TEXT SIZE

        string strtxtSize = "100%";
        switch (txtSize)
        {
            case "Larger":
                strtxtSize = "102%";
                break;
            case "Normal":
                strtxtSize = "100%";
                break;
            case "Smaller":
                strtxtSize = "95%";
                break;

            default:
                txtSize = "Normal";
                strtxtSize = "100%";
                break;
        }
        if (Request.Cookies["CRCL_Accessibility"] != null)
        {
            string strtheme = "";
            HttpCookie aCookie = Request.Cookies["CRCL_Accessibility"];
            if (aCookie.Values["Theme"] != null)
            {
                strtheme = aCookie.Values["Theme"].ToString();
            }
            else
            {
                strtheme = "";
            }


            //string s = "";
            //if ((Resources.WPC_Resource.Lang_Id) == "2")
            //{
            //    s = "hin";

            //}
            setCookies(txtSize, strtheme);


            //switch (strtheme)
            //{

            //    case "Green": imgLogoo.Attributes.Add("src", "~/App_Themes/Green/images/logo" + s + ".png");
            //        break;

            //    case "Orange": imgLogoo.Attributes.Add("src", "~/App_Themes/Orange/images/logo" + s + ".png");
            //        break;

            //    case "HighContrast": imgLogoo.Attributes.Add("src", "~/App_Themes/HighContrast/images/logo" + s + ".png");
            //        break;
            //    default: imgLogoo.Attributes.Add("src", "~/App_Themes/Default/images/logo" + s + ".png");
            //        break;

            //}


        }
        else
        {
            setCookies(txtSize, "");
        }

        Page.Header.Controls.Add(new LiteralControl("<style type=\"text/css\" media=\"screen\">" + Environment.NewLine.ToString() + " html, body{" + Environment.NewLine.ToString() + "" + Environment.NewLine.ToString() + "font-size:" + strtxtSize + ";" + Environment.NewLine.ToString() + "}" + Environment.NewLine.ToString() + "</style>"));
    }
}