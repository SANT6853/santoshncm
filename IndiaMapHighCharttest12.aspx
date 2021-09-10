<%@ Page Title="" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="IndiaMapHighCharttest12.aspx.cs" Inherits="IndiaMapHighCharttest1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBanner" runat="Server">
    <style>
        .highcharts-credits {
            display: none;
        }

        .highcharts-button-symbol {
            display: none;
        }
       .highcharts-drillup-button{
           display: none;
       } 
        
       

    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="Server">
    <div>


       <%-- <script src="https://code.highcharts.com/maps/highmaps.js"></script>
        <script src="https://code.highcharts.com/maps/modules/data.js"></script>
        <script src="https://code.highcharts.com/maps/modules/drilldown.js"></script>
        <script src="https://code.highcharts.com/maps/modules/exporting.js"></script>
        <script src="https://code.highcharts.com/maps/modules/offline-exporting.js"></script>--%>

        <script src="<%=ResolveUrl("~/js/HcharNew/1highmaps.js") %>"></script>
        <script src="<%=ResolveUrl("~/js/HcharNew/2data.js") %>"></script>
        <script src="<%=ResolveUrl("~/js/HcharNew/3drilldown.js") %>"></script>
        <script src="<%=ResolveUrl("~/js/HcharNew/4exporting.js") %>"></script>
        <script src="<%=ResolveUrl("~/js/HcharNew/5offline-exporting.js") %>"></script>

        <script src="<%=ResolveUrl("~/js/data/in-all.js") %>"></script>
        <link href="<%=ResolveUrl("~/js/HcharNew/6font-awesome.css") %>" rel="stylesheet" />
       <%-- <link href="https://netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet" />--%>
    </div>
    <div id="container1">
        <style type="text/css">
table,th,td
{
border:1px solid black;
border-collapse:collapse;
}
</style>
        <table id="tbDetails" cellpadding="0" cellspacing="0">
<thead style="background-color:#DC5807; color:White; font-weight:bold">
<tr style="border:solid 1px #000000">
<td>Tiger reserve name</td>
<td>State</td>
<td>Village list</td>
    <td>Village relocate</td>
    <td>Village yet to relocate</td>
