<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>NTCA</title>
<link rel="apple-touch-icon" sizes="57x57" href="images/fav/apple-icon-57x57.png">
<link rel="apple-touch-icon" sizes="60x60" href="images/fav/apple-icon-60x60.png">
<link rel="apple-touch-icon" sizes="72x72" href="images/fav/apple-icon-72x72.png">
<link rel="apple-touch-icon" sizes="76x76" href="images/fav/apple-icon-76x76.png">
<link rel="apple-touch-icon" sizes="114x114" href="images/fav/apple-icon-114x114.png">
<link rel="apple-touch-icon" sizes="120x120" href="images/fav/apple-icon-120x120.png">
<link rel="apple-touch-icon" sizes="144x144" href="images/fav/apple-icon-144x144.png">
<link rel="apple-touch-icon" sizes="152x152" href="images/fav/apple-icon-152x152.png">
<link rel="apple-touch-icon" sizes="180x180" href="images/fav/apple-icon-180x180.png">
<link rel="icon" type="image/png" sizes="192x192"  href="images/fav/android-icon-192x192.png">
<link rel="icon" type="image/png" sizes="32x32" href="images/fav/favicon-32x32.png">
<link rel="icon" type="image/png" sizes="96x96" href="images/fav/favicon-96x96.png">
<link rel="icon" type="image/png" sizes="16x16" href="images/fav/favicon-16x16.png">
<link rel="manifest" href="/manifest.json">
<meta name="msapplication-TileColor" content="#ffffff">
<meta name="msapplication-TileImage" content="/ms-icon-144x144.png">
<meta name="theme-color" content="#ffffff">

<link href="css/style.css" rel="stylesheet" type="text/css">
<link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">
<link href="css/meanmenu.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
   <header>
<div class="container">
<div class="row">
<div class="col-md-2 res_textcenter"><a href="index.html"><img src="images/logo.png" alt="NTCA" title="National Tiger Conservation Authority" class="logo"></a></div>
<div class="col-md-10">
<div class="top_access hidden-xs">
<div class="pull-right back_arrow">
<ul id="example" class="top_accessibility">
<li class="pd4"><input type="text" class="search_top" placeholder="Enter Keyword!"><button type="submit" class="searchbtn" name="search"><i class="fa fa-search"></i></button></li>
<li><a href=""><img src="images/skip.png" alt="Skip To Content" title="Skip To Content"></a></li>
<li class="drop_menu"><a href=""><img src="images/handicape.png" alt="Handicape" title="Handicape"></a>
	<ul class="drop_content">
	<li><a href=""><img src="images/decrease-font-size.png" alt="Decrease Font Size" title="Decrease Font Size"></a></li>
	<li><a href=""><img src="images/standard-view.png" alt="Normal Font" title="Normal Font"></a></li>
	<li><a href=""><img src="images/increase-text-size.png" alt="Increase Text Size" title="Increase Text Size"></a></li>
	<li><a href=""><img src="images/high-contrast.png" alt="High Contrast" title="High Contrast"></a></li>
	<li><a href=""><img src="images/standard-view.png" alt="Standard View" title="Standard View"></a></li>
	</ul>
</li>
<li class="drop_menu"><a href=""><a href=""><img src="images/ico-social.png" alt="Social Icon" title="Social Icon"></a>
<ul class="drop_content">
	<li><a href=""><img src="images/facebook-icons.jpg" alt="Facebook" title="Facebook"></a></li>
	<li><a href=""><img src="images/twitter.jpg" alt="Twitter" title="Twitter"></a></li>
	<li><a href=""><img src="images/you-tube.jpg" alt="you-tube" title="you-tube"></a></li>
	</ul>
</li>
<li><a href="#"><img src="images/sitemap.png" alt="Sitemap" title="Sitemap"></a></li>
<li><a href="#">हिंदी</a></li>
</ul>
</div>
</div>

