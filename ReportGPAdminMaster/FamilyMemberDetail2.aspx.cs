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

public partial class ReportGP_FamilyMemberDetail2 : System.Web.UI.Page
{
    FamilyDB FDB = new FamilyDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "FAMILY MEMBER REPORT : SARISKA TIGER RESERVE";
        //if (Session["LoginID"] == null || Session["LoginID"].ToString() == "")
        //{
        //    Response.Redirect(ResolveUrl("~/AUTH/TIGERRESERVEADMIN/User_Login.aspx"), true);
        //}

        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {

                if (Request.QueryString["id"].ToString() != "")
                {

                    DisplayMemberDetail();
                }
            }

        }

    }
    public void GridveiwNumericColumnCalculationOptionWise(DataSet ds)
    {
        string Total = "Total=";
        int sno = 0;
        decimal AllottedAmountRs = 0;
        //  decimal InstallmentAmountRs = 0;
        //int FamilyMember = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            sno = ds.Tables[0].Rows.Count;
            AllottedAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["FMLY_MEMB_ANUL_INCM"]);
            //InstallmentAmountRs += Convert.ToDecimal(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
            // FamilyMember += Convert.ToInt32(ds.Tables[0].Rows[i]["FMLY_NO_MEMB"]);
        }
        //sno
        gv_FamilyMemberDetail.FooterRow.Cells[0].Text = "Total rows=" + sno.ToString();
        gv_FamilyMemberDetail.FooterRow.Cells[0].Font.Bold = true;
        gv_FamilyMemberDetail.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilyMemberDetail.FooterRow.BackColor = System.Drawing.Color.Beige;
        //AllottedAmountRs
        gv_FamilyMemberDetail.FooterRow.Cells[5].Text = Total + AllottedAmountRs.ToString();
        gv_FamilyMemberDetail.FooterRow.Cells[5].Font.Bold = true;
        gv_FamilyMemberDetail.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Center;
        gv_FamilyMemberDetail.FooterRow.BackColor = System.Drawing.Color.Beige;
        //InstallmentAmountRs
        //gv_FamilySearch.FooterRow.Cells[7].Text = Total + InstallmentAmountRs.ToString();
        //gv_FamilySearch.FooterRow.Cells[7].Font.Bold = true;
        //gv_FamilySearch.FooterRow.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        //gv_FamilySearch.FooterRow.BackColor = System.Drawing.Color.Beige;
        ////FamilyMember

    }
    public void DisplayMemberDetail()
    {
        DataSet ds = FDB.Proc_DisplayFamilyMemberDetail(Request.QueryString["id"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            btn_print.Visible = true;
            gv_FamilyMemberDetail.Visible = true;
            lblnodatafound.Text = "";
            gv_FamilyMemberDetail.DataSource = ds.Tables[0].DefaultView;
            ViewState["Data"] = ds;
            gv_FamilyMemberDetail.DataBind();
            GridveiwNumericColumnCalculationOptionWise(ds);

        }
        else
        {
            btn_print.Visible = false;
            gv_FamilyMemberDetail.Visible = false;
            lblnodatafound.Text = "No Record Found";

        }


    }
    protected void gv_FamilyMemberDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_FamilyMemberDetail.PageIndex = e.NewPageIndex;
        DisplayMemberDetail();
    }
    //protected void btn_print_Click(object sender, EventArgs e)
    //{
    //    btn_print.Attributes.Add("Onclick", "getPrint('print_area');");
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        string vid = Request.QueryString["V_ID"].ToString();
        Response.Redirect("FamilyDetail2.aspx?V_ID=" + vid);
    }




    void printGrid()
    {
        // GridView GridView1 = new GridView();
        gv_FamilyMemberDetail.DataSource = ViewState["Data"];
        gv_FamilyMemberDetail.AllowPaging = false;
        gv_FamilyMemberDetail.DataBind();
        //Footer rows record sum
        DataSet Ds = (DataSet)ViewState["Data"];
        GridveiwNumericColumnCalculationOptionWise(Ds);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        gv_FamilyMemberDetail.RenderControl(hw);
        string gridHTML = sw.ToString().Replace("\"", "'")
            .Replace(System.Environment.NewLine, "");
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload = new function(){");
        sb.Append("var printWin = window.open('', '', 'left=0");
        sb.Append(",top=0,width=1000,height=600,status=0');");
        sb.Append("printWin.document.write(\"");
        sb.Append("<font size=5px align=center> ");
        sb.Append("Family Wise Memeber Detail");
        sb.Append("</font> ");
        sb.Append(gridHTML);
        sb.Append("\");");
        sb.Append("printWin.document.close();");
        sb.Append("printWin.focus();");
        sb.Append("printWin.print();");
        sb.Append("printWin.close();};");
        sb.Append("</script>");
        ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        gv_FamilyMemberDetail.AllowPaging = true;
        gv_FamilyMemberDetail.DataBind();
    }

    protected void btn_print_Click1(object sender, EventArgs e)
    {
        this.printGrid();
        if (Request.QueryString["id"] != null)
        {

            if (Request.QueryString["id"].ToString() != "")
            {

                DisplayMemberDetail();
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET      
         * server control at run time. */

    }  
}