<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login1.aspx.cs" Inherits="auth_Adminpanel_login1" %>

<%@ Register Assembly="ncmcaptcha" Namespace="ncmcaptcha" TagPrefix="Captcha" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>NTCA Admin</title>
    <!-- Bootstrap -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <!-- slimscroll -->
    <link href="assets/css/jquery.slimscroll.css" rel="stylesheet" />


    <!-- Fontes -->
    <link href="assets/css/font-awesome.min.css" rel="stylesheet" />

    <link href="assets/css/ameffectsanimation.css" rel="stylesheet" />
    <link href="assets/css/buttons.css" rel="stylesheet" />
    <!-- top nev css -->
    <link href="assets/css/page-header.css" rel="stylesheet" />
    <!-- adminui main css -->
    <link href="assets/css/main.css" rel="stylesheet" />

    <!-- red theme css -->
    <link href="assets/css/red.css" rel="stylesheet" />
    <!-- media css for responsive  -->
    <link href="assets/css/main.media.css" rel="stylesheet" />
    <style>
        #CaptchDiv div a {
        display:none;
        }
    </style>
    <script type="text/javascript">


        $(document).ready(function () {

          
        });
        function getPass() {

            var exp = /((?=.*\d)(?=.*[a-z])(?=.*[@#$&]).{8,15})/;
            var exp1 = /^[A-Za-z0-9._]{3,25}$/;
            var exp3 = /(^[\s\S]{0,5}$)/;
            var exp4 = /(^[0-9a-zA-Z ]+$)/;

            var value = document.getElementById('txtPwd').value;
            var value1 = document.getElementById('<%=txtUserName.ClientID%>').value;
            //alert(value1);
            var capvalue = document.getElementById('<%=txtcaptcha.ClientID%>').value;
            var capvalue = document.getElementById('<%=txtcaptcha.ClientID%>').value;
            
            if (capvalue == '') {
                alert('Please enter Captcha Code');
                document.getElementById('<%=txtcaptcha.ClientID%>').focus();
                return false;
            }
            if (value1 == '') {
                alert("Please enter username");
                document.getElementById('<%=txtUserName.ClientID%>').focus();
                return false;
            }
          <%--if (value1.search(exp1) == -1)
            {
                alert("Don't use any special characters except . and _  in username and Should be more then 3 characters");
                document.getElementById('<%=txtUserName.ClientID%>').focus();
                return false;
            }--%>

            if (value == '') {
                alert('Please enter password');
                document.getElementById('txtPwd').value.focus();
                return false;
            }
            if (value.search(exp) == -1) {
                document.getElementById('txtPwd').value.focus();
                alert("Please enter password in correct format.");
                return false;
            }
           


            var salt = '<%=Session["salt"]%>';

            var hash = hex_sha512(hex_sha512(value) + salt);

            document.getElementById('txtPwd').value = hash;
            document.getElementById('<%=hfpwd.ClientID%>').value = hash;


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
    <form id="form1" runat="server" defaultbutton="btnsubmit">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                        <label id="LblMsg" runat="server"></label>
                    </p>
                    <div class="top15">
                        <div class="form-group">

                            <asp:TextBox ID="txtUserName" runat="server" autocomplete="off" placeholder="User name" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:HiddenField ID="hfpwd" runat="server" />
                            <input type="password" placeholder="Password" autocomplete="off" id="txtPwd" name="password" class="form-control">
                        </div>
                        <div class="form-group" id="CaptchDiv">
                            <Captcha:CaptchaControl ID="recaptcha" runat="server" CaptchaLength="5"
                                CaptchaWidth="168"  RefreshImageURL="images/images.jpeg" SoundImageURL="images/WebResource.gif" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtcaptcha" runat="server" autocomplete="off" placeholder="Captcha" class="form-control" MaxLength="5"></asp:TextBox>

                        </div>
                        <asp:Button ID="btnsubmit" runat="server" OnClientClick="return getPass();"
                            CssClass="btn green block full-width  bottom15" Text="Login"
                            ValidationGroup="Login" OnClick="btnsubmit_Click" />
                        <a href="ForgetPassword.aspx?Ftype=MainSite" style="color: white;"><small>Forgot password?</small></a>
                        <%--<p class="text-muted text-center" style="color:white;"><small>Do not have an account?</small></p>--%>
                        <%--<a href="#" class="btn btn-sm btn-white btn-block">Create an account</a>--%>
                    </div>
                    <p style="color: white;"><small>NTCA &copy;  2017</small> </p>
                </div>
            </div>
        </div>



        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="assets/js/vendor/jquery.min.js"></script>
        <!-- bootstrap js -->
        <script src="assets/js/vendor/bootstrap.min.js"></script>
        <!-- js for print and download -->
        <script type="text/javascript" src="assets/js/vendor/vfs_fonts.js"></script>
        <script src="assets/js/vendor/chartJs/Chart.bundle.js"></script>
        <script src="assets/js/dashboard1.js"></script>
        <!-- slimscroll js -->
        <script type="text/javascript" src="assets/js/vendor/jquery.slimscroll.js"></script>
        <!-- main js -->
        <script src="assets/js/main.js"></script>
    </form>
</body>
</html>
