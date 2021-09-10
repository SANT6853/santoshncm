<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_Family_Details.aspx.cs" Inherits="auth_Adminpanel_FAMILYDATA_View_Family_Details" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
<title></title>
<style>
.btn-primary {
    color: #fff;
    background-color: #337ab7;
    border-color: #2e6da4;
}
.btn {
    display: inline-block;
    padding: 6px 12px;
    margin-bottom: 0;
    font-size: 14px;
    font-weight: 400;
    line-height: 1.42857143;
    text-align: center;
    white-space: nowrap;
    vertical-align: middle;
    -ms-touch-action: manipulation;
    touch-action: manipulation;
    cursor: pointer;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    background-image: none;
    border: 1px solid transparent;
    border-radius: 4px;
}
table{
	border:1px solid #ddd;
	font-family: sans-serif;
}
table tr td{
	padding:6px;
	border:1px solid #ddd;
	border-top:0;
	border-left:0;
}
.pull-right{
	float:right;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table width="100%"  class="table-2" cellspacing="0" cellpadding="0" border="0">
     <tr>
     <tr>
    <td colspan="4" bgcolor="#e1e0c4" align="center" style="padding:6px; font-size:larger; font-family:Verdana; color:#3F5E1B;"><strong> Village Details</strong> <asp:Button ID="ImageButton1" runat="server" CssClass="btn-mid btn btn-primary btn-sm pull-right" Text="Close" OnClientClick="javascript:window.close();" /></td>
  </tr>
   <tr>
        <td colspan="4" align="center"><asp:Label ID="lblMsg" runat="server" Cssclass="red-text" ></asp:Label></td>
      </tr>
    <tr>
    <td align="right" class="for-view"> &nbsp;</td>
    <td>&nbsp;</td>
  
    <td align="right" class="for-view">&nbsp;</td>
    <td>&nbsp;</td>
    </tr>
    <tr>
    <td align="right" class="for-view">District :</td>
    <td><asp:Label ID="lbldtname" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">Tehsil :</td>
    <td><asp:Label ID="lbltehsil" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">Grampanchayat :</td>
    <td><asp:Label ID="lblgp" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">Village :</td>
    <td><asp:Label ID="lblname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
   <%-- <td align="right" class="for-view">Village Code :</td>
    <td><asp:Label ID="lblcode" runat="server" CssClass="for-view-lable"></asp:Label></td>--%>
    <td align="right" class="for-view" style="display:none;">Relocation Place  :</td>
    <td style="display:none;"><asp:Label ID="lblreloplace" runat="server" CssClass="for-view-lable"></asp:Label></td>
    <td align="right" class="for-view" style="display:none;">
        Family Code :</td>
    <td style="display:none;" ><asp:Label ID="lblfamcode" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>  
    <tr>
    <td align="right" class="for-view">
        Option Selected :</td>
    <td><asp:Label ID="lblscheme" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">
        Group :</td>
    <td><asp:Label ID="lblgroupname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view">
         Valid ID Name <span class="red-text-asterix"></span>:</td>
    <td><asp:Label ID="lblvalididname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    
    <td align="right" class="for-view">
       Valid ID Card Number :</td>
    <td><asp:Label ID="lblrashan" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>  
   
    <tr>
    <td align="right" class="for-view"> Agricultural Land(Ha) :</td>
    <td><asp:Label ID="lblagri" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
    <td align="right" class="for-view">
        Residential Land(Ha)<span class="red-text-asterix"></span> :</td>
    <td><asp:Label ID="lblres" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
      <tr>
    <td align="right" class="for-view">
         Status of Residence(Kachcha/Pakka):</td>
    <td><asp:Label ID="lblresland" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
     <td align="right" class="for-view"> Wells :</td>
    <td><asp:Label ID="lblwells" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr> 
     <td align="right" class="for-view"> Standing Trees :</td>
    <td><asp:Label ID="lbltrees" runat="server" CssClass="for-view-lable"></asp:Label></td>
    <td align="right" class="for-view">
        Other Assets :</td>
    <td><asp:Label ID="lblotherassets" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
     <td align="right" class="for-view">
        Total Livestock :</td>
    <td><asp:Label ID="lblstock" runat="server" CssClass="for-view-lable"></asp:Label></td>
    
     <td align="right" class="for-view">
         Cow :</td>
    <td><asp:Label ID="lblcownbuff" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
     <td align="right" class="for-view">
         Buffalo:</td>
    <td><asp:Label ID="lblstock0" runat="server" CssClass="for-view-lable"></asp:Label></td>
    
     <td align="right" class="for-view">
         &nbsp;Goat</td>
    <td><asp:Label ID="lblcownbuff0" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
     <td align="right" class="for-view">
         Sheep&nbsp; :</td>
    <td><asp:Label ID="lblsheepngoat" runat="server" CssClass="for-view-lable"></asp:Label></td>
 
    <td align="right" class="for-view"> Other Animal :</td>
    <td><asp:Label ID="lblotheranimal" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
   <tr>
    <td align="right" class="for-view">
        Relocation Status :</td>
    <td><asp:Label ID="lblfamstatus" runat="server" CssClass="for-view-lable"></asp:Label></td>
    
    <td align="right" class="for-view">  Survey Date :</td>
   <td><asp:Label ID="lbldate" runat="server" CssClass="for-view-lable"></asp:Label></td>
   </tr>
   <tr>
    <td align="right" class="for-view" >
        Comments :</td>
         <td colspan="3">
         <asp:Label ID="lblcomments" runat="server" CssClass="for-view-lable"></asp:Label></td
   </tr>
  
    </table>
    </div>
    </form>
</body>
</html>
