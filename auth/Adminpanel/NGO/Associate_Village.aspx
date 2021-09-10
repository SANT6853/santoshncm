<%@ Page Title="NTCA:" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Associate_Village.aspx.cs" Inherits="auth_Adminpanel_NGO_Associate_Village" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


</script>
<div class="inner-content-right">
<table width="99%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td bgcolor="#e1e0c4" align="center" 
          style="font-size:smaller; color:#3F5E1B;" colspan="2"><strong >
        Associate NGO</strong></td>
  </tr>
  <tr>
    <td colspan="2">&nbsp;</td>
  </tr>
 <tr>
 <td align ="center" colspan="2" >
     <asp:Label ID="lblmsg" runat="server" ForeColor="#CC3300"></asp:Label></td>
  </tr> 
 <tr>
    <td  align="right" >
   
        </td>
    <td  align="right" >
   
        </td>
</tr>
<tr>
<td class="black-text" align="right" style="width:50%">
    <asp:Label ID="lblvillage" runat="server" Text="Village Name:"></asp:Label><span class="red-text-1a">*</span>
</td>
<td style="width:50%">
    <asp:DropDownList ID="ddlvillage" Width="120" CssClass="form-control" runat="server">
    </asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="textfield" runat="server" ErrorMessage="Plese select the Village "
                            Display="Dynamic" ControlToValidate="ddlvillage" InitialValue="0" ValidationGroup="AssociateVillage" SetFocusOnError="True" ForeColor="#CC3300"></asp:RequiredFieldValidator> 
</td>
</tr>
<tr>
<td class="black-text" align="right" style="width:50%">
    <asp:Label ID="lblngo" runat="server" Text="NGO Name:"></asp:Label><span class="red-text-1a">*</span>
</td>
<td style="width:50%">
<br />
    <asp:ListBox ID="ddlngo" CssClass="form-control" SelectionMode="Multiple" runat="server" Width="530"  ></asp:ListBox>
   
     <asp:RequiredFieldValidator ID="reqvali1" CssClass="textfield" runat="server" ErrorMessage="Plese select the NGO "
                            Display="Dynamic" ControlToValidate="ddlngo" InitialValue="0" ValidationGroup="AssociateVillage" SetFocusOnError="True" ForeColor="#CC3300"></asp:RequiredFieldValidator> 
                            
</td>
</tr>
<tr>
<td class="black-text" align="right" style="width:50%">
<br />
    <asp:Label ID="lblamount" runat="server" Text="Amount Given:"></asp:Label>
    </td>
<td style="width:50%">
<br />
    <asp:TextBox ID="txtamount" CssClass="form-control" runat="server" Width="80px"  MaxLength="50"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtamount"
            CssClass="textfield" Display="Dynamic" ErrorMessage="Please Enter Amount" SetFocusOnError="True"
            ValidationGroup="AssociateVillage" ForeColor="#CC3300"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  runat="server" CssClass="textfield" ControlToValidate="txtamount"
            Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="AssociateVillage" ForeColor="#CC3300" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
</td>
</tr>
 <tr>
<td class="black-text" align="right" style="width:50%">
<br />
    <asp:Label ID="lblworkdone" runat="server" Text="Work Done By NGO For Village:"></asp:Label>
    </td>
<td style="width:50%">
<br />
    <asp:TextBox ID="txtworkdone" CssClass="form-control" TextMode="MultiLine" runat="server" Width="530" ></asp:TextBox>
</td>
</tr>


<tr>
<td colspan="2" align="center">
<br /><br />
    <asp:Button ID="btnsubmit" CssClass="btn btn-primary btn-add" runat="server" ValidationGroup="AssociateVillage"  Text="Submit" 
        onclick="btnsubmit_Click" />
    <asp:Button ID="btnreset" CssClass="btn btn-primary btn-add" runat="server"  Text="Reset" 
        onclick="btnreset_Click" />
    <asp:Button ID="btnback" CssClass="btn btn-primary btn-add" runat="server"  Text="Back" 
        onclick="btnback_Click" />
</td>
</tr>
</table>
</div>
</asp:Content>

