<?php
ob_start();
session_start();

require_once "../includes/connection.php";
require_once "../includes/config.inc.php";
require_once "../includes/functions.inc.php";
include('../design.php');
require_once "../includes/functions-data.php";
include("../includes/useAVclass.php");
include("../includes/def_constant.inc.php");
require_once("../includes/ps_pagination1.php");


@extract($_GET);
@extract($_POST);
@extract($_SESSION);

$statecatgory = content_desc(check_input(trim($_GET['statecatgory'])));
$cities = content_desc(check_input(trim($_GET['cities'])));

$useAVclass = new useAVclass();
$useAVclass->connection();
//
$sql ="select state_code,amrut_state_id from mapping_amrut_state where status='1'";
$amrut_covered_state_result = mysql_query($sql);
$amrut_covered_list=[];
while($row= mysql_fetch_array($amrut_covered_state_result)){
    array_push($amrut_covered_list, $row);
}
$sql = "select city_name,amrut_city_id from mapping_amrut_city where status='1'";
$amrut_covered_city_result = mysql_query($sql);
$amrut_covered_citylist=[];



while($row= mysql_fetch_array($amrut_covered_city_result)){
    array_push($amrut_covered_citylist, $row);
}

$no_of_cities_sql = "select count(mac.amrut_city_id) as no_of_cities, mac.amrut_state_id, mas.state_code,mas.no_ofsaapsize,mas.commited_central from mapping_amrut_city mac left join mapping_amrut_state mas on mac.amrut_state_id=mas.amrut_state_id group by amrut_state_id";
$no_of_cities_result =  mysql_query($no_of_cities_sql);
$tmp_no_of_cities=[];
while($row = mysql_fetch_array($no_of_cities_result))
{
    array_push($tmp_no_of_cities, $row);
}

//echo "<pre>";print_r($tmp_no_of_cities);die();    


if ($_SERVER['REQUEST_URI']) {
    $url = mysql_real_escape_string($_SERVER['REQUEST_URI']);
    $val = explode('/', $url);
    $url = $val['4'];
    $open = $val['3'];

    $search_key = content_desc(check_input($_POST['search_key']));

    $errmsg = "";
    if (trim($search_key) != "") {
        if (preg_match("/^[ A-Za-z0-9_' ./()&+-]*$/", $search_key)) {
            $errmsg .= "In All these Keywords, Only (_'./()&+-) special character will be allow" . "<br>";
        }
    }

    $sql = "SELECT m_publish_id as page_id, m_name, content as content, m_url ,m_title,menu_positions,module_id,update_date,create_date FROM menu_publish where language_id='1' and approve_status='3' and m_id='1'";


    $sql = mysql_query($sql);
    $row = mysql_fetch_array($sql);
    $page_id = $row['page_id'];
    $page_name = $row['m_name'];
    $position = $row['menu_positions'];
    //$rootid=get_root_parent($page_id);
    $rootid = "1";
    $parentid = parentid($page_id);
    $m_name = get_page($page_id);
    $m_url = $row['m_url'];
    $sub_flag_id = $row['m_id'];
}


?>

<?php
$sql55 ="select * from tbl_covered_cities where approve_status='3'";
$amrut_result = mysql_query($sql55);
while($row55= mysql_fetch_array($amrut_result)){
//print_r($row55); 
}

?>

