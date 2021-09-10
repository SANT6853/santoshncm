<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="AddNGO.aspx.cs" Inherits="auth_Adminpanel_NGO_Management_AddNGO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
   <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <h5>All form elements </h5>
                    <hr>
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Name of NGO</label>
                            <div class="col-sm-3">
                              <asp:TextBox ID="txtNGOName" runat="server" placeholder="Enter NGO Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                       
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Address</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtAddress" runat="server" Height="50" placeholder="Enter Address" CssClass="form-control"></asp:TextBox>
                            </div>
                           
                        </div>
                       <div class="form-group">
                            <label class="col-sm-2 control-label">State
                            </label>
                            <div class="col-sm-3"> 
                              <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"></asp:DropDownList>

                                
                            </div>

                        </div>

                         <div class="form-group">
                            <label class="col-sm-2 control-label">Phone Number
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtPhoneNumber"  ValidationGroup="val" 
                                    ErrorMessage="Enter phone number" />

                               
                            </div>

                        </div>
                            <div class="form-group">
                            <label class="col-sm-2 control-label">Mobile Number
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block"  ControlToValidate="txtMobileNumber"  ValidationGroup="val" 
                                    ErrorMessage="Enter mobile number" />

                                
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Work Done by NGO
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="txtWorkDonebyNGO" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50"></asp:TextBox>
                                

                                
                            </div>

                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Remarks
                            </label>
                            <div class="col-sm-3"> 
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="MultiLine" Height="50"></asp:TextBox>
                                

                                
                            </div>

                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Attachments 
                            </label>
                            <div class="col-sm-3">
                                <asp:FileUpload ID="FileUploader" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredImage" runat="server" ControlToValidate="FileUploader"
                                    Display="Dynamic" ErrorMessage="Please Enter Image" SetFocusOnError="True" ValidationGroup="val">
                                </asp:RequiredFieldValidator>
                             
                                <asp:CustomValidator ID="CustomValidator1" runat="server"
                                    ClientValidationFunction="ValidateFileUpload" ControlToValidate="FileUploader"
                                    Display="Dynamic"
                                    ErrorMessage="Please select only .jpeg, .jpg, .png or .gif image."
                                    OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="val">
                                </asp:CustomValidator>
                            </div>

                        </div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="btnsave" runat="server" ValidationGroup="val" Text="Save" OnClientClick="return getPass();" CssClass="btn aqua" OnClick="btnsave_Click" />
                                    <asp:Button ID="btnBack" runat="server" ValidationGroup="val" Text="Back" OnClientClick="return getPass();" CssClass="btn aqua" OnClick="btnBack_Click" />
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  
</asp:Content>

