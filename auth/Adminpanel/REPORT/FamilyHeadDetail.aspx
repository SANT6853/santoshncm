<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FamilyHeadDetail.aspx.cs" Inherits="auth_Adminpanel_REPORT_FamilyHeadDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="css/print.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <script language="javascript" src="../JS/Script.js" type="text/javascript"></script>


    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        #panel1 {
            padding-top: 40px;
        }
    </style>

</head>
<body>
    <div class="container-fluid" style="margin-top: 100px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <form id="form1" runat="server">



            <asp:Panel ID="panel2" runat="server" Width="100%">
                <span style="float: right">

                    <asp:Button ID="ImageButton1" runat="server" CssClass="btn btn-primary" Text="Close" OnClientClick="javascript:window.close();" />
                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click1" />
                    <asp:Button ID="Button1" runat="server" Visible="false" Text="Export to Excel" CssClass="btn btn-warning" OnClick="Button1_Click" />
                </span>
            </asp:Panel>
            <asp:Panel ID="panel1" runat="server" Width="100%">
                <div id="div_print">

                    <table id="tbpanel" runat="server" width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table table-bordered table-striped">



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
                                <asp:Image ID="ImgPhoto" runat="server" Height="100px" Width="100px" />
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
                            <td align="right" class="for-view">Cast :</td>
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
                            <td align="right" class="for-view">Adhaar Card :</td>
                            <td>
                                <asp:Label ID="LblAdhaarCard" runat="server" CssClass="for-view-lable"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="for-view">Any other Card Details :</td>
                            <td>
                                <asp:Image ID="Image1" runat="server" Height="120px" Width="120px" />
                                Card detail Title:<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

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
                            <td align="right" class="for-view">Beneficiary's Name,Address & Mobile no :</td>
                            <td>
                                <asp:Label ID="LblBeneficiaryNameAddressMobileNo" runat="server" CssClass="for-view-lable"></asp:Label></td>
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
                        <tr style="display:none;">
                            <td align="right" class="for-view">Aadhar No :</td>
                            <td>
                                <asp:Label ID="LblAadharNo" runat="server" CssClass="for-view-lable"></asp:Label></td>
                        </tr>


                        <%--</div>--%>
                    </table>
                </div>
            </asp:Panel>



        </form>
    </div>
</body>
</html>
