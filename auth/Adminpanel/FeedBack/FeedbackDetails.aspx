<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FeedbackDetails.aspx.cs" Inherits="auth_Adminpanel_FeedBack_FeedbackDetails" %>

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


    <div class="clearfix"></div>
    
    <div style="text-align:center;">
        <table class="table table-bordered table-striped table-responsive">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Email</th>
                    <th>Phone</th>
                    <th>state</th>
                    <th>Feedback from page</th>
                    <th>Address</th>
                    <th>Message</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><p><asp:Label ID="LblName" runat="server" Text=""></asp:Label></p></td>
                    <td> <p><asp:Label ID="LblEmail" runat="server" Text=""></asp:Label></p></td>
                    <td><p><asp:Label ID="LblPhone" runat="server" Text=""></asp:Label></p></td>
                    <td><p><asp:Label ID="Lblstate" runat="server" Text=""></asp:Label></p></td>
                    <td><p><asp:Label ID="LblfeedbackTpe" runat="server" Text=""></asp:Label></p></td>
                    <td><p><asp:Label ID="LblAddress" runat="server" Text=""></asp:Label></p></td>
                    <td><p><asp:Label ID="Lblmessage" runat="server" Text=""></asp:Label></p></td>
                </tr>
            </tbody>
        </table>
        


    </div>

</body>
</html>
