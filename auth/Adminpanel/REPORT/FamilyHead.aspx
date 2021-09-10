<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FamilyHead.aspx.cs" Inherits="auth_Adminpanel_REPORT_FamilyHead" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Family:NTCA</title>

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
		.form-group {
    margin-bottom: 0px;
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
            padding: 1px;
        }

        #contentbody_gvforVillages tr th:nth-child(1) {
            width: 1%;
        }
		.seldiv{border:1px solid #d9d6d6; padding:10px; margin-bottom:15px;word-break: break-word; text-align:left;}
		.seldiv span{font-size:14px;}
		legend{margin-bottom:0; text-align:left;}
		div.dd_chk_select{
			height:30px !important;
		}
		div.dd_chk_select div#caption{top:6px !important;}
		div.dd_chk_drop{top:30px !important;}
		hr{margin-top:0px;}
		#btn_print{margin-left:3px;}
		.mt10{margin-top:10px;}
		.sel legend{font-size:14px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
                <div class="col-sm-12" style="overflow-x: auto">
                    <div class="row">
                        <div class="col-md-12 mt20">
                            <h3>Family Report</h3>
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
                    <div class="row form-group" >
					<div class="col-md-10 mt20">
						<label class="col-sm-4 control-label">
                            State Name:
                        </label>
                       
                        <div class="col-sm-6 text-left">
                            <%--<asp:DropDownList ID="DdlStateName" Visible="false" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>--%>
                            <asp:Label ID="LblMsgStateName" runat="server"></asp:Label>
                        </div>
                    </div>
                    </div>
                    <div class="row form-group" >
					<div class="col-md-10 mt20">
						<label class="col-sm-4 control-label">
                           Tiger reserve name:
                        </label>
                        <div class="col-sm-6 text-left">

                            <asp:DropDownCheckBoxes ID="DdlTigerReserve" runat="server" AutoPostBack="true" Font-Size="Larger"
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlTigerReserve_SelectedIndexChanged">
                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                <Texts SelectBoxCaption="Select Tiger reserve name" />
                            </asp:DropDownCheckBoxes>
                            <asp:Label ID="ErrorChkTigerReserveName" runat="server" ForeColor="Red"></asp:Label>
							
                        </div>
                        </div>
                    </div>
					<div class="row form-group" >
                        <div class="col-md-10 mt20">
                            <div class="col-sm-4 control-label">
                                <span class="">Selected Tiger reserve:</span>

                            </div>
                            <div class="form-group col-md-5">
							<fieldset class="mt10 sel">
                                       
										<div class="seldiv">
                                        <asp:Label ID="LblMsgTigerReserveName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                                        <asp:Label ID="LblMsgTigerReserveValue" Font-Size="0px" runat="server" ForeColor="green">You have not selected.</asp:Label>
										</div>
                                    </fieldset>
                            </div>
                        </div>
                    </div>
					
                    <div class="row form-group" >
					<div class="col-md-10 mt20">
						<label class="col-sm-4 control-label">
                            Choose Village name:
                        </label>
                       
                        <div class="col-sm-6 text-left">
                            <asp:DropDownCheckBoxes ID="DdlVillageName" runat="server" AutoPostBack="true" Font-Size="Larger"
                                AddJQueryReference="True" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlVillageName_SelectedIndexChanged">
                                <Style SelectBoxWidth="250" DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                                <Texts SelectBoxCaption="Select village name" />
                            </asp:DropDownCheckBoxes>
                            <asp:Label ID="LblerrorDdlVillageName" runat="server" ForeColor="Red"></asp:Label>
							
                        </div>
                        </div>
                    </div>
                   <div class="row form-group" >
                        <div class="col-md-10 mt20">
                            <div class="col-sm-4 control-label">
                                <span class="">Selected Villages:<span>

                            </div>
                            <div class="form-group col-md-5">
							<fieldset class="mt10 sel">
                                       
										<div class="seldiv">
                                        <asp:Label ID="LblMsgVillageName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                                        <asp:Label ID="LblMsgVillageValue" Font-Size="0px" runat="server" ForeColor="green">You have not selected.</asp:Label>
										</div>
                                    </fieldset>
                            </div>
                        </div>
                    </div>

                    <div class="row form-group" >
					<div class="col-md-10 mt20">
                        <div class="col-sm-4 text-left">
                        </div>
                        <div class="col-sm-4 text-left">
                            <asp:Button ID="ImgbtnSubmit" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmit_Click" />
                            <asp:Button ID="BtnRefresh" runat="server" Text="Reset" CssClass="btn btn-primary btn-success" OnClick="BtnRefresh_Click" />
                        </div>
                    </div>
                    </div>
                    <div class="row">
                        <asp:GridView ID="GridViewNarenConsoldateReport" runat="server" AutoGenerateColumns="false" CellPadding="0" ShowFooter="true"
                            CellSpacing="0" AllowPaging="True" PageSize="15" Width="100%" OnPageIndexChanging="GridViewNarenConsoldateReport_PageIndexChanging"
                            RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-striped" OnRowCommand="GridViewNarenConsoldateReport_RowCommand">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" />
                            <RowStyle CssClass="drow" />
                            <AlternatingRowStyle CssClass="alt" BackColor="White" />
                            <PagerStyle CssClass="pgr" HorizontalAlign="Right" />
                            <Columns>
                                <asp:TemplateField HeaderText="S No." HeaderStyle-CssClass="Text-Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#Container.DataItemIndex+1 %>
                                            <%--<asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>--%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Tiger Reserve " HeaderStyle-CssClass="Text-Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>

                                        <b>
                                            <asp:Label ID="LblTigerReserve" runat="server" Text='<%#Eval("TigerReserveName") %>'></asp:Label>
                                            <%--<asp:LinkButton ID="LnkTigerReserve" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("NoOfTigerReserve") %>' CommandName="TigerReserve" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "StateID") %>'></asp:LinkButton>--%>
                                        </b>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Village" HeaderStyle-CssClass="Text-Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>

                                        <b>
                                            <asp:Label ID="LblVillage" runat="server" Text='<%#Eval("Vill_NM") %>'></asp:Label>

                                        </b>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Family" HeaderStyle-CssClass="Text-Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>

                                        <b>
                                            <asp:Label ID="LblFamily" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>

                                        </b>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Family Details" HeaderStyle-CssClass="Text-Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>

                                        <b>
                                            <%--CommandArgument='<%#Eval("ScrapId")+","+ Eval("UserId")+","+ Eval("UserId")%>'--%>
                                            <asp:Label ID="LblFamilyhead" Visible="false" runat="server" Text='<%#Eval("Family") %>'></asp:Label>
                                             <asp:LinkButton ID="LnkFamilyhead" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("Family") %>' CommandName="Familyhead" CommandArgument='<%#Eval("TigerReserveName")+","+ Eval("VILL_ID")+","+ Eval("FMLY_ID")%>'></asp:LinkButton>
                                        </b>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Family Members Details" HeaderStyle-CssClass="Text-Center">
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>

                                        <b>
                                             <asp:Label ID="LblFamilyMemberDetails" Visible="false" runat="server" Text='<%#Eval("FamilyMemberDetails") %>'></asp:Label>
                                            <asp:LinkButton ID="LnkFamilyMemberDetails" ForeColor="Blue" Font-Underline="true" runat="server" Text='<%#Eval("FamilyMemberDetails") %>' CommandName="FamilyMember" CommandArgument='<%#Eval("TigerReserveName")+","+ Eval("VILL_ID")+","+ Eval("FMLY_ID")%>'></asp:LinkButton>
                                        </b>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <PagerSettings Mode="Numeric" />
                            <PagerStyle CssClass="GridPager pagination" Font-Bold="True" ForeColor="black"
                                HorizontalAlign="right" />
                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                            <SortedAscendingHeaderStyle BackColor="#848384" />
                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                            <SortedDescendingHeaderStyle BackColor="#575357" />
                        </asp:GridView>
                    </div>
                    <div id="NarenDivMessageError" runat="server" style="color: red; font-weight: bold; text-align:center;" visible="false">
                        NO RECORD FOUND
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
