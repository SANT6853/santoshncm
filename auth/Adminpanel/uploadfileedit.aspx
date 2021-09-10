<%@ Page Title="NTCA:Edit related file images" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="uploadfileedit.aspx.cs" Inherits="auth_Adminpanel_uploadfileedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<style>
.table-2 td{
padding:10px;
text-align:left;
    width: 23% !important;
	vertical-align:top;
}
.container-fluid{
margin-bottom:50px !important;
}
.textfield-drop{width:70%;}
</style>

    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


</script>
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
<div class="wrapper-content" style="padding-top:0px;">	
<div class="inner-content-right">
<table width="100%" align="center" cellpadding="3" cellspacing="1" class="table-2">
  <tr>
    <td colspan="5" style="border-bottom: 3px solid #005529; padding-left:0px; padding-bottom:0px;"><h3 style="color: #005529;">Edit Related files for village</h3></td>
    
  </tr>
  <tr>
  <td colspan="2" align="center"><br />
      <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></td></tr>
<%--</table>
<table width="100%" align="center" cellpadding="3" cellspacing="1" class="table-2">--%>

<tr><td align="right" width="50%"><span style="font-size:15px; color:red;">*</span><label>Select Village Name :</label></td>
<td width="50%">
    <asp:DropDownList ID="ddlvillage" CssClass ="textfield-drop form-control" Enabled="false" runat="server" >
    </asp:DropDownList>  <asp:RequiredFieldValidator ID="req1" runat="server" ErrorMessage="Plese select the village "
                            Display="Dynamic" ControlToValidate="ddlvillage" InitialValue="0" ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
<td align="right"></td>
<td align="right"></td>

</tr>
<tr><td align="right"><span style="font-size:15px; color:red;">*</span><label> Image/File :</label>
</td>
<td >
    <asp:DropDownList ID="ddltype" CssClass ="textfield-drop form-control" runat="server" >
    <asp:ListItem Value ="0">Select</asp:ListItem>
    <asp:ListItem Value="1">Image</asp:ListItem>
    <asp:ListItem Value="2">File</asp:ListItem>
    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Plese select the type "
                            Display="Dynamic" ControlToValidate="ddltype" InitialValue="0" ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>

</td>


</tr>
<tr><td align="right"><span style="font-size:15px; color:red;">*</span><label>Title:</label></td>
<td>
    <asp:TextBox ID="txttitle" runat="server" class="textfield form-control"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Plese Enter The Title "
                            Display="Dynamic" ControlToValidate="txttitle"  ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txttitle"
                                    ValidationGroup="1"   ValidationExpression="^((?:[A-Za-z0-9-'.,s_:%!()?$ ]+|&[^#])*&?)$" ErrorMessage="Title Allow Only(!,-,%,:,?,&,(),''and alphanumeric characters)"
                                    Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
    </td>

</tr>
<tr><td align="right"><span style="font-size:15px; color:red;">*</span><label> 	Description :</label></td>
<td>
    <asp:TextBox ID="txtdescription" TextMode="MultiLine" class="textfield form-control" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Plese Enter The Description "
                            Display="Dynamic" ControlToValidate="txtdescription"  ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>

<tr><td align="right">
<label>Upload :</label></td>
<td>
    <asp:FileUpload ID="FileUpload1"  runat="server" ForeColor="Green" /><br />
    <asp:HyperLink ID="hypfile" Target="_blank" runat="server" ForeColor="Green">Uploaded File</asp:HyperLink>
    </td>

<tr>
<td align="right"></td>

<td colspan="2" style="text-align:left;">

    <asp:Button ID="btnsave"
        runat="server" CssClass="btn btn-primary btn-add" ValidationGroup="1" Text="Submit" onclick="btnsave_Click" />
        <asp:Button ID="btnreset"
        runat="server" CssClass="btn btn-primary btn-add" Text="Reset" Visible="false" onclick="btnreset_Click" /><asp:Button
            ID="btnback" CssClass="btn btn-primary btn-add" runat="server" Text="Back" 
        onclick="btnback_Click" /></td>

</tr>
</tr>
</tr>
</tr>
</table>
</div>
</div>
</div>
</asp:Content>

