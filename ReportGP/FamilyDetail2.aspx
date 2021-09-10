<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="FamilyDetail2.aspx.cs" Inherits="ReportGP_FamilyDetail2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.bgcolor{background: #005529 !important;}
</style>
    <script type="text/javascript">

        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);
        }
    </script>
<style>
#print_area th{background:#005529;color:#fff;}

</style>	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBannerImages" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentLeftMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentMainContent" Runat="Server">
<div class=" Compliance_table">
    <table id="print_area" align="center"  class="PrintStyle.css table_new01"  border="0" cellpadding="0" cellspacing="0" width="100%"  >
                    <tr>
   
   
     <th colspan="4">Village Relocation Family Data </th>
                    
  </tr>
  
  <tr >
  <td colspan="4">
  <table border="0" cellpadding="0" cellspacing="0" width="100%" >
  
  
  
  
   <tr>
       
        <td width="25%" align="" class="for-view" > State&nbsp;:</td>
        <td width="25%" align="left"><asp:Label ID="lblstatename" runat="server" CssClass="for-view-lable"></asp:Label></td>
       
        <td width="25%" align=""  class="for-view" > Reserve&nbsp;: </td>
        <td width="25%" align="left" ><asp:Label ID="lblreaserve" runat="server" CssClass="for-view-lable"  ></asp:Label></td>
        </tr>
      
      
       
        <tr>
        <td width="25%" align="" class="for-view"> District&nbsp;: </td>
        <td width="25%" align="left"><asp:Label ID="lbldistrict" runat="server" CssClass="for-view-lable"  ></asp:Label></td>
       
        <td width="25%" align="" class="for-view">  Tehsil&nbsp;: </td>
        <td width="25%" align="left"><asp:Label ID="lbltehsil" runat="server" CssClass="for-view-lable"></asp:Label></td>
        </tr>
       
      
        <tr>
        <td width="25%" align="" class="for-view"> Grampanchayat&nbsp;: </td>
        <td width="25%" align="left"><asp:Label ID="lblgp" runat="server"   CssClass="for-view-lable"></asp:Label></td>
      
        <td width="25%" align="" class="for-view"> Village&nbsp;:</td>
        <td width="25%" align="left"><asp:Label ID="lblvillname" runat="server"  CssClass="for-view-lable"></asp:Label></td>
       </tr>

        <tr>
        <td width="25%" align="" class="for-view"> Village Code&nbsp;: </td>
        <td width="25%" align="left"><asp:Label ID="lblvillcode" runat="server"   CssClass="for-view-lable"></asp:Label></td>
        
        <td>&nbsp; </td>
        <td>&nbsp; </td>
        </tr>
        
     
     
     
     </td></tr></table>
        
        <table id="Table1" align="center"  class="table-2"   border="0" cellpadding="0" cellspacing="0" width="100%"  >
            <tr>
              
                <td  align="center" width="90%">
                <asp:Label ID="lblnodatafound" runat ="server" ForeColor="red" ></asp:Label>
                <div >
                    <asp:GridView ID="gv_FamilySearch" runat="server" AutoGenerateColumns="False" 
                        CellPadding="0" CellSpacing="0" AllowPaging="True" PageSize="15" bgColor="#005529" border="1"  
                        Width="100%" OnPageIndexChanging="gv_FamilySearch_PageIndexChanging"  RowStyle-Wrap="true" 
                        HeaderStyle-Wrap="true"  OnRowDataBound="gv_FamilySearch_RowDataBound" > 
                        
                      <HeaderStyle HorizontalAlign="Center"  VerticalAlign="Middle" Wrap="True" ForeColor="white" CssClass="mGrid bgcolor" />
                    <AlternatingRowStyle CssClass="alt_row" />
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
                            
                              <asp:TemplateField HeaderText="Family Code">
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

                            <asp:TemplateField HeaderText="Installment Amount(Rs.)" Visible="false" >
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
                                      
                                            NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"FMLY_ID","~/ReportGP/FamilyMemberDetail2.aspx?id={0}" ).ToString()+ "&vid="+Request.QueryString["V_ID"] %>' 
                                        Target="_blank"> 
                                      </asp:HyperLink>
                                   <%--<asp:HyperLink ID="hyperId" runat="server" 
                                    NavigateUrl='~/tigerreserveadmin/report/familymemberdetail2.aspx'></asp:HyperLink>--%>
                      <%-- <a href="FamilyMemberDetail2.aspx?F_ID=<%# DataBinder.Eval(Container.DataItem, "FMLY_ID") %>&V_ID=<%= Request.QueryString["V_ID"].ToString() %>"  target="_blank" style="color:#3F5E1B;">
                    
                      </a>--%>
                                    
                                </ItemTemplate>
                            </asp:TemplateField> 
                                                  

                           
                        </Columns>
                        <PagerStyle BackColor="#FDF4C9"  ForeColor="Black" HorizontalAlign="Center" BorderWidth="0" CssClass="paging" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="drow " />
                    </asp:GridView>
                    </div> 
                </td>
            </tr>
            <tr>
                <td align="center">  </td>
                </tr>
          <tr>
                    <td align="center" width="100%">
                        
                        <asp:Button ID="btn_print" class="btn btn-primary" runat="server" Text="Print"  Width="70px" OnClick="btn_print_Click1" />
                        <asp:Button ID="ImageButton1" class="btn btn-primary" runat="server"  Text="Close" OnClientClick="javascript:window.close();" /></td>
                </tr>
        </table>
   
</div>
    <script type="text/javascript">
        var Inputs = document.getElementById("gv_FamilySearch").getElementsByTagName("a");
        for (var n = 0; n < Inputs.length; ++n)
            if (Inputs[n].innerHTML == "No Record") {
                Inputs[n].style.textDecoration = 'none';
            }
    </script>
</asp:Content>

