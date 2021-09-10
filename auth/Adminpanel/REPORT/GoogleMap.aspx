<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="GoogleMap.aspx.cs" Inherits="auth_Adminpanel_REPORT_GoogleMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; background: #fff;">
        <div class="inner-content-right">
		
			<div class="widgets-container">
			<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Google Map</h3>
                    </div>                    
                </div>
			<div class="col-md-12">	
            <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-add pull-right" OnClick="BtnBack_Click" />


            <script src="http://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
            <script type="text/javascript">
                var markers = [
                <asp:Repeater ID="rptMarkers" runat="server">
                <ItemTemplate>
                         {
                             "title": '<%# Eval("Name") %>',
                             "lat": '<%# Eval("Latitude") %>',
                             "lng": '<%# Eval("Longitude") %>',
                             "description": '<%# Eval("Description") %>',
                             "type": '<%# Eval("type") %>'
                         }
    </ItemTemplate>
    <SeparatorTemplate>
        ,
    </SeparatorTemplate>
    </asp:Repeater>
                ];
            </script>
            <script type="text/javascript">
                window.onload = function () 
                {  
  
                    var mapOptions = {  
                        center: new google.maps.LatLng(markers[1].lat, markers[1].lng),  
                        zoom: 200,  
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
                            case "from":  
                                icon = "red";  
                                break;  
                            case "to":  
                                icon = "blue";  
                                break;  
                                //case "Mall":  
                                //    icon = "yellow";  
                                //    break;  
                                //case "Company":  
                                //    icon = "green";  
                                //    break;  
                        }  
                        icon = "http://maps.google.com/mapfiles/ms/icons/" + icon + ".png";  
                        var marker = new google.maps.Marker({  
                            position: myLatlng,  
                            map: map,  
                            title: data.title,  
                            animation: google.maps.Animation.BOUNCE,  
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
                //window.onload = function () 
                //{
                //    var mapOptions = {
                //        center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                //        zoom: 8,
                //        mapTypeId: google.maps.MapTypeId.ROADMAP
                //    };
                //    var infoWindow = new google.maps.InfoWindow();
                //    var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
                //    for (i = 0; i < markers.length; i++) {
                //        var data = markers[i]
                //        var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                //        var marker = new google.maps.Marker({
                //            position: myLatlng,
                //            map: map,
                //            title: data.title
                //        });
                //        (function (marker, data) {
                //            google.maps.event.addListener(marker, "click", function (e) {
                //                infoWindow.setContent(data.description);
                //                infoWindow.open(map, marker);
                //            });
                //        })(marker, data);
                //    }
                //}
        
            </script>

            <div style="text-align: center;">
                <img alt="" src="http://maps.google.com/mapfiles/ms/icons/red.png" />
                From address: (Village name:<asp:Label ID="LblFromVillage" runat="server"></asp:Label>,Lat:<asp:Label ID="LblFromLat" runat="server"></asp:Label>.Long:<asp:Label ID="LblFromLong" runat="server"></asp:Label> )  
    <img alt="" src="http://maps.google.com/mapfiles/ms/icons/blue.png" />
                Relocated To:(Village name:<asp:Label ID="LblToVillage" runat="server"></asp:Label>,Lat:<asp:Label ID="LbltoLat" runat="server"></asp:Label>.Long:<asp:Label ID="LblToLong" runat="server"></asp:Label> )  
        <hr />

            </div>
            </div>
			<div class="col-md-12">
            <div id="dvMap" style="width: 100%; height: 900px;">
            </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>

