<%@ Page Title="NTCA:View Banner" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master"
    AutoEventWireup="true" CodeFile="ViewBanner.aspx.cs" Inherits="auth_Adminpanel_Banner_ViewBanner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <style>
.control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left !important;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <script type="text/javascript">

        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.grdBanner.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }


        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.grdBanner.ClientID %>');
            var TargetChildControl = "chkSelect";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;
            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }
        function validatecheckbox() {
            if (Counter == 0) {
                alert('Please select at least one check box !');
                return false;
            }
            else
                return true;

        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target base & child control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter;            
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }
        function IMG1_onclick() {

        }


        /****************************************************
    
        ****************************************************/
        var win = null;
        function NewWindow(mypage, myname, w, h, scroll, pos) {
            if (pos == "random") { LeftPosition = (screen.availWidth) ? Math.floor(Math.random() * (screen.availWidth - w)) : 50; TopPosition = (screen.availHeight) ? Math.floor(Math.random() * ((screen.availHeight - h) - 75)) : 50; }
            if (pos == "center") { LeftPosition = (screen.availWidth) ? (screen.availWidth - w) / 2 : 50; TopPosition = (screen.availHeight) ? (screen.availHeight - h) / 2 : 50; }
            if (pos == "default") { LeftPosition = 50; TopPosition = 50 }
            else if ((pos != "center" && pos != "random" && pos != "default") || pos == null) { LeftPosition = 0; TopPosition = 20 }
            settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=yes';
            win = window.open(mypage, myname, settings);
            if (win.focus) { win.focus(); }
        }
        function IMG1_onclick() {

        }
     
    </script>
  
  <div class="container-fluid" style="margin-bottom: 62px; background:#fff;">
    <div class="wrapper-content">
      <div class="inner-content-right">
        <div class="box box-primary1" style="margin-bottom: 25px;">
          <div class="box-header with-border">
            <h3 class="box-title" style="color: #005529;">View Banner List</h3>
          </div>
        </div>
        <div class="form-horizontal">
          <div class="col-md-6">
            <div class="form-group">
              <label class="col-sm-3 control-label"> Select Site
                <asp:Label ID="StarSite" runat="server" ForeColor="Red" Text="*" Font-Bold="true"></asp:Label>
              </label>
              <div class="col-md-6 input-group">
                <asp:DropDownList ID="ddlwebsite" AutoPostBack="true" runat="server" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged">
                  <asp:ListItem Value="1">Mainsite</asp:ListItem>
                  <asp:ListItem Value="2">Tiger Reserve</asp:ListItem>
                </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="form-group">
              <label class="col-md-3 control-label"> Select State
                <asp:Label ID="StartState" Visible="false" runat="server" ForeColor="Red" Text="*" Font-Bold="true"></asp:Label>
              </label>
              <div class="col-md-6 input-group">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged"> </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="form-group">
              <label class="col-md-3 control-label"> Select Tiger Reserve
                <asp:Label ID="StarReserve" Visible="false" runat="server" ForeColor="Red" Text="*" Font-Bold="true"></asp:Label>
              </label>
              <div class="col-md-6 input-group">
                <asp:DropDownList ID="ddlTigerReserve" runat="server" CssClass="form-control"> </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="form-group">
              <label class="col-md-3 control-label"> Select Status
                <asp:Label ID="StarStatus"  runat="server" ForeColor="Red" Text="*" Font-Bold="true"></asp:Label>
              </label>
              <div class="col-md-6 input-group">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"> </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-12">
            <div class="form-group ">
              <div class="col-md-12">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add"
                                                            OnClick="btnSearch_Click" ToolTip="Click To Search" />
              </div>
            </div>
          </div>
        </div>
        <br />
        <asp:Label ID="LblMsg" runat="server"></asp:Label>
        <div id="divGrid" runat="server" visible="false">
          <asp:GridView ID="grdBanner" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="Temp_Link_Id" GridLines="None" PageSize="10" Width="100%" CssClass="table table-bordered table-hover"
                                OnPageIndexChanging="grdBanner_PageIndexChanging" OnRowCommand="grdBanner_RowCommand"
                                OnRowCreated="grdBanner_RowCreated" OnRowDataBound="grdBanner_RowDataBound" OnRowDeleting="grdBanner_RowDeleting">
            <AlternatingRowStyle CssClass="alt" />
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="2" FirstPageText="« First"
                                    LastPageText="Last »" />
            <Columns>
            <asp:TemplateField HeaderText="CheckAll">
              <HeaderTemplate>
                <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:HeaderClick(this);" />
              </HeaderTemplate>
              <ItemTemplate>
                <asp:CheckBox ID="chkSelect" runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="S.No." HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%#Container.DataItemIndex + 1 %> </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "Name")%><br />
                <%-- <img src="http://localhost:2429/WriteReadData/BannerImages/<%#Eval("Image_Name") %>" alt="<%# Eval("Image_Name") %>" width="650" height="250" hspace="5" vspace="5" border="0" class="vlightbox" />--%>
                <img src="http://45.115.99.199/ntca_mis/WriteReadData/BannerImages/<%#Eval("Image_Name") %>" alt="<%# Eval("Image_Name") %>" width="650" height="250" hspace="5" vspace="5" border="0" class="vlightbox" /> </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Record Inserted Date" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "Rec_Insert_Date")%> </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="Text-Center" ItemStyle-CssClass="Text-Center">
              <ItemTemplate> <a href="BannerEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Temp_Link_Id")%>&statusID=<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>">
                <asp:Image ID="imgedit" runat="server" ImageUrl="../images/edit.gif" ToolTip="Edit" />
                </a>
                <asp:Image ID="emgnotedit" runat="server" Height="10" ImageUrl="../images/th_star.png"
                                                Visible="false" ToolTip="Record present in pending list" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <HeaderTemplate> Delete </HeaderTemplate>
              <ItemTemplate>
                <asp:ImageButton ID="imgDelete" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Temp_Link_Id") %>'
                                                CommandName="Delete" ToolTip="Delete" Height="10" ImageUrl="../images/cross.png"
                                                OnClientClick="return confirm('Are you sure you want to delete?');" Width="11" />
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate> <span style="color: #459300;">Record(s) Not Available.</span> </EmptyDataTemplate>
            <PagerStyle CssClass="pgr" />
            <RowStyle CssClass="drow" Wrap="True" />
          </asp:GridView>
          <asp:Button ID="btnApprove" runat="server" Text="Publish" CssClass="btn btn-primary"
                                OnClientClick="javascript:return validatecheckbox();" OnClick="btnApprove_Click"
                                ToolTip="Click To Publish" />
        </div>
      </div>
    </div>
  </div>
  <script type="text/javascript">
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
