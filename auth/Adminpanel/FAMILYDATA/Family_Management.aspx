<%@ Page Title="NTCA:View family List" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Family_Management.aspx.cs" Inherits="auth_Adminpanel_FAMILYDATA_Family_Management" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<style type="text/css">
.Text-Center {
	text-align: center;
}
.table-2 td {
	padding: 10px;
	text-align: left;
	width: 23% !important;
}
.modal-dialog {
	top: 7%;
}
.ty23 {
	height: 300px;
	overflow-y: auto;
}
.table_new01 {
	padding-top: 20px;
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
.stp {
	color: #000000;
	text-align: left;
	font-weight: bold;
	background: #f7b000;
	padding: 5px;
}
.form-horizontal .control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left;
}
</style>
<script language="javascript" type="text/javascript">
$(document).ready(function () {

$("[id*=lnkViewDetailss]").click(function (event) {
    // alert('fdf');
    var pagrUrl = "Tooltip.html";
    $('#demoModal').modal('show').find('.modal-body').load(pagrUrl);

    return false;
});
});
</script>
<script type="text/javascript">
var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });
</script>

<div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
  <div class="wrapper-content">
    <div class="inner-content-right">
      <div class="box box-primary1" style="margin-bottom: 25px;">
        <div class="stpdiv"> <span class="box-title stp1 stepArrow">Step-1</span> <span class="box-title stp1 stepArrow stepActive">Step-2</span> <span class="box-title stp1 stepArrow">Step-3</span> <span class="box-title stp1 stepArrow">Step-4</span> <span class="box-title stp1 stepArrow">Step-5</span> <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 5</span> </div>
        <div class="box-header with-border">
          <h3 class="box-title" style="color: #005529;">Add New Family</h3>
          <span class="pull-right">		 
              <asp:Button ID="famback" runat="server" CssClass="btn btn-primary pull-left btn-sm" style=" margin-right: 10px;" Text="Back" OnClick="famback_Click"/>
		  <asp:Button ID="ImgbtnAddNew" runat="server" Text="Add New Family" CssClass="btn btn-primary btn-add btn-sm pull-right" ValidationGroup="Registration" OnClick="ImgbtnAddNew_Click" />
		  </span>
        </div>
      </div>
      
      <div id="foradmin" class="form-horizontal" runat="server">
        <%if (Session["UserType"].ToString().Equals("1"))
                                  {%>
        <div class="col-md-6 col-sm-6 col-xs-12">
          <div class="form-group">
            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Select state name :</label>
            <div class="col-md-8 col-sm-8 col-xs-12">
              <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-sm-6 col-xs-12" id="td" runat="server" visible="false">
          <div class="form-group">
            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Select Tiger Reserve:</label>
            <div class="col-md-8 col-sm-8 col-xs-12">
              <asp:DropDownList ID="ddlselectreserve" runat="server" Visible="false" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged"> </asp:DropDownList>
            </div>
          </div>
        </div>
        <%} %>
        <div class="col-md-6 col-sm-6 col-xs-12" style="display:none;">
          <div class="form-group">
            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Village Name:</label>
            <div class="col-md-8 col-sm-8 col-xs-12">
              <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged"> </asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-sm-6 col-xs-12" style="display:none;">
          <div class="form-group">
            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Option:</label>
            <div class="col-md-8 col-sm-8 col-xs-12">
              <asp:DropDownList ID="ddlselectscheme" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectscheme_SelectedIndexChanged">
                <asp:ListItem Value="0" Text="Select Option"></asp:ListItem>
                <asp:ListItem Value="1" Text="I"></asp:ListItem>
                <asp:ListItem Value="3" Text="II"></asp:ListItem>
                <asp:ListItem Value="4">No Option</asp:ListItem>
              </asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-sm-6 col-xs-12" style="display:none;">
          <div class="form-group">
            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Relocation Status:</label>
            <div class="col-md-8 col-sm-8 col-xs-12">
              <asp:DropDownList ID="ddlselectRelocation" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectRelocation_SelectedIndexChanged">
                <asp:ListItem Value="-1">Select Status</asp:ListItem>
                <asp:ListItem Value="1">Relocated</asp:ListItem>
                <asp:ListItem Value="0">Non-Relocated</asp:ListItem>
              </asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-sm-6 col-xs-12" runat="server" id="ddlselectheadnameRequest">
          <div class="form-group">
            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Family Head Name:</label>
            <div class="col-md-8 col-sm-8 col-xs-12">
              <asp:DropDownList ID="ddlselectheadname" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectheadname_SelectedIndexChanged1"> </asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="col-md-12 col-sm-12 col-xs-12">
		<div class="form-group">
          <asp:Button ID="ImageButton1" runat="server" Text="Search" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImageButton1_Click" />
          <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="btnNext_Click" visible="" />
        </div>
        </div>
        </div>
      </div>
      <div align="center" class="table_new01">
        <asp:GridView ID="gvForFamily" runat="server" AutoGenerateColumns="False" Width="98%" class="table table-bordered table-striped" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-FirstPageImageUrl="~/AUTH/TIGERRESERVEADMIN/images/First1.jpg" CellPadding="4"
                    DataKeyNames="FMLY_ID" AllowPaging="True" OnPageIndexChanging="gvForFamily_PageIndexChanging" OnRowCommand="gvForFamily_RowCommand" OnRowDataBound="gvForFamily_RowDataBound" OnRowDeleting="gvForFamily_RowDeleting" OnRowEditing="gvForFamily_RowEditing" RowStyle-Wrap="true" HeaderStyle-Wrap="true" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
          <FooterStyle BackColor="#CCCC99" />
          <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" BackColor="#005529" Font-Bold="True" ForeColor="White" />
          <RowStyle CssClass="drow" BackColor="" />
          <AlternatingRowStyle CssClass="alt_row" BackColor="White" />
          <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
          <Columns>
          <asp:TemplateField HeaderText="S. No." HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
              <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="StateName" HeaderText="State Name" />
          <asp:TemplateField HeaderText="Village name" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
              <%--<asp:Label ID="LblVillageName" runat="server" Text='<%#Eval("VILL_NM") %>'></asp:Label>--%>
              <a href="javascript:void();" onClick="MM_openBrWindow('View_Family_Details.aspx?<%= WebConstant.QueryStringEnum.Familyid  %>=<%# DataBinder.Eval(Container.DataItem, "FMLY_ID") %>&VillId=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>','main','scrollbars=yes,width=1200,height=700')" style="color: blue; text-decoration: underline;"> <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%> </a> </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Family Head Name" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate> <a href="javascript:void();" onClick="MM_openBrWindow('View_FamilyMember_Details.aspx?<%= WebConstant.QueryStringEnum.FamilyMemberID  %>=<%# DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID") %>','main','scrollbars=yes,width=600,height=450')" style="color: blue; text-decoration: underline;"> <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_NM")%> </a> </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Family Members Details" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="left" />
            <ItemTemplate> <b>
              <asp:Label ID="LblFamilyMemberDetails" Visible="false" runat="server" Text="Family Members Details"></asp:Label>
              <asp:LinkButton ID="LnkFamilyMemberDetails" ForeColor="Blue" Font-Underline="true" runat="server" Text="Family Members Details" CommandName="FamilyMember" CommandArgument='<%# Eval("FMLY_ID")+","+Eval("VILL_ID")%>'></asp:LinkButton>
              </b> </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Option Selected" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
              <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("SCHM_ID") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Edit Family Details" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
            <ItemTemplate>
              <asp:ImageButton ID="ibEditfamilydetails" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FMLY_ID")+","+DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="EditFamilyDetails"
                                    Visible="true" ImageUrl="~/AUTH/adminpanel/images/arrow.png" />
            </ItemTemplate>
            <HeaderStyle HorizontalAlign="Center" />
          </asp:TemplateField>
          <asp:TemplateField HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
            <HeaderTemplate> Delete </HeaderTemplate>
            <ItemTemplate>
              <asp:HiddenField ID="hddnFinalSubmit" runat="server" Value='<%# Eval("FinalSubmit") %>' />
              <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete family?');"
                                    CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FMLY_ID") %>'
                                    runat="server" Visible="true" ImageUrl="~/AUTH/adminpanel/images/wrong.png" />
              <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
            </ItemTemplate>
          </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>No records filled by Deputy Director/DFO.</EmptyDataTemplate>
          <PagerSettings FirstPageImageUrl="~/AUTH/adminpanel/images/First1.jpg" Mode="Numeric" />
          <PagerStyle BackColor="" CssClass="GridPager pagination" Font-Bold="True" ForeColor="black" HorizontalAlign="right" />
          <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
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
<div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">OPTION I & OPTION II DETAILS</h4>
      </div>
      <div class="modal-body ty23"> </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
<%--end modal popup--%>
</asp:Content>
