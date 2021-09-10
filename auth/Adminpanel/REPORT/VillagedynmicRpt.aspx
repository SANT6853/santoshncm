﻿<%@ Page Title="NTCA:Villages wise Dynamic Report" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="VillagedynmicRpt.aspx.cs" Inherits="auth_Adminpanel_REPORT_VillagedynmicRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .table-2 td {
            /*width: 25% !important;*/
        }

        #btn_print {
            padding-left: 10px;
        }

        .container-fluid {
            margin-bottom: 50px !important;
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

        .prntbck {
            margin-right: 20px;
        }

            .prntbck input {
                margin-left: 3px;
            }

        div::-webkit-scrollbar {
            width: 8px;
            height: 8px;
        }


        div::-webkit-scrollbar-track {
            background: #fafafa;
            border-radius: 10px;
        }


        div::-webkit-scrollbar-thumb {
            background: #888;
            border-radius: 10px;
        }


            div::-webkit-scrollbar-thumb:hover {
                background: #555;
            }

        .errmsg {
            margin-left: 25px;
            margin-bottom: 20px;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            $("#contentbody_gv_villageSearch").tablesorter();
        });
    </script>

    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>
    <script language="javascript" type="text/javascript">
        function IMG1_onclick() {

        }


        /****************************************************
            
        ****************************************************/
        var win = null;
        function NewWindow(mypage, myname, w, h, scroll, pos) {
            if (pos == "random") { LeftPosition = (screen.availWidth) ? Math.floor(Math.random() * (screen.availWidth - w)) : 50; TopPosition = (screen.availHeight) ? Math.floor(Math.random() * ((screen.availHeight - h) - 75)) : 50; }
            if (pos == "center") { LeftPosition = (screen.availWidth) ? (screen.availWidth - w) / 2 : 50; TopPosition = (screen.availHeight) ? (screen.availHeight - h) / 2 : 50; }
            if (pos == "default") { LeftPosition = 50; TopPosition = 50 }
            else if ((pos != "center" && pos != "random" && pos != "default") || pos == null) { LeftPosition = 0; TopPosition = 20 }
            settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=yes';
            win = window.open(mypage, myname, settings);
            if (win.focus) { win.focus(); }
        }
        function IMG1_onclick() {

        }
    </script>

    <script type="text/javascript">
