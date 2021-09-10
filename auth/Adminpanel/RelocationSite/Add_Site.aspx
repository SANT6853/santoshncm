<%@ Page Title="Add Relocation Site:NTCA" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Add_Site.aspx.cs" Inherits="auth_Adminpanel_RelocationSite_Add_Site" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .table-2 td {
            padding: 10px;
            text-align: left;
            vertical-align: top;
        }

        .container-fluid {
            margin-bottom: 50px !important;
        }

        .red-text-1a {
            color: red;
        }
    </style>
  <%--  <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>--%>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#<%= ImgbtnSubmit.ClientID %>').click(function (e) {
                debugger;

              <%--  if ($('#<%= ddlselectname.ClientID %>').val() == "0") {
                    $('#<%= Lblddlselectname.ClientID %>').html("<span style='color:red;'>Please select village name!</span>");

                }--%>
                if ($('#<%= ddlselectstate1.ClientID %>').val() == "0") {
                    $('#<%= Lblddlselectstate1.ClientID %>').html("<span style='color:red;'>Please select state name!</span>");

                }
                // alert($('#<%= ddlselectdistrict.ClientID %>').val());
                if ($('#<%= ddlselectstate1.ClientID %>').val() != "0") {
                    if ($('#<%= ddlselectdistrict.ClientID %>').val() == "0") {
                        $('#<%= Lblddlselectdistrict.ClientID %>').html("<span style='color:red;'>please select district name!</span>");

                    }
                }

            });
        });
    </script>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px;">
            <div class="inner-content-right">

                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" style="border-bottom: 3px solid #005529;">
                            <h3 style="color: #005529;">Insert Relocation Site Details</h3>
                        </td>

                    </tr>

                    <tr>
                        <td colspan="3">
                            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Label ID="lblMsg" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label></td>
                                </tr>
                                


                                <tr>
                                    <td colspan="3" align="center" style="font-size: smaller; color: #f7b000;"><strong>Please Select The Village Which Is Going To Be Relocated</strong></td>
                                </tr>



                                <tr>
                                    <td class="black-text" align="right" width="26%">Relocated from Selected Village<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center" width="2%">:</td>
                                    <td width="53%">
                                        <asp:DropDownList ID="ddlselectname" runat="server" AutoPostBack="True" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged"></asp:DropDownList>&nbsp;
        <asp:Label ID="Lblddlselectname" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>


                                <tr>
                                    <td colspan="3" align="center" style="font-size: smaller; color: #f7b000;"><strong>Please Enter The Details of Relocation Site For The Selected Village</strong></td>
                                </tr>

                                <tr>
                                    <td class="black-text" align="right">Relocated to State Name<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center">:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlselectstate1" runat="server" Width="300" CssClass="textfield-drop form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlselectstate1_SelectedIndexChanged">
                                        </asp:DropDownList>

                                        <asp:Label ID="Lblddlselectstate1" runat="server" ForeColor="Red"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated to District Name<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center">:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlselectdistrict" runat="server" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectdistrict_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        <asp:Label ID="Lblddlselectdistrict" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated to Tehsil Name<span class="red-text-1a">*</span>:</td>
                                    <td class="black-text" align="center">:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlselecttehsil" runat="server" AutoPostBack="True" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselecttehsil_SelectedIndexChanged"   ></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="red-text-asterix" InitialValue="Select Tehsil" ErrorMessage="Please select Tehsil Name" ControlToValidate="ddlselecttehsil" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please select tehsil name</asp:RequiredFieldValidator>
                                          <asp:Label ID="lblmsgdt" runat="server" CssClass="red-text-asterix" ForeColor="Red"></asp:Label>
                                         <asp:Label ID="lblmsgth" runat="server" CssClass ="red-text-asterix" ForeColor="Red"></asp:Label>
                                         <asp:TextBox ID="txttehsil" Visible="false" runat="server" autocomplete="off" Width="300" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txttehsil" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated to Gram panchayat Name<span class="red-text-1a">*</span>:</td>
                                    <td class="black-text" align="center">:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlselectgp" runat="server" AutoPostBack="True" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectgp_SelectedIndexChanged"  ></asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="red-text-asterix" InitialValue="Select Grampanchayat" ErrorMessage="Please select Gram panchayat Name" ControlToValidate="ddlselectgp" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please select Gram panchayat Name</asp:RequiredFieldValidator>
                                         <asp:Label ID="lblmsggp" runat="server" CssClass ="red-text-asterix" ForeColor="Red"></asp:Label>
                                          <asp:TextBox ID="txtgp" Visible="false" runat="server" Width="300" autocomplete="off" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtgp" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated to Village Name<span class="red-text-1a">*</span></td>
                                    <td class="black-text" align="center">:</td>
                                    <td>
                                        <asp:DropDownList ID="DdlRelocatedVillageName" runat="server" Width="300" CssClass="textfield-drop form-control" >
                                    </asp:DropDownList>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="red-text-asterix" InitialValue="0" ErrorMessage="Please select Village Name " ControlToValidate="DdlRelocatedVillageName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please select Village Name</asp:RequiredFieldValidator>
                                        <%--<asp:TextBox ID="txtvillage" Visible="false" runat="server" Width="300" autocomplete="off"  CssClass="textfield-drop form-control" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="red-text-asterix" InitialValue="0" ErrorMessage="Please select Village Name" ControlToValidate="DdlRelocatedVillageName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please Enter Village Name</asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtvillage" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>--%>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="black-text" align="right">Help to find Latitude and Longitude:</td>
                                    <td class="black-text" align="center">&nbsp;</td>
                                    <td>
                                         <i class="glyphicon glyphicon-info-sign">Help</i> :<a href="https://www.latlong.net/" style=" color:blue; text-decoration:underline;" target="_blank" >Find Latitude and Longitude please click</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated to Latitude<span class="red-text-1a">*</span>:</td>
                                    <td class="black-text" align="center">&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="TxtLatitude" runat="server" Width="300" CssClass="textfield form-control" MaxLength="20" autocomplete="off"></asp:TextBox><br />

                                        <asp:RequiredFieldValidator ID="RequireTxtLatitude" runat="server" CssClass="red-text-asterix" ErrorMessage="Please enter Latitude" ControlToValidate="TxtLatitude" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please enter Latitude</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegulTxtLatitude" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtLatitude"
                                            Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="^[1-9]\d*(\.\d+)?$"
                                            ValidationGroup="ADD" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="black-text" align="right">Relocated to Longitude<span class="red-text-1a">*</span>:</td>
                                    <td class="black-text" align="center">&nbsp;</td>
                                    <td>
                                        <asp:TextBox ID="TxtLongitude" Width="300" runat="server" CssClass="textfield form-control" MaxLength="20" autocomplete="off"></asp:TextBox><br />

                                        <asp:RequiredFieldValidator ID="RequLongitude" runat="server" CssClass="red-text-asterix" ErrorMessage="Please enter Longitude" ControlToValidate="TxtLongitude" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please enter Longitude</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="ReguLongitude" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtLongitude"
                                            Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="^[1-9]\d*(\.\d+)?$"
                                            ValidationGroup="ADD" ForeColor="Red">Please Enter Only Numeric Values</asp:RegularExpressionValidator></td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated to Address</td>
                                    <td class="black-text" align="center">:</td>
                                    <td>
                                        <asp:TextBox ID="txraddress" runat="server" Width="300" CssClass="textfield form-control" Height="100px" TextMode="MultiLine" MaxLength="300"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated to Comment</td>
                                    <td class="black-text" align="center">:</td>
                                    <td>
                                        <asp:TextBox ID="txtcomment" runat="server" CssClass="textfield form-control" Width="300" TextMode="MultiLine" Height="100px" MaxLength="300"></asp:TextBox>
                                    </td>
                                </tr>


                            </table>
                        </td>
                    </tr>


                    <tr>
                        <td colspan="" align="center" width="35%"></td>

                        <td>

                            <asp:Button ID="ImgbtnSubmit" runat="server" CssClass="btn btn-primary btn-add" Text="Save" ValidationGroup="ADD" OnClick="ImgbtnSubmit_Click" />
                            <asp:Button ID="ImgbtnCancel" runat="server" CssClass="btn btn-primary btn-add" Text="Reset" Visible="false" CausesValidation="false" OnClick="ImgbtnCancel_Click" />
                            <asp:Button ID="ImgbtnBack" runat="server" CssClass="btn btn-primary btn-add" Text="Back" CausesValidation="false" OnClick="ImgbtnBack_Click" />
                        </td>

                    </tr>

                </table>

            </div>
        </div>
    </div>
</asp:Content>

