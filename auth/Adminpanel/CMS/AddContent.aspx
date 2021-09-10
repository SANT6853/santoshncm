<%@ Page Title="NTCA:Add Cms" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="AddContent.aspx.cs" Inherits="auth_Adminpanel_CMS_AddContent" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style>
.lblColor {
	color: red;
}
.control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left !important;
}
#contentbody_LblFCKeditor1 {
	border: 1px solid #f2f2f2 !important;
}
</style>
  <script type="text/javascript" language="javascript">
        $(document).ready(function () {

        });
        function ValidateFileUpload1(Source, args) {
            var fuData = document.getElementById('<%= fileUpload_Menu.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                if (Extension == "pdf" || Extension == ".xlsx" || Extension == "docx" || Extension == "doc") {
                    args.IsValid = true; // Valid file type
                }
                else {
                    args.IsValid = false; // Not valid file type
                }
            }
        }

        function validateData() {
            $('#<%= LblddlState.ClientID %>').html("");
            $('#<%= LblddlTigerReserve.ClientID %>').html("");
            $('#<%= LbltxtMenuName.ClientID %>').html("");
            $('#<%= LbltxtPageTitle.ClientID %>').html("");
            $('#<%= LbltxtBrowserTitle.ClientID %>').html("");
            $('#<%= LbltxtUrlName.ClientID %>').html("");
            //ddl change event


            //$("#contentbody_ddlwebsite").change(function ()
            //{
            //    alert($('option:selected', this).text());
            //});
            // $('[id*=FCKeditor1]').each(function () { alert( $(this).val())});
            // alert($('#contentbody_FCKeditor1').val());
            var vMenuType = $('#<%= ddlMenuType.ClientID %>').val();

            var ddwebsite = $('#<%= ddlwebsite.ClientID %>').val();
            if (ddwebsite == "1") {

                if ($('#<%= txtMenuName.ClientID %>').val() == "") {
                    $('#<%= txtMenuName.ClientID %>').focus();
                    $('#<%= LbltxtMenuName.ClientID %>').html("<span style='color:red; font-size:12px;'>Enter Menu name</span>");
                    return false;
                }
                if ($('#<%= txtPageTitle.ClientID %>').val() == "") {
                    $('#<%= txtPageTitle .ClientID %>').focus();
                    $('#<%= LbltxtPageTitle.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter page title</span>");
                    return false;
                }
                if ($('#<%= txtBrowserTitle.ClientID %>').val() == "") {
                    $('#<%= txtBrowserTitle.ClientID %>').focus();
                   $('#<%= LbltxtBrowserTitle.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Browse title.</span>");
                   return false;
               }
               if ($('#<%= txtUrlName.ClientID %>').val() == "") {
                    $('#<%= txtUrlName.ClientID %>').focus();
                    $('#<%= LbltxtUrlName.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Url name.</span>");
                    return false;
                }
                if (vMenuType == "1") {

                  // <%--if ($('#<%= FCKeditor1.ClientID %>').val() == "") {
                  //     alert('first');
                   //     $('#<%= LblFCKeditor1.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Page descriptions.</span>");
                    //     return false;
                   //  }--%>
                }
                if (vMenuType == "2") {
                    if ($('#<%= txtLinkUrl.ClientID %>').val() == "") {
                        $('#<%= txtLinkUrl.ClientID %>').focus();
                        $('#<%= LbltxtLinkUrl.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Page Url.</span>");
                        return false;
                    }
                }
                if (vMenuType == "3") {
                    if ($('#<%= fileUpload_Menu.ClientID %>').val() == "") {
                        $('#<%= fileUpload_Menu.ClientID %>').focus();
                        $('#<%= LblfileUpload_Menu.ClientID %>').html("<span style='color:red;font-size:12px;'>Browse file/document.</span>");
                        return false;
                    }
                }
            }
            else {



                if ($('#<%= ddlState.ClientID %>').val() == "0") {
                    $('#<%= ddlState.ClientID %>').focus();
                    $('#<%= LblddlState.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select State</span>");
                    return false;
                }
                if ($('#<%= ddlTigerReserve.ClientID %>').val() == "0") {
                    $('#<%= ddlTigerReserve.ClientID %>').focus();
                    $('#<%= LblddlTigerReserve.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select Tiger Reserve</span>");
                    return false;
                }
                if ($('#<%= txtMenuName .ClientID %>').val() == "") {
                    $('#<%= txtMenuName.ClientID %>').focus();
                    $('#<%= LbltxtMenuName.ClientID %>').html("<span style='color:red; font-size:12px;'>Enter Menu name</span>");
                    return false;
                }
                if ($('#<%= txtPageTitle.ClientID %>').val() == "") {
                    $('#<%= txtPageTitle.ClientID %>').focus();
                     $('#<%= LbltxtPageTitle.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter page title</span>");
                     return false;
                 }
                 if ($('#<%= txtBrowserTitle.ClientID %>').val() == "") {
                    $('#<%= txtBrowserTitle.ClientID %>').focus();
                    $('#<%= LbltxtBrowserTitle.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Browse title.</span>");
                    return false;
                }
                if ($('#<%= txtUrlName.ClientID %>').val() == "") {
                    $('#<%= txtUrlName.ClientID %>').focus();
                   $('#<%= LbltxtUrlName.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Url name.</span>");
                   return false;
               }
               if (vMenuType == "1") {
                // <%--  if ($('#<%= FCKeditor1.ClientID %>').val() == "") {
                 //      alert('last');
                 //         $('#<%= LblFCKeditor1.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Page descriptions.</span>");
                 //       return false;
                 //   }--%>
                }
                if (vMenuType == "2") {
                    if ($('#<%= txtLinkUrl.ClientID %>').val() == "") {
                        $('#<%= txtLinkUrl.ClientID %>').focus();
                        $('#<%= LbltxtLinkUrl.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Page Url.</span>");
                        return false;
                    }
                }
                if (vMenuType == "3") {
                    if ($('#<%= fileUpload_Menu.ClientID %>').val() == "") {
                        $('#<%= fileUpload_Menu.ClientID %>').focus();
                        $('#<%= LblfileUpload_Menu.ClientID %>').html("<span style='color:red;font-size:12px;'>Browse file/document.</span>");
                        return false;
                    }
                }
            }
            return true;
        }//


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
        <div class="wrapper-content">
          <div class="inner-content-right">
            <div class="box box-primary1" style="margin-bottom: 25px;">
              <div class="box-header with-border">
                <h3 class="box-title" style="color: #005529;">Add CMS</h3>
              </div>
            </div>
            <div class="form-horizontal">
              <asp:HiddenField ID="hfpwd" runat="server" />
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">
                  Select site
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:DropDownList ID="ddlwebsite" ValidationGroup="GroupCMS" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged">
                      <asp:ListItem Value="1">Mainsite</asp:ListItem>
                      <asp:ListItem Value="2">Tiger Reserve</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">
                  Select Language
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:DropDownList ID="ddlLanguage" ValidationGroup="GroupCMS" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
                      <asp:ListItem Value="1">English</asp:ListItem>
                      <asp:ListItem Value="2">Hindi</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label"> State
                    <asp:Label ID="StateStar" Visible="false" runat="server" Font-Bold="true" Text="*" ForeColor="Red"></asp:Label>
                  </label>
                  <div class="col-sm-6">
                    <asp:DropDownList ID="ddlState" ValidationGroup="GroupCMS" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"> </asp:DropDownList>
                    <%-- <asp:RequiredFieldValidator ID="rfvState" runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="GroupCMS" 
                                    ErrorMessage="Select State" InitialValue="0" />--%>
                    <div>
                      <asp:Label ID="LblddlState" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label"> Select Tiger Reserve
                    <asp:Label ID="ReserveStar" Visible="false" Font-Bold="true" runat="server" Text="*" ForeColor="Red"></asp:Label>
                  </label>
                  <div class="col-sm-6">
                    <asp:DropDownList ID="ddlTigerReserve" ValidationGroup="GroupCMS" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlTigerReserve_SelectedIndexChanged"> </asp:DropDownList>
                    <%--                                        <asp:RequiredFieldValidator runat="server" Display="Dynamic"  CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="GroupCMS"
                                            ErrorMessage="Select tiger reserve" InitialValue="0" />--%>
                    <div>
                      <asp:Label ID="LblddlTigerReserve" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">
                  Select Position
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:DropDownList ID="ddlPosition" ValidationGroup="GroupCMS" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPosition_SelectedIndexChanged">
                      <asp:ListItem Value="1">Top</asp:ListItem>
                      <asp:ListItem Value="2">Bottom</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">Select Main Page</label>
                  <div class="col-sm-6">
                    <asp:ListBox ID="lbMenu" ValidationGroup="GroupCMS" runat="server" CssClass="form-control" Width="100%" Height="167px"></asp:ListBox>
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" CssClass="help-block" Display="Dynamic" ControlToValidate="lbMenu" ValidationGroup="GroupCMS"
                                                ErrorMessage="Select main page" ForeColor="Red" />
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">
                  Menu Name
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtMenuName" ValidationGroup="GroupCMS" autocomplete="off" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Display="Dynamic" CssClass="help-block" ControlToValidate="txtMenuName" ValidationGroup="GroupCMS"
                                                ErrorMessage="Enter menu name" ForeColor="Red" />
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                ControlToValidate="txtMenuName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupCMS"
                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                    <div>
                      <asp:Label ID="LbltxtMenuName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">
                  Menu Type
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:DropDownList ID="ddlMenuType" ValidationGroup="GroupCMS" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMenuType_SelectedIndexChanged">
                      <asp:ListItem Value="1">Content</asp:ListItem>
                      <asp:ListItem Value="2">Link</asp:ListItem>
                      <asp:ListItem Value="3">File/Document</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group " id="divLink" runat="server" visible="false">
                  <label class="col-sm-3 control-label">
                  link Url
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtLinkUrl" ValidationGroup="GroupCMS" autocomplete="off" runat="server" CssClass="form-control"></asp:TextBox>
                    <em><span style="font-size: 8pt; color: #459300; font-weight: bold; font-family: Verdana">Tip:-http://www.abc.com </span></em>
                    <asp:RegularExpressionValidator ID="RevLinkUrl" SetFocusOnError="true" runat="server" ControlToValidate="txtLinkUrl"
                                                Display="Dynamic" ErrorMessage="Please enter valid url" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                                ValidationGroup="GroupCMS" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RfvUrlName" runat="server" SetFocusOnError="true" ControlToValidate="txtLinkUrl"
                                                ErrorMessage="Enter link url name" ValidationGroup="GroupCMS" Display="Dynamic" class="redtext" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" SetFocusOnError="true" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                                ControlToValidate="txtLinkUrl" Display="Dynamic" ValidationGroup="GroupCMS"
                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div>
                      <asp:Label ID="LbltxtLinkUrl" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group" id="DivFilDocument" runat="server" visible="false">
                  <label class="col-sm-3 control-label">
                  File Upload:
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:FileUpload ID="fileUpload_Menu" runat="server" ValidationGroup="GroupCMS" />
                    <asp:Label ID="lblmenuMsg" runat="server" Text="Current File:" Visible="False" ForeColor="Black"></asp:Label>
                    <asp:Label ID="lblFileName" runat="server" Visible="False" ForeColor="Green"></asp:Label>
                    <em class="em" style="color: green;">Tip:-pdf,xlsx,docx,doc</em> <span class="validation">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                    ControlToValidate="fileUpload_Menu" ErrorMessage="File Required!" SetFocusOnError="true" Display="Dynamic" ValidationGroup="GroupCMS" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator3" SetFocusOnError="true" runat="server" ClientValidationFunction="ValidateFileUpload1"
                                                    ControlToValidate="fileUpload_Menu" OnServerValidate="CustomValidator3_ServerValidate"
                                                    ValidationGroup="GroupCMS" ErrorMessage="Please select pdf,xlsx,docx,doc." Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                    </span>
                    <div>
                      <asp:Label ID="LblfileUpload_Menu" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                    <br />
                    <div class="clear"></div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">
                  Page Title
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtPageTitle" ValidationGroup="GroupCMS" autocomplete="off" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator SetFocusOnError="true" runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtPageTitle" ValidationGroup="GroupCMS"
                                                ErrorMessage="Enter page title" ForeColor="Red" />
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtPageTitle"
                                                ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                                ValidationGroup="GroupCMS" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="regPageTitle" SetFocusOnError="true" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                                ControlToValidate="txtPageTitle" Display="Dynamic" ValidationGroup="GroupCMS"
                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div>
                      <asp:Label ID="LbltxtPageTitle" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">
                  Browser Title
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtBrowserTitle" ValidationGroup="GroupCMS" autocomplete="off" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RevBrowserTitle" SetFocusOnError="true" runat="server" ErrorMessage="Please enter browser title with one of the following special characters:(&/:'_-)"
                                                ControlToValidate="txtBrowserTitle" ValidationExpression="[\u0900-\u097F0-9a-zA-Z\s&/:'_-]+"
                                                ValidationGroup="GroupCMS" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtBrowserTitle"
                                                ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                                ValidationGroup="GroupCMS" ErrorMessage="Minimum 2 and maximum 50 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" SetFocusOnError="true" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                ControlToValidate="txtBrowserTitle" Display="Dynamic" ValidationGroup="GroupCMS"
                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div>
                      <asp:Label ID="LbltxtBrowserTitle" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label">
                  URL Name
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtUrlName" ValidationGroup="GroupCMS" autocomplete="off" runat="server" MaxLength="50" CssClass="form-control" />
                    <asp:RegularExpressionValidator ID="regUrlName" SetFocusOnError="true" runat="server" ErrorMessage="Please enter url name in english with following special characters:(_-)"
                                                ControlToValidate="txtUrlName" ValidationExpression="[0-9a-zA-Z_-]+" ValidationGroup="GroupCMS"
                                                Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ControlToValidate="txtUrlName" ID="regUrlNameLength" SetFocusOnError="true"
                                                ValidationExpression="^[\s\S]{2,50}$" runat="server" ValidationGroup="Menu" ErrorMessage="Minimum 2 and maximum 50 characters required."
                                                Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfUrlname" runat="server" ControlToValidate="txtUrlName" SetFocusOnError="true"
                                                Display="Dynamic" ErrorMessage="Please enter url name." ValidationGroup="GroupCMS"
                                                class="redtext" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" SetFocusOnError="true" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                ControlToValidate="txtUrlName" Display="Dynamic" ValidationGroup="GroupCMS"
                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div>
                      <asp:Label ID="LbltxtUrlName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label"> Meta Keyword(Enter comma seprated keyword) </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtMetaKeyword" ValidationGroup="GroupCMS" autocomplete="off" runat="server" MaxLength="300" TextMode="MultiLine"
                                                CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RevMetaKeyword" SetFocusOnError="true" runat="server" ErrorMessage="Please enter valid data. No special characters are allowed except (space and ,)"
                                                ControlToValidate="txtMetaKeyword" ValidationExpression="([\u0900-\u097F]|[a-z]|[A-Z]|[0-9]|[, ])*"
                                                ValidationGroup="Menu" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtMetaKeyword"
                                                ID="regMetakeywordLength" ValidationExpression="^[\s\S]{1,300}$" runat="server"
                                                ValidationGroup="GroupCMS" ErrorMessage="Minimum 1 and maximum 300 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMetaKeyword"
                                Display="Dynamic" ErrorMessage="Please enter Metakeyword." ValidationGroup="GroupCMS"
                                CssClass="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label"> Meta Description </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtMetaDescription" ValidationGroup="GroupCMS" autocomplete="off" runat="server" MaxLength="300" TextMode="MultiLine"
                                                CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtMetaDescription"
                                                ID="regMetaDescriptionLength" ValidationExpression="^[\s\S]{1,300}$" runat="server"
                                                ValidationGroup="GroupCMS" ErrorMessage="Minimum 1 and maximum 300 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMetaDescription"
                                Display="Dynamic" ErrorMessage="Please enter MetaDescription." ValidationGroup="GroupCMS"
                                CssClass="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" SetFocusOnError="true" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                ControlToValidate="txtMetaDescription" Display="Dynamic" ValidationGroup="GroupCMS"
                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label"> Meta Language </label>
                  <div class="col-sm-6">
                    <asp:DropDownList ID="ddlMetaLang" ValidationGroup="GroupCMS" runat="server" CssClass="form-control">
                      <asp:ListItem Value="en">English</asp:ListItem>
                      <asp:ListItem Value="hi">Hindi</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="clearfix"></div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label"> Meta Title </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtMetaTitle" ValidationGroup="GroupCMS" autocomplete="off" runat="server" MaxLength="300" TextMode="MultiLine"
                                                CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtMetaTitle"
                                                ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{1,300}$" runat="server"
                                                ValidationGroup="GroupCMS" ErrorMessage="Minimum 1 and maximum 300 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMetaTitle"
                                    Display="Dynamic" ErrorMessage="Please enter Meta Title." ValidationGroup="GroupCMS"
                                    CssClass="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" SetFocusOnError="true" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                ControlToValidate="txtMetaTitle" Display="Dynamic" ValidationGroup="GroupCMS"
                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-3 control-label"> Page Small Description </label>
                  <div class="col-sm-6">
                    <asp:TextBox ID="txtSmallDescription" ValidationGroup="GroupCMS" autocomplete="off" runat="server" MaxLength="300" TextMode="MultiLine"
                                                CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtMetaTitle"
                                                ID="reSmallDesc" ValidationExpression="^[\s\S]{1,500}$" runat="server"
                                                ValidationGroup="GroupCMS" ErrorMessage="Minimum 1 and maximum 300 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <%--<asp:RequiredFieldValidator ID="rfvSmallDesc" runat="server" ControlToValidate="txtMetaTitle"
                                    Display="Dynamic" ErrorMessage="Please enter Meta Title." ValidationGroup="GroupCMS"
                                    CssClass="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" SetFocusOnError="true" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                ControlToValidate="txtSmallDescription" Display="Dynamic" ValidationGroup="GroupCMS"
                                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-11">
                <div class="form-group" id="divContent" runat="server">
                  <label class="col-sm-2 control-label">
                  Page Description
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-sm-12">
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" BasePath="~/fckeditor/"
                                                Height="360" Width="100%"> </FCKeditorV2:FCKeditor>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FCKeditor1"
                                                ErrorMessage="Enter Page descriptions" ValidationGroup="GroupCMS" Display="Dynamic" class="redtext" ForeColor="Red"></asp:RequiredFieldValidator>
                    <div>
                      <asp:Label ID="LblFCKeditor1" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <div class="col-sm-4 ">
                    <asp:Button ID="btnsave" runat="server" ValidationGroup="GroupCMS" Text="Save" OnClientClick="return validateData();" CssClass="btn btn-primary" OnClick="btnsave_Click" />
                    <asp:Button ID="btnBack" runat="server" ValidationGroup="GroupCMS1" Text="Back" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnBack_Click" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </ContentTemplate>
    <Triggers>
      <%--<asp:PostBackTrigger ControlID="ImgbtnSubmit" />--%>
      <asp:PostBackTrigger ControlID="btnsave" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
