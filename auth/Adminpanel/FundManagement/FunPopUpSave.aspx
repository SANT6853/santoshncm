<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FunPopUpSave.aspx.cs" Inherits="auth_Adminpanel_FundManagement_FunPopUpSave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   
                                <div class="row">
                                    <div class="col-sm-12">
                                        <asp:HiddenField ID="HImageButtonClickFind" runat="server" />
                                        <asp:HiddenField ID="HImageButtonClickFindID" runat="server" />
                                        <asp:HiddenField ID="HRowID" runat="server" />
                                        <label id="lblAmnt" class="col-sm-4 control-label lblAmnt">
                                            Enter Amount</label>
                                        <div class="form-group col-md-8">
                                            <asp:TextBox ID="txtfundRealeaseamount" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" Display="Dynamic"
                                                ForeColor="Red" CssClass="help-block" SetFocusOnError="true" ControlToValidate="txtfundRealeaseamount"
                                                ValidationGroup="valamount" ErrorMessage="Enter Amount" />
                                            <asp:RegularExpressionValidator ID="regamount" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$"
                                                SetFocusOnError="true" ControlToValidate="txtfundRealeaseamount" ForeColor="Red"
                                                ValidationGroup="valamount" ErrorMessage="Enter valid Fund Amount with 2 digit decimal value" />
                                        </div>
                                    </div>
                                    <div class="col-sm-12">
                                        <label class="col-sm-4 control-label">
                                            Description
                                        </label>
                                        <div class="form-group col-md-8">
                                            <asp:TextBox ID="txtamountdetials" TextMode="MultiLine" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" Display="Dynamic"
                                                ForeColor="Red" CssClass="help-block" SetFocusOnError="true" ControlToValidate="txtamountdetials"
                                                ValidationGroup="valamount" ErrorMessage="Enter Amount Description" />
                                        </div>
                                    </div>
                                    
                               
                                <div class="form-group col-md-12">
                                    <asp:Button id="BtnActionEvent" OnClick="BtnActionEvent_Click" ValidationGroup="valamount" runat="server" Text="Save" CssClass="btn btn-success" />
                                </div>
                            </div>
                    
    </div>
    </form>
</body>
</html>
