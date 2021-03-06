using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class auth_Adminpanel_CDPManagement_ViewCDP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displayVillageName();
            displayVillageInGrid();
        }
    }

    #region Function to village name in dropdown list

    private void displayVillageName()
    {
        Project_Variables p_Var = new Project_Variables();
        VillageOB villObject = new VillageOB();
        Commanfuction commonBL = new Commanfuction();
        villObject.TigerReserveid = Convert.ToInt16(9);
        villObject.villageID = null;
        p_Var.dSet = commonBL.getVillageName(villObject);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            ddlVillagee.DataSource = p_Var.dSet;
            ddlVillagee.DataTextField = "Village_Name";
            ddlVillagee.DataValueField = "TempVillageid";
            ddlVillagee.DataBind();
            ddlVillagee.Items.Insert(0, new ListItem("Select Village", "0"));
        }
    }


    #endregion

    #region Function to village name in dropdown list

    private void displayVillageInGrid()
    {
        Project_Variables p_Var = new Project_Variables();
        VillageOB villObject = new VillageOB();
        Commanfuction commonBL = new Commanfuction();
        villObject.TigerReserveid = Convert.ToInt16(9);
        if (Convert.ToInt16(ddlVillagee.SelectedValue) != 0)
        {
            villObject.villageID = Convert.ToInt16(ddlVillagee.SelectedValue);
        }
        else
        {
            villObject.villageID = null;
        }
    
        p_Var.dSet = commonBL.getVillageName(villObject);
        if (p_Var.dSet.Tables[0].Rows.Count > 0)
        {
            divGrid.Visible = true;
            gvforVillages.DataSource = p_Var.dSet;
            gvforVillages.DataBind();
        }
    }


    #endregion

    protected void ddlVillagee_SelectedIndexChanged(object sender, EventArgs e)
    {
        displayVillageInGrid();
    }



    protected void gvforVillages_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if (Page.IsValid)
     //  {
           try
           {

               string hdnblank = ((HiddenField)this.Master.FindControl("hdnblank")).Value;
               string CurrentSessionId = Convert.ToString(Session["AntiForgeryToken"]);
               if (Session["CurrentRequestUrl"] != null && Convert.ToString(Session["CurrentRequestUrl"]).Equals(Convert.ToString(Request.ServerVariables["HTTP_REFERER"])))
               {
                   if (CurrentSessionId == hdnblank)
                   {

                       if (Page.IsValid)
                       {

                           if (e.CommandName == "Add")
                           {
                               //if (btnviewcurrent.Visible == false && imgbtnviewall.Visible == false)
                               //{
                               Response.Redirect(ResolveUrl("~/Auth/AdminPanel/CDPManagement/AddCDP.aspx?village=" + e.CommandArgument.ToString()));

                               //}
                               //else
                               //{
                               //    if (btnviewcurrent.Visible == true)
                               //    {
                               //        Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/CDP/CDP_Add.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&viewid=2"), false);
                               //    }
                               //    else
                               //    {
                               //        Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/CDP/CDP_Add.aspx?" + WebConstant.QueryStringEnum.VillageID + "=" + e.CommandArgument.ToString() + "&inid=" + ViewState["indexpage"].ToString() + "&vid=" + ddlselectname.SelectedValue.ToString() + "&viewid=1"), false);
                               //    }
                           }
                       }
                   }
               }
          }
           catch
           {
               throw;
           }
           

     //  }

    
    }

    protected void gvforVillages_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Commanfuction commonBL = new Commanfuction();
        foreach (GridViewRow row in gvforVillages.Rows)
        {
            string t = row.Cells[3].Text;
            string villid = gvforVillages.DataKeys[row.RowIndex].Value.ToString();
            DataSet ds = commonBL.CheckCDP_details(villid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString().Equals("1"))
                {

                    ImageButton ib = (ImageButton)row.FindControl("ibEdit");
                    ib.Visible = true;

                }
                else if (ds.Tables[0].Rows[0][0].ToString().Equals("0"))
                {
                    ImageButton ib = (ImageButton)row.FindControl("ibAdd");
                    ib.Visible = true;
                }
            }
        }
    }
}