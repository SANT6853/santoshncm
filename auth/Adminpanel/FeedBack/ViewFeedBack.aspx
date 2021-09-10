<%@ Page Title="View:FeedBack" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewFeedBack.aspx.cs" Inherits="auth_Adminpanel_FeedBack_ViewFeedBack" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style type="text/css">
.Text-Center {
	text-align:center;
}
.Background {
	background-color: Black;
	filter: alpha(opacity=90);
	opacity: 0.8;
}
.Popup {
	background-color: #FFFFFF;
	border-width: 3px;
	border-style: solid;
	border-color: black;
	padding-top: 10px;
	padding-left: 10px;
	width: 700px;
}
.lbl {
	font-size: 16px;
	font-style: italic;
	font-weight: bold;
}
.ty23 {
	overflow: scroll;
}
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
	background-color: #005529 !important;
	color: #fff;
	border: 1px solid #005529;
}
.pagination td {
	border: none !important;
	padding: 1px;
}
</style>
  <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
  <%--<script src="../../../js/bootstrap.min.js"></script>--%>
  <script src="../../../js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <script type="text/javascript">
        $(function () {
            $("[id*=lnkViewDetailss]").click(function (event) {
                debugger;
                var feedbackid = $(this).attr("data-id");
                // alert(villageid);
                var pagrUrl = "FeedbackDetails.aspx?vid=" + feedbackid;
                $('#demoModal').modal('show').find('.modal-body').load(pagrUrl);

                return false;
            });

        });

    </script>
  <style>
        .modal-dialog {
            width: 70% !important;
        }
    </style>
  
  <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
    <div class="wrapper-content">
      <div class="inner-content-right">
        <div class="box box-primary1" style="margin-bottom: 25px;">
          <div class="box-header with-border">
            <h3 class="box-title" style="color: #005529;">View feedback List</h3>
          </div>
        </div>
        <!--<div class="ibox-title">
                    <h5>View feedback List</h5>
                </div>-->
        <%--start modal popup--%>
        <div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="myModalLabel">Feedback Details</h4>
              </div>
              <div class="modal-body ty23"> </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
              </div>
            </div>
          </div>
        </div>
        <%--end modal popup--%>
        <div class="form-horizontal">
          <div class="col-md-6" id="divTpe" runat="server">
            <div class="form-group">
              <label class="col-sm-4 control-label"> Select feedback page</label>
              <div class="col-md-8">
                <asp:DropDownList ID="DdlType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlType_SelectedIndexChanged">
                  <asp:ListItem Text="-select any one-" Value="0"></asp:ListItem>
                  <asp:ListItem Text="NTCA feedback" Value="9"></asp:ListItem>
                  <asp:ListItem Text="TIGER RESERVE feedback" Value="11"></asp:ListItem>
                </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-6" id="Ntcasub" runat="server" visible="false">
            <div class="form-group">
              <label class="col-sm-4 control-label"> Select feedback from</label>
              <div class="col-md-8">
                <asp:DropDownList ID="DdlNtcaSub" runat="server" CssClass="form-control">
                  <asp:ListItem Text="-select any one-" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Tiger Reserve" Value="1"></asp:ListItem>
                  <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-6" id="Reservesub" runat="server" visible="false">
            <div class="form-group">
              <label class="col-sm-4 control-label"> Select feedback from</label>
              <div class="col-md-8">
                <asp:DropDownList ID="DdlTigerreserSub" runat="server" CssClass="form-control">
                  <asp:ListItem Text="-select any one-" Value="0"></asp:ListItem>
                  <asp:ListItem Text="Ntca" Value="1"></asp:ListItem>
                  <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-12">
          <div class="col-md-12">
          <div class="form-group">
            <asp:Button ID="BtnSearech" runat="server" Text="Search" CssClass="btn btn-primary btn-add"
                                                                    ToolTip="Click To Search" OnClick="btnSearch_Click" />
          </div>
          </div>
          </div>
        </div>
        <div id="divGrid" runat="server" class="col-md-12 col-xs-12">
          <asp:GridView ID="grdFeedback" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        DataKeyNames="FeedBackFormID" GridLines="Vertical" Width="100%" CssClass="table table-bordered table-hover" OnPageIndexChanging="grdFeedback_PageIndexChanging" OnRowCommand="grdFeedback_RowCommand" OnRowDeleting="grdFeedback_RowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" OnRowDataBound="grdFeedback_RowDataBound">
            <AlternatingRowStyle CssClass="alt" BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <Columns>
            <asp:TemplateField HeaderText="Created date" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "CreateDate")%> </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate>
                <asp:LinkButton ID="lnkViewDetailss" runat="server" Text='<%# Eval("Name") %>' data-id='<%# Eval("FeedBackFormID") %>'></asp:LinkButton>
              </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "EmailID")%> </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "Phone")%> </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="State" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "StateName")%> </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Feedback from page" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "ModuleId")%> </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Feedback from" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "FeedBackFrom")%> </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status" Visible="false">
              <ItemTemplate>
                <asp:LinkButton ID="LnkActiveDeaActive" runat="server" Text='<%#Eval("ActiveStatus") %>' CommandName="AD" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FeedBackFormID") %>'></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate> <span style="color: #459300;">Record(s) Not Available.</span> </EmptyDataTemplate>
            <PagerStyle CssClass="GridPager pagination" BackColor="" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle CssClass="drow" Wrap="True" BackColor="" />
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
  <style type="text/css">
        body {
            background-color: #005529;
        }
    </style>
</asp:Content>
