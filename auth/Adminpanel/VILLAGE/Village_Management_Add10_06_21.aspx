<%@ Page Title="NTCA:Add village" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Village_Management_Add.aspx.cs" Inherits="auth_Adminpanel_VILLAGE_Village_Management_Add" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
.form-group div[class*=col-] img{
    position: absolute;
    top: 11px;
    right: 25px;
}
.textfield{
	width:100%;
}
.auto-style1 {
	height: 59px;
}
.red-text-1a {
	color: red;
}
.form-group select{
	height:32px !important;
}
.form-horizontal .control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left;
}
.table-2 td {
	padding: 1px;
	text-align: left;
	width: 23% !important;
	vertical-align: top;
}
div.ajax__calendar_days table tr td {
	padding-right: 0px;
}
div.ajax__calendar_body {
	width: 170px;
}
div.ajax__calendar_container {
	width: 215px;
}
/*.auto-style2 {
	width: 35%;
}
.textfield-drop {
	width: 70%;
}*/
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
.input_inline {
	display:inline-block !important;
	max-width: 70%;
}
.stpdiv {
	padding: 0 0 30px 0;
}
.form-horizontal .form-group {
	min-height:52px;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
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
        function ValidateFileUpload1(Source, args) {
            var fuData = document.getElementById('<%= fileUpload_Menu.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                if (Extension == "pdf" || Extension == "xlsx" || Extension == "docx" || Extension == "doc" || Extension == "jpg" || Extension == "JPG" || Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "PNG") {
                    args.IsValid = true; // Valid file type
                }
                else {
                    args.IsValid = false; // Not valid file type
                }
            }
        }



        function CompareDates(source, args) {

            var fromDate = new Date();
            var txtFromDate = document.getElementById('<%= txtsurdate.ClientID %>').value;
            var FromDate = txtFromDate.split("/");
            /*Start 'Date to String' conversion block, this block is required because javascript do not provide any direct function to convert 'String to Date' */
            var fdd = FromDate[0]; //get the day part
            var fmm = FromDate[1]; //get the month part
            var fyyyy = FromDate[2]; //get the year part
            fromDate.setUTCDate(fdd);
            fromDate.setUTCMonth(fmm - 1);
            fromDate.setUTCFullYear(fyyyy);
            var toDate = new Date();
            var txtToDate = document.getElementById('<%= HiddenField1.ClientID %>').value;
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

    </script>
  <script type="text/javascript" language="javascript">


        $(document).ready(function () {
            $('#<%= txtsurdate.ClientID %>').attr('readonly', true);
            $('#<%= TxtDateMeeting.ClientID %>').attr('readonly', true);
            $('#<%= TxtCuttOffDate.ClientID %>').attr('readonly', true);


            $('#<%= txtPop.ClientID %>').attr('readonly', true);
            $('#<%= txtland.ClientID %>').attr('readonly', true);
            $('#<%= txtlivestock.ClientID %>').attr('readonly', true);
            //--------------TotalVillagePopulation-----------------
            $('#<%= txtst.ClientID %>').on('keyup', function () {

                TotalVillagePopulation();
            });
            $('#<%= txtobc.ClientID %>').on('keyup', function () {
                TotalVillagePopulation();
            });
            $('#<%= txtother.ClientID %>').on('keyup', function () {
                TotalVillagePopulation();
            });
            $('#<%= txtsc.ClientID %>').on('keyup', function () {
                TotalVillagePopulation();
            });
            $('#<%= txtst.ClientID %>').on('keyup', function () {
                TotalVillagePopulation();
            });

            //-----------------ToalLandARea---------------------
            $('#<%= txtotherland.ClientID %>').on('keyup', function () {

                ToalLandARea();
            });
            $('#<%= txtagri.ClientID %>').on('keyup', function () {
                ToalLandARea();
            });
            $('#<%= txtnonagri.ClientID %>').on('keyup', function () {
                ToalLandARea();
            });


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
            $('#<%= txtothranml.ClientID %>').on('keyup', function () {
                TotalLivestock();
            });



            //--------------------------------------------
          
        });
        function ToalLandARea() {
            // alert('ffd');
            var OthersLandsArea = "0";
            var AgriculturalLand = "0";
            var ResidentialLand = "0";

            var Total = "0";
            if ($('#<%= txtotherland.ClientID %>').val() == "") {
                OthersLandsArea = "0";
            }
            else {
                OthersLandsArea = $('#<%= txtotherland.ClientID %>').val();
            }
            if ($('#<%= txtagri.ClientID %>').val() == "") {
                AgriculturalLand = "0";
            }
            else {
                AgriculturalLand = $('#<%= txtagri.ClientID %>').val();
            }
            if ($('#<%= txtnonagri.ClientID %>').val() == "") {
                ResidentialLand = "0";
            }
            else {
                ResidentialLand = $('#<%= txtnonagri.ClientID %>').val();
            }

            //-------------
            // parseFloat
            Total = parseFloat(OthersLandsArea) + parseFloat(AgriculturalLand) + parseFloat(ResidentialLand);
            $('#<%= txtland.ClientID %>').val(Total.toFixed(2));
            //alert(Total);
        }
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
            if ($('#<%= txtothranml.ClientID %>').val() == "") {
                otherAnimal = "0";
            }
            else {
                otherAnimal = $('#<%= txtothranml.ClientID %>').val();
            }
            //-------------
            Total = parseInt(cow) + parseInt(Buffalo) + parseInt(sheep) + parseInt(Goat) + parseInt(otherAnimal);
            $('#<%= txtlivestock.ClientID %>').val(Total);
            //alert(Total);
        }
        function TotalVillagePopulation() {
            // alert('ffd');
            var ST = "0";
            var OBC = "0";
            var OTHERS = "0";
            var SC = "0";
            var Total = "0";
            if ($('#<%= txtst.ClientID %>').val() == "") {
                ST = "0";
            }
            else {
                ST = $('#<%= txtst.ClientID %>').val();
            }
            if ($('#<%= txtobc.ClientID %>').val() == "") {
                OBC = "0";
            }
            else {
                OBC = $('#<%= txtobc.ClientID %>').val();
            }
            if ($('#<%= txtother.ClientID %>').val() == "") {
                OTHERS = "0";
            }
            else {
                OTHERS = $('#<%= txtother.ClientID %>').val();
            }
            if ($('#<%= txtsc.ClientID %>').val() == "") {
                SC = "0";
            }
            else {
                SC = $('#<%= txtsc.ClientID %>').val();
            }
            //-------------
            Total = parseInt(ST) + parseInt(OBC) + parseInt(OTHERS) + parseInt(SC);
            $('#<%= txtPop.ClientID %>').val(Total);
            //alert(Total);
        }
        function validateNumber(event) {
            var key = window.event ? event.keyCode : event.which;
            if (event.keyCode === 8 || event.keyCode === 46) {
                return true;
            }
            else if (key < 48 || key > 57) {
                alert('Please Enter Only Numeric Value.');
                return false;
            } else {
                return true;
            }
        };
    </script>
  <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
  
  
  <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
    <div class="wrapper-content" style="padding-top: 0px; padding-bottom: 0;">
      <div class="">
        <div class="row">
          <div class="col-lg-12">
            <div class="widgets-container">
              <div class="box box-primary1" style="margin-bottom: 25px;">
                <div class="stpdiv"> <span class="box-title stp1">Step-1</span> <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 5</span> </div>
                <div class="box-header with-border">
                  <h3 class="box-title" style="color: #005529;">Add Village Details</h3>
                </div>
              </div>
              <div class="form-horizontal">
                <asp:Label ID="lblMsg" runat="server" CssClass="red-text" ForeColor="Red"></asp:Label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label id="TdState" runat="server" visible="false" class="control-label col-md-4 col-sm-4 col-xs-12">Select State<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12" id="TdddlState" runat="server" visible="false">
                      <asp:DropDownList ID="DdlState" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" ValidationGroup="GroupVmg" OnSelectedIndexChanged="DdlState_SelectedIndexChanged"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="reqDdlstate" runat="server" SetFocusOnError="true" Text="Please select state name" ForeColor="Red" ValidationGroup="GroupVmg" ErrorMessage="Please select state name" InitialValue="Select State" ControlToValidate="DdlState"></asp:RequiredFieldValidator>
                      <span id="LblStatedv" runat="server" visible="false"> </span> </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label id="Td1" runat="server"  class="control-label col-md-4 col-sm-4 col-xs12" visible="false">Select Tiger Reserve<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:DropDownList ID="ddlselectreserve" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" ValidationGroup="GroupVmg" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged" Visible="false"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator291" runat="server" SetFocusOnError="true" Text="Please select state name" ForeColor="Red" ValidationGroup="GroupVmg" ErrorMessage="Please select Tiger Reserve" InitialValue="Select Tiger Reserve" ControlToValidate="ddlselectreserve"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Select District<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:DropDownList ID="ddlSelectDistrict" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlSelectDistrict_SelectedIndexChanged" ValidationGroup="GroupVmg"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" SetFocusOnError="true" Text="Please select District name" ForeColor="Red" ValidationGroup="GroupVmg" ErrorMessage="Please select District name" InitialValue="Select District" ControlToValidate="ddlSelectDistrict"></asp:RequiredFieldValidator>
                      <span>
                      <asp:Label ID="lblmsgdt" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                      </span> </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Select Tehsil<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:DropDownList ID="ddlselecttehsil" ValidationGroup="GroupVmg" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselecttehsil_SelectedIndexChanged"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" SetFocusOnError="true" Text="Please select Tehsil name" ForeColor="Red" ValidationGroup="GroupVmg" ErrorMessage="Please select Tehsil name" InitialValue="Select Tehsil" ControlToValidate="ddlselecttehsil"></asp:RequiredFieldValidator>
                      <asp:Label ID="lblmsgth" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Select Gram panchayat<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:DropDownList ID="ddlselectgp" ValidationGroup="GroupVmg" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectgp_SelectedIndexChanged"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" SetFocusOnError="true" Text="Please select Gram panchayat name" ForeColor="Red" ValidationGroup="GroupVmg" ErrorMessage="Please select Gram panchayat name" InitialValue="Select Grampanchayat" ControlToValidate="ddlselectgp"></asp:RequiredFieldValidator>
                      <asp:Label ID="lblmsggp" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12" style="display: none;">Village Code<span class="red-text-1a"></span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12" style="display: none;">
                      <asp:TextBox ID="txtcode" runat="server" CssClass="textfield form-control" MaxLength="3" autocomplete="off" Visible="false"></asp:TextBox>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Enter Village Name<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:TextBox ID="txtname" ValidationGroup="GroupVmg" runat="server" CssClass="form-control" MaxLength="100" autocomplete="off"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Village Name" ControlToValidate="txtname" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Village Name</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="red-text-asterix" ControlToValidate="txtname"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Characters" SetFocusOnError="True" ValidationExpression="[a-zA-Z ]+$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Select Legal Status<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:DropDownList ID="ddlVillageLegalStatus" ValidationGroup="GroupVmg" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlVillageLegalStatus_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select Status</asp:ListItem>
                        <asp:ListItem Value="1">Revenue</asp:ListItem>
                        <asp:ListItem Value="2">Forest</asp:ListItem>
                        <asp:ListItem Value="3">Others</asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" SetFocusOnError="true" Text="Please select Legal Status" ForeColor="Red" ValidationGroup="GroupVmg" ErrorMessage="Please select Legal Status" InitialValue="0" ControlToValidate="ddlVillageLegalStatus"></asp:RequiredFieldValidator>
                      <asp:Label ID="lblmsglglstts" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Select Status<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:DropDownList ID="ddlVillageStatus" ValidationGroup="GroupVmg" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlVillageStatus_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select Status</asp:ListItem>
                        <%-- <asp:ListItem Value="1">Relocated</asp:ListItem>--%>
                        <asp:ListItem Value="2">Non-Relocated</asp:ListItem>
                        <asp:ListItem Value="3">In Progress</asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" SetFocusOnError="true" Text="Please select Status" ForeColor="Red" ValidationGroup="GroupVmg" ErrorMessage="Please select Status" InitialValue="0" ControlToValidate="ddlVillageStatus"></asp:RequiredFieldValidator>
                      <asp:Label ID="lblmsgvillstts" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12" style="display: none;">Select Core/Buffer Status<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12" style="display: none;">
                      <asp:DropDownList ID="ddlcorebufferstatus" ValidationGroup="GroupVmg" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlcorebufferstatus_SelectedIndexChanged" Visible="false">
                        <asp:ListItem Value="0">Select Status</asp:ListItem>
                        <asp:ListItem Value="1">Core Area</asp:ListItem>
                        <asp:ListItem Value="2">Buffer Area</asp:ListItem>
                      </asp:DropDownList>
                      <asp:Label ID="lblmsgcrbuffstts" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Latitude<span class="red-text-1a">*</span>: </label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:TextBox ID="TxtLatitude" ValidationGroup="GroupVmg" placeholder="00.000000" runat="server" CssClass=" form-control" MaxLength="20" autocomplete="off" ></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequireTxtLatitude" runat="server" CssClass="red-text-asterix" ErrorMessage="Please enter Latitude" ControlToValidate="TxtLatitude" Display="Dynamic" SetFocusOnError="True" ValidationGroup="GroupVmg" ForeColor="Red">Please enter Latitude</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegulTxtLatitude" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtLatitude"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="^\d{2}(\.\d{6})$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Latitude in Format (00.000000)</asp:RegularExpressionValidator>
                        
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Longitude<span class="red-text-1a">*</span>: </label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:TextBox ID="TxtLongitude" placeholder="00.000000" ValidationGroup="GroupVmg" runat="server" CssClass="form-control" MaxLength="20" autocomplete="off"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequLongitude" runat="server" CssClass="red-text-asterix" ErrorMessage="Please enter Longitude" ControlToValidate="TxtLongitude" Display="Dynamic" SetFocusOnError="True" ValidationGroup="GroupVmg" ForeColor="Red">Please enter Longitude</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="ReguLongitude" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtLongitude"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="^\d{2}(\.\d{6})$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Longitude in Format (00.000000)</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                  <span>Note:- Format For Latitude and Logitude (22.212900)</span>
                <div class="clearfix"></div>
                <h4><a href="https://www.latlong.net/" style="color: blue; text-decoration: underline;" target="_blank">Please click here for Latitude and Longitude</a></h4>
                <hr>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Date Of Survey<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:TextBox ID="txtsurdate" CssClass="form-control" ValidationGroup="GroupVmg" runat="server" autocomplete="off"></asp:TextBox>
                      <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ValidationGroup="GroupVmg" ID="Image1" runat="server" />
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtsurdate"
                                                                    Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                                    ValidationGroup="GroupVmg" CssClass="red-text-asterix" ForeColor="Red"></asp:RegularExpressionValidator>
                      <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtsurdate"
                                                                    PopupButtonID="Image1" runat="server"> </cc1:CalendarExtender>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtsurdate"
                                                                    Display="Dynamic" ErrorMessage="Please Select Date Of Survey" SetFocusOnError="True"
                                                                    ValidationGroup="GroupVmg" CssClass="red-text-asterix" ForeColor="Red"></asp:RequiredFieldValidator>
                      <asp:CustomValidator runat="server" ID="custDateValidator" ControlToValidate="txtsurdate"
                                                                    ClientValidationFunction="CompareDates" ErrorMessage="Date Should Be Less Than Or Equal to Today's Date "
                                                                    ValidationGroup="GroupVmg" Display="Dynamic" CssClass="red-text-asterix" ForeColor="Red"></asp:CustomValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Date of meeting<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:TextBox ID="TxtDateMeeting" CssClass="form-control" ValidationGroup="GroupVmg" runat="server" autocomplete="off" OnTextChanged="TxtDateMeeting_TextChanged"></asp:TextBox>
                      <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image2" ValidationGroup="GroupVmg" runat="server" />
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="TxtDateMeeting"
                                                                    Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                                    ValidationGroup="GroupVmg" CssClass="red-text-asterix" ForeColor="Red"></asp:RegularExpressionValidator>
                      <cc1:CalendarExtender ID="CaleTxtDateMeeting" Format="dd/MM/yyyy" TargetControlID="TxtDateMeeting"
                                                                    PopupButtonID="Image2" runat="server"> </cc1:CalendarExtender>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TxtDateMeeting"
                                                                    Display="Dynamic" ErrorMessage="Please Select Date Of meeting" SetFocusOnError="True"
                                                                    ValidationGroup="GroupVmg" CssClass="red-text-asterix" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Cut-off Date<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:TextBox ID="TxtCuttOffDate" CssClass="form-control" ValidationGroup="GroupVmg" runat="server" autocomplete="off"></asp:TextBox>
                      <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ValidationGroup="GroupVmg" ID="Image3" runat="server" />
                      <asp:RegularExpressionValidator ID="RegulTxtCuttOffDate" runat="server" ControlToValidate="TxtCuttOffDate"
                                                                    Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                                    ValidationGroup="GroupVmg" CssClass="red-text-asterix" ForeColor="Red"></asp:RegularExpressionValidator>
                      <cc1:CalendarExtender ID="CalendarTxtCuttOffDate" Format="dd/MM/yyyy" TargetControlID="TxtCuttOffDate"
                                                                    PopupButtonID="Image3" runat="server"> </cc1:CalendarExtender>
                      <asp:RequiredFieldValidator ID="RequiredTxtCuttOffDate" runat="server" ControlToValidate="TxtCuttOffDate"
                                                                    Display="Dynamic" ErrorMessage="Please Select cutt-off Date" SetFocusOnError="True"
                                                                    ValidationGroup="GroupVmg" CssClass="red-text-asterix" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                  </div>
                </div>
                <div class="clearfix"></div>
                <hr>
                <div class="col-md-12" style="display: none;">
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">&nbsp;Latitude 1<span class="red-text-asterix"></span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtlang1" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="45px" MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="txtlatmin1" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <asp:TextBox ID="txtlatsec1" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <span class="black-text" style="color: Green;">&nbsp;&nbsp;Degree&nbsp&nbsp;Minutes&nbsp;&nbsp;Seconds</span>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Please Enter value between -90.00 to 90.00 in Degree" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlang1" MaximumValue="90.00" MinimumValue="-90.00" Type="Double" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please Enter value between 0 to 59 in Minutes" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlatmin1" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Please Enter value between 0 to 59 in seconds" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlatsec1" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Longitude 1<span class="red-text-asterix"></span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtlong1" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="45px" MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="txtlongmin1" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <asp:TextBox ID="txtlongsec1" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <span class="black-text" style="color: Green;">&nbsp;&nbsp;Degree&nbsp&nbsp;Minutes&nbsp;&nbsp;Seconds</span>
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="Please Enter value between -90.00 to 90.00 in Degree" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlong1" MaximumValue="90.00" MinimumValue="-90.00" Type="Double" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="Please Enter value between 0 to 59 in Minutes" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlongmin1" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="Please Enter value between 0 to 59 in seconds" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlongsec1" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Latitude 2<span class="red-text-asterix"></span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtlang2" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="45px" MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="txtlatmin2" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2" OnTextChanged="txtlatmin2_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtlatsec2" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <span class="black-text" style="color: Green;">&nbsp;&nbsp;Degree&nbsp&nbsp;Minutes&nbsp;&nbsp;Seconds</span>
                        <asp:RangeValidator ID="RangeValidator7" runat="server" ErrorMessage="Please Enter value between -90.00 to 90.00 in Degree" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlang2" MaximumValue="90.00" MinimumValue="-90.00" Type="Double" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator8" runat="server" ErrorMessage="Please Enter value between 0 to 59 in Minutes" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlatmin2" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator9" runat="server" ErrorMessage="Please Enter value between 0 to 59 in seconds" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlatsec2" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Longitude 2<span class="red-text-asterix"></span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtlong2" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="45px" MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="txtlongmin2" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2" OnTextChanged="txtlongmin2_TextChanged"></asp:TextBox>
                        <asp:TextBox ID="txtlongsec2" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <span class="black-text" style="color: Green;">&nbsp;&nbsp;Degree&nbsp&nbsp;Minutes&nbsp;&nbsp;Seconds</span><br />
                        <asp:RangeValidator ID="RangeValidator10" runat="server" ErrorMessage="Please Enter value between -90.00 to 90.00 in Degree" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlong2" MaximumValue="90.00" MinimumValue="-90.00" Type="Double" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator11" runat="server" ErrorMessage="Please Enter value between 0 to 59 in Minutes" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlongmin2" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator12" runat="server" ErrorMessage="Please Enter value between 0 to 59 in seconds" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlongsec2" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Latitude 3<span class="red-text-asterix"></span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtlang3" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="45px" MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="txtlatmin3" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <asp:TextBox ID="txtlatsec3" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <span class="black-text" style="color: Green;">&nbsp;&nbsp;Degree&nbsp&nbsp;Minutes&nbsp;&nbsp;Seconds</span>
                        <asp:RangeValidator ID="RangeValidator13" runat="server" ErrorMessage="Please Enter value between -90.00 to 90.00 in Degree" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlang3" MaximumValue="90.00" MinimumValue="-90.00" Type="Double" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator14" runat="server" ErrorMessage="Please Enter value between 0 to 59 in Minutes" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlatmin3" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator15" runat="server" ErrorMessage="Please Enter value between 0 to 59 in seconds" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlatsec3" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Longitude 3<span class="red-text-asterix"></span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtlong3" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="45px" MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="txtlongmin3" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <asp:TextBox ID="txtlongsec3" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <span class="black-text" style="color: Green;">&nbsp;&nbsp;Degree&nbsp&nbsp;Minutes&nbsp;&nbsp;Seconds</span>
                        <asp:RangeValidator ID="RangeValidator16" runat="server" ErrorMessage="Please Enter value between -90.00 to 90.00 in Degree" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlong3" MaximumValue="90.00" MinimumValue="-90.00" Type="Double" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator17" runat="server" ErrorMessage="Please Enter value between 0 to 59 in Minutes" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlongmin3" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator18" runat="server" ErrorMessage="Please Enter value between 0 to 59 in seconds" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlongsec3" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Latitude 4<span class="red-text-asterix"></span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtlang4" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="45px" MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="txtlatmin4" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <asp:TextBox ID="txtlatsec4" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <span class="black-text" style="color: Green;">&nbsp;&nbsp;Degree&nbsp&nbsp;Minutes&nbsp;&nbsp;Seconds</span>
                        <asp:RangeValidator ID="RangeValidator19" runat="server" ErrorMessage="Please Enter value between -90.00 to 90.00 in Degree" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlang4" MaximumValue="90.00" MinimumValue="-90.00" Type="Double" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator20" runat="server" ErrorMessage="Please Enter value between 0 to 59 in Minutes" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlatmin4" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator21" runat="server" ErrorMessage="Please Enter value between 0 to 59 in seconds" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlatsec4" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Longitude 4<span class="red-text-asterix"></span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtlong4" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="45px" MaxLength="6"></asp:TextBox>
                        <asp:TextBox ID="txtlongmin4" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <asp:TextBox ID="txtlongsec4" ValidationGroup="GroupVmg" runat="server" CssClass="textfield" Width="38px" MaxLength="2"></asp:TextBox>
                        <span class="black-text" style="color: Green;">&nbsp;&nbsp;Degree&nbsp&nbsp;Minutes&nbsp;&nbsp;Seconds</span>
                        <asp:RangeValidator ID="RangeValidator22" runat="server" ErrorMessage="Please Enter value between -90.00 to 90.00 in Degree" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlong4" MaximumValue="90.00" MinimumValue="-90.00" Type="Double" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator23" runat="server" ErrorMessage="Please Enter value between 0 to 59 in Minutes" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlongmin4" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator24" runat="server" ErrorMessage="Please Enter value between 0 to 59 in seconds" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtlongsec4" MaximumValue="59" MinimumValue="0" Type="Integer" ForeColor="Red"></asp:RangeValidator>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="clearfix"></div>
                <div class="form-horizontal table-2 col-md-12">
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Male Population<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12 auto-style1">
                        <asp:TextBox ID="txtmalepop" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Number of villages" ControlToValidate="txtmalepop" Display="Dynamic" SetFocusOnError="True" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Male Population</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" CssClass="red-text-asterix" ControlToValidate="txtmalepop"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Female Population<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12 auto-style1">
                        <asp:TextBox ID="txtfemalepop" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Number of villages" ControlToValidate="txtfemalepop" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Female Population</asp:RequiredFieldValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total number of adult<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12 auto-style1">
                        <asp:TextBox ID="Txtadult" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Number of adult" ControlToValidate="Txtadult" Display="Dynamic" SetFocusOnError="True" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total number of adult</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" CssClass="red-text-asterix" ControlToValidate="Txtadult"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total number of transgender:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12 auto-style1">
                        <asp:TextBox ID="TxtnoTransgender" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtnoTransgender"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                        <asp:CustomValidator runat="server" ID="CustomValidator2" SetFocusOnError="True" ControlToValidate="txtmalepop"
                                                                    ClientValidationFunction="AddPopulation" ValidationGroup="GroupVmg" ForeColor="Red"></asp:CustomValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of ST<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtst" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" OnTextChanged="txtst_TextChanged" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Number of villages" ControlToValidate="txtst" Display="Dynamic" SetFocusOnError="True" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total ST</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" CssClass="red-text-asterix" ControlToValidate="txtst"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                      </div>
                    </div>
                  </div>
                  <div class="clearfix"></div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of OBC<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtobc" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" OnTextChanged="txtobc_TextChanged" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Number of villages" ControlToValidate="txtobc" Display="Dynamic" SetFocusOnError="True" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total OBC</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" CssClass="red-text-asterix" ControlToValidate="txtobc"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of OTHERS<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtother" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Number of villages" ControlToValidate="txtother" Display="Dynamic" SetFocusOnError="True" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Others</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" CssClass="red-text-asterix" ControlToValidate="txtother"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of SC<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtsc" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Number of villages" ControlToValidate="txtsc" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total SC</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" CssClass="red-text-asterix" ControlToValidate="txtsc"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total number of Village Population<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtPop" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      </div>
                    </div>
                  </div>
                </div>
                <asp:Label ID="LblVpop" runat="server" ForeColor="Red"></asp:Label>
                <div class="clearfix"></div>
                <hr />
                <div class="table-2 col-md-12 form-horizontal">
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Others Lands Area (Ha)<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                        <asp:TextBox ID="txtotherland" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" ErrorMessage="Total Number of villages" Display="Dynamic" ControlToValidate="txtotherland" ForeColor="Red">Please Enter Others Lands Area</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtotherland" ErrorMessage="Enter Only Decimal value" ValidationExpression="[[0-9]+(\.[0-9][0-9][0-9]?)?" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Agricultural Land (Ha)<span class="red-text-1a">*</span>:</label>
                      <div class="col-md-8 col-sm-8 col-xs-12">
                        <asp:TextBox ID="txtagri" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" ErrorMessage="Total Number of villages" Display="Dynamic" ControlToValidate="txtagri" ForeColor="Red">Please Enter Total Agricultural Land</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtagri" ErrorMessage="Enter Only Decimal value" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">
                    Total Residential Land (Ha)<span class="red-text-1a">*:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="txtnonagri" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator16" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" ErrorMessage="Total Number of villages" Display="Dynamic" ControlToValidate="txtnonagri" ForeColor="Red">Please Enter Total Residential Land</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtnonagri" ErrorMessage="Enter Only Decimal value" ValidationExpression="[[0-9]+(\.[0-9][0-9][0-9]?)?" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Land Area (Ha)<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:TextBox ID="txtland" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" OnTextChanged="txtland_TextChanged" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Land area" ControlToValidate="txtland" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Land Area</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" CssClass="red-text-asterix" ControlToValidate="txtland"
                                                                    Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                                                    ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Value of Agricultural Land (Per Ha)<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="txtvalagri" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="15" OnTextChanged="txtvalagri_TextChanged" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="True" CssClass="red-text-asterix" ValidationGroup="GroupVmg" ErrorMessage="Value of Agricultural Land" Display="Dynamic" ControlToValidate="txtvalagri" ForeColor="Red">Please Enter Value of Agricultural Land</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtvalagri" ErrorMessage="Enter Only Decimal value" ValidationExpression="[[0-9]+(\.[0-9][0-9][0-9]?)?" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Value of Residential Land (Per Ha)<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="txtvalres" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="15" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" ErrorMessage="Total Number of villages" Display="Dynamic" ControlToValidate="txtvalres" ForeColor="Red">Please Enter Value of Residential Land</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" CssClass="red-text-asterix" ValidationGroup="GroupVmg" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtvalres" ErrorMessage="Enter Only Decimal value" ValidationExpression="[[0-9]+(\.[0-9][0-9][0-9]?)?" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Number Of Families<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="txtfamilies" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Enter Numbers Of Families " ControlToValidate="txtfamilies" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Numbers Of Families</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="red-text-asterix" ControlToValidate="txtfamilies"
                                                        Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                        ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of Cow:<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12">
                      <asp:TextBox ID="TxtNoCow" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator22" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Cow" ControlToValidate="TxtNoCow" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Cow</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtNoCow"
                                                        Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                        ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of Buffalo:<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="TxtBuffalo" runat="server" ValidationGroup="GroupVmg" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator23" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Buffalo" ControlToValidate="TxtBuffalo" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Buffalo</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtBuffalo"
                                                        Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                        ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Number of Sheep:<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="TxtSheep" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator24" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Sheep" ControlToValidate="TxtSheep" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Sheep</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtSheep"
                                                        Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                        ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Number of Goat:<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="TxtGoat" runat="server" ValidationGroup="GroupVmg" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator25" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Goat" ControlToValidate="TxtGoat" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Goat</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtGoat" Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                        ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Numbers of Others Animals<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="txtothranml" ValidationGroup="GroupVmg" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator20" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Numbers of Other Animals" ControlToValidate="txtothranml" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Numbers of Other Animals</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" CssClass="red-text-asterix" ControlToValidate="txtothranml"
                                                        Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                        ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Livestock<span class="red-text-1a">*</span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="txtlivestock" runat="server" ValidationGroup="GroupVmg" CssClass="textfield form-control" MaxLength="10" autocomplete="off" onkeypress="return validateNumber(event);"></asp:TextBox>
                      <br />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" SetFocusOnError="True" runat="server" CssClass="red-text-asterix" ErrorMessage="Total Livestock" ControlToValidate="txtlivestock" Display="Dynamic" ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Total Livestock</asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" CssClass="red-text-asterix" ControlToValidate="txtlivestock"
                                                        Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                        ValidationGroup="GroupVmg" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">Comments<span class="red-text-asterix"></span>:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                      <asp:TextBox ID="txtcomments" runat="server" CssClass="textfield form-control" ValidationGroup="GroupVmg" AutoCompleteType="Email" TextMode="MultiLine" Height="100px" MaxLength="300" autocomplete="off"></asp:TextBox>
                      <br />
                    </div>
                  </div>
                </div>
                <div class="col-md-12" style="display: none;">
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Cow & Buffalo<span class="red-text-1a">*</span>:-----</label>
                      <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                        <asp:TextBox ID="txtcnb" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                        ------<br />
                      </div>
                    </div>
                  </div>
                  <div class="col-md-6 col-sm-6 col-xs-12">
                    <div class="form-group">
                      <label class="control-label col-md-4 col-sm-4 col-xs-12">Total Sheep & Goat<span class="red-text-1a">*</span>:--------</label>
                      <div class="col-md-8 col-sm-8 col-xs-12 auto-style2">
                        <asp:TextBox ID="txtsng" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                        ------<br />
                      </div>
                    </div>
                  </div>
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">File/Image attachment:</label>
                    <div class="col-md-8 col-sm-8 col-xs-12 auto-style2"> <span style="font-family: Arial">Click here to upload multiple files</span>&nbsp;&nbsp;
                      <input id="Button1" type="button" value="add" onClick="AddFileUpload()" class="btn btn-success" />
                      <asp:FileUpload ID="fileUpload_Menu" runat="server" ValidationGroup="GroupVmg" Visible="false"/>
                      <asp:Label ID="lblmenuMsg" runat="server" Text="Current File:" Visible="False" ForeColor="Black"></asp:Label>
                      <asp:Label ID="lblFileName" runat="server" Visible="False" ForeColor="Green"></asp:Label>
                      <br/><em class="em" style="color: green;">Note:-pdf,xlsx,docx,doc,jpg,jpeg,png</em> <span class="validation">
                      <asp:CustomValidator ID="CustomValidator3" runat="server" SetFocusOnError="true" ClientValidationFunction="ValidateFileUpload1"
                                                            ControlToValidate="fileUpload_Menu" OnServerValidate="CustomValidator3_ServerValidate"
                                                            ValidationGroup="GroupVmg" ErrorMessage="Please select pdf,xlsx,docx,doc." Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                      </span>
                      <asp:CustomValidator ID="CustomValidator1" SetFocusOnError="true" ValidationGroup="GroupVmg" OnServerValidate="ValidateFileSize" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="fileUpload_Menu" ErrorMessage="FileSize should not exceed 3MB." ClientValidationFunction="checkfilesize" />
                      <div>
                        <asp:Label ID="LblfileUpload_Menu" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                      </div>
                    </div>
                  </div>
                </div>
                     <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <label class="control-label col-md-4 col-sm-4 col-xs-12">KML File:</label>
                    
                      <asp:FileUpload ID="fileKML" runat="server" ValidationGroup="GroupVmg" />
                      <asp:Label ID="lblKMLCurrentFile" runat="server" Text="Current File:" Visible="False" ForeColor="Black"></asp:Label>
                      <asp:Label ID="lblKMLOldFile" runat="server" Visible="False" ForeColor="Green"></asp:Label>
                      <br/><em class="em" style="color: green;">Note:-kml or kmz file</em> <span class="validation">
                      <asp:CustomValidator ID="CustomValidator4" runat="server" SetFocusOnError="true" 
                                                            ControlToValidate="fileKML" OnServerValidate="CustomValidator4_ServerValidate"
                                                            ValidationGroup="GroupVmg" ErrorMessage="Please select kml or kmz file" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                      </span>
                      <div>
                        <asp:Label ID="Label3" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                      </div>
                    </div>
                 
                </div>
                <div class="col-md-6 col-sm-6 col-xs-12">
                  <div class="form-group">
                    <div id="FileUploadContainer"> 
                      <!--FileUpload Controls will be added here --> 
                    </div>
                  </div>
                </div>
              </div>
              <hr />
              <div class="col-md-12">
                <div style="display: none; background-color: black; color: white; padding: 7px; margin-bottom: 20px;">
                  <p>NOTE:"Total Numbers of(SC's,OBC's,ST's and others) must be equal to Village Population"</p>
                  <p>NOTE:"Total of(Agricultural land,Residentail land and others land Area) must be equal to Total Land Area"</p>
                  <p>NOTE:"Total of(Cow & Buffalo,Sheep & Goat and Other Animal) must be equal to Total Livestocks"</p>
                </div>
                <asp:Button ID="ImgbtnSubmit" runat="server" data-toggle="tooltip" Text="Save & Next" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmit_Click" title="Click here for next step" ValidationGroup="GroupVmg" />
                &nbsp;
                <asp:Button ID="ImgbtnCancel" runat="server" CssClass="btn btn-primary btn-add" CausesValidation="false" Text="Reset" OnClick="ImgbtnCancel_Click" />
                &nbsp;
                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary btn-add" Text="Next" OnClick="btnNext_Click" visible="false" />
                   &nbsp;
                  <asp:Button ID="ImgbtnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImgbtnBack_ClickNew" />
                <br />
                <br />
              </div>
              <asp:HiddenField ID="HiddenField1" runat="server" />
              <div style="clear: both"></div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="modal fade tophght" id="myModal" role="dialog">
      <div class="modal-dialog modwidth"> 
        
        <!-- Modal content-->
        <div class="modal-content">
          <div class="modal-header nobdr"> </div>
          <div class="modal-body text-center modwidth1">
            <p><b>Village Detail has been save successfully.Please proceed to next step</b></p>
          </div>
          <div class="modal-footer text-center procenter nobdr" >
            <asp:Button ID="btnnextstep" runat="server" CssClass="btn btn-success" Text="OK" OnClick="btnnextstep_Click"/>
          </div>
        </div>
      </div>
    </div>
    <script type="text/javascript">

            var counter = 0;

            function AddFileUpload() {

                var div = document.createElement('DIV');

                div.innerHTML = '<input id="file' + counter + '" name = "file' + counter +

                                '" type="file" class="input_inline" />' +

                                '<input id="Button' + counter + '" type="button" ' +

                                'value="Remove" class="btn btn-danger" onclick = "RemoveFileUpload(this)" />';

                document.getElementById("FileUploadContainer").appendChild(div);

                counter++;

            }

            function RemoveFileUpload(div) {

                document.getElementById("FileUploadContainer").removeChild(div.parentNode);

            }
            $(document).ready(function () {
               // $('#contentbody_btnNext').hide();
                $('#btnclose').click(function () {
                    $('#contentbody_ImgbtnCancel').hide();
                    $('#contentbody_ImgbtnSubmit').hide();
                    $('#contentbody_btnNext').show();
                   
            });
        });
    </script> 
         <script type="text/javascript">

             $(document).ready(function () {
                 $("[id*=TxtLatitude]").on("keypress keyup blur", function (event) {
                     //this.value = this.value.replace(/[^0-9\.]/g,'');
                     $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
                     if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                         event.preventDefault();
                     }
                 });
                 
                 $("[id*=TxtLongitude]").on("keypress keyup blur", function (event) {
                     //this.value = this.value.replace(/[^0-9\.]/g,'');
                     $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
                     if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
                         event.preventDefault();
                     }
                 });
                 $('[data-toggle="tooltip"]').tooltip();
             });
             
    </script>
  </div>
  </div>
  </div>
</asp:Content>
