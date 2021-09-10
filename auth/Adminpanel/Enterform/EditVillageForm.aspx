<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="EditVillageForm.aspx.cs" Inherits="auth_Adminpanel_Enterform_EditVillageForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <asp:HiddenField ID="hydanimallist" runat="server" />
    <asp:HiddenField ID="hydvillageid" runat="server" />
    <asp:HiddenField ID="hydstatus" runat="server" />
    <div class="col-lg-12 top20 bottom40">
        <div class="tabs-container">
            <div class="bg_white">
                <h2>Village Area</h2>

                <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">State</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlstate" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlstate" ValidationGroup="val"
                                ErrorMessage="Enter Address" />
                        </div>

                    </div>
                </div>
                <div class="col-md-6">
                    <label class="col-sm-4 control-label" for="exampleFormControlSelect1">Tiger Reserves</label>
                    <div class="form-group col-sm-8">
                        <asp:DropDownList ID="ddltigerreserve" runat="server" CssClass="form-control">
                        </asp:DropDownList>

                    </div>
                </div>
                  <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">District</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDistrict" runat="server" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlDistrict" ValidationGroup="val"
                                ErrorMessage="Select value" />
                        </div>

                    </div>
                </div>
                  <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Tehshil</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlTehshiil" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTehshiil_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvTehshil" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlTehshiil" ValidationGroup="val"
                                ErrorMessage="Select value" />
                        </div>

                    </div>
                </div>
                 <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">GramPanchayat</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlGramPanchayat" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlGramPanchayat_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvGramPanchayat" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlGramPanchayat" ValidationGroup="val"
                                ErrorMessage="Select value" />
                        </div>

                    </div>
                </div>
                <div class="col-md-6">
                     <label class="col-sm-4 control-label" for="<%= txtvillagename.ClientID %>">Village Name</label>
                    <div class="form-group col-sm-8">
                       
                        <asp:TextBox ID="txtvillagename" runat="server" CssClass="form-control" placeholder="Enter Village Name"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Legal Status</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlLegalStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Revenue</asp:ListItem>
                                <asp:ListItem Value="2">Forest</asp:ListItem>
                                <asp:ListItem Value="3">Others</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvLegalStatus" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlLegalStatus" ValidationGroup="val"
                                ErrorMessage="Select value" />
                        </div>

                    </div>
                </div>
                 <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Status</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" >
                                 <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Relocated</asp:ListItem>
                                <asp:ListItem Value="2">Non-Relocated</asp:ListItem>
                                <asp:ListItem Value="3">Inprogress</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvStatus" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlStatus" ValidationGroup="val"
                                ErrorMessage="Select value" />
                        </div>

                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Area</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control" >
                                 <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="1">Core Area</asp:ListItem>
                               
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ID="rfvArea" Display="Dynamic" CssClass="help-block" InitialValue="0" ControlToValidate="ddlArea" ValidationGroup="val"
                                ErrorMessage="Select value" />
                        </div>

                    </div>
                </div>

                 <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Date of survey</label>
                        <div class="col-sm-8">
                           <asp:TextBox ID="txtsurdate" runat="server" CssClass ="form-control"></asp:TextBox>
                             <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image1" runat="server" /><br />
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtsurdate"
                                Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                ValidationGroup="val" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                            <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtsurdate"
                                PopupButtonID="Image1" runat="server">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtsurdate"
                                Display="Dynamic" ErrorMessage="Please Enter Date Of Survey" SetFocusOnError="True"
                                ValidationGroup="val" CssClass="red-text-asterix"></asp:RequiredFieldValidator>
                                
                        </div>

                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Date of Consenment</label>
                        <div class="col-sm-8">
                           <asp:TextBox ID="txtConcenmentDate" runat="server" CssClass ="form-control"></asp:TextBox>
                             <asp:Image ImageUrl="~/auth/Adminpanel/images/cal.jpg" ID="Image2" runat="server" /><br />
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConcenmentDate"
                                Display="Dynamic" ErrorMessage="Date Formate Should Be in(DD/MM/YYYY)" SetFocusOnError="True"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[//.](0[1-9]|1[012])[//.](19|20)\d\d"
                                ValidationGroup="val" CssClass="red-text-asterix"></asp:RegularExpressionValidator>
                            <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtConcenmentDate"
                                PopupButtonID="Image1" runat="server">
                            </cc1:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConcenmentDate"
                                Display="Dynamic" ErrorMessage="Please enter date Of concenment" SetFocusOnError="True"
                                ValidationGroup="val" CssClass="red-text-asterix"></asp:RequiredFieldValidator>
                                
                        </div>

                    </div>
                </div>
                <div class="col-md-6">
                     <label class="col-sm-4 control-label" for="<%= txtvillagename.ClientID %>">Agriculture Land (Ha)</label>
                    <div class="form-group col-sm-8">
                       
                        <asp:TextBox ID="txtagricultureland" runat="server" CssClass="form-control" />



                    </div>
                </div>

                <div class="col-md-6">
                     <label class="col-sm-4 control-label" for="<%= txtresidentialpropery.ClientID %>">Residential property (Ha)</label>
                    <div class="form-group col-sm-8">
                       
                        <asp:TextBox ID="txtresidentialpropery" runat="server" CssClass="form-control" placeholder="Enter Residential property (Ha)" />
                    </div>
                </div>
                <div class="col-md-6">
                    <label class="col-sm-4 control-label" for="<%= txttotalstandingtrees.ClientID %>">Total Standing Trees</label>
                    <div class="form-group col-sm-8">
                        
                        <asp:TextBox ID="txttotalstandingtrees" runat="server" CssClass="form-control" placeholder="Enter Total Standing Trees" />
                    </div>
                </div>
                <div class="col-md-6">
                      <label class="col-sm-4 control-label" for="<%= txttotallivestock.ClientID %>">Total Livestock</label>
                    <div class="form-group col-sm-8">
                      

                        <asp:TextBox ID="txttotallivestock" CssClass="form-control" runat="server" placeholder="Enter Total Livestock" />
                    </div>
                </div>



                <div class="col-md-6">
                    <label class="col-sm-4 control-label" for="<%= txtRelocaedfrom.ClientID %>">Relocated from</label>
                    <div class="form-group col-sm-8">
                        

                        <asp:TextBox ID="txtRelocaedfrom" CssClass="form-control" runat="server" placeholder="Enter Relocated from Place" />
                    </div>
                </div>

                <div class="col-md-6">
                    <label class="col-sm-4 control-label" for="<%= txtrelocateTo.ClientID %>">Relocated place</label>
                    <div class="form-group col-sm-8">
                        <asp:TextBox ID="txtrelocateTo" CssClass="form-control" runat="server" placeholder="Enter Relocated place" />
                    </div>
                </div>

                <div class="col-md-6">
                    <label class="col-sm-4 control-label" for="<%= txttotalwell.ClientID %>">Total well</label>

                    <div class="form-group col-sm-8">
                        
                        <asp:TextBox ID="txttotalwell" CssClass="form-control" runat="server" placeholder="Enter Total well" />
                    </div>
                </div>
               


                <div class="col-md-6 min-height100">
                     <label class="col-sm-4 control-label" for="<%= txtLatitudeCurrent.ClientID %>">GPS coordinates of Current location </label>
                    <div class="form-group col-sm-8">
                       

                        <asp:TextBox ID="txtLatitudeCurrent" runat="server" CssClass="form-control" placeholder="Latitude ie:- 28.568739" />
                    </div>
                </div>
                <div class="col-md-6">
                    <label class="col-sm-4 control-label" for="<%= txtLongitudecurrent.ClientID %>">GPS coordinates of Current location place</label>
                    <div class="form-group col-sm-8">
                        
                        <asp:TextBox ID="txtLongitudecurrent" runat="server" CssClass="form-control" placeholder="Longitude ie:-38.568739" />
                    </div>
                </div>

                

                <div class="col-md-6">
                      <label class="col-sm-4 control-label" for="<%= txtLatitudefrom.ClientID %>">GPS coordinates of Relocated From</label>

                    <div class="form-group col-sm-8">
                      
                        <asp:TextBox ID="txtLatitudefrom" runat="server" CssClass="form-control" placeholder="Latitude ie:-28.568739" />
                    </div>
                </div>
                <div class="col-md-6">
                     <label class="col-sm-4 control-label" for="<%= txtLongitudefrom.ClientID %>">GPS coordinates of Relocated From</label>
                    <div class="form-group col-sm-8">
                       
                        <asp:TextBox ID="txtLongitudefrom" runat="server" CssClass="form-control" placeholder="Longitude ie:- 38.568739" />
                    </div>
                </div>

               <%--  
                <div class="col-md-6">
                    <div class="form-group multiple-form-group">
                        <label class="col-sm-4 control-label">Other Animels</label>

                         <div class="form-group input-group col-md-8">
                            <div class="row col-md-12">
                                <table id="tblanimallist" class="table col-md-12">
                                    <thead>
                                        <tr>
                                            <td>Animal Type
                                            </td>
                                            <td>No of Animal
                                            </td>
                                            <td></td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                        <span class="input-group-btn">
                            <input type="button" id="btnaddmore" class="btn btn-primary btn-add" value="Add More" />

                        </span>
                    </div>
                </div>--%>
                <div class="col-md-6 min-height100">
                    <label class="col-sm-4 control-label" for="<%= txtotherAssets.ClientID %>">Other Assets</label>

                    <div class="form-group col-sm-8">
                        
                        <asp:TextBox ID="txtotherAssets" CssClass="form-control" TextMode="MultiLine" runat="server" />
                    </div>
                </div>
                <div class="col-md-12 text-center">

                    <asp:Button ID="btnsubmit" OnClientClick="return Validatetionform();" CssClass="btn btn-primary btn-add" runat="server" Text="Save" OnClick="btnsubmit_Click" />
                </div>


            </div>


        </div>

    </div>
    <script src="../assets/js/vendor/jquery.min.js"></script>
    
    <script type="text/javascript">


        function Validatetionform() {
            var Pageflag = true;
            var tblanimallist = "";
            $('#tblanimallist tbody tr').each(function () {

                if ($(this).find('[name="ddlanimal"]').val() == "0") {
                    alert("Please Select Animal.");
                    $(this).find('[name="ddlanimal"]').focus();
                    Pageflag = false;
                    return false;
                }
                else {
                    tblanimallist = tblanimallist + $(this).find('[name="ddlanimal"]').val() + "~";
                }
                if (Pageflag) {
                    if ($(this).find('[name="txtanimalno"]').val().trim() == "") {
                        alert("Please enter no of Animal.");
                        $(this).find('[name="txtanimalno"]').focus();
                        Pageflag = false;
                        return false;
                    }
                    else {
                        tblanimallist = tblanimallist + $(this).find('[name="txtanimalno"]').val().trim() + "^";
                    }
                }
            });

            $('[id*="hydanimallist"]').val(tblanimallist);

            return Pageflag;
        }

        var return_animal = "";
        var return_animal_village = "";
        function callback(response) {
            return_animal = response;
            //use return_first variable here
        }
        function callbackVillage(response) {
            return_animal_village = response;
            //use return_first variable here
        }
        function GetAnimal() {
            $.ajax({
                type: "POST",
                url: "../AjaxMethod.aspx/GetAllAnimal",
                async: false,
                data: {},
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    callback(response.d);
                },
                failure: function (request, error) {
                    alert(" Can't do because: " + error);
                }
            });
        }

        function GetAnimal_ByVillage() {

            var varVillageid = $('[id*="hydvillageid"]').val();
            var varStatusID = $('[id*="hydstatus"]').val();

            var data0 = { Villageid: varVillageid, StatusID: varStatusID };
            $.ajax({
                type: "POST",
                url: "../AjaxMethod.aspx/GetAll_Animal_Village",

                data: '{villageOB:' + JSON.stringify(data0) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    $.each(JSON.parse(response.d), function (idx, obj) {

                        var newrowparticipate = "<tr><td><select  name='ddlanimal' placeholder='Select' class='form-control' id='ddlanimal" + obj.id + "'  ></select></td><td> <input name='txtanimalno' class='form-control' id='txtanimalno" + obj.id + "' type='text'/></td><td><input type='Button' name='btndeleteanimal' class='btn btn-primary'  value='X'/></td></tr>";
                        $('#tblanimallist tbody').append(newrowparticipate);
                        //  bind  person dropdown
                        var ddlanimal = "ddlanimal" + obj.id;
                        var txtanimalno = "txtanimalno" + obj.id;
                        $('#' + ddlanimal).find('option').remove().end().append('<option value="0">Select</option>').val('0');

                        $.each(JSON.parse(return_animal), function (idx1, obj1) {

                            var option = $("<option />").val(obj1.Animalid).html(obj1.Animal);

                            $('#tblanimallist tbody tr:last [name="ddlanimal"]').append(option);
                        });
                        //  Select Previous Value to control
                        $('#' + ddlanimal).val(obj.Animalid);
                        $('#' + txtanimalno).val(obj.TotalAnimal);
                    });

                },
                failure: function (request, error) {
                    alert(" Can't do because: " + error);
                }
            });


        }
        $(document).ready(function () {

            GetAnimal();
            GetAnimal_ByVillage();

            addNewAnimalrow();
            $("#tblanimallist").on('click', '[name=btndeleteanimal]', function () {
                $(this).closest('tr').remove();

            });


        });
        var addNewAnimalrow = function () {


            $('#btnaddmore').click(function () {
                var newrowparticipate = "<tr><td><select  name='ddlanimal' placeholder='Select' class='form-control' ></select></td><td> <input name='txtanimalno' class='form-control'  type='text'/></td><td><input type='Button' name='btndeleteanimal' class='btn btn-primary'  value='X'/></td></tr>";

                $('#tblanimallist tbody').append(newrowparticipate);
                //  bind  person dropdown

                $('#tblanimallist tbody tr:last [name="ddlanimal"]').find('option').remove().end().append('<option value="0">Select</option>').val('0');


                $.each(JSON.parse(return_animal), function (idx, obj) {

                    var option = $("<option />").val(obj.Animalid).html(obj.Animal);
                    $('#tblanimallist tbody tr:last [name="ddlanimal"]').append(option);
                });

            });
        }
    </script>
</asp:Content>

