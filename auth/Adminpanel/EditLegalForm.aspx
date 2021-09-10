<%@ Page Title="NTCA:Legal form" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="EditLegalForm.aspx.cs" Inherits="auth_Adminpanel_EditLegalForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style type="text/css">
        /*.textfield {
    background-color: #FFFFFF;
    border: 1px solid #B4BA7E;
    color: #4C4C4C;
    font-size: 12px;
    height: 15px;
    width: 160px;
}
.textfield-drop {
    background-color: #FFFFFF;
    border: 1px solid #B4BA7E;
    color: #4C4C4C;
    font-size: 12px;
    height: 20px;
    width: 160px;
}*/
        .textfield, .textfield-drop {
            width: 50%;
        }

        .red-text-1a {
            color: red;
        }

        .table-2 td {
            text-align: left;
            padding-bottom: 7px;
        }
    </style>
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content">
            <div class="inner-content-right">
                <div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;"></h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                </div>
                <div class="col-md-2">
                    <span style="font-size: 15px;">Select village name:</span>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="Legal_table">
                    <tr>
                        <td colspan="5" style="font-weight: bold; padding: 8px 0px;">Please fill the following mandatory form to proceed further.
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="font-size: small; color: #3F5E1B; padding-bottom: 8px;"><strong>Compliance of the Wildlife (Protection) Act, 1972 and the Scheduled Tribes & Other Traditional Forest Dwellers (Recognition of Forest Rights) Act, 2006.</strong></td>
                    </tr>


                    <tr>
                        <td colspan="5">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table-2">

                                <tr>


                                    <td colspan="4">
                                        <asp:Label ID="lblMsg" Font-Size="X-Large" runat="server" CssClass="red-text-1a"></asp:Label></td>
                                </tr>
                                <tr>

                                    <td width="2%" class="black-text" style="color: #005529;"><strong>1.</strong></td>
                                    <td width="2%" class="black-text"></td>
                                    <td colspan="6" style="border-bottom: 1px solid #dfdbdb; padding-bottom: 0px;">
                                        <h4 style="color: #005529;">Core or Critical Tiger Habitat (CTH)</h4>
                                    </td>


                                </tr>
                                <tr>
                                    <td colspan="5"></td>
                                </tr>
                                <tr>
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">a.</td>
                                    <td class="black-text" align="right">Notified<span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:DropDownList ID="DontDrpList1" runat="server" CssClass="textfield-drop form-control" AutoPostBack="true" OnSelectedIndexChanged="DontDrpList1_SelectedIndexChanged">
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>


                                    </td>
                                </tr>

                                <tr id="checkdate1" runat="server">
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">b.</td>
                                    <td class="black-text" align="right">Date of Notification<span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:TextBox ID="txtdate1" runat="server" CssClass="textfield form-control"></asp:TextBox>
                                        <asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image3" runat="server" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtdate1"
                                            Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                            ValidationGroup="ADD" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtdate1"
                                            PopupButtonID="Image3" runat="server">
                                        </cc1:CalendarExtender>
                                        &nbsp;
        
                                    </td>
                                </tr>

                                <tr>
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">c.</td>
                                    <td class="black-text" align="right">Area(Ha.)<span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:TextBox ID="textbox1" runat="server" CssClass="textfield form-control" MaxLength="15"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix" ControlToValidate="textbox1"
                                            Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                            ValidationGroup="ADD">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>


                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="red-text-asterix" ValidationGroup="ADD" Display="Dynamic" ControlToValidate="textbox1" ErrorMessage="Please Enter Area"></asp:RequiredFieldValidator>



                                    </td>
                                </tr>
                                <tr>
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">d.</td>
                                    <td class="black-text" align="right">Compliance of section 38V of the Wildlife	(Protection) Act, 1972
            <span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="textbox2" runat="server" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="red-text-asterix" ValidationGroup="ADD" Display="Dynamic" ControlToValidate="textbox2" ErrorMessage="Please Enter WLPA Information"></asp:RequiredFieldValidator>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5"></td>
                                </tr>




                                <tr>

                                    <td width="2%" class="black-text" style="color: #005529;"><strong>2.</strong></td>
                                    <td width="2%" class="black-text"></td>
                                    <td colspan="6" style="border-bottom: 1px solid #dfdbdb; padding-bottom: 0px;">
                                        <h4 style="color: #005529;">Buffer or Peripheral Area</h4>
                                    </td>


                                </tr>
                                <tr>
                                    <td colspan="5"></td>
                                </tr>
                                <tr>
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">a.</td>
                                    <td class="black-text" align="right">Notified <span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:DropDownList ID="DontDrpList2" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="DontDrpList2_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>

                                        </asp:DropDownList>


                                    </td>
                                </tr>

                                <tr id="checkdate2" runat="server">
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">b.</td>
                                    <td class="black-text" align="right">Date of notification<span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:TextBox ID="txtdate2" runat="server" CssClass="textfield form-control"></asp:TextBox>
                                        <asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image1" runat="server" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtdate2"
                                            Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                            ValidationGroup="ADD" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtdate2"
                                            PopupButtonID="Image1" runat="server">
                                        </cc1:CalendarExtender>
                                        &nbsp;
        
                                    </td>
                                </tr>

                                <tr>
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">c.</td>
                                    <td class="black-text" align="right">Area(Ha.)<span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:TextBox ID="textbox3" runat="server" CssClass="textfield form-control" MaxLength="15"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="textbox3"
                                            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit"
                                            SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?" ValidationGroup="ADD">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator><%--  <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" Cssclass="red-text-asterix" ValidationGroup="Login" Display="Dynamic" ControlToValidate="txtCaptcha" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>--%>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="red-text-asterix" ValidationGroup="ADD" Display="Dynamic" ControlToValidate="textbox3" ErrorMessage="Please Enter Area"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">d.</td>
                                    <td class="black-text" align="right">Expert Committee
                                    </td>
                                    <td class="black-text">:</td>
                                    <td class="black-text">&nbsp; </td>
                                </tr>
                                <tr>
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">&nbsp  i.</td>
                                    <td class="black-text" align="right">Constituted<span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:DropDownList ID="DontDrpList3" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="DontDrpList3_SelectedIndexChanged">
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>


                                    </td>
                                </tr>

                                <tr id="checkdate3" runat="server">
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">e.</td>
                                    <td class="black-text" align="right">Date of Constitution <span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:TextBox ID="txtdate3" runat="server" CssClass="textfield form-control"></asp:TextBox>
                                        <asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image6" runat="server" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtdate3"
                                            Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                            ValidationGroup="ADD" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                                        <cc1:CalendarExtender ID="CalendarExtender6" Format="dd/MM/yyyy" TargetControlID="txtdate3"
                                            PopupButtonID="Image6" runat="server">
                                        </cc1:CalendarExtender>
                                        &nbsp;
        
                                    </td>
                                </tr>
                                <tr>
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">f.</td>
                                    <td class="black-text" align="right">Consultation With Gram Sabha
            <span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:DropDownList ID="DontDrpList4" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="DontDrpList4_SelectedIndexChanged">
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False">No</asp:ListItem>
                                        </asp:DropDownList>&nbsp;<%--<asp:TextBox ID="GrammColTxtBx" runat="server" CssClass ="textfield"></asp:TextBox>--%>
        
                                    </td>
                                </tr>
                                <tr id="checkdate4" runat="server">
                                    <td width="2%" class="black-text"></td>
                                    <td width="2%" class="black-text">g.</td>
                                    <td class="black-text" align="right">Name of Gram Sabha
            <span class="red-text-1a">*</span></td>
                                    <td class="black-text">:</td>
                                    <td>
                                        <asp:TextBox ID="textbox5" runat="server" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="red-text-asterix" ValidationGroup="ADD" Display="Dynamic" ControlToValidate="textbox5" ErrorMessage="Please Enter Gram Shabha"></asp:RequiredFieldValidator>

                                    </td>
                                </tr>



                                <tr>
                                    <td colspan="5">
                                        <br />
                                    </td>
                                </tr>
                                <tr>

                                    <td width="2%" class="black-text" style="color: #005529;"><strong>3.</strong></td>
                                    <td width="2%" class="black-text"></td>
                                    <td width="48%" class="black-text" colspan="2"><strong>Map of CTH & Buffer or Peripheral Area.(jpg or .pdf files only)</strong></td>
                                    <td width="48%">
                                        <asp:FileUpload ID="FUForImage" runat="server" BorderColor="#B4BA7E" />
                                        <br />
                                        <asp:HyperLink ID="map1" Visible="false" Target="_blank" runat="server">MAP FIRST (Max Size of file should be 2 MB)</asp:HyperLink>
                                        <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" Cssclass="red-text-asterix" ValidationGroup="Login" Display="Dynamic" ControlToValidate="txtCaptcha" ErrorMessage="Enter Password"></asp:RequiredFieldValidator></td>--%>
                                        <%--<asp:Label ID="Literal1" runat="server" Text="Label"></asp:Label>--%></td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="center"></td>
                                    <td colspan="5">
                                        <br />
                                    </td>
                                </tr>
                                <tr>

                                    <td width="2%" class="black-text" style="color: #005529;"><strong>4.</strong></td>
                                    <td width="2%" class="black-text"></td>
                                    <td width="48%" class="black-text" colspan="2"><strong>Upload file:</strong></td>
                                    <td width="48%">

                                        <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="#B4BA7E" /><asp:Label ID="lbl1" Visible="false" runat="server"></asp:Label>
                                        <br />
                                        <asp:HyperLink ID="map2" Visible="false" Target="_blank" runat="server">Doc 1</asp:HyperLink>
                                        <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" Cssclass="red-text-asterix" ValidationGroup="Login" Display="Dynamic" ControlToValidate="txtCaptcha" ErrorMessage="Enter Password"></asp:RequiredFieldValidator></td>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <br />
                                    </td>
                                </tr>
                                <tr>

                                    <td width="2%" class="black-text" style="color: #005529;"><strong>5.</strong></td>
                                    <td width="2%" class="black-text"></td>
                                    <td width="48%" class="black-text" colspan="2"><strong>Upload file:</strong></td>
                                    <td width="48%">

                                        <asp:FileUpload ID="FileUpload2" runat="server" BorderColor="#B4BA7E" /><asp:Label ID="lbl2" Visible="false" runat="server"></asp:Label>

                                        <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" Cssclass="red-text-asterix" ValidationGroup="Login" Display="Dynamic" ControlToValidate="txtCaptcha" ErrorMessage="Enter Password"></asp:RequiredFieldValidator></td>--%>
                                        <br />
                                        <asp:HyperLink ID="map3" Visible="false" Target="_blank" runat="server">Doc 2</asp:HyperLink>
                                    </td>
                                </tr>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <br />
                        </td>
                        <tr>

                            <td width="2%" class="black-text" style="color: #005529;">
                                <strong>6.</strong></td>
                            <td width="2%" class="black-text"></td>
                            <td colspan="6" style="border-bottom: 1px solid #dfdbdb; padding-bottom: 0px;">
                                <h4 style="color: #005529;">Recognition / Determination/ Acquisition / Vesting of Forest Rights of Schedule Tribes & such other Traditional Forest Dwellers</h4>
                            </td>


                        </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text">a.</td>
                        <td class="black-text" align="right">Completed <span class="red-text-1a">*</span></td>
                        <td class="black-text">:</td>
                        <td>
                            <asp:DropDownList ID="DontDrpList5" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="DontDrpList5_SelectedIndexChanged">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Value="False">No</asp:ListItem>
                            </asp:DropDownList>

                            <asp:FileUpload ID="FileUploadCompleted" runat="server" ToolTip="(Upload only pdf!.)" />

                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" Cssclass="red-text-asterix" runat="server" ErrorMessage="Enter User ID" ValidationGroup="Login"  ControlToValidate="txtID" Display="Dynamic"></asp:RequiredFieldValidator>--%></td>
                    </tr>




                    <tr>
                        <td colspan="5">
                            <br />
                        </td>
                    </tr>


                    <tr>

                        <td width="2%" class="black-text" style="color: #005529;"><strong>7.</strong></td>
                        <td width="2%" class="black-text"></td>
                        <td colspan="6" style="border-bottom: 1px solid #dfdbdb; padding-bottom: 0px;">
                            <h4 style="color: #005529;">Re-settlement or Alternative Package</h4>
                        </td>


                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text">a.</td>
                        <td class="black-text" align="right">Provided <span class="red-text-1a">*</span></td>
                        <td class="black-text">:</td>

                        <td>
                            <asp:DropDownList ID="DontDrpList6" runat="server" CssClass="textfield-drop form-control">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Value="False">No</asp:ListItem>
                            </asp:DropDownList>

                            <%--   <asp:TextBox ID="RemarkTxtBx2" runat="server" CssClass ="textfield form-control" TextMode="MultiLine" Height="40px" Width="250px" MaxLength="300"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="RemarkTxtBx2"
                CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Remark" ValidationGroup="ADD"></asp:RequiredFieldValidator> <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Cssclass="red-text-asterix" runat="server" ErrorMessage="Enter User ID" ValidationGroup="Login"  ControlToValidate="txtID" Display="Dynamic"></asp:RequiredFieldValidator>--%></td>
                    </tr>








                    <tr>

                        <td width="2%" class="black-text" style="color: #005529;"><strong>8.</strong></td>
                        <td width="2%" class="black-text"></td>
                        <td colspan="6" style="border-bottom: 1px solid #dfdbdb; padding-bottom: 0px;">
                            <h4 style="color: #005529;">Free informed consent of Gram Sabha to the Resettlement Programme</h4>
                        </td>


                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text">a.</td>
                        <td class="black-text" align="right">Obtained  <span class="red-text-1a">*</span></td>
                        <td class="black-text">:</td>

                        <td>
                            <asp:DropDownList ID="DontDrpList7" runat="server" CssClass="textfield-drop form-control">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Value="False">No</asp:ListItem>
                            </asp:DropDownList>
                            <%--   <asp:TextBox ID="RemarkTxtBx2" runat="server" CssClass ="textfield" TextMode="MultiLine" Height="40px" Width="250px" MaxLength="300"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="RemarkTxtBx2"
                CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Remark" ValidationGroup="ADD"></asp:RequiredFieldValidator> <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Cssclass="red-text-asterix" runat="server" ErrorMessage="Enter User ID" ValidationGroup="Login"  ControlToValidate="txtID" Display="Dynamic"></asp:RequiredFieldValidator>--%></td>
                    </tr>




                    <tr>

                        <td width="2%" class="black-text" style="color: #005529;"><strong>9.</strong></td>
                        <td width="2%" class="black-text"></td>
                        <td colspan="6" style="border-bottom: 1px solid #dfdbdb; padding-bottom: 0px;">
                            <h4 style="color: #005529;">Voluntary consent of individuals affected</h4>
                        </td>


                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text">a.</td>
                        <td class="black-text" align="right">Obtained  <span class="red-text-1a">*</span></td>
                        <td class="black-text">:</td>

                        <td>
                            <asp:DropDownList ID="DontDrpList8" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="DontDrpList8_SelectedIndexChanged">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Value="False">No</asp:ListItem>
                            </asp:DropDownList>
                            <asp:FileUpload ID="FileupObtained" runat="server" ToolTip="(Upload only pdf!.)" />
                            <%--   <asp:TextBox ID="RemarkTxtBx2" runat="server" CssClass ="textfield form-control" TextMode="MultiLine" Height="40px" Width="250px" MaxLength="300"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="RemarkTxtBx2"
                CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Remark" ValidationGroup="ADD"></asp:RequiredFieldValidator> <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Cssclass="red-text-asterix" runat="server" ErrorMessage="Enter User ID" ValidationGroup="Login"  ControlToValidate="txtID" Display="Dynamic"></asp:RequiredFieldValidator>--%></td>
                    </tr>





                    <tr>
                        <td colspan="5">
                            <br />
                        </td>
                    </tr>



                    <tr>

                        <td width="2%" class="black-text" style="color: #005529;"><strong>10.</strong></td>
                        <td width="2%" class="black-text"></td>
                        <td colspan="6" style="border-bottom: 1px solid #dfdbdb; padding-bottom: 0px;">
                            <h4 style="color: #005529;">Facilities & Land Allocation At The Resettlement Location</h4>
                        </td>


                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text"></td>
                        <td class="black-text" align="right">Provided<span class="red-text-1a">*</span></td>
                        <td class="black-text">:</td>
                        <td>
                            <asp:DropDownList ID="DontDrpList9" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="DontDrpList9_SelectedIndexChanged">
                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                <asp:ListItem Value="False">No</asp:ListItem>
                            </asp:DropDownList>

                            <asp:FileUpload ID="FileUpProvided" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="5">
                            <br />
                        </td>
                    </tr>

                    <tr>

                        <td width="2%" class="black-text" style="color: #005529;"><strong>11.</strong></td>
                        <td width="2%" class="black-text"></td>
                        <td colspan="6" style="border-bottom: 1px solid #dfdbdb; padding-bottom: 0px;">
                            <h4 style="color: #005529;">Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal</h4>
                        </td>


                    </tr>
                    <tr>
                        <td colspan="5"></td>
                    </tr>
                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text">a.</td>
                        <td class="black-text" style="color: #f8b600" colspan="3">Sub Divisional Level Committee</td>



                    </tr>

                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text"></td>
                        <td class="black-text" align="right">Constituted<span class="red-text-1a">*</span></td>
                        <td class="black-text">:</td>
                        <td>
                            <asp:DropDownList ID="DontDrpList10" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="DontDrpList10_SelectedIndexChanged">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                                <asp:ListItem Value="2">In-Progress</asp:ListItem>
                            </asp:DropDownList>
                            <asp:FileUpload ID="FileUpConstitutedA" runat="server" ToolTip="(Upload only pdf!.)" />
                        </td>
                    </tr>



                    <tr id="checkdate5" runat="server">
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text"></td>
                        <td class="black-text" align="right">Date of constitution  <span class="red-text-1a"></span></td>
                        <td class="black-text">:</td>
                        <td>
                            <asp:TextBox ID="txtdate4" runat="server" CssClass="textfield form-control"></asp:TextBox>
                            <asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image2" runat="server" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtdate4"
                                CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate"
                                SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                ValidationGroup="ADD"></asp:RegularExpressionValidator>
                            <br />
                            <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator19" runat="server" Cssclass="red-text-asterix" ValidationGroup="Login" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>--%>
                            <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" TargetControlID="txtdate4"
                                PopupButtonID="Image2" runat="server">
                            </cc1:CalendarExtender>

                        </td>
                    </tr>



                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text">b.</td>
                        <td class="black-text" style="color: #f8b600" colspan="3">District Level Committee</td>



                    </tr>

                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text"></td>
                        <td class="black-text" align="right">Constituted<span class="red-text-1a">*</span></td>
                        <td class="black-text">:</td>
                        <td>
                            <asp:DropDownList ID="DontDrpList11" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="DontDrpList11_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                                <asp:ListItem Value="2">In-Progress</asp:ListItem>
                            </asp:DropDownList>
                            <asp:FileUpload ID="FileUpConstitutedB" runat="server" ToolTip="(Upload only pdf!.)" />
                        </td>
                    </tr>
                    <tr id="checkdate6" runat="server">
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text"></td>
                        <td class="black-text" align="right">Date of constitution  <span class="red-text-1a"></span></td>
                        <td class="black-text">:</td>
                        <td>
                            <asp:TextBox ID="txtdate5" runat="server" CssClass="textfield form-control"></asp:TextBox>
                            <asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image4" runat="server" />
                            &nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtdate5"
                CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate"
                SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                ValidationGroup="ADD"></asp:RegularExpressionValidator>
                            <cc1:CalendarExtender ID="CalendarExtender5" Format="dd/MM/yyyy" TargetControlID="txtdate5"
                                PopupButtonID="Image4" runat="server">
                            </cc1:CalendarExtender>
                            <%--<asp:RequiredFieldValidator id="RequiredFieldValidator21" runat="server" Cssclass="red-text-asterix" ValidationGroup="Login" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>--%></td>
                    </tr>

                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text">c.</td>
                        <td class="black-text" style="color: #f8b600" colspan="3">State Level Monitoring Committee.</td>



                    </tr>


                    <tr>
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text"></td>
                        <td class="black-text" align="right">Constituted<span class="red-text-1a">*</span></td>
                        <td class="black-text">:</td>
                        <td>
                            <asp:DropDownList ID="DontDrpList12" runat="server" CssClass="textfield-drop form-control" AutoPostBack="True" OnSelectedIndexChanged="DontDrpList12_SelectedIndexChanged">
                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                <asp:ListItem Value="0">No</asp:ListItem>
                                <asp:ListItem Value="2">In-Progress</asp:ListItem>
                            </asp:DropDownList>
                            <asp:FileUpload ID="FileUPConstitutedC" runat="server" ToolTip="(Upload only pdf!.)" />
                        </td>
                    </tr>
                    <tr id="checkdate7" runat="server">
                        <td width="2%" class="black-text"></td>
                        <td width="2%" class="black-text"></td>
                        <td class="black-text" align="right">Date of constitution  <span class="red-text-asterix-asterix"></span></td>
                        <td class="black-text">:</td>
                        <td>
                            <asp:TextBox ID="txtdate6" runat="server" CssClass="textfield form-control"></asp:TextBox>
                            <asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image5" runat="server" />&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtdate6"
                CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate"
                SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                ValidationGroup="ADD"></asp:RegularExpressionValidator>
                            <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" TargetControlID="txtdate6"
                                PopupButtonID="Image5" runat="server">
                            </cc1:CalendarExtender>
                            <%-- <asp:RequiredFieldValidator id="RequiredFieldValidator23" runat="server" Cssclass="red-text-asterix" ValidationGroup="Login" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                            --%></td>
                    </tr>



                    <tr>
                        <td width="100%" colspan="5" style="text-align: center; padding-top: 10px;">&nbsp;&nbsp;




      <asp:Button ID="ImgbtnSubmit" runat="server" Text="Save" ValidationGroup="ADD" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmit_Click" />
                            <asp:Button ID="imgbtnreset" runat="server" Text="Reset" CausesValidation="false" CssClass="btn btn-primary btn-add" OnClick="imgbtnreset_Click" />&nbsp;
          <br />
                            <br />
                        </td>
                    </tr>


                </table>
                </td>
</tr>
</table>





 
 
 

            </div>
            <!-- end of inner-content-right -->
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>

