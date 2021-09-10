<%@ Page Title="NTCA:View Relocation Progress Report Management" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="RelocationProgresManagement.aspx.cs" Inherits="auth_Adminpanel_Villagerelocationprogress_RelocationProgresManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
   
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


</script>

<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
<div class="wrapper-content" style="padding-top:0px;">	
<div class="inner-content-right">
    <table style="width: 100%;">
        <tr>
			<td colspan="3" style="border-bottom: 3px solid #005529;"><h3 style="color: #005529;">View Relocation Progress Report Management</h3></td>
            
            
        </tr>
        <tr>
            
            <td align="center">
                <strong><asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></strong>
            </td>
			
        </tr>
        <tr>
            
            <td align="right"><br/>
                <asp:Button ID="btnAdd" runat="server"  
                    CssClass="btn btn-primary btn-add"  Text="Add Report" onclick="btnAdd_Click" /> <br /> 
              
            </td>
        </tr>
        <tr>
            
            <td>
                <asp:GridView ID="gvforVillages" runat="server" AllowPaging="True" DataKeyNames="id" OnPageIndexChanging="gvforVillages_PageIndexChanging" OnRowDeleting="gvforVillages_RowDeleting" OnRowEditing="gvforVillages_RowEditing" OnRowCommand="gvforVillages_RowCommand" AutoGenerateColumns="False"
            CellPadding="4"  RowStyle-Wrap="true" HeaderStyle-Wrap="true"   CssClass= "mGrid table table-bordered table-striped" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" > 
                      <FooterStyle BackColor="#CCCC99" />
                      <HeaderStyle   HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" /> 
         <RowStyle CssClass="drow"  />
                    <AlternatingRowStyle CssClass="alt" BackColor="White" />
                    <PagerStyle CssClass="pgr"  HorizontalAlign="Right" />
                  <Columns> 
        <asp:TemplateField HeaderText="S. No.">
           <ItemStyle HorizontalAlign="Center"/>
                    <ItemTemplate>
                    <strong>
                      <%#Container.DataItemIndex+1%>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>      
                            
                  <asp:TemplateField HeaderText="Report As on Date">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("Date") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name Of State">
                   <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                  
                     <%#DataBinder.Eval(Container.DataItem, "ST_NAME")%>
                     
                     </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Name Of Tiger Reserve">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblwork" runat="server" Text='<%#Eval("ReserveId") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Relocation Report View">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    
                        <%-- <a href="FamilyDetail2.aspx?V_ID=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %> " target="_blank"
                                                style="color: #3F5E1B;">--%>
                        <a ID="HyperLink1" href="ShowDetail.aspx?id=<%#Eval("id") %>" style="color: #3F5E1B;">Relocation Details</a>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Edit">
                     <ItemStyle HorizontalAlign="Center"  />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                        
                                            <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CommandName="Edit"
                                               ImageUrl="~/AUTH/adminpanel/images/arrow.png"  />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                       <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderTemplate>
                                        <strong>
                                            Delete
                                            </strong>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete?');"
                                                CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                              runat="server"  ImageUrl="~/AUTH/adminpanel/images/wrong.png" Visible="true" />
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                            
                                    
                
            </Columns>
               <PagerSettings FirstPageImageUrl="~/AUTH/adminpanel/images/First1.jpg" Mode="Numeric"  />
                        <PagerStyle BackColor="#FDF4C9" CssClass="GridPager" Font-Bold="True" ForeColor="black"
                            HorizontalAlign="right" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />     
                      <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                      <SortedAscendingCellStyle BackColor="#FBFBF2" />
                      <SortedAscendingHeaderStyle BackColor="#848384" />
                      <SortedDescendingCellStyle BackColor="#EAEAD3" />
                      <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            </td>
        </tr>
    </table>
</div>
</div>
</div>
</asp:Content>

