<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="FamilyHeadDetail.aspx.cs" Inherits="ReportGP_FamilyHeadDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBannerImages" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" Runat="Server">
       <asp:Panel ID="panel2" runat ="server" Width ="100%" >
         <span style="float:right">
     
      <asp:Button ID="ImageButton1" runat="server" CssClass="btn-mid" Text="Close" OnClientClick="javascript:window.close();" />
        <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click"  CssClass="btn-mid"  />
        </span>
        </asp:Panel>
       <asp:Panel ID="panel1" runat ="server" Width ="100%" >
      
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2" >
          
     <tr>
    
      <td   colspan="2" style="background-color: #e1e0c4; color:#743D02; font-size:large;" align="center" width="100%"><strong>
                 Familiy Head Details</strong>
                    </td>
  </tr>
   
     <tr>
    <td align="right" class="for-view" width="50%"> Head Name :</td>
    <td width="50%"><asp:Label ID="lblname" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
    
     <tr>
    <td align="right" class="for-view"> Father Name :</td>
    <td><asp:Label ID="lblfathername" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
    <tr>
    <td align="right" class="for-view"> Age(Years) :</td>
    <td><asp:Label ID="lblage" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
      <tr>
    <td align="right" class="for-view">
        Sex :</td>
    <td><asp:Label ID="lblsex" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">
        Caste :</td>
    <td><asp:Label ID="lblcast" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view">
        Valid Id Card Name :</td>
    <td><asp:Label ID="lblcardname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">
        Valid Id Card Number :</td>
    <td><asp:Label ID="lblvoter" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">
        Contact Number :</td>
    <td><asp:Label ID="lblcontact" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view">
        Education :</td>
    <td><asp:Label ID="lbledu" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view">
        Occupation<span class="red-text-asterix"></span> :</td>
    <td><asp:Label ID="lbloccu" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">
        Annual Income(Rs) :</td>
    <td><asp:Label ID="lblincome" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>  
 
<%--</div>--%>
    </table>
     </asp:Panel>
</asp:Content>

