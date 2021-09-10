<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="VillageAreaDisplay.aspx.cs" Inherits="auth_Adminpanel_Enterform_VillageAreaDisplay" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 700px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
    </style>
    <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../../js/bootstrap.min.js"></script>
    <script src="../../../js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">

    <script type="text/javascript">

        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.gvVillage.Rows.Count %>');
            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }


        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl = document.getElementById('<%= this.gvVillage.ClientID %>');
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
    <script type="text/javascript">
        $(function () {
            $("[id*=lnkViewDetails]").click(function (event) {
                debugger;
                var villageid = $(this).attr("data-id");

                var pagrUrl = "villagedetails.aspx?vid=" + villageid;
                $('#demoModal').modal('show').find('.modal-body').load(pagrUrl);
                //  $('#demoModal').modal('show');
                // $('#demoModal').modal('show').find('[id*=iframevillage]').attr("src", pagrUrl)



                return false;
            });
            //$('[id*=iframevillage]').load(function () {
            //    alert("");
            //    this.style.height =
            //    this.contentWindow.document.body.offsetHeight + 'px';
            //});
        });

    </script>
    <style>
        .modal-dialog {
            width: 70% !important;
        }
    </style>
    <!--Button to Trigger Modal-->

    <!-- Modal -->
    <div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    
    
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Village Details</h4>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                </div>
            </div>
        </div>
        
        
        
    </div>
    <div class="wrapper-content">
        <div class="row">
            <div class="col-lg-12 top20 bottom20">
                <div class="widgets-container">
                    <div style="float: right">
                        <asp:Button ID="btnAssociateNGO" CssClass="btn btn-primary" runat="server" Text="Associate NGO" OnClick="btnAssocateNGO_Click" />

                    </div>
                    <h5>All form elements </h5>
                    <hr>
                    <div class="form-horizontal">
                        
                        <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Select State</label>
                            <div class="col-md-9 input-group">
                                <asp:DropDownList ID="ddlstate" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlstate" ValidationGroup="val"
                                    ErrorMessage="Enter Address" />
                            </div>

                        </div>
                        </div>
                        <div class="col-md-6">
                        <div class="form-group">
                            <label class="col-md-3 control-label">Select Tiger Reserve</label>
                            <div class="col-md-9 input-group">
                                <asp:DropDownList ID="ddltigerreserve" runat="server" CssClass="form-control"></asp:DropDownList>

                            </div>
                        </div>
                        </div>

                        <div class="col-md-6">
                        <div class="form-group">

                            <div class="col-sm-5 pdd5">
                                <asp:Button ID="btnsubmit" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
                            </div>
                        </div>
                        </div>
                        
                        <hr>
                        <div class="ibox-content collapse in">
                            <div class="widgets-container">
                                <div id="divGrid" runat="server" visible="false">
                                    <asp:GridView ID="gvVillage" AutoGenerateColumns="false" DataKeyNames="TempVillageid" runat="server" CssClass="table table-bordered table-hover"
                                        OnRowCommand="gvVillage_RowCommand"
                                        OnRowCreated="gvVillage_RowCreated">
                                        <Columns>
                                            <asp:TemplateField HeaderText="CheckAll">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" onclick="javascript:HeaderClick(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                    <asp:HiddenField ID="hydid" runat="server" Value='<%# Eval("TempVillageid") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Village Name">
                                                <ItemTemplate>
                                                    <%-- <a href="#" id="ViewDetails" ><%# DataBinder.Eval(Container.DataItem, "Village_Name") %></a>--%>
                                                    <asp:LinkButton ID="lnkViewDetails" runat="server" Text='<%# Eval("Village_Name") %>' data-id='<%# Eval("TempVillageid") %>'></asp:LinkButton>
                                                    <%--  <asp:HyperLink ID="hypVillageName" runat="server"  Text='<%# Eval("Village_Name") %>'> 

                                                    </asp:HyperLink>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Relocated_from" HeaderText="Relocated from" />
                                            <asp:BoundField DataField="Relocated_place" HeaderText="Relocated place" />

                                            <asp:BoundField DataField="NoofFamily" HeaderText="No of Family" />
                                            <asp:BoundField DataField="Current_location_Longitude" HeaderText="Current location Longitude" />

                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    Edit
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="EditVillageForm.aspx?id=<%# DataBinder.Eval(Container.DataItem, "TempVillageid") %>&Status=<%# DataBinder.Eval(Container.DataItem, "Status") %>">
                                                        <asp:Image ID="imgedit" runat="server" ToolTip="Edit" ImageUrl="~/Auth/AdminPanel/images/edit.gif" />
                                                    </a>
                                                    <asp:Image ID="imgnotedit" runat="server" Visible="false" ToolTip="pending" Height="15"
                                                        Width="15" ImageUrl="~/Auth/AdminPanel/images/th_star.png" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="Legal Notice">
                                                <ItemTemplate>
                                                    <a href="Legalnotice.aspx?id=<%# DataBinder.Eval(Container.DataItem, "TempVillageid") %>">
                                                        <asp:Image ID="imgAddLegalNotice" runat="server" ToolTip="Edit" ImageUrl="~/Auth/AdminPanel/images/edit.gif" />
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    Delete
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgDelete" runat="server" OnClientClick="return confirm('Are you sure you want delete?');"
                                                        CommandName="Delete" ImageUrl="~/Auth/AdminPanel/images/cross.png" CommandArgument='<%# Eval("TempVillageid") %>'
                                                        ToolTip="Delete" Height="15" Width="15" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                    </asp:GridView>



                                    <asp:GridView ID="grvngo" AutoGenerateColumns="false" runat="server"
                                        CellPadding="1" CellSpacing="1" Width="100%" DataKeyNames="ID"
                                        RowStyle-Wrap="true" HeaderStyle-Wrap="true" CssClass="table table-bordered table-hover"
                                        AllowPaging="True" OnRowCommand="grvngo_RowCommand"
                                        OnRowDeleting="grvngo_RowDeleting" EmptyDataText="No NGO Found">


                                        <AlternatingRowStyle CssClass="alt" />
                                        <PagerStyle CssClass="pgr" />
                                        <RowStyle Wrap="True"></RowStyle>
                                        <Columns>
                                            <%-- <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("s_no") %>'></asp:Label>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Village" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVillageNameNgo" runat="server" Text='<%#Eval("Village_Name") %>'></asp:Label>
                                                    <asp:HiddenField ID="hidVillageNgo" runat="server" Value='<%#Eval("VillageID") %>' />
                                                    <asp:HiddenField ID="hidState" runat="server" Value='<%#Eval("Stateid") %>' />
                                                    <asp:HiddenField ID="hidTigerReserveID" runat="server" Value='<%#Eval("TigerReserveid") %>' />
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NGO" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNGOName" runat="server" Text='<%#Eval("ngoname") %>'></asp:Label>
                                                    <asp:HiddenField ID="hidNgoID" runat="server" Value='<%#Eval("NGO_ID") %>' />
                                                </ItemTemplate>


                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tiger Reserve Name" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTigerReserveName" runat="server" Text='<%#Eval("TigerReserveName") %>'></asp:Label>
                                                </ItemTemplate>


                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amounts</br>(In Rs.)" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("date") %>'></asp:Label>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Work Done For Village" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWorkbyNGO" runat="server" Text='<%#Eval("WorkForVillage") %>'></asp:Label>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a id="hyedit" href="#">
                                                        <img id="editimg" src="../images/edit.gif" alt="Edit" title="Edit" width="20"
                                                            height="10" border="0" />
                                                    </a>

                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="ShowPopup" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="NgodetailDelete" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id") %>' CommandName="Delete"
                                                        Visible="true" ImageUrl="~/Auth/AdminPanel/images/cross.png" />

                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                        </Columns>

                                        <HeaderStyle Wrap="True"></HeaderStyle>
                                    </asp:GridView>

                                </div>
                                <div id="divPager" runat="server" visible="false">

                                    <asp:Repeater ID="rptPager" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                Enabled='<%# Eval("Enabled") %>' OnClick="lnkPage_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-control" Width="70px" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged_PageSizeChanged">
                                        <asp:ListItem Text="12" Value="12" />
                                        <asp:ListItem Text="24" Value="24" />
                                        <asp:ListItem Text="36" Value="36" />
                                        <asp:ListItem Text="48" Value="48" />
                                        <asp:ListItem Text="60" Value="60" />
                                        <asp:ListItem Text="120" Value="120" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <asp:Panel ID="pnlAssociateNGO" runat="server" CssClass="Popup" align="center" Style="display: none">
        <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">

            <ContentTemplate>
                <div class="widgets-container">
                    <h5>Associate NGO </h5>
                    <hr>
                    <div class="form-horizontal">
                        <asp:HiddenField ID="hfpwd" runat="server" />


                        <div class="form-group">
                            <label class="col-sm-3 control-label">Select State</label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlNGOState" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlNGOState_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlNGOState" ValidationGroup="val"
                                    ErrorMessage="Select State" />
                            </div>

                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">Select Tiger Reserve</label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlNGOTigerReserve" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlNGOTigerReserve_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">
                                Select Village
                            </label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlVillage" CssClass="form-control" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlVillage" ValidationGroup="val"
                                    ErrorMessage="Please select village" InitialValue="0" />


                            </div>

                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">
                                Select NGO
                            </label>
                            <div class="col-sm-9">
                                <asp:DropDownList ID="ddlNGO" runat="server" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" ControlToValidate="ddlNGO" ValidationGroup="val"
                                    ErrorMessage="Please select NGO" InitialValue="0" />

                            </div>

                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label">
                                Amount 
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>

                            </div>


                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label">
                                Work done by NGO
                            </label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtWorkByNGO" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>



                            </div>


                        </div>



                        <div class="form-group">
                            <div class="col-sm-12 col-sm-offset-2">
                                <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="btn aqua" OnClick="btnsaveNGO_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Save" CssClass="btn aqua" OnClick="btnupdateNGO_Click" Visible="false"/>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn aqua" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlNGOState" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlNGOTigerReserve" EventName="SelectedIndexChanged" />
                <asp:PostBackTrigger ControlID="btnsave" />
                <asp:PostBackTrigger ControlID="btnUpdate" />
                <asp:PostBackTrigger ControlID="btnCancel" />
            </Triggers>
        </asp:UpdatePanel>

    </asp:Panel>
    <asp:Button ID="btnShowAuditPopup" runat="server" Style="display: none" />
    <cc1:ModalPopupExtender ID="mpAssociateNGO" runat="server" PopupControlID="pnlAssociateNGO" CancelControlID="btnCancel" TargetControlID="btnShowAuditPopup" BackgroundCssClass="Background"></cc1:ModalPopupExtender>

</asp:Content>

