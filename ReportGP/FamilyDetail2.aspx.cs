using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;

public partial class ReportGP_FamilyDetail2 : System.Web.UI.Page
{
    VillageDB vdb = new VillageDB();
    CommonDB COMMDB_Obj = new CommonDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "FAMILY DETAILS REPORT : NTCA";
        //if (Session["User_Id"] == null || Session["User_Id"].ToString() == "")
        //{
        //    Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        //}

        if (!IsPostBack)
        {
            if (Request.QueryString["V_ID"] != null)
            {
                if (Request.QueryString["V_ID"].ToString() != "")
                {
                    FillAll();
                    displayFamily();
                }
            }

        }

    }
    public void FillAll()
    {
        DataSet ds = vdb.Get_OthersIDs_By_VillId(Request.QueryString["V_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblvillcode.Text = ds.Tables[0].Rows[0][0].ToString();
            lblvillname.Text = ds.Tables[0].Rows[0][1].ToString();
            DataSet ds1 = COMMDB_Obj.Display_State_District_Reserve_Tehsil_Grampanchayat_Name_By_IDs(ds.Tables[0].Rows[0]["CmnStateID"].ToString(), ds.Tables[0].Rows[0]["DT_ID"].ToString(), ds.Tables[0].Rows[0]["CmnDataOperatorTigerReserveID"].ToString(), ds.Tables[0].Rows[0]["TH_ID"].ToString(), ds.Tables[0].Rows[0]["GP_ID"].ToString());
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblstatename.Text = ds1.Tables[0].Rows[0]["ST_NAME"].ToString();
                lbldistrict.Text = ds1.Tables[1].Rows[0]["DT_NAME"].ToString();
              
                lbltehsil.Text = ds1.Tables[2].Rows[0]["TH_NAME"].ToString();
                lblgp.Text = ds1.Tables[3].Rows[0]["GP_NAME"].ToString();
                lblreaserve.Text = ds1.Tables[4].Rows[0]["TigerReserveName"].ToString();



            }

        }
    }
    public void displayFamily()
    {

        DataSet ds = vdb.Proc_DisplayFamilyByVillage(Request.QueryString["V_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_FamilySearch.Visible = true;
            btn_print.Visible = true;
            lblnodatafound.Text = "";
            gv_FamilySearch.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_FamilySearch.DataBind();

        }
        else
        {
            btn_print.Visible = false;

            gv_FamilySearch.Visible = false;
            lblnodatafound.Text = "No Record Found";

        }



    }
    protected void gv_FamilySearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_FamilySearch.PageIndex = e.NewPageIndex;
        displayFamily();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/ReportGP/VillageSearch.aspx?"));
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {

    }



    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gv_FamilySearch.DataSource = ViewState["Data"];
        gv_FamilySearch.AllowPaging = false;
        gv_FamilySearch.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gv_FamilySearch.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");

        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append("Village Relocation Family Data ");
        sb.Append("</font></div>");
        sb.Append("<div>");
        sb.Append("-------------------------------------------------------------------------------------------------------------------");
        sb.Append("-----------------------------------------------");
        sb.Append("</div>");
        sb.Append("<div>");

        //sb.Append("<ul>");
        //sb.Append("<li>");
        sb.Append("State :&nbsp;" + lblstatename.Text);
        //sb.Append("</li>");
        //sb.Append("<li>");
        sb.Append("&nbsp; | &nbsp; Reserve :&nbsp;" + lblreaserve.Text);
        sb.Append("&nbsp;  | &nbsp;District :&nbsp;" + lblreaserve.Text);
        sb.Append("&nbsp;  | &nbsp;Tehsil :&nbsp;" + lbltehsil.Text);
        sb.Append("&nbsp;  | &nbsp;Grampanchayat :&nbsp;" + lblgp.Text);
        sb.Append("&nbsp;  | &nbsp;Village :&nbsp;" + lblvillname.Text);
        sb.Append("&nbsp;  | &nbsp;Village Code :&nbsp;" + lblvillcode.Text);
        //sb.Append("</li>");
        //sb.Append("</ul>");

        sb.Append("</div>");
        sb.Append("<div>");
        sb.Append("-------------------------------------------------------------------------------------------------------------------");
        sb.Append("-----------------------------------------------");
        sb.Append("</div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();weindow.reload();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gv_FamilySearch.AllowPaging = true;
        gv_FamilySearch.DataBind();
    }

    protected void btn_print_Click1(object sender, EventArgs e)
    {
        this.printGrid();

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
    protected void gv_FamilySearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HyperLink hyper = e.Row.FindControl("HyperLink1") as HyperLink;
            if (hyper.Text.Equals("0"))
            {
                hyper.NavigateUrl = "#";
                hyper.Attributes.Add("target", "");

                hyper.Text = "No Record";
            }
        }
    }
}