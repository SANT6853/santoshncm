<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddEdit.aspx.cs" Inherits="auth_Adminpanel_HomePageContent_AddEdit" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <h5>All form elements </h5>
                    <hr>
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
                        <div class="form-group">
                            <label class="col-sm-2 control-label">State</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="val"
                                    ErrorMessage="Select State" InitialValue="Select State" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Select Tiger Reserve</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlTigerReserve" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="val"
                                    ErrorMessage="Select tiger reserve" InitialValue="Select Tiger Reserve" />
                            </div>

                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Title
                            </label>
                            <div class="col-sm-3">
                                 <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" BasePath="~/fckeditor/"
                                Height="730" Width="675">
                            </FCKeditorV2:FCKeditor>
                            </div>

                        </div>




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
