<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="exporttopdf.aspx.cs" Inherits="auth_Adminpanel_REPORT_exporttopdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">

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

                                <asp:TemplateField>
                                    <HeaderTemplate>Image</HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="<%= ResolveUrl("~/WriteReadData/UserFiles/") %><%#Eval("file_name") %>" rel="lightbox[slide]" target="_blank" class="vlightbox" caption="Title : -<%# Eval("title") %>  Description: -<%# Eval("description") %>">

                                            <img src="http://localhost:2429/WriteReadData/UserFiles/<%#Eval("file_name") %>" alt="<%# Eval("file_name") %>" width="100" height="100" hspace="5" vspace="5" border="0" class="vlightbox" />
                                        </a>
                                        <%--<img src="http://localhost:2429/WriteReadData/UserFiles/<%#Eval("file_name") %>" alt="<%# Eval("file_name") %>" width="100" height="100" hspace="5" vspace="5" border="0" class="vlightbox" /></a>
                                        --%>
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

            </table>
            <asp:Button ID="btnexp" runat="server" Text="export" OnClick="btnPDF_Click" />
        </div>
    </div>

    <%-- <asp:GridView ID="bindphotos" AutoGenerateColumns="false" CellPadding="5" runat="server" CssClass="mGrid table table-bordered table-striped"  Width="100%">
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
            <asp:TemplateField>
                <HeaderTemplate>Image</HeaderTemplate>
                <ItemTemplate>
                    <img height="50px" width="50px" src="http://localhost:2429/images/gallery/2-375.jpg" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
          <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>--%>
</asp:Content>

