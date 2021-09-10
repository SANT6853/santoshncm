<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="FundProgress.aspx.cs" Inherits="auth_Adminpanel_Villagerelocationprogress_FundProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<style>
.table-2 td{
padding:10px;
text-align:left;
width:23% !important;
vertical-align:top;
}
#btnback{
margin-left:4px;
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
 <table width="100%" align="center" cellpadding="3" cellspacing="1" class="Progress_table table-2">
  <tr>
   <td colspan="5" style="border-bottom: 3px solid #005529; padding-left:0px; padding-bottom:0px;"><h3 style="color: #005529;">Fund Progress</h3></td>
   
  </tr>
  <tr>
  <td colspan="2" align="center"><br />
      <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></td></tr>
<%--</table>
<table width="100%" align="center" cellpadding="3" cellspacing="1" class="table-2">--%>
     <tr><td align="right"><span style="font-size:15px; color:red;">*</span><label>Select State Name </label>:</td>
<td>
    <asp:DropDownList ID="ddlStatename" CssClass ="textfield-drop form-control" runat="server" OnSelectedIndexChanged="ddlStatename_SelectedIndexChanged" AutoPostBack="true" >
    </asp:DropDownList>  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Plese select the State "
                            Display="Dynamic" ControlToValidate="ddlStatename" InitialValue="0" ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
<td align="right"></td>
<td align="right"></td>

</tr>

     <tr><td align="right"><span style="font-size:15px; color:red;">*</span><label>Tiger Reserve</label>:</td>
<td>
    <asp:DropDownList ID="ddlTigerreserve" CssClass ="textfield-drop form-control" runat="server" OnSelectedIndexChanged="ddlTigerreserve_SelectedIndexChanged" AutoPostBack="true" >
    </asp:DropDownList>  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Plese select Tigerreserve "
                            Display="Dynamic" ControlToValidate="ddlTigerreserve" InitialValue="0" ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
<td align="right"></td>
<td align="right"></td>

</tr>

<tr><td align="right"><span style="font-size:15px; color:red;">*</span><label>Select Village Name </label>:</td>
<td>
    <asp:DropDownList ID="ddlvillage" CssClass ="textfield-drop form-control" runat="server" >
    </asp:DropDownList>  <asp:RequiredFieldValidator ID="req1" runat="server" ErrorMessage="Plese select the village "
                            Display="Dynamic" ControlToValidate="ddlvillage" InitialValue="0" ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
<td align="right"></td>
<td align="right"></td>

</tr>
<tr><td align="right"><span style="font-size:15px; color:red;">*</span><label> Option :</label>
</td>
<td >
    <asp:DropDownList ID="ddltype" CssClass ="textfield-drop form-control" runat="server" >
    <asp:ListItem Value ="0">Select</asp:ListItem>
    <asp:ListItem Value="1">I</asp:ListItem>
    <asp:ListItem Value="2">II</asp:ListItem>
    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Plese select the type "
                            Display="Dynamic" ControlToValidate="ddltype" InitialValue="0" ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>

</td>


</tr>
<tr><td align="right"><span style="font-size:15px; color:red;">*</span><label>Year:</label></td>
<td>
    <asp:TextBox ID="txttitle" runat="server" CssClass ="textfield form-control" ></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Plese Enter The Title "
                            Display="Dynamic" ControlToValidate="txttitle"  ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txttitle"
                                    ValidationGroup="1"   ValidationExpression="^((?:[A-Za-z0-9-'.,s_:%!()?$ ]+|&[^#])*&?)$" ErrorMessage="Title Allow Only(!,-,%,:,?,&,(),''and alphanumeric characters)"
                                    Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
    </td>

</tr>
<tr><td align="right"><span style="font-size:15px; color:red;">*</span><label> 	Fund :</label></td>
<td>
    <asp:TextBox ID="txtdescription" class="textfield form-control" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Plese Enter The Description "
                            Display="Dynamic" ControlToValidate="txtdescription"  ValidationGroup="1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>

<tr><td align="right">
<%--<label>Upload :</label></td>--%>
<td>
   <%-- <asp:FileUpload ID="FileUpload1"  runat="server" ForeColor="Green" />
     <span style="color:green; ">
        Image type formate support:jpg,jpeg,png.
         File type formate support:Pdf.
    </span>--%>
</td>
   
<tr>
<td align="right"></td>
<td colspan="2" align="center">
    <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary btn-add" ValidationGroup="1" Text="Save" onclick="btnsave_Click" />
        <asp:Button ID="btnreset"   runat="server" CssClass="btn btn-primary btn-add" Text="Reset" onclick="btnreset_Click" />
		<asp:Button            ID="btnback" CssClass="btn btn-primary btn-add" runat="server" Text="Back"         onclick="btnback_Click" /></td>

</tr>
</tr>
</tr>
</tr>
</table>
 </div>
 </div>
 </div>
</asp:Content>