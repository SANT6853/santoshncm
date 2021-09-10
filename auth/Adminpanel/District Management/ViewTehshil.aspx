<%@ Page Title="NTCA:View Tehsil" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewTehshil.aspx.cs" Inherits="auth_Adminpanel_District_Management_ViewTehshil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
	<style>
	#contentbody_grdTehsil tr th{
	background:#005529;
	color:#fff;
	}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
	<div class="wrapper-content" style="padding-top:0px; min-height:550px;">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="box box-primary1" style="margin-bottom: 25px;">
                        <div class="box-header with-border">
                            <h3 class="box-title" style="color: #005529;">View Tehsil</h3>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                    </div>
                    <!--<div class="ibox-title">
                    <h5></h5>
                </div>-->
                    <div class="ibox-content collapse in">
                        <div class="widgets-container">

                            <div class="col-md-6" style="padding-left: 0px;" id="dvstate" runat="server" visible="false">
                                <div class="form-group">
                                    <label class="col-md-3 control-label gtx">Select state</label>
									<div class="col-md-6 input-group">
                                    <asp:DropDownList ID="DdlState" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DdlState_SelectedIndexChanged" ValidationGroup="val1"></asp:DropDownList>
									</div>
                                    <div>
                                        <label id="Lbl" style="color: red;"></label>
                                    </div>
                                </div>
                            </div>

                            <!--<div class="ibox float-e-margins">

                                    <div class="ibox-content collapse in">
                                        <div class="widgets-container">-->

                            <div class="col-md-6" style="padding-left: 0px;">
                                <div class="form-group">
                                    <label class="col-md-3 control-label gtx">Select District</label>
                                    <div class="col-md-6 input-group">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>

                                    </div>
                                </div>
                            </div>

                            <!--</div>
                                    </div>
                                </div>-->


                            <div id="divGrid" runat="server" visible="false">

                                <asp:GridView ID="grdTehsil" DataKeyNames="Tehsil" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-bordered table-hover" OnRowCommand="grdTehsil_RowCommand" OnRowDeleting="grdTehsil_RowDeleting"
                                    OnRowEditing="grdTehsil_RowEditing">
                                    <Columns>

                                        <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                                        <asp:BoundField DataField="Tehsil_Name" HeaderText="Tehsil Name" />
                                        <asp:BoundField DataField="SubmitBy" HeaderText="Inserted By" />
                                        <asp:BoundField DataField="DateofInsert" HeaderText="Insert Date" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Edit
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a href="EditTehshil.aspx?id=<%# DataBinder.Eval(Container.DataItem, "Tehsil") %> ">
                                                    <asp:Image ID="imgedit" runat="server" ToolTip="Edit" ImageUrl="~/Auth/AdminPanel/images/edit.gif" />
                                                </a>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Delete
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want delete?');"
                                                    CommandName="Delete" ImageUrl="~/Auth/AdminPanel/images/cross.png" CommandArgument='<%# Eval("Tehsil") %>'
                                                    ToolTip="Delete" Height="15" Width="15" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <HeaderTemplate>
                                                Id
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMCategory_ID" runat="server" Text='<%#Eval("Tehsil")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="text_3" HorizontalAlign="Center" Wrap="True" />
                                    <RowStyle CssClass="drow" Wrap="True" />
                                </asp:GridView>



                            </div>
                            <div class="col-sm-12" style="color:red;">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <script src="../assets/js/vendor/bootstrap.min.js"></script>

    <!-- slimscroll js -->

    <script>
        function extendedValidatorUpdateDisplay(obj) {
            // Appelle la méthode originale
            if (typeof originalValidatorUpdateDisplay === "function") {
                originalValidatorUpdateDisplay(obj);
            }

            // Récupère l'état du control (valide ou invalide) 
            // et ajoute ou enlève la classe has-error
            var control = document.getElementById(obj.controltovalidate);
            if (control) {
                var isValid = true;
                for (var i = 0; i < control.Validators.length; i += 1) {
                    if (!control.Validators[i].isvalid) {
                        isValid = false;
                        break;
                    }
                }

                if (isValid) {
                    $(control).closest(".form-group").removeClass("has-error");
                } else {
                    $(control).closest(".form-group").addClass("has-error");
                }
            }
        }

        // Remplace la méthode ValidatorUpdateDisplay
        var originalValidatorUpdateDisplay = window.ValidatorUpdateDisplay;
        window.ValidatorUpdateDisplay = extendedValidatorUpdateDisplay;
    </script>
    <script type="text/javascript">
        function ValidateDropDown() {
            // alert('fd');
            $('#Lbl').html('');
            var cmbID = "<%=DdlState.ClientID %>";
             //  alert($('#' + cmbID).val());

             if ($('#' + cmbID).val() == "Select State") {
                 //  alert("Please select State");
                 $('#Lbl').html('Please select State');
                 return false;
             }
             return true;
         }
    </script>
</asp:Content>

