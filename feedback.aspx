<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/MainsiteMiddleContent.master" AutoEventWireup="true" CodeFile="feedback.aspx.cs" Inherits="feedback" %>

<%@ Register Assembly="ncmcaptcha" Namespace="ncmcaptcha" TagPrefix="Captcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        #CaptchDiv div a {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $(window).load(function () {
            $('#<%= TxtName.ClientID %>').focus();

        });
        $(document).ready(function () {

            $('#YourName').click(function () {
                $('#<%= TxtName.ClientID %>').focus();
            });
            $('#YourEmail').click(function () {
                $('#<%= TxtEmail.ClientID %>').focus();
            });
            $('#YourPhone').click(function () {
                $('#<%= TxtPhone.ClientID %>').focus();
            });
            $('#State').click(function () {
                $('#<%= ddlstate.ClientID %>').focus();
            });
            $('#Feedbackfrom').click(function () {
                $('#<%= DdlFeedBackFrom.ClientID %>').focus();
            });
            $('#WriteAddress').click(function () {
                $('#<%= TxtAddress.ClientID %>').focus();
            });
            $('#YourMessage').click(function () {
                $('#<%= TxtMessage.ClientID %>').focus();
            });

        });

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31
              && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        //-->


        function getPass() {

             <%-- var capvalue = document.getElementById('<%=txtcaptcha.ClientID%>').value;
             if (capvalue == '')
             {
            alert('Please enter Captcha Code');
            document.getElementById('<%=txtcaptcha.ClientID%>').focus();
            return false;--%>
         }




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">



    <%--<link href="css/style.css" rel="stylesheet" />
    <div class="col-md-12">

        </div>--%>

    <div class="col-sm-9">
        <div class="cenn">
            <div class="col-md-7 cen2">
                <h3>Feedback Form</h3>
                <div class="col-sm-12 regleft">
                    <label for="fnamesss" class="col-sm-6">(All *fields are mandatory!.)</label><br />
					<!--<a href="/NTCA_MIS/Maincontent/2074_2_ContactUs.aspx"	> click</a>	-->
                </div>

                <div class="col-sm-12 regleft">
                    <label id="YourName" for="fname" class="col-sm-3">Your Name<span style="color: red;">*</span></label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TxtName" autocomplete="off" MaxLength="150" runat="server" placeholder="Your name.." ValidationGroup="feedback"></asp:TextBox>
                        <div>
                            <asp:RegularExpressionValidator ID="regAddress" runat="server" ErrorMessage="Enter only alphanumeric values and ( * - , / () : _ .space) special characters."
                                ControlToValidate="TxtName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="feedback"
                                ValidationExpression="^([A-Za-z0-9-* - _'.,:()/\s]*)$" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
                                ControlToValidate="TxtName" ValidationGroup="feedback" ErrorMessage="Enter Your name.." ForeColor="red" />
                        </div>
                    </div>
                </div>


                <div class="col-sm-12 regleft">

                    <label id="YourEmail" for="Lemail" class="col-sm-3">Your Email<span style="color: red;">*</span></label>

                    <div class="col-sm-9">
                        <asp:TextBox ID="TxtEmail" autocomplete="off" runat="server" MaxLength="150" placeholder="Your email.."></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
                                ControlToValidate="TxtEmail" ValidationGroup="feedback" ErrorMessage="Enter Your email.." ForeColor="red" />
                            <asp:RegularExpressionValidator ID="validateEmail" Display="Dynamic"
                                runat="server" ErrorMessage="Invalid email." ValidationGroup="feedback"
                                ControlToValidate="TxtEmail"
                                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ForeColor="Red" />
                        </div>
                    </div>

                </div>



                <div class="col-sm-12 regleft">
                    <label id="YourPhone" for="LPhone" class="col-sm-3">Your Phone<span style="color: red;">*</span></label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="TxtPhone" autocomplete="off" runat="server" MaxLength="10" placeholder="Your Phone.." onkeypress="return isNumberKey(event)"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
                                ControlToValidate="TxtPhone" ValidationGroup="feedback" ErrorMessage="Enter Your phone.." ForeColor="red" />
                            <asp:RegularExpressionValidator Display="Dynamic" ValidationGroup="feedback" ControlToValidate="TxtPhone" ForeColor="Red" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{7,10}$" runat="server" ErrorMessage="Your phone will be Minimum 7 and Maximum 10 characters required."></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtPhone" ForeColor="Red"
                                ErrorMessage="Please Enter Only Numbers" ValidationGroup="feedback" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>


                        </div>
                    </div>
                </div>



                <div class="col-sm-12 regleft">
                    <label id="State" for="LState" class="col-sm-3">State<span style="color: red;">*</span></label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList>
                        <div>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ForeColor="red"
                                InitialValue="0" ControlToValidate="ddlstate" ValidationGroup="feedback" ErrorMessage="Select state" />
                        </div>
                    </div>
                </div>
               
                <div class="col-sm-12 regleft">
                    <label id="Feedbackfrom" for="LState" class="col-sm-3">Feedback from<span style="color: red;">*</span></label>
                    <div class="col-sm-9">
                         <br />
                        <asp:DropDownList ID="DdlFeedBackFrom" runat="server">
                            <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Tiger reserve" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Public" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <div>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ForeColor="red"
                                InitialValue="0" ControlToValidate="DdlFeedBackFrom" ValidationGroup="feedback" ErrorMessage="Select feedback from" />
                        </div>
                    </div>
                </div>

                <div class="col-sm-12 regleft">
                    <label id="WriteAddress" for="LAddress" class="col-sm-3">Write Address</label>
                    <div class="col-sm-9">
                         <br />
                       <%-- <asp:TextBox ID="TxtAddress" autocomplete="off" Height="50px" MaxLength="250" runat="server" placeholder="Write Address.." Style="height: 50px" TextMode="MultiLine"></asp:TextBox>--%>
                        <textarea runat="server" id="TxtAddress" placeholder="Write message.."
                            maxlength="250" rows="4" cols="30"></textarea>
                    </div>
                </div>


                <div class="col-sm-12 regleft">
                    <label id="YourMessage" for="LMessage" class="col-sm-3">Your Message<span style="color: red;">*</span></label>
                    <div class="col-sm-9">
                        <%-- <asp:TextBox ID="TxtMessage" autocomplete="off" Height="100px" MaxLength="20" runat="server" placeholder="Write message.." TextMode="MultiLine" ></asp:TextBox>--%>
                        <%-- <textarea id="TxtAreaMessage" runat="server" MaxLength="550" name="TxtAreaMessage" placeholder="Write something.." style="height:200px"></textarea>--%>
                        <div>
                             <br />
                            <textarea runat="server" id="TxtMessage" placeholder="Write message.."
                                maxlength="250" rows="4" cols="30"></textarea>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
                                ControlToValidate="TxtMessage" ValidationGroup="feedback" ErrorMessage="Enter Your message.." ForeColor="red" />
                            <asp:RegularExpressionValidator Display="Dynamic" ValidationGroup="feedback" ControlToValidate="TxtMessage" ForeColor="Red" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{10,250}$" runat="server" ErrorMessage="Your message will be Minimum 10 and Maximum 250 characters required."></asp:RegularExpressionValidator>

                        </div>
                    </div>
                </div>


                <div class="col-sm-12 regleft">
                    <div class="col-sm-9 col-sm-offset-3">
                        <div class="form-group" id="CaptchDiv">
                             <br />
                            <Captcha:CaptchaControl ID="recaptcha" runat="server" CaptchaWidth="168" RefreshImageURL="images/images.jpeg" SoundImageURL="images/WebResource.gif" />

                        </div>

                        <asp:TextBox ID="txtcaptcha" autocomplete="off" runat="server" placeholder="Captcha" class="form-control"></asp:TextBox>
                        <div>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block"
                                ControlToValidate="txtcaptcha" ValidationGroup="feedback" ErrorMessage="Enter valid captcha.." ForeColor="red" />
                        </div>
                        <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="feedback" Text="Submit" OnClick="BtnSubmit_Click" OnClientClick="return getPass();" />
                        <div>
                            <asp:Label ID="LblMsg" runat="server" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

	
    <script type="text/jscript">

       


    </script>

</asp:Content>

