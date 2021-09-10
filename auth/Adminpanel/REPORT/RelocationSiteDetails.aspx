<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RelocationSiteDetails.aspx.cs" Inherits="auth_Adminpanel_REPORT_RelocationSiteDetails" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relocation site details:NTCA</title>
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

        .pagination {
            background: transparent !important;
        }

            .pagination > td {
                border: none !important;
            }

        .table {
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
		.seldiv{border:1px solid #f2f2f2; padding:10px; margin-bottom:15px;word-break: break-word; text-align:left;}
		.seldiv span{font-size:14px;}
		legend{margin-bottom:0; text-align:left;}
		div.dd_chk_select{
			height:30px !important;
		}
		div.dd_chk_select div#caption{top:6px !important;}
		div.dd_chk_drop{top:30px !important;}
		hr{margin-top:0px;}
		#btn_print{margin-left:3px;}
		.red-text{color:red;}
		.mt10{margin-top:10px;}
		.sel legend{font-size:14px;}
		#btnprint {
    margin-left: 3px;
}
.form-group{margin-bottom:0px;}
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
            <div>
                <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
                    <div class="col-sm-12" id="print_area" >
						
						<div class="row">
							<div class="col-md-12 mt20">
								<h3>Relocation site report</h3>
								<hr />
								<div>
																	<asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary btn-add pull-right" Text="Print" 
          onclick="btnprint_Click" /> 
								<asp:Button ID="ImageButton1" runat="server" Text="Back" CssClass="btn btn-primary pull-right" OnClick="ImageButton1_Click" />
								<asp:Button ID="btnexporttoexel" runat="server" CssClass="btn btn-warning btn-add" Text="Export to Excel" 
          onclick="btnexporttoexel_Click" />

							<asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
								
								</div>
								<br />
							</div>
						</div>
						
						<div class="row">
							<div class="col-md-10 mt20">
								<label class="col-sm-4 control-label">
									State Name :
								</label>
								<div class="form-group col-md-5">
								   <asp:Label ID="LblMsgStateName" runat="server"></asp:Label>
								</div>
							</div>							
						</div>
						
						<div class="row">
							<div class="col-md-10 mt20">
								<label class="col-sm-4 control-label">
									Tiger reserve name :
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
                                <span class="">Choose Village name:</span>

                            </div>
                            <div class="form-group col-md-5">
							<fieldset class="mt10 sel">
                                                         
                                                        <%--    Font-Size="0px"--%>
														<div class="seldiv">
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
									Tiger reserve name :
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
                                                            
															<div class="seldiv">
                                                            <asp:Label ID="LblMsgVillageName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                                                            <asp:Label ID="LblMsgVillageValue" Font-Size="0px"  runat="server" ForeColor="green">You have not selected.</asp:Label>
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
													<asp:Button ID="BtnRefresh" runat="server" Text="Reset" CssClass="btn btn-primary btn-success" OnClick="BtnRefresh_Click" />
								</div>
							</div>							
						</div>
					
					
						
                        
                       
                                    
                       
				<div class="" style="overflow-x:auto; margin-top:30px;">
					<table width="100%" id="t1" runat="server" border="0" cellspacing="0" cellpadding="0" class="">
										<tr>
											<%--(<%=Session["sStateName"] %>)--%>
											<td align="center" style="background-color:#e5e5e4; border-right:1px solid #000; padding:5px;">
												<span >Relocation From</span>
											</td>
											<td align="center" style="width: 44%;background-color:#e5e5e4; padding: 5px;">
												<span >Relocated To</span>
											</td>
										</tr>                       
										<tr>
											<td align="center" colspan="2">
												<%--<h4> <span style="color:Red;">*</span>  &nbsp; source from <%= Session["sTigerReserveName"].ToString()%> </h4>--%>
											</td>
										</tr>
					</table>
                   <asp:Panel ID="panel" runat="server">
                                <asp:GridView ID="gvforVillages" runat="server" AllowPaging="True" OnPageIndexChanging="gvforVillages_PageIndexChanging"
                                    PageSize="15" AutoGenerateColumns="False" bgColor="#FCF8ED"
                                    CellPadding="3" Width="100%"
                                    RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-striped" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#000000" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" />
                                    <RowStyle CssClass="drow" BackColor="#FFF7E7" ForeColor="#000000" />
                                    <AlternatingRowStyle CssClass="alt" />
                                    <PagerStyle CssClass="pgr" HorizontalAlign="Center" ForeColor="#000000" />

                                    <Columns>
                                       
                                        <asp:TemplateField  HeaderText="S No.">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                                            <ItemTemplate>
                                                <div>

                                                    <asp:Label ID="lblSno" runat="server" Width="28" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tiger Reserve name">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                                            <ItemTemplate>
                                                <div>
                                                    <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="State">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                                            <ItemTemplate>
                                                <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "statename")%>
                  
                                                </div>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Village Name ">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                                            <ItemTemplate>
                                                 <div>
                                                    <asp:Label ID="lblstname" runat="server" Text='<%#Eval("tvillage") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="State">
                     <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lbldtname" runat="server" Text='<%#Eval("tvstate") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="District">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                                            <ItemTemplate>
                                                <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "District_name")%>
                     
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Tiger Reserve Name">
                   <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                    <strong>
                    
                     <%#DataBinder.Eval(Container.DataItem, "RSRV_AREA_NM")%>
                    
                     </strong>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Tehsil">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff" />
                                            <ItemTemplate>
                                                 <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "FromTehSilName")%>
                    
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gram panchayat">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>
                                                <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "FromGrampanChyatname")%>
                 
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>

                                                 <div>
                                                    State:<%#DataBinder.Eval(Container.DataItem, "statename")%><br />District: <%#DataBinder.Eval(Container.DataItem, "District_name")%><br />
                                                    Tehsil: <%#DataBinder.Eval(Container.DataItem, "FromTehSilName")%><br />
                                                    Gram panchayat:<%#DataBinder.Eval(Container.DataItem, "FromGrampanChyatname")%></div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField>
                                            <ItemStyle HorizontalAlign="Center"  Width="80px" BackColor="#e5e5e4"/>
                                            <ItemTemplate>
                                                <strong>

                                                    <%--<img src="http://localhost:7352/images/arrow_li1.png"  />--%>
                                                    <img src="http://45.115.99.199/ntca_mis/images/arrow_li1.png" />
                                                    <%--<asp:Image ID="Img" runat="server" Width="50px" ImageUrl="~/images/FromTo.jpg" />--%>
                                               
                                                </strong>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tiger Reserve name">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>
                                               <div>
                                                    <%#DataBinder.Eval(Container.DataItem, "ToTigerReserveName")%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="State">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>
                                                <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "ToStatename")%>
                  
                                                </div>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Village Name ">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>
                                                 <div>
                                                    <%#DataBinder.Eval(Container.DataItem, "ToVillage")%>
               
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="District">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>
                                                 <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "ToDisticname")%>
                
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tehsil">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>
                                                 <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "ToTehSilName")%>
                  
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gram panchayat">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>
                                                 <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "ToGrampanChyatname")%>
                     
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address">
                                            <ItemStyle HorizontalAlign="Center" BackColor="#ffffff"/>
                                            <ItemTemplate>
                                                 <div>

                                                    <%#DataBinder.Eval(Container.DataItem, "RELOC_SITE_ADD")%>
                     
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <PagerSettings Mode="Numeric" />
                                    <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                        HorizontalAlign="Center" />
                                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                </asp:GridView>
                                     </asp:Panel>
                </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
