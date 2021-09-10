<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FamilyMemberDetail2.aspx.cs" Inherits="auth_Adminpanel_REPORT_FamilyMemberDetail2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NTCA:Scheme Wise Report</title>

    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <script type="text/javascript">

        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);


        }



    </script>
    <style type="text/css">
        .GridPager a, .GridPager span {
            display: block;
            height: 18px;
            width: 18px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
        }

        .GridPager a {
            background-color: #f5f5f5;
            color: #969696;
            border: 1px solid #969696;
        }

        .GridPager span {
            background-color: #A1DCF2;
            color: #000;
            border: 1px solid #3AC0F2;
        }
		
		
    </style>
	<style type="text/css">
	@media print 
			{
			    a[href]:after { content: none !important; }
				img[src]:after { content: none !important; }
  
				*{
				font-size:10px !important;
				}
				#ImageButton1,#btn_print{ display:none;}
		        #gv_FamilyMemberDetail tr th{ background-color:#005529 !important; color:#fff !important;}
			   @page {size:landscape;}  

		 }
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="" style="margin-top: 100px; padding: 10px;">
                <tr>
                    <td align="right">
                        <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn btn-primary" OnClick="btn_print_Click1" />
                        <asp:Button ID="ImageButton1" runat="server" CssClass="btn btn-primary" Text="Close" OnClientClick="javascript:window.close();" />
                    </td>
                </tr>
                <tr>

                    <td style="color: #743D02; font-size: large;" align="center" width="100%"><strong>Family Memeber's Details</strong>
                    </td>
                </tr>
                <tr>

                    <td align="center">
                        <asp:Label ID="lblnodatafound" runat="server" ForeColor="red"></asp:Label>
                    </td>
                </tr>

                <tr>

                    <td align="center" class="">

                        <asp:GridView ID="gv_FamilyMemberDetail" runat="server" AutoGenerateColumns="False" CellPadding="0"
                            CellSpacing="0" AllowPaging="True" PageSize="10" ShowFooter="true"
                            BorderWidth="1px" BackColor="White"
                            Width="100%" OnPageIndexChanging="gv_FamilyMemberDetail_PageIndexChanging" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-striped">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered table-striped" ForeColor="white" BackColor="#005529" />
                            <RowStyle CssClass="drow" />
                            <AlternatingRowStyle CssClass="alt" />
                             <footerstyle backcolor="#f5f5dc" />
                            <EmptyDataTemplate>
                                <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>

                            </EmptyDataTemplate>
                            <Columns>

                                <asp:TemplateField HeaderText="S No.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <asp:Label ID="lblsno" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Relation With Head">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>




                                            <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_NM")%>
                      
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <strong>

                                                <a href="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("Photo") %>" rel="lightbox[slide]" target="_blank">
                                                    <img src="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("Photo") %>" alt="<%# Eval("Photo") %>" width="100" height="100" /></a>

                                            </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Father Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <strong>

                                                <asp:Label ID="lblageFATHER_NM" runat="server" Text='<%#Eval("FATHER_NM") %>'></asp:Label>

                                            </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DOB">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <strong>

                                                <asp:Label ID="lblageDOB1" runat="server" Text='<%#Eval("DOB1") %>'></asp:Label>

                                            </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Age(Years)">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>



                                            <asp:Label ID="lblageFMLY_MEMB_AGE" runat="server" Text='<%#Eval("FMLY_MEMB_AGE") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sex">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_SEX")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cast">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CAST")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Number">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CONT_NO")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pan card">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "PenCard")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Voter Id">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adhaar Card">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "AdhaarCard")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Any other Card Details">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                           <a href="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("IdentityCardPhoto") %>" rel="lightbox[slide]" target="_blank">
                                                <%#Eval("IdentityCardPhoto") %> </a>
                                        </strong>
                                        <strong>
                                            CARD DETAILS TITLE:<%#DataBinder.Eval(Container.DataItem, "IdentityCardPhotoTitle")%>
                                            </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total number of beneficiaries">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "NoBeneficiary")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marital Status">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "MaritalStatus")%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Education">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>

                                            <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_EDU")%>
                     
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Occupation">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>

                                            <%#DataBinder.Eval(Container.DataItem, "OCCUPATION_NAME")%>
                     
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Annual Income(Rs)">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ANUL_INCM")%>
                      
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="18+ Required information">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                       
                                        <span>
                                            BENEFICIARY'S NAME,ADDRESS & MOBILE NO: <strong><%#DataBinder.Eval(Container.DataItem, "BankNameMobile")%>         
                                            </strong>
                                        </span>
                                        <span>
                                            BANK/POSTAL ACCOUNT NO: <strong><%#DataBinder.Eval(Container.DataItem, "BankPostAccountNo")%>         
                                            </strong>
                                        </span>
                                        <span>
                                            BANK/POST OFFICE NAME:<strong><%#DataBinder.Eval(Container.DataItem, "BankPostOfficeName")%></strong></span><span><strong>IFSC/Pin Code:<%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%></strong></span><span><strong>Bank Post office Address: <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%>         
                                            </strong>
                                            </span>
                                        <span>
                                            
                                                IFSC/PIN CODE:<strong><%#DataBinder.Eval(Container.DataItem, "IFSC")%> 
                                            </strong>
                                        </span>
                                          <span>
                                            
                                               Bank Post office Address:<strong><%#DataBinder.Eval(Container.DataItem, "BankPostOfficeAdress")%> 
                                            </strong>
                                        </span>
                                        <span>
                                            AADHAR NO:<br /> <strong><%#DataBinder.Eval(Container.DataItem, "AadharNo")%>         
                                            </strong>
                                        </span>


                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <PagerSettings />
                            <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black"
                                HorizontalAlign="right" />
                            <RowStyle Wrap="True" />
                        </asp:GridView>

                    </td>
                </tr>


            </table>
        </div>
    </form>
</body>
</html>
