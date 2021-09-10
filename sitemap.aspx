<%@ Page Title="" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="sitemap.aspx.cs" Inherits="auth_sitemap" %>
<%@ Register Src="UserControl/TopUserControl.ascx" TagName="TopMenu" TagPrefix="uc1" %>
<%@ Register Src="UserControl/footer.ascx" TagName="footMenu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBanner" Runat="Server">
<style>
.sitemap{
	padding-left:0;
}
.sitemap ul{
	padding:0;
}
.sitemap ul li{
	display:block;
}
.sitemap ul li a{
	display:block;
	padding:6px;
	text-decoration:none;
}
.visible-lg-block {
    display: none !important;
}
</style>
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" Runat="Server">

<div class="container">
    <section id="body-part">
<div class="internal-page-left-part">
<asp:Literal ID="LtrLeftMenu" runat="server"></asp:Literal>


</div>
<div class="internal-page-right-part">
<div class="innner-page-main-about-us-bredcum">
<div class="bredcummain">
<div class="breadcrumb">
<a href='<%=ResolveUrl("~/home.aspx") %>'><%=Resources.NTCAResources.HomePage %></a>
<a class="active" href="#"><%=Resources.NTCAResources.Sitemap %></a>
	
</div>
</div>

</div>


		


  <h2><%=Resources.NTCAResources.Sitemap %></h2>

<div class="sitemap">
 
 <h3><%=Resources.NTCAResources.MainMenu%></h3>
 <ul>
      <%--  <Nav:navigation ID="navigation" runat="server" />--%> <uc1:TopMenu ID="Top5" WebsiteID="1" runat="server" />
        </ul>
         <h3><%=Resources.CRCL_Resource.FooterMenu%></h3>
		 <ul>
              <uc2:footMenu ID="footMenu2" Websiteid="1" runat="server" />
        
</ul>
		</div>
		</div>


</div>

</section>
</asp:Content>

