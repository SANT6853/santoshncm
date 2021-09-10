<%@ Page Title="" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register src="UserControl/BannerUserControl.ascx" tagname="BannerUserControl" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="banner" ContentPlaceHolderID="contentBanner" runat="server">

    <section>
          <%--  <uc1:BannerUserControl ID="BannerUserControl1" WebsiteID="1" runat="server" />--%>

        <asp:Literal ID="LtrBanner1" runat="server"></asp:Literal>  
   
        </section>
</asp:Content>

