<%@ Page Title="NTCA:View Grampanchayat" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewGramPanchayat.aspx.cs" Inherits="auth_Adminpanel_District_Management_ViewGramPanchayat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="../assets/js/vendor/bootstrap.min.js"></script>
	 <style>
	 .input-group .form-control {
   
    width: 70%;
    
}
table tr th{
background:#005529;
color:#fff;
}
	 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; min-height:550px; padding: 10px; background:#fff;">
      <div class="row">
        <div class="col-lg-12 top20">
				<div class="box box-primary1" style="margin-bottom: 25px;">
                    <div class="box-header with-border">
                        <h3 class="box-title" style="color: #005529;">View Grampanchayat</h3>
                    </div>
                    <!-- /.box-header -->
                    <!-- form start -->

                </div>
            <div class="ibox float-e-margins">
                
                <div class="ibox-content collapse in">
                    <div class="widgets-container">
                        
                        <div class="col-md-6" id="dvstate" runat="server" visible="false">
                                            <div class="form-group">
                                                <label class="col-md-3 control-label gtx">Select State</label>
                                                <div class="col-md-9 input-group">
                                                     <asp:DropDownList ID="DdlState" runat="server" AutoPostBack="True"  CssClass="form-control"  ValidationGroup="ADD" OnSelectedIndexChanged="DdlState_SelectedIndexChanged"></asp:DropDownList> 

                                                </div>
                                            </div>
                                            </div>
                                            <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-md-3 control-label gtx">Select District</label>
                                                <div class="col-md-9 input-group">
                                                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" CssClass="form-control">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>
                                            </div>
                                            
                                            <div class="col-md-6">
                                             <div class="form-group">
                                                <label class="col-md-3 control-label gtx">Select Tehshil</label>
                                                <div class="col-md-9 input-group">
                                                    <asp:DropDownList ID="ddlTehshil" runat="server" CssClass="form-control"></asp:DropDownList>

                                                </div>
                                            </div>
                                            </div>
											<div class="clearfix"></div>
											
											<div class="col-sm-12">
											<div class="col-sm-11 text-center" style="margin-bottom: 25px;">

											<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add"
                                                        OnClick="btnSearch_Click"
                                                        ToolTip="Click To Search" />
                                                <br />
                                                <asp:Label ID="Lblmsg" runat="server"></asp:Label>
											</div>
											</div>
                                            
                                             
                                            
                                        
                        <div id="divGrid" runat="server" visible="false">

                            <asp:GridView ID="grdGrampanchayat" DataKeyNames="GramPanchayatID" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-bordered table-hover" OnRowCommand="grdGrampanchayat_RowCommand" OnRowDeleting="grdGrampanchayat_RowDeleting"
                                OnRowEditing="grdGrampanchayat_RowEditing">
                                <Columns>
                                   
                                    <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                                    <asp:BoundField DataField="GramPanchayatName" HeaderText="Grampanchayat Name" />
                                     <asp:BoundField DataField="SubmitBy" HeaderText="Inserted By" />
                                     <asp:BoundField DataField="DateofInsert" HeaderText="Insert Date" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <a href="EditGramPanchayat.aspx?id=<%# DataBinder.Eval(Container.DataItem, "GramPanchayatID") %> ">
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
                                                CommandName="Delete" ImageUrl="~/Auth/AdminPanel/images/cross.png" CommandArgument='<%# Eval("GramPanchayatID") %>'
                                                ToolTip="Delete" Height="15" Width="15" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            Id
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblMCategory_ID" runat="server" Text='<%#Eval("GramPanchayatID")%>'>
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

