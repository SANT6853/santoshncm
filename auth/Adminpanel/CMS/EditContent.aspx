<%@ Page Title="NTCA:Edit Cms" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="EditContent.aspx.cs" Inherits="auth_Adminpanel_CMS_EditContent" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--<script src="../assets/js/vendor/bootstrap.min.js"></script>-->
      <style>
        .lblColor {
            color: red;
        }
		.control-label{text-align:left !important;}
    </style>
    <script type="text/javascript" language="javascript">
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

            var vMenuType = $('#<%= ddlMenuType.ClientID %>').val();

            var ddwebsite = $('#<%= ddlwebsite.ClientID %>').val();
            if (ddwebsite == "1") {

                if ($('#<%= txtMenuName .ClientID %>').val() == "") {

                    $('#<%= LbltxtMenuName.ClientID %>').html("<span style='color:red; font-size:12px;'>Enter Menu name</span>");
                    return false;
                }
                if ($('#<%= txtPageTitle.ClientID %>').val() == "") {

                    $('#<%= LbltxtPageTitle.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter page title</span>");
                    return false;
                }
                if ($('#<%= txtBrowserTitle.ClientID %>').val() == "") {

                    $('#<%= LbltxtBrowserTitle.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Browse title.</span>");
                   return false;
               }
               if ($('#<%= txtUrlName.ClientID %>').val() == "") {

                    $('#<%= LbltxtUrlName.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Url name.</span>");
                    return false;
                }
                if (vMenuType == "1") {
                    if ($('#<%= FCKeditor1.ClientID %>').val() == "") {

                        $('#<%= LblFCKeditor1.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Page descriptions.</span>");
                        return false;
                    }
                }
                if (vMenuType == "2") {
                    if ($('#<%= txtLinkUrl.ClientID %>').val() == "") {

                        $('#<%= LbltxtLinkUrl.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Page Url.</span>");
                        return false;
                    }
                }
                if (vMenuType == "3") {
                    if ($('#<%= fileUpload_Menu.ClientID %>').val() == "") {

                        $('#<%= LblfileUpload_Menu.ClientID %>').html("<span style='color:red;font-size:12px;'>Browse file/document.</span>");
                        return false;
                    }
                }
            }
            else {



                if ($('#<%= ddlState.ClientID %>').val() == "0") {
                    $('#<%= LblddlState.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select State</span>");
                    return false;
                }
                if ($('#<%= ddlTigerReserve.ClientID %>').val() == "0") {
                    $('#<%= LblddlTigerReserve.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select Tiger Reserve</span>");
                    return false;
                }
                if ($('#<%= txtMenuName .ClientID %>').val() == "") {

                    $('#<%= LbltxtMenuName.ClientID %>').html("<span style='color:red; font-size:12px;'>Enter Menu name</span>");
                    return false;
                }
                if ($('#<%= txtPageTitle.ClientID %>').val() == "") {

                    $('#<%= LbltxtPageTitle.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter page title</span>");
                     return false;
                 }
                 if ($('#<%= txtBrowserTitle.ClientID %>').val() == "") {

                    $('#<%= LbltxtBrowserTitle.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Browse title.</span>");
                    return false;
                }
                if ($('#<%= txtUrlName.ClientID %>').val() == "") {

                    $('#<%= LbltxtUrlName.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Url name.</span>");
                   return false;
               }
               if (vMenuType == "1") {
                   if ($('#<%= FCKeditor1.ClientID %>').val() == "") {

                        $('#<%= LblFCKeditor1.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Page descriptions.</span>");
                        return false;
                    }
                }
                if (vMenuType == "2") {
                    if ($('#<%= txtLinkUrl.ClientID %>').val() == "") {

                        $('#<%= LbltxtLinkUrl.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter Page Url.</span>");
                        return false;
                    }
                }
                if (vMenuType == "3") {
                    if ($('#<%= fileUpload_Menu.ClientID %>').val() == "") {

                        $('#<%= LblfileUpload_Menu.ClientID %>').html("<span style='color:red;font-size:12px;'>Browse file/document.</span>");
                        return false;
                    }
                }
            }
            return true;
        }//


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
 <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
     <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
        <div class="row">
            <div class="col-lg-12 ">
                <div class="widgets-container">
					<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Edit Cms</h3>
                    </div>
                </div>
                  
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
                        
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Select site<label class="lblColor">*</label></label>
                                    <div class="col-sm-3">

                                        <asp:DropDownList ID="ddlwebsite" runat="server" CssClass="form-control" >
                                            <asp:ListItem Value="1">Mainsite</asp:ListItem>
                                            <asp:ListItem Value="2">Tiger Reserve</asp:ListItem>

                                        </asp:DropDownList>

                                    </div>

                                </div>
                              
                          <div class="form-group">
                            <label class="col-sm-2 control-label">Select Language<label class="lblColor">*</label></label>
                            <div class="col-sm-3">

                                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">English</asp:ListItem>
                                    <asp:ListItem Value="2">Hindi</asp:ListItem>
                                    
                                </asp:DropDownList>
                               
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">State<label class="lblColor">*</label></label>
                            <div class="col-sm-3">
                               <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">

                               </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="val" 
                                    ErrorMessage="Select State" InitialValue="Select State" ForeColor="Red" />
                           <div>
                                <asp:Label ID="LblddlState" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                                
                                 </div>
                        </div>
                       
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Select Tiger Reserve<label class="lblColor">*</label></label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlTigerReserve" runat="server"  CssClass="form-control" OnSelectedIndexChanged="ddlTigerReserve_SelectedIndexChanged">

                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="val" 
                                    ErrorMessage="Select tiger reserve" InitialValue="Select Tiger Reserve" ForeColor="Red"/>
                            <div>
                                <asp:Label ID="LblddlTigerReserve" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                                
                                 </div>
                           
                        </div>
                      
                       <%-- <div class="form-group">
                            <label class="col-sm-2 control-label">Select Position</label>
                            <div class="col-sm-3">
                               <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlPosition_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Top</asp:ListItem>
                                    <asp:ListItem Value="2">Bottom</asp:ListItem>
                                   
                                </asp:DropDownList>
                            </div>

                        </div>--%>
                      <%--  <div class="form-group">
                            <label class="col-sm-2 control-label">Select Main Page</label>
                            <div class="col-sm-6">
                                <asp:ListBox ID="lbMenu" runat="server" CssClass="form-control" Width="250px" Height="167px">
                            </asp:ListBox>
                                <asp:RequiredFieldValidator runat="server" CssClass="help-block" Display="Dynamic" ControlToValidate="lbMenu"  ValidationGroup="val" 
                                    ErrorMessage="Select main page" />
                            </div>
                            </div>--%>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Menu Name<label class="lblColor">*</label></label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtMenuName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                     <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="txtMenuName" ValidationGroup="val" 
                                    ErrorMessage="Enter menu name" ForeColor="Red" />
                                 <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="txtMenuName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                             <div>
                                <asp:Label ID="LbltxtMenuName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                                
                                </div>

                            </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Menu Type<label class="lblColor">*</label></label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlMenuType" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">Content</asp:ListItem>
                                  <asp:ListItem Value="2">Link</asp:ListItem>
                                     <asp:ListItem Value="3">File/Document</asp:ListItem>
                                </asp:DropDownList>
                                
                            </div>

                        </div>

                         <div class="form-group" id="divLink" runat="server" visible="false">
                            <label class="col-sm-2 control-label">link Url<label class="lblColor">*</label>
                            </label>
                            <div class="col-sm-3"> 
                                 <asp:TextBox ID="txtLinkUrl" runat="server" CssClass="form-control"></asp:TextBox>
                            <em><span style="font-size: 8pt; color: #459300; font-weight: bold; font-family: Verdana">
                                Tip:-http://www.abc.com </span></em>
                            <asp:RegularExpressionValidator ID="RevLinkUrl" runat="server" ControlToValidate="txtLinkUrl"
                                Display="Dynamic" ErrorMessage="Please enter valid url" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                ValidationGroup="val" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RfvUrlName" runat="server" ControlToValidate="txtLinkUrl"
                                ErrorMessage="Enter link url name" ValidationGroup="val" Display="Dynamic" class="redtext" ForeColor="Red"></asp:RequiredFieldValidator>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLinkUrl"
                            ErrorMessage="Enter link url name" ValidationGroup="val" Display="Dynamic" class="redtext" ForeColor="Red"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtLinkUrl" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                         
                         <div>
                                <asp:Label ID="LbltxtLinkUrl" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                                
                                  </div>

                        </div>
                        <div class="form-group" id="DivFilDocument" runat="server" visible="false">
                    <label class="col-sm-2 control-label">
                        File Upload:<label class="lblColor">*</label>
                    </label>
                    <div class="col-sm-3">
                       <asp:FileUpload ID="fileUpload_Menu" runat="server" />
                        <asp:Label ID="lblmenuMsg" runat="server" Text="Current File:" Visible="False" ForeColor="Black"></asp:Label>
                            <asp:Label ID="lblFileName" runat="server" Visible="False" ForeColor="Green"></asp:Label>
                      <br />
                        <em class="em" style=" color:green;">
                                Tip:-pdf,xlsx,docx,doc</em>
                        
                        <span class="validation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="fileUpload_Menu" ErrorMessage="File Required!" Display="Dynamic" ValidationGroup="val" ForeColor="Red"></asp:RequiredFieldValidator>
                        
                         <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="ValidateFileUpload1"
                                ControlToValidate="fileUpload_Menu" OnServerValidate="CustomValidator3_ServerValidate"
                                ValidationGroup="val" ErrorMessage="Please select only .pdf file." Display="Dynamic" ForeColor="Red"></asp:CustomValidator></span>
                           <div>
                                <asp:Label ID="LblfileUpload_Menu" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                        
                          <br />
                            
                        <div class="clear"></div>
                          </div>

                </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Page Title<label class="lblColor">*</label>
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtPageTitle" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtPageTitle"  ValidationGroup="val" 
                                    ErrorMessage="Enter page title" ForeColor="Red" />

                                 <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtPageTitle"
                                ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                ControlToValidate="txtPageTitle" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                            
                            
                             <div>
                                <asp:Label ID="LbltxtPageTitle" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                                
                                 </div>

                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Browser Title<label class="lblColor">*</label>
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtBrowserTitle" runat="server" CssClass="form-control" MaxLength="50" ></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RevBrowserTitle" runat="server" ErrorMessage="Please enter browser title with one of the following special characters:(&/:'_-)"
                                ControlToValidate="txtBrowserTitle" ValidationExpression="[\u0900-\u097F0-9a-zA-Z\s&/:'_-]+"
                                ValidationGroup="val" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>

                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtBrowserTitle"
                                ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 2 and maximum 50 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="txtBrowserTitle" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                            <div>
                                <asp:Label ID="LbltxtBrowserTitle" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                            </div>
                            

                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">URL Name<label class="lblColor">*</label>
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtUrlName"  runat="server" MaxLength="50" CssClass="form-control" />
                                <asp:RegularExpressionValidator ID="regUrlName" runat="server" ErrorMessage="Please enter url name in english with following special characters:(_-)"
                                ControlToValidate="txtUrlName" ValidationExpression="[0-9a-zA-Z_-]+" ValidationGroup="val"
                                Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtUrlName" ID="regUrlNameLength"
                                ValidationExpression="^[\s\S]{2,50}$" runat="server" ValidationGroup="Menu" ErrorMessage="Minimum 2 and maximum 50 characters required."
                                Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfUrlname" runat="server" ControlToValidate="txtUrlName"
                                Display="Dynamic" ErrorMessage="Please enter url name." ValidationGroup="val"
                                class="redtext" ForeColor="Red"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="txtUrlName" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                  <div>
                                <asp:Label ID="LbltxtUrlName" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                            </div>
                            

                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Meta Keyword(Enter comma seprated keyword)
                            </label>
                            <div class="col-sm-3"> 
                                 <asp:TextBox ID="txtMetaKeyword" runat="server" MaxLength="300" TextMode="MultiLine"
                                CssClass="form-control" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RevMetaKeyword" runat="server" ErrorMessage="Please enter valid data. No special characters are allowed except (space and ,)"
                                ControlToValidate="txtMetaKeyword" ValidationExpression="([\u0900-\u097F]|[a-z]|[A-Z]|[0-9]|[, ])*"
                                ValidationGroup="Menu" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtMetaKeyword"
                                ID="regMetakeywordLength" ValidationExpression="^[\s\S]{1,300}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 1 and maximum 300 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMetaKeyword"
                                Display="Dynamic" ErrorMessage="Please enter Metakeyword." ValidationGroup="val"
                                CssClass="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>

                            </div>
                            

                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Meta Description
                            </label>
                            <div class="col-sm-3"> 
                                 <asp:TextBox ID="txtMetaDescription" runat="server" MaxLength="300" TextMode="MultiLine"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtMetaDescription"
                                ID="regMetaDescriptionLength" ValidationExpression="^[\s\S]{1,300}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 1 and maximum 300 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                                  <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMetaDescription"
                Display="Dynamic" ErrorMessage="Please enter MetaDescription." ValidationGroup="val"
                CssClass="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="txtMetaDescription" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            

                        </div>

                         <div class="form-group">
                            <label class="col-sm-2 control-label">Meta Language
                            </label>
                            <div class="col-sm-3"> 
                                <asp:DropDownList ID="ddlMetaLang" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="en">English</asp:ListItem>
                                     <asp:ListItem Value="hi">Hindi</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            

                        </div>

                          <div class="form-group">
                            <label class="col-sm-2 control-label">Meta Title
                            </label>
                            <div class="col-sm-3"> 
                               <asp:TextBox ID="txtMetaTitle" runat="server" MaxLength="300" TextMode="MultiLine"
                               CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtMetaTitle"
                                ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{1,300}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 1 and maximum 300 characters required." ForeColor="Red"></asp:RegularExpressionValidator>

                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMetaTitle"
                Display="Dynamic" ErrorMessage="Please enter Meta Title." ValidationGroup="val"
                CssClass="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="txtMetaTitle" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            

                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Page Small Description
                            </label>
                            <div class="col-sm-3"> 
                               <asp:TextBox ID="txtSmallDescription" runat="server" MaxLength="300" TextMode="MultiLine"
                               CssClass="form-control"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtMetaTitle"
                                ID="reSmallDesc" ValidationExpression="^[\s\S]{1,500}$" runat="server"
                                ValidationGroup="val" ErrorMessage="Minimum 1 and maximum 300 characters required." ForeColor="Red"></asp:RegularExpressionValidator>

                                <%--<asp:RequiredFieldValidator ID="rfvSmallDesc" runat="server" ControlToValidate="txtMetaTitle"
                Display="Dynamic" ErrorMessage="Please enter Meta Title." ValidationGroup="val"
                CssClass="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                        ControlToValidate="txtSmallDescription" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                        ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                            

                        </div>
                         <div class="form-group" id="divContent" runat="server">
                            <label class="col-sm-2 control-label"> Page Description<label class="lblColor">*</label>
                            </label>
                            <div class="col-sm-12"> 
                                <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" BasePath="~/fckeditor/"
                                Height="730" Width="100%">
                            </FCKeditorV2:FCKeditor>
                                 <div>
                                <asp:Label ID="LblFCKeditor1" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                            </div>
                            </div>
                            

                        </div>
                            
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Update" OnClientClick="return getPass();" CssClass="btn aqua" OnClick="btnsave_Click" />
                                    <asp:Button ID="btnBack" runat="server" CausesValidation="false" Text="Back"  CssClass="btn aqua" OnClick="btnBack_Click" />
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <script>
        function extendedValidatorUpdateDisplay(obj) {
            // Appelle la méthode originale
            if (typeof originalValidatorUpdateDisplay === "function") {
                originalValidatorUpdateDisplay(obj);
            }

            // Récupère l'état du control (valide ou invalide) 
            // et ajoute ou enlève la classe has-error
            var control = document.getElementById(obj.controltovalidate);
            if (control) {
                var isValid = true;
                for (var i = 0; i < control.Validators.length; i += 1) {
                    if (!control.Validators[i].isvalid) {
                        isValid = false;
                        break;
                    }
                }
                
                if (isValid) {
                    $(control).closest(".form-group").removeClass("has-error");
                } else {
                    $(control).closest(".form-group").addClass("has-error");
                }
            }
        }

        // Remplace la méthode ValidatorUpdateDisplay
        var originalValidatorUpdateDisplay = window.ValidatorUpdateDisplay;
        window.ValidatorUpdateDisplay = extendedValidatorUpdateDisplay;
    </script>
</asp:Content>