</tr>
</thead>
<tbody>
</tbody>
</table>

         <label id="txt"></label>
        <div id="container" style="height: 700px; min-width: 310px; max-width: 1000px; margin: 0 auto"></div>
       
        <script>
          
            $("text").hide();
            $('#tbDetails').hide();
            //$('#txt').text('');
            var datawb;
            var nameSet;
            var latSet;
            var lonSet;
            var drilldownSets;
            var stateID;
            var stateName;
            var HcKey;

           
            var data = Highcharts.geojson(Highcharts.maps['countries/in/in-all']),
                separators = Highcharts.geojson(Highcharts.maps['countries/in/in-all'], 'mapline'),
                // Some responsiveness
                small = $('#container').width() < 400;

            // var datawb;
            // Set drilldown pointers
            $.each(data, function (i) {

              //  this['hc-key'] = this.properties['hc-key'];
               // this['postal-code'] = this.properties['postal-code'];
                this.drilldown = this.properties['hc-key'];
                this.value = i; // Non-random bogus data



            });
          //  var xyz = { 'name': 'xyz' };
            // Instantiate the map
            Highcharts.mapChart('container', {

                chart: {
                    events: {
                        drilldown: function (e) {

                            if (!e.seriesOptions) {

                                var chart = this,
                                    //mapkey=countries/in/in-br-all means collect state data when click on map state
                                   mapKey = e.point.drilldown;
                                alert(e.point.name);
                                if (mapKey == "in-ap" && e.point.name == "Telengana") {
                                    mapKey = "in-tl";

                                } else if (mapKey == "in-ap" && e.point.name != "Telengana") {
                                    mapKey = "in-ap";
                                }

                                // Handle error, the timeout is cleared on success
                                fail = setTimeout(function () {

                                    if (!Highcharts.maps[mapKey]) {
                                        HcKey = '';
                                        chart.showLoading('<i class="icon-frown"></i> Failed loading ' + e.point.name);
                                        fail = setTimeout(function () {
                                            chart.hideLoading();
                                        }, 1000);
                                    }
                                }, 3000);

                                // alert(mapKey);
                                // alert(HcKey);
                                //  alert(JSON.stringify(datawb));
                                // Show the spinner
                                chart.showLoading('<i class="icon-spinner icon-spin icon-3x"></i>'); // Font Awesome spinner


                                // Load the drilldown map
                                $.getScript('../js/data/' + mapKey + '.js', function () {
                                    data = Highcharts.geojson(Highcharts.maps[mapKey]);

                                    $.each(data, function (i) {
                                        this.value = i;
                                      //  this.properties.copy = xyz.name;
                                    });
                                    // Hide loading and add series
                                    chart.hideLoading();
                                    clearTimeout(fail);
                                    chart.addSeriesAsDrilldown(e.point, {
                                        name: e.point.name,
                                        data: data,
                                        dataLabels: {
                                            enabled: true,
                                            format: '{point.name}'
                                        }

                                    });

                                    Highcharts.mapChart('container', {

                                        chart: {
                                            map: mapKey,
                                            resetZoomButton: {
                                                theme: {
                                                    display: 'none'
                                                }
                                            }
                                        },
                                        tooltip: {
                                            headerFormat: '',
                                            pointFormat: '<b>Village list:</b>{point.VillageList}<br><b>Relocate village list:</b>{point.RelocateVillageList}'
                                        },

                                        series: [{
                                            // Use the gb-all map with no data as a basemap
                                            name: 'Basemap',
                                            borderColor: '#A0A0A0',
                                            nullColor: 'rgb(40, 111, 98)',

                                            showInLegend: false
                                        }, {
                                            name: 'Separators',
                                            type: 'mapline',
                                            nullColor: '#707070',
                                            showInLegend: false,
                                            enableMouseTracking: false
                                        }
                                        ,
                                        {
                                            // Specify points using lat/lon
                                            //state list click event below  click: pointClick
                                            type: 'mappoint',
                                            showInLegend: false,
                                            point: {
                                                events: {
                                                    click: pointClick
                                                }

                                            },
                                            color: Highcharts.getOptions().colors[1],
                                           // data: datawb,
                                        }]
                                    });
                                });
                            }

                            this.setTitle(null, { text: e.point.name });
                        },
                        drillup: function () {
                            this.setTitle(null, { text: '' });
                        },

                    }
                },

                title: {
                    text: 'India Map'
                },

                subtitle: {
                    text: '',
                    floating: true,
                    align: 'right',
                    y: 50,
                    style: {
                        fontSize: '16px'
                    }
                },

                legend: false,


                colorAxis: {
                    min: 0,
                    minColor: '#E6E7E8',
                    maxColor: '#005645'
                },


                plotOptions: {
                    map: {
                        states: {
                            hover: {
                                color: '#EEDD66'
                            }
                        }
                    },
                    series: {
                        point: {
                            events: {
                                click: function () {

                                  //  alert(this.properties.copy);


                                }, mouseOver: function () {



                                },
                                mouseOut: function () {

                                },
                                show: function () {

                                    // show_all_state();
                                }
                            }
                        }
                    }
                },

                mapNavigation: {
                    enabled: true,
                    buttonOptions: {
                        verticalAlign: 'bottom'
                    }
                },
                series: [{
                    data: data,
                    name: 'India',
                    dataLabels: {
                        enabled: true,
                        format: '{point.properties.name}'
                    }
                }, {
                    type: 'mapline',
                    data: separators,
                    color: 'silver',
                    enableMouseTracking: false,
                    animation: {
                        duration: 500
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

            function getTigerReserves(stateID) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighCharttest1.aspx/GetTigerReserveByStateID",
                    async: false,
                    data: '{StateID: "' + stateID + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        for (var i = 0; i < data.d.length; i++) {
                            $("#tbDetails").append("<tr><td>" + data.d[i].name + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");
                            // debugger;
                            // alert(response.d);
                            //  datawb = response.d;
                            //$.each(JSON.parse(response.d), function (idx, obj) {

                            //    //radio = obj.status_id;
                            //    //comment = obj.comment;
                            //    nameSet = obj.name;
                            //    latSet = parseFloat(obj.lat).toFixed(5);
                            //    lonSet = parseFloat(obj.lon).toFixed(5);
                            //    drilldownSets = obj.drilldown;


                            //});
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
        </script>

    </div>
</asp:Content>

