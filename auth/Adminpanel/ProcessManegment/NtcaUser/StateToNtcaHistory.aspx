<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="StateToNtcaHistory.aspx.cs" Inherits="auth_Adminpanel_ProcessManegment_ReserveUser_StateToNtcaHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
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
    </style>
    <script type="text/javascript" language="javascript">
        function ConfirmOnDelete(item) {
            if (confirm("Are you sure to delete: " + item + "?") == true)
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <div class="ibox-title">
                        <h5>View Process Management.
                        </h5>
                    </div>
                    <hr>
                    <div class="form-horizontal">

                        <div class="ibox-content collapse in">
                            <div class="widgets-container">
                               <asp:Button ID="BtnBack" runat="server" Text="Back" CausesValidation="false" CssClass="btn btn-primary btn-add" OnClick="BtnBack_Click"  />
                                <div>
                                       
                            
                          
                            <div>
                                Status:
                                <asp:DropDownList ID="DDlStatus" runat="server" CssClass="form-control" Width="250px">
                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Pending" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Verified" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Approved" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="Rejected" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div><br />
                                <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="BtnSearch_Click" />
                            </div>


                        </div>
                                    <asp:Label ID="LblMsg" runat="server" ForeColor="Red" Font-Size="Larger" Font-Bold="true"></asp:Label>

                                    <asp:GridView ID="GrdDfoReserve" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" ForeColor="Black" OnPageIndexChanging="GrdDfoReserve_PageIndexChanging" OnRowCommand="GrdDfoReserve_RowCommand" OnRowDeleting="GrdDfoReserve_RowDeleting" OnRowDataBound="GrdDfoReserve_RowDataBound">
                                        <EmptyDataTemplate>
                                            <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                                        </EmptyDataTemplate>
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                     <%-- testing purpose id:<%# DataBinder.Eval(Container.DataItem, "TblFromReserveToStateAutoID") %>--%><br />
                                                    <asp:Label ID="lblsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TokenID">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblTokenID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TokenId_FirstTimeInsertNoChange")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "StatusIDDefault1")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Village Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="VillageName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VILL_NM")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Request Amount in(Rs)">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblRequestAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FromAmount_FirstTimeInsertNoChange")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Accepted Amount in(Rs)">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAcceptedAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AcceptedAmount")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Descriptions">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDescriptions" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FromDescription_FirstTimeInsertNoChange")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Applied Date(dd/mm/yyyy)">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblAppliedDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FromInsertDate_FirstTimeInsertNoChange1")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <%-- <asp:TemplateField HeaderText="Reporting Manager">
                                                <ItemTemplate>

                                                    <asp:Label ID="LblReportingManager" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ToPersonUserName")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                             <asp:TemplateField HeaderText="Action By">
                                                <ItemTemplate>

                                                    <asp:Label ID="lblActionBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Commented">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCommented" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CommentedRemarks")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reply Date (dd/mm/yyyy)">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCommentDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CommentedDate1")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            

                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" CssClass="GridPager" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#F7F7DE" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
   
</asp:Content>

