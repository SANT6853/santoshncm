<%@ Page Title="NTCA:Add Tiger reserve" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddTigerReserve.aspx.cs" Inherits="auth_Adminpanel_TigerReserve_AddTigerReserve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .lblColor {
            color: red;
        }

        .form-horizontal .control-label {
            padding-top: 7px;
            margin-bottom: 0;
            text-align: left;
        }

        .form-control {
            width: 70%;
        }
    </style>
    <script type="text/javascript" language="javascript">


        function validateData() {



            if ($('#<%= ddlstate.ClientID %>').val() == "0") {

                $('#<%= lblmsgst.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select State</span>");
                if ($('#<%= ddldist.ClientID %>').val() == "0") {

                    $('#<%= lblmsgds.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select district</span>");

                }
                if ($('#<%= txttigerreservename.ClientID %>').val() == "") {

                    $('#<%= Lbltxttigerreservename.ClientID %>').html("<span style='color:red; font-size:12px;'>Please enter tiger reserve name</span>");

                }
                if ($('#<%= txttigerreservenamehindi.ClientID %>').val() == "") {

                    $('#<%= Lbltxttigerreservenamehindi.ClientID %>').html("<span style='color:red;font-size:12px;'>Please enter tiger reserve name(HINDI)</span>");

                }
                return false;
            }
            if ($('#<%= txtnoofvillage.ClientID %>').val() == "000") {
                alert("No of Village is not valid!.");
                $('#<%= txtnoofvillage.ClientID %>').focus();
                return false;
            }



          <%--  if ($('#<%= ddldist.ClientID %>').val() == "0") {

                $('#<%= lblmsgds.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select district</span>");
                return false;
            }--%>
            return true;
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="widgets-container">

                        <div class="box box-primary1" style="margin-bottom: 25px;">
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;"><%=HeaderTitle %> </h3>
                            </div>

                        </div>
                        <div class="form-horizontal">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Tiger Reserve Name<label class="lblColor">*</label></label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txttigerreservename" autocomplete="off" MaxLength="200" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txttigerreservename" ValidationGroup="val"
                                            ErrorMessage="Please enter tiger reserve name" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txttigerreservename" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                        
                                            <asp:Label ID="Lbltxttigerreservename" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                       
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">Tiger Reserve Name(Hindi)<label class="lblColor">*</label></label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txttigerreservenamehindi" autocomplete="off" MaxLength="200" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txttigerreservenamehindi" ValidationGroup="val"
                                            ErrorMessage="Enter Tiger Reserve Name(Hindi)" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txttigerreservenamehindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                                       
                                            <asp:Label ID="Lbltxttigerreservenamehindi" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                        
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-sm-3 control-label">No of Village</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox ID="txtnoofvillage" autocomplete="off" runat="server" MaxLength="3" CssClass="form-control" />
                                            <asp:RegularExpressionValidator ID="RegularExpres" runat="server" CssClass="red-text-asterix " Font-Size="Small" ValidationGroup="val" Display="Dynamic" ControlToValidate="txtnoofvillage" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" ForeColor="Red" SetFocusOnError="True">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                       
                                    </div>

                                </div>
                            </div>
                      

                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Select State<label class="lblColor">*</label></label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="ddlstate" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator runat="server" InitialValue="0" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlstate" ValidationGroup="val"
                                    ErrorMessage="Select State" />--%>
                                    
                                        <asp:Label ID="lblmsgst" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                    
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <%--jhjhj--%>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Select District<label class="lblColor">*</label></label>
                                <div class="col-sm-9">
                                    <asp:DropDownList ID="ddldist" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddldist_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <%-- <asp:RequiredFieldValidator runat="server" InitialValue="0" Display="Dynamic" CssClass="help-block" ControlToValidate="ddldist" ValidationGroup="val"
                                    ErrorMessage="Select district" />--%>
                                   
                                        <asp:Label ID="lblmsgds" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                   
                                </div>
                            </div>
                        </div>
                        <%--gfgfg--%>

                        <div class="col-md-6" style="display: none;">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Upload Map</label>
                                <div class="col-sm-9">
                                    <asp:FileUpload ID="filemap" CssClass="form-control" runat="server" />

                                </div>
                                <!--<div class="col-sm-3">
                                <asp:Label ID="lblmap" runat="server" />

                            </div>-->
                            </div>
                        </div>

                        <div class="col-md-6" style="display: none;">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Core Area</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtcorearea" runat="server" CssClass="form-control" />
                                    <%-- <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtcorearea" ValidationGroup="val"
                                    ErrorMessage="Enter Core Area" />--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6" style="display: none;">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Buffer Area</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtbufferarea" runat="server" CssClass="form-control" />
                                    <%--<asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtbufferarea" ValidationGroup="val"
                                    ErrorMessage="Enter Buffer Area" />--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6" style="display: none;">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Longitude </label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control" />
                                    <%-- <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtLongitude" ValidationGroup="val"
                                        ErrorMessage="Enter Longitude" />--%>
                                </div>
                            </div>
                        </div>


                        <div class="col-md-6" style="display: none;">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Latitude </label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control" />
                                    <%--   <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtLatitude" ValidationGroup="val"
                                        ErrorMessage="Enter Latitude" />--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-sm-11 text-center">
                                    <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Save" OnClientClick="return validateData();" CssClass="btn btn-primary" OnClick="btnsave_Click" />
                                    <asp:Button ID="BtnBack" runat="server" Visible="false" Text="Back" CausesValidation="false" OnClick="BtnBack_Click" CssClass="btn btn-primary" />
                                    <asp:Label ID="Label1" runat="server" ForeColor="#CC3300" Font-Bold="True" Font-Size="15px"></asp:Label>

                                </div>
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

