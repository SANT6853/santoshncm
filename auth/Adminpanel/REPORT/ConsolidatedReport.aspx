<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ConsolidatedReport.aspx.cs" Inherits="auth_Adminpanel_REPORT_ConsolidatedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .Text-Center {
            text-align: left;
            width: 20px;
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
            padding: 1px;
        }

        #contentbody_gvforVillages tr th:nth-child(1) {
            width: 1%;
        }
    </style>


    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "minus.png";
            } else {
                div.style.display = "none";
                img.src = "plus.png";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="inner-content-right">
            <div class="row">
                <div class="col-md-10 mt20">
                    <label class="col-sm-4 control-label">
                        State Name<span style="color: red;">*</span>:
                    </label>
                    <div class="form-group col-md-5">

                        <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10 mt20">
                    <label class="col-sm-4 control-label">
                        Choose Tiger Reserve name<span class="red-text">*</span>
                    </label>
                    <div class="form-group col-md-5">
                        <asp:CheckBoxList ID="ChkTigerReserveName" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                        </asp:CheckBoxList>
                        <asp:Label ID="ErrorChkTigerReserveName" runat="server" ForeColor="Red"></asp:Label>

                    </div>
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="Naren_GridViewParentStateName" runat="server" AutoGenerateColumns="false" CellPadding="0" DataKeyNames="id"
                    CellSpacing="0" AllowPaging="True" PageSize="15" Width="100%" OnRowDataBound="Naren_GridViewParentStateName_RowDataBound"
                    RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table-bordered table-striped" OnPageIndexChanging="Naren_GridViewParentStateName_PageIndexChanging">

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
                                <a href="JavaScript:divexpandcollapse('div<%# Eval("id") %>');">
                                    <img id="imgdiv<%# Eval("id") %>" border="0" src="plus.png" />
                                </a>
                              

                                <div id="div<%# Eval("id") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                    <table>
                                        <thead>
                                            <tr>
                                                <th></th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                    <%--tiger reserve details--%>
                                                    <asp:GridView ID="gvTigerReserveName" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S No." HeaderStyle-CssClass="Text-Center">
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <ItemTemplate>
                                                                    <strong>
                                                                        <%#Container.DataItemIndex+1 %>
                                                       
                                                                    </strong>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tiger Reserve name" HeaderStyle-CssClass="Text-Center">
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <ItemTemplate>
                                                                    <strong>

                                                                        <asp:Label ID="LblTigerReserveName" runat="server" Text='<%#Eval("TigerReserveName") %>'></asp:Label>
                                                                    </strong>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                                <td valign="top">
                                                     <%--Village details--%>
                                                    <asp:GridView ID="GvVillageList" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S No." HeaderStyle-CssClass="Text-Center">
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <ItemTemplate>
                                                                    <strong>
                                                                        <%#Container.DataItemIndex+1 %>
                                                       
                                                                    </strong>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Village name" HeaderStyle-CssClass="Text-Center">
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <ItemTemplate>
                                                                    <strong>

                                                                        <asp:Label ID="LblVillageName" runat="server" Text='<%#Eval("VILL_NM") %>'></asp:Label>
                                                                    </strong>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </div>
                              

                                <%--Parent below record--%>
                                <b>
                                    <asp:Label ID="LblStateName" runat="server" Text='<%#Eval("StateName") %>'></asp:Label>
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

