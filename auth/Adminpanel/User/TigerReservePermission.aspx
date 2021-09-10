<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="TigerReservePermission.aspx.cs" Inherits="auth_Adminpanel_User_TigerReservePermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <asp:HiddenField ID="hydselectedTigerReserve" runat="server" />
    <div class="row">
        <div class="col-lg-5">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>Tiger Reserver </h5>

                    <!-- ibox-tools -->
                </div>
                <!-- / ibox-title -->
                <div id="demo7" class="ibox-content collapse in">
                    <div class="borderedTable">
                        <div class="table-scrollable">
                            <asp:ListBox ID="lstMsttiger" runat="server" Height="200px" CssClass="form-control">
                               
                            </asp:ListBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-2">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5></h5>
                    <asp:DropDownList ID="ddlstate" runat="server" CssClass="form-control"></asp:DropDownList>
                    <!-- ibox-tools -->
                </div>
                <!-- / ibox-title -->
                <div id="demo6" class="ibox-content collapse in">
                    <div class="borderedTable">
                        <div class="table-scrollable" style="text-align: center;">
                            <div>
                                <input id="btnselect" type="button" class="btn btn-circle btn-primary" value=">" /></div>
                            <div>
                                <input id="btnRemoveOne" type="button" class="btn btn-circle btn-primary" value="<" /></div>
                            <%--<div>
                                <input id="btnselectAll" type="button" class="btn btn-circle btn-primary" value=">>" /></div>
                            <div>
                                <input id="btnRemoveall" type="button" class="btn btn-circle btn-primary" value="<<" /></div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-5">
            <div class="ibox float-e-margins">
                <div class="ibox-title">
                    <h5>Selected Tiger Reserver </h5>

                    <!-- ibox-tools -->
                </div>
                <!-- / ibox-title -->
                <div id="demo8" class="ibox-content collapse in">
                    <div class="borderedTable">
                        <div class="table-scrollable">

                            <asp:ListBox ID="ddlselected" runat="server" Height="200px" CssClass="form-control"></asp:ListBox>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5">
        </div>
        <div class="col-lg-2">

            <asp:Button ID="btnsubmit" runat="server"  Text="Submit" CssClass="btn btn-info" OnClick="btnsubmit_Click" 
            OnClientClick="return GetSelectedValue();" />
        </div>
        <div class="col-lg-5">
        </div>
    </div>
   
    <script type="text/javascript">
        function GetSelectedValue() {
            var countoption = $("#contentbody_ddlselected option").length;
            var selectedoption = $("#contentbody_ddlselected :selected").length;
            var selectedTigerReserve=""
            if (countoption > 0)
            {

                $('#contentbody_ddlselected option').each(function () {
                    var itemvalue = $(this).val();
                    var itemtext = $(this).text();
                    selectedTigerReserve = selectedTigerReserve + itemvalue + ",";

                });
                $('[id*=hydselectedTigerReserve]').val(selectedTigerReserve);
            }
            //else
            //{
            //    alert("Sorry! no item selected");
            //    return false;

            //}


        }
        $(document).ready(function () {


            $('#btnRemoveall').click(function () {
                $('#contentbody_ddlselected option').each(function () {
                    $(this).remove();
                });
            });
            $('#btnselectAll').click(function ()
            {
               
               
                var countoption = $("#contentbody_ddlselected option").length;
                $('#contentbody_lstMsttiger option').each(function () {
                    var itemvalue = $(this).val();
                    var itemtext = $(this).text();
                    var exists = false;
                    $('#contentbody_ddlselected option').each(function () {
                        if (this.value == itemvalue) {
                            exists = true;
                        }
                    });
                    if (!exists) {
                        var mySelect = $('#contentbody_ddlselected');
                        mySelect.append($('<option></option>').val(itemvalue).html(itemtext));
                    }

                });


            });

            $('#btnRemoveOne').click(function () {
                var countoption = $("#contentbody_ddlselected option").length;
                var selectedoption = $("#contentbody_ddlselected :selected").length;

                var Selectedtest = $("#contentbody_ddlselected option:selected").text();
                var Selectedval = $("#contentbody_ddlselected option:selected").val();
                if (countoption > 0)
                {

                    if (selectedoption > 0) {
                        $("#contentbody_ddlselected option:selected").remove();
                        var mySelect = $('#contentbody_lstMsttiger');
                        mySelect.append(
                             $('<option></option>').val(Selectedval).html(Selectedtest));
                    }
                    else {
                        alert("Please select item for remove");

                    }
                }
                else {
                    alert("Sorry! no item for remove");
                }

            });

            $('#btnselect').click(function () {
               
                var count = $("#contentbody_lstMsttiger :selected").length;
             
                if (count > 0)
                {
                    var Selectedtest = $("#contentbody_lstMsttiger option:selected").text();
                    if (Selectedtest != "No record found")
                    {
                        var Selectedval = $("#contentbody_lstMsttiger option:selected").val();
                        // Check  Item Exists or not in Selected Item
                        var exists = false;
                        $('#contentbody_ddlselected option').each(function () {
                            if (this.value == Selectedval) {
                                exists = true;
                                return false;
                            }
                        });
                        if (!exists) {
                            var mySelect = $('#contentbody_ddlselected');
                            mySelect.append(
                                 $('<option></option>').val(Selectedval).html(Selectedtest));

                            $("#contentbody_lstMsttiger option:selected").remove();
                        }
                    }
                    else {
                        alert("Please add tiger reserve.");

                    }

                }
                else {
                    alert("Please Select column.");
                    $("#contentbody_lstMsttiger").focus();
                }

            });
        });
    </script>
</asp:Content>

