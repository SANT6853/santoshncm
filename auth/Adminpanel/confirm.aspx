<%@ Page Language="C#" AutoEventWireup="true" CodeFile="confirm.aspx.cs" Inherits="auth_Adminpanel_confirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirmation</title>
        <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/main.css" rel="stylesheet" />
    <!-- Fontes -->
    <link href="assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/css/ameffectsanimation.css" rel="stylesheet" />
    <link href="assets/css/buttons.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;">
    <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12  bottom20">
                <div class="widgets-container">
					<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">Confirmation Message</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                </div>
                   
                    
                    <div class="form-horizontal">
						<div class="col-md-12">
                        <asp:Label ID="lblmsg"  runat="server" />
                        <asp:Button ID="btnback" runat="server" CssClass="btn btn-primary pull-right" Text="Back" OnClick="btnback_Click" />
						</div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
</div>
    </div>
    </form>
</body>
</html>
