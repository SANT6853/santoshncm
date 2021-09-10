<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="form-preview.aspx.cs" Inherits="auth_Adminpanel_form_preview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
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
.procenter {
	text-align: center;
}
.modwidth {
	width: 500px !important;
}
.modwidth1 p {
	font-size: 160%;
}
.nobdr {
	border: none !important;
}
.tophght {
	top: 26% !important;
}
</style>
<div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
        <div class="wrapper-content">
          <div class="inner-content-right">
          <div class="box box-primary1" style="margin-bottom: 25px;">
            <div class="box-header with-border">
              <h3 class="box-title" style="color: #005529;">Form Preview </h3>
			  <div class="pull-right" runat="server" id="divfinal" >
                <asp:Button ID="btnFinalSubmit"  runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btnFinalSubmit_Click" />
			</div>
            </div>
          </div>
          <div class="form-horizontal">
            <div class="col-md-12 pt20 table-responsive">
            <div class="row">
              <asp:GridView ID="GvAdd_NGODetails" runat="server" DataKeyNames="VILL_ID" AutoGenerateColumns="false"
                                    OnRowCommand="GvAdd_NGODetails_RowCommand" OnRowDataBound="GvAdd_NGODetails_RowDataBound" Width="100%"  AllowPaging="false"
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
                <asp:BoundField DataField="StateName" HeaderText="State Name" />
                <asp:BoundField DataField="TigerReserveName" HeaderText="Tiger Reserve" />
                <asp:TemplateField>
                  <HeaderTemplate> Village Name </HeaderTemplate>
                  <ItemTemplate>
                    <asp:LinkButton ID="linkVillage" runat="server" OnClick="linkVillage_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'><%#Eval("VILL_NM") %></asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                  <HeaderTemplate> Family </HeaderTemplate>
                  <ItemTemplate>
                    <asp:LinkButton ID="linkFamily" runat="server" OnClick="linkFamily_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'><%#Eval("VillageCount") %></asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                  <HeaderTemplate> Forms: (pre/survey/legal/consent) </HeaderTemplate>
                  <ItemTemplate>
                    <asp:LinkButton ID="btnServey" runat="server" Text="View" OnClick="btnServey_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'></asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                  <HeaderTemplate> NGO </HeaderTemplate>
                  <ItemTemplate>
                    <asp:LinkButton ID="btnNGO" runat="server" OnClick="btnNGO_Click"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'><%# Eval("NGOCount") %></asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                  <HeaderTemplate> Funds Required </HeaderTemplate>
                  <ItemTemplate>
                    <asp:LinkButton ID="btnFund" runat="server" OnClick="btnFund_Click"  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'><%# Eval("FundAmount") %></asp:LinkButton>
                  </ItemTemplate>
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
            </div>
            
            
            <div class="col-md-12"> </div>
          </div>
        </div>
      </div>
    </div>
  <%-- *******************end nw --%>
</div>
<div class="modal fade tophght" id="myModal" role="dialog">
  <div class="modal-dialog modwidth"> 
    
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header nobdr"> </div>
      <div class="modal-body text-center modwidth1">
        <p><b>Do you want to final submit of form, After submit form you can not able to any changes.</b></p>
      </div>
      <div class="modal-footer text-center procenter nobdr">
        <asp:Button ID="btnnextstep" runat="server" CssClass="btn btn-success" Text="Yes" OnClick="btnnextstep_Click"/>
        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="No" />
      </div>
    </div>
  </div>
</div>
</asp:Content>
