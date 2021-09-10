<%@ Page Title="View NGO:NTCA" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewNgo.aspx.cs" Inherits="auth_Adminpanel_DataEntry_Ngo_ViewNgo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .table-2 td {
            padding: 10px;
            text-align: left;
            width: 19% !important;
        }


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


    <script type="text/javascript" language="javascript">

        function confirmDelete() {

            if (confirm("Are you sure to remove this item?") == true)
                return true;
            else
                return false;
        }

    </script>


    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px;">
            <div class="inner-content-right">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" style="border-bottom: 3px solid #005529;">
                            <h3 style="color: #005529;">View NGO  
                                <asp:Label ID="lblvillagename" Visible="false" runat="server" Text=""></asp:Label></h3>
                        </td>

                    </tr>


                    <tr>
                        <td colspan="3">&nbsp;</td>
                    </tr>

                    <tr>
                        <td colspan="3">
                            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1">
                                <tr>
                                    <td colspan="3" align="center"></td>
                                </tr>
                                <tr>
                                    <td class="black-text" align="right" colspan="3">

                                        <asp:Button ID="btnassociatevillage" CssClass="btn btn-primary btn-add" runat="server"
                                            Text="Associated NGO" OnClick="btnassociatevillage_Click" />


                                        <asp:Button ID="Button1" Visible="false" runat="server" Text="Display Legal Form" CssClass="btn btn-primary btn-add" OnClick="Button1_Click" />
                                        &nbsp;<asp:Button ID="ImgbtnAddNew" runat="server" Text="Add New Village" Visible="false" OnClick="ImgbtnAddNew_Click1" CssClass="btn btn-primary btn-add" />
                                        <asp:Button ID="lnkrelatedlinks" runat="server" Text="Related images" CssClass="btn btn-primary btn-add"
                                            OnClick="lnkrelatedlinks_Click" />


                                        <%--<a href="../EditLegalForm.aspx"><span  style="font-size:large; color:#e1e0c4; text-decoration:none; color:#3F5E1B; float:left;"><u>Edit Legal Form</u></span></a>--%>
        
                                    </td>
                                </tr>

                                <tr>

                                    <td colspan="3">
                                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
                                            <tr>
                                                <td width="15%" align="center"><span class="black-text"><strong>Search By :</strong> </span></td>

                                                <%--<td width="15%" class="black-text" align="center">
         State</td>
      <td width="15%" class="black-text" align="center">
          Tiger Reserve Name</td>--%>

                                                <td width="15%" class="black-text" align="center"></td>
                                                <td align="center" class="black-text" width="5%"></td>
                                                <td width="15%" class="black-text" align="center"></td>

                                                <td width="15%" class="black-text" align="center"></td>
                                            </tr>
                                            <%if (Session["UserType"].ToString().Equals("1"))
                                              {%>
                                            <tr>
                                                <td width="20%"> State name:</td>

                                                <td width="20%" align="center">
                                                    <asp:DropDownList ID="DdlStateName" runat="server" Width="250px" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged"></asp:DropDownList>
                                                </td>

                                            </tr>
                                            <%} %>
                                            <%if (Session["UserType"].ToString().Equals("1") || Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("3"))
                                              {%>

                                            <tr>
                                                <td width="20%">Select Tiger reserve name<label style="color: red">*</label></td>

                                                <td width="20%" align="center">

                                                    <asp:DropDownList ID="ddlselectreserve" runat="server" CssClass="textfield-drop form-control" Width="250px" OnSelectedIndexChanged="ddlselectreserve_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>

                                                </td>

                                            </tr>
                                            <%} %>
                                            <tr style="display:none;">
                                                <td width="20%"><span class="black-text" align="center">Village Code
                                                    <label style="color: red"></label></span></td>

                                                <td width="20%" align="center">
                                                    <asp:DropDownList ID="ddlselectcode" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectcode_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td align="center" width="5%">Village Name<label style="color: red"></label>
                                                </td>
                                                <td width="20%" align="center">
                                                    <asp:DropDownList ID="ddlselectname" runat="server" CssClass="textfield-drop form-control" OnSelectedIndexChanged="ddlselectname_SelectedIndexChanged">
                                                    </asp:DropDownList>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" width="5%"></td>
                                                <td width="20%" class="black-text" align="right">
                                                    <asp:Button ID="ImageButton1" runat="server" Text="Search" CssClass="btn btn-primary btn-add"
                                                        OnClick="ImageButton1_Click1" /><br />
                                                    <asp:Label ID="lblMsg" runat="server" CssClass="red-text"></asp:Label>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>

                                </tr>



                                <tr>
                                    <td colspan="3">&nbsp;<asp:Button ID="imgbtnviewall" Visible="false" runat="server" Text="View All" CssClass="btn btn-primary btn-add" OnClick="imgbtnviewall_Click" />
                                        <asp:Button ID="btnviewcurrent" Visible="false" runat="server" Text="View Current" CssClass="btn btn-primary btn-add" OnClick="btnviewcurrent_Click" />
                                    </td>
                                </tr>

                                <tr>

                                    <td colspan="3" align="center">

                                        <span style="display: none;">
                                            <asp:GridView ID="gvforVillages" Visible="false" runat="server" AllowPaging="True" DataKeyNames="VILL_ID" OnPageIndexChanging="gvforVillages_PageIndexChanging" OnRowDataBound="gvforVillages_RowDataBound" OnRowDeleting="gvforVillages_RowDeleting" OnRowEditing="gvforVillages_RowEditing" OnRowCommand="gvforVillages_RowCommand" AutoGenerateColumns="False"
                                                CellPadding="4" Width="100%"
                                                RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                                                <FooterStyle BackColor="#CCCC99" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid" BackColor="#005529" Font-Bold="True" ForeColor="White" />
                                                <RowStyle CssClass="drow" BackColor="#F7F7DE" />
                                                <AlternatingRowStyle CssClass="alt" BackColor="White" />
                                                <PagerStyle CssClass="pgr" BackColor="#F7F7DE" HorizontalAlign="Right" />

                                                <Columns>
                                                    <asp:TemplateField HeaderText="S. No.">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <strong>
                                                                <asp:Label ID="lblSno" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                                            </strong>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Village Code">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <strong>
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("VILL_CD") %>'></asp:Label>
                                                            </strong>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Village Name">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <strong>
                                                                <a href="javascript:void();" onclick="MM_openBrWindow('Village_Management_View.aspx?<%= WebConstant.QueryStringEnum.VillageID  %>=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>','main','scrollbars=yes,width=700,height=900')" style="color: #3F5E1B;">
                                                                    <%#DataBinder.Eval(Container.DataItem, "VILL_NM")%>
                                                                </a>
                                                            </strong>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <ItemTemplate>

                                                            <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>' CommandName="Edit"
                                                                Visible="true" ImageUrl="~/auth/adminpanel/images/arrow.png" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <HeaderTemplate>
                                                            <strong>Delete
                                                            </strong>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="imgDelete"
                                                                CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>'
                                                                runat="server" ImageUrl="~/auth/adminpanel/images/wrong.png" Visible="true" OnClientClick="return confirmDelete();" />
                                                            <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>




                                                </Columns>
                                                <PagerSettings Mode="Numeric" />
                                                <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                                    HorizontalAlign="Center" />
                                                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                                <SortedDescendingHeaderStyle BackColor="#575357" />
                                            </asp:GridView>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="border-bottom: 3px solid #005529;">
                                        <h3 style="color: #005529;">NGO'S Associated With Village</h3>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:GridView ID="grvngo" AutoGenerateColumns="False" runat="server"
                                            CellPadding="4" Width="100%"
                                            RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped "
                                            AllowPaging="True" OnPageIndexChanging="grvngo_PageIndexChanging" OnRowCommand="grvngo_RowCommand"
                                            OnRowDeleting="grvngo_RowDeleting" EmptyDataText="No NGO Found" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grvngo_RowDataBound">
                                            <FooterStyle BackColor="#CCCC99" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" ForeColor="White" />
                                            <RowStyle CssClass="" />
                                            <AlternatingRowStyle CssClass="alt" BackColor="White" />
                                            <PagerStyle CssClass="pgr" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <RowStyle Wrap="True"></RowStyle>
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("s_no") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="StateName" HeaderText="State Name" />
                                                    <%--<asp:BoundField DataField="StateName" HeaderText="Tiger Reserve" />--%>
                                                <asp:TemplateField HeaderText="Village" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("vill_nm") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="NGO" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amounts</br>(Rupees.) released by tiger reserve" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Work Done For facilitating voluntary village relocation" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%#Eval("work_done_for_village") %>'></asp:Label>
                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <a id="hyedit" href="../NGO/editassciatevillage1.aspx?id=<%#Eval("id") %> ">
                                                            <img id="editimg" src="../images/arrow.png" alt="Edit" title="Edit" width="20"
                                                                height="10" border="0" />
                                                        </a>

                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="NgodetailDelete" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CommandName="Delete" OnClientClick="return confirmDelete();"
                                                            Visible="true" ImageUrl="~/auth/adminpanel/images/wrong.png" />

                                                    </ItemTemplate>

                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                            </Columns>

                                            <HeaderStyle Wrap="True"></HeaderStyle>
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" CssClass="GridPager" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                            <SortedAscendingHeaderStyle BackColor="#848384" />
                                            <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                            <SortedDescendingHeaderStyle BackColor="#575357" />
                                        </asp:GridView>
                                    </td>
                                </tr>







                                <div style="clear: both"></div>

                                <!-- end of inner-content-right -->


                            </table>
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </div>
</asp:Content>

