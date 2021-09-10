<%@ Page Title="NTCA:Tiger Reserve Comparative chart Report" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="TigerReserveComparativeChart.aspx.cs" Inherits="auth_Adminpanel_BarPieChart_TigerReserveComparativeChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style>
.control-label {
    text-align: left;
}
.ibox-title{
	padding:0px !important;

}
.ibox-title h3{
	margin-top:8px;
}
.borderedTable {
	height: 650px;
	overflow:scroll;
}

div::-webkit-scrollbar {
	width: 5px;
	height: 5px;
}


div::-webkit-scrollbar-track {
	background: #fafafa; 
	border-radius: 10px;
}


div::-webkit-scrollbar-thumb {
    background: #888; 
	border-radius: 10px;
}


div::-webkit-scrollbar-thumb:hover {
    background: #555; 
}
.full_width{
	width:100%:
	float:left;
}
@media print{
.col-xs-12{
width:50%;
}
}
</style>
    <script src="<%#ResolveUrl("jsapi.js") %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">

    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="form-horizontal">

                <div class="box box-primary1 pull-left" style="margin-bottom: 25px;">
                    <div class="box-header with-border full_width">
                        <h3 class="box-title" style="color: #005529;">Chart Report of Tiger Reserve Comparative chart Report</h3>
						<a href="javascript:void(0)" onclick="printWindow()" class="btn btn-primary btn-xs pull-right">Print</a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-5 col-md-5 col-xs-12 control-label">Select State Name:</label>
                            <div class="col-md-7 col-sm-7 col-xs-12">
                                <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-5 col-md-5 col-xs-12 control-label">Select Tiger reserve name:</label>
                            <div class="col-md-7 col-sm-7 col-xs-12">
                                <asp:DropDownList ID="DdTigerReserve" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-5 col-md-5 col-xs-12 control-label">Select status:</label>
                            <div class="col-md-7 col-sm-7 col-xs-12">
                                <asp:DropDownList ID="DDlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Relocated" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Non-Relocated" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="In-Progress" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="No Of Village Population" Value="Populations"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="text-left">
                                <asp:Button ID="ImgbtnSubmit" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmit_Click" />
                        </div>
                    </div>
                </div>

            </div>
            <div class="row">

                <div class="col-lg-12 col-md-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title" style="background-color:#005529;">
                            <h3 style="text-align: center; color:white;">TIGER RESERVE COMPARATIVE CHART</h3>

                            <!-- ibox-tools -->
                        </div>
                        <!-- / ibox-title -->
                        <div id="demo1" class="ibox-content collapse in">
                            <div class="borderedTable">
                                <div>

                                    <asp:Literal ID="lt" runat="server"></asp:Literal>
                                </div>

                                <div id="chart_div"></div>
                            </div>
                        </div>
                    </div>
                </div>



            </div>
        </div>
    </div>
<script>
function printWindow() {
  window.print();
}
</script>
</asp:Content>

