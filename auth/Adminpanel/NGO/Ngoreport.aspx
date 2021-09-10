<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Ngoreport.aspx.cs" Inherits="auth_Adminpanel_NGO_Ngoreport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <style>
	.table-2 td {
		padding: 10px;
		text-align: left;
		vertical-align: middle !important;
	}
	.container-fluid {
		margin-bottom: 50px !important;
	}
</style>
<script type="text/javascript">
	var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
	var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
	var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
	var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
	var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });
</script>
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
    <div class="wrapper-content" style="padding-top:0px;">
      <div class="inner-content-right">
        <div class="box box-primary1" style="margin-bottom: 25px;">
          <div class="box-header with-border">
            <h3 class="box-title" style="color: #005529;">NGO PRE Monitoring Report</h3>
          </div>
        </div>
        <%if (Session["UserType"].ToString().Equals("1"))
             {%>
        <div>
          <div class="form-group">
            <div class="col-sm-4 ">
              <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged"> </asp:DropDownList>
            </div>
          </div>
        </div>
        <%} %>
        <div class="col-md-12 text-right">
          <asp:Button ID="BtnBackConsoldateReport" Visible="false" runat="server" Text="Back" CssClass="btn btn-primary btn-add" OnClick="BtnBackConsoldateReport_Click" />
          <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
          <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnExcelExport_Click"  />
          <asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary btn-add" Text="Print" OnClick="btnprint_Click" />
        </div>
        <table width="100%" class="table-2">
          <asp:Panel ID="panelprint" runat="server">
            <tr>
              <td><asp:GridView ID="gvforngo" runat="server" AllowPaging="True" DataKeyNames="id" OnPageIndexChanging="gvforngo_PageIndexChanging" PageSize="10" AutoGenerateColumns="False" CellPadding="1" CellSpacing="1" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" Width="100%"
                                OnRowDataBound="gvforngo_RowDataBound">
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" />
                  <RowStyle CssClass="drow" />
                  <AlternatingRowStyle CssClass="alt" />
                  <PagerStyle CssClass="pgr" />
                  <Columns>
                  <asp:TemplateField HeaderText="S. No.">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="lblSno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                      <asp:HiddenField ID="hiden" Value='<%#Eval("id") %>' runat="server" />
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Name of NGO">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Village Name">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="lblnamevillage" runat="server" Text='<%#Eval("VILL_NM") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Mobile No of NGO">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "mobile_no")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Address of NGO">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="address" runat="server" Text='<%#Eval("address") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Email">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="lblwork" runat="server" Text='<%#Eval("work_done") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate> <strong>NGO History </strong> </HeaderTemplate>
                    <ItemTemplate>
                      <asp:GridView ID="grdvillage" AutoGenerateColumns="false" runat="server" CssClass="mGrid table table-bordered table-striped">
                        <Columns>
                        <asp:TemplateField HeaderText="NGO Name">
                          <ItemTemplate> <%#DataBinder.Eval(Container.DataItem, "NGO_NAME")%> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Work Done">
                          <ItemTemplate> <%#DataBinder.Eval(Container.DataItem, "NGO_Work")%> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                          <ItemStyle Width="100%" HorizontalAlign="Center" />
                          <ItemTemplate> <%#DataBinder.Eval(Container.DataItem, "Address")%> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile">
                          <ItemStyle Width="100%" HorizontalAlign="Center" />
                          <ItemTemplate> <%#DataBinder.Eval(Container.DataItem, "Mobile")%> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                          <ItemStyle Width="100%" HorizontalAlign="Center" />
                          <ItemTemplate> <%#DataBinder.Eval(Container.DataItem, "Remarks")%> </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Registration No">
                          <ItemStyle Width="100%" HorizontalAlign="Center" />
                          <ItemTemplate> <%#DataBinder.Eval(Container.DataItem, "Rgistration")%> </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
                  <PagerSettings FirstPageImageUrl="~/AUTH/TIGERRESERVEADMIN/images/First1.jpg" Mode="Numeric" />
                  <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                    HorizontalAlign="Center" />
                  <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                </asp:GridView></td>
            </tr>
            <tr>
              <td align="center"><%-- <h4> <span style="color:Red;">*</span>  &nbsp; <b>source from <%=Session["sTigerReserveName"].ToString() %></b> </h4>--%></td>
            </tr>
          </asp:Panel>
          <tr>
            <td align="center"></td>
          </tr>
        </table>
      </div>
    </div>
  </div>
</asp:Content>
