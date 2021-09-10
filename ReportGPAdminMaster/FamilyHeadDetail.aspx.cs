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

public partial class ReportGP_FamilyHeadDetail : System.Web.UI.Page
{
    FamilyDB FDB = new FamilyDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = "FAMILY HEAD DETAIL REPORT : NTCA";
        //if (Session["User_Id"] == null || Session["User_Id"].ToString() == "")
        //{
        //    Response.Redirect(ResolveUrl("~/Home.aspx"), true);
        //}

        if (!IsPostBack)
        {
            if (Request.QueryString["F_ID"] != null)
            {

                if (Request.QueryString["F_ID"].ToString() != "")
                {

                    DisplayHeadDetail();
                }
            }

        }

    }
    public void DisplayHeadDetail()
    {
        DataSet ds = FDB.Proc_DisplayHeadDetail(Request.QueryString["F_ID"].ToString());
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnPrint.Visible = true;
            lblname.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_NM"].ToString();



            lblage.Text = ds.Tables[0].Rows[0][1].ToString();
            lblfathername.Text = ds.Tables[0].Rows[0][2].ToString();
            string sex = ds.Tables[0].Rows[0][5].ToString();
            if (sex == "1")
            {
                lblsex.Text = "Male";
            }
            else
            {
                lblsex.Text = "Female";
            }

            string cast = ds.Tables[0].Rows[0][7].ToString();
            if (cast == "1")
            {
                lblcast.Text = "OBC";
            }
            else if (cast == "2")
            {
                lblcast.Text = "SC";
            }
            else if (cast == "3")
            {
                lblcast.Text = "ST";
            }
            else
            {
                lblcast.Text = "OTHER";
            }

            lblcardname.Text = ds.Tables[0].Rows[0]["FMLY_MEMB_ID_NAME"].ToString();
            lblvoter.Text = ds.Tables[0].Rows[0][8].ToString();
            if (ds.Tables[0].Rows[0][9].ToString().Equals("0"))
            {
                lblcontact.Text = "";
            }
            else
            {
                lblcontact.Text = ds.Tables[0].Rows[0][9].ToString();

            }
            lbledu.Text = ds.Tables[0].Rows[0][6].ToString();
            lbloccu.Text = ds.Tables[0].Rows[0][3].ToString();

            lblincome.Text = ds.Tables[0].Rows[0][4].ToString();


        }
        else
        {
            btnPrint.Visible = false;
        }


    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Session["ctrl"] = panel1;
        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=600px,scrollbars=1');</script>");
    }
}