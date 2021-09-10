<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Auth_Adminpanel_ResetPassword" Debug="true" %>

<%@ Register Assembly="ncmcaptcha" Namespace="ncmcaptcha" TagPrefix="Captcha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>WPC Admin Reset Password</title>
<<link href="assets/css/bootstrap.min.css" rel="stylesheet" />
<link href="assets/css/main.css" rel="stylesheet" />
<!-- Fontes -->
<link href="assets/css/font-awesome.min.css" rel="stylesheet" />
<link href="assets/css/ameffectsanimation.css" rel="stylesheet" />
<link href="assets/css/buttons.css" rel="stylesheet" />




<style>
#CaptchDiv div a {
display: none;
}
.frm_row label[class*="col-md-"]{
	padding-left:8px;
	padding-right:8px;
}
.frm_row label{
	text-align:left !important;
}
h2 {
animation-duration: 1200ms;
animation-name: blink;
animation-iteration-count: infinite;
animation-direction: alternate;
-webkit-animation: blink 1200ms infinite; /* Safari and Chrome */
padding-bottom: 10px;
}

@keyframes blink {
from {
color: red;
}

to {
color: white;
}
}

@-webkit-keyframes blink {
from {
color: red;
}

to {
color: white;
}
}
</style>
 <script type="text/javascript" src="assets/js/sha512.js"></script>
<script type="text/javascript" language="javascript">


