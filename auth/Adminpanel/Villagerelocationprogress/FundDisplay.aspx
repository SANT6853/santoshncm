<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="FundDisplay.aspx.cs" Inherits="auth_Adminpanel_Villagerelocationprogress_FundDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <style>
        .table-2 td {
            padding: 10px;
            text-align: left;
            width: 23% !important;
            vertical-align: top;
        }

        #btnback {
            margin-left: 4px;
        }

        .container-fluid {
            margin-bottom: 50px !important;
        }

        .textfield-drop {
            width: 70%;
        }
    </style>
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


    </script>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <div class="wrapper-content" style="padding-top: 0px;">
            <div class="inner-content-right">
                <table width="100%" align="center" cellpadding="3" cellspacing="1" class="Progress_table table-2">
                    <tr>
                        <td colspan="5" style="border-bottom: 3px solid #005529; padding-left: 0px; padding-bottom: 0px;">
                            <h3 style="color: #005529;">Fund Display</h3>
                        </td>

                    </tr>
<tr>
    <tr>
              <td colspan="3" align="center">
                  <asp:GridView ID="gvDisplayFund" runat="server" AllowPaging="false"  AutoGenerateColumns="true" CellPadding="4" Width="100%" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="mGrid table table-bordered table-striped" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                  <FooterStyle BackColor="#CCCC99" />
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid table table-bordered table-striped" BackColor="#005529" Font-Bold="True" />
                  <RowStyle CssClass="drow" />
                  <AlternatingRowStyle CssClass="alt" />
                  <%--<PagerStyle CssClass="pgr" HorizontalAlign="Right" />--%>
                  <Columns>
                  
                  </Columns>
                 <%-- <PagerSettings Mode="Numeric" />--%>
                 <%-- <PagerStyle CssClass="GridPager pagination" Font-Bold="True" ForeColor="black"
                                                    HorizontalAlign="right" />--%>
                  <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                  <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#FBFBF2" />
                  <SortedAscendingHeaderStyle BackColor="#848384" />
                  <SortedDescendingCellStyle BackColor="#EAEAD3" />
                  <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView></td>
</tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


