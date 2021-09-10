<%@ Page Title="NTCA:Add District" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddDistrict.aspx.cs" Inherits="auth_Adminpanel_District_Management_AddDistrict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
     <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <h5>Add District </h5>
                    <hr>
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
                        <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">State</label>
                            <div class="col-sm-9">
                               <asp:DropDownList ID="ddlState"  runat="server" CssClass="form-control">

                               </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="val" 
                                    ErrorMessage="Select State" InitialValue="Select State" />
                            </div>
                        </div>
                        </div>
                       
                   
                         <div class="col-md-6">
                         <div class="form-group">
                            <label class="col-sm-3 control-label">District Name
                            </label>
                            <div class="col-sm-9"> 
                                <asp:TextBox ID="txtDistrictName" runat="server" CssClass="form-control" MaxLength="50" ValidationGroup="val"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtDistrictName"  ValidationGroup="val" 
                                    ErrorMessage="Please enter District Name" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtDistrictName"
                                ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="it should be accept only Alphabets with some special characters like space and dot."
                                ControlToValidate="txtDistrictName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^[0-9a-zA-Z\. ]+$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                        </div>
                            
                            <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2 pdd5">
                                    <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Save"  CssClass="btn aqua" OnClick="btnsave_Click" />
                                    <asp:Button ID="btnBack" runat="server" Visible="false" ValidationGroup="val" Text="Back" CssClass="btn aqua" OnClick="btnBack_Click" />
                                    
                                </div>
                            </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
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

