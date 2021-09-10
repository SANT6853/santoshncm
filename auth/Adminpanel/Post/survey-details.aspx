<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="survey-details.aspx.cs" Inherits="auth_Adminpanel_Post_survey_details" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<style type="text/css">
.table-2 td {
	border-top: none !important;
}
.control-label {
	text-align: left !important;
}
.red-text {
	color: red;
}
a {
	color: #337ab7;
	text-decoration: none;
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
.pgr a, .pgr span {
	display: block;
	height: 30px;
	width: 30px;
	font-weight: bold;
	text-align: center;
	text-decoration: none;
	padding: 5px 10px;
}
a {
	color: #337ab7;
	text-decoration: none;
}
.pgr a {
	background-color: #f5f5f5;
	color: #969696;
	border: 1px solid #969696;
}
.pgr span {
	background-color: #005529;
	color: #fff;
	border: 1px solid #005529;
}
.pagination td {
	border: none !important;
	padding: 1px;
}
</style>

<div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
<div style="margin-left: 993px;">
Instruction File:    <a href="../../Instruction NTCA.pdf" target="_blank" >How to submit the form</a>
</div>
<div class="wrapper-content">
<div class="inner-content-right">
<div class="box box-primary1" style="margin-bottom: 25px;">
<div class="stpdiv"> <span class="box-title stp1 stepArrow stepActive">Step-1</span> <span class="box-title stp1 stepArrow">Step-2</span> <span class="box-title stp1 stepArrow">Step-3</span> <span class="box-title stp1 stepArrow">Step-4</span> <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 4</span> </div>
<div class="box-header with-border">
<h3 class="box-title" style="color: #005529;">Survey Details</h3>
<div class="pull-right" runat="server" id="divAddOption"> <a class="btn btn-primary pull-right btn btn-sm" href="survey.aspx">Add Post Survey Form</a> </div>
</div>
</div>
<div class="form-horizontal">
<div class="col-md-6 col-sm-6 col-xs-12">
<div class="form-group" id="divState" runat="server">
<label class="col-md-4 col-sm-4 col-xs-12 control-label"> State Name : </label>
<div class="col-md-8">
<asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"></asp:DropDownList>
            </div>
          </div>
        </div>
<div class="col-md-6 col-sm-6 col-xs-12">
<div class="form-group" id="divTigerReserve" runat="server">
            <label class="col-md-4 col-sm-4 col-xs-12 control-label"> Tiger Reserve : </label>
            <div class="col-md-8">
              <asp:DropDownList ID="ddlTigerReserve" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddltigerReserve_SelectedIndexChanged"></asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-sm-6 col-xs-12">
<div class="form-group" id="divVilage" runat="server">
<label class="col-md-4 col-sm-4 col-xs-12 control-label"> Village : </label>
            <div class="col-md-8">
              <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-sm-12">
        <div class="col-sm-12">
        <div class="form-group">
          <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
        </div>
        </div>
        </div>
        <div class="col-sm-12">
        <div class="col-sm-12">
		<div class="form-group">
          <asp:Button ID="btnexport" runat="server" CssClass="btn btn-primary" Text="Export to Excel" OnClick="btnexport_Click" Visible="false" style="margin-left:100%" />
        </div>
        </div>
        </div>
      </div>
      <div class="col-md-12 pt20 table-responsive">
        <asp:GridView ID="GVSurvey_Details" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GVSurvey_Details_PageIndexChanging" PageSize="10"
       OnRowCommand="GVSurvey_Details_RowCommand" OnRowDataBound="GVSurvey_Details_RowDataBound" Width="100%"
       CellPadding="4" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass=" table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
       <FooterStyle BackColor="#CCCC99" />
       <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered table-striped" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
       <RowStyle CssClass="" />
       <AlternatingRowStyle CssClass="alt" BackColor="White" />
        <PagerStyle CssClass="pgr" HorizontalAlign="Left" />
          <EmptyDataTemplate>No record found!!</EmptyDataTemplate>
          <Columns>
          <asp:TemplateField ItemStyle-CssClass="Text-Center" HeaderText="S.No.">
            <ItemTemplate> <%#Container .DataItemIndex + 1 %> </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="StateName" HeaderText="State" />
          <asp:BoundField DataField="TigerReserveName" HeaderText="Tiger Reserve" />
          <asp:TemplateField HeaderText="Village" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate> <strong>
              <asp:LinkButton ID="linkFamily" runat="server" OnClick="linkFamily_Click" Text='<%#Eval("VILL_NM") %>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%#Eval("VILL_NM") %></asp:LinkButton>
              </strong> </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>
            <HeaderTemplate> Scheme </HeaderTemplate>
            <ItemTemplate>
              <asp:LinkButton ID="btnScheme" runat="server" OnClick="btnScheme_Click" Text='<%# Eval("Scheme") %>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# Eval("Scheme") %></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          
		  
		   <asp:TemplateField HeaderText="Village" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
			<HeaderTemplate>
			Scheme Amount Used (In <i class="fa fa-inr" style="font-size:16px;" aria-hidden="true"></i>)
			</HeaderTemplate>
            <ItemTemplate> 
				<asp:Label id="lblSchemeAmount" runat="server" Text='<%# Eval("AmountSpent")%>'></asp:Label>
			</ItemTemplate>
          </asp:TemplateField>
		  
		  
		  
		  
          <asp:TemplateField>
            <HeaderTemplate> Work performed under option (II) </HeaderTemplate>
            <ItemTemplate>
              <asp:LinkButton ID="btnWorkperform" runat="server" OnClick="btnWorkperform_Click" Text='<%# Eval("Totalworkperform") %>'  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# Eval("Totalworkperform") %></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
      
		
		   <asp:TemplateField HeaderText="Village" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
			<HeaderTemplate>
			Work performed Amount spent (In Rs <i class="fa fa-inr" style="font-size:16px;" aria-hidden="true"></i>)
			</HeaderTemplate>
            <ItemTemplate> 
				<asp:Label id="lblSpentAmount" runat="server" Text='<%# Eval("SpentAmount")%>'></asp:Label>
			</ItemTemplate>
          </asp:TemplateField>
		
          <asp:BoundField DataField="RemainingAmount" HeaderText="Work performed Remaining Balance (In Rs)" Visible="false" />
          <asp:TemplateField>
            <HeaderTemplate> NGO </HeaderTemplate>
            <ItemTemplate>
              <asp:LinkButton ID="btnNGO" runat="server" OnClick="btnNGO_Click" Text='<%# string.Format("{0}",Eval("TotalNGO").ToString()=="0" && Eval("FinalSubmit").ToString().Trim()=="Submitted"?" ":Eval("TotalNGO").ToString()) %>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# string.Format("{0}",Eval("TotalNGO").ToString()=="0" && Eval("FinalSubmit").ToString().Trim()=="Submitted"?" ":Eval("TotalNGO").ToString()) %></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="reallocated" HeaderText="Relocation Status" />
          <asp:TemplateField>
            <HeaderTemplate> Status at CWLW level </HeaderTemplate>
            <ItemTemplate>
              <%-- <asp:HiddenField ID="hddnAction" runat="server" Value='<%# Eval("status") %>' />--%>
              <asp:Label ID="lblAction" runat="server" Text='<%# Eval("FinalSubmit") %>'></asp:Label>
              <asp:HiddenField ID="hddnAction" runat="server" Value='<%# Eval("FinalSubmit") %>' />
              <asp:LinkButton ID="stateApprove" CssClass="btn btn-primary" Text="Approve" runat="server" OnClick="stateApprove_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PostVill_ID") %>'></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>
            <HeaderTemplate> Status at NTCA level </HeaderTemplate>
            <ItemTemplate>
              <%-- <asp:HiddenField ID="hddnAction" runat="server" Value='<%# Eval("status") %>' />--%>
              <asp:Label ID="lblActionNTCA" runat="server" Text=''></asp:Label>
              <asp:HiddenField ID="hddnActionNTCA" runat="server" Value='<%# Eval("NtcaFinal") %>' />
              <asp:LinkButton ID="stateApproveNTCA" CssClass="btn btn-primary" Text="Approve" runat="server" OnClick="stateApproveNTCA_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PostVill_ID")+","+DataBinder.Eval(Container.DataItem, "FinalSubmit") %>'></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="View Map">
          <ItemStyle HorizontalAlign="Center" />
          <ItemTemplate> <strong>
           <asp:ImageButton ID="viewmap" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PostVill_ID") %>' CommandName="Map"
            Visible="true" ImageUrl="~/auth/Adminpanel/REPORT/Gmap.ico" Width="40px" />
              <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
              </strong> </ItemTemplate>
          </asp:TemplateField>
          </Columns>
          <PagerSettings FirstPageImageUrl="~/AUTH/TIGERRESERVEADMIN/images/First1.jpg" Mode="Numeric" />
          <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black" HorizontalAlign="Center" />
          <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
          <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
          <SortedAscendingCellStyle BackColor="#FBFBF2" />
          <SortedAscendingHeaderStyle BackColor="#848384" />
          <SortedDescendingCellStyle BackColor="#EAEAD3" />
          <SortedDescendingHeaderStyle BackColor="#575357" />
          <PagerStyle CssClass="pgr" />
        </asp:GridView>
      </div>
    </div>
  </div>
</div>
</asp:Content>
