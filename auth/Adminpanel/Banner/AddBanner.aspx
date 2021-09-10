<%@ Page Title="NTCA:Banner" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddBanner.aspx.cs" Inherits="auth_Adminpanel_Banner_AddBanner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style>
.control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left !important;
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
		var fuData = document.getElementById('<%= ImageUploader.ClientID %>');
		var FileUploadPath = fuData.value;
		if (FileUploadPath == '') {
			// There is no file selected
			args.IsValid = false;
		}
		else {
			var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
			//  alert(Extension);
			if (Extension == "jpg" || Extension == "JPG" || Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "PNG" || Extension == "swf" || Extension == "SWF") {
				args.IsValid = true; // Valid file type
			}
			else {
				//  alert('tet');
				args.IsValid = false; // Not valid file type
			}
		}
	}
	$(document).ready(function () {
	});

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  
      <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
        <div class="wrapper-content">
          <div class="inner-content-right">
            <div class="box box-primary1" style="margin-bottom: 25px;">
              <div class="box-header with-border">
                <h3 class="box-title" style="color: #005529;">Add Banner</h3>
              </div>
            </div>
            <div class="form-horizontal">
              <asp:HiddenField ID="hfpwd" runat="server" />
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">Select Site</label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlwebsite" ValidationGroup="GroupBanner" AutoPostBack="true" runat="server" CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged">
                      <asp:ListItem Value="1">Mainsite</asp:ListItem>
                      <asp:ListItem Value="2">Tiger Reserve</asp:ListItem>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6" id="divstate" runat="server" visible="false">
                <div class="form-group">
                  <label class="col-sm-4 control-label">State</label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlState" runat="server" ValidationGroup="GroupBanner" AutoPostBack="true"
                                                    CssClass="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged1"> </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="GroupBanner"
                                                    ErrorMessage="Select State" InitialValue="0" ForeColor="Red" />
                  </div>
                </div>
              </div>
              <div class="col-md-6" id="divTigerReserve" runat="server" visible="false">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Select Tiger Reserve
                  <label style="color: red;">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlTigerReserve" runat="server" ValidationGroup="GroupBanner" CssClass="form-control"> </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="GroupBanner"
                                                    ErrorMessage="Select tiger reserve" InitialValue="0" ForeColor="Red" />
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Title
                  <label style="color: red;">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtTitle" runat="server" ValidationGroup="GroupBanner" CssClass="form-control" MaxLength="200" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block" ControlToValidate="txtTitle" ValidationGroup="GroupBanner"
                                                    ErrorMessage="Enter page title" ForeColor="Red" />
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTitle" SetFocusOnError="true"
                                                    ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                                    ValidationGroup="GroupBanner" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character even space."
                                                    ControlToValidate="txtTitle" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupBanner"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_'.:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Upload Image
                  <label style="color: red;">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:FileUpload ID="ImageUploader" runat="server" ValidationGroup="GroupBanner" />
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupBanner" ErrorMessage="Please upload." ControlToValidate="ImageUploader" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" SetFocusOnError="true" ClientValidationFunction="ValidateFileUpload1"
                                                    OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="ImageUploader"
                                                    Display="Dynamic" ErrorMessage="Please select only .jpeg, .jpg, .png or .gif or .swf image."
                                                    ValidationGroup="GroupBanner" ForeColor="Red"></asp:CustomValidator>
                    <%-- <asp:Label ID="LblOldImage" runat="server" Text="Old Image:"></asp:Label>--%>
                    <asp:Label ID="LblImage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                    <br />
                    <em><span style="font-size: 8pt; font-weight: bold; color: #459300; font-family: Verdana">Tip: .jpeg .jpg .png or .gif,swf image only.For better resolution  height=336 width=1366 </span></em> </div>
                </div>
              </div>
              <div class="col-md-12">
                <div class="form-group">
                  <div class="col-sm-12">
                    <asp:Label ID="LblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Button ID="btnsave" runat="server" ValidationGroup="GroupBanner" Text="Save" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnsave_Click" />
                    <asp:Button ID="btnBack" runat="server" Visible="false" Text="Back" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnBack_Click" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
   
</asp:Content>
