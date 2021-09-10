<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="SurveyForm.aspx.cs" Inherits="auth_Adminpanel_SurveyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
        }

        .red {
            color: red;
        }

        .box.box-primary1 {
            border-bottom-color: #005529 !important;
        }

        .box-header .box-title {
            display: inline-block;
            font-size: 18px;
            margin: 0;
            line-height: 1;
            color: #fff;
        }

        .box-header.with-border {
            border-bottom: 1px solid #005529;
        }

        .box-header {
            color: #444;
            display: block;
            padding: 7px;
            position: relative;
        }

        label {
            font-weight: 500;
        }

        .headfrm {
            text-align: center;
        }

            .headfrm h3 {
                background: #005529;
                position: absolute;
                top: -34px;
                left: 41%;
                z-index: 999;
                padding: 7px 45px;
                color: #fff;
                font-size: 22px;
                box-shadow: 3px 3px 2px 1px rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
            }

        .tile {
            margin-bottom: 20px;
        }
		.stp{
			color: #000000;
			text-align: left;
			font-weight: bold;
			background: #f7b000;
			padding: 5px;
			}
			.stp1{
			color: #fff;
			text-align: left;
			font-weight: bold;
			background: #005529;
			padding: 5px;
			}
		.stpdiv{
			padding:0 0 30px 0;
		}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 30px; margin-bottom: 62px; padding: 30px; background: #fff;">
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">

                    <div class="col-sm-12 tile">
                       <!-- <div class="headfrm">
                            <h3>Survey Form </h3>
                        </div>-->
                        <div class="box box-primary1" style="margin-bottom: 25px;">
							<div class="stpdiv">
								<span class="box-title stp1" >Step-1</span>
								<span class="box-title stp" style="color: #005529; float:right;">Total Steps - 4</span>
							</div>
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;"></span>  Survey Details</h3>
                            </div>
                            <!-- /.box-header -->
                            <!-- form start -->

                        </div>
                    </div>
                    <div class="col-sm-12">
                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Date of survey<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="date" class="form-control" id="date" placeholder="date of survey">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
                        <!-- <div class="col-sm-6">                
			    <div class="form-group">
			        <label for="" class="col-sm-6">Name of the NGO<span class="red">*</span></label>
					<div class="col-sm-4 input-group"> 
			        	<input type="name" class="form-control" id="" placeholder="Name of the NGO">
			        </div>
			    </div>
			</div> -->
			
			
			
                        <!--=========================================================-->

                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Name of surveyor<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" id="" placeholder="Name of surveyor">
                                </div>
                            </div>
                        </div>
						
						
						 <!--=========================================================-->
                       <div class="col-sm-6">                
								<div class="form-group">
									<label for="" class="col-sm-6">Designation of Surveyor<span class="red">*</span></label>
									<div class="col-sm-4 input-group"> 
										<input type="name" class="form-control" id="" placeholder="Designation of Surveyor">
									</div>
								</div>
							</div> 
                        <!--=========================================================-->
                        <!--=========================================================-->

                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="exampleInputEmail1" class="col-sm-6">State<span class="red">*</span></label>
                                <div class=" col-sm-4 input-group">
                                    <select class="form-control">

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
                        <!--=========================================================-->

                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Village<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" id="" placeholder="">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Gram Panchayat<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" id="" placeholder="">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->

                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">District<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" id="" placeholder="">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->

                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Name of the Tiger Reserve<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" id="" placeholder="Name of the Tiger Reserve">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
						<div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Relocation Status<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" id="" placeholder="">
                                </div>
                            </div>
                        </div>
						<!--=========================================================-->
						<div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Latitude<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" id="" placeholder="">
                                </div>
                            </div>
                        </div>
						<!--=========================================================-->
						<div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Longitude<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <input type="name" class="form-control" id="" placeholder="">
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
                    </div>

                    




                    <div class="col-sm-12">
                        <div class="box box-primary1" style="margin-bottom: 15px;">
                            <div class="box-header with-border" style="">
                                <h3 class="box-title" style="color: #005529;">Survey Information</h3>
                            </div>
                        </div>
                    </div>

                    <!--================================================-->
                    <div class="col-sm-12 tile">
                       <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Panchayat Office <span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <label class="radio-inline">
                                        <asp:RadioButtonList ID="RdbPanchayatOffice" AutoPostBack="true" OnSelectedIndexChanged="RdbPanchayatOffice_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                            <asp:ListItem Text="Yes"  Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
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
                                        <asp:RadioButtonList ID="RdbAnganwadi" AutoPostBack="true" OnSelectedIndexChanged="RdbAnganwadi_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbAllWeatherRoad" AutoPostBack="true" OnSelectedIndexChanged="RdbAllWeatherRoad_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbPostOffice" AutoPostBack="true" OnSelectedIndexChanged="RdbPostOffice_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbBank" AutoPostBack="true" OnSelectedIndexChanged="RdbBank_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbPDSShop" AutoPostBack="true" OnSelectedIndexChanged="RdbPDSShop_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbPublicTelephonePCo" AutoPostBack="true" OnSelectedIndexChanged="RdbPublicTelephonePCo_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbMobileSignal" AutoPostBack="true" OnSelectedIndexChanged="RdbMobileSignal_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbAccessibiliythealthCare" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessibiliythealthCare_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbAccessibiliyRoad" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessibiliyRoad_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbAccessbilitySchool" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessbilitySchool_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbAccessbilityElectrif" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessbilityElectrif_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbAccessiblityVeterinary" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessiblityVeterinary_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbAvenuesEmployment" AutoPostBack="true" OnSelectedIndexChanged="RdbAvenuesEmployment_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbHumanWildlifecon" AutoPostBack="true" OnSelectedIndexChanged="RdbHumanWildlifecon_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
                                        <asp:RadioButtonList ID="RdbAccessFireFodNwfps" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessFireFodNwfps_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
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
						
						
                        <!-- <div class="col-sm-6">                
			    <div class="form-group">
			        <label for="" class="col-sm-6">Remarks <span class="red">*</span></label>
					<div class="col-sm-6 input-group"> 
			        	<textarea class="form-control" rows="2" id=""  style="resize: none;"></textarea>
			        </div>
			    </div>
			</div> -->
                        <!--================================================-->


                    </div>




				
				
                    <div class="col-sm-12">
					<hr/>
                        <div class="" style="margin-bottom: 25px; text-align: left;">

                            <a class="btn btn-primary">Save</a>
                            <a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/WorkPerformedOptionII.aspx" class="btn btn-primary">Next</a>


                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <%-- <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDl" EventName="SelectedIndexChanged" />
                    </Triggers>--%>
        </asp:UpdatePanel>

    </div>

</asp:Content>

