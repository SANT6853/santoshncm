<%@ Page Title="NTCA:View CDP" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewCDP.aspx.cs" Inherits="auth_Adminpanel_CDPManagement_ViewCDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <h5>View CDP </h5>
                    <hr>
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Village Name</label>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlVillagee" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlVillagee_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>


                    </div>
                    <div id="divGrid" runat="server" visible="false">

                        <asp:GridView ID="gvforVillages" runat="server" AllowPaging="True" DataKeyNames="TempVillageid" OnRowDataBound="gvforVillages_RowDataBound" PageSize="10" OnRowCommand="gvforVillages_RowCommand" AutoGenerateColumns="False"
                            CellPadding="1" CellSpacing="1" RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-hover" Width="100%">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" CssClass="mGrid" />
                            <RowStyle CssClass="drow" />
                            <AlternatingRowStyle CssClass="alt" />
                            <PagerStyle CssClass="pgr" />
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
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("S_NO") %>'></asp:Label>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Village Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <strong>
                                            <%--   <a href="javascript:void();" onclick="MM_openBrWindow('Village_Management_View.aspx?<%= WebConstant.QueryStringEnum.VillageID  %>=<%# DataBinder.Eval(Container.DataItem, "VILL_ID") %>','main','scrollbars=yes,width=600,height=450')"  style="color:#3F5E1B;">--%>
                                            <%#DataBinder.Eval(Container.DataItem, "Village_Name")%>
                                            <%-- </a>--%>
                                        </strong>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Add CDP">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>

                                        <asp:ImageButton ID="ibAdd" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TempVillageid") %>' CommandName="Add"
                                            ImageUrl="~/auth/Adminpanel/images/edit.gif" Visible="false" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>

                                        <asp:ImageButton ID="ibEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TempVillageid") %>' CommandName="Edit"
                                            ImageUrl="~/auth/Adminpanel/images/edit.gif" Visible="false" /><%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
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
                                        <asp:ImageButton ID="imgDelete" OnClientClick="return confirm('Are you sure you want delete?');"
                                            CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "TempVillageid") %>'
                                            runat="server" ImageUrl="~/AUTH/TIGERRESERVEADMIN/images/wrong.png" Visible="true" />
                                        <%--Visible='<%# DataBinder.Eval(Container.DataItem, "visible") %>'--%>
                                    </ItemTemplate>
                                </asp:TemplateField>




                            </Columns>
                            <PagerSettings FirstPageImageUrl="~/AUTH/TIGERRESERVEADMIN/images/First1.jpg" Mode="Numeric" />
                            <PagerStyle BackColor="#FDF4C9" CssClass="white-text" Font-Bold="True" ForeColor="black"
                                HorizontalAlign="Center" />
                            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        </asp:GridView>


                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../assets/js/vendor/bootstrap.min.js"></script>
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

