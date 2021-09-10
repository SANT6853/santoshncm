using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class PhotoGallery : System.Web.UI.Page
{
    #region Data declaration zone

    Project_Variables p_var = new Project_Variables();
    PhotoGalleryBL obj_galleryBL = new PhotoGalleryBL();
    PhotoGalleryOB obj_galleryOB=new PhotoGalleryOB();
    PaginationBL pagingBL = new PaginationBL();


    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CategoryID"] != null)
            {
                Bind_Image(1);
            }

        }
    }

    #region function to display image of category
    void Bind_Image(int pageIndex)
    {
        StringBuilder strbimage = new StringBuilder();

        obj_galleryOB.StateID = 5;
        obj_galleryOB.TigerReserveID = 9;
        obj_galleryOB.PageIndex = pageIndex;
        obj_galleryOB.PageSize = Convert.ToInt32(10);
        obj_galleryOB.CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"].ToString());//for main site
        p_var.dSet = obj_galleryBL.Get_PhotoGalleryImage(obj_galleryOB, out p_var.k);

        for (int i = 0; i < p_var.dSet.Tables[0].Rows.Count; i++)
        {
            strbimage.Append(" <li class=\"col-xs-6 col-sm-4 col-md-3\" data-src='"+ ResolveUrl("~/") + "WriteReadData/PhotoGallery/Images/" + p_var.dSet.Tables[0].Rows[i]["ImageName"].ToString() + "'>");

            strbimage.Append("<a href=\"\">");
            strbimage.Append("<img Title='" + p_var.dSet.Tables[0].Rows[i]["Title"].ToString() + "' alt=" + p_var.dSet.Tables[0].Rows[i]["AltTag"].ToString() + " src='" + ResolveUrl("~/") + "WriteReadData/PhotoGallery/ThumbnailImages/" + p_var.dSet.Tables[0].Rows[i]["ImageName"].ToString() + "'>");
            //strbimage.Append("<h4>");
            //strbimage.Append(p_var.dSet.Tables[0].Rows[i]["Title"].ToString());
            //strbimage.Append("</h4>");
            strbimage.Append("</a>");
            strbimage.Append("</li>");

        }
        //p_var.Result = p_var.k;
        //if (p_var.Result > Convert.ToInt16(ddlPageSize.SelectedValue))
        //{
        //    pagingBL.Paging_Show(p_var.Result, pageIndex, ddlPageSize, rptPager);
        //}
        //else
        //{
        //    rptPager.Visible = false;
        //}
        ltrlgalleryname.Text = strbimage.ToString();
    }

    #endregion
}