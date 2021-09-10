<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InstallmentDetail.aspx.cs" Inherits="auth_Adminpanel_REPORT_InstallmentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Installment Deatil's</title>
	<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
	<link href="css/print.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


     <script type="text/javascript">

         function MM_openBrWindow(theURL, winName, features) { //v2.0
             window.open(theURL, winName, features);

         }

    </script>
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
        .style2
        {
            width: 51%;
        }
		#ImageButton1{
		  margin:4px;
		}
		table tr th{
		background: #005529 !important;
		color:#fff;
		}
        </style>
</head>
<body>
    <form id="form1" runat="server">
	
	
	<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
	<div class="col-sm-12" style="margin-top:20px;">
	
	
   <table width="100%" border="0"  cellpadding="3" cellspacing="1" id="print_area"  class=""  >
    <tr>
    <td colspan="2" align="">
    <asp:Button ID="ImageButton1" runat="server" CssClass="btn btn-primary pull-right" Text="Close" OnClientClick="javascript:window.close();" />
    <asp:Button ID="BtnPdfExport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPdfExport_Click"  />
    <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnExcelExport_Click"  />
    </td>
    </tr>
    <tr id="I" runat="server" visible="false" >
  <td  colspan="2" style="color:#743D02; font-size:large;" align="center" width="100%"><strong>
                 Option I (Family Installment Details)</strong>
                    </td>
                  
        </tr>
     <tr id="II" runat="server" visible="false">
       <td  colspan="2"  style="background-color: #e1e0c4; color:#743D02; font-size:large;" align="center" width="100%"><strong>
                 Option II (Family Installment Details)</strong>
                    </td>
     </tr>
        
        <tr>
        <td width="100%" align="center" style="padding:15px 0px;">
        <table width="100%" border="0"  cellpadding="3" cellspacing="1" class=" table table-bordered table-striped"  style="padding:20px; width:100%!important;">
        <tr>
    <td colspan="2" bgcolor="#005529" align="center" style="font-size:medium; font-family:Verdana; color:#ffffff;"><strong>Account Holder Details</strong></td>
    
  </tr>
  <tr>
    <td align="right" class="for-view" width="50%"> Family Code :</td>
    <td class="style2"><asp:Label ID="lblFamilyCode" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
    <tr>
    <td align="right" class="for-view" width="50%"> Head Name :</td>
    <td class="style2"><asp:Label ID="lblHeadName" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
    <tr>
    <td align="right" class="for-view" width="50%"> Account Holder Name :</td>
    <td class="style2"><asp:Label ID="lblholname" runat="server" CssClass="for-view-lable"></asp:Label> </td>
    </tr>
      <tr>
    <td align="right" class="for-view" >
        Bank Name :</td>
    <td class="style2"><asp:Label ID="lblbank" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view" >
        Branch Name :</td>
    <td class="style2"><asp:Label ID="lblbranch" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
      <tr>
    <td align="right" class="for-view" >
        Account Number :</td>
    <td class="style2">
    <asp:Label ID="lblacc" runat="server" CssClass="for-view-lable"></asp:Label></td>
    </tr>
        </table>
         </td>
        
        
    
        </tr>
    
    <tr>
    <td colspan="2" width="100%" align="center">
    
    <table width="100%" border="1"  cellpadding="3" cellspacing="1" class=" table table-bordered table-striped" style="padding:20px; width:100%!important;">
    <tr>
    <td colspan="6" align="center" style="font-size:medium; background-color:#005529;">
     <font color="white">Installment Detail</font>
    </td>
    </tr>
    <tr>
     <td colspan="6" align="center" >
     <asp:GridView ID="gv1B" runat="server" AutoGenerateColumns="False"  CellPadding="1"
                        CellSpacing="1" AllowPaging="True" PageSize="10"  
                        Width="98%"  
                          RowStyle-Wrap=true HeaderStyle-Wrap=true   CssClass= "table table-bordered table-striped"> 
                      <HeaderStyle   HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  CssClass="table table-bordered table-striped" /> 
                    <RowStyle CssClass="drow" />
                    <AlternatingRowStyle CssClass="alt" />
                    <PagerStyle CssClass="pgr" />
           
                        
                        <Columns>
                            <asp:TemplateField HeaderText="S. No.">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong>
                                        <%# Container.DataItemIndex+1 %>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                      
                            <asp:TemplateField HeaderText="Bank Name">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong >
                                        <%#DataBinder.Eval(Container.DataItem, "BANK_NAME")%>
                                   </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="A/C No.">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong >
                                        <%#DataBinder.Eval(Container.DataItem, "ACCOUNT_NO")%>
                                   </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong>
                                      <%#DataBinder.Eval(Container.DataItem, "REC_CRT_DT")%>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cheque Number">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong >
                                     <%#DataBinder.Eval(Container.DataItem, "INST_ISCM_CHK_NO")%>
                                    
                                    </strong>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount(Rs.)">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong >
                                     <%#DataBinder.Eval(Container.DataItem, "INST_ISCM_AMT")%>
                                    
                                    </strong>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                                                        

                           
                        </Columns>
                       <PagerSettings />
                        <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                            HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                    </asp:GridView>
     </td>
    </tr>
    <tr>
    <td colspan="6" align="center">
    
    <strong>
        <asp:Label ID="lblamount" runat="server" Text=""></asp:Label></strong>
    </td>
    </tr>
    
    
    </table>
    </td>
    </tr>

    </table>
	</div>
	</div>
    </form>
</body>
</html>
