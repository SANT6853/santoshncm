<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="contentBannerHead" ContentPlaceHolderID="contentBannerHeader" Runat="Server">
    <h1>MIS FOR RELOCATION OF VILLAGES <span>SARISKA TIGER RESERVE</span></h1>
<h2>NATIONAL TIGER CONSERVATION AUTHORITY <span>(NTCA)</span> / PROJECT TIGER <span>(PT)</span></h2>
<h2>MINISTRY OF ENVIRONMENT AND FOREST <span>(MOEF)</span></h2>
<p>(STATUTORY BODY UNDER THE MINISTRY OF ENVIRONMENT & FOREST)</p>
<p>(GOVERNMENT OF INDIA)</p>
</asp:Content>
<asp:Content ID="contentBannerImg" runat="server" ContentPlaceHolderID="contentBannerImages">
     <ol class="carousel-indicators">
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
  </div>
</asp:Content>
<asp:Content ID="contentMainContentBox" runat="server" ContentPlaceHolderID="contentMainContent">
    <div class="col-md-8 font_medium">
<h3>Sariska Tiger Reserve</h3>

<p class="text-justify">Sariska Tiger Reserve is located in Alwar District of Rajasthan in lap of Aravali hills and situated 200 Kms from National capital Delhi, Sariska Tiger Reserve or Sariska National Park was a hunting reserve area for Alwar state , It got a status of wildlife reserve in year 1955 and in year 1978 it became Sariska Tiger Reserve. It contains area of 866 sq kms .</p>

<p class="text-justify">Wild life found at Sariska as Royal Bengal Tiger, Leopard, Jungle Cat, Caracal, Striped Hyena, Golden Jackal, Chital, Sambhar, Blue Bull, Chinkara, Four Horned antelope, Wild Boar, Hare Langur and many birds and reptiles etc.</p>

<p class="text-justify">Flora of Sariska is found as Dhok tree, Salar, Kadaya, Dhak, Gol, Ber, Khair, Bargad, Arjun, Gugal, Bamboo etc, Many shrubs like Kair, Adusta, Jhar Ber etc.</p>

<p class="text-justify">Sariska Tiger Reserve contains historical places inside as Kankarwadi fort, built by kind Jai Singh second, Kankarwadi fort is located in centre of Sariska Tiger Reserve, Mughel emperor Aurangzeb imprisoned his brother Dara Shikoh at Kankarwadi fort in struggle for succession of the throne, Famous temple of lord Hanuman is situated at Pandupol which is related to Pandavas, Entry to Pandupole is free on Saturdays and Tuesday round the year.</p>


</div>
<div class="col-md-4">
<div class="employee_login">
<h3>Employee Login</h3>
<form>
<div class="form-group">
<input type="text" class="form-control" name="" placeholder="User Name">
</div>
<div class="form-group">
<input type="password" class="form-control" name="" placeholder="Password">
</div>
<div class="form-group">
<img src="images/captcha.jpg" alt="" title="" class="img-responsive">
</div>
<div class="form-group">
<input type="text" class="form-control" name="" placeholder="Captcha Code">
</div>
<button type="submit" class="btn-submit">Submit</button>
</form>


</div>
</div>
</asp:Content>
<asp:Content ID="contentFooter" runat="server" ContentPlaceHolderID="contentFooter">
    <ul class="footer_list">
<li><a href="#"><img src="images/wii.jpg" alt="" title=""></a></li>
<li><a href="#"><img src="images/traffic.jpg" alt="" title=""></a></li>
<li><a href="#"><img src="images/mis.jpg" alt="" title=""></a></li>
<li><a href="#"><img src="images/cites.jpg" alt="" title=""></a></li>
<li><a href="#"><img src="images/gtf.jpg" alt="" title=""></a></li>
</ul>
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
</asp:Content>

