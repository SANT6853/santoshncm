<%@ Page Title="NTCA:Logo Banner" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddBanner.aspx.cs" Inherits="auth_Adminpanel_Banner_AddBanner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style>
.control-label {
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
               args.IsValid = false;
           }
           else {
               var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();

               if (Extension == "jpg" || Extension == "JPG" || Extension == "jpeg" || Extension == "JPEG" || Extension == "png" || Extension == "PNG")
               {
                   args.IsValid = true; 
               }
               else {
                   args.IsValid = false; 
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
            <h3 class="box-title" style="color: #005529;">Add Logo Banner </h3>
          </div>
        </div>
        <div class="form-horizontal">
          <asp:HiddenField ID="hfpwd" runat="server" />
          <div class="col-md-6">
            <div class="form-group">
              <label class="col-sm-4 control-label">Select Language</label>
              <div class="col-md-8">
                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
                  <asp:ListItem Value="1">English</asp:ListItem>
                  <asp:ListItem Value="2">Hindi</asp:ListItem>
                </asp:DropDownList>
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
                <asp:FileUpload ID="ImageUploader" runat="server" ValidationGroup="val" CssClass="form-control" />
                <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload1"
                                            OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="ImageUploader"
                                            Display="Dynamic" ErrorMessage="Please select only .jpeg, .jpg, .png or .gif image(malicious file will not be allow.)."
                                            ValidationGroup="val" ForeColor="Red"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="rfvFileupload" ValidationGroup="val" runat="server"
                                            ControlToValidate="ImageUploader" Text="Please upload any one of type .jpeg, .jpg, .png or .gif image." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:Label ID="LblImage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                <br />
                <em><span style="font-size: 8pt; font-weight: bold; color: #459300; font-family: Verdana">Tip: .png or width 1176 X 183 for better resolution </span></em> </div>
            </div>
          </div>
          <div class="col-md-12">
              <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Save" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnsave_Click" />
              <asp:Button ID="btnBack" runat="server" Visible="false" ValidationGroup="val" Text="Back" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnBack_Click" />
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
