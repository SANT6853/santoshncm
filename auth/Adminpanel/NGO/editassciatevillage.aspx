<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="editassciatevillage.aspx.cs" Inherits="auth_Adminpanel_NGO_editassciatevillage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.table-2 td{
padding:6px;
text-align:left;

}
.textfield, .form-control {
    width: 50%;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


</script>
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 15px; background: #fff;">
<div class="inner-content-right">
    <table style="width: 100%;" cellspacing="0" cellpadding="0" class="table-2">
        <tr>
           
			  <td colspan="6" style="border-bottom: 3px solid #005529;">
                        <h3 style="color: #005529;">Edit Deatils</h3>
                    </td>	
              
          
        </tr>
        <tr>
           
            <td>
                &nbsp;
            </td>
            
        </tr>
        <tr>
           
            <td colspan="5" align="center">
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <asp:Panel Id="panel" runat="server" >
        <tr>
           
            <td class="black-text" align="right" >
                <asp:Label ID="village" runat="server" Text="Village Name :"></asp:Label>
            </td>
            <td > 
                <asp:Label ID="lblvillge" runat="server" Text=""></asp:Label>
            </td>
			<td width="20%"></td>
			<td width="20%"></td>
			<td width="20%"></td>
        </tr>
        <tr>
           
            <td class="black-text" align="right" >
                <asp:Label ID="ngo" runat="server" Text="Ngo Name :"></asp:Label>
            </td>
            <td style="width:50%"> 
                <asp:Label ID="lblngoname" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
           
            <td class="black-text" align="right" >
                 <asp:Label ID="lblamount" runat="server" Text="Amount Given:"></asp:Label>
            </td>
            <td style="width:50%">
              <asp:TextBox ID="txtamount" runat="server" CssClass="textfield form-control" MaxLength="50"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtamount"
            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Amount" SetFocusOnError="True"
            ValidationGroup="AssociateVillage"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix" ControlToValidate="txtamount"
            Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="AssociateVillage" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
            </td>
        </tr>
        <tr>
           
            <td class="black-text" align="right" style="width:20%">
                <asp:Label ID="lblworkdone" runat="server" Text="Work Done By Ngo For Village:"></asp:Label>
            </td>
            <td style="width:50%">
               <asp:TextBox ID="txtworkdone" TextMode="MultiLine" runat="server"  CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
           
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
         
        </asp:Panel>
         <tr>
           
            <td colspan="2" align="center">
               <asp:Button ID="btnsubmit" runat="server" ValidationGroup="AssociateVillage" CssClass="btn btn-primary btn-add" Text="Submit" 
        onclick="btnsubmit_Click" />
    <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary btn-add" Text="Reset" Visible="false" 
        onclick="btnreset_Click" />
    <asp:Button ID="btnback" runat="server" CssClass="btn btn-primary btn-add" Text="Back" 
        onclick="btnback_Click" />
            </td>
        </tr>
        
    </table>
    </div>
	</div>
</asp:Content>