<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="language" content="en">
        <meta name="title" content="List of Cities covered by AMRUT">
        <meta name="description" content="List of Cities covered by AMRUT">
        <meta name="keyword" content="List of Cities covered by AMRUT">

        <title>List of Cities covered by AMRUT :: ATAL MISSION FOR REJUVENATION AND URBAN TRANSFORMATION</title>

        <!-- Bootstrap Core CSS -->
        <link href="<?php echo $HomeURL; ?>/css/bootstrap.css" rel="stylesheet">
        <!-- Custom CSS  -->
        <link href="<?php echo $HomeURL; ?>/css/style.css" rel="stylesheet"> 
        <link rel="stylesheet" type="text/css"  href="<?php echo $HomeURL; ?>/jquery-ui/jquery-ui.min.css" media="all">

        <link href="<?php echo $HomeURL; ?>/css/print.css" rel="stylesheet" type="text/css" media="print">

        <!-- Responsive CSS -->
        <link rel="stylesheet" href="<?php echo $HomeURL; ?>/css/responsive.css" />

        <link rel="stylesheet" href="<?php echo $HomeURL; ?>/css/meanmenu.css" />

        <!-- Custom Fonts -->
        <link href="<?php echo $HomeURL; ?>/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
        <link rel="alternate stylesheet" href="<?php echo $HomeURL; ?>/css/change.css" media="screen" title="change" />
        <link href="<?php echo $HomeURL; ?>/css/jquery.treeview.css" rel="stylesheet">

        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
            <script src="js/html5shiv.js"></script>
            <script src="js/respond.min.js"></script>
        <![endif]-->


        <!-- jQuery -->
        <script src="<?php echo $HomeURL; ?>/js/jquery.min.js"></script>

        <!-- Bootstrap Core JavaScript -->
        <script src="<?php echo $HomeURL; ?>/js/bootstrap.min.js"></script>

        <!-- Menu Access for Tab Key -->
        <script src="<?php echo $HomeURL; ?>/js/superfish.js"></script>

        <!-- font Size Increase Decrease -->
        <script src="<?php echo $HomeURL; ?>/js/font-size.js"></script>

        <script src="<?php echo $HomeURL; ?>/js/swithcer.js"></script>
        <script src="<?php echo $HomeURL; ?>/js/jquery.treeview.js"></script>

        <!-- <script src="<?php echo $HomeURL; ?>/js/script.js"></script>  
        <script src="<?php echo $HomeURL; ?>/js/script_again.js"></script> -->
        <style>
            .highcharts-button-symbol,.highcharts-credits,.highcharts-legend-item.highcharts-undefined-series.highcharts-color-undefined {
                display: none;
            }.state-info-con{
                /*position: absolute;
				height: 200px;
                right: 10px;
                top: 200px;*/
                z-index: 999;
                //background-color: red;
                width: 100%;
                
                visibility: visible;
            }
            #container {
  height: 700px;
  min-width: 310px;
  max-width: 900px;
  margin: 0 auto;
}

