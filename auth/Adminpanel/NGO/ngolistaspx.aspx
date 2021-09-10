<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ngolistaspx.aspx.cs" Inherits="auth_Adminpanel_NGO_ngolistaspx" %>
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
.full_width{
	width:100%;
	float:left;
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
                       url: "ngolistaspx.aspx/BindModelGridView",
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
                                   bodyhtml = bodyhtml + "<tr><td>" + (i + 1) + "</td><td>" + valuebody[i].NGO_NAME + "</td><td>" + valuebody[i].NGO_Work + "</td><td>" + valuebody[i].Address + "</td><td>" + valuebody[i].Mobile + "</td><td>" + valuebody[i].Remarks + "</td><td>" + valuebody[i].Rgistration + "</td><td>" + "<a target='_blank' href='" +<%=ResolveUrl("~")%> +"/WriteReadData/NGOAttachments/" + valuebody[i].Files + "' id='filename' >" + valuebody[i].Files + " </a>" + "</td></tr>"
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
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true" id="btnClose">&times;</button>
          <h4 class="modal-title" id="myModalLabel">NGO details </h4>
        </div>
        <div class="modal-body">
          <div>
            <div>
              <table class="table tblProducts">
                <thead>
                  <tr class="headings">
                    <th>Sl.no </th>
                    <th>NGO Name </th>
                    <th>Work Done </th>
                    <th>Address </th>
                    <th>Mobile </th>
                    <th>Remarks </th>
                    <th>Registration No </th>
                    <th>File Link </th>
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
  <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
  <div class="wrapper-content" style="padding-top: 0px; padding-bottom: 0; min-height: 550px;">
  <div class="row">
  <div class="col-lg-12">
    <div class="widgets-container">
      <div class="box box-primary1 full_width" style="margin-bottom: 1px;">
        <div class="full_width padding15 stpdiv">
		<span class="box-title stp1 stepArrow">Step-1</span>
		<span class="box-title stp1 stepArrow ">Step-2</span>
		<span class="box-title stp1 stepArrow ">Step-3</span>
		<span class="box-title stp1 stepArrow stepActive">Step-4</span>
		<span class="box-title stp1 stepArrow">Step-5</span>
								<span class="box-title stp pull-right" style="color: #005529;">Total Steps - 5</span> </div>
         <div><h2 class="box-title" style="color: #005529;margin-left:30%">Add NGO (if any) For Pre Monitoring </h2></div>
      </div>
      <span id="contentbody_lblmsg"></span>
      <div class="form-horizontal full_width" style="margin-top:15px;">
        <div class="col-md-5">
          <label id="contentbody_lblserch" class="col-sm-3 pt6">Search NGO:</label>
          <div class="col-sm-9">
            <asp:DropDownList ID="ddlNGO" runat="server" CssClass="form-control"></asp:DropDownList>
          </div>
        </div>
        <div class="col-sm-1">
          <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSave_Click" />
        </div>
        <div class="col-md-1 pull-right text-right" runat="server" id="divNGO" visible="false">
          <asp:Button ID="btnAddNGO" runat="server" Text="Add NGO (if any)" CssClass="btn btn-primary" OnClick="btnAddNGO_Click"  />
        </div>
      </div>
      <div class="col-md-12">
        <div class="row">
          <asp:Button ID="btnSkip" runat="server" CssClass="btn btn-primary" Text="Skip" OnClick="btnSkip_Click" />
          <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary" Text="Next" OnClick="btnNext_Click" />
        </div>
      </div>
    </div>
    </div>
  </div>
  <div class="col-md-12">
    <div class="padding10 table-responsive">
      <asp:GridView ID="GvAdd_NGODetails" runat="server" DataKeyNames="NGO_ID" AutoGenerateColumns="false"
            OnRowCommand="GvAdd_NGODetails_RowCommand" OnRowDataBound="GvAdd_NGODetails_RowDataBound" Width="100%" PageSize="50" AllowPaging="true" OnPageIndexChanging="GvAdd_NGODetails_PageIndexChanging" OnRowDeleting="GvAdd_NGODetails_RowDeleting"
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
          <HeaderTemplate> Name </HeaderTemplate>
          <ItemTemplate> <a href="javascript:void(0);" id="btnShow" ConversionID='<%# Eval("NGO_ID") %>'><%# DataBinder.Eval(Container.DataItem, "NGO_NAME")%> </a> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="NGO_Work" HeaderText="Email Id" />
        <asp:BoundField DataField="Address" HeaderText="Address" />
        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
        <asp:BoundField DataField="Rgistration" HeaderText="Registration No" />
        <asp:TemplateField HeaderText="File Link" SortExpression="Attachment" HeaderStyle-CssClass="Text-Center"
                    ItemStyle-CssClass="Text-Center">
          <ItemTemplate> <a href="<%=ResolveUrl("~/WriteReadData/NGOAttachments/")%><%# Eval("Files")%>" target="_blank"><%# Eval("Files")%></a> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
          <HeaderTemplate> Add NGO (if any)</HeaderTemplate>
          <ItemTemplate>
            <asp:HiddenField ID="hddnNGOID" runat="server" Value='<%# Eval("NGO_ID") %>' />
            <asp:Button ID="btnaddNGO" runat="server" ToolTip="Delete" CssClass="btn btn-primary btn-xs" Text="Add Ngo " CommandArgument='<%#DataBinder.Eval(Container.DataItem,"NGO_ID")%>' CommandName="Add" />
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
          <HeaderTemplate> Delete NGO (if any) </HeaderTemplate>
          <ItemTemplate>
            <asp:HiddenField ID="hddnfinalsubmit" runat="server" Value='<%# Eval("FinalSubmit") %>' />
            <asp:Button ID="imgedit1" runat="server" ToolTip="Delete" CssClass="btn btn-danger btn-xs" Text="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"NGO_ID")%>' CommandName="Delete" />
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
        <EmptyDataTemplate>No records filled by Depty Director/DFO.</EmptyDataTemplate>
      </asp:GridView>
    </div>
  </div>
  </div>
  </div>
</asp:Content>
