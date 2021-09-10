<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="FamilyMemberDetail2.aspx.cs" Inherits="ReportGP_FamilyMemberDetail2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">

        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);


        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBannerImages" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" Runat="Server">
        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
     <tr>
                    <td align="right">
                        <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn-mid"  OnClick="btn_print_Click1" />
                        <asp:Button ID="ImageButton1" runat="server" CssClass="btn-mid" Text="Close" OnClientClick="javascript:window.close();" />
                        </td>
                </tr>
             <tr>
   
         <td  style="background-color: #e1e0c4; color:#743D02; font-size:large;" align="center" width="100%"><strong>
                 Family Memeber's Details</strong>
                    </td>
  </tr>
            <tr>
         
                <td  align="center" >
                <asp:Label ID="lblnodatafound" runat ="server" ForeColor="red"></asp:Label>
                </td>
                </tr>
             <tr>
         
                <td  align="center" >
              
                    <asp:GridView ID="gv_FamilyMemberDetail" runat="server" AutoGenerateColumns="False"  CellPadding="0"
                        CellSpacing="0" AllowPaging="True" PageSize="10" 
                          BorderWidth="1px" BackColor="White"
                        Width="100%" OnPageIndexChanging="gv_FamilyMemberDetail_PageIndexChanging"  RowStyle-Wrap="true" HeaderStyle-Wrap="true"   CssClass= "mGrid" > 
                      <HeaderStyle   HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"  CssClass="mGrid" ForeColor="Brown" BackColor="#FDF4C9"/> 
         <RowStyle CssClass="drow" />
                    <AlternatingRowStyle CssClass="alt" />
                       <EmptyDataTemplate >
                       <asp:Label ID="NoDataFound" runat ="server" Text ="No Record Found" ></asp:Label>
                       
                       </EmptyDataTemplate>
                        <Columns>
                        
                            <asp:TemplateField HeaderText="S No.">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>' ></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="Name">
                                <ItemStyle HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <strong>
                                        <asp:Label ID="lblsno" runat="server" Text='<%#Eval("FMLY_MEMB_NM") %>'></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                              <asp:TemplateField HeaderText="Age(Years)">
                                <ItemStyle HorizontalAlign="Center"/>
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                       <asp:Label ID="lblage" runat="server" Text='<%#Eval("FMLY_MEMB_AGE") %>' ></asp:Label>
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sex">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <strong >
                                        <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_SEX")%>
                                   </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                                

                            <asp:TemplateField HeaderText="Education">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_EDU")%>
                     
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Annual Income(Rs)">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ANUL_INCM")%>
                      
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                             <asp:TemplateField HeaderText="Relation With Head">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "RELATION_NAME")%>
                      
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                                                  
                                                  
                                                     <asp:TemplateField HeaderText="Cast">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CAST")%>
                      
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 

                            <asp:TemplateField HeaderText="Valid ID Name">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%>
                      
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
                              <asp:TemplateField HeaderText="Valid ID Number">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NO")%>
                      
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:TemplateField HeaderText="Contact Number">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                  <strong >
                                  
                                  
                                   
                      
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_CONT_NO")%>
                      
                                    </strong>
                                </ItemTemplate>
                            </asp:TemplateField> 
                        </Columns>
                        <PagerSettings />
                        <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                            HorizontalAlign="Center" />
                        <RowStyle Wrap="True" />
                    </asp:GridView>
                  
                </td>
            </tr>
           
          
        </table>
    
</asp:Content>

