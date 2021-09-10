<%@ Page Title="" Language="C#" MasterPageFile="~/MainsiteMiddleContent.master" AutoEventWireup="true" CodeFile="Homemiddlecontent.aspx.cs" Inherits="Homemiddlecontent" ValidateRequest="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="css/print.css" rel="stylesheet" type="text/css" />
<style>
p{text-align:justify;}
</style>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="contentBanner" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" Runat="Server">
			
			<!--<div class="breadcrumb">
				
				<a onclick="javascript: window.print()" class="pull-right" title="Print" href="javascript: void(0)">
                    <p class="glyphicon glyphicon-print  print">
                    </p>
                </a>
				
			</div>-->
    
            <div class="col-sm-9" id="content">
			<div class="">
            <span style="font-size:30px;">
            <asp:Literal ID="LtrTitle" runat="server"></asp:Literal></span>
			
			
				</div>
             <asp:Literal ID="LtrCntMiddleContent" runat="server"></asp:Literal>
            </div>
           
</asp:Content>

