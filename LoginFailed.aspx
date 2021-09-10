<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="LoginFailed.aspx.cs" Inherits="LoginFailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBannerImages" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" Runat="Server">
    <div>
    </div>
        <b>You don't have permission to access this tiger reserver. please choose your assigned tiger reserver!!.</b>
    <div>
        <a  href='<%=ResolveUrl("IndiaMapHighChart.aspx")%>'>Back to site</a>
    </div>
</asp:Content>

