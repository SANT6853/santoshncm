using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class auth_Adminpanel_upload_file_imege_manegement : System.Web.UI.Page
{
    Dal_upload_file dal = new Dal_upload_file();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["User_Id"] == null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"), true);

        }
        if (!IsPostBack)
        {
            if (Session["UserType"].ToString().Equals("1"))
            {
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
                ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
                btnadd.Visible = true;
                BindStateName();
                filldropedownvillage1();
                BindGrid();

            }
            if (Session["UserType"].ToString().Equals("2"))
            {
                btnadd.Visible = false;
               // filldropedownvillage2();
                BindTigerReserveName2();
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
                BindGrid();
            }
            if (Session["UserType"].ToString().Equals("3"))
            {
                btnadd.Visible = false;
               // filldropedownvillage3();
                BindTigerReserveName2();
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
                BindGrid();
            }
            if (Session["UserType"].ToString().Equals("4"))
            {

                //filldropedownvillage();
                BindTigerReserveName2();
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
                BindGrid();
            }
        }

    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("Uploadreletedfile.aspx?id="+ddlvillage.SelectedValue));
    }
    protected void gvVillagesRelatedfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        gvVillagesRelatedfile.PageIndex = e.NewPageIndex;
        BindGrid();


    }
    protected void gvVillagesRelatedfile_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvVillagesRelatedfile_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvVillagesRelatedfile_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        {
            if (e.CommandName == "Edit")
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                Response.Redirect("uploadfileedit.aspx?id=" + id);
            }

            if (e.CommandName == "Delete")
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                string i = dal.delete_file(id);

                BindGrid();
                if ((!string.IsNullOrEmpty(i)))
                {
                    lblmsg.Text = "Record Deleted successfuly";
                    lblmsg.ForeColor = System.Drawing.Color.Green;
                    System.IO.FileInfo fileinfo = new System.IO.FileInfo(Server.MapPath(@"~\WriteReadData\UserFiles\" + i));
                    if (fileinfo.Exists)
                    {
                        fileinfo.Delete();
                    }
                }
            }
        }

    }
   
    public void filldropedownvillage()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.Proc_Get_All_Villages(Convert.ToInt32(Session["User_Id"]));
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldropedownvillage3()
    {
        ddlvillage.Items.Clear();
        DataTable dt = NgoDal.Proc_Get_All_Villages3(Convert.ToInt32(Session["User_Id"]));
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldropedownvillage2()
    {
        ddlvillage.Items.Clear();
        ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        int Tiger = Convert.ToInt32(ddlselectreserve.SelectedValue);
        DataTable dt = NgoDal.Get_All_Villages2(Tiger);
        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    public void filldropedownvillage1()
    
    {
        ddlvillage.Items.Clear();
        ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        int TigerReserve = Convert.ToInt32(ddlselectreserve.SelectedValue);
        DataTable dt = NgoDal.Get_Villages(TigerReserve);

        if (dt.Rows.Count > 0)
        {
            ddlvillage.DataSource = dt;
            ddlvillage.DataTextField = "VILL_NM";
            ddlvillage.DataValueField = "VILL_ID";
            ddlvillage.DataBind();
            ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    protected void ddlvillage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReserveName();
    }
    protected void ddlselectreserve_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        if (Convert.ToInt32(Session["User_Id"]) != 1)
        {
            filldropedownvillage2();
        }
        else
        {
            filldropedownvillage1();
        }
    }

    void BindTigerReserveName()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            int StateID=Convert.ToInt32(DdlStateName.SelectedValue);
            DataSet ds = new VillageDB().BindTigerReservefile(StateID);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
            }



            else
            {
                ddlselectreserve.Items.Clear();
                ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            }
        }
        catch (Exception er)
        {
        }
    }
    void BindStateName()
    {
        Project_Variables P_var = new Project_Variables();
        Commanfuction _commanfuction = new Commanfuction();
        NtcaUserOB _objNtcauser = new NtcaUserOB();
        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        // P_var.dSet = _commanfuction.BindDdlStateBarChart(_objNtcauser);
        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);
        //if (P_var.dSet.Tables[3].Rows.Count > 0)
        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            DdlStateName.DataSource = P_var.dSet.Tables[0];
            DdlStateName.DataTextField = "StateName";
            DdlStateName.DataValueField = "id";
            DdlStateName.DataBind();
            DdlStateName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }
    }
    void BindTigerReserveName2()
    {
        try
        {
            ddlselectreserve.Items.Clear();
            ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));  //
            int stateid = Convert.ToInt32(Session["ntca_StateID"]);
            DataSet ds = new VillageDB().BindTigerReserves(Convert.ToInt32(Session["User_Id"]), stateid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Session["UserType"].ToString().Equals("2"))
                {
                ddlselectreserve.DataSource = ds.Tables[1];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
                }
                else
                {
                    ddlselectreserve.DataSource = ds.Tables[0];
                ddlselectreserve.DataTextField = "TigerReserveName";
                ddlselectreserve.DataValueField = "TigerReserveid";
                ddlselectreserve.DataBind();

                ddlselectreserve.Items.Insert(0, new ListItem("-Select-", "0"));
                }
                
            }



            else
            {
                ddlselectreserve.Items.Clear();
                ddlselectreserve.Items.Add(new ListItem("-Select-", "0"));
            }
        }
        catch (Exception er)
        {
        }
    }
    public void BindGrid()
    {
        try
        {
            
                int vid = Int32.Parse(ddlvillage.SelectedValue);
                DataSet ds = dal.show_imeges(vid, null, null);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvVillagesRelatedfile.DataSource = ds;
                    gvVillagesRelatedfile.DataBind();
                }
                else
                {
                    gvVillagesRelatedfile.DataSource = null;
                    gvVillagesRelatedfile.DataBind();
                }
            
        }
        catch (Exception er)
        {
            throw;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void gvVillagesRelatedfile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Literal ltl = e.Row.FindControl("ltlViewLetter") as Literal;
            //HiddenField hydfile = e.Row.FindControl("hydfile") as HiddenField;
            //int vid = Int32.Parse(ddlvillage.SelectedValue);
            //DataSet ds = dal.show_imeges(vid, null, null);
            //if (hydfile.Value!="")
            //{
            //    ltl.Text = "<a  target='_blank' href='<%#ResolveUrl("~/WriteReadData/UserFiles/")%> + hydfile.Value.ToString()  + "'>View</a>";
            //}
            
           
        }
    }
}