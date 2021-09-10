<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFamilyHeadGrid.aspx.cs" Inherits="auth_Adminpanel_REPORT_ViewFamilyHeadGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" src="../JS/Script.js" type="text/javascript"></script>

    <link href="~/TIGERRESERVEADMIN/CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="~/TIGERRESERVEADMIN/CSS/ForValidationControl.css" type="text/css" />
    <link href="~/TIGERRESERVEADMIN/CSS/ModelStyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <script type="text/javascript">

        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);


        }
    </script>



    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <style>
        .pnlalignCenter
        {
            text-align:center;
        }
        .GridPager a, .GridPager span {
            display: block;
            height: 18px;
            width: 18px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
        }

        .GridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }

        .GridPager span {
            background-color: #A1DCF2;
            color: #000;
            border: 1px solid #3AC0F2;
        }

        .anchorColor {
            color: blue;
            text-decoration-line: underline;
        }

        .alt_row {
            background: #fff !important;
        }

        .background {
            background: #fff !important;
        }

        table tr {
            text-align: left !important;
        }

        .for-view, .alt_row {
            text-align: left !important;
        }

        .alt_row {
            font-weight: bold;
        }
		#btn_print{margin-left:3px;}
		.for-view-lable{color:#000;}
    </style>
    <style type="text/css">
        @media print {
            a[href]:after {
                content: none !important;
            }

            img[src]:after {
                content: none !important;
            }

            * {
                font-size: 10px !important;
            }

            #btnPrint, #ImageButton1 {
                display: none;
            }

            table {
            }

            th, td {
            }

            .table-2 {
                border: 1px solid #333333 !important;
            }

            @page {
                size:;
            }

            .table-2 {
                margin-top: 0 !important;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class=" container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
		<div class="col-sm-12">
            <div class="" style="margin-top: 20px;">
				
				<div class="row">
                    <div class="col-md-12 mt20">
                        <!--<h3>heading</h3>
                        <hr />-->
                        <div>
						<asp:Button ID="btn_print" runat="server" Text="Print" OnClick="btn_print_Click" CssClass="btn btn-primary pull-right" />
						<asp:Button ID="ImageButton1" runat="server" Text="Back" OnClick="ImageButton1_Click" CssClass="btn btn-primary pull-right" />
                        <asp:Button ID="BtnPdfHeadDetails" runat="server" Text="Export to Pdf of family details" CssClass="btn btn-warning" OnClick="BtnPdfHeadDetails_Click" />
						<asp:Button ID="BtnFamilyImagesHdtails" runat="server" Text="Export to Pdf of family head detail" CssClass="btn btn-warning" OnClick="BtnFamilyImagesHdtails_Click" />
						
						<div id="dvall" runat="server">
							<asp:Panel ID="PnlFamiyDetails" runat="server" Width="100%">                        
                        </div>
						</div>
                        <br />
                    </div>
                </div>

               
                   
                    <div class="col-md-12 mt20">
                        <%-- table used fore show family deatil --%>

                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class=" table table-bordered" style="padding-top: 10px;">

                            <tr>
                                <td colspan="4" bgcolor="#005529" align="center" style="color: #fff; font-size: large;"><strong>Family Details</strong></td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center" class="background">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="red-text"></asp:Label></td>
                            </tr>
                            <tr class="alt_row">
                                <td align="right" class="for-view">State :</td>
                                <td>
                                    <asp:Label ID="lblstateName" runat="server" CssClass="for-view-lable"></asp:Label>
                                </td>

                                <td align="right" class="for-view">District :</td>
                                <td>
                                    <asp:Label ID="lbldtname" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="background">
                                <td align="right" class="for-view">Reserve :</td>
                                <td>
                                    <asp:Label ID="lblrsname" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="for-view">Tehsil :</td>
                                <td>
                                    <asp:Label ID="lbltehsil" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="alt_row">Grampanchayat :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblgp" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="alt_row">Village :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblname" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="background">
                                <%-- <td align="right" class="for-view">Village Code :</td>
    <td><asp:Label ID="lblcode" runat="server" CssClass="for-view-lable"></asp:Label></td>--%>
                                <td align="right" class="for-view">Relocation Place :</td>
                                <td>
                                    <asp:Label ID="lblreloplace" runat="server" CssClass="for-view-lable"></asp:Label></td>
                                <td align="right" class="for-view">Family Code :</td>
                                <td>
                                    <asp:Label ID="lblfamcode" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="alt_row">Option Selected :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblscheme" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="alt_row">Group :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblgroupname" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="background">
                                <td align="right" class="for-view">Valid ID Name <span class="red-text-asterix"></span>:</td>
                                <td>
                                    <asp:Label ID="lblvalididname" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="for-view">Valid ID Card Number :</td>
                                <td>
                                    <asp:Label ID="lblrashan" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>

                            <tr>
                                <td align="right" class="alt_row">Agricultural Land(Ha) :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblagri" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="alt_row">Residential Land(Ha)<span class="red-text-asterix"></span> :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblres" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="background">
                                <td align="right" class="for-view">Status of Residence(Kachha/Pakka):</td>
                                <td>
                                    <asp:Label ID="lblresland" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="for-view">Wells :</td>
                                <td>
                                    <asp:Label ID="lblwells" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="alt_row">Standing Trees :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lbltrees" runat="server" CssClass="for-view-lable"></asp:Label></td>
                                <td align="right" class="alt_row">Other Assets :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblotherassets" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="background">
                                <td align="right" class="for-view">Total Livestock :</td>
                                <td>
                                    <asp:Label ID="lblstock" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="for-view">Cow :</td>
                                <td>
                                    <asp:Label ID="lblcownbuff" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="background">
                                <td align="right" class="for-view">Buffalo:</td>
                                <td>
                                    <asp:Label ID="lblfamstatus0" runat="server" CssClass="for-view-lable"></asp:Label>
                                </td>
                                <td align="right" class="for-view">Sheep:</td>
                                <td>
                                    <asp:Label ID="lblfamstatus1" runat="server" CssClass="for-view-lable"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="alt_row">&nbsp;Goat :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblsheepngoat" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="alt_row">Other Animal :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblotheranimal" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="background">
                                <td align="right" class="for-view">Relocation Status :</td>
                                <td>
                                    <asp:Label ID="lblfamstatus" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="for-view">Survey Date :</td>
                                <td>
                                    <asp:Label ID="Label75" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="alt_row">
                                <td align="right" class="for-view">Comments :</td>
                                <td colspan="3">
                                    <asp:Label ID="lblcomments" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>

                        </table>
                        </asp:Panel>
                        <br />

                        <%-- table used fore show family deatil --%>
                   <%-- </asp:Panel>--%>
                    
					 </div>
					 
					 
					 <div class="row">
                    <div class="col-md-12 mt20">
                  
                <%--<asp:Button ID="BtnPdfFamilyDetails" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfFamilyDetails_Click" />--%>
            
                  <asp:Panel ID="PnlHeadDetails" runat="server" Width="100%">
                        <table class="table table-bordered table-striped">



                            <%-- <div id="print_area" class="PrintStyle.css" >--%>


                            <tr>

                                <td colspan="2" style="background-color: #005529; color: #fff; font-size: large;" align="center" ><strong>Familiy Head Details</strong>
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
                                    <asp:HyperLink ID="hypfile" Target="_blank" runat="server"  CssClass="anchorColor" ForeColor="Blue" Font-Bold="True" Font-Italic="True"></asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink1" Target="_blank"  CssClass="anchorColor" runat="server" ForeColor="#000099" Font-Bold="True" Font-Italic="True">
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
                     </asp:Panel>
					 </div>
					 </div>
                
                </div>
            </div>
        </div>
        </div>

    </form>
</body>
</html>
