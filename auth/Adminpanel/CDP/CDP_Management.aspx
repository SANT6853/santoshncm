<%@ Page Title="NTCA:View cdp" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="CDP_Management.aspx.cs" Inherits="auth_Adminpanel_CDP_CDP_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .table-2 td {
            padding: 10px;
            text-align: left;
        }

        .container-fluid {
            margin-bottom: 50px !important;
        }

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
         .control-label {
            text-align: left !important;
        }
         .form-group {
    margin-bottom: 0px !important;
}
    </style>

    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <%-- ***************nw****** --%>
        <div class="wrapper-content" style="padding-top: 0px; padding-bottom: 0;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="widgets-container">
                        <div class="box box-primary1" style="margin-bottom: 25px;">
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Community Development Management
                                    <asp:Label ID="lblvillagename" Visible="false" runat="server" Text=""></asp:Label>
                                </h3>
                            </div>
                        </div>
                        <div class="form-horizontal">
                            <%-- <div class="">
                                <div class="pull-right">
                                    <asp:Button ID="btnassociatevillage" Visible="false" CssClass="btn btn-primary btn-add" runat="server"
                                        Text="Associate NGO" OnClick="btnassociatevillage_Click" />
                                    <asp:Button ID="Button1" Visible="false" runat="server" Text="Display Legal Form" CssClass="btn btn-primary btn-add" OnClick="Button1_Click" />
                                    &nbsp;<asp:Button ID="ImgbtnAddNew" runat="server" Text="Add New Village" OnClick="ImgbtnAddNew_Click1" CssClass="btn btn-primary btn-add" />
                                    <asp:Button ID="lnkrelatedlinks" runat="server" Text="Related images" CssClass="btn btn-primary btn-add"
                                        OnClick="lnkrelatedlinks_Click" />
                                </div>
                            </div>--%>
                            <%if (Session["UserType"].ToString().Equals("1"))
                              {%>
                            <div class="col-md-8"  runat="server" id="ddlState">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label"><span class="black-text" align="center">State name<asp:Label ID="StartStateName" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>:</span></label>
                                    <div class="col-sm-9">
                                        <asp:DropDownList ID="DdlStateName" runat="server" Width="250px" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <%} %>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label" id="td" runat="server"  style="font-size: 15px; vertical-align: middle;">
                                        <span class="black-text" align="center">Select Tiger Reserve<asp:Label ID="StarTreserve" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>:</span>
                                    </label>
                                    <div class="col-sm-9">

                                        <div id="td1" runat="server">
                                            <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="textfield-drop form-control" Width="250px" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </div>
                                        <div width="60%" id="td007" runat="server" ></div>
                                        <div id="td008" runat="server" ></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                 <div class="form-group">
                                     <label class="col-sm-3 control-label" style="display: none;">Village Code<asp:Label ID="StartVcode" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>:
                                            </label>
                                    <div class="col-sm-9" style="display: none;"">
                                        <asp:DropDownList ID="ddlselectcode" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectcode_SelectedIndexChanged">
                                                </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Village Name<asp:Label ID="StarVname" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>:</label>
                                    <div class="col-sm-9">
                                        <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" Width="250px" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label"></label>
                                    <div class="col-sm-9">
                                        <asp:Button ID="ImageButton1" runat="server" Text="Search" CssClass="btn btn-primary btn-add"
                                            OnClick="ImageButton1_Click" />
                                        <br />
                                        <asp:Label ID="lblMsg" runat="server" CssClass="red-text"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%if (Session["UserType"].ToString().Equals("40000"))
          {%>
        <div>
            <asp:Button ID="imgbtnviewall" runat="server" Text="View All" OnClick="imgbtnviewall_Click" CssClass="btn-mid" />
            <asp:Button ID="btnviewcurrent" runat="server" Text="View Current" CssClass="btn-mid" OnClick="btnviewcurrent_Click" />
        </div>
        <%} %>
        <%-- *******************end nw --%>
        <div>
            <asp:GridView ID="gvforVillages" runat="server" AllowPaging="True" DataKeyNames="VILL_ID" OnPageIndexChanging="gvforVillages_PageIndexChanging" OnRowDataBound="gvforVillages_RowDataBound" OnRowDeleting="gvforVillages_RowDeleting" OnRowEditing="gvforVillages_RowEditing" OnRowCommand="gvforVillages_RowCommand" AutoGenerateColumns="False"
                CellPadding="4" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" />
                <RowStyle CssClass="" />
                <AlternatingRowStyle CssClass="alt" BackColor="White" />
                <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
                <Columns>
                    <asp:TemplateField HeaderText="S. No.">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <strong>
                                <asp:Label ID="lblSno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                            </strong>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StateName" HeaderText="StateName"/>  
                    <asp:BoundField DataField="TigerReserveName" HeaderText="Tiger Reserve"/>  
                    <asp:TemplateField HeaderText="Village Code">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <strong>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("VILL_CD") %>'></asp:Label>
                            </strong>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Village Name">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <strong>
                                <%--   <a href="javascript:void();" onclick="MM_openBrWindow('Village_Management_View.aspx?<%= WebConstant.QueryStringEnum.VillageID  %>=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>','main','scrollbars=yes,width=600,height=450')"  style="color:#3F5E1B;">--%>
                                <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                <%-- </a>--%>
                            </strong>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Add CDP">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:ImageButton ID="ibAdd" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="Add"
                                ImageUrl="~/AUTH/adminpanel/images/arrow.png" Visible="false" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="Edit"
                                ImageUrl="~/AUTH/adminpanel/images/arrow.png" Visible="false" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            <strong>Delete
                            </strong>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete?');"
                                CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>'
                                runat="server" ImageUrl="~/AUTH/adminpanel/images/wrong.png" Visible="true" />
                            <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings FirstPageImageUrl="~/AUTH/adminpanel/images/First1.jpg" Mode="Numeric" />
                <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black"
                    HorizontalAlign="right" />
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>

            <asp:HiddenField ID="HiddenField1" runat="server" />

        </div>
    </div>
</asp:Content>

