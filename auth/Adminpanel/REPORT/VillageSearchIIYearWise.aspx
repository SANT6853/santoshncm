<%@ Page Title="Village-Wise Report:NTCA" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="VillageSearchIIYearWise.aspx.cs" Inherits="auth_Adminpanel_REPORT_VillageSearchIIYearWise" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <script type="text/javascript">
function MM_openBrWindow(theURL, winName, features) { //v2.0
	window.open(theURL, winName, features);
}
</script>
<script language="javascript" src="../JS/Script.js" type="text/javascript"></script>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<!--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>-->
<style>
.table_new01 {
	padding-top: 10px;
}
.table_new01 a {
	color: blue !important;
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
<style type="text/css">
body {
	background-color: #005529;
}
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
#btn_print, #ImageButton1, .pagination {
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
#print_area {
	margin-top: 0px;
}
@page {
size: landscape;
}
.container-fluid {
	margin-top: 0 !important;
}
#contentbody_gvwork {
	width: 100%;
}
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
.full_width {
 width:100%:
 float:left;
}
@media print {
.col-xs-12 {
	width:50%;
}
}
.form-horizontal .control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left;
}
.table-striped>tbody>tr:nth-of-type(odd) {
	background-color: #f4ffde;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
  <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
      <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
        <div class="wrapper-content">
          <div class="inner-content-right">
            <div class="box box-primary1 pull-left" style="margin-bottom: 25px;">
              <div class="box-header with-border full_width">
                <h3 class="box-title" style="color: #005529; font-weight:bold;">Village-Year Wise Report</h3>
                <div class="prntbck pull-right">
                  <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn btn-sm btn-primary pull-right" OnClick="btn_print_Click1" />
                  <asp:Button ID="BtnExportPDF" runat="server" Text="Export to PDF" CssClass="btn btn-sm btn-warning" OnClick="BtnExportPDF_Click" />
                  <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-sm btn-warning" OnClick="BtnExcelExport_Click" />
                  <asp:Button ID="ImageButton1" runat="server" Text="Back" CssClass="btn btn-primary btn-sm pull-right" Visible="false" OnClick="ImageButton1_Click" />
                </div>
              </div>
            </div>
            <div class="form-horizontal">
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label class="col-sm-4 col-md-4 col-xs-12 control-label">State Name:</label>
                  <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label class="col-sm-4 col-md-4 col-xs-12 control-label">Tiger reserve name:</label>
                  <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged"> </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label class="col-sm-4 col-md-4 col-xs-12 control-label">Village name:</label>
                  <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:TextBox ID="TxtVillName" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
              </div>
              <div class="col-md-6 col-sm-6 col-xs-12" style="display:none;">
                <div class="form-group">
                  <label class="col-sm-4 col-md-4 col-xs-12 control-label">Village code: </label>
                  <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:TextBox ID="TxtVillCOde" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                </div>
              </div>
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label class="col-sm-4 col-md-4 col-xs-12 control-label">Status: </label>
                  <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="DDlStatus" runat="server" CssClass="form-control">
                      <asp:ListItem Text="All" Value="0"></asp:ListItem>
                      <asp:ListItem Text="Relocated" Value="1"></asp:ListItem>
                      <asp:ListItem Text="Non-Relocated" Value="2"></asp:ListItem>
                      <asp:ListItem Text="In Progress" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label class="col-sm-4 col-md-4 col-xs-12 control-label">From date: </label>
                  <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:TextBox ID="txtFrom" autocomplete="off" runat="server" CssClass="form-control" ></asp:TextBox>
                    <%--<asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image3" ImageAlign="Bottom" runat="server" />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFrom"
Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtFrom"
runat="server"> </cc1:CalendarExtender>
                  </div>
                </div>
              </div>
              <div class="col-md-6 col-sm-6 col-xs-12">
                <div class="form-group">
                  <label class="col-sm-4 col-md-4 col-xs-12 control-label">To date: </label>
                  <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:TextBox ID="TxtTo" autocomplete="off"
runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtTo"
Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="TxtTo"
runat="server"> </cc1:CalendarExtender>
                  </div>
                </div>
              </div>
              <div class="col-sm-12 text-left">
                <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                <asp:Button ID="ImgbtnSubmit" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmit_Click" />
              </div>
            </div>
            <div class="col-md-12 table-responsive"
        
            <table id="print_area" width="100%" border="0"
cellpadding="3" cellspacing="0" class=" " style="padding: 15px;">
              <tr>
                <td style="color: #743D02; font-size: large;" align="center" width="100%"><%if (Session["UserType"].ToString().Equals("4"))
{%>
                  <strong><%=Session["sTigerReserveName"].ToString() %> Village-Year Wise Report </strong>
                  <%} %>
                  <%if (Session["UserType"].ToString().Equals("3"))
{%>
                  <strong>Village-Year Wise Report </strong>
                  <%} %>
                  <%if (Session["UserType"].ToString().Equals("1"))

{%>
                  <%} %>
                  <%if (Session["UserType"].ToString().Equals("2"))
{%>
                  <strong>Village-Wise Report </strong>
                  <%} %></td>
              </tr>
              <tr>
                <td align="center"><asp:Label ID="lblnodatafound" runat="server" ForeColor="red"></asp:Label></td>
              </tr>
              <tr>
                <td align="center"><span style="text-align: center;">
                  <asp:Label ID="Label1" runat="server" CssClass="for-view"></asp:Label>
                  <asp:Label ID="Label2" runat="server" CssClass="for-view-lable"></asp:Label>
                  &nbsp; &nbsp;
                  <asp:Label ID="Label3" runat="server" CssClass="for-view"></asp:Label>
                  <asp:Label ID="Label4" runat="server" CssClass="for-view-lable"></asp:Label>
                  </span></td>
              </tr>
              <tr>
                <td class="table_new01"><asp:GridView ID="gv_villageSearch" runat="server" AutoGenerateColumns="False" CellPadding="0"
CellSpacing="0" AllowPaging="True" PageSize="15" Width="100%" OnPageIndexChanging="gv_villageSearch_PageIndexChanging"
RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table-bordered table-striped" OnRowDataBound="gv_villageSearch_RowDataBound" ShowFooter="true">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="white"
BackColor="#FDF4C9" CssClass="table table-bordered table-striped" />
                    <AlternatingRowStyle CssClass="" />
                    <EmptyDataTemplate>
                      <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                    </EmptyDataTemplate>
                    <Columns>
                    <asp:TemplateField HeaderText="S No.">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#Container.DataItemIndex+1 %> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="State Name">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "StateName")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tiger Reserve name">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="submit date">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "REC_CRT_DT1")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Village Name">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate> <strong> <a href="FamilyDetail2.aspx?V_ID=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %> " target="_blank" style="color:blue; text-decoration:underline;"> <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%> </a> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Village Code" Visible="false">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Population">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Land Area(Ha)">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong>
                        <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>
                        </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Total Agriculture Land Area(Ha)">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Total Non Agriculture Land Area(Ha)">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Other Land Area(Ha)">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Value of Agriculture land">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Value Residential Land">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Cow">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoCows")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Buffalo">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoBuffalo")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Sheep">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoSheep")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Goat">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoGoat")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Other Animal">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Relocated Families">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%> </strong> </ItemTemplate>
                      <HeaderStyle Wrap="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Non- Relocated Families">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "vill_status")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NGO">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong>
                        <asp:HyperLink ID="hyperngo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ngo")%>'
