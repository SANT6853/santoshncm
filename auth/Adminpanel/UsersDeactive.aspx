<%@ Page Language="C#" Title="NTCA:Active or Deactive" AutoEventWireup="true" CodeFile="UsersDeactive.aspx.cs" Inherits="auth_Adminpanel_UsersDeactive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Users Deactive</title>
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
        }

        @keyframes blink {
            from {
                color: green;
            }

            to {
                color: white;
            }
        }

        @-webkit-keyframes blink {
            from {
                color: green;
            }

            to {
                color: white;
            }
        }
    </style>
</head>
<body class="login">
    <form id="form1" runat="server">
   <div class="red-bg1">
            <div class="middle-box text-center loginscreen ">
                <div class="widgets-container" style="border: 10px solid #ddd; background-color:beige;">
                    <div style="text-align: center;">
                        <div class="error_mass">
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True"></asp:Label>
                        </div>
                        <div id="login-box">


                            <div class="box-ineer">
                                <div>
                                    <h1 class="logo-name"><a href="../../Home.aspx">
                                        <img src="assets/images/logo1.png" alt="" title=""></a></h1>
                                    <h3 style="color:black;">MIS FOR RELOCATION OF VILLAGES</h3>

                                    <h2 style="color:red;">Your Login is disable,Please contact to Administartor</h2>
                                </div>


                                 <div class="login-b">
                                    <span class="button-l">
                                     
                                        <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn green block full-width  bottom15" OnClick="BtnBack_Click" />
                                    </span>

                                </div>


                                <div class="cls"></div>
                            </div>

                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
