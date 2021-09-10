<%@ Page Title="NTCA:Add Grampanchayat" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddGramPanchayat.aspx.cs" Inherits="auth_Adminpanel_District_Management_AddGramPanchayat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
	<style>
		.form-control {
			Width: 70%;
			
	}
	.form-group{margin-bottom:0px !important;}
	.wrapper-content{min-height:550px;}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">    
         <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
				<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Add Grampanchayat</h3>
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
                            <div class="col-sm-9">
                             <asp:DropDownList ID="DdlState" runat="server" AutoPostBack="True"  CssClass="form-control"   OnSelectedIndexChanged="DdlState_SelectedIndexChanged"  ValidationGroup="val1"></asp:DropDownList>
                                           
                                <div>
                                    <label id="Lbl" style="color:red;"></label>
                                </div>
                            </div>
                            </div>
                        </div>


                        <div class="col-md-6">
                          <div class="form-group">
                            <label class="col-sm-3 control-label gtx">Select District<label style="color:red">*</label></label>
                            <div class="col-sm-9">
                                 
                               <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="form-control">

                               </asp:DropDownList>
                                <%--<asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlDistrict" ValidationGroup="val" 
                                    ErrorMessage="Select district" />--%>
                                <div>
                                    <label id="LblDistrict" style="color:red;"></label>
                                </div>
                            </div>
                        </div>
                        </div>
                        
                        <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label gtx">Select Tehshil <label style="color:red">*</label></label>
                            <div class="col-sm-9">
                               <asp:DropDownList ID="ddlTehshil" runat="server" CssClass="form-control">

                               </asp:DropDownList>
                              
                                
                                    <label id="LblTehsil" style="color:red;"></label>
                              
                            </div>
                        </div>
                        </div>
                       
                   
                      <div class="col-md-6">
                         <div class="form-group">
                            <label class="col-sm-3 control-label gtx">Gram panchayat Name<label style="color:red">*</label>
                            </label>
                            <div class="col-sm-9"> 
                                <asp:TextBox ID="txtGramPanchayatName" runat="server" CssClass="form-control" MaxLength="50" ValidationGroup="val" autocomplete="off"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtGramPanchayatName"  ValidationGroup="val" 
                                    ErrorMessage="Please enter grampanchayat name" ForeColor="Red" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtGramPanchayatName"
                                ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="it should be accept only Alphabets with some special characters like space and dot."
                                ControlToValidate="txtGramPanchayatName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^[0-9a-zA-Z\. ]+$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                          
                                
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ControlToValidate="txtGramPanchayatName"
                                            ValidationExpression="[a-zA-Z ]*$" ValidationGroup="val" ErrorMessage="Only Alphabets and space are allow." />
                                  </div>

                        </div>
                        </div>
						
						<div class="clearfix"> </div>
						
							<div class="col-sm-12">
							

								<div class="col-sm-3 control-label gtx">
                                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>

                                    </div>
									<div class="col-sm-11 text-center" style="padding-left:1px;">
                                    <asp:Button ID="btnsave" runat="server" OnClientClick="return ValidateDropDown();" ValidationGroup="val" Text="Submit"  CssClass="btn btn-primary" OnClick="btnsave_Click" />
                                    <asp:Button ID="btnBack" runat="server" ValidationGroup="val11" Text="Back" Visible="false" CssClass="btn btn-primary" OnClick="btnBack_Click" />
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
    <script type="text/javascript">
        function ValidateDropDown()
        {
            // alert('fd');
            $('#Lbl').html('');
            $('#LblDistrict').html('');
            $('#LblTehsil').html('');
            var cmbID = "<%=DdlState.ClientID %>";
            var vddlDistrict = "<%=ddlDistrict.ClientID %>";
            var vddlTehshil = "<%=ddlTehshil.ClientID %>";
             //  alert($('#' + cmbID).val());

            if ($('#' + cmbID).val() == "Select State")
            {
                 //  alert("Please select State");
                 $('#Lbl').html('Please select State');
                 return false;
            }

            if ($('#' + vddlDistrict).val() == "No Record") {
                //  alert("Please select State");
                $('#LblDistrict').html('Please select District');
                return false;
            }
            if ($('#' + vddlDistrict).val() == "Select District") {
                //  alert("Please select State");
                $('#LblDistrict').html('Please select District');
                return false;
            }
            if ($('#' + vddlTehshil).val() == "No Record")
            {
                //  alert("Please select State");
                $('#LblTehsil').html('Please select tehsil');
                return false;
            }
            if ($('#' + vddlTehshil).val() == "Select Tehshil") {
                //  alert("Please select State");
                $('#LblTehsil').html('Please select tehsil');
                return false;
            }
             return true;
         }
    </script>
</asp:Content>

