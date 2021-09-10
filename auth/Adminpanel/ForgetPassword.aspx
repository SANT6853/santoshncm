<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPassword.aspx.cs" Inherits="auth_Adminpanel_ForgetPassword" %>

<%@ Register Assembly="ncmcaptcha" Namespace="ncmcaptcha" TagPrefix="Captcha" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forget password</title>
    <%-- <script type="text/javascript" src="js/html5.js"></script>--%>
    <%--   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>--%>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/main.css" rel="stylesheet" />
    <!-- Fontes -->
    <link href="assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/css/ameffectsanimation.css" rel="stylesheet" />
    <link href="assets/css/buttons.css" rel="stylesheet" />




    <style>
        #CaptchDiv div a {
            display: none;
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
    <script type="text/javascript">

        function getPass() {
            // alert('fdfd');
            var exp = /((?=.*\d)(?=.*[a-z])(?=.*[@#$&]).{8,15})/;
            var exp1 = /^[A-Za-z0-9._]{3,25}$/;
            var exp3 = /(^[\s\S]{0,5}$)/;
            var exp4 = /(^[0-9a-zA-Z ]+$)/;


            var value1 = document.getElementById('<%=txtUserName.ClientID%>').value;
            //alert(value1);
            var capvalue = document.getElementById('<%=txtcaptcha.ClientID%>').value;
            var capvalue = document.getElementById('<%=txtcaptcha.ClientID%>').value;


            if (value1 == '') {
                alert("Please enter username");
                document.getElementById('<%=txtUserName.ClientID%>').focus();
              
                return false;
            }
            if (capvalue == '') {
                alert('Please enter Captcha Code');
                document.getElementById('<%=txtcaptcha.ClientID%>').focus();
               
                return false;
            }

            myImagerefresh();


        }


        function myImagerefresh() {
            $('input[type=image]').click(function () {
                // insert voodoo go get inputs here
                // ajax call
                document.getElementById('<%=txtcaptcha.ClientID%>').value = '';
                    document.getElementById('<%=txtcaptcha.ClientID%>').focus();
                    return false;
                });
            }




    </script>
</head>
<body class="login">
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
                            <input type="password" placeholder="Password" id="txtPwd" name="password" value="admin@123" class="form-control">
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
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True"></asp:Label>
                        </div>
                        <div id="login-box">


                            <div class="box-ineer">
                                <div>
                                    <h1 class="logo-name"><a href="../../Home.aspx">
                                        <img src="assets/images/logo1.png" alt="" title=""></a></h1>
                                    <h3 style="color: white;">MIS FOR RELOCATION OF VILLAGES</h3>

                                    <h2 style="color: white;">Forgot Password</h2>
                                </div>



                                <div class="frm_row form-group">
                                    <%-- <label for='<%=txtUserName.ClientID %>'>User Name<strong class="text3">*</strong></label>--%>
                                    <asp:TextBox ID="txtUserName" autocomplete="off" runat="server" ValidationGroup="ab" placeholder="User Name" class="input_class form-control"></asp:TextBox>

                                    <div class="cls">
                                    </div>
                                </div>


                                <div class="form-group" id="CaptchDiv">
                                    <Captcha:CaptchaControl ID="recaptcha" runat="server" CaptchaLength="5"
                                        CaptchaWidth="168" RefreshImageURL="images/images.jpeg" SoundImageURL="images/WebResource.gif" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtcaptcha" runat="server" autocomplete="off" ValidationGroup="ab" placeholder="Captcha" class="form-control" MaxLength="5"></asp:TextBox>

                                </div>



                                <div class="login-b">
                                    <span class="button-l">
                                        <asp:Button ID="btnLogin" runat="server" ValidationGroup="ab" Text="Submit" CssClass="btn green block full-width  bottom15" OnClientClick="return getPass();" OnClick="btnLogin_Click" />
                                        <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn green block full-width  bottom15" OnClick="BtnBack_Click" />
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
