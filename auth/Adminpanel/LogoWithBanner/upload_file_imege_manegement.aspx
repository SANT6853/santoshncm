<%@ Page Title="NTCA:Related file images" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="upload_file_imege_manegement.aspx.cs" Inherits="auth_Adminpanel_upload_file_imege_manegement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<style>
.table-2 td {
	padding:10px;
	text-align:left;
}
.container-fluid {
	margin-bottom:50px !important;
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
</style>
<script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });
</script>
<script type="text/javascript">
       function validation() {
           debugger;
           var state = document.getElementById("<%=DdlStateName.ClientID%>").value.trim();
           var Tiger = document.getElementById("<%=ddlselectreserve.ClientID%>").value.trim();
           var Village = document.getElementById("<%=ddlvillage.ClientID%>").value.trim();
           if (state == 0) {
               alert("Please Select State Name");
               document.getElementById("<%=DdlStateName.ClientID%>").focus();
               return false;
           }
           if (state == 0) {
              <%-- alert("Please Select Tiger Reserve");
               document.getElementById("<%=ddlselectreserve.ClientID%>").focus();
               return false;--%>
           }
           if (Village == 0) {
               alert("Please Select Village Name");
               document.getElementById("<%=ddlvillage.ClientID%>").focus();
               return false;
           }
       }
      
</script>

<div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
        <div class="wrapper-content">
          <div class="inner-content-right">
          <div class="box box-primary1" style="margin-bottom: 25px;">
            <div class="box-header with-border">
              <h3 class="box-title" style="color: #005529;">Related files and Images</h3>
            </div>
          </div>
          <div class="form-horizontal">
            <div class="">
              <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            </div>
            <%if (Session["UserType"].ToString().Equals("1"))
                                      {%>
            <div class="col-md-6">
              <div class="form-group">
                <label class="col-sm-3 control-label"><span class="black-text" align="center">State Name
                  <asp:Label ID="StartStateName" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*">*</asp:Label>
                  :</span></label>
                <div class="col-sm-9">
                  <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged" ></asp:DropDownList>
                </div>
              </div>
            </div>
            <%} %>
            <div class="col-md-6">
              <div class="form-group">
                <label class="col-sm-3 control-label" id="td" runat="server"  style="font-size: 15px; vertical-align: middle;"> <span class="black-text" align="center">Tiger Reserve
                  <asp:Label ID="StarTreserve" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>
                  :</span> </label>
                <div class="col-sm-9">
                  <div id="td1" runat="server" >
                    <asp:DropDownList ID="ddlselectreserve" Width="100%" runat="server"  CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList>
                  </div>
                  <div width="60%" id="td007" runat="server" visible=""></div>
                  <div id="td008" runat="server" visible=""></div>
                </div>
              </div>
            </div>
            <div class="col-md-6" style="display: none;">
              <div class="form-group">
                <label class="col-sm-3 control-label">Village Code
                  <asp:Label ID="StartVcode" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>
                  : </label>
                <div class="col-sm-9">
                  <asp:DropDownList ID="ddlselectcode" runat="server" CssClass="textfield-drop form-control"> </asp:DropDownList>
                </div>
              </div>
            </div>
            <div class="col-md-6">
              <div class="form-group">
                <label class="col-sm-3 control-label">Village Name
                  <asp:Label ID="StarVname" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>
                  :</label>
                <div class="col-sm-9">
                  <asp:DropDownList ID="ddlvillage" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlvillage_SelectedIndexChanged"> </asp:DropDownList>
                </div>
              </div>
            </div>
            <div class="col-md-8">
            <div class="col-md-8">
            <div class="form-group">
              <asp:Button ID="btnadd" runat="server" Text="Add Files" CssClass="btn btn-primary btn-add" onclick="btnadd_Click"  />
              <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success" OnClick="btnSearch_Click" />
              <br />
              <asp:Label ID="Label1" runat="server" CssClass="red-text"></asp:Label>
            </div>
            </div>
            </div>
          </div>
<%-- *******************end nw --%>
<div class="col-md-12">
  <asp:GridView ID="gvVillagesRelatedfile" runat="server" AllowPaging="True" OnRowDataBound="gvVillagesRelatedfile_RowDataBound" 
        DataKeyNames="id" 
        OnPageIndexChanging="gvVillagesRelatedfile_PageIndexChanging"  
        OnRowDeleting="gvVillagesRelatedfile_RowDeleting" 
        OnRowEditing="gvVillagesRelatedfile_RowEditing" 
        OnRowCommand="gvVillagesRelatedfile_RowCommand" AutoGenerateColumns="False"
            CellPadding="4"  RowStyle-Wrap="true" 
        HeaderStyle-Wrap="true"   CssClass= "mGrid table table-bordered table-striped" Width="100%" 
        EmptyDataText="No Related File Uploaded" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" >
    <FooterStyle BackColor="#CCCC99" />
    <HeaderStyle   HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" />
    <RowStyle CssClass="drow" BackColor="" />
    <AlternatingRowStyle CssClass="alt" BackColor="White" />
    <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
    <Columns>
    <asp:TemplateField HeaderText="S. No.">
      <ItemStyle HorizontalAlign="Center"/>
      <ItemTemplate>
        <asp:Label ID="lblSno" runat="server" Text ='<%#Container.DataItemIndex+1 %>'></asp:Label>
      </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Title">
      <ItemStyle HorizontalAlign="Center"  />
      <ItemTemplate>
        <asp:Label ID="lblname" runat="server" Text='<%#Eval("title") %>' ></asp:Label>
      </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Description">
      <ItemStyle HorizontalAlign="Center"  />
      <ItemTemplate> <%#DataBinder.Eval(Container.DataItem, "description")%> </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField HeaderText="View File">
      <ItemStyle HorizontalAlign="Center"  />
      <ItemTemplate>
          <%-- <%#DataBinder.Eval(Container.DataItem, "file_Name")%> --%>
          <asp:HiddenField ID="hydfile" runat="server" Value='<%# Eval("file_Name") %>' />
           <%--<asp:Literal ID="ltlViewLetter" runat="server" ></asp:Literal>--%>
          <a target="_blank" href="<%=ResolveUrl("~/WriteReadData/UserFiles/") %><%#Eval("file_Name") %>">View</a>
      </ItemTemplate>
           
            
    </asp:TemplateField>
    <asp:TemplateField HeaderText="File type">
      <ItemStyle HorizontalAlign="Center"  />
      <ItemTemplate> <%#DataBinder.Eval(Container.DataItem, "files")%> </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Edit">
      <ItemStyle HorizontalAlign="Center"  />
      <ItemStyle HorizontalAlign="Center" />
      <ItemTemplate>
        <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CommandName="Edit"
                                               ImageUrl="~/AUTH/adminpanel/images/arrow.png"  />
        <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
      </ItemTemplate>
      <HeaderStyle HorizontalAlign="Center" />
    </asp:TemplateField>
    <asp:TemplateField>
      <ItemStyle HorizontalAlign="Center"  />
      <HeaderTemplate> <strong> Delete </strong> </HeaderTemplate>
      <ItemTemplate>
        <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete?');"
                                                CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                              runat="server"  ImageUrl="~/AUTH/adminpanel/images/wrong.png" Visible="true" />
      </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    <PagerSettings FirstPageImageUrl="~/AUTH/adminpanel/images/First1.jpg" Mode="Numeric"  />
    <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black"
                            HorizontalAlign="right" />
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
</asp:Content>
