<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpage.aspx.cs" Inherits="testpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.highcharts.com/maps/highmaps.js"></script>
<script src="https://code.highcharts.com/maps/modules/exporting.js"></script>
<script src="https://code.highcharts.com/mapdata/countries/in/in-all.js"></script>
    <style>
        #container {
    height: 500px; 
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
    <form id="form1" runat="server">
    <div id="container"></div>
        <script>

            // Prepare demo data
            // Data is joined to map using value of 'hc-key' property by default.
            // See API docs for 'joinBy' for more info on linking data and map.
            var data = [
                ['in-py', 0],
                ['in-ld', 1],
                ['in-wb', 2],
                ['in-or', 3],
                ['in-br', 4],
                ['in-sk', 5],
                ['in-ct', 6],
                ['in-tn', 7],
                ['in-mp', 8],
                ['in-2984', 9],
                ['in-ga', 10],
                ['in-nl', 11],
                ['in-mn', 12],
                ['in-ar', 13],
                ['in-mz', 14],
                ['in-tr', 15],
                ['in-3464', 16],
                ['in-dl', 17],
                ['in-hr', 18],
                ['in-ch', 19],
                ['in-hp', 20],
                ['in-jk', 21],
                ['in-kl', 22],
                ['in-ka', 23],
                ['in-dn', 24],
                ['in-mh', 25],
                ['in-as', 26],
                ['in-ap', 27],
                ['in-ml', 28],
                ['in-pb', 29],
                ['in-rj', 30],
                ['in-up', 31],
                ['in-ut', 32],
                ['in-jh', 33]
            ];

            // Create the chart
            Highcharts.mapChart('container', {
                chart: {
                    map: 'countries/in/in-all'
                },

                title: {
                    text: 'Highmaps basic demo'
                },

                subtitle: {
                    text: 'Source map: <a href="http://code.highcharts.com/mapdata/countries/in/in-all.js">India</a>'
                },

                mapNavigation: {
                    enabled: true,
                    buttonOptions: {
                        verticalAlign: 'bottom'
                    }
                },

                colorAxis: {
                    min: 0
                },

                series: [{
                    data: data,
                    name: 'Random data',
                    states: {
                        hover: {
                            color: '#BADA55'
                        }
                    },
                    dataLabels: {
                        enabled: true,
                        format: '{point.id}'
                    }
                }]
            });

    </script>
    </form>
</body>
</html>
