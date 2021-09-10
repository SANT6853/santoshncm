<%@ Page Language="C#" Title="NTCA:Village-Wise Report" AutoEventWireup="true" CodeFile="VillageSearchII.aspx.cs" Inherits="auth_Adminpanel_REPORT_VillageSearchII" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Village-Wise Report:NTCA</title>
    <%--  <link href="<%# ResolveUrl("~/AUTH/TIGERRESERVEADMIN/CSS/style.css")%>" rel="stylesheet" type="text/css"  />
   <link href="~/TIGERRESERVEADMIN/CSS/style.css" rel="stylesheet" type="text/css"  />
 
       <script src="<%# ResolveUrl("~/AUTH/TIGERRESERVEADMIN/JS/Script.js")%>" type="text/javascript"></script>
       
     <script language ="javascript" src ="../JS/Script.js" type="text/javascript" ></script>--%>

    <script type="text/javascript">

        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);


        }
    </script>

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
        <div class="container-fluid">
            <div class="col-sm-12" style="overflow-x: auto">
                <div class="prntbck">

                    <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn btn-primary pull-right" OnClick="btn_print_Click1" />
                    <asp:Button ID="BtnExportPDF" runat="server" Text="Export to PDF" CssClass="btn btn-warning"
                        OnClick="BtnExportPDF_Click" />
                     <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning"
                        OnClick="BtnExcelExport_Click" />
                    <asp:Button ID="ImageButton1" runat="server" Text="Back" CssClass="btn btn-primary pull-right" OnClick="ImageButton1_Click" />
                </div>
                <table id="print_area" width="100%" border="0"
                    cellpadding="3" cellspacing="1" class=" " style="margin-top: 10px; padding: 15px;">

                    <tr>
                        <td style="color: #743D02; font-size: large;" align="center" width="100%">
                            <%if (Session["UserType"].ToString().Equals("4"))
                              {%>
                            <strong><%=Session["sTigerReserveName"].ToString() %> Village-Wise Report  </strong>
                            <%} %>

                            <%if (Session["UserType"].ToString().Equals("3"))
                              {%>
                            <strong>Village-Wise Report </strong>
                            <%} %>

                            <%if (Session["UserType"].ToString().Equals("1"))
                              {%>

                            <strong>Village-Wise Report</strong>

                            <div class="" style="margin-top: 20px;">
                                <div class="row form-group" style="margin-left: 0;">
                                    <div class="col-sm-2 text-left">
                                        State Name:
                                    </div>
                                    <div class="col-sm-4 text-left">
                                        <asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>


                                <div class="row form-group" style="margin-left: 0;">
                                    <div class="col-sm-2 text-left">
                                        Tiger reserve name:
                                    </div>
                                    <div class="col-sm-4 text-left">
                                        <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div class="row form-group" style="margin-left: 0;">
                                    <div class="col-sm-2 text-left">
                                    </div>
                                    <div class="col-sm-4 text-left">
                                        <asp:Button ID="ImgbtnSubmit" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="ImgbtnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
            </div>
            <%} %>

            <%if (Session["UserType"].ToString().Equals("2"))
              {%>
            <strong>Village-Wise Report </strong>

            <%} %>         
                   
                    </td>
                </tr>
                <tr>
                    <td align="center">

                        <asp:Label ID="lblnodatafound" runat="server" ForeColor="red"></asp:Label>
                    </td>

                </tr>
            <tr>
                <td align="center">
                    <span style="text-align: center;">
                        <asp:Label ID="Label1" runat="server" CssClass="for-view"></asp:Label>
                        <asp:Label ID="Label2" runat="server" CssClass="for-view-lable"></asp:Label>
                        &nbsp; &nbsp;
                                     
                       <asp:Label ID="Label3" runat="server" CssClass="for-view"></asp:Label>
                        <asp:Label ID="Label4" runat="server" CssClass="for-view-lable"></asp:Label>
                    </span>

                </td>

            </tr>
            <tr>
                <td class="table_new01">
                    <asp:GridView ID="gv_villageSearch" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        CellSpacing="0" AllowPaging="True" PageSize="15" Width="100%" OnPageIndexChanging="gv_villageSearch_PageIndexChanging"
                        RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table-bordered table-striped" OnRowDataBound="gv_villageSearch_RowDataBound" ShowFooter="true">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="white"
                            BackColor="#FDF4C9" CssClass="table table-bordered table-striped" />
                        <AlternatingRowStyle CssClass="" />
                        <EmptyDataTemplate>
                            <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="S No.">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#Container.DataItemIndex+1 %>
                                        <%--<asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>--%>
                                    </strong>
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
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <strong>
                                      <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                       <%-- <a href="FamilyDetail2.aspx?V_ID=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %> " target="_blank"
                                            style="color: #3F5E1B;">
                                            <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                        </a>--%>

                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Village Code" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Population">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Land Area(Ha)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Total Agriculture Land Area(Ha)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Total Non Agriculture Land Area(Ha)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Land Area(Ha)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Value of Agriculture land">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Value Residential Land">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Cow">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "NoCows")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Buffalo">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "NoBuffalo")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Sheep">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "NoSheep")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Goat">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "NoGoat")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Animal">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Relocated Families">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%>
                                    </strong>
                                </ItemTemplate>
                                <HeaderStyle Wrap="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Non- Relocated Families">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" Visible="false">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "vill_status")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NGO" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                    
                                        <asp:HiddenField ID="villid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' />
                                        <asp:HyperLink ID="hyperngo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ngo")%>'
                                            ForeColor="#3F5E1B">  
                                        </asp:HyperLink>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                        </Columns>
                        <PagerStyle CssClass="white-text pagination GridPager" Font-Bold="True" ForeColor="Black"
                            HorizontalAlign="left" />
                        <RowStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="True" CssClass="" />
                    </asp:GridView>
                
                
                <%--Export grid--%>
                    <asp:GridView ID="GridViewExport" Visible="false" runat="server" AutoGenerateColumns="False" CellPadding="0"
                        CellSpacing="0"  Width="100%" OnPageIndexChanging="GridViewExport_PageIndexChanging"
                        RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table-bordered table-striped" OnRowDataBound="GridViewExport_RowDataBound" ShowFooter="true">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="white"
                            BackColor="#FDF4C9" CssClass="table table-bordered table-striped" />
                        <AlternatingRowStyle CssClass="" />
                        <EmptyDataTemplate>
                            <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="S No.">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#Container.DataItemIndex+1 %>
                                        <%--<asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>--%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State Name" Visible="false">
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
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <strong>
                                      <asp:Label ID="LblVillageName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>'></asp:Label>
                                      

                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Village Code" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Population">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Land Area(Ha)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Total Agriculture Land Area(Ha)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Total Non Agriculture Land Area(Ha)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Land Area(Ha)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Value of Agriculture land">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Value Residential Land">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Cow">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "NoCows")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Buffalo">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "NoBuffalo")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Sheep">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "NoSheep")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total Goat">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "NoGoat")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Animal">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Relocated Families">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%>
                                    </strong>
                                </ItemTemplate>
                                <HeaderStyle Wrap="True" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Non- Relocated Families">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" Visible="false">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <strong>
                                        <%#DataBinder.Eval(Container.DataItem, "vill_status")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NGO" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong>
                                     <asp:Label ID="LblNgo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ngo")%>'></asp:Label>
                                        <asp:HiddenField ID="villid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' />
                                        <asp:HyperLink ID="hyperngo" Visible="false" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ngo")%>'
                                            ForeColor="#3F5E1B">  
                                        </asp:HyperLink>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                        </Columns>
                        <PagerStyle CssClass="white-text pagination GridPager" Font-Bold="True" ForeColor="Black"
                            HorizontalAlign="left" />
                        <RowStyle HorizontalAlign="left" VerticalAlign="Middle" Wrap="True" CssClass="" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div></div>

                </td>
            </tr>
            <tr>

                <td align="center" style="padding: 20px;"></td>
            </tr>

            </table>
        </div>
        </div>

    </form>
</body>
</html>
