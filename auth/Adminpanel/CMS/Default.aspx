<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="auth_Adminpanel_CMS_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
        <tr>
            <td>
                First Name
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="*" ValidationGroup="a" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtFirstName"
                    runat="server" />
               <asp:RegularExpressionValidator ID="regUsername" Display="Dynamic" SetFocusOnError="true"
                                        runat="server" ErrorMessage="Minimum 5 characters use." ValidationGroup="a"
                                        ControlToValidate="txtFirstName"
                                        ValidationExpression="^.{5,35}$" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Last Name:
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="*" ValidationGroup="a" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtLastName"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Designation:
            </td>
            <td>
                <asp:TextBox ID="txtDesignation" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="*" ValidationGroup="a" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtDesignation"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Address:
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="*" ValidationGroup="a" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtAddress"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Telephone:
            </td>
            <td>
                <asp:TextBox ID="txtTelephone" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="*" ValidationGroup="a" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtTelephone"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Email:
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="*" ValidationGroup="a" SetFocusOnError="true" ForeColor="Red" ControlToValidate="txtEmail"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td colspan="2">
                <asp:Button ID="btnSubmit" ValidationGroup="a" Text="Submit" runat="server" />
            </td>
        </tr>
    </table>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        if (!Page_Validators[i].isvalid) {
                            var control = $("#" + Page_Validators[i].controltovalidate);

                            var top = control.offset().top;
                            $('html, body').animate({ scrollTop: top - 10 }, 800);
                            control.focus();
                            return;
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
</asp:Content>

