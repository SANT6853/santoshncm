<%@ Page Title="Edit SiteDetails:NTCA" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Edit_Site.aspx.cs" Inherits="auth_Adminpanel_RelocationSite_Edit_Site" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .table-2 td {
            padding: 5px 0px;
            text-align: left;
            vertical-align: top;
        }

        .red-text-1a {
            color: red;
        }

        .container-fluid {
            margin-bottom: 50px !important;
        }
    </style>
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#<%= ImgbtnSubmit.ClientID %>').click(function (e) {
                debugger;

                if ($('#<%= ddlselectstate1.ClientID %>').val() == "0") {
                    $('#<%= Lblddlselectstate1.ClientID %>').html("<span style='color:red;'>Please select state name!</span>");

                }

                if ($('#<%= ddlselectstate1.ClientID %>').val() != "0") {
                    if ($('#<%= ddlselectdistrict1.ClientID %>').val() == "0") {
                        $('#<%= Lblddlselectdistrict.ClientID %>').html("<span style='color:red;'>please select district name!</span>");

                    }
                }

            });
        });
    </script>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px;">
            <div class="inner-content-right">

                <table width="98%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="5" style="border-bottom: 3px solid #005529;">
                            <h3 style="color: #005529;">Update Relocation Site Details</h3>
                            <h1>Relocated from village name:(<asp:Label ID="LblFromVillageHeader" ForeColor="Blue" Font-Bold="true" runat="server">dsds</asp:Label>)</h1>
                        </td>

                    </tr>

                    <tr>
                        <td colspan="3" style="height: 306px">
                            <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:Label ID="lblMsg" runat="server" CssClass="red-text" ForeColor="Red" Font-Bold="True" Font-Size="15px"></asp:Label></td>
                                </tr>


                                <tr>
                                    <td class="black-text" align="right">Relocated from State<span class="red-text-1a">*</span>:</td>

                                    <td>
                                        <asp:DropDownList ID="ddlselectstate" runat="server" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectstate_SelectedIndexChanged" AutoPostBack="True" Enabled="false">
                                        </asp:DropDownList>&nbsp;
                                    </td>
                                    <td colspan="" width="17%"></td>


                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated from Tiger Reserve Name<span class="red-text-1a">*</span>:</td>

                                    <td>

                                        <asp:DropDownList ID="ddlselectreserve" runat="server" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged" AutoPostBack="True" Enabled="false">
                                        </asp:DropDownList>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated from District<span class="red-text-1a">*</span>:</td>

                                    <td>
                                        <asp:DropDownList ID="ddlSelectDistrict" runat="server" AutoPostBack="True" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlSelectDistrict_SelectedIndexChanged" Enabled="false"></asp:DropDownList>&nbsp;
                                    </td>
                                </tr>

                              
                                <tr style="display: none;">
                                    <td class="black-text" align="right">Relocated from Grampanchayat<span class="red-text-1a">*</span>:</td>


                                    <td>
                                        <asp:DropDownList ID="ddlselectgp" runat="server" AutoPostBack="True" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectgp_SelectedIndexChanged" Enabled="false"></asp:DropDownList>&nbsp;
                                    </td>
                                </tr>
                                <tr style="display: none;">
                                    <td class="black-text" align="right">Relocated from Village<span class="red-text-1a">*</span>:</td>

                                    <td>
                                        <asp:DropDownList ID="ddlselectname" runat="server" AutoPostBack="True" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged" Enabled="false"></asp:DropDownList>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="black-text" align="right">Help to find Latitude and Longitude:</td>
                                   
                                    <td>
                                        <i class="glyphicon glyphicon-info-sign">Help</i> :<a href="https://www.latlong.net/" style="color: blue; text-decoration: underline;" target="_blank">Find Latitude and Longitude please click</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right">Relocated to Latitude<span class="red-text-1a">*</span>:</td>

                                    <td>
                                        <asp:TextBox ID="TxtLatitude" runat="server" Width="300" CssClass="textfield form-control" MaxLength="20" autocomplete="off"></asp:TextBox><br />

                                        <asp:RequiredFieldValidator ID="RequireTxtLatitude" runat="server" CssClass="red-text-asterix" ErrorMessage="Please enter Latitude" ControlToValidate="TxtLatitude" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please enter Latitude</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegulTxtLatitude" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtLatitude"
                                            Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="^[1-9]\d*(\.\d+)?$"
                                            ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator></td>
                                </tr>


                                <tr>
                                    <td class="black-text" align="right">Relocated to Longitude<span class="red-text-1a">*</span>:</td>

                                    <td>
                                        <asp:TextBox ID="TxtLongitude" Width="300" runat="server" CssClass="textfield form-control" MaxLength="20" autocomplete="off"></asp:TextBox><br />

                                        <asp:RequiredFieldValidator ID="RequLongitude" runat="server" CssClass="red-text-asterix" ErrorMessage="Please enter Longitude" ControlToValidate="TxtLongitude" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="#CC3300">Please enter Longitude</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="ReguLongitude" runat="server" CssClass="red-text-asterix" ControlToValidate="TxtLongitude"
                                            Display="Dynamic" ErrorMessage="Enter Only Numbers" SetFocusOnError="True" ValidationExpression="^[1-9]\d*(\.\d+)?$"
                                            ValidationGroup="ADD" ForeColor="#CC3300">Please Enter Only Numeric Values</asp:RegularExpressionValidator></td>
                        </td>
                    </tr>


                    <tr>
                        <td class="black-text" align="right">Relocated to State Name<span class="red-text-1a">*</span>:</td>

                        <td>
                            <asp:DropDownList ID="ddlselectstate1" runat="server" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectstate1_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:Label ID="Lblddlselectstate1" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="black-text" align="right">Relocated to District Name<span class="red-text-1a">*</span>:</td>

                        <td>
                            <asp:DropDownList ID="ddlselectdistrict1" runat="server" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectdistrict1_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            <asp:Label ID="Lblddlselectdistrict" runat="server" ForeColor="Red"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td class="black-text" align="right">Relocated to Tehsil Name <span class="red-text-1a">*</span>:</td>

                        <td>
                            <asp:DropDownList ID="ddlselecttehsil" runat="server" AutoPostBack="True" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselecttehsil_SelectedIndexChanged"   ></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="red-text-asterix" InitialValue="Select Tehsil" ErrorMessage="Please select Tehsil Name" ControlToValidate="ddlselecttehsil" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please select tehsil name</asp:RequiredFieldValidator>
                            <%--<asp:TextBox ID="txttehsil" runat="server" Width="300" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txttehsil" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="black-text" align="right">Relocated to Gram panchayat Name<span class="red-text-1a">*</span>:</td>

                        <td>
                             <asp:DropDownList ID="DDlRelocatedGrampanChyat" runat="server" AutoPostBack="True" Width="300" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectgp_SelectedIndexChanged"  ></asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="red-text-asterix" InitialValue="Select Grampanchayat" ErrorMessage="Please select Gram panchayat Name" ControlToValidate="ddlselectgp" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please select Gram panchayat Name</asp:RequiredFieldValidator>
                           <%-- <asp:TextBox ID="txtgp" runat="server" Width="300" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtgp" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="black-text" align="right">Relocated to village name<span style="color:red">*</span>:</td>

                        <td>
                            <asp:DropDownList ID="DdlRelocatedVillageName" runat="server" Width="300" CssClass="textfield-drop form-control" >
                                    </asp:DropDownList>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="red-text-asterix" InitialValue="Select Name" ErrorMessage="Please select Gram panchayat Name" ControlToValidate="DdlRelocatedVillageName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please select Village Name</asp:RequiredFieldValidator>
                            <%--<asp:TextBox ID="txtvillage" runat="server" Width="300" CssClass="textfield form-control" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="red-text-asterix" ErrorMessage="Please Enter Village Name" ControlToValidate="txtvillage" Display="Dynamic" SetFocusOnError="True" ValidationGroup="ADD" ForeColor="Red">Please Enter Village Name</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix " ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtvillage" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Characters</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>

                    <tr>
                        <td class="black-text" align="right">Relocated to Other Address :</td>

                        <td>
                            <asp:TextBox ID="txraddress" runat="server" Width="300" CssClass="textfield form-control" TextMode="MultiLine" Height="100px" MaxLength="300"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="black-text" align="right">Relocated to Comment :</td>

                        <td>
                            <asp:TextBox ID="txtcomment" runat="server" Width="300" CssClass="textfield form-control" TextMode="MultiLine" Height="100px" MaxLength="300"></asp:TextBox>
                        </td>

                    </tr>


                </table>
                </td>
  </tr>
  

 <tr>
     <td class="black-text" align="right" width="21.2%"></td>
     <td align="left" colspan="1">


         <asp:Button ID="ImgbtnSubmit" runat="server" CssClass="btn btn-primary btn-add" Text="Save" ValidationGroup="ADD" OnClick="ImgbtnSubmit_Click" />
         <asp:Button ID="ImgbtnCancel" runat="server" CssClass="btn btn-primary btn-add" Text="Reset" Visible="false" CausesValidation="false" OnClick="ImgbtnCancel_Click" />
         <asp:Button ID="ImgbtnBack" runat="server" CssClass="btn btn-primary btn-add" Text="Back" CausesValidation="false" OnClick="ImgbtnBack_Click" />

     </td>
     <td colspan="" width="20%"></td>
     <td colspan="" width="20%"></td>

 </tr>

                </table>

            </div>
        </div>
    </div>
</asp:Content>

