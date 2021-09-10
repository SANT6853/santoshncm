<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ReplyFromReserveToDfo.aspx.cs" Inherits="auth_Adminpanel_ProcessManegment_ReserveUser_ReplyFromReserveToDfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
         .red-text {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <div class="ibox-title">
                        <h5>
                           Reply
                        </h5>
                    </div>

                     <div style="text-align:center;">
                        <h3>
                            <asp:Label id="Lblmsg" runat="server"></asp:Label>
                        </h3>
                    </div>
                    <hr>

                    <div class="col-lg-12 top20 bottom40">
                       
                        <div class="widgets-container">
                             
                            <div class="row">
                                <!-- tabs -->
                                <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                        
                                       
                                    </label>
                                   
                                </div>
                                <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                        Token/Ticket Id(Generate automatic):</label>
                                    <div class="form-group col-md-8">
                                        <asp:Label ID="LblTokenID" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                        Apply Date:</label>
                                    <div class="form-group col-md-8">
                                        <asp:Label ID="lblapplydate" runat="server" Text=""></asp:Label>
                                       
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                        Village Name:</label>
                                    <div class="form-group col-md-8">
                                        <asp:Label ID="LblVillageName" runat="server" Text=""></asp:Label>
                                       
                                    </div>
                                </div>
                                 <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                       Status:</label>
                                    <div class="form-group col-md-8">
                                          <asp:DropDownList ID="DDlStatus" runat="server" CssClass="form-control" Width="250px">
                                   
                                   <%-- <asp:ListItem Text="Pending" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Verified" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Approved" Value="3"></asp:ListItem>
                                     <asp:ListItem Text="Rejected" Value="4"></asp:ListItem>--%>
                                </asp:DropDownList>
                                       
                                    </div>
                                </div>
                                 <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                      Requested Amount in(Rs):</label>
                                    <div class="form-group col-md-8">
                                      
                                      <asp:Label ID="LblRequestedAmount" runat="server"></asp:Label>
                                    </div>
                                </div>
                                 <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                      Previous Accepted Amount in(Rs) :</label>
                                    <div class="form-group col-md-8">
                                      
                                      <asp:Label ID="LblPreviousAcceptedAmount" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                      Accepted Amount in(Rs) <span class="red-text">*</span>:</label>
                                    <div class="form-group col-md-8">
                                      
                                       <asp:TextBox ID="txtAcceptedAmount" runat="server" CssClass="form-control" autocomplete="off" MaxLength="100" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" autocomplete="off" Display="Dynamic" CssClass="help-block"
                                            SetFocusOnError="true" ControlToValidate="txtAcceptedAmount" ForeColor="Red"
                                            ValidationGroup="val" ErrorMessage="Enter Accepted Amount in Rs" />

                                        <asp:RegularExpressionValidator ID="regamount" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" SetFocusOnError="true" ControlToValidate="txtAcceptedAmount" ForeColor="Red"
                                            ValidationGroup="val" ErrorMessage="Enter valid Accepted Amount with 2 digit decimal value" />
                                    </div>
                                </div>
                                  <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                       Description:</label>
                                    <div class="form-group col-md-8">
                                        <asp:Label ID="LblDescrption" runat="server" Text=""></asp:Label>
                                       
                                    </div>
                                </div>
                                 <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                        Apply by:</label>
                                    <div class="form-group col-md-8">
                                        <asp:Label ID="LblReportingManager" runat="server" Text=""></asp:Label>
                                       
                                    </div>
                                </div>
                                 
                                <div class="col-md-12">
                                    <label class="col-sm-2 control-label">
                                        Comment <span class="red-text">*</span>:</label>
                                    <div class="form-group col-md-8">
                                        <asp:TextBox ID="txtfunddescription" TextMode="MultiLine" autocomplete="off" runat="server" MaxLength="500" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" CssClass="help-block"
                                            SetFocusOnError="true" ControlToValidate="txtfunddescription" ForeColor="Red"
                                            ValidationGroup="val" ErrorMessage="Enter Comment" />
                                        <asp:RegularExpressionValidator Display = "Dynamic" ValidationGroup="val" ControlToValidate = "txtfunddescription" ForeColor="Red" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{10,500}$" runat="server" ErrorMessage="Your Comment will be Minimum 10 and Maximum 500 characters required."></asp:RegularExpressionValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter only alphanumeric values,don't use any special character."
                                ControlToValidate="txtfunddescription" Display="Dynamic" SetFocusOnError="true" ValidationGroup="val"
                                ValidationExpression="^([\u0900-\u097FA-Za-z0-9-*_' .:,()/\s]*)$" CssClass="help-block" ForeColor="Red"></asp:RegularExpressionValidator>
                                        
                                         </div>
                                </div>

                                

                                <div class="clearfix">
                                </div>
                                <div class="col-md-6 pull-right">
                                    <asp:Button ID="btnsumbit" runat="server" Text="Reply" ValidationGroup="val"
                                        CssClass="btn btn-primary center" OnClick="btnsumbit_Click"  />
                                    <asp:Button ID="BtnBack" runat="server" Text="Back" CausesValidation="false"
                                        CssClass="btn btn-primary center" OnClick="BtnBack_Click"  />
                                    
                                </div>
                              
                                <!-- tabs -->
                                <!-- start footer -->
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>

