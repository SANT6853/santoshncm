using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_REPORT_surveyreport :CrsfBase
{
    ReportBL reportbl = new ReportBL();
    Project_Variables p_Val = new Project_Variables();
    Project_Variables P_var = new Project_Variables();
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    public static int Search = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["User_Id"]== null)
        {
            Response.Redirect(ResolveUrl("~/Home.aspx"));
        }

        if (!IsPostBack)
        {
            BindDdlCheckboxIntoStateName();
            bindGrid();

            if (Session["UserType"].ToString().Equals("2"))
            {
                rolsupertiger.Visible = true;
                string stateid = Session["PermissionState"].ToString();
                BindTigerReserveOnBasisStateID(stateid);
            }
        }
        if (Session["User_Id"].ToString() == "1")
        {
            rolsuper.Visible = true;
            rolsupertiger.Visible = true;
        }
        
    }

    private void bindGrid()
    {

        if (LblMsgStateValue.Text == "You have not selected.")
        {
            if (Session["User_Id"].ToString() == "1")
            {
                _objNtcauser.StateIDParameters = null;
            }
            //else
            //{
            //    _objNtcauser.StateIDParameters = Session["sStateID"].ToString();
            //}
           
        }
        else
        {
            _objNtcauser.StateIDParameters = LblMsgStateValue.Text.Trim();
        }
        if (LblMsgTigerReserveValue.Text == "You have not selected.")
        {
            if (Session["User_Id"].ToString() == "1")
            {
                _objNtcauser.TigerReseveIDParameters = null;
            }
            //else
            //{
            //    _objNtcauser.TigerReseveIDParameters = Session["sTigerReserveid"].ToString();
            //}
        }
        else
        {
            _objNtcauser.TigerReseveIDParameters = LblMsgTigerReserveValue.Text.Trim();
        }
        _objNtcauser.UserID = Convert.ToInt32(HttpContext.Current.Session["User_Id"]);
        p_Val.dSet = reportbl.SurveyReport(_objNtcauser);
        GridView1.DataSource = p_Val.dSet;
        GridView1.DataBind();
        
    }

    public static void MergeRows(GridView gridView)
    {
        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];

            //for (int i = 0; i < row.Cells.Count; i++)
            for (int i = 0; i < 2; i++)
            {
                if (row.Cells[i].Text == previousRow.Cells[i].Text)
                {
                    row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                           previousRow.Cells[i].RowSpan + 1;
                    previousRow.Cells[i].Visible = false;
                }
            }
        }
    }
    protected void gridView_PreRender(object sender, EventArgs e)
    {
        MergeRows(GridView1);
    }



    private void ExportToExcel()
    {
        int index;
        if (ViewState["index"] == null)
        {
            index = 1;
        }
        else
        {
            index = Convert.ToInt32(ViewState["index"]);
        }
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            string sbhead = "<div style='text-align:center;margin-bottom:10px;'><h1>Survey Reports</h1></div>";
            hw.InnerWriter.Write(sbhead);
            //To Export all pages
            // grdRecommende.AllowPaging = false;
            //this.Bind_Recommend(index);
            bindGrid();
            GridView1.HeaderRow.BackColor = System.Drawing.Color.White;

            MergeRows(GridView1);
            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }



    protected void excl_Click(object sender, EventArgs e)
    {
          // if (Page.IsValid)
      // {

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


                        ExportToExcel();
                    }
                }
            }
        }
        catch
        {
            throw;
        }

        //}
    }  
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlStateName_SelectedIndexChangedMethod();

    }

    void DdlStateName_SelectedIndexChangedMethod()
    {
        LblMsgStateName.Text = string.Empty;
         LblMsgStateValue.Text = string.Empty;
        //----------------------------
        //  LblMsgTigerReserveName.Text = string.Empty;
        //  LblMsgTigerReserveValue.Text = string.Empty;
        //---------------------------------
        //  LblMsgVillageName.Text = string.Empty;
        // LblMsgVillageValue.Text = string.Empty;
        //---------------------------------
        string StateID = string.Empty;
        string StateName = string.Empty;

        List<String> StateID_list = new List<string>();
        List<String> StateName_list = new List<string>();

        foreach (System.Web.UI.WebControls.ListItem item in DdlStateName.Items)
        {
            if (item.Selected)
            {
                StateID_list.Add(item.Value);
                StateName_list.Add(item.Text);
            }

            StateID = String.Join(",", StateID_list.ToArray());
            StateName = String.Join(",", StateName_list.ToArray());
        }
        if (StateID == "")
        {
            DdlTigerReserve.Items.Clear();
            LblMsgTigerReserveName.Text = "You have not selected.";
            LblMsgTigerReserveValue.Text = "You have not selected.";
            StateID = null;
            LblMsgStateName.Text = "You have not selected.";
            LblMsgStateValue.Text = "You have not selected.";
            //  DdlTigerReserve_SelectedIndexChanged(this, EventArgs.Empty);
            //  DdlTigerReserve_SelectedIndexChangedMethod();
            BindTigerReserveOnBasisStateIDDDl(StateID);
        }
        else
        {
            // DdlTigerReserve.Items.Clear();
            LblMsgStateName.Text = String.Join(",", StateName_list.ToArray());
            LblMsgStateValue.Text = String.Join(",", StateID_list.ToArray());
            // LblMsgTigerReserveName.Text = "";
            BindTigerReserveOnBasisStateID(StateID);
            //  DdlTigerReserve_SelectedIndexChanged(this, EventArgs.Empty);

            //ddlSponsor_SelectedIndexChanged(this, EventArgs.Empty);
            //  DdlTigerReserve_SelectedIndexChangedMethod();
            BindTigerReserveOnBasisStateIDDDl(StateID);
        }
        // BindVillageNameOnBasisTigerReserveIDDdl(ReserveID);
    }


    protected void DdlTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {

        DdlTigerReserve_SelectedIndexChangedMethod();
    }


    void DdlTigerReserve_SelectedIndexChangedMethod()
    {
        LblMsgTigerReserveName.Text = string.Empty;
        LblMsgTigerReserveValue.Text = string.Empty;
        string ReserveID = string.Empty;
        string ReserveName = string.Empty;

        List<String> ReserveID_list = new List<string>();
        List<String> ReserveName_list = new List<string>();

        foreach (System.Web.UI.WebControls.ListItem item in DdlTigerReserve.Items)
        {
            if (item.Selected)
            {
                ReserveID_list.Add(item.Value);
                ReserveName_list.Add(item.Text);
            }

            ReserveID = String.Join(",", ReserveID_list.ToArray());
            ReserveName = String.Join(",", ReserveName_list.ToArray());
        }
        if (ReserveID == "")
        {
           // DdlVillageName.Items.Clear();
            ReserveID = null;
          ///  LblMsgVillageName.Text = "You have not selected.";
          ///  LblMsgVillageValue.Text = "You have not selected.";
            LblMsgTigerReserveName.Text = "You have not selected.";
            LblMsgTigerReserveValue.Text = "You have not selected.";
            LblMsgTigerReserveName.Text = "You have not selected.";
            LblMsgTigerReserveValue.Text = "You have not selected.";
            //DdlVillageName_SelectedIndexChanged(this, EventArgs.Empty);
           
        }
        else
        {
            LblMsgTigerReserveName.Text = "";
            LblMsgTigerReserveValue.Text = "";
            LblMsgTigerReserveName.Text = String.Join(",", ReserveName_list.ToArray());
            LblMsgTigerReserveValue.Text = String.Join(",", ReserveID_list.ToArray());
           
            
            //  DdlVillageName_SelectedIndexChanged(this, EventArgs.Empty);
        }
    }

    void BindDdlCheckboxIntoStateName()
    {

        P_var.dSet = _commanfuction.GetStateName(_objNtcauser);

        if (P_var.dSet.Tables[0].Rows.Count > 0)
        {
            DdlStateName.DataSource = P_var.dSet.Tables[0];
            DdlStateName.DataTextField = "StateName";
            DdlStateName.DataValueField = "id";
            DdlStateName.DataBind();
            // DdlStateName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));
        }
    }

    void BindTigerReserveOnBasisStateIDDDl(string StateId)
    {
        //LblMsgTigerReserveName.Text = string.Empty;
        //LblMsgTigerReserveValue.Text = string.Empty;
        string ReserveID = string.Empty;
        string ReserveName = string.Empty;

        List<String> ReserveID_list = new List<string>();
        List<String> ReserveName_list = new List<string>();
        try
        {

            if (StateId != null)
            {
                //  DdlTigerReserve.Items.Clear();
                DataSet ds = new VillageDB().DsConsoldateBindTigerReserve(StateId);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        // string ss = ds.Tables[0].Rows[0]["TigerReserveName"].ToString();
                        // string ss = ds.Tables[0].Rows[0]["TigerReserveid"].ToString();
                        ReserveID_list.Add(ds.Tables[0].Rows[i]["TigerReserveid"].ToString());
                        ReserveName_list.Add(ds.Tables[0].Rows[i]["TigerReserveName"].ToString());

                        ReserveID = String.Join(",", ReserveID_list.ToArray());
                        ReserveName = String.Join(",", ReserveName_list.ToArray());
                    }
                    if (ReserveID != "")
                    {
                        if (LblMsgTigerReserveName.Text != "You have not selected.")
                        {
                            LblMsgTigerReserveName.Text = String.Join(",", ReserveName_list.ToArray());
                            LblMsgTigerReserveValue.Text = String.Join(",", ReserveID_list.ToArray());
                        }
                        
                    }

                }
                else
                {

                    //DdlTigerReserve.Items.Clear();
                    //ErrorChkTigerReserveName.Text = "--No Record Found--";
                    // ChkTigerReserveName.Items.Add(new System.Web.UI.WebControls.ListItem("--No Record--", "0"));
                }
            }
            else
            {
                StateId = null;
            }


        }
        catch (Exception er)
        {
        }
    }

    void BindTigerReserveOnBasisStateID(string StateId)
    {
        ErrorChkTigerReserveName.Text = "";
        try
        {

            if (StateId != null)
            {
                DdlTigerReserve.Items.Clear();
                DataSet ds = new VillageDB().DsConsoldateBindTigerReserve(StateId);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    DdlTigerReserve.DataSource = ds.Tables[0];
                    DdlTigerReserve.DataTextField = "TigerReserveName";
                    DdlTigerReserve.DataValueField = "TigerReserveid";
                    DdlTigerReserve.DataBind();

                    //ChkTigerReserveName.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-Select--", "0"));
                }
                else
                {

                    DdlTigerReserve.Items.Clear();
                    ErrorChkTigerReserveName.Text = "--No Record Found--";
                    // ChkTigerReserveName.Items.Add(new System.Web.UI.WebControls.ListItem("--No Record--", "0"));
                }
            }
            else
            {
                StateId = null;
            }


        }
        catch (Exception er)
        {
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        // if (Page.IsValid)
      // {

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

                        bindGrid();

                    }
                }
            }
        }
        catch
        {
            throw;
        }

        //}
    }  

    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
         // if (Page.IsValid)
      // {

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


                        Response.Redirect(ResolveUrl("~/auth/Adminpanel/REPORT/surveyreport.aspx"));
                    }
                }
            }
        }
        catch
        {
            throw;
        }

        //}
    }  

    

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bindGrid();
    }
}