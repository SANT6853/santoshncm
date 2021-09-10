<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="fund.aspx.cs" Inherits="auth_Adminpanel_FundManagement_fund" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .table-2 td {
            border-top: none !important;
        }

        .control-label {
            text-align: left !important;
        }

        .red-text {
            color: red;
        }
        /*.form-group {
	margin-bottom: 0;
}*/
        .stp {
            color: #000000;
            text-align: left;
            font-weight: bold;
            background: #f7b000;
            padding: 5px;
        }

        .stp1 {
            color: #fff;
            text-align: left;
            font-weight: bold;
            background: #005529;
            padding: 5px;
        }

        .stpdiv {
            padding: 0 0 30px 0;
        }

        .form-horizontal .form-group {
            margin-right: 0;
            margin-left: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <%-- ***************nw****** --%>
        <div class="wrapper-content" style="padding-top: 0px; padding-bottom: 0; min-height: 550px;">
            <div class="row">
                <div class="col-lg-12">
                    <div class="widgets-container">
                        <div class="box box-primary1" style="margin-bottom: 25px;">
                            <div class="stpdiv">
                                <div class="full_width padding15 stpdiv">
                                    <span class="box-title stp1 stepArrow">Step-1</span>
                                    <span class="box-title stp1 stepArrow">Step-2</span>
                                    <span class="box-title stp1 stepArrow">Step-3</span>
                                    <span class="box-title stp1 stepArrow">Step-4</span>
                                    <span class="box-title stp1 stepArrow stepActive">Step-5</span>
                                    <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 5</span>
                                </div>
                                <div class="box-header with-border">
                                    <h3 class="box-title" style="color: #005529;">Funds Required </h3>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary pull-right" Text="Back" OnClick="btnBack_Click" />
                                    </div>

                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_product1" class="control-label  requiredField">State <span class="red">* </span></label>
                                            <div class="controls">
                                                <asp:TextBox disabled="disabled" ID="txtStateName" runat="server" class="textinput form-control" autocomplete="stopdoingthat" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_product1" class="control-label  requiredField">Tiger Reserve <span class="red">* </span></label>
                                            <div class="controls">
                                                <asp:TextBox runat="server" disabled="disabled" ID="txtTigerReserve" class="textinput form-control" autocomplete="stopdoingthat" onkeypress="return IsAlphaNumeric(event);" onkeyup="myFunction()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_product1" class="control-label  requiredField">District <span class="red">* </span></label>
                                            <div class="controls">
                                                <asp:TextBox runat="server" disabled="disabled" ID="txtDistrict" class="textinput form-control" autocomplete="stopdoingthat" onkeypress="return IsAlphaNumeric(event);" onkeyup="myFunction()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_product1" class="control-label  requiredField">Village <span class="red">* </span></label>
                                            <div class="controls">
                                                <asp:TextBox runat="server" disabled="disabled" name="txtApplicantName" ID="txtVillage" class="textinput form-control" autocomplete="stopdoingthat" onkeypress="return IsAlphaNumeric(event);" onkeyup="myFunction()"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <asp:UpdatePanel ID="updOptions" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="ddltype" class="control-label">Option <span class="red-text"></span>: </label>
                                                    <asp:DropDownList ID="ddltype" CssClass="textfield-drop form-control" runat="server" Enabled="false">
                                                       
                                                        <asp:ListItem Value="1">I</asp:ListItem>
                                                       
                                                    </asp:DropDownList>
                                                 
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label">Amount <span class="red-text"></span>: </label>
                                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" MaxLength="10" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label for="ddltype" class="control-label">Option <span class="red-text"></span>: </label>
                                                    <asp:DropDownList ID="ddlType2" CssClass="textfield-drop form-control" runat="server" Enabled="false">
                                                       
                                                       
                                                        <asp:ListItem Value="2">II</asp:ListItem>
                                                    </asp:DropDownList>
                                                 
                                                </div>
                                            </div>

                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label class="control-label">Amount <span class="red-text"></span>: </label>
                                                    <asp:TextBox ID="txtAmount2" runat="server" CssClass="form-control" MaxLength="10" Enabled="false"></asp:TextBox>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label">Remarks <span class="red-text"></span>: </label>
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="control-label"></label>
                                            <div class="clearfix"></div>
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" ValidationGroup="fund" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- *******************end nw --%>
        </div>
</asp:Content>
