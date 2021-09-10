<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="addngo.aspx.cs" Inherits="auth_Adminpanel_NGO_addngo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .red {
            color: red;
        }
        .recordset{
            position:relative;
        }
        #btnMinus {
            position:absolute;
            bottom:8px;
            right:0px;
        }
		#btnMinus {
			right: 2px !important;
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
            var url_string = window.location.href; //window.location.href
            var url = new URL(url_string);
            var c = url.searchParams.get("id");
                var App = true;
                try {
                    $('[id*=txtApplicantName]').each(function () {

                        if ($(this).val() == "") {
                            alert('Please Enter Name')
                            $(this).focus();
                            App = false;
                            return false;
                        }
                    })
                    $('[id*=txtRgistration]').each(function () {

                        if ($(this).val() == "") {
                            alert('Please Registration Number')
                            $(this).focus();
                            App = false;
                            return false;
                        }
                    })
                    $('[id*=txtAddress]').each(function () {
                        if ($(this).val() == "" && App == true) {
                            alert('Please Enter Address')
                            $(this).focus();
                            App = false;
                            return false;
                        }
                    })
                    $('[id*=txtMobile]').each(function () {
                        if ($(this).val() == "" && App == true) {
                            alert('Please Enter Mobile')
                            $(this).focus();
                            App = false;
                            return false;
                        }
                    })
                    $('[id*=txtWork]').each(function () {
                        if ($(this).val() == "" && App == true) {
                            alert('Please Enter Work Done')
                            $(this).focus();
                            App = false;
                            return false;
                        }
                    })
                    
                    var d = '';
                    var NGORecordArray = new Array();
                    var NGORecord = {};
                    $('.recordset').each(function () {
                        NGORecord.Name = $(this).find('#txtApplicantName').val();
                        NGORecord.Rgistration = $(this).find('#txtRgistration').val();
                        NGORecord.Address = $(this).find('#txtAddress').val();
                        NGORecord.Mobile = $(this).find('#txtMobile').val();
                        NGORecord.WorkDone = $(this).find('#txtWork').val();
                        NGORecord.Remark = $(this).find('#txtRemarks').val();
                        NGORecord.fileupload = $(this).find('#fileupload').val();
                        var Cus = JSON.stringify(NGORecord);
                       
                        NGORecordArray.push(Cus);
                    });
                    //=========================Handler==================================
                   
                    //========================Save Multiple Record============================================
                    if (NGORecordArray.length > 0 && App == true) {
                        $.ajax({
                            type: "POST",
                            url: "addngo.aspx/SaveRecord",
                            data: "{'NGORECORD': '" + JSON.stringify(NGORecordArray) + "' }",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                alert("NGO Record has been save sucessfully");
                                window.location.href = "ngolistaspx.aspx?id="+ c ;
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
        <div class="wrapper-content" style="padding-top: 0px; min-height: 550px;">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-primary1" style="margin-bottom: 25px; margin-top: 20px;">
                        <div class="box-header with-border">
                            <h3 class="box-title" style="color: #005529;">Add NGO Details(if any)</h3>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                <div class="col-md-12">
					<button type="button" class="btn btn-primary btn-md pull-left">Back</button>
					<asp:Button ID="btnSkip" runat="server" CssClass="btn btn-success pull-right" Text="Skip" OnClick="btnSkip_Click"/>
				</div>
				</div>
                <div class="col-md-12">                    
                    <div class="col-md-3">
                        <div id="" class="form-group">
                            <label for="id_stock_1_product1" class="control-label requiredField">
                                State <span class="red">* </span>
                            </label>
                            <div class="controls">
                                <asp:TextBox disabled="disabled" id="txtStateName" runat="server" class="textinput form-control" autocomplete="stopdoingthat" onkeypress="return IsAlphaNumeric(event);"></asp:TextBox>
						   </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div id="" class="form-group">
                            <label for="id_stock_1_product1" class="control-label  requiredField">
                                Tiger Reserve <span class="red">* </span>
                            </label>
                            <div class="controls">
                                <asp:TextBox runat="server" disabled="disabled" id="txtTigerReserve" class="textinput form-control" autocomplete="stopdoingthat" onkeypress="return IsAlphaNumeric(event);" onkeyup="myFunction()"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div id="" class="form-group">
                            <label for="id_stock_1_product1" class="control-label requiredField">
                                District <span class="red">* </span>
                            </label>
                            <div class="controls">
                                <asp:TextBox runat="server" disabled="disabled" id="txtDistrict" class="textinput form-control" autocomplete="stopdoingthat" onkeypress="return IsAlphaNumeric(event);" onkeyup="myFunction()"></asp:TextBox> 
                                
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div id="" class="form-group">
                            <label for="id_stock_1_product1" class="control-label  requiredField">
                                Village <span class="red">* </span>
                            </label>
                            <div class="controls">
                                <asp:TextBox runat="server" disabled="disabled" name="txtApplicantName" id="txtVillage" class="textinput form-control" autocomplete="stopdoingthat" onkeypress="return IsAlphaNumeric(event);" onkeyup="myFunction()"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div id="czContainer">
                        <div id="first">
                            <div class="recordset">
                                <div class="fieldRow clearfix">
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_product1" class="control-label  requiredField">
                                                Name <span class="red">* </span>
                                            </label>
                                            <div class="controls">
                                                <input type="text" name="txtApplicantName" id="txtApplicantName" class="textinput form-control" autocomplete="stopdoingthat">
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_product1" class="control-label  requiredField">
                                                Registration <span class="red">* </span>
                                            </label>
                                            <div class="controls">
                                                <input type="text" name="txtRgistration" id="txtRgistration" class="textinput form-control" autocomplete="stopdoingthat" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_unit1" class="control-label  requiredField">
                                                Address <span class="red">* </span>
                                            </label>
                                            <div class="controls ">
                                                <input type="text" id="txtAddress" class="form-control" autocomplete="off">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                Mobile No. <span class="red">* </span>
                                            </label>
                                            <div class="controls">
                                                <input type="text" id="txtMobile" class="form-control" id="" maxlength="10" autocomplete="off" onkeypress="return IsAlphaNumeric(event);" onkeyup="myFunction()" name="">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                Email <span class="red">* </span>
                                            </label>
                                            <div class="controls ">
                                                <input type="text" class="form-control" id="txtWork"  autocomplete="off" >
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                Remarks<span class="red"> </span>
                                            </label>
                                            <div class="controls ">
                                                <input type="text" class="form-control" id="txtRemarks"  autocomplete="off" onkeypress="return validateNumber(event);" onkeyup="myFunction()" name="">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div id="" class="form-group">
                                            <label for="id_stock_1_quantity1" class="control-label  requiredField">
                                                Related Attachment<span class="red"> </span>
                                            </label>
                                            <div class="controls ">
                                                <input type="file" name="fileupload" id="fileupload" class="form-control">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <div class="col-md-6 ">
            <div class="text-left mt0">
                <button type="button" class="btn btn-primary" id="btnSaveRecords" onclick="return Saverecords()">Submit</button>
            </div>
        </div>
        </div>
    </div>
    
    <div class="row">
    </div>
    <script src="JS/jquery.czMore-1.5.3.2.js"></script>
    <script type="text/javascript">
        $("#czContainer").czMore();
        $("#btnPlus").trigger("click");
    </script>
    <input type="file" name="postedFile" style="display:none"/>
    <input type="button" id="btnUpload" value="Upload" style="display:none"/>
    <progress id="fileProgress" style="display: none"></progress>
    <hr />
    <span id="lblMessage" style="color: Green"></span>
    <script type="text/javascript">
        $("body").on("click", "#btnSaveRecords", function () {
            $.ajax({
                url: '<%=ResolveUrl("~/Handler.ashx")%>',
                type: 'POST',
                data: new FormData($('form')[0]),
                cache: false,
                contentType: false,
                processData: false,
                success: function (file) {
                    $("#fileProgress").hide();
                    $("#lblMessage").html("<b>" + file.name + "</b> has been uploaded.");
                },
                xhr: function () {
                    var fileXhr = $.ajaxSettings.xhr();
                    if (fileXhr.upload) {
                        $("progress").hide();
                        fileXhr.upload.addEventListener("progress", function (e) {
                            if (e.lengthComputable) {
                                $("#fileProgress").attr({
                                    value: e.loaded,
                                    max: e.total
                                });
                            }
                        }, false);
                    }
                    return fileXhr;
                }
            });
        });
    </script>
</asp:Content>

