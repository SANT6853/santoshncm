<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="RelocationScheme_IB_Mangement.aspx.cs" Inherits="auth_Adminpanel_FAMILYDATA_RelocationScheme_IB_Mangement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<style>
.table-2 td{

text-align:left;
padding-bottom:4px;
}

</style>
    <script language="JavaScript" type="text/javascript">
        function CompareDates1(source, args) {

            var fromDate = new Date();
            var txtFromDate = document.getElementById('<%= txtsurdate.ClientID %>').value;
    var FromDate = txtFromDate.split("/");
    /*Start 'Date to String' conversion block, this block is required because javascript do not provide any direct function to convert 'String to Date' */
    var fdd = FromDate[0]; //get the day part
    var fmm = FromDate[1]; //get the month part
    var fyyyy = FromDate[2]; //get the year part
    fromDate.setUTCDate(fdd);
    fromDate.setUTCMonth(fmm - 1);
    fromDate.setUTCFullYear(fyyyy);
    var toDate = new Date();
    var txtToDate = document.getElementById('<%= HiddenField4.ClientID %>').value;
    var ToDate = txtToDate.split("/");
    var tdd = ToDate[0]; //get the day part
    var tmm = ToDate[1]; //get the month part
    var tyyyy = ToDate[2]; //get the year part
    toDate.setUTCDate(tdd);
    toDate.setUTCMonth(tmm - 1);
    toDate.setUTCFullYear(tyyyy);
    //end of 'String to Date' conversion block
    var difference = toDate.getTime() - fromDate.getTime();
    var daysDifference = Math.floor(difference / 1000 / 60 / 60 / 24);

    //     alert('df');
    difference -= daysDifference * 1000 * 60 * 60 * 24;

    //    //if diffrence is greater then 366 then invalidate, else form is valid
    // if(difference > 366 )
    if (daysDifference < 0)
        args.IsValid = false;
    else
        args.IsValid = true;
    //else
    //  args.IsValid = true;
}</script>

  <script type="text/javascript">

      var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
      var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
      var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
      var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
      var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


