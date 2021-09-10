<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OptionWiseFamilyRptII.aspx.cs" Inherits="auth_Adminpanel_REPORT_OptionWiseFamilyRptII" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NTCA:Scheme Wise Report</title>

    <script type="text/javascript">

        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);


        }
    </script>
    <style>
        .table-2 {
            border: none !important;
        }

        .table_new01 {
            border: 1px solid #cccccc;
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

            #btn_print, #ImageButton1 {
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


    <script language="javascript" src="../JS/Script.js" type="text/javascript"></script>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <span style="float: right;"></span>

            <div id="print_area">
                <div style="text-align: center;">
                    <h3 style="color: #005529;">Option wise Family Details</h3>
                    <hr style="border: groove;" />
                </div>
                <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2" style="margin-top: 10px; padding: 10px;">

                    <tr>
                        <td align="center">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>

                        </td>


                    </tr>
                    <tr style="display: none;">

                        <td style="color: #743D02; font-size: large;" align="center" width="100%"><strong>Option wise Family Details</strong>
                            <span style="float: right; font-size: smaller;">Grand Total : -
                                <asp:Label ID="grandtotalnew" runat="server"></asp:Label></span>
                        </td>


                    </tr>

                    <tr>
                        <%-- <td class="black-text" align="right"><span class="red-text-asterix"></span></td>
        <td class="black-text"></td>--%>
                        <td align="center" class="table_new01">

                            <asp:GridView ID="gvForFamily" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="3" CellSpacing="1"
                                DataKeyNames="FMLY_ID" AllowPaging="True" PageSize="15" OnPageIndexChanging="gvForFamily_PageIndexChanging" OnRowDataBound="gvForFamily_RowDataBound" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered" ShowFooter="true">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered" ForeColor="white" BackColor="#FDF4C9" />
                                <RowStyle CssClass="drow" />
                                <AlternatingRowStyle CssClass="alt" />
                                <PagerStyle CssClass="pgr" />
                                <FooterStyle BackColor="#f5f5dc" />
                                <Columns>


                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Family Code" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                              
                                                <%#DataBinder.Eval(Container.DataItem, "FMLY_REG_CD")%>
                        
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Head Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "a")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Option Selected ">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("SCHM_ID") %>'></asp:Label>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Relocation Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "relocation")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allotted Amount(Rs)" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "allotedamount")%>
                                            </strong>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <%-- <asp:Label ID="lbltotalalloted" runat="server"></asp:Label>--%>
                                        </FooterTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Installment Amount(Rs)" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "installment")%>
                                            </strong>
                                        </ItemTemplate>
                                        <FooterTemplate>

                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Family Member">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <a id="fmldetails" href='<%# string.Format("ViewFamilyData.aspx?F_ID={0}&s_ID=1&villid={1}&Resv={2}", Eval("fmly_id").ToString(), Request.QueryString["V_ID"].ToString(),Request.QueryString["Reservename"].ToString()) %>'><%#DataBinder.Eval(Container.DataItem, "FMLY_NO_MEMB")%></a>
                                              
              
                                            </strong>
                                        </ItemTemplate>

                                    </asp:TemplateField>




                                </Columns>

                                <PagerSettings />
                                <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                    HorizontalAlign="Center" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" Font-Bold="true" />
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                            </asp:GridView>


                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <%--  <h4> <span style="color:Red;">*</span>  &nbsp; source from <%=Session["sTigerReserveName"].ToString() %> </h4>--%>

                        </td>
                    </tr>
                    <tr>

                        <td align="center">
                            <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf"  CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
                            <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning"
                                OnClick="BtnExcelExport_Click" />
                            <asp:Button ID="btn_print" runat="server" Text="Print" Width="70px" OnClick="btn_print_Click1" CssClass="btn btn-primary" />&nbsp;
                        <asp:Button ID="ImageButton1" runat="server" Text="Back" OnClick="ImageButton1_Click" CssClass="btn btn-primary" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
