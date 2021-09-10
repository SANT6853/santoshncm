<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="workperformlist.aspx.cs" Inherits="auth_Adminpanel_Post_workperformlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                      url: "workperformlist.aspx/BindModelGridView",
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
                                  bodyhtml = bodyhtml + "<tr><td>" + (i + 1) + "</td><td>" + valuebody[i].ExecutiveName + "</td><td>" + valuebody[i].SpentAmount + "</td><td>" + valuebody[i].taskDone + "</td><td>" + valuebody[i].Remarks + "</td><td>" + valuebody[i].CreatedOn + "</td></tr>"
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
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
  <div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
      <div class="modal-content modal-lg">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="btnClose">&times;</button>
          <h4 class="modal-title" id="myModalLabel">Work performed under option (II) History </h4>
        </div>
        <div class="modal-body">
          <div>
            <div>
              <table class="table tblProducts">
                <thead>
                  <tr class="headings">
                    <th>Sl.no </th>
                    <th>Executing Agency Name </th>
                    <th>Amount spent </th>
                    <th>Work Done </th>
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
<div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
        <div class="wrapper-content">
          <div class="inner-content-right">
      <div class="box box-primary1" style="margin-bottom: 25px;">
        <div class="stpdiv"> <span class="box-title stp1 stepArrow">Step-1</span> <span class="box-title stp1 stepArrow">Step-2</span> <span class="box-title stp1 stepArrow stepActive">Step-3</span> <span class="box-title stp1 stepArrow">Step-4</span> <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 4</span> </div>
        <div class="box-header">
          <h3 class="box-title" style="color: #005529;">Work performed under option (II)</h3>
          <div class="pull-right" runat="server" id="divNGO">
          <asp:Button ID="btnExecutive" runat="server" Text="Add Executing Agency " CssClass="btn btn-primary btn-sm" OnClick="btnExecutive_Click"  />
          <asp:Button ID="btnexport" runat="server" CssClass="brn btn-primary btn-sm" Text="Export to Excel" OnClick="btnexport_Click" Visible="false"/>
        </div>
        </div>
		
      </div>
      <span id="contentbody_lblmsg"></span>
      <div class="form-horizontal">
          <div style="margin-left: 1133px;">
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
                            </div>
        <div class="col-md-6">
          <div class="form-group">
            <label id="" class="col-md-4 control-label"><b>Executing Agency Name</b></label>
            <div class="col-sm-8">
              <asp:DropDownList ID="ddlexcutive" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
          </div>
        </div>
        
      </div>
      <br />
      <div class="col-md-8">
        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
        <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary" Text="Next" OnClick="btnNext_Click" />
      </div>
      <div class="col-md-12 pt20 table-responsive">
    <asp:GridView ID="GvAdd_NGODetails" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" OnRowDeleted="GvAdd_NGODetails_RowDeleted"
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
      <asp:TemplateField>
        <HeaderTemplate> Executing  Agency Name </HeaderTemplate>
        <ItemTemplate> <a href="javascript:void(0);" id="btnShow" ConversionID='<%# Eval("ID") %>'><%# DataBinder.Eval(Container.DataItem, "ExecutiveName")%> </a> </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="SpentAmount" HeaderText="Amount spent" />
      <asp:BoundField DataField="RemainingAmount" HeaderText="Remaining Balance"  Visible="false"/>
      <asp:BoundField DataField="taskDone" HeaderText="Work Done " />
      <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
      <asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" />
      <asp:TemplateField>
        <HeaderTemplate> Add Executing  Agency </HeaderTemplate>
        <ItemTemplate>
          <asp:HiddenField ID="hddnfinalsubmit1" runat="server" Value='<%# Eval("FinalSubmit") %>' />
          <asp:Button ID="btnaddScheme" runat="server" ToolTip="Add Executing Agency" CssClass="btn btn-primary btn-xs" Text="Add Executing Agency" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' CommandName="Add" />
        </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField>
        <HeaderTemplate> Delete </HeaderTemplate>
        <ItemTemplate>
          <asp:HiddenField ID="hddnfinalsubmit" runat="server" Value='<%# Eval("FinalSubmit") %>' />
          <asp:Button ID="imgedit1" runat="server" ToolTip="Delete" CssClass="btn btn-danger btn-xs" Text="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>' CommandName="Delete" />
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
