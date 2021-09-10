<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReserveWiseII.aspx.cs" Inherits="auth_Adminpanel_REPORT_ReserveWiseII" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        
        <table width="100%">
            <tr>
                <td align="CENTER" width="100%">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-add" OnClick="Button1_Click"
                        Text="Back" />
                </td>
            </tr>
            <tr>
                <td>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" ShowPrintButton="true" DocumentMapWidth="100%"
                        SizeToReportContent="True" Height="600px" Width="1000px">
                    </rsweb:ReportViewer>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <%--<h4>
                        <span style="color: Red;">*</span> &nbsp; source from Sariska Tiger Reserve
                    </h4>--%>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
