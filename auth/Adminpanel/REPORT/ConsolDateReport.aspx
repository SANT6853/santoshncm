<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsolDateReport.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="auth_Adminpanel_REPORT_ConsoldateReport_ConsolDateReport" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consoldate Report(NTCA Admin)</title>
    <script language="javascript" src="../JS/Script.js" type="text/javascript"></script>

    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	
    <style type="text/css">
        .Text-Center {
            text-align: left;
            width: 20px;
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
		.pagination {
			display: table-row;
			}
        .pagination td {
            border: none !important;
            padding: 1px;
        }

        #contentbody_gvforVillages tr th:nth-child(1) {
            width: 1%;
        }
		.seldiv{border:1px solid #f2f2f2; padding:10px; margin-bottom:15px;word-break: break-word;}
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

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
		<div class="col-sm-12">
            <div class="inner-content-right">
                <div class="row">
                    <div class="col-md-12 mt20">
                        <h3>Consolidate Report</h3>
                        <hr />
                        <div>
						<asp:Button ID="btn_print" runat="server" Text="Print" OnClick="btn_print_Click" CssClass="btn btn-primary pull-right" />
                            <asp:Button ID="BtnBackConsoldateReport" runat="server" Text="Back" CssClass="btn btn-primary btn-add pull-right"
                                OnClick="BtnBackConsoldateReport_Click" />
                             <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning"
                            OnClick="BtnExcelExport_Click" />
                        <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click" />
                        
                        </div>
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            State Name<span style="color: red;">*</span>:
                        </label>
                        <div class="form-group col-md-5">
                            <asp:DropDownCheckBoxes ID="DdlStateName" runat="server" AutoPostBack="true" Font-Size="Larger"
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged">
                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                <Texts SelectBoxCaption="Select State Name" />
                            </asp:DropDownCheckBoxes>
                            <%--<asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:DropDownList>--%>
						
							<fieldset class="mt10 sel">
                                    <legend>Selected states:</legend>
									<div class="seldiv" style="margin-left: 0;">
                                    <asp:Label ID="LblMsgStateName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                                    <asp:Label ID="LblMsgStateValue" Font-Size="0px" runat="server" ForeColor="green">You have not selected.</asp:Label>
									</div>
                            </fieldset>  
                        </div>
                    </div>
					
                </div>
				
                <div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            Choose Tiger Reserve name<span class="red-text">*</span>
                        </label>
                        <div class="form-group col-md-5">
                            <asp:DropDownCheckBoxes ID="DdlTigerReserve" runat="server" AutoPostBack="true" Font-Size="Larger"
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlTigerReserve_SelectedIndexChanged">
                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                <Texts SelectBoxCaption="Select Tiger reserve name" />
                            </asp:DropDownCheckBoxes>
                            <asp:Label ID="ErrorChkTigerReserveName" runat="server" ForeColor="Red"></asp:Label>
						
							<fieldset class="mt10 sel">
                                    <legend>Selected Tiger reserve:</legend>
									<div class="seldiv" style="margin-left: 0;">
                                    <asp:Label ID="LblMsgTigerReserveName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                                    <asp:Label ID="LblMsgTigerReserveValue" Font-Size="0px"  runat="server" ForeColor="green">You have not selected.</asp:Label>
									</div>
                                </fieldset>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            Choose Village name<span class="red-text">*</span>
                        </label>
                        <div class="form-group col-md-5">
                            <asp:DropDownCheckBoxes ID="DdlVillageName" runat="server" AutoPostBack="true" Font-Size="Larger"
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlVillageName_SelectedIndexChanged">
                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                <Texts SelectBoxCaption="Select village name" />
                            </asp:DropDownCheckBoxes>
                            <asp:Label ID="LblerrorDdlVillageName" runat="server" ForeColor="Red"></asp:Label>
							
							 <fieldset class="mt10 sel">
                                    <legend>Selected Villages:</legend>
									<div class="seldiv" style="margin-left: 0;">
                                    <asp:Label ID="LblMsgVillageName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                                    <asp:Label ID="LblMsgVillageValue" runat="server" Font-Size="0px"  ForeColor="green">You have not selected.</asp:Label>
									</div>
                                </fieldset>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            Choose <span class="red-text">*</span>
                        </label>
                        <div class="form-group col-md-5">
                            <asp:CheckBox ID="cbSelectAll" OnCheckedChanged="cbSelectAll_CheckedChanged" Checked="true" AutoPostBack="true" runat="server" />
                            SELECT ALL/UNCHECKED ALL 
                            <asp:CheckBoxList ID="ChkReportShowHide" runat="server" RepeatDirection="Horizontal" RepeatColumns="1">
                                <asp:ListItem Text="VILLAGE REPORT" Value="1" ></asp:ListItem>
                                <asp:ListItem Text="FAMILY REPORT" Value="2" ></asp:ListItem>
                                <asp:ListItem Text="CDP REPORT" Value="3" ></asp:ListItem>
                                <asp:ListItem Text="NGO REPORT" Value="4" ></asp:ListItem>
                                <asp:ListItem Text="RELOCATED REPORT" Value="5" ></asp:ListItem>
                                <asp:ListItem Text="RELOCATION SITE REPORT" Value="6" ></asp:ListItem>
                                <asp:ListItem Text="RELOCATION PROGRESS REPORT" Value="7" ></asp:ListItem>
                            </asp:CheckBoxList>
                            <asp:Label ID="LblErrorChkReportShowHide" runat="server" ForeColor="Red"></asp:Label>

                        </div>
                    </div>
                </div>


                <!--<div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            <span class="">You have selected following labels</span>

                        </label>
                        
                    </div>
                </div>-->
                <div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            <span class="red-text"></span>
                        </label>
                        <div class="form-group col-md-5">

                            <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add"
                                OnClick="BtnSearch_Click" />
                            <asp:Button ID="BtnRefresh" runat="server" Text="Reset" CssClass="btn btn-primary btn-add"
                                OnClick="BtnRefresh_Click" />
                            <asp:Label ID="LblErrorBtnSearch" runat="server" ForeColor="Red"></asp:Label>

                        </div>
                    </div>
                </div>
                <%--<div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            Choose Family head name<span class="red-text">*</span>
                        </label>
                        <div class="form-group col-md-5">
                            <asp:DropDownCheckBoxes ID="DdlFamilyHeadName" runat="server" AutoPostBack="true" Font-Size="Larger"
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlFamilyHeadName_SelectedIndexChanged">
                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                <Texts SelectBoxCaption="Select family head name" />
                            </asp:DropDownCheckBoxes>
                            <asp:Label ID="LblErrorDdlFamilyHeadName" runat="server" ForeColor="Red"></asp:Label>

                        </div>
                    </div>
                </div>--%>
                <%--<div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            Choose Family member name<span class="red-text">*</span>
                        </label>
                        <div class="form-group col-md-5">
                            <asp:DropDownCheckBoxes ID="DdlFamilyMember" runat="server" AutoPostBack="true" Font-Size="Larger"
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlFamilyMember_SelectedIndexChanged">
                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                <Texts SelectBoxCaption="Select Family name" />
                            </asp:DropDownCheckBoxes>
                            <asp:Label ID="LblErrorDdlFamilyMember" runat="server" ForeColor="Red"></asp:Label>

                        </div>
                    </div>
                </div>--%>
                <%--<div class="row">
                    <div class="col-md-10 mt20">
                        <label class="col-sm-4 control-label">
                            Choose Cdp Agency name<span class="red-text">*</span>
                        </label>
                        <div class="form-group col-md-5">
                            <asp:DropDownCheckBoxes ID="DdlCdpAgencyName" runat="server" AutoPostBack="true" Font-Size="Larger"
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlCdpAgencyName_SelectedIndexChanged">
                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                <Texts SelectBoxCaption="Select cdp Agency name" />
                            </asp:DropDownCheckBoxes>
                            <asp:Label ID="LblErrorDdlCdpAgencyName" runat="server" ForeColor="Red"></asp:Label>

                        </div>
                    </div>
                </div>--%>
                <div class="row">
				<div class="col-sm-12" style="overflow-x:scroll;">
                    <asp:GridView ID="GridViewNarenConsoldateReport" runat="server" AutoGenerateColumns="false" CellPadding="0" ShowFooter="true"
                        CellSpacing="0" AllowPaging="True" PageSize="15" Width="100%" OnPageIndexChanging="GridViewNarenConsoldateReport_PageIndexChanging"
                        RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-striped" OnRowCommand="GridViewNarenConsoldateReport_RowCommand" OnRowDataBound="GridViewNarenConsoldateReport_RowDataBound">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" />
                        <RowStyle CssClass="drow" />
                        <AlternatingRowStyle CssClass="alt" BackColor="White" />
                        <PagerStyle CssClass="pgr" HorizontalAlign="Right" />
                        <Columns>
                            <asp:TemplateField HeaderText="S No." HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="left" />
                                <ItemTemplate>
                                    <strong>
                                        <%#Container.DataItemIndex+1 %>
                                        <%--<asp:Label ID="lblsno1" runat="server" Text='<%#Eval("RowNumber") %>'></asp:Label>--%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State Name" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                        <asp:Label ID="LblStateName" runat="server" Text='<%#Eval("StateName") %>'></asp:Label>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tiger Reserve " HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                        <asp:Label ID="LblTigerReserve" runat="server" Text='<%#Eval("NoOfTigerReserve") %>'></asp:Label>
                                        <%--<asp:LinkButton ID="LnkTigerReserve" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfTigerReserve") %>' CommandName="TigerReserve" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>--%>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Village" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                         <asp:Label ID="LblVillage" Visible="false" runat="server" Text='<%#Eval("NoOfVillage") %>'></asp:Label>
                                        <asp:LinkButton ID="LnkVillage" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfVillage") %>' CommandName="Village" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Family" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                         <asp:Label ID="LblFamilyhead" Visible="false" runat="server" Text='<%#Eval("NoOfFamilyHead") %>'></asp:Label>
                                        <asp:LinkButton ID="LnkFamilyhead" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfFamilyHead") %>' CommandName="Familyhead" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Family Member" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>

                                        <asp:Label ID="LblFamilyMember" runat="server" Text='<%#Eval("NoOfFamilyMember") %>'></asp:Label>
                                        <%--<asp:LinkButton ID="LnkFamilyMember" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfFamilyMember") %>' CommandName="FamilyMember" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateName") %>'></asp:LinkButton>--%>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Benificiaries" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                        <asp:Label ID="LblBenificiaries" runat="server" Text='<%#Eval("NoOfFamilyHead") %>'></asp:Label>
                                        <%--<asp:LinkButton ID="LnkBenificiaries" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfBeneficary") %>' CommandName="Benificiaries" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateName") %>'></asp:LinkButton>--%>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="(CDP)Executive Agency" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                          <asp:Label ID="LblExecutiveAgency" Visible="false" runat="server" Text='<%#Eval("NoOfCDPAgencyInVillage") %>'></asp:Label>
                                        <asp:LinkButton ID="LnkExecutiveAgency" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfCDPAgencyInVillage") %>' CommandName="CDPExecutiveAgency" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="(CDP)Allotement Amount (In Rs)" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                        <asp:Label ID="LblAllotementAmount" runat="server" Text='<%#Eval("CDPAllotementAmount") %>'></asp:Label>
                                        <%--<asp:LinkButton ID="LnkAllotementAmount" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("CDPAllotementAmount") %>' CommandName="AllotementAmount" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateName") %>'></asp:LinkButton>--%>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="(CDP)Amount Used (In Rs)" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                        <asp:Label ID="LblAmountUsed" runat="server" Text='<%#Eval("CDPAllotementUSedAmount") %>'></asp:Label>
                                        <%--<asp:LinkButton ID="LnkAmountUsed" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("CDPAllotementUSedAmount") %>' CommandName="AmountUsed" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateName") %>'></asp:LinkButton>--%>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NGO" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                         <asp:Label ID="LblNGO" Visible="false" runat="server" Text='<%#Eval("NoOfNgo") %>'></asp:Label>
                                        <asp:LinkButton ID="LnkNGO" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfNgo") %>' CommandName="NGO" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amounts(Rupees.) released by tiger reserve" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                        <asp:Label ID="LblngoAmountUsed" runat="server" Text='<%#Eval("NgoAllotAmount") %>'></asp:Label>
                                        <%--<asp:LinkButton ID="LnkngoAmountUsed" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NgoAllotAmount") %>' CommandName="ngoAmountUsed" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateName") %>'></asp:LinkButton>--%>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No of Relocated Village" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                          <asp:Label ID="LblRelocationStatus" Visible="false" runat="server" Text='<%#Eval("NoOfVillageRelocated") %>'></asp:Label>
                                        <asp:LinkButton ID="LnkRelocationStatus" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfVillageRelocated") %>' CommandName="RelocationStatus" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Map" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                         <asp:Label ID="LblMap" Visible="false" runat="server" Text='<%#Eval("RelocationSiteReport") %>'></asp:Label>
                                        <asp:LinkButton ID="LnkMap" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("RelocationSiteReport") %>' CommandName="Map" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>
                                        <%--<asp:LinkButton ID="LnkRelocationMap" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("RelocationMap") %>' OnClick="Display"></asp:LinkButton>--%>
                                    
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Relocation Progress Report" HeaderStyle-CssClass="Text-Center">
                                <ItemStyle HorizontalAlign="center" />
                                <ItemTemplate>

                                    <b>
                                         <asp:Label ID="LblRelocationProgressReport" Visible="false" runat="server" Text='<%#Eval("RelocationProgressReport") %>'></asp:Label>
                                        <asp:LinkButton ID="LnkRelocationProgressReport" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("RelocationProgressReport") %>' CommandName="RelocationProgressReport" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>
                                        <%--<asp:LinkButton ID="LnkRelocationMap" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("RelocationMap") %>' OnClick="Display"></asp:LinkButton>--%>
                                    
                                    </b>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                        <PagerSettings Mode="Numeric" />
                        <PagerStyle CssClass="GridPager pagination" Font-Bold="True" ForeColor="black"
                            HorizontalAlign="left" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>

                   <%-- Below Grid for Exporting--%>
				   </div>
                </div>
                <div id="NarenDivMessageError" runat="server" style="color: red; font-weight: bold;" visible="false">
                    NO RECORD FOUND
                </div>

            </div>
        </div>
        <%--Tiger resve popUp--%>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">Student Fee Details</h4>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                            <div class="form-group">
                                <asp:Label ID="lblstudent" runat="server" Text="Aadmission No: "></asp:Label>
                                <asp:Label ID="lblstudentid" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Month"></asp:Label>
                                <asp:Label ID="lblmonth" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                                <asp:TextBox ID="txtAmount" runat="server" TabIndex="3" MaxLength="75" CssClass="form-control"
                                    placeholder="Enter Amount"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <%--<asp:Button ID="btnSave" runat="server" Text="Pay" OnClick="btnSave_Click" CssClass="btn btn-info" />--%>
                        <button type="button" class="btn btn-info" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <script type='text/javascript'>
            function openModal() {
                $('[id*=myModal]').modal('show');

            }
        </script>
    </form>
</body>
</html>
