using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Configuration;
using System.Runtime.InteropServices;

public partial class auth_Adminpanel_BarPieChart_VillageMaritalOptionBarPieChart :CrsfBase 
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
            VillageName();
            BindBarChart();
            //  BindPieChart();
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
                        if (DdTigerReserve.SelectedValue == "0" && DDlStatus.SelectedValue == "All")
                        {
                            BindBarChart();

                            LblTigerReserNme.Visible = false;
                            demo2.Visible = false;
                        }
                        if (DdTigerReserve.SelectedValue != "0" && DDlStatus.SelectedValue == "All")
                        {
                            LblTigerReserNme.Visible = false;
                            demo2.Visible = false;

                            BindBarChart();
                            // BindPieChart();
                        }
                        if (DdTigerReserve.SelectedValue != "0" && DdlVillageName.SelectedValue != "0" && DDlStatus.SelectedValue == "All")
                        {
                            LblTigerReserNme.Visible = true;
                            demo2.Visible = true;
                            BindPieChart();
                        }
                        if (DdTigerReserve.SelectedValue == "0" && DDlStatus.SelectedValue != "All")
                        {
                            Response.Write("<script>alert('Please select Tiger reserve name.!');</script>");
                            return;
                        }
                        else
                        {
                            if (DdTigerReserve.SelectedValue != "0" && DDlStatus.SelectedValue != "All")
                            {
                                if (DDlStatus.SelectedItem.Text == "Single")
                                {
                                    BindBarChartSingle();
                                    // BindBarChart();
                                    LblTigerReserNme.Visible = false;
                                    demo2.Visible = false;

                                }
                                if (DDlStatus.SelectedItem.Text == "Married")
                                {
                                    //BindBarChartNonRelocated();
                                    //  BindBarChart();
                                    BindBarChartMarried();
                                    LblTigerReserNme.Visible = false;
                                    demo2.Visible = false;
                                }
                                if (DDlStatus.SelectedItem.Text == "Divorce")
                                {
                                    //  BindBarChartInProgress();
                                    // BindBarChart();
                                    BindBarChartDivorce();
                                    LblTigerReserNme.Visible = false;
                                    demo2.Visible = false;
                                }
                                if (DDlStatus.SelectedValue == "I")
                                {
                                    //  BindBarChartInProgress();
                                    // BindBarChart();
                                    BindBarChartI();
                                    LblTigerReserNme.Visible = false;
                                    demo2.Visible = false;
                                }
                                if (DDlStatus.SelectedValue == "II")
                                {
                                    //  BindBarChartInProgress();
                                    // BindBarChart();
                                    BindBarChartII();
                                    LblTigerReserNme.Visible = false;
                                    demo2.Visible = false;
                                }
                                if (DDlStatus.SelectedValue == "No Option")
                                {
                                    //  BindBarChartInProgress();
                                    // BindBarChart();
                                    BindBarChartNo_Option();
                                    LblTigerReserNme.Visible = false;
                                    demo2.Visible = false;
                                }
                            }
                        }
                        if (DdTigerReserve.SelectedValue == "0" && DdlVillageName.SelectedValue == "0" && DdlStateName.SelectedValue == "0" && DDlStatus.SelectedValue == "All")
                        {
                            LeftDivPanel.Visible = false;
                        }
                        if (DdTigerReserve.SelectedValue != "0" && DdlVillageName.SelectedValue == "0" && DdlStateName.SelectedValue == "0" && DDlStatus.SelectedValue == "All")
                        {
                            LeftDivPanel.Visible = false;
                        }
                        if (DdTigerReserve.SelectedValue != "0" && DdlVillageName.SelectedValue == "0" && DdlStateName.SelectedValue != "0" && DDlStatus.SelectedValue == "All")
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

    
    void VillageName()
    {

        _objNtcauser.VillageName = null;
        _objNtcauser.sAction = "ReserveID";
        _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;

        P_var.dSet = _commanfuction.BindVillagenameChart(_objNtcauser);
        if (P_var.dSet.Tables[2].Rows.Count > 0)
        {
            DdlVillageName.DataSource = P_var.dSet.Tables[2];
            DdlVillageName.DataTextField = "VILL_NM";
            DdlVillageName.DataValueField = "VILL_NM";
            DdlVillageName.DataBind();
            DdlVillageName.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            DdlVillageName.Items.Clear();
            DdlVillageName.Items.Insert(0, new ListItem("--No record found--", "0"));
        }
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
    void BindBarChart()
    {

        if (DdTigerReserve.SelectedValue == "0")
        {
            _objNtcauser.TigerReserveName = null;
        }
        else
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;
        }
        if (DdlVillageName.SelectedValue == "0")
        {
            _objNtcauser.VillageName = null;
        }
        else
        {
            _objNtcauser.VillageName = DdlVillageName.SelectedItem.Text;
        }
        if (DDlStatus.SelectedValue == "All")
        {
            _objNtcauser.sAction = "All";
        }
        else
        {
            _objNtcauser.sAction = DDlStatus.SelectedValue;
        }
        // _objNtcauser.VillageName = null;
        ///_objNtcauser.sAction = "All";
        /// _objNtcauser.TigerReserveName = null;

        P_var.dSet = _commanfuction.BindVillageMaritalStatusOptionWiseChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[6];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'VillageName');
           
            data.addColumn('number', 'I');  
            data.addColumn('number', 'II');  
                

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["VillageName"].ToString() + "');");
               // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Single"].ToString() + ") ;");
               // str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Married"].ToString() + ") ;");
               // str.Append("data.setValue(" + i + "," + 3 + "," + dt.Rows[i]["Divorce"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["I"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["II"].ToString() + ") ;");
                
            }

            str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data,{isStacked:true, width:"+30* (dt.Rows.Count)+", height:450,chartArea: {left: 40,top: 10,width:" + 25 * (dt.Rows.Count) + ",height: 350}, hAxis: {showTextEvery:1, slantedText:true}});}");

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

        DataTable dtt = new DataTable();
        StringBuilder strScript = new StringBuilder();


        if (DdTigerReserve.SelectedValue == "0")
        {
            _objNtcauser.TigerReserveName = null;
        }
        else
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;
        }
        if (DdlVillageName.SelectedValue == "0")
        {
            _objNtcauser.VillageName = null;
        }
        else
        {
            _objNtcauser.VillageName = DdlVillageName.SelectedItem.Text;
        }
        if (DDlStatus.SelectedValue == "All")
        {
            _objNtcauser.sAction = "All";
        }
        else
        {
            _objNtcauser.sAction = DDlStatus.SelectedValue;
        }

        P_var.dSet = _commanfuction.BindVillageMaritalStatusOptionWiseChart(_objNtcauser);
        dtt = P_var.dSet.Tables[6];

        DataTable dsChartData = new DataTable();
        dsChartData.Columns.Add("MaritalStatusOptionWise", typeof(string));
        dsChartData.Columns.Add("NoOfMaritalStatusOptionWise", typeof(int));
       // dsChartData.Columns.Add("NoofNoBeneficiarycounting", typeof(int));
        for (int i = 0; i < dtt.Rows.Count; i++)
        {
            //-----------------

            if (i == 0)
            {
                LblTigerReserNme.Text = "You have selected village name:-" + dtt.Rows[i]["VillageName"].ToString().ToUpper();
            }


            // Here we add five DataRows.
          //  dsChartData.Rows.Add("Single", Convert.ToInt32(dtt.Rows[i]["Single"]));
          //  dsChartData.Rows.Add("Married", Convert.ToInt32(dtt.Rows[i]["Married"]));
          //  dsChartData.Rows.Add("Divorce", Convert.ToInt32(dtt.Rows[i]["Divorce"]));
            dsChartData.Rows.Add("I", Convert.ToInt32(dtt.Rows[i]["I"]));
            dsChartData.Rows.Add("II", Convert.ToInt32(dtt.Rows[i]["II"]));
           // dsChartData.Rows.Add("No Option", Convert.ToInt32(dtt.Rows[i]["No Option"]));
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
                strScript.Append("['" + row["MaritalStatusOptionWise"] + "'," + row["NoOfMaritalStatusOptionWise"] + "],");
               // strScript.Append("['" + row["Cast"] + "'," + row["NoOfCast"] + "'," + row["NoofNoBeneficiarycounting"] + "],");
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
    //---------------------------
    void BindBarChartSingle()
    {


        //if (DdTigerReserve.SelectedValue != "0")
        //{
        //    _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        //}
        //_objNtcauser.sAction = "Relocated";
        if (DdTigerReserve.SelectedValue == "0")
        {
            _objNtcauser.TigerReserveName = null;
        }
        else
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;
        }
        if (DdlVillageName.SelectedValue == "0")
        {
            _objNtcauser.VillageName = null;
        }
        else
        {
            _objNtcauser.VillageName = DdlVillageName.SelectedItem.Text;
        }
        if (DDlStatus.SelectedValue == "All")
        {
            _objNtcauser.sAction = "All";
        }
        else
        {
            _objNtcauser.sAction = DDlStatus.SelectedValue;
        }
        P_var.dSet = _commanfuction.BindVillageMaritalStatusOptionWiseChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[6];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'VillageName');
            data.addColumn('number', 'Single');
                  

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["VillageName"].ToString() + "');");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Single"].ToString() + ") ;");
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
    void BindBarChartMarried()
    {


        //if (DdTigerReserve.SelectedValue != "0")
        //{
        //    _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        //}
        //_objNtcauser.sAction = "Non-Relocated";
        if (DdTigerReserve.SelectedValue == "0")
        {
            _objNtcauser.TigerReserveName = null;
        }
        else
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;
        }
        if (DdlVillageName.SelectedValue == "0")
        {
            _objNtcauser.VillageName = null;
        }
        else
        {
            _objNtcauser.VillageName = DdlVillageName.SelectedItem.Text;
        }
        if (DDlStatus.SelectedValue == "All")
        {
            _objNtcauser.sAction = "All";
        }
        else
        {
            _objNtcauser.sAction = DDlStatus.SelectedValue;
        }
        P_var.dSet = _commanfuction.BindVillageMaritalStatusOptionWiseChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[6];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'VillageName');        
            data.addColumn('number', 'Married'); 
               
            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["VillageName"].ToString() + "');");
                // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Married"].ToString() + ") ;");
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
    void BindBarChartDivorce()
    {


        //if (DdTigerReserve.SelectedValue != "0")
        //{
        //    _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        //}
        //_objNtcauser.sAction = "In-Progress";
        if (DdTigerReserve.SelectedValue == "0")
        {
            _objNtcauser.TigerReserveName = null;
        }
        else
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;
        }
        if (DdlVillageName.SelectedValue == "0")
        {
            _objNtcauser.VillageName = null;
        }
        else
        {
            _objNtcauser.VillageName = DdlVillageName.SelectedItem.Text;
        }
        if (DDlStatus.SelectedValue == "All")
        {
            _objNtcauser.sAction = "All";
        }
        else
        {
            _objNtcauser.sAction = DDlStatus.SelectedValue;
        }
        P_var.dSet = _commanfuction.BindVillageMaritalStatusOptionWiseChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[6];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'VillageName');
           
            data.addColumn('number', 'Divorce');         

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["VillageName"].ToString() + "');");
                // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                //  str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Divorce"].ToString() + ") ;");
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
    void BindBarChartI()
    {


        //if (DdTigerReserve.SelectedValue != "0")
        //{
        //    _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        //}
        //_objNtcauser.sAction = "In-Progress";
        if (DdTigerReserve.SelectedValue == "0")
        {
            _objNtcauser.TigerReserveName = null;
        }
        else
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;
        }
        if (DdlVillageName.SelectedValue == "0")
        {
            _objNtcauser.VillageName = null;
        }
        else
        {
            _objNtcauser.VillageName = DdlVillageName.SelectedItem.Text;
        }
        if (DDlStatus.SelectedValue == "All")
        {
            _objNtcauser.sAction = "All";
        }
        else
        {
            _objNtcauser.sAction = DDlStatus.SelectedValue;
        }
        P_var.dSet = _commanfuction.BindVillageMaritalStatusOptionWiseChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[6];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'VillageName');
           
            data.addColumn('number', 'I');         

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["VillageName"].ToString() + "');");
                // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                //  str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["I"].ToString() + ") ;");
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
    void BindBarChartII()
    {


        //if (DdTigerReserve.SelectedValue != "0")
        //{
        //    _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        //}
        //_objNtcauser.sAction = "In-Progress";
        if (DdTigerReserve.SelectedValue == "0")
        {
            _objNtcauser.TigerReserveName = null;
        }
        else
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;
        }
        if (DdlVillageName.SelectedValue == "0")
        {
            _objNtcauser.VillageName = null;
        }
        else
        {
            _objNtcauser.VillageName = DdlVillageName.SelectedItem.Text;
        }
        if (DDlStatus.SelectedValue == "All")
        {
            _objNtcauser.sAction = "All";
        }
        else
        {
            _objNtcauser.sAction = DDlStatus.SelectedValue;
        }
        P_var.dSet = _commanfuction.BindVillageMaritalStatusOptionWiseChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[6];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'VillageName');
           
            data.addColumn('number', 'II');         

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["VillageName"].ToString() + "');");
                // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                //  str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["II"].ToString() + ") ;");
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
    void BindBarChartNo_Option()
    {


        //if (DdTigerReserve.SelectedValue != "0")
        //{
        //    _objNtcauser.TigerReserveName = DdTigerReserve.SelectedValue;
        //}
        //_objNtcauser.sAction = "In-Progress";
        if (DdTigerReserve.SelectedValue == "0")
        {
            _objNtcauser.TigerReserveName = null;
        }
        else
        {
            _objNtcauser.TigerReserveName = DdTigerReserve.SelectedItem.Text;
        }
        if (DdlVillageName.SelectedValue == "0")
        {
            _objNtcauser.VillageName = null;
        }
        else
        {
            _objNtcauser.VillageName = DdlVillageName.SelectedItem.Text;
        }
        if (DDlStatus.SelectedValue == "All")
        {
            _objNtcauser.sAction = "All";
        }
        else
        {
            _objNtcauser.sAction = DDlStatus.SelectedValue;
        }
        P_var.dSet = _commanfuction.BindVillageMaritalStatusOptionWiseChart(_objNtcauser);
        DataTable dt = P_var.dSet.Tables[6];

        try
        {

            str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'VillageName');
           
            data.addColumn('number', 'No Option');         

            data.addRows(" + dt.Rows.Count + ");");

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["VillageName"].ToString() + "');");
                // str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Relocated"].ToString() + ") ;");
                //  str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Non-Relocated"].ToString() + ") ;");
                str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["No Option"].ToString() + ") ;");
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
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTigerReservename();
    }
    protected void DdTigerReserve_SelectedIndexChanged(object sender, EventArgs e)
    {

        VillageName();
    }
}