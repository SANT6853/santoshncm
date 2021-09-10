<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ConsoldateTigerReserveDetails.aspx.cs" Inherits="auth_Adminpanel_REPORT_ConsoldateTigerReserveDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
     <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="inner-content-right">
    <div class="row">
        <asp:Button ID="BtnBackConsoldateReport"  runat="server" Text="Back" CssClass="btn btn-primary btn-add"
                                        OnClick="BtnBackConsoldateReport_Click" />
        </div>
    <div class="row">
                <asp:GridView ID="GridViewNarenConsoldateReport" runat="server" AutoGenerateColumns="false" CellPadding="0"  
                    CellSpacing="0"  Width="100%"  
                    RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table-bordered table-striped"  >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" />
                    <RowStyle CssClass="drow" />
                    <AlternatingRowStyle CssClass="alt" BackColor="White" />
                    <PagerStyle CssClass="pgr" HorizontalAlign="Right" />
                    <Columns>
                        <asp:TemplateField HeaderText="S No." HeaderStyle-CssClass="Text-Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                                <strong>
                                    <%#Container.DataItemIndex+1 %>
                                    <%--<asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>--%>
                                </strong>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="State Name" HeaderStyle-CssClass="Text-Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                               
                                <b>
                                     <asp:label ID="LblStateName"  runat="server" Text='<%#Eval("StateName") %>' ></asp:label>
                                </b>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tiger Reserve " HeaderStyle-CssClass="Text-Center">
                            <ItemStyle HorizontalAlign="left" />
                            <ItemTemplate>
                               
                                <b>
                                     <asp:label ID="LnkTigerReserve"  runat="server" Text='<%#Eval("TigerReserveName") %>' ></asp:label>
                                </b>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                       
                    </Columns>

                    <PagerSettings Mode="Numeric" />
                    <PagerStyle CssClass="GridPager pagination" Font-Bold="True" ForeColor="black"
                        HorizontalAlign="right" />
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </div>
            <div id="NarenDivMessageError" runat="server" style="color: red; font-weight: bold;" visible="false">
                NO RECORD FOUND
            </div>
            </div>
         </div>
</asp:Content>

