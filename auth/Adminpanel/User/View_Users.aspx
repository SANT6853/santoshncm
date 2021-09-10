<%@ Page Title="View Users:NTCA admin" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="View_Users.aspx.cs" Inherits="auth_Adminpanel_User_View_Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style type="text/css">
.control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left !important;
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
	border:none !important;
	padding:1px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
        <div class="wrapper-content">
          <div class="inner-content-right">
      <div class="box box-primary1" style="margin-bottom: 25px;">
        <div class="box-header with-border">
          <h3 class="box-title" style="color: #005529;">View User List</h3>
        </div>
      </div>
      <div class="col-md-6 col-sm-6 col-xs-12">
        <div class="form-group">
          <label class="col-sm-4 control-label">Select State</label>
          <div class="col-sm-8">
            <asp:DropDownList ID="ddlstate" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"> </asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" InitialValue="0" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlstate" ValidationGroup="val"
                                    ErrorMessage="Select State" />
          </div>
        </div>
      </div>
      <div class="col-sm-12" style="overflow-x:auto;">
        <h2 style=" text-align:center;">
          <asp:Label ID="LblMsg" runat="server"></asp:Label>
        </h2>
        <%-- <asp:GridView ID="grduser" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowDataBound="grduser_RowDataBound" AllowPaging="True" OnPageIndexChanging="grduser_PageIndexChanging" OnRowDeleting="grduser_RowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="20" OnRowCommand="grduser_RowCommand">
                                <AlternatingRowStyle  />--%>
        <asp:GridView ID="grduser" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnRowDataBound="grduser_RowDataBound" AllowPaging="True" OnPageIndexChanging="grduser_PageIndexChanging" OnRowDeleting="grduser_RowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" PageSize="20" OnRowCommand="grduser_RowCommand">
          <AlternatingRowStyle  />
          <Columns>
          <asp:BoundField DataField="UserType" HeaderText="User type" />
          <asp:BoundField DataField="StateName" HeaderText="State" />
          <asp:BoundField DataField="UserName" HeaderText="User Name" />
          <asp:BoundField DataField="FirstName" HeaderText="Name" />
          <asp:BoundField DataField="EmailID" HeaderText="EmailID" />
          <asp:TemplateField HeaderText="Edit">
            <ItemTemplate>
              <asp:HiddenField ID="Hyd" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "UserType") %>' />
              <a class="btn btn-outline btn-round btn-sm purple" href='<%# ResolveUrl("~/auth/Adminpanel/user/Adduser.aspx?Moduleid=1&uid="+Eval("Userid")) %>'><i class="fa fa-edit"></i>Edit</a> </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Permission">
            <ItemTemplate><a id="aPermission" class="btn btn-outline btn-round btn-sm purple" runat="server" href='<%# ResolveUrl("~/auth/Adminpanel/user/TigerReservePermission.aspx?Moduleid=1&uid="+Eval("Userid")) %>'><i class="fa fa-edit"></i>Tiger Reserve Access</a></ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>
            <ItemTemplate><a id="aPermissionDataOperator" class="btn btn-outline btn-round btn-sm purple" runat="server" href='<%# ResolveUrl("~/auth/Adminpanel/user/DpPermision.aspx?Moduleid=1&uid="+Eval("Userid")+"&UserName="+Eval("UserName")) %>'><i class="fa fa-edit"></i>Deputy Director/DFO Access</a></ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
              <asp:LinkButton ID="LnkActiveDeaActive" runat="server" Text='<%#Eval("ActiveStatus") %>' CommandName="AD" CssClass="btn btn-xs btn-success btn-radius" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'  ></asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
              <asp:TemplateField HeaderText="Send Details">
            <ItemTemplate>
              <asp:LinkButton ID="LnksendDetails" runat="server"   CssClass="btn btn-xs btn-success btn-radius" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserID") %>' OnClick="LnksendDetails_Click"  >Send</asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          </Columns>
          <FooterStyle BackColor="#CCCC99" />
          <HeaderStyle BackColor="#005529" Font-Bold="True" ForeColor="White" />
          <PagerStyle  ForeColor="Black" HorizontalAlign="Right" CssClass="GridPager pagination" />
          <RowStyle  />
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
  <script type="text/javascript">
        function ViewDetails(UserName, FirstName, EmailID) {
            alert('dd');
            var message = "UserName: " + UserName;
            message += "\nName: " + FirstName;
            message += "\nEmailID: " + EmailID;
            alert(message);
            return false;
        }
</script> 
  <script type="text/javascript">
         function tryDelete(button)
         {
             var itemName = getItemName(button);
             var itemName1 = getItemName1(button);
            alert(itemName1);
             return confirm("Are you sure ['" + itemName + "'?]");
         }

         function getItemName(button) {
             return button.parentElement.parentElement.children[2].innerHTML;
         }
         function getItemName1(button) {
             return button.parentElement.parentElement.children[10].innerHTML;
         }
       
    </script> 
</asp:Content>
