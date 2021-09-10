<%@ Page Title="NTCA:Add Tehshil" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddTehshil.aspx.cs" Inherits="auth_Adminpanel_District_Management_AddTehshil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/js/vendor/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">

    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="row">
                <div class="col-lg-12 top20 bottom20">
                    <div class="box box-primary1" style="margin-bottom: 25px;">
                        <div class="box-header with-border">
                            <h3 class="box-title" style="color: #005529;">Add Tehshil</h3>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                    </div>
                    <div class="">

                        <div class="form-horizontal">
                            <asp:HiddenField ID="hfpwd" runat="server" />
                            <div class="col-md-6" id="dvstate" runat="server" visible="false">
                                <div class="form-group">

                                    <label class="col-sm-3 control-label gtx">Select state</label>
                                    <div class="col-sm-6 input-group">
                                        <asp:DropDownList ID="DdlState" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DdlState_SelectedIndexChanged" ValidationGroup="val1"></asp:DropDownList>

                                            <label id="Lbl" style="color: red;"></label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">

                                    <label class="col-sm-3 control-label gtx">Select District<label style="color:red">*</label></label>
                                    <div class="col-sm-6 input-group">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" ValidationGroup="val1" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlDistrict" ValidationGroup="val1"
                                            ErrorMessage="Select district" InitialValue="Select District" ForeColor="Red" />
                                        <label id="lbldistrict" style="color: red;"></label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label gtx">
                                        Tehshil Name<label style="color:red">*</label>
                                    </label>
                                    <div class="col-sm-6 input-group">
                                        <asp:TextBox ID="txtTehshilName" runat="server" autocomplete="off" CssClass="form-control" MaxLength="50" ValidationGroup="val1"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtTehshilName" ValidationGroup="val1"
                                            ErrorMessage="Please enter tehshil Name" ForeColor="Red" />

                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTehshilName"
                                            ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                            ValidationGroup="val1" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                                        <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="it should be accept only Alphabets with some special characters like space and dot."
                                            ControlToValidate="txtTehshilName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val1"
                                            ValidationExpression="^[0-9a-zA-Z\. ]+$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ControlToValidate="txtTehshilName"
                                            ValidationExpression="[a-zA-Z ]*$" ValidationGroup="val1" ErrorMessage="Only Alphabets and space are allow." />
                                    </div>

                                </div>
                            </div>
                            <div class="clearfix"></div>

                            <div class="col-md-6 ">
                                <div class="form-group">
                                    <div class="col-sm-3 "></div>
                                    <div class="col-sm-6 input-group" style="margin-bottom: 25px;">

                                        <asp:Button ID="btnsave" runat="server" ValidationGroup="val1" Text="Submit" OnClientClick="return ValidateDropDown();" CssClass="btn btn-primary" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnBack" runat="server" Visible="false" Text="Back" CssClass="btn btn-primary" OnClick="btnBack_Click" />


                                    </div>
                                </div>
                            </div>
                            <!--<div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2 pdd5">
                                   
                                    
                                </div>
                            </div>-->
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
    <script type="text/javascript">
        function ValidateDropDown() {
            // alert('fd');
            $('#Lbl').html('');
            $('#lbldistrict').html('');
            var cmbID = "<%=DdlState.ClientID %>";
             var vddlDistrict = "<%=ddlDistrict.ClientID %>";
             //  alert($('#' + cmbID).val());

             if ($('#' + cmbID).val() == "Select State") {
                 //  alert("Please select State");
                 $('#Lbl').html('Please select State');
                 return false;
             }
             if ($('#' + vddlDistrict).val() == "No Record") {
                 //  alert("Please select State");
                 $('#lbldistrict').html('Please select district');
                 return false;
             }
             if ($('#' + vddlDistrict).val() == "Select District") {
                 //  alert("Please select State");
                 $('#lbldistrict').html('Please select district');
                 return false;
             }
             return true;
         }
    </script>
</asp:Content>