<!--Logo Text-->
<div class="logo_text">
<h1>MIS FOR RELOCATION OF VILLAGES <span>SARISKA TIGER RESERVE</span></h1>
<h2>NATIONAL TIGER CONSERVATION AUTHORITY <span>(NTCA)</span> / PROJECT TIGER <span>(PT)</span></h2>
<h2>MINISTRY OF ENVIRONMENT AND FOREST <span>(MOEF)</span></h2>
<p>(STATUTORY BODY UNDER THE MINISTRY OF ENVIRONMENT & FOREST)</p>
<p>(GOVERNMENT OF INDIA)</p>
</div>



</div>
</div>
</div>


</header>
<section>
<div class="mean-container"></div>
<div id="main-nav" class="navigation-bg">
<div class="container">
<nav>
<ul class="clearfix sf-menu sf-js-enabled sf-arrows sf-arrows1" id="example1">
<li class="current"><a href="index.html" title="Home">Home</a></li>							  
<li><a href="#">About NTCA</a>
	<ul>
	 <li><a href="introduction.html">Introduction</a></li>
	 <li><a href="#">Our Director</a></li>
	 <li><a href="#">Previous Directors</a></li>
	 <li><a href="#">Research Council</a></li> 
	</ul>
</li>
<li><a href="#">Contact Us</a>
<li><a href="#">Related Links</a>
</ul>
</nav>
</div>
</div>
</section>

<section>
<div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
 <%-- <ol class="carousel-indicators">
    <li data-target="#myCarousel" data-slide-to="0" class=""></li>
    <li data-target="#myCarousel" data-slide-to="1" class=""></li>
    <li data-target="#myCarousel" data-slide-to="2" class="active"></li>
  </ol>

  <!-- Wrapper for slides -->
  <div class="carousel-inner">
    <div class="item">
      <img src="images/banner.jpg" alt="banner" title="banner">
    </div>

    <div class="item">
      <img src="images/banner.jpg" alt="banner1" title="banner1">
    </div>

    <div class="item active">
      <img src="images/banner.jpg" alt="banner2" title="banner2">
    </div>
  </div>

  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" data-slide="prev">
    <span class="glyphicon glyphicon-chevron-left"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" data-slide="next">
    <span class="glyphicon glyphicon-chevron-right"></span>
    <span class="sr-only">Next</span>
  </a>

  <div id="carouselButtons">
      <button id="playButton" type="button" class="btn btn-default btn-xs">
          <span class="glyphicon glyphicon-play"></span>
       </button>
      <button id="pauseButton" type="button" class="btn btn-default btn-xs">
          <span class="glyphicon glyphicon-pause"></span>
      </button>
  </div>--%>

</div>
</section>
<section class="pb30">
<div class="container">
<div class="row">
<div class="col-md-12">
<ol class="breadcrumb">
<li><a href="#">Home</a></li>
<li class="active">Gallery</li>        
</ol>
</div>
<div class="col-md-12 font_medium">
<div class="main-content">
<h3>Photo Gallery</h3>

<div class="demo-gallery">
<ul id="lightgallery" class="list-unstyled row">
	<li class="col-xs-6 col-sm-4 col-md-3" data-responsive="images/gallery/1-375.jpg 375, images/gallery/1-480.jpg 480, images/gallery/1.jpg 800" data-src="images/gallery/1-1600.jpg" data-sub-html="<h4>Fading Light</h4><p>Classic view from Rigwood Jetty.</p>">
		<a href="">
			<img class="img-responsive" src="images/gallery/thumb-1.jpg">
		</a>
	</li>
	<li class="col-xs-6 col-sm-4 col-md-3" data-responsive="images/gallery/2-375.jpg 375, images/gallery/2-480.jpg 480, images/gallery/2.jpg 800" data-src="images/gallery/2-1600.jpg" data-sub-html="<h4>Bowness Bay</h4><p>A beautiful Sunrise this morning taken En-route right time.</p>">
		<a href="">
			<img class="img-responsive" src="images/gallery/thumb-2.jpg">
		</a>
	</li>
	<li class="col-xs-6 col-sm-4 col-md-3" data-responsive="images/gallery/13-375.jpg 375, images/gallery/13-480.jpg 480, images/gallery/13.jpg 800" data-src="images/gallery/13-1600.jpg" data-sub-html="<h4>Bowness Bay</h4><p>A beautiful Sunrise this morning taken En-route to Keswick.</p>">
		<a href="">
			<img class="img-responsive" src="images/gallery/thumb-13.jpg">
		</a>
	</li>
	<li class="col-xs-6 col-sm-4 col-md-3" data-responsive="images/gallery/4-375.jpg 375, images/gallery/4-480.jpg 480, images/gallery/4.jpg 800" data-src="images/gallery/4-1600.jpg" data-sub-html="<h4>Bowness Bay</h4><p>A beautiful Sunrise this morning taken En-route to Keswick not one as planned.</p>">
		<a href="">
			<img class="img-responsive" src="images/gallery/thumb-4.jpg">
		</a>
	</li>
