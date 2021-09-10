<%@ Page Title="NTCA:Village Relocation Progress Report" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ReportConsold.aspx.cs" Inherits="auth_Adminpanel_Villagerelocationprogress_ReportConsold" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .table-2 td {
            text-align: left;
            padding-bottom: 4px;
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

            strong {
                font-weight: 400 !important;
            }

            #contentbody_btnprint, .page-sidebar, .page-heading, #contentbody_btnexporet {
                display: none;
            }

            table {
            }

            th, td {
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
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content">
            <table width="100%" class="table-2">
                <tr>
                    <td colspan="3" style="border-bottom: 3px solid #005529;">
                        <h3 style="color: #005529;">Village Relocation Progress Report</h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="padding-top: 10px;"><span></span></td>
                </tr>
                <%if (Session["UserType"].ToString().Equals("1"))
                  {%>
                <tr style="display:none;">
                    <td style="width: 265px;">
                        <b>Tiger Reserve:</b><asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="form-control" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td width="7%">&nbsp;
                    </td>
                    <td width="15%">&nbsp;</td>

                </tr>
                <%} %>

                <tr style="display:none;">
                    <td>
                        <asp:Label ID="Label1" Font-Bold="true" runat="server" Text="Select Date:"></asp:Label>
                        <p>
                            <asp:TextBox ID="txtdate"
                                runat="server" OnTextChanged="txtdate_TextChanged" CssClass="form-control" Width="250px"></asp:TextBox>
                            <asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image3" runat="server" />
                        </p>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDate"
                            Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                            ValidationGroup="ADD" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtdate"
                            PopupButtonID="Image3" runat="server">
                        </cc1:CalendarExtender>
                    </td>
                    <td width="7%">&nbsp;</td>
                    <td width="15%"></td>

                </tr>


                <tr>
                    <td style="width: 265px;">
                        <asp:Button ID="BtnBackConsoldateReport" Visible="false" runat="server" Text="Back" CssClass="btn btn-primary btn-add"
                                        OnClick="BtnBackConsoldateReport_Click" />
                        <asp:Button ID="btnsubmit" Visible="false" runat="server" CssClass="btn btn-primary btn-add" OnClick="btnsubmit_Click" Text="Search" />
                    </td>
                    <td width="7%">&nbsp;</td>
                    <td width="15%">&nbsp;</td>

                </tr>


                <tr>
                    <td colspan="3">
                        <br />
                        <div>
                            <h2><u><asp:Label ID="LblMsgStateName" runat="server"></asp:Label></u> </h2>
                        </div>
                        <asp:Panel ID="panelprint" runat="server">
                            <asp:GridView ID="gvforVillages" runat="server" AllowPaging="True"
                                DataKeyNames="id" OnPageIndexChanging="gvforVillages_PageIndexChanging" AutoGenerateColumns="False"
                                CellPadding="4" RowStyle-Wrap="true" ShowFooter="true"
                                HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" Width="100%"
                                EmptyDataText="No Report Found" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                 <FooterStyle BackColor="#f5f5dc" />
                                <RowStyle CssClass="drow" />
                                <AlternatingRowStyle CssClass="alt" BackColor="White" />
                                <PagerStyle CssClass="pgr" HorizontalAlign="Right" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S. No.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Report As on Date">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("Date") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name Of State">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>


                                            <%#DataBinder.Eval(Container.DataItem, "ST_NAME")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name Of Tiger Reserve">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <asp:Label ID="lblwork" runat="server" Text='<%#Eval("ReserveId") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of the villages in the notified Core (CTH)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("Village") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of the families in the notified Core (CTH)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("family") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("relocatedvill") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>


                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("relocatefam") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No. of villages remaining inside the core (CTH)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("remainvill") %>'></asp:Label>


                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="No.of families remaining inside the core (CTH)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("remainfam") %>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="10 Lakh per Family">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>


                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("moneyperfam") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Land Package">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>


                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("landpackge") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="1 Lakh per Family & Land">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>


                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("landandmoney") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Villages Relocated with any other Package">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>


                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("villrelocotherpack") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("remarks") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>






                                </Columns>
                                <PagerSettings FirstPageImageUrl="~/AUTH/adminpanel/images/First1.jpg" Mode="Numeric" />
                                <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                    HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="">
                        <%--<h4> <span style="color:Red;">*</span>  &nbsp; source from <%=Session["sTigerReserveName"].ToString() %> </h4>--%>

                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary btn-add" Text="Print"
                            OnClick="btnprint_Click" />
                        <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
                        <asp:Button ID="btnexporet" CssClass="btn btn-primary btn-add" OnClick="btnexporet_Click" runat="server" Text="Export to Excel" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

