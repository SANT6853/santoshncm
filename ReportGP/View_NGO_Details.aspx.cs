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

public partial class ReportGP_View_NGO_Details : System.Web.UI.Page
{
    NgoDB ngo = new NgoDB();


    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "NGO REPORT :NTCA";
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
                    BindNGOById();

                }
            }

        }

    }


    protected void btn_print_Click(object sender, EventArgs e)
    {
        this.printGrid();
        //btn_print.Attributes.Add("Onclick", "getPrint('print_area');");
        //Session["ctrl"] = Panel1;

        //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=600px,scrollbars=1');</script>"); 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/ReportGP/VillageSearch.aspx"), false);
    }

    public void BindNGOById()
    {
        DataSet ds = new DataSet();
        try
        {

            ds = ngo.Proc_DisplayNGODetail(Request.QueryString["V_ID"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvforVillages.Visible = true;
                gvforVillages.DataSource = ds;
                ViewState["Data"] = ds;
                gvforVillages.DataBind();
                Button2.Visible = true;
            }
            else
            {
                Button2.Visible = false;
                gvforVillages.Visible = false;
                lblMsg.Text = WebConstant.UserFriendlyMessages.NoRecordFound;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }
    }
    protected void gvforVillages_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvforVillages.PageIndex = e.NewPageIndex;
            BindNGOById();

        }
        catch (Exception e1)
        {
            lblMsg.Text = WebConstant.UserFriendlyMessages.ExceptionError;//+ e1.Message.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;

        }

    }
    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gvforVillages.DataSource = ViewState["Data"];
        gvforVillages.AllowPaging = false;
        gvforVillages.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gvforVillages.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<div style='text-align:center'><font size=5px > ");
        sb.Append(" Total NGO Report for a Village ");
        sb.Append("</font></div>");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gvforVillages.AllowPaging = true;
        gvforVillages.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }
}