<%@ Page Title="Report Dashboard:NTCA" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="MisReportDashBoard.aspx.cs" Inherits="auth_Adminpanel_MisReportDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .icon a {
            color: #fff;
        }

            .icon a .fa {
                font-size: -webkit-xx-large !important;
                font-size: -moz-xx-large !important;
                font-size: xx-large !important;
                margin-right: 22px;
            }

        .small-box {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid bigfacebg" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 15px; min-height: 95vh;">
        <%--start superadmin 1--%>
        <div class="">
            <h1 class="text-center" style="background: #33414e; color: #fff; padding: 5px;">MIS Reports Generation</h1>
        </div>

        <div class="">
            <div class="row nu12">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-green bg-green-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Report/VillageSearch.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/VillageSearch.aspx") %>">
                                        <h4>Village-Wise Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/VillageSearch.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>
                            </div>
                        </div>
                        <!-- ./col -->
                        <div class="col-lg-3 col-xs-6 bxtp" style="display:none;">
                            <!-- small box -->
                            <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Report/CDP_Report.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/CDP_Report.aspx") %>">
                                        <h4>CDP Report Village-Wise</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/CDP_Report.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-aqua bg-aqua-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Report/OptionWiseFamilyRpt.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/OptionWiseFamilyRpt.aspx") %>">
                                        <h4>Option-Wise Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/OptionWiseFamilyRpt.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-red bg-red-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/NGO/Ngoreport.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/NGO/Ngoreport.aspx") %>">
                                        <h4>NGO PRE Monitoring Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/NGO/Ngoreport.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>

                            </div>
                        </div>

                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-red bg-red-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/NGO/PostNgoreport.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/NGO/PostNgoreport.aspx") %>">
                                        <h4>NGO POST Monitoring Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/NGO/PostNgoreport.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>

                            </div>
                        </div>

                        
                    </div>
                </div>
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-red bg-red-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Report/Familydata.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/Familydata.aspx") %>">
                                        <h4>Family Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/Familydata.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>

                            </div>
                        </div>
                        <!-- ./col -->
                        <div class="col-lg-3 col-xs-6 bxtp" style="display:none;">
                            <!-- small box -->
                            <div class="small-box bg-aqua bg-aqua-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Report/perticular_village_report.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/perticular_village_report.aspx") %>">
                                        <h4>Particular Village Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/perticular_village_report.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-green bg-green-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/RELOCATIONSITE/Relocation_Site_Report.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/RELOCATIONSITE/Relocation_Site_Report.aspx") %>">
                                        <h4>Relocation Site Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/RELOCATIONSITE/Relocation_Site_Report.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Villagerelocationprogress/Report.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Villagerelocationprogress/Report.aspx") %>">
                                        <h4>Relocation Progress Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Villagerelocationprogress/Report.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>

                            </div>
                        </div>
                        <%if (Session["UserType"].ToString().Equals("1"))
                          {%>
                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Report/ConsoldateReport/ConsolDateReport.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/ConsoldateReport/ConsolDateReport.aspx") %>">
                                        <h4> Pre Consolidated Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/ConsoldateReport/ConsolDateReport.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>

                            </div>
                        </div>

                        <div class="col-lg-3 col-xs-6 bxtp">
                            <!-- small box -->
                            <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Report/ConsoldateReport/PostConsolDateReport.aspx") %>';">
                                <div class="inner">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/ConsoldateReport/PostConsolDateReport.aspx") %>">
                                        <h4>Post Consolidated Report</h4>
                                    </a>
                                </div>
                                <div class="icon">
                                    <a href="<%= ResolveUrl("~/auth/adminpanel/Report/ConsoldateReport/PostConsolDateReport.aspx") %>"><i class="fa fa-file"></i></a>
                                </div>

                            </div>
                        </div>
                        <%} %>

                        <div class="col-lg-3 col-xs-6 bxtp">
                        <!-- small box -->
                        <div class="small-box bg-green bg-green-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Report/surveyreport.aspx") %>';">
                            <div class="inner">
                                <a href="<%= ResolveUrl("~/auth/Adminpanel/Report/surveyreport.aspx") %>">
                                    <h4>Survey Reports</h4>
                                </a>

                                
                            </div>
                            <div class="icon">
                                <a href="<%= ResolveUrl("~/auth/Adminpanel/Report/surveyreport.aspx") %>"><i class="fa fa-file"></i></a>
                            </div>
                            
                        </div>
                   </div>
                    </div>
                </div>
            </div>
        </div>

        <%--end superadmin 1--%>
    </div>
</asp:Content>

