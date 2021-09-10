<%@ Page Title="NTCA:View Tiger Reserve" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewTigerReserver.aspx.cs" Inherits="auth_Adminpanel_TigerReserve_ViewTigerReserver" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
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

        .control-label {
            text-align: left !important;
            margin-left: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="row">
                <div class="col-lg-12 ">
                    <div class="widgets-container">
                        <div class="box box-primary1" style="margin-bottom: 25px;">
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">View Tiger Reserve </h3>
                            </div>

                        </div>


                        <div class="form-horizontal">

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Select State</label>
                                <div class="col-sm-3">
                                    <asp:DropDownList ID="ddlstate" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" InitialValue="0" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlstate" ValidationGroup="val"
                                        ErrorMessage="Select State" />
                                </div>
                            </div>



                            <div class="ibox-content collapse in">
                                <div class="widgets-container">
                                    <div>


                                        <asp:GridView ID="grdtiger" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdtiger_PageIndexChanging" OnRowDeleting="grdtiger_RowDeleting" OnRowCommand="grdtiger_RowCommand" OnRowDataBound="grdtiger_RowDataBound">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField ItemStyle-CssClass="Text-Center" HeaderText="S.No.">
                                                    <ItemTemplate>
                                                        <%#Container .DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TigerReserveName" HeaderText="Tiger Reserve Name" />
                                                <asp:BoundField DataField="NoofVillages" HeaderText="No of Villages" />


                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <a href='<%# ResolveUrl("~/auth/Adminpanel/TigerReserve/AddTigerReserve.aspx?Moduleid=3&tid="+Eval("TigerReserveid")) %>'>
                                                            <asp:Image ID="imgedit" runat="server" ImageUrl="../images/edit.gif" ToolTip="Edit" /></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LnkActiveDeaActive" runat="server" Text='<%#Eval("ActiveStatus") %>' CommandName="AD" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TigerReserveid") %>'></asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="" ForeColor="Black" CssClass="GridPager pagination" HorizontalAlign="Right" />
                                            <RowStyle BackColor="" />
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
        </div>

        <%--<script src="../assets/js/vendor/bootstrap.min.js"></script>
    <!--  morris Charts  -->
    <!-- js for print and download -->
    <script type="text/javascript" src="../assets/js/vendor/vfs_fonts.js"></script>
    <script src="../assets/js/vendor/chartJs/Chart.bundle.js"></script>
    <script src="../assets/js/dashboard1.js"></script>
    <!-- slimscroll js -->
    <script type="text/javascript" src="../assets/js/vendor/jquery.slimscroll.js"></script>
    <!-- main js -->
    <script src="../assets/js/main.js"></script>--%>
</asp:Content>