.loading {
  margin-top: 10em;
  text-align: center;
  color: gray;
}

        </style>
        <script>

            // initialise plugins
            if (getCookie("mysheet") == "change") {
                setStylesheet("change");
            } else if (getCookie("mysheet") == "style") {
                setStylesheet("style");
            } else if (getCookie("mysheet") == "green") {
                setStylesheet("green");
            } else if (getCookie("mysheet") == "orange") {
                setStylesheet("orange");
            } else {
                setStylesheet("");
            }
            
            function in_array(needle, haystack) {
                for(var i in haystack) {
                    if(haystack[i] == needle) return true;
                }
                return false;
            }
        </script>

        <script>

            (function ($) { //create closure so we can safely use $ as alias for jQuery

                $(document).ready(function () {

// initialise plugin
                    var example = $('#example').superfish({
//add options here if required
                    });

// buttons to demonstrate Superfish's public methods
                    $('.destroy').on('click', function () {
                        example.superfish('destroy');
                    });

                    $('.init').on('click', function () {
                        example.superfish();
                    });

                    $('.open').on('click', function () {
                        example.children('li:first').superfish('show');
                    });

                    $('.close').on('click', function () {
                        example.children('li:first').superfish('hide');
                    });
                });

            })(jQuery);
        </script>

        <script>

            (function ($) { //create closure so we can safely use $ as alias for jQuery

                $(document).ready(function () {

// initialise plugin
                    var example = $('#example1').superfish({
//add options here if required
                    });

// buttons to demonstrate Superfish's public methods
                    $('.destroy').on('click', function () {
                        example.superfish('destroy');
                    });

                    $('.init').on('click', function () {
                        example.superfish();
                    });

                    $('.open').on('click', function () {
                        example.children('li:first').superfish('show');
                    });

                    $('.close').on('click', function () {
                        example.children('li:first').superfish('hide');
                    });
                });

            })(jQuery);
        </script>

        <script src="<?php echo $HomeURL; ?>/js/modern-ticker.js" type="text/javascript"></script>
        <script type="text/javascript">
            window.root_url = '<?php echo $HomeURL; ?>';
            $(function () {
                $(".ticker1").modernTicker({
                    effect: "scroll",
                    scrollInterval: 20,
                    transitionTime: 500,
                    autoplay: true
                });
            });
        </script>
        <script type="text/javascript" src="<?php echo $HomeURL; ?>/js/jquery.totemticker.js"></script>
        <script type="text/javascript">
            $(function () {
                $('#vertical-ticker').totemticker({
                    row_height: '100px',
                    next: '#ticker-next',
                    previous: '#ticker-previous',
                    stop: '#stop',
                    start: '#start',
                    mousestop: true,
                });
            });
        </script>
        <script src="<?php echo $HomeURL; ?>/js/jquery.meanmenu.js"></script>   
        <script src="<?php echo $HomeURL; ?>/jquery-ui/jquery-ui.js"></script>
        <script type="text/jscript">
            jQuery(document).ready(function () {
            jQuery('#main-nav nav').meanmenu()
            });
        </script>   
        <script type='text/javascript'>//<![CDATA[ 
            $(window).load(function () {
                $(function () {
                    $('#homeCarousel').carousel({
                        interval: 2000,
                        pause: "false"
                    });
                    $('#playButton').click(function () {
                        $('#homeCarousel').carousel('cycle');
                    });
                    $('#pauseButton').click(function () {
                        $('#homeCarousel').carousel('pause');
                    });
                });
            });//]]>  

            $(document).ready(function () {

                $('#startdate').datepicker({
                    altField: '#strtdate',
                    altFormat: 'yy-mm-dd',
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'dd-mm-yy',
                    showAnim: 'slideDown',
                    yearRange: '-125:+0',
                    onChangeMonthYear: function (y, m, i) {
                        var d = i.selectedDay;
                        $(this).datepicker('setDate', new Date(y, m - 1, d));
                    }
                });

                $('#start_date').datepicker({
                    altField: '#edate',
                    altFormat: 'yy-mm-dd',
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'dd-mm-yy',
                    showAnim: 'slideDown',
                    yearRange: '-125:+0',
                    onChangeMonthYear: function (y, m, i) {
                        var d = i.selectedDay;
                        $(this).datepicker('setDate', new Date(y, m - 1, d));
                    }
                });

            });
        </script> 
        <script type="text/javascript">
            jQuery(document).ready(function () {
                jQuery('li.dropdown:has(ul:empty)').remove();
                jQuery('ul.menu li:has(ul)').addClass('collapsed');
                jQuery("ul.menu").treeview({
                    collapsed: true,
                    unique: true,
                    persist: "location"
                });
                return false;
            });
        </script>
        <script>

            var delete_id = '';
            var searchUrl = '?';
            var search_key = '';
            function doSearch()
            {   //alert(2);

                var searchParam = '';
                var search_key = $.trim($('#search_key').val());
                var startdate = $.trim($('#startdate').val());
                var start_date = $.trim($('#start_date').val());
                if (search_key)
                {

                    searchParam = searchParam + 'search_key=' + search_key;
                }

                if (startdate != 0)
                {
                    searchParam += '&startdate=' + startdate;

                }
                if (start_date != 0)
                {
                    searchParam += '&enddate=' + start_date;

                }
              
                window.location = searchUrl + searchParam;
        //alert(searchParam);
            }
            /*function doFilter()
             {
             if(search_q != '')
             {
     
     
             }
     
             }*/

        </script>
        <script src="https://code.highcharts.com/maps/highmaps.js"></script>
        <script src="https://code.highcharts.com/maps/modules/data.js"></script>
        <script src="https://code.highcharts.com/maps/modules/drilldown.js"></script>
        <script src="https://code.highcharts.com/maps/modules/exporting.js"></script>
        <script src="https://code.highcharts.com/maps/modules/offline-exporting.js"></script>
        <script src="<?php echo $HomeURL; ?>/js/data/in-all.js"></script>
        <link href="https://netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.css" rel="stylesheet">
    </head>
    <body id="fontSize">
        <!-- Accessbility Part Start -->
        <div class="container-fluid accebility-bg">
            <div class="container">
