<%@ Page Title="NTCA:Add process managment" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddProcessDFO.aspx.cs" Inherits="auth_Adminpanel_ProcessManegment_DfoUser_AddProcessDFO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        .ajax__calendar {
            z-index: 999;
        }

        .file-field.big .file-path-wrapper .file-path {
            height: 3rem;
        }

        .form-control {
            height: inherit !important;
        }

        input[type=date].form-control {
            line-height: inherit;
        }

        .stp {
            color: #000000;
            text-align: left;
            font-weight: bold;
            background: #f7b000;
            padding: 5px;
        }

        .stp1 {
            color: #fff;
            text-align: left;
            font-weight: bold;
            background: #005529;
            padding: 5px;
        }
		.display_inline{
			display:inline !important;
		}
		.display_inline input[type=submit], .display_inline input[type=button]{
		margin:0;
		}

        .stpdiv {
            padding: 0 0 30px 0;
        }
        .input_inline {
            display:inline-block !important;max-width: 40%;
        }
        .sml-btn{
            width:auto !important;
            height:auto !important;
            margin:2px !important;
        }
    </style>
    <link href="../style.css" rel="stylesheet" />
    <script src="../multi_step_form.js"></script>
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

        .main {
            margin-top: 10px;
        }

        .red {
            color: red;
        }
    </style>
      <style>
        .procenter {
            text-align: center;
        }

        .modwidth {
            width: 500px !important;
        }

        .modwidth1 p {
            font-size: 160%;
        }

        .nobdr {
            border: none !important;
        }

        .tophght {
            top: 26% !important;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#<%= TextCheckItems6.ClientID %>').attr('readonly', true);
            $("#contentbody_TxtDateNotification1_b").prop('readonly', true);
            $("#contentbody_TxtDateNotification2_b").prop('readonly', true);
            $("#contentbody_TxtDateConstitution2_e").prop('readonly', true);
            $("#contentbody_TxtDateofconstitution8_a_b").prop('readonly', true);
            $("#contentbody_TxtDateofconstitution8_c_b").prop('readonly', true);
            $("#contentbody_TxtDateofconstitution8_b_b").prop('readonly', true);
            //----------------------------------
            //----------------------------
            //start first panel =conditon wise control visible true false
            $("#<%=DdlNotified1_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlNotified1_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#dvTxtDateNotification1_b").show();
                    // return false;
                }
                else {
                    $("#dvTxtDateNotification1_b").hide();
                    // return true;
                }
            });
            $("#<%=DdlNotified2_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlNotified2_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#DvDateNotification2_b").show();
                    // return false;
                }
                else {
                    $("#DvDateNotification2_b").hide();
                    //return true;
                }
            });
            $("#<%=DdlExpertCommittee2_d.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlExpertCommittee2_d.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#DvDdlExpertCommittee2_d").show();
                    //  return false;
                }
                else {
                    $("#DvDdlExpertCommittee2_d").hide();
                    // return true;
                }
            });
            $("#<%=DdlConsultationGramSabha2_f.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlConsultationGramSabha2_f.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#DvDdlConsultationGramSabha2_f").show();
                    // return false;
                }
                else {
                    $("#DvDdlConsultationGramSabha2_f").hide();
                    //return true;
                }
            });
            $("#<%=DdlCompleted3_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlCompleted3_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#SpFileUploadCompleted3_a").show();
                    // return false;
                }
                else {
                    $("#SpFileUploadCompleted3_a").hide();
                    // return true;
                }
            });
            $("#<%=DdlObtained6_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlObtained6_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanFileUpload6_a").show();
                    // return false;
                }
                else {
                    $("#spanFileUpload6_a").hide();
                    // return true;
                }
            });
            $("#<%=DdlProvided7_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlProvided7_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanFileUploadProvided7_a").show();
                    // return false;
                }
                else {
                    $("#spanFileUploadProvided7_a").hide();
                    //  return true;
                }
            });
            $("#<%=DdlConstituted8_a_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlConstituted8_a_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanFileUpload8_a_a").show();
                    $("#DvTxtDateofconstitution8_a_b").show();
                    // return false;
                }
                else {
                    $("#spanFileUpload8_a_a").hide();
                    $("#DvTxtDateofconstitution8_a_b").hide();
                    //  return true;
                }
            });
            $("#<%=DdlConstituted8_b_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlConstituted8_b_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanDdlConstituted8_b_a").show();
                    $("#DvTxtDateofconstitution8_b_b").show();
                    // return false;
                }
                else {
                    $("#spanDdlConstituted8_b_a").hide();
                    $("#DvTxtDateofconstitution8_b_b").hide();
                    //  return true;
                }
            });
            $("#<%=Ddl8_c_a.ClientID %>").change(function () {
                var getvalue = $("#<%=Ddl8_c_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanFileUpload8_c_a").show();
                    $("#dvTxtDateofconstitution8_c_b").show();
                    // return false;
                }
                else {
                    $("#spanFileUpload8_c_a").hide();
                    $("#dvTxtDateofconstitution8_c_b").hide();
                    //  return true;
                }
            });

            $('#<%=RdbCheckItems1.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems1").show();
                        // return false;
                    }
                    else {

                        $("#divCheckItems1").hide();
                        //  return true;
                    }
                });
            });

            $('#<%=RdbCheckItems2.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems2").show();
                        // return false;
                    }
                    else {

                        $("#divCheckItems2").hide();
                        // return true;
                    }
                });
            });//-----------
            $('#<%=RdbCheckItems3.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems3").show();
                        // return false;
                    }
                    else {

                        $("#divCheckItems3").hide();
                        // return true;
                    }
                });
            });//-----------
            $('#<%=RdbCheckItems4.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems4").show();
                        // return false;
                    }
                    else {

                        $("#divCheckItems4").hide();
                        // return true;
                    }
                });
            });//-----------
            $('#<%=RdbCheckItems5.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems5").show();
                        //  return false;
                    }
                    else {

                        $("#divCheckItems5").hide();
                        // return true;

                    }
                });
            });//-----------
            $('#<%=RdbCheckItems6.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems6").show();
                        // return false;
                    }
                    else {

                        $("#divCheckItems6").hide();
                        //  return true;
                    }
                });
            });//-----------
            $('#<%=RdbCheckItems7.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems7").show();
                        // return false;
                    }
                    else {

                        $("#divCheckItems7").hide();
                        // return true;
                    }
                });
            });//-----------

            //------end 2 second panel-=conditon wise control visible true false----



        });//End of document function

       
        //------------------------
        function ClientValidate(sender, element) {

            if (document.getElementById("<%= ddlselectname.ClientID %>").selectedIndex == 0 && document.getElementById("<%= ddlselectname.ClientID %>").value != "") {

                element.IsValid = false;
            } else {

                element.IsValid = true;
            }
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <%--<asp:UpdatePanel ID="updatepnl" runat="server">

<ContentTemplate>--%>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">

        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="row">
                <div class="col-md-12">

                    <div class="box box-primary1" style="margin-bottom: 25px; margin-top: 20px;">
                        <div class="stpdiv">
							<span class="box-title stp1 stepArrow">Step-1</span>
                                <span class="box-title stp1 stepArrow ">Step-2</span>
								<span class="box-title stp1 stepArrow stepActive">Step-3</span>
								<span class="box-title stp1 stepArrow">Step-4</span>
								<span class="box-title stp1 stepArrow">Step-5</span>
                            <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 5</span>
                        </div>
						<div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Add Forms</h3>
                            </div>

                    </div>

                    <!-- multistep form -->
                    <div class="col-md-12 main">

                        <!-- progressbar -->
                        <ul id="progressbar">
                            <li class="active">Pre-Survey Form</li>
                            <li>Legal Form</li>
                            <li>Consent Form</li>

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
                                            <div class="col-sm-5 input-group">
                                                <asp:TextBox ID="txtSurveyDate" runat="server" placeholder="dd/mm/yyyy" ValidationGroup="ADDMember" Width="70%" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                                <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image4" runat="server" /><br />
                                                
                                                <asp:RegularExpressionValidator ID="RegulTxtDOB" runat="server" ControlToValidate="txtSurveyDate"
                                                    Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="CalendarTxtDOB" Format="dd/MM/yyyy" TargetControlID="txtSurveyDate"
                                                    PopupButtonID="Image4" runat="server">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredTxtCuttOffDate" runat="server" ControlToValidate="txtSurveyDate"
                                                    Display="Dynamic" ErrorMessage="Please Enter DOB" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="" class="col-sm-6">Name of surveyor<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                              <asp:TextBox ID="txtSurveyor" runat="server" CssClass="form-control" placeholder="Enter surveyor Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSurveyor"
                                                    Display="Dynamic" ErrorMessage="Please Enter Name" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="" class="col-sm-6">Designation of Surveyor<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <asp:TextBox ID="txtDesignationSurveyor" runat="server"  CssClass="form-control" placeholder="Enter Designation"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesignationSurveyor"
                                                    Display="Dynamic" ErrorMessage="Please Enter Designation" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1" class="col-sm-6">State<span class="red">*</span></label>
                                            <div class=" col-sm-4 input-group">
                                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtState"
                                                    Display="Dynamic" ErrorMessage="Please Enter State" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <!--=========================================================-->
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="" class="col-sm-6">Village<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <asp:TextBox ID="txtVillage" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVillage"
                                                    Display="Dynamic" ErrorMessage="Please Enter Village" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <!--=========================================================-->
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="" class="col-sm-6">Gram Panchayat<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <asp:TextBox ID="txtGramPanchayat" runat="server" CssClass="form-control"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtGramPanchayat"
                                                    Display="Dynamic" ErrorMessage="Please Enter Gram Panchayat" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <!--=========================================================-->
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="" class="col-sm-6">District<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <asp:TextBox ID="txtDistrict" runat="server" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDistrict"
                                                    Display="Dynamic" ErrorMessage="Please Enter District" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <!--=========================================================-->

                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="" class="col-sm-6">Name of the Tiger Reserve<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <asp:TextBox ID="txtTigerReserve" runat="server" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTigerReserve"
                                                    Display="Dynamic" ErrorMessage="Please Enter Tiger Reserve name" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <!--=========================================================-->

                                </div>
                                <asp:UpdatePanel ID="updatepnl" runat="server">
                                   <ContentTemplate>                             


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
                                                    <asp:RadioButtonList ID="RdbPanchayatOffice" AutoPostBack="true" OnSelectedIndexChanged="RdbPanchayatOffice_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                <div class="row" style="display:none;">
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="" class="col-sm-6">All weather<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <label class="radio-inline">
                                                    <asp:RadioButtonList ID="RdbAllWeatherRoad" AutoPostBack="true" OnSelectedIndexChanged="RdbAllWeatherRoad_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                            <label for="" class="col-sm-6" style="display:none;">Post office<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <label class="radio-inline" style="display:none;">
                                                    <asp:RadioButtonList ID="RdbPostOffice" AutoPostBack="true" OnSelectedIndexChanged="RdbPostOffice_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                            <label for="" class="col-sm-6">Mobile Network <span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <label class="radio-inline">
                                                    <asp:RadioButtonList ID="RdbMobileSignal" AutoPostBack="true" OnSelectedIndexChanged="RdbMobileSignal_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                            <label for="" class="col-sm-6">Access  to health care<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <label class="radio-inline">
                                                    <asp:RadioButtonList ID="RdbAccessibiliythealthCare" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessibiliythealthCare_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                            <label for="" class="col-sm-6">Access  to road<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <label class="radio-inline">
                                                    <asp:RadioButtonList ID="RdbAccessibiliyRoad" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessibiliyRoad_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                            <label for="" class="col-sm-6">Access  to education<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <label class="radio-inline">
                                                    <asp:RadioButtonList ID="RdbAccessbilitySchool" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessbilitySchool_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                                    <asp:TextBox ID="TxtAccessbilitySchool_HighSchool" Visible="false" CssClass="form-control" runat="server" placeholder="High School- how far?"></asp:TextBox>
                                                </label>
                                                <label>
                                                    <asp:TextBox ID="TxtAccessbilitySchool_College" Visible="false" CssClass="form-control" runat="server" placeholder="College- how far?"></asp:TextBox>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label for="" class="col-sm-6">Access  to electricity<span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <label class="radio-inline">
                                                    <asp:RadioButtonList ID="RdbAccessbilityElectrif" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessbilityElectrif_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <%--<input type="radio" name="optradio11" checked="">Yes--%>
                                                </label>
                                                <label id="lblRdbAccessbilityElectrif" runat="server" visible="false">
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
                                            <label for="" class="col-sm-6">Access  to Veterinary health care: <span class="red">*</span></label>
                                            <div class="col-sm-4 input-group">
                                                <label class="radio-inline">
                                                    <asp:RadioButtonList ID="RdbAccessiblityVeterinary" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessiblityVeterinary_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
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
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <%-- <input type="radio" name="optradio11" checked="">Yes--%>
                                                </label>
                                                <label id="lblRdbAvenuesEmployment1" runat="server" visible="false">
                                                    Primary sector (Agriculture, Animal Husbandry etc):
                                        <asp:TextBox ID="TxtAvenuesEmployment_Primary" CssClass="form-control" runat="server" placeholder="Primary sector (Agriculture, Animal Husbandry etc)"></asp:TextBox>
                                                </label>
                                                <label id="lblRdbAvenuesEmployment2" runat="server" visible="false">
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
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <%-- <input type="radio" name="optradio11" checked="">Yes--%>
                                                </label>
                                                <label id="lblRdbHumanWildlifecon" runat="server" visible="false">
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
                                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </label>
                                                <label id="lblRdbAccessFireFodNwfps" runat="server" visible="false">
                                                    Crop damage/injury/fatality:
                                        <asp:TextBox ID="TXTAccessFireFodNwfps" Visible="false" CssClass="form-control" runat="server" placeholder="Crop damage/injury/fatality"></asp:TextBox>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                       
                                   </ContentTemplate>
                                        </asp:UpdatePanel>
                                <!--******************************-->
                            </div>

                            <input type="button" id="btnprenxt" name="next" class="next_btn btn-primary ml10" value="Next" />

                        </fieldset>
                        <!--end pre-survey form -->


                        <!--start legal form -->

                        <fieldset id="second">
                            <h2 class="title">Legal Form</h2>
                            <p class="subtitle">Step 2</p>
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

                                                        <asp:DropDownList ID="DdlNotified1_a" runat="server" CssClass="form-control">
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
                                                        <asp:TextBox ID="TxtDateNotification1_b" runat="server" autocomplete="off" MaxLength="150" CssClass="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                            TargetControlID="TxtDateNotification1_b">
                                                        </cc1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TxtDateNotification1_b"
                                                    Display="Dynamic" ErrorMessage="Please Enter Date of Notification" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember2" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20">
                                                    <label class="col-sm-4 control-label">
                                                        Area(Ha.)<span class="red-text">*</span>
                                                    </label>
                                                    <div class="form-group col-md-5">
                                                        <asp:TextBox ID="TxtAreaHa1_c" runat="server" CssClass="form-control" autocomplete="off" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtAreaHa1_c"
                                                    Display="Dynamic" ErrorMessage="Please Enter Area(Ha.)" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember2" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20">
                                                    <label class="col-sm-4 control-label">
                                                        Compliance of section 38V of the Wildlife	(Protection) Act, 1972<span class="red-text">*</span>
                                                    </label>
                                                    <div class="form-group col-md-5">
                                                        <asp:TextBox ID="TxtCompliance1_d" runat="server" CssClass="form-control" autocomplete="off" MaxLength="100"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtCompliance1_d"
                                                    Display="Dynamic" ErrorMessage="Please Enter  Compliance of section 38V of the Wildlife	(Protection) Act, 1972" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember2" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
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
                                                        <asp:DropDownList ID="DdlNotified2_a" runat="server" CssClass="form-control">
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
                                                        <asp:TextBox ID="TxtDateNotification2_b" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy" autocomplete="off" MaxLength="150"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtDateNotification2_b"
                                                    Display="Dynamic" ErrorMessage="Please Enter Date of Notification" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember2" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                                            TargetControlID="TxtDateNotification2_b">
                                                        </cc1:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20">
                                                    <label class="col-sm-4 control-label">
                                                        Area(Ha.)<span class="red-text">*</span>
                                                    </label>
                                                    <div class="form-group col-md-5">

                                                        <asp:TextBox ID="TxtAreaHa2_c" runat="server" CssClass="form-control" autocomplete="off" MaxLength="15"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TxtAreaHa2_c"
                                                    Display="Dynamic" ErrorMessage="Please Enter  Area(Ha.)" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember2" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20">
                                                    <label class="col-sm-4 control-label">
                                                        Expert Committee (Constituted)<span class="red-text">*</span>
                                                    </label>
                                                    <div class="form-group col-md-5">
                                                        <asp:DropDownList ID="DdlExpertCommittee2_d" runat="server" CssClass="form-control">
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
                                                        <asp:TextBox ID="TxtDateConstitution2_e" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy" autocomplete="off" MaxLength="150"></asp:TextBox>
                                                        <%--<asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image1" runat="server" />--%>
                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                            TargetControlID="TxtDateConstitution2_e">
                                                        </cc1:CalendarExtender>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TxtDateConstitution2_e"
                                                    Display="Dynamic" ErrorMessage="Please Enter  Date of Constitution" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember2" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20" style="display:none">
                                                    <label class="col-sm-4 control-label">
                                                        Consultation With Gram Sabha<span class="red-text">*</span>
                                                    </label>
                                                    <div class="form-group col-md-5">
                                                        <asp:DropDownList ID="DdlConsultationGramSabha2_f" runat="server" CssClass="form-control">
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
                                                        <asp:TextBox ID="TxtNameGramSabha2_g" runat="server" CssClass="form-control" autocomplete="off" MaxLength="100"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtNameGramSabha2_g"
                                                    Display="Dynamic" ErrorMessage="Please Enter  Name of Gram Sabha" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember2" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>


                                            </div>
                                            <!--END OF ROW-->
                                            <div class="row">
                                                <div class="col-md-10 mt20">
                                                    <label class="col-sm-4 control-label">
                                                        <strong>Map of CTH & Buffer or Peripheral Area.<span style="color: green; font-weight: bolder;">(jpg or .pdf files only)</span></strong>
                                                    </label>
                                                    <div class="form-group col-md-5" id="dvFileUploadMapCTH2_h">
                                                        <asp:FileUpload ID="FileUploadMapCTH2_h" CssClass="form-control" runat="server" />
                                                        <br />
                                                         <asp:Label ID="lblMap" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20">
                                                    <label class="col-sm-4 control-label">
                                                        <strong>Upload file </strong>
                                                    </label>
                                                    <div class="form-group col-md-5">

                                                        <asp:FileUpload ID="FileUploadUploadfile2_i" runat="server" CssClass="form-control" /><asp:Label ID="lbl1" Visible="false" runat="server"></asp:Label>
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                        <br />
                                                        <asp:HyperLink ID="HypUploadfile2_i" Visible="false" Target="_blank" runat="server">Doc 1</asp:HyperLink>
                                                         <asp:Label ID="lblUpload" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20">
                                                    <label class="col-sm-4 control-label">
                                                        <strong>Upload file </strong>
                                                    </label>
                                                    <div class="form-group col-md-5">
                                                        <asp:FileUpload ID="FileUploadUploadfile2_j" CssClass="form-control" runat="server" /><asp:Label ID="lbl2" Visible="false" runat="server"></asp:Label>
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                        <br />
                                                        <asp:HyperLink ID="HypUploadfile2_j" Visible="false" Target="_blank" runat="server">Doc 2</asp:HyperLink>
                                                         <asp:Label ID="lblUpload1" runat="server" CssClass="for-view-lable"></asp:Label>
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
                                                        <asp:DropDownList ID="DdlCompleted3_a" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />
                                                        <span id="SpFileUploadCompleted3_a">
                                                            <asp:FileUpload ID="FileUploadCompleted3_a" runat="server" CssClass="form-control" ToolTip="(Upload only pdf!.)" /></span>
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                        <asp:Label ID="lblCompleted3_a" runat="server" CssClass="for-view-lable"></asp:Label>
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
                                                        <asp:DropDownList ID="DdlProvided4_a" runat="server" CssClass="form-control">
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
                                                        <asp:DropDownList ID="DdlObtained5_a" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 ">
                                                    <label class="col-sm-4 control-label"></label>
                                                    <div class="form-group col-md-5">
                                                        <button id="Button1" onclick="AddFileUpload()" class="btn btn-success btn-xs sml-btn" type="button"> Add more file <span class='glyphicon glyphicon-plus'></span></button>
                                                         <%--<input id="Button1" type="button"  value="add multiple file upload" onclick="AddFileUpload()" class="btn btn-success btn-xs sml-btn" />--%>
                                                    </div>
                                                    
                                                </div>
                                                <div class="col-md-10 ">
                                                    <label class="col-sm-4 control-label"></label>
                                                    <div class="form-group col-md-8">
                                                         <div id="FileUploadContainer">
                                                            <!--FileUpload Controls will be added here -->
                                                         </div>
                                                        <asp:Label ID="lblfile" runat="server" CssClass="for-view-lable"></asp:Label>
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
                                                        <asp:DropDownList ID="DdlObtained6_a" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                       
                                                        <span id="spanFileUpload6_a" style="display:none;">
                                                            <asp:FileUpload ID="FileUpload6_a" runat="server" CssClass="form-control" ToolTip="(Upload only pdf!.)" /></span>
                                                       
                                                    </div>
                                                </div>
                                                <div class="col-md-10 ">
                                                    <label class="col-sm-4 control-label"></label>
                                                    <div class="form-group col-md-5">
                                                        <button id="Button2" onclick="AddFileUpload1()" class="btn btn-success btn-xs sml-btn" type="button"> Add more file <span class='glyphicon glyphicon-plus'></span></button>
                                                         <%--<input id="Button2" type="button"  value='<%=HtmlUtilities.ConvertToPlainText("Add more file<span class='glyphicon glyphicon-plus'></span>") %>' onclick="AddFileUpload1()" class="btn btn-success btn-xs sml-btn" />--%>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 ">
                                                    <label class="col-sm-4 control-label"></label>
                                                    <div class="form-group col-md-8">
                                                         <div id="FileUploadContainer1">
                                                            <!--FileUpload Controls will be added here -->
                                                         </div>
                                                         <asp:Label ID="lblVolantry" runat="server" CssClass="for-view-lable"></asp:Label>
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
                                                        <asp:DropDownList ID="DdlProvided7_a" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />

                                                        <span id="spanFileUploadProvided7_a">
                                                            <asp:FileUpload ID="FileUploadProvided7_a" CssClass="form-control" runat="server" /></span>
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                         <asp:Label ID="lblFacilities" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <!--END OF ROW-->
                                            <div class="row mt20">
                                                <span class="frmheading"><strong>8.Sub-divisional, District and State – level committees for monitoring of Voluntary village relocation process & grievance redressal</strong></span>
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
                                                        <asp:DropDownList ID="DdlConstituted8_a_a" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                            <asp:ListItem Value="In-Progress">In-Progress</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />
                                                        <span id="spanFileUpload8_a_a">
                                                            <asp:FileUpload ID="FileUpload8_a_a" runat="server" CssClass="form-control" ToolTip="(Upload only pdf!.)" /></span>
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                         <asp:Label ID="lblFileUpload8_a_a" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20" id="DvTxtDateofconstitution8_a_b">
                                                    <label class="col-sm-4 control-label">
                                                        Date of constitution
                                                    </label>
                                                    <div class="form-group col-md-5">
                                                        <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                        <asp:TextBox ID="TxtDateofconstitution8_a_b" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy" autocomplete="off" MaxLength="150"></asp:TextBox>
                                                        <%--<asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image1" runat="server" />--%>
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                            TargetControlID="TxtDateofconstitution8_a_b">
                                                        </cc1:CalendarExtender>

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
                                                        <asp:DropDownList ID="DdlConstituted8_b_a" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                            <asp:ListItem Value="In-Progress">In-Progress</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />
                                                        <span id="spanDdlConstituted8_b_a">
                                                            <asp:FileUpload ID="FileUpload8_b_a" CssClass="form-control" runat="server" ToolTip="(Upload only pdf!.)" /></span>
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                         <asp:Label ID="lblConstituted" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="col-md-10 mt20" id="DvTxtDateofconstitution8_b_b">
                                                    <label class="col-sm-4 control-label">
                                                        Date of constitution
                                                    </label>
                                                    <div class="form-group col-md-5">
                                                        <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                        <asp:TextBox ID="TxtDateofconstitution8_b_b" runat="server" CssClass="form-control" autocomplete="off" MaxLength="150" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                                            TargetControlID="TxtDateofconstitution8_b_b">
                                                        </cc1:CalendarExtender>
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
                                                        <asp:DropDownList ID="Ddl8_c_a" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                            <asp:ListItem Value="In-Progress">In-Progress</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <br />

                                                        <span id="spanFileUpload8_c_a" class="file-path-wrapper">
                                                            <asp:FileUpload ID="FileUpload8_c_a" runat="server" CssClass="file-path validate form-control" ToolTip="(Upload only pdf!.)" /></span>
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                        <asp:Label ID="lblCon2" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="col-md-10 mt20" id="dvTxtDateofconstitution8_c_b">
                                                    <label class="col-sm-4 control-label">
                                                        Date of constitution
                                                    </label>
                                                    <div class="form-group col-md-5">
                                                        <%--<input name="DateNotification" id="DateNotification" runat="server" class=" form-control" type="date">--%>
                                                        <asp:TextBox ID="TxtDateofconstitution8_c_b" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy" autocomplete="off" MaxLength="150"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy"
                                                            TargetControlID="TxtDateofconstitution8_c_b">
                                                        </cc1:CalendarExtender>
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
                        <!--end legal form -->

                        <!--start Form 1 -->

                        <fieldset id="third">
                            <h2 class="title">Consent Form</h2>
                            <p class="subtitle">Step 3</p>
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
                                            <%--<td>Whether Core/critical tiger habitat has been notified by the State as per Section 38V of the Wildlife Act? (If so, please enclose a copy of the notification)</td>--%>
                                            
                                            <td>Enclose a copy of core/critical tiger habitat notification under Section 38 V of the Wildlife    (Protection) Act, 1972.</td>
                                            <td>
                                                <asp:RadioButtonList ID="RdbCheckItems1" RepeatDirection="Horizontal" runat="server" Width="36%">
                                                    <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <div id="divCheckItems1">
                                                    <span>

                                                        <span style="font-weight: bold;">Remarks:</span>
                                                        <br />
                                                        <asp:TextBox ID="TextCheckItems1" CssClass="form-control" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                    </span>

                                                    <span>
                                                        <br />
                                                        <span style="font-weight: bold;"></span>

                                                        <asp:FileUpload ID="FileUploadCheckItems1" CssClass="form-control" runat="server" ToolTip="(Upload only pdf!.)" />
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                        <asp:Label ID="lblCheck1" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>2</td>
                                            <td>
                                                <%--  Whether consent of villages obtained?
                                                Whether consent of Individual family obtained?--%>
                                                Whether “informed consent” of the Gram Sabha and Persons affected has been obtained?
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="RdbCheckItems2" RepeatDirection="Horizontal" runat="server" Width="36%">
                                                    <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <div id="divCheckItems2">
                                                    <span>

                                                        <span style="font-weight: bold;">Remarks:</span>
                                                        <br />
                                                        <asp:TextBox ID="TextCheckItems2" runat="server" CssClass="form-control" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                    </span>

                                                    <span>
                                                        <br />
                                                        <span style="font-weight: bold;"></span>

                                                        <asp:FileUpload ID="FileUploadCheckItems2" CssClass="form-control" runat="server" ToolTip="(Upload only pdf!.)" />
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                         <asp:Label ID="lblCheckItems2" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td>
                                                <%--Whether process of recognition and determination of rights and acquisition of land or forests rights of the ST and other forests dwelling person is complete? The lists are to be certified by Collectors.--
                                                Whether process of recognition and determination of rights and acquisition of land or forests rights of the Scheduled Tribes and other forests dwellers are settled?--%>
                                                Whether process of recognition and determination of rights and acquisition of land or forest    rights of the Scheduled Tribes and such other forest dwelling persons is complete under the Scheduled Tribes & Other traditional Forest Dwellers (Recognition of Forest Right) Act, 2006?

                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="RdbCheckItems3" RepeatDirection="Horizontal" runat="server" Width="36%">
                                                    <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <div id="divCheckItems3">
                                                    <span>

                                                        <span style="font-weight: bold;">Remarks:</span>
                                                        <br />
                                                        <asp:TextBox ID="TextCheckItems3" CssClass="form-control" runat="server" MaxLength="250"></asp:TextBox>
                                                    </span>

                                                    <span>
                                                        <br />
                                                        <span style="font-weight: bold;"></span>

                                                        <asp:FileUpload ID="FileUploadCheckItems3" CssClass="form-control" runat="server" ToolTip="(Upload only pdf!.)" />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                         <asp:Label ID="lblCheckItems3" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>

                                        <tr style="display:none;">
                                            <td>4</td>
                                            <td>Whether provisions of the ST & OFD (Recognition of Forests Rights) Act, 1972 and the Scheduled Tribes & Other Traditional Forest Dwellers (Recognition of Forest Rights) Act, 2006.</td>
                                            <td>
                                                <asp:RadioButtonList ID="RdbCheckItems4" RepeatDirection="Horizontal" runat="server" Width="36%">
                                                    <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <div id="divCheckItems4">
                                                    <span>

                                                        <span style="font-weight: bold;">Remarks:</span>
                                                        <br />
                                                        <asp:TextBox ID="TextCheckItems4" CssClass="form-control" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                    </span>

                                                    <span>
                                                        <br />
                                                        <span style="font-weight: bold;"></span>

                                                        <asp:FileUpload ID="FileUploadCheckItems4" CssClass="form-control" runat="server" ToolTip="(Upload only pdf!.)" />
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                        <asp:Label ID="lblCheckItems4" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>4</td>
                                            <td>Whether District Level & State Level Monitoring Committees have been constituted?</td>
                                            <td>
                                                <asp:RadioButtonList ID="RdbCheckItems5" RepeatDirection="Horizontal" runat="server" Width="36%">
                                                    <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <div id="divCheckItems5">
                                                    <span>

                                                        <span style="font-weight: bold;">Remarks:</span>
                                                        <br />
                                                        <asp:TextBox ID="TextCheckItems5" CssClass="form-control" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                    </span>

                                                    <span>
                                                        <br />

                                                        <asp:FileUpload ID="FileUploadCheckItems5" CssClass="form-control" runat="server" ToolTip="(Upload only pdf!.)" />
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                         <asp:Label ID="lblCheckItems5" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>5</td>
                                            <td>
                                                <%--What is the cut of date as decided by the Competent Authority?
                                                What is the cut of date as decided by the Competent Authority,  "for deciding the eligibility criteria"--%>
                                                Whether clearance under the Forest (Conservation) Act, 1980 obtained in case of resettlement to
                                                forest land?

                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="RdbCheckItems6" Visible="false" RepeatDirection="Horizontal" Width="36%" runat="server">
                                                    <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <div id="divCheckItems6">
                                                    <span>

                                                        <span style="font-weight: bold;">Remarks:</span>
                                                        <br />
                                                        <asp:TextBox ID="TextCheckItems6" CssClass="form-control" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>

                                                        <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image1" runat="server" /><br />
                                                        <cc1:CalendarExtender ID="CalendarExtender7" Format="dd/MM/yyyy" TargetControlID="TextCheckItems6"
                                                            PopupButtonID="Image1" runat="server">
                                                        </cc1:CalendarExtender>
                                                    </span>

                                                    <span style="display: none;">
                                                        <br />
                                                        <asp:FileUpload ID="FileUploadCheckItems6" CssClass="form-control" runat="server" ToolTip="(Upload only pdf!.)" />
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                       
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td>6</td>
                                            <td>Whether clearance under the Forest (Conservation) Act obtained in case of resettlement to forest land?</td>
                                            <td>
                                                <asp:RadioButtonList ID="RdbCheckItems7" RepeatDirection="Horizontal" runat="server" Width="36%">
                                                    <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <div id="divCheckItems7">
                                                    <span>

                                                        <span style="font-weight: bold;">Remarks:</span>
                                                        <br />
                                                        <asp:TextBox ID="TextCheckItems7" CssClass="form-control" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                    </span>

                                                    <span>
                                                        <br />

                                                        <asp:FileUpload ID="FileUploadCheckItems7" CssClass="form-control" runat="server" ToolTip="(Upload only pdf!.)" />
                                                        <br />
                                                        <span style="color: green; font-weight: bolder;">(pdf files only)</span>
                                                          <asp:Label ID="lblCheckItems6" runat="server" CssClass="for-view-lable"></asp:Label>
                                                    </span>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="col-md-12 mt20" style="padding-left: 0;">
                                <div class="row">

                                    <div class="col-md-10">
                                        <label class="col-sm-4 control-label">
                                            <asp:Label ID="Lblmsg" runat="server"></asp:Label>
                                        </label>
                                    </div>
                                    <div class="col-md-10" style="display:none;">
                                        <label class="col-sm-4 control-label">
                                            Token/Ticket Id(Generate automatic):
                                        </label>
                                        <div class="form-group col-md-5">
                                            <span id="" style="color: Green; font-weight: bold;">
                                                <asp:Label ID="LblTokenID" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label></span>
                                        </div>
                                    </div>
                                    <div class="col-md-10" style="display:none;">
                                        <label class="col-sm-4 control-label">
                                            Select Village Name <span class="red-text">*</span>:
                                        </label>
                                        <div class="form-group col-md-5">
                                            <asp:DropDownList ID="ddlselectname" runat="server" CssClass="form-control" Width="250px">
                                            </asp:DropDownList>
                                           
                                        </div>
                                    </div>
                                    <div class="col-md-10" style="display:none;">
                                        <label class="col-sm-4 control-label">
                                            Amount <span class="red-text">*</span>:
                                        </label>
                                        <div class="form-group col-md-5">
                                            <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" autocomplete="off" MaxLength="100" Width="250px" />
                                            
                                        </div>
                                    </div>
                                    <div class="col-md-10" style="display:none;">
                                        <label class="col-sm-4 control-label">
                                            Description <span class="red-text">*</span>:</label>
                                        <div class="form-group col-md-5">
                                            <asp:TextBox ID="txtfunddescription" TextMode="MultiLine" autocomplete="off" runat="server" MaxLength="500" CssClass="form-control" Width="250px" />
                                           
                                        </div>
                                    </div>
                                </div>
                            </div>
							<div class="col-md-12 display_inline">
                            <input type="button" name="previous" class="pre_btn btn-primary ml10" value="Previous" />
                            <div id="divSubmit" class="pull-left display_inline" runat="server" visible="false">
                            <asp:Button ID="btnsumbit" runat="server" Text="Submit" ValidationGroup="val"
                                CssClass="btn btn-primary center" OnClick="btnsumbit_Click" OnClientClick="return validationPage();" />
                                </div>
                            <asp:Button ID="btnBck" runat="server" CssClass="btn btn-success" Text="BACK" OnClick="btnBck_Click" />
							</div>
                            <%--<input onclick="location.href = 'auth/adminpanel/NGO/Tiger_Ngo.aspx'"  value="Next" type="button" class="btn btn-primary" />	--%>
                        </fieldset>
                        <!--end Form 1 -->
                    </div>
                    <!-- multistep form----end -->
                </div>
            </div>
            <div style="text-align: center;">
                <asp:Label ID="LblerrorFileUpload" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenField2" runat="server" />
        <div class="modal fade tophght" id="myModal" role="dialog">
        <div class="modal-dialog modwidth">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header nobdr">
                </div>
                <div class="modal-body text-center modwidth1">
                    <p><b>Forms:(pre/survey/legal/consent) has been updated successfully.</b></p>
                </div>
                <div class="modal-footer text-center procenter nobdr">
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="btn btn-success" Text="OK" />
                </div>
            </div>

        </div>
    </div>
      <div class="modal fade tophght" id="myModals" role="dialog">
        <div class="modal-dialog modwidth">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header nobdr">
                </div>
                <div class="modal-body text-center modwidth1">
                    <p><b>Forms:(pre/survey/legal/consent) has been submitted successfully.please follow the next steps.</b></p>
                </div>
                <div class="modal-footer text-center procenter nobdr">
                    <asp:Button ID="btncloases" runat="server" OnClick="btncloases_Click" CssClass="btn btn-success" Text="OK" />
                </div>
            </div>

        </div>
    </div>
    <%--   </ContentTemplate>
</asp:UpdatePanel>--%>
     <script type="text/javascript">
         var counter = 0;
         function AddFileUpload() {
             var div = document.createElement('DIV');
             div.innerHTML = '<input id="file' + counter + '" name = "Free_informed' + counter +
                             '" type="file" class="input_inline" />' +
                             '<input id="Button' + counter + '" type="button" ' +

                             'value="Remove" class="btn btn-danger btn-xs sml-btn" onclick = "RemoveFileUpload(this)" />';

             document.getElementById("FileUploadContainer").appendChild(div);
             counter++;
         }
         function RemoveFileUpload(div) {

             document.getElementById("FileUploadContainer").removeChild(div.parentNode);

         }
         var counter = 0;

         function AddFileUpload1() {

             var div = document.createElement('DIV');

             div.innerHTML = '<input id="file' + counter + '" name = "Voluntary' + counter +

                             '" type="file" class="input_inline" />' +

                             '<input id="Button' + counter + '" type="button" ' +

                             'value="Remove" class="btn btn-danger btn-xs sml-btn" onclick = "RemoveFileUpload1(this)" />';

             document.getElementById("FileUploadContainer1").appendChild(div);

             counter++;

         }

         function RemoveFileUpload1(div) {

             document.getElementById("FileUploadContainer1").removeChild(div.parentNode);

         }
        
    </script>
    <script>
         $(document).ready(function () {
             radio1();
             radio2();
             radio3();
             radio4();
             radio5();
             radio6();
             radio7();
             });

        
         function radio1() {
             var getvalue = $('#<%=RdbCheckItems1.ClientID%> :checked').val();
            
             if (getvalue == "Yes") {

                 $("#divCheckItems1").show();
                 // return false;
             }
             else {

                 $("#divCheckItems1").hide();
                 //  return true;
             }
         }
         function radio2() {
             var getvalue = $('#<%=RdbCheckItems2.ClientID%> :checked').val();
           
             if (getvalue == "Yes") {

                 $("#divCheckItems2").show();
                 // return false;
             }
             else {

                 $("#divCheckItems2").hide();
                 // return true;
             }
         }

        function radio3(){        
                 var getvalue = $('#<%=RdbCheckItems3.ClientID%> :checked').val();
                 // alert(getvalue);
                 if (getvalue == "Yes") {

                     $("#divCheckItems3").show();
                     // return false;
                 }
                 else {

                     $("#divCheckItems3").hide();
                     // return true;
                 }
           
         }

        function radio4(){       
                    var getvalue = $('#<%=RdbCheckItems4.ClientID%> :checked').val();
                  
                    if (getvalue == "Yes") {

                        $("#divCheckItems4").show();
                     
                    }
                    else {

                        $("#divCheckItems4").hide();
                      
                    }
             
        }

        function radio5(){
            
                    var getvalue = $('#<%=RdbCheckItems5.ClientID%> :checked').val();
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems5").show();
                        //  return false;
                    }
                    else {

                        $("#divCheckItems5").hide();
                        // return true;

                    }
              
        }
        function radio6() {
          
                    var getvalue = $('#<%=RdbCheckItems6.ClientID%> :checked').val();
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems6").show();
                        // return false;
                    }
                    else {

                        $("#divCheckItems6").hide();
                        //  return true;
                    }
                
        }

        function radio7(){
          
                    var getvalue = $('#<%=RdbCheckItems7.ClientID%> :checked').val();
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems7").show();
                        // return false;
                    }
                    else {

                        $("#divCheckItems7").hide();
                        // return true;
                    }
              
        }
    </script>
</asp:Content>

