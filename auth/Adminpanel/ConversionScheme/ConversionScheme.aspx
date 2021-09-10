<%@ Page Title="NTCA:View Convergence" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ConversionScheme.aspx.cs" Inherits="auth_Adminpanel_ConversionScheme_ConversionScheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type = "text/javascript">

        function RadioCheck(rb) {

            var gv = document.getElementById("<%=grdtiger.ClientID%>");

         var rbs = gv.getElementsByTagName("input");



         var row = rb.parentNode.parentNode;

         for (var i = 0; i < rbs.length; i++) {

             if (rbs[i].type == "radio") {

                 if (rbs[i].checked && rbs[i] != rb) {

                     rbs[i].checked = false;

                     break;

                 }

             }

         }

     }

</script>
    <style type="text/css">
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
		.control-label{text-align:left !important;}
        .GridPager span {
            background-color: #A1DCF2;
            color: #000;
            border: 1px solid #3AC0F2;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
    <div class="wrapper-content" style="padding-top:0px; min-height:550px;">
        <div class="row">
            <div class="col-lg-12 ">
                <div class="widgets-container">
					<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Convergence with others central/state Government Scheme</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                </div>
                   
                    <div class="form-horizontal">

                        <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Scheme Name:</label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="TxtSchemeName" CssClass="form-control" runat="server"></asp:TextBox><br/>
                                <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="BtnSearch_Click" />
                            </div>
                        </div>
                        </div>
                         <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Village name:</label>
                            <div class="col-sm-6">
                                 <asp:DropDownList ID="ddlselectname" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="Requirddlselectname" runat="server" ForeColor="Red" ValidationGroup="val" ControlToValidate="ddlselectname" InitialValue="0" ErrorMessage="Please select village name" />
                                    <div>
                                        <asp:Label ID="LblVillageName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                    </div>
                            </div>
                        </div>
                        </div>

                     
                        <div class="ibox-content collapse in">
                            <div class="widgets-container">
                                <div>
                                    <asp:Label ID="LblMsg" runat="server" ForeColor="Red" Font-Size="Larger" Font-Bold="true"></asp:Label>

                                    <asp:GridView ID="grdtiger" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" runat="server" AllowPaging="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="grdtiger_PageIndexChanging" OnRowDeleting="grdtiger_RowDeleting" OnRowCommand="grdtiger_RowCommand" OnRowDataBound="grdtiger_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Action">

                                                <ItemTemplate>

                                                    <asp:RadioButton ID="RadioButton1" runat="server" 
                                                        onclick="RadioCheck(this);" />

                                                    <asp:HiddenField ID="HiddenField1" runat="server"
                                                        Value='<%#Eval("ConversionID")%>' />

                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SNo" HeaderText="S.No" />
                                             <asp:BoundField DataField="VILL_NM" HeaderText="Village Name" />
                                            <asp:BoundField DataField="SchemeName" HeaderText="Scheme Name" />
                                            <asp:BoundField DataField="StateCentralType" HeaderText="State/Central" />
                                            <asp:BoundField DataField="BenfitExten" HeaderText="Benefits Extended" />
                                            <asp:BoundField DataField="AmountSpent" HeaderText="Amount Spent(Rupees)" />


                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <%--<a href='<%# ResolveUrl("~/auth/Adminpanel/ConversionScheme/AddConversionScheme.aspx?tid="+Eval("ConversionID")) %>'></a>--%>
                                                        <%--<asp:Image ID="imgedit" runat="server" ImageUrl="../images/edit.gif" ToolTip="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ConversionID") %>' />--%>
                                               <asp:ImageButton ID="Imgbtn" runat="server" ImageUrl="../images/edit.gif" ToolTip="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ConversionID") %>' />
                                                    
                                                     </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkActiveDeaActive" runat="server" Text='<%#Eval("Statuss") %>' CommandName="AD" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ConversionID") %>'></asp:LinkButton>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" CssClass="GridPager" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#F7F7DE" />
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
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

