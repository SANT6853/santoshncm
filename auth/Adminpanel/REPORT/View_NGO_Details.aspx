<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_NGO_Details.aspx.cs" Inherits="auth_Adminpanel_REPORT_View_NGO_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <style>
        .btn-mid {
            background: #337ab7 !important;
            padding: 10px;
        }
		#Button2{margin-right:3px;}
		.table_new01{border:none;}
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

            #Button1, #Button2 {
                display: none;
            }

            table {
                border: solid #333333 !important;
                border-width: 1px 0 0 1px !important;
            }

            th, td {
                border: solid #333333 !important;
                border-width: 0 1px 1px 0 !important;
            }

            .table_new01 tr th {
                background-color: #005529 !important;
                color: #fff !important;
                border: none;
            }

            @page {
                size: landscape;
            }

            .container-fluid {
                margin-top: 0 !important;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class=" container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
		<div class="col-sm-12" style="margin-top:20px;">
		
            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="" >

                <tr>

                    <td width="100%" align="">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary button pull-right" Text="Close" OnClientClick="javascript:window.close();" />
                        <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
                         <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnExcelExport_Click"  />
                        <asp:Button ID="Button2" runat="server" Text="Print" CssClass="btn btn-primary button pull-right" OnClick="btn_print_Click" />
                    </td>
                </tr>

                <tr>

                    <td style="color: #743D02; font-size: large;" align="center" width="100%"><strong>NGO Details</strong>
                    </td>


                </tr>
                <tr>
                    <td width="100%" align="center">

                        <asp:Label ID="lblMsg" runat="server" ForeColor="white" CssClass="table  table-striped"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <%-- <td class="black-text" align="right"><span class="red-text-asterix"></span></td>
        <td class="black-text"></td>--%>
                    <td align="center" class="table_new01">


                        <asp:GridView ID="gvforVillages" runat="server" AllowPaging="True" OnPageIndexChanging="gvforVillages_PageIndexChanging" PageSize="15" AutoGenerateColumns="False"
                            CellPadding="1" CellSpacing="1" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-striped" Width="100%" ShowFooter="true">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="white"
                                BackColor="#FDF4C9" CssClass="table table-bordered table-striped" />
                            <footerstyle backcolor="#f5f5dc" />
                             <RowStyle CssClass="drow" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
                            <Columns>
                                <asp:TemplateField HeaderText="S. No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%# Container.DataItemIndex+1 %>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>

                                            <%#DataBinder.Eval(Container.DataItem, "address")%>
                     
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact No">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblwork" runat="server" Text='<%#Eval("mobile_no") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amounts </br>(In Rs.)">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblwork" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblwork" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="work done for village">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblwork" runat="server" Text='<%#Eval("work_done_for_village") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>





                            </Columns>
                            <PagerSettings FirstPageImageUrl="~/adminpanel/images/First1.jpg" Mode="Numeric" />
                            <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        </asp:GridView>

                    </td>
                </tr>



            </table>
        </div>
        </div>
    </form>
</body>
</html>
