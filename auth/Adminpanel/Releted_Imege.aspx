<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Releted_Imege.aspx.cs" Inherits="auth_Adminpanel_Releted_Imege" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .vlightbox{
            color:blue;
             text-decoration-line:underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="inner-content-right">
            <table width="100%" align="center" cellpadding="3" cellspacing="1" class="table-2">
                <tr>
                    <td>
                        <center><asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></center>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="bindphotos" CssClass="mGrid table table-bordered table-striped" CellPadding="4" Width="100%"
                            RowStyle-Wrap="true" HeaderStyle-Wrap="true" runat="server"
                            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal">
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <RowStyle CssClass="drow" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.NO">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="Village Name">
                                    <ItemTemplate>
                                       <%#Eval("VILL_NM") %> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                       <%#Eval("description") %> 
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="View Image" >
                                    <ItemTemplate>
                                        <strong>
                                          <%-- Image Title: <asp:Label ID="lbltitle" runat="server" Text='<%# Eval("title") %>'></asp:Label></strong><br />--%>
                                        <a href="<%= ResolveUrl("~/WriteReadData/UserFiles/") %><%#Eval("file_name") %>" rel="lightbox[slide]" target="_blank" class="vlightbox" caption="Title : -<%# Eval("title") %>  Description: -<%# Eval("description") %>">
                                            <%--<img src="<%= ResolveUrl("~/WriteReadData/UserFiles/") %><%#Eval("file_name") %>" alt="<%# Eval("file_name") %>" width="100" height="100" hspace="5" vspace="5" border="0" class="vlightbox" />--%>
                                             <%--<img src="http://localhost:2429/WriteReadData/UserFiles/<%#Eval("file_name") %>" alt="<%# Eval("file_name") %>" width="100" height="100" hspace="5" vspace="5" border="0" class="vlightbox" />--%>
                                         <img src="http://45.115.99.199/ntca_mis/WriteReadData/UserFiles/<%#Eval("file_name") %>" alt="<%# Eval("file_name") %>" width="100" height="100" hspace="5" vspace="5" border="0" class="vlightbox" />
                                        </a>
                                       
                                        </center>
                                    </ItemTemplate>

                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="View File" >
                                    <ItemTemplate>
                                        <strong>
                                           File Title: <asp:Label ID="lbltitle" runat="server" Text='<%# Eval("title") %>'></asp:Label><br />
                                        </strong>
                                        <a href="<%= ResolveUrl("~/WriteReadData/UserFiles/") %><%#Eval("file_name") %>" rel="lightbox[slide]" target="_blank" class="vlightbox" caption="Title : -<%# Eval("title") %>  Description: -<%# Eval("description") %>">
                                            <%#Eval("file_name") %> </a>
                                        </center>
                                    </ItemTemplate>

                                    
                                </asp:TemplateField>

                                 

                            </Columns>


                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />


                        </asp:GridView>



                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="BtnPDFexport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPDFexport_Click"  />
                        <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnExcelExport_Click"  />
                        <asp:Button ID="btnback" runat="server" CssClass="btn btn-primary btn-add" Text="Back"
                            OnClick="btnback_Click" />
                        <%--<asp:Button ID="btnExport" runat="server" Text="Export To PDF" OnClick = "ExportToPDF" />--%>
                        <br />
                        <br />
                        <br />
                        <br />


                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