function getPass() {
var exp = /((?=.*\d)(?=.*[a-z])(?=.*[@#$%]).{6,10})/;
var value = document.getElementById('<%=txtNewPass.ClientID%>').value;




var value3 = document.getElementById('<%=txtConfirmPass.ClientID%>').value;



if (value3 == '') {
alert('Please Enter New Confirm Password');
return false;
}

if (value == '') {
alert('Please Enter user name and password');
return false;
}
if (value.search(exp) == -1) {
alert("Use min 6 Characters.The password must have at least one  alphabets, one digit and one special character (@#$%^&+=_).");
return false;
}


var salt = '<%=Session["salt"]%>';
var value = document.getElementById('<%=txtNewPass.ClientID%>').value;

var hash = hex_sha512(value);
document.getElementById('<%=txtNewPass.ClientID %>').value = hash;

var value2 = document.getElementById('<%=txtConfirmPass.ClientID%>').value;
var hash2 = hex_sha512(value2);

document.getElementById('<%=txtConfirmPass.ClientID %>').value = hash2;

}


</script>

</head>
<body>

<form id="form" runat="server">
<!--hii ******************************************************************************start

<div class="red-bg1">
<div class="middle-box text-center loginscreen ">
<div class="widgets-container" style="border: 10px solid #ddd">
	<div>
		<h1 class="logo-name"><a href="../../Home.aspx">
			<img src="assets/images/logo1.png" alt="" title=""></a></h1>
	</div>
	<h3 style="color: white;">Welcome to NTCA Admin</h3>
	<p style="color: white;">Login in. To see it in action.</p>
	<p style="color: white;">
		<label id="LblMsg"></label>
	</p>
	<div class="top15">
		<div class="form-group">

			<input name="txtUserName" type="text" id="txtUserName" class="form-control" placeholder="User name">
		</div>
		<div class="form-group">
			<input type="hidden" name="hfpwd" id="hfpwd">
			<input type="password" placeholder="Password" class="" id="txtPwd" name="password" value="admin@123" class="form-control">
		</div>
		<div class="form-group" id="CaptchDiv">
			<div style="background-color:White;"><img src="CaptchaImage.axd?guid=e8b3f2de-6120-4d37-a4f5-a1fe73a9e82d" border="0" width="168" height="50"><input type="image" name="recaptcha$btnrefresh" id="recaptcha_btnrefresh" title="Refresh" src="images/images.jpeg" alt="Refresh" onclick="ClearTextbox();"><a target="_blank" href="CaptchaAudio.axd?guid=e8b3f2de-6120-4d37-a4f5-a1fe73a9e82d"><img border="0" title="Play Audio" alt="Play Audio" src="/NTCA_MIS/auth/Adminpanel/images/WebResource.gif"></a></div>
		</div>
		<div class="form-group">
			<input name="txtcaptcha" type="text" maxlength="5" id="txtcaptcha" placeholder="Captcha" class="form-control">

		</div>
		<input type="submit" name="btnsubmit" value="Login" onclick="return getPass();" id="btnsubmit" class="btn green block full-width  bottom15">
		<a href="ForgetPassword.aspx?Ftype=MainSite" style="color: white;"><small>Forgot password?</small></a>
		
		
	</div>
	<p style="color: white;"><small>NTCA ©  2017</small> </p>
</div>
</div>
</div>
-- end**************************************************************************************************** mm-->


<div class="red-bg1">
<div class="middle-box text-center loginscreen ">
<div class="widgets-container" style="border: 10px solid #ddd;">
	<div style="text-align: center;">
		<div class="error_mass">
			<asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
		</div>
		<div id="login-box">
			<div class="box-ineer form-horizontal">
				<div>
					<h1 class="logo-name"><a href="../../Home.aspx">
						<img src="assets/images/logo1.png" alt="" title=""></a></h1>
					<h3 style="color: white;">MIS FOR RELOCATION OF VILLAGES</h3>

					<h2 style="color: white;">Reset Password</h2>
				</div>



				<div class="frm_row form-group">
	   <label class="col-md-5 control-label" for='<%=txtNewPass.ClientID %>'>New Password<strong class="text3">*</strong></label>
	   <div class="col-md-7">
	   <asp:TextBox ID="txtNewPass" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
	   <span class="validation">
		<asp:RequiredFieldValidator ID ="RequiredFieldValidator2" Display="Dynamic" ValidationGroup="Reset" runat ="server"  ControlToValidate ="txtNewPass" ErrorMessage ="Please Enter New Password"></asp:RequiredFieldValidator>
	   </span>
	   
					</div>
</div>
<div class="frm_row form-group"> 
	   <label class="col-md-5 control-label" for='<%=txtConfirmPass.ClientID %>'>Confirm Password<strong class="text3">*</strong></label>
	   <div class="col-md-7">
	   <asp:TextBox ID="txtConfirmPass" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
	   <span class="validation">
	  <asp:RequiredFieldValidator ID ="RequiredFieldValidator1" runat ="server"  ControlToValidate ="txtConfirmPass" ErrorMessage ="Please Enter New Confirm Password"  Display="Dynamic" ValidationGroup="Reset"></asp:RequiredFieldValidator>
	<asp:CompareValidator ID="CompareValidator1" CssClass="errormesg2" runat="server" Display="Dynamic"
									  ValidationGroup="Reset"      ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPass" ErrorMessage="Password did not match.">
										</asp:CompareValidator>
	   </div>
<div class="cls">
					</div>
</div>
			   


				<div class="form-group" id="CaptchDiv">
					<Captcha:CaptchaControl ID="recaptcha" runat="server" CaptchaLength="5"
						CaptchaWidth="168" RefreshImageURL="images/images.jpeg" SoundImageURL="images/WebResource.gif" />
				</div>
				<div class="col-md-12">
				<div class="form-group">
					<asp:TextBox ID="txtcaptcha" runat="server" autocomplete="off" ValidationGroup="ab" placeholder="Captcha" class="form-control" MaxLength="5"></asp:TextBox>

				</div>
				</div>



				<div class="login-b">
					<span class="button-l">
						<asp:Button ID="btnLogin" runat="server" ValidationGroup="ab" Text="Submit" CssClass="btn green block full-width  bottom15" OnClientClick="return getPass();" OnClick="btnLogin_Click" />
					</span>

				</div>


				<div class="cls"></div>
			</div>

		</div>
		<div class="cls"></div>
	</div>
</div>
</div>
</div>
</form>
</body>
</html>
