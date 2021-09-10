<%@ Page Title="NTCA:Add cdp" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="CDP_Add.aspx.cs" Inherits="auth_Adminpanel_CDP_CDP_Add" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">

    <style>
        .red-text-1a {
            color: Red;
            font-size: large;
        }
		
.table-2 td{
padding:5px;
text-align:left;

}
.container-fluid{
margin-bottom:50px !important;
}
.table-3 td {
    padding: 5px 0px;
    text-align: left;
	
}
 .GridPager a, .GridPager span
    {
        display: block;
        height: 18px;
        width: 18px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }
    .GridPager a
    {
        background-color: #f5f5f5;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }


    </style>
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


        function TABLE1_onclick() {

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

                 if (Extension == "pdf" || Extension == "xlsx" || Extension == "docx" || Extension == "doc") {
                     args.IsValid = true; // Valid file type
                 }
                 else {
                     args.IsValid = false; // Not valid file type
                 }
             }
         }
        $(document).ready(function () {

            $("#<%= imgbtnaddwork.ClientID %>").dblclick(function (e) {

                e.preventDefault();

            });

        });
    </script>
    <%--<asp:ScriptManager id="ScriptManager1"    runat="server">
    </asp:ScriptManager>--%>
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">	
    <div class="inner-content-right">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-2">
            <tr>
			<td colspan="3" style="border-bottom: 3px solid #005529;"><h3 style="color: #005529;">Community development Management</h3></td>
               
            </tr>

            <tr>
                <td colspan="3">
                    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1">
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Label ID="lblMsg" runat="server" CssClass="red-text" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="black-text" colspan="3">
                                <table width="99%" align="center" cellpadding="3" cellspacing="1" class="table-2 table table-bordered table-striped">
                                    <tr>
                                        <td width="50%">
                                            <table width="98%" align="center" cellpadding="3" cellspacing="1">
                                                <tr>
                                                    <td width="50%" align="right"><span style="color: Black;"><b>State&nbsp;:</b></span> </td>
                                                    <td width="50%" align="left"><b>
                                                        <asp:Label ID="lblstatename" runat="server" ForeColor="#713002"></asp:Label></b></td>
                                                </tr>
                                            </table>

                                        </td>
                                        <td width="50%">
                                            <table width="98%" align="center" cellpadding="3" cellspacing="1">
                                                <tr>
                                                    <td width="50%" align="right"><span style="color: Black;"><b>Reserve&nbsp;:</b></span> </td>
                                                    <td width="50%" align="left"><b>
                                                        <asp:Label ID="lblreaserve" runat="server" ForeColor="#713002"></asp:Label></b></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td>
                                            <table width="100%" align="center" cellpadding="3" cellspacing="1">
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

                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="3">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-2 table table-bordered table-striped">
                                    <tr>


                                        <td class="black-text" align="right" width="25%">Status Of Land of Village <span class="red-text-asterix"></span>:</td>

                                        <td width="25%">
                                            <asp:DropDownList ID="ddlselectstatus" runat="server" CssClass="textfield-drop form-control" >
                                                <asp:ListItem Value="0" Text="Select Status"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Revenue Land With DC"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Buying Private Land/Property"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Diversion Of Forest Land under FCA"></asp:ListItem>

                                            </asp:DropDownList>

                                        </td>




                                        <td class="black-text" align="left" width="25%">Amount Allocated For CDP Rs.<span class="red-text-asterix"></span>:</td>
                                        <td class="black-text" width="25%"><strong>
                                            <asp:Label ID="lbltotalamt" runat="server" Text="" ForeColor="#713002"></asp:Label></strong></td>

                                    </tr>
                                    <tr>
                                        <td class="black-text" align="right">Amount Used(Rs)<span class="red-text-asterix"></span>:</td>

                                        <td class="black-text">
                                            <b>
                                                <asp:Label ID="lblamtused" runat="server" Text="" ForeColor="#713002"></asp:Label></b>
                                        </td>
                                        <td class="black-text" align="center">
                                            <span class="red-text-asterix"></span></td>

                                        <td class="black-text"></td>
                                    </tr>

                                    <tr>

                                        <td class="black-text" colspan="4" align="center">
                                            <strong>Details Of Relocation Site Address:- </strong>

                                        </td>

                                    </tr>

                                    <tr>
                                        <td class="black-text" align="right" width="20%">State :</td>


                                        <td width="30%"><strong>
                                            <asp:Label ID="lblstatename1" runat="server" ForeColor="#713002" CssClass="black-text"></asp:Label></strong>
                                        </td>


                                        <td class="black-text" align="right" width="20%">District&nbsp;:</td>

                                        <td width="30%"><strong>
                                            <asp:Label ID="lbldistrictname" runat="server" ForeColor="#713002" CssClass="black-text"></asp:Label></strong></td>


                                    </tr>

                                    <tr>
                                        <td class="black-text" align="right">Tehsil&nbsp;:
                                        </td>

                                        <td><strong>
                                            <asp:Label ID="lblteshsil" runat="server" ForeColor="#713002" CssClass="black-text"></asp:Label></strong>
                                        </td>


                                        <td class="black-text" align="right">Grampanchayat&nbsp;:
                                        </td>
                                        <td><strong>
                                            <asp:Label ID="lblgpname" runat="server" ForeColor="#713002" CssClass="black-text"></asp:Label>
                                        </strong></td>


                                    </tr>
                                    <tr>
                                        <td class="black-text" align="right">Village Name&nbsp;:
                                        </td>

                                        <td><strong>
                                            <asp:Label ID="lblvillage" runat="server" ForeColor="#713002" CssClass="black-text"></asp:Label></strong>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>



            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="imgbtnpopupwork" runat="server" Text="Add Work" CssClass="btn btn-primary btn-add" OnClick="imgbtnpopupwork_Click" />

                </td>

            </tr>
            <tr>
                <td colspan="3">
                    <%--start popup--%>
                    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Width="610px">
                        <table width="410" border="0" align="center" cellpadding="3" cellspacing="1">
                            <tr>

                                <td colspan="3" align="center ">
                                    <asp:Label ID="lblMsg1" runat="server" Text="" CssClass="red-text"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="3" bgcolor="#e1e0c4" align="center" style="font-size: smaller; color: #3F5E1B;">Please Enter Work Details
                                </td>
                            </tr>
                            <tr>
                                <td width="200" class="black-text" align="right">Name of Relocation Site<span class="red-text-1a">*</span></td>
                                <td class="black-text" width="10" align="center">:</td>
                                <td align="left" width="200">
                                    <asp:TextBox ID="Textcdpwork" runat="server" autocomplete="off" CssClass="textfield" MaxLength="100"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textcdpwork"
                                        Display="Dynamic" ErrorMessage="Please Enter Work" SetFocusOnError="True"
                                        ValidationGroup="ADDWork" CssClass="red-text-asterix" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>

                            </tr>


                            <tr>
                                <td class="black-text" align="right">Allotement Amount(Rs)<span class="red-text-1a">*</span></td>
                                <td class="black-text" align="center">:</td>
                                <td>
                                    <asp:TextBox ID="txtalltdamt" autocomplete="off" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator125" runat="server" ControlToValidate="txtalltdamt"
                                        Display="Dynamic" ErrorMessage="Please Enter Allotement Amount" SetFocusOnError="True"
                                        ValidationGroup="ADDWork" CssClass="red-text-asterix" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator123" runat="server" CssClass="red-text-asterix" ControlToValidate="txtalltdamt"
                                        Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                        ValidationGroup="ADDWork" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>

                                </td>

                            </tr>
                            <tr>
                                <td class="black-text" align="right">Amount Used(Rs)<span class="red-text-1a">*</span></td>
                                <td class="black-text" align="center">:</td>
                                <td>
                                    <asp:TextBox ID="txtamtusd" autocomplete="off" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator126" runat="server" ControlToValidate="txtamtusd"
                                        Display="Dynamic" ErrorMessage="Please Enter Allotement Amount" SetFocusOnError="True"
                                        ValidationGroup="ADDWork" CssClass="red-text-asterix" ForeColor="Red"></asp:RequiredFieldValidator>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="red-text-asterix" ControlToValidate="txtamtusd"
                                        Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                        ValidationGroup="ADDWork" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>

                                </td>

                            </tr>
                            <tr>
                                <td align="right" class="black-text"><span>Amount allocated for CDP under voluntary Village Relocation</span></td>
                                <td align="center" class="black-text">&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TxtAmntAllcteCdpVillRe" autocomplete="off"  runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtAmntAllcteCdpVillRe"
                                        Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                        ValidationGroup="ADDWork" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                                      </td>
                            </tr>
                            <tr>
                                <td align="right" class="black-text"><span>Amount allocated for other Central/State Scheme</span></td>
                                <td align="center" class="black-text">&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="TxtAmountCentraState" autocomplete="off" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtAmountCentraState"
                                        Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                        ValidationGroup="ADDWork" ForeColor="Red">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                                     </td>
                            </tr>
                            <tr>
                                <td align="right" class="black-text">File attachment</td>
                                <td align="center" class="black-text">&nbsp;</td>
                                <td>
                                     <asp:FileUpload ID="fileUpload_Menu" runat="server" />
                        <asp:Label ID="lblmenuMsg" runat="server" Text="Current File:" Visible="False" ForeColor="Black"></asp:Label>
                            <asp:Label ID="lblFileName" runat="server" Visible="False" ForeColor="Green"></asp:Label>
                      
                        <em class="em" style=" color:green;">
                                Tip:-pdf,xlsx,docx,doc</em>
                        
                        <span class="validation">
                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
            ControlToValidate="fileUpload_Menu" ErrorMessage="File Required!" Display="Dynamic" ValidationGroup="ADDWork" ForeColor="Red"></asp:RequiredFieldValidator>
                        --%>
                         <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="ValidateFileUpload1"
                                ControlToValidate="fileUpload_Menu" OnServerValidate="CustomValidator3_ServerValidate"
                                ValidationGroup="ADDWork" ErrorMessage="Please select pdf,xlsx,docx,doc." Display="Dynamic" ForeColor="Red"></asp:CustomValidator></span>
 <br /><asp:HyperLink ID="hypfile" Target="_blank" runat="server" Visible="false" ForeColor="Tomato">Uploaded File</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td class="black-text" align="right">Execution Agency<span class="red-text-1a">*</span></td>
                                <td class="black-text" align="center">:</td>
                                <td>
                                    <asp:TextBox ID="txtagency" runat="server" autocomplete="off" CssClass="textfield" MaxLength="200"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtagency"
                                        Display="Dynamic" ErrorMessage="Please Enter Execution Agency" SetFocusOnError="True"
                                        ValidationGroup="ADDWork" CssClass="red-text-asterix" ForeColor="Red"></asp:RequiredFieldValidator>

                                </td>

                            </tr>
                            <tr>
                                <td class="black-text" align="right">Comment</td>
                                <td class="black-text" align="center">:</td>
                                <td>
                                    <asp:TextBox ID="txtcomment" runat="server" autocomplete="off" CssClass="textfield" Height="100px" MaxLength="300"></asp:TextBox></td>

                            </tr>

                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Button ID="imgbtnaddwork" runat="server" Text="Save" OnClick="imgbtnaddwork_Click" ValidationGroup="ADDWork" CssClass="btn btn-primary btn-add" />


                                    <asp:Button ID="imgbtnreset" runat="server" Text="Reset" CausesValidation="false" Visible="false" OnClick="imgbtnreset_Click" CssClass="btn btn-primary btn-add" />
                                    <asp:Button ID="imgbtncancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="imgbtncancel_Click" CssClass="btn btn-primary btn-add" /></td>
                            </tr>
                        </table>


                    </asp:Panel>
                     <%--end popup--%>
                </td>
            </tr>


            <tr>
                <td colspan="3" align="center">
                    <asp:GridView ID="gvForwork" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataKeyNames="CDP_WRK_INFO_ID" AllowPaging="True" PagerStyle-HorizontalAlign="Center" Width="100%" OnRowDeleting="gvForwork_RowDeleting1" OnRowCommand="gvForwork_RowCommand" OnRowEditing="gvForwork_RowEditing" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="gvForwork_PageIndexChanging" OnRowDataBound="gvForwork_RowDataBound">
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <RowStyle CssClass="drow" BackColor="#F7F7DE" />
                        <AlternatingRowStyle CssClass="alt" BackColor="White" />
                        <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
                        <Columns>
                            <asp:TemplateField HeaderText="S No.">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("VILL_ID") %>' />
                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Work Name">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblmemberid" runat="server" Text='<%#Eval("CDP_WRK_NM") %>'></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Amount allocated for other Central/State Scheme">
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <strong>
                                                <asp:Label ID="lblAmountCentraState" runat="server" Text='<%#Eval("AmountCentraState") %>'></asp:Label>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            <asp:TemplateField HeaderText="Allotted Amount">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("CDP_ALLTD_AMT") %>'></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount Used">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblrelation" runat="server" Text='<%#Eval("CDP_AMT_USD") %>'></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>

                                    <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CdpPrimaryID") %>' CommandName="Edit"
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
                                        CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CdpPrimaryID") %>'
                                        runat="server" Visible="true" ImageUrl="~/AUTH/adminpanel/images/wrong.png" />
                                    <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                </ItemTemplate>
                            </asp:TemplateField>




                        </Columns>
                        <PagerSettings />
                        <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black"
                            HorizontalAlign="right" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />

                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />

                    </asp:GridView>

                </td>
            </tr>

            
            <tr>
                <td align="center" colspan="3" style="height: 24px; text-align:center;">

                    <asp:Button ID="ImageButton1" runat="server" Text="Save" ValidationGroup="AddMember" OnClick="ImgbtnSubmitMember_Click" CssClass="btn btn-primary btn-add" />
                    <asp:Button ID="ImageButton2" runat="server" Text="Reset" CausesValidation="false" Visible="false" OnClick="ImgbtnCancel1_Click" CssClass="btn btn-primary btn-add" />
                    <asp:Button ID="btnback" runat="server" Text="Back" ValidationGroup="AddMember" OnClick="btnback_Click" CssClass="btn btn-primary btn-add" />


                </td>

            </tr>
        </table>
    </div>
    <div style="clear: both"></div>

</div>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        TargetControlID="HiddenField1"
        PopupControlID="Panel1"
        BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>

    <asp:HiddenField ID="HiddenField1" runat="server" />
</asp:Content>

