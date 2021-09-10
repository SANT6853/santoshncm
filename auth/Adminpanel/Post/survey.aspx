<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="survey.aspx.cs" Inherits="auth_Adminpanel_Post_survey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
        function checkval() {
            var SurveyDate = $('#contentbody_txtSurveyDate').val();
            var NameofSurveyor = $('#contentbody_txtNameofSurveyor').val();
            var Designation = $('#contentbody_txtDesignation').val();
            var PreState = $('#contentbody_ddlState').val();
            var PreTigerReserve = $('#contentbody_ddlTigerReserve').val();
            var PreVillage = $('#contentbody_ddlVillage').val();
            var PostState = $('#contentbody_ddlPostState').val();
            var Postdistict = $('#contentbody_ddlDistric').val();
            var Postgrampanchayat = $('#contentbody_ddlGramPanchayat').val();
            var PostReserve = $('#contentbody_ddlPostReserve').val();
            var PostVillgae = $('#contentbody_txtPostvillage').val();
            var Latitude = $('#contentbody_txtLatitude').val();
            var Longitude = $('#contentbody_txtLongitude').val();
            if (SurveyDate == '') {
                alert('Please Select SurveyDate');
                $('#contentbody_txtSurveyDate').focus();
                return false;
            }
            if (NameofSurveyor == '') {
                alert('Please Enter Name of surveyor');
                $('#contentbody_txtNameofSurveyor').focus();
                return false;
            }
            if (Designation == '') {
                alert('Please Enter Designation of Surveyor');
                $('#contentbody_txtDesignation').focus();
                return false;
            }
            if (PreState == 0) {
                alert('Please Select Pre State');
                $('#contentbody_ddlState').focus();
                return false;
            }
            if (PreTigerReserve == 0) {
                alert('Please Select Pre Tiger Reserve');
                $('#contentbody_ddlTigerReserve').focus();
                return false;
            }
            if (PreTigerReserve == 0) {
                alert('Please Select Pre Tiger Reserve');
                $('#contentbody_ddlTigerReserve').focus();
                return false;
            }
            if (PreVillage == 0) {
                alert('Please Select Pre Village');
                $('#contentbody_ddlVillage').focus();
                return false;
            }
            if (PostState == 0) {
                alert('Please Select Post State');
                $('#contentbody_ddlPostState').focus();
                return false;
            }
            if (Postdistict == 0) {
                alert('Please Select Post District');
                $('#contentbody_ddlDistric').focus();
                return false;
            }
            if (Postgrampanchayat == 0) {
                alert('Please Select Post Gram Panchayat');
                $('#contentbody_ddlGramPanchayat').focus();
                return false;
            }
            if (PostReserve == 0) {
                alert('Please Select Post Tiger Reserve');
                $('#contentbody_ddlPostReserve').focus();
                return false;
            }
            if (PostVillgae == 0) {
                alert('Please Enter Post Village');
                $('#contentbody_txtPostvillage').focus();
                return false;
            }
            if (Latitude == 0) {
                alert('Please enter latitude');
                $('#contentbody_txtLatitude').focus();
                return false;
            }
            if (Longitude == 0) {
                alert('Please enter longitude');
                $('#contentbody_txtLongitude').focus();
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
      <div class="container-fluid" style="margin-bottom: 62px; background: #fff;">
        <div class="modal fade tophght" id="myModal" role="dialog">
            <div class="modal-dialog modwidth">
                <div class="modal-content">
                    <div class="modal-header nobdr">
                    </div>
                    <div class="modal-body text-center modwidth1">
                        <p><b>Survey Details has been save successfully.Please proceed to next step.</b></p>
                    </div>
                    <div class="modal-footer text-center procenter nobdr">
                        <asp:Button ID="btnnextstep" runat="server" CssClass="btn btn-success" Text="OK" OnClick="btnnextstep_Click" />
                    </div>
                </div>
            </div>
        </div>
           <div class="modal fade tophght" id="myModals" role="dialog">
            <div class="modal-dialog modwidth">
                <div class="modal-content">
                    <div class="modal-header nobdr">
                    </div>
                    <div class="modal-body text-center modwidth1">
                        <p><b>Survey Details has been update successfully.</b></p>
                    </div>
                    <div class="modal-footer text-center procenter nobdr">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="OK" />
                    </div>
                </div>

            </div>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-sm-12 tile">
                        <!-- <div class="headfrm">
                            <h3>Survey Form </h3>
                        </div>-->
                        <div class="box box-primary1" style="margin-bottom: 25px;">
                            <div class="stpdiv">
                                <span class="box-title stp1 stepArrow stepActive">Step-1</span>
                                <span class="box-title stp1 stepArrow">Step-2</span>
                                <span class="box-title stp1 stepArrow">Step-3</span>
                                <span class="box-title stp1 stepArrow">Step-4</span>
                                <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 4</span>
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
                                    <asp:TextBox ID="txtSurveyDate" runat="server" CssClass="form-control" placeholder="DD/MM/YYYY"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSurveyDate" ForeColor="Red"
                                        Display="Dynamic" ErrorMessage="Enter date in dd/mm/yyyy format" SetFocusOnError="True"
                                        ValidationGroup="Add" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"></asp:RegularExpressionValidator>
                                    <AjaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                        TargetControlID="txtSurveyDate">
                                    </AjaxToolkit:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Name of surveyor<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:TextBox ID="txtNameofSurveyor" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Designation of Surveyor<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
						<div class="clearfix"></div>
						<hr>
                        <!--=========================================================-->
                        <!--=========================================================-->
                        <%--<div id="divPre" runat="server" visible="false">--%>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="exampleInputEmail1" class="col-sm-6">State (Pre)<span class="red">*</span></label>
                                <div class=" col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                       
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Tiger Reserve (Pre)<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlTigerReserve" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTigerReserve_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Village (Pre)<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

						<div class="clearfix"></div>
						<hr>
                          <%--  </div>--%>
                        <!--=========================================================-->
                         <div class="col-sm-6">
                            <div class="form-group">
                                <label for="exampleInputEmail1" class="col-sm-6">State (Post)<span class="red">*</span></label>
                                <div class=" col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlPostState" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPostState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                         <!--=========================================================-->
                        <div class="col-sm-6" ">
                            <div class="form-group">
                                <label for="" class="col-sm-6">District (Post)<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlDistric" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistric_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->

                        <!--=========================================================-->
                        <div class="col-sm-6" ">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Gram Panchayat (Post)<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlGramPanchayat" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->


                          <div class="col-sm-6" runat="server" visible="false">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Tiger Reserve<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlPostReserve" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPostReserve_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Village (Post)<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlPostVillgae" runat="server" CssClass="form-control" Visible="false"></asp:DropDownList>
                                    <asp:TextBox ID="txtPostvillage" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Legal Status of Land<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:DropDownList ID="ddlVillageLegalStatus" ValidationGroup="GroupVmg" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" >
                                            <asp:ListItem Value="0">Select Status</asp:ListItem>
                                            <asp:ListItem Value="1">Revenue Land</asp:ListItem>
                                            <asp:ListItem Value="2">Forest Land</asp:ListItem>
                                            <asp:ListItem Value="3">Any Other</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
						<div class="clearfix"></div>
						<hr>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Latitude<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control" placeholder="00.00000"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!--=========================================================-->
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="" class="col-sm-6">Longitude<span class="red">*</span></label>
                                <div class="col-sm-4 input-group">
                                    <asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control" placeholder="00.00000"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--=========================================================-->
                    <span>Note:- Format For Latitude and Logitude (22.212900)</span>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="" class="col-sm-6">Latitude and Longitude<span class="red"></span></label>
                            <div class="col-sm-4 input-group">
                            </div>
                            <a href="https://www.latlong.net/" style="color: blue; text-decoration: underline;" target="_blank">Please click here for longitude and latitude</a>
                        </div>
                    </div>

                    <!--=========================================================-->
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
                        <div class="row">
                            <div class="col-sm-6" style="display:none;">
                                <div class="form-group">
                                    <label for="" class="col-sm-6">All weather road<span class="red">*</span></label>
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
                            <div class="col-sm-6" style="display:none;">
                                <div class="form-group">
                                    <label for="" class="col-sm-6">Post office<span class="red">*</span></label>
                                    <div class="col-sm-4 input-group">
                                        <label class="radio-inline">
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
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label for="" class="col-sm-6">Mobile Signal<span class="red">*</span></label>
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
                                    <label for="" class="col-sm-6">Access to health care<span class="red">*</span></label>
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
                                    <label for="" class="col-sm-6">Access to road<span class="red">*</span></label>
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
                                    <label for="" class="col-sm-6">Access to education<span class="red">*</span></label>
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
                                    <label for="" class="col-sm-6">Access to electricity<span class="red">*</span></label>
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
                                    <label for="" class="col-sm-6">Access to Veterinary health care: <span class="red">*</span></label>
                                    <div class="col-sm-4 input-group">
                                        <label class="radio-inline">
                                            <asp:RadioButtonList ID="RdbAccessiblityVeterinary" AutoPostBack="true" OnSelectedIndexChanged="RdbAccessiblityVeterinary_SelectedIndexChanged" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<input type="radio" name="optradio11" checked="">Yes--%>
                                        </label>
                                        <label>
                                            <asp:TextBox ID="TxtAccessiblityVeterinary" Visible="false" CssClass="form-control" runat="server" placeholder="How far?"></asp:TextBox>
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
                                           Human Death:
                                        <asp:TextBox ID="TxtRdbHumanWildlifecon" Visible="false" CssClass="form-control" runat="server" placeholder="Human Death"></asp:TextBox>
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
                                           Access to firewood:
                                        <asp:TextBox ID="TXTAccessFireFodNwfps" Visible="false" CssClass="form-control" runat="server" placeholder="Access to firewood"></asp:TextBox>
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                     </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
          
                    <div class="col-sm-12">
                        <hr />
                        <div class="" style="margin-bottom: 25px; text-align: left;" id="divfinal" runat="server">
                           
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" Text="Save & Next" OnClick="btnSave_Click" title="Click here for next step" OnClientClick="return checkval();" />
                            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
                           
                        </div>
                         
                    </div>
                </div>
    <script>
        $('[data-toggle="tooltip"]').tooltip();
    </script>
</asp:Content>

