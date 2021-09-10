<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register Src="~/UserControl/BannerUserControl.ascx" TagName="BannerImage" TagPrefix="ucBanner" %>
<%@ Register Assembly="ncmcaptcha" Namespace="ncmcaptcha" TagPrefix="Captcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        #CaptchDiv div a {
            display: none;
        }
    </style>
    <script type="text/javascript">
        //  console.log(window.document.location.href);
        $(document).ready(function () {
            var BrowserUrl = window.document.location.href;
        });

        function getPass() {

            var exp = /((?=.*\d)(?=.*[a-z])(?=.*[@#$&]).{8,15})/;
            var exp1 = /^[A-Za-z0-9._]{3,25}$/;
            var exp3 = /(^[\s\S]{0,5}$)/;
            var exp4 = /(^[0-9a-zA-Z ]+$)/;
            var chk;

            var value = document.getElementById('txtPwd').value;
            var value1 = document.getElementById('<%=txtUserName.ClientID%>').value;
            var ddl = document.getElementById('<%=DdlUserType.ClientID%>').value;

            var capvalue = document.getElementById('<%=txtcaptcha.ClientID%>').value;
            <%--if (capvalue == '') {
                alert('Please enter Captcha Code');
                document.getElementById('<%=txtcaptcha.ClientID%>').focus();
              
                return false;
               
            }--%>
            if (ddl == '0') {
                alert("Please choose your user type!");
                document.getElementById('<%=DdlUserType.ClientID%>').focus();

                return false;
            }
            if (value1 == '') {
                alert("Please enter username");
                document.getElementById('<%=txtUserName.ClientID%>').focus();

                return false;
            }
            if (value1.search(exp1) == -1) {
                alert("Don't use any special characters except . and _  in username and Should be more then 3 characters");
                document.getElementById('<%=txtUserName.ClientID%>').focus();

                return false;
            }

            if (value == '') {
                alert('Please enter password');
                document.getElementById('txtPwd').value.focus();
                return false;
            }
            if (value.search(exp) == -1) {
                alert("Please enter password in correct format.");
                document.getElementById('txtPwd').value.focus();
                return false;
            }
            if (capvalue == '') {
                alert('Please enter Captcha Code');
                document.getElementById('<%=txtcaptcha.ClientID%>').focus();

                return false;

            }

            var salt = '<%=Session["salt"]%>';
            var hash = hex_sha512(hex_sha512(value) + salt);

            document.getElementById('txtPwd').value = hash;
            document.getElementById('<%=hfpwd.ClientID%>').value = hash;


                return true;
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
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBannerImages" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" runat="Server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">

</asp:ScriptManager>
<asp:UpdatePanel ID="updatepnl" runat="server">

<ContentTemplate>
    <div class="col-md-9 font_medium bantigr">

        <asp:Literal ID="LtrBanner1" runat="server"></asp:Literal>

        <asp:Literal ID="LtrBannerCarouserInner" runat="server"></asp:Literal>

        <h3>
            <asp:Literal ID="ltrlTigerReserveName" runat="server"></asp:Literal></h3>

        <asp:Literal ID="ltrlContent" runat="server"></asp:Literal>
        <asp:Literal ID="LtrPrevious" runat="server"></asp:Literal>
        <asp:Literal ID="LtrNext" runat="server"></asp:Literal>

    </div>
    <div class="col-md-3">
        <div class="employee_login">           
           <%if (Session["tigerreserveNameforLable"] != null)
                {%>
              <h3><%= Session["tigerreserveNameforLable"].ToString() %></h3>
            <%}
           else { %>
             <h3>Tiger Reseve</h3>
            <%} %>
            <div class="form-group">
                <asp:DropDownList ID="DdlUserType" runat="server">
                    <asp:ListItem Text="-SELECT USER TYPE-" Value="0"></asp:ListItem>
                    <%-- <asp:ListItem Text="NTCA" Value="1"></asp:ListItem>--%>
                    <asp:ListItem Text="DEPUTY DIRECTOR/DFO" Value="4"></asp:ListItem>
                    <asp:ListItem Text="FD (Field Director)" Value="3"></asp:ListItem>
                    <asp:ListItem Text="CWLF (Chief Wildlife Warden)" Value="2"></asp:ListItem>
                    
                    
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtUserName" runat="server" autocomplete="off" placeholder="User name" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">

                <asp:HiddenField ID="hfpwd" runat="server" />
                <input type="password" placeholder="Password" autocomplete="off" id="txtPwd" name="password" class="form-control" />
            </div>
            <div class="form-group" id="CaptchDiv">
               <%-- <Captcha:CaptchaControl ID="recaptcha" runat="server" CaptchaLength="5" RefreshImageURL="images/images.jpeg"
                    CaptchaWidth="168" />--%>
                <asp:Image ID="imgCaptcha" runat="server" /><span><asp:ImageButton ID="btnRefresh" ImageUrl="images/images.jpeg" runat="server" OnClick="btnRefresh_Click" /></span>
                <asp:Label ID="LblMsg1" runat="server" Font-Italic="true" ForeColor="White" Font-Bold="true" BorderColor="Blue"></asp:Label>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtcaptcha" MaxLength="5" autocomplete="off" runat="server" placeholder="Captcha" class="form-control"></asp:TextBox>
            </div>
            <a href="auth/Adminpanel/ForgetPassword.aspx?Ftype=TigerReserve" style="color: blue; text-decoration:underline;"><small>Forgot password?</small></a>
            | <a href="<%=ResolveUrl("/NTCA_MIS/Home.aspx") %>" style="color:blue; text-decoration:underline;"><small>Back to Home</small></a>
                                <br />
             <asp:Button ID="btnsubmit" runat="server" OnClientClick="return getPass();"
                CssClass="btn-submit" Text="Login"
                ValidationGroup="Login" OnClick="btnsubmit_Click" />



        </div>
    </div>
    </ContentTemplate>

</asp:UpdatePanel>

</asp:Content>


