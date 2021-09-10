<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFamilyData.aspx.cs" Inherits="auth_Adminpanel_REPORT_ViewFamilyData" %>

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
        <div class=" container-fluid" style="margin-top: 10px;">

            <div class="table_new01" style="margin-top: 20px;">

                <span style="float: right; margin-bottom: 20px;">
                    <asp:Button ID="ImageButton1" runat="server" Text="Back" OnClick="ImageButton1_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" Width="94px" CssClass="btn btn-primary" /></span>
                <asp:Panel ID="PRINT" runat="server">
                    <asp:Panel ID="panel4" runat="server" Width="100%">
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

                                <td align="right" class="alt_row" style="display:none">Village :</td>
                                <td class="alt_row" style="display:none">
                                    <asp:Label ID="lblname" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr class="background">
                                <%-- <td align="right" class="for-view">Village Code :</td>
    <td><asp:Label ID="lblcode" runat="server" CssClass="for-view-lable"></asp:Label></td>--%>
                                <td align="right" class="for-view" style="display:none">Relocation Place :</td>
                                <td  style="display:none">
                                    <asp:Label ID="lblreloplace" runat="server" CssClass="for-view-lable"></asp:Label></td>
                                <td align="right" class="for-view" style="display:none">Family Code :</td>
                                <td style="display:none">
                                    <asp:Label ID="lblfamcode" runat="server" CssClass="for-view-lable"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="alt_row">Option Selected :</td>
                                <td class="alt_row">
                                    <asp:Label ID="lblscheme" runat="server" CssClass="for-view-lable"></asp:Label></td>

                                <td align="right" class="alt_row" style="display:none">Group :</td>
                                <td class="alt_row" style="display:none">
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
                                <td align="right" class="for-view">Status of Residence(Kachcha/Pakka):</td>
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
                        <br />

                        <%-- table used fore show family deatil --%>
                    </asp:Panel>

                    <asp:Panel ID="panel2" runat="server" Width="100%">
                    </asp:Panel>
                    <asp:Panel ID="panel3" runat="server" Width="100%">
                    </asp:Panel>
                    <asp:Panel ID="headdetails" runat="server" Width="100%">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table table-bordered table-striped">



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




                        <br />

                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="background-color: #005529; color: #fff; font-size: large;" align="center" width="100%"><strong>Family Member Details</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--<asp:GridView ID="gv_FamilyMemberDetail" runat="server" AutoGenerateColumns="False"  CellPadding="0"
                        CellSpacing="0"  PageSize="10" bgColor=""
                           
                        Width="100%"   RowStyle-Wrap="true" HeaderStyle-Wrap="true"   CssClass= "table table-bordered" > 
                      <HeaderStyle   HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"   ForeColor="white"/> 
         <RowStyle CssClass="" />
                   <AlternatingRowStyle CssClass="" />
                       <EmptyDataTemplate >
                       <asp:Label ID="NoDataFound" runat ="server" Text ="No Record Found" ></asp:Label>
                       
                       </EmptyDataTemplate>
                        <Columns>
                        
                            <asp:TemplateField HeaderText="S No.">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>' ></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="Name">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="Age(Years)">
                                <ItemStyle HorizontalAlign="Center"/>
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                       <asp:Label ID="lblage" runat="server" Text='<%#Eval("FMLY_MEMB_AGE") %>' ></asp:Label>
                                  </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sex">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong >
                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_SEX")%>
                                   </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                                

                            <asp:TemplateField HeaderText="Education">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_EDU")%>
                     
                                  </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Annual Income(in Rs)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ANUL_INCM")%>
                      
                                  </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                             <asp:TemplateField HeaderText="Relation With Head">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "RELATION_NAME")%>
                      
                                  </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                                                  
                                                  
                                                     <asp:TemplateField HeaderText="Cast">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CAST")%>
                      
                                  </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Valid ID Name">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%>
                      
                                  </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                              <asp:TemplateField HeaderText="Valid ID Number">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NO")%>
                      
                                  </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Contact Number">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CONT_NO")%>
                      
                                  </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                        </Columns>
                        <PagerSettings />
                        <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="white"
                            HorizontalAlign="Center" />
                        <RowStyle Wrap="True" />
            </asp:GridView>--%>
                                    <asp:GridView ID="gv_FamilyMemberDetail" runat="server" AutoGenerateColumns="False" CellPadding="0" ShowFooter="true"
                                        CellSpacing="0" PageSize="10" 
                                        Width="100%" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered" OnRowDataBound="gv_FamilyMemberDetail_RowDataBound">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="white" />
                                        <FooterStyle BackColor="#f5f5dc" />

                                        <EmptyDataTemplate>
                                            <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>

                                        </EmptyDataTemplate>
                                        <Columns>

                                            <asp:TemplateField HeaderText="S No.">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <asp:Label ID="lblFMLY_MEMB_NM" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Relation With Head">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>




                                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_NM")%>
                      
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Photo">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <strong>

                                                            <a href="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("Photo") %>" rel="lightbox[slide]" target="_blank">
                                                                <%--<img src="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("Photo") %>" alt="<%# Eval("Photo") %>" width="100" height="100" />--%>
                                                                <img src="http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/<%#Eval("Photo") %>" width="100" height="100" />
                                                            </a>

                                                        </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Father Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <strong>

                                                            <asp:Label ID="lblageFATHER_NM" runat="server" Text='<%#Eval("FATHER_NM") %>'></asp:Label>

                                                        </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOB">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <strong>

                                                            <asp:Label ID="lblageDOB1" runat="server" Text='<%#Eval("DOB1") %>'></asp:Label>

                                                        </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Age(Years)">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>



                                                        <asp:Label ID="lblageFMLY_MEMB_AGE" runat="server" Text='<%#Eval("FMLY_MEMB_AGE") %>'></asp:Label>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Sex">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_SEX")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cast">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CAST")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Number">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CONT_NO")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pan card">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "PenCard")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Voter Id">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Adhaar Card">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <asp:Label ID="LblAdharCard" runat="server" Text='<%# Eval("AdhaarCard") %>'></asp:Label>
                                                      <%--  <%#DataBinder.Eval(Container.DataItem, "AdhaarCard")%>--%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Any other Card Details">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <a href="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("IdentityCardPhoto") %>" rel="lightbox[slide]" target="_blank">
                                                            <%#Eval("IdentityCardPhoto") %> </a>
                                                    </strong>
                                                    <strong>CARD DETAILS TITLE:<%#DataBinder.Eval(Container.DataItem, "IdentityCardPhotoTitle")%></strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total number of beneficiaries">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "NoBeneficiary")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Marital Status">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "MaritalStatus")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Education">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>

                                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_EDU")%>
                     
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Occupation">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>

                                                        <%#DataBinder.Eval(Container.DataItem, "OCCUPATION_NAME")%>
                     
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Annual Income(Rs)">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ANUL_INCM")%>
                      
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="18+ Required information">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <span>BENEFICIARY'S NAME,ADDRESS & MOBILE NO: <strong><%#DataBinder.Eval(Container.DataItem, "BankNameMobile")%>         
                                                    </strong>
                                                    </span>
                                                    <span>BANK/POSTAL ACCOUNT NO: <strong><%#DataBinder.Eval(Container.DataItem, "BankPostAccountNo")%>         
                                                    </strong>
                                                    </span>
                                                    <span>BANK/POST OFFICE NAME:<strong><%#DataBinder.Eval(Container.DataItem, "BankPostOfficeName")%></strong></span><span><strong>IFSC/Pin Code:<%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%></strong></span><span><strong>Bank Post office Address: <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%>         
                                                    </strong>
                                                    </span>
                                                    <span>IFSC/PIN CODE:<strong><%#DataBinder.Eval(Container.DataItem, "IFSC")%></strong></span><span>Bank Post office Address:<strong><%#DataBinder.Eval(Container.DataItem, "BankPostOfficeAdress")%></strong>
                                                       <%--</span><span>AADHAR NO:<br />--%>
                                                        <strong>
                                                             <asp:Label ID="LblAdharCardLast" Visible="false" runat="server" Text='<%# Eval("AadharNo") %>'></asp:Label>
                                                                 
                                                        </strong>
                                                    </span>


                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerSettings />
                                        <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black"
                                            HorizontalAlign="right" />
                                        <RowStyle Wrap="True" />
                                    </asp:GridView>
                                    <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnExcelExport_Click" />
                                    <asp:Button ID="BtnPDFexport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPDFexport_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                        <br />

                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">



                            <%-- <div id="print_area" class="PrintStyle.css" >--%>


                            <tr>

                                <td style="display:none;  background-color: #005529; color: #fff; font-size: large;" align="center" width="100%"><strong>Installment Details</strong>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" width="100%" style="display:none;">
                                    <asp:GridView ID="gv1B" runat="server" AutoGenerateColumns="False" CellPadding="0" ShowFooter="true"
                                        CellSpacing="0" AllowPaging="True" PageSize="10" DataKeyNames="INST_ISCM_ID"
                                        Width="100%" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered" ForeColor="white" />
                                        <RowStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="" />
                                        <PagerStyle CssClass="pgr" />
                                        <FooterStyle BackColor="#f5f5dc" />

                                        <Columns>
                                            <asp:TemplateField HeaderText="S. No.">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Holder's Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>

                                                        <%#DataBinder.Eval(Container.DataItem, "INST_ISCM_HOLD_NM")%>
                    
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Bank Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "BANK_NAME")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="A/C No.">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "ACCOUNT_NO")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Installment No.">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("INST_ISCM_NO") %>'></asp:Label>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "REC_CRT_DT")%>
                                    
                                                    </strong>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount(in Rs.)">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "INST_ISCM_AMT")%>
                                    
                                                    </strong>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>





                                        </Columns>
                                        <PagerSettings />
                                        <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                            HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                    </asp:GridView>
                                    <asp:Button ID="BtnExportPdf2" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnExportPdf2_Click" />
                                    <asp:Button ID="Btngv1B" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="Btngv1BExcelExport_Click" />
                                </td>

                            </tr>

                            <tr>

                                <td align="center">
                                    <strong>
                                        <asp:Label ID="lbltotal" runat="server" Visible="False"></asp:Label></strong>
                                </td>
                            </tr>


                            <tr>
                                <td align="center">
                                    <%--<h4><span style="color: Red;">*</span>  &nbsp; source from <%=Session["sTigerReserveName"].ToString() %> </h4>--%>
                                </td>
                            </tr>


                        </table>
                    </asp:Panel>
                </asp:Panel>

            </div>
        </div>

    </form>
</body>
</html>
