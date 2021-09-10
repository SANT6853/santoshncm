<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testmap.aspx.cs" Inherits="auth_Adminpanel_Map_testmap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Mapjs.js?sensor=false"></script>
     <script type="text/javascript">
         var markers = [
             {
                 "title": 'Bombay Hospital',
                 "lat": '18.9409388',
                 "lng": '72.82819189999998',
                 "description": 'Bombay Hospital',
                 "type": 'Hospital'
             },
             {
                 "title": 'Jaslok Hospital',
                 "lat": '18.9716956',
                 "lng": '72.80991180000001',
                 "description": 'Jaslok Hospital',
                 "type": 'Hospital'
             },
             {
                 "title": 'Lilavati Hospital',
                 "lat": '19.0509488',
                 "lng": '72.8285644',
                 "description": 'Lilavati Hospital',
                 "type": 'Hospital'
             },
             {
                 "title": 'Aksa Beach',
                 "lat": '19.1759668',
                 "lng": '72.79504659999998',
                 "description": 'Aksa Beach',
                 "type": 'Beach'
             },
             {
                 "title": 'Juhu Beach',
                 "lat": '19.0883595',
                 "lng": '72.82652380000002',
                 "description": 'Juhu Beach',
                 "type": 'Beach'
             },
             {
                 "title": 'Girgaum Beach',
                 "lat": '18.9542149',
                 "lng": '72.81203529999993',
                 "description": 'Girgaum Beach',
                 "type": 'Beach'
             },
             {
                 "title": 'Oberoi Mall',
                 "lat": '19.1737704',
                 "lng": '72.86062400000003',
                 "description": 'Oberoi Mall',
                 "type": 'Mall'
             },
             {
                 "title": 'Infinity Mall',
                 "lat": '19.1846511',
                 "lng": '72.83454899999992',
                 "description": 'Infinity Mall',
                 "type": 'Mall'
             },
             {
                 "title": 'Phoenix Mall',
                 "lat": '19.0759837',
                 "lng": '72.87765590000003',
                 "description": 'Phoenix Mall',
                 "type": 'Mall'
             },
             {
                 "title": 'Phoenix Mall',
                 "lat": '19.0759837',
                 "lng": '72.87765590000003',
                 "description": 'Phoenix Mall',
                 "type": 'Mall'
             },
             {
                 "title": 'Hanging Garden',
                 "lat": '18.9560279',
                 "lng": '72.80538039999999',
                 "description": 'Hanging Garden',
                 "type": 'Park'
             },
             {
                 "title": 'Jijamata Udyan',
                 "lat": '18.979006',
                 "lng": '72.83388300000001',
                 "description": 'Jijamata Udyan',
                 "type": 'Park'
             }
             ,
             {
                 "title": 'Juhu Garden',
                 "lat": '19.0839704',
                 "lng": '72.83388300000001',
                 "description": 'Juhu Garden',
                 "type": 'Park'
             },
             {
                 "title": 'Sanjay Gandhi National Park',
                 "lat": '19.2147067',
                 "lng": '72.91062020000004',
                 "description": 'Sanjay Gandhi National Park',
                 "type": 'Park'
             }
         ];
         window.onload = function () {

             var mapOptions = {
                 center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                 zoom: 8,
                 mapTypeId: google.maps.MapTypeId.ROADMAP
             };
             var infoWindow = new google.maps.InfoWindow();
             var latlngbounds = new google.maps.LatLngBounds();
             var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
             var i = 0;
             var interval = setInterval(function () {
                 var data = markers[i]
                 var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                 var icon = "";
                 switch (data.type) {
                     case "Hospital":
                         icon = "red";
                         break;
                     case "Beach":
                         icon = "blue";
                         break;
                     case "Mall":
                         icon = "yellow";
                         break;
                     case "Park":
                         icon = "green";
                         break;
                 }

                 icon ="bluelocator.png";
                 var marker = new google.maps.Marker({
                     position: myLatlng,
                     map: map,
                     title: data.title,
                     animation: google.maps.Animation.DROP,
                     icon: new google.maps.MarkerImage(icon)
                 });
                 (function (marker, data) {
                     google.maps.event.addListener(marker, "click", function (e) {
                         infoWindow.setContent(data.description);
                         infoWindow.open(map, marker);
                     });
                 })(marker, data);
                 latlngbounds.extend(marker.position);
                 i++;
                 if (i == markers.length) {
                     clearInterval(interval);
                     var bounds = new google.maps.LatLngBounds();
                     map.setCenter(latlngbounds.getCenter());
                     map.fitBounds(latlngbounds);
                 }
             }, 80);
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
   
<table>
<tr>
    <td>
        <div id="dvMap" style="width: 500px; height: 500px">
        </div>
    </td>
    <td valign="top">
        <u>Legend:</u><br />
        <img src="bluelocator.png" />
       
        Hospitals<br />
        <img alt="" src="http://maps.google.com/mapfiles/ms/icons/blue.png" />
        Beaches<br />
        <img alt="" src="http://maps.google.com/mapfiles/ms/icons/yellow.png" />
        Malls<br />
        <img alt="" src="http://maps.google.com/mapfiles/ms/icons/green.png" />
        Parks<br />
    </td>
</tr>
</table>
    </form>
</body>
</html>
