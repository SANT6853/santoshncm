<%@ Page Title="Associated NGO:NTCA" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Associate_Village1.aspx.cs" Inherits="auth_Adminpanel_NGO_Associate_Village1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            height: 106px;
        }

        .red-text-1a {
            color: red;
            font-size: larger;
        }

        .table-2 td {
            padding-left: 5px;
            text-align: left;
            width: 23% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
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
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


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
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="col-md-12">
			
                <table width="99%" border="0" cellspacing="0" cellpadding="0" class="table-2">
                    <tr>
                        <td colspan="6" style="border-bottom: 3px solid #005529;">
                            <h3 style="color: #005529;">Associated NGO</h3>
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right"></td>
                        <td align="right"></td>
                    </tr>
                    <tr>
                        <td class="black-text" align="right">
                            <asp:Label ID="lblvillage" runat="server" Text="Village Name:"></asp:Label><span class="red-text-1a">*</span>
                        </td>
                        <td style="width: ">
                            <asp:DropDownList ID="ddlvillage" Width="300" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="textfield" runat="server" ErrorMessage="Plese select the Village "
                                Display="Dynamic" ControlToValidate="ddlvillage" InitialValue="0" ValidationGroup="AssociateVillage" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="" width="20%"></td>
                        <td colspan="" width="20%"></td>
                        <td colspan="" width="20%"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1" align="right">
                            <asp:Label ID="lblngo" runat="server" Text="NGO Name:"></asp:Label><span class="red-text-1a">*</span>
                        </td>
                        <td class="auto-style1">
                            <br />
                            <asp:ListBox ID="ddlngo" CssClass="form-control" SelectionMode="Multiple" runat="server" Width="300"></asp:ListBox>

                            <%-- <asp:RequiredFieldValidator ID="reqvali1" CssClass="textfield"  runat="server" ErrorMessage="Plese select the NGO "
                            Display="Dynamic" ControlToValidate="ddlngo" InitialValue="0" ValidationGroup="AssociateVillage" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator> --%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlngo" InitialValue="" runat="server" ErrorMessage="Please select some items" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblDdngo" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="black-text" align="right">
                            <br />
                            <asp:Label ID="lblamount" runat="server"  Text="Amount(Rupees) released by tiger reserve:"></asp:Label><span class="red-text-1a">*</span>
                        </td>
                        <td style="width: 50%">
                            <br />
                            <asp:TextBox ID="txtamount" CssClass="form-control" runat="server" Width="300" MaxLength="50" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtamount"
                                CssClass="textfield" Display="Dynamic" ErrorMessage="Please Enter Amount" SetFocusOnError="True"
                                ValidationGroup="AssociateVillage" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="textfield" ControlToValidate="txtamount"
                                Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                ValidationGroup="AssociateVillage" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="black-text" align="right" style="width: 50%">
                            <br />
                            <asp:Label ID="lblworkdone" runat="server" Text="Work Done For facilitating voluntary village relocation:"></asp:Label>
                        </td>
                        <td style="width: 50%">
                            <br />
                            <asp:TextBox ID="txtworkdone" CssClass="form-control" TextMode="MultiLine" runat="server" Width="300"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                ControlToValidate="txtworkdone" Display="Dynamic" SetFocusOnError="true" ValidationGroup="AssociateVillage"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                        </td>
                    </tr>


                    <tr>
                        <td colspan="" width="20%"></td>

                        <td colspan="2" align="left" style="">
                            <br />
                            <br />
                            <asp:Button ID="btnsubmit" CssClass="btn btn-primary btn-add" runat="server" ValidationGroup="AssociateVillage" Text="Submit"
                                OnClick="btnsubmit_Click" />
                            <asp:Button ID="btnreset" CssClass="btn btn-primary btn-add" runat="server" Text="Reset"
                                OnClick="btnreset_Click" />
                            <asp:Button ID="btnback" CssClass="btn btn-primary btn-add" CausesValidation="false" runat="server" Text="Back"
                                OnClick="btnback_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

