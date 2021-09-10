<%@ Page Title="NTCA:Reply Process managment" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewLegalForm.aspx.cs" Inherits="auth_Adminpanel_ProcessManegment_DfoUser_ViewLegalForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding-top: 0px;
            text-align: left;
        }
    </style>
    <style>
        .cColor {
            color: red;
            font-size: larger;
        }

        .control-label {
            padding-top: 0px;
            text-align: left;
        }

        .file-field.big .file-path-wrapper {
            height: 3.2rem;
        }

            .file-field.big .file-path-wrapper .file-path {
                height: 3rem;
            }
			.main {
    margin-top: 10px !important;
}
.red{color:red;}
    </style>
    <link href="../style.css" rel="stylesheet" />
    <script src="../view.js"></script>
    <style>
        th {
            vertical-align: middle !important;
        }

        .mt20 {
            margin-top: 20px;
        }

        .ml10 {
            margin-left: 10px !important;
        }

        .frmheading {
            color: #ffffff;
            padding: 5px 12px;
            background: #005529;
            margin-left: 10px;
        }

        .frmsubheading {
            color: #474545;
            background: #f7b000;
            padding: 2px 6px;
        }

        .red-text {
            color: red;
        }
    </style>
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>--%>


    <%-- <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"
        type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css"
        rel="Stylesheet" type="text/css" />--%>

    <%--  <link href="../../../../css/datepicker.css" rel="stylesheet" />
    <script src="../../../../js/bootstrap-datepicker.js"></script>--%>


    <script type="text/javascript">

        $(document).ready(function () {
           

        });//End of document function


        //------------------------
        <%-- function ClientValidate(sender, element) {

            if (document.getElementById("<%= ddlselectname.ClientID %>").selectedIndex == 0 && document.getElementById("<%= ddlselectname.ClientID %>").value != "") {

                element.IsValid = false;
            } else {

                element.IsValid = true;
            }
        }--%>


    </script>
    <script type="text/javascript">
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="row">
                <div class="col-lg-12 ">
                    <div class="widgets-container">
                        <div class="box box-primary1" style="margin-bottom: 25px;">
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Reply Process managment</h3>

                            </div>
                        </div>
                        <!--start multistep form -->
                        <div class="col-md-12 main">
                            <!-- progressbar -->
                            <ul id="progressbar">
                               <li class="active">Pre-Survey Form</li>
							   <li >Legal Form</li>
                               <li>Consent Form</li>
                              <%--  <li>Upate record</li>--%>
                            </ul>
							
							<!--start pre-survey form -->
						
						<fieldset id="first">
                            <h2 class="title">Pre-Survey Form</h2>
                            <p class="subtitle">Step 1</p>
							<div class="col-md-12">
								<div class="row">
                                     <span class="frmheading"><strong>Survey Details</strong></span>
                                </div>
								<div class="row mt20"> 
								 <div class="col-sm-6">
									<div class="form-group">
										<label for="" class="col-sm-6">Date of survey<span class="red">*</span></label>
										<div class="col-sm-4 input-group">
											<input type="date" class="form-control" id="date" disabled="disabled" placeholder="date of survey">
										</div>
									</div>
								</div>
								<div class="col-sm-6">
									<div class="form-group">
										<label for="" class="col-sm-6">Name of surveyor<span class="red">*</span></label>
										<div class="col-sm-4 input-group">
											<input type="name" class="form-control" id="" disabled="disabled" placeholder="Name of surveyor">
										</div>
									</div>
								</div>
								<div class="clearfix"></div>
								<div class="col-sm-6">                
								<div class="form-group">
									<label for="" class="col-sm-6">Designation of Surveyor<span class="red">*</span></label>
									<div class="col-sm-4 input-group"> 
										<input type="name" class="form-control" id="" disabled="disabled" placeholder="Designation of Surveyor">
									</div>
								</div>
							</div> 
							<div class="col-sm-6">
								<div class="form-group">
									<label for="exampleInputEmail1" class="col-sm-6">State<span class="red">*</span></label>
									<div class=" col-sm-4 input-group">
										<select class="form-control" disabled="disabled">

											<option value="select">---Select State---</option>
											<option value="select">Bihar</option>
											<option value="select">Chattisgarh</option>
											<option value="select">Jharkhand</option>
											<option value="select">Madhya Pradesh</option>
											<option value="select">Odhisa</option>
											<option value="select">Rajashthan</option>
											<option value="select">Uttar Pradesh</option>
										</select>
									</div>
								</div>
							</div>
							<div class="clearfix"></div>
							<!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Village<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" disabled="disabled" id="" placeholder="">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Gram Panchayat<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" disabled="disabled" id="" placeholder="">
                                </div>
                            </div>
                        </div>
						<div class="clearfix"></div>
                        <!--=========================================================-->
						<div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">District<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" disabled="disabled" id="" placeholder="">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->

                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Name of the Tiger Reserve<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" disabled="disabled" id="" placeholder="Name of the Tiger Reserve">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
								
							</div>
							<div class="row">
                                     <span class="frmheading"><strong>Survey Information</strong></span>
                            </div>
							<!--******************************-->
								<div class="row mt20">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Panchayat Office <span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbPanchayatOffice" AutoPostBack="true" Enabled="false"  runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes" ></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" disabled="disabled" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradioschool" checked="">Yes--%>
                                    </label>
                                    <label>
                                        <asp:TextBox ID="TxtRdbPanchayatOffice" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
						
                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Anganwadi <span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbAnganwadi" AutoPostBack="true" Enabled="false"  runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradiohospital" checked="">Yes--%>
                                    </label>
                                   <label>
                                        <asp:TextBox ID="TxtRdbAnganwadi" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
						</div>
						<div class="clear"></div>
						<div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">All weather road<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbAllWeatherRoad" AutoPostBack="true" Enabled="false"  runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio5" checked="">Yes--%>
                                    </label>
                                   <label>
                                        <asp:TextBox ID="TxtRdbAllWeatherRoad" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Post office<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbPostOffice" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio6" checked="">Yes--%>
                                    </label>
                                    <label>
                                        <asp:TextBox ID="TxtRdbPostOffice" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
						</div>
						<div class="clear"></div>
                        <!--=========================================================-->
						<div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Bank<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbBank" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio7" checked="">Yes--%>
                                    </label>
                                   <label>
                                        <asp:TextBox ID="TxtRdbBank" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">PDS shop/outlet<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbPDSShop" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio8" checked="">Yes--%>
                                    </label>
                                      <label>
                                        <asp:TextBox ID="TxtRdbPDSShop" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
						</div>
                        <!--=========================================================-->
						<div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Public telephone (PCO)<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbPublicTelephonePCo" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio9" checked="">Yes--%>
                                    </label>
                                    <label>
                                        <asp:TextBox ID="TxtRdbPublicTelephonePCo" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->

                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Mobile signal<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbMobileSignal" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio11" checked="">Yes--%>
                                    </label>
                                     <label>
                                        <asp:TextBox ID="TxtRdbMobileSignal" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
						</div>
                        <!--=========================================================-->
						<div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Accessibility to health care<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbAccessibiliythealthCare" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio11" checked="">Yes--%>
                                    </label>
                                    <label>
                                        <asp:TextBox ID="TxtAccessibiliythealthCare" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Accessibility to road<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbAccessibiliyRoad" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio11" checked="">Yes--%>
                                    </label>
                                     <label>
                                        <asp:TextBox ID="TxtAccessibiliyRoad" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
                                    </label>

                                </div>
                            </div>
                        </div>
						</div>
						
						<div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Accessibility to school<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbAccessbilitySchool" AutoPostBack="true" Enabled="false"  runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio11" checked="">Yes--%>
                                    </label>
                                     <label>
                                        <asp:TextBox ID="TxtAccessbilitySchoolPrimary" Visible="false" CssClass="form-control" runat="server" placeholder="primary- how far?"></asp:TextBox>
                                    </label>
                                     <label>
                                        <asp:TextBox ID="TxtAccessbilitySchool_Secondary" Visible="false" CssClass="form-control" runat="server" placeholder="Secondary- how far?"></asp:TextBox>
                                    </label>
                                     <label>
                                        <asp:TextBox ID="TxtAccessbilitySchool_HighSchool" Visible="false" CssClass="form-control" runat="server" placeholder="HighSchool- how far?"></asp:TextBox>
                                    </label>
                                     <label>
                                        <asp:TextBox ID="TxtAccessbilitySchool_College" Visible="false" CssClass="form-control" runat="server" placeholder="College- how far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Accessibility to electrification<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbAccessbilityElectrif" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio11" checked="">Yes--%>
                                    </label>
                                   <label id="lblRdbAccessbilityElectrif" runat="server" Visible="false">
                                       Duration of electricity in villages, households?:
                                        <asp:TextBox ID="TxtAccessbilityElectrif_DurationElectricityVillages" Visible="false" CssClass="form-control" runat="server" placeholder="Duration of electricity in villages, households?"></asp:TextBox>
                                    </label>
                                    
                                </div>
                            </div>
                        </div>
						</div>
						
						
						<div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Accessibility to Veterinary health care: <span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbAccessiblityVeterinary" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--<input type="radio" name="optradio11" checked="">Yes--%>
                                    </label>
                                      <label>
                                        <asp:TextBox ID="TxtAccessiblityVeterinary" Visible="false" CssClass="form-control" runat="server" placeholder="College- how far?"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Avenues of employment<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbAvenuesEmployment" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%-- <input type="radio" name="optradio11" checked="">Yes--%>
                                    </label>
                                   <label id="lblRdbAvenuesEmployment1" runat="server" Visible="false">
                                       Primary sector (Agriculture, Animal Husbandry etc):
                                        <asp:TextBox ID="TxtAvenuesEmployment_Primary" CssClass="form-control" runat="server" placeholder="Primary sector (Agriculture, Animal Husbandry etc)"></asp:TextBox>
                                    </label>
                                    <label id="lblRdbAvenuesEmployment2" runat="server" Visible="false">
                                        Secondary Sector (Factory, manufacturing unit, food processing etc):
                                        <asp:TextBox ID="TxtAvenuesEmployment_Secondary" Visible="false" CssClass="form-control" runat="server" placeholder="Secondary Sector (Factory, manufacturing unit, food processing etc)"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
						</div>
						
						
						<div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Human-wildlife Conflict<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbHumanWildlifecon" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%-- <input type="radio" name="optradio11" checked="">Yes--%>
                                    </label>
                                       <label id="lblRdbHumanWildlifecon" runat="server" Visible="false">
                                           Crop damage/injury/fatality:
                                        <asp:TextBox ID="TxtRdbHumanWildlifecon" Visible="false" CssClass="form-control" runat="server" placeholder="Crop damage/injury/fatality"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Access to firewood/fodder/NWFPs in forest<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">

                                    <label class="radio-inline">
                                        <%-- <input type="radio" name="optradio11" checked="">Yes--%>
                                        <asp:RadioButtonList ID="RdbAccessFireFodNwfps" AutoPostBack="true" Enabled="false" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </label>
                                   <label id="lblRdbAccessFireFodNwfps" runat="server" Visible="false">
                                       Crop damage/injury/fatality:
                                        <asp:TextBox ID="TXTAccessFireFodNwfps" Visible="false" CssClass="form-control" runat="server" placeholder="Crop damage/injury/fatality"></asp:TextBox>
                                    </label>
                                </div>
                            </div>
                        </div>
						</div>
							<!--******************************-->
							
							
							
							
							
							
							</div>                           

                            <input type="button" id="btnprenxt"   name="next" class="next_btn btn-primary ml10" value="Next" />
                            
                        </fieldset>
						<!--end pre-survey form -->

                            <!-- legal form -->

                            <fieldset >
                                <h2 class="title">Legal Form</h2>
                                <p class="subtitle">Step 1</p>
                                <div class="col-md-12 mt20">
                                    <div class="row">
                                        <%-- <div class="col-md-10">
                                        <label class="col-sm-4 control-label" style="padding-left: 0;">
                                            Select Village Name:
                                        </label>
                                        <div class="form-group col-md-5">
                                            <select name="" id="" class="form-control">
                                                <option value="0">Select</option>
                                                <option value="1">2</option>
                                                <option value="2">3</option>
                                            </select>
                                        </div>
                                    </div>--%>
                                        <div class="col-md-12">
                                            <span>Please fill the following mandatory form to proceed further.</span><br />
                                            <span><strong>Compliance of the Wildlife (Protection) Act, 1972 and the Scheduled Tribes & Other Traditional Forest Dwellers (Recognition of Forest Rights) Act, 2006.</strong></span>
                                        </div>

                                        <div class="">
                                            <div class="col-md-12 mt20">
                                                <div class="row">
                                                    <span class="frmheading"><strong>1.Core or Critical Tiger Habitat (CTH)</strong></span>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Notified<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">

                                                            <asp:DropDownList ID="DdlNotified1_a" runat="server"  Enabled="false"  CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-10 mt20" id="dvTxtDateNotification1_b">
                                                        <label class="col-sm-4 control-label">
                                                            Date of Notification<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                            <asp:TextBox ID="TxtDateNotification1_b" runat="server" Enabled="false" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                           
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Area(Ha.)<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:TextBox ID="TxtAreaHa1_c" runat="server" Enabled="false" CssClass="form-control" MaxLength="15"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Compliance of section 38V of the Wildlife	(Protection) Act, 1972<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:TextBox ID="TxtCompliance1_d" runat="server" Enabled="false" CssClass="form-control" MaxLength="100"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>



                                                <div class="row mt20">
                                                    <span class="frmheading"><strong>2.Buffer or Peripheral Area</strong></span>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Notified<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlNotified2_a" Enabled="false" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-10 mt20" id="DvDateNotification2_b">
                                                        <label class="col-sm-4 control-label">
                                                            Date of Notification<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                            <asp:TextBox ID="TxtDateNotification2_b" Enabled="false" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                          
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Area(Ha.)<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">

                                                            <asp:TextBox ID="TxtAreaHa2_c" runat="server" Enabled="false" CssClass="form-control" MaxLength="15"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Expert Committee (Constituted)<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlExpertCommittee2_d" Enabled="false" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20" id="DvDdlExpertCommittee2_d">
                                                        <label class="col-sm-4 control-label">
                                                            Date of Constitution <span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                            <asp:TextBox ID="TxtDateConstitution2_e" runat="server" Enabled="false" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                            <%--<asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image1" runat="server" />--%>
                                                         

                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Consultation With Gram Sabha<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlConsultationGramSabha2_f" Enabled="false" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20" id="DvDdlConsultationGramSabha2_f">
                                                        <label class="col-sm-4 control-label">
                                                            Name of Gram Sabha<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:TextBox ID="TxtNameGramSabha2_g" runat="server" Enabled="false" CssClass="form-control" MaxLength="100"></asp:TextBox>

                                                        </div>
                                                    </div>


                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            <strong>Map of CTH & Buffer or Peripheral Area.</strong>
                                                        </label>
                                                        <div class="form-group col-md-5" id="dvFileUploadMapCTH2_h">
                                                            <asp:FileUpload ID="FileUploadMapCTH2_h" runat="server" Enabled="false" BorderColor="#B4BA7E" />
                                                            <br />
                                                        <span style="color:green; font-weight:bolder;">(.jpg or pdf files only)</span>
                                                          <br />
                                                              <asp:HyperLink ID="HypMapCTH2_h" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            <strong>Upload file </strong>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                           
                                                        <asp:FileUpload ID="FileUploadUploadfile2_i" runat="server" Enabled="false" BorderColor="#B4BA7E" /><asp:Label ID="lbl1" Visible="false" runat="server"></asp:Label>
                                                           <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                              <br />
                                                            <asp:HyperLink ID="HypUploadfile2_i" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            <strong>Upload file </strong>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:FileUpload ID="FileUploadUploadfile2_j" Enabled="false" runat="server" BorderColor="#B4BA7E" /><asp:Label ID="lbl2" Visible="false" runat="server"></asp:Label>
                                                             <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                            <br />
                                                            <asp:HyperLink ID="HypUploadfile2_j" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row mt20">
                                                    <span class="frmheading"><strong>3.Recognition / Determination/ Acquisition / Vesting of Forest Rights of Schedule Tribes & such other Traditional Forest Dwellers</strong></span>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Completed <span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlCompleted3_a" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
															<br />
                                                            <span id="SpFileUploadCompleted3_a">
                                                            <asp:FileUpload ID="FileUploadCompleted3_a" runat="server" Enabled="false" ToolTip="(Upload only pdf!.)" /></span>
                                                            <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                             <asp:HyperLink ID="HypFileUploadCompleted3_a" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>

                                                        </div>
                                                    </div>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row mt20">
                                                    <span class="frmheading"><strong>4.Re-settlement or Alternative Package</strong></span>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Provided <span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlProvided4_a" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row mt20">
                                                    <span class="frmheading"><strong>5.Free informed consent of Gram Sabha to the Resettlement Programme</strong></span>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Obtained <span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlObtained5_a" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row mt20">
                                                    <span class="frmheading"><strong>6.Voluntary consent of individuals affected</strong></span>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Obtained <span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlObtained6_a" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
															<br />

                                                            <span id="spanFileUpload6_a">
                                                            <asp:FileUpload ID="FileUpload6_a" runat="server" Enabled="false" ToolTip="(Upload only pdf!.)" /></span>
                                                             <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                            <asp:HyperLink ID="HypFileUpload6_a" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--END OF ROW-->


                                                <div class="row mt20">
                                                    <span class="frmheading"><strong>7.Facilities & Land Allocation At The Resettlement Location</strong></span>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Provided <span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlProvided7_a" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>
															<br />

                                                            <span id="spanFileUploadProvided7_a">
                                                            <asp:FileUpload ID="FileUploadProvided7_a" runat="server" Enabled="false" /></span>
                                                             <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                            <asp:HyperLink ID="HypFileUploadProvided7_a" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row mt20">
                                                    <span class="frmheading"><strong>8.Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal</strong></span>
                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row">
                                                    <div class="col-md-12 mt20">
                                                        <span class="frmsubheading"><strong>Sub Divisional Level Committee</strong></span>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Constituted<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlConstituted8_a_a" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                                <asp:ListItem Value="In-Progress">In-Progress</asp:ListItem>
                                                            </asp:DropDownList>
															<br />
                                                            <span id="spanFileUpload8_a_a">
                                                            <asp:FileUpload ID="FileUpload8_a_a" runat="server" Enabled="false" ToolTip="(Upload only pdf!.)" /></span>
                                                            <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                             <asp:HyperLink ID="HypFileUpload8_a_a" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20" id="DvTxtDateofconstitution8_a_b">
                                                        <label class="col-sm-4 control-label">
                                                            Date of constitution
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                            <asp:TextBox ID="TxtDateofconstitution8_a_b" runat="server" Enabled="false" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                            <%--<asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image1" runat="server" />--%>
                                                         

                                                        </div>
                                                    </div>





                                                    <div class="col-md-12 mt20">
                                                        <span class="frmsubheading"><strong>District Level Committee</strong></span>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Constituted<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="DdlConstituted8_b_a" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                                <asp:ListItem Value="In-Progress">In-Progress</asp:ListItem>
                                                            </asp:DropDownList>
															<br />
                                                            <span id="spanDdlConstituted8_b_a">
                                                            <asp:FileUpload ID="FileUpload8_b_a" runat="server" Enabled="false" ToolTip="(Upload only pdf!.)" /></span>
                                                             <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                            <asp:HyperLink ID="HypFileUpload8_b_a" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20" id="DvTxtDateofconstitution8_b_b">
                                                        <label class="col-sm-4 control-label">
                                                            Date of constitution
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                            <asp:TextBox ID="TxtDateofconstitution8_b_b" runat="server" Enabled="false" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                           
                                                        </div>
                                                    </div>

                                                    <div class="col-md-12 mt20">
                                                        <span class="frmsubheading"><strong>State Level Monitoring Committee</strong></span>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Constituted<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:DropDownList ID="Ddl8_c_a" runat="server" Enabled="false" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                                <asp:ListItem Value="In-Progress">In-Progress</asp:ListItem>
                                                            </asp:DropDownList>
															<br />

                                                            <span id="spanFileUpload8_c_a" class="file-path-wrapper">
                                                            <asp:FileUpload ID="FileUpload8_c_a" runat="server" Enabled="false" CssClass="file-path validate" ToolTip="(Upload only pdf!.)" /></span>
                                                           <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                              <asp:HyperLink ID="HypFileUpload8_c_a" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>

                                                    <div class="col-md-10 mt20" id="dvTxtDateofconstitution8_c_b">
                                                        <label class="col-sm-4 control-label">
                                                            Date of constitution
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                            <asp:TextBox ID="TxtDateofconstitution8_c_b" Enabled="false" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                           
                                                        </div>
                                                    </div>


                                                </div>

                                                <!--END OF ROW-->



                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <%-- <asp:Button ID="BtnNext" runat="server" Text="Next"  CssClass="next_btn btn-primary ml10" />--%>
								<input type="button" name="previous" class="pre_btn btn-primary ml10" value="Previous" />
                                <input type="button" id="BtnNext" name="next" class="next_btn btn-primary ml10" value="Next" />
                                <%-- <div style="text-align: center;">
                                <h2 style="color: red; text-decoration: underline;">Validation Summary</h2>
                                <h4 style="color: green;">All * field are mandatorys</h4>
                               
                            </div>--%>
                            </fieldset>

                            <!-- fieldsets -->

                            <fieldset>
                                <h2 class="title">Form 1</h2>
                                <p class="subtitle">Step 2</p>
                                <div class="col-md-12 mt20">
                                    <table class="table table-bordered table-striped">
                                        <thead>
                                            <tr>
                                                <th>S.No.</th>
                                                <th>Check Items</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <td>Whether core/critical tiger habitat has been notified by the State as per Section 38V of the Wildlife Act? (If so, please enclose a copy of the notification)</td>
                                                <td>
                                                    <asp:RadioButtonList ID="RdbCheckItems1" RepeatDirection="Horizontal" Enabled="false" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems1">
                                                       
                                                            <span>

                                                                <span style="font-weight: bold;" >Result:</span>
                                                                <br />
                                                                <asp:TextBox ID="TextCheckItems1" runat="server" Enabled="false" CssClass="form-control" MaxLength="250"></asp:TextBox>
                                                            </span>
															

                                                            <span>                                                              
																<br />
                                                                <asp:FileUpload ID="FileUploadCheckItems1"  runat="server" Enabled="false" ToolTip="(Upload only pdf!.)" />
                                                               <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                                  <asp:HyperLink ID="HypFileUploadCheckItems1" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>

                                                            </span>
                                                        
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>2</td>
                                                <td>
                                                    <%--Whether consent of villages obtained?--%>
                                                     Whether consent of Individual family obtained?
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="RdbCheckItems2" RepeatDirection="Horizontal" Enabled="false" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems2">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems2" CssClass="form-control" runat="server" Enabled="false" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
                                                           <br />
														   <asp:FileUpload ID="FileUploadCheckItems2" Enabled="false" runat="server" ToolTip="(Upload only pdf!.)" />
                                                             <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                            <asp:HyperLink ID="HypFileUploadCheckItems2" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>

                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>3</td>
                                                <td>
                                                    <%--Whether process of recognition and determination of rights and acquisition of land or forests rights of the ST and other forests dwelling person is complete? The lists are to be certified by Collectors.--%>
                                                    Whether process of recognition and determination of rights and acquisition of land or forests rights of the Scheduled Tribes and other forests dwellers are settled?
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="RdbCheckItems3" Enabled="false" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems3">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems3" CssClass="form-control" Enabled="false" runat="server" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>                                                           
															<br/>
                                                            <asp:FileUpload ID="FileUploadCheckItems3" Enabled="false" runat="server" ToolTip="(Upload only pdf!.)" />
                                                            <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                             <asp:HyperLink ID="HypFileUploadCheckItems3" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>

                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>4</td>
                                                <td>Whether provisions of the ST & OFD (Recognition of Forests Rights) Act have been compiled with?</td>
                                                <td>
                                                    <asp:RadioButtonList ID="RdbCheckItems4" RepeatDirection="Horizontal" Enabled="false" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems4">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems4" CssClass="form-control" Enabled="false" runat="server" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
														   <br/>														
                                                            <asp:FileUpload ID="FileUploadCheckItems4" Enabled="false" runat="server" ToolTip="(Upload only pdf!.)" />
                                                            <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                             <asp:HyperLink ID="HypFileUploadCheckItems4" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>5</td>
                                                <td>Whether District Level & State Level Monitoring Committees have been constituted?</td>
                                                <td>
                                                    <asp:RadioButtonList ID="RdbCheckItems5" RepeatDirection="Horizontal" Enabled="false" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems5">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems5" CssClass="form-control" runat="server" Enabled="false" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
                                                            

                                                            <br/>
															<asp:FileUpload ID="FileUploadCheckItems5" Enabled="false" runat="server" ToolTip="(Upload only pdf!.)" />
                                                             <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                            <asp:HyperLink ID="HypFileUploadCheckItems5" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>

                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>6</td>
                                                <td>
                                                    <%--What is the cut of date as decided by the Competent Authority?--%>
 What is the cut of date as decided by the Competent Authority,  "for deciding the eligibility criteria"
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="RdbCheckItems6" Visible="false" RepeatDirection="Horizontal" Enabled="false" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems6">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems6" CssClass="form-control" runat="server" Enabled="false" MaxLength="250"></asp:TextBox>
                                                       <%--<asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg"  ID="Image1" runat="server" /><br />--%>
                                                      <%--  <cc1:CalendarExtender ID="CalendarExtender7" Format="dd/MM/yyyy" TargetControlID="TextCheckItems6"
                                                            PopupButtonID="Image1" runat="server">
                                                        </cc1:CalendarExtender>--%>
                                                              </span>

                                                        <span style="display:none;">
															<br/>

                                                            <asp:FileUpload ID="FileUploadCheckItems6" Enabled="false" runat="server" ToolTip="(Upload only pdf!.)" />
                                                          <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                               <asp:HyperLink ID="HypFileUploadCheckItems6" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>

                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td>7</td>
                                                <td>Whether clearance under the Forest (Conservation) Act obtained in case of resettlement to forest land?</td>
                                                <td>
                                                    <asp:RadioButtonList ID="RdbCheckItems7" RepeatDirection="Horizontal" Enabled="false" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems7">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems7" CssClass="form-control" runat="server" Enabled="false" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
															<br/>

                                                            <asp:FileUpload ID="FileUploadCheckItems7" Enabled="false" runat="server" ToolTip="(Upload only pdf!.)" />
                                                           <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                              <asp:HyperLink ID="HypFileUploadCheckItems7" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>

                                                        </span>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <input type="button" name="previous" class="pre_btn btn-primary ml10" value="Previous" />
                                <%--<input type="button" name="next" class="next_btn btn-primary" value="Next" />--%>
                            </fieldset>
                            <!-- Process form -->
                            <%--<fieldset>
                                <h2 class="title">Update record</h2>
                                <p class="subtitle">Step 3</p>
                                <div class="col-md-12 mt20" style="padding-left: 0;">
                                </div>
                                <input type="button" class="pre_btn btn-primary ml10" value="Previous" />
                                <asp:Button ID="btnsumbit" runat="server" Text="Update" Visible="false" ValidationGroup="val"
                                    CssClass="btn btn-primary center" OnClick="btnsumbit_Click" />
									
                                <asp:Button ID="BtnBack" runat="server" Visible="false" Text="Back" CausesValidation="false"
                                    CssClass="btn btn-primary center" OnClick="BtnBack_Click" />
                            </fieldset>--%>
                        </div>
                        <!--end multistep form---- -->
						<div class="col-md-12 mt20">
							<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/form-preview.aspx" class="btn btn-primary" >Back</a>
						</div>
                    </div>
					
                </div>
            </div>
        </div>
        <div>

             <!--<asp:Button ID="BtnBack" runat="server"  Text="Back" 
                                    CssClass="btn btn-primary center" OnClick="BtnBack_Click1" />-->
									
        </div>
        <div style="text-align: center;">
            <asp:Label ID="LblerrorFileUpload" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

