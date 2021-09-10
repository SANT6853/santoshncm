<%@ Page Title="" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="IndiaMapHighChart.aspx.cs" Inherits="IndiaMapHighChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBanner" runat="Server">
    <style>
        .highcharts-credits {
            display: none;
        }

        /*.highcharts-label {
            opacity: 100 !important;
        }*/

        #ImgTiger {
            border-radius: 50%;
        }

        #theImg {
            border-radius: 50%;
        }

        .highcharts-label span {
            color: black !important;
			cursor: pointer;
        }
        /* default button hide*/
        /*.highcharts-button-symbol,.highcharts-button {
            display: none;
        }*/
        /*.highcharts-legend-item highcharts-undefined-series highcharts-color-undefined
        {
            display: none;
        }*/
        /*.highcharts-drillup-button{
           display: none;
       }*/
        .modal-dialog {
            width: 80% !important;
        }

        .highcharts-contextbutton, .highcharts-color-undefined {
            display: none;
        }
		.modal-body{
			overflow-x: auto !important;
		}
		 path{
          cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="Server">
    <div>




        <script src="<%=ResolveUrl("~/js/HcharNew/1highmaps.js") %>"></script>
        <script src="<%=ResolveUrl("~/js/HcharNew/2data.js") %>"></script>
        <script src="<%=ResolveUrl("~/js/HcharNew/3drilldown.js") %>"></script>
        <script src="<%=ResolveUrl("~/js/HcharNew/4exporting.js") %>"></script>
        <script src="<%=ResolveUrl("~/js/HcharNew/5offline-exporting.js") %>"></script>

        <script src="<%=ResolveUrl("~/js/data/in-all.js") %>"></script>
        <link href="<%=ResolveUrl("~/js/HcharNew/6font-awesome.css") %>" rel="stylesheet" />

    </div>
    <div id="container1" class="bigfacebg">
        <style type="text/css">
            table, th, td {
                border: 1px solid black;
                border-collapse: collapse;
                /*width: 100% !important;*/
            }
        </style>

        <script type="text/javascript">
            function DisplayVillage() {

                $('#myModalVillage').modal('show');

                return false;
            }
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
            $(document).ready(function () {
                $('#LblTigerReserveShow').hide();
                $('#ball_footballbox').hide();
                show_all_state();
                ////  alert("\"amit\""+"\"ajit\""+'\'ffff\'');
                //$(window).load(function () {
                //    var d = ("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img id=" + "\"ImgTiger\"" + " src=" + "\"./images/ttt.jpg\"" + " width=" + "\"25px\"" + ">")
                //    // alert(d);
                //    $('div.highcharts-drilldown-data-label').find('span').each(function () {
                //        var ch = ($(this).html());
                //        console.log(ch);

                //        if (ch == d) {
                //            $(this).html('');

                //        }
                //    })
                //});


            });
        </script>

        <%--Start India map Icon code--%>
        <label id="LblBihar" style="display: none;"></label>
        <label id="LblAndamanNicobarStateName" style="display: none;"></label>
        <label id="LblAndhraPradeshStateName" style="display: none;"></label>
        <label id="LblArunachalPradeshStateName" style="display: none;"></label>
        <label id="LblAssamStateName" style="display: none;"></label>
        <label id="LblChhattisgarhStateName" style="display: none;"></label>
        <label id="LblChandigarhStateName" style="display: none;"></label>
        <label id="LblDamanDiuStateName" style="display: none;"></label>
        <label id="LblDelhiStateName" style="display: none;"></label>
        <label id="LblDadraHaveliStateName" style="display: none;"></label>
        <label id="LblGoaStateName" style="display: none;"></label>
        <label id="LblGujaratStateName" style="display: none;"></label>
        <label id="LblHimachalPradeshStateName" style="display: none;"></label>
        <label id="LblHaryanaStateName" style="display: none;"></label>
        <label id="LblJammuKashmirStateName" style="display: none;"></label>
        <label id="LblJharkhandStateName" style="display: none;"></label>
        <label id="LblKeralaStateName" style="display: none;"></label>
        <label id="LblKarnatakaStateName" style="display: none;"></label>
        <label id="LblLakshadweepStateName" style="display: none;"></label>
        <label id="LblMeghalayaStateName" style="display: none;"></label>
        <label id="LblMaharashtraStateName" style="display: none;"></label>
        <label id="LblManipurStateName" style="display: none;"></label>
        <label id="LblMadhyaPradeshStateName" style="display: none;"></label>
        <label id="LblMizoramStateName" style="display: none;"></label>
        <label id="LblNagalandStateName" style="display: none;"></label>
        <label id="LblOrissaStateName" style="display: none;"></label>
        <label id="LblPunjabStateName" style="display: none;"></label>
        <label id="LblPuducherryStateName" style="display: none;"></label>
        <label id="LblRajasthanStateName" style="display: none;"></label>
        <label id="LblSikkimStateName" style="display: none;"></label>
        <label id="LblTamilNaduStateName" style="display: none;"></label>
        <label id="LblTripuraStateName" style="display: none;"></label>
        <label id="LblUttarakhandStateName" style="display: none;"></label>
        <label id="LblUttarPradeshStateName" style="display: none;"></label>
        <label id="LblWestBengalStateName" style="display: none;"></label>
        <label id="LblTelenganaStateName" style="display: none;"></label>
        <label id="LblCheckDt" style="display: none;"></label>
        <label id="LblCheckDt1" style="display: none;"></label>

        <%--Start India map Icon code--%>

        <%--<asp:LinkButton ID="lnlviewvillageDetails" OnClientClick="return DisplayVillage();"   runat="server" CssClass="btn btn-info btn-mg" ><i class="fa glyphicon glyphicon-th-list">View</i></asp:LinkButton>--%>
        <div id="myModalVillage" class="modal fade" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">
                            <label id="LblHeading"></label>
                        </h4>
                    </div>
                    <div class="modal-body">

                        <table id="tbDetails" cellpadding="0" cellspacing="0" style="">
                            <thead style="background-color: #005529; color: White; font-weight: bold">
                                <tr style="border: solid 1px #000000">
                                   <%-- <td>S.No</td>--%>
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

                        <div id="tbDetails1"></div>
                        <label style="display: none;" id="LblMsg"></label>
                        <div id="tbDetails11"></div>
                        <%--<table id="tbDetails1">
                            
                            <tbody>
                            </tbody>
                        </table>--%>

                        
                    </div>

                </div>

            </div>
        </div>


       <!-- <a onclick="javascript: window.print()" title="Print" href="javascript: void(0)">
            <p class="glyphicon glyphicon-print  print">
            </p>
        </a>-->
        <%-- <img id="ImgDistric"  width="25px">--%>
       <%-- <div class="ball_footballbox"></div>--%>
        <label id="ball_footballbox"></label>
        <label id="LblTigerReserveShow"></label>

        <label id="txt"></label>

        <label style="display: none;" id="LblstateID"></label>
        <label style="display: none;" id="LblMapStatID"></label>
        <label style="display: none;" id="LblMapDistricID"></label>
        <%--  //start show back button--%>
        <%-- <div style=" float:right;">
                             <button type="submit" id="BtnBack"  value="Back">Back</button>
                               
                          </div>
                            <label id="BtnBackValues" style="display:none;"></label>--%>
        <%-- //start show back button--%>
        <div id="container" style="height: 950px; min-width: 310px; max-width: 1200px; margin: 0 auto"></div>

        <script>
            //start show back button
            $(document).ready(function () {
                //  alert('fdfd');
                show_all_state();
                //if ($('#BtnBackValues').text() == "") {

                //    $('#BtnBack').hide();
                //}
                //else {
                //    $('#BtnBack').show();
                //}
            });
            //$('#BtnBackValues').click(function () {
            //    var d = ("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img id=" + "\"ImgTiger\"" + " src=" + "\"./images/ttt.jpg\"" + " width=" + "\"25px\"" + ">")
            //    $('div.highcharts-drilldown-data-label').find('span').each(function () {
            //        var ch = ($(this).html());
            //        console.log(ch);

            //        // var d=ch
            //        if (ch == d) {
            //            $(this).html('');

            //        }
            //    })
            //});
            //end show back button
            // --Start India map Icon code--
          
            //End India map Icon code

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
            //-------------------------------------------
            //function show_all_state() {


            //    $('.highcharts-label').css("opacity", "100 !important;");

            //    transform = $('.highcharts-label').attr('transform');
            //    transform_css = $('div.highcharts-drilldown-data-label').attr('style');

            //    left1 = transform_css.slice(26, 29);

            //    top1 = transform_css.slice(38, 41);

            //    //110, 10 
            //    //961,100
            //    console.log(left1, top1);

            //    left12_zoom_now = parseInt(left1);
            //    top12 = parseInt(top1);
            //    var num_left = parseInt(961);
            //    var nout_top = parseInt(100);



            //    var res = transform.slice(-8, -1);
            //    var now = res.replace(",", ".");



            //    var zoom_area = parseFloat(now);
            //    var num = parseFloat(100.000);
            //    var nout = parseFloat(240.581);

            //    //if (num_left <= left12_zoom_now) {

            //    //}
            //    //if (top12 <)
            //    //{

            //    //}
            //    // 5 min ok ok

            //    if (num <= zoom_area) {
            //        $(".highcharts-label").removeAttr("opacity");
            //        $(".highcharts-label").removeAttr("visibility");
            //    }
            //    if (nout <= zoom_area) {
            //        $(".highcharts-label").removeAttr("opacity");
            //        $(".highcharts-label").removeAttr("visibility");
            //    }

            //    $(window).load(function () {
            //        show_all_state();
            //    });

            //}

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
            var lock = true;
            var preVal = null;
            var data = Highcharts.geojson(Highcharts.maps['countries/in/in-all']),       
                separators = Highcharts.geojson(Highcharts.maps['countries/in/in-all'], 'mapline'),
                // Some responsiveness
                small = $('#container').width() < 400;         
            // var datawb;
            // Set drilldown pointers
            $.each(data, function (i) {

                // this['hc-key'] = this.properties['hc-key'];
                // this['postal-code'] = this.properties['postal-code'];
                this.drilldown = this.properties['hc-key'];
                this.value = i; // Non-random bogus data

              //  alert("statename:" + this.properties.name + "  postal code:" + this.properties['postal-code']);
                // alert(this.properties.name);
               // alert(this.properties['postal-code']);
                // alert(JSON.stringify(data));
                //alert(this.properties['postal-code']);

                //Start India map Icon code
                // alert(this.properties['postal-code']);

                if (this.properties['postal-code'] == "BR") {

                    funCheckStateRecordExistanceBihar(this.properties.name);
                    // alert($('#LblBihar').text());
                    if ($('#LblBihar').text() == "") {
                        this.properties['DataImage'] = "";
                        //tooltip();
                    }
                }
                if (this.properties['postal-code'] == "AP") {
                    funChkRecordExistInStateAndhraPradesh(this.properties.name);
                    if ($('#LblAndhraPradeshStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "AN") {/////////////
                    funChkRecordExistInStateAndamanNicobar(this.properties.name);
                    if ($('#LblAndamanNicobarStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "AR") {
                    funChkRecordExistInStateArunachalPradesh(this.properties.name);
                    if ($('#LblArunachalPradeshStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "AS") {
                    funChkRecordExistInStateAssam(this.properties.name);
                    if ($('#LblAssamStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "CT") {
                    funChkRecordExistInStateChhattisgarh(this.properties.name);
                    if ($('#LblChhattisgarhStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "CH") {

                    funChkRecordExistInStateChandigarh(this.properties.name);
                    if ($('#LblChandigarhStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "3464") {

                    funChkRecordExistInStateDamanDiu(this.properties.name);
                    // alert($('#LblDamanDiuStateName').text());
                    if ($('#LblDamanDiuStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "DL") {
                    funChkRecordExistInStateDelhi(this.properties.name);
                    if ($('#LblDelhiStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "DN") {
                    funChkRecordExistInDadraHaveliStateName(this.properties.name);
                    // alert($('#LblDadraHaveliStateName').text());
                    if ($('#LblDadraHaveliStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "GA") {

                    funChkRecordExistInGoaStateName(this.properties.name);
                    if ($('#LblGoaStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "2984") {
                    // alert(this.properties['postal-code']);
                    funChkRecordExistInGujaratStateName(this.properties.name);
                    if ($('#LblGujaratStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "HP") {
                    funChkRecordExistInHimachalPradeshStateName(this.properties.name);
                    if ($('#LblHimachalPradeshStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "HR") {
                    funChkRecordExistInHaryanaStateName(this.properties.name);
                    if ($('#LblHaryanaStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "JK") {
                    funChkRecordExistInJammuKashmirStateName(this.properties.name);
                    if ($('#LblJammuKashmirStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "JH") {
                    funChkRecordExistInJharkhandStateName(this.properties.name);
                    if ($('#LblJharkhandStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "KL") {/////////////////
                    funChkRecordExistInKeralaStateName(this.properties.name);
                    if ($('#LblKeralaStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "KA") {
                    funChkRecordExistInKarnatakaStateName(this.properties.name);
                    if ($('#LblKarnatakaStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "LD") {///////////////////
                    funChkRecordExistInLakshadweepStateName(this.properties.name);
                    if ($('#LblLakshadweepStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "ML") {
                    funChkRecordExistInMeghalayaStateName(this.properties.name);
                    if ($('#LblMeghalayaStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "MH") {
                    funChkRecordExistInMaharashtraStateName(this.properties.name);
                    if ($('#LblMaharashtraStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "MN") {
                    funChkRecordExistInManipurStateName(this.properties.name);
                    if ($('#LblManipurStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "MP") {
                    funChkRecordExistInMadhyaPradeshStateName(this.properties.name);
                    if ($('#LblMadhyaPradeshStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "MZ") {
                    funChkRecordExistInMizoramStateName(this.properties.name);
                    if ($('#LblMizoramStateName').text() == "")
                    {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "NL") {
                    funChkRecordExistInNagalandStateName(this.properties.name);
                    if ($('#LblNagalandStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "OR") {
                    funChkRecordExistInOrissaStateName(this.properties.name);
                    if ($('#LblOrissaStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "PB") {
                    funChkRecordExistInPunjabStateName(this.properties.name);
                    if ($('#LblPunjabStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "PY") {///////////////////////

                    funChkRecordExistInPuducherryStateName(this.properties.name);

                    if ($('#LblPuducherryStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "RJ") {
                    funChkRecordExistInRajasthanStateName(this.properties.name);
                    if ($('#LblRajasthanStateName').text() == "") {
                        ///tooltip();
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "SK") {
                    funChkRecordExistInSikkimStateName(this.properties.name);
                    if ($('#LblSikkimStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "TN") {/////////////////

                    funChkRecordExistInTamilNaduStateName(this.properties.name);
                     // alert($('#LblTamilNaduStateName').text());
                    if ($('#LblTamilNaduStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                    else
                    {
                       // alert(this.properties['DataImage']);
                        this.properties['DataImage'] = ""+"<img id='ImgTiger' src='./images/ttt.jpg' width='25px'  />";
                    }
                }
                if (this.properties['postal-code'] == "TR") {
                    funChkRecordExistInTripuraStateName(this.properties.name);
                    if ($('#LblTripuraStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "UT") {

                    funChkRecordExistInUttarakhandStateName(this.properties.name);
                    if ($('#LblUttarakhandStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "UP") {
                    funChkRecordExistInStateUp(this.properties.name);
                    if ($('#LblUttarPradeshStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }

                if (this.properties['postal-code'] == "WB") {
                    funChkRecordExistInWestBengalStateName(this.properties.name);
                    if ($('#LblWestBengalStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }
                if (this.properties['postal-code'] == "TL") {
                  
                    funChkRecordExistInTelenganaStateName(this.properties.name);
                    if ($('#LblTelenganaStateName').text() == "") {
                        this.properties['DataImage'] = "";
                    }
                }

                //Start India map Icon code


            });
            //  var xyz = { 'name': 'xyz' };
            // Instantiate the map
            Highcharts.mapChart('container', {
                
                
                chart: {

                    events: {
                        drilldown: function (e) {
                            
                           
                            try {
                                if (!e.seriesOptions) {
                                    var chart = this,
                                            mapKey = e.point.drilldown;
                                    // alert(mapKey);
                                    // debugger;

                                    //start show back button
                                    //$('#BtnBackValues').text('dfdfdf');
                                    //end show back button
                                   // getTigerReserves(0, mapKey);


                                    if (mapKey == "in-ap" && e.point.name == "Telengana") {
                                        mapKey = "in-tl";

                                    } else if (mapKey == "in-ap" && e.point.name != "Telengana") {
                                        mapKey = "in-ap";
                                    }
                                    getTigerReserves(0, mapKey);
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
                                      
                                        $.each(data, function (i)
                                        {
                                          // alert('fd');
                                            //  debugger;
                                            this.value = i;
                                            this.DistID = this.properties['ID_2'];
                                            //  alert(this.properties.ID_2);
                                            //if (typeof this.properties.ID_2 != 'undefined')
                                            //{
                                            //    if (this.properties.ID_2 == 68) {

                                            //        this.Remarks = 'Valmik tiger<br>abc tiger reserver';
                                            //    }

                                            //}                             

                                            if (typeof this.properties.ID_2 != 'undefined') {
                                                //  $('#tbDetails tbody').remove(); bind tiger reserve on district map

                                               // alert(this.properties.ID_2);
                                                $('#LblTigerReserveShow').html('');
                                                $('#ball_footballbox').html('');

                                                var getStatID = $('#LblstateID').text();
                                                var getMapStatID = $('#LblMapStatID').text();
                                               
                                                getTigerReservesByDistricIDOnShow(getStatID, getMapStatID, this.properties.ID_2);
                                                // DisplayVillage();

                                                this.Remarks = $('#LblTigerReserveShow').html();
                                                this.DistrictIconImage = $('#ball_footballbox').html();

                                                //if ($('#LblTigerReserveShow').html() == "")
                                                //{
                                                //    this.Remarks = $('#LblTigerReserveShow').html();
                                                //}
                                                //else {
                                                //    this.Remarks = $('#LblTigerReserveShow').html().append($('.ball_footballbox').html());
                                                //}

                                                //this.Remarks = $('#LblTigerReserveShow').html();
                                                //this.DistrictIconImage = $('.ball_footballbox').html();
                                              //  alert($('.ball_footballbox').html());
                                            }
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
                                                format: '<br>{point.Remarks}{point.DistrictIconImage}'
                                            }, tooltip: {
                                                enabled: true,
                                                headerFormat: '',
                                          
                                                // pointFormat: '{point.Remarks}'
                                            }
                                        });
                                       
                                        tooltip();
                                    });
                                }
                                this.setTitle(null, { text: e.point.name });
                            } catch (err) {
                                alert(err)
                            }
                        },
                        drillup: function () {
                           
                            
                            this.setTitle(null, { text: '' });
                            $(".state-info-con").css("display", "none");
                            this.series.borderColor = '#000000';
                            window.location.href = '<%=ResolveUrl("~/IndiaMapHighChart.aspx")%>';
                        },
                        load: function () {

                            show_all_state();
                           
                            // StateExtraText();

                        }
                    }
                },
              
           
                legend: {
                    enabled: false

                }, tooltip: {
                    enabled: false
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
                    enabled: false,//enabled=true zooming enabled
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
                                   // alert('fff');
                                    //click on districmap click on show popu code
                                    if (typeof this.properties.ID_2 != 'undefined') {
                                        // alert(this.properties.ID_2);

                                        //26july
                                         funjsChkNoRecordFoundClickCreateDataOperator(this.properties.ID_2);
                                         funjsChkNoRecordFoundClickCreateDataOperatorUserPemission(this.properties.ID_2);
                                        //end
                                        $('#tbDetails tbody').remove();
                                        $('#tbDetails1 tbody').remove();
                                        var getStatID = $('#LblstateID').text();
                                        var getMapStatID = $('#LblMapStatID').text();
                                        getTigerReservesByDistricID(getStatID, getMapStatID, this.properties.ID_2);
                                        return DisplayVillage();
                                    }


                                }, mouseOver: function () {

                                    
                                    show_all_state();
                                },
                                mouseOut: function () {

                                    show_all_state();
                                },
                                mouseleave: function () {



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
                          format: '{point.name}{point.properties.DataImage}'//India map Icon code
                      //  format: '{point.properties.DataImage}'//India map Icon code
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
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/GetTigerReserveByStateIDgetTigerReserves",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblstateID').text('');
                        $('#LblMapStatID').text('');
                        //start show back button
                        //if ($('#BtnBackValues').text() == "") {
                        //    alert('fdf');
                        //    $('#BtnBack').hide();
                        //}
                        //else {
                        //    $('#BtnBack').show();
                        //}
                        //end show back button


                        // alert(JSON.stringify(data));
                        for (var i = 0; i < data.d.length; i++) {
                            // $("#tbDetails").append("<tr><td>" + data.d[i].name + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");

                            $('#LblstateID').text(data.d[i].StateID);

                            $('#LblMapStatID').text(data.d[i].mapStatID);


                            // alert();
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
            //end First function
            //second First function
            function getTigerReservesByDistricID(stateID, vmapStatID, ImapDistricID) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/GetTigerReserveByDistrictID",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",mapDistricid:"' + ImapDistricID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        // debugger;

                       //  alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            //19july
                            $('#LblHeading').text('');
                            $('#tbDetails1').text('');
                            $('#tbDetails11').text('');
                            for (var i = 0; i < data.d.length; i++) {
                              
                                // $("#tbDetails").append("<tr><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].VillageList + "</td><td><b></b>" + data.d[i].RelocateVillageList + "</td><td><b></b>" + "</td><td><b></b>" + data.d[i].RelocateyetVillageList + "</td><td><b></b>" + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + "</td></tr>");
                                // $("#tbDetails").append("<tr><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].VillageList + "</td><td><b></b>" + data.d[i].RelocateVillageList + "</td><td><b></b>" + data.d[i].RelocateyetVillageList + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td></tr>");
                                //  $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                // $("#tbDetails1").append("<tr><td><b></b></td><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b></td><td><b></b></td><td><b></b></td><td><b></b></td><td><b></b></td><td><b></b></td><td><b></b></td><td><b></b></td><td><b></b></td><td><b></b></td><td><b></b></td></tr>");

                                //  $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $("#tbDetails").append("<tr><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $("#tbDetails1").append("<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "&TigerreserveName=" + data.d[i].name+"'>" + "Click Here to Login" + "</a>");

                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                                //19july--------
                                $('#LblHeading').text(data.d[i].name);
                            }
                        }
                        else {

                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            //19july
                            $('#LblHeading').text('');
                            $('#tbDetails1').text('');
                            $('#tbDetails11').text('');
                            ///-------------
                            $('#tbDetails1').text('');
                            $('#tbDetails11').text('');
                            // $('#LblstateID')
                            var chkdt = $('#LblCheckDt').html();
                            var chkdt1 = $('#LblCheckDt1').html();
                           // alert(chkdt1);
                            if (chkdt == "") {
                               // alert('blank');
                                // $('#tbDetails11').hide();
                                if (chkdt1 == "")
                                {
                                   // alert('ffff');
                                    $('#tbDetails11').text('');
                                    // $('#tbDetails11').hide();
                                    //$('#myModalVillage').remove();
                                }
                              
                            }
                            if (chkdt == "") {
                               // alert('blank');
                                // $('#tbDetails11').hide();
                                if (chkdt1 != "") {
                                   // alert('fd');
                                    var stateidvar = $('#LblstateID').html();
                                    $("#tbDetails11").append("<a href='index.aspx?StateID=" + stateidvar + "&MapStatID=0&MapDistricID=0&TigerReserveid=0&DataOperatorUserID=0'>" + "Click Here to Login from tiger reserve" + "</a>");
                                }
                              
                            }
                            if (chkdt != "") {
                                // alert('blank');
                                // $('#tbDetails11').hide();
                                if (chkdt1 != "") {
                                    $('#tbDetails11').text('');
                                    //$('#tbDetails11').hide();
                                }

                            }
                            //else
                            //{
                            //   // var stateidvar = $('#LblstateID').html();
                            //    // alert(stateidvar);
                            //  //  $("#tbDetails11").append("<a href='index.aspx?StateID=" + stateidvar + "&MapStatID=0&MapDistricID=0&TigerReserveid=0&DataOperatorUserID=0'>" + "Click Here to Login create dataoperator" + "</a>");
                            //    alert('notblank');
                               
                            //}
                            $('#tbDetails tbody').remove();
                            $('#tbDetails1 tbody').remove();
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
            //Start third function
            //GetTigerReserveByDistrictID
            function getTigerReservesByDistricIDOnShow(stateID, vmapStatID, ImapDistricID) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/GetTigerReserveByDistrictIDgetTigerReservesByDistricIDOnShow",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",mapDistricid:"' + ImapDistricID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        // debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                           // $('.ball_footballbox').html('');
                            for (var i = 0; i < data.d.length; i++) {

                                //alert(JSON.stringify(data));
                                $("#LblTigerReserveShow").append(data.d[i].name + "<br>");
                              //  $('.ball_footballbox').prepend('<img id="theImg" src="./images/ttt.jpg" prepended="yes" width="25px"/>')
                                $("#ball_footballbox").append(data.d[i].DistrictIconImage + "<br>");


                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                               // $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {

                           // $('.ball_footballbox').html('');
                            $('#tbDetails tbody').remove();
                            $('#tbDetails1 tbody').remove();
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
            //End third function

            // Start India map Icon code
            function funCheckStateRecordExistanceBihar(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateBihar",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblBihar').text('');

                        for (var i = 0; i < data.d.length; i++) {

                            // alert(JSON.stringify(data.d));
                            //alert(JSON.stringify(data.d[i].AndamanNicobarStateName));

                            $('#LblBihar').text(data.d[i].BiharStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateUp(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateUp",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        //$('#LblUttarPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblUttarPradeshStateName').text(data.d[i].UttarPradeshStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateAndamanNicobar(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateAndamanNicobar",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblAndamanNicobarStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblAndamanNicobarStateName').text(data.d[i].AndamanNicobarStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateAndhraPradesh(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateAndhraPradesh",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblAndhraPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {

                            $('#LblAndhraPradeshStateName').text(data.d[i].AndhraPradeshStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateArunachalPradesh(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateArunachalPradesh",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblArunachalPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblArunachalPradeshStateName').text(data.d[i].ArunachalPradeshStateName);

                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateAssam(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateAssam",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblBihar').text('');

                        $('#LblAssamStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblAssamStateName').text(data.d[i].AssamStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateChhattisgarh(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateChhattisgarh",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblChhattisgarhStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblChhattisgarhStateName').text(data.d[i].ChhattisgarhStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateChandigarh(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateChandigarh",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblChandigarhStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblChandigarhStateName').text(data.d[i].ChandigarhStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateDamanDiu(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateDamanDiu",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblDamanDiuStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblDamanDiuStateName').text(data.d[i].DamanDiuStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateDelhi(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInStateDelhi",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblDelhiStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblDelhiStateName').text(data.d[i].DelhiStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInDadraHaveliStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInDadraHaveliStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblDadraHaveliStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblDadraHaveliStateName').text(data.d[i].DadraHaveliStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInGoaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInGoaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblGoaStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblGoaStateName').text(data.d[i].GoaStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInGujaratStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInGujaratStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblGujaratStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblGujaratStateName').text(data.d[i].GujaratStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInHimachalPradeshStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInHimachalPradeshStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblHimachalPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblHimachalPradeshStateName').text(data.d[i].HimachalPradeshStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInHaryanaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInHaryanaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblHaryanaStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblHaryanaStateName').text(data.d[i].HaryanaStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInJammuKashmirStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInJammuKashmirStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblJammuKashmirStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblJammuKashmirStateName').text(data.d[i].JammuKashmirStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInJharkhandStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInJharkhandStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblJharkhandStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblJharkhandStateName').text(data.d[i].JharkhandStateName);
                           // alert(JSON.stringify(data.d[i].JharkhandStateName));

                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInKeralaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInKeralaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblKeralaStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblKeralaStateName').text(data.d[i].KeralaStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInKarnatakaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInKarnatakaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblKarnatakaStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblKarnatakaStateName').text(data.d[i].KarnatakaStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInLakshadweepStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInLakshadweepStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblLakshadweepStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {

                            $('#LblLakshadweepStateName').text(data.d[i].LakshadweepStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInMeghalayaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInMeghalayaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblMeghalayaStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblMeghalayaStateName').text(data.d[i].MeghalayaStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInMaharashtraStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInMaharashtraStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblMaharashtraStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblMaharashtraStateName').text(data.d[i].MaharashtraStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInManipurStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInManipurStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblManipurStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblManipurStateName').text(data.d[i].ManipurStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInMadhyaPradeshStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInMadhyaPradeshStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblMadhyaPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblMadhyaPradeshStateName').text(data.d[i].MadhyaPradeshStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInMizoramStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInMizoramStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblMizoramStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblMizoramStateName').text(data.d[i].MizoramStateName);
                          //  alert(JSON.stringify(data.d[i].TelenganaStateName));

                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInNagalandStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInNagalandStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblNagalandStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblNagalandStateName').text(data.d[i].NagalandStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInOrissaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInOrissaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblOrissaStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblOrissaStateName').text(data.d[i].OrissaStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInPunjabStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInPunjabStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblPunjabStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblPunjabStateName').text(data.d[i].PunjabStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInPuducherryStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInPuducherryStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblPuducherryStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblPuducherryStateName').text(data.d[i].PuducherryStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInRajasthanStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInRajasthanStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblRajasthanStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblRajasthanStateName').text(data.d[i].RajasthanStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInSikkimStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInSikkimStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblSikkimStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblSikkimStateName').text(data.d[i].SikkimStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInTamilNaduStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInTamilNaduStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblTamilNaduStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblTamilNaduStateName').text(data.d[i].TamilNaduStateName);
                            //alert(JSON.stringify(data.d[i].TamilNaduStateName));
                            //TamilNaduStateName
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInTripuraStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInTripuraStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblTripuraStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblTripuraStateName').text(data.d[i].TripuraStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInUttarakhandStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInUttarakhandStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblUttarakhandStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblUttarakhandStateName').text(data.d[i].UttarakhandStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInWestBengalStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInWestBengalStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblWestBengalStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblWestBengalStateName').text(data.d[i].WestBengalStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInTelenganaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkRecordExistInTelenganaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblTelenganaStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblTelenganaStateName').text(data.d[i].TelenganaStateName);

                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }

            //26july
            function funjsChkNoRecordFoundClickCreateDataOperatorUserPemission(ParmMapDistrictID) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkNoRecordFoundClickCreateDataOperatorUserPemission",
                    async: false,
                    data: '{MapDistrictID: "' + ParmMapDistrictID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblCheckDt1').text('');
                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblCheckDt1').text(data.d[i].DistName1);
                            //alert($('#LblCheckDt').html());
                        }

                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funjsChkNoRecordFoundClickCreateDataOperator(ParmMapDistrictID) {
                $.ajax({
                    type: "POST",
                    url: "IndiaMapHighChart.aspx/ChkNoRecordFoundClickCreateDataOperator",
                    async: false,
                    data: '{MapDistrictID: "' + ParmMapDistrictID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblCheckDt').text('');
                        for (var i = 0; i < data.d.length; i++) {

                            
                            $('#LblCheckDt').text(data.d[i].DistName);
                            //alert($('#LblCheckDt').html());
                        }
                    
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            //End India map Icon code
        </script>
        <script type="text/javascript">
            $(window).load(function () {
                show_all_state();
            });
            $(document).ready(function () {
                show_all_state();
            });
        </script>
        <style>
            .tooltip{width:150px;padding:10px;top:-10px}
        </style>
        <script type="text/javascript">
            function myfunctionstyle() {
               
            $('#container').find('div .highcharts-data-labels').find('div').each(function () {
                var name = $(this).find('span').text();               
                if (name.slice(0, 5) == 'Delhi')
                {
                    var st = $(this).attr('style');
                    var slicest = st.split(';');
                    var len = slicest.length;
                    var newstyle = '';
                   
                    for (var i = 0; i < len - 3; i++)
                    {
                        newstyle = newstyle + slicest[i] + ';';
                    }
                  
                    $(this).attr('style', newstyle);                   
                }
                //if (name.slice(0, 9) == 'Jharkhand') {
                //    var st = $(this).attr('style');
                //    var slicest = st.split(';');
                //    var len = slicest.length;
                //    var newstyle = '';

                //    for (var i = 0; i < len - 3; i++) {
                //        newstyle = newstyle + slicest[i] + ';';
                //    }

                //    $(this).attr('style', newstyle);
                //}
                //if (name.slice(0, 8) == 'Nagaland') {
                //    var st = $(this).attr('style');
                //    var slicest = st.split(';');
                //    var len = slicest.length;
                //    var newstyle = '';

                //    for (var i = 0; i < len - 3; i++) {
                //        newstyle = newstyle + slicest[i] + ';';
                //    }

                //    $(this).attr('style', newstyle);
                //}
                
                if (name.slice(0, 7) == 'Tripura') {
                    var st = $(this).attr('style');
                    var slicest = st.split(';');
                    var len = slicest.length;
                    var newstyle = '';

                    for (var i = 0; i < len - 3; i++) {
                        newstyle = newstyle + slicest[i] + ';';
                    }
                    $(this).attr('style', newstyle); 
                  
                    
                }
                if (name.slice(0, 7) == 'Haryana') {                   
                    $(this).find('span').css('top', '-26px');
                
                   // $(this).attr('style', newstyle);

                }
               
            });
            }           
            myfunctionstyle();
            function tooltip() {
               
             $('#container').find('div .highcharts-tracker').find('img').each(function () {               
                $(this).parent('span').attr('data-toggle', 'tooltip');
                $(this).parent('span').attr('title','Click here for login');
             });
             $('[data-toggle="tooltip"]').tooltip();
            }
            //This code ussed for tooltip front page
            $(window).load(function () {
                tooltip();

            });
        </script>
    </div>
</asp:Content>

