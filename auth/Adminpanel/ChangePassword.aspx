<%@ Page Title="Change Password:NTCA" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="auth_Adminpanel_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.text3{
color:red;
}
</style>
    <script src='<%#ResolveUrl("assets/js/sha512.js")%>'></script>
    <script type="text/javascript">
        function getPass() {
            var exp = /((?=.*\d)(?=.*[a-z])(?=.*[@#$%]).{8,15})/;
            var valueOldPwd = document.getElementById('<%=OldPassword.ClientID%>').value;
            if (valueOldPwd == "") {
                alert("please enter old password");
                return false;
            }
            var value1 = document.getElementById('<%=NewPassword.ClientID%>').value;

            var value6 = document.getElementById('<%=ConfirmPassword.ClientID%>').value;

            if (value1 == "") {
                alert("please enter new password");
                return false;
            }


            if (value6 == "") {
                alert("please enter Confirm password");
                return false;
            }

            if (value1.search(exp) == -1) {
                alert("Use min 8 Characters.The password must have at least one  alphabets, one digit and one special character (@#$%^&+=_).");
                return false;
            }


            var hash1 = hex_sha512(value1);
            document.getElementById('<%=NewPassword.ClientID %>').value = hash1;

            var value2 = document.getElementById('<%=ConfirmPassword.ClientID %>').value
            var hash2 = hex_sha512(value2);
            document.getElementById('<%=ConfirmPassword.ClientID %>').value = hash2;

            var hash3 = hex_sha512(valueOldPwd);

            document.getElementById('<%=OldPassword.ClientID %>').value = hash3;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
<div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12  bottom20">
				<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color:black;">Change Password</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                </div>
    <div class="feedback">
		<div class="widgets-container">
			<div class="col-md-7" style="padding-left: 0px;">
                                <div class="form-group">
                                    <label for="<%=OldPassword.ClientID %>" class="col-md-4 control-label gtx label1"> <span style="color:black;">Old Password:</span> <strong class="text3">* </strong></label>
									<div class="col-md-6 input-group">
										<span class="input1">
											<asp:TextBox ID="OldPassword" runat="server" CssClass="input_class form-control" TextMode="Password"></asp:TextBox></span>
                        <span class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                    ErrorMessage="Please enter old password" ControlToValidate="OldPassword" ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator>
										</span>
									</div>
                                    
                                </div>
                            </div>
		
		
		
		
		
		<div class="col-md-7" style="padding-left: 0px;">
                                <div class="form-group">
                                    <label for="<%=NewPassword.ClientID%>" class="col-md-4 control-label gtx label1"> <span style="color:black;">New Password :</span> <strong class="text3">* </strong></label>
									<div class="col-md-6 input-group">
										<span class="input1">
											<asp:TextBox ID="NewPassword" runat="server" CssClass="input_class form-control" TextMode="Password"></asp:TextBox></span>
                        <span class="validation">
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                    ErrorMessage="Please enter Confirm password" ControlToValidate="NewPassword" ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator>

                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" 
                                    ErrorMessage="Please enter new password" ControlToValidate="NewPassword" ValidationGroup="ChangePassword" ForeColor="Red" ></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NewPassword"
                                    ErrorMessage="Password must have at least 1 number, 1 special character,and min 8 characters." Display="Dynamic"
                                    ValidationExpression="((?=.*\d)(?=.*[a-z])(?=.*[@#$%]).{8,15})" ForeColor="Red"></asp:RegularExpressionValidator>
										</span>
									</div>
                                    
                                </div>
                            </div>
							
							
							
							<div class="col-md-7" style="padding-left: 0px;">
                                <div class="form-group">
                                    <label for="<%=ConfirmPassword.ClientID %>" class="col-md-4 control-label gtx label1"><span style="color:black;"> Confirm Password:</span> <strong class="text3">* </strong></label>
									<div class="col-md-6 input-group">
										<span class="input1">
											<asp:TextBox ID="ConfirmPassword" runat="server" CssClass="input_class form-control"
                                    TextMode="Password"></asp:TextBox></span>
                        <span class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                    ErrorMessage="Please enter Confirm password" ControlToValidate="OldPassword" ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <asp:CompareValidator ID="compare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmPassword" Operator="Equal" ErrorMessage="New Password  & Confirm Password are not same" ValidationGroup="ChangePassword" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
										</span>
									</div>
                                    
                                </div>
                            </div>
							
							<div class="col-md-7" style="padding-left: 0px;">
                                <div class="form-group">
                                    <div class="col-md-6 input-group">
                                    
                                        </div>
                                    </div>
                                </div>
							
							<div class="col-md-7 ">
							<div class="col-md-4"></div>
							<div class="col-md-6 input-group">
                                
								<span class="button_row">
										<asp:Button ID="update" runat="server" Text="Update" CssClass="button btn btn-primary" ValidationGroup="ChangePassword"
										OnClick="update_Click" OnClientClick="return getPass();"  />
                                    <asp:Button ID="BtnReset" CssClass="button btn btn-primary" CausesValidation="false" runat="server" Text="Reset" OnClick="BtnReset_Click" />
                                    <br />
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
								
                               </span>
                                </div>
                                <div>
                                    
                                </div>
							</div>   
							<div class="clear"></div>
							</div>

							<div class="col-md-7 ">
   
							</div>
   
   
		</div>
	
               
</div>
</div>
</div>
</div>

</asp:Content>

