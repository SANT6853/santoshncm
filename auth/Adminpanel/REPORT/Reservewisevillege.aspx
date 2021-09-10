<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Reservewisevillege.aspx.cs" Inherits="auth_Adminpanel_REPORT_Reservewisevillege" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
    <script type="text/javascript">

        var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });


</script>
<!--<div class="inner-content-right">
       
       <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="533px" Width="850px" ShowPrintButton="true" DocumentMapCollapsed="True" DocumentMapWidth="10%" >
        </rsweb:ReportViewer>--%>
 

</div> end of inner-content-right -->
<div class="inner-content-right">
        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="table-2">
           <tr>
    <td  colspan="6" bgcolor="#e1e0c4" align="center" style="font-size:smaller; color:#3F5E1B;"><strong> Villages Report for a Sariska Tiger Reserves</strong></td>
  </tr>
            <tr>
               
             
                <td width="25%" class="black-text" align="left" >
                 <span  style="font-size:small;">
                    <asp:LinkButton ID="lnlbtn" runat="server" OnClick="lnlbtn_Click" ForeColor="#3F5E1B">Click Here To View Report</asp:LinkButton>
                    </span>
                </td>
                <td width="25%"  align="center" >
                    &nbsp;<asp:Label ID="lblnodatafound" runat ="server" ForeColor="red" ></asp:Label>
                </td>
                <td width="25%" align="right" >
                <span  style="font-size:small;">
                </span>
                </td>
            </tr>
         
            
        </table>
    </div>
</asp:Content>

