<%@ Page Title="NTCA:Dashboard" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="auth_Adminpanel_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#LblTigerReserveShow').hide();
            $('#ball_footballbox').hide();
            $('.counter').each(function () {
                $(this).prop('Counter', 0).animate({
                    Counter: $(this).text()
                }, {
                    duration: 4000,
                    easing: 'swing',
                    step: function (now) {
                        $(this).text(Math.ceil(now));
                    }
                });
            });
            $('#myModalVillage').click(function () {
                location.reload();
            });
        });
    </script>
    <style type="text/css">
        .highcharts-label span {
            color: black !important;
        }
         #theImg {
            border-radius: 50%;
        }
        .counter {
        }
        /*below high chart css*/
        .highcharts-credits {
            display: none;
        }

        .highcharts-button-symbol {
            display: none;
        }

        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            /*width: 100% !important;*/
        }
    </style>
    <style>
        #container {
            height: 400px;
            min-width: 310px;
            max-width: 600px;
            margin: 0 auto;
        }

        .loading {
            margin-top: 10em;
            text-align: center;
            color: gray;
        }

        .modal-dialog {
            /*width: 100% !important;*/
            width: 80% !important;
        }
         .highcharts-contextbutton,.highcharts-color-undefined{ display:none;}
		 
		 .villist{
			    padding: 0px;
				min-height: 999px;
		 }
		 #contentbody_gvVillage tr:nth-child(1){
			display:none;
		 }
		 .highcharts-background{fill:none !important;}
		 .icon a{color:#fff;}
		.icon a .fa{font-size: 55px !important; margin-right: 22px;}
		.small-box{cursor:pointer;}
    </style>
    <script src="<%=ResolveUrl("~/js/HcharNew/1highmaps.js") %>"></script>
    <script src="<%=ResolveUrl("~/js/HcharNew/2data.js") %>"></script>
    <script src="<%=ResolveUrl("~/js/HcharNew/3drilldown.js") %>"></script>
    <script src="<%=ResolveUrl("~/js/HcharNew/4exporting.js") %>"></script>
    <script src="<%=ResolveUrl("~/js/HcharNew/5offline-exporting.js") %>"></script>
    <%if (!Session["UserType"].ToString().Equals("1"))
      {%>
    <script src="<%=ResolveUrl("~/js/data/"+Session["sMapStatID"].ToString()+".js") %>"></script>
    <%} %>





    <link href="<%=ResolveUrl("~/js/HcharNew/6font-awesome.css") %>" rel="stylesheet" />
</asp:Content>
<asp:Content ID="contentMainBody" ContentPlaceHolderID="contentbody" runat="server">
 <div class="container-fluid bigfacebg" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 15px; ">
	<div class="">
        <div>
        </div>


        <div class="row nu12">
            <div class="col-lg-12">


                <div class="row">
                    <div class="col-lg-3 col-xs-6 bxtp">

                        <div class="small-box bg-aqua bg-aqua-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>';">
                            <div class="inner">
                                <h3><span class="counter">

                                    <label id="LblVillageCounter" runat="server"></label>
                                </span></h3>

                                <p>VILLAGE</p>
                            </div>
                            <div class="icon">
                                <img src="images/village.png">
                            </div>
                            <!--<a href="<%=ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>-->
                        </div>
                    </div>

                    <div class="col-lg-3 col-xs-6 bxtp">

                        <div class="small-box bg-green bg-green-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/TigerReserve/ViewTigerReserver.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.TigerReserve) %>';">
                            <div class="inner">
                                <h3><span class="counter">
                                    <label id="LblTigerReserve" runat="server"></label>
                                </span>
                                </h3>

                                <p>TIGER RESERVE</p>
                            </div>
                            <div class="icon">
                                <img src="images/tiger.png">
                            </div>
                           <!-- <a href="<%= ResolveUrl("~/auth/adminpanel/TigerReserve/ViewTigerReserver.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.TigerReserve) %>" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>-->
                        </div>
                    </div>

                    <div class="col-lg-3 col-xs-6 bxtp">
                        <!-- small box -->
                        <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/FamilyData/Family_Management.aspx") %>';">
                            <div class="inner">
                                <h3><span class="counter">
                                    <label id="LblFamilyCounter" runat="server"></label>
                                </span></h3>

                                <p>FAMILY</p>
                            </div>
                            <div class="icon">
                                <img src="images/family.png">
                            </div>
                           <!-- <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>-->
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-xs-6 bxtp">
                        <!-- small box -->
                        <div class="small-box bg-red bg-red-shadow hvr-grow-shadow" onclick="window.location='<% %>';">
                            <div class="inner">
                                <h3><span class="counter">
                                    <label id="LblNgocounter" runat="server"></label>
                                </span></h3>

                                <p>NGO</p>
                            </div>
                            <div class="icon">
                                <img src="images/ngo.png">
                            </div>
                            <!--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>-->
                        </div>
                    </div>
                    <!-- ./col -->
                </div>
            </div>
            <div class="col-lg-12">


                <div class="row">
				
				
                    <div class="col-lg-3 col-xs-6 bxtp" id="dBannerMang" runat="server" visible="false">
                        <!-- small box -->

                        <div class="small-box bg-red bg-red-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Banner/AddBanner.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.Banner) %>';">
                            <div class="inner">
                                <a href="<%= ResolveUrl("~/auth/adminpanel/Banner/AddBanner.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.Banner) %>">
                                    <h4>Banner Management </h4>
                                </a>

                                <p></p>
                            </div>
                            <div class="icon">
                                <a href="<%= ResolveUrl("~/auth/adminpanel/Banner/AddBanner.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.Banner) %>">
                                    <img src="images/banner-management.png"></a>
                            </div>
                            <%--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
                        </div>

                    </div>
					
					
                    <div class="col-lg-3 col-xs-6 bxtp" id="dPhotoGall" runat="server" visible="false">
                        <!-- small box -->
                        <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow">
                            <div class="inner">
                                <a href="#">
                                    <h4>Photo Gallery</h4>
                                </a>

                                <p></p>
                            </div>
                            <div class="icon">
                                <a href="#">
                                    <img src="images/photo-gallery.png"></a>
                            </div>
                            <%--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
                        </div>
                    </div>
					
					
                    <div class="col-lg-3 col-xs-6 bxtp" id="dCdpMng" runat="server" visible="false">
                        <!-- small box -->
                        <div class="small-box bg-aqua bg-aqua-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/CDP/CDP_Management.aspx") %>';">
                            <div class="inner">
                                <a href="<%=ResolveUrl("~/auth/adminpanel/CDP/CDP_Management.aspx") %>">
                                    <h4>CDP Management</h4>
                                </a>

                                <p></p>
                            </div>
                            <div class="icon">
                                <a href="<%=ResolveUrl("~/auth/adminpanel/CDP/CDP_Management.aspx") %>">
                                    <img src="images/cdp-management.png"></a>
                            </div>
                            <%--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
                        </div>
                    </div>
					<div class="col-lg-3 col-xs-6 bxtp">
                        <!-- small box -->
                        <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/MisReportDashBoard.aspx") %>';">
                            <div class="inner">
                                <a href="<%= ResolveUrl("~/auth/adminpanel/MisReportDashBoard.aspx") %>">
                                    <h4> MIS Reports Generation</h4>
                                </a>

                                
                            </div>
                            <div class="icon">
                                <a href="<%= ResolveUrl("~/auth/adminpanel/MisReportDashBoard.aspx") %>"><i class="fa fa-file"></i></a>
                            </div>
                            
                        </div>
                   </div>
                    <!-- ./col -->
					
					<!--pre-post-form-->
					<div class="col-lg-6 col-xs-6 bxtp">
                        <!-- small box -->
                        <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>';">
                            <div class="inner">
                                <a href="<%= ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>">
                                    <h4> Voluntary village Relocation</h4>
                                </a>

                                
                            </div>
                            <div class="icon">
                                <a href="<%= ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>"><i class="fa fa-file"></i></a>
                            </div>
                            
                        </div>
                   </div>
                    <!-- ./col -->
					
					<div class="col-lg-6 col-xs-6 bxtp">
                        <!-- small box -->
                        <div class="small-box bg-aqua bg-aqua-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Post/survey-details.aspx") %>';">
                            <div class="inner">
                                <a href="<%= ResolveUrl("~/auth/Adminpanel/Post/survey-details.aspx") %>">
                                    <h4> Post-Voluntary Village Relocation Monitoring form</h4>
                                </a>

                                
                            </div>
                            <div class="icon">
                                <a href="<%= ResolveUrl("~/auth/Adminpanel/Post/survey-details.aspx") %>"><i class="fa fa-file"></i></a>
                            </div>
                            
                        </div>
                   </div>
                    <!-- ./col -->
					<!--pre-post-form-end-->
				
					
                    <div class="col-lg-3 col-xs-6 bxtp" id="dCms" runat="server" visible="false">
                        
                        <div class="small-box bg-green bg-green-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/CMS/AddContent.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.cms) %>';">
                            <div class="inner">
                                <a href="<%= ResolveUrl("~/auth/adminpanel/CMS/AddContent.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.cms) %>">
                                    <h4>CMS</h4>
                                </a>

                                <p></p>
                            </div>
                            <div class="icon">
                                <a href="<%= ResolveUrl("~/auth/adminpanel/CMS/AddContent.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.cms) %>">
                                    <img src="images/cms.png"></a>
                            </div>
                            
                        </div>
                    </div>
					
					                    <!-- ./col -->
										
					

                    <!-- ./col -->
               
            </div>
        </div>
        <div class="row">
            <div class="col-lg-9">
                <div class="restbodr">
                    <div class="panel panel-green">
                        <div class="rest1">
                            <div class="panel-heading ">
                                <i class="fa fa-bar-chart-o fa-fw"></i>[<%=Session["sStatename"]%>] State Map
                                            
                            </div>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body bigfacebg">
                            <%--India map code--%>
                            <label id="ball_footballbox"></label>
                            <label id="LblTigerReserveShow" style="display: none;"></label>
                            <label id="txt"></label>

                            <label style="display: none;" id="LblstateID"></label>
                            <label style="display: none;" id="LblMapStatID"></label>
                            <label style="display: none;" id="LblMapDistricID"></label>

                            <div id="container" style="height: 950px; min-width: 310px; max-width: 1200px; margin: 0 auto"></div>
                        </div>
                    </div>

                </div>
            </div>
            <!-- /.col-lg-9 start naren-->
            <!-- /.col-lg-9 -->
            <div class="col-lg-3">
                <div class="restbodr">
                    <div class="panel panel-green">
                        <div class="rest1">
                            <div class="panel-heading">
                                <i class="fa fa-bell fa-fw"></i>Village list
                                [<asp:Label ID="lblcount" runat="server" Font-Bold="True"></asp:Label>]
                            </div>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body villist bigfacebg">
                            <%--Village list code below--%>
        <div>

            <asp:Label ID="lblnorecord" runat="server" Text=""></asp:Label>
            <asp:GridView ID="gvVillage" AutoGenerateColumns="False" DataKeyNames="VILL_ID" runat="server" CssClass="table table-bordered table-hover "
                OnRowCommand="gvVillage_RowCommand"
                OnRowCreated="gvVillage_RowCreated" BackColor="" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="" />
                <Columns>



                    <asp:TemplateField HeaderText="Village Name">
                        <ItemTemplate>
                            <%# Eval("VILL_NM") %>
                            <%-- <a href="#" id="ViewDetails" ><%# DataBinder.Eval(Container.DataItem, "Village_Name") %></a>--%>
                            <%--<asp:LinkButton ID="lnkViewDetails" runat="server" Text='<%# Eval("VILL_NM") %>' data-id='<%# Eval("VILL_ID") %>'></asp:LinkButton>--%>
                            <%--  <asp:HyperLink ID="hypVillageName" runat="server"  Text='<%# Eval("Village_Name") %>'> 

                                                    </asp:HyperLink>--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <EmptyDataTemplate>
                    <span style="color: #459300;">Record(s) Not Available.</span>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#005529" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="pgr" BackColor="" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle CssClass="drow" Wrap="True" BackColor="" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
           
        </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                </div>
                <!-- /.panel -->

                <!-- /.panel -->

                <!-- /.panel .chat-panel -->
            </div>
            <!-- /.col-lg-3 -->
            <!-- /.col-lg-3 end naren-->




            <div class="footer">

                <div><strong>Copyright</strong> NTCA ©  2017 </div>
            </div>

        </div>


        <div id="container1">
            <style type="text/css">
                table, th, td {
                    border: 1px solid black;
                    border-collapse: collapse;
                    /*width: 100% !important;*/
                }

                    table tr td {
                        padding: 7px;
                    }
            </style>

            <script type="text/javascript">
                function DisplayVillage() {

                    $('#myModalVillage').modal('show');

                    return false;

                }


            </script>
            <%--Modal popu below--%>
            <div id="myModalVillage" class="modal fade" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Details</h4>
                        </div>
                        <div class="modal-body">

                            <table id="tbDetails" cellpadding="0" cellspacing="0">
                                <thead style="background-color: #005529; color: White; font-weight: bold">
                                    <tr style="border: solid 1px #000000">
                                        <%--<td>S.No</td>--%>
                                        <td>Tiger Reserve name</td>
                                        <td>State</td>
                                        <td style="display: none;">Village list</td>
                                        <td style="display: none;">Village relocate</td>
                                        <td style="display: none;">Village yet to relocate</td>

                                        <td>No of Villages in the notified Core(CTH)</td>
                                        <td>No of Families in the notified Core(CTH)</td>
                                        <td>No of Villages relocated from the Core(CTH) since the inception of the Project Tiger</td>
                                        <td>No of Families relocated from the Core(CTH) since the inception of the Project Tiger</td>
                                        <td>No.of Villages remaining inside the notified Core(CTH)</td>
                                        <td>No.of Families remaining inside the notified Core(CTH)</td>
                                        <td>10 Lakh per family</td>
                                        <td>1 Lakh per family</td>
                                        <td>Families relocated with any other package</td>
                                        <td>Remarks</td>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>
                            <label style="display: none;" id="LblMsg"></label>
                        </div>

                    </div>

                </div>
            </div>


            <script>
                // show all hidden place name --
                function show_all_state() {
                    transform = $('.highcharts-label').attr('transform');
                    var res = transform.slice(-8, -1);
                    var now = res.replace(",", ".");

                    var zoom_area = parseFloat(now);
                    var num = parseFloat(100.000);
                    var nout = parseFloat(240.581);
                    if (num <= zoom_area) {
                        $(".highcharts-label").removeAttr("opacity");
                        $(".highcharts-label").removeAttr("visibility");
                    }
                    if (nout <= zoom_area) {
                        $(".highcharts-label").removeAttr("opacity");
                        $(".highcharts-label").removeAttr("visibility");
                    }
                    $(window).load(function () {
                        show_all_state();
                    });
                }




                /*   $('.suddan').hover(function(){
                show_all_state();
              });*/
                $(document).on('hover', '.suddan', function () {
                    show_all_state();
                });
                $(document).on('mousemove', '.suddan', function () {
                    show_all_state();
                });
                $("text").hide();
                //$('#tbDetails').hide();
                //$('#txt').text('');

                var datawb;
                var nameSet;
                var latSet;
                var lonSet;
                var drilldownSets;
                var stateID;
                var MapStatID;
                var MapDistricID;
                var stateName;
                var HcKey;
                var varStatId = "<%=Session["sStateID"]%>";
            var varMapDistrictID = "<%=Session["sMapDistricID"]%>";
                var MapKeyvar = "<%=Session["sMapStatID"]%>";
                var VarTigerReserverID = "<%=Session["sTigerReserveid"]%>";
                var MapPassStateID = "<%=Session["sMapStatID"]%>";
                var UserType = "<%=Session["UserType"]%>";
                var UserID = "<%=Session["User_Id"]%>";
                var SateIDLogin = "<%=Session["PermissionState"]%>";
                var data = Highcharts.geojson(Highcharts.maps[MapPassStateID]),
                    separators = Highcharts.geojson(Highcharts.maps[MapPassStateID], 'mapline'),
                    // Some responsiveness
                    small = $('#container').width() < 400;


                $.each(data, function (i) {


                    this.drilldown = this.properties['hc-key'];
                    this.value = i; // Non-random bogus data

                    this.DistID = this.properties['ID_2'];
                    //alert(this.properties['ID_2']);
                    //this.Remarks = 'Valmik tiger<br>abc tiger reserver';
                    $('#ball_footballbox').html('');
                    if (UserType == "2") {
                        $('#LblTigerReserveShow').html('');
                        $('#ball_footballbox').html('');
                        var getStatID = $('#LblstateID').text();
                        var getMapStatID = $('#LblMapStatID').text();
                        getTigerReservesByDistricIDStateUser2(SateIDLogin, MapKeyvar, this.properties.ID_2);
                        this.Remarks = $('#LblTigerReserveShow').html();
                        this.DistrictIconImage = $('#ball_footballbox').html();
                    }
                    if (UserType == "3") {
                        
                        $('#LblTigerReserveShow').html('');
                        $('#ball_footballbox').html('');
                        var getStatID = $('#LblstateID').text();
                        var getMapStatID = $('#LblMapStatID').text();
                        getTigerReservesByDistricIDTigerUser3(SateIDLogin, MapKeyvar, UserID, this.properties.ID_2);
                        this.Remarks = $('#LblTigerReserveShow').html();
                        this.DistrictIconImage = $('#ball_footballbox').html();
                    }
                    if (UserType == "4") {
                       // alert('fdf');
                        if (this.properties.ID_2 == varMapDistrictID) {
                            $('#LblTigerReserveShow').html('');
                            $('#ball_footballbox').html('');

                            var getStatID = $('#LblstateID').text();
                            var getMapStatID = $('#LblMapStatID').text();
                            //getTigerReservesByDistricIDDtoperator(varStatId, MapKeyvar, varMapDistrictID, VarTigerReserverID);
                            getTigerReservesByDistricIDTigerUser33(SateIDLogin, MapKeyvar, UserID, this.properties.ID_2);
                            //return DisplayVillage();
                            this.Remarks = $('#LblTigerReserveShow').html();
                            this.DistrictIconImage = $('#ball_footballbox').html();
                        }

                        //else { alert("You don't have permisson to access this district!!"); }  
                    }
                });

                Highcharts.mapChart('container', {
                    chart: {
                        events: {
                            drilldown: function (e) {

                                try {
                                    if (!e.seriesOptions) {

                                        if (e.point.drilldown == MapKeyvar) {
                                            var chart = this,
                                                    mapKey = MapKeyvar;
                                            // alert(mapKey);
                                            debugger;
                                            //  alert(MapKeyvar);
                                            // getTigerReserves(0, mapKey);
                                            //  alert(e.point.name);

                                            if (mapKey == "in-ap" && e.point.name == "Telengana") {
                                                mapKey = "in-tl";

                                            } else if (mapKey == "in-ap" && e.point.name != "Telengana") {
                                                mapKey = "in-ap";
                                            }
                                            // Handle error, the timeout is cleared on success
                                            fail = setTimeout(function () {
                                                if (!Highcharts.maps[mapKey]) {
                                                    chart.showLoading('<i class="icon-frown"></i> Failed loading ' + e.point.name);
                                                    fail = setTimeout(function () {
                                                        chart.hideLoading();
                                                    }, 1000);
                                                }
                                            }, 3000);

                                            // Show the spinner
                                            chart.showLoading('<i class="icon-spinner icon-spin icon-3x"></i>'); // Font Awesome spinner

                                            // Load the drilldown map
                                            $.getScript('<%=ResolveUrl("~/js/data/") %>' + mapKey + '.js', function () {
                                            data = Highcharts.geojson(Highcharts.maps[mapKey]);
                                            // alert(JSON.stringify(data));

                                            $.each(data, function (i) {
                                                this.value = i;
                                                this.DistID = this.properties['ID_2'];
                                                //  alert(this.properties.ID_2);
                                                //if (typeof this.properties.ID_2 != 'undefined') {
                                                //    
                                                //    this.Remarks = "hghgh";
                                                //}
                                            });
                                            // Hide loading and add series
                                            chart.hideLoading();
                                            clearTimeout(fail);
                                            chart.addSeriesAsDrilldown(e.point, {
                                                name: e.point.name,
                                                data: data,
                                                dataLabels: {
                                                    enabled: true,
                                                    useHTML: true,
                                                    // format: '{point.name}'
                                                    format: '<br>{point.Remarks}{point.DistrictIconImage}'
                                                }, tooltip: {
                                                    enabled: true,
                                                    headerFormat: '',
                                                    // pointFormat: '{point.Remarks}'
                                                }
                                            });
                                        });

                                    }
                                    else { alert("You don't have permisson to access this state!!"); }
                                }//end
                                this.setTitle(null, { text: e.point.name });
                            } catch (err) {
                                alert(err)
                            }
                        },
                        drillup: function () {
                            this.setTitle(null, { text: '' });
                            $(".state-info-con").css("display", "none");
                            this.series.borderColor = '#000000';
                        },
                        load: function () {
                            show_all_state();
                        }
                    }
                },
                legend: {
                    enabled: false
                }, tooltip: {
                    enabled: false,
                },
                lang: {
                    drillUpText: "Back"
                },
                title: {
                    text: '',
                    floating: true,
                    align: 'left',
                    y: 2,
                    style: {
                        fontSize: '16px'
                    }
                },
                subtitle: {
                    text: '',
                    floating: true,
                    align: 'center',
                    y: 5,
                    style: {
                        fontSize: '16px'
                    }
                },
                legend: small ? {} : {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },
                colorAxis: {

                    min: 0,
                    minColor: '#005629',
                    maxColor: '#f7b000'
                },
                mapNavigation: {
                    enabled: false,
                    buttonOptions: {
                        verticalAlign: 'bottom'
                    }

                },
                plotOptions: {
                    map: {
                        states: {
                            hover: {
                                color: '#008000'
                            }
                        }
                    },
                    series: {
                        point: {
                            events: {
                                click: function () {
                                    // debugger;
                                    if (typeof this.properties.ID_2 != 'undefined') {
                                        //debugger;
                                        if (UserType == "2") {
                                            $('#tbDetails tbody').remove();
                                            var getStatID = $('#LblstateID').text();
                                            var getMapStatID = $('#LblMapStatID').text();
                                            getTigerReservesByDistricIDStateUser(SateIDLogin, MapKeyvar, this.properties.ID_2);
                                            return DisplayVillage();
                                        }
                                        if (UserType == "3") {
                                            $('#tbDetails tbody').remove();
                                            var getStatID = $('#LblstateID').text();
                                            var getMapStatID = $('#LblMapStatID').text();
                                            getTigerReservesByDistricIDTigerUser(SateIDLogin, MapKeyvar, UserID, this.properties.ID_2);
                                            return DisplayVillage();
                                        }
                                        if (UserType == "4") {


                                            if (this.properties.ID_2 == varMapDistrictID) {
                                                $('#tbDetails tbody').remove();
                                                var getStatID = $('#LblstateID').text();
                                                var getMapStatID = $('#LblMapStatID').text();
                                                getTigerReservesByDistricID(varStatId, MapKeyvar, varMapDistrictID, VarTigerReserverID);
                                                return DisplayVillage();
                                            }
                                            else { alert("You don't have permisson to access this district!!"); }
                                        }


                                    }


                                }, mouseOver: function () {

                                    show_all_state();

                                },
                                mouseOut: function () {
                                    show_all_state();
                                },
                                show: function () {

                                    show_all_state();
                                }
                            }
                        }
                    }
                },
                series: [{
                    data: data,
                    name: 'India',
                    borderColor: '#000000',
                    dataLabels: {
                        enabled: true,
                        useHTML: true,//India map Icon code
                        //format: '{point.properties.postal-code}'
                        format: '<br>{point.Remarks}{point.DistrictIconImage}'
                    }
                }],
                drilldown: {
                    activeDataLabelStyle: {
                        color: '#FFFFFF',
                        textDecoration: 'none',
                        textOutline: '1px #000000'
                    },
                    drillUpButton: {
                        relativeTo: 'spacingBox',
                        position: {
                            x: 0,
                            y: 60
                        }
                    }
                }
            });

            //start First function
            function getTigerReserves(stateID, vmapStatID) {
                debugger;
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/GetTigerReserveByStateID",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblstateID').text('');
                        $('#LblMapStatID').text('');



                        // alert(JSON.stringify(data));
                        for (var i = 0; i < data.d.length; i++) {
                            // $("#tbDetails").append("<tr><td>" + data.d[i].name + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");

                            $('#LblstateID').text(data.d[i].StateID);

                            $('#LblMapStatID').text(data.d[i].mapStatID);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            //end First function
            //second First function
            function getTigerReservesByDistricID(stateID, vmapStatID, ImapDistricID, TigerReserveID) {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/GetTigerReserveByDistrictID",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",mapDistricid:"' + ImapDistricID + '",TigerReserID:"' + TigerReserveID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            for (var i = 0; i < data.d.length; i++) {

                                //  $("#tbDetails").append("<tr><td>" + "<a href='Dashboard.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");
                                // $("#tbDetails").append("<tr><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].VillageList + "</td><td><b></b>" + data.d[i].RelocateVillageList + "</td><td><b></b>" + data.d[i].RelocateyetVillageList + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td></tr>");
                               // $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $("#tbDetails").append("<tr><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");

                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {


                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
                //previous GetTigerReserveByDistrictID
            function getTigerReservesByDistricIDDtoperator(stateID, vmapStatID, ImapDistricID, TigerReserveID) {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/GetTigerReserveByDistrictID",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",mapDistricid:"' + ImapDistricID + '",TigerReserID:"' + TigerReserveID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            for (var i = 0; i < data.d.length; i++) {

                                $("#LblTigerReserveShow").append(data.d[i].name + "<br>");
                                $("#ball_footballbox").append(data.d[i].DistrictIconImage + "<br>");

                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {


                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            //end second function
            //third function for tigeruser
            function getTigerReservesByDistricIDTigerUser(stateID, vmapStatID, ParentTigerReserveUserID, MapDistrictID) {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/GetTigerReserveByDistrictIDTigerUser",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",ParentTigerReserveUserID:"' + ParentTigerReserveUserID + '",MapDistrictID:"' + MapDistrictID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            for (var i = 0; i < data.d.length; i++) {

                                //   $("#tbDetails").append("<tr><td>" + "<a href='Dashboard.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");
                                // $("#tbDetails").append("<tr><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].VillageList + "</td><td><b></b>" + data.d[i].RelocateVillageList + "</td><td><b></b>" + data.d[i].RelocateyetVillageList + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td></tr>");

                               // $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + "<a href='Dashboard.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $("#tbDetails").append("<tr><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                // $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {


                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function getTigerReservesByDistricIDTigerUser3(stateID, vmapStatID, ParentTigerReserveUserID, MapDistrictID) {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/GetTigerReserveByDistrictIDTigerUser",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",ParentTigerReserveUserID:"' + ParentTigerReserveUserID + '",MapDistrictID:"' + MapDistrictID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            for (var i = 0; i < data.d.length; i++) {

                                $("#LblTigerReserveShow").append(data.d[i].name + "<br>");
                                $("#ball_footballbox").append(data.d[i].DistrictIconImage + "<br>");
                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {


                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function getTigerReservesByDistricIDTigerUser33(stateID, vmapStatID, ParentTigerReserveUserID, MapDistrictID) {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/GetTigerReserveByDistrictIDTigerUser33",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",ParentTigerReserveUserID:"' + ParentTigerReserveUserID + '",MapDistrictID:"' + MapDistrictID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            for (var i = 0; i < data.d.length; i++) {

                                $("#LblTigerReserveShow").append(data.d[i].name + "<br>");
                                $("#ball_footballbox").append(data.d[i].DistrictIconImage + "<br>");
                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {


                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }

                //end third function for tigerUser
            //start forth stateuser
            function getTigerReservesByDistricIDStateUser(stateID, vmapStatID, MapDistrictID) {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/GetTigerReserveByDistrictIDStateUser",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",MapDistrictID:"' + MapDistrictID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            for (var i = 0; i < data.d.length; i++) {

                                // $("#tbDetails").append("<tr><td>" + "<a href='Dashboard.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");
                                //  $("#tbDetails").append("<tr><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].VillageList + "</td><td><b></b>" + data.d[i].RelocateVillageList + "</td><td><b></b>" + data.d[i].RelocateyetVillageList + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td></tr>");

                               // $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + "<a href='Dashboard.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                              //  $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $("#tbDetails").append("<tr><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {


                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function getTigerReservesByDistricIDStateUser2(stateID, vmapStatID, MapDistrictID) {
                $.ajax({
                    type: "POST",
                    url: "Dashboard.aspx/GetTigerReserveByDistrictIDStateUser",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",MapDistrictID:"' + MapDistrictID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            for (var i = 0; i < data.d.length; i++) {

                                $("#LblTigerReserveShow").append(data.d[i].name + "<br>");
                                $("#ball_footballbox").append(data.d[i].DistrictIconImage + "<br>");
                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {


                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            //end forth stateuser
            </script>

        </div>

      </div>  
    </div>
</asp:Content>

