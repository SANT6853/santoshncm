<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="Auth_Adminpanel_ResetPassword" Debug="true" %>
<%@ Register Assembly="ncmcaptcha" Namespace="ncmcaptcha" TagPrefix="Captcha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>BPR&D Admin Reset Password</title>
     <style>
        #CaptchDiv div a {
            display: none;
        }
    </style>

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
   <form id="form1" runat="server" defaultbutton ="btnLogin">
      <div class="error_mass"><asp:Label ID="lblmsg" runat="server" Font-Bold="True"></asp:Label></div>
   <div id="login-box" style="text-align:center;">
  

<div class="box-ineer" style="text-align:center;">
 <div style="text-align:center;">
                        <h1 class="logo-name"><a href="../../Home.aspx">
                            <img src="/images/logo1.png" alt="" title=""></a></h1>
                         <h1>MIS FOR RELOCATION OF VILLAGES</h1>
                   
                   <h2>Reset Password</h2>
                    </div>


<div class="frm_row" style="text-align:center;">
<span class="label1"> 
                       <label>New Password<strong class="text3">*</strong></label></span>
                       <span class="input1"> <asp:TextBox ID="txtNewPass" runat="server" class="input_class" TextMode="Password"></asp:TextBox>
                      </span>
                       <span class="validation">
                        <asp:RequiredFieldValidator ID ="RequiredFieldValidator2" Display="Dynamic" ValidationGroup="Reset" runat ="server"  ControlToValidate ="txtNewPass" ErrorMessage ="Please Enter New Password" ForeColor="Red"></asp:RequiredFieldValidator>
                       </span>
                        <div class="clear"></div>
                        </div>
                        


                        <div class="frm_row">
<span class="label1"> 
                       <label>Confirm Password<strong class="text3">*</strong></label></span>
                       <span class="input1"> <asp:TextBox ID="txtConfirmPass" runat="server" class="input_class" TextMode="Password"></asp:TextBox>
                      </span>
                       <span class="validation">
                      <asp:RequiredFieldValidator ID ="RequiredFieldValidator1" runat ="server"  ControlToValidate ="txtConfirmPass" ErrorMessage ="Please Enter New Confirm Password"  Display="Dynamic" ValidationGroup="Reset" ForeColor="Red"></asp:RequiredFieldValidator>
				    <asp:CompareValidator ID="CompareValidator1" CssClass="errormesg2" runat="server" Display="Dynamic"
                                                      ValidationGroup="Reset"      ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPass" ErrorMessage="Password did not match." ForeColor="Red"></asp:CompareValidator>
                       </span>
                        <div class="clear"></div>
                        </div>

    <div class="form-group" id="CaptchDiv">
                        <Captcha:CaptchaControl ID="recaptcha" runat="server" CaptchaLength="5"
                            CaptchaWidth="168" RefreshImageURL="images/images.jpeg" SoundImageURL="images/WebResource.gif" />
                    </div>
                     <div class="form-group">
                            <asp:TextBox ID="txtcaptcha" runat="server" ValidationGroup="ab" placeholder="Captcha" class="form-control" MaxLength="5"></asp:TextBox>

                        </div>

<div class="login-b" align="center">
  <span class="button-l">
  <asp:Button ID="btnLogin" runat="server"  Text="Submit" OnClientClick="javascript:return getPass();"
                                                        OnClick="btnLogin_Click" ValidationGroup="Reset" />

                                                        <input name="Cancel" type="reset" value="Cancel"  />
 
  </span>
 
  </div>
                        

 <div class="cls"></div>
  </div>  
  
</div>
 <div class="cls"></div>
    </form>
</body>
</html>
