<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testnew.aspx.cs" Inherits="testnew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #container {
    height: 680px;
    min-width: 310px;
    max-width: 800px;
    margin: 0 auto;
}
.loading {
    margin-top: 10em;
    text-align: center;
    color: gray;
}
    </style>
</head>
<body>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/proj4js/2.3.6/proj4.js"></script>
<script src="https://code.highcharts.com/maps/highmaps.js"></script>
<script src="https://code.highcharts.com/maps/modules/exporting.js"></script>
<script src="https://code.highcharts.com/maps/modules/offline-exporting.js"></script>
<script src="https://code.highcharts.com/mapdata/countries/gb/gb-all.js"></script>

<div id="container"></div>
    <script>

        // Initiate the chart
        Highcharts.mapChart('container', {

            chart: {
                map: 'countries/gb/gb-all'
            },

            title: {
                text: 'Highmaps basic lat/lon demo'
            },

            mapNavigation: {
                enabled: true
            },

            tooltip: {
                headerFormat: '',
                pointFormat: '<b>{point.name}</b><br>Lat: {point.lat}, Lon: {point.lon}'
            },

            series: [{
                // Use the gb-all map with no data as a basemap
                name: 'Basemap',
                borderColor: '#A0A0A0',
                nullColor: 'rgba(200, 200, 200, 0.3)',
                showInLegend: false
            }, {
                name: 'Separators',
                type: 'mapline',
                nullColor: '#707070',
                showInLegend: false,
                enableMouseTracking: false
            }, {
                // Specify points using lat/lon
                type: 'mappoint',
                name: 'Cities',
                color: Highcharts.getOptions().colors[1],
                data: [{
                    name: 'London',
                    lat: 51.507222,
                    lon: -0.1275
                }, {
                    name: 'Birmingham',
                    lat: 52.483056,
                    lon: -1.893611
                }, {
                    name: 'Leeds',
                    lat: 53.799722,
                    lon: -1.549167
                }, {
                    name: 'Glasgow',
                    lat: 55.858,
                    lon: -4.259
                }, {
                    name: 'Sheffield',
                    lat: 53.383611,
                    lon: -1.466944
                }, {
                    name: 'Liverpool',
                    lat: 53.4,
                    lon: -3
                }, {
                    name: 'Bristol',
                    lat: 51.45,
                    lon: -2.583333
                }, {
                    name: 'Belfast',
                    lat: 54.597,
                    lon: -5.93
                }, {
                    name: 'Lerwick',
                    lat: 60.155,
                    lon: -1.145,
                    dataLabels: {
                        align: 'left',
                        x: 5,
                        verticalAlign: 'middle'
                    }
                }]
            }]
        });

    </script>
    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" />
</body>
</html>
