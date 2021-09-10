<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="editassciatevillage1.aspx.cs" Inherits="auth_Adminpanel_NGO_editassciatevillage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
         .red-text-1a {
        color:red;font-size:larger;
        }
		.table-2 td{
padding-left:5px;
text-align:left;
width:10% !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <script language="Javascript">
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
    //-->
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#<%= btnsubmit.ClientID %>').click(function (e) {
                debugger;
                if ($('#<%= ddlngo.ClientID %>').val() == null) {
                    $('#<%= lblDdngo.ClientID %>').html("<span style='color:red;'>Plese select the NGO</span>");

                }

            });
        });
    </script>
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
    <table style="width: 100%;" cellspacing="0" cellpadding="0" class="table-2">
        <tr>
           
            <td colspan="5" style="border-bottom: 3px solid #005529;"><h3 style="color: #005529;">Edit Deatils   </h3></td>
              
          
        </tr>
        <tr>
           
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
           
            <td colspan="2" align="center">
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <asp:Panel Id="panel" runat="server" >
        <tr>
           
            <td class="black-text" align="left" >
                <asp:Label ID="village" runat="server" Text="Village Name :"></asp:Label>
            </td>
            <td > 
                <asp:Label ID="lblvillge" runat="server" Text="" Width="300" CssClass="form-control"></asp:Label>
            </td>
			<td colspan="" width="20%"></td>
			<td colspan="" width="20%"></td>
			<td colspan="" width="20%"></td>
			
        </tr>
		<tr><td><br/></td></tr>
        <tr>
           
            <td class="black-text" align="right" style="width:50%">
                <asp:Label ID="ngo" runat="server" Text="Ngo Name :"></asp:Label><span class="red-text-1a">*</span>
            </td>
            <td style="width:70%"> 
                <asp:Label ID="lblngoname" runat="server" Text=""></asp:Label>
                 <asp:ListBox ID="ddlngo" CssClass="form-control" SelectionMode="Single" runat="server" Width="300"  ></asp:ListBox>
   
     <asp:RequiredFieldValidator ID="reqvali1" CssClass="textfield" runat="server" ErrorMessage="Plese select the NGO "
                            Display="Dynamic" ControlToValidate="ddlngo" InitialValue="0" ValidationGroup="AssociateVillage" SetFocusOnError="True" ForeColor="#CC3300"></asp:RequiredFieldValidator> 
            <asp:Label ID="lblDdngo" runat="server" ForeColor="Red"></asp:Label>
                 </td>
        </tr>
		<tr><td><br/></td></tr>
        <tr>
           
            <td class="black-text" align="right" style="width:50%">
                 <asp:Label ID="lblamount" runat="server" Text="Amount Given:"></asp:Label>
            </td>
            <td style="width:30%">
              <asp:TextBox ID="txtamount" runat="server" CssClass="textfield form-control" MaxLength="50" Width="300" onkeypress="return isNumberKey(event)"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtamount"
            CssClass="red-text-asterix" ForeColor="Red" Display="Dynamic" ErrorMessage="Please Enter Amount" SetFocusOnError="True"
            ValidationGroup="AssociateVillage"></asp:RequiredFieldValidator>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" CssClass="red-text-asterix" ControlToValidate="txtamount"
            Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="AssociateVillage" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
            </td>
        </tr>
		<tr><td><br/></td></tr>
        <tr>
           
            <td class="black-text" align="right" style="width:50%">
                <asp:Label ID="lblworkdone" runat="server" Text="Work Done By Ngo For Village:"></asp:Label>
            </td>
            <td style="width:50%">
               <asp:TextBox ID="txtworkdone" TextMode="MultiLine" CssClass=" form-control" runat="server" Width="300" ></asp:TextBox>
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
		 <td colspan="1"></td>
           
            <td colspan="2" align="center">
               <asp:Button ID="btnsubmit" runat="server" ValidationGroup="AssociateVillage" CssClass="btn btn-primary btn-add" Text="Submit" 
        onclick="btnsubmit_Click" />
    <asp:Button ID="btnreset" runat="server" Visible="false" CssClass="btn btn-primary btn-add" Text="Reset" 
        onclick="btnreset_Click" />
    <asp:Button ID="btnback" runat="server" CssClass="btn btn-primary btn-add" Text="Back" 
        onclick="btnback_Click" />
            </td>
        </tr>
        
    </table>
    </div>
</div>	
</div>
</asp:Content>

