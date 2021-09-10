<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="ContentPage.aspx.cs" Inherits="ContentPage" %>
<%@ Register Src="~/UserControl/LeftMenu.ascx" TagName="LeftMenu"
    TagPrefix="ucLeftMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentLeftMenu" Runat="Server">
    
    <%--<ucLeftMenu:LeftMenu ID="leftMenu" runat="server" WebsiteID="2" />--%>
                          
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" Runat="Server">
    <style>
        .mainct .row .col-md-3 li{
            background: #f2f2f2;
    padding: 10px;
    margin-bottom: 3px;
    border: 1px solid #f7b000;
    list-style:none;
    text-align:center;
    color:#fff;
        }
        .mainct .row .col-md-3 li:hover{
            background: #f7b000;
    padding: 10px;
    margin-bottom: 3px;
    border: 1px solid #f7b000;
    list-style:none;
    text-align:center;
    color:#fff;
        }
        .mainct .row .col-md-3 li a{
            color:#000;
        }
    </style>
    <div class=" container background-white">
        
                 <div class="container mainct">
                <div class="row">
                
                    <asp:Literal ID="LtrLeftMenu" runat="server"></asp:Literal>
                
            <div class="col-md-9 content-area">
                <h2>
                    <asp:Label ID="lbltoshowh2" runat="server"></asp:Label>
                    <asp:Literal ID="litPageHead" runat="server"> </asp:Literal></h2>
                <asp:Label ID="lblshow4" runat="server" Text=""></asp:Label>
                <asp:Literal ID="LitDesc" runat="server"> </asp:Literal>
				<div id="divdetails"></div>

                <div id="dvHTMLStripped"></div>
                <div class="pull-right pt15">
                    <asp:Literal ID="ltrlastupdated" runat="server" />
                </div>
            </div>
    </div>
            </div>
            </div>

    <%-- <div class="col-md-9"> <asp:Literal ID="ltrlMainContent" runat="server" >
            </asp:Literal>
         </div>--%>
</asp:Content>

