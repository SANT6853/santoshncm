﻿<%@ Page Title="NTCA:Banner Edit" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="BannerEdit.aspx.cs" Inherits="auth_Adminpanel_Banner_BannerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<style>
.control-label{
text-align:left !important;
}
</style>
   <%-- <script src="../assets/js/vendor/bootstrap.min.js"></script>--%>
    <script language="JavaScript" type="text/javascript">
        function checkfilesize(source, arguments) {
            arguments.IsValid = false;

            var axo = new ActiveXObject("Scripting.FileSystemObject");
            thefile = axo.getFile(arguments.Value);
            var size = thefile.size;
            if (size > 3145728) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }


        }
        function checkfilesize1(source, arguments) {
            arguments.IsValid = false;

            var axo = new ActiveXObject("Scripting.FileSystemObject");
            thefile = axo.getFile(arguments.Value);
            var size = thefile.size;
            if (size > 3145728) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }


        }

        function ValidateFileUpload1(Source, args) {
            var fuData = document.getElementById('<%= ImageUploader.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                if (Extension == "jpg" || Extension == "JPG" || Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "PNG" || Extension == "swf" || Extension == "SWF") {
                    args.IsValid = true; // Valid file type
                }
                else {
                    args.IsValid = false; // Not valid file type
                }
            }
        }


        $(document).ready(function () {


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; min-height:550px; padding: 10px; background:#fff;">
    <div class="wrapper-content" style="padding-top:0px; min-height:550px;">
        <div class="row">
            <div class="col-lg-12">
                <div class="widgets-container">
				<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Edit Banner </h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                </div>
                  
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
					<div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Select Site</label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlwebsite" AutoPostBack="true" runat="server" CssClass="form-control"
                                    OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged" Enabled="False">
                                    <asp:ListItem Value="1">Mainsite</asp:ListItem>
                                    <asp:ListItem Value="2">Tiger Reserve</asp:ListItem>
                                </asp:DropDownList>


                            </div>
                        </div>
                        <div class="form-group" id="divstate" runat="server">
                            <label class="col-sm-3 control-label">State</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" Enabled="False">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="val"
                                    ErrorMessage="Select State" InitialValue="Select State" />
                            </div>
                        </div>

                        <div class="form-group" id="divTigerReserve" runat="server">
                            <label class="col-sm-3 control-label">Select Tiger Reserve</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlTigerReserve" runat="server" CssClass="form-control" Enabled="False">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="val"
                                    ErrorMessage="Select tiger reserve" InitialValue="Select Tiger Reserve" />
                            </div>

                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label">
                                Title<label style=" color:red;">*</label>
                            </label>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" autocomplete="off" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtTitle" ValidationGroup="val"
                                    ErrorMessage="Enter page title" ForeColor="Red" />

                                <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTitle"
                                    ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                    ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                                <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                    ControlToValidate="txtTitle" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                        </div>




                        <div class="form-group">
                            <label class="col-sm-3 control-label">
                                Upload Image<label style="color: red;">*</label>
                            </label>
                            <div class="col-sm-6">
                                <asp:FileUpload ID="ImageUploader" runat="server" />
                                <%--<asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload1"
                OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="ImageUploader"
                Display="Dynamic" ErrorMessage="Please select only .jpeg, .jpg, .png or .gif or swf image."
                ValidationGroup="Add" ForeColor="Red"></asp:CustomValidator>--%>
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload1"
                                    OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="ImageUploader"
                                    Display="Dynamic" ErrorMessage="Please select only .jpeg, .jpg, .png or .gif or .swf image."
                                    ValidationGroup="val" ForeColor="Red"></asp:CustomValidator>
                                <asp:Label ID="LblOldImage" runat="server" Text="Old Image:"></asp:Label>
                                <asp:Label ID="LblImage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                <br />
                                <em><span style="font-size: 8pt; font-weight: bold; color: #459300; font-family: Verdana">Tip: .jpeg .jpg .png or .gif or swf image only.For better resolution  height=336 width=1366 </span></em>

                            </div>


                        </div>


                        <div class="form-group">
                            <div class="col-sm-4 col-sm-offset-3">
                                <asp:Label ID="LblMsg" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Save" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnsave_Click" />
                                <asp:Button ID="btnBack" runat="server" ValidationGroup="val" Text="Back" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnBack_Click" />

                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

    <script>
        function extendedValidatorUpdateDisplay(obj) {
            // Appelle la méthode originale
            if (typeof originalValidatorUpdateDisplay === "function") {
                originalValidatorUpdateDisplay(obj);
            }

            // Récupère l'état du control (valide ou invalide) 
            // et ajoute ou enlève la classe has-error
            var control = document.getElementById(obj.controltovalidate);
            if (control) {
                var isValid = true;
                for (var i = 0; i < control.Validators.length; i += 1) {
                    if (!control.Validators[i].isvalid) {
                        isValid = false;
                        break;
                    }
                }

                if (isValid) {
                    $(control).closest(".form-group").removeClass("has-error");
                } else {
                    $(control).closest(".form-group").addClass("has-error");
                }
            }
        }

        // Remplace la méthode ValidatorUpdateDisplay
        var originalValidatorUpdateDisplay = window.ValidatorUpdateDisplay;
        window.ValidatorUpdateDisplay = extendedValidatorUpdateDisplay;
    </script>
</asp:Content>

