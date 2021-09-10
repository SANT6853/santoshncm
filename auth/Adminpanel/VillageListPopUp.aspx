<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VillageListPopUp.aspx.cs" Inherits="auth_Adminpanel_VillageListPopUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>NTCA Admin</title>
    <!-- Bootstrap -->

</head>
<body class="page-header-fixed ">
    <form id="form1" runat="server">

        <div class="clearfix"></div>

        <div style="text-align: center;">
            <asp:Label ID="lblnorecord" runat="server" Text=""></asp:Label>
            <asp:GridView ID="gvVillage" AutoGenerateColumns="False" DataKeyNames="VILL_ID" runat="server" CssClass="table table-bordered table-hover"
                OnRowCommand="gvVillage_RowCommand"
                OnRowCreated="gvVillage_RowCreated" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">

                <Columns>

                    <asp:TemplateField HeaderText="Village Name" >
                        <ItemTemplate>
                            <%# Eval("VILL_NM") %>
                        </ItemTemplate>

                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateField>


                </Columns>
                <EmptyDataTemplate>
                    <span style="color: #459300;">Record(s) Not Available.</span>
                </EmptyDataTemplate>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="pgr" BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle CssClass="drow" Wrap="True" BackColor="" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>




        </div>
    </form>
</body>
</html>
