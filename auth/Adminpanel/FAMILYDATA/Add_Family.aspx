<%@ Page Title="NTCA:Add Family" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Add_Family.aspx.cs" Inherits="auth_Adminpanel_FAMILYDATA_Add_Family" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .form-horizontal .control-label {
            padding-top: 7px;
            margin-bottom: 0;
            text-align: left;
        }

        .txtcolor {
            color: red;
        }

        .table-2 td {
            padding: 4px;
            text-align: left;
            width: 23% !important;
            vertical-align: top;
        }

        .table-3 td {
            padding: 9px 0px;
            text-align: left;
            vertical-align: text-top;
        }

        select {
            width: 70%;
        }

        .textfield-drop {
            width: 70%;
        }

        div.ajax__calendar_days table tr td {
            padding: 1px;
        }

        .modal-dialog {
            top: 7%;
        }

        .ty23 {
            height: 300px;
            overflow-y: auto;
        }

        div.ajax__calendar_container {
            width: 215px;
        }

        .red-text-1a {
            color: red;
        }

        #contentbody_txtsurdate {
            float: left;
            margin-right: 2px;
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

        .stpdiv {
            padding: 0 0 30px 0;
        }

        .input_inline {
            margin-bottom: 5px;
            display: inline-block !important;
            width: 212px;
            border: 1px solid #e0e0e0;
            margin-right: 3px;
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
            font-size: 120%;
        }

        #btnyes {
            margin-bottom: 0px !important;
        }

        .nobdr {
            border: none !important;
        }

        .tophght {
            top: 26% !important;
        }
    </style>
    <script language="Javascript">
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
    //-->
    </script>
    <script type="text/javascript">
        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });
    </script>
    <script language="JavaScript" type="text/javascript">
        function checkfilesize(source, arguments) {
            arguments.IsValid = false;

            var axo = new ActiveXObject("Scripting.FileSystemObject");
            thefile = axo.getFile(arguments.Value);
            var size = thefile.size;
            if (size > 3145728) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }


        }
        function checkfilesize1(source, arguments) {
            arguments.IsValid = false;

            var axo = new ActiveXObject("Scripting.FileSystemObject");
            thefile = axo.getFile(arguments.Value);
            var size = thefile.size;
            if (size > 3145728) {
                arguments.IsValid = false;
            }
            else {
                arguments.IsValid = true;
            }


        }

        function ValidateFileUpload1(Source, args) {
            var fuData = document.getElementById('<%= fileUpload_Menu.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
                // alert(Extension);
                if (Extension == "jpg" || Extension == "JPG" || Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "PNG") {
                    args.IsValid = true; // Valid file type
                }
                else {
                    args.IsValid = false; // Not valid file type
                }
            }
        }
        function ValidateFileUpload11(Source, args) {
            var fuData = document.getElementById('<%= fileUploadCardDetails.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                if (Extension == "jpg" || Extension == "JPG" || Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "PNG") {
                    args.IsValid = true; // Valid file type
                }
                else {
                    args.IsValid = false; // Not valid file type
                }
            }
        }
        function checkfile(Source, args) {
            var file = $('#FileUploadContainer').find('[type = file]').length;
            if (file == 0) {
                args.IsValid = false;

            }
            else {
                args.IsValid = true;
            }


        }


        function CompareDates(source, args) {

            var fromDate = new Date();
            var txtFromDate = document.getElementById('<%= TxtDOB.ClientID %>').value;
            var FromDate = txtFromDate.split("/");
            /*Start 'Date to String' conversion block, this block is required because javascript do not provide any direct function to convert 'String to Date' */
            var fdd = FromDate[0]; //get the day part
            var fmm = FromDate[1]; //get the month part
            var fyyyy = FromDate[2]; //get the year part
            fromDate.setUTCDate(fdd);
            fromDate.setUTCMonth(fmm - 1);
            fromDate.setUTCFullYear(fyyyy);
            var toDate = new Date();
            var txtToDate = document.getElementById('<%= HiddenField2.ClientID %>').value;
        var ToDate = txtToDate.split("/");
        var tdd = ToDate[0]; //get the day part
        var tmm = ToDate[1]; //get the month part
        var tyyyy = ToDate[2]; //get the year part
        toDate.setUTCDate(tdd);
        toDate.setUTCMonth(tmm - 1);
        toDate.setUTCFullYear(tyyyy);
        //end of 'String to Date' conversion block
        var difference = toDate.getTime() - fromDate.getTime();
        var daysDifference = Math.floor(difference / 1000 / 60 / 60 / 24);

        //     alert('df');
        difference -= daysDifference * 1000 * 60 * 60 * 24;

        //    //if diffrence is greater then 366 then invalidate, else form is valid
        // if(difference > 366 )
        if (daysDifference < 0)
            args.IsValid = false;
        else
            args.IsValid = true;
            //else
            //  args.IsValid = true;
        }

        $(document).ready(function () {
            $("[id*=lnkViewDetailss]").click(function (event) {
                //  debugger;
                //  var feedbackid = $(this).attr("data-id");
                // alert(villageid);
                var pagrUrl = "Tooltip.html";
                $('#demoModal').modal('show').find('.modal-body').load(pagrUrl);

                return false;
            });
            //------------
            $("#ToolTipHref").mouseover(function () {
                $("#TooltipContent").show();
                return false;
                // alert('mouseover');
                // $("p").css("background-color", "yellow");
            });
            $("#ToolTipHref").mouseout(function () {
                $("#TooltipContent").hide();
                return false;
                // alert('mouseout');
                //$("p").css("background-color", "lightgray");
            });


            $("#ToolTipHref1").mouseover(function () {
                $("#TooltipContent1").show();
                return false;
                // alert('mouseover');
                // $("p").css("background-color", "yellow");
            });
            $("#ToolTipHref1").mouseout(function () {
                $("#TooltipContent1").hide();
                return false;
                // alert('mouseout');
                //$("p").css("background-color", "lightgray");
            });
		//---------------------
		// $('#<%= txtsurdate.ClientID %>').attr('readonly', true);
            $('#<%= txtsurdate.ClientID %>').prop("readonly", "readonly");
            $('#<%= TxtDOB.ClientID %>').prop("readonly", "readonly");


        $('#<%= txtage.ClientID %>').attr('readonly', true);
        $('#<%= txtlivestock.ClientID %>').attr('readonly', true);

        //------------------TotalLivestock------------------------
        $('#<%= TxtNoCow.ClientID %>').on('keyup', function () {

            TotalLivestock();
        });
        $('#<%= TxtBuffalo.ClientID %>').on('keyup', function () {
            TotalLivestock();
        });
        $('#<%= TxtSheep.ClientID %>').on('keyup', function () {
            TotalLivestock();
        });
        $('#<%= TxtGoat.ClientID %>').on('keyup', function () {
            TotalLivestock();
        });
        $('#<%= txtotheranimal.ClientID %>').on('keyup', function () {
            TotalLivestock();
        });

        });

        function TotalLivestock() {
            // alert('ffd');
            var cow = "0";
            var Buffalo = "0";
            var sheep = "0";
            var Goat = "0";
            var otherAnimal = "0";

            var Total = "0";
            if ($('#<%= TxtNoCow.ClientID %>').val() == "") {
                cow = "0";
            }
            else {
                cow = $('#<%= TxtNoCow.ClientID %>').val();
            }
            if ($('#<%= TxtBuffalo.ClientID %>').val() == "") {
                Buffalo = "0";
            }
            else {
                Buffalo = $('#<%= TxtBuffalo.ClientID %>').val();
            }
            if ($('#<%= TxtSheep.ClientID %>').val() == "") {
            sheep = "0";
        }
        else {
            sheep = $('#<%= TxtSheep.ClientID %>').val();
        }
        if ($('#<%= TxtGoat.ClientID %>').val() == "") {
            Goat = "0";
        }
        else {
            Goat = $('#<%= TxtGoat.ClientID %>').val();
        }
        if ($('#<%= txtotheranimal.ClientID %>').val() == "") {
            otherAnimal = "0";
        }
        else {
            otherAnimal = $('#<%= txtotheranimal.ClientID %>').val();
        }
        //-------------
        Total = parseInt(cow) + parseInt(Buffalo) + parseInt(sheep) + parseInt(Goat) + parseInt(otherAnimal);
        $('#<%= txtlivestock.ClientID %>').val(Total);
            //alert(Total);
        }//
        function validateData() {

            var DobAge = $('#<%= TxtBnameMobile .ClientID %>').val();
            $('#<%= LblTxtBnameMobile.ClientID %>').html("");
            $('#<%= lblTxtBankPostAccountNo.ClientID %>').html("");
        $('#<%= lblTxtBankPostOfficeName.ClientID %>').html("");
        $('#<%= lblTxtIFSC.ClientID %>').html("");
        $('#<%= lblTxtBankPostOfficeAdress.ClientID %>').html("");
        $('#<%= lblTxtAadharNo.ClientID %>').html("");
        alert($('#<%= ddlselectrelation .ClientID %>').val());
        if ($('#<%= ddlselectrelation .ClientID %>').val() == "") {

        }
        if (DobAge != "") {
            if (DobAge >= 18) {
                //alert('fdfd');
                if ($('#<%= TxtBnameMobile .ClientID %>').val() == "") {
					//  alert($('#<%= TxtBnameMobile .ClientID %>').val());
                    $('#<%= LblTxtBnameMobile.ClientID %>').html("<span style='color:red; font-size:12px;'>Please enter tiger reserve name</span>");
                    return false;
                }
                if ($('#<%= TxtBankPostAccountNo.ClientID %>').val() == "") {

                    $('#<%= lblTxtBankPostAccountNo.ClientID %>').html("<span style='color:red;font-size:12px;'>Please enter bank post office account no.</span>");
                    return false;
                }
                if ($('#<%= TxtBankPostOfficeName .ClientID %>').val() == "") {

                    $('#<%= lblTxtBankPostOfficeName.ClientID %>').html("<span style='color:red;font-size:12px;'>Please enter post office name.</span>");
                    return false;
                }
                if ($('#<%= TxtIFSC.ClientID %>').val() == "") {
                    $('#<%= lblTxtIFSC.ClientID %>').html("<span style='color:red;font-size:12px;'>Please enter ifsc code.</span>");
                    return false;
                }
                if ($('#<%= TxtBankPostOfficeAdress.ClientID %>').val() == "") {
                    $('#<%= lblTxtBankPostOfficeAdress.ClientID %>').html("<span style='color:red;font-size:12px;'>Please enter bank post office number.</span>");
                    return false;
                }
                if ($('#<%= TxtAadharNo.ClientID %>').val() == "") {
                    $('#<%= lblTxtAadharNo.ClientID %>').html("<span style='color:red;font-size:12px;'>Please enter aadhar no</span>");
                    return false;
                }
            }
        }

        return true;

        }

        function PhotoMethod() {
            alert($('#<%= ddlselectrelation .ClientID %>').val());

            return true;
        }
    </script>
    <script>
        function modelpopup(a, b) {
            if (Page_ClientValidate("ADD")) {
                $('#myModal').modal('show');
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <div class="modal fade tophght" id="myModal" role="dialog">
        <div class="modal-dialog modwidth">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header nobdr"></div>
                <div class="modal-body text-center modwidth1">
                    <p><b>Are you sure,you want to submit the form ? After submitting  the form you will not able to add more family members.</b></p>
                </div>
                <div class="modal-footer text-center procenter nobdr">
                    <asp:Button ID="ImgbtnSubmit" runat="server" Text="Yes" data-toggle="modal" data-target="#myModal" CssClass="btn btn-primary btn-add" ValidationGroup="ADD" OnClick="ImgbtnSubmit_Click" />
                    <button type="button" id="btnclose" class="btn btn-danger" data-dismiss="modal">No</button>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid" style="margin-bottom: 62px; background: #fff;">
        <div class="wrapper-content">
            <div class="inner-content-right">
                <div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="stpdiv"><span class="box-title stp1">Step-2</span> <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 5</span> </div>
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Add Family Details</h3>
                    </div>
                </div>
                <div class="form-horizontal">
                    <asp:Label ID="lblMsg" ForeColor="Red" runat="server" CssClass="red-text"></asp:Label>

                    <%if (Session["UserType"].ToString().Equals("334"))
                        {%>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">State:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:Label ID="lblstatename" runat="server" ForeColor="#713002"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Reserve:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:Label ID="lblreaserve" runat="server" ForeColor="#713002"></asp:Label>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">District:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:Label ID="lbldistrict" runat="server" ForeColor="#713002"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Tehsil:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:Label ID="lbltehsil" runat="server" ForeColor="#713002"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Grampanchayat:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:Label ID="lblgp" runat="server" ForeColor="#713002"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Village:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:Label ID="lblvillname" runat="server" ForeColor="#713002"></asp:Label>
                            </div>
                        </div>
                    </div>


                    <div class="col-md-6 col-sm-6 col-xs-12" style="display: none;">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Village Code:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:Label ID="lblvillcode" runat="server" ForeColor="#713002"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <%} %>
                    <%if (Session["UserType"].ToString().Equals("4") || Session["UserType"].ToString().Equals("1"))
                        {%>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">State Name<span class="red-text-1a">*</span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:DropDownList ID="DdlStateName" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged" disabled="true"></asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="red-text-asterix " ErrorMessage="Please Select Village" ControlToValidate="DdlStateName" Display="Dynamic" InitialValue="Select Village" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ADD">Please Select State Name</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Tiger Reserve:<span class="red-text-1a">*</span></label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlTiger_SelectedIndexChanged" AutoPostBack="true" disabled="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="red-text-asterix " ErrorMessage="Please Select Village" ControlToValidate="ddlselectreserve" Display="Dynamic" InitialValue="Select Tiger Reserve" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ADD">Please Select State Name</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Select Village<span class="red-text-1a">*</span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:DropDownList ID="ddlselectname" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged" disabled="true"></asp:DropDownList>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="red-text-asterix " ErrorMessage="Please Select Village" ControlToValidate="ddlselectname" Display="Dynamic" InitialValue="Select Village" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ADD">Please Select Village</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Survey Date:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox CssClass="textfield form-control" ID="txtsurdate" runat="server" autocomplete="off"></asp:TextBox>
                                <asp:Image ImageUrl="~/AUTH/adminpanel/images/cal.jpg" ID="Image" runat="server" />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ForeColor="Red" runat="server" ControlToValidate="txtsurdate" Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtsurdate" PopupButtonID="Image" runat="server"></cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>
                    <%} %>
                    <div class="col-md-6 col-sm-6 col-xs-12" style="display: none;">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Survey Date:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox CssClass="textfield form-control" ID="txtsurdate1" runat="server" autocomplete="off"></asp:TextBox>
                                <asp:Image ImageUrl="~/AUTH/adminpanel/images/cal.jpg" ID="Image3" runat="server" />
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ForeColor="Red" runat="server" ControlToValidate="txtsurdate1" Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d" ValidationGroup="ADD"></asp:RegularExpressionValidator>
                                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtsurdate1" PopupButtonID="Image3" runat="server"></cc1:CalendarExtender>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12" style="display: none;">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Family Code<span class="red-text-1a"></span></label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtcode" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="3" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Name (as on valid ID Proof)<span class="red-text-1a">*</span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtvalididname" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character." ControlToValidate="txtvalididname" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADD" ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:Button ID="btnAddmember" runat="server" Text="Add Family Head Details" CssClass="btn btn-primary btn-add" OnClick="btnAddmember_Click" />
                            </div>
                        </div>
                    </div>


                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Valid Id Number (PAN Card)<span style="color: red;"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtrashancard" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character." ControlToValidate="txtrashancard" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADD" ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Agricultural Land (Ha)<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtagri" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="10"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ForeColor="Red" runat="server" CssClass="red-text-asterix " ControlToValidate="txtagri" Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?" ValidationGroup="ADD">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Residential Property (Ha)<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtresland" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="10"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" CssClass="red-text-asterix " ControlToValidate="txtresland" Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?" ValidationGroup="ADD">Please Enter Only Decimal value up to 2 digit up to 2 digit</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Status of Residence (Kaccha/Pucca):</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:DropDownList ID="ddlselectstatusresland" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectstatusresland_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select Home Status</asp:ListItem>
                                    <asp:ListItem Value="1" Text="Kaccha"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Pucca"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Wells<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtwells" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="10"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtwells" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" ForeColor="Red" SetFocusOnError="True">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Standing Trees<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txttrees" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="10"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txttrees" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" ForeColor="Red" SetFocusOnError="True">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Other Assets<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtotherassets" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="10"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtotherassets" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" ForeColor="Red" SetFocusOnError="True">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of Cow:<span class="red-text-1a">*</span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="TxtNoCow" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="10"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Cow" ControlToValidate="TxtNoCow" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Total Cow</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtNoCow" Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of Buffalo:<span class="red-text-1a">*</span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="TxtBuffalo" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Buffalo" ControlToValidate="TxtBuffalo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Total Buffalo</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtBuffalo" Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Number of Goat:<span class="red-text-1a">*</span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="TxtGoat" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Goat" ControlToValidate="TxtGoat" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Total Goat</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtGoat" Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                    ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Other Animal<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtotheranimal" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="10"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtotheranimal" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" ForeColor="Red" SetFocusOnError="True">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Number of Sheep:<span class="red-text-1a">*</span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="TxtSheep" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Sheep" ControlToValidate="TxtSheep" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Total Sheep</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtSheep" Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Livestock<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtlivestock" runat="server" CssClass="textfield form-control" autocomplete="off" MaxLength="10"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtlivestock" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" ForeColor="Red" SetFocusOnError="True">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12" style="display: none;">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Cow & Buffalo<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtcownbuff" runat="server" CssClass="textfield form-control" autocomplete="off" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12" style="display: none;">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Total Sheep & Goat<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtsheepngoat" runat="server" CssClass="textfield form-control" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="updOptionSelection" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                             <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Option Selected<span class="red-text-1a">*</span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:DropDownList ID="ddlselectscheme" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectscheme_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Select Option"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="I"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="II"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Any Other"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12"></label>
                            <div id="dvOtherOption" runat="server" visible="false" class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtOtherOption" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                   <div class="clearfix"></div>
                    <div class="col-md-6 col-sm-6 col-xs-12" style="display: none;">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Group Name<span class="red-text-asterix"></span>: </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:DropDownList ID="ddlselectgroupname" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectgroupname_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12">Comments<span class="red-text-asterix"></span>:</label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:TextBox ID="txtcomments" runat="server" CssClass="textfield form-control" TextMode="MultiLine" Height="100px" autocomplete="off" MaxLength="300"></asp:TextBox>
                            </div>
                        </div>
                    </div>



                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label for="" class="control-label col-md-4 col-sm-4 col-xs-12"></label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:LinkButton ID="lnkViewDetailss" Font-Underline="true" Font-Bold="true" ForeColor="Blue" runat="server" Text='Option I & Option II details.'></asp:LinkButton>
                            </div>
                        </div>
                    </div>

                    <div style="overflow-y: auto; max-height: 600px; width: 600px;">
                        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none; max-height: 500px; overflow-y: auto;" Width="600px">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table width="550px" border="0" align="center" cellpadding="3" cellspacing="1" class="table-3">
                                        <tr>
                                            <td colspan="3" style="border-bottom: 3px solid #005529;">
                                                <h3 style="color: #005529;">
                                                    <%--   Please Enter Family Member Details--%>
                                                    <asp:Label ID="LblHeadingPopUp" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                                </h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="black-text" align="center">
                                                <br />
                                                <h4><a href="#" style="color: blue;" id="ToolTipHref">Notice:Family Definition</a></h4>
                                                <div id="TooltipContent" style="display: none; background-color: #e8d289; border: groove; text-justify: auto; font-weight: bold;">
                                                    <p>A "family" would mean a person, his or her spouse, minor sons and daughters, minor brothers or unmarried sisters, father, mother and other members residing with him/her and dependent on him/her for their livelihood. A family would be eligible for the package from only one location where it normally resides even if it owns land in other settlements requiring relocation. </p>
                                                    <p>
                                                        "family" would mean a person, his or her spouse, minor sons and daughters, minor brothers or unmarried sisters, father, mother and other members residing with him/her and dependent on him/her for their livelihood. A family would be eligible for the package from only one location where it normally resides even if it owns land in other settlements requiring relocation.
                                      <p>1. A major (over 18 years) son irrespective of his marital status.</p>
                                                    <p>2. Unmarried daughter/sister more than 18 years of age.</p>
                                                    <p>3. Physically and mentally challenged person irrespective of age and sex.</p>
                                                    <p>4. Minor orphan, who has lost both his/her parents.</p>
                                                    <p>5. A widow or a woman divorcee.</p>
                                                </div>
                                                <br />
                                                <asp:Label ID="lblMsg1" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right" width="200px">Name<span class="red-text-1a">*</span></td>
                                            <td class="black-text" width="10px" align="center">:</td>
                                            <td width="200px" align="left">
                                                <asp:TextBox ID="txtname" runat="server" ValidationGroup="ADDMember" autocomplete="off" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtname"
                                                    Display="Dynamic" ErrorMessage="Please Enter Name" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix "></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ForeColor="Red" CssClass="red-text-asterix"
                                                    ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtname"
                                                    ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$"
                                                    SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr id="TrRelationHead" runat="server">
                                            <td class="black-text" align="right">Relation With Family Head</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlselectrelation" ValidationGroup="ADDMember" runat="server" CssClass="textfield-drop form-control"></asp:DropDownList>
                                                &nbsp; </td>
                                        </tr>
                                        <%if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
                                            { %>
                                        <tr>
                                            <td class="black-text" align="right">Father/Husband Name</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtfathername" runat="server" ValidationGroup="ADDMember" autocomplete="off" CssClass="textfield form-control" OnTextChanged="txtfathername_TextChanged" MaxLength="100"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ValidationGroup="ADDMember" ForeColor="Red" runat="server" CssClass="red-text-asterix" Display="Dynamic" ControlToValidate="txtfathername" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator></td>
                                        </tr>
                                        <% }%>
                                        <tr>
                                            <td class="black-text" align="right">Date of Birth (DOB):<span class="red-text-1a">*</span></td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="TxtDOB" runat="server" ValidationGroup="ADDMember" Width="70%" autocomplete="off" AutoPostBack="True" OnTextChanged="TxtDOB_TextChanged"></asp:TextBox>
                                                <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image4" runat="server" />
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegulTxtDOB" runat="server" ControlToValidate="TxtDOB"
                                                    Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RegularExpressionValidator>
                                                <cc1:CalendarExtender ID="CalendarTxtDOB" Format="dd/MM/yyyy" TargetControlID="TxtDOB"
                                                    PopupButtonID="Image4" runat="server">
                                                </cc1:CalendarExtender>
                                                <asp:RequiredFieldValidator ID="RequiredTxtCuttOffDate" runat="server" ControlToValidate="TxtDOB"
                                                    Display="Dynamic" ErrorMessage="Please Enter DOB" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                                                <asp:Label ID="LblCuttoffDateShow" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                                <%--  <asp:CustomValidator runat="server" ID="custDateTxtDOB" ControlToValidate="TxtDOB"
                                                                    ClientValidationFunction="CompareDates" ErrorMessage="Date Should Be Less Than Or Equal to Today's Date "
                                                                    ValidationGroup="ADDMember" Display="Dynamic" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:CustomValidator>--%>
                                                <asp:Label ID="LblMsgDbo" runat="server" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Calculated Age(Years):</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtage" runat="server" ValidationGroup="ADDMember" autocomplete="off" CssClass="textfield form-control" MaxLength="3"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ForeColor="Red" runat="server" CssClass="red-text-asterix" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtage" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="Requirtxtage" runat="server" ForeColor="Red" ControlToValidate="txtage"
                                                    Display="Dynamic" ErrorMessage="Please Enter DOB.Your age will be calculate automatic." SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix "></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Sex<span class="red-text-1a">*</span></td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlselectsex" ValidationGroup="ADDMember" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectsex_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Text="Select Sex"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Transgender"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="Red" runat="server" ControlToValidate="ddlselectsex"
                                                    Display="Dynamic" ErrorMessage="Please Select Sex" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" InitialValue="0" CssClass="red-text-asterix "></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Caste<span class="red-text-1a">*</span></td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlselectcast" runat="server" CssClass="textfield-drop form-control" ValidationGroup="ADDMember">
                                                    <asp:ListItem Value="0" Text="Select Caste"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="OBC"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="SC"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="ST"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="OTHER"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" runat="server" ControlToValidate="ddlselectcast"
                                                    Display="Dynamic" ErrorMessage="Please Select Caste" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" InitialValue="0" CssClass="red-text-asterix "></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td class="black-text" align="right">Valid Id Number </td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtvoter" autocomplete="off" runat="server" ValidationGroup="ADDMember" CssClass="textfield form-control" Text="0" MaxLength="100"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator17" ValidationGroup="ADDMember" Display="Dynamic" runat="server" ControlToValidate="txtvoter" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z0-9]*$" ErrorMessage="Valid characters: Alphabets and Numbers." /></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Contact Number</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtcontact" autocomplete="off" ValidationGroup="ADDMember" runat="server" CssClass="textfield form-control" MaxLength="11" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ForeColor="Red" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtcontact" ErrorMessage="Please Enter Contact No. upto 10 or 11 digit" ValidationExpression="^[0-9]{10,11}$" SetFocusOnError="True"></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Valid Id proof<span class="red-text-1a">*</span></td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:DropDownList ID="DropDownvalidId" runat="server" CssClass="textfield-drop form-control" ValidationGroup="ADDMember">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="PAN Card"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Voter Id"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Aadhaar Card"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Any other Card Details"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" runat="server" ControlToValidate="DropDownvalidId"
                                                    Display="Dynamic" ErrorMessage="Please Select Valid Id Proof" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" InitialValue="0" CssClass="red-text-asterix "></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right"><span class="red-text-1a"></span></td>
                                            <td class="black-text" align="center"></td>
                                            <td align="left">
                                                <asp:TextBox ID="txtpencard" autocomplete="off" ValidationGroup="ADDMember" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtpencard"
                                                    Display="Dynamic" ErrorMessage="Please enter pen card" SetFocusOnError="True"
                                                    ValidationGroup="ADDMember" CssClass="red-text-asterix "></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td class="black-text" align="right">Voter Id<br />
                                            </td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtvalidcardnumber" autocomplete="off" ValidationGroup="ADDMember" runat="server" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="ADDMember" Display="Dynamic" runat="server" ControlToValidate="txtvalidcardnumber" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z0-9]*$" ErrorMessage="Valid characters: Alphabets and Numbers." /></td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td class="black-text" align="right">Adhaar Card</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="TxtAdhaarCard" ValidationGroup="ADDMember" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="12"></asp:TextBox>
                                                <asp:RegularExpressionValidator ForeColor="Red" Display="Dynamic" ControlToValidate="TxtAdhaarCard" ID="RegularExpressionValidator23" ValidationExpression="^[\s\S]{12,12}$" runat="server" ValidationGroup="ADDMember" ErrorMessage="Adhaar Card must be 12 character length."></asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td class="black-text" align="right" width="200px">Any other Card Details</td>
                                            <td class="black-text" width="10px" align="center">:</td>
                                            <td width="200px" align="left">
                                                <asp:FileUpload ID="fileUploadCardDetails" runat="server" />
                                                <em class="em" style="color: green;">Tip:-jpg,jpeg,png</em>
                                                <br />
                                                Any other Card Details Title:
                                    <asp:TextBox ID="TxtCardFile" Width="70%" runat="server" ValidationGroup="ADDMember"></asp:TextBox>
                                                <span class="validation">
                                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="ValidateFileUpload11"
                                                        ControlToValidate="fileUploadCardDetails" OnServerValidate="CustomValidator3_ServerValidate1"
                                                        ValidationGroup="ADDMember" ErrorMessage="Please select jpg,jpeg,png." Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                                                </span>
                                                <asp:CustomValidator ID="CustomValidator4" ValidationGroup="ADDMember" OnServerValidate="ValidateFileSize1" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="fileUploadCardDetails" ErrorMessage="FileSize should not exceed 3MB." ClientValidationFunction="checkfilesize" />
                                                <div>
                                                    <asp:Label ID="LblCardMsge" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                </div>
                                                <div id="Div1" runat="server" visible="false">
                                                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" ForeColor="#000099" Font-Bold="True" Font-Italic="True"></asp:HyperLink>
                                                    <asp:Button ID="BtnDeleteAttachmentCard" runat="server" Text="Delete Attachment" OnClientClick="return confirm('Are you sure delete permanently?');" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="BtnDeleteAttachment_Click1" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right" width="200px"></td>
                                            <td class="black-text" width="10px" align="center"></td>
                                            <td width="200px" align="left">
                                                <input id="Button1" type="button" value="add" onclick="AddFileUpload()" class="btn btn-success" />
                                                <asp:FileUpload ID="fileUpload1" runat="server" ValidationGroup="GroupVmg" Visible="false" />
                                                <asp:Label ID="Label1" runat="server" Text="Current File:" Visible="False" ForeColor="Black"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Visible="False" ForeColor="Green"></asp:Label>
                                                <div id="FileUploadContainer">
                                                    <!--FileUpload Controls will be added here -->
                                                </div>
                                                <asp:CustomValidator runat="server" ID="customFile" ErrorMessage="Please Upload File" ClientValidationFunction="checkfile" ControlToValidate="DropDownvalidId"
                                                    ValidationGroup="ADDMember" ForeColor="Red" Display="Dynamic"></asp:CustomValidator></td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td class="black-text" align="right">Others</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtothers" ValidationGroup="ADDMember" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td class="black-text" align="right">Transgender</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="TxtTransgender" ValidationGroup="ADDMember" autocomplete="off" Text="0" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr id="benifi" runat="server">
                                            <td class="black-text" align="right">Total number of beneficiaries</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="TxtNoBeneficiary" ValidationGroup="ADDMember" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="4"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Marital Status <span style="color: red;">*</span>:</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:DropDownList ID="DdlMaritalStatus" runat="server" CssClass="textfield-drop form-control" ValidationGroup="ADDMember">
                                                    <asp:ListItem Value="0" Text="Select Marital Status"></asp:ListItem>
                                                    <asp:ListItem Value="Single" Text="Single"></asp:ListItem>
                                                    <asp:ListItem Value="Married" Text="Married"></asp:ListItem>
                                                    <asp:ListItem Value="Divorce" Text="Divorced"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvTypeff" runat="server" Display="Dynamic" ControlToValidate="DdlMaritalStatus"
                                                    InitialValue="0" ErrorMessage="Type required." ValidationGroup="ADDMember" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        </tr>
                                        <tr id="trPhoto" runat="server" visible="false">
                                            <td class="black-text" align="right" width="200px">Add your photo:<span class="red-text-1a">*</span></td>
                                            <td class="black-text" width="10px" align="center">:</td>
                                            <td width="200px" align="left">
                                                <asp:FileUpload ID="fileUpload_Menu" runat="server" />
                                                <asp:Label ID="lblmenuMsg" runat="server" Text="Current File:" Visible="False" ForeColor="Black"></asp:Label>
                                                <asp:Label ID="lblFileName" runat="server" Visible="False" ForeColor="Green"></asp:Label>
                                                <em class="em" style="color: green;">Tip:-jpg,jpeg,png</em> <span class="validation">
                                                    <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="ValidateFileUpload1"
                                                        ControlToValidate="fileUpload_Menu" OnServerValidate="CustomValidator3_ServerValidate"
                                                        ValidationGroup="ADDMember" ErrorMessage="Please select jpg,jpeg,png." Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                                                </span>
                                                <asp:CustomValidator ID="CustomValidator1" ValidationGroup="ADDMember" OnServerValidate="ValidateFileSize" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="fileUpload_Menu" ErrorMessage="FileSize should not exceed 3MB." ClientValidationFunction="checkfilesize" />
                                                <div>
                                                    <asp:Label ID="LblfileUpload_Menu" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                </div>
                                                <div id="DvPhoto" runat="server" visible="false">
                                                    <asp:HyperLink ID="hypfile" Target="_blank" runat="server" ForeColor="#000099" Font-Bold="True" Font-Italic="True"></asp:HyperLink>
                                                    <asp:Button ID="BtnDeleteAttachment" runat="server" Text="Delete Attachment" OnClientClick="return confirm('Are you sure delete permanently?');" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="BtnDeleteAttachment_Click" />
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Education</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtedu" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="100" ValidationGroup="ADDMember"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ValidationGroup="ADDMember" Display="Dynamic" runat="server" ControlToValidate="txtedu" ForeColor="Red"
                                                    ValidationExpression="[a-zA-Z0-9]*$" ErrorMessage="Valid characters: Alphabets and Numbers." /></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Occupation</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlselectoccupation" runat="server" ValidationGroup="ADDMember" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectoccupation_SelectedIndexChanged"></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Annual Income (Rs.)</td>
                                            <td class="black-text" align="center">:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtincome" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="10" ValidationGroup="ADDMember"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" ForeColor="Red" runat="server" CssClass="red-text-asterix " ControlToValidate="txtincome"
                                                    Display="Dynamic" ErrorMessage="Only Decimal" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?"
                                                    ValidationGroup="ADDMember">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator></td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="text-align: center;">
                                                <div id="DvValidAgePanel" visible="false" runat="server">
                                                    <span style="font-size: large; font-weight: bold;"></span>
                                                    <hr />
                                                    <span style="font-size: larger; font-weight: 500; color: black;">Please fill details below</span>
                                                    <hr />
                                                    <table>
                                                        <tr>
                                                            <td>Beneficiary Name
                                            <label class="txtcolor">*</label>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtBnameMobile" runat="server" autocomplete="off" ValidationGroup="ADDMember"></asp:TextBox>
                                                                <div>
                                                                    <asp:Label ID="LblTxtBnameMobile" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Beneficiary Address
                                            <label class="txtcolor">*</label>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="txtBeniAddress" runat="server" autocomplete="off" ValidationGroup="ADDMember"></asp:TextBox>
                                                                <div>
                                                                    <asp:Label ID="lblBeniAddress" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Beneficiary Mobile no
                                            <label class="txtcolor">*</label>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="txtBeniMobile" runat="server" autocomplete="off" ValidationGroup="ADDMember" MaxLength="10"></asp:TextBox>
                                                                <div>
                                                                    <asp:Label ID="lblBeniMobile" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Bank/Postal Account No
                                            <label class="txtcolor">*</label>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtBankPostAccountNo" runat="server" autocomplete="off" ValidationGroup="ADDMember" MaxLength="17"></asp:TextBox>
                                                                <div>
                                                                    <asp:Label ID="lblTxtBankPostAccountNo" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Bank/Post office Name
                                            <label class="txtcolor">*</label>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtBankPostOfficeName" runat="server" autocomplete="off" ValidationGroup="ADDMember"></asp:TextBox>
                                                                <div>
                                                                    <asp:Label ID="lblTxtBankPostOfficeName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>IFSC/Pin Code
                                            <label class="txtcolor">*</label>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtIFSC" runat="server" autocomplete="off" ValidationGroup="ADDMember"></asp:TextBox>
                                                                <div>
                                                                    <asp:Label ID="lblTxtIFSC" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Bank Post office Address
                                            <label class="txtcolor">*</label>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtBankPostOfficeAdress" runat="server" autocomplete="off" ValidationGroup="ADDMember"></asp:TextBox>
                                                                <div>
                                                                    <asp:Label ID="lblTxtBankPostOfficeAdress" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>Aadhar No
                                            <label class="txtcolor">*</label>
                                                                :</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtAadharNo" runat="server" autocomplete="off" ValidationGroup="ADDMember" MaxLength="12"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ForeColor="Red" Display="Dynamic" ControlToValidate="TxtAadharNo" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{12,12}$" runat="server" ValidationGroup="ADDMember" ErrorMessage="Adhaar Card must be 12 character length."></asp:RegularExpressionValidator>
                                                                <div>
                                                                    <asp:Label ID="lblTxtAadharNo" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <tr>
                                                    <td class="black-text"></td>
                                                    <td class="black-text"></td>
                                                    <td>
                                                        <asp:Button ID="ImgbtnSubmitMember" runat="server" Text="Submit" CssClass="btn btn-primary btn-add" ValidationGroup="ADDMember" OnClick="ImgbtnSubmitMember_Click" />
                                                        &nbsp;
                                    <asp:Button ID="imgbtnreset" runat="server" Visible="false" Text="Reset" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="imgbtnreset_Click" />
                                                        &nbsp;
                                    <asp:Button ID="imgbtncancel1" runat="server" Text="Cancel" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="imgbtncancel1_Click" /></td>
                                                </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <%--  <asp:AsyncPostBackTrigger ControlID="ImgbtnSubmitMember" EventName="Click" />--%>
                                    <asp:PostBackTrigger ControlID="ImgbtnSubmitMember" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <%--end PopUp--%>
                        </asp:Panel>
                    </div>

                    <div class="col-md-12">
                        <asp:GridView ID="gvFormembers" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            DataKeyNames="FMLY_MEMB_ID" AllowPaging="True" Width="100%" OnPageIndexChanging="gvFormembers_PageIndexChanging" OnRowCommand="gvFormembers_RowCommand" OnRowDataBound="gvFormembers_RowDataBound" OnRowDeleting="gvFormembers_RowDeleting" OnRowEditing="gvFormembers_RowEditing"
                            RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                            <FooterStyle BackColor="#CCCC99" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                            <RowStyle CssClass="drow" BackColor="#F7F7DE" />
                            <AlternatingRowStyle CssClass="alt" BackColor="White" />
                            <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
                            <Columns>
                                <asp:TemplateField HeaderText="S. No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Member's ID" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblmemberid" runat="server" Text='<%#Eval("FMLY_MEMB_ID") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relation With Family Head">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblrelation" runat="server" Text='<%#Eval("FMLY_MEMB_REL") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID") %>' CommandName="Edit"
                                            Visible="true" ImageUrl="~/AUTH/adminpanel/images/arrow.png" />
                                        <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>Delete </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete?');"
                                            CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID") %>'
                                            runat="server" Visible="true" ImageUrl="~/AUTH/adminpanel/images/wrong.png" />
                                        <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings FirstPageImageUrl="~/AUTH/adminpanel/images/First1.jpg" Mode="Numeric" />
                            <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                    </div>
                    <div class="clearfix"></div>
                    <hr />

                    <div class="col-md-12 col-xs-12">
                        <asp:Button ID="Imgbtn" runat="server" data-toggle="tooltip" Text="Save & Next Step" title="Click here for next step" CssClass="btn btn-primary btn-add" ValidationGroup="ADD" OnClientClick="return modelpopup(event,this)" />
                        <asp:Button ID="ImgbtnCancel" runat="server" Text="Reset" CssClass="btn btn-primary btn-add" Visible="false" CausesValidation="false" OnClick="ImgbtnCancel_Click" />
                        <asp:Button ID="ImgbtnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImgbtnBack_Click" />
                        <a class="btn btn-primary btn-add" href="<%=ResolveUrl("~/auth/adminpanel/ProcessManegment/DfoUser/AddProcessDFO.aspx") %>" style="display: none;">Next</a>
                    </div>
                </div>
                <div style="clear: both"></div>
            </div>
        </div>
    </div>
    
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        TargetControlID="HiddenField2"
        PopupControlID="Panel1"
        BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <%--start modal popup--%>
    <div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">OPTION I & OPTION II DETAILS</h4>
                </div>
                <div class="modal-body ty23"></div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <%--end modal popup--%>
    <script type="text/javascript">

        var counter = 0;

        function AddFileUpload() {
            var checkLrngth = $('#FileUploadContainer').find('input').length;

            var div = document.createElement('DIV');

            div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +

                '" type="file" class="input_inline" />' +

                '<input id="Button' + counter + '" type="button" ' +

                'value="Remove" class="btn btn-danger btn-xs" onclick = "RemoveFileUpload(this)" />';
            if (checkLrngth < 2) {
                document.getElementById("FileUploadContainer").appendChild(div);
                counter++;
            }




        }

        function RemoveFileUpload(div) {

            document.getElementById("FileUploadContainer").removeChild(div.parentNode);

        }
        $(document).ready(function () {
            $('#btnclose').click(function () {
                $('[data-toggle="tooltip"]').tooltip();
            });
        });
    </script>
</asp:Content>
