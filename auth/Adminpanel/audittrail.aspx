


<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="audittrail.aspx.cs" Inherits="auth_Adminpanel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
<div class="wrapper-content">
<div class="row">
<div class="col-lg-12  bottom20">
<div class="box box-primary1" style="margin-bottom: 25px;">
<div class="box-header with-border">
<h3 class="box-title" style="color: #005529;">Audit Trail</h3>
</div>
<!-- /.box-header -->
<!-- form start -->
</div>


<style>
.main_pagination table tbody tr td {
 padding: 15px !important;
 border:none !important;
 border:1px solid #fff !important;
 background:#005529!important;
 color:#fff !important;
 }
 
 </style>

<div class="feedback">
<!--start-->
<asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"  AllowPaging="true" PageSize="10">
<PagerStyle  CssClass="main_pagination"/>
<Columns>
<asp:BoundField HeaderText="Sl No" DataField="slno" />
<asp:BoundField HeaderText="Name" DataField="userName" />
<asp:BoundField HeaderText="User Id" DataField="userid" />
<asp:BoundField HeaderText="Date & Time" DataField="timeDate" />
<asp:BoundField HeaderText="Activity" DataField="ActionType" />
<asp:BoundField HeaderText="Ip Address" DataField="Ip_Address" />
</Columns>
</asp:GridView>
<!--end-->
</div>
</div>
</div>
</div>
</div>
</asp:Content>