</script>
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">  
     <div class="inner-content-right">
 <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-2 ">
   <tr>
    <td colspan="6" style="border-bottom: 3px solid #005529;"><h3 style="color: #005529;">Relocation Option I Management Page</h3></td>
    
  </tr>
  <tr>
    <td colspan="3">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="3" ><table width="100%" border="0" align="center" cellpadding="3" cellspacing="1">
      <tr>
      
        <td width="100%" colspan="3" align="center"><asp:Label ID="lblMsg" runat="server" Cssclass="red-text"></asp:Label></td>
      </tr>
            <tr>
                            <td class="black-text" colspan="3">
                               <table width="100%"  align="center" cellpadding="3" cellspacing="1" class="table-2 table table-bordered ">
        
       
       
        <tr>
        <td>
         <table width="100%"  align="center" cellpadding="3" cellspacing="1" class="">
        <tr>
        <td width="50%" align="right"><span style="color:Black;"><b>
        District&nbsp;:</b></span> </td>
        <td width="50%" align="left"><b><asp:Label ID="lbldistrict" runat="server"  ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
        </td>
        
        <td>
          <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right"><span style="color:Black;"><b>
        Tehsil&nbsp;:</b></span> </td>
        <td width="50%" align="left"><b><asp:Label ID="lbltehsil" runat="server" ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
        
        
        
        </td>
        </tr>
        <tr>
        <td>
         <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right"><span style="color:Black;"><b>
        Grampanchayat&nbsp;:</b></span> </td>
        <td width="50%" align="left"><b><asp:Label ID="lblgp" runat="server"   ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
        
        
        </td>
        <td>
        <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right"><span style="color:Black;"><b>
        Village&nbsp;:</b></span> </td>
        <td width="50%" align="left"><b><asp:Label ID="lblvillname" runat="server"   ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
              
        
        
        </td>
        </tr>
        <tr>
        <td>
        
        <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right"><span style="color:Black;"><b>
        Village Code&nbsp;:</b></span> </td>
        <td width="50%" align="left"><b><asp:Label ID="lblvillcode" runat="server"   ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
        
       
        </td>
        
        <td>
        
        <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right"><span style="color:Black;"><b>
        Family Code&nbsp;:</b></span> </td>
        <td width="50%" align="left"><b><asp:Label ID="Lblfamilycode" runat="server"   ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
        
       
        </td>
        </tr>
        
        
        
        
           <tr>
        <td>
        
        <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right"><span style="color:Black;"><b>
         Family Head Name&nbsp;:</b></span> </td>
        <td width="50%" align="left"><b><asp:Label ID="Lblheadname" runat="server"   ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
        
       
        </td>
        
        <td>
        
        <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right"><span style="color:Black;"><b>
         Option Selected&nbsp;:</b></span> </td>
        <td width="50%" align="left"><b><asp:Label ID="Lblscheme" runat="server"   ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
        
       
        </td>
        </tr>
        
        
           <tr>
        <td>
        
        <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right" style="display:none;"><span style="color:Black;"><b>
        Group Name&nbsp;:</b></span> </td>
        <td width="50%" align="left" style="display:none;"><b><asp:Label ID="Lblgpname" runat="server"   ForeColor="#713002"></asp:Label></b></td>
        </tr>
        </table>
        
       
        </td>
        
        <td>
        
        <table width="100%"  align="center" cellpadding="3" cellspacing="1">
        <tr>
        <td width="50%" align="right"> </td>
        <td width="50%" align="left"></td>
        </tr>
        </table>
        
       
        </td>
        </tr>
               </table> 
                            </td>
                        </tr>
    <tr>
   
   <td colspan="3">
   <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2 table table-bordered">
  
  
         <tr>
        <td class="black-text" align="right" width="45%"  >Agricultural Land( <asp:Label ID="Label1" runat="server" ForeColor="#6600CC" ></asp:Label> Ha)</td>
        <td class="black-text"    align="center">:</td>
        <td width="53%"> 
        
            <asp:TextBox ID="TextAgrivalue" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox>
            <asp:Label ID="Lblagri" runat="server" Text=""  ForeColor="#713002"></asp:Label>&nbsp;
                                                    
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator123" runat="server" CssClass="red-text-asterix" ControlToValidate="TextAgrivalue"
            Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="AddAssets" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
                                                    
            </td>
      </tr>
       <tr>
        <td class="black-text" align="right"    >Residential Land( <asp:Label ID="Label2" runat="server" ForeColor="#6600CC"></asp:Label> Ha)</td>
        <td class="black-text"  align="center">:</td>
        <td> 
       
            <asp:TextBox ID="Textresvalue" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox>
            <asp:Label ID="Lblresland" runat="server" Text="" ForeColor="#713002"></asp:Label>&nbsp;
                                                    
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" CssClass="red-text-asterix" ControlToValidate="Textresvalue"
            Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="AddAssets" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
                       
            </td>
      </tr>
      
      
       <tr>
        <td class="black-text" align="right"    >
            Number of Wells(<asp:Label ID="Label3" runat="server" ForeColor="#6600CC" ></asp:Label>)</td>
        <td class="black-text"  align="center">:</td>
        <td> 
      
            <asp:TextBox ID="Textwellsvalue" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox>
            <asp:Label ID="Lblwells" runat="server" Text="" ForeColor="#713002"></asp:Label>&nbsp;
                                                    
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" CssClass="red-text-asterix" ControlToValidate="Textwellsvalue"
            Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="AddAssets" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
                       
            </td>
      </tr>
       <tr>
        <td class="black-text" align="right"    >
            Number of Standing Trees(<asp:Label ID="Label4" runat="server" ForeColor="#6600CC" ></asp:Label>)</td>
        <td class="black-text"  align="center">:</td>
        <td> 
       
            <asp:TextBox ID="Texttreesvalue" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox>
            <asp:Label ID="Lbltress" runat="server" Text="" ForeColor="#713002"></asp:Label>&nbsp;
                                                    
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" CssClass="red-text-asterix" ControlToValidate="Texttreesvalue"
            Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="AddAssets" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
                       
            </td>
      </tr>
        <tr>
        <td class="black-text" align="right"    >Others(<asp:Label ID="Label5" runat="server" ForeColor="#6600CC" ></asp:Label>)</td>
        <td class="black-text"  align="center">:</td>
        <td> 
      
            <asp:TextBox ID="Textothervalue" runat="server" CssClass="textfield" MaxLength="10"></asp:TextBox>
            <asp:Label ID="Lblother" runat="server" Text="" ForeColor="#713002"></asp:Label>&nbsp;
                                                    
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" CssClass="red-text-asterix" ControlToValidate="Textothervalue"
            Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="AddAssets" >Please Enter Only Decimal value up to 2 digit</asp:RegularExpressionValidator>     
                     
            </td>
      </tr>
      </table>
      </td>
      </tr>
       <tr>
       
        
        <td colspan="3" align="center"> &nbsp; &nbsp;&nbsp;
            
            
          
              <asp:Button ID="btn_saveAssets" runat="server" ValidationGroup="AddAssets" Text="Save Assets" CssClass="btn btn-primary btn-add" OnClick="btn_saveAssets_Click"  />&nbsp;
              <asp:Button ID="btneditAssets" runat="server" ValidationGroup="AddAssets"  CausesValidation="false" Text="Edit Assets" CssClass="btn btn-primary btn-add" Visible="false" OnClick="btneditAssets_Click"   />&nbsp;
              
               <asp:Button ID="btnsecond" runat="server" Text="Add Installment" Visible="false" CssClass="btn btn-primary btn-add" OnClick="btnsecond_Click"  />&nbsp;
                       <asp:Button ID="btnaddrelocation" runat="server" Text="Add Relocation Details" CssClass="btn btn-primary btn-add" OnClick="btnaddrelocation_Click" Visible="false"/>&nbsp;
                        <asp:Button ID="btneditrelocation" runat="server" Text="Edit Relocation Details" CssClass="btn btn-primary btn-add" OnClick="btneditrelocation_Click" Visible="false"  />&nbsp;
            
        </td>
      </tr>
      <tr>
                
                <td colspan="3" align="center" >
                    <asp:GridView ID="gv1B" runat="server" AutoGenerateColumns="False"  CellPadding="1"
                        CellSpacing="1" AllowPaging="True" PageSize="10"  DataKeyNames ="INST_ISCM_ID"  onrowdeleting="gv1B_RowDeleting"
                        Width="98%" OnRowEditing="gv1B_RowEditing" OnRowDataBound="gv1B_RowDataBound" OnRowCommand="gv1B_RowCommand1"
                          RowStyle-Wrap=true HeaderStyle-Wrap=true   CssClass= "mGrid"> 
                      <HeaderStyle   HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  CssClass="mGrid" /> 
                    <RowStyle CssClass="drow" />
                    <AlternatingRowStyle CssClass="alt" />
                    <PagerStyle CssClass="pgr" />
           
                        
                        <Columns>
                            <asp:TemplateField HeaderText="S. No.">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>' ></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                      
                              <asp:TemplateField HeaderText="Holder's Name">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                       <a href="javascript:void();" onclick="MM_openBrWindow('View_Installment_II.aspx?<%= WebConstant.QueryStringEnum.INSTID  %>=<%# DataBinder.Eval(Container.DataItem, "INST_ISCM_ID") %>&no=+<%#Container.DataItemIndex+1 %>','main','scrollbars=yes,width=600,height=450')"  style="color:#3F5E1B;">
                     <%#DataBinder.Eval(Container.DataItem, "INST_ISCM_HOLD_NM")%>
                      </a>
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

                            <asp:TemplateField HeaderText="Installment No.">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("INST_ISCM_NO") %>' ></asp:Label>
                                    </strong>
                                </ItemTemplate>
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
                                                        <asp:TemplateField HeaderText="Edit">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <ItemTemplate>
                                        
                                            <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "INST_ISCM_ID") %>' CommandName="Edit"
                                                Visible="true" ImageUrl="~/AUTH/adminpanel/images/arrow.png" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                        </ItemTemplate>
                                  
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <ItemTemplate>
                                        
                                            <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "INST_ISCM_ID") %>' CommandName="Delete"
                                                Visible="true" ImageUrl="~/AUTH/adminpanel/images/wrong.png" />
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
       
        
        <td colspan="3" align="center"> 
            &nbsp;<asp:Button ID="ImgbtnBack" runat="server" Text="Back" CssClass="btn btn-primary btn-add" onclick="ImgbtnBack_Click" CausesValidation="false" />
        </td>
      </tr>
      
       <tr>
        <td   colspan="3">
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup"  Visible ="false"  Width="410px" >
            <table width="410px" border="0" align="center" cellpadding="3" cellspacing="1">
             <tr>
            <td colspan="3"  align="center">
                <asp:Label ID="lblMsg1a" runat="server" CssClass="red-text-asterix" ></asp:Label></td>
            </tr>
                <tr>
                    <td colspan="3" align="center" bgcolor="#e1e0c4"><font size="1px" face="Verdana"><strong>
                                    Please Enter Account Holder Details</strong></font>
                    </td>
                </tr>
             <tr>
        <td width="200px" class="black-text" align="right">Holder's Name<span class="red-text-1a">*</span></td>
        <td class="black-text" width="10px">:</td>
        <td width="200px"><asp:TextBox ID="txtholdername" runat="server" CssClass ="textfield" MaxLength="100"></asp:TextBox><br />
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtholdername"
                                                    Display="Dynamic" ErrorMessage="Please enter Holder Name" SetFocusOnError="True"
                                                    ValidationGroup="ADDFirstInstallment" CssClass="red-text-asterix"></asp:RequiredFieldValidator>
                                                    
                                                     <asp:RegularExpressionValidator id="RegularExpressionValidator13" runat="server" Cssclass="red-text-asterix" 
                                                    ValidationGroup="ADDFirstInstallment" Display="Dynamic" ControlToValidate="txtholdername" 
                                                    ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" 
                                                    SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator></td>
        
      </tr>
      
       <tr>
        <td  class="black-text" align="right">Bank Name<span class="red-text-1a">*</span></td>
        <td class="black-text"  >
            :</td>
        <td ><asp:TextBox ID="txtbankname" runat="server" CssClass ="textfield" MaxLength="100"></asp:TextBox><br />
         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtbankname"
                                                    Display="Dynamic" ErrorMessage="Please enter Bank Name" SetFocusOnError="True"
                                                    ValidationGroup="ADDFirstInstallment" CssClass="red-text-asterix"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator id="RegularExpressionValidator14" runat="server" Cssclass="red-text-asterix" 
                                                    ValidationGroup="ADDFirstInstallment" Display="Dynamic" ControlToValidate="txtbankname" 
                                                    ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" 
                                                    SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator>
        
        </td>
        
      </tr>
      <tr>
        <td  class="black-text" align="right">Branch Name<span class="red-text-1a">*</span></td>
        <td class="black-text"  >
            :</td>
        <td ><asp:TextBox ID="txtbranchname" runat="server" CssClass ="textfield" MaxLength="100"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtbranchname"
                                                    Display="Dynamic" ErrorMessage="Please enter Branch Name" SetFocusOnError="True"
                                                    ValidationGroup="ADDFirstInstallment" CssClass="red-text-asterix" ></asp:RequiredFieldValidator>
        
         <asp:RegularExpressionValidator id="RegularExpressionValidator15" runat="server" Cssclass="red-text-asterix" 
                                                    ValidationGroup="ADDFirstInstallment" Display="Dynamic" ControlToValidate="txtbranchname" 
                                                    ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" 
                                                    SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator>
        </td>
        
      </tr>
       <tr>
        <td  class="black-text" align="right">
            Account Number<span class="red-text-1a">*</span></td>
        <td class="black-text"  >
            :</td>
        <td ><asp:TextBox ID="txtaccountno" runat="server" CssClass ="textfield" MaxLength="30"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtaccountno"
                                                    Display="Dynamic" ErrorMessage="Please enter Acoount Name" SetFocusOnError="True"
                                                    ValidationGroup="ADDFirstInstallment" CssClass="red-text-asterix"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator id="RegularExpressionValidator19" runat="server" CssClass="red-text-asterix" ValidationGroup="ADDFirstInstallment" Display="Dynamic" ControlToValidate="txtaccountno" ErrorMessage="Enter Only Digits" ValidationExpression="[0-9]+$" SetFocusOnError="True">Please Enter Only Numeric Values</asp:RegularExpressionValidator>       
        </td>
       
      </tr>
       <tr>
                   <td colspan="3" align="center" ><br />
                    </td>
                </tr>
                <tr>
                   <td colspan="3" align="center" bgcolor="#e1e0c4"><font size="1px" face="Verdana"><strong>
                                  
                        Please Enter Cheque Details</strong></font>
                    </td>
                </tr>
         <tr>
                                            <td class="black-text" align="right">
                                                 Bank Name<span class="red-text-1a"></span></td>
                                            <td class="black-text" >
                                                :</td>
                                            <td >
                                                <asp:TextBox ID="txtckbankname" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox><br />
                                               
                                                     <asp:RegularExpressionValidator id="RegularExpressionValidator16" runat="server" Cssclass="red-text-asterix" 
                                                    ValidationGroup="ADDFirstInstallment" Display="Dynamic" ControlToValidate="txtckbankname" 
                                                    ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" 
                                                    SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator>
                                                </td>
                                        </tr>
                                         <tr>
                                            <td  class="black-text" align="right" >
                                                 Branch Name<span class="red-text-1a"></span></td>
                                            <td class="black-text" >
                                                :</td>
                                            <td >
                                                <asp:TextBox ID="txtckBranch" runat="server" CssClass="textfield" MaxLength="100"></asp:TextBox><br />
                                              
                                                      <asp:RegularExpressionValidator id="RegularExpressionValidator17" runat="server" Cssclass="red-text-asterix" 
                                                    ValidationGroup="ADDFirstInstallment" Display="Dynamic" ControlToValidate="txtckBranch" 
                                                    ErrorMessage="Please Enter Only Characters" ValidationExpression="[a-zA-Z ]+$" 
                                                    SetFocusOnError="True">Please Enter Only Characters</asp:RegularExpressionValidator>
                                                </td>
                                        </tr>
            
      <tr>
        <td  class="black-text" align="right">Cheque Number<span class="red-text-1a"></span></td>
        <td class="black-text"  >:</td>
        <td ><asp:TextBox ID="txtchkno" runat="server" CssClass ="textfield" MaxLength="30"></asp:TextBox><br />
      
        </td>
        
      </tr>
     <tr>
        <td class="black-text" align="right">
          Cheque Date<span class="red-text-1a"></span></td>
        <td class="black-text">:</td>
        <td>   
        <asp:TextBox ID="txtsurdate" runat="server" CssClass ="textfield"></asp:TextBox>
         <asp:Image ImageUrl="~/AUTH/adminpanel/images/cal.jpg" ID="Image3" runat="server" /><br />
         <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtsurdate"
                                Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                ValidationGroup="ADDFirstInstallment" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                                                  
                            <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtsurdate"
                                PopupButtonID="Image3" runat="server">
                            </cc1:CalendarExtender>
                           </td>
      </tr>
     
      <tr>
        <td  class="black-text" align="right">
            Amount(Rs.)<span class="red-text-1a">*</span></td>
        <td class="black-text"  >:</td>
        <td ><asp:TextBox ID="txtamount" runat="server" CssClass ="textfield" MaxLength="10"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtamount"
                                                    Display="Dynamic" ErrorMessage="Please enter Cheque Amount" SetFocusOnError="True"
                                                    ValidationGroup="ADDFirstInstallment" CssClass="red-text-asterix"></asp:RequiredFieldValidator>
                                                    
                                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" CssClass="red-text-asterix" ControlToValidate="txtamount"
            Display="Dynamic" ErrorMessage="Enter Only Decimal value" SetFocusOnError="True"  ValidationExpression="[0-9]+(\.[0-9][0-9][0-9]?)?"
            ValidationGroup="ADDFirstInstallment" >Please Enter Only Decimal value upto 2 digit</asp:RegularExpressionValidator>     
        
        </td>
        
      </tr><tr>
                   <td colspan="3" align="center" ><br />
                    </td>
                </tr>
     
      <tr>
    <td   align="center" colspan="3">
      

