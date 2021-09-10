<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Tiger_Ngo.aspx.cs" Inherits="auth_Adminpanel_NGO_Tiger_Ngo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .red-text-1a
        {
            color:red;
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
		.btn-add{
			margin-bottom:0px;
		}
		.control-label {
            text-align: left !important;
        }
		.mr3{margin-right:3px;}
		.stp{
			color: #000000;
			text-align: left;
			font-weight: bold;
			background: #f7b000;
			padding: 5px;
			}
			.stp1{
			color: #fff;
			text-align: left;
			font-weight: bold;
			background: #005529;
			padding: 5px;
			}
		.stpdiv{
			padding:0 0 30px 0;
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
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
			<div class="row">
                <div class="col-lg-12">
				<div class="widgets-container">
						<div class="box box-primary1" style="margin-bottom: 25px;">
							<div class="stpdiv">
								<span class="box-title stp1" >Step-4</span>
								<span class="box-title stp" style="color: #005529; float:right;">Total Steps - 5</span>
							</div>
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">NGO Management</h3>
                            </div>
                        </div>						
						<asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
						<div class="form-horizontal">
							<div class="col-md-6">
                                <div class="form-group">
                                    <label id="contentbody_td" class="col-sm-3 control-label" style="font-size: 15px; vertical-align: middle;">
                                        <asp:Label ID="lblserch" runat="server" Text="Search NGO"></asp:Label>
                                    </label>
                                    <div class="col-sm-6">
										<asp:DropDownList ID="ddlserchngo" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlserchngo_SelectedIndexChanged">
								</asp:DropDownList>
								</div>
                                </div>
                            </div>
							<div class="col-md-6 ">
								<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/NGO/Associate_Village1.aspx" class="btn btn-primary btn-add pull-right " style="display:none;">Associated NGO</a>&nbsp;&nbsp;
								<asp:Button ID="btnngo" runat="server" Text="Add NGO" OnClick="btnngo_Click" CssClass="btn btn-primary btn-add mr3 pull-right" />
								</div>
						</div>
            <table width="99%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="3">
                        <asp:Panel ID="Panelngo" runat="server" CssClass="modalPopup" Style="display: none; width: 450px; position: fixed; z-index: 100001; left: 493px; top: -93px;">
                            <table width="410" class="table-3" border="0" align="center" cellpadding="3" cellspacing="1" visible="false">
                                <tr>
                                    <td colspan="3" style="border-bottom: 3px solid #005529;">
                                        <h3 style="color: #005529;">Please Enter NGO Details</h3>
                                    </td>

                                </tr>
								<tr>
                    <td colspan="2" align="center" style="padding-bottom:15px;"></td>

                </tr>


                                <tr>
                                    <td class="black-text" align="right" width="200">Name of NGO
            <span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center" width="10">:</td>
                                    <td width="200">
                                        <asp:TextBox ID="txtngoname" runat="server" CssClass="textfield" MaxLength="50"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtngoname" ForeColor="Red"
                                            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter NGO Name" SetFocusOnError="True"
                                            ValidationGroup="ADDMember"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="txtngoname" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                               </td>
                                         </tr>
                                <tr>
                                    <td class="black-text" align="right" width="200">Address of NGO
            <span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center" width="10">:</td>
                                    <td width="200">
                                        <asp:TextBox ID="txtaddress" runat="server" CssClass="textfield" MaxLength="50"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" runat="server" ControlToValidate="txtaddress"
                                            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter NGO Address" SetFocusOnError="True"
                                            ValidationGroup="ADDMember"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="txtaddress" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                               </td>
                                         </tr>
                                <tr>
                                    <td align="right" class="black-text">Phone No of NGO.<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center" width="2%">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtphoneno" runat="server" CssClass="textfield" MaxLength="11"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" runat="server" ControlToValidate="txtphoneno"
                                            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Phone No" SetFocusOnError="True"
                                            ValidationGroup="ADDMember"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" CssClass="red-text-asterix" ControlToValidate="txtphoneno"
                                            Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True" ValidationExpression="[0-9]+"
                                            ValidationGroup="ADDMember">Please Enter Only Number</asp:RegularExpressionValidator>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="black-text">Mobile No of NGO.<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center" width="2%">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtmobno" runat="server" CssClass="textfield" MaxLength="11"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ControlToValidate="txtmobno"
                                            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Mobile No" SetFocusOnError="True"
                                            ValidationGroup="ADDMember"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" runat="server" CssClass="red-text-asterix" ControlToValidate="txtmobno"
                                            Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True" ValidationExpression="[0-9]+"
                                            ValidationGroup="ADDMember">Please Enter Only Number</asp:RegularExpressionValidator>

                                    </td>
                                </tr>
                                <%-- <tr>
    <td  align="right" class="black-text" >Amount Given By NGO(Rs.)<span class="red-text-1a">*</span></td>
      <td class="black-text" align="center" width="2%">
            :</td>
    <td align="left" ><asp:TextBox ID="txtamaunt" runat="server" CssClass ="textfield" MaxLength="15"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtamaunt"
            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Amount" SetFocusOnError="True"
            ValidationGroup="ADDMember"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix" ControlToValidate="txtamaunt"
            Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="ADDMember" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
                   
            </td>
  </tr>--%>
                                <tr>
                                    <td align="right" class="black-text">Work Done By NGO<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center" width="2%">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtworkdone" TextMode="MultiLine" Height="50" runat="server"
                                            CssClass="textfield"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" runat="server" ControlToValidate="txtworkdone"
                                            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Work" SetFocusOnError="True"
                                            ValidationGroup="ADDMember"></asp:RequiredFieldValidator>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtworkdone" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="black-text">Remarks<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center" width="2%">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtremarks" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox><br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtremarks" ForeColor="Red"
                                            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Remarks" SetFocusOnError="True"
                                            ValidationGroup="ADDMember"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtremarks" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="black-text">Related Attachment<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center" width="2%">:</td>
                                    <td align="left">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:HyperLink ID="hylinkattechmen" Visible="false" Target="_blank" runat="server">Attachment</asp:HyperLink>
                                    </td>
                                </tr>
								<tr>
									<td colspan="2" align="center" style="padding-bottom:10px;"></td>

								</tr>
                                <tr>
									<td></td>
									<td class="black-text" align="center" width="2%"></td>
                                    <td align="center" >
                                        <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="btn btn-primary btn-add"
                                            ValidationGroup="ADDMember" OnClick="btnupdate_Click" Visible="False" />
                                        <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="btn btn-primary btn-add"
                                            OnClick="btnreset_Click" Visible="False" />
                                        <asp:Button ID="imgbtnsave" runat="server" Text="Submit" CssClass="btn btn-primary btn-add"
                                            ValidationGroup="ADDMember" OnClick="imgbtnsave_Click" Visible="False" />
                                        <asp:Button ID="imgbtnreset" runat="server" Text="Reset"
                                            CausesValidation="false" CssClass="btn btn-primary btn-add" OnClick="imgbtnreset_Click"
                                            Visible="False" />
                                        <asp:Button ID="imgbtncancle" runat="server" Text="Cancel"
                                            CausesValidation="false" CssClass="btn btn-primary btn-add" OnClick="imgbtncancle_Click" /></td>
                                </tr>

                            </table>
                        </asp:Panel>


                    </td>
                </tr>




            </table>
            <table width="99%" border="0" cellspacing="0" cellpadding="0">

                <tr>
                    <td colspan="3" align="center">&nbsp; </td>
                </tr>

                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="gvforngo" runat="server" AllowPaging="True" DataKeyNames="id"
                            OnPageIndexChanging="gvforngo_PageIndexChanging"
                            OnRowCommand="gvforngo_RowCommand" AutoGenerateColumns="False"
                            CellPadding="4" RowStyle-Wrap="true"
                            HeaderStyle-Wrap="true" CssClass=" table table-bordered table-striped" Width="100%"
                            OnRowEditing="gvforngo_RowEditing" OnRowDeleting="gvforngo_RowDeleting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered table-striped" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <RowStyle CssClass="" />
                            <AlternatingRowStyle CssClass="alt" BackColor="White" />
                            <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
                            <Columns>
                                <asp:TemplateField HeaderText="S. No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblSno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name of NGO">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile No of NGO ">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>

                                            <%#DataBinder.Eval(Container.DataItem, "mobile_no")%>
                     
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address of NGO ">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="address" runat="server" Text='<%#Eval("address") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Work done by NGO ">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblwork" runat="server" Text='<%#Eval("work_done") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>

                                        <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CommandName="Edit"
                                            ImageUrl="~/AUTH/adminpanel/images/arrow.png" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <strong>Delete
                                        </strong>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete?');"
                                            CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                            runat="server" ImageUrl="~/AUTH/adminpanel/images/wrong.png" Visible="true" />
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
                        </asp:GridView>
                    </td>
                </tr>
            </table>
			<hr/>
			<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/funds-required.aspx" class="btn btn-primary">Skip</a>
			<a href="" class="btn btn-primary">Save</a>
			<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/funds-required.aspx" class="btn btn-primary">Next</a>
            <div>
            <div>
            <div>
            <div>
                <cc1:ModalPopupExtender ID="ModalPopupaddngo" runat="server"
                    TargetControlID="HiddenField1"
                    PopupControlID="Panelngo"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:HiddenField ID="HiddenField1" runat="server" />

                <%--  <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
            </div>
        </div>
    </div>
</asp:Content>