ForeColor="#3F5E1B"> </asp:HyperLink>
                        </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NGO I">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong>
                        <asp:HiddenField ID="villid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' />
                        <asp:HyperLink ID="hyperngo1a" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NGOII")%>'
ForeColor="#3F5E1B"> </asp:HyperLink>
                        </strong> </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="white-text pagination GridPager" Font-Bold="True" ForeColor="Black"
HorizontalAlign="left" />
                    <RowStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="True" CssClass="" />
                  </asp:GridView>
                  <%--Exporting gridview--%>
                  <asp:GridView ID="GridViewExport" Visible="false" runat="server" AutoGenerateColumns="False" CellPadding="0"
CellSpacing="0"  Width="100%" OnPageIndexChanging="GridViewExport_PageIndexChanging"
RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table-bordered table-striped" OnRowDataBound="GridViewExport_RowDataBound" ShowFooter="true">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="white"
BackColor="#FDF4C9" CssClass="table table-bordered table-striped" />
                    <AlternatingRowStyle CssClass="" />
                    <EmptyDataTemplate>
                      <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                    </EmptyDataTemplate>
                    <Columns>
                    <asp:TemplateField HeaderText="S No.">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#Container.DataItemIndex+1 %>
                        <%--<asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>--%>
                        </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="State Name">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "StateName")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tiger Reserve name">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="submit date">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "REC_CRT_DT1")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Village Name">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate> <strong>
                        <asp:Label ID="LblVillageName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>'></asp:Label>
                        </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Village Code">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Population">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Land Area(Ha)">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong>
                        <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>
                        </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Total Agriculture Land Area(Ha)">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Total Non Agriculture Land Area(Ha)">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Other Land Area(Ha)">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Value of Agriculture land">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Value Residential Land">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Cow">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoCows")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Buffalo">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoBuffalo")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Sheep">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoSheep")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Goat">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoGoat")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Other Animal">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Relocated Families">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%> </strong> </ItemTemplate>
                      <HeaderStyle Wrap="True" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Non- Relocated Families">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status">
                      <ItemStyle HorizontalAlign="Center" Width="10%" />
                      <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "vill_status")%> </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NGO">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong>
                        <asp:Label ID="LblNGo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ngo")%>'></asp:Label>
                        </strong> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NGO I">
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate> <strong>
                        <asp:HiddenField ID="villid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' />
                        <asp:HyperLink ID="hyperngo1a" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NGOII")%>'
ForeColor="#3F5E1B"> </asp:HyperLink>
                        </strong> </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="white-text pagination GridPager" Font-Bold="True" ForeColor="Black"
HorizontalAlign="left" />
                    <RowStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="True" CssClass="" />
                  </asp:GridView></td>
              </tr>
              <tr>
                <td align="center"><div></div>
                  <%-- <%if (Session["UserType"].ToString().Equals("4"))
{%>
<h4><span style="color: Red;">*</span>  &nbsp; source from <%=Session["sTigerReserveName"].ToString() %> </h4>
<%} %>--%></td>
              </tr>
              <tr>
                <td align="center" style="padding: 20px;"></td>
              </tr>
            </table>
          </div>
        </div>
      </div>
      </div>
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="ImgbtnSubmit" EventName="click" />

        <asp:PostBackTrigger ControlID="BtnExportPDF" />
        <asp:PostBackTrigger ControlID="BtnExcelExport" />
        <asp:PostBackTrigger ControlID="btn_print" />
      <asp:AsyncPostBackTrigger ControlID="gv_villageSearch" EventName="PageIndexChanging" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
