<%@ Page Title="Edit Profile:NTCA" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="EditProfile.aspx.cs" Inherits="auth_Adminpanel_EditProfile" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .frm_row span.label1 {
            width: 163px;
            float: none;
            font-size: 100%;
        }

        .frm_row span.input1 {
            width: 260px;
            float: none;
            display: block;
        }

        .text3 {
            color: red;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#dvEmailid').click(function () {
                //alert('fd');
                $('#<%= TxtEmail.ClientID %>').focus();
            });
            $('#dvName').click(function () {
                //alert('fd');
                $('#<%= TxtFName.ClientID %>').focus();
            });
            $('#dvLastname').click(function () {
                //alert('fd');----
                $('#<%= TxtLastName.ClientID %>').focus();
            });
            $('#dvMobile').click(function () {
                //alert('fd');---
                $('#<%= TxtMobile.ClientID %>').focus();
            });
            $('#dvLandLine').click(function () {
                //alert('fd');---
                $('#<%= TxtLandline.ClientID %>').focus();
            });
            $('#dvAddress1').click(function () {
                //alert('fd');
                $('#<%= TxtAddress1.ClientID %>').focus();
            });
            $('#dvAddress2').click(function () {
               // alert('fd');
                $('#<%= TxtAddress2.ClientID %>').focus();
              });
            $('#dvPincode').click(function () {
                //alert('fd');---
                $('#<%= TxtPincode.ClientID %>').focus();
            });
            $('#dvUserName').click(function () {
                //alert('fd');---
                $('#<%= TxtEmail.ClientID %>').focus();
            });
            $('#dvTxtAreaCode').click(function () {
                //alert('fd');
                $('#<%= TxtAreaCode.ClientID %>').focus();
            });
            //-----------
            $('#<%= btnupdate.ClientID %>').click(function () {
                // alert("Please enter username");TxtLandline

                if ($('#<%= TxtPincode.ClientID %>').val() == "000000")
                {
                    alert("Your pincode is not valid!.");
                    $('#<%= TxtPincode.ClientID %>').focus();
                    return false;
                }
                if ($('#<%= TxtAreaCode.ClientID %>').val() == "0000") {
                    alert("Your AreaCode is not valid!.");
                    $('#<%= TxtAreaCode.ClientID %>').focus();
                    return false;
                }
                if ($('#<%= TxtLandline.ClientID %>').val() == "0000000000") {
                    alert("Your Landline is not valid!.");
                    $('#<%= TxtLandline.ClientID %>').focus();
                    return false;
                }
                if ($('#<%= TxtMobile.ClientID %>').val() == "0000000000") {
                    alert("Your Mobile is not valid!.");
                    $('#<%= TxtMobile.ClientID %>').focus();
                    return false;
                }

                return true;
              });

        });
    </script>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content">
            <div class="row">
                <div class="col-lg-12  bottom20">
                    <div class="box box-primary1" style="margin-bottom: 25px;">
                        <div class="box-header with-border">
                            <h3 class="box-title" style="color: #005529;">Edit Profile</h3>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                    </div>


                    <div class="feedback">
                        <!--start-->
                        <div class="widgets-container">

                            <div id="" class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                    <div id="dvUserName">
                                        <label class="col-md-4 control-label gtx label1">Username: <strong class="text3">* </strong></label>
                                    </div>
                                    <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtUsername" runat="server" autocomplete="off" CssClass="input_class form-control" MaxLength="40"></asp:TextBox></span>
                                        <span class="validation">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtUsername"
                                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="Editprofile" ErrorMessage="Please Enter UserName" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RevName" ValidationGroup="Editprofile" runat="server" ErrorMessage="  Minmum 3 character required(allowed only . and _ and should start with an alphabet) "
                                                ControlToValidate="TxtUsername" Display="Dynamic" ValidationExpression="[A-Za-z][A-Za-z0-9._]{2,14}" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                </div>
                            </div>



                            <div class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                   <div id="dvEmailid"><label class="col-md-4 control-label gtx">Email id: <strong class="text3">* </strong></label>
                                    </div> 
                                       <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtEmail" runat="server" autocomplete="off" CssClass="input_class form-control" MaxLength="50"></asp:TextBox></span>
                                        <em><span style="font-size: 8pt; color: #459300; font-weight: bold; font-family: Verdana">Tip:-abc@gmail.com</span></em>
                                        <span class="validation">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtEmail"
                                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="Editprofile" ErrorMessage="Please Enter Email-Id" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="regularexp"
                                                ControlToValidate="TxtEmail" Display="Dynamic" Text="Please enter valid e-mail id eg. abc@xyz.com."
                                                ValidationGroup="Editprofile" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator></span>
                                    </div>
                                </div>
                            </div>






                            <div id="" class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                   <div id="dvName"><label class="col-md-4 control-label gtx label1">Name:<strong class="text3">* </strong></label>
                                   </div> 
                                        <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtFName" autocomplete="off" runat="server" CssClass="input_class form-control" MaxLength="100"></asp:TextBox></span>

                                        <span class="validation">

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtFName"
                                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="Editprofile" ErrorMessage="Please Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtFName"
                                                Display="Dynamic" ErrorMessage="only alphabets are allowed" SetFocusOnError="True"
                                                ValidationExpression="^[a-zA-Z\s.]*$" ValidationGroup="Editprofile" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                </div>
                            </div>



                            <div id="" class="col-md-6" style="padding-left: 0px; display: none;">
                                <div class="form-group">
                                  <div id="dvLastname">  <label class="col-md-4 control-label gtx label1">Last Name:<strong class="text3"></strong></label></span> </label>
									</div>
                                      <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtLastName" autocomplete="off" runat="server" CssClass="input_class form-control" MaxLength="100"></asp:TextBox></span>

                                        <span class="validation">


                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TxtLastName"
                                                Display="Dynamic" ErrorMessage="only alphabets are allowed" SetFocusOnError="True"
                                                ValidationExpression="^[a-zA-Z\s.]*$" ValidationGroup="Editprofile" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                </div>
                            </div>



                            <div id="" class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                  <div id="dvMobile">  <label class="col-md-4 control-label gtx label1">Mobile No: <strong class="text3">* </strong></label>
                                   </div>
                                       <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtMobile" autocomplete="off" runat="server" CssClass="input_class form-control" MaxLength="10"></asp:TextBox>

                                            <asp:FilteredTextBoxExtender ID="filText" runat="server" FilterType="Numbers" TargetControlID="TxtMobile"></asp:FilteredTextBoxExtender>
                                        </span>
                                        <span class="validation">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtMobile"
                                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="Editprofile" ErrorMessage="Please Enter Contact Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TxtMobile"
                                                ValidationGroup="Editprofile" Display="Dynamic" ErrorMessage="Please enter 10 digits number"
                                                CssClass="validation" ValidationExpression="\d{10,10}" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                </div>
                            </div>

                            <div id="" class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                   <div id="dvTxtAreaCode"> <label class="col-md-4 control-label gtx label1">AreaCode:<strong class="text3"></strong></label>
									</div>
                                       <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtAreaCode" autocomplete="off" runat="server" CssClass="input_class form-control" MaxLength="4"></asp:TextBox></span>

                                        <span class="validation">



                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TxtAreaCode"
                                                Display="Dynamic" ErrorMessage="Please Enter Only Numbers" SetFocusOnError="True"
                                                ValidationExpression="^\d+$" ValidationGroup="Editprofile" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                </div>
                            </div>
                            <div id="" class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                   <div id="dvLandLine"> <label class="col-md-4 control-label gtx label1">Landline:<strong class="text3"></strong></label></span></label>
									</div>
                                       <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtLandline" autocomplete="off" runat="server" CssClass="input_class form-control" MaxLength="10"></asp:TextBox></span>

                                        <span class="validation">



                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="TxtLandline"
                                                Display="Dynamic" ErrorMessage="Please Enter Only Numbers" SetFocusOnError="True"
                                                ValidationExpression="^\d+$" ValidationGroup="Editprofile" ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                </div>
                            </div>



                            <div id="" class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                   <div id="dvAddress1"> <label class="col-md-4 control-label gtx label1">Address1:<strong class="text3">* </strong></label>
                                   </div>
                                        <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtAddress1" autocomplete="off" runat="server" CssClass="textarea_class form-control" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                                        </span>

                                        <span class="validation">

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtAddress1"
                                                Display="Dynamic" SetFocusOnError="True" ValidationGroup="Editprofile" ErrorMessage="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>

                                            <asp:RegularExpressionValidator ID="regAddress" runat="server" ErrorMessage="Enter only alphanumeric values and ( * - , / () : _ ) special characters."
                                                ControlToValidate="TxtAddress1" Display="Dynamic" SetFocusOnError="true" ValidationGroup="Editprofile"
                                                ValidationExpression="^([A-Za-z0-9-* - _'.,:()/\s]*)$" ForeColor="Red"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TxtAddress1" SetFocusOnError="true"
                                                ID="regAddressLength" ValidationExpression="^[\s\S]{10,200}$" runat="server" ValidationGroup="Editprofile"
                                                ErrorMessage="Minimum 10 and maximum 200 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                </div>
                            </div>



                            <div id="" class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                  <div id="dvAddress2">  <label class="col-md-4 control-label gtx label1">Address2:<strong class="text3"> </strong></label>
                                   </div>
                                       <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtAddress2" autocomplete="off" runat="server" CssClass="textarea_class form-control" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                                        </span>

                                        <span class="validation">



                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Enter only alphanumeric values and ( * - , / () : _ ) special characters."
                                                ControlToValidate="TxtAddress2" Display="Dynamic" SetFocusOnError="true" ValidationGroup="Editprofile"
                                                ValidationExpression="^([A-Za-z0-9-* - _'.,:()/\s]*)$" ForeColor="Red"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TxtAddress2" SetFocusOnError="true"
                                                ID="RegularExpressionValidator8" ValidationExpression="^[\s\S]{10,200}$" runat="server" ValidationGroup="Editprofile"
                                                ErrorMessage="Minimum 10 and maximum 200 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                                        </span>
                                    </div>

                                </div>
                            </div>



                            <div id="" class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                    <div id="dvPincode"><label class="col-md-4 control-label gtx label1">Pincode:<strong class="text3"></strong></label></span> </label>
									</div>
                                        <div class="col-md-6 input-group">
                                        <span class="input1">
                                            <asp:TextBox ID="TxtPincode" autocomplete="off" runat="server" CssClass="input_class form-control" MaxLength="6"></asp:TextBox></span>

                                        <span class="validation">


                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtPincode"
                                                Display="Dynamic" ErrorMessage="Pin code must be 6 numeric digits" SetFocusOnError="True"
                                                ValidationExpression="\d{6}" ValidationGroup="Editprofile" ForeColor="Red"></asp:RegularExpressionValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtPincode"
                                                Display="Dynamic" ErrorMessage="Please Enter Only Numbers" SetFocusOnError="True"
                                                ValidationExpression="^\d+$" ValidationGroup="Editprofile" ForeColor="Red"></asp:RegularExpressionValidator>
                                            
                                        </span>
                                    </div>

                                </div>
                            </div>




                            




                            <br />
                            <br />
							
							<div class="col-md-7 pull-right">
                                <asp:Label ID="LblPincodeMsg" runat="server" ForeColor="Red"></asp:Label>
                                <span class="button_row">
                                    <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click"
                                        CssClass="button btn btn-primary" ValidationGroup="Editprofile" />
                                    <asp:Button ID="BtnReset" CssClass="button btn btn-primary" CausesValidation="false" runat="server" Text="Reset" OnClick="BtnReset_Click" />

                                </span>

                                <div class="clear"></div>
                            </div>






                        </div>
                        <!--end-->








































                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

