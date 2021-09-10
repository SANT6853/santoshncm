<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="FeedBackTigerReserve.aspx.cs" Inherits="FeedBackTigerReserve" %>
<%@ Register Assembly="ncmcaptcha" Namespace="ncmcaptcha" TagPrefix="Captcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBannerImages" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" Runat="Server">
    <style>
         #CaptchDiv div a {
        display:none;
        }
        .mainct .row .col-md-3 li{
            background: #f2f2f2;
    padding: 10px;
    margin-bottom: 3px;
    border: 1px solid #f7b000;
    list-style:none;
    text-align:center;
    color:#fff;
        }
        .mainct .row .col-md-3 li:hover{
            background: #f7b000;
    padding: 10px;
    margin-bottom: 3px;
    border: 1px solid #f7b000;
    list-style:none;
    text-align:center;
    color:#fff;
        }
        .mainct .row .col-md-3 li a{
            color:#000;
        }
        
    </style>
    <script language="Javascript">
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
    //-->


    function getPass() {



        var capvalue = document.getElementById('<%=txtcaptcha.ClientID%>').value;
            if (capvalue == '') {
                alert('Please enter Captcha Code');
                document.getElementById('<%=txtcaptcha.ClientID%>').focus();
                  return false;
              }


          }
    </script>
    <div>
         <div class="container mainct">
                <div class="row">
               
                    <asp:Literal ID="LtrLeftMenu" runat="server"></asp:Literal>
                    <div class="col-sm-9">
    <div class="cenn">
    <div class="col-md-7 col-md-offset-2 cen2">
        <h3>Feedback Form</h3>
    <div class="col-sm-12 regleft">
        <label for="fnamesss" class="col-sm-6">(All *fields are mandatory!!)</label><br />
    </div>

    <div class="col-sm-12 regleft">
    <label for="fname" class="col-sm-3">Your Name<span style="color:red;">*</span></label>
    <div class="col-sm-9">
        <asp:TextBox ID="TxtName" autocomplete="off" MaxLength="150" runat="server" placeholder="Your name.." ValidationGroup="feedback"></asp:TextBox>
        <div>
    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
    ControlToValidate="TxtName" ValidationGroup="feedback" ErrorMessage="Enter Your name.." ForeColor="red" />
        </div>
    </div>
    </div>


    <div class="col-sm-12 regleft">

        <label for="Lemail" class="col-sm-3">Your Email<span style="color:red;">*</span></label>

        <div class="col-sm-9">
            <asp:TextBox ID="TxtEmail" autocomplete="off" runat="server" MaxLength="150" placeholder="Your email.."></asp:TextBox>
                 <div>
            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
            ControlToValidate="TxtEmail" ValidationGroup="feedback" ErrorMessage="Enter Your email.." ForeColor="red" />
                     <asp:RegularExpressionValidator ID="validateEmail" Display="Dynamic"    
          runat="server" ErrorMessage="Invalid email." ValidationGroup="feedback"
          ControlToValidate="TxtEmail" 
          ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                </div>
       </div>

    </div>



    <div class="col-sm-12 regleft">
                <label for="LPhone" class="col-sm-3">Your Phone<span style="color:red;">*</span></label>
        <div class="col-sm-9">
            <asp:TextBox ID="TxtPhone" autocomplete="off" runat="server" MaxLength="10" placeholder="Your Phone.."></asp:TextBox>
                 <div>
            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
            ControlToValidate="TxtPhone" ValidationGroup="feedback" ErrorMessage="Enter Your phone.." ForeColor="red" />
                   <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="feedback" ControlToValidate = "TxtPhone" ForeColor="Red" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{7,10}$" runat="server" ErrorMessage="Your phone will be Minimum 7 and Maximum 10 characters required."></asp:RegularExpressionValidator>
                     
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtPhone" ForeColor="Red"
ErrorMessage="Please Enter Only Numbers" ValidationGroup="feedback"  ValidationExpression="^\d+$" ></asp:RegularExpressionValidator> 
                     
                 </div>
        </div>
    </div>



    <div class="col-sm-12 regleft">
            <label for="LState" class="col-sm-3">Your State<span style="color:red;">*</span></label>
        <div class="col-sm-9">
                <asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList>
                <div>
                     <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ForeColor="red"
                                            InitialValue="0" ControlToValidate="ddlstate" ValidationGroup="feedback" ErrorMessage="Select state" />
                </div>
        </div>
    </div>

        <div class="col-sm-12 regleft">
            <label for="LState" class="col-sm-3">Feedback from<span style="color:red;">*</span></label>
        <div class="col-sm-9">
                <asp:DropDownList ID="DdlFeedBackFrom" runat="server">
                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                     <asp:ListItem Text="Ntca" Value="1"></asp:ListItem>
                     <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <div>
                     <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ForeColor="red"
                                            InitialValue="0" ControlToValidate="DdlFeedBackFrom" ValidationGroup="feedback" ErrorMessage="Select feedback from" />
                </div>
        </div>
    </div>
    <div class="col-sm-12 regleft">
        <label for="LAddress" class="col-sm-3">Write Address</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TxtAddress" autocomplete="off" Height="50px" MaxLength="250" runat="server" placeholder="Write Address.." style="height:50px"></asp:TextBox>
        </div>
    </div>


    <div class="col-sm-12 regleft">
            <label for="LMessage" class="col-sm-3">Your Message<span style="color:red;">*</span></label>
        <div class="col-sm-9">
                <asp:TextBox ID="TxtMessage" autocomplete="off" Height="100px" MaxLength="550" runat="server" placeholder="Write message.." ></asp:TextBox>
           <%-- <textarea id="TxtAreaMessage" runat="server" MaxLength="550" name="TxtAreaMessage" placeholder="Write something.." style="height:200px"></textarea>--%>
                <div>
            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
            ControlToValidate="TxtMessage" ValidationGroup="feedback" ErrorMessage="Enter Your message.." ForeColor="red" />
                 <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="feedback" ControlToValidate = "TxtMessage" ForeColor="Red" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{10,250}$" runat="server" ErrorMessage="Your message will be Minimum 10 and Maximum 250 characters required."></asp:RegularExpressionValidator>
                     </div>
        </div>
    </div>


        <div class="col-sm-12 regleft">
            <div class="col-sm-9 col-sm-offset-3">
                <div id="CaptchDiv">
                 <captcha:captchacontrol ID="recaptcha" runat="server" CaptchaWidth="168" RefreshImageURL="images/images.jpeg" SoundImageURL="images/WebResource.gif" /></div>

                 <asp:TextBox ID="txtcaptcha" autocomplete="off" runat="server" placeholder="Captcha" class="form-control"></asp:TextBox>
                 <div>
            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
            ControlToValidate="txtcaptcha" ValidationGroup="feedback" ErrorMessage="Enter valid captcha.." ForeColor="red" />
                </div>
                <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="feedback" Text="Submit" OnClick="BtnSubmit_Click" OnClientClick="return getPass();" />
           </div>
        </div>
</div>
    </div>
    </div>
                </div>
            </div>
    </div>
    
</asp:Content>

