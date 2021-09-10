<%@ Page Title="NTCA:Convergence" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddConversionScheme.aspx.cs" Inherits="auth_Adminpanel_ConversionScheme_AddConversionScheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            height: 17px;
        }

        .auto-style2 {
            height: 17px;
        }
		.control-label{text-align:left !important;}

        table {
            border-spacing: 10px;
            border-collapse: separate;
        }

        .lblColor {
            color: red;
        }
		.form-group {
    margin-bottom: 0;
}
		.form-control{width: 70%;}
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
     <script type="text/javascript" language="javascript">

       
         $(document).ready(function ()
         {
             $('#<%= TxtSNo.ClientID %>').attr('readonly', true);
         });
       </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
    <div class="wrapper-content" style="padding-top:0px; min-height:550px;">
        <div class="row">
            <div class="col-lg-12 ">
                <div class="widgets-container">
					<div class="box box-primary1" style="margin-bottom: 25px;">
						<div class="stpdiv">
								<span class="box-title stp1" style="">Step-3</span>
								<span class="box-title stp" style="color: #005529; float:right;">Total Steps - 4</span>
							</div>
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;"><%=HeaderTitle %> </h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                </div>
                    
                    <div class="form-horizontal">


                        <div class="col-md-6" >
                            <div class="form-group">
                                <label class="col-sm-3 control-label">S.No:<label class="lblColor"></label></label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="TxtSNo" CssClass="form-control"  autocomplete="off" runat="server" ></asp:TextBox>
                                   <%-- <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="TxtSNo" ValidationGroup="val"
                                        ErrorMessage="Enter TxtSNo" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="TxtSNo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                    <div>
                                        <asp:Label ID="LblTxtSNo" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Scheme Name:<label class="lblColor">*</label></label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="TxtSchemeName" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="TxtSchemeName" ValidationGroup="val"
                                        ErrorMessage="Enter Scheme name" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="TxtSchemeName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                                    <div>
                                        <asp:Label ID="LblTxtSchemeName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Village name:<label class="lblColor">*</label></label>
                                <div class="col-sm-9">
                                    
                                     <asp:DropDownList ID="ddlselectname" runat="server" CssClass="form-control" >
                                    </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="Requirddlselectname" runat="server" ForeColor="Red" ValidationGroup="val" ControlToValidate="ddlselectname" InitialValue="0" ErrorMessage="Please select village name" />
                                    <div>
                                        <asp:Label ID="LblVillageName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">State/Central:<label class="lblColor">*</label></label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="DdlStateCentral" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="-Select-" Value="-Select-"></asp:ListItem>
                                        <asp:ListItem Text="State" Value="State"></asp:ListItem>
                                        <asp:ListItem Text="Central" Value="Central"></asp:ListItem>
                                    </asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="rfv1" runat="server" ForeColor="Red" ValidationGroup="val" ControlToValidate="DdlStateCentral" InitialValue="-Select-" ErrorMessage="Please select State/Central" />
                                    <div>
                                        <asp:Label ID="LblDdlStateCentral" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Benefits Extended:</label>
                                <div class="col-sm-9">
                                  <asp:TextBox ID="TxtBenfitExt" autocomplete="off" CssClass="form-control"  runat="server"  ></asp:TextBox>
                                    
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="TxtBenfitExt" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                     <div>
                                        <asp:Label ID="lblTxtBenfitExt" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--jhjhj--%>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Amount Spent:<label class="lblColor">*</label></label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="TxtAmountSpent" autocomplete="off" CssClass="form-control"   runat="server"  ></asp:TextBox>
                                  <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="TxtAmountSpent" ValidationGroup="val"
                                        ErrorMessage="Enter Amount Spent." ForeColor="Red" />
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" CssClass="red-text-asterix " ValidationGroup="val" Display="Dynamic" ControlToValidate="TxtAmountSpent" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                     <div>
                                        <asp:Label ID="lblmsgds" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-md-12">
						<hr/>
                            <div class="form-group">
                                <div class="col-sm-11 text-left">
                                    <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Save" OnClientClick="return validateData();" CssClass="btn btn-primary btn-add" OnClick="btnsave_Click" />
                                    <asp:Button ID="BtnBack" runat="server" Visible="false" Text="Back" CausesValidation="false" OnClick="BtnBack_Click" CssClass="btn aqua" />
                                    <asp:Label ID="Label1" runat="server" ForeColor="#CC3300"></asp:Label>
									<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/NGO/NGO.aspx" class="btn btn-primary">Next</a>

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

