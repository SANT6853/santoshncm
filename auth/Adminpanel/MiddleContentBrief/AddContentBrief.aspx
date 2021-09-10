<%@ Page Title="NTCA:Add middle content" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master"  AutoEventWireup="true" CodeFile="AddContentBrief.aspx.cs" Inherits="auth_Adminpanel_MiddleContentBrief_AddContentBrief" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style>
.control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left !important;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
        <div class="wrapper-content">
          <div class="inner-content-right">
            <div class="box box-primary1" style="margin-bottom: 25px;">
              <div class="box-header with-border">
                <h3 class="box-title" style="color: #005529;">Add Middle Content</h3>
              </div>
            </div>
            <div class="form-horizontal">
              <asp:HiddenField ID="hfpwd" runat="server" />
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Select Site
                  <label style="color: red;"></label>
                  </label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlwebsite" AutoPostBack="true" Enabled="false" runat="server" ValidationGroup="GroupCbrief" CssClass="form-control"
                                                    OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged">
                      <asp:ListItem Value="1">Mainsite</asp:ListItem>
                      <%--<asp:ListItem Value="2">Tiger Reserve</asp:ListItem>--%>
                    </asp:DropDownList>
                  </div>
                </div>
              </div>
              <div class="col-md-6" id="divstate" runat="server" visible="false">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  State
                  <label style="color: red;"></label>
                  </label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" ValidationGroup="GroupCbrief"
                                                    CssClass="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged1"> </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block" ControlToValidate="ddlState" ValidationGroup="GroupCbrief"
                                                    ErrorMessage="Select State" InitialValue="Select State" ForeColor="Red" />
                  </div>
                </div>
              </div>
              <div class="col-md-6" id="divTigerReserve" runat="server" visible="false">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Select Tiger Reserve
                  <label style="color: red;"></label>
                  </label>
                  <div class="col-md-8">
                    <asp:DropDownList ID="ddlTigerReserve" runat="server" ValidationGroup="GroupCbrief" CssClass="form-control"> </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" SetFocusOnError="true" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlTigerReserve" ValidationGroup="GroupCbrief"
                                                    ErrorMessage="Select tiger reserve" InitialValue="Select Tiger Reserve" />
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
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" ValidationGroup="GroupCbrief" MaxLength="50" ForeColor="Red"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block" ControlToValidate="txtTitle" ValidationGroup="GroupCbrief"
                                                    ErrorMessage="Enter page title" ForeColor="Red" />
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="txtTitle" SetFocusOnError="true"
                                                    ID="regPageTitleLength" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                                    ValidationGroup="GroupCbrief" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="regPageTitle" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="txtTitle" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupCbrief"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <%--start 22march2018--%>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Short details
                  <label style="color: red;">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="TxtSmallDetails" runat="server" ValidationGroup="GroupCbrief" CssClass="form-control" MaxLength="250"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block" ControlToValidate="TxtSmallDetails" ValidationGroup="GroupCbrief"
                                                    ErrorMessage="Enter short details" ForeColor="Red" />
                    <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TxtSmallDetails" SetFocusOnError="true"
                                                    ID="REVSamllDetailsLength" ValidationExpression="^[\s\S]{2,250}$" runat="server"
                                                    ValidationGroup="GroupCbrief" ErrorMessage="Minimum 2 and maximum 250 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="REVsmallDetailsValidation" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="TxtSmallDetails" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupCbrief"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <%--end 22march2018--%>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label">
                  Title in Hindi
                  <label style="color: red;">*</label>
                  </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtTitleHindi" runat="server" ValidationGroup="GroupCbrief" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block" ControlToValidate="txtTitleHindi" ValidationGroup="GroupCbrief"
                                                    ErrorMessage="Enter page title" ForeColor="Red" />
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtTitleHindi"
                                                    ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{2,100}$" runat="server"
                                                    ValidationGroup="GroupCbrief" ErrorMessage="Minimum 2 and maximum 50 characters required." CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="txtTitleHindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupCbrief"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label"> Alternate Tag </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtAltTag" runat="server" ValidationGroup="GroupCbrief" CssClass="form-control" MaxLength="50"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RevBrowserTitle" SetFocusOnError="true" runat="server" ErrorMessage="Please enter browser title with one of the following special characters:(&/:'_-)"
                                                    ControlToValidate="txtAltTag" ValidationExpression="[\u0900-\u097F0-9a-zA-Z\s&/:'_-]+"
                                                    ValidationGroup="GroupCbrief" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtAltTag"
                                                    ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{2,50}$" runat="server"
                                                    ValidationGroup="GroupCbrief" ErrorMessage="Minimum 2 and maximum 50 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="Regullidator3" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="txtAltTag" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupCbrief"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-6">
                <div class="form-group">
                  <label class="col-sm-4 control-label"> Alternate Tag in Hindi </label>
                  <div class="col-md-8">
                    <asp:TextBox ID="txtAltTagHindi" runat="server" ValidationGroup="GroupCbrief" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" SetFocusOnError="true" runat="server" ErrorMessage="Please enter browser title with one of the following special characters:(&/:'_-)"
                                                    ControlToValidate="txtAltTagHindi" ValidationExpression="[\u0900-\u097F0-9a-zA-Z\s&/:'_-]+"
                                                    ValidationGroup="GroupCbrief" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtAltTagHindi"
                                                    ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{2,100}$" runat="server"
                                                    ValidationGroup="GroupCbrief" ErrorMessage="Minimum 2 and maximum 50 characters required." ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                                    ControlToValidate="txtAltTagHindi" Display="Dynamic" SetFocusOnError="true" ValidationGroup="GroupCbrief"
                                                    ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                  </div>
                </div>
              </div>
              <div class="col-md-12">
                <div class="form-group">
                  <label class="col-sm-12 control-label">
                  Page Description
                  <label style="color: red;">*</label>
                  </label>
                  <div class="col-md-12">
                    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" ToolbarSet="Basic" BasePath="~/fckeditor/"
                                                    Height="400" Width="100%"> </FCKeditorV2:FCKeditor>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" SetFocusOnError="true" CssClass="help-block" ControlToValidate="FCKeditor1" ValidationGroup="GroupCbrief"
                                                    ErrorMessage="Enter page Description" ForeColor="Red" />
                  </div>
                </div>
              </div>
              <div class="clearfix"></div>
              <div class="col-md-12">
                <div class="form-group">
                  <div class="col-md-12">
                    <asp:Button ID="btnsave" runat="server" ValidationGroup="GroupCbrief" Text="Save" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnsave_Click" />
                    <asp:Button ID="btnBack" runat="server" ValidationGroup="GroupCbrief" Text="Back" OnClientClick="return getPass();" CssClass="btn btn-primary" OnClick="btnBack_Click" />
                  </div>
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
