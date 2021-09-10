<%@ Page Title="NTCA:View Cms" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="ViewContent.aspx.cs" Inherits="auth_Adminpanel_CMS_ViewContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
  <style>
        .GridPager a, .GridPager span {
            display: block;
            height: 15px;
            width: 15px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
        }

        .GridPager a {
            color: #969696;
        }

        .GridPager span {
            color: #000;
        }

        .control-label {
            padding-top: 7px;
            margin-bottom: 0;
            font-weight: 400;
            text-align: left !important;
        }

        legend {
            display: block;
            width: 100%;
            padding: 0;
            margin-bottom: 10px !important;
            font-size: 21px;
            line-height: inherit;
            color: #333;
            border: 0;
            border-bottom: none !important;
        }
    </style>
  <script type="text/javascript">

        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.grdCMSMenu.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }


        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.grdCMSMenu.ClientID %>');
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
            <h3 class="box-title" style="color: #005529;">View CMS</h3>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group">
            <label class="col-md-3 control-label">
            Select site
            <label style="color:red;">*</label>
            </label>
            <div class="col-md-6 input-group">
              <asp:DropDownList ID="ddlwebsite" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlwebsite_SelectedIndexChanged">
                <asp:ListItem Value="1">Mainsite</asp:ListItem>
                <asp:ListItem Value="2">Tiger Reserve</asp:ListItem>
              </asp:DropDownList>
            </div>
          </div>
        </div>
        <%--above naren update--%>
        <div class="col-md-6">
          <div class="form-group">
            <label class="col-md-3 control-label">
            Select Language
            <label style="color:red;">*</label>
            </label>
            <div class="col-md-6 input-group">
              <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" CssClass="form-control">
                <asp:ListItem Value="1">English</asp:ListItem>
                <asp:ListItem Value="2">Hindi</asp:ListItem>
              </asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6" >
          <div class="form-group">
            <label class="col-md-3 control-label">Select State
              <%--  <label style="color:red;">*</label>--%>
              <asp:Label ID="StateStar" Visible="false" runat="server" Font-Bold="true" Text="*" ForeColor="Red"></asp:Label>
            </label>
            <div class="col-md-6 input-group">
              <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group">
            <label class="col-md-3 control-label">Select Tiger Reserve
              <%-- <label style="color:red;">*</label>--%>
              <asp:Label ID="ReserveStar" Visible="false" Font-Bold="true" runat="server" Text="*" ForeColor="Red"></asp:Label>
            </label>
            <div class="col-md-6 input-group">
              <asp:DropDownList ID="ddlTigerReserve" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTigerReserve_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group">
            <label class="col-md-3 control-label">
            Select Position
            <label style="color:red;">*</label>
            </label>
            <div class="col-md-6 input-group">
              <asp:DropDownList ID="ddlPosition" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPosition_SelectedIndexChanged" CssClass="form-control">
                <asp:ListItem Value="1">Top</asp:ListItem>
                <asp:ListItem Value="2">Bottom</asp:ListItem>
              </asp:DropDownList>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group">
            <label class="col-md-3 control-label">
            Select Main Page Name
            <label style="color:red;">*</label>
            </label>
            <div class="col-md-6 input-group">
              <asp:ListBox ID="lbMenu" runat="server" CssClass="form-control" Width="100%" Height="170px"></asp:ListBox>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group">
            <label class="col-md-3 control-label">
            Select Status
            <label style="color:red;">*</label>
            </label>
            <div class="col-md-6 input-group">
              <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged1"> </asp:DropDownList>
            </div>
          </div>
        </div>
        <%--start naren10apr2018--%>
        <div class="col-md-6"> <span class="button_row">
          <asp:Panel ID="pnlButton" runat="server" GroupingText="Menu order adjustment"> <span>First select menu then click buttons </span> <br />
            <asp:Button ID="btnTop" runat="server" CssClass="btn btn-primary btn-add btn-sm" Text="Up" CausesValidation="false"
                                OnClick="btnUp_Click" OnClientClick="javascript:return confirm( 'Would you like to Change order of MENU ?')" />
            <asp:Button ID="btnBottom" runat="server" CssClass="btn btn-primary btn-add btn-sm" CausesValidation="false"
                                Text="Down" OnClick="btnDown_Click" OnClientClick="javascript:return confirm( 'Would you like to Change order of MENU ?')" />
            <%--  <asp:Button ID="btnLeft" runat="server" CssClass="btn btn-primary btn-add" CausesValidation="false"
                        Text="Left" OnClick="btnLeft_Click" OnClientClick="javascript:return confirm( 'Would you like to Change order of MENU ?')" />
                    <asp:Button ID="btnRight" runat="server" CssClass="btn btn-primary btn-add" CausesValidation="false"
                        Text="Right" OnClick="btnRight_Click" OnClientClick="javascript:return confirm( 'Would you like to Change order of MENU ?')" />--%>
          </asp:Panel>
          </span>
          <div class="clear"> </div>
        </div>
        <%--end naren10apr2018 --%>
        <div class="col-md-11">
          <div class="form-group">
            <div class="text-left input-group ">
              <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add"
                                OnClick="btnSearch_Click"
                                ToolTip="Click To Search" />
              <br />
              <asp:Label ID="LblMsg" runat="server"></asp:Label>
            </div>
          </div>
        </div>
        <div class="form-group">
          <div id="divGrid" runat="server" visible="false">
            <asp:GridView ID="grdCMSMenu" runat="server" AutoGenerateColumns="False" DataKeyNames="Temp_Link_Id" CssClass="table table-bordered table-hover"
                        GridLines="Vertical" Width="100%" OnRowCommand="grdCMSMenu_RowCommand"
                        OnRowCreated="grdCMSMenu_RowCreated" OnRowDataBound="grdCMSMenu_RowDataBound"
                        AllowPaging="True" OnPageIndexChanging="grdCMSMenu_PageIndexChanging"
                        AllowSorting="True" OnSorting="grdCMSMenu_Sorting" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black">
              <FooterStyle BackColor="#CCCC99" />
              <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
              <PagerSettings PageButtonCount="2" FirstPageText="« First"
                            LastPageText="Last »" />
              <AlternatingRowStyle BackColor="White" />
              <Columns>
              <asp:TemplateField HeaderText="CheckAll">
                <HeaderTemplate>
                  <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:HeaderClick(this);" />
                </HeaderTemplate>
                <ItemTemplate>
                  <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="RowNumber" HeaderText="S.No." SortExpression="RowNumber"
                                HeaderStyle-CssClass="Text-Center" ItemStyle-CssClass="Text-Center">
                <HeaderStyle CssClass="Text-Center"></HeaderStyle>
                <ItemStyle CssClass="Text-Center"></ItemStyle>
              </asp:BoundField>
              <asp:TemplateField HeaderText="Menu Name" SortExpression="Name" HeaderStyle-CssClass="Text-Center">
                <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "Name")%>
                  <%-- <a href="javascript:void();" onclick="window.open('ViewDetails.aspx?Id=<%#DataBinder.Eval(Container.DataItem,"Temp_Link_Id")%> &status_id=<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>','main','scrollbars=yes,fullscreen=no')">
                                <%# DataBinder.Eval(Container.DataItem, "Name")%></a>--%>
                  <asp:HiddenField ID="HydLinkID" Value='<%#DataBinder.Eval(Container.DataItem,"Link_Id")%>' runat="server" />
                </ItemTemplate>
                <HeaderStyle CssClass="Text-Center"></HeaderStyle>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Title" SortExpression="Page_Title" HeaderStyle-CssClass="Text-Center">
                <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "Page_Title")%> </ItemTemplate>
                <HeaderStyle CssClass="Text-Center"></HeaderStyle>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Created Date" SortExpression="Rec_Insert_Date" HeaderStyle-CssClass="Text-Center"
                                ItemStyle-CssClass="Text-Center">
                <ItemTemplate> <%# DataBinder.Eval(Container.DataItem, "Rec_Insert_Date")%> </ItemTemplate>
                <HeaderStyle CssClass="Text-Center"></HeaderStyle>
                <ItemStyle CssClass="Text-Center"></ItemStyle>
              </asp:TemplateField>
              <asp:TemplateField HeaderStyle-CssClass="Text-Center" ItemStyle-CssClass="Text-Center">
                <HeaderTemplate> Edit </HeaderTemplate>
                <ItemTemplate> <a href="<%# ResolveUrl("~/auth/Adminpanel/cms/EditContent.aspx?Moduleid=1&uid=2&MenuID="+Eval("Temp_Link_Id")) %>&statusID=<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>">
                  <asp:Image ID="imgedit" runat="server" ImageUrl="../images/edit.gif" ToolTip="Edit" />
                  </a>
                  <%--<a  class="btn btn-outline btn-round btn-sm purple" href='<%# ResolveUrl("~/auth/Adminpanel/cms/EditContent.aspx?Moduleid=1&uid=2&MenuID="+Eval("Temp_Link_Id")) %>&statusID=<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>' ><i class="fa fa-edit"></i>Edit</a>--%>
                  <asp:Image ID="emgnotedit" runat="server" Height="10" ImageUrl="../images/th_star.png"
                                        Visible="false" ToolTip="Record present in draft list" />
                </ItemTemplate>
                <HeaderStyle CssClass="Text-Center"></HeaderStyle>
                <ItemStyle CssClass="Text-Center"></ItemStyle>
              </asp:TemplateField>
              <asp:TemplateField>
                <HeaderTemplate> Delete </HeaderTemplate>
                <ItemTemplate> <a href="<%# ResolveUrl("~/auth/Adminpanel/cms/DeletedContent.aspx?Moduleid=1&uid=2&MenuID="+Eval("Temp_Link_Id")) %>&statusID=<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>">
                  <asp:Image ID="imgedit1" runat="server" ImageUrl="~/Auth/AdminPanel/images/delete-icon.png" ToolTip="Edit" />
                  </a>
                  <%--<a  class="btn btn-outline btn-round btn-sm purple" href='<%# ResolveUrl("~/auth/Adminpanel/cms/EditContent.aspx?Moduleid=1&uid=2&MenuID="+Eval("Temp_Link_Id")) %>&statusID=<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>' ><i class="fa fa-edit"></i>Edit</a>--%>
                  <asp:Image ID="emgnotedit1" runat="server" Height="10" ImageUrl="../images/th_star.png"
                                        Visible="false" ToolTip="Record present in deleted list" />
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <HeaderTemplate> Delete permanently </HeaderTemplate>
                <ItemTemplate>
                  <asp:ImageButton ID="imgDelete" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Temp_Link_Id") %>'
                                        CommandName="Delete" ToolTip="Delete" Height="10" ImageUrl="~/Auth/AdminPanel/images/delete-icon.png"
                                        OnClientClick="return confirm('Are You sure want to Delete?');" Width="11" />
                  <asp:Label ID="lblStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>'
                                        Visible="false"> </asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <%--<asp:TemplateField>
                <HeaderTemplate>
                    Restore
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="imgRestore" runat="server" border="0" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Temp_Link_Id") %>'
                        CommandName="Restore" ToolTip="Restore" Height="10" ImageUrl="~/Auth/AdminPanel/images/restoreIconLarge.jpg"
                        OnClientClick="return confirm('Are You sure want to restore?');" Width="11" />
                    <asp:Label ID="lblRestoreStatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status_Id")%>'
                        Visible="false">
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
              </Columns>
              <EmptyDataTemplate> Record Not available </EmptyDataTemplate>
              <%-- <PagerStyle CssClass="pgr" />--%>
              <PagerStyle HorizontalAlign="Right" CssClass="GridPager" BackColor="#F7F7DE" ForeColor="Black" />
              <RowStyle CssClass="drow" Wrap="True" BackColor="#F7F7DE" />
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
  </div>
</asp:Content>
