<%@ Page Title="NTCA:Reply Process managment" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="EditLegalForm1.aspx.cs" Inherits="auth_Adminpanel_ProcessManegment_DfoUser_EditLegalForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../style.css" rel="stylesheet" />
     <script src="../Edit.js"></script>
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
    </style>

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

                }
                else {
                    $("#dvTxtDateNotification1_b").hide();

                }
            });
            $("#<%=DdlNotified2_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlNotified2_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#DvDateNotification2_b").show();

                }
                else {
                    $("#DvDateNotification2_b").hide();

                }
            });
            $("#<%=DdlExpertCommittee2_d.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlExpertCommittee2_d.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#DvDdlExpertCommittee2_d").show();

                }
                else {
                    $("#DvDdlExpertCommittee2_d").hide();

                }
            });
            $("#<%=DdlConsultationGramSabha2_f.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlConsultationGramSabha2_f.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#DvDdlConsultationGramSabha2_f").show();

                }
                else {
                    $("#DvDdlConsultationGramSabha2_f").hide();

                }
            });
            $("#<%=DdlCompleted3_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlCompleted3_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#SpFileUploadCompleted3_a").show();

                }
                else {
                    $("#SpFileUploadCompleted3_a").hide();

                }
            });
            $("#<%=DdlObtained6_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlObtained6_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanFileUpload6_a").show();

                }
                else {
                    $("#spanFileUpload6_a").hide();

                }
            });
            $("#<%=DdlProvided7_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlProvided7_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanFileUploadProvided7_a").show();

                }
                else {
                    $("#spanFileUploadProvided7_a").hide();

                }
            });
            $("#<%=DdlConstituted8_a_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlConstituted8_a_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanFileUpload8_a_a").show();
                    $("#DvTxtDateofconstitution8_a_b").show();
                }
                else {
                    $("#spanFileUpload8_a_a").hide();
                    $("#DvTxtDateofconstitution8_a_b").hide();

                }
            });
            $("#<%=DdlConstituted8_b_a.ClientID %>").change(function () {
                var getvalue = $("#<%=DdlConstituted8_b_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanDdlConstituted8_b_a").show();
                    $("#DvTxtDateofconstitution8_b_b").show();
                }
                else {
                    $("#spanDdlConstituted8_b_a").hide();
                    $("#DvTxtDateofconstitution8_b_b").hide();

                }
            });
            $("#<%=Ddl8_c_a.ClientID %>").change(function () {
                var getvalue = $("#<%=Ddl8_c_a.ClientID %>").val();
                if (getvalue == "Yes") {
                    $("#spanFileUpload8_c_a").show();
                    $("#dvTxtDateofconstitution8_c_b").show();
                }
                else {
                    $("#spanFileUpload8_c_a").hide();
                    $("#dvTxtDateofconstitution8_c_b").hide();

                }
            });
            //end first panel =conditon wise control visible true false


            //------start 2 second panel---=conditon wise control visible true false--
            $('#<%=RdbCheckItems1.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems1").show();
                    }
                    else {

                        $("#divCheckItems1").hide();

                    }
                });
            });

            $('#<%=RdbCheckItems2.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems2").show();
                    }
                    else {

                        $("#divCheckItems2").hide();

                    }
                });
            });//-----------
            $('#<%=RdbCheckItems3.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems3").show();
                    }
                    else {

                        $("#divCheckItems3").hide();

                    }
                });
            });//-----------
            $('#<%=RdbCheckItems4.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems4").show();
                    }
                    else {

                        $("#divCheckItems4").hide();

                    }
                });
            });//-----------
            $('#<%=RdbCheckItems5.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems5").show();
                    }
                    else {

                        $("#divCheckItems5").hide();

                    }
                });
            });//-----------
            $('#<%=RdbCheckItems6.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems6").show();
                    }
                    else {

                        $("#divCheckItems6").hide();

                    }
                });
            });//-----------
            $('#<%=RdbCheckItems7.ClientID%> input[type="radio"]').each(function () {
                $(this).click(function () {
                    var getvalue = (this).value;
                    // alert(getvalue);
                    if (getvalue == "Yes") {

                        $("#divCheckItems7").show();
                    }
                    else {

                        $("#divCheckItems7").hide();

                    }
                });
            });//-----------

            //------end 2 second panel-=conditon wise control visible true false----



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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="row">
                <div class="col-lg-12 top20 bottom20">
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
                                <li class="active">Legal Form</li>
                                <li>Form 1</li>
                               <%-- <li>Upate record</li>--%>
                            </ul>

                            <!-- legal form -->

                            <fieldset id="first">
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
                                                            <asp:TextBox ID="TxtDateNotification1_b" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy" autocomplete="off" MaxLength="150"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                                TargetControlID="TxtDateNotification1_b">
                                                            </cc1:CalendarExtender>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Area(Ha.)<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:TextBox ID="TxtAreaHa1_c" runat="server" CssClass="form-control" autocomplete="off" MaxLength="15"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            Compliance of section 38V of the Wildlife	(Protection) Act, 1972<span class="red-text">*</span>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                            <asp:TextBox ID="TxtCompliance1_d" runat="server" CssClass="form-control" autocomplete="off" MaxLength="100"></asp:TextBox>

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

                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
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
                                                            <asp:TextBox ID="TxtNameGramSabha2_g" runat="server" CssClass="form-control" autocomplete="off" MaxLength="200"></asp:TextBox>

                                                        </div>
                                                    </div>


                                                </div>
                                                <!--END OF ROW-->
                                                <div class="row">
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            <strong>Map of CTH & Buffer or Peripheral Area.<span style=" color:green; font-weight:bolder;">(jpg or .pdf files only)</span></strong>
                                                        </label>
                                                        <div class="form-group col-md-5" id="dvFileUploadMapCTH2_h">
                                                            <asp:FileUpload ID="FileUploadMapCTH2_h" runat="server" BorderColor="#B4BA7E" />
                                                            <br />
                                                            <asp:HyperLink ID="HypMapCTH2_h" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            <strong>Upload file </strong>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                           
                                                        <asp:FileUpload ID="FileUploadUploadfile2_i" runat="server" BorderColor="#B4BA7E" /><asp:Label ID="lbl1" Visible="false" runat="server"></asp:Label>
                                                            <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
                                                            <asp:HyperLink ID="HypUploadfile2_i" ForeColor="Blue" Font-Underline="true" Target="_blank" runat="server"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-10 mt20">
                                                        <label class="col-sm-4 control-label">
                                                            <strong>Upload file </strong>
                                                        </label>
                                                        <div class="form-group col-md-5">
                                                           <asp:FileUpload ID="FileUploadUploadfile2_j" runat="server" BorderColor="#B4BA7E" /><asp:Label ID="lbl2" Visible="false" runat="server"></asp:Label>
                                                            <br />
                                                        <span style="color:green; font-weight:bolder;">(pdf files only)</span>
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
                                                            <asp:DropDownList ID="DdlCompleted3_a" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>

                                                            <span id="SpFileUploadCompleted3_a">
                                                            <asp:FileUpload ID="FileUploadCompleted3_a" runat="server" ToolTip="(Upload only pdf!.)" /></span>
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

                                                            <span id="spanFileUpload6_a">
                                                            <asp:FileUpload ID="FileUpload6_a" runat="server" ToolTip="(Upload only pdf!.)" /></span>
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
                                                            <asp:DropDownList ID="DdlProvided7_a" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                            </asp:DropDownList>

                                                            <span id="spanFileUploadProvided7_a">
                                                            <asp:FileUpload ID="FileUploadProvided7_a" runat="server" /></span>
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
                                                            <asp:DropDownList ID="DdlConstituted8_a_a" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                <asp:ListItem Value="No">No</asp:ListItem>
                                                                <asp:ListItem Value="In-Progress">In-Progress</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <span id="spanFileUpload8_a_a">
                                                            <asp:FileUpload ID="FileUpload8_a_a" runat="server" ToolTip="(Upload only pdf!.)" /></span>
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
                                                            <span id="spanDdlConstituted8_b_a">
                                                            <asp:FileUpload ID="FileUpload8_b_a" runat="server" ToolTip="(Upload only pdf!.)" /></span>
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
                                                            <asp:TextBox ID="TxtDateofconstitution8_b_b" runat="server" CssClass="form-control" placeholder="dd/mm/yyyy" autocomplete="off" MaxLength="150"></asp:TextBox>
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

                                                            <span id="spanFileUpload8_c_a" class="file-path-wrapper">
                                                            <asp:FileUpload ID="FileUpload8_c_a" runat="server" CssClass="file-path validate" ToolTip="(Upload only pdf!.)" /></span>
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
                                                    <asp:RadioButtonList ID="RdbCheckItems1" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems1">

                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems1" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
                                                           

                                                            <asp:FileUpload ID="FileUploadCheckItems1" runat="server" ToolTip="(Upload only pdf!.)" />
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
                                                    <asp:RadioButtonList ID="RdbCheckItems2" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems2">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems2" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
                                                          

                                                            <asp:FileUpload ID="FileUploadCheckItems2" runat="server" ToolTip="(Upload only pdf!.)" />
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
                                                    <asp:RadioButtonList ID="RdbCheckItems3" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems3">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems3" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
                                                           

                                                            <asp:FileUpload ID="FileUploadCheckItems3" runat="server" ToolTip="(Upload only pdf!.)" />
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
                                                    <asp:RadioButtonList ID="RdbCheckItems4" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems4">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems4" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
                                                          

                                                            <asp:FileUpload ID="FileUploadCheckItems4" runat="server" ToolTip="(Upload only pdf!.)" />
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
                                                    <asp:RadioButtonList ID="RdbCheckItems5" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems5">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems5" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
                                                           

                                                            <asp:FileUpload ID="FileUploadCheckItems5" runat="server" ToolTip="(Upload only pdf!.)" />
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
                                                    <asp:RadioButtonList ID="RdbCheckItems6" Visible="false" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems6">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems6" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                             <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg"  ID="Image1" runat="server" /><br />
                                                        <cc1:CalendarExtender ID="CalendarExtender7" Format="dd/MM/yyyy" TargetControlID="TextCheckItems6"
                                                            PopupButtonID="Image1" runat="server">
                                                        </cc1:CalendarExtender>
                                                        </span>

                                                        <span style="display:none;">
                                                           

                                                            <asp:FileUpload ID="FileUploadCheckItems6" runat="server" ToolTip="(Upload only pdf!.)" />
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
                                                    <asp:RadioButtonList ID="RdbCheckItems7" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <div id="divCheckItems7">
                                                        <span>

                                                            <span style="font-weight: bold;">Result:</span>
                                                            <br />
                                                            <asp:TextBox ID="TextCheckItems7" runat="server" autocomplete="off" MaxLength="250"></asp:TextBox>
                                                        </span>

                                                        <span>
                                                          

                                                            <asp:FileUpload ID="FileUploadCheckItems7" runat="server" ToolTip="(Upload only pdf!.)" />
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
                                 <asp:Button ID="btnsumbit" runat="server" Text="Update" ValidationGroup="val"
                                    CssClass="btn btn-primary center" OnClick="btnsumbit_Click" />
                               <%-- <asp:Button ID="BtnBack" runat="server" Text="Back" CausesValidation="false"
                                    CssClass="btn btn-primary center" OnClick="BtnBack_Click" />--%>
                            </fieldset>
                            <!-- Process form -->
                         <%--   <fieldset>
                                <h2 class="title">Update record</h2>
                                <p class="subtitle">Step 3</p>
                                <div class="col-md-12 mt20" style="padding-left: 0;">
                                </div>
                                <input type="button" class="pre_btn btn-primary ml10" value="Previous" />
                               
                            </fieldset>--%>
                        </div>
                        <!--end multistep form---- -->
                    </div>
                </div>
            </div>
        </div>
        <div style="text-align: center;">
            <asp:Button ID="Button1" runat="server" Text="Back"
                CssClass="btn btn-primary center" OnClick="Button1_Click" />
            <asp:Label ID="LblerrorFileUpload" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

