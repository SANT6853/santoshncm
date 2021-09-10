<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NgoListDetails.aspx.cs" Inherits="auth_Adminpanel_REPORT_CDP_NgoListDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CDP details:NTCA</title>
    <script language="javascript" src="../JS/Script.js" type="text/javascript"></script>

    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     <style>
        .table_new01 {
            padding-top: 10px;
        }

            .table_new01 a {
                color: #f4b301 !important;
            }

        .pagination table tr td {
            border: 1px solid #cccccc;
        }

        .pagination {
            background: transparent !important;
        }

            .pagination > td {
                border: none !important;
            }

        .table {
        }

        .pagination {
            display: contents;
        }

        .table_new01 {
            border-right: none;
            border-bottom: none;
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

        .pagination td {
            border: none !important;
            padding: 3px !important;
        }
    </style>
    <style>
        .table-2 td {
            padding: 10px;
            text-align: left;
            width: 3% !important;
        }

        #gvwork {
            margin-top: -20px;
        }
		hr{margin-top:0px;}
		#btn_print{margin-left:3px;}
		.table-2{border:none;}
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

            #contentbody_btn_print, .page-sidebar, .page-heading {
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



            @page {
                size: portrait;
            }

            .container-fluid {
                margin-top: 0 !important;
            }

            #contentbody_gvwork {
                width: 100%;
            }
        }
    </style>
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>
    <script language="javascript" src="../JS/Script.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
        <div class="col-sm-12">
		
			<div class="row">
                    <div class="col-md-12 mt20">
                        <h3>Work done for village by  <span>NGO :<asp:Label ID="LblNgoName" runat="server"></asp:Label></span></h3>
                       
                        <hr />
                        <div>
						<asp:Button ID="btn_print" runat="server" Text="Print" OnClick="btn_print_Click" CssClass="btn btn-primary btn-add pull-right" />
							<asp:Button ID="BtnBackConsoldateReport" Visible="false" runat="server" Text="Back" CssClass="btn btn-primary btn-add pull-right"
                                        OnClick="BtnBackConsoldateReport_Click" />
                        <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning"
                            OnClick="BtnExcelExport_Click" />
                        <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click" />
                        
                        
                        </div>
                        <br />
                    </div>
                </div>
			
			
			<div class="row">
            <table width="100%" align="center" cellpadding="3" cellspacing="1" class="table-2">
                
                

                <tr>
                    <td colspan="5" align="center">
                        
                        <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
                    </td>
                </tr>
              

                <tr>
                    <td colspan="5">
                        <div class="col-xs-12">
                            <asp:GridView ID="gvwork" runat="server" AutoGenerateColumns="False" ShowFooter="true"
                                CellPadding="4" AllowPaging="True" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass=" table table-bordered table-striped" Width="99%" OnPageIndexChanging="gvwork_PageIndexChanging" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal">
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass=" table table-bordered table-striped" ForeColor="White" BackColor="#005529" Font-Bold="True" />
                                <FooterStyle BackColor="#f5f5dc" />
                                <RowStyle CssClass="drow" Wrap="True" />
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <%#Container.DataItemIndex+1 %>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Tiger Reserve name">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Village name">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "vill_nm")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Work done for village">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "work_done_for_village")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount(Rs)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "amount")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                  
                                </Columns>
                                <PagerSettings />
                                <PagerStyle BackColor="White" CssClass="white-text pagination GridPager" ForeColor="black"
                                    HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#242121" />
                            </asp:GridView>
                        </div>


                    </td>
                </tr>

                <tr>
                    <td class="for-view" width="20%" align="right">
                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>

                    </td>

                    <td width="20%" align="left">
                        <asp:Label ID="lblamttotal" runat="server" CssClass="for-view-lable" Visible="False"></asp:Label>
                    </td>
                    <td width="20%" align="right" class="for-view">
                        <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td width="20%" colspan="2" align="left">
                        <asp:Label ID="lblamtused" runat="server" CssClass="for-view-lable" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr id="line" runat="server" visible="false">
                    <td align="center" colspan="5">
                        <%--<h4> <span style="color:Red;">*</span>  &nbsp; source from <%=Session["sTigerReserveName"].ToString() %> </h4>--%>

                    </td>
                </tr>
            </table>
        </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
