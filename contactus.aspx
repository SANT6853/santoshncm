<%@ Page Title="" Language="C#" MasterPageFile="~/MainsiteMiddleContent.master" AutoEventWireup="true" CodeFile="contactus.aspx.cs" Inherits="contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
     <a onclick="javascript: window.print()" class="pull-right" title="Print" href="javascript: void(0)">
                    <p class="glyphicon glyphicon-print  print">
                    </p>
                </a>
    <div class="col-sm-9" style=" min-height:300px;">
            <span style="font-size:30px;">
            <asp:Literal ID="LtrTitle" runat="server"></asp:Literal></span><br />
            <div style="width:200px;">
             <asp:Literal ID="LtrCntMiddleContent" runat="server"></asp:Literal></div>
            
        </div>


   
</asp:Content>

