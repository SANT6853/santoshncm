<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_FamilyMember_Details.aspx.cs" Inherits="auth_Adminpanel_FAMILYDATA_View_FamilyMember_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        .table-2 td {
            padding: 10px;
            text-align: left;
            width: 23% !important;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
            <div>


                <asp:Button ID="ImageButton1" runat="server" CssClass="btn btn-primary pull-right" Text="Close" OnClientClick="javascript:window.close();" />
                </br>
        <asp:Label ID="lblMsg" runat="server" CssClass="red-text"></asp:Label>
                <table width="100%" align="center" cellpadding="3" cellspacing="1" class="table-2 table-bordered " border="1px">



                    <%-- <div id="print_area" class="PrintStyle.css" >--%>


                    <tr>

                        <td colspan="2" style="background-color: #005529; color: #fff; font-size: large;" align="center" width="100%"><strong>Familiy Head Details</strong>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" class="for-view" width="50%">Head Name :</td>
                        <td width="50%">
                            <asp:Label ID="LblHeadName" runat="server" CssClass="for-view-lable"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" class="for-view">Photo:</td>
                        <td>
                            <asp:HyperLink ID="hypfile" Target="_blank" runat="server" CssClass="anchorColor" ForeColor="Blue" Font-Bold="True" Font-Italic="True"></asp:HyperLink>
                            <asp:Image ID="ImgPhoto" runat="server" Height="120px" Width="120px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Father Name :</td>
                        <td>
                            <asp:Label ID="lblfathername" runat="server" CssClass="for-view-lable"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">DOB:</td>
                        <td>
                            <asp:Label ID="LblDOB" runat="server" CssClass="for-view-lable"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Age(Years) :</td>
                        <td>
                            <asp:Label ID="lblage" runat="server" CssClass="for-view-lable"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Sex :</td>
                        <td>
                            <asp:Label ID="lblsex" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Caste :</td>
                        <td>
                            <asp:Label ID="lblcast" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Contact Number :</td>
                        <td>
                            <asp:Label ID="lblcontact" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Pan card :</td>
                        <td>
                            <asp:Label ID="LblPancard" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Voter Id :</td>
                        <td>
                            <asp:Label ID="LblVoterId" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Aadhaar Card :</td>
                        <td>
                            <asp:Label ID="LblAdhaarCard" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Any other Card Details :</td>
                        <td>
                            <asp:HyperLink ID="HyperLink1" Target="_blank" CssClass="anchorColor" runat="server" ForeColor="#000099" Font-Bold="True" Font-Italic="True">
                            </asp:HyperLink>

                            <asp:Image ID="Image1" runat="server" Height="120px" Width="120px" />
                            Card detail Title:<asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Total number of beneficiaries :</td>
                        <td>
                            <asp:Label ID="LblTotalNumberOfBeneficiaries" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Marital Status :</td>
                        <td>
                            <asp:Label ID="LblMaritalStatus" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Education :</td>
                        <td>
                            <asp:Label ID="LblEducation" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Occupation :</td>
                        <td>
                            <asp:Label ID="LblOccupation" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Annual Income(Rs) :</td>
                        <td>
                            <asp:Label ID="LblAnnualIncome" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Beneficiary Name :</td>
                        <td>
                            <asp:Label ID="LblBeneficiaryNameAddressMobileNo" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Beneficiary Address :</td>
                        <td>
                            <asp:Label ID="lblBenAddress" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Beneficiary Mobile no :</td>
                        <td>
                            <asp:Label ID="lblBenMobile" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Bank/Postal Account No :</td>
                        <td>
                            <asp:Label ID="LblBankPostalAccountNo" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Bank/Post office Name :</td>
                        <td>
                            <asp:Label ID="LblBankPostOfficeName" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">IFSC/Pin Code :</td>
                        <td>
                            <asp:Label ID="LblIFSCPinCode" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Bank Post office Address :</td>
                        <td>
                            <asp:Label ID="LblBankPostofficeAddress" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="for-view">Aadhar No :</td>
                        <td>
                            <asp:Label ID="LblAadharNo" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    </tr>


                    <%--</div>--%>
                </table>

            </div>
        </div>
    </form>

</body>
</html>
