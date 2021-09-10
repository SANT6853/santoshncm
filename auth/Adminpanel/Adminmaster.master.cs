using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_Adminmaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Home.aspx");
        }

        MyCustomPrincipal m = new MyCustomPrincipal(HttpContext.Current.User.Identity.Name);
        m = (MyCustomPrincipal)HttpContext.Current.User;
        lbllogedinusername.Text = m.UserName;
        //  lifundrequest.Visible = m.UserType == 3;Session["SMapDistrictName"]
        //Session["UserType"]!= null
        if (!string.IsNullOrWhiteSpace(Session["UserType"] as string))
        {
            if (Session["UserType"].ToString() == "4")
            {
                LblReserName.Visible = true;
                LblReserName.Text = Session["sTigerReserveName"].ToString();
                LblState.Visible = true;
                LblState.Text = Session["Sstatename"].ToString();
                liCreatUser.Visible = false;
                liAddContent.Visible = false;
              //  liAddBanner.Visible = false;
                liMiddleContent.Visible = false;
               // lithumnail.Visible = false;
                lifeedback.Visible = false;
                liPageContent.Visible = false;
                liTigerReserve.Visible = false;
                liPhotoGallery.Visible = false;
                spDsitrictName.Visible = true;
                LblDistictName.Text = Session["SMapDistrictName"].ToString();
                // liMasterManagment.Visible = false;

            }
            if (Session["UserType"].ToString() == "1")
            {
                liTigerReserve.Visible = true;
            }
            else
            {
                liTigerReserve.Visible = false;
            }
        }
        else
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"));

        }
        

    }
}
