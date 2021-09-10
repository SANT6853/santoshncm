<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Village_Management_View.aspx.cs" Inherits="auth_Adminpanel_VILLAGE_Village_Management_View" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="../assets/css/bootstrap.min.css" rel="stylesheet" />

	<style>
	    table{border-collapse: collapse; text-align:left !important;}
	</style>
</head>
<body>
<div class="container-fluid" style="margin-top:60px;">
   <form id="form1" runat="server" >
    <div>
    <table width="100%" class="table table-bordered table-striped" border="1px">
      <tr>
   
    <td align="right" width="100%" colspan="4">
        <asp:Button ID="ImageButton1" runat="server" CssClass="btn btn-primary" Text="Close" OnClientClick="javascript:window.close();" />
         </td>
    </tr>  
     <tr>
    <td colspan="4" bgcolor="#005529" align="center" style="font-size:larger; color:#fff; font-family:Verdana;"><strong>Village Details</strong></td>
  </tr>
   <tr>
        <td colspan="4" align="center"><asp:Label ID="lblMsg" runat="server" Cssclass="red-text"></asp:Label></td>
      </tr>
     <tr>
         <%-- <td align="right" class="for-view"> Survey Cut Of Date :</td>
    <td><asp:Label ID="lblcutdate" runat="server" CssClass="for-view-lable"></asp:Label> </td>--%>
   
    <td align="right" class="for-view" colspan="2"> Date Of Survey :</td>
    <td colspan="2"><asp:Label ID="lblsurdate" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
     <tr style="display:none">
   
    <td align="right" class="for-view" colspan="2"> State Village Code :</td>
    <td colspan="2"><asp:Label ID="lblstvillcode" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
    <tr>
    <td align="right" class="for-view"> Date of meeting:</td>
    <td><asp:Label ID="lbldtname0" runat="server" CssClass="for-view-lable"></asp:Label></td>
    
    <td align="right" class="for-view">Cutt-off Date:</td>
    <td><asp:Label ID="lbldtname1" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">
        District:</td>
    <td><asp:Label ID="lbldtname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    
    <td align="right" class="for-view">Tehsil&nbsp; :</td>
    <td><asp:Label ID="lbltehsil" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view">Gram panchayat&nbsp; :</td>
    <td><asp:Label ID="lblgp" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
    <td align="right" class="for-view">Village&nbsp; :</td>
    <td><asp:Label ID="lblname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr style="display:none;" >
    <td align="right" class="for-view">Village Code :</td>
    <td><asp:Label ID="lblcode" runat="server" CssClass="for-view-lable"></asp:Label></td>
    
    <td align="right" class="for-view"> Legal Status :</td>
    <td><asp:Label ID="lbllegstatus" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
     <tr>
    <td align="right" class="for-view"> Status :</td>
    <td><asp:Label ID="lblstatus" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view"> Core/Buffer Status :</td>
    <td><asp:Label ID="lblcorebuffstatus" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    
    <tr>
    <td align="right" class="for-view">Total Land(Ha) :</td>
    <td><asp:Label ID="lblland" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
    <td align="right" class="for-view">Total Agricultural Land(Ha) :</td>
    <td><asp:Label ID="lblagri" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>  
    <tr>
    <td align="right" class="for-view">Total Residential Land(Ha) :</td>
    <td><asp:Label ID="lblnonagri" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">Total Other Land(Ha) :</td>
    <td><asp:Label ID="lblotherland" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
     <tr>
    <td align="right" class="for-view">Value of Agricultural Land(Per Ha) :</td>
    <td><asp:Label ID="lblvalagri" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">Value of Residential Land(Per Ha) :</td>
    <td><asp:Label ID="lblvalres" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
   
    <tr>
    <td align="right" class="for-view">Total No Of Families :</td>
    <td><asp:Label ID="lblfamilies" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">Total Male Population :</td>
    <td><asp:Label ID="lblmalepop" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
   
    <tr>
    <td align="right" class="for-view">Total number of adult:</td>
    <td><asp:Label ID="lblmalepop1" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">Total number of transgender:</td>
    <td><asp:Label ID="lblmalepop0" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
      <tr>
    <td align="right" class="for-view">Total Female Population :</td>
    <td><asp:Label ID="lblfemalepop" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
     <td align="right" class="for-view">Total Population :</td>
    <td><asp:Label ID="lblpop" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr> 
     <td align="right" class="for-view">Total Number of OBC's :</td>
    <td><asp:Label ID="lblobc" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
     <td align="right" class="for-view">Total Number of ST's :</td>
    <td><asp:Label ID="lblst" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>  
    <tr> 
     <td align="right" class="for-view">Total Number of SC's :</td>
    <td><asp:Label ID="lblsc" runat="server" CssClass="for-view-lable"></asp:Label></td>

     <td align="right" class="for-view">Total Number of OTHERS :</td>
    <td><asp:Label ID="lblother" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>    
    <tr>
    <td align="right" class="for-view">Total No of Buffalo :</td>
    <td><asp:Label ID="lblsng0" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">Total No Of Cow :</td>
    <td><asp:Label ID="lblcnb" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
    <tr>
    <td align="right" class="for-view">Total No of&nbsp; Goat :</td>
    <td><asp:Label ID="lblsng" runat="server" CssClass="for-view-lable"></asp:Label></td>
  
    <td align="right" class="for-view">Total No Of Sheep :</td>
    <td><asp:Label ID="lblcnb0" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
     <tr>
    <td align="right" class="for-view">Total No Of Livestock :</td>
    <td><asp:Label ID="lbllivestocks" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
    <td align="right" class="for-view">Total No Of Other Animal :</td>
    <td><asp:Label ID="lblothranml" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
     <tr>
    <td align="right" class="for-view">File/Image attachment:</td>
    <td><asp:HyperLink ID="hypfile" Target="_blank" runat="server" ForeColor="#000099" Font-Bold="True" Font-Italic="True"></asp:HyperLink></td>
   
    <td align="right" class="for-view">Comments :</td>
    <td><asp:Label ID="lblcomments" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
    <tr>
    <td align="right" class="for-view">Latitude:</td>
    <td><asp:Label ID="LblLatitude" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
    <td align="right" class="for-view">Longitude:</td>
    <td><asp:Label ID="LblLagituted" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr> 
    <tr>
    <td align="right" class="for-view">File</td>
    <td><asp:Label ID="lblfile" runat="server" CssClass="for-view-lable"></asp:Label></td>
   
    <td align="right" class="for-view">&nbsp;</td>
    <td>&nbsp;</td>
    </tr> 
    </table>
    </div>
    </form>
	</div>
</body>
</html>
