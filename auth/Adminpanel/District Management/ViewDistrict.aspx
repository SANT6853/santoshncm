<%@ Page Title="View District:NTCA" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewDistrict.aspx.cs" Inherits="auth_Adminpanel_District_Management_ViewDistrict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    
    <div class="row">
        <div class="col-lg-12">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>View District</h5>
                </div>
                <div class="ibox-content collapse in">
                    <div class="widgets-container">
                        <div>

                            <div class="col-lg-12">
                                <div class="ibox float-e-margins">

                                    <div class="ibox-content collapse in">
                                        <div class="widgets-container">


                                            <div class="form-group">
                                                <label class="col-md-2 control-label">Select State</label>
                                                <div class="col-md-5 input-group">
                                                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>

                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divGrid" runat="server" visible="false">

                            <asp:GridView ID="grdDistrict" DataKeyNames="DistID" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-bordered table-hover" OnRowCommand="grdDistrict_RowCommand" OnRowDeleting="grdDistrict_RowDeleting"
                                OnRowEditing="grdDistrict_RowEditing">
                                <Columns>
                                   
                                    <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                                    <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                     <asp:BoundField DataField="InsertedBy" HeaderText="Inserted By" />
                                     <asp:BoundField DataField="InsertDate" HeaderText="Insert Date" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <a href="EditDistrict.aspx?id=<%# DataBinder.Eval(Container.DataItem, "DistID") %> ">
                                                <asp:Image ID="imgedit" runat="server" ToolTip="Edit" ImageUrl="~/Auth/AdminPanel/images/edit.gif" />
                                            </a>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            Delete
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want delete?');"
                                                CommandName="Delete" ImageUrl="~/Auth/AdminPanel/images/cross.png" CommandArgument='<%# Eval("DistID") %>'
                                                ToolTip="Delete" Height="15" Width="15" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            Id
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMCategory_ID" runat="server" Text='<%#Eval("DistID")%>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="text_3" HorizontalAlign="Center" Wrap="True" />
                                <RowStyle CssClass="drow" Wrap="True" />
                            </asp:GridView>

                          

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
</asp:Content>

