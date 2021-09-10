<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="family-welfare.aspx.cs" Inherits="auth_Adminpanel_Familymanegment_family_welfare" %>
<%@ Register src="../../../UserControl/HeadingControl.ascx" tagname="HeadingControl" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 650px;
			padding-bottom: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="col-lg-12 top20 bottom40">
     <div class="widgets-container">
    <div class="row">

       
       

        <!-- tabs -->
        
                     <uc1:HeadingControl ID="heading1" runat="server" Heading="Family Welfare" />

                    <div class="col-md-6">

                        <label class="col-sm-4 control-label" >Select State</label>
                        <div class="form-group col-md-8">
                            <asp:DropDownList ID="ddlstate" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="reqstate" Display="Dynamic" CssClass="help-block" ForeColor="Red" InitialValue="0" ControlToValidate="ddlstate" SetFocusOnError="true" ValidationGroup="val"
                                ErrorMessage="Select State" />
                        </div>
                    </div>
                    <div class="col-md-6">

                        <label class="col-sm-4 control-label">Select Tiger Reserves</label>
                        <div class="form-group col-md-8">

                            <asp:DropDownList ID="ddltigerreserve" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddltigerreserve_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="reqddltiger" Display="Dynamic" ForeColor="Red" CssClass="help-block" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddltigerreserve" ValidationGroup="val"
                                ErrorMessage="Select Tiger Reserve" />
                        </div>
                    </div>
                    <div class="col-md-6">

                        <label class="col-sm-4 control-label" >Select Village Name</label>
                        <div class="form-group col-md-8">
                            <asp:DropDownList ID="ddlvillage" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlvillage_SelectedIndexChanged" />
                            <asp:RequiredFieldValidator ID="reqddlvillage" runat="server" Display="Dynamic" CssClass="help-block" InitialValue="0"
                                SetFocusOnError="true" ControlToValidate="ddlvillage" ForeColor="Red" ValidationGroup="val"
                                ErrorMessage="Select Village" />

                        </div>
                    </div>
                    <div class="col-md-6">
                       
                       
                            <label class="col-sm-4 control-label">Survey Date</label>
                            <div class="col-sm-8 form-group">
                                <asp:TextBox ID="txtsurveydate" runat="server" CssClass="form-control" /> 
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtsurveydate"
                                Display="Dynamic" ErrorMessage="Please Enter Date Of Survey" SetFocusOnError="True"
                                 CssClass="red-text-asterix"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidatorsurvey" runat="server" ControlToValidate="txtsurveydate"
                                Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                 CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtsurveydate"
                                PopupButtonID="txtsurveydate" runat="server">
                            </cc1:CalendarExtender>
                            </div>
                     

                       
                    </div>
                          <div class="col-md-6">

                            <label for="villageName" class="col-sm-4 control-label">Option Selected</label>
                            <div class="form-group col-md-8">
                                <asp:DropDownList ID="ddloptionSelected" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select Option</asp:ListItem>
                                    <asp:ListItem Value="1">I Option</asp:ListItem>
                                    <asp:ListItem Value="2">II Option</asp:ListItem>
                                    <asp:ListItem Value="3">No Option</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    <div class="col-md-6">
                   
                        <label class="col-sm-4 control-label">Legal Status</label>
                        <div class="col-sm-8 form-group">
                            <asp:DropDownList ID="ddlLegalStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Revenue</asp:ListItem>
                                <asp:ListItem Value="2">Forest</asp:ListItem>
                                <asp:ListItem Value="3">Others</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLegalStatus" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlLegalStatus" ValidationGroup="val"
                                ErrorMessage="Select value" />
                        </div>

                   
                </div>
                        <uc1:HeadingControl ID="HeadingControl1" runat="server" Heading="Reallocation Details" />
                  
                    <div class="col-md-6">
                        <div class="clearfix"></div>
                       
                            <label class="col-sm-4 control-label">District</label>
                            <div class="col-sm-8 form-group">
                                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvDistrict" runat="server" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlDistrict" ValidationGroup="val"
                                    ErrorMessage="Select value" />
                            </div>

                      
                    </div>
                    <div class="col-md-6">
                        
                            <label class="col-sm-4 control-label">Tehshil</label>
                            <div class="col-sm-8 form-group">
                                <asp:DropDownList ID="ddlTehshiil" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTehshiil_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvTehshil" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlTehshiil" ValidationGroup="val"
                                    ErrorMessage="Select value" />
                           

                        </div>
                    </div>
                    <div class="col-md-6">
                        
                            <label class="col-sm-4 control-label">GramPanchayat</label>
                            <div class="col-sm-8 form-group">
                                <asp:DropDownList ID="ddlGramPanchayat" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGramPanchayat_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvGramPanchayat" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlGramPanchayat" ValidationGroup="val"
                                    ErrorMessage="Select value" />
                            </div>

                        
                    </div>
                    <div class="col-md-6">
                        
                            <label class="col-sm-4 control-label">Area</label>
                            <div class="col-sm-8 form-group">
                                <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Core Area</asp:ListItem>

                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ID="rfvArea" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlArea" ValidationGroup="val"
                                    ErrorMessage="Select value" />
                            </div>

                        
                    </div>
                    <div class="col-md-6">

                        <label class="col-sm-4 control-label" for="villageName">Family Head Name</label>
                        <div class="form-group col-md-8">

                            <asp:TextBox ID="txtheadname" CssClass="form-control" runat="server" placeholder="Enter Family Head Name" />
                            <asp:RequiredFieldValidator ID="reqheadname" runat="server" ForeColor="Red" ControlToValidate="txtheadname"
                                SetFocusOnError="true" ValidationGroup="val" ErrorMessage="Please enter family head name" />
                        </div>
                    </div>


                    <div class="col-md-6">
                        <label class="col-sm-4 control-label" for="villageName">Agriculture Land (Ha)</label>
                        <div class="form-group col-md-8">
                            <asp:TextBox ID="txtagricultureland" CssClass="form-control" runat="server" placeholder="Agriculture property (Ha)" />
                            <asp:RegularExpressionValidator ID="RegexAgriculture" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
                                ControlToValidate="txtagricultureland" ValidationGroup="val" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label class="col-sm-4 control-label" for="villageName">Residential property (Ha)</label>
                        <div class="form-group col-md-8">


                            <asp:TextBox ID="txtresidentialPropery" CssClass="form-control" runat="server" placeholder="Residential property (Ha)" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                ErrorMessage="Please enter valid integer or decimal number with 2 decimal places."
                                ControlToValidate="txtresidentialPropery" ValidationGroup="val" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />

                        </div>
                    </div>
                    <div class="col-md-6">
                        
                            <label class="col-sm-4 control-label">Status of Residence(Kacha/Pakka)</label>
                            <div class="col-sm-8 form-group">
                                <asp:DropDownList ID="ddlhousestatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select Residence Status  </asp:ListItem>
                                    <asp:ListItem Value="1">Kacha</asp:ListItem>
                                    <asp:ListItem Value="1">Pakka</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" CssClass="help-block"
                                    InitialValue="0" ControlToValidate="ddlhousestatus" ValidationGroup="val"
                                    ErrorMessage="Select value" />
                            </div>

                       
                    </div>
                    <div class="col-md-6">
                       
                            <label class="col-sm-4 control-label" for="exampleFormControlSelect1">Reallocation Place</label>
                            <div class="form-group col-md-8">
                                <asp:TextBox ID="txtreallocationPlace" runat="server" CssClass="form-control" />

                            </div>
                        
                    </div>

                    <div class="col-md-6">
                        <label class="col-sm-4 control-label" for="villageName">Total Livestock</label>
                        <div class="form-group col-md-8">

                            <asp:TextBox ID="txtlivestock" CssClass="form-control" runat="server" MaxLength="4" placeholder="EnterTotal Livestock" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^[0-9]{0,4}$"
                                ErrorMessage="Please enter valid numeric value."
                                ControlToValidate="txtlivestock" ValidationGroup="val" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label class="col-sm-4 control-label" for="villageName">Total Well</label>
                        <div class="form-group col-md-8">

                            <asp:TextBox ID="txttotalwell" CssClass="form-control" runat="server" MaxLength="4" placeholder="Enter Total Well" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="^[0-9]{0,4}$"
                                ErrorMessage="Please enter valid numeric value."
                                ControlToValidate="txttotalwell" ValidationGroup="val" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <label class="col-sm-4 control-label" for="villageName">Total Tree</label>
                        <div class="form-group col-md-8">

                            <asp:TextBox ID="txttree" CssClass="form-control" runat="server" MaxLength="4" placeholder="EnterTotal Tree" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="^\d$"
                                ErrorMessage="Please enter valid numeric value."
                                ControlToValidate="txttree" ValidationGroup="val" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                        </div>
                        </div>
                        <div class="col-md-6">

                            <label for="villageName" class="col-sm-4 control-label">Latitude GPS coordinates</label>
                            <div class="form-group col-md-8">
                                <asp:TextBox ID="txtLatitudeCurrent" runat="server" CssClass="form-control" placeholder="Latitude ie:- 28.568739" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <label for="villageName" class="col-sm-4 control-label">Longitude GPS coordinates </label>
                            <div class="form-group col-md-8">
                                <asp:TextBox ID="txtLongitudecurrent" runat="server" CssClass="form-control" placeholder="Longitude ie:-38.568739" />

                            </div>
                        </div>
                        <div class="col-md-6">
                            <label class="col-sm-4 control-label" for="exampleFormControlTextarea1">Other Assets</label>
                            <div class="form-group col-md-8">

                                <asp:TextBox ID="txtotherassest" runat="server" TextMode="MultiLine" CssClass="form-control" MaxLength="400" />
                            </div>
                        </div>
                  
                   
        <uc1:HeadingControl ID="HeadingControl3" runat="server" Heading="Animal Details" />
                        <div class="col-md-12">
                            <div class="form-group multiple-form-group col-md-6" data-max="3">
                                

                                <div class="form-group input-group">
                                    <div class="row">
                                        <asp:GridView ID="grdAnimal" CssClass="table tabbable-line" GridLines="None" runat="server" ShowFooter="true"
                                             AutoGenerateColumns="false" OnRowDataBound="grdAnimal_RowDataBound" OnRowCommand="grdAnimal_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.no">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex+1 %>
                                                        <asp:HiddenField ID="hydindex" runat="server" Value='<%# Eval("ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Animal">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hydanimaltype" runat="server" Value='<%# Eval("AnimalType") %>' />
                                                        <asp:Label ID="lblanimal" runat="server" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:DropDownList ID="ddlAnimal" CssClass="form-control" runat="server" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No of Animal">
                                                    <ItemTemplate>
                                                        <%# Eval("NOofAnimal") %>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:TextBox ID="txtnoofanimal" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="reqnoofanimal" ValidationGroup="valanimal" ForeColor="Red" runat="server" ControlToValidate="txtnoofanimal"
                                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^\d+$"
                                                            ErrorMessage="Please enter valid numeric value."
                                                            ControlToValidate="txtnoofanimal" ValidationGroup="valanimal" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" />
                                                    </FooterTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnremove" runat="server" CssClass="btn btn-primary btn-default btn-danger btn-remove" CommandName="removeRecord" CommandArgument='<%# Eval("RowNumber") %>' Text="X" />
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="ButtonAdd" ValidationGroup="valanimal" CssClass="btn btn-primary btn-add" runat="server" Text="Add New Row"
                                                            OnClick="ButtonAdd_Click" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </div>

                                </div>
                            </div>
                        </div>
                  
         <uc1:HeadingControl ID="HeadingControl2" runat="server" Heading="Family Member Details" />
                       
                       
                       <div class="col-md-12">
                       <div class="col-md-6  pull-right">
                       
                            <asp:Button ID="btnaddmember" runat="server" Text="Add Member" CssClass="btn btn-primary pull-right" />
                        </div>
                        
                        <div class="col-md-6 text-left">

                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="val" CssClass="btn btn-success" OnClick="btnsubmit_Click" />
                        </div>
                        </div>
                        
                        
                        <div class="col-md-12">

                            <div class="col-md-12 text-center">
                                
                                    <div class="row">
                                <asp:UpdatePanel ID="upd2" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdmember" Width="100%" CssClass="table tabbable-line" GridLines="None" AutoGenerateColumns="false" runat="server">
                                            <Columns>
                                                  <asp:TemplateField>
                                                        <HeaderTemplate>S.no</HeaderTemplate>
                                                         <ItemTemplate><%# Container.DataItemIndex+1 %>
                                                             <asp:HiddenField ID="hydmemberid"  runat="server"  Value='<%# Eval("MemberID") %>' />

                                                         </ItemTemplate>
                                                  </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                         Member  Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#  Eval("MemberName") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>Age </HeaderTemplate>
                                                    <ItemTemplate>
                                                       <%# Eval("Age") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                         Card  Name
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#  Eval("ValidCardName") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField>
                                                    <HeaderTemplate>
                                                         Card  No
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <%#  Eval("ValidCardNo") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                        </div>
                                   
                            </div>




                            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <table width="600px" border="0" align="center" cellpadding="3" cellspacing="1">
                                            <tr>
                                                <td colspan="3" class="modal-header" align="center" bgcolor="#fff"><strong>Please Enter Family Member Details </strong></td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" class="black-text" align="center">
                                                    <asp:Label ID="lblMsg1" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right" width="100px">Name<span class="red-text-1a">*</span></td>
                                                <td class="black-text" width="10px" align="center">:</td>
                                                <td width="200px" align="left" class="pdd">
                                                    <asp:TextBox ID="txtname" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox>
                                                    <br />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtname"
                                                        Display="Dynamic" ErrorMessage="Please Enter Name" SetFocusOnError="True"
                                                        ValidationGroup="ADDMember" CssClass="red-text-asterix "></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" CssClass="red-text-asterix"
                                                        ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtname"
                                                        ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z0-9 ]+$"
                                                        SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Sex</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:DropDownList ID="ddlselectsex" OnSelectedIndexChanged="ddlselectsex_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="textfield-drop pdd2">
                                                        <asp:ListItem Value="0" Text="Select Sex"></asp:ListItem>
                                                        <asp:ListItem Value="M" Text="Male"></asp:ListItem>
                                                        <asp:ListItem Value="F" Text="Female"></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlselectsex"
                                                        Display="Dynamic" ErrorMessage="Please Select Sex" SetFocusOnError="True"
                                                        ValidationGroup="ADDMember" InitialValue="0" CssClass="red-text-asterix"></asp:RequiredFieldValidator>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="black-text" colspan="3" align="right">

                                                    <asp:RadioButtonList Visible="false" ID="rdomarredstatus" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Value="1">Married</asp:ListItem>
                                                        <asp:ListItem Value="2">UnMarried</asp:ListItem>
                                                        <asp:ListItem Value="3">Widow</asp:ListItem>
                                                        <asp:ListItem Value="3">Divorce</asp:ListItem>
                                                    </asp:RadioButtonList>

                                                </td>


                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Relation With Family Head</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:DropDownList ID="ddlselectrelation" AutoPostBack="true" OnSelectedIndexChanged="ddlselectrelation_selectindexched" runat="server" CssClass="textfield-drop pdd2">
                                                        <asp:ListItem Value="0">Select Relation</asp:ListItem>
                                                        <asp:ListItem Value="1">Family Head</asp:ListItem>

                                                        <asp:ListItem Value="2">Father</asp:ListItem>

                                                        <asp:ListItem Value="3">Mother</asp:ListItem>

                                                        <asp:ListItem Value="4">Brother</asp:ListItem>

                                                        <asp:ListItem Value="5">Sister</asp:ListItem>

                                                        <asp:ListItem Value="6">Wife</asp:ListItem>
                                                        <asp:ListItem Value="7">Others</asp:ListItem>
                                                        <asp:ListItem Value="8">Son</asp:ListItem>
                                                        <asp:ListItem Value="9">Daughter</asp:ListItem>
                                                        <asp:ListItem Value="10">Daughter In Law</asp:ListItem>
                                                        <asp:ListItem Value="11">Grand Son</asp:ListItem>
                                                        <asp:ListItem Value="12">Grand Daughter</asp:ListItem>
                                                    </asp:DropDownList>&nbsp;
                                                </td>

                                            </tr>






                                            <tr id="trfatherhusband" runat="server" visible="false">
                                                <td class="black-text" align="right">Father/Husband Name</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:TextBox ID="txtfathername" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox><br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" CssClass="red-text-asterix" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtfathername" ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator>

                                                </td>

                                            </tr>

                                            <tr>
                                                <td class="black-text" align="right">Age(Years)</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:TextBox ID="txtage" runat="server" CssClass="textfield" MaxLength="3"></asp:TextBox><br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" CssClass="red-text-asterix" ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtage" ErrorMessage="Please Enter Only Numeric Values" ValidationExpression="[0-9]+$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                </td>

                                            </tr>



                                            <tr>
                                                <td class="black-text" align="right">Cast</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:DropDownList ID="ddlselectcast" runat="server" CssClass="textfield-drop pdd2">
                                                        <asp:ListItem Value="0" Text="Select Cast"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="OBC"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="SC"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="ST"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="OTHER"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlselectcast"
                                                        Display="Dynamic" ErrorMessage="Please Select Cast" SetFocusOnError="True"
                                                        ValidationGroup="ADDMember" InitialValue="0" CssClass="red-text-asterix "></asp:RequiredFieldValidator>
                                                </td>

                                            </tr>

                                            <tr>
                                                <td class="black-text" align="right">Any Valid Id Card Name<br />
                                                    (Like Ration Card or Voter ID)</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:TextBox ID="txtvalidcardnumber" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox></td>

                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Valid Id Number<br />
                                                </td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:TextBox ID="txtvoter" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox></td>

                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Contact Number</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:TextBox ID="txtcontact" runat="server" CssClass="textfield" MaxLength="11"></asp:TextBox>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" CssClass="red-text-asterix " ValidationGroup="ADDMember" Display="Dynamic" ControlToValidate="txtcontact" ErrorMessage="Please Enter Contact No. upto 10 or 11 digit" ValidationExpression="^[0-9]{10,11}$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td class="black-text" align="right">Education</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:TextBox ID="txtedu" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox></td>

                                            </tr>


                                            <tr>
                                                <td class="black-text" align="right">Occupation</td>
                                                <td class="black-text" align="center">:</td>
                                                <td align="left" class="pdd">
                                                    <asp:DropDownList ID="ddlselectoccupation" runat="server" CssClass="textfield-drop pdd2">
                                                        <asp:ListItem Value="0">Select Occupation</asp:ListItem>
                                                        <asp:ListItem Value="1">Labour</asp:ListItem>
                                                        <asp:ListItem Value="2">Farmer</asp:ListItem>
                                                        <asp:ListItem Value="3">Dairy</asp:ListItem>
                                                        <asp:ListItem Value="4">Others</asp:ListItem>
                                                        <asp:ListItem Value="5">Student</asp:ListItem>
                                                        <asp:ListItem Value="6">Dependent</asp:ListItem>
                                                        <asp:ListItem Value="7">Cattle Farming</asp:ListItem>
                                                    </asp:DropDownList>&nbsp;
            
                                                </td>

                                            </tr>


                                            <tr>
                                                <td class="black-text" align="right" style="height: 68px">Annual Income(Rs.)</td>
                                                <td class="black-text" align="center" style="height: 68px">:</td>
                                                <td align="left" style="height: 68px">
                                                    <asp:TextBox ID="txtincome" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox>
                                                    <br />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" CssClass="red-text-asterix " ControlToValidate="txtincome"
                                                        Display="Dynamic" ErrorMessage="Only Decimal" SetFocusOnError="True" ValidationExpression="[0-9]+(\.[0-9][0-9]?)?"
                                                        ValidationGroup="ADDMember">Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="ImgbtnSubmitMember" OnClick="ImgbtnSubmitMember_Click" runat="server" Text="Save" CssClass="btn btn-primary btn-add" ValidationGroup="ADDMember" />&nbsp;
  <asp:Button ID="imgbtnreset" runat="server" Text="Reset" CssClass="btn btn-primary btn-add" CausesValidation="false" />&nbsp;
   <asp:Button ID="imgbtncancel1" runat="server" Text="Cancel" CssClass="btn btn-primary btn-add" CausesValidation="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlselectsex" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-primary btn-add" />
                            </asp:Panel>



                            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnaddmember"
                                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>
                        </div>


                        <div class="clearfix"></div>


                        

                       



                        




            <!-- tabs -->

            <!-- start footer -->
            
        </div>
         </div>
        </div>

        <script src="../assets/js/vendor/jquery.min.js"></script>
</asp:Content>



