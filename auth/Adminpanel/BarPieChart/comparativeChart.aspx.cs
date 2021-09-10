using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;  

public partial class auth_Adminpanel_BarPieChart_comparativeChart : CrsfBase
{
    Project_Variables P_var = new Project_Variables();
    Content_ManagementBL obj_ContentBl = new Content_ManagementBL();
    ContentOB objContentOB = new ContentOB();
    TigerReserveBL _tigerReserverBl = new TigerReserveBL();
    TigerReserveOB _TigerReserveOB = new TigerReserveOB();
    string LoginUserid;
    int LoginUsertype;
    Commanfuction _commanfuction = new Commanfuction();
    NtcaUserOB _objNtcauser = new NtcaUserOB();
    public static string HeaderTitle = string.Empty;
    StringBuilder str = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (!IsPostBack)
        {
            BindTigerReservename();
            BindBarChart();
           
        }
    }
    protected void ImgbtnSubmit_Click(object sender, EventArgs e)
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
                        if (DdTigerReserve.SelectedValue == "0" && DDlStatus.SelectedValue == "0")
                        {
                            BindBarChart();
          
                        }
                        if (DdTigerReserve.SelectedValue != "0" && DDlStatus.SelectedValue == "0")
                        {
                            BindBarChart();
            
                        }
       
                        if (DdTigerReserve.SelectedValue == "0" && DDlStatus.SelectedValue != "0")
                        {
                            Response.Write("<script>alert('Please select Tiger reserve name.!');</script>");
                            return;
                        }
                        else
                        {
                            if (DdTigerReserve.SelectedValue != "0" && DDlStatus.SelectedValue != "0")
                            {
                                if (DDlStatus.SelectedItem.Text == "Relocated")
                                {
                                    BindBarChartRelocated();
                    

                                }
                                if (DDlStatus.SelectedItem.Text == "Non-Relocated")
                                {
                                    BindBarChartNonRelocated();
                   
                                }
                                if (DDlStatus.SelectedItem.Text == "In-Progress")
                                {
                                    BindBarChartInProgress();
                   
                                }
                            }
                        }
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
    void BindTigerReservename()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        P_var.dSet = _commanfuction.BindBarChart(_objNtcauser);
        DdTigerReserve.DataSource = P_var.dSet.Tables[0];
        DdTigerReserve.DataTextField = "TigerReserveName";
        DdTigerReserve.DataValueField = "TigerReserveName";
        DdTigerReserve.DataBind();
        DdTigerReserve.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    void BindBarChart()
    {
        lt.Text = string.Empty;
        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }

        P_var.dSet = _commanfuction.BindBarChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[1];

        try
        {

             str.Append(@" <script type='text/javascript'>
              google.load('visualization', '1', {packages:['corechart']});
              google.setOnLoadCallback(drawChart);
              function drawChart() {
              var data = google.visualization.arrayToDataTable([['TigerReserveName', 'Relocated', 'Non-Relocated','In-Progress'],");

             int count = dt.Rows.Count - 1;
             for (int i = 0; i <= count; i++)
             {
                 if (count == i)
                 {
                     str.Append("['" + dt.Rows[i]["TigerReserveName"].ToString() + "'," + dt.Rows[i]["Relocated"].ToString() + "," + dt.Rows[i]["Non-Relocated"].ToString() + "," + dt.Rows[i]["In-Progress"].ToString() + "]");
                 }
                 else
                 {
                     str.Append("['" + dt.Rows[i]["TigerReserveName"].ToString() + "'," + dt.Rows[i]["Relocated"].ToString() + "," + dt.Rows[i]["Non-Relocated"].ToString() + "," + dt.Rows[i]["In-Progress"].ToString() + "],");
                 }
             }
             str.Append("]);");
             str.Append(" var options = { title: '', hAxis: {title: 'Tiger Reserve name',  titleTextStyle: {color: '#333'}}, vAxis: {minValue: 0} };");
             str.Append(" var chart = new google.visualization.AreaChart(document.getElementById('chart_div')); chart.draw(data, options); }");
             str.Append(" </script>");

             lt.Text = str.ToString();
        }
        catch
        {
        }
    }
    void BindBarChartRelocated()
    {
        lt.Text = string.Empty;
        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }

        _objNtcauser.sAction = "Relocated";
        P_var.dSet = _commanfuction.BindBarChartRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[0];

        try
        {

            str.Append(@" <script type='text/javascript'>
              google.load('visualization', '1', {packages:['corechart']});
              google.setOnLoadCallback(drawChart);
              function drawChart() {
              var data = google.visualization.arrayToDataTable([['TigerReserveName', 'Relocated'],");

            int count = dt.Rows.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                if (count == i)
                {
                    str.Append("['" + dt.Rows[i]["TigerReserveName"].ToString() + "'," + dt.Rows[i]["Relocated"].ToString() + "]");
                }
                else
                {
                    str.Append("['" + dt.Rows[i]["TigerReserveName"].ToString() + "'," + dt.Rows[i]["Relocated"].ToString() + "],");
                }
            }
            str.Append("]);");
            str.Append(" var options = { title: '', hAxis: {title: 'Tiger Reserve name',  titleTextStyle: {color: '#333'}}, vAxis: {minValue: 0} };");
            str.Append(" var chart = new google.visualization.AreaChart(document.getElementById('chart_div')); chart.draw(data, options); }");
            str.Append(" </script>");

            lt.Text = str.ToString();
        }
        catch
        {
        }
    }
    void BindBarChartNonRelocated()
    {
        lt.Text = string.Empty;

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }

        _objNtcauser.sAction = "Non-Relocated";
        P_var.dSet = _commanfuction.BindBarChartRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[0];

        try
        {

            str.Append(@" <script type='text/javascript'>
              google.load('visualization', '1', {packages:['corechart']});
              google.setOnLoadCallback(drawChart);
              function drawChart() {
              var data = google.visualization.arrayToDataTable([['TigerReserveName','Non-Relocated'],");

            int count = dt.Rows.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                if (count == i)
                {
                    str.Append("['" + dt.Rows[i]["TigerReserveName"].ToString() + "'," + dt.Rows[i]["Non-Relocated"].ToString() + "]");
                }
                else
                {
                    str.Append("['" + dt.Rows[i]["TigerReserveName"].ToString() + "'," + dt.Rows[i]["Non-Relocated"].ToString() + "],");
                }
            }
            str.Append("]);");
            str.Append(" var options = { title: '', hAxis: {title: 'Tiger Reserve name',  titleTextStyle: {color: '#333'}}, vAxis: {minValue: 0} };");
            str.Append(" var chart = new google.visualization.AreaChart(document.getElementById('chart_div')); chart.draw(data, options); }");
            str.Append(" </script>");

            lt.Text = str.ToString();
        }
        catch
        {
        }
    }
    void BindBarChartInProgress()
    {
        lt.Text = string.Empty;
        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }

        _objNtcauser.sAction = "In-Progress";
        P_var.dSet = _commanfuction.BindBarChartRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[0];

        try
        {

            str.Append(@" <script type='text/javascript'>
              google.load('visualization', '1', {packages:['corechart']});
              google.setOnLoadCallback(drawChart);
              function drawChart() {
              var data = google.visualization.arrayToDataTable([['TigerReserveName','In-Progress'],");

            int count = dt.Rows.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                if (count == i)
                {
                    str.Append("['" + dt.Rows[i]["TigerReserveName"].ToString() + "'," + dt.Rows[i]["In-Progress"].ToString() + "]");
                }
                else
                {
                    str.Append("['" + dt.Rows[i]["TigerReserveName"].ToString() + "'," + dt.Rows[i]["In-Progress"].ToString() + "],");
                }
            }
            str.Append("]);");
            str.Append(" var options = { title: '', hAxis: {title: 'Tiger Reserve name',  titleTextStyle: {color: '#333'}}, vAxis: {minValue: 0} };");
            str.Append(" var chart = new google.visualization.AreaChart(document.getElementById('chart_div')); chart.draw(data, options); }");
            str.Append(" </script>");

            lt.Text = str.ToString();
        }
        catch
        {
        }
    }
}