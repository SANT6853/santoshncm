<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FamilyDetail2.aspx.cs" Inherits="auth_Adminpanel_REPORT_FamilyDetail2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    
    <title>Untitled Page</title>
     <%--  <link href="<%# ResolveUrl("~/AUTH/TIGERRESERVEADMIN/CSS/style.css")%>" rel="stylesheet" type="text/css"  />
   <link href="~/TIGERRESERVEADMIN/CSS/style.css" rel="stylesheet" type="text/css"  />
  
   
  
 
       <script src="<%# ResolveUrl("~/AUTH/TIGERRESERVEADMIN/JS/Script.js")%>" type="text/javascript"></script>
       
     <script language ="javascript" src ="../JS/Script.js" type="text/javascript" ></script>--%>
	 
	  <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
     
 <script type="text/javascript">

     function MM_openBrWindow(theURL, winName, features) { //v2.0
         window.open(theURL, winName, features);


     }



    </script>

    
     <script language ="javascript" src ="../JS/Script.js" type="text/javascript" ></script>
    
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
	<style>
		.Compliance_table{
		border:none !important;
		}
		.table_new01{
		border:none;
		}
		.table_new01 a {
    color: #f4b301 !important;
}
.table_new01 table tr td {
    border-bottom: none !important;
    /* border-left: 1px solid #cccccc; */
    padding: 5px 10px;
}
#gv_FamilySearch{
margin-top:20px;
}
	</style>
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
		#Table1>td{ border:none !important;}
		#btn_print{margin-right:3px;}
    </style>
	<style type="text/css">
		@media print 
			{
			    a[href]:after { content: none !important; }
				img[src]:after { content: none !important; }
  
				*{
				font-size:10px !important;
				}
				#ImageButton1,#btn_print,#BtnPdfExport,#BtnExcelExport{ display:none;}
				
		        .table_new01 tr th{ background-color:#005529 !important; color:#fff !important; border:none;}
				
			   @page {size:landscape;}
				.container-fluid{margin-top:0 !important;}

		 }
	</style>
</head>
<body  >
    <form id="form1" runat="server">
 

   <div class=" container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
   <div class="col-sm-12">
		
		
    <table id="print_area" align="center"  class=" table_new01 table-2"  border="0" cellpadding="0" cellspacing="0" width="100%" style="padding:15px; margin-top:20px;" >
				<tr>
						<td align="" width="100%">
							<asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
							<asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnExcelExport_Click"  />
							<asp:Button ID="ImageButton1" runat="server" cssclass="btn btn-primary pull-right"  Text="Close" OnClientClick="javascript:window.close();" />
							<asp:Button ID="btn_print" runat="server" cssclass="btn btn-primary pull-right" Text="Print"   OnClick="btn_print_Click1" />
							<br/>
							<br/>
                        </td>
                </tr>
				
                    <tr>
   
   
     <th colspan="4"  style="color:#fff; text-align:center; font-size:medium; margin-top:20px;"><strong>Village Relocation Family Data</strong></th>
                    
  </tr>
  
  <tr >
  <td colspan="4">
  <table  cellpadding="0" cellspacing="0" width="100%" class="table table-bordered table-stripped" style="margin: 10px 0px; border: 1px solid #cccccc; border-collapse:collapse;">
  
  
  
  
   <tr>
       
        <td width="25%" align="left" class="for-view" > State&nbsp;:</td>
        <td width="25%" align="left"><asp:Label ID="lblstatename" runat="server" CssClass="for-view-lable"></asp:Label></td>
       
        <td width="25%" align="left"  class="for-view" > Reserve&nbsp;: </td>
        <td width="25%" align="left" ><asp:Label ID="lblreaserve" runat="server" CssClass="for-view-lable"  ></asp:Label></td>
        </tr>
      
      
       
        <tr>
        <td width="25%" align="left" class="for-view"> District&nbsp;: </td>
        <td width="25%" align="left"><asp:Label ID="lbldistrict" runat="server" CssClass="for-view-lable"  ></asp:Label></td>
       
        <td width="25%" align="left" class="for-view">  Tehsil&nbsp;: </td>
        <td width="25%" align="left"><asp:Label ID="lbltehsil" runat="server" CssClass="for-view-lable"></asp:Label></td>
        </tr>
       
      
        <tr>
        <td width="25%" align="left" class="for-view"> Gram panchayat&nbsp;: </td>
        <td width="25%" align="left"><asp:Label ID="lblgp" runat="server"   CssClass="for-view-lable"></asp:Label></td>
      
        <td width="25%" align="left" class="for-view"> Village&nbsp;:</td>
        <td width="25%" align="left"><asp:Label ID="lblvillname" runat="server"  CssClass="for-view-lable"></asp:Label></td>
       </tr>

        <tr style="display:none;">
        <td width="25%" align="left" class="for-view"> Village Code&nbsp;: </td>
        <td width="25%" align="left"><asp:Label ID="lblvillcode" runat="server"   CssClass="for-view-lable"></asp:Label></td>
        
        <td>&nbsp; </td>
        <td>&nbsp; </td>
        </tr>
        
     
     
     
     </td></tr></table>
	 
	 
        
        <table id="Table1" align="center"  class=""   border="0" cellpadding="0" cellspacing="0" width="100%"  >
            <tr>
              
                <td  align="center" width="90%" style="padding:0px; border:none;">
                <asp:Label ID="lblnodatafound" runat ="server" ForeColor="red" ></asp:Label>
                
                    <asp:GridView ID="gv_FamilySearch" runat="server" AutoGenerateColumns="False" GridLines="Both" 
                        CellPadding="0" CellSpacing="0" AllowPaging="True" PageSize="15" bgColor="#FCF8ED" border="1"  
                        Width="100%" OnPageIndexChanging="gv_FamilySearch_PageIndexChanging"  RowStyle-Wrap="true" 
                        HeaderStyle-Wrap="true"  OnRowDataBound="gv_FamilySearch_RowDataBound" ShowFooter="true" > 
                        <footerstyle backcolor="#f5f5dc" />
                      <HeaderStyle HorizontalAlign="Center"  VerticalAlign="Middle" Wrap="True" ForeColor="white" CssClass="table table-bordered table-striped" />
                    <AlternatingRowStyle CssClass="" />
                       <EmptyDataTemplate >
                       <asp:Label ID="NoDataFound" runat ="server" Text ="No Record Found" ></asp:Label>
                       
                       </EmptyDataTemplate>
                        <Columns>
                        
                            <asp:TemplateField HeaderText="S No.">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate >
                                    
                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>' ></asp:Label>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="Family Code" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    
                                        <asp:Label ID="lblsno1" runat="server" Text='<%#Eval("FMLY_REG_CD") %>' ></asp:Label>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="Head Name">
                                <ItemStyle HorizontalAlign="Center" Width="19%"/>
                                <ItemTemplate>
                                 
                              <a href="FamilyHeadDetail.aspx?F_ID=<%# DataBinder.Eval(Container.DataItem, "FMLY_ID") %>" target="_blank"  style="color:#3F5E1B;">
                                  <%#DataBinder.Eval(Container.DataItem, "a")%>
                               </a>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Relocation Status" >
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                   
                                        <%#DataBinder.Eval(Container.DataItem, "relocation")%>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Allotted Amount(Rs.)">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                   
                                      <%#DataBinder.Eval(Container.DataItem, "installment")%>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Installment Amount(Rs.)" >
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                 
                                  
                                  
                                   
                       <a href="InstallmentDetail.aspx?s_ID=<%# DataBinder.Eval(Container.DataItem, "schm") %>&F_ID=<%# DataBinder.Eval(Container.DataItem, "FMLY_ID") %>" target="_blank"  style="color:#3F5E1B;">
                     <%#DataBinder.Eval(Container.DataItem, "installment")%>
                      </a>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Option Selected">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                   
                                     <%#DataBinder.Eval(Container.DataItem, "SCHM_ID") %>
                                    
                                    
                                </ItemTemplate>
                               
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Family Member">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                 
                                      <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FMLY_NO_MEMB")%>'
                                      
                                            NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"FMLY_ID","~/AUTH/adminpanel/REPORT/FamilyMemberDetail2.aspx?id={0}" ).ToString()+ "&vid="+Request.QueryString["V_ID"] %>' 
                                        Target="_blank"> 
                                      </asp:HyperLink>
                                   <%--<asp:HyperLink ID="hyperId" runat="server" 
                                    NavigateUrl='~/tigerreserveadmin/report/familymemberdetail2.aspx'></asp:HyperLink>--%>
                      <%-- <a href="FamilyMemberDetail2.aspx?F_ID=<%# DataBinder.Eval(Container.DataItem, "FMLY_ID") %>&V_ID=<%= Request.QueryString["V_ID"].ToString() %>"  target="_blank" style="color:#3F5E1B;">
                    
                      </a>--%>
                                    
                                </ItemTemplate>
                            </asp:TemplateField> 
                                                  

                           
                        </Columns>
                        <PagerStyle CssClass="white-text pagination GridPager" BackColor="#FDF4C9"  ForeColor="Black" HorizontalAlign="Center" BorderWidth="0"  />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass=" " />
                    </asp:GridView>
                    
                </td>
            </tr>
           
          
        </table>
   
</div>
</div>
    </form>
    <script type="text/javascript">
        var Inputs = document.getElementById("gv_FamilySearch").getElementsByTagName("a");
        for (var n = 0; n < Inputs.length; ++n)
            if (Inputs[n].innerHTML == "No Record") {
                Inputs[n].style.textDecoration = 'none';
            }
    </script>
</body>
</html>
