<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="LegalNotice.aspx.cs" Inherits="auth_Adminpanel_Enterform_LegalNotice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="col-lg-12 top20 bottom40">
        <div class="widgets-container">
            <h3>Legal Form</h3>
            <h5>Compliance of the Wildlife (Protection) Act, 1972 and the Scheduled Tribes & Other Traditional Forest Dwellers (Recognition of Forest Rights) Act, 2006</h5>
            <hr>
            <div class="form-horizontal">
                <div class="btn aqua col-sm-12 pull-left">
                    1. Core or Critical Tiger Habitat (CTH)
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Notified</label>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="DDLCTHNotified" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Date of Notification*	:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="TXTCTHDATEOFNOTIFICATION" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image3" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TXTCTHDATEOFNOTIFICATION"
                            Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                            ValidationGroup="ADD" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="TXTCTHDATEOFNOTIFICATION"
                            PopupButtonID="Image3" runat="server">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Area(Ha.)*</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="Txtctharea" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="red-text-asterix" ControlToValidate="Txtctharea"
                            Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
                            ValidationGroup="ADD">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>


                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="red-text-asterix" ValidationGroup="ADD" Display="Dynamic"
                             ControlToValidate="Txtctharea" ErrorMessage="Please Enter Area"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Compliance of section 38V of the Wildlife	(Protection) Act, 1972 *</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtCompliance_ofsection38V" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="red-text-asterix" ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtCompliance_ofsection38V" ErrorMessage="Please Enter WLPA Information"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <hr>
                <div class="btn aqua col-sm-12 pull-left">
                    2. 	Buffer or Peripheral Area
                </div>
                <hr />
                <div class="form-group">
                    <label class="col-lg-2 control-label">a. Notified *</label>
                    <div class="col-lg-2">
                        <asp:DropDownList ID="ddlbufferNotified" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-lg-2 control-label">b. Date of notification*	</label>
                    <div class="col-lg-4">
                        <asp:TextBox ID="txtbufferdateofnotification" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                    <div class="col-lg-2">
                        <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image1" runat="server" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtbufferdateofnotification"
                            Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                            ValidationGroup="ADD" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtbufferdateofnotification"
                            PopupButtonID="Image1" runat="server">
                        </cc1:CalendarExtender>
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">c Area(Ha.)</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtbufferarea" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtbufferarea"
                            CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Please Enter Only Decimal value up to 2 digit"
                            SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?" ValidationGroup="ADD">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator><%--  <asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" Cssclass="red-text-asterix" ValidationGroup="Login" Display="Dynamic" ControlToValidate="txtCaptcha" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>--%>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="red-text-asterix" 
                            ValidationGroup="ADD" Display="Dynamic" ControlToValidate="txtbufferarea" ErrorMessage="Please Enter Area"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">d Expert Committee	</label>

                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">i Constituted*	</label>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlexpert_Constituted" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                            <asp:ListItem Value="False">In-Progress</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">ii Date of Constitution *</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="expert_date_of_Constitution" runat="server" CssClass="form-control"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="expert_date_of_Constitution"
                            Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                            ValidationGroup="ADD" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                        <cc1:CalendarExtender ID="CalendarExtender6" Format="dd/MM/yyyy" TargetControlID="expert_date_of_Constitution"
                            PopupButtonID="Image6" runat="server">
                        </cc1:CalendarExtender>

                    </div>
                    <div class="col-sm-2">
                        <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image6" runat="server" />
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">e Consultation With Gram Sabha <span class="has-error">*	</span></label>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlConsultation_With_Gram_Sabha" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">f. Name of Gram Sabha</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtnameofgramsabha" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="red-text-asterix" ValidationGroup="ADD"
                             Display="Dynamic" ControlToValidate="txtnameofgramsabha" ErrorMessage="Please Enter Gram Shabha"></asp:RequiredFieldValidator>

                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 text-white aqua-bg">3 Map of CTH & Buffer or Peripheral Area.(jpg or .pdf files only)</label>
                    <div class="col-sm-10">
                        <asp:FileUpload ID="FUforiamge" runat="server" CssClass="form-group-lg" />
                        <asp:Label ID="lbldisplay" runat="server"></asp:Label>
                        <asp:HiddenField ID="hyddisplay" runat="server" />
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 text-white aqua-bg">4 Upload file:</label>
                    <div class="col-sm-10">
                        <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="#B4BA7E" />
                        <asp:Label ID="lblfile2" runat="server"></asp:Label>
                        <asp:HiddenField ID="hydfile2" runat="server" />
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 text-white aqua-bg">5 Upload file</label>
                    <div class="col-sm-8">
                        <asp:FileUpload ID="FileUpload2" runat="server" BorderColor="#B4BA7E" />
                        <asp:Label ID="lblfile3" runat="server"></asp:Label>
                        <asp:HiddenField ID="hydfile3" runat="server" />
                    </div>
                </div>
                <hr>
                <div class="form-group ">

                    <div class="col-sm-12 btn aqua-bg text-white">
                        6  Recognition / Determination/ Acquisition / Vesting of Forest Rights of Schedule Tribes & such other Traditional Forest Dwellers
                    </div>
                </div>
                <hr>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Completed</label>
                    <div class="col-sm-4">

                        <asp:DropDownList ID="ddlForest_Dwellers_Completed" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr>

                <div class="form-group ">

                    <div class="col-sm-12 btn aqua-bg text-white">
                        7  Re-settlement or Alternative Package
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <label class="col-sm-2 control-label">Provided</label>
                    <div class="col-sm-4">

                        <asp:DropDownList ID="ddl_Re_settlement_Provided" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr>
                <div class="form-group ">

                    <div class="col-sm-12 btn aqua-bg text-white">
                        8  Free informed consent of Gram Sabha to the Resettlement Programme.
                    </div>
                </div>
                <hr>

                <div class="form-group">
                    <label class="col-sm-2 control-label">Obtained</label>
                    <div class="col-sm-4">

                        <asp:DropDownList ID="ddlResettlement_Obtained" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr>
                <div class="form-group ">
                    <div class="col-sm-12 btn aqua-bg text-white">
                        9 Voluntary consent of individuals affected
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <label class="col-sm-2 control-label">Obtained</label>
                    <div class="col-sm-4">

                        <asp:DropDownList ID="ddlVoluntary_Obtained" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr>
                <div class="form-group ">
                    <div class="col-sm-12 btn aqua-bg text-white">
                        10 Facilities & Land Allocation At The Resettlement Location
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <label class="col-sm-2 control-label">Provided</label>
                    <div class="col-sm-4">

                        <asp:DropDownList ID="ddl_Facilities_Provided" runat="server" CssClass="form-control">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <hr>
                <div class="form-group ">
                    <div class="col-sm-12 btn aqua-bg text-white">
                        11 Sub- divisional, District and State � level committees for monitoring of village relocation process & grievance redressal.
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <label class="col-sm-2 control-label">a Sub Divisional Level Committee</label>
                   
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Constituted</label>
                    <div class="col-sm-4">

                         <asp:DropDownList ID="ddlSub_DivisionalConstituted" runat="server" CssClass="form-control" 
                                                   >
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                    <asp:ListItem Value="2">In-Progress</asp:ListItem>
                                                </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Date of constitution</label>
                    <div class="col-sm-4">

                         <asp:TextBox ID="txtSub_Divisional_Date_of_constitution" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image2" runat="server" />
                                                  <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" 
                             TargetControlID="txtSub_Divisional_Date_of_constitution"
                            PopupButtonID="Image2" runat="server">
                        </cc1:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtSub_Divisional_Date_of_constitution"
                                                    CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate"
                                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                    ValidationGroup="ADD"></asp:RegularExpressionValidator>
                    </div>
                </div>


                
                <div class="form-group">
                    <label class="col-sm-2 control-label">b District Level Committee</label>
                   
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Constituted</label>
                    <div class="col-sm-4">

                         <asp:DropDownList ID="ddlDistrict_Level_Committee_Constituted" runat="server" CssClass="form-control" AutoPostBack="True"
                                                   >
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                    <asp:ListItem Value="2">In-Progress</asp:ListItem>
                                                </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Date of constitution</label>
                    <div class="col-sm-4">

                         <asp:TextBox ID="txtDistrict_Level_Committee_Date_of_constitution" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image4" runat="server" />
                          <cc1:CalendarExtender ID="CalendarDistrict_Level_Committee_Date_of_constitution" Format="dd/MM/yyyy" 
                             TargetControlID="txtDistrict_Level_Committee_Date_of_constitution"
                            PopupButtonID="Image4" runat="server">
                        </cc1:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtDistrict_Level_Committee_Date_of_constitution"
                                                    CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate"
                                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                    ValidationGroup="ADD"></asp:RegularExpressionValidator>
                    </div>
                </div>


                
                <div class="form-group">
                    <label class="col-sm-2 control-label">c State Level Monitoring Committee.</label>
                   
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">Constituted</label>
                    <div class="col-sm-4">

                         <asp:DropDownList ID="ddlState_Level_Monitoring_Committee_Constituted" runat="server" CssClass="form-control" AutoPostBack="True"
                                                   >
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                    <asp:ListItem Value="2">In-Progress</asp:ListItem>
                                                </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label ">Date of constitution</label>
                    <div class="col-sm-4">

                         <asp:TextBox ID="txtState_Level_Monitoring_Committee_Date_of_constitution" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image5" runat="server" />
                         <cc1:CalendarExtender ID="CalendarState_Level_Monitoring_Committee_Date_of_constitution" Format="dd/MM/yyyy" 
                             TargetControlID="txtState_Level_Monitoring_Committee_Date_of_constitution"
                            PopupButtonID="Image5" runat="server">
                        </cc1:CalendarExtender>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtState_Level_Monitoring_Committee_Date_of_constitution"
                                                    CssClass="red-text-asterix" Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate"
                                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                                    ValidationGroup="ADD"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-sm-4 col-sm-offset-2">
                        
      <asp:Button ID="ImgbtnSubmit" runat="server" Text="Save" ValidationGroup="ADD" CssClass="btn btn-primary" OnClick="ImgbtnSubmit_Click" />
                                        <asp:Button ID="imgbtnreset" runat="server" Text="Reset" CausesValidation="false" CssClass="btn btn-warning" OnClick="imgbtnreset_Click" />
                                        <asp:Button ID="btnback" runat="server" Text="Back" CausesValidation="false" CssClass="btn aqua" OnClick="btnback_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

