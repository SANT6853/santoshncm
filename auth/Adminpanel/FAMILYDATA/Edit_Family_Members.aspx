<%@ Page Title="NTCA:Edit Family memeber" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="Edit_Family_Members.aspx.cs" Inherits="auth_Adminpanel_FAMILYDATA_Edit_Family_Members" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .table-2 td {
            padding: 10px;
            text-align: left;
            width: 6% !important;
            vertical-align: top;
        }

        .textfield {
            width: 100%;
        }

        .red-text-asterix {
            color: red;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">

    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content">
            <script type="text/javascript">
                $(document).ready(function () {
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

                    //-----------------
                    $('#<%= TxtDOB.ClientID %>').prop("readonly", "readonly");
                });
                var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
                var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
                var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
                var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
                var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });
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
                function IsAlphaNumeric(event) {
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




            <div class="inner-content-right">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-2">
                    <tr>
                        <td colspan="3" style="border-bottom: 3px solid #005529;">
                            <h3 style="color: #005529;">
                                <%--Edit Member's Detail--%>
                                <asp:Label ID="LblHeadingPopUp" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                            </h3>
                        </td>

                    </tr>

                    <tr>
                        <td colspan="3" style="height: 306px">


                            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
                                <!-- <tr>
                            <td colspan="3" class="black-text" align="center"></td>
                        </tr>-->
                                <tr>
                                    <td colspan="3" class="black-text" align="center">

                                        <h4><a href="#" style="color: blue;" id="ToolTipHref">Notice:Family Definition</a></h4>
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

                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>

                                    </td>
                                </tr>
                                <tr>

                                    <td width="45%" class="black-text" align="right">Name<span class="red-text-asterix">*</span></td>
                                    <td class="black-text" width="2%" align="center">:</td>
                                    <td width="53%" align="left">
                                        <asp:TextBox ID="txtname" runat="server" CssClass="textfield form-control" MaxLength="200" autocomplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtname"
                                            Display="Dynamic" ErrorMessage="Please Enter Member Name" SetFocusOnError="True"
                                            ValidationGroup="ADDMember" CssClass="red-text" ForeColor="Red"></asp:RequiredFieldValidator>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" CssClass="red-text-asterix" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtname" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>

                                    </td>
                                    <td width="45%"></td>
                                    <td width="45%"></td>

                                </tr>
                                <tr id="trPhoto" runat="server" visible="false">
                                    <td class="black-text" align="right" width="200px">Add your photo:<span class="red-text-asterix red-text-1a">*</span></td>
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
                                            <asp:HyperLink ID="hypfile" Target="_blank" runat="server" ForeColor="#000099" Font-Bold="True" Font-Italic="True">


                                            </asp:HyperLink>
                                            <asp:Image ID="IMphoto" runat="server" Height="100px" Width="100px" />
                                            <asp:Button ID="BtnDeleteAttachment" runat="server" Text="Delete Attachment" OnClientClick="return confirm('Are you sure delete permanently?');" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="BtnDeleteAttachment_Click" />
                                        </div>
                                    </td>

                                </tr>

                                <tr>
                                    <td class="black-text" align="right">Relation With Family Head<span class="red-text-asterix">*</span></td>
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
                                        <asp:TextBox ID="txtfathername" runat="server" CssClass="textfield form-control" MaxLength="150" autocomplete="off"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtfathername" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <% }%>
                                <tr>
                                    <td class="black-text" align="right">Date of Birth(DOB):</td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">

                                        <asp:TextBox ID="TxtDOB" runat="server" AutoPostBack="True" OnTextChanged="TxtDOB_TextChanged" autocomplete="off"></asp:TextBox>
                                        <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image4" runat="server" /><br />
                                        <asp:RegularExpressionValidator ID="RelTxtDOB" runat="server" ControlToValidate="TxtDOB"
                                            Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                            ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RegularExpressionValidator>
                                        <cc1:CalendarExtender ID="CadarTxtDOB" Format="dd/MM/yyyy" TargetControlID="TxtDOB"
                                            PopupButtonID="Image4" runat="server">
                                        </cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="ReqdTxtCuttOffDate" runat="server" ControlToValidate="TxtDOB"
                                            Display="Dynamic" ErrorMessage="Please Enter DOB" SetFocusOnError="True"
                                            ValidationGroup="ADDMember" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:RequiredFieldValidator>

                                        <%-- <asp:CustomValidator runat="server" ID="custeTxtDOB" ControlToValidate="TxtDOB"
                                    ClientValidationFunction="CompareDates" ErrorMessage="Date Should Be Less Than Or Equal to Today's Date "
                                    ValidationGroup="ADDMember" Display="Dynamic" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:CustomValidator>
                                <asp:Label ID="LblMsgDbo" runat="server" ForeColor="Red"></asp:Label>--%>
                                        <br />
                                        <asp:Label ID="LblCuttoffDateShow" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                        <br />
                                        <asp:Label ID="LblMsgDbo" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Age(Years)<span class="red-text-asterix">*</span></td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtage" runat="server" CssClass="textfield form-control" MaxLength="3" autocomplete="off" OnTextChanged="txtage_TextChanged"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" CssClass="red-text" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtage" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                    </td>

                                </tr>


                                <tr>
                                    <td class="black-text" align="right">Sex<span class="red-text-asterix">*</span></td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlselectsex" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectsex_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Text="Select Sex"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Transgender"></asp:ListItem>
                                        </asp:DropDownList></td>

                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Cast<span class="red-text-asterix">*</span></td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlselectcast" runat="server" CssClass="textfield-drop form-control">
                                            <asp:ListItem Value="0" Text="Select Cast"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="OBC"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="SC"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="ST"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="OTHER"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                </tr>



                                <tr>
                                    <td class="black-text" align="right">Valid Id Number<br />
                                    </td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtvoter" runat="server" CssClass="textfield form-control" MaxLength="100" autocomplete="off"></asp:TextBox>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtvoter" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Contact Number</td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtcontact" runat="server" CssClass="textfield form-control" MaxLength="11" autocomplete="off"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ForeColor="Red" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtcontact" ErrorMessage="Please Enter Contact No. upto 10 or 11 digit" ValidationExpression="^[0-9]{10,11}$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                    </td>

                                </tr>

                                <tr>
                                                            <td class="black-text" align="right">Valid Id proof</td>
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
                                                                    ValidationGroup="ADDMember" InitialValue="0" CssClass="red-text-asterix "></asp:RequiredFieldValidator>
                                                          
                                                                
                                                                
                                                            </td>

                                                        </tr>


                                <tr >
                                    <td class="black-text" align="right"><span class="red-text-asterix"></span></td>
                                    <td class="black-text" align="center"></td>
                                    <td align="left">
                                        <asp:TextBox ID="txtpencard" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtpencard"
                                            Display="Dynamic" ErrorMessage="Please enter pen card" SetFocusOnError="True"
                                            ValidationGroup="ADDMember" CssClass="red-text-asterix "></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtpencard" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                                    </td>

                                </tr>
                                <tr style="display:none;">
                                    <td class="black-text" align="right">Voter ID<br />
                                    </td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtvalidcardnumber" runat="server" CssClass="textfield form-control" MaxLength="100" autocomplete="off"></asp:TextBox>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtvalidcardnumber" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>

                                </tr>
                                <tr style="display:none;">
                                    <td class="black-text" align="right">Adhaar Card</td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="TxtAdhaarCard" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                        <asp:RegularExpressionValidator ForeColor="Red" Display="Dynamic" ControlToValidate="TxtAdhaarCard"
                                            ID="RegularExpressionValidator17" ValidationExpression="^[\s\S]{12,12}$" runat="server" ValidationGroup="ADDMember"
                                            ErrorMessage="Adhaar Card must be 12 character length."></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="TxtAdhaarCard" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>

                                </tr>


                                <tr style="display: none;">
                                    <td class="black-text" align="right">Others</td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtothers" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtothers" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="black-text" align="right" width="200px"></td>
                                    <td class="black-text" width="10px" align="center"></td>
                                    <td width="200px" align="left">
                                        <asp:FileUpload ID="fileUploadCardDetails" runat="server" />

                                        <em class="em" style="color: green;">Tip:-jpg,jpeg,png</em>
                                        <br />
                                    <%-- Any other Card Details Title:--%>
                                        <br>
                                        <asp:TextBox Visible="false" CssClass="form-control" ID="TxtCardFile" runat="server"></asp:TextBox>
                                        <br />

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
                                        <asp:TextBox ID="TxtTransgender" Text="0" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtTransgender"
                                            Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                            ValidationGroup="ADDMember" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Total number of beneficiaries</td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="TxtNoBeneficiary" autocomplete="off" runat="server" CssClass="textfield form-control" MaxLength="30"></asp:TextBox>
                                        <br />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtNoBeneficiary"
                                            Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="[0-9]+$"
                                            ValidationGroup="ADDMember" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Marital Status<span class="red-text-asterix">*</span></td>
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
                                    <td class="black-text" align="right">Education</td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtedu" runat="server" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtedu" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>

                                </tr>


                                <tr>
                                    <td class="black-text" align="right">Occupation<span class="red-text-asterix">*</span></td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlselectoccupation" runat="server" CssClass="textfield-drop form-control">
                                           
                                        </asp:DropDownList>
                                    </td>

                                </tr>


                                <tr>
                                    <td class="black-text" align="right">Annual Income(Rs.)</td>
                                    <td class="black-text" align="center">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtincome" runat="server" CssClass="textfield form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" CssClass="red-text" ControlToValidate="txtincome"
                                            Display="Dynamic" ErrorMessage="Only Decimal" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?"
                                            ValidationGroup="ADDMember" ForeColor="Red">Please Enter Only Decimal Values up to 2 digit</asp:RegularExpressionValidator>
                                    </td>

                                </tr>


                                <tr>
                                    <td align="center" colspan="3" width="100%" style="text-align: center;">&nbsp;&nbsp;
   
   
                                    </td>
                                </tr>
                            </table>
                            <div style="">
                                <div id="DvValidAgePanel" visible="false" runat="server" style="text-align: center; margin-right: 100px;">
                                    <span style="font-size: large; font-weight: bold;"></span>
                                    <hr />
                                    <span style="font-size: larger; font-weight: 500; color: black;">Please fill details below</span>
                                    <hr />
                                    <table style="text-align: center;" width="93%" class="table-2">
                                        <tr>
                                            <td>Beneficiary Name<label class=" red-text-asterix txtcolor">*</label></td>
                                            <td class="black-text" align="center">:</td>
                                            <td>
                                                <asp:TextBox ID="TxtBnameMobile" runat="server" autocomplete="off" CssClass="form-control" MaxLength="250"></asp:TextBox>
                                                <div>
                                                    <asp:Label ID="LblTxtBnameMobile" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                </div>
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ForeColor="Red" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="TxtBnameMobile" ErrorMessage="Please Enter Contact No. upto 10 or 11 digit" ValidationExpression="^[0-9]{10,11}$" SetFocusOnError="True"></asp:RegularExpressionValidator>--%>
                                            </td>
                                            <td width="45%"></td>
                                            <td width="45%"></td>
                                        </tr>
                                        <tr>
                                            <td>Beneficiary Address
                                                <label class=" red-text-asterix txtcolor">*</label></td>
                                            <td class="black-text" align="center">:</td>
                                            <td>
                                                <asp:TextBox ID="txtBeniAddress" runat="server" autocomplete="off" CssClass="form-control" MaxLength="250"></asp:TextBox>
                                                <div>
                                                    <asp:Label ID="lblBeniAddress" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                </div>
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ForeColor="Red" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="TxtBnameMobile" ErrorMessage="Please Enter Contact No. upto 10 or 11 digit" ValidationExpression="^[0-9]{10,11}$" SetFocusOnError="True"></asp:RegularExpressionValidator>--%>
                                            </td>
                                            <td width="45%"></td>
                                            <td width="45%"></td>
                                        </tr>
                                        <tr>
                                            <td>Beneficiary Mobile no<label class=" red-text-asterix txtcolor">*</label></td>
                                            <td class="black-text" align="center">:</td>
                                            <td>
                                                <asp:TextBox ID="txtBeniMobile" runat="server" autocomplete="off" CssClass="form-control" MaxLength="10" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>
                                                <div>
                                                    <asp:Label ID="lblBeniMobile" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                </div>
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ForeColor="Red" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="TxtBnameMobile" ErrorMessage="Please Enter Contact No. upto 10 or 11 digit" ValidationExpression="^[0-9]{10,11}$" SetFocusOnError="True"></asp:RegularExpressionValidator>--%>
                                            </td>
                                            <td width="45%"></td>
                                            <td width="45%"></td>
                                        </tr>
                                        <tr>
                                            <td>Bank/Postal Account No<label class="red-text-asterix txtcolor">*</label></td>
                                            <td class="black-text" align="center">:</td>
                                            <td>
                                                <asp:TextBox ID="TxtBankPostAccountNo" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                                <div>
                                                    <asp:Label ID="lblTxtBankPostAccountNo" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                </div>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="TxtBankPostAccountNo" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Bank/Post office Name<label class="red-text-asterix txtcolor">*</label></td>
                                            <td class="black-text" align="center">:</td>
                                            <td>
                                                <asp:TextBox ID="TxtBankPostOfficeName" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                                <div>
                                                    <asp:Label ID="lblTxtBankPostOfficeName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                </div>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="TxtBankPostOfficeName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>IFSC/Pin Code<label class="red-text-asterix txtcolor">*</label></td>
                                            <td class="black-text" align="center">:</td>
                                            <td>
                                                <asp:TextBox ID="TxtIFSC" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                                <div>
                                                    <asp:Label ID="lblTxtIFSC" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                </div>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="TxtIFSC" Display="Dynamic" SetFocusOnError="true" ValidationGroup="ADDMember"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>Bank Post office Address<label class="red-text-asterix txtcolor">*</label></td>
                                            <td class="black-text" align="center">:</td>
                                            <td>
                                                <asp:TextBox ID="TxtBankPostOfficeAdress" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                                <div>
                                                    <asp:Label ID="lblTxtBankPostOfficeAdress" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Aadhar No<label class="red-text-asterix txtcolor">*</label></td>
                                            <td class="black-text" align="center">:</td>
                                            <td>
                                                <asp:TextBox ID="TxtAadharNo" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ForeColor="Red" Display="Dynamic" ControlToValidate="TxtAadharNo"
                                                    ID="RegularExpressionValidator16" ValidationExpression="^[\s\S]{12,12}$" runat="server" ValidationGroup="ADDMember"
                                                    ErrorMessage="Adhaar Card must be 12 character length."></asp:RegularExpressionValidator>
                                                <div>
                                                    <asp:Label ID="lblTxtAadharNo" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>

                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="text-align: left;">

                                    <asp:Button ID="ImgbtnSubmitMember" runat="server" Text="Save" CssClass="btn btn-primary btn-add" ValidationGroup="ADDMember" OnClick="ImgbtnSubmitMember_Click" />
                                    <asp:Button ID="imgbtnreset" runat="server" Text="Reset" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="imgbtnreset_Click1" />
                                    <asp:Button ID="imgbtnback" runat="server" Text="Back" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="imgbtnback_Click" />&nbsp;&nbsp;&nbsp;
                                </div>


                            </div>
                        </td>
                    </tr>
                </table>


                <!-- end of inner-content-right -->
                <div style="clear: both"></div>

            </div>
        </div>
    </div>
</asp:Content>