<?php include("accessbility-menu.php"); ?>
            </div>
            <div class="clear"></div>
        </div>
        <!-- Accessbility Part End -->

        <!-- Logo Part Start -->
        <div class="container-fluid logo-top-back">
            <div  class="container">

<?php include('header.php'); ?>

            </div>
        </div>
        <!-- Logo Part end -->

        <div id="main-nav" class="navigation-bg">
            <nav>
                <div class="container">
<?php include('navigation.php'); ?>
                </div>
            </nav>
        </div>
        <!-- Menu Part End --> 

        <div class="container background-white">
            <div class="row">
                <div class="col-md-12">
                    <ol class = "breadcrumb breadcrum-margin-top">
                        <li><a href = "index.php" title="Home">Home</a></li>
                        <li class = "active">About AMRUT</li>
                        <li class = "active"><a href="<?php echo $HomeURL; ?>/content/citiescovered.php">List of Cities covered under AMRUT</a></li>


                    </ol>
                    <a onClick="javascript: window.print()" title="Print" href="javascript: void(0)"><p class="glyphicon glyphicon-print  print"></p></a>
                </div>
            </div>
        </div>

        <!--Middle Part Start -->   
        <div class="container background-white" id="skip">
            <div class="row">
                <div class="col-md-3 for-print">
                    <div class="left-sidebar">

<?php include('left_menu.php'); ?>
                    </div>
<?php //include('innerleft-menu.php'); ?>
                </div> 


                <div class="col-md-9 content-area">
                    <h3>Map of Cities covered under AMRUT</h3>     
                	<div class='state-info-con'>
                        <ul class="list-group">

                        </ul> 
                    </div>
					<div class="suddan">
                    <div id="map-container" style="height: 700px; min-width: 310px; max-width: 1000px; margin: 0 auto"></div>
                    </div>
                    <form name="stateinfo" id="stateinfo" method="post" action="citiescovered.php">
                        <input type="hidden" name="statecatgory" id="stateid" value="">
                    </form>
                    
                        <script type="text/javascript">



