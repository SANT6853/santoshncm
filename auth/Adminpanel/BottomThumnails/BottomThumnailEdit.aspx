<%@ Page Title="NTCA:Edit bottom thumnail" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="BottomThumnailEdit.aspx.cs" Inherits="auth_Adminpanel_BottomThumnails_BottomThumnailEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <%--  <script src="../assets/js/vendor/bootstrap.min.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
      <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <h5>Edit bottom thumnail </h5>
                    <hr>
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
                        
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Select Site</label>
                            <div class="col-md-3">
                               <asp:DropDownList ID="ddlwebsite" AutoPostBack="true" runat="server" CssClass="form-control" 
                                    onselectedindexchanged="ddlwebsite_SelectedIndexChanged" Enabled="False">
                               <asp:ListItem Value="1">Mainsite</asp:ListItem>
                                <asp:ListItem Value="2">Tiger Reserve</asp:ListItem>
                               </asp:DropDownList>
                               
                            
                        </div>
                        </div>
                        <div class="form-group" id="divstate" runat="server">
                            <label class="col-sm-2 control-label">State</label>
                            <div class="col-sm-3">
                               <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" Enabled="False">

                               </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="val" 
                                    ErrorMessage="Select State" InitialValue="Select State" />
                            </div>
                        </div>
                       
                        <div class="form-group" id="divTigerReserve" runat="server">
                            <label class="col-sm-2 control-label">Select Tiger Reserve</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlTigerReserve" runat="server"  CssClass="form-control" Enabled="False">

                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="val" 
                                    ErrorMessage="Select tiger reserve" InitialValue="Select Tiger Reserve"/>
                            </div>
                           
                        </div>
                      
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Title
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtTitle"  ValidationGroup="val" 
                                    ErrorMessage="Enter page title" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTitle"
                                ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtTitle" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>
                                                 <div class="form-group">
                            <label class="col-sm-2 control-label">Title in Hindi
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtTitleHindi" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtTitleHindi"  ValidationGroup="val" 
                                    ErrorMessage="Enter page title" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTitleHindi"
                                ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{2,100}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtTitleHindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                            </div>

                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label">Alternate Tag
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtAltTag" runat="server" CssClass="form-control" MaxLength="50" ></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RevBrowserTitle" runat="server" ErrorMessage="Please enter browser title with one of the following special characters:(&/:'_-)"
                                ControlToValidate="txtAltTag" ValidationExpression="[\u0900-\u097F0-9a-zA-Z\s&/:'_-]+"
                                ValidationGroup="val" Display="Dynamic"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtAltTag"
                                ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required."></asp:RegularExpressionValidator>

                            </div>
                            

                        </div>
                                                <div class="form-group">
                            <label class="col-sm-2 control-label">Alternate Tag in Hindi
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtAltTagHindi" runat="server" CssClass="form-control" MaxLength="100" ></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter browser title with one of the following special characters:(&/:'_-)"
                                ControlToValidate="txtAltTagHindi" ValidationExpression="[\u0900-\u097F0-9a-zA-Z\s&/:'_-]+"
                                ValidationGroup="val" Display="Dynamic"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtAltTagHindi"
                                ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{2,100}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required."></asp:RegularExpressionValidator>

                            </div>
                            

                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Upload Image
                            </label>
                            <div class="col-sm-3"> 
                                 <asp:FileUpload ID="ImageUploader" runat="server" />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload"
                OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="ImageUploader"
                Display="Dynamic" ErrorMessage="Please select only .jpeg, .jpg, .png or .gif image."
                ValidationGroup="Add">
            </asp:CustomValidator>
            <asp:Label ID="LblOldImage" runat="server" Text="Old Image:"></asp:Label>
            <asp:Label ID="LblImage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
            <br />
            <em><span style="font-size: 8pt; font-weight: bold; color: #459300; font-family: Verdana">
                Tip: .jpeg .jpg .png or .gif image only. </span></em>

                            </div>
                            

                        </div>
                      <div class="form-group">
                            <label class="col-sm-2 control-label"> link url name:
                            </label>
                            <div class="col-sm-3"> 
                                  <asp:TextBox ID="txtLinkUrl" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                                        <em><span style="font-size: 8pt; color: #459300; font-weight: bold; font-family: Verdana">Tip:-http://www.abc.com </span></em>
                                        <asp:RegularExpressionValidator ID="RevLinkUrl" runat="server" ControlToValidate="txtLinkUrl"
                                            Display="Dynamic" ErrorMessage="Please enter valid url" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                            ValidationGroup="val" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <%--<asp:RequiredFieldValidator ID="RfvUrlName" runat="server" ControlToValidate="txtLinkUrl"
                                            ErrorMessage="Enter link url name" ValidationGroup="val" Display="Dynamic" class="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                            ControlToValidate="txtLinkUrl" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
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
    
    <%--<script>
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
        </script>--%>
</asp:Content>

