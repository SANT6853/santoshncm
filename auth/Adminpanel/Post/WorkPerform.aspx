﻿<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="WorkPerform.aspx.cs" Inherits="auth_Adminpanel_Post_WorkPerform" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
            var c = url.searchParams.get("id");
            var App = true;
            try {
                $('[id*=txtExecutiveName]').each(function () {

                    if ($(this).val() == "") {
                        alert('Please Enter Name')
                        $(this).focus();
                        App = false;
                        $("#btnupoading").hide();
                        $("#btnSaveRecords").show();
                        return false;
                    }
                })
                $('[id*=txtAmountSpent]').each(function () {
                    if ($(this).val() == "" && App == true) {
                        alert('Please Enter Address')
                        $(this).focus();
                        App = false;
                        $("#btnupoading").hide();
                        $("#btnSaveRecords").show();
                        return false;
                    }
                })
                $('[id*=txtremaningBalance]').each(function () {
                    if ($(this).val() == "" && App == true) {
                       // alert('Please Enter Mobile')
                       // $(this).focus();
                       // App = false;
                       // $("#btnupoading").hide();
                       // $("#btnSaveRecords").show();
                       // return false;
                    }
                })
                $('[id*=txtWork]').each(function () {
                    if ($(this).val() == "" && App == true) {
                        alert('Please Enter Work Done')
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
                    NGORecord.Name = $(this).find('#txtExecutiveName').val();
                    NGORecord.AmountSpent = $(this).find('#txtAmountSpent').val();
                    NGORecord.RemainingBalance = $(this).find('#txtremaningBalance').val();
                    NGORecord.WorkDone = $(this).find('#txtWork').val();
                    NGORecord.TaskDone = $(this).find('#txtTaskDone').val();
                    NGORecord.Remark = $(this).find('#txtRemarks').val();
                    var Cus = JSON.stringify(NGORecord);

                    NGORecordArray.push(Cus);
                });
                //=========================Handler==================================

                //========================Save Multiple Record============================================
                if (NGORecordArray.length > 0 && App == true) {
                    $.ajax({
                        type: "POST",
                        url: "WorkPerform.aspx/SaveRecord",
                        data: "{'WorkPerform': '" + JSON.stringify(NGORecordArray) + "' }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            alert("Record has been save sucessfully");
                            window.location.href = "workperformlist.aspx?id=" + c;
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
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
        <%-- ***************nw****** --%>
        <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
            <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
                <div class="row">
                    <div class="stpdiv"> <span class="box-title stp1 stepArrow">Step-1</span> <span class="box-title stp1 stepArrow">Step-2</span> <span class="box-title stp1 stepArrow stepActive">Step-3</span> <span class="box-title stp1 stepArrow">Step-4</span> <span class="box-title stp" style="color: #005529; float: right;">Total Steps - 4</span> </div>
                    <div class="col-md-12">
                        <div class="box box-primary1" style="margin-bottom: 25px; margin-top: 20px;">
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Work performed under option (II)</h3>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                    </div>
                    <div class="col-md-12">
                        <div style="margin-left: 1133px;">
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
                            </div>
                        <div class="col-md-3">
                            <div id="" class="form-group">
                                <label for="id_stock_1_product1" class="control-label  requiredField">
                                    State <span class="red">* </span>
                                </label>
                                <div class="controls">
                                    <asp:TextBox disabled="disabled" ID="txtStateName" runat="server" class="textinput form-control" autocomplete="stopdoingthat"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div id="" class="form-group">
                                <label for="id_stock_1_product1" class="control-label  requiredField">
                                    Tiger Reserve <span class="red">* </span>
                                </label>
                                <div class="controls">
                                    <asp:TextBox runat="server" disabled="disabled" ID="txtTigerReserve" class="textinput form-control" autocomplete="stopdoingthat"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div id="" class="form-group">
                                <label for="id_stock_1_product1" class="control-label  requiredField">
                                    District <span class="red">* </span>
                                </label>
                                <div class="controls">
                                    <asp:TextBox runat="server" disabled="disabled" ID="txtDistrict" class="textinput form-control" autocomplete="stopdoingthat"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div id="" class="form-group">
                                <label for="id_stock_1_product1" class="control-label  requiredField">
                                    Village <span class="red">* </span>
                                </label>
                                <div class="controls">
                                    <asp:TextBox runat="server" disabled="disabled" name="txtApplicantName" ID="txtVillage" class="textinput form-control" autocomplete="stopdoingthat"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div id="czContainer">
                            <div id="first">
                                <div class="recordset">
                                    <div class="fieldRow clearfix">
                                        <div class="col-md-2">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_product1" class="control-label  requiredField">
                                                    Executing Name <span class="red">* </span>
                                                </label>
                                                <div class="controls">
                                                    <input type="text" name="txtExecutiveName" id="txtExecutiveName" class="textinput form-control" autocomplete="off">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_unit1" class="control-label  requiredField">
                                                    Amount spent <span class="red">* </span>
                                                </label>
                                                <div class="controls ">
                                                    <input type="text" id="txtAmountSpent" name="txtAmountSpent" class="form-control" autocomplete="off" onkeypress="return IsAlphaNumeric(event);">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2" style="display:none;">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                    Remaining Balance <span class="red">* </span>
                                                </label>
                                                <div class="controls ">
                                                    <input type="text" id="txtremaningBalance" class="form-control" maxlength="10" autocomplete="off" onkeypress="return IsAlphaNumeric(event);">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                    Work Done <span class="red">* </span>
                                                </label>
                                                <div class="controls ">
                                                    <input type="text" class="form-control" id="txtWork" autocomplete="off" onkeypress="return validateNumber(event);" onkeyup="myFunction()" name="">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2" style="display:none;">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                    Task Done<span class="red"> * </span>
                                                </label>
                                                <div class="controls ">
                                                    <input type="text" class="form-control" id="txtTaskDone" autocomplete="off" onkeypress="return validateNumber(event);" onkeyup="myFunction()" name="">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div id="" class="form-group">
                                                <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                    Remarks<span class="red">  </span>
                                                </label>
                                                <div class="controls ">
                                                    <input type="text" class="form-control" id="txtRemarks" autocomplete="off" onkeypress="return validateNumber(event);" onkeyup="myFunction()" name="">
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
                                <button type="button" class="btn btn-primary" id="btnupoading" style="display:none;">upload....</button>
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

