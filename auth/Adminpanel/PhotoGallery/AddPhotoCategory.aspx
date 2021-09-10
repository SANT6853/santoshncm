<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddPhotoCategory.aspx.cs" Inherits="auth_Adminpanel_PhotoGallery_AddPhotoCategory" %>

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
                                <asp:DropDownList ID="ddlTigerReserve" runat="server"  CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="val" 
                                    ErrorMessage="Select tiger reserve" InitialValue="Select Tiger Reserve"/>
                            </div>
                           
                        </div>
                        </div>
                         
                         <div class="col-md-6">
                         <div class="form-group">
                            <label class="col-sm-3 control-label">Category Name
                            </label>
                            <div class="col-sm-9"> 
                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtCategoryName"  ValidationGroup="val" 
                                    ErrorMessage="Enter category name" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCategoryName"
                                ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtCategoryName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                        
                            <div class="col-md-6">
                            <div class="form-group">
                            <label class="col-sm-3 control-label">Category Name in Hindi
                            </label>
                            <div class="col-sm-9"> 
                                <asp:TextBox ID="txtCategoryNameHindi" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtCategoryNameHindi"  ValidationGroup="val" 
                                    ErrorMessage="Enter category name in hindi" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtCategoryNameHindi"
                                ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{2,100}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtCategoryNameHindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                            
                            <div class="col-md-9">
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
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