<asp:Button ID="ImgbtnSubmitMember" runat="server" Text="Save" CssClass="btn btn-primary btn-add"   ValidationGroup="ADDFirstInstallment" OnClick="ImgbtnSubmitMember_Click" />&nbsp;
 <asp:Button ID="btnaddinstalment" runat="server" Text="Save" CssClass="btn btn-primary btn-add" 
            Visible="false"   ValidationGroup="ADDFirstInstallment" 
            onclick="btnaddinstalment_Click" />                                          
                                          
                                                <asp:Button ID="ImgbtnCancel1" runat="server" Text="Reset" Visible="false" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImgbtnCancel1_Click"   />&nbsp;
                                                <asp:Button ID="btnresetinstalment" 
            runat="server" Text="Reset" Visible="false" CssClass="btn btn-primary btn-add" CausesValidation="false" 
            onclick="btnresetinstalment_Click"/>
                                                <asp:Button ID="ImageButton1" runat="server" Text="Cancel" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImageButton1_Click"   />&nbsp;
                   
    </td>
  </tr>
      </table>
      
            </asp:Panel>
            </td>
      </tr>
      
      
      <tr>
    <td  align="right"  ><span class="black-text"></span>&nbsp;</td>
    <td width="1%">&nbsp;</td>
    <td width="32%" align="right"><span class="black-text">&nbsp;
    </span></td>
  </tr>
  
  
      </table> </td>
  </tr>
 

</table>
</div><!-- end of inner-content-right -->
<div style="clear:both"></div>
    <cc1:ModalPopupExtender ID="poUpEx1" runat="server"
            TargetControlID = "hf"
            PopupControlID="Panel1" 
            BackgroundCssClass="modalBackground" >
        
        
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hf" runat="server" />
   
      <asp:HiddenField ID="HiddenField4" runat="server" />
	  </div>
</asp:Content>

