<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddPhotoGallery.aspx.cs" Inherits="auth_Adminpanel_PhotoGallery_AddPhotoGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <h5>All form elements </h5>
                    <hr>
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
                        
                        <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">State</label>
                            <div class="col-sm-9">
                               <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">

                               </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="val" 
                                    ErrorMessage="Select State" InitialValue="Select State" />
                            </div>
                        </div>
                       </div>
                       
                       <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Select Tiger Reserve</label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlTigerReserve" runat="server"  CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTigerReserve_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="val" 
                                    ErrorMessage="Select tiger reserve" InitialValue="Select Tiger Reserve"/>
                            </div>
                           
                        </div>
                        </div>
                        
                        <div class="col-md-6">
                         <div class="form-group">
                            <label class="col-sm-3 control-label">Select Photo Category</label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control">
                                 </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlcategory" ValidationGroup="val" 
                                    ErrorMessage="Select Category" InitialValue="Select Category"/>
                            </div>
                           
                        </div>
                        </div>
                          
                          <div class="col-md-6">
                         <div class="form-group">
                            <label class="col-sm-3 control-label">Photo Name
                            </label>
                            <div class="col-sm-9"> 
                                <asp:TextBox ID="txtPhotoName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtPhotoName"  ValidationGroup="val" 
                                    ErrorMessage="Enter photo name" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPhotoName"
                                ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtPhotoName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                        
                            <div class="col-md-6">
                            <div class="form-group">
                            <label class="col-sm-3 control-label">Photo Name in Hindi
                            </label>
                            <div class="col-sm-9"> 
                                <asp:TextBox ID="txtPhotoNameHindi" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtPhotoNameHindi"  ValidationGroup="val" 
                                    ErrorMessage="Enter photo name in hindi" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPhotoNameHindi"
                                ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{2,100}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtPhotoNameHindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                        
                        
                        <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Photo Description
                            </label>
                            <div class="col-sm-9"> 
                                <asp:TextBox ID="txtPhotoDescription" runat="server" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtPhotoDescription"  ValidationGroup="val" 
                                    ErrorMessage="Enter photo name in hindi" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPhotoDescription"
                                ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{2,1000}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtPhotoDescription" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                        
                        <div class="col-md-6">
                         <div class="form-group">
                            <label class="col-sm-3 control-label">Photo Description in Hindi
                            </label>
                            <div class="col-sm-9"> 
                                <asp:TextBox ID="txtPhotoDescriptionHindi" runat="server" CssClass="form-control" MaxLength="1000"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtPhotoDescriptionHindi"  ValidationGroup="val" 
                                    ErrorMessage="Enter photo description in hindi" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPhotoDescriptionHindi"
                                ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{2,1000}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtPhotoDescriptionHindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                        <div class="col-md-6">
                         <div class="form-group">
                            <label class="col-sm-3 control-label">Photo Alt Tag
                            </label>
                            <div class="col-sm-9"> 
                                                   <asp:TextBox ID="txtAlttag" runat="server" CssClass="form-control"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                        ControlToValidate="txtAlttag" Display="Dynamic" 
                        ErrorMessage="Please Enter AltTag" SetFocusOnError="True" ValidationGroup="val">
                </asp:RequiredFieldValidator>

                  <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Min 4 Character, special charecter number Not allow"
                    ControlToValidate="txtAlttag" ValidationGroup="val"  ValidationExpression="[A-Za-z][A-Za-z ]{3,1000}"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                       <div class="col-md-6">
                         <div class="form-group">
                            <label class="col-sm-3 control-label">Photo Alt Tag in Hindi
                            </label>
                            <div class="col-sm-9"> 
                                                   <asp:TextBox ID="txtAlttagHindi" runat="server" CssClass="form-control"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtAlttagHindi" Display="Dynamic" 
                        ErrorMessage="Please Enter AltTag" SetFocusOnError="True" ValidationGroup="val">
                </asp:RequiredFieldValidator>

                  <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Min 4 Character, special charecter number Not allow"
                    ControlToValidate="txtAlttagHindi" ValidationGroup="val"  ValidationExpression="[A-Za-z][A-Za-z ]{3,1000}"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                        
                        <div class="col-md-6">
                       <div class="form-group">
                            <label class="col-sm-3 control-label">Photo 
                            </label>
                            <div class="col-sm-9"> 
                                                   <asp:FileUpload ID="ImageUploader" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredImage" runat="server" ControlToValidate="ImageUploader"
                    Display="Dynamic" ErrorMessage="Please Enter Image" SetFocusOnError="True" ValidationGroup="val">
                </asp:RequiredFieldValidator>
                    <%-- <asp:CustomValidator ID="FileSizeValidator" runat="server" ControlToValidate="ImageUploader" ClientValidationFunction="FileSizeValidator"
                ErrorMessage="Image size should not be greater than 1 MB" OnServerValidate="FileSizeValidator_ServerValidate"
                ValidationGroup="1" Display="Dynamic">
            </asp:CustomValidator>--%>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" 
                        ClientValidationFunction="ValidateFileUpload" ControlToValidate="ImageUploader" 
                        Display="Dynamic" 
                        ErrorMessage="Please select only .jpeg, .jpg, .png or .gif image." 
                        OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="val">
                </asp:CustomValidator>
                            </div>

                        </div>
                        </div>
                            
                            <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-1">
                                    <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Save" OnClientClick="return getPass();" CssClass="btn aqua" OnClick="btnsave_Click" />
                                    <asp:Button ID="btnBack" runat="server" ValidationGroup="val" Text="Back" OnClientClick="return getPass();" CssClass="btn aqua" OnClick="btnBack_Click" />
                                    
                                </div>
                            </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
   <%-- <script src="../assets/js/vendor/bootstrap.min.js"></script>
    <!--  morris Charts  -->
    <!-- js for print and download -->
    <script type="text/javascript" src="../assets/js/vendor/vfs_fonts.js"></script>
    <script src="../assets/js/vendor/chartJs/Chart.bundle.js"></script>
    <script src="../assets/js/dashboard1.js"></script>
    <!-- slimscroll js -->
    <script type="text/javascript" src="../assets/js/vendor/jquery.slimscroll.js"></script>
    <!-- main js -->
    <script src="../assets/js/main.js"></script>--%>
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

