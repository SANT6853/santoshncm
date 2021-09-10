<%@ Page Title="NTCA:Family Report by Head Name" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Familydata.aspx.cs" Inherits="auth_Adminpanel_REPORT_Familydata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<style>
.table-2 td {
	text-align: left;
	padding-bottom: 4px;
}
.container-fluid {
	margin-bottom: 50px !important;
}
.red-text {
	color: red;
}
.form-horizontal .control-label {
    padding-top: 7px;
    margin-bottom: 0;
    text-align: left;
}
</style>
<div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
  <div class="wrapper-content">
    <div class="inner-content-right">
      <div class="box box-primary1" style="margin-bottom: 25px;">
        <div class="box-header with-border">
          <h3 class="box-title" style="color: #005529;">Family Report by Head Name</h3>
        </div>
      </div>
	  <div class="form-horizontal">
      <p>
        <asp:Label ID="lblMsg" runat="server" ForeColor="red"> </asp:Label>
      </p>
      <%if (Session["UserType"].ToString().Equals("1"))
                  {%>
      <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="form-group">
          <label class="control-label col-md-4 col-sm-4 col-xs-12">Tiger Reserve name <span class="red-text">*</span>:</label>
          <div class="col-md-8 col-sm-8 col-xs-12">
            <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged"> </asp:DropDownList>
          </div>
        </div>
      </div>
      <%} %>
      <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="form-group">
          <label class="control-label col-md-4 col-sm-4 col-xs-12">Village Name <span class="red-text">*</span>:</label>
          <div class="col-md-8 col-sm-8 col-xs-12">
            <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged"> </asp:DropDownList>
          </div>
        </div>
      </div>
      <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="form-group">
          <label class="control-label col-md-4 col-sm-4 col-xs-12">Family Head Name<span class="red-text">*</span>:</label>
          <div class="col-md-8 col-sm-8 col-xs-12">
            <asp:DropDownList ID="ddlselectheadname" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control"> </asp:DropDownList>
          </div>
        </div>
      </div>
      <div class="col-md-12 col-sm-12 col-xs-12">
        <asp:Button ID="BtnBackConsoldateReport" Visible="false" runat="server" Text="Back" CssClass="btn btn-primary btn-add" OnClick="BtnBackConsoldateReport_Click" />
        <asp:Button ID="ImageButton1" runat="server" Text="Search" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImageButton1_Click" />
      </div>
    </div>
    </div>
  </div>
</div>
</asp:Content>
