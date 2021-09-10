<%@ Page Title="" Language="C#" MasterPageFile="~/FrontPage.master" AutoEventWireup="true" CodeFile="ReportsGP.aspx.cs" Inherits="ReportsGP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.table-2 tr td{
padding:8px 12px !important;
}
.drow{ background:#fff !important;}
#contentMainContent_BtnPrintOption{
text-align:center !important;
}
.ta-12 tr td{
   padding:5px 40px !important;
}
.ta-12 tr th{ text-align:center;}
</style>
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
    
    <table id="print_area" width="100%" border="0" align="center"
            cellpadding="3" cellspacing="1" class="table-2">

            <tr>
                <td style="background-color: #005529; color: #fff; font-size: large;" align="center" width="100%">
                                   
                    <strong>Reports</strong>
                  
                   
                </td>
            </tr>
            <tr>
                <td align="center">

                    <asp:Label ID="lblnodatafound" runat="server" ForeColor="red"></asp:Label>
                </td>

            </tr>
            <tr>
                <td align="center">
                    <span style="text-align: center;">
                        <asp:Label ID="Label1" runat="server" CssClass="for-view"></asp:Label>
                        <asp:Label ID="Label2" runat="server" CssClass="for-view-lable"></asp:Label>
                        &nbsp;&nbsp;
                                     
                       <asp:Label ID="Label3" runat="server" CssClass="for-view"></asp:Label>
                        <asp:Label ID="Label4" runat="server" CssClass="for-view-lable"></asp:Label>
                    </span>
                    <div class="col-md-12">
        <div id="DVTr" runat="server" class="col-md-6">
             Select Tiger Reserve:
        <asp:DropDownList ID="ddlselectreserve" runat="server"  Width="250px" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged">
         </asp:DropDownList>
        </div>
        <div id="DVCat" runat="server" class="col-md-6">
            Category:
  <asp:DropDownList ID="DdlCat" runat="server" Width="250px"    OnSelectedIndexChanged="DdlCat_SelectedIndexChanged">
                                        <asp:ListItem Text="-Select-" Value="00"></asp:ListItem>
                                        <asp:ListItem Text="Number of villages relocated" Value="22"></asp:ListItem>
                                        <asp:ListItem Text="Progress of relocation" Value="1"></asp:ListItem>
                                        
                                        <asp:ListItem Text="Option wise" Value="33"></asp:ListItem>
                                    </asp:DropDownList>
        </div>
<div id="DvOpt" runat="server" visible="false" >
   <div class="col-md-6">
       Select Village name:
       <asp:DropDownList ID="ddlselectname" runat="server" CssClass ="textfield-drop" Width="250px" AutoPostBack="True">
         </asp:DropDownList>
   </div>
    <div class="col-md-6">
       Option:
         <asp:DropDownList ID="ddlselectscheme" runat="server" AutoPostBack="True" CssClass ="textfield-drop" Width="250px" >
         <asp:ListItem Value="0" Text="Select Option"></asp:ListItem>
         <asp:ListItem Value="1" Text="I"></asp:ListItem>
             
         <asp:ListItem Value="3" Text="II"></asp:ListItem>
            
         </asp:DropDownList>
    </div>
    <div>
         <asp:Button ID="Button12" runat="server" Text="Search" CssClass="btn btn-primary btn-add" CausesValidation="false" OnClick="ImageButton12_Click" /><br />
    </div>
	<br/>
