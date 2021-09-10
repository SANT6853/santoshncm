<%@ Page Title="NTCA:Edit Tehshil" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="EditTehshil.aspx.cs" Inherits="auth_Adminpanel_District_Management_EditTehshil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.form-horizontal .control-label {
   
    text-align: left !important;
}
</style>
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
       <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
        <div class="row">
            <div class="col-lg-12 ">
                <div class="widgets-container">
                    
                     
					<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Edit Tehshil</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                </div>
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Select District<label style="color:red">*</label></label>
                            <div class="col-sm-3">
                               <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control">

                               </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlDistrict" ValidationGroup="val" 
                                    ErrorMessage="Select district" InitialValue="Select District" />
                            </div>
                        </div>
                       
                   
                      
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Tehshil Name<label style="color:red">*</label>
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtTehshilName" runat="server" CssClass="form-control" MaxLength="50" ValidationGroup="val"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtTehshilName"  ValidationGroup="val" 
                                    ErrorMessage="Please enter District Name" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTehshilName"
                                ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="it should be accept only Alphabets with some special characters like space and dot."
                                ControlToValidate="txtTehshilName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^[0-9a-zA-Z\. ]+$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                            

                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Submit"  CssClass="btn btn-primary" OnClick="btnsave_Click" />
                                    <asp:Button ID="btnBack" runat="server" ValidationGroup="val22" Text="Back"  CssClass="btn btn-primary" OnClick="btnBack_Click" />
                                    
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

