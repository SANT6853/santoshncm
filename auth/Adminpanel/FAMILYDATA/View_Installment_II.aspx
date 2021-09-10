<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_Installment_II.aspx.cs" Inherits="auth_Adminpanel_FAMILYDATA_View_Installment_II" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
   <div>
     <table width="100%" class="table-2" border="1px" >
    <tr>
   
    <td align="right" width="100%" colspan="2">
        <asp:Button ID="ImageButton1" runat="server" CssClass="btn-mid" Text="Close" OnClientClick="javascript:window.close();" />
         </td>
    </tr>  
     <tr>
    <td colspan="2" bgcolor="#e1e0c4" align="center" style="font-size:larger; font-family:Verdana; color:#3F5E1B;"><strong> Installment Details</strong></td>
  </tr>
   <tr>
        <td colspan="2" align="center"><asp:Label ID="lblMsg" runat="server" Cssclass="red-text"></asp:Label></td>
      </tr>
   <tr>
    <td colspan="2" bgcolor="#e1e0c4" align="center" style="font-size:smaller; font-family:Verdana; color:#3F5E1B;"><strong>Account Holder Details</strong></td>
  </tr>
    <tr>
    <td align="right" class="for-view" width="50%"> Account Holder Name :</td>
    <td width="50%"><asp:Label ID="lblholname" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
      <tr>
    <td align="right" class="for-view" >
        Bank Name :</td>
    <td><asp:Label ID="lblbank" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view" >
        Branch Name :</td>
    <td><asp:Label ID="lblbranch" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view" >
        Acoount Number :</td>
    <td><asp:Label ID="lblacc" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
  <tr>
    <td colspan="2" bgcolor="#e1e0c4" align="center" style="font-size:smaller; font-family:Verdana; color:#3F5E1B;"><strong>Cheque Details</strong></td>
  </tr>
      <tr>
    <td align="right" class="for-view" >
        &nbsp; Cheque&nbsp;
        Amount(Rs.) :</td>
    <td><asp:Label ID="lblamount" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
   
 
      <tr>
    <td align="right" class="for-view" >
         Bank Name :</td>
    <td><asp:Label ID="lblckbankname" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view" >
          Branch Name :</td>
    <td><asp:Label ID="lblckbranch" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    <tr>
    <td align="right" class="for-view" >
        Cheque Number<span class="red-text-asterix"></span> :</td>
    <td><asp:Label ID="lblcheque" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
    
    <tr>
    <td align="right" class="for-view" >
        Date :</td>
    <td><asp:Label ID="lbldate" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
  
    <tr>
    <td align="right" class="for-view" >
        Installment Number :</td>
    <td><asp:Label ID="lblinstno" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>  

    </table>
    </div>
    </form>
</body>
</html>
