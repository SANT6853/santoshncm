<%@ Page Title="Family Memeber's Details:NTCA" Language="C#" MasterPageFile="~/Mainsite.master" AutoEventWireup="true" CodeFile="FamilyMemberDetail2.aspx.cs" Inherits="ReportGP_FamilyMemberDetail2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function MM_openBrWindow(theURL, winName, features) { //v2.0
            window.open(theURL, winName, features);


        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentBanner" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentbody" runat="Server">
    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
        <tr>
            <td align="right">
                <asp:Button ID="btn_print" runat="server" Text="Print" class="btn btn-primary btn-sm" OnClick="btn_print_Click1" />
                <asp:Button ID="ImageButton1" runat="server" class="btn btn-primary btn-sm" Text="Back" OnClientClick="javascript:window.close();" />
            </td>
        </tr>
        <tr>

            <td style="background-color: #e1e0c4; color: #743D02; font-size: large;" align="center" width="100%"><strong>Family Memeber's Details</strong>
            </td>
        </tr>
        <tr>

            <td align="center">
                <asp:Label ID="lblnodatafound" runat="server" ForeColor="red"></asp:Label>
            </td>
        </tr>
        <tr>

            <td align="center">

                <asp:GridView ID="gv_FamilyMemberDetail" runat="server" AutoGenerateColumns="False" CellPadding="0"
                    CellSpacing="0" AllowPaging="True" PageSize="10" ShowFooter="true"
                    BorderWidth="1px" BackColor="White"
                    Width="100%" OnPageIndexChanging="gv_FamilyMemberDetail_PageIndexChanging" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid" ForeColor="white" BackColor="#FDF4C9" />
                    <RowStyle CssClass="drow" />
                    <FooterStyle BackColor="#f5f5dc" />
                    <AlternatingRowStyle CssClass="alt" />
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

                        <asp:TemplateField HeaderText="Age(Years)">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <strong>



                                    <asp:Label ID="lblage" runat="server" Text='<%#Eval("FMLY_MEMB_AGE") %>'></asp:Label>
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


                        <asp:TemplateField HeaderText="Education">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <strong>




                                    <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_EDU")%>
                     
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
                        <asp:TemplateField HeaderText="Relation With Head">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <strong>




                                    <%#DataBinder.Eval(Container.DataItem, "RELATION_NAME")%>
                      
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

                        <asp:TemplateField HeaderText="Valid ID Name">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <strong>




                                    <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NAME")%>
                      
                                </strong>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Valid ID Number">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <strong>




                                    <%#DataBinder.Eval(Container.DataItem, "FMLY_MEMB_ID_NO")%>
                      
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
                    </Columns>
                    <PagerSettings />
                    <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                        HorizontalAlign="Center" />
                    <RowStyle Wrap="True" />
                </asp:GridView>

            </td>
        </tr>


    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

