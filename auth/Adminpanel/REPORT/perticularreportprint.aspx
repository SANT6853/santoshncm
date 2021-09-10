<%@ Page Language="C#" AutoEventWireup="true" CodeFile="perticularreportprint.aspx.cs" Inherits="auth_Adminpanel_REPORT_perticularreportprint" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Report</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" media="all" />
    <link href="../CSS/print.css" rel="stylesheet" type="text/css" media="print" />

    <script language="javascript" src="../JS/Script.js" type="text/javascript"></script>
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        .Village-Report {
            border-top: 1px solid #cccccc;
            border-left: 1px solid #cccccc;
        }

            .Village-Report ol, .Village-Report ol li {
                padding: 0px 0px 0px 10px;
                margin: 0px 0px 0px 25px;
            }

            .Village-Report tr td {
                padding: 5px;
                border-bottom: 1px solid #cccccc;
                border-right: 1px solid #cccccc;
            }

        .report3 tr td {
            border-bottom: 0px !important;
        }

        .no_brd {
            border: 0px !important;
        }

        .no_padding {
            padding: 0px !important;
        }

        .alt_row {
            background: #ffffff !important;
        }

        .background {
            background: #ffffff !important;
        }

        .Grid_view tr th {
            background: #005529 !important;
            border: 1px solid #cccccc;
            text-align: center;
            color: #fff;
        }

        .GridPager a, .GridPager span {
            display: block;
            height: 30px;
            width: 30px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            padding: 5px 10px;
        }

        .GridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }

        .GridPager span {
            background-color: #005529;
            color: #fff;
            border: 1px solid #005529;
        }

        .red-text {
            color: red;
        }

        .pagination td {
            border: none !important;
            padding: 1px;
        }

        .pagination {
            display: contents;
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

            #btnprint, #btnback, .pagination {
                display: none;
            }

            table {
            }

            th, td {
            }

            .table-2 {
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
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <form id="form1" runat="server">
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th colspan="3" bgcolor="#005529" align="center" style="color: #fff; padding: 5px; font-size: 120%;">Particular Village Report</th>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
                <asp:Panel ID="panel" runat="server" Visible="true">

                    <table width="100%" border="1" cellspacing="0" style="background: #FCF8ED" cellpadding="0" class=" Village-Report table table-bordered table-striped">
                        <tr class="background">
                            <td width="16%" align="left" valign="top" class="alt_row"><strong>Village Name:</strong></td>
                            <td colspan="2" align="left" valign="top" class="background">
                                <asp:Label ID="lblvillagename" runat="server" Text=""></asp:Label>
                            </td>
                            <td width="16%" align="left" valign="top" class="alt_row"><strong>Village Code:</strong> </td>
                            <td colspan="2" align="left" valign="top">
                                <asp:Label ID="lblvillagecode" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr class="background">
                            <td colspan="3" align="left" valign="top" class="alt_row"><strong>Population</strong></td>
                            <td colspan="3" align="left" valign="top" class="alt_row"><strong>Assets</strong></td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="background">Total:
        <asp:Label ID="lblpopulation" runat="server" Text=""></asp:Label>
                            </td>
                            <td width="16%" align="left" valign="top" class="background">Male:
        <asp:Label ID="lblmail" runat="server" Text=""></asp:Label>
                            </td>
                            <td width="18%" align="left" valign="top" class="background">Female:
        <asp:Label ID="lblfemail" runat="server" Text=""></asp:Label>
                            </td>
                            <td rowspan="3" align="left" valign="top" class="background">Cow &amp; Buffalo: 
        <asp:Label ID="lblcowbuffelo" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td width="16%" rowspan="3" align="left" valign="top" class="background">Sheep &amp; Goat:
        <asp:Label ID="lblsheepgot" runat="server" Text=""></asp:Label>
                            </td>
                            <td width="18%" rowspan="3" align="left" valign="top" class="background">Total Live Stock
      :
        <asp:Label ID="lbltotallivestock" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left" valign="top" class="alt_row"><strong>Caste</strong></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left" valign="top" class="no_padding">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="report3 table table-bordered">
                                    <tr class="background">
                                        <td class="background" width="25%">OBC:
            <asp:Label ID="lblobc" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="background" width="25%">SC: 
            <asp:Label ID="lblsc" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="25%">ST:<asp:Label ID="lblst" runat="server" Text=""></asp:Label></td>
                                        <td class="no_brd " width="25%">Other:<asp:Label ID="lblother" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left" valign="top" class="alt_row"><strong>Land Area</strong></td>
                            <td colspan="3" align="left" valign="top" class="alt_row"><strong>Land Value</strong></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left" valign="top" class="no_padding">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="report3 table table-bordered">
                                    <tr class="alt_row">
                                        <td width="25%" align="center" class="background">Total:  
            <asp:Label ID="lbltotalland" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="25%" align="center" class="background">Agriculture: 
            <asp:Label ID="lblagriculture" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="25%" align="center" class="background">Residential: 
            <asp:Label ID="lblnonagricultureland" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="25%" class="background" align="center">Other: 
            <asp:Label ID="lblotherland" runat="server" Text=""> </asp:Label>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                            <td colspan="3" align="left" valign="top" class="no_padding">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="report3 table table-bordered">
                                    <tr class="alt_row">
                                        <td class="background">Agriculture:<asp:Label ID="lbllandvaluofagriculture" runat="server" Text=""></asp:Label></td>
                                        <td class="background">Residential:
            <asp:Label ID="lblvalueresidentialland" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="background"><strong>Status:</strong>
                                            <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="left" valign="top" class="alt_row">
                                <strong>NGO Names:</strong>

                                <asp:GridView ID="gvforVillages" CssClass="detail_table background table table-bordered" border="0" runat="server" AutoGenerateColumns="False"
                                    Width="100%" ShowFooter="true" BorderStyle="None" EmptyDataText="NA" BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">

                                    <RowStyle CssClass="drow" />
                                    <AlternatingRowStyle CssClass="alt_row" />
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#005529" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="pgr" BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S. No." HeaderStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>

                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="NGO Name" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>

                                                <asp:Label ID="ngoname" runat="server" Text='<%#Eval("name") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount(in Rs.)" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" />

                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" />

                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Work Done For Village" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("work_done_for_village") %>'></asp:Label>
                                            </ItemTemplate>

                                            <HeaderStyle HorizontalAlign="Center" />

                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        </asp:TemplateField>


                                    </Columns>
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                </asp:GridView>
                                <asp:Button ID="BtnNgoExcel" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnNgoExcel_Click"  />
                           <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
                                 </td>
                        </tr>
                    </table>


                    <table style="width: 100%;" border="0" cellpadding="0" cellspacing="0" class="table table-bordered">
                        <tr>
                            <td>

                                <asp:GridView ID="gvforngo" runat="server" AllowPaging="True" ShowFooter="true"
                                    AutoGenerateColumns="False" CssClass="Grid_view table table-bordered"
                                    DataKeyNames="FMLY_ID" HeaderStyle-Wrap="true" bgColor="#005529"
                                    OnPageIndexChanging="gvforngo_PageIndexChanging"
                                    OnRowCommand="gvforngo_RowCommand" OnRowDataBound="gvforngo_RowDataBound" RowStyle-Wrap="true" Width="100%">
                                    <FooterStyle BackColor="#f5f5dc" />
                                    <AlternatingRowStyle CssClass="alt_row" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S. No." ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Family Code" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("FMLY_REG_CD") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Head Name" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblheadname" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Age" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAge" runat="server" Text='<%#Eval("FMLY_MEMB_AGE") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Option Selected" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lbloption" runat="server" Text='<%#Eval("SCHM_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("FMLY_STAT") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top" ItemStyle-Width="22%">
                                            <HeaderTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" class="inner_details table table-bordered" width="100%" style="background-color: #005529;">
                                                    <tr>
                                                        <td style="width: 40%"><strong>Family Members</strong></td>
                                                        <td style="width: 20%"><strong>Age</strong></td>
                                                        <td style="width: 40%"><strong>Relation</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3"><strong>Family Details</strong></td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:GridView ID="grvfamilydeatil" runat="server" AllowPaging="false" AutoGenerateColumns="false" BorderStyle="NotSet" BorderWidth="0" OnRowDataBound="grvfamilydeatil_RowDataBound" ShowHeader="false" Width="100%" CssClass="table table-bordered">
                                                    <Columns>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top" ItemStyle-Width="9%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblage" runat="server" Text='<%#Eval("FMLY_MEMB_AGE")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top" ItemStyle-Width="4%">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsno" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top" ItemStyle-Width="9%">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "RELATION_NAME")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <asp:HiddenField ID="hidenfid" runat="server" Value='<%#Eval("FMLY_ID") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="22%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount Allocated(in Rs.)" ItemStyle-VerticalAlign="top">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblwork" runat="server" Text='<%#Eval("alloted_amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="top" ItemStyle-Width="22%">
                                            <HeaderTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" class="inner_details table table-bordered" width="100%" style="background-color: #005529;">
                                                    <tr>
                                                        <td align="center" colspan="3"><strong>Bank Details</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 33%"><strong>Branch Name</strong></td>
                                                        <td style="width: 33%"><strong>Bank Name</strong></td>
                                                        <td style="width: 34%"><strong>Installment</strong></td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hidenIfid" runat="server" Value='<%#Eval("FMLY_ID") %>' />
                                                <asp:GridView ID="gv1B" runat="server" AutoGenerateColumns="False" CellPadding="1" GridLines="None" Hight="100%" OnRowDataBound="gv1B_RowDataBound" ShowHeader="false" Width="100%" CssClass="table table-bordered">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labe" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BANK_NAME")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "BRANCH_NAME")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hidenIfid1" runat="server" Value='<%#Eval("FMLY_ID") %>' />
                                                                <asp:Repeater ID="Repeterinstallment" runat="server">
                                                                    <ItemTemplate>
                                                                        <%#DataBinder.Eval(Container.DataItem, "INST_ISCM_AMT")%>
                                                                        <br />
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="22%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"
                                        Wrap="True" />
                                    <PagerSettings FirstPageImageUrl="~/AUTH/TIGERRESERVEADMIN/images/First1.jpg"
                                        Mode="Numeric" />

                                    <PagerStyle CssClass="pgr GridPager pagination" />
                                    <RowStyle CssClass="drow" />
                                </asp:GridView>

                                 <asp:Button ID="BtnFamilYmember" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnFamilYmember_Click"  />
                                <asp:Button ID="Button1" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="Button1_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <%-- <h4> <span style="color:Red;">*</span>  &nbsp; source from <%=  Session["sTigerReserveName"].ToString()%> </h4>--%>

                            </td>
                        </tr>
                    </table>

                </asp:Panel>
            </div>
            <br />
            <div>
                <center> 
     
     
     
     <asp:Button ID="btnprint" runat="server"   Text="Print" onclick="btnprint_Click" CssClass="btn btn-primary"/>
             <asp:Button ID="btnback" runat="server"  Text="Back" onclick="btnback_Click" CssClass="btn btn-primary"/></center>
            </div>

        </form>
    </div>
</body>
</html>
