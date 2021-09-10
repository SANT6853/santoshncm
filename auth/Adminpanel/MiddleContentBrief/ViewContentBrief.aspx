<%@ Page Title="NTCA:View Middle Content" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" 
    AutoEventWireup="true" CodeFile="ViewContentBrief.aspx.cs" Inherits="auth_Adminpanel_MiddleContentBrief_ViewContentBrief" %>
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
            <h3 class="box-title" style="color: #005529;">View Middle Content List</h3>
          </div>
        </div>
        <div class="form-horizontal">
          <div class="col-md-6">
            <div class="form-group">
              <label class="col-sm-4 control-label"> Select Site</label>
              <div class="col-md-8 input-group">
                <asp:DropDownList ID="ddlwebsite" Enabled="false" AutoPostBack="true" runat="server" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged">
                  <asp:ListItem Value="1">Mainsite</asp:ListItem>
                  <%--<asp:ListItem Value="2">Tiger Reserve</asp:ListItem>--%>
                </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-6" style="display:none;">
            <div class="form-group">
              <label class="col-md-4 control-label"> Select State</label>
              <div class="col-md-8 input-group">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged"> </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="clearfix"></div>
          <div class="col-md-6" style="display:none;">
            <div class="form-group">
              <label class="col-md-4 control-label"> Select Tiger Reserve</label>
              <div class="col-md-8 input-group">
                <asp:DropDownList ID="ddlTigerReserve" runat="server" CssClass="form-control"> </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="form-group">
              <label class="col-md-4 control-label"> Select Status</label>
              <div class="col-md-8 input-group">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control"> </asp:DropDownList>
              </div>
            </div>
          </div>
          <div class="col-md-12">
            <div class="form-group ">
              <div class="col-md-12">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add"
                                                            OnClick="btnSearch_Click" ToolTip="Click To Search" />
                <br />
                <asp:Label ID="LblMsg" runat="server"></asp:Label>
              </div>
            </div>
          </div>
        </div>
        <div id="divGrid" runat="server" visible="false" class="col-md-12 col-xs-12">
          <asp:GridView ID="grdBanner" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                DataKeyNames="Temp_Link_Id" GridLines="Vertical" Width="100%" CssClass="table table-bordered table-hover"
                                OnPageIndexChanging="grdBanner_PageIndexChanging" 
                                OnRowCreated="grdBanner_RowCreated" OnRowDataBound="grdBanner_RowDataBound" OnRowCommand="grdBanner_RowCommand" OnRowDeleting="grdBanner_RowDeleting" OnSelectedIndexChanged="grdBanner_SelectedIndexChanged" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">
            <AlternatingRowStyle CssClass="alt" BackColor="White" />
            <FooterStyle BackColor="" />
            <HeaderStyle BackColor="#005529" Font-Bold="True" ForeColor="White" />
            <PagerSettings PageButtonCount="2" FirstPageText="« First"
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
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "Name")%> </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Record Inserted Date" HeaderStyle-CssClass="Text-Center">
              <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "Rec_Insert_Date")%> </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="Text-Center" ItemStyle-CssClass="Text-Center">
              <ItemTemplate> <a href="ContentBriefEdit.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Temp_Link_Id")%>&statusID=<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>">
                <asp:Image ID="imgedit" runat="server" ImageUrl="../images/edit.gif" ToolTip="Edit" />
                </a>
                <asp:Image ID="emgnotedit" runat="server" Height="10" ImageUrl="../images/th_star.png"
                                                Visible="false" ToolTip="Record present in pending list" />
              </ItemTemplate>
              <HeaderStyle CssClass="Text-Center"></HeaderStyle>
              <ItemStyle CssClass="Text-Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
              <HeaderTemplate> Delete </HeaderTemplate>
              <ItemTemplate>
                <asp:ImageButton ID="imgDelete" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Temp_Link_Id") %>'
                                                CommandName="Delete" ToolTip="Delete" Height="10" ImageUrl="../images/cross.png"
                                                OnClientClick="return confirm('Are you sure you want to delete?');" Width="11" />
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate> <span style="color: #459300;">Record(s) Not Available.</span> </EmptyDataTemplate>
            <PagerStyle CssClass="pgr" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle CssClass="drow" Wrap="True"  />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
          </asp:GridView>
          &nbsp;
          <asp:Button ID="btnApprove" runat="server" Text="Publish" CssClass="btn btn-default"
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
