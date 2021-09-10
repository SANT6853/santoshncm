using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_BarPieChart_TigerReserveComparativeChart : CrsfBase
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
            BindStateName();
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
                        if (DdTigerReserve.SelectedValue == "0" && DDlStatus.SelectedValue == "0" && DdlStateName.SelectedValue == "0")
                        {
                            BindBarChart();

                        }
                        if (DdlStateName.SelectedValue != "0")
                        {
                            BindBarChart();
                        }
                        if (DdTigerReserve.SelectedValue != "0")
                        {
                            BindBarChart();
                        }
                        if (DDlStatus.SelectedValue != "0")
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
                            if (DDlStatus.SelectedValue == "Populations")
                            {
                                BindBarChartPopulation();

                            }
                        }

                        //if (DdTigerReserve.SelectedValue != "0" && DDlStatus.SelectedValue != "0")
                        //{
                        //    if (DDlStatus.SelectedItem.Text == "Relocated")
                        //    {
                        //        BindBarChartRelocated();


                        //    }
                        //    if (DDlStatus.SelectedItem.Text == "Non-Relocated")
                        //    {
                        //        BindBarChartNonRelocated();

                        //    }
                        //    if (DDlStatus.SelectedItem.Text == "In-Progress")
                        //    {
                        //        BindBarChartInProgress();

                        //    }
                        //    if (DDlStatus.SelectedValue == "Populations")
                        //    {
                        //        BindBarChartPopulation();

                        //    }
                        //}
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
        if (DdlStateName.SelectedValue != "0")
        {
            _objNtcauser.StateName = DdlStateName.SelectedValue;
        }
        else
        {
            _objNtcauser.StateName = null;
        }

        P_var.dSet = _commanfuction.BindBarChart(_objNtcauser);
        if (P_var.dSet.Tables[1].Rows.Count > 0)
        {
            DdTigerReserve.DataSource = P_var.dSet.Tables[1];
            DdTigerReserve.DataTextField = "TigerReserveName";
            DdTigerReserve.DataValueField = "TigerReserveName";
            DdTigerReserve.DataBind();
            DdTigerReserve.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    void BindStateName()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        P_var.dSet = _commanfuction.BindDdlStateBarChart(_objNtcauser);
        if (P_var.dSet.Tables[3].Rows.Count > 0)
        {
            DdlStateName.DataSource = P_var.dSet.Tables[3];
            DdlStateName.DataTextField = "StateName";
            DdlStateName.DataValueField = "StateName";
            DdlStateName.DataBind();
            DdlStateName.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    void BindBarChart()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdlStateName.SelectedValue != "0")
        {
            _objNtcauser.StateName = DdlStateName.SelectedValue;
        }
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }

        P_var.dSet = _commanfuction.BindBarComparativeChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[3];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Tiger Reserve name');
        data.addColumn('number', 'No of village populations');      
        data.addColumn('number', 'Relocated');  
        data.addColumn('number', 'Non-Relocated');  
        data.addColumn('number', 'In-Progress');      

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["TigerReserveName"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["PopulationCount"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 3 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 4 + "," + dt.Rows[i]["In-Progress"].ToString() + ") ;");    
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data, {width: 900, height: 500, title: '',");
            str.Append("hAxis: {title: 'Tiger Reserve Name', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    //------------------
    void BindBarChartRelocated()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }
        _objNtcauser.sAction = "Relocated";
        P_var.dSet = _commanfuction.BindBarChartComparativeRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[3];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'TigerReserveName');
            data.addColumn('number', 'Relocated');
                  

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["TigerReserveName"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                // str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                // str.Append("data.setValue(" + i + "," + 3 + "," + dt.Rows[i]["In-Progress"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data, {width: 1050, height: 500, title: '',");
            str.Append("hAxis: {title: 'Tiger Reserve Name', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    void BindBarChartNonRelocated()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }
        _objNtcauser.sAction = "Non-Relocated";
        P_var.dSet = _commanfuction.BindBarChartComparativeRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[3];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'TigerReserveName');        
            data.addColumn('number', 'Non-Relocated'); 
               
            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["TigerReserveName"].ToString() + "');");
                // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                // str.Append("data.setValue(" + i + "," + 3 + "," + dt.Rows[i]["In-Progress"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data, {width: 1050, height: 500, title: '',");
            str.Append("hAxis: {title: 'Tiger Reserve Name', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    void BindBarChartInProgress()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }
        _objNtcauser.sAction = "In-Progress";
        P_var.dSet = _commanfuction.BindBarChartComparativeRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[3];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'TigerReserveName');
           
            data.addColumn('number', 'In-Progress');         

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["TigerReserveName"].ToString() + "');");
                // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                //  str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["In-Progress"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data, {width: 1050, height: 500, title: '',");
            str.Append("hAxis: {title: 'Tiger Reserve Name', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    void BindBarChartPopulation()
    {

        // objContentOB.LangID = 1;
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }
        _objNtcauser.sAction = "Populations";
        P_var.dSet = _commanfuction.BindBarChartComparativeRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[3];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'TigerReserveName');
           
            data.addColumn('number', 'No of Village Populations');         

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["TigerReserveName"].ToString() + "');");
                // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                //  str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["PopulationCount"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data, {width: 1050, height: 500, title: '',");
            str.Append("hAxis: {title: 'Tiger Reserve Name', titleTextStyle: {color: 'green'}}");
            str.Append("}); }");
            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    //-----------------------------
  
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReservename();
    }
}