// show all hidden place name --
                            function show_all_state() {
                                transform = $('.highcharts-label').attr('transform');
                                var res = transform.slice(-8,-1);
                                var now = res.replace(",",".");

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
                                  $( window ).load(function() {
                                        show_all_state();
                                    });
                            }



                



                       /*   $('.suddan').hover(function(){
                            show_all_state();
                          });*/
                          $(document).on('hover','.suddan',function(){
                            show_all_state();
                          });
                          $(document).on('mousemove','.suddan',function(){
                            show_all_state();
                          });

                            /*
                             TODO:
                             - Check data labels after drilling. Label rank? New positions?
                             */

                            var no_of_cities = <?php echo json_encode($tmp_no_of_cities); ?>;
                            var data = Highcharts.geojson(Highcharts.maps['countries/in/in-all']),
                                    separators = Highcharts.geojson(Highcharts.maps['countries/in/in-all'], 'mapline'),
                                    small = $('#map-container').width() < 400;
                            var $amrut_covered_citylist = <?php echo json_encode(array_column($amrut_covered_citylist,'city_name')); ?> ;
                           
                            
                        // Set drilldown pointers
                            var $amrut_covered_list = JSON.parse('<?php echo json_encode(array_column($amrut_covered_list,'state_code')); ?>');
                            $tmp=[];
                            $.each(data, function (i) {
                                if(in_array(this.properties['hc-key'],$amrut_covered_list))
                                {
                                    $tmp.push(data[i]);
                                }else{
                                    
                                }
                            });
                            data=null;
                            data=$tmp;
                            
                            $.each(data, function (i) {
                                    this.drilldown = this.properties['hc-key'];
                                    this.value = i; // Non-random bogin data
                            });

                        //var in_hr_mapping = [
                        //     {"state_id":"6","city_id":"800365","city_name":"Ambala" ,"distt_map_value":"0","distt_map_id":"149"}
                        //    ,{"state_id":"6","city_id":"800367","city_name":"Ambala Sadar","distt_map_value":"0","distt_map_id":"0"}
                        //    ,{"state_id":"6","city_id":"800418","city_name":"Bahadurgarh","distt_map_value":"6","distt_map_id":"0"}
                        //    ,{"state_id":"6","city_id":"800409","city_name":"Bhiwani","distt_map_value":"1","distt_map_id":"150"}
                        //    ,{"state_id":"6","city_id":"800436","city_name":"Faridabad","distt_map_value":"2","distt_map_id":"151"}
                        //    ,{"state_id":"6","city_id":"800429","city_name":"Gurgaon","distt_map_value":"4","distt_map_id":"153"}
                        //    ,{"state_id":"6","city_id":"800405","city_name":"Hisar","distt_map_value":"5","distt_map_id":"154"}
                        //    ,{"state_id":"6","city_id":"800368","city_name":"Jagadhri","distt_map_value":"18","distt_map_id":"167"}
                        //    ,{"state_id":"6","city_id":"800393","city_name":"Jind","distt_map_value":"5","distt_map_id":"154"}
                        //    ,{"state_id":"6","city_id":"800375","city_name":"Kaithal","distt_map_value":"0","distt_map_id":"149"}
                        //    ,{"state_id":"6","city_id":"800381","city_name":"Karnal","distt_map_value":"9","distt_map_id":"158"}
                        //    ,{"state_id":"6","city_id":"800437","city_name":"Palwal","distt_map_value":"2","distt_map_id":"151"}
                        //    ,{"state_id":"6","city_id":"800363","city_name":"Panchkula","distt_map_value":"12","distt_map_id":"161"}
                        //    ,{"state_id":"6","city_id":"800385","city_name":"Panipat","distt_map_value":"9","distt_map_id":"158"}
                        //    ,{"state_id":"6","city_id":"800425","city_name":"Rewari","distt_map_value":"14","distt_map_id":"163"}
                        //    ,{"state_id":"6","city_id":"800414","city_name":"Rohtak","distt_map_value":"15","distt_map_id":"164"}
                        //    ,{"state_id":"6","city_id":"800401","city_name":"Sirsa","distt_map_value":"16","distt_map_id":"165"}
                        //    ,{"state_id":"6","city_id":"800389","city_name":"Sonipat","distt_map_value":"15","distt_map_id":"164"}
                        //    ,{"state_id":"6","city_id":"800372","city_name":"Thanesar","distt_map_value":"10","distt_map_id":"159"}
                        //    ,{"state_id":"6","city_id":"800369","city_name":"Yamunanagar","distt_map_value":"18","distt_map_id":"167"}
                        //]

                            Highcharts.mapChart('map-container', {
                                chart: {
                                    events: {
                                        drilldown: function (e) {
                                            
                                            try {
                                                if (!e.seriesOptions) {
                                                    var chart = this,
                                                            mapKey = e.point.drilldown;
                                                  
                                                     
                                                    if(mapKey=="in-ap" &&  e.point.name=="Telengana")
                                                    {
                                                        mapKey ="in-tl";
                                                        
                                                    }else if(mapKey=="in-ap" &&  e.point.name!="Telengana"){
                                                        mapKey ="in-ap";
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
                                                    $.getScript('../js/data/' + mapKey + '.js', function () {
                                                        data = Highcharts.geojson(Highcharts.maps[mapKey]);
                                                        // Set a non-random bogus value
//                                                        $tmp=[];
//                                                        $.each(data, function (i) {
//                                                            if(in_array(this.properties.NAME,$amrut_covered_citylist))
//                                                            {
//                                                                $tmp.push(data[i]);
//                                                            }else{
//                                                                data[i].name='';
//                                                                data[i].properties.name='';
//                                                                 $tmp.push(data[i]);
//                                                            }
//                                                        });
//                                                        data=null;
//                                                        data=$tmp;
                                                        
                                                        $.each(data, function (i) {
                                                            this.value = i;
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
                                                    });
                                                }
                                                this.setTitle(null, {text: e.point.name});
                                            } catch (err) {
                                                alert(err)
                                            }
                                        },
                                        drillup: function () {
                                            this.setTitle(null, {text: ''});
                                            $(".state-info-con").css("display", "none");
                                            this.series. borderColor='#000000';
                                        },
                                          load: function () {
                                                show_all_state();
                                        }
                                    }
                                },
                                legend: {
                                    enabled: false
                                },tooltip: {
                                    enabled: false,
                                },
                                lang:{
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
                        /*    dataClasses: [{
                            to: 19,
                            color: "red"
                          }, {
                            from: 3,
                            to: 10,
                            color: "yellow"
                          }, {
                            from: 20,
                            to: 30,
                            color: "green"
                          }, {
                            from: 30,
                            to: 100,
                            color: "blue"
                          }, {
                            from: 100,
                            to: 300,
                            color: "pink"
                          }, {
                            from: 300,
                            to: 1000,
                            color: "purple"
                          }, {
                            from: 1000,
                            color: "black"
                          }], */
                                    min: 0,
                                    minColor: '#B2DBEA',
                                    maxColor: '#0088BB'
                                },
                                mapNavigation: {
                                    enabled: true,
                                    buttonOptions: {
                                        verticalAlign: 'bottom'
                                    }
                              
                                },
                                plotOptions:{
                                     map: {
                                        states: {
                                            hover: {
                                                color: '#0077aa'
                                            }
                                        }
                                    },
                                    series: {
                                        point: {
                                            events: {
                                                click: function () {
                                                    
                                                    var current_city_code =this.drilldown;
                                                    var cities='';
                                                    
                                                   
                                                   

                                                   
                                                    if(this.drilldown=="in-ap" &&  this.properties.name=="Telengana" )
                                                    {
                                                        current_city_code ="in-tl";
                                                       // this.properties.ID_1='36';
                                                    }else if(this.drilldown=="in-ap" &&  this.properties.name!="Telengana"   ){
                                                        current_city_code ="in-ap";
                                                    }

                                                    for(i in no_of_cities){
                                                        if(no_of_cities[i].state_code ==  current_city_code)
                                                        {
                                                            

                                                            cities =no_of_cities[i].no_of_cities;
                                                            shapsize =no_of_cities[i].no_ofsaapsize;
                                                            commitedcentral =no_of_cities[i].commited_central;
                                                            break;
                                                        }
                                                    }

													if(typeof this.properties.NAME_1=="undefined"){
 
                                                    $(".state-info-con").css("display", "block");
                                                    $(".state-info-con ul").html("<li class='no-of-cities'><span class='icoN-sec'><img src='../images/building.png' alt='' title=''></span><span class='icoNtext-sec'>No of cities </span><span class='icoNtext-sec'><b class=''>"+cities +"</b></span></li>" +
                                                            "<li class='no-of-cities saap-size'><span class='icoN-sec'><img src='../images/gear-rotation.png' alt='' title=''></span><span class='icoNtext-sec'>Approved SAAP size(In Crore) </span><span class='icoNtext-sec'><b class=''>"+shapsize +"</b></span></li>"+
                                                            "<li class='no-of-cities saap-size'><span class='icoN-sec'><img src='../images/committed.png' alt='' title=''></span><span class='icoNtext-sec'>Commited Central Assistance(In Crore) </span><span class='icoNtext-sec'><b class=''>"+commitedcentral +"</b></span></li>");
                                                    }
                                                    if (typeof this.properties.ID_1 != 'undefined') {

                                                        $("#stateid").val(this.properties.ID_1);
                                                        $("#stateinfo").submit();
                                                        //window.location.href = window.root_url + "/content/citiescovered.php?statecatgory=" + this.properties.ID_1;
                                                    }
                                                },mouseOver: function(){

                                                    show_all_state();
                                                   
                                                },
                                                mouseOut: function(){
                                                 //   console.log(this);
                                                // alert("check");
                                                 show_all_state();
                                                },
                                                show: function(){
                                                    
                                                   // show_all_state();
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
                                            //format: '{point.properties.postal-code}'
                                            format: '{point.name}'
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
                        //$(document).read(function(){
                        //    $('.highcharts-title').text("India");
                        //})
                        </script>  
                </div>
          
                <?php
                $sql = mysql_query(" SELECT * FROM `audit_trail` WHERE `page_name` ='List of Cities covered by AMRUT' AND `page_category`='1' ORDER BY `audit_trail`.`page_action_date` DESC");
                $res = mysql_fetch_array($sql);
                ?>
                <p style="text-align: right;">Page Last Updated On : <?php
                    $update1 = $res['page_action_date'];
                    echo $dt = date('d-m-Y', strtotime($update1));
                    ?>
            </div>        
        </div>


        <!--Footer Logo -->
        <div class="container-fluid footer-logo-bg">
            <div class="container">
                <div class="ticker1 modern-ticker mt-round mt-scroll">
<?php include('bottom-link.php') ?>
                </div>		 
            </div>
        </div>
        <!--Footer Logo end -->

        <!-- Footer part -->
        <div class="container-fluid background-dark-gray">
<?php include('footer.php'); ?>
        </div>

        <div class="container-fluid background-dark-black">
<?php include('lastfooter.php'); ?>
        </div>
        <!-- Footer part -->   
        <script type="text/javascript">

            $(document).bind("contextmenu", function(e) {

                 
    return false;
});

            function getPage(id) {
//alert(id);
                //generate the parameter for the php script
                var stateid = document.getElementById("statecatgory").value;
//alert(statename);  
                var data = 'id=' + stateid;
                //alert(data);
                $.ajax({
                    url: "get_district1.php",
                    type: "POST",
                    data: data,
                    cache: false,
                    success: function (html) {
                        // alert(html);
                        //hide the progress bar
                        $('#loading').hide();

                        //add the content retrieved from ajax and put it in the #content div
                        $('#population1').html(html);

                        //display the body with fadeIn transition
                        $('#content1').fadeIn('slow');
                    }
                });
            }

            function getStateInformationData(id) {
                $.ajax({
                    url: 'getStateInformation.php',
                    method: "post",
                    dataType: "json",
                    data: {"id": id},
                    beforeSend: function () {

                    }, success: function (res) {

                        // state-info-con
                        if (res.status)
                        {
                            var temp = "";
                            for (i in res.result[0]) {
                                temp = temp + "<li class='list-group-item'>" + i + "<span class='badge'>" + res.result[0][i] + "</span></li>";
                            }
                        }
                        $(".state-info-con ul").html(temp);
                    }
                });
            }
            

        </script>
    </body>
</html>
