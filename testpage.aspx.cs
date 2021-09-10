using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class testpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //public void BindGrid(int statusid)
    //{
    //    try
    //    {
    //        if (ddlStatus.SelectedValue == "0")
    //        {
    //            grdBanner.Visible = false;

    //        }
    //        else
    //        {
    //            grdBanner.Visible = true;
    //            //contentObject.LangId = langid;
    //            contentObject.TigerReserveid = Convert.ToInt16(ddlTigerReserve.SelectedValue);
    //            contentObject.StateID = Convert.ToInt16(ddlState.SelectedValue);
    //            contentObject.StatusID = statusid;
    //            contentObject.ModuleID = (int)Module_ID_Enum.Project_Module_ID.MiddleContent;
    //            contentObject.Websiteid = Convert.ToInt32(ddlwebsite.SelectedValue);
    //            p_Var.dsFileName = MiddleContentBL.GetMiddleContentData(contentObject);
    //            if (p_Var.dsFileName.Tables[0].Rows.Count > 0)
    //            {
    //                divGrid.Visible = true;
    //                grdBanner.DataSource = p_Var.dsFileName;
    //                grdBanner.DataBind();
    //                p_Var.dSet = null;


    //                p_Var.dSet = null;
    //                // lblmsg.Visible = false;

    //            }
    //            else
    //            {
    //                divGrid.Visible = false;
    //            }
    //        }
    //    }


    //    catch
    //    {
    //        throw;
    //    }
    //}
}