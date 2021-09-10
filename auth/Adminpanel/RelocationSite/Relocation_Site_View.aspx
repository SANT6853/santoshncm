<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Relocation_Site_View.aspx.cs" Inherits="auth_Adminpanel_RelocationSite_Relocation_Site_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="../CSS/style.css" rel="stylesheet" type="text/css" /><link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
	
    <table width="100%" class="table table-bordered " border="1px">
      <tr>
   
        <td align="right" width="100%" colspan="2">
        <asp:Button ID="ImageButton1" runat="server" CssClass="btn btn-primary" Text="Close" OnClientClick="javascript:window.close();" />
         </td>
    </tr>  
   <tr>
        <td colspan="2" align="center"><asp:Label ID="lblMsg" runat="server" Cssclass="red-text"></asp:Label></td>
      </tr>
    <tr>
    <td colspan="2" bgcolor="#005529" align="center" style="font-size:smaller; color:#fff; font-family:Verdana;"><strong>Current Village Details</strong></td>
  </tr>
    <tr>
    <td align="right" class="for-view" width="50%"> State:</td>
    <td width="50%"><asp:Label ID="lblstateName" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
      <tr>
    <td align="right" class="for-view">District:</td>
    <td><asp:Label ID="lbldtname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">
        Tiger Reserve Name :</td>
    <td><asp:Label ID="lblrsname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">Tehsil :</td>
    <td><asp:Label ID="lbltehsil" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">Grampanchayat :</td>
    <td><asp:Label ID="lblgp" runat="server" CssClass="for-view-lable" ></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view">Village:</td>
    <td><asp:Label ID="lblname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td colspan="2" bgcolor="#005529" align="center" style="font-size:smaller; color:#fff; font-family:Verdana;"><strong>Relocation Site Details</strong></td>
  </tr>
    <tr> 
     <td align="right" class="for-view">
         State :</td>
    <td><asp:Label ID="lblstname1" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>  
    <tr> 
     <td align="right" class="for-view">
         District :</td>
    <td><asp:Label ID="lbldtname1" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>    
    <tr>
    <td align="right" class="for-view">
        Tehsil :</td>
    <td><asp:Label ID="lblthname1" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
    
     <tr>
    <td align="right" class="for-view">
        Grampanchayat :</td>
    <td><asp:Label ID="lblgpname1" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
     <tr>
    <td align="right" class="for-view">
        Village :</td>
    <td><asp:Label ID="lblvillname1" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
     <tr>
    <td align="right" class="for-view">
        Addtress :</td>
    <td><asp:Label ID="lbladdress" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
   
   
     <tr>
    <td align="right" class="for-view">
        Latitude:</td>
    <td><asp:Label ID="LbLatitude" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
   
   
     <tr>
    <td align="right" class="for-view">
        Longitude:</td>
    <td><asp:Label ID="LblLongitutde" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
   
   
      <tr>
    <td align="right" class="for-view">Comments :</td>
    <td><asp:Label ID="lblcomments" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
    </table>
    </div>
	</div>
    </form>
</body>
</html>