<!--
    function MM_openBrWindow(theURL, winName, features) { //v2.0

        window.open(theURL, winName, features);
    }
    //-->
    </script>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 50px; padding: 10px; background: #fff;">
        <div class="inner-content-right">

            <div class="widgets-container" style="padding-bottom: 0;">
                <div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Villages wise Dynamic Report</h3>
                    </div>
                </div>

            </div>
            <div class="prntbck">
                <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-primary btn-add pull-right" OnClick="btnback_OnClick" />
                <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning"
                    OnClick="BtnExcelExport_Click" />
                <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click" />
                <asp:Button ID="btn_print" runat="server" Text="Print selected checked" CssClass="btn btn-primary btn-add pull-right" Visible="false" OnClick="btn_print_Click1" />
                <asp:Button ID="BtnPrintAll" runat="server" Text="Print all" CssClass="btn btn-primary btn-add pull-right" Visible="false" OnClick="BtnPrintAll_Click" />
            </div>
            <div class="row">
                <div class="errmsg">&nbsp;</div>


                <div class="col-sm-8">
                    <%if (Session["UserType"].ToString().Equals("1"))
                      {%>
                    <div class="col-sm-12">
                        <label for="" class="col-sm-5">State Name:</label>
                        <div class="col-sm-4 input-group">
                            <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <%} %>
                    <%if (Session["UserType"].ToString().Equals("1") || Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("3"))
                      {%>

                    <div class="col-sm-12">
                        <label for="" class="col-sm-5">Tiger reserve name:</label>
                        <div class="col-sm-4 input-group">
                            <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <%} %>

                    <div class="col-sm-12">
                        <label for="" class="col-sm-5">Village Name:</label>
                        <div class="col-sm-4 input-group">
                            <asp:TextBox ID="TxtVillageName" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                            <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" >
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-sm-12" style="display:none;">
                        <label for="" class="col-sm-5">Village Code:</label>
                        <div class="col-sm-4 input-group">
                            <asp:TextBox ID="TxtVillageCode" CssClass="form-control" runat="server" Visible="False"></asp:TextBox>
                            <asp:DropDownList ID="ddlselectcode" runat="server" CssClass="textfield-drop form-control" >
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-sm-12">
                        <label for="" class="col-sm-5">Status:</label>
                        <div class="col-sm-4 input-group">
                            <asp:DropDownList ID="DDlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Relocated" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Non-Relocated" Value="2"></asp:ListItem>
                                <asp:ListItem Text="In Progress" Value="3"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-sm-12">
                        <label for="" class="col-sm-5"></label>
                        <div class="col-sm-4 input-group">
                            <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="BtnSearch_Click" />
                       <br />
                            <asp:Label ID="lblnodatafound" runat="server" Font-Size="Large" CssClass="red-text"></asp:Label>
                             </div>


                    </div>
                </div>

                <div class="col-md-12">
                    <div class="col-md-12" style="overflow-x: auto;">
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2 ">
                            <tr>
                                <td width="90%" align="left">

                                    <asp:GridView ID="gv_villageSearch1" runat="server" AutoGenerateColumns="False" CellPadding="4" AllowPaging="True" Width="100%" OnPageIndexChanging="gv_villageSearch_PageIndexChanging"
                                        RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" ShowFooter="true" OnRowDataBound="gv_villageSearch1_RowDataBound">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="top" Wrap="True" ForeColor="White"
                                            BackColor="#005529" CssClass="mGrid table table-bordered table-striped" Font-Bold="True" />
                                        <AlternatingRowStyle CssClass="alt_row" BackColor="White" />

                                        <EmptyDataTemplate>
                                            <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                                        </EmptyDataTemplate>
                                        <Columns>

                                            <asp:TemplateField HeaderText="S No.">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <asp:Label ID="lblsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    <%-- <%#DataBinder.Eval(Container.DataItem, "S_NO")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "StateName")%>                                         
                                                    </strong>

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
                                            <asp:TemplateField HeaderText="Village Name">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>


                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Village Code" Visible="false">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Population">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Land Area">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Total Agriculture Land Area">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Total Non Agriculture Land Area">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Other Land Area(Ha)">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Value of Agriculture land">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Value of Residential Land">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>




                                            <asp:TemplateField HeaderText="Total Cow">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "NoCows")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Buffalo">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "NoBuffalo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total Sheep">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "NoSheep")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Total Goat">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "NoGoat")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Other animal">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="True" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Total Relocated Families">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="True" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Non-Relocated Families">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "vill_status")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NGO">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "NGO")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="GoogleMap">

                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <strong>
                                                        <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="Edit"
                                                            Visible="true" ImageUrl="~/auth/Adminpanel/REPORT/Gmap.ico" Width="40px" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                                    </strong>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Tiger Reserve name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                        </Columns>
                                        <PagerStyle BackColor="#F7F7DE" CssClass="white-text" ForeColor="Black"
                                            HorizontalAlign="Right" />
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="drow" BackColor="#F7F7DE" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                                    </asp:GridView>

                                </td>

                            </tr>



                            <tr>

                                <%-- this grid used fore view data and select column fore print--%>
                                <td colspan="2" width="100%">
                                    <asp:GridView ID="gv_villageSearch" runat="server" AutoGenerateColumns="False" CellPadding="4" AllowPaging="True" Width="100%" OnPageIndexChanging="gv_villageSearch_PageIndexChanging"
                                        RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped table-responsive" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" OnRowCommand="gv_villageSearch_RowCommand" ShowFooter="true" OnRowDataBound="gv_villageSearch_RowDataBound" OnRowDeleting="gv_villageSearch_RowDeleting" OnRowEditing="gv_villageSearch_RowEditing">

                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="top" Wrap="True" ForeColor="White"
                                            BackColor="#005529" CssClass="mGrid table table-bordered table-striped table-responsive" Font-Bold="True" />
                                        <AlternatingRowStyle CssClass="alt_row" />

                                        <EmptyDataTemplate>
                                            <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                                        </EmptyDataTemplate>

                                        <Columns>

                                            <asp:TemplateField HeaderText="S No">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>

                                                            <td align="center" valign="top">
                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>S No
                                               
                                                            </td>
                                                        </tr>
                                                    </table>


                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>


                                                    <asp:Label ID="lblsno" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                    <%--<%#DataBinder.Eval(Container.DataItem, "S_NO")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="State Name">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckStateName" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>State Name
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "StateName")%>                                         
                                                    </strong>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tiger Reserve name">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckTigerReservename" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Tiger Reserve name
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Village Name">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox2" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>

                                                                <asp:LinkButton ID="LnkVName" Font-Underline="True" runat="server" Text="Village Name" ForeColor="White" CommandName="Sort" CommandArgument="VILL_NM">

                                                                </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>



                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>


                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Village Code" Visible="false">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox3" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="LnkVillCode" runat="server" Font-Underline="True" Text="Village Code" ForeColor="White" CommandName="Sort" CommandArgument="VILL_CD" />
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Population">
                                                <HeaderTemplate>

                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox4" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="LnkPopulation" runat="server" Font-Underline="True" Text="Population" ForeColor="White" CommandName="Sort" CommandArgument="VILL_POPU" />
                                                            </td>
                                                        </tr>
                                                    </table>


                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Land Area">
                                                <HeaderTemplate>

                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox5" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Land Area(Ha)
                                                            </td>
                                                        </tr>
                                                    </table>




                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Total Agriculture Land Area">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox6" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Agriculture Land Area(Ha)
                                                            </td>
                                                        </tr>
                                                    </table>


                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Total Non Agriculture Land Area">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox7" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Non Agriculture Land Area(Ha)
                                                            </td>
                                                        </tr>
                                                    </table>



                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Other Land Area">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox8" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Other Land Area(Ha)
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--add new column  --%>
                                            <asp:TemplateField HeaderText="Value of Agriculture land">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox9" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Value of Agriculture land
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Value of Residential Land">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox10" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Value of Residential Land
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--18june--%>

                                            <asp:TemplateField HeaderText="Total Cow">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="ChkCow" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Cow
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "NoCows")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Buffalo">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="ChkBuffalo" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Buffalo
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "NoBuffalo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Total Sheep">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="ChkSheep" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Sheep
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "NoSheep")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Goat">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="ChkGoat" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Goat
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "NoGoat")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--18june--%>




                                            <asp:TemplateField HeaderText="Other Animal">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox13" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Other Animal
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>



                                            <%--add new column  --%>


                                            <asp:TemplateField HeaderText="Total Relocated Families">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox14" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Relocated Families
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%>
                                                </ItemTemplate>
                                                <HeaderStyle Wrap="True" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Non-Relocated Families">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox15" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Total Non-Relocated Families
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox16" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Status
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label ID="LblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "vill_status")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="NGO">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBox17" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>NGO
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "ngo")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Tiger Reserve name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="GoogleMap">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="CheckGoogleMap" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>GoogleMap
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <strong>
                                                        <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="Edit"
                                                            Visible="true" ImageUrl="~/auth/Adminpanel/REPORT/Gmap.ico" Width="40px" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                                    </strong>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="White" CssClass="GridPager pagination" ForeColor="Black"
                                            HorizontalAlign="Right" />
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="drow" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                    </asp:GridView>
                                </td>
                            </tr>



                            <tr>

                                <td align="center" colspan="4">
                                    <%if (Session["UserType"].ToString().Equals("4"))
                                      {%>
                                    <p style="font-size: 10pt">
                                        <b><span style="color: Red;">Note</span> :-</b> Field which are selected through check box will be printed.<br />
                                        <%--<span style="color: Red;">*</span>  &nbsp; <b style="font: 10;">source from <%=Session["sTigerReserveName"].ToString() %> </b>--%>
                                    </p>
                                    <br />

                                    <%} %>



                        
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div style="display: none;">
            </div>
        </div>
</asp:Content>

