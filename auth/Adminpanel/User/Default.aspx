<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="auth_Adminpanel_User_Default" %>
<%--<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="Adduser.aspx.cs" Inherits="auth_Adminpanel_User_Adduser" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div class="wrapper-content" style="padding-top:0px; min-height:550px;">
        <div class="row">
            <div class="col-lg-12 ">
                <div class="widgets-container">
                    
                    
						<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                      <%--  <h3 class="box-title" style="color: #005529;"><%=HeaderTitle %></h3>--%>
                    </div>
                    
                </div>
					
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    UserName<span style="color:red;">*</span></label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtUserName" ValidationGroup="GroupUser" autocomplete="off" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator  runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
                                        ControlToValidate="txtUserName" ValidationGroup="GroupUser" ErrorMessage="Enter UserName" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ID="regUsername" Display="Dynamic" SetFocusOnError="true"
                                        runat="server" ErrorMessage="Minimum 5 characters use." ValidationGroup="GroupUser"
                                        ControlToValidate="txtUserName"
                                        ValidationExpression="^.{5,35}$" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" SetFocusOnError="true" ValidationGroup="GroupUser" Display="Dynamic" runat="server" ControlToValidate="txtUserName" ForeColor="Red"
                                        ValidationExpression="[a-zA-Z0-9.]*$" ErrorMessage="Please use letters and number" />

                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Name<span style="color:red;">*</span></label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtfirstname" ValidationGroup="GroupUser" autocomplete="off" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" SetFocusOnError="true"
                                        ControlToValidate="txtfirstname" ValidationGroup="GroupUser" ErrorMessage="Enter Name" ForeColor="Red" />
                                  <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="GroupUser" Display="Dynamic" runat="server" ControlToValidate="txtfirstname" ForeColor="Red"
                                        ValidationExpression="[a-zA-Z0-9. ]*$" ErrorMessage="Please use letters and number" />--%>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" SetFocusOnError="true" ValidationGroup="GroupUser" Display="Dynamic" runat="server" ControlToValidate="txtfirstname" ForeColor="Red"
                                        ValidationExpression="^[a-zA-Z\s\.]+$" ErrorMessage="Please enter alphabets. Name field should be accepted only alphabets (some special characters should be allowed like space and dot)" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" SetFocusOnError="true" Display="Dynamic"
                                        runat="server" ErrorMessage="Minimum 3 characters use." ValidationGroup="GroupUser"
                                        ControlToValidate="txtfirstname"
                                        ValidationExpression="^.{3,30}$" ForeColor="Red" />
                                    
                                     </div>
                            </div>
                            <!--<div class="col-sm-3">
                                <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"
                                    ControlToValidate="txtlastname" ValidationGroup="val" ErrorMessage="Enter Last Name" />
                            </div>-->
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    UserType<span style="color:red;">*</span></label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlUsertype" runat="server" ValidationGroup="GroupUser" CssClass="form-control">
                                        <asp:ListItem Value="0"> Select User Type</asp:ListItem>
                                        <asp:ListItem Value="2">State User</asp:ListItem>
                                        <asp:ListItem Value="3">Tiger Reserve User</asp:ListItem>
                                        <asp:ListItem Value="4">Deputy Director/DFO</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"
                                        ControlToValidate="ddlUsertype" InitialValue="0" ValidationGroup="GroupUser" ErrorMessage="Select UserType" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Select State<span style="color:red;">*</span></label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlstate" runat="server" ValidationGroup="GroupUser" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"
                                        InitialValue="0" ControlToValidate="ddlstate" ValidationGroup="GroupUser" ErrorMessage="Select state" ForeColor="Red" />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Email<span style="color:red;">*</span></label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtemail" ValidationGroup="GroupUser" autocomplete="off" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"
                                        ControlToValidate="txtemail" ValidationGroup="GroupUser" ErrorMessage="Enter Email" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ID="validateEmail" Display="Dynamic" ForeColor="Red"
                                        runat="server" ErrorMessage="Invalid email." ValidationGroup="GroupUser"
                                        ControlToValidate="txtemail"
                                        ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Address1<span style="color:red;">*</span></label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtaddress1" autocomplete="off"  ValidationGroup="GroupUser" runat="server" MaxLength="100" TextMode="MultiLine" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" CssClass="help-block" Display="Dynamic"
                                        ControlToValidate="txtaddress1" ValidationGroup="GroupUser" ErrorMessage="Enter Address" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Address2</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtaddress2" autocomplete="off" runat="server" ValidationGroup="GroupUser" TextMode="MultiLine" MaxLength="100" CssClass="form-control" />

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="GroupUser" Display="Dynamic" runat="server" ControlToValidate="txtaddress2" ForeColor="Red"
                                        ValidationExpression="[a-zA-Z0-9. ]*$" ErrorMessage="Please use letters and number." />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Pincode<span style="color:red;">*</span>
                                </label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtpincode" ValidationGroup="GroupUser" autocomplete="off" runat="server" MaxLength="6" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"
                                        ControlToValidate="txtpincode" ValidationGroup="GroupUser" ErrorMessage="Enter Pincode" ForeColor="Red" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" Display="Dynamic"
                                        runat="server" ErrorMessage="Enter six digit pincode." ValidationGroup="GroupUser"
                                        ControlToValidate="txtpincode"
                                        ValidationExpression="^.{6,6}$" ForeColor="Red" />
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtpincode" ForeColor="Red"
ErrorMessage="Please Enter Only Numbers" ValidationGroup="GroupUser"  ValidationExpression="^\d+$" ></asp:RegularExpressionValidator> 
                                    <asp:Label ID="LblPincodeMsg" runat="server" ForeColor="Red" ></asp:Label>
                                     </div>
                            </div>
                        </div>
						<div class="clearfix"></div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Land Line No
                                </label>
                                <div class="col-sm-2">
                                    <asp:TextBox ID="txtareacode" ValidationGroup="GroupUser" autocomplete="off" placeholder="Area Code" runat="server"  CssClass="form-control" MaxLength="5" /><br />
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtareacode" Display="Dynamic" ForeColor="Red"
ErrorMessage="Please Enter Only Numbers" ValidationGroup="GroupUser"  ValidationExpression="^\d+$" ></asp:RegularExpressionValidator> 
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator12" Display="Dynamic"
                                        runat="server" ErrorMessage="Minimum 3 characters use." ValidationGroup="GroupUser"
                                        ControlToValidate="txtareacode"
                                        ValidationExpression="^.{3,5}$" ForeColor="Red" />
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="txtlandlineno" ValidationGroup="GroupUser" autocomplete="off" placeholder="Land Line no" runat="server" MaxLength="8"
                                        CssClass="form-control" />
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtlandlineno" ForeColor="Red"
ErrorMessage="Please Enter Only Numbers" ValidationGroup="GroupUser"  ValidationExpression="^\d+$" ></asp:RegularExpressionValidator> 
                               <%--<asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="GroupUser" ControlToValidate = "txtlandlineno" ForeColor="Red" ID="RegularExpressionValidator11" ValidationExpression = "^[\s\S]{6,8}$" runat="server" ErrorMessage="Land Line No Field- 6 to 8 digits."></asp:RegularExpressionValidator>--%>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator13" Display="Dynamic"
                                        runat="server" ErrorMessage="Minimum 6 characters use." ValidationGroup="GroupUser"
                                        ControlToValidate="txtlandlineno"
                                        ValidationExpression="^.{6,8}$" ForeColor="Red" />
                                     </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    Mobile No
                                </label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtmobileno" ValidationGroup="GroupUser" autocomplete="off" placeholder="Mobile No" runat="server" MaxLength="10"
                                        CssClass="form-control" />
                                      <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="GroupUser" ControlToValidate = "txtmobileno" ForeColor="Red" ID="RegularExpressionValidator6" ValidationExpression = "^[\s\S]{7,10}$" runat="server" ErrorMessage="Please enter 10 digits Mobile number."></asp:RegularExpressionValidator>
                     
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtmobileno" ForeColor="Red"
ErrorMessage="Please Enter Only Numbers" ValidationGroup="GroupUser"  ValidationExpression="^\d+$" ></asp:RegularExpressionValidator> 
                     
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-md-12 text-center">
                            <div class="form-group">
                                <div class="col-sm-8 col-sm-offset-1">
                                    <asp:Label ID="LblMSg" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:Button ID="Button1" runat="server" ValidationGroup="GroupUser" Text="Button" />
                                  
                               
                                     </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--  morris Charts  -->
    <!-- js for print and download -->

    
	  </ContentTemplate>
           
        </asp:UpdatePanel>
</asp:Content>

