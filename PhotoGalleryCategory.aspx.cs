using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class PhotoGalleryCategory : System.Web.UI.Page
{
    #region Data declaration zone

    PhotoGalleryBL photoCategoryBL=new PhotoGalleryBL();
    PhotoGalleryOB photoCategoryObject=new PhotoGalleryOB();
    Project_Variables p_Var = new Project_Variables();
    string imageThumbnailUrl = ConfigurationManager.AppSettings["WriteReadData"].ToString() + "/" + ConfigurationManager.AppSettings["PhotoGallery"].ToString() + "/" + ConfigurationManager.AppSettings["ThumbnailImages"].ToString() + "/";

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DisplayPhotoCategory(5, 9);
        }
    }

    #region Function to display all photo category

    public void DisplayPhotoCategory(int StateID, int TigerReserveID)
    {
        photoCategoryObject.StateID = StateID;
        photoCategoryObject.TigerReserveID = TigerReserveID;
        photoCategoryObject.LangID = Convert.ToInt16(Resources.NTCAResources.Lang_Id);
        p_Var.dSet = photoCategoryBL.GetPhotoCategoryFront(photoCategoryObject);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < p_Var.dSet.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == Convert.ToInt16(Module_ID_Enum.Language_ID.English))
                {
                    p_Var.sbuilder.Append("<a href=" + ResolveUrl("~/") + "PhotoGallery.aspx?CategoryID=" + p_Var.dSet.Tables[0].Rows[i]["CategoryId"] + ">");
                    p_Var.sbuilder.Append("<div class=\"col-md-3 cat_item\">");
                    p_Var.sbuilder.Append("<img class=\"img-responsive img-thumbnail\" src='" + ResolveUrl("~/") + imageThumbnailUrl + p_Var.dSet.Tables[0].Rows[i]["ImageName"].ToString() + "'>");
                    p_Var.sbuilder.Append("<h4>" + p_Var.dSet.Tables[0].Rows[i]["CatName"].ToString() + " </ h4 >");
                    p_Var.sbuilder.Append("</div>");
                    p_Var.sbuilder.Append("</a>");
                }
                else
                {
                    // sb.Append("<a href=" + ResolveUrl("~/") + "content/Hindi/Thumbnail/" + id + "_" + position + "_" + dSet.Tables[0].Rows[i]["MCategory_Id"] + "_" + dSet.Tables[0].Rows[i]["CAT_NAME"].ToString().Replace("&", "and").Replace("'", "").Replace(" ", "") + ".aspx" + "><span>");
                }
                //if (Convert.ToInt16(Resources.NTCAResources.Lang_Id) == Convert.ToInt16(Module_ID_Enum.Language_ID.English))
                //{
                //    //sb.Append("<img width=\"178\" height=\"115\" alt=" + dSet.Tables[0].Rows[i]["Alt_Tag"].ToString() + " src='" + ResolveUrl("~/") + imageUrl + dSet.Tables[0].Rows[i]["File_Name"].ToString() + "'>");
                //    //sb.Append(" </span>");
                //    //sb.Append("<div class=\"th_title\">");
                //    //sb.Append(dSet.Tables[0].Rows[i]["CAT_NAME"].ToString());
                //    //sb.Append("</div>");
                //    //sb.Append("</a>");
                //}
                //else
                //{
                //    //sb.Append("<img width=\"178\" height=\"115\" alt=" + dSet.Tables[0].Rows[i]["Alt_Tag_RegLng"].ToString() + " src='" + ResolveUrl("~/") + imageUrl + dSet.Tables[0].Rows[i]["File_Name"].ToString() + "'>");
                //    //sb.Append(" </span>");
                //    //sb.Append("<div class=\"th_title\">");
                //    //sb.Append(dSet.Tables[0].Rows[i]["Cat_Name_RegLng"].ToString());
                //    //sb.Append("</div>");
                //    //sb.Append("</a>");
                //}
            }
            ltrlImage.Text = p_Var.sbuilder.ToString();
        }
    }

    #endregion
}