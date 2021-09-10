<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="VillageManagement.aspx.cs" Inherits="auth_Adminpanel_VILLAGE_VillageManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
      <asp:FileUpload ID="FileUpload2" runat="server" />  
    <div class="col-md10">
     <p style="text-align-left">  
        <asp:FileUpload ID="FileUpload1" runat="server" />  
    </p>  
    <p>  
        <asp:ListBox ID="ListBox1" runat="server" Rows="5" SelectionMode="Single" Width="221px" BackColor="#CCCCFF">  
        </asp:ListBox>  
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>  
    </p>  
    <p>  
        <asp:Button ID="Button1" runat="server" Text="Add" Width="75px" OnClick="Button1_Click" />  
        <asp:Button ID="Button2" runat="server" Text="Remove" Width="98px" OnClick="Button2_Click" />  
    </p>  
    </div>
</asp:Content>

