<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ConfirmationPage.aspx.cs" Inherits="auth_Adminpanel_ConfirmationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
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
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
    <!--  morris Charts  -->
    <!-- js for print and download -->
    <script type="text/javascript" src="../assets/js/vendor/vfs_fonts.js"></script>
    <script src="../assets/js/vendor/chartJs/Chart.bundle.js"></script>
    <script src="../assets/js/dashboard1.js"></script>
    <!-- slimscroll js -->
    <script type="text/javascript" src="../assets/js/vendor/jquery.slimscroll.js"></script>
    <!-- main js -->
    <script src="../assets/js/main.js"></script>
</asp:Content>