</ul>
</div>

</div>
</div>



</div>
</div>
</section>

<footer>
<div class="container">
<div class="col-md-9">
<div class="gal_scroller">
<div class="carousel carousel-showmanymoveone slide" id="carousel123">
<div class="carousel-inner">
  <div class="item active">
	<div class="col-xs-12 col-sm-6 col-md-3"><a href="#"><img src="images/wii.jpg" alt="" title=""></a></div>
  </div>
  <div class="item">
	<div class="col-xs-12 col-sm-6 col-md-3"><a href="#"><img src="images/traffic.jpg" class="img-responsive"></a></div>
  </div>
  <div class="item">
	<div class="col-xs-12 col-sm-6 col-md-3"><a href="#"><img src="images/mis.jpg" class="img-responsive"></a></div>
  </div>          
  <div class="item">
	<div class="col-xs-12 col-sm-6 col-md-3"><a href="#"><img src="images/cites.jpg" class="img-responsive"></a></div>
  </div>
  <div class="item">
	<div class="col-xs-12 col-sm-6 col-md-3"><a href="#"><img src="images/gtf.jpg" class="img-responsive"></a></div>
  </div>
</div>
<a class="left carousel-control" href="#carousel123" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>
<a class="right carousel-control" href="#carousel123" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>
</div>
</div>
</div>

<div class="col-md-3">
<div class="gallantry_box mt15">
<a href="gallery.html"><img src="images/gal_1.jpg" class="img-responsive border_double" alt="" title=""></a>
</div>
</div>

</div>
<div class="devider"></div>
 <div class="container">
<ul class="footer_menu_list">
<li><a href="#">Home</a></li>
<li><a href="#">Why Relocation? </a></li>
<li><a href="#">Tiger Reserve in India</a></li>
<li><a href="#">NTCA</a></li>
<li><a href="#">Contact Us</a></li>
<ul>
<p class="copy">This Website belongs to National Tiger Conservation Authority, Government of India.</p>
</div>
</footer>











<!--Deafult Js-->
<script src="js/jquery.min.js" type="text/javascript"></script>
<script src="js/bootstrap.min.js" type="text/javascript"></script>
<script src="js/superfish.js" type="text/javascript"></script>
<script src="js/jquery.meanmenu.js" type="text/javascript"></script>   
<script type="text/jscript">
jQuery(document).ready(function () {
	jQuery('#main-nav nav').meanmenu()
});
</script>

<script src="js/ace-responsive-menu.js" type="text/javascript"></script>
<script src="js/customNews.js" type="text/javascript"></script>
<!--Light Box-->
<script type="text/javascript">
$(document).ready(function(){
	$('#lightgallery').lightGallery();
});
</script>
<script src="https://cdn.jsdelivr.net/picturefill/2.3.1/picturefill.min.js"></script>
<script src="js/lightgallery-all.min.js"></script>
<script src="js/jquery.mousewheel.min.js"></script>
    </form>
</body>
</html>
