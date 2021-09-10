<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RelocationMapGoogle.aspx.cs" Inherits="auth_Adminpanel_REPORT_RelocationMapGoogle" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Map:NTCA</title>
    <script language="javascript" src="../JS/Script.js" type="text/javascript"></script>

    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
        .table_new01 {
            padding-top: 10px;
        }

            .table_new01 a {
                color: #f4b301 !important;
            }

        .pagination table tr td {
            border: 1px solid #cccccc;
        }
	.alt_row {
    background: none !important;
}
        .pagination {
            background: transparent !important;
        }

            .pagination > td {
                border: none !important;
            }

        .table-2  {
		border:none;
        }

        .pagination {
            display: contents;
        }

        .table_new01 {
            border-right: none;
            border-bottom: none;
        }

        .GridPager a, .GridPager span {
            display: block;
            height: 30px;
            width: 30px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
            padding: 5px 10px;
        }

        .GridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }

        .GridPager span {
            background-color: #005529;
            color: #fff;
            border: 1px solid #005529;
        }

        .pagination td {
            border: none !important;
            padding: 3px !important;
        }
		#btn_print{margin-left:3px; margin-right:3px;}
		.seldiv{border:1px solid #d9d6d6; padding:10px; margin-bottom:15px;word-break: break-word;}
		legend{margin-bottom:0;}
		div.dd_chk_select{
			height:30px !important;
		}
		div.dd_chk_select div#caption{top:6px !important;}
		#btn_print{margin-left:3px;}
		hr{margin-top:0px;}
		.red-text{color:red;}
		.mt10{margin-top:10px;}
		.sel legend{font-size:14px;}
		div.dd_chk_drop{top:30px !important;}
		.form-group{margin-bottom:0px;}
		.tblchk
		#ChkReportShowHide td label{ font-size:65%; font-weight:300; vertical-align: middle;}
		#ChkReportShowHide td{padding:0px 5px 9px 0px;}
    </style>
    </style>
    <style type="text/css">
        @media print {
            a[href]:after {
                content: none !important;
            }

            img[src]:after {
                content: none !important;
            }

            * {
                font-size: 10px !important;
            }

            #btn_print, #ImageButton1, .pagination {
                display: none;
            }

            table {
                border: solid #333333 !important;
                border-width: 1px 0 0 1px !important;
            }

            th, td {
                border: solid #333333 !important;
                border-width: 0 1px 1px 0 !important;
            }

            #print_area {
                margin-top: 0px;
            }


            @page {
                size: landscape;
            }

            .container-fluid {
                margin-top: 0 !important;
            }

            #contentbody_gvwork {
                width: 100%;
            }
        }

        .prntbck {
            margin-right: 20px;
            margin-top: 30px;
        }

            .prntbck input {
                margin-left: 3px;
            }

        div::-webkit-scrollbar {
            width: 8px;
            height: 8px;
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

        .errmsg {
            margin-left: 25px;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
                <div class="col-sm-12" id="print_area" >
				
					<div class="row">
						<div class="col-md-12 mt20">
							<h3>Relocated villages map showing</h3>
							<hr />
							<div>
						<asp:Button ID="ImageButton1" runat="server" Text="Back" CssClass="btn btn-primary pull-right" OnClick="ImageButton1_Click" />
                        <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning"
                            OnClick="BtnExcelExport_Click" />
                        <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click" />
                        <asp:Button ID="btn_print" runat="server" Text="Print selected checked" CssClass="btn btn-primary btn-add pull-right" Visible="false" OnClick="btn_print_Click1" />
                        <asp:Button ID="BtnPrintAll" runat="server" Text="Print all" CssClass="btn btn-primary btn-add pull-right" Visible="false" OnClick="BtnPrintAll_Click" />
							
							</div>
							<br />
						</div>
					</div>
					<div class="row">
						<div class="col-md-10 mt20">
							<label class="col-sm-4 control-label">
								 State Name:
							</label>
							<div class="form-group col-md-5">
								<asp:Label ID="LblMsgStateName" runat="server"></asp:Label>	
							</div>
						</div>					
					</div>
					<div class="row">
						<div class="col-md-10 mt20">
							<label class="col-sm-4 control-label">
								 Tiger reserve name:
							</label>
							<div class="form-group col-md-5">
								<asp:DropDownCheckBoxes ID="DdlTigerReserve" runat="server" AutoPostBack="true" Font-Size="Larger"
                                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlTigerReserve_SelectedIndexChanged">
                                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                                <Texts SelectBoxCaption="Select Tiger reserve name" />
                                            </asp:DropDownCheckBoxes>
                                            <asp:Label ID="ErrorChkTigerReserveName" runat="server" ForeColor="Red"></asp:Label>
							</div>
						</div>					
					</div>
					<div class="row " >
                        <div class="col-md-10 mt20">
                            <div class="col-sm-4 control-label">
                                <span class="">Selected Tiger reserve:</span>
                            </div>
                            <div class="form-group col-md-5">
							<fieldset class="mt10 sel">
                                     <div class="seldiv" style="margin-left: 0;">
                                      <asp:Label ID="LblMsgTigerReserveName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                                      <asp:Label ID="LblMsgTigerReserveValue" Font-Size="0px" runat="server" ForeColor="green">You have not selected.</asp:Label>
									</div>
                            </fieldset>
							
                            </div>
                        </div>
                    </div>
					<div class="row">
						<div class="col-md-10 mt20">
							<label class="col-sm-4 control-label">
								 Choose Village name:
							</label>
							<div class="form-group col-md-5">
								 <asp:DropDownCheckBoxes ID="DdlVillageName" runat="server" AutoPostBack="true" Font-Size="Larger"
                                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlVillageName_SelectedIndexChanged">
                                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                                <Texts SelectBoxCaption="Select village name" />
                                            </asp:DropDownCheckBoxes>
                                            <asp:Label ID="LblerrorDdlVillageName" runat="server" ForeColor="Red"></asp:Label>
							</div>
						</div>					
					</div>
					
					<div class="row " >
                        <div class="col-md-10 mt20">
                            <div class="col-sm-4 control-label">
                                <span class="">Selected Villages:</span>
                            </div>
                            <div class="form-group col-md-5">
							<fieldset class="mt10 sel">
                                     <div class="seldiv" style="margin-left: 0;">
                                      <asp:Label ID="LblMsgVillageName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                                                        <asp:Label ID="LblMsgVillageValue" Font-Size="0px" runat="server" ForeColor="green">You have not selected.</asp:Label>
									</div>
                            </fieldset>
							
							
                            </div>
                        </div>
                    </div>
					<div class="row">
						<div class="col-md-10 mt20">
							<label class="col-sm-4 control-label">
								
							</label>
							<div class="form-group col-md-5">
								  <asp:Button ID="ImgbtnSubmit" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmit_Click" />
                                            <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" CssClass="btn btn-primary btn-success" OnClick="BtnRefresh_Click" />
							</div>
						</div>					
					</div>
					
                    
                   
                    <div class="col-md-12">
                        <div class="" style="overflow-x: auto;">
                            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2 ">
                                <tr>
                                    <td width="90%" align="left">

                                        <asp:GridView ID="gv_villageSearch1"  runat="server" AutoGenerateColumns="False" CellPadding="4" AllowPaging="True" Width="100%" OnPageIndexChanging="gv_villageSearch_PageIndexChanging"
                                            RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" ShowFooter="true" OnRowDataBound="gv_villageSearch1_RowDataBound">
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="top" Wrap="True" ForeColor="White"
                                                BackColor="#005529" CssClass=" table table-bordered table-striped" Font-Bold="True" />
                                            <AlternatingRowStyle CssClass="alt_row" BackColor="White" />

                                            <EmptyDataTemplate>
                                                <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                                            </EmptyDataTemplate>
                                            <Columns>

                                                <asp:TemplateField HeaderText="S No.">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <asp:Label ID="lblsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        <%-- <%#DataBinder.Eval(Container.DataItem, "S_NO")%>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State Name">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <strong>
                                                            <%#DataBinder.Eval(Container.DataItem, "StateName")%>                                         
                                                        </strong>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tiger Reserve name">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <strong>
                                                            <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                                        </strong>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Village Name">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>


                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Village Code" Visible="false">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Population">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Land Area">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Total Agriculture Land Area">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Total Non Agriculture Land Area">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Other Land Area(Ha)">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Value of Agriculture land">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Value of Residential Land">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>




                                                <asp:TemplateField HeaderText="Total Cow">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "NoCows")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Buffalo">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "NoBuffalo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Sheep">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "NoSheep")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Goat">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "NoGoat")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Other animal">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="True" />
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Total Relocated Families">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="True" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Non-Relocated Families">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "vill_status")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="NGO">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "NGO")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="GoogleMap">

                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <strong>
                                                            <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="Edit"
                                                                Visible="true" ImageUrl="~/auth/Adminpanel/REPORT/Gmap.ico" Width="40px" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                                        </strong>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Tiger Reserve name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                            </Columns>
                                            <PagerStyle BackColor="#F7F7DE" CssClass="white-text" ForeColor="Black"
                                                HorizontalAlign="Right" />
                                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="drow" BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                        </asp:GridView>

                                    </td>

                                </tr>



                                <tr>

                                    <%-- this grid used fore view data and select column fore print--%>
                                    <td colspan="2" width="100%" >
                                        <asp:Label ID="lblnodatafound" runat="server" Font-Size="Large" CssClass="red-text"></asp:Label><br />
                                        <asp:GridView ID="gv_villageSearch" runat="server" AutoGenerateColumns="False" CellPadding="4" AllowPaging="True" Width="100%" OnPageIndexChanging="gv_villageSearch_PageIndexChanging"
                                            RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-striped table-responsive" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Horizontal" OnRowCommand="gv_villageSearch_RowCommand" ShowFooter="true" OnRowDataBound="gv_villageSearch_RowDataBound" OnRowDeleting="gv_villageSearch_RowDeleting" OnRowEditing="gv_villageSearch_RowEditing">

                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="top" Wrap="True" ForeColor="White"
                                                BackColor="#005529" CssClass="table table-bordered table-striped table-responsive" Font-Bold="True" />
                                            <AlternatingRowStyle CssClass="alt_row" />

                                            <EmptyDataTemplate>
                                                <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                                            </EmptyDataTemplate>

                                            <Columns>

                                                <asp:TemplateField HeaderText="S No">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>

                                                                <td align="center" valign="top">
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>S No
                                               
                                                                </td>
                                                            </tr>
                                                        </table>


                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>


                                                        <asp:Label ID="lblsno" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                        <%--<%#DataBinder.Eval(Container.DataItem, "S_NO")%>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State Name">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckStateName" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>State Name
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <strong>
                                                            <%#DataBinder.Eval(Container.DataItem, "StateName")%>                                         
                                                        </strong>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tiger Reserve name">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckTigerReservename" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Tiger Reserve name
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <strong>
                                                            <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                                        </strong>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Village Name">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>

                                                                    <asp:LinkButton ID="LnkVName" Font-Underline="True" runat="server" Text="Village Name" ForeColor="White" CommandName="Sort" CommandArgument="VILL_NM">

                                                                    </asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>



                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>


                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Village Code" Visible="false">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox3" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="LnkVillCode" runat="server" Font-Underline="True" Text="Village Code" ForeColor="White" CommandName="Sort" CommandArgument="VILL_CD" />
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Population">
                                                    <HeaderTemplate>

                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox4" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="LnkPopulation" runat="server" Font-Underline="True" Text="Population" ForeColor="White" CommandName="Sort" CommandArgument="VILL_POPU" />
                                                                </td>
                                                            </tr>
                                                        </table>


                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Land Area">
                                                    <HeaderTemplate>

                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox5" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Land Area(Ha)
                                                                </td>
                                                            </tr>
                                                        </table>




                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Total Agriculture Land Area">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox6" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Agriculture Land Area(Ha)
                                                                </td>
                                                            </tr>
                                                        </table>


                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Total Non Agriculture Land Area">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox7" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Non Agriculture Land Area(Ha)
                                                                </td>
                                                            </tr>
                                                        </table>



                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Other Land Area">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox8" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Other Land Area(Ha)
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--add new column  --%>
                                                <asp:TemplateField HeaderText="Value of Agriculture land">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox9" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Value of Agriculture land
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Value of Residential Land">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox10" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Value of Residential Land
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--18june--%>

                                                <asp:TemplateField HeaderText="Total Cow">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="ChkCow" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Cow
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "NoCows")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Buffalo">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="ChkBuffalo" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Buffalo
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "NoBuffalo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Total Sheep">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="ChkSheep" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Sheep
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "NoSheep")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Goat">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="ChkGoat" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Goat
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "NoGoat")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--18june--%>




                                                <asp:TemplateField HeaderText="Other Animal">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox13" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Other Animal
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <%--add new column  --%>


                                                <asp:TemplateField HeaderText="Total Relocated Families">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox14" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Relocated Families
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="True" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Non-Relocated Families">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox15" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Total Non-Relocated Families
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox16" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Status
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "vill_status")%>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="NGO">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox17" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>NGO
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "ngo")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:TemplateField HeaderText="Tiger Reserve name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="GoogleMap">
                                                    <HeaderTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckGoogleMap" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>GoogleMap
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>

                                                        <strong>
                                                            <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%#Eval("CmnDataOperatorTigerReserveID")+","+ Eval("vill_ID")%>' CommandName="Edit"
                                                                Visible="true" ImageUrl="~/auth/Adminpanel/REPORT/Gmap.ico" Width="40px" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                                        </strong>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle BackColor="White" CssClass="GridPager pagination" ForeColor="Black"
                                                HorizontalAlign="Left" />
                                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="drow" />
                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                        </asp:GridView>
                                    </td>
                                </tr>



                                </table>
                        </div>
                    </div>
                    <%--Export grid--%>                    
                
            </div>
        </div>
    </form>
</body>
</html>
