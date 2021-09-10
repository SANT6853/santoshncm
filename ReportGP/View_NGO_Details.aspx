<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="View_NGO_Details.aspx.cs" Inherits="ReportGP_View_NGO_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBannerImages" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" Runat="Server">
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
            
            <tr>
               
                <td width="100%" align="right"  >
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-mid" Text="Close" OnClientClick="javascript:window.close();" />
                    
                    <asp:Button ID="Button2" runat="server" Text="Print"  CssClass="btn btn-primary  btn-mid" OnClick="btn_print_Click" />
                    </td>
            </tr>
     
     <tr>
   
      <td  style="background-color: #005529; color:#ffffff; font-size:large;" align="center" width="100%"><strong>
               NGO Details</strong>
                    </td>


  </tr>
   <tr>
     <td width="100%" align="center" >
                
                <asp:Label ID="lblMsg" runat ="server" ForeColor="red" ></asp:Label>
                
                </td>
                </tr>
    <tr>
       <%-- <td class="black-text" align="right"><span class="red-text-asterix"></span></td>
        <td class="black-text"></td>--%>
        <td  align="center">
        
        
            <asp:GridView ID="gvforVillages" runat="server" AllowPaging="True"  OnPageIndexChanging="gvforVillages_PageIndexChanging" PageSize="15"  AutoGenerateColumns="False"
            CellPadding="1" CellSpacing="1"  RowStyle-Wrap=true HeaderStyle-Wrap=true   CssClass= "mGrid" Width="100%" > 
                     <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="white"
                                BackColor="#005529" CssClass="mGrid" />
         <RowStyle CssClass="drow" />
                    <AlternatingRowStyle CssClass="alt" />
                    <PagerStyle CssClass="pgr" />
                  <Columns> 
        <asp:TemplateField HeaderText="S. No.">
           <ItemStyle HorizontalAlign="Center"/>
                    <ItemTemplate>
                    <strong>
                       <%# Container.DataItemIndex+1 %>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>      
                            
                  <asp:TemplateField HeaderText="Name">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("name") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                   <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                  
                     <%#DataBinder.Eval(Container.DataItem, "address")%>
                     
                     </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Contact No">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblwork" runat="server" Text='<%#Eval("mobile_no") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amounts </br>(In Rs.)">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblwork" runat="server" Text='<%#Eval("amount") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblwork" runat="server" Text='<%#Eval("date") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="work done for village">
                     <ItemStyle HorizontalAlign="Center"  />
                    <ItemTemplate>
                    <strong>
                        <asp:Label ID="lblwork" runat="server" Text='<%#Eval("work_done_for_village") %>' ></asp:Label>
                        </strong>
                    </ItemTemplate>
                </asp:TemplateField>
 
                                   
                             
                                    
                
            </Columns>
               <PagerSettings FirstPageImageUrl="~/adminpanel/images/First1.jpg" Mode="Numeric"  />
                        <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                            HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />     
            </asp:GridView>
       
        </td>
      </tr>
  
               
               
                </table>
</asp:Content>

