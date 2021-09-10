<%@ Page Title="NTCA:Village Beneficiary chart" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="VillageBeneficiaryBarPieChart.aspx.cs" Inherits="auth_Adminpanel_BarPieChart_VillageBeneficiaryBarPieChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<script type="text/javascript" src="jsapi.js"></script>--%>
    <script src="<%#ResolveUrl("jsapi.js") %>" type="text/javascript"></script>
    <style>
        .lblColor {
            color: red;
        }

        .form-horizontal .control-label {
            padding-top: 7px;
            margin-bottom: 0;
            text-align: left;
        }

        .control-label {
            padding-top: 7px;
            margin-bottom: 0;
            text-align: left;
        }

        .ibox-title {
            background-color: #005529;
            color: #fff;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="form-horizontal">

                <div class="box box-primary1 pull-left" style="margin-bottom: 25px;">
                    <div class="box-header with-border full_width">
                        <h3 class="box-title" style="color: #005529;">Chart Report of Village Beneficiary Bar/pie chart Report</h3>
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
                                <asp:DropDownList ID="DdTigerReserve" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdTigerReserve_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-5 col-md-5 col-xs-12 control-label">Select Village name:</label>
                            <div class="col-md-7 col-sm-7 col-xs-12">
                                <asp:DropDownList ID="DdlVillageName" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                <div style=" display:none;">
                    <div class="col-md-6 col-sm-6 col-xs-12">
                        <div class="form-group">
                            <label class="col-sm-5 col-md-5 col-xs-12 control-label">Select Cast/Beneficiary:</label>
                            <div class="col-md-7 col-sm-7 col-xs-12">
                                <asp:DropDownList ID="DDlStatus" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="-Select-" Value="All"></asp:ListItem>
                                    <asp:ListItem Text="OBC" Value="OBC"></asp:ListItem>
                                    <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                                    <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                                    <asp:ListItem Text="OTHER" Value="OTHER"></asp:ListItem>
                                     <asp:ListItem Text="Beneficiary" Value="Beneficiary"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                    <div class="col-md-8">
                        <div class="text-left">
                                <asp:Button ID="ImgbtnSubmit" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmit_Click" />
                        </div>
                    </div>

            </div>
            <div class="row">

                <div class="col-lg-12 col-md-12">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <h5></h5>

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


                <%-- <div style="padding-left: 250px"><b>NTCA Bar Chart.</b></div>--%>
                <%--Below Pie Char code--%>


                <div class="col-lg-4 col-md-12" id="LeftDivPanel" runat="server" visible="false">
                    <div class="ibox float-e-margins">
                        <div class="ibox-title">
                            <asp:Label ID="LblTigerReserNme" runat="server" Font-Size="12px"></asp:Label>

                            <!-- ibox-tools -->
                        </div>
                        <!-- / ibox-title -->
                        <div id="demo2" runat="server" class="ibox-content collapse in">
                            <div class="borderedTable">
                                <div>

                                    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
                                    <div id="piechart_3d" style="width: 350px; height: 300px;">
                                    </div>

                                </div>
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

