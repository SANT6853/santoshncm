<%@ Page Title="NTCA:Survey Report" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="surveyreport.aspx.cs" Inherits="auth_Adminpanel_REPORT_surveyreport" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
  <style>
/*#scfar, tr:hover {
	background-color: #f5f5f5;
}*/
#contentbody_rolsuper .form-control {
	display: block;
	width: 100%;
	height: 34px;
	padding: 6px 12px;
	font-size: 14px;
	line-height: 1.42857143;
	color: #555;
	background-color: #fff;
	border: 1px solid #ccc;
	border-radius: 4px;
	-webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
	box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
	-webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
	-o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
	transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
}
.row {
	margin-left: -10px;
	margin-right: -10px;
}
.pgr a, .pgr span {
	display: block;
	height: 30px;
	width: 30px;
	font-weight: bold;
	text-align: center;
	text-decoration: none;
	padding: 5px 10px;
}
a {
	color: #337ab7;
	text-decoration: none;
}
.pgr a {
	background-color: #f5f5f5;
	color: #969696;
	border: 1px solid #969696;
}
.pgr span {
	background-color: #005529;
	color: #fff;
	border: 1px solid #005529;
}
.pagination td {
	border: none !important;
	padding: 1px;
}
.form-horizontal .control-label {
	padding-top: 7px;
	margin-bottom: 0;
	text-align: left;
}
.mb15{
	margin-bottom:15px;
}
.table>tbody>tr:nth-of-type(odd) {
    background-color: #f4ffde;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server" >
  <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
    <div class="col-md-12 mb15 text-right">
        <asp:Button id="excl" CssClass="btn btn-primary btn-sm" runat="server" OnClick="excl_Click" Text="export to excel"/>
    </div>
    <div class="wrapper-content">
      <div class="form-horizontal">
        <div class="row" id="rolsuper" runat="server" visible="false">
          <div class="col-md-4">
            <div class="form-group">
              <label class="col-sm-5 control-label"> State Name <span style="color: red;">*</span>: </label>
              <div class="col-md-7">
                <asp:DropDownCheckBoxes ID="DdlStateName" runat="server" AutoPostBack="true" CssClass="form-control" Font-Size="Larger" AddJQueryReference="false" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlStateName_SelectedIndexChanged">
                  <Style DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                  <Texts SelectBoxCaption="Select State Name"  />
                </asp:DropDownCheckBoxes>
                <%--<asp:DropDownList ID="DdlStateName" runat="server" CssClass="form-control" AutoPostBack="True" ></asp:DropDownList>--%>
              </div>
            </div>
          </div>
          <div class="col-md-4">
          <div class="form-group">
              <label class="col-sm-5 control-label">Selected states:</label>
            <div class="col-md-7">
              <fieldset class="mt10 sel padding10">
                <div class="seldiv" style="margin-left: 0;">
                  <asp:Label ID="LblMsgStateName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                  <asp:Label ID="LblMsgStateValue" Font-Size="0px" runat="server" ForeColor="green">You have not selected.</asp:Label>
                </div>
              </fieldset>
            </div>
          </div>
        </div>
        <div id="rolsupertiger" runat="server" visible="false">
          <div class="col-md-4">
          <div class="form-group">
            <label class="col-sm-5 control-label"> Select Tiger Reserve name<span class="red-text">*</span> </label>
            <div class="col-md-7">
              <asp:DropDownCheckBoxes ID="DdlTigerReserve" runat="server" CssClass="form-control" AutoPostBack="true" Font-Size="Larger" AddJQueryReference="false" UseButtons="True" UseSelectAllNode="True" OnSelectedIndexChanged="DdlTigerReserve_SelectedIndexChanged">
                <Style DropDownBoxBoxWidth="200" DropDownBoxBoxHeight="130" />
                <Texts SelectBoxCaption="Select Tiger reserve name" />
              </asp:DropDownCheckBoxes>
              <asp:Label ID="ErrorChkTigerReserveName" runat="server" ForeColor="Red"></asp:Label>
            </div>
          </div>
          </div>
          <div class="col-md-4">
            <div class="form-group">
              <label class="col-sm-4 control-label">Selected Tiger reserve:</label>
            <div class="col-md-7">
              <fieldset class="mt10 sel padding10">
                <div class="seldiv" style="margin-left: 0;">
                  <asp:Label ID="LblMsgTigerReserveName" runat="server" ForeColor="green">You have not selected.</asp:Label>
                  <asp:Label ID="LblMsgTigerReserveValue" Font-Size="0px"  runat="server" ForeColor="green">You have not selected.</asp:Label>
                </div>
              </fieldset>
            </div>
          </div>
        </div>
        <div class="col-md-12 mt20">
          <div class="form-group col-md-8">
            <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-add" OnClick="BtnSearch_Click" />
            <asp:Button ID="BtnRefresh" runat="server" Text="Reset" CssClass="btn btn-primary btn-add" OnClick="BtnRefresh_Click" />
            <asp:Label ID="LblErrorBtnSearch" runat="server" ForeColor="Red"></asp:Label>
          </div>
        </div>
      </div>
    </div>
    <div class="col-md-12">
      <div class="row">
        <div class="table-responsive">
          <asp:GridView ID="GridView1" OnPreRender="gridView_PreRender" runat="server" AutoGenerateColumns="false" cssclass="table" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
            <PagerStyle CssClass="pgr" HorizontalAlign="Left" />
            <EmptyDataTemplate >NO record found!!</EmptyDataTemplate>
            <Columns>
            <asp:BoundField DataField="slno" HeaderText="Sl.No" />
            <asp:BoundField DataField="datatype" HeaderText="Type" />
            <asp:BoundField DataField="SurveyDate" HeaderText="Date of survey" />
            <asp:BoundField DataField="Surveyor" HeaderText="Name of surveyor" />
            <asp:BoundField DataField="DesignationSurveyor" HeaderText="Designation of Surveyor" />
            <asp:BoundField DataField="StateName" HeaderText="State" />
            <asp:BoundField DataField="Tiger_Village" HeaderText="Village" />
            <asp:BoundField DataField="GramPanchayatName" HeaderText="Gram Panchayat" />
            <asp:BoundField DataField="DistName" HeaderText="District" />
            <asp:BoundField DataField="TigerReserveName" HeaderText="Name of the Tiger Reserve" />
            <asp:TemplateField HeaderText="Panchayat Office" >
              <ItemTemplate>
                <asp:Label ID="po" runat="server" Text='<%# string.Format("{0}",Eval("RdbPanchayatOffice").ToString()=="Yes"?Eval("PanchayatOffice"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Anganwadi">
              <ItemTemplate>
                <asp:Label ID="Ang" runat="server" Text='<%# string.Format("{0}",Eval("RdbAnganwadi").ToString()=="Yes"?Eval("Anganwadi"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="All weather road">
              <ItemTemplate>
                <asp:Label ID="AWR" runat="server" Text='<%# string.Format("{0}",Eval("RdbAllWeatherRoad").ToString()=="Yes"?Eval("AllWeatherRoad"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Post office">
              <ItemTemplate>
                <asp:Label ID="postofice" runat="server" Text='<%# string.Format("{0}",Eval("RdbPostOffice").ToString()=="Yes"?Eval("PostOffice"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bank">
              <ItemTemplate>
                <asp:Label ID="bank" runat="server" Text='<%# string.Format("{0}",Eval("RdbBank").ToString()=="Yes"?Eval("Bank"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PDS shop/outlet">
              <ItemTemplate>
                <asp:Label ID="pds" runat="server" Text='<%# string.Format("{0}",Eval("RdbPDSShop").ToString()=="Yes"?Eval("pdsshop"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Public telephone (PCO)">
              <ItemTemplate>
                <asp:Label ID="pco" runat="server" Text='<%# string.Format("{0}",Eval("RdbPublicTelephonePCo").ToString()=="Yes"?Eval("PublicTelephonePCo"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mobile Network">
              <ItemTemplate>
                <asp:Label ID="MN" runat="server" Text='<%# string.Format("{0}",Eval("RdbMobileSignal").ToString()=="Yes"?Eval("MobileSignal"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Access to health care">
              <ItemTemplate>
                <asp:Label ID="Hcr" runat="server" Text='<%# string.Format("{0}",Eval("RdbAccessibiliythealthCare").ToString()=="Yes"?Eval("AccessibiliythealthCare"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Access to road">
              <ItemTemplate>
                <asp:Label ID="AtR" runat="server" Text='<%# string.Format("{0}",Eval("RdbAccessibiliyRoad").ToString()=="Yes"?Eval("AccessibiliyRoad"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Access to Education">
              <ItemTemplate>
                <asp:Label ID="Ats" runat="server"  Text='<%# string.Format("<table id={2}><tr><td>Primary</td><td>{0}</td></tr><tr><td>Secondary</td><td>{1}</td></tr><tr><td>High School</td><td>{3}</td></tr><tr><td>College</td><td>{4}</td></tr></table>",Eval("RdbAvenuesEmployment").ToString()=="Yes"?Eval("EmploymentPrimary"):"NO",Eval("RdbAvenuesEmployment").ToString()=="Yes"?Eval("EmploymentSecondary"):"NO","scfar",Eval("RdbAvenuesEmployment").ToString()=="Yes"?Eval("HighSchool"):"NO",Eval("RdbAvenuesEmployment").ToString()=="Yes"?Eval("College"):"NO") %>' Style="white-space: nowrap;"></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Avenues of employment">
              <ItemTemplate>
                <asp:Label ID="empl" runat="server" Text='<%# string.Format("{0}",Eval("RdbAccessbilityElectrif").ToString()=="Yes"?Eval("AccessbilityElectrif"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Access to electricity">
              <ItemTemplate>
                <asp:Label ID="electric" runat="server" Text='<%# string.Format("{0}",Eval("RdbAccessbilityElectrif").ToString()=="Yes"?Eval("AccessbilityElectrif"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Access to Veterinary health care">
              <ItemTemplate>
                <asp:Label ID="AVHC" runat="server" Text='<%# string.Format("{0}",Eval("RdbAccessiblityVeterinary").ToString()=="Yes"?Eval("AccessiblityVeterinary"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Human-wildlife Conflict">
              <ItemTemplate>
                <asp:Label ID="HWC" runat="server" Text='<%# string.Format("{0}",Eval("RdbHumanWildlifecon").ToString()=="Yes"?Eval("HumanWildlifecon"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Access to firewood/fodder/NWFPs in forest">
              <ItemTemplate>
                <asp:Label ID="Ats" runat="server" Text='<%# string.Format("{0}",Eval("RdbAccessFireFodNwfps").ToString()=="Yes"?Eval("AccessFireFodNwfps"):"NO") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
