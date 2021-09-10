<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="DpPermision.aspx.cs" Inherits="auth_Adminpanel_User_DpPermision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <div class="container">
    <div>User name:<b><asp:Literal ID="LtrUserName" runat="server"></asp:Literal></b></div>
    <div>
        Assign tiger reserve is:<b><asp:Literal ID="LtrTigerReserver" runat="server"></asp:Literal></b>
    </div>
    <div>
        <asp:RadioButtonList ID="Rdb" runat="server"></asp:RadioButtonList>
    </div>
    <div>
      <asp:Button ID="btnsubmit" runat="server"  Text="Submit" CssClass="btn btn-info" OnClick="btnsubmit_Click" />
    </div>
        </div>
</asp:Content>

