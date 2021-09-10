<%@ Page Title="NTCA:Add Bottom thumnail" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddBottomThumnail.aspx.cs" Inherits="auth_Adminpanel_BottomThumnails_AddBottomThumnail" %>
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
</style>
  <script type="text/javascript" language="javascript">
        //jpeg, .jpg, .png or .gif
        function ValidateFileUpload(Source, args) {
            var fuData = document.getElementById('<%= ImageUploader.ClientID %>');
            var FileUploadPath = fuData.value;

            if (FileUploadPath == '') {
                // There is no file selected
                args.IsValid = false;
            }
            else {
                var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

                if (Extension == "jpeg" || Extension == "jpg" || Extension == "png" || Extension == "gif") {
                    args.IsValid = true; // Valid file type
                }
                else {
                    args.IsValid = false; // Not valid file type
                }
            }
        }





        $(function () {
            $('#<%=ImageUploader.ClientID %>').change(
                 function () {
                     var fileExtension = ['jpeg', 'jpg', 'png'];
                     if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                         $('#<%=ImageUploader.ClientID %>').focus();
                         $('#<%= LblImageUploader.ClientID %>').html("<span style='color:red;font-size:12px;'>Only '.jpeg','.jpg','.png' formats are allowed.</span>");
                     }
                     else {
                         $('#<%=ImageUploader.ClientID %>').focus();
                         $('#<%= LblImageUploader.ClientID %>').html(" ");
                     }
                 })
        })

             function validateData() {
                 $('#<%= LbltxtTitle.ClientID %>').html("");
                 $('#<%= LbltxtTitleHindi.ClientID %>').html("");
                 $('#<%= LblImageUploader.ClientID %>').html("");
                 $('#<%= LblddlState.ClientID %>').html("");
                 $('#<%= LblddlTigerReserve.ClientID %>').html("");

                 var ddwebsite = $('#<%= ddlwebsite.ClientID %>').val();
                 if (ddwebsite == "1") {
                     if ($('#<%= txtTitle.ClientID %>').val() == "") {
                         $('#<%=txtTitle.ClientID %>').focus();
                    $('#<%= LbltxtTitle.ClientID %>').html("<span style='color:red; font-size:12px;'>Enter page title</span>");
                    return false;
                }
                if ($('#<%= txtTitleHindi.ClientID %>').val() == "") {
                    $('#<%=txtTitleHindi.ClientID %>').focus();
                    $('#<%= LbltxtTitleHindi.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter page title(HINDI)</span>");
                    return false;
                }
                if ($('#<%= ImageUploader.ClientID %>').val() == "") {
                    $('#<%=ImageUploader.ClientID %>').focus();
                    $('#<%= LblImageUploader.ClientID %>').html("<span style='color:red;font-size:12px;'>Please add image.</span>");
                    return false;
                }
            }
            else {



                     if ($('#<%= ddlState.ClientID %>').val() == "0") {
                         $('#<%=ddlState.ClientID %>').focus();
                    $('#<%= LblddlState.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select State</span>");
                    return false;
                }
                     if ($('#<%= ddlTigerReserve.ClientID %>').val() == "0") {
                         $('#<%=ddlTigerReserve.ClientID %>').focus();
                    $('#<%= LblddlTigerReserve.ClientID %>').html("<span style='color:red;font-size:12px;'>Please select Tiger Reserve</span>");
                    return false;
                }
                if ($('#<%= txtTitle.ClientID %>').val() == "") {
                    $('#<%=txtTitle.ClientID %>').focus();
                    $('#<%= LbltxtTitle.ClientID %>').html("<span style='color:red; font-size:12px;'>Enter page title</span>");
                    return false;
                }
                if ($('#<%= txtTitleHindi.ClientID %>').val() == "") {
                    $('#<%=txtTitleHindi.ClientID %>').focus();
                    $('#<%= LbltxtTitleHindi.ClientID %>').html("<span style='color:red;font-size:12px;'>Enter page title(HINDI)</span>");
                    return false;
                }
                if ($('#<%= ImageUploader.ClientID %>').val() == "") {
                    $('#<%=ImageUploader.ClientID %>').focus();
                    $('#<%= LblImageUploader.ClientID %>').html("<span style='color:red;font-size:12px;'>Please add image.</span>");
                     return false;
                 }
             }
             return true;
         }


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
                <h3 class="box-title" style="color: #005529;">Add Bottom Thumbnails</h3>
              </div>
            </div>
            <div class="form-horizontal">
              <asp:HiddenField ID="hfpwd" runat="server" />
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">Select Site</label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlwebsite" AutoPostBack="true" runat="server" CssClass="form-control" ValidationGroup="GroupBthum"
                                            OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged">
                      <asp:ListItem Value="1">Mainsite</asp:ListItem>
                      <asp:ListItem Value="2">Tiger Reserve</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6" id="divstate" runat="server" visible="false">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  State
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" ValidationGroup="GroupBthum"
                                            CssClass="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged1"> </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="GroupBthum"
                                            ErrorMessage="Select State" InitialValue="Select State" ForeColor="Red" />
                    <div>
                      <asp:Label ID="LblddlState" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6" id="divTigerReserve" runat="server" visible="false">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Select Tiger Reserve
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlTigerReserve" runat="server" ValidationGroup="GroupBthum" CssClass="form-control"> </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="GroupBthum"
                                            ErrorMessage="Select tiger reserve" InitialValue="Select Tiger Reserve" ForeColor="Red" />
                    <div>
                      <asp:Label ID="LblddlTigerReserve" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Title
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" ValidationGroup="GroupBthum" MaxLength="50" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block" ControlToValidate="txtTitle" ValidationGroup="GroupBthum"
                                            ErrorMessage="Enter page title" ForeColor="Red" />
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTitle" SetFocusOnError="true"
                                            ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                            ValidationGroup="GroupBthum" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtTitle" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupBthum"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div>
                      <asp:Label ID="LbltxtTitle" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Title in Hindi
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtTitleHindi" runat="server" CssClass="form-control" ValidationGroup="GroupBthum" MaxLength="100" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block" ControlToValidate="txtTitleHindi" ValidationGroup="GroupBthum"
                                            ErrorMessage="Enter page title in hindi" ForeColor="Red" />
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTitleHindi" SetFocusOnError="true"
                                            ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{2,100}$" runat="server"
                                            ValidationGroup="GroupBthum" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtTitleHindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupBthum"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <div>
                      <asp:Label ID="LbltxtTitleHindi" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label"> Alternate Tag </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtAltTag" runat="server" CssClass="form-control" ValidationGroup="GroupBthum" MaxLength="50" autocomplete="off"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RevBrowserTitle" runat="server" SetFocusOnError="true" ErrorMessage="Please enter browser title with one of the following special characters:(&/:'_-)"
                                            ControlToValidate="txtAltTag" ValidationExpression="[\u0900-\u097F0-9a-zA-Z\s&/:'_-]+"
                                            ValidationGroup="GroupBthum" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtAltTag" SetFocusOnError="true"
                                            ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                            ValidationGroup="GroupBthum" ErrorMessage="Minimum 2 and maximum 50 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtAltTag" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupBthum"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label"> Alternate Tag in Hindi </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtAltTagHindi" runat="server" ValidationGroup="GroupBthum" CssClass="form-control" MaxLength="100" autocomplete="off"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" SetFocusOnError="true" runat="server" ErrorMessage="Please enter browser title with one of the following special characters:(&/:'_-)"
                                            ControlToValidate="txtAltTagHindi" ValidationExpression="[\u0900-\u097F0-9a-zA-Z\s&/:'_-]+"
                                            ValidationGroup="GroupBthum" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtAltTagHindi" SetFocusOnError="true"
                                            ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{2,100}$" runat="server"
                                            ValidationGroup="GroupBthum" ErrorMessage="Minimum 2 and maximum 50 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                            ControlToValidate="txtAltTagHindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupBthum"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Upload Image
                  <label class="lblColor">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:FileUpload ID="ImageUploader" ValidationGroup="GroupBthum" runat="server" />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload"
                                            OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="ImageUploader"
                                            Display="Dynamic" ErrorMessage="Please select only .jpeg, .jpg, .png or .gif image."
                                            ValidationGroup="GroupBthum" ForeColor="Red"></asp:CustomValidator>
                    <%--<asp:Label ID="LblOldImage" runat="server" Text="Old Image:"></asp:Label>--%>
                    <asp:Label ID="LblImage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                    <br />
                    <em><span style="font-size: 8pt; font-weight: bold; color: #459300; font-family: Verdana">Tip: .jpeg .jpg .png or .gif image only. </span></em>
                    <div>
                      <asp:Label ID="LblImageUploader" runat="server" CssClass="red-text-asterix" ForeColor="#CC3300"></asp:Label>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  link url name:
                  <label class="lblColor"></label>
                  </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtLinkUrl" autocomplete="off" ValidationGroup="GroupBthum" runat="server" CssClass="form-control"></asp:TextBox>
                    <em><span style="font-size: 8pt; color: #459300; font-weight: bold; font-family: Verdana">Tip:-http://www.abc.com </span></em>
                    <asp:RegularExpressionValidator ID="RevLinkUrl" runat="server" ControlToValidate="txtLinkUrl" SetFocusOnError="true"
                                            Display="Dynamic" ErrorMessage="Please enter valid url" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
                                            ValidationGroup="GroupBthum" ForeColor="Red"></asp:RegularExpressionValidator>
                    <%--<asp:RequiredFieldValidator ID="RfvUrlName" runat="server" ControlToValidate="txtLinkUrl"
                                            ErrorMessage="Enter link url name" ValidationGroup="GroupBthum" Display="Dynamic" class="redtext" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                            ControlToValidate="txtLinkUrl" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupBthum"
                                            ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-12">
                  <div class="text-left">
                    <asp:Button ID="btnsave" runat="server" ValidationGroup="GroupBthum" Text="Save" OnClientClick="return validateData();" CssClass="btn btn-primary" OnClick="btnsave_Click" />
                    <asp:Button ID="btnBack" runat="server" ValidationGroup="GroupBthum" Text="Back" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnBack_Click" />
                  </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </ContentTemplate>
    <Triggers>
      <asp:PostBackTrigger ControlID="btnsave" />
    </Triggers>
  </asp:UpdatePanel>
</asp:Content>
