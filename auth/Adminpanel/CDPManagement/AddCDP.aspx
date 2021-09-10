<%@ Page Title="NTCA:Add CDP" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddCDP.aspx.cs" Inherits="auth_Adminpanel_CDPManagement_AddCDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-2">
        <tr>
            <td colspan="3" bgcolor="#e1e0c4" align="center" style="font-size: smaller; color: #3F5E1B;">CDP Management</td>
        </tr>

        <tr>
            <td colspan="3">
                <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1">
                    <tr>
                        <td colspan="3" align="center">
                            <asp:Label ID="lblMsg" runat="server" CssClass="red-text"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="black-text" colspan="3">
                            <table width="99%" align="center" cellpadding="3" cellspacing="1" class="table-2">
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
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-2">
                                <tr>


                                    <td class="black-text" align="right" width="25%">Status Of Land of Village <span class="red-text-asterix"></span>:</td>

                                    <td width="25%">
                                        <asp:DropDownList ID="ddlselectstatus" runat="server" CssClass="textfield-drop" Width="150px">
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
                <asp:Button ID="imgbtnpopupwork" runat="server" Text="Add Work" CssClass="btn-mid" OnClick="imgbtnpopupwork_Click" />

            </td>

        </tr>
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Width="410px">
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
                                <asp:TextBox ID="Textcdpwork" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textcdpwork"
                                    Display="Dynamic" ErrorMessage="Please Enter Work" SetFocusOnError="True"
                                    ValidationGroup="ADDWork" CssClass="red-text-asterix"></asp:RequiredFieldValidator>

                            </td>

                        </tr>


                        <tr>
                            <td class="black-text" align="right">Allotement Amount(Rs)<span class="red-text-1a">*</span></td>
                            <td class="black-text" align="center">:</td>
                            <td>
                                <asp:TextBox ID="txtalltdamt" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator125" runat="server" ControlToValidate="txtalltdamt"
                                    Display="Dynamic" ErrorMessage="Please Enter Allotement Amount" SetFocusOnError="True"
                                    ValidationGroup="ADDWork" CssClass="red-text-asterix"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator123" runat="server" CssClass="red-text-asterix" ControlToValidate="txtalltdamt"
                                    Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                    ValidationGroup="ADDWork">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>

                            </td>

                        </tr>
                        <tr>
                            <td class="black-text" align="right">Amount Used(Rs)<span class="red-text-1a">*</span></td>
                            <td class="black-text" align="center">:</td>
                            <td>
                                <asp:TextBox ID="txtamtusd" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator126" runat="server" ControlToValidate="txtamtusd"
                                    Display="Dynamic" ErrorMessage="Please Enter Allotement Amount" SetFocusOnError="True"
                                    ValidationGroup="ADDWork" CssClass="red-text-asterix"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="red-text-asterix" ControlToValidate="txtamtusd"
                                    Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                                    ValidationGroup="ADDWork">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>

                            </td>

                        </tr>
                        <tr>
                            <td class="black-text" align="right">Execution Agency<span class="red-text-1a">*</span></td>
                            <td class="black-text" align="center">:</td>
                            <td>
                                <asp:TextBox ID="txtagency" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtagency"
                                    Display="Dynamic" ErrorMessage="Please Enter Execution Agency" SetFocusOnError="True"
                                    ValidationGroup="ADDWork" CssClass="red-text-asterix"></asp:RequiredFieldValidator>

                            </td>

                        </tr>
                        <tr>
                            <td class="black-text" align="right">Comment</td>
                            <td class="black-text" align="center">:</td>
                            <td>
                                <asp:TextBox ID="txtcomment" runat="server" CssClass="textfield" Height="100px" MaxLength="300"></asp:TextBox></td>

                        </tr>

                        <tr>
                            <td align="center" colspan="3">
                                <asp:Button ID="imgbtnaddwork" runat="server" Text="Save" OnClick="imgbtnaddwork_Click" ValidationGroup="ADDWork" CssClass="btn-mid" />


                                <asp:Button ID="imgbtnreset" runat="server" Text="Reset" CausesValidation="false" OnClick="imgbtnreset_Click" CssClass="btn-mid" />
                                <asp:Button ID="imgbtncancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="imgbtncancel_Click" CssClass="btn-mid" /></td>
                        </tr>
                    </table>


                </asp:Panel>
            </td>
        </tr>


        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="gvForwork" runat="server" AutoGenerateColumns="False" CellPadding="1" CellSpacing="1"
                    DataKeyNames="CDP_WRK_INFO_ID" AllowPaging="True" PageSize="10" PagerStyle-HorizontalAlign="Center" Width="100%" OnRowDeleting="gvForwork_RowDeleting1" OnRowCommand="gvForwork_RowCommand" OnRowEditing="gvForwork_RowEditing" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid" />
                    <RowStyle CssClass="drow" />
                    <AlternatingRowStyle CssClass="alt" />
                    <PagerStyle CssClass="pgr" />
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

                                <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CDP_WRK_INFO_ID") %>' CommandName="Edit"
                                    Visible="true" ImageUrl="~/AUTH/TIGERRESERVEADMIN/images/arrow.png" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
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
                                    CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CDP_WRK_INFO_ID") %>'
                                    runat="server" Visible="true" ImageUrl="~/AUTH/TIGERRESERVEADMIN/images/wrong.png" />
                                <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                            </ItemTemplate>
                        </asp:TemplateField>




                    </Columns>
                    <PagerSettings />
                    <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                        HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />

                </asp:GridView>

            </td>
        </tr>

        <tr>
            <td class="black-text" align="right" style="width: 408px; height: 25px;"><span class="red-text-asterix"></span></td>
            <td class="black-text" style="height: 25px"></td>
            <td style="height: 25px"></td>
        </tr>


        <tr>
            <td align="center" colspan="3" style="height: 24px">

                <asp:Button ID="ImageButton1" runat="server" Text="Save" ValidationGroup="AddMember" OnClick="ImgbtnSubmitMember_Click" CssClass="btn-mid" />
                <asp:Button ID="ImageButton2" runat="server" Text="Reset" CausesValidation="false" OnClick="ImgbtnCancel1_Click" CssClass="btn-mid" />
                <asp:Button ID="btnback" runat="server" Text="Back" ValidationGroup="AddMember" OnClick="btnback_Click" CssClass="btn-mid" />


            </td>

        </tr>
    </table>
</asp:Content>

