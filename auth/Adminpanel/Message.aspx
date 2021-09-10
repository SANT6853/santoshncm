<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="auth_Adminpanel_Message" %>
<%--<%@ Register Assembly="accopt" Namespace="accopt" TagPrefix="cc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <table width="50%" align="center">
     <tr>
    <td align="center"><br/><br/>
    </td>
    </tr>
         <tr>
    <td align="center"><br /><br/>
        &nbsp;</td>
    </tr>
         <tr>
    <td align="center"><br /><br/>
    </td>
    </tr>
         <tr>
    <td align="center"><br /><br/>
    </td>
    </tr>
    
    <tr>
    <td align="center" style="height: 6px"><asp:Label ID="lblMsg" runat="server"></asp:Label>
    </td>
    </tr>
    <tr>
    <td align="center">
        <asp:Button ID="ImageButton1" runat="server" Text="Add More" OnClick="ImageButton1_Click" CssClass="btn btn-primary btn-add" CausesValidation="False"  />
         <asp:Button ID="ImageButton2" runat="server" Text="Back" OnClick="ImageButton2_Click"  CssClass="btn btn-primary btn-add"  CausesValidation="False"  />
    
    </td>
    </tr>
    </table>
</asp:Content>

