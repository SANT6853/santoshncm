<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="fundlist.aspx.cs" Inherits="auth_Adminpanel_FundManagement_fundlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style>
.red-text-1a {
	color: red;
}
.table-2 td {
	padding: 10px;
	text-align: left;
	vertical-align: middle !important;
}
.container-fluid {
	margin-bottom: 50px !important;
}
.table-3 td {
	padding: 5px;
	text-align: left;
}
.btn-add {
	margin-bottom: 0px;
}
.control-label {
	text-align: left !important;
}
.mr3 {
	margin-right: 3px;
}
.stp {
	color: #000000;
	text-align: left;
	font-weight: bold;
	background: #f7b000;
	padding: 5px;
}
.stp1 {
	color: #fff;
	text-align: left;
	font-weight: bold;
	background: #005529;
	padding: 5px;
}
.stpdiv {
	padding: 0 0 30px 0;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
<div class="wrapper-content" style="padding-top: 0px; padding-bottom: 0; min-height: 550px;">
<div class="row">
<div class="col-lg-12">
<div class="widgets-container">
<div class="box box-primary1" style="margin-bottom: 25px;">
     <div><h2 class="box-title" style="color: #005529;margin-left:37%">View Fund Details</h2></div>
</div>
  <div class="row">
  <div class="col-md-12 text-right">
	<asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
</div>
  
  <div class="col-md-12 pt20 table-responsive">
    <asp:GridView ID="GvAdd_NGODetails" runat="server" DataKeyNames="fid" AutoGenerateColumns="false"
            OnRowCommand="GvAdd_NGODetails_RowCommand" OnRowDataBound="GvAdd_NGODetails_RowDataBound" Width="100%" PageSize="50" AllowPaging="true" OnPageIndexChanging="GvAdd_NGODetails_PageIndexChanging"
            CellPadding="4" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass=" table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
      <FooterStyle BackColor="#CCCC99" />
      <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered table-striped" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
      <RowStyle CssClass="" />
      <AlternatingRowStyle CssClass="alt" BackColor="White" />
      <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
      <Columns>
      <asp:TemplateField ItemStyle-CssClass="Text-Center" HeaderText="S.No.">
        <ItemTemplate> <%#Container .DataItemIndex + 1 %> </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="VILL_NM" HeaderText="Village NAME" />
      <asp:BoundField DataField="FundAmount" HeaderText="Fund Amount" />
      <asp:BoundField DataField="FunDescription" HeaderText="Description" />
      <asp:BoundField DataField="Date" HeaderText="CreatedOn" />
      <asp:TemplateField>
        <HeaderTemplate> Edit </HeaderTemplate>
        <ItemTemplate>
          <asp:Button ID="imgedit1" runat="server" ToolTip="Edit" CssClass="btn btn-primary btn-xs" Text="Edit" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"fid")%>' CommandName="Edit" />
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField>
        <HeaderTemplate> Delete </HeaderTemplate>
        <ItemTemplate>
          <asp:HiddenField ID="hddnFinal" runat="server" Value='<%# Eval("FinalSubmit") %>' />
          <asp:Button ID="imgedit" runat="server" ToolTip="Delete" CssClass="btn btn-danger btn-xs" Text="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"fid")%>' CommandName="Delete" />
        </ItemTemplate>
      </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>Fund request not submitted by DFO</EmptyDataTemplate>
      <PagerSettings FirstPageImageUrl="~/AUTH/TIGERRESERVEADMIN/images/First1.jpg" Mode="Numeric" />
      <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" />
      <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
      <SortedAscendingCellStyle BackColor="#FBFBF2" />
      <SortedAscendingHeaderStyle BackColor="#848384" />
      <SortedDescendingCellStyle BackColor="#EAEAD3" />
      <SortedDescendingHeaderStyle BackColor="#575357" />
      <PagerStyle CssClass="page_style" />
    </asp:GridView>
  </div>
  <div class="col-md-12 margin-top-10">
    <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary" Text="Next" OnClick="btnNext_Click" />
  </div>
  </div>
</div>

</div>
</div>
</div>
</div>
</asp:Content>
