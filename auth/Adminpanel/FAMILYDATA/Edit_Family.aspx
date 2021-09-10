<%@ Page Title="NTCA:Edit family" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Edit_Family.aspx.cs" Inherits="auth_Adminpanel_FAMILYDATA_Edit_Family" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .table-2 td {
            text-align: left;
            padding-bottom: 4px;
            vertical-align: top;
        }

        .textfield-drop {
            width: 70%;
        }

        .jinn {
            float: left;
        }

        .red-text-1a {
            color: red;
        }
    </style>
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
        }</script>
    <script language="javascript" type="text/javascript">
        function IMG1_onclick() {

        }


        /****************************************************
            
        ****************************************************/
        var win = null;
        function NewWindow(mypage, myname, w, h, scroll, pos) {
            if (pos == "random") { LeftPosition = (screen.availWidth) ? Math.floor(Math.random() * (screen.availWidth - w)) : 50; TopPosition = (screen.availHeight) ? Math.floor(Math.random() * ((screen.availHeight - h) - 75)) : 50; }
            if (pos == "center") { LeftPosition = (screen.availWidth) ? (screen.availWidth - w) / 2 : 50; TopPosition = (screen.availHeight) ? (screen.availHeight - h) / 2 : 50; }
            if (pos == "default") { LeftPosition = 50; TopPosition = 50 }
            else if ((pos != "center" && pos != "random" && pos != "default") || pos == null) { LeftPosition = 0; TopPosition = 20 }
            settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=yes';
            win = window.open(mypage, myname, settings);
            if (win.focus) { win.focus(); }
        }
        function IMG1_onclick() {

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


            $("#ToolTipHref").mouseover(function () {
                $("#TooltipContent").show(1000);
                return false;
                // alert('mouseover');
                // $("p").css("background-color", "yellow");
            });
            $("#ToolTipHref").mouseout(function () {
                $("#TooltipContent").hide(1000);
                return false;
                // alert('mouseout');
                //$("p").css("background-color", "lightgray");
            });

            //-----------------

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
    </script>

    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>

    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">

        <div class="inner-content-right">

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-2">
                <tr>
                    <td colspan="6" style="border-bottom: 3px solid #005529;">
                        <h3 style="color: #005529;">Edit Family Details</h3>
                    </td>

                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 306px">
                        <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1">
                            <tr>
                                <td colspan="3" align="center">
                                    <asp:Label ID="lblMsg" runat="server" CssClass="red-text"></asp:Label></td>
                            </tr>

                            <tr>
                                <td class="black-text" colspan="3">
                                    <table width="98%" border="0px" align="center" cellpadding="3" cellspacing="1" class="table-2 table table-bordered">



                                        <tr>
                                            <td>
                                                <table width="98%" align="center" cellpadding="3" cellspacing="1">
                                                    <tr>
                                                        <td width="50%" align="right"><span style="color: Black;"><b>District&nbsp;:</b></span> </td>
                                                        <td width="50%" align="left"><b>
                                                            <asp:Label ID="lbldistrict" runat="server" ForeColor="#713002"></asp:Label></b></td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td>
                                                <table width="98%" align="center" cellpadding="3" cellspacing="1">
                                                    <tr>
                                                        <td width="50%" align="right"><span style="color: Black;"><b>Tehsil&nbsp;:</b></span> </td>
                                                        <td width="50%" align="left"><b>
                                                            <asp:Label ID="lbltehsil" runat="server" ForeColor="#713002"></asp:Label></b></td>
                                                    </tr>
                                                </table>



                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="98%" align="center" cellpadding="3" cellspacing="1">
                                                    <tr>
                                                        <td width="50%" align="right"><span style="color: Black;"><b>Grampanchayat&nbsp;:</b></span> </td>
                                                        <td width="50%" align="left"><b>
                                                            <asp:Label ID="lblgp" runat="server" ForeColor="#713002"></asp:Label></b></td>
                                                    </tr>
                                                </table>


                                            </td>
                                            <td>
                                                <table width="98%" align="center" cellpadding="3" cellspacing="1">
                                                    <tr>
                                                        <td width="50%" align="right"><span style="color: Black;"><b>Village&nbsp;:</b></span> </td>
                                                        <td width="50%" align="left"><b>
                                                            <asp:Label ID="lblvillname" runat="server" ForeColor="#713002"></asp:Label></b></td>
                                                    </tr>
                                                </table>



                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td style="height: 52px">

                                                <table width="98%" align="center" cellpadding="3" cellspacing="1">
                                                    <tr>
                                                        <td width="50%" align="right"><span style="color: Black;"><b>Village Code&nbsp;:</b></span> </td>
                                                        <td width="50%" align="left"><b>
                                                            <asp:Label ID="lblvillcode" runat="server" ForeColor="#713002"></asp:Label></b></td>
                                                    </tr>
                                                </table>


                                            </td>
                                            <td style="height: 52px">

                                                <table width="98%" align="center" cellpadding="3" cellspacing="1">
                                                    <tr>
                                                        <td width="50%" align="right"><span style="color: Black;"><b>Family Code :</b></span></td>
                                                        <td width="50%" align="left"><b>
                                                            <asp:Label ID="lblcode" runat="server" ForeColor="#713002"></asp:Label></b></td>
                                                    </tr>
                                                </table>


                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="3" width="100%">
                                    <p>
                                        <asp:LinkButton ID="lnkViewDetailss" Font-Underline="true" Font-Bold="true" ForeColor="Blue" runat="server" Text='Option I & Option II details.'></asp:LinkButton>
                                    </p>
                                    <table width="98%" border="0px" align="center" cellpadding="3" cellspacing="1" class="table-2">

                                        <tr>
                                            <td class="black-text" align="right" width="20%">Option Selected<span class="red-text-1a">*</span>:</td>

                                            <td width="30%">
                                                <asp:UpdatePanel ID="updOptionSelection" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="DDLSchemeopted" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="DDLSchemeopted_SelectedIndexChanged">
                                                            <asp:ListItem Value="1" Text="I"></asp:ListItem>

                                                            <asp:ListItem Value="3" Text="II"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="Any Other"></asp:ListItem>

                                                        </asp:DropDownList>
                                                        <div id="dvOtherOption" runat="server" visible="false" class="col-md-8 col-sm-8 col-xs-12">
                                                            <asp:TextBox ID="txtOtherOption" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>

                                            <td class="black-text" align="right" width="20%" style="display: none;">Group Name<span class="red-text-asterix"></span> :</td>

                                            <td width="30%" style="display: none;">
                                                <asp:DropDownList ID="ddlselectgroupname" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Survey Date:</td>

                                            <td width="30%">
                                                <asp:TextBox ID="txtsurdate" runat="server" autocomplete="off" CssClass="textfield form-control jinn"></asp:TextBox>
                                                <asp:Image ImageUrl="~/AUTH/adminpanel/images/cal.jpg" ID="Image3" runat="server" /><br />
                                                <br />

                                                <div>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtsurdate"
                                                        Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                        ValidationGroup="ADD" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </div>
                                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtsurdate"
                                Display="Dynamic" ErrorMessage="Please enter Survey Date" SetFocusOnError="True"
                                ValidationGroup="ADD"></asp:RequiredFieldValidator>        --%>
                                                <%--<%--                                 <asp:CustomValidator runat="server" ID="custDateValidator" ControlToValidate="txtsurdate"
                                ClientValidationFunction="CompareDates" ErrorMessage="Date Should Be Less Than Or Equal to Today's Date "
                                ValidationGroup="ADD"  Display="Dynamic" CssClass="red-text-asterix"></asp:CustomValidator>--%>
                                                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtsurdate"
                                                    PopupButtonID="Image3" runat="server">
                                                </cc1:CalendarExtender>
                                            </td>

                                            <td class="black-text" align="right">Relocation Status</td>

                                            <td width="30%">
                                                <asp:DropDownList ID="ddlselectRelocation" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True">
                                                    <asp:ListItem Value="-1">Select Status</asp:ListItem>
                                                    <asp:ListItem Value="2">Non-Relocated</asp:ListItem>
                                                    <asp:ListItem Value="3">In Progress</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="black-text" align="right" width="40%">Valid Id Name (Like Ration Card or Voter ID):</td>

                                                        <td width="60">
                                                            <asp:TextBox ID="txtrashancard" runat="server" CssClass="textfield form-control" autocomplete="off" MaxLength="100"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                                ControlToValidate="txtrashancard" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADD"
                                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="black-text" align="right" style="height: 26px">Valid Id Number<span class="red-text-asterix"></span>:</td>

                                                        <td style="height: 26px">
                                                            <asp:TextBox ID="txtrashan" runat="server" CssClass="textfield form-control" autocomplete="off" MaxLength="100"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                                ControlToValidate="txtrashan" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADD"
                                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td class="black-text" align="right">&nbsp;Write Relocation site :</td>

                                                        <td>
                                                            <asp:TextBox ID="txtreloplace" runat="server" CssClass="textfield form-control" MaxLength="150"></asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" CssClass="red-text-asterix"
                                                                ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtreloplace"
                                                                ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$"
                                                                SetFocusOnError="True" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>
                                                            --%> </td>
                                                    </tr>
                                                </table>
                                            </td>


                                            <td class="black-text" align="right">Comments<span class="red-text-asterix"></span>:</td>

                                            <td>
                                                <asp:TextBox ID="txtcomments" runat="server" CssClass="textfield form-control" TextMode="MultiLine" Height="100px" autocomplete="off" MaxLength="300"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="txtcomments" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADD"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>


                            <tr>
                                <td colspan="3">
                                    <table width="98%" border="0px" align="center" cellpadding="3" cellspacing="1" class="table-2">

                                        <tr>
                                            <td class="black-text" align="right" width="20%">Agricultural Land (Ha)<span class="red-text-asterix"></span>:</td>

                                            <td width="30%">
                                                <asp:TextBox ID="txtagri" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox><br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" CssClass="red-text-asterix " ControlToValidate="txtagri"
                                                    Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                                    ValidationGroup="ADD" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                                            </td>

                                            <td class="black-text" align="right" width="20%">Residential Property (Ha)<span class="red-text-asterix"></span>:</td>

                                            <td width="30%">
                                                <asp:TextBox ID="txtresland" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox><br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="red-text-asterix " ControlToValidate="txtresland"
                                                    Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                                    ValidationGroup="ADD" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">&nbsp;Status of Residence (Kaccha/Pucca):</td>

                                            <td>
                                                <asp:DropDownList ID="ddlselectstatusresland" runat="server" AutoPostBack="True" CssClass="textfield-drop form-control">
                                                    <asp:ListItem Value="0">Select Home Status</asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Kaccha"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pucca"></asp:ListItem>
                                                </asp:DropDownList>

                                            </td>

                                            <td class="black-text" align="right">Total&nbsp; Wells<span class="red-text-asterix"></span>:</td>

                                            <td>
                                                <asp:TextBox ID="txtwells" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtwells" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Total&nbsp; Standing Trees<span class="red-text-asterix"></span>:</td>

                                            <td>
                                                <asp:TextBox ID="txttrees" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtwells" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                            </td>

                                            <td class="black-text" align="right">Other Assets<span class="red-text-asterix"></span>:</td>

                                            <td>
                                                <asp:TextBox ID="txtotherassets" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtotherassets" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Total Numbers of Cow:<span class="red-text-1a">*</span>:</td>

                                            <td>
                                                <asp:TextBox ID="TxtNoCow" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Cow" ControlToValidate="TxtNoCow" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Total Cow</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtNoCow"
                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                    ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                            </td>

                                            <td class="black-text" align="right">Total Numbers of Buffalo:<span class="red-text-1a">*</span>:
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TxtBuffalo" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Buffalo" ControlToValidate="TxtBuffalo" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Total Buffalo</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtBuffalo"
                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                    ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Total Number of Goat:<span class="red-text-1a">*</span>:    
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TxtGoat" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Goat" ControlToValidate="TxtGoat" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Total Goat</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtGoat"
                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                    ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                            </td>

                                            <td class="black-text" align="right">Total Number of Sheep:<span class="red-text-1a">*</span>:
                                            </td>

                                            <td>
                                                <asp:TextBox ID="TxtSheep" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox><br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Total Sheep" ControlToValidate="TxtSheep" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Total Sheep</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtSheep"
                                                    Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                                    ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="black-text" align="right">Other Animal<span class="red-text-asterix"></span>:</td>

                                            <td>
                                                <asp:TextBox ID="txtotheranimal" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtotheranimal" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                            </td>

                                            <td class="black-text" align="right">Total Livestock<span class="red-text-asterix"></span>:</td>

                                            <td>
                                                <asp:TextBox ID="txtlivestock" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtlivestock" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td class="black-text" align="right"></td>

                                            <td></td>

                                            <td class="black-text" align="right">Total Cow & Buffalo<span class="red-text-asterix"></span>:</td>

                                            <td>
                                                <asp:TextBox ID="txtcownbuff" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox>
                                                <br />
                                                <%--<asp:RegularExpressionValidator id="RegularExpressionValidator7" runat="server" Cssclass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtcownbuff" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>--%>      
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td class="black-text" align="right">Total Sheep & Goat<span class="red-text-asterix"></span>:</td>

                                            <td>
                                                <asp:TextBox ID="txtsheepngoat" runat="server" CssClass="textfield form-control" MaxLength="10" autocomplete="off"></asp:TextBox><br />
                                                <%--<asp:RegularExpressionValidator id="RegularExpressionValidator8" runat="server" Cssclass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtsheepngoat" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>--%>          
                                            </td>

                                            <td class="black-text" align="right"></td>


                                            <td></td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="3" width="100%">
                                    <table width="98%" border="0px" align="center" cellpadding="3" cellspacing="1" class="table-2">
                                        <tr>
                                            <td colspan="4" width="100%" align="center">
                                                <asp:Button ID="btnAddmember" Visible="false" runat="server" Text="Add New Member" CssClass="btn btn-primary btn-add" OnClick="btnAddmember_Click" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>



                            <tr>

                                <td width="70%" colspan="3">

                                    <%--start popu--%>

                                    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none; max-height: 80%; overflow-y: auto;" Width="600px">
                                        <table border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">

                                            <tr>
                                                <td colspan="3" style="border-bottom: 3px solid #005529;">
                                                    <h3 style="color: #005529;">Please Enter Family Member Details </h3>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td colspan="3" class="black-text" align="center">

                                                    <h4><a href="#" style="color: blue;" id="ToolTipHref">Notice:Family Definition</a></h4>
                                                    <div class="col-md-12">
                                                        <div id="TooltipContent" style="display: none; background-color: #e8d289; border: groove; text-justify: auto; font-weight: bold;">

                                                            <p>
                                                                A "family" would mean a person, his or her spouse, minor sons 

and daughters, minor brothers or unmarried sisters, father, mother and other members residing with him/her and dependent on him/her for 

their livelihood. A family would be eligible for the package from only one location where it normally resides even if it owns land in 

other settlements requiring relocation.
                                                            </p>
                                                            <p>
                                                                "family" would mean a person, his or her spouse, minor sons and 

daughters, minor brothers or unmarried sisters, father, mother and other members residing with him/her and dependent on him/her for 

their livelihood. A family would be eligible for the package from only one location where it normally resides even if it owns land in 

other settlements requiring relocation.

                                                                    <p>
                                                                        1. A major (over 18 years) son irrespective of his marital 

status.
                                                                    </p>
                                                            <p>2. Unmarried daughter/sister more than 18 years of age.</p>
                                                            <p>
                                                                3. Physically and mentally challenged person irrespective of age 

and sex.
                                                            </p>
                                                            <p>4. Minor orphan, who has lost both his/her parents.</p>
                                                            <p>5. A widow or a woman divorcee.</p>
                                                        </div>
                                                    </div>

                                                    <asp:Label ID="lblMsg1" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right" width="200px">Name<span class="red-text-1a">*</span></td>
                                                <td class="black-text" width="10px" align="center">:</td>
                                                <td width="200px" align="left">
                                                    <asp:TextBox ID="txtname" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="100"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtname"
                                                        Display="Dynamic" ErrorMessage="Please Enter Name" SetFocusOnError="True"
                                                        ValidationGroup="ADDMember" CssClass="red-text-asterix"></asp:RequiredFieldValidator>
                                                </td>

                                            </tr>


                                            <tr id="trPhoto" runat="server" visible="false">
                                                <td class="black-text" align="right" width="200px">Add your photo:<span class="red-text-1a">*</span></td>
                                                <td class="black-text" width="10px" align="center">:</td>
                                                <td width="200px" align="left">
                                                    <asp:FileUpload ID="fileUpload_Menu" runat="server" />
                                                    <asp:Label ID="lblmenuMsg" runat="server" Text="Current File:" Visible="False" ForeColor="Black"></asp:Label>
                                                    <asp:Label ID="lblFileName" runat="server" Visible="False" ForeColor="Green"></asp:Label>

                                                    <em class="em" style="color: green;">Tip:-jpg,jpeg,png</em>

                                                    <span class="validation">
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
            ControlToValidate="fileUpload_Menu" ErrorMessage="Photo Required!" Display="Dynamic" ValidationGroup="ADDMember" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        --%>
                                                        <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="ValidateFileUpload1"
                                                            ControlToValidate="fileUpload_Menu" OnServerValidate="CustomValidator3_ServerValidate"
                                                            ValidationGroup="ADDMember" ErrorMessage="Please select jpg,jpeg,png." Display="Dynamic" ForeColor="Red"></asp:CustomValidator></span>
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
                                                <td class="black-text" align="right">Relation With Family Head</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlselectrelation" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectrelation_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </td>

                                            </tr>


                                            <%if (ddlselectrelation.SelectedValue.ToString().Equals("1"))
                                                { %>

                                            <tr>
                                                <td class="black-text" align="right">Father/Husband Name</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtfathername" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="100"></asp:TextBox><br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ForeColor="Red" runat="server" CssClass="red-text-asterix" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtfathername" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator>

                                                </td>

                                            </tr>
                                            <% }%>
                                            <tr>
                                                <td class="black-text" align="right">Date of Birth (DOB):</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtDOB" autocomplete="off" runat="server" AutoPostBack="True" CssClass="textfield " OnTextChanged="TxtDOB_TextChanged"></asp:TextBox>
                                                    <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image4" runat="server" /><br />
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

                                                    <%-- <asp:CustomValidator runat="server" ID="custDateTxtDOB" ControlToValidate="TxtDOB"
                                                        ClientValidationFunction="CompareDates" ErrorMessage="Date Should Be Less Than Or Equal to Today's Date "
                                                        ValidationGroup="ADDMember" Display="Dynamic" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:CustomValidator>--%>

                                                    <asp:Label ID="LblCuttoffDateShow" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="LblMsgDbo" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>

                                            <tr>



                                                <td align="right" class="black-text">Age (Years)</td>
                                                <td align="center" class="black-text">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtage" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="3"></asp:TextBox>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtage" CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Only Digits" SetFocusOnError="True" ValidationExpression="[0-9]+$" ValidationGroup="ADDMember">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                                </td>
                                                <tr>
                                                    <td align="right" class="black-text">Sex</td>
                                                    <td align="center" class="black-text">:</td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="ddlselectsex" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectsex_SelectedIndexChanged">
                                                            <asp:ListItem Text="Select Sex" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Transgender"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            <tr>
                                                <td align="right" class="black-text">cast</td>
                                                <td align="center" class="black-text">:</td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlselectcast" runat="server" CssClass="textfield-drop form-control">
                                                        <asp:ListItem Text="Select Cast" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="OBC" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="SC" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="ST" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="OTHER" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>



                                            <tr style="display: none;">
                                                <td align="right" class="black-text">Valid Id Number<br />
                                                </td>
                                                <td align="center" class="black-text">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtvoter" runat="server" autocomplete="off" Text="0" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="black-text">Contact Number</td>
                                                <td align="center" class="black-text">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtcontact" runat="server" CssClass="textfield form-control" MaxLength="11" autocomplete="off"></asp:TextBox>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtcontact" CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Invalid number" SetFocusOnError="True" ValidationExpression="^[0-9]{10,11}$" ValidationGroup="ADDMember">Please Enter Valid Contact No. upto 10 or 11 digit</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Pan card *</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtpencard" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtpencard"
                                                        Display="Dynamic" ErrorMessage="Please enter pen card" SetFocusOnError="True"
                                                        ValidationGroup="ADDMember" CssClass="red-text-asterix "></asp:RequiredFieldValidator>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="right" class="black-text">Voter Id</td>
                                                <td align="center" class="black-text">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtvalidcardnumber" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Adhaar Card</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtAdhaarCard" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="12"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ForeColor="Red" Display="Dynamic" ControlToValidate="TxtAdhaarCard" ID="RegularExpressionValidator24" ValidationExpression="^[\s\S]{12,12}$" runat="server" ValidationGroup="ADDMember" ErrorMessage="Adhaar Card must be 12 character length."></asp:RegularExpressionValidator>
                                                    <br />

                                                </td>

                                            </tr>



                                            <tr style="display: none;">
                                                <td class="black-text" align="right">Others</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtothers" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                                    <br />

                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right" width="200px">Any other Card Details:</td>
                                                <td class="black-text" width="10px" align="center">:</td>
                                                <td width="200px" align="left">
                                                    <asp:FileUpload ID="fileUploadCardDetails" runat="server" />

                                                    <em class="em" style="color: green;">Tip:-jpg,jpeg,png</em>
                                                    <br />
                                                    Any other Card Details Title:<asp:TextBox ID="TxtCardFile" runat="server" CssClass="textfield form-control"></asp:TextBox>

                                                    <span class="validation">
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
            ControlToValidate="fileUpload_Menu" ErrorMessage="Photo Required!" Display="Dynamic" ValidationGroup="ADDMember" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        --%>
                                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="ValidateFileUpload11"
                                                            ControlToValidate="fileUploadCardDetails" OnServerValidate="CustomValidator3_ServerValidate1"
                                                            ValidationGroup="ADDMember" ErrorMessage="Please select jpg,jpeg,png." Display="Dynamic" ForeColor="Red"></asp:CustomValidator></span>
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
                                            <tr style="display: none;">
                                                <td class="black-text" align="right">Transgender</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtTransgender" autocomplete="off" Text="0" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                                    <br />

                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Total number of beneficiaries</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="TxtNoBeneficiary" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                                    <br />

                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Marital Status*:</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DdlMaritalStatus" runat="server" CssClass="textfield-drop form-control">
                                                        <asp:ListItem Value="0" Text="Select Marital Status"></asp:ListItem>
                                                        <asp:ListItem Value="Single" Text="Single"></asp:ListItem>
                                                        <asp:ListItem Value="Married" Text="Married"></asp:ListItem>
                                                        <asp:ListItem Value="Divorce" Text="Divorced"></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvTypeff" runat="server" Display="Dynamic" ControlToValidate="DdlMaritalStatus"
                                                        InitialValue="0" ErrorMessage="Type required." ValidationGroup="ADDMember" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="right" class="black-text">&nbsp;Education</td>
                                                <td align="center" class="black-text">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtedu" runat="server" autocomplete="off" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="black-text">Occupation</td>
                                                <td align="center" class="black-text">:</td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlselectoccupation" autocomplete="off" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectoccupation_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="black-text">Annual Income(Rs.)</td>
                                                <td align="center" class="black-text">:</td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtincome" autocomplete="off" runat="server" CssClass="textfield form-control"></asp:TextBox>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtincome" CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Only Decimal" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?" ValidationGroup="ADDMember">Please Enter Only Decimal value up to 2 digits</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td align="center" colspan="3" width="100%">
                                                    <div id="DvValidAgePanel" visible="false" runat="server">
                                                        <span style="font-size: large; font-weight: bold;"></span>
                                                        <hr />
                                                        <span style="font-size: larger; font-weight: 500; color: black;">Please fill details below</span>
                                                        <hr />
                                                        <table>
                                                            <tr>
                                                                <td>Beneficiary's Name,Address & Mobile no<label class="txtcolor">*</label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtBnameMobile" runat="server" autocomplete="off"></asp:TextBox>
                                                                    <div>
                                                                        <asp:Label ID="LblTxtBnameMobile" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Bank/Postal Account No<label class="txtcolor">*</label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtBankPostAccountNo" runat="server" autocomplete="off"></asp:TextBox>
                                                                    <div>
                                                                        <asp:Label ID="lblTxtBankPostAccountNo" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Bank/Post office Name<label class="txtcolor">*</label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtBankPostOfficeName" runat="server" autocomplete="off"></asp:TextBox>
                                                                    <div>
                                                                        <asp:Label ID="lblTxtBankPostOfficeName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>IFSC/Pin Code<label class="txtcolor">*</label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtIFSC" runat="server" autocomplete="off"></asp:TextBox>
                                                                    <div>
                                                                        <asp:Label ID="lblTxtIFSC" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                                    </div>
                                                                </td>

                                                            </tr>

                                                            <tr>
                                                                <td>Bank Post office Address<label class="txtcolor">*</label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtBankPostOfficeAdress" runat="server" autocomplete="off"></asp:TextBox>
                                                                    <div>
                                                                        <asp:Label ID="lblTxtBankPostOfficeAdress" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Aadhar No<label class="txtcolor">*</label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="TxtAadharNo" runat="server" autocomplete="off"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ForeColor="Red" Display="Dynamic" ControlToValidate="TxtAadharNo" ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{12,12}$" runat="server" ValidationGroup="ADDMember" ErrorMessage="Adhaar Card must be 12 character length."></asp:RegularExpressionValidator>
                                                                    <div>
                                                                        <asp:Label ID="lblTxtAadharNo" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <tr>
                                                        <td></td>
                                                        <td align="center" class="black-text"></td>
                                                        <td colspan="">
                                                            <asp:Button ID="ImgbtnSubmitMember" runat="server" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmitMember_Click" Text="Submit" ValidationGroup="ADDMember" />
                                                            &nbsp;
                        <asp:Button ID="imgbtnreset" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-add" OnClick="imgbtnreset_Click" Text="Reset" />
                                                            &nbsp;
                        <asp:Button ID="imgbtncancel1" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-add" OnClick="imgbtncancel1_Click" Text="Cancel" />
                                                            &nbsp;&nbsp; </td>
                                                    </tr>
                                        </table>

                                    </asp:Panel>



                                    <%--end popu--%>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="6" align="left" valign="top">
                                    <asp:GridView ID="gvFormembers" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        DataKeyNames="FMLY_MEMB_ID" AllowPaging="True" Width="100%" OnPageIndexChanging="gvFormembers_PageIndexChanging" OnRowCommand="gvFormembers_RowCommand" OnRowDataBound="gvFormembers_RowDataBound" OnRowDeleting="gvFormembers_RowDeleting" OnRowEditing="gvFormembers_RowEditing"
                                        RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" />
                                        <RowStyle CssClass="drow" BackColor="" />
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
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Name">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <a href="javascript:void();" onclick="MM_openBrWindow('View_FamilyMember_Details.aspx?<%= WebConstant.QueryStringEnum.FamilyMemberID  %>=<%# DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID") %>','main','scrollbars=yes,width=600,height=450')" style="color: #3F5E1B;">
                                                            <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_NM")%>
                                                        </a>



                                                    </strong>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Relation With Family Head">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        <asp:Label ID="lblrelation" runat="server" Text='<%#Eval("FMLY_MEMB_REL") %>'></asp:Label>
                                                    </strong>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>

                                                    <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID") %>' CommandName="Edit"
                                                        Visible="true" ImageUrl="~/AUTH/adminpanel/images/arrow.png" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete?');"
                                                        CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID") %>'
                                                        runat="server" Visible="true" ImageUrl="~/AUTH/adminpanel/images/wrong.png" />
                                                    <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
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


                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td width="100%" align="center" colspan="3" style="height: 24px">&nbsp;&nbsp;
    
     <asp:Button ID="ImgbtnSubmit" runat="server" Text="Save" CssClass="btn btn-primary btn-add" ValidationGroup="Login" OnClick="ImgbtnSubmit_Click" />
                        <asp:Button ID="ImgbtnCancel" runat="server" Text="Reset" Visible="false" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImgbtnCancel_Click" />
                        <asp:Button ID="ImgbtnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImgbtnBack_Click" />&nbsp;&nbsp;&nbsp;
 
    
   
                    </td>
                </tr>

            </table>


        </div>
        <!-- end of inner-content-right btnAddmember -->
        <div style="clear: both"></div>
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
            TargetControlID="HiddenField2"
            PopupControlID="Panel1"
            BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <%--start modal popup--%>
        <div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">


            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">OPTION I & OPTION II DETAILS</h4>
                    </div>
                    <div class="modal-body ty23">
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                    </div>
                </div>
            </div>



        </div>
        <%--end modal popup--%>
    </div>
</asp:Content>

