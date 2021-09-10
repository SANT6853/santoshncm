<%@ Page Title="NTCA:View Village List" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Village_Management.aspx.cs" Inherits="auth_Adminpanel_DataEntry_Village_Management" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <style type="text/css">
	.Text-Center {
		text-align: center;
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

	a {
		color: #337ab7;
		text-decoration: none;
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

	#contentbody_gvforVillages tr th:nth-child(1) {
		width: 1%;
	}

	.table-2 td {
		border-top: none !important;
	}

	.control-label {
		text-align: left !important;
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
	div table.table-striped>tbody>tr:nth-of-type(odd) {
		background-color: #f4ffde;
	}
</style>
  <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>
  <script language="javascript" type="text/javascript">
        function IMG1_onclick() {

        }
        /****************************************************
            
        ****************************************************/
        var win = null;
        function NewWindow(mypage, myname, w, h, scroll, pos) {
            if (pos == "random") { LeftPosition = (screen.availWidth) ? Math.floor(Math.random() * (screen.availWidth - w)) : 50; TopPosition = (screen.availHeight) ? Math.floor(Math.random() * ((screen.availHeight - h) - 75)) : 50; }
            if (pos == "center") { LeftPosition = (screen.availWidth) ? (screen.availWidth - w) / 2 : 50; TopPosition = (screen.availHeight) ? (screen.availHeight - h) / 2 : 50; }
            if (pos == "default") { LeftPosition = 50; TopPosition = 50 }
            else if ((pos != "center" && pos != "random" && pos != "default") || pos == null) { LeftPosition = 0; TopPosition = 20 }
            settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=yes';
            win = window.open(mypage, myname, settings);
            if (win.focus) { win.focus(); }
        }
        function IMG1_onclick() {

        }
    </script>
  
  <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
    <div class="wrapper-content">
      <div class="inner-content-right">
        <div class="box box-primary1" style="margin-bottom: 25px;">
          <div class="stpdiv"> <span class="box-title stp1 stepArrow stepActive">Step-1</span> <span class="box-title stp1 stepArrow">Step-2</span> <span class="box-title stp1 stepArrow">Step-3</span> <span class="box-title stp1 stepArrow">Step-4</span> <span class="box-title stp1 stepArrow">Step-5</span> <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 5</span> </div>
          <div> </div>
          <div class="box-header with-border">
            <h3 class="box-title" style="color: #005529;">Add New Village Details
              <asp:Label ID="lblvillagename" Visible="false" runat="server" Text=""></asp:Label>
            </h3>
			<div class="pull-right">
              <asp:Button ID="btnassociatevillage" Visible="false" CssClass="btn btn-primary btn-add" runat="server" Text="Associate NGO" OnClick="btnassociatevillage_Click" />
              <asp:Button ID="Button1" Visible="false" runat="server" Text="Display Legal Form" CssClass="btn btn-primary btn-add" OnClick="Button1_Click" />
              &nbsp;
              <asp:Button ID="ImgbtnAddNew" runat="server" Text="Add New Village" OnClick="ImgbtnAddNew_Click1" CssClass="btn btn-primary btn-add" />
              <asp:Button ID="lnkrelatedlinks" runat="server" Text="Related images" CssClass="btn btn-primary btn-add" OnClick="lnkrelatedlinks_Click" />
            </div>
          </div>
        </div>
        <div class="form-horizontal">
          <div class="">
            
          </div>
          <%if (Session["UserType"].ToString().Equals("1"))
                              {%>
          <div class="col-md-3">
            <div class="form-group">
              <label class="col-sm-4 control-label"><span class="black-text" align="center">State name
                <asp:Label ID="StartStateName" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>
                :</span></label>
              <div class="col-sm-8">
                <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
              </div>
            </div>
          </div>
          <%} %>
          <div class="col-md-4">
            <div class="form-group">
              <label class="col-sm-4 control-label" id="td" runat="server" visible="false" style="font-size: 15px; vertical-align: middle;"> <span class="black-text" align="center">Select Tiger Reserve
                <asp:Label ID="StarTreserve" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>
                :</span> </label>
              <div class="col-sm-8">
                <div id="td1" runat="server" visible="false">
                  <asp:DropDownList ID="ddlselectreserve" runat="server" Visible="false" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList>
                </div>
                <div width="60%" id="td007" runat="server" visible="false"></div>
                <div id="td008" runat="server" visible="false"></div>
              </div>
            </div>
          </div>
          <div class="col-md-4" style="display: none;">
            <div class="form-group">
              <label class="col-sm-3 control-label" > Village Code
                <asp:Label ID="StartVcode" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>
              </label>
              <div class="col-sm-9" style="display: none;">
                <asp:DropDownList ID="ddlselectcode" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectcode_SelectedIndexChanged"> </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-4" >
              <div class="form-group">
					<label class="col-sm-5 control-label">Village Name
                  <asp:Label ID="StarVname" runat="server" ForeColor="Red" Font-Bold="true" Visible="false" Text="*"></asp:Label>
                  :</label>
					<div class="col-sm-7" runat="server" id="divVillage">
					  <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged"> </asp:DropDownList>
					</div>
					<div class="col-sm-7" runat="server" id="div1" visible="false">
					  <asp:DropDownList ID="ddlVillage" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged"> </asp:DropDownList>
					</div>
              </div>
            
          </div>
		  <div class="col-md-3">
              <div class="form-group">
                <div class="col-sm-12">
                  <asp:Button ID="ImageButton1" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="ImageButton1_Click1" />
                  <br />
                  <asp:Label ID="lblMsg" runat="server" CssClass="red-text" visible="false"></asp:Label>
                </div>
              </div>
            </div>
		  <div class="clearfix"></div>
          <div class="table-responsive">
               <table class="" width="100%" border="0" align="center" cellpadding="3" cellspacing="1">
            <tr>
              <td colspan="3">&nbsp;
                <asp:Button ID="imgbtnviewall" Visible="false" runat="server" Text="View All" CssClass="btn btn-primary btn-add" OnClick="imgbtnviewall_Click" />
                <asp:Button ID="btnviewcurrent" Visible="false" runat="server" Text="View Current" CssClass="btn btn-primary btn-add" OnClick="btnviewcurrent_Click" /></td>
            <tr>
              <td colspan="3" align="center"><asp:GridView ID="gvforVillages" runat="server" AllowPaging="True" DataKeyNames="VILL_ID" OnPageIndexChanging="gvforVillages_PageIndexChanging" OnRowDataBound="gvforVillages_RowDataBound" OnRowDeleting="gvforVillages_RowDeleting" OnRowEditing="gvforVillages_RowEditing" OnRowCommand="gvforVillages_RowCommand" AutoGenerateColumns="False" CellPadding="4" Width="100%" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                  <FooterStyle BackColor="#CCCC99" />
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" />
                  <RowStyle CssClass="drow" />
                  <AlternatingRowStyle CssClass="alt" />
                  <PagerStyle CssClass="pgr" HorizontalAlign="Right" />
                  <Columns>
                  <asp:TemplateField HeaderText="S. No." HeaderStyle-CssClass="Text-Center">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="lblSno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                      <asp:HiddenField ID="hyd" runat="server" Value='<%#Eval("CmnStateID") %>' />
                      </strong> </ItemTemplate>
                    <HeaderStyle CssClass="Text-Center"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="State Name">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="Label1" runat="server" Text='<%#Eval("StateName") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="TigerReserveName" HeaderText="Tiger Reserve" />
                  <asp:TemplateField HeaderText="Village Name" HeaderStyle-CssClass="Text-Center">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <a href="javascript:void();" onclick="MM_openBrWindow('Village_Management_View.aspx?<%= WebConstant.QueryStringEnum.VillageID  %>=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>','main','scrollbars=yes,width=700,height=900')" style="color: blue; text-decoration: underline;"> <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%> </a> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Family" HeaderStyle-CssClass="Text-Center">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:LinkButton ID="linkFamily" runat="server" OnClick="linkFamily_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'><%#Eval("VillageCount") %></asp:LinkButton>
                      </a> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate> Forms: (pre/survey/legal/consent) </HeaderTemplate>
                    <ItemTemplate>
                      <asp:LinkButton ID="btnServey" runat="server" Text="View" OnClick="btnServey_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate> NGO (If Any) </HeaderTemplate>
                    <ItemTemplate>
                      <asp:LinkButton ID="btnNGO" runat="server" OnClick="btnNGO_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'><%# string.Format("{0}",Eval("NGOCount").ToString()=="0"?"0 ":Eval("NGOCount").ToString()) %></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate> Funds Required  <i class="fa fa-inr" style="font-size:20px;" aria-hidden="true"></i> </HeaderTemplate>
                    <ItemTemplate>
                      <asp:LinkButton ID="btnFund" runat="server" OnClick="btnFund_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"VILL_ID")%>'><%# Eval("FundAmount") %></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Village Edit" HeaderStyle-CssClass="Text-Center">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                      <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="Edit"
                                                                Visible="true" ImageUrl="~/auth/adminpanel/images/arrow.png" />
                      <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate> Status at CWLW</HeaderTemplate>
                    <ItemTemplate>
                      <asp:HiddenField ID="hddnAction" runat="server" Value='<%# Eval("statusNew") %>' />
                      <asp:Label ID="lblAction" runat="server" Text='<%# Eval("final") %>'></asp:Label>
                      <asp:LinkButton ID="stateApprove" CssClass="btn btn-primary" Text="Approve" runat="server" CommandName="StateApprove" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>'></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <HeaderTemplate> Status at NTCA</HeaderTemplate>
                    <ItemTemplate>
                      <asp:HiddenField ID="hddnActionNTCA" runat="server" Value='<%# Eval("NtcaFinal") %>' />
                      <asp:Label ID="lblActionNTCA" runat="server" Text=""></asp:Label>
                      <asp:LinkButton ID="stateApproveNTCA" CssClass="btn btn-primary" Text="Approve" runat="server" CommandName="StateApproveNTCA" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID")+","+DataBinder.Eval(Container.DataItem, "statusNew") %>'></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
				  <asp:TemplateField>
                    <HeaderTemplate>Status for request to modify(Modify/Edit)</HeaderTemplate>
                    <ItemTemplate>
                      <asp:HiddenField ID="RemarksIdvill" runat="server" Value='<%# Eval("VILL_ID") %>' />                     
                       <a href="javascript:void(0)" id="linkremarks" class="btn nt"><%# Eval("queryStatus") %></a>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="View Map">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:ImageButton ID="viewmap" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="Map"
                                                                Visible="true" ImageUrl="~/auth/Adminpanel/REPORT/Gmap.ico" Width="40px" />
                      <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
                  <PagerSettings Mode="Numeric" />
                  <PagerStyle CssClass="GridPager pagination" Font-Bold="True" ForeColor="black"
                                                    HorizontalAlign="right" />
                  <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                  <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#FBFBF2" />
                  <SortedAscendingHeaderStyle BackColor="#848384" />
                  <SortedDescendingCellStyle BackColor="#EAEAD3" />
                  <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView></td>
            </tr>
            <tr>
              <td colspan="3"></td>
            </tr>
            <tr>
              <td colspan="3"></td>
            </tr>
            <tr>
              <td colspan="3" align="center" style="display:none;"><asp:GridView ID="grvngo" AutoGenerateColumns="False" runat="server"
                                            CellPadding="4" Width="100%"
                                            RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped"
                                            AllowPaging="True" OnPageIndexChanging="grvngo_PageIndexChanging" OnRowCommand="grvngo_RowCommand"
                                            OnRowDeleting="grvngo_RowDeleting" EmptyDataText="No NGO Found" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal">
                  <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#333333" Font-Bold="True" ForeColor="White" />
                  <RowStyle CssClass="drow" />
                  <AlternatingRowStyle CssClass="alt" />
                  <PagerStyle CssClass="pgr" BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle Wrap="True"></RowStyle>
                  <Columns>
                  <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%#Eval("s_no") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Village" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="Label11" runat="server" Text='<%#Eval("vill_nm") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="NGO" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="Label14" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Amounts</br>(In Rs.)" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="Label4" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Work Done For Village" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:Label ID="Label5" runat="server" Text='<%#Eval("work_done_for_village") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate> <a id="hyedit" href="../NGO/editassciatevillage.aspx?id=<%#Eval("id") %> "> <img id="editimg" src="../images/arrow.png" alt="Edit" title="Edit" width="20"
                                                                height="10" border="0" /> </a> </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:ImageButton ID="NgodetailDelete" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CommandName="Delete"
                                                            Visible="true" ImageUrl="~/auth/adminpanel/images/wrong.png" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  </Columns>
                  <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black"
                                                HorizontalAlign="right" />
                  <HeaderStyle Wrap="True"></HeaderStyle>
                  <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#F7F7F7" />
                  <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                  <SortedDescendingCellStyle BackColor="#E5E5E5" />
                  <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView></td>
            </tr>
            <div style="clear: both"></div>
          </table>
          <div class="col-md-12" style="display: none">
            <table class="table table-bordered table-stripped">
              <thead>
                <tr>
                  <th>S.No</th>
                  <th>Tiger Reserve</th>
                  <th>Village</th>
                  <th>Family</th>
                  <th>Forms- pre-survey,legal,consent Form</th>
                  <th>NGO</th>
                  <th>Funds Required <i class="fa fa-inr" aria-hidden="true"></i></th>
                  <th>Status-Submitted,pending</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>1</td>
                  <td>name of TR</td>
                  <td><a href="">Basana</a></td>
                  <td><a href="">20</a></td>
                  <td><a href="" class="btn btn-primary btn-xs">View </a></td>
                  <td><a href="">4</a></td>
                  <td>5,45,909</td>
                  <td><a href="" class="btn btn-success btn-xs">Submitted</a></td>
                </tr>
                <tr>
                  <td>2</td>
                  <td>assds</td>
                  <td><a href="">Bhandar</a></td>
                  <td><a href="">14</a></td>
                  <td><a href="" class="btn btn-primary btn-xs">View </a></td>
                  <td></td>
                  <td></td>
                  <td><a href="" class="btn btn-danger btn-xs">Pending</a></td>
                </tr>
              </tbody>
            </table>
          </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div id="MyModelforQuery" class="modal fade" role="dialog">
                <div class="modal-dialog modal-lg">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                &times;</button>
                            <h4 class="modal-title" style="color: green;" id="headerName">Send remarks</h4>
                        </div>
                        <div class="modal-body" id="Divmsgforquery"> 
                            <div class="form-group">
                                <asp:HiddenField ID="RemarksvillageId" runat="server" />
                                <asp:HiddenField ID="ReplyForRemarksId" runat="server" />
                                <asp:TextBox ID="txtforwardforQuery" TextMode="MultiLine" CssClass="form-control"
                                    runat="server" />
                                <span class="error">
                                    <asp:RequiredFieldValidator ID="reqq" runat="server" ControlToValidate="txtforwardforQuery"
                                        ErrorMessage="*" ValidationGroup="ddd" /></span>
                                <div>
                                    <asp:Button ID="btnforwardquerytoforce" ValidationGroup="ddd" CssClass="btn btn-primary" 
                                Text="Send" runat="server" OnClick="btnforwardquerytoforce_Click"   />
                                     <asp:Button ID="Button3" ValidationGroup="ddd" CssClass="btn btn-primary" 
                                Text="Reply" runat="server"  OnClick="Button3_Click"   />
                                </div>
                                
                            </div>


                            <div class="form-group">
                                <table class="table">
                                    <thead>
                                       <tr>
                                           <th>S.No.</th>
                                           <th>Remarks By</th>
                                           <th>Remarks</th>
                                           <th>Remark Date</th>
                                           <th>Reply By</th>
                                           <th>Reply </th>
                                       </tr>
                                    </thead>
                                    <tbody id="remarksBody">
                                        
                                    </tbody>
                                </table>
                                
                                </div>
                                
                           
                        </div>
                        <div class="modal-footer">
                            
                        </div>
                    </div>
                </div>
            </div>




    <div id="MyModelforPoup" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">                         
                            
                        </div>
                        <div class="modal-body" > 
                            <div class="form-group">
                               <h4 class="modal-title" style="color: green;" id="headerconfirmation"></h4>
                                <div>
                                    <asp:Button ID="Button2" ValidationGroup="ddd" CssClass="btn btn-primary" 
                                Text="Ok" runat="server"   />
                                </div>
                                
                            </div>                          
                                
                           
                        </div>
                        <div class="modal-footer">
                            
                        </div>
                    </div>
                </div>
            </div>
    <script>
        $(document).ready(function () {
            var checktypebutton = '<%=Session["UserType"].ToString()%>'
            if (checktypebutton == "4")
            {
                $('[id*=btnforwardquerytoforce]').hide();
            }
            $('[id*=Button3]').hide();
            $('[id*=linkremarks]').click(function () {            
                $('[id*=MyModelforQuery]').modal({ backdrop: 'static', keyboard: false });
                $('#headerName').html("Send Request to Modify/Edit details.");
                var villid = $(this).closest('td').find('[id*=RemarksIdvill]').val();              
                $('[id*=RemarksvillageId]').val(villid)
                debugger;
                $.ajax({
                    type: "POST",
                    url: "Village_Management.aspx/Bindgridview",
                    async: true,
                    data: '{villageId: "' + villid + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (res) {
                        var result = JSON.parse(res.d);
                        $('#remarksBody').html('');
                       
                        $.each(result.Table, function (a, b) {
                            var bindpending = "";
                            if (result.Table[a].Replystatus=="1")
                            {
                                bindpending = result.Table[a].Reply;
                            }
                            else
                            {
                                if (result.Table[a].RemarksSender == '<%=Session["UserType"].ToString()%>')
                                {
                                    bindpending = "<span style='color: red;'>Pending</span>"
                                }
                                else
                                {
                                    if (result.Table[a].RemarksReciever == '<%=Session["UserType"].ToString()%>')
                                    {
                                        bindpending = "<a href='javascript:void(0)' class='btn btn-success' id='btnPending' remarksid='" + result.Table[a].RemarksId + "'>Pending</a>"

                                    }
                                    else
                                    {
                                        bindpending = "<span style='color: red;'>Pending</span>"
                                    }
                                    
                                }
                                
                            }
                            $('#remarksBody').append("<tr><td>" + (a + 1) + "</td><td>" + result.Table[a].sendername + "</td><td>" + result.Table[a].Remarks + "</td><td>" + result.Table[a].RemarkDate + "</td><td>" + result.Table[a].replyName + "</td><td>" + bindpending + "</td></tr>");
                           
                        });
                       
                    }



                });
            });

            $('#remarksBody').on('click', '[id*=btnPending]', function () {
                $('#remarksBody').find('[id *= btnPending]').each(function () {                   
                        $(this).closest('tr').attr('style', '');
                });   
                $(this).closest('tr').css('background', 'blue');
                $('[id*=ReplyForRemarksId]').val($(this).attr('remarksid'));
                $('#headerName').html("Reply");
                $('[id*=Button3]').show();
                $('[id*=btnforwardquerytoforce]').attr('style', 'display:none');

            });

        });

        function showpoupconfirmation(a) {           
            $('[id*=MyModelforPoup]').modal({ backdrop: 'static', keyboard: false });
            $('#headerconfirmation').html(a);
        }

        $('.close').click(function () {
            window.location.replace('<%=Request.Url.AbsoluteUri%>');
            });
    </script>
</asp:Content>
