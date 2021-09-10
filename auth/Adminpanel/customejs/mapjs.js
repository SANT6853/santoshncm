var maplat_lag = "";
function callbackmap(response) {
    maplat_lag = response;
    //use return_first variable here
}
var loadMap = function () {
    $("#map").TekMap();

    $.ajax({
        type: "POST",
        url: "auth/Adminpanel/AjaxMethod.aspx/getMapCredentials",
        async: false,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
	               
            callbackmap(response.d);
        },
        failure: function (request, error) {
            alert(" Can't do because: " + error);
        }
    });



    $.each(JSON.parse(maplat_lag), function (idx, obj) {

        $("#map").TekMarker({
            lat: obj.latitude, lng: obj.longitude, draggable: true, drag: function (marker) { alert("a"); }, infowindow: "<div ><img src='images/fav/apple-icon-57x57.png' title='tiger' /> <a target='_blank' href='index.aspx?Tid=" + obj.TigerReserveID + "'>" + obj.TigerReserveName + "</a></div>",
        });
     
    });
}
