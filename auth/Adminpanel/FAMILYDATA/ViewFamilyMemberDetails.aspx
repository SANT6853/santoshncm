<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFamilyMemberDetails.aspx.cs" Inherits="auth_Adminpanel_FamiliyData_ViewFamilyMemberDetails" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Untitled Page</title>
<script language="javascript" src="../JS/Script.js" type="text/javascript"></script>
<link href="~/TIGERRESERVEADMIN/CSS/style.css" rel="stylesheet" type="text/css" />
<link href="~/TIGERRESERVEADMIN/CSS/ForValidationControl.css" type="text/css" />
<link href="~/TIGERRESERVEADMIN/CSS/ModelStyleSheet.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
<script type="text/javascript">
	function MM_openBrWindow(theURL, winName, features) { //v2.0
		window.open(theURL, winName, features);
	}
</script>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<style>
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
.anchorColor {
	color: blue;
	text-decoration-line: underline;
}
.alt_row {
	background: #fff !important;
}
.background {
	background: #fff !important;
}
table tr {
	text-align: left !important;
}
.for-view, .alt_row {
	text-align: left !important;
}
.alt_row {
	font-weight: bold;
}
#headdetails {
	overflow-x:auto;
}
#btnPrint {
	margin-right:3px;
}
#gv_FamilyMemberDetail th {
	background:#005529;
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
#btnPrint, #ImageButton1 {
	display: none;
}
table {
}
th, td {
}
.table-2 {
	border: 1px solid #333333 !important;
}
.table-2 {
	margin-top: 0 !important;
}
}
</style>
</head>
<body>
<form id="form1" runat="server">
  <div class=" container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 40px; background: #fff;">
    <div class="col-sm-12">
      <div class="" style="margin-top: 20px;">
        <div class="row">
          <div class="col-md-12 mt20"> 
            <!--<h3>heading</h3>
				<hr />-->
            <div class="form-group">
              <asp:Button ID="BtnExcelExport" runat="server" Text="Export to Excel" CssClass="btn btn-warning" OnClick="BtnExcelExport_Click" />
              <asp:Button ID="BtnPDFexport" runat="server" Text="Export to Pdf" CssClass="btn btn-warning" OnClick="BtnPDFexport_Click" />
              <asp:Button ID="ImageButton1" runat="server" Text="Back" OnClick="ImageButton1_Click" CssClass="btn btn-primary pull-right" />
              <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" Width="94px" CssClass="btn btn-primary pull-right" />
			  </div>
			  <div>
              <asp:Panel ID="PRINT" runat="server">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class=" table table-bordered" style="padding-top: 10px;">
                  <tr>
                    <td colspan="4" bgcolor="#005529" align="center" style="color: #fff; font-size: large;"><strong>Family Details</strong></td>
                  </tr>
                  <tr>
                    <td colspan="4" align="center" class="background"><asp:Label ID="lblMsg" runat="server" CssClass="red-text"></asp:Label></td>
                  </tr>
                  <tr class="alt_row">
                    <td align="right" class="for-view">State :</td>
                    <td><asp:Label ID="lblstateName" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    <td align="right" class="for-view">District :</td>
                    <td><asp:Label ID="lbldtname" runat="server" CssClass="for-view-lable"></asp:Label></td>
                  </tr>
                  <tr class="background">
                    <td align="right" class="for-view">Reserve :</td>
                    <td><asp:Label ID="lblrsname" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    <td align="right" class="for-view">Tehsil :</td>
                    <td><asp:Label ID="lbltehsil" runat="server" CssClass="for-view-lable"></asp:Label></td>
                  </tr>
                  <tr>
                    <td align="right" class="alt_row">Grampanchayat :</td>
                    <td class="alt_row"><asp:Label ID="lblgp" runat="server" CssClass="for-view-lable"></asp:Label></td>
                    <td align="right" class="alt_row">Village :</td>
                    <td class="alt_row"><asp:Label ID="lblname" runat="server" CssClass="for-view-lable"></asp:Label></td>
                  </tr>
                </table>
                <asp:GridView ID="gv_FamilyMemberDetail" runat="server" AutoGenerateColumns="False" CellPadding="0" ShowFooter="true" CellSpacing="0" PageSize="10" Width="100%" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered" OnRowDataBound="gv_FamilyMemberDetail_RowDataBound">
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="white" />
                  <FooterStyle BackColor="#f5f5dc" />
                  <EmptyDataTemplate>
                    <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                  </EmptyDataTemplate>
                  <Columns>
                  <asp:TemplateField HeaderText="S No.">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Name">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="lblFMLY_MEMB_NM" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Relation With Head">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "RELATION_NAME")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Photo" >
                    <ItemStyle HorizontalAlign="Center" Width="150px" />
                    <ItemTemplate> <strong> <strong> <a href="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("Photo") %>" rel="lightbox[slide]" target="_blank">
                      <%--<img src="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("Photo") %>" alt="<%# Eval("Photo") %>" width="100" height="100" />--%>
                      <img src="http://45.115.99.199/ntca_mis/WriteReadData/Familyaadhar/<%#Eval("Photo") %>" width="100" height="100" /> </a> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Father Name">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <strong>
                      <asp:Label ID="lblageFATHER_NM" runat="server" Text='<%#Eval("FATHER_NM") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="DOB">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <strong>
                      <asp:Label ID="lblageDOB1" runat="server" Text='<%#Eval("DOB1") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Age(Years)">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="lblageFMLY_MEMB_AGE" runat="server" Text='<%#Eval("FMLY_MEMB_AGE") %>'></asp:Label>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Sex">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_SEX")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Caste">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CAST")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Contact Number">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CONT_NO")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Pan card">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "PenCard")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Voter Id">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Aadhaar Card">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong>
                      <asp:Label ID="LblAdharCard" runat="server" Text='<%# Eval("AdhaarCard") %>'></asp:Label>
                      <%--<%#DataBinder.Eval(Container.DataItem, "AdhaarCard")%>--%>
                      </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Any other Card Details">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <a href="<%= ResolveUrl("~/WriteReadData/Familyaadhar/") %><%#Eval("IdentityCardPhoto") %>" rel="lightbox[slide]" target="_blank"> <%#Eval("IdentityCardPhoto") %> </a> </strong> <strong>CARD DETAILS TITLE:<%#DataBinder.Eval(Container.DataItem, "IdentityCardPhotoTitle")%></strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Total number of beneficiaries">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "NoBeneficiary")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Marital Status">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "MaritalStatus")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Education">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_EDU")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Occupation">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "OCCUPATION_NAME")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Annual Income(Rs)">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate> <strong> <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ANUL_INCM")%> </strong> </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="18+ Required information">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
					<span>BENEFICIARY'S NAME,ADDRESS & MOBILE NO: <strong><%#DataBinder.Eval(Container.DataItem, "BankNameMobile")%> </strong> </span>
					<span>BANK/POSTAL ACCOUNT NO: <strong><%#DataBinder.Eval(Container.DataItem, "BankPostAccountNo")%> </strong> </span> <span>BANK/POST OFFICE NAME:<strong><%#DataBinder.Eval(Container.DataItem, "BankPostOfficeName")%></strong></span><span><strong>IFSC/Pin Code:<%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%></strong></span><span><strong>Bank Post office Address: <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%> </strong> </span> <span>IFSC/PIN CODE:<strong><%#DataBinder.Eval(Container.DataItem, "IFSC")%></strong></span><span>Bank Post office Address:<strong><%#DataBinder.Eval(Container.DataItem, "BankPostOfficeAdress")%></strong></span>
                      <%-- <span>AADHAR NO:<br />--%>
                      <strong>
                      <asp:Label ID="LblAdharCardLast" Visible="false" runat="server" Text='<%# Eval("AadharNo") %>'></asp:Label>
                      </strong>
					  </span>
					  </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
                  <PagerSettings />
                  <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black" HorizontalAlign="right" />
                  <RowStyle Wrap="True" />
                </asp:GridView>
              </asp:Panel>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</form>
</body>
</html>