</div>
        <div class="col-md-12" >
             <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add" Width="70px" OnClick="BtnSearch_Click" />
       <asp:Button ID="BtnCancel" runat="server" CssClass="btn btn-primary btn-add pull-right" Text="Back" Visible="false" OnClick="BtnCancel_Click"    />
             </div>
    </div>
                </td>

            </tr>
            <tr>
                <td>
                        <div id="VillProgresss" runat="server" style="max-width: 1114px; overflow-x: auto;">
                            <asp:GridView ID="GVSurvey_Details" runat="server" AutoGenerateColumns="false"
                                        OnRowCommand="GVSurvey_Details_RowCommand" OnRowDataBound="GVSurvey_Details_RowDataBound" Width="100%"
                                        CellPadding="4" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass=" table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                                        <FooterStyle BackColor="#CCCC99" />
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="table table-bordered table-striped" BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                        <RowStyle CssClass="" />
                                        <AlternatingRowStyle CssClass="alt" BackColor="White" />
                                        <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
                                        <EmptyDataTemplate>No record found!!</EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField ItemStyle-CssClass="Text-Center" HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#Container .DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="StateName" HeaderText="State" />
                                            <asp:BoundField DataField="TigerReserveName" HeaderText="Tiger Reserve" />
                                            <asp:TemplateField HeaderText="Village" HeaderStyle-CssClass="Text-Center">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <strong>
                                                        
                                                       

                                                <a href="FamilyDetail2.aspx?V_ID=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>&post=<%# DataBinder.Eval(Container.DataItem, "PostVill_ID") %> " target="_blank"
                                                    style=" color:blue; text-decoration:underline;">
                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                                </a>

                                            
                                                    </strong>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Scheme
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnScheme" runat="server" Text='<%# Eval("Scheme") %>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# Eval("Scheme") %></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AmountSpent" HeaderText="Scheme Amount Used (In Rs)" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Work performed under option (II)
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnWorkperform" runat="server"  Text='<%# Eval("Totalworkperform") %>'  CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# Eval("Totalworkperform") %></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SpentAmount" HeaderText="Work performed Amount spent (In Rs)" />
                                            <asp:BoundField DataField="RemainingAmount" HeaderText="Work performed Remaining Balance (In Rs)" Visible="false" />
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    NGO
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <asp:LinkButton ID="btnNGO" runat="server"  Text='<%# string.Format("{0}",Eval("TotalNGO").ToString()=="0" && Eval("FinalSubmit").ToString().Trim()=="Submitted"?" ":Eval("TotalNGO").ToString()) %>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"PostVill_ID")%>'><%# string.Format("{0}",Eval("TotalNGO").ToString()=="0" && Eval("FinalSubmit").ToString().Trim()=="Submitted"?" ":Eval("TotalNGO").ToString()) %></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="reallocated" HeaderText="Relocation Status" />
                                            

                                        </Columns>
                                        <PagerSettings FirstPageImageUrl="~/AUTH/TIGERRESERVEADMIN/images/First1.jpg" Mode="Numeric" />
                                        <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                            HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                        <SortedAscendingHeaderStyle BackColor="#848384" />
                                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                        <SortedDescendingHeaderStyle BackColor="#575357" />
                                        <PagerStyle CssClass="page_style" />
                                    </asp:GridView>
                            
                        </div>
                        <div id="GrdNumberOfVillages" runat="server" style="max-width: 1114px; overflow-x: auto;">
                            <asp:GridView ID="gv_villageSearch" runat="server" AutoGenerateColumns="False" CellPadding="4" AllowPaging="True" PageSize="15" Width="100%" OnPageIndexChanging="gv_villageSearch_PageIndexChanging" ShowFooter="true"
                                RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" OnRowDataBound="gv_villageSearch_RowDataBound" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                                <FooterStyle BackColor="#f5f5dc" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" ForeColor="White"
                                    BackColor="#005529" CssClass="mGrid table table-bordered table-striped" Font-Bold="True" />
                                <AlternatingRowStyle CssClass="alt_row" BackColor="White" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="NoDataFound" runat="server" Text="No Record Found"></asp:Label>
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:TemplateField HeaderText="S No.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#Container.DataItemIndex+1 %>
                                                <%--<asp:Label ID="lblsno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>--%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Village Name">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <strong>

                                                <a href="FamilyDetail2.aspx?V_ID=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %> " target="_blank"
                                                    style=" color:blue; text-decoration:underline;">
                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                                </a>

                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tiger Reserve name">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "TigerReserveName")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State name">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "StateName")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Village Code">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_CD")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Population">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_POPU")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Land Area(Ha)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("VILL_TOT_LND_AREA") %>'></asp:Label>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Total Agriculture Land Area(Ha)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_AGRI_LND_AREA")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Total Non Agriculture Land Area(Ha)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_NON_AGRI_LND_AREA")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Other Land Area(Ha)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_OTHER_LND_AREA")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Value of Agriculture land">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_AGRI")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Value Residential Land">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_VAL_RES")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Cow & Bufflo">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_CNB")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Sheep & Goat">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "VILL_TOT_SNG")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Other Animal">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "TOT_OTHR_ANML")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Relocated Families">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "Total_Relocated_Population")%>
                                            </strong>
                                        </ItemTemplate>
                                        <HeaderStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Non- Relocated Families">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "Total_Non_Relocated_Population")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "vill_status")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NGO">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <asp:HyperLink ID="hyperngo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ngo")%>'
                                                    ForeColor="#f7b000">  
                                                </asp:HyperLink>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NGO I" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <asp:HiddenField ID="villid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' />
                                                <asp:HyperLink ID="hyperngo1a" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NGOII")%>'
                                                    ForeColor="#3F5E1B">  
                                                </asp:HyperLink>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle BackColor="" ForeColor="Black" CssClass="GridPager pagination" HorizontalAlign="center" />
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="drow" BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                        </div>
                        <div id="OptionWise" runat="server">
                            <asp:GridView ID="gvForFamily" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                DataKeyNames="FMLY_ID" AllowPaging="True" PageSize="15" OnPageIndexChanging="gvForFamily_PageIndexChanging" OnRowDataBound="gvForFamily_RowDataBound" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" ShowFooter="True" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                                <RowStyle CssClass="" />
                                <AlternatingRowStyle CssClass="alt" BackColor="White" />
                                <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />
                                <FooterStyle BackColor="#f5f5dc" />
                                <EmptyDataTemplate>
                                    No record found!!
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
                                    <asp:TemplateField HeaderText="Family Code" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%-- <a href="javascript:void();" onclick="MM_openBrWindow('View_Family_Details.aspx?<%= WebConstant.QueryStringEnum.Familyid  %>=<%# DataBinder.Eval(Container.DataItem, "FMLY_ID") %>','main','scrollbars=yes,width=600,height=450')"  style="color:#3F5E1B;">
                     <%#DataBinder.Eval(Container.DataItem, "FMLY_REG_CD")%>
                      </a>--%>

                                                <%#DataBinder.Eval(Container.DataItem, "FMLY_REG_CD")%>
                        
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Head Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "a")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Option Selected ">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <asp:Label ID="lblscheme" runat="server" Text='<%#Eval("SCHM_ID") %>'></asp:Label>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Relocation Status">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "relocation")%>
                                            </strong>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allotted Amount(Rs)">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "allotedamount")%>
                                            </strong>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <%-- <asp:Label ID="lbltotalalloted" runat="server"></asp:Label>--%>
                                        </FooterTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Installment Amount(Rs)" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>
                                                <%#DataBinder.Eval(Container.DataItem, "installment")%>
                                            </strong>
                                        </ItemTemplate>
                                        <FooterTemplate>

                                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Family Member">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <strong>



                                                <%--<a href="javascript:void();" onclick="MM_openBrWindow('FamilyMemberDetail2.aspx?F_ID=<%# DataBinder.Eval(Container.DataItem, "FMLY_ID") %>&V_ID=<%= Request.QueryString["V_ID"].ToString() %>')"  style="color:Blue;">--%>
                                                <%#DataBinder.Eval(Container.DataItem, "FMLY_NO_MEMB")%>
                      </a>
                                            </strong>
                                        </ItemTemplate>

                                    </asp:TemplateField>




                                </Columns>

                                <PagerSettings />
                                <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                    HorizontalAlign="Center" />
                                <FooterStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                            <asp:Button ID="BtnPrintOption" runat="server" Visible="false" Text="Print" CssClass="btn btn-primary btn-add" Width="70px" OnClick="BtnPrintOption_Click" />
                        </div>
                    </td>
            </tr>
            <tr>
                <td align="center">
                  
                    

                </td>
            </tr>
            <tr>

                <td  >
                    <asp:Button ID="btn_print" runat="server" Visible="false" Text="Print" CssClass="btn btn-primary btn-add" Width="70px" OnClick="btn_print_Click1" />
                    <asp:Button ID="ImageButton1" runat="server" Visible="false" Text="Back" OnClick="ImageButton1_Click" />
                
                  <asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary btn-add" Text="Print" Visible="false"   onclick="btnprint_Click" /> 
                  
                </td>
            </tr>

        </table>
</asp:Content>

