<%@ Page Title="NTCA:Relocation Site Management" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Relocation_Management.aspx.cs" Inherits="auth_Adminpanel_RelocationSite_Relocation_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
  <style>
.table-2 td{
padding:6px;
text-align:left;

}

  .GridPager a, .GridPager span
    {
        display: block;
        height: 18px;
        width: 18px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }
    .GridPager a
    {
        background-color: #f5f5f5;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }

</style>  
<script language="javascript" type="text/javascript">
    function IMG1_onclick() {

    }


    /****************************************************
        
    ****************************************************/
    var win = null;
    function NewWindow(mypage, myname, w, h, scroll, pos) {
        if (pos == "random") { LeftPosition = (screen.availWidth) ? Math.floor(Math.random() * (screen.availWidth - w)) : 50; TopPosition = (screen.availHeight) ? Math.floor(Math.random() * ((screen.availHeight - h) - 75)) : 50; }
        if (pos == "center") { LeftPosition = (screen.availWidth) ? (screen.availWidth - w) / 2 : 50; TopPosition = (screen.availHeight) ? (screen.availHeight - h) / 2 : 50; }
        if (pos == "default") { LeftPosition = 50; TopPosition = 50 }
        else if ((pos != "center" && pos != "random" && pos != "default") || pos == null) { LeftPosition = 0; TopPosition = 20 }
        settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=yes';
        win = window.open(mypage, myname, settings);
        if (win.focus) { win.focus(); }
    }
    function IMG1_onclick() {

    }
</script>
<script type="text/javascript">

    var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
    var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
    var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
    var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
    var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


</script>

<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
<div class="wrapper-content" style="padding-top:0px; ">
<div class="inner-content-right">
 
 <table width="100%" border="0" cellspacing="0" cellpadding="0" class="table-2">
 <tr>
	<td colspan="3" style="border-bottom: 3px solid #005529; padding:0px;"><h3 style="color: #005529;">Relocation Site Management</h3></td>
   
  </tr>
  
  
     
  <tr>
    <td colspan="3" ><table width="100%" border="0" align="center" cellpadding="3" cellspacing="1">
      <tr style="display:none;">
        <td colspan="3" align="center">
       </td>
      </tr>
       <tr style="display:none;">
        <td class="black-text" align="right" colspan="3">
            &nbsp;<asp:Button ID="ImgbtnAddNew" runat="server" Text="Add New Relocation Site" CssClass="btn btn-primary btn-add" ValidationGroup="Registration" OnClick="ImgbtnAddNew_Click" />
        </td>
      </tr>
        <tr>
  
   <td colspan="3">
   <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
    <tr style="display:none;">
    <td width="12%" align="center" ><span class="black-text"><strong>Search By :</strong </span></td>
     
     <td width="12%" class="black-text" align="center"> Village Name :</td>
      <td width="20%" align="center">
      <asp:DropDownList ID="ddlselectname" runat="server" CssClass ="textfield-drop form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged"> 
         </asp:DropDownList>
     
     </td>
	  <td align="right" class="black-text" colspan="2">
          &nbsp;<asp:Button ID="ImageButton1" runat="server" Text="Search" CssClass="btn btn-primary btn-add"  CausesValidation="false" OnClick="ImgbtnGo_Click"  />
         </td>
       </tr>
     
       
  </table>
      </td>
      
  </tr>
      
        <tr>
      
        <td colspan="3" align="center">
         <asp:Label ID="lblMsg" runat="server" Cssclass="red-text"></asp:Label><br />
        
            <asp:GridView ID="gvforVillages" runat="server" AllowPaging="True" DataKeyNames="RELOC_AREA_ID" OnPageIndexChanging="gvforVillages_PageIndexChanging" OnRowDataBound="gvforVillages_RowDataBound" OnRowDeleting="gvforVillages_RowDeleting" OnRowEditing="gvforVillages_RowEditing" PageSize="5" OnRowCommand="gvforVillages_RowCommand" AutoGenerateColumns="False"
            CellPadding="4"  Width="100%" 
            RowStyle-Wrap="true" HeaderStyle-Wrap="true"   CssClass= "mGrid table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" > 
                      <FooterStyle BackColor="#CCCC99" />
                      <HeaderStyle   HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" /> 
                    <RowStyle CssClass=""  />
                    <AlternatingRowStyle CssClass="alt" BackColor="White" />
                    <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
            
                  <Columns> 
        <asp:TemplateField HeaderText="S No.">
           <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblSno" runat="server" Text ='<%#Eval("S_NO") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>      
                            
                  <asp:TemplateField HeaderText="State Name">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblstname" runat="server" Text='<%#Eval("statename") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="District Name">
                     <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lbldtname" runat="server" Text='<%#Eval("District_name") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Relocated from village">
                     <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lbltvillage" runat="server" Text='<%#Eval("tvillage") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Relocated to village">
                   <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                    <strong>
                     <a href="javascript:void();" onclick="MM_openBrWindow('Relocation_Site_View.aspx?<%= WebConstant.QueryStringEnum.RELO_ID  %>=<%# DataBinder.Eval(Container.DataItem, "RELOC_AREA_ID") %>','main','scrollbars=yes,width=600,height=450')"  style="color:blue; text-decoration:underline;">
                    Relocated details
                         <%-- <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>--%>
                     </a>
                     </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Edit">
                     <ItemStyle HorizontalAlign="Center"  />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                        
                                            <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RELOC_AREA_ID") %>' CommandName="Edit"
                                                Visible="true" ImageUrl="~/AUTH/adminpanel/images/arrow.png" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                       <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderTemplate>
                                        <strong>
                                            Delete
                                            </strong>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete?');"
                                                CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "RELOC_AREA_ID") %>'
                                              runat="server"  ImageUrl="~/AUTH/adminpanel/images/wrong.png" Visible="true" />
                                            <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    
                                    
                
            </Columns>
            <PagerSettings  Mode="Numeric"  />
                        <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black"
                            HorizontalAlign="right" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#FBFBF2" />
                      <SortedAscendingHeaderStyle BackColor="#848384" />
                      <SortedDescendingCellStyle BackColor="#EAEAD3" />
                      <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
       <asp:Button ID="ImgbtnBack" runat="server" CssClass="btn btn-primary btn-add" Text="Back" CausesValidation="false" OnClick="ImgbtnBack_Click" />
        </td>
      </tr>
      
      </table></td>
  </tr>
  

 

</table>




 
 
 <div style="clear:both"></div>

</div><!-- end of inner-content-right -->
</div>
</div>
</asp:Content>

