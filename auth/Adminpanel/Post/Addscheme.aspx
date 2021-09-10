<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Addscheme.aspx.cs" Inherits="auth_Adminpanel_Post_Addscheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .red {
            color: red;
        }
    </style>
    <style type="text/css">
        .table-2 td {
            border-top: none !important;
        }

        .control-label {
            text-align: left !important;
        }

        .red-text {
            color: red;
        }

        .form-group {
            margin-bottom: 0;
        }

        .stp {
            color: #000000;
            text-align: left;
            font-weight: bold;
            background: #f7b000;
            padding: 5px;
        }

        .stp1 {
            color: #fff;
            text-align: left;
            font-weight: bold;
            background: #005529;
            padding: 5px;
        }

        .stpdiv {
            padding: 0 0 30px 0;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            var customers = new Array();
            for (var i = 0; i < customers.length; i++) {
                AddRow(customers[i][0], customers[i][1]);
            }
        });
        function Add() {
            AddRow($("#txtName").val(), $("#txtCountry").val());
            $("#txtName").val("");
            $("#txtCountry").val("");
        };
        function AddRow(name, country) {
            var tBody = $("#tblCustomers > TBODY")[0];
            row = tBody.insertRow(-1);
            var cell = $(row.insertCell(-1));
            cell.html(name);
            cell = $(row.insertCell(-1));
            var btnRemove = $("<input />");
            btnRemove.attr("type", "button");
            btnRemove.attr("class", "btn btn-danger btn-xs");
            btnRemove.attr("onclick", "Remove(this);");
            btnRemove.val("Remove");
            cell.append(btnRemove);
        };
        function Remove(button) {
            var row = $(button).closest("TR");
            var name = $("TD", row).eq(0).html();
            if (confirm("Do you want to delete: " + name)) {
                var table = $("#tblCustomers")[0];
                table.deleteRow(row[0].rowIndex);
            }
        };
    </script>
    <script type="text/javascript">
        function Saverecords() {
            $("#btnupoading").show();
            $("#btnSaveRecords").hide();
            var url_string = window.location.href; //window.location.href
            var url = new URL(url_string);
            var c = url.searchParams.get("s");
            var App = true;
            try {
                
                $('[id*=txtBenifits]').each(function () {
                    if ($(this).val() == "" && App == true) {
                        alert('Please Enter Benifits')
                        $(this).focus();
                        App = false;
                        $("#btnupoading").hide();
                        $("#btnSaveRecords").show();
                        return false;
                    }
                })
                $('[id*=txtAmountSpent]').each(function () {
                    if ($(this).val() == "" && App == true) {
                        alert('Please Enter Amount Spent')
                        $(this).focus();
                        App = false;
                        $("#btnupoading").hide();
                        $("#btnSaveRecords").show();
                        return false;
                    }
                })
                var d = '';
                var NGORecordArray = new Array();
                var NGORecord = {};
                $('.recordset').each(function () {
                    NGORecord.Central = $(this).find('#ddlCentral').val();
                    NGORecord.BenefitsExtended = $(this).find('#txtBenifits').val();
                    NGORecord.AmountSpent = $(this).find('#txtAmountSpent').val();
                    NGORecord.Remark = $(this).find('#txtRemarks').val();
                    var Cus = JSON.stringify(NGORecord);

                    NGORecordArray.push(Cus);
                });
                //=========================Handler==================================

                //========================Save Multiple Record============================================
                if (NGORecordArray.length > 0 && App == true) {
                    $.ajax({
                        type: "POST",
                        url: "Addscheme.aspx/SaveRecord",
                        data: "{'WorkPerform': '" + JSON.stringify(NGORecordArray) + "' }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            alert("Convergence with others central/state Government Scheme has been save sucessfully");
                            window.location.href = "ConversionScheme.aspx?id=" + c;
                        },
                        error: function (response) {
                            alert('Failed to save record!');
                            $("#btnSaveRecords").prop('disabled', false);
                        }
                    });
                }
            }
            catch (ex) {
                $("#btnSaveRecords").prop('disabled', false);
            }
            return App;
            // return false;
        }
        function IsAlphaNumeric(event) {
            var key = window.event ? event.keyCode : event.which;
            if (event.keyCode === 8 || event.keyCode === 46) {
                return true;
            }
            else if (key < 48 || key > 57) {
                alert('Please Enter Only Numeric Value.');
                return false;
            } else {
                return true;
            }
        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
   
     <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <%-- ***************nw****** --%>
        <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
            <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
                <div class="row">
                    <div class="stpdiv">
                        <span class="box-title stp1">Step-3</span>
                        <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 4</span>
                    </div>
                    <div class="col-md-12">
                        <div class="box box-primary1" style="margin-bottom: 25px; margin-top: 20px;">
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Convergence with others central/state Government Scheme</h3>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-3">
                            <div id="" class="form-group">
                                <label for="id_stock_1_product1" class="control-label  requiredField">
                                    Scheme <span class="red">* </span>
                                </label>
                                <div class="controls">
                                    <asp:TextBox disabled="disabled" ID="txtScheme" runat="server" class="textinput form-control" autocomplete="stopdoingthat"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div id="czContainer">
                            <div id="first">
                                <div class="recordset">
                                    <div class="fieldRow clearfix">
                                        <div class="col-md-2" style="display:none;">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_product1" class="control-label  requiredField">
                                                    Scheme Name <span class="red">* </span>
                                                </label>
                                                <div class="controls">
                                                    <input type="text" name="txtSchemeName" id="txtSchemeName" class="textinput form-control" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_unit1" class="control-label  requiredField">
                                                    State/Central <span class="red">* </span>
                                                </label>
                                                <div class="controls ">
                                                    <select id="ddlCentral" class="form-control" name="ddlCentral">
                                                        <option value="1">State</option>
                                                        <option value="2">Central</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                    Benefits Extended <span class="red">* </span>
                                                </label>
                                                <div class="controls ">
                                                    <input type="text" id="txtBenifits" name="txtBenifits" class="form-control" maxlength="100" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                    Amount Spent <i class="fa fa-inr" style="font-size:16px;" aria-hidden="true"></i> <span class="red">* </span>
                                                </label>
                                                <div class="controls ">
                                                    <input type="text" class="form-control" id="txtAmountSpent" autocomplete="off" onkeypress="return IsAlphaNumeric(event);" onkeyup="myFunction()" name="">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                    Remarks<span class="red">  </span>
                                                </label>
                                                <div class="controls ">
                                                    <input type="text" class="form-control" id="txtRemarks" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-3">
                                <button type="button" class="btn btn-primary" id="btnSaveRecords" onclick="return Saverecords()">Submit</button>
                                <button type="button" class="btn btn-primary" id="btnupoading" style="display: none;">upload....</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="JS/jquery.czMore-1.5.3.2.js"></script>
    <script type="text/javascript">
        $("#czContainer").czMore();
        $("#btnPlus").trigger("click");
    </script>
</asp:Content>

