<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="post-preview.aspx.cs" Inherits="auth_Adminpanel_Post_post_preview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
.form-group {
	margin-bottom: 0;
}
a {
	color: #337ab7;
}
.hts {
	background: #005529;
	color: #fff;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
  <div class="modal fade tophght" id="myModal" role="dialog">
    <div class="modal-dialog modwidth">
      <div class="modal-content">
        <div class="modal-header nobdr"> </div>
        <div class="modal-body text-center modwidth1">
          <p><b>form has been submitted.</b></p>
        </div>
        <div class="modal-footer text-center procenter nobdr">
          <asp:Button ID="btnnextstep" runat="server" CssClass="btn btn-success" Text="OK" OnClick="btnnextstep_Click" />
        </div>
      </div>
    </div>
  </div>
  <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
    <div class="wrapper-content">
      <div class="inner-content-right">
        <div class="box box-primary1" style="margin-bottom: 25px;">
          <div class="box-header with-border">
            <h3 class="box-title" style="color: #005529;">Form Preview </h3>
          </div>
        </div>
        <div class="form-horizontal">
        <div class="row">
          <div class="col-md-12 pt20 table-responsive">
            <asp:GridView ID="GVSurvey_Details" runat="server"  AutoGenerateColumns="false"
                                        OnRowCommand="GVSurvey_Details_RowCommand" OnRowDataBound="GVSurvey_Details_RowDataBound" Width="100%"
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
              <asp:TemplateField HeaderText="Village" HeaderStyle-CssClass="Text-Center">
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate> <strong>
                  <asp:LinkButton ID="linkFamily" runat="server" OnClick="linkFamily_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%#Eval("VILL_NM") %></asp:LinkButton>
                  </strong> </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <HeaderTemplate> Scheme </HeaderTemplate>
                <ItemTemplate>
                  <asp:LinkButton ID="btnScheme" runat="server" OnClick="btnScheme_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# Eval("Scheme") %></asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="AmountSpent" HeaderText="Scheme Amount Used (In Rs)" />
              <asp:TemplateField>
                <HeaderTemplate> Work performed under option (II) </HeaderTemplate>
                <ItemTemplate>
                  <asp:LinkButton ID="btnWorkperform" runat="server" OnClick="btnWorkperform_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# Eval("Totalworkperform") %></asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="SpentAmount" HeaderText="Work performed Amount spent (In Rs)" />
              <asp:BoundField DataField="RemainingAmount" HeaderText="Work performed Remaining Balance (In Rs)" Visible="false" />
              <asp:TemplateField>
                <HeaderTemplate> NGO </HeaderTemplate>
                <ItemTemplate>
                  <asp:LinkButton ID="btnNGO" runat="server" OnClick="btnNGO_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# Eval("TotalNGO") %></asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="reallocated" HeaderText="Relocation Status" />
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
              <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                            HorizontalAlign="Center" />
              <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
              <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#FBFBF2" />
              <SortedAscendingHeaderStyle BackColor="#848384" />
              <SortedDescendingCellStyle BackColor="#EAEAD3" />
              <SortedDescendingHeaderStyle BackColor="#575357" />
              <PagerStyle CssClass="page_style" />
            </asp:GridView>
          </div>
          <div class="col-md-8">
            <div class="form-group">
              <div class="col-md-6"> </div>
            </div>
          </div>
          <div class="col-md-8" runat="server" id="divfinal">
            <div class="form-group">
              <div class="col-sm-6">
                <asp:Button ID="btnFinalSubmit" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btnFinalSubmit_Click"  />
              </div>
            </div>
          </div>
           </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
