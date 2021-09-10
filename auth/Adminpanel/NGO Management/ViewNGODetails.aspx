<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="ViewNGODetails.aspx.cs" Inherits="auth_Adminpanel_NGO_Management_ViewNGODetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../assets/js/vendor/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <script type="text/javascript">

        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.grdNGODetails.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }


        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.grdNGODetails.ClientID %>');
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
    <div class="row">
        <div class="col-lg-12">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>View Content List</h5>
                </div>
                <div class="ibox-content collapse in">
                    <div class="widgets-container">
                        <div>

                            <div class="col-lg-12">
                                <div class="ibox float-e-margins">

                                    <div class="ibox-content collapse in">
                                        <div class="widgets-container">

                                            <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="col-md-3 control-label">Select State</label>
                                                <div class="col-md-9 input-group">
                                                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>

                                                </div>
                                            </div>
                                            </div>




                                          <%--  <div class="form-group">
                                                <label class="col-md-2 control-label">Select Status</label>
                                                <div class="col-md-5 input-group">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>--%>

                                            <div class="form-group">

<%--                                                <div class="col-md-5 input-group">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default"
                                                        OnClick="btnSearch_Click"
                                                        ToolTip="Click To Search" />
                                                </div>--%>
                                            </div>


                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divGrid" runat="server" visible="false">

                            <asp:GridView ID="grdNGODetails" DataKeyNames="NgoIDTemp" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-bordered table-hover" OnRowCommand="grdNGODetails_RowCommand" OnRowDeleting="grdNGODetails_RowDeleting"
                                OnRowEditing="grdNGODetails_RowEditing"
                                OnRowCreated="grdNGODetails_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="CheckAll">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:HeaderClick(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RowNumber" HeaderText="S No" />
                                    <asp:BoundField DataField="NgoName" HeaderText="NGO Name" />
                                    <asp:BoundField DataField="NgoAddress" HeaderText="Address" />
                                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Edit
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <a href="EditNGO.aspx?id=<%# DataBinder.Eval(Container.DataItem, "NgoIDTemp") %>&Status=<%# DataBinder.Eval(Container.DataItem, "StatusId") %>">
                                                <asp:Image ID="imgedit" runat="server" ToolTip="Edit" ImageUrl="~/Auth/AdminPanel/images/edit.gif" />
                                            </a>
                                            <asp:Image ID="imgnotedit" runat="server" Visible="false" ToolTip="pending" Height="15"
                                                Width="15" ImageUrl="~/Auth/AdminPanel/images/th_star.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Delete
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want delete?');"
                                                CommandName="Delete" ImageUrl="~/Auth/AdminPanel/images/cross.png" CommandArgument='<%# Eval("NgoIDTemp") %>'
                                                ToolTip="Delete" Height="15" Width="15" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>
                                            Id
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNgoIDTemp" runat="server" Text='<%#Eval("NgoIDTemp")%>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="text_3" HorizontalAlign="Center" Wrap="True" />
                                <RowStyle CssClass="drow" Wrap="True" />
                            </asp:GridView>

                         <%--   &nbsp;<asp:Button ID="btnApprove" runat="server" Text="Publish" CssClass="btn btn-default"
                                OnClientClick="javascript:return validatecheckbox();" OnClick="btnApprove_Click"
                                ToolTip="Click To Publish" />--%>

                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

