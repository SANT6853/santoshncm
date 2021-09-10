<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master"
    AutoEventWireup="true" CodeFile="viewfund.aspx.cs" Inherits="auth_Adminpanel_FundManagement_viewfund" %>

<%@ Register Src="../../../UserControl/HeadingControl.ascx" TagName="HeadingControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="col-lg-12 top20 bottom40">
        <div class="widgets-container">
            <div class="row">
                <!-- tabs -->
                <uc1:HeadingControl ID="heading1" runat="server" Heading="Fund List" />
                <div class="col-md-6">
                    <label class="col-sm-4 control-label">
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
                <div class="col-md-6">
                    <label class="col-sm-4 control-label">
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
                <div class="col-md-6">
                    <label class="col-sm-4 control-label">
                        Select Village Name</label>
                    <div class="form-group col-md-8">
                        <asp:DropDownList ID="ddlvillage" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="reqddlvillage" runat="server" Display="Dynamic" CssClass="help-block"
                            InitialValue="0" SetFocusOnError="true" ControlToValidate="ddlvillage" ForeColor="Red"
                            ValidationGroup="val" ErrorMessage="Select Village" />
                    </div>
                </div>
                <%-- <div class="col-md-6">
                    <label class="col-sm-4 control-label">
                        Fund Status</label>
                    <div class="form-group col-md-8">
                        <asp:DropDownList ID="ddlfundstatus" CssClass="form-control" runat="server">
                            <asp:ListItem Value="1">Save</asp:ListItem>
                            <asp:ListItem Value="2">Submit</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            CssClass="help-block" SetFocusOnError="true" ControlToValidate="ddlfundstatus"
                            ForeColor="Red" ValidationGroup="val" ErrorMessage="Select fund Status" />
                    </div>
                </div>--%>
                <div class="clearfix">
                </div>
                <div class="col-md-6 pull-right">
                    <asp:Button ID="btnsumbit" runat="server" Text="Search" ValidationGroup="val" CssClass="btn btn-primary center"
                        OnClick="btnsumbit_Click" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="grdfund" CssClass="table table-bordered table-hover" runat="server"
                        AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="grdfund_PageIndexChanging" OnRowCommand="grdfund_RowCommand" OnRowDataBound="grdfund_RowDataBound" OnRowDeleting="grdfund_RowDeleting">
                        <Columns>

                            <asp:BoundField DataField="VillageName" HeaderText="Village" />
                            <asp:TemplateField HeaderText="Fund Description">
                                <ItemTemplate>
                                    <%# Eval("FunDescription")%>

                                    <asp:HiddenField ID="HfundID" runat="server" Value='<%# Eval("Fid") %>' />
                                    <asp:HiddenField ID="HProcessingStatusID" runat="server" Value='<%# Eval("ProcessingStatusID") %>' />
                                    <asp:HiddenField ID="HActionButtonStatusTigerReserveUser" runat="server" Value='<%# Eval("ActionButtonStatusTigerReserveUser") %>' />
                                    <asp:HiddenField ID="HActionButtonStatusStateUser" runat="server" Value='<%# Eval("ActionButtonStatusStateUser") %>' />
                                    <asp:HiddenField ID="HActionButtonStatusNtcaUser" runat="server" Value='<%# Eval("ActionButtonStatusNtcaUser") %>' />
                                    <asp:HiddenField ID="HTigerReserveUserID" runat="server" Value='<%# Eval("TigerReserveUserID") %>' />
                                    <asp:HiddenField ID="HTigerReserveUserName" runat="server" Value='<%# Eval("TigerReserveUserName") %>' />
                                    <asp:HiddenField ID="HTigerReserveID" runat="server" Value='<%# Eval("TigerReserveID") %>' />
                                    <asp:HiddenField ID="HTigerReserveName" runat="server" Value='<%# Eval("TigerReserveName") %>' />
                                    <asp:HiddenField ID="HVillageID" runat="server" Value='<%# Eval("VillageID") %>' />
                                    <asp:HiddenField ID="HVillageName" runat="server" Value='<%# Eval("VillageName") %>' />

                                    <asp:HiddenField ID="HiStateUserID" runat="server" Value='<%# Eval("StateUserID") %>' />
                                    <asp:HiddenField ID="HStateUserName" runat="server" Value='<%# Eval("StateUserName") %>' />
                                    <asp:HiddenField ID="HStateID" runat="server" Value='<%# Eval("StateID") %>' />
                                    <asp:HiddenField ID="HStateName" runat="server" Value='<%# Eval("StateName") %>' />
                                    <asp:HiddenField ID="HFundAmount" runat="server" Value='<%# Eval("FundAmount") %>' />
                                    <asp:HiddenField ID="HNtcaUserID" runat="server" Value='<%# Eval("NtcaUserID") %>' />
                                    <asp:HiddenField ID="HCommonGroupQueryID" runat="server" Value='<%# Eval("CommonGroupQueryID") %>' />
                                    <asp:HiddenField ID="HFundSanctionStatus" runat="server" Value='<%# Eval("FundSanctionStatus") %>' />

                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:BoundField DataField="CommonGroupQueryID" HeaderText="CommonGroupQueryID" />--%>
                            <asp:BoundField DataField="FundSanctionStatus" HeaderText="Fund sanction status" />
                            <asp:BoundField DataField="FundAmount" HeaderText="Amount" DataFormatString="{0:n}" />
                            <asp:BoundField DataField="ProcessingStatusName" HeaderText="Process status" />
                            <asp:TemplateField HeaderText="Tiger Reserve user">
                                <ItemTemplate>
                                    <asp:Label ID="lblTigerReserveUser" runat="server" Text='<%# Eval("TigerReserveUserName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State user">
                                <ItemTemplate>
                                    <asp:Label ID="lblStateUser" runat="server" Text='<%# Eval("StateUserName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NTCA user">
                                <ItemTemplate>
                                    <asp:Label ID="lblNtcaUserName" runat="server" Text='<%# Eval("NtcaUserName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateDate" HeaderText="Date" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImgForward" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Fid") %>'
                                        CommandName="FrwdTigerReserve" 
                                        data-HfundID='<%# Eval("Fid") %>'
                                        data-HImageButtonClickFind="Forwarded by TIGER RESERVE user send to STATE user only"
                                        data-HImageButtonClickFindID="1"
                                        data-HProcessingStatusID='<%# Eval("TigerReserveUserName") %>' data-HActionButtonStatusTigerReserveUser='<%# Eval("ActionButtonStatusTigerReserveUser") %>'
                                        data-HActionButtonStatusStateUser='<%# Eval("ActionButtonStatusStateUser") %>' data-HActionButtonStatusNtcaUser='<%# Eval("ActionButtonStatusNtcaUser") %>'
                                        data-HTigerReserveUserID='<%# Eval("TigerReserveUserID") %>' data-HTigerReserveUserName='<%# Eval("TigerReserveUserName") %>'
                                        data-HTigerReserveID='<%# Eval("TigerReserveID") %>' data-HTigerReserveName='<%# Eval("TigerReserveUserName") %>'
                                        data-HVillageID='<%# Eval("VillageID") %>' data-HVillageName='<%# Eval("VillageName") %>'
                                        data-HiStateUserID='<%# Eval("StateUserID") %>' data-HStateUserName='<%# Eval("StateUserName") %>'
                                        data-HStateID='<%# Eval("StateID") %>' data-HStateName='<%# Eval("StateName") %>'
                                        data-HFundAmount='<%# Eval("FundAmount") %>' data-HNtcaUserID='<%# Eval("NtcaUserID") %>'
                                        data-HCommonGroupQueryID='<%# Eval("CommonGroupQueryID") %>' data-HFundSanctionStatus='<%# Eval("FundSanctionStatus") %>'
                                        Height="50px" Width="50px" />

                                    <asp:ImageButton ID="ImgReturnStateUser" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Fid") %>'
                                        CommandName="ReturnStateUser" 
                                        data-HfundID='<%# Eval("Fid") %>'
                                        data-HImageButtonClickFind="Return by STATE user send to TIGER RESERVE user only"
                                        data-HImageButtonClickFindID="2"
                                        data-HProcessingStatusID='<%# Eval("TigerReserveUserName") %>' data-HActionButtonStatusTigerReserveUser='<%# Eval("ActionButtonStatusTigerReserveUser") %>'
                                        data-HActionButtonStatusStateUser='<%# Eval("ActionButtonStatusStateUser") %>' data-HActionButtonStatusNtcaUser='<%# Eval("ActionButtonStatusNtcaUser") %>'
                                        data-HTigerReserveUserID='<%# Eval("TigerReserveUserID") %>' data-HTigerReserveUserName='<%# Eval("TigerReserveUserName") %>'
                                        data-HTigerReserveID='<%# Eval("TigerReserveID") %>' data-HTigerReserveName='<%# Eval("TigerReserveUserName") %>'
                                        data-HVillageID='<%# Eval("VillageID") %>' data-HVillageName='<%# Eval("VillageName") %>'
                                        data-HiStateUserID='<%# Eval("StateUserID") %>' data-HStateUserName='<%# Eval("StateUserName") %>'
                                        data-HStateID='<%# Eval("StateID") %>' data-HStateName='<%# Eval("StateName") %>'
                                        data-HFundAmount='<%# Eval("FundAmount") %>' data-HNtcaUserID='<%# Eval("NtcaUserID") %>'
                                        data-HCommonGroupQueryID='<%# Eval("CommonGroupQueryID") %>' data-HFundSanctionStatus='<%# Eval("FundSanctionStatus") %>'
                                        Height="50px" Width="50px" />

                                    <asp:ImageButton ID="ImgForwardStateUser" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Fid") %>'
                                        CommandName="ForwardStateUser"
                                        data-HfundID='<%# Eval("Fid") %>'
                                        data-HImageButtonClickFind="Forwarded by STATE user send to NTCA user only"
                                        data-HImageButtonClickFindID="3"
                                        data-HProcessingStatusID='<%# Eval("TigerReserveUserName") %>' data-HActionButtonStatusTigerReserveUser='<%# Eval("ActionButtonStatusTigerReserveUser") %>'
                                        data-HActionButtonStatusStateUser='<%# Eval("ActionButtonStatusStateUser") %>' data-HActionButtonStatusNtcaUser='<%# Eval("ActionButtonStatusNtcaUser") %>'
                                        data-HTigerReserveUserID='<%# Eval("TigerReserveUserID") %>' data-HTigerReserveUserName='<%# Eval("TigerReserveUserName") %>'
                                        data-HTigerReserveID='<%# Eval("TigerReserveID") %>' data-HTigerReserveName='<%# Eval("TigerReserveUserName") %>'
                                        data-HVillageID='<%# Eval("VillageID") %>' data-HVillageName='<%# Eval("VillageName") %>'
                                        data-HiStateUserID='<%# Eval("StateUserID") %>' data-HStateUserName='<%# Eval("StateUserName") %>'
                                        data-HStateID='<%# Eval("StateID") %>' data-HStateName='<%# Eval("StateName") %>'
                                        data-HFundAmount='<%# Eval("FundAmount") %>' data-HNtcaUserID='<%# Eval("NtcaUserID") %>'
                                        data-HCommonGroupQueryID='<%# Eval("CommonGroupQueryID") %>' data-HFundSanctionStatus='<%# Eval("FundSanctionStatus") %>'
                                        Height="50px" Width="50px" />

                                    <asp:ImageButton ID="ImgApproveNtcaUser" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Fid") %>'
                                        CommandName="ApproveNtcaUser"
                                        data-HfundID='<%# Eval("Fid") %>'
                                        data-HImageButtonClickFind="Approve by NTCA user send to STATE user only"
                                        data-HImageButtonClickFindID="4"
                                        data-HProcessingStatusID='<%# Eval("TigerReserveUserName") %>' data-HActionButtonStatusTigerReserveUser='<%# Eval("ActionButtonStatusTigerReserveUser") %>'
                                        data-HActionButtonStatusStateUser='<%# Eval("ActionButtonStatusStateUser") %>' data-HActionButtonStatusNtcaUser='<%# Eval("ActionButtonStatusNtcaUser") %>'
                                        data-HTigerReserveUserID='<%# Eval("TigerReserveUserID") %>' data-HTigerReserveUserName='<%# Eval("TigerReserveUserName") %>'
                                        data-HTigerReserveID='<%# Eval("TigerReserveID") %>' data-HTigerReserveName='<%# Eval("TigerReserveUserName") %>'
                                        data-HVillageID='<%# Eval("VillageID") %>' data-HVillageName='<%# Eval("VillageName") %>'
                                        data-HiStateUserID='<%# Eval("StateUserID") %>' data-HStateUserName='<%# Eval("StateUserName") %>'
                                        data-HStateID='<%# Eval("StateID") %>' data-HStateName='<%# Eval("StateName") %>'
                                        data-HFundAmount='<%# Eval("FundAmount") %>' data-HNtcaUserID='<%# Eval("NtcaUserID") %>'
                                        data-HCommonGroupQueryID='<%# Eval("CommonGroupQueryID") %>' data-HFundSanctionStatus='<%# Eval("FundSanctionStatus") %>'
                                        Height="50px" Width="50px" />

                                    <asp:ImageButton ID="ImgReturnNtcaUser" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Fid") %>'
                                        CommandName="ReturnNtcaUser" 
                                        data-HfundID='<%# Eval("Fid") %>'
                                        data-HImageButtonClickFind="Return by NTCA user send to STATE user only"
                                        data-HImageButtonClickFindID="5"
                                        data-HProcessingStatusID='<%# Eval("TigerReserveUserName") %>' data-HActionButtonStatusTigerReserveUser='<%# Eval("ActionButtonStatusTigerReserveUser") %>'
                                        data-HActionButtonStatusStateUser='<%# Eval("ActionButtonStatusStateUser") %>' data-HActionButtonStatusNtcaUser='<%# Eval("ActionButtonStatusNtcaUser") %>'
                                        data-HTigerReserveUserID='<%# Eval("TigerReserveUserID") %>' data-HTigerReserveUserName='<%# Eval("TigerReserveUserName") %>'
                                        data-HTigerReserveID='<%# Eval("TigerReserveID") %>' data-HTigerReserveName='<%# Eval("TigerReserveUserName") %>'
                                        data-HVillageID='<%# Eval("VillageID") %>' data-HVillageName='<%# Eval("VillageName") %>'
                                        data-HiStateUserID='<%# Eval("StateUserID") %>' data-HStateUserName='<%# Eval("StateUserName") %>'
                                        data-HStateID='<%# Eval("StateID") %>' data-HStateName='<%# Eval("StateName") %>'
                                        data-HFundAmount='<%# Eval("FundAmount") %>' data-HNtcaUserID='<%# Eval("NtcaUserID") %>'
                                        data-HCommonGroupQueryID='<%# Eval("CommonGroupQueryID") %>' data-HFundSanctionStatus='<%# Eval("FundSanctionStatus") %>'
                                        Height="50px" Width="50px" />

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="clearfix">
                </div>
                <div class="col-md-6 pull-right">
                    <asp:Button ID="btnfinalsumbit" Visible="false" runat="server" Text="Submit" ValidationGroup="val"
                        CssClass="btn btn-primary center" OnClick="btnfinalsumbit_Click" />
                </div>
                <div class="clearfix">
                </div>
                <%--start modal popup--%>
                <div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">


                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title" id="myModalLabel">Fund Section Form</h4>
                            </div>
                            <div class="modal-body ty23">
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>



                </div>
                <%--end modal popup--%>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function ()
        {
                   
            $(function ()
            {
                $("[id*=ImgForwardStateUser]").click(function (event)
                {
                    var oHfundID = $(this).attr("data-HfundID");
                    var oHImageButtonClickFind = $(this).attr("data-HImageButtonClickFind");
                    var oHImageButtonClickFindID = $(this).attr("data-HImageButtonClickFindID");
                    var oHProcessingStatusID = $(this).attr("data-HProcessingStatusID");
                    var oHActionButtonStatusTigerReserveUser = $(this).attr("data-HActionButtonStatusTigerReserveUser");
                    var oHActionButtonStatusStateUser = $(this).attr("data-HActionButtonStatusStateUser");
                    var oHActionButtonStatusNtcaUser = $(this).attr("data-HActionButtonStatusNtcaUser");
                    var oHTigerReserveUserID = $(this).attr("data-HTigerReserveUserID");
                    var oHTigerReserveUserName = $(this).attr("data-HTigerReserveUserName");
                    var oHTigerReserveID = $(this).attr("data-HTigerReserveID");
                    var oHTigerReserveName = $(this).attr("data-HTigerReserveName");
                    var oHVillageID = $(this).attr("data-HVillageID");
                    var oHVillageName = $(this).attr("data-HVillageName");
                    var oHiStateUserID = $(this).attr("data-HiStateUserID");
                    var oHStateUserName = $(this).attr("data-HStateUserName");
                    var oHStateID = $(this).attr("data-HStateID");
                    var oHStateName = $(this).attr("data-HStateName");
                    var oHFundAmount = $(this).attr("data-HFundAmount");
                    var oHNtcaUserID = $(this).attr("data-HNtcaUserID");
                    var oHCommonGroupQueryID = $(this).attr("data-HCommonGroupQueryID");
                    var oHFundSanctionStatus = $(this).attr("data-HFundSanctionStatus");
                   
                    var pagrUrl = "FunPopUpSave.aspx?HImageButtonClickFind=" + oHImageButtonClickFind + "&HImageButtonClickFindID=" + oHImageButtonClickFindID +
                    "&HProcessingStatusID="
                        + oHProcessingStatusID + "&HActionButtonStatusTigerReserveUser=" + oHActionButtonStatusTigerReserveUser +
                        "&HActionButtonStatusStateUser=" + oHActionButtonStatusStateUser +
                        "&HActionButtonStatusNtcaUser=" + oHActionButtonStatusNtcaUser +
                        "&HTigerReserveUserID=" + oHTigerReserveUserID +
                        "&HTigerReserveUserName=" + oHTigerReserveUserName +
                        "&HTigerReserveID=" + oHTigerReserveID +
                        "&HTigerReserveName=" + oHTigerReserveName +
                        "&HVillageID=" + oHVillageID +
                        "&HVillageName=" + oHVillageName +
                        "&HiStateUserID=" + oHiStateUserID +
                        "&HStateUserName=" + oHStateUserName +
                        "&HStateID=" + oHStateID +
                        "&HStateName=" + oHStateName +
                        "&HFundAmount=" + oHFundAmount +
                        "&HCommonGroupQueryID=" + oHCommonGroupQueryID +
                        "&HFundSanctionStatus=" + oHFundSanctionStatus + "&HfundID=" + oHfundID + "&HNtcaUserID=" + oHNtcaUserID;
                    $('#demoModal').modal('show').find('.modal-body').load(encodeURI(pagrUrl));
                   // alert(encodeURI(pagrUrl));

                    return false;
                   
                });

            });
            //-------------------------
            $(function () {
                $("[id*=ImgReturnStateUser]").click(function (event) {
                    var oHfundID = $(this).attr("data-HfundID");
                    var oHImageButtonClickFind = $(this).attr("data-HImageButtonClickFind");
                    var oHImageButtonClickFindID = $(this).attr("data-HImageButtonClickFindID");
                    var oHProcessingStatusID = $(this).attr("data-HProcessingStatusID");
                    var oHActionButtonStatusTigerReserveUser = $(this).attr("data-HActionButtonStatusTigerReserveUser");
                    var oHActionButtonStatusStateUser = $(this).attr("data-HActionButtonStatusStateUser");
                    var oHActionButtonStatusNtcaUser = $(this).attr("data-HActionButtonStatusNtcaUser");
                    var oHTigerReserveUserID = $(this).attr("data-HTigerReserveUserID");
                    var oHTigerReserveUserName = $(this).attr("data-HTigerReserveUserName");
                    var oHTigerReserveID = $(this).attr("data-HTigerReserveID");
                    var oHTigerReserveName = $(this).attr("data-HTigerReserveName");
                    var oHVillageID = $(this).attr("data-HVillageID");
                    var oHVillageName = $(this).attr("data-HVillageName");
                    var oHiStateUserID = $(this).attr("data-HiStateUserID");
                    var oHStateUserName = $(this).attr("data-HStateUserName");
                    var oHStateID = $(this).attr("data-HStateID");
                    var oHStateName = $(this).attr("data-HStateName");
                    var oHFundAmount = $(this).attr("data-HFundAmount");
                    var oHNtcaUserID = $(this).attr("data-HNtcaUserID");
                    var oHCommonGroupQueryID = $(this).attr("data-HCommonGroupQueryID");
                    var oHFundSanctionStatus = $(this).attr("data-HFundSanctionStatus");
                    var pagrUrl = "FunPopUpSave.aspx?HImageButtonClickFind=" + oHImageButtonClickFind + "&HImageButtonClickFindID=" + oHImageButtonClickFindID +
                    "&HProcessingStatusID="
                        + oHProcessingStatusID + "&HActionButtonStatusTigerReserveUser=" + oHActionButtonStatusTigerReserveUser +
                        "&HActionButtonStatusStateUser=" + oHActionButtonStatusStateUser +
                        "&HActionButtonStatusNtcaUser=" + oHActionButtonStatusNtcaUser +
                        "&HTigerReserveUserID=" + oHTigerReserveUserID +
                        "&HTigerReserveUserName=" + oHTigerReserveUserName +
                        "&HTigerReserveID=" + oHTigerReserveID +
                        "&HTigerReserveName=" + oHTigerReserveName +
                        "&HVillageID=" + oHVillageID +
                        "&HVillageName=" + oHVillageName +
                        "&HiStateUserID=" + oHiStateUserID +
                        "&HStateUserName=" + oHStateUserName +
                        "&HStateID=" + oHStateID +
                        "&HStateName=" + oHStateName +
                        "&HFundAmount=" + oHFundAmount +
                        "&HCommonGroupQueryID=" + oHCommonGroupQueryID +
                        "&HFundSanctionStatus=" + oHFundSanctionStatus + "&HfundID=" + oHfundID;
                    $('#demoModal').modal('show').find('.modal-body').load(encodeURI(pagrUrl));

                    return false;

                });

            });
            //-------------------
            //-------------------------
            $(function () {
                $("[id*=ImgApproveNtcaUser]").click(function (event) {
                    var oHfundID = $(this).attr("data-HfundID");
                    var oHImageButtonClickFind = $(this).attr("data-HImageButtonClickFind");
                    var oHImageButtonClickFindID = $(this).attr("data-HImageButtonClickFindID");
                    var oHProcessingStatusID = $(this).attr("data-HProcessingStatusID");
                    var oHActionButtonStatusTigerReserveUser = $(this).attr("data-HActionButtonStatusTigerReserveUser");
                    var oHActionButtonStatusStateUser = $(this).attr("data-HActionButtonStatusStateUser");
                    var oHActionButtonStatusNtcaUser = $(this).attr("data-HActionButtonStatusNtcaUser");
                    var oHTigerReserveUserID = $(this).attr("data-HTigerReserveUserID");
                    var oHTigerReserveUserName = $(this).attr("data-HTigerReserveUserName");
                    var oHTigerReserveID = $(this).attr("data-HTigerReserveID");
                    var oHTigerReserveName = $(this).attr("data-HTigerReserveName");
                    var oHVillageID = $(this).attr("data-HVillageID");
                    var oHVillageName = $(this).attr("data-HVillageName");
                    var oHiStateUserID = $(this).attr("data-HiStateUserID");
                    var oHStateUserName = $(this).attr("data-HStateUserName");
                    var oHStateID = $(this).attr("data-HStateID");
                    var oHStateName = $(this).attr("data-HStateName");
                    var oHFundAmount = $(this).attr("data-HFundAmount");
                    var oHNtcaUserID = $(this).attr("data-HNtcaUserID");
                    var oHCommonGroupQueryID = $(this).attr("data-HCommonGroupQueryID");
                    var oHFundSanctionStatus = $(this).attr("data-HFundSanctionStatus");
                    var pagrUrl = "FunPopUpSave.aspx?HImageButtonClickFind=" + oHImageButtonClickFind + "&HImageButtonClickFindID=" + oHImageButtonClickFindID +
                    "&HProcessingStatusID="
                        + oHProcessingStatusID + "&HActionButtonStatusTigerReserveUser=" + oHActionButtonStatusTigerReserveUser +
                        "&HActionButtonStatusStateUser=" + oHActionButtonStatusStateUser +
                        "&HActionButtonStatusNtcaUser=" + oHActionButtonStatusNtcaUser +
                        "&HTigerReserveUserID=" + oHTigerReserveUserID +
                        "&HTigerReserveUserName=" + oHTigerReserveUserName +
                        "&HTigerReserveID=" + oHTigerReserveID +
                        "&HTigerReserveName=" + oHTigerReserveName +
                        "&HVillageID=" + oHVillageID +
                        "&HVillageName=" + oHVillageName +
                        "&HiStateUserID=" + oHiStateUserID +
                        "&HStateUserName=" + oHStateUserName +
                        "&HStateID=" + oHStateID +
                        "&HStateName=" + oHStateName +
                        "&HFundAmount=" + oHFundAmount +
                        "&HCommonGroupQueryID=" + oHCommonGroupQueryID +
                        "&HFundSanctionStatus=" + oHFundSanctionStatus + "&HfundID=" + oHfundID;
                    $('#demoModal').modal('show').find('.modal-body').load(encodeURI(pagrUrl));

                    return false;

                });

            });
            //-------------------
            //-------------------------
            $(function () {
                $("[id*=ImgReturnNtcaUser]").click(function (event) {
                    var oHfundID = $(this).attr("data-HfundID");
                    var oHImageButtonClickFind = $(this).attr("data-HImageButtonClickFind");
                    var oHImageButtonClickFindID = $(this).attr("data-HImageButtonClickFindID");
                    var oHProcessingStatusID = $(this).attr("data-HProcessingStatusID");
                    var oHActionButtonStatusTigerReserveUser = $(this).attr("data-HActionButtonStatusTigerReserveUser");
                    var oHActionButtonStatusStateUser = $(this).attr("data-HActionButtonStatusStateUser");
                    var oHActionButtonStatusNtcaUser = $(this).attr("data-HActionButtonStatusNtcaUser");
                    var oHTigerReserveUserID = $(this).attr("data-HTigerReserveUserID");
                    var oHTigerReserveUserName = $(this).attr("data-HTigerReserveUserName");
                    var oHTigerReserveID = $(this).attr("data-HTigerReserveID");
                    var oHTigerReserveName = $(this).attr("data-HTigerReserveName");
                    var oHVillageID = $(this).attr("data-HVillageID");
                    var oHVillageName = $(this).attr("data-HVillageName");
                    var oHiStateUserID = $(this).attr("data-HiStateUserID");
                    var oHStateUserName = $(this).attr("data-HStateUserName");
                    var oHStateID = $(this).attr("data-HStateID");
                    var oHStateName = $(this).attr("data-HStateName");
                    var oHFundAmount = $(this).attr("data-HFundAmount");
                    var oHNtcaUserID = $(this).attr("data-HNtcaUserID");
                    var oHCommonGroupQueryID = $(this).attr("data-HCommonGroupQueryID");
                    var oHFundSanctionStatus = $(this).attr("data-HFundSanctionStatus");
                    var pagrUrl = "FunPopUpSave.aspx?HImageButtonClickFind=" + oHImageButtonClickFind + "&HImageButtonClickFindID=" + oHImageButtonClickFindID +
                    "&HProcessingStatusID="
                        + oHProcessingStatusID + "&HActionButtonStatusTigerReserveUser=" + oHActionButtonStatusTigerReserveUser +
                        "&HActionButtonStatusStateUser=" + oHActionButtonStatusStateUser +
                        "&HActionButtonStatusNtcaUser=" + oHActionButtonStatusNtcaUser +
                        "&HTigerReserveUserID=" + oHTigerReserveUserID +
                        "&HTigerReserveUserName=" + oHTigerReserveUserName +
                        "&HTigerReserveID=" + oHTigerReserveID +
                        "&HTigerReserveName=" + oHTigerReserveName +
                        "&HVillageID=" + oHVillageID +
                        "&HVillageName=" + oHVillageName +
                        "&HiStateUserID=" + oHiStateUserID +
                        "&HStateUserName=" + oHStateUserName +
                        "&HStateID=" + oHStateID +
                        "&HStateName=" + oHStateName +
                        "&HFundAmount=" + oHFundAmount +
                        "&HCommonGroupQueryID=" + oHCommonGroupQueryID +
                        "&HFundSanctionStatus=" + oHFundSanctionStatus + "&HfundID=" + oHfundID;
                    $('#demoModal').modal('show').find('.modal-body').load(encodeURI(pagrUrl));

                    return false;

                });

            });
            //-------------------
        });
    </script>
</asp:Content>
