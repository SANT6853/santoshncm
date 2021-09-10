<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ConversionScheme.aspx.cs" Inherits="auth_Adminpanel_Post_ConversionScheme" %>
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
table tr.headings th {
	background: #efefef !important;
	color: #212121;
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
<script type="text/javascript">
        $(function () {
            $("[id*=btnShow]").click(function () {
                debugger;
                backdrop: 'static'
                keyboard: false
                var ConversionID = $(this).attr('ConversionID');
                var bodyhtml = "";
                $.ajax({
                    type: "POST",
                    url: "ConversionScheme.aspx/BindModelGridView",
                    data: "{ 'ConversionID':'" + ConversionID + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (r) {
                        debugger;
                        var valuebody = JSON.parse(r.d)
                        var bodylen = valuebody.length;
                        if (bodylen == "0") {
                            bodyhtml = bodyhtml + "<tr colspan=" + 5 + "><td>" + "No Records Found!" + "</td></tr>"
                        }
                        else {

                            for (i = 0; i < bodylen; i++) {
                                bodyhtml = bodyhtml + "<tr><td>" + (i + 1) + "</td><td>" + valuebody[i].SchemeName + "</td><td>" + valuebody[i].StateCentralType + "</td><td>" + valuebody[i].BenfitExten + "</td><td>" + valuebody[i].AmountSpent + "</td><td>" + valuebody[i].remark + "</td><td>" + valuebody[i].CreatedDate + "</td></tr>"
                            }
                        }
                        $('[id*=gridhearing]').html(bodyhtml);
                        bodyhtml = "";

                    },
                    error: function (r) {
                    }
                });

                $('#demoModal').modal('show').find('.modal-body');
                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
      <div class="modal-content modal-lg">
        <div class="modal-header">
          <div></div>
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="btnClose">&times;</button>
          <h4 class="modal-title" id="myModalLabel">Scheme History </h4>
        </div>
        <div class="modal-body">
          <div>
            <div>
              <table class="table tblProducts">
                <thead>
                  <tr class="headings">
                    <th>Sl.no </th>
                    <th>Scheme Name </th>
                    <th>State/Central </th>
                    <th>Benefits Extended </th>
                    <th>Amount Spent </th>
                    <th>Remarks </th>
                    <th>CreatedOn </th>
                  </tr>
                </thead>
                <tbody id="gridhearing">
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="modal fade tophght" id="myModal" role="dialog">
    <div class="modal-dialog modwidth">
      <div class="modal-content">
        <div class="modal-header nobdr"> </div>
        <div class="modal-body text-center modwidth1">
          <p><b>Scheme has been deleted.</b></p>
        </div>
        <div class="modal-footer text-center procenter nobdr">
          <asp:Button ID="btnnextstep" runat="server" CssClass="btn btn-success" Text="OK" />
        </div>
      </div>
    </div>
  </div>
  <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
    <div class="wrapper-content">
      <div class="inner-content-right">
        <div class="box box-primary1" style="margin-bottom: 25px;">
          <div class="stpdiv"> <span class="box-title stp1 stepArrow">Step-1</span> <span class="box-title stp1 stepArrow stepActive">Step-2</span> <span class="box-title stp1 stepArrow">Step-3</span> <span class="box-title stp1 stepArrow">Step-4</span> <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 4</span> </div>
          <div class="box-header with-border">
            <h3 class="box-title" style="color: #005529;">Convergence with others central/state Government Scheme</h3>
            <div class="pull-right">
			<asp:Button ID="btnexport" runat="server" CssClass="btn btn-sm btn-primary pull-left" Text="Export to Excel" OnClick="btnexport_Click" Visible="false" />
            <div class="pull-right" runat="server" id="divNGO" style="margin-left:15px;">
              <asp:Button ID="btnScheme" runat="server" Text="Add Scheme" CssClass="btn btn-primary btn-sm" OnClick="btnScheme_Click" />
            </div>
            </div>
          </div>
        </div>
        <span id="contentbody_lblmsg"></span>
        <div class="form-horizontal">
          <div class="col-md-6">
            <div class="form-group">
              <label id="" class="col-md-4 control-label"><b>Scheme Name </b></label>
              <div class="col-sm-8">
                <asp:DropDownList ID="ddlScheme" runat="server" CssClass="form-control"></asp:DropDownList>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-8">
          <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
          <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary" Text="Next" OnClick="btnNext_Click" />
        </div>
        <div class="col-md-12 pt20 table-responsive">
          <asp:GridView ID="GV_Scheme" runat="server" DataKeyNames="ConversionID" AutoGenerateColumns="false"
            OnRowCommand="GV_Scheme_RowCommand" OnRowDataBound="GV_Scheme_RowDataBound" Width="100%" OnRowDeleted="GV_Scheme_RowDeleted"
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
            <asp:TemplateField>
              <HeaderTemplate> Scheme Name </HeaderTemplate>
              <ItemTemplate> <a href="javascript:void(0);" id="btnShow" conversionid='<%# Eval("ConversionID") %>'><%# DataBinder.Eval(Container.DataItem, "SchemeName")%> </a> </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StateCentralType" HeaderText="State/Central" />
            <asp:BoundField DataField="BenfitExten" HeaderText="Benefits Extended" />
            
			<asp:TemplateField HeaderText="Village" HeaderStyle-CssClass="Text-Center">
            <ItemStyle HorizontalAlign="Center" />
			<HeaderTemplate>
			Scheme Amount Used (In <i class="fa fa-inr" style="font-size:16px;" aria-hidden="true"></i>)
			</HeaderTemplate>
            <ItemTemplate> 
				<asp:Label id="lblAmountSpent" runat="server" Text='<%# Eval("AmountSpent")%>'></asp:Label>
			</ItemTemplate>
          </asp:TemplateField>
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedOn" />
            <asp:TemplateField>
              <HeaderTemplate> Add Scheme </HeaderTemplate>
              <ItemTemplate>
                <asp:HiddenField ID="hddnfinalsubmit1" runat="server" Value='<%# Eval("ConversionID") %>' />
                <asp:Button ID="btnaddScheme" runat="server" ToolTip="Delete" CssClass="btn btn-primary btn-xs" Text="Add Scheme" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ConversionID")%>' CommandName="Add" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <HeaderTemplate> Delete Scheme </HeaderTemplate>
              <ItemTemplate>
                <asp:HiddenField ID="hddnfinalsubmit" runat="server" Value='<%# Eval("FinalSubmit") %>' />
                <asp:Button ID="imgedit1" runat="server" ToolTip="Delete" CssClass="btn btn-danger btn-xs" Text="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ConversionID")%>' CommandName="Delete" />
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
    </div>
  </div>
</asp:Content>
