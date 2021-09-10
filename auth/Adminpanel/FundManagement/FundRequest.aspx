<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master"
    AutoEventWireup="true" CodeFile="FundRequest.aspx.cs" Inherits="auth_Adminpanel_FundManagement_FundRequest" %>

<%@ Register Src="../../../UserControl/HeadingControl.ascx" TagName="HeadingControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
        .modal-dialog {
            width: 70% !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="col-lg-12 top20 bottom40">
        <div class="widgets-container">
            <div class="row">
                <!-- tabs -->
                <uc1:HeadingControl ID="heading1" runat="server" Heading="Fund Request Form" />
                <div class="col-md-12">
                    <label class="col-sm-2 control-label">
                        Select State</label>
                    <div class="form-group col-md-8">
                        <asp:DropDownList ID="ddlstate" AutoPostBack="true" runat="server" CssClass="form-control"
                            OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqstate" Display="Dynamic" CssClass="help-block"
                            ForeColor="Red" InitialValue="0" ControlToValidate="ddlstate" SetFocusOnError="true"
                            ValidationGroup="val" ErrorMessage="Select State" />
                    </div>
                </div>
                <div class="col-md-12">
                    <label class="col-sm-2 control-label">
                        Select Tiger Reserves</label>
                    <div class="form-group col-md-8">
                        <asp:DropDownList ID="ddltigerreserve" AutoPostBack="true" runat="server" CssClass="form-control"
                            OnSelectedIndexChanged="ddltigerreserve_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqddltiger" Display="Dynamic" ForeColor="Red"
                            CssClass="help-block" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddltigerreserve"
                            ValidationGroup="val" ErrorMessage="Select Tiger Reserve" />
                    </div>
                </div>
                <div class="col-md-12">
                    <label class="col-sm-2 control-label">
                        Select Village Name</label>
                    <div class="form-group col-md-8">
                    
                        <asp:DropDownList ID="ddlvillage"  AutoPostBack="true" CssClass="form-control" 
                            runat="server" onselectedindexchanged="ddlvillage_SelectedIndexChanged"  />
                            
                        <asp:RequiredFieldValidator ID="reqddlvillage" runat="server" Display="Dynamic" CssClass="help-block"
                            InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlvillage" ForeColor="Red"
                            ValidationGroup="val" ErrorMessage="Select Village" />
                            
                    </div>
                    <div class="form-group col-md-2">
                     <asp:LinkButton ID="lnlviewvillageDetails" OnClientClick="return DisplayVillage();"   runat="server" CssClass="btn btn-info btn-mg" ><i class="fa glyphicon glyphicon-th-list">View</i></asp:LinkButton>
                    </div>
                    
                </div>
                <div class="col-md-12">
                    <label class="col-sm-2 control-label">
                        Total Family</label>
                    <div class="form-group col-md-2">
                       <asp:TextBox ID="txttotalfamily" runat="server" Width="100px" Text="0" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label class="col-sm-2 control-label">
                        Total Family Member</label>
                    <div class="form-group col-md-2">
                       <asp:TextBox ID="txtfamillymember" runat="server" Width="100px" Text="0" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <label class="col-sm-2 control-label">
                        Family(Option I)</label>
                    <div class="form-group col-md-2">
                       <asp:TextBox ID="txtoption1" runat="server" Width="100px" Text="0" CssClass="form-control"></asp:TextBox>
                    </div>
                    <label class="col-sm-2 control-label">
                        Family(Option II)</label>
                    <div class="form-group col-md-2">
                       <asp:TextBox ID="txtoption2" runat="server" Width="100px" Text="0" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    
                </div>

                <div class="col-md-12">
                    <label class="col-sm-2 control-label">
                       Fund Amount</label>
                    <div class="form-group col-md-8">
                       <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" CssClass="help-block"
                             SetFocusOnError="true" ControlToValidate="txtamount" ForeColor="Red"
                            ValidationGroup="val" ErrorMessage="Enter Fund Amount" />

                            <asp:RegularExpressionValidator ID="regamount" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$"  SetFocusOnError="true"                                              ControlToValidate="txtamount" ForeColor="Red"
                            ValidationGroup="val" ErrorMessage="Enter valid Fund Amount with 2 digit decimal value" />
                    </div>
                </div>
                 <div class="col-md-12">
                    <label class="col-sm-2 control-label">
                       Fund Description</label>
                    <div class="form-group col-md-8">
                       <asp:TextBox ID="txtfunddescription" TextMode="MultiLine" runat="server" CssClass="form-control" />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  runat="server" Display="Dynamic" CssClass="help-block"
                             SetFocusOnError="true" ControlToValidate="txtfunddescription" ForeColor="Red"
                             ValidationGroup="val" ErrorMessage="Fund Description" />

                    </div>
                </div>
                
             
                
                <div class="clearfix">
                </div>
                <div class="col-md-6 pull-right">
                  <asp:Button ID="btnsumbit" runat="server" Text="Submit" ValidationGroup="val" 
                        CssClass="btn btn-primary center" onclick="btnsumbit_Click" />
                </div>
                <!-- tabs -->
                <!-- start footer -->
            </div>
        </div>
    </div>

    <div id="myModalVillage" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Form Details</h4>
      </div>
      <div class="modal-body">
        <p>Some text in the modal.</p>
      </div>
     
    </div>

  </div>
</div>

   <script type="text/javascript">
       function DisplayVillage() {
           //var villageid = $(this).attr("data-id");
           var villageid = $('[id*=ddlvillage]').val();
           var pagrUrl = "VillageDisplay.aspx?vid=" + villageid;
           $('#myModalVillage').modal('show').find('.modal-body').load(pagrUrl);
           //  $('#demoModal').modal('show');
           // $('#demoModal').modal('show').find('[id*=iframevillage]').attr("src", pagrUrl)



           return false;
       }
   
   </script>
</asp:Content>
