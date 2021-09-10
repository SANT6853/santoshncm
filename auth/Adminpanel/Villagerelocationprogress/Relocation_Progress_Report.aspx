<%@ Page Title="NTCA:Village Relocation Progress Report" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Relocation_Progress_Report.aspx.cs" Inherits="auth_Adminpanel_Villagerelocationprogress_Relocation_Progress_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">

    <style>
        table, th, td {
            border: none;
        }

        .table-2 td {
            padding: 10px;
            text-align: left;
            width: 8% !important;
        }

        .textfield, .textfield-drop {
            width: 81%;
        }

        .container-fluid {
            margin-bottom: 50px !important;
        }

        #contentbody_txtDate {
            float: left;
			margin-right:2px;
        }
		label {
 
     font-weight: 400; 
}

        .ajax__calendar_container TD {
            padding: 0px !important;
            margin: 0px;
            font-size: 11px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
           
            $('#<%= txtDate.ClientID %>').attr('readonly', true);
            $('#<%= txtnooffamilyreaming.ClientID %>').attr('readonly', true);
            $('#<%= txtnoofVilageremaining.ClientID %>').attr('readonly', true);
            //---------------------
            //Auto intelligence code fill in textbox3

            //[No. of villages remaining inside the core (CTH) ]
            // =
            //[No. of the villages in the notified Core (CTH)]
            // -
            //[No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger]
            //textbox should be enabled false
            
            $('#<%= txtNovillage.ClientID %>').on('keyup', function () {

                ToalLandARea();
            });
            $('#<%= txtnoofRelocatevillage.ClientID %>').on('keyup', function () {
                ToalLandARea();
            });
            //----------------------------------------
            //Auto intelligence code fill in textbox3

            //[No.of families remaining inside the core (CTH) ]contentbody_txtnooffamilyreaming
            // =
            //[No. of the families in the notified Core (CTH)]contentbody_txtNooffamily
            // -
            //[No. of families Relocated from the notified core (CTH) since the inception of the Project Tiger]contentbody_txtnoofRelocatedFamily
            //textbox should be enabled false
            $('#<%= txtNooffamily.ClientID %>').on('keyup', function () {

                ToalLandARea1();
            });
            $('#<%= txtnoofRelocatedFamily.ClientID %>').on('keyup', function () {
                ToalLandARea1();
            });

        });
        function ToalLandARea1() {
            // alert('ffd');contentbody_txtnooffamilyreaming
            
            var Nooffamily = "0";
            var noofRelocatedFamily = "0";
            var nooffamilyreaming = "0";

            var Total = "0";
           

            if ($('#<%= txtNooffamily.ClientID %>').val() == "") {
                Nooffamily = "0";
             }
             else {
               Nooffamily = $('#<%= txtNooffamily.ClientID %>').val();
            }
            if ($('#<%= txtnoofRelocatedFamily.ClientID %>').val() == "") {
                noofRelocatedFamily = "0";
             }
             else {
                noofRelocatedFamily = $('#<%= txtnoofRelocatedFamily.ClientID %>').val();
            }
            if ($('#<%= txtnooffamilyreaming.ClientID %>').val() == "") {
                nooffamilyreaming = "0";
            }
            else {
                nooffamilyreaming = $('#<%= txtnooffamilyreaming.ClientID %>').val();
             }
             //-------------
             // parseFloat
            Total = parseInt(Nooffamily) - parseInt(noofRelocatedFamily);
            $('#<%= txtnooffamilyreaming.ClientID %>').val(Total);
             // $('#<%= txtnooffamilyreaming.ClientID %>').val(Total.toFixed(2));
             //alert(Total);
         }
        function ToalLandARea() {
            // alert('ffd');contentbody_txtnooffamilyreaming
            var Novillage = "0";
            var noofRelocatevillage = "0";
            var noofVilageremaining = "0";

            var Total = "0";
            if ($('#<%= txtNovillage.ClientID %>').val() == "") {
                Novillage = "0";
            }
            else {
                Novillage = $('#<%= txtNovillage.ClientID %>').val();
            }
            if ($('#<%= txtnoofRelocatevillage.ClientID %>').val() == "") {
               noofRelocatevillage = "0";
             }
             else {
                noofRelocatevillage = $('#<%= txtnoofRelocatevillage.ClientID %>').val();
            }
            if ($('#<%= txtnoofVilageremaining.ClientID %>').val() == "") {
                noofVilageremaining = "0";
             }
             else {
                noofVilageremaining = $('#<%= txtnoofVilageremaining.ClientID %>').val();
            }

             //-------------
             // parseFloat
            Total = parseInt(Novillage) - parseInt(noofRelocatevillage);
            $('#<%= txtnoofVilageremaining.ClientID %>').val(Total);
           // $('#<%= txtnooffamilyreaming.ClientID %>').val(Total.toFixed(2));
             //alert(Total);
        }
        //var CollapsiblePanel1 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel1", { contentIsOpen: false });
        //var CollapsiblePanel2 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false });
        //var CollapsiblePanel3 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel3", { contentIsOpen: false });
        //var CollapsiblePanel4 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel4", { contentIsOpen: false });
        //var CollapsiblePanel5 = new Spry.Widget.CollapsiblePanel("CollapsiblePanel5", { contentIsOpen: false });

        function CompareDates(source, args) {

            var fromDate = new Date();
            var txtFromDate = document.getElementById('<%= txtDate.ClientID %>').value;
            var FromDate = txtFromDate.split("/");
            /*Start 'Date to String' conversion block, this block is required because javascript do not provide any direct function to convert 'String to Date' */
            var fdd = FromDate[0]; //get the day part
            var fmm = FromDate[1]; //get the month part
            var fyyyy = FromDate[2]; //get the year part
            fromDate.setUTCDate(fdd);
            fromDate.setUTCMonth(fmm - 1);
            fromDate.setUTCFullYear(fyyyy);
            var toDate = new Date();
            var txtToDate = document.getElementById('<%= HiddenField1.ClientID %>').value;
        var ToDate = txtToDate.split("/");
        var tdd = ToDate[0]; //get the day part
        var tmm = ToDate[1]; //get the month part
        var tyyyy = ToDate[2]; //get the year part
        toDate.setUTCDate(tdd);
        toDate.setUTCMonth(tmm - 1);
        toDate.setUTCFullYear(tyyyy);
            //end of 'String to Date' conversion block
        var difference = toDate.getTime() - fromDate.getTime();
        var daysDifference = Math.floor(difference / 1000 / 60 / 60 / 24);

            //     alert('df');
        difference -= daysDifference * 1000 * 60 * 60 * 24;

            //    //if diffrence is greater then 366 then invalidate, else form is valid
            // if(difference > 366 )
        if (daysDifference < 0)
            args.IsValid = false;
        else
            args.IsValid = true;
            //else
            //  args.IsValid = true;
    }
    </script>
    <%--<cc1:ToolkitScriptManager ID="abh" EnablePageMethods="true"  ScriptMode="Release" runat="server"></cc1:ToolkitScriptManager>--%>

    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
	<div class="wrapper-content" style="padding-top:0px;">	
        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
        <div class="inner-content-right" id="TblForm" runat="server">


		
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="Progress_table table-2">
				
				<tr>
					<td colspan="3" style="border-bottom: 3px solid #005529; padding:0;"><h3 style="color: #005529;">Village Relocation Progress Report</h3></td>
				</tr>
                
                <tr>
                    <td colspan="2" align="center"></td>

                </tr>
                <tr>

                    <td align="right">
                        <label id="dare">Report As on Date<span style="font-size: 15px; color: red;">*</span> : </label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDate" CssClass="textfield form-control" ValidationGroup="detail" runat="server"></asp:TextBox>

                        <asp:Image ImageUrl="~/auth/adminpanel/images/cal.jpg" ID="Image3" runat="server" /><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDate"
                            Display="Dynamic" ErrorMessage="Date Should Be in DD/MM/YYYY Formate" SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                            ValidationGroup="ADD" CssClass="red-text-asterix" ForeColor="Red"></asp:RegularExpressionValidator>
                        <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtDate"
                            PopupButtonID="Image3" runat="server">
                        </cc1:CalendarExtender>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="detail"
                            ControlToValidate="txtDate" ErrorMessage="Select the Date" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                        <asp:CustomValidator runat="server" ID="custDateValidator" ControlToValidate="txtDate"
                            ClientValidationFunction="CompareDates" ErrorMessage="Date Should Be Less Than Or Equal to Today's Date "
                            ValidationGroup="detail" Display="Dynamic" CssClass="red-text-asterix" ForeColor="Red"></asp:CustomValidator>
                    </td>
					<td></td>
					
                    
                </tr>
                <tr>
                    <td align="right">

                        <label>Name of the State <span style="font-size: 15px; color: red;">*</span> :</label>

                    </td>
                    <td align="left">

                        <asp:DropDownList ID="ddlstate" CssClass="textfield-drop form-control" ValidationGroup="detail" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ValidationGroup="detail"
                            InitialValue="0" ControlToValidate="ddlstate" ErrorMessage="Select the state" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td align="right">

                        <label>Name of the Tiger Reserve :</label>
                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtReserve" CssClass="textfield form-control" autocomplete="off" runat="server" ValidationGroup="detail"></asp:TextBox>
                        <%--<asp:RegularExpressionValidator ID="RegExpName" runat="server" ControlToValidate="txtReserve"
                                    Display="Dynamic" ErrorMessage="Character Only" ValidationExpression="^[a-zA-Z,-/.]*$"
                                    ValidationGroup="detail"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="detail"
                                     ControlToValidate="txtReserve" ErrorMessage="Insert The Reserve Name">
                                </asp:RequiredFieldValidator>--%>
                    </td>

                </tr>
                <tr>

                    <td align="right">


                        <label>No. of the villages in the notified Core (CTH)<span style="font-size: 15px; color: red;">*</span>:</label>

                    </td>
                    <td align="left">


                        <asp:TextBox ID="txtNovillage" CssClass="textfield form-control" autocomplete="off" ValidationGroup="detail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNovillage" runat="server" ValidationGroup="detail" ErrorMessage="Please fill it." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="txtFaxValidator3" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtNovillage" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">


                        <label>No. of the families in the notified Core (CTH)<span style="font-size: 15px; color: red;">*</span>:</label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtNooffamily" CssClass="textfield form-control" autocomplete="off" ValidationGroup="detail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtNooffamily" runat="server" ValidationGroup="detail" ErrorMessage="Please fill it." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtNooffamily" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <label>No. of villages Relocated from the notified Core (CTH) since the inception of the Project Tiger <span style="font-size: 15px; color: red;">*</span>: </label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtnoofRelocatevillage" CssClass="textfield form-control" autocomplete="off" ValidationGroup="detail" runat="server"></asp:TextBox>
                        <asp:Label ID="LbltxtnoofRelocatevillage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtnoofRelocatevillage" runat="server" ValidationGroup="detail" ErrorMessage="Please fill it." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtnoofRelocatevillage" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>

                </tr>
                <tr>

                    <td align="right">
                        <label>No. of families Relocated from the notified  core (CTH) since the inception of the Project Tiger  <span style="font-size: 15px; color: red;">*</span>: </label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtnoofRelocatedFamily" CssClass="textfield form-control" autocomplete="off" runat="server" ValidationGroup="detail"></asp:TextBox>
                        <asp:Label ID="LbltxtnoofRelocatedFamily" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtnoofRelocatedFamily" runat="server" ValidationGroup="detail" ErrorMessage="Please fill it." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtnoofRelocatedFamily" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 14px">


                        <label>No. of villages remaining inside the core (CTH) <span style="font-size: 15px; color: red;">*</span> :</label>

                    </td>
                    <td align="left" style="height: 14px">

                        <asp:TextBox ID="txtnoofVilageremaining" CssClass="textfield form-control" autocomplete="off" ValidationGroup="detail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtnoofVilageremaining" runat="server" ValidationGroup="detail" ErrorMessage="Please fill it." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtnoofVilageremaining" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                        <br />
                    </td>

                </tr>
                <tr>
                    <td align="right">

                        <label>No.of families remaining inside the core (CTH)<span style="font-size: 15px; color: red;"></span> :</label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtnooffamilyreaming" CssClass="textfield form-control"  autocomplete="off" runat="server" ValidationGroup="detail"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtnooffamilyreaming" runat="server" ValidationGroup="detail" ErrorMessage="Please fill it." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtnooffamilyreaming" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>

                </tr>
                <tr>

                    <td colspan="2"></td>
                </tr>
				<tr>
					<td colspan="3" style="border-bottom: 3px solid #005529; padding:0;"><h3 style="color: #005529;">Package with which no of Villages/families relocated</h3></td>
					
				</tr>
               <tr>
                    <td colspan="2" align="center"></td>

                </tr>
                <tr >
                    <td align="right">

                        <label align="right">10 Lakh per Family</label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtAmountperfamily" CssClass="textfield form-control" autocomplete="off" runat="server" ValidationGroup="detail"></asp:TextBox>
                       <asp:Label ID="LbltxtAmountperfamily" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtAmountperfamily" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>

                </tr>
                <tr>

                    <td align="right">

                        <label>
                            Land Packageable</label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtlandpackage" CssClass="textfield form-control" autocomplete="off" runat="server" ValidationGroup="detail"></asp:TextBox>
                       <asp:Label ID="Lbltxtlandpackage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtlandpackage" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">

                        <label>
                            1 Lakh per Family & Landable</label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtlandmoneyperfamily" CssClass="textfield form-control" autocomplete="off" runat="server" ValidationGroup="detail"></asp:TextBox>
                      <asp:Label ID="Lbltxtlandmoneyperfamily" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtlandmoneyperfamily" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>

                </tr>
                <tr>
                    <td align="right">

                        <label>Villages Relocated with any other Package :</label>

                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtvillageReAnyotherpackge" CssClass="textfield form-control" autocomplete="off" runat="server" ValidationGroup="detail"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ValidationGroup="detail"
                            Display="Dynamic" ControlToValidate="txtvillageReAnyotherpackge" ErrorMessage="Please Enter Only Numeric Digit"
                            ValidationExpression="[0-9]+$" SetFocusOnError="True" ForeColor="Red">Please Enter Only Numeric Digit</asp:RegularExpressionValidator>
                    </td>

                </tr>
                <tr>

                    <td align="right">
                        <label>Remarks :</label>
                    </td>
                    <td align="left">

                        <asp:TextBox ID="txtremarks" runat="server" CssClass="textfield form-control" autocomplete="off" TextMode="MultiLine" ValidationGroup="detail"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td></td>
                    <td colspan="" style=" ">
                        <asp:Button ID="btnsubmit" runat="server" ValidationGroup="detail" Text="Submit" CssClass="btn btn-primary btn-add"
                            OnClick="btnsubmit_Click" />
                        &nbsp;
                <asp:Button ID="Btnreset" runat="server"
                    CssClass="btn btn-primary btn-add" Text="Reset" CausesValidation="false" OnClick="Btnreset_Click" />&nbsp;
                <asp:Button
                    ID="btnback" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-add" Text="Back"
                    OnClick="btnback_Click" />
                    </td>

                </tr>
                <asp:HiddenField ID="HiddenField1" runat="server" />
        </div>
    </div>
    </div>
    <%--</div>
    </div>--%>
</asp:Content>

