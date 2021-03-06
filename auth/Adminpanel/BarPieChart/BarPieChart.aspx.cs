using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;  


public partial class auth_Adminpanel_BarPieChart_BarPieChart :  CrsfBase

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
            BindPieChart();           
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
                           // BindPieChart();
                            LblTigerReserNme.Visible = false;
                            demo2.Visible = false;
                        }
                        if(DdTigerReserve.SelectedValue!="0" && DDlStatus.SelectedValue=="0")
                        {
                            LblTigerReserNme.Visible = true;
                            demo2.Visible = true;

                            BindBarChart();
                            BindPieChart();
                        }
                        if(DdTigerReserve.SelectedValue=="0" && DDlStatus.SelectedValue!="0")
                        {
                            Response.Write("<script>alert('Please select Tiger reserve name.!');</script>");
                            return;
                        }
                        else
                        {
                            if(DdTigerReserve.SelectedValue!="0" && DDlStatus.SelectedValue!="0")
                            {
                                if (DDlStatus.SelectedItem.Text == "Relocated")
                                {
                                    BindBarChartRelocated();
                                  // BindPieChartRelocated();
                                    LblTigerReserNme.Visible = false;
                                    demo2.Visible = false;

                                }
                                if (DDlStatus.SelectedItem.Text == "Non-Relocated")
                                {
                                    BindBarChartNonRelocated();
                                 // BindPieChartNonRelocated();
                                    LblTigerReserNme.Visible = false;
                                    demo2.Visible = false;
                                }
                                if (DDlStatus.SelectedItem.Text == "In-Progress")
                                {
                                   BindBarChartInProgress();
                                  // BindPieChartInProgress();
                                   LblTigerReserNme.Visible = false;
                                   demo2.Visible = false;
                                }
                            }
                        }
                        if (DdTigerReserve.SelectedValue == "0" && DDlStatus.SelectedValue == "0" && DdlStateName.SelectedValue=="0")
                        {
                            LeftDivPanel.Visible = false;
                        }
                        if (DdTigerReserve.SelectedValue == "0" && DDlStatus.SelectedValue == "0" && DdlStateName.SelectedValue != "0")
                        {
                            LeftDivPanel.Visible = false;
                        }
                        if (DdTigerReserve.SelectedValue != "0" && DDlStatus.SelectedValue != "0" )
                        {
                            LeftDivPanel.Visible = false;
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
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        }
        
        P_var.dSet = _commanfuction.BindBarChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[1];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'TigerReserveName');
            data.addColumn('number', 'Relocated');
            data.addColumn('number', 'Non-Relocated'); 
            data.addColumn('number', 'In-Progress');         

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["TigerReserveName"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 3 + "," + dt.Rows[i]["In-Progress"].ToString() + ") ;");
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data,{isStacked:true, width:700, height:550, hAxis: {showTextEvery:1, slantedText:true}});}");

            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    void BindPieChart()
    {
        LblTigerReserNme.Text = string.Empty;
      //  DataTable dsChartData = new DataTable();
        DataTable dtt = new DataTable();
        StringBuilder strScript = new StringBuilder();
        // objContentOB.LangID = 1;
        //Valmiki Tiger Reserve
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
            P_var.dSet = _commanfuction.BindBarChart(_objNtcauser);
            dtt = P_var.dSet.Tables[1];
        }
        //_objNtcauser.TigerReserveName = "Valmiki Tiger Reserve";
        
        
        DataTable dsChartData = new DataTable();
        dsChartData.Columns.Add("VillageStatus", typeof(string));
        dsChartData.Columns.Add("NoOfVillages", typeof(int));
        for (int i = 0; i < dtt.Rows.Count; i++)
        {
            //-----------------
           
            if(i==0)
            {
                LblTigerReserNme.Text ="You have selected Tiger reserve name:-"+ dtt.Rows[i]["TigerReserveName"].ToString().ToUpper();
            }


            // Here we add five DataRows.
            dsChartData.Rows.Add("Relocated", Convert.ToInt32(dtt.Rows[i]["Relocated"]));
            dsChartData.Rows.Add("Non-Relocated", Convert.ToInt32(dtt.Rows[i]["Non-Relocated"]));
            dsChartData.Rows.Add("In-Progress", Convert.ToInt32(dtt.Rows[i]["In-Progress"]));
        }
        //---------------
        try
        {
           

            strScript.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']}); </script>
                    
                    <script type='text/javascript'>
                   
                    function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                    ['TigerReserveName', 'fdfdfd'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["VillageStatus"] + "'," + row["NoOfVillages"] + "],");
               // strScript.Append("['" + row["TigerReserveName"] + "'," + row["Relocated"] + "," + row["Non-Relocated"] + "," + row["In-Progress"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {   
                                    title: '',          
                                    is3D: true,        
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));        
                                chart.draw(data, options);      
                                }  
                            google.setOnLoadCallback(drawChart);
                            ");
            strScript.Append(" </script>");

            ltScripts.Text = strScript.ToString();
            if (dsChartData.Rows.Count >0)
            {
                LeftDivPanel.Visible = true;
               
               
            }
            else
            {
                LeftDivPanel.Visible = false;
            }
        }
        catch
        {
        }
        finally
        {
            dsChartData.Dispose();
            strScript.Clear();
        }
    }
    void BindBarChartRelocated()
    {

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
            str.Append(" chart.draw(data,{isStacked:true, width:700, height:550, hAxis: {showTextEvery:1, slantedText:true}});}");

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
        P_var.dSet = _commanfuction.BindBarChartRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[0];

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
            str.Append(" chart.draw(data,{isStacked:true, width:700, height:550, hAxis: {showTextEvery:1, slantedText:true}});}");

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
        P_var.dSet = _commanfuction.BindBarChartRelocated(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[0];

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
            str.Append(" chart.draw(data,{isStacked:true, width:700, height:550, hAxis: {showTextEvery:1, slantedText:true}});}");

            str.Append("</script>");
            lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch
        {
        }
    }
    //-----------------------------
    void BindPieChartRelocated()
    {
        LblTigerReserNme.Text = string.Empty;
        //  DataTable dsChartData = new DataTable();
        DataTable dtt = new DataTable();
        StringBuilder strScript = new StringBuilder();
        // objContentOB.LangID = 1;
        //Valmiki Tiger Reserve
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
           _objNtcauser.sAction = "Relocated";
        P_var.dSet = _commanfuction.BindBarChartRelocated(_objNtcauser);
            dtt = P_var.dSet.Tables[0];
        }
        //_objNtcauser.TigerReserveName = "Valmiki Tiger Reserve";


        DataTable dsChartData = new DataTable();
        dsChartData.Columns.Add("VillageStatus", typeof(string));
        dsChartData.Columns.Add("NoOfVillages", typeof(int));
        for (int i = 0; i < dtt.Rows.Count; i++)
        {
            //-----------------

            if (i == 0)
            {
                LblTigerReserNme.Text = "You have selected Tiger reserve name:-" + dtt.Rows[i]["TigerReserveName"].ToString().ToUpper();
            }


            // Here we add five DataRows.
            dsChartData.Rows.Add("Relocated", Convert.ToInt32(dtt.Rows[i]["Relocated"]));
          //  dsChartData.Rows.Add("Non-Relocated", Convert.ToInt32(dtt.Rows[i]["Non-Relocated"]));
            //dsChartData.Rows.Add("In-Progress", Convert.ToInt32(dtt.Rows[i]["In-Progress"]));
        }
        //---------------
        try
        {


            strScript.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']}); </script>
                    
                    <script type='text/javascript'>
                   
                    function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                    ['TigerReserveName', 'fdfdfd'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["VillageStatus"] + "'," + row["NoOfVillages"] + "],");
                // strScript.Append("['" + row["TigerReserveName"] + "'," + row["Relocated"] + "," + row["Non-Relocated"] + "," + row["In-Progress"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {   
                                    title: '',          
                                    is3D: true,        
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));        
                                chart.draw(data, options);      
                                }  
                            google.setOnLoadCallback(drawChart);
                            ");
            strScript.Append(" </script>");

            ltScripts.Text = strScript.ToString();
            if (dsChartData.Rows.Count > 0)
            {
                LeftDivPanel.Visible = true;


            }
            else
            {
                LeftDivPanel.Visible = false;
            }
        }
        catch
        {
        }
        finally
        {
            dsChartData.Dispose();
            strScript.Clear();
        }
    }
    void BindPieChartNonRelocated()
    {
        LblTigerReserNme.Text = string.Empty;
        //  DataTable dsChartData = new DataTable();
        DataTable dtt = new DataTable();
        StringBuilder strScript = new StringBuilder();
        // objContentOB.LangID = 1;
        //Valmiki Tiger Reserve
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
            _objNtcauser.sAction = "Non-Relocated";
        P_var.dSet = _commanfuction.BindBarChartRelocated(_objNtcauser);
            dtt = P_var.dSet.Tables[0];
        }
        //_objNtcauser.TigerReserveName = "Valmiki Tiger Reserve";


        DataTable dsChartData = new DataTable();
        dsChartData.Columns.Add("VillageStatus", typeof(string));
        dsChartData.Columns.Add("NoOfVillages", typeof(int));
        for (int i = 0; i < dtt.Rows.Count; i++)
        {
            //-----------------

            if (i == 0)
            {
                LblTigerReserNme.Text = "You have selected Tiger reserve name:-" + dtt.Rows[i]["TigerReserveName"].ToString().ToUpper();
            }


            // Here we add five DataRows.
         //   dsChartData.Rows.Add("Relocated", Convert.ToInt32(dtt.Rows[i]["Relocated"]));
            dsChartData.Rows.Add("Non-Relocated", Convert.ToInt32(dtt.Rows[i]["Non-Relocated"]));
          //  dsChartData.Rows.Add("In-Progress", Convert.ToInt32(dtt.Rows[i]["In-Progress"]));
        }
        //---------------
        try
        {


            strScript.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']}); </script>
                    
                    <script type='text/javascript'>
                   
                    function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                    ['TigerReserveName', 'fdfdfd'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["VillageStatus"] + "'," + row["NoOfVillages"] + "],");
                // strScript.Append("['" + row["TigerReserveName"] + "'," + row["Relocated"] + "," + row["Non-Relocated"] + "," + row["In-Progress"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {   
                                    title: '',          
                                    is3D: true,        
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));        
                                chart.draw(data, options);      
                                }  
                            google.setOnLoadCallback(drawChart);
                            ");
            strScript.Append(" </script>");

            ltScripts.Text = strScript.ToString();
            if (dsChartData.Rows.Count > 0)
            {
                LeftDivPanel.Visible = true;


            }
            else
            {
                LeftDivPanel.Visible = false;
            }
        }
        catch
        {
        }
        finally
        {
            dsChartData.Dispose();
            strScript.Clear();
        }
    }
    void BindPieChartInProgress()
    {
        LblTigerReserNme.Text = string.Empty;
        //  DataTable dsChartData = new DataTable();
        DataTable dtt = new DataTable();
        StringBuilder strScript = new StringBuilder();
        // objContentOB.LangID = 1;
        //Valmiki Tiger Reserve
        // P_var.dSet = obj_ContentBl.getStateName(objContentOB);
        if (DdTigerReserve.SelectedValue != "0")
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
            _objNtcauser.sAction = "In-Progress";
            P_var.dSet = _commanfuction.BindBarChartRelocated(_objNtcauser);
            dtt = P_var.dSet.Tables[0];
        }
        //_objNtcauser.TigerReserveName = "Valmiki Tiger Reserve";


        DataTable dsChartData = new DataTable();
        dsChartData.Columns.Add("VillageStatus", typeof(string));
        dsChartData.Columns.Add("NoOfVillages", typeof(int));
        for (int i = 0; i < dtt.Rows.Count; i++)
        {
            //-----------------

            if (i == 0)
            {
                LblTigerReserNme.Text = "You have selected Tiger reserve name:-" + dtt.Rows[i]["TigerReserveName"].ToString().ToUpper();
            }


            // Here we add five DataRows.
            //   dsChartData.Rows.Add("Relocated", Convert.ToInt32(dtt.Rows[i]["Relocated"]));
           // dsChartData.Rows.Add("Non-Relocated", Convert.ToInt32(dtt.Rows[i]["Non-Relocated"]));
              dsChartData.Rows.Add("In-Progress", Convert.ToInt32(dtt.Rows[i]["In-Progress"]));
        }
        //---------------
        try
        {


            strScript.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']}); </script>
                    
                    <script type='text/javascript'>
                   
                    function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                    ['TigerReserveName', 'fdfdfd'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["VillageStatus"] + "'," + row["NoOfVillages"] + "],");
                // strScript.Append("['" + row["TigerReserveName"] + "'," + row["Relocated"] + "," + row["Non-Relocated"] + "," + row["In-Progress"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {   
                                    title: '',          
                                    is3D: true,        
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));        
                                chart.draw(data, options);      
                                }  
                            google.setOnLoadCallback(drawChart);
                            ");
            strScript.Append(" </script>");

            ltScripts.Text = strScript.ToString();
            if (dsChartData.Rows.Count > 0)
            {
                LeftDivPanel.Visible = true;


            }
            else
            {
                LeftDivPanel.Visible = false;
            }
        }
        catch
        {
        }
        finally
        {
            dsChartData.Dispose();
            strScript.Clear();
        }
    }

    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReservename();
    }
}