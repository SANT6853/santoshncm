<%@ Page Title="NTCA:Dashboard" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="DashboardNTCA.aspx.cs" Inherits="auth_Adminpanel_DashboardNTCA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
	$(function ()
	{
		$("[id*=lnkViewDetailss]").click(function (event) {
			debugger;
			var feedbackid = $(this).attr("data-id");
			// alert(villageid);
			var pagrUrl = "VillageListPopUp.aspx?vid=" + feedbackid;
			$('#demoModal').modal('show').find('.modal-body').load(pagrUrl);
			return false;
		});

	});
</script>
<script type="text/javascript">
	$(document).ready(function () {
		$('#LblTigerReserveShow').hide();
		$('#ball_footballbox').hide();
		$('.counter').each(function () {
			$(this).prop('Counter', 0).animate({
				Counter: $(this).text()
			}, {
				duration: 4000,
				easing: 'swing',
				step: function (now) {
					$(this).text(Math.ceil(now));
				}
			});
		});
		$('#myModalVillage').click(function () {
			location.reload();
		});
	});
</script>
<style type="text/css">
.bxtp {
    margin-bottom: 20px;
}
#theImg {
	border-radius: 50%;
}
/*Back button hide*/
/*.highcharts-button-symbol,.highcharts-button {
	display: none;
}*/
.counter {
}
/*below high chart css*/
.highcharts-credits {
	display: none;
}
.highcharts-button-symbol {
	display: none;
}
table, th, td {
	border: 1px solid black;
	border-collapse: collapse;/*width: 100% !important;*/
}
.modal-dialog {
	/*width: 100% !important;*/
	width: 80% !important;
}
#ImgTiger {
	border-radius: 50%;
}
/*.highcharts-label {
	opacity: 100 !important;
}*/
</style>
  <style>
.highcharts-label span {
	color: black !important;
}
#container {
	height: 400px;
	min-width: 310px;
	max-width: 600px;
	margin: 0 auto;
}
.loading {
	margin-top: 10em;
	text-align: center;
	color: gray;
}
.highcharts-contextbutton, .highcharts-color-undefined {
	display: none;
}
.villist {
	padding: 0px;
	min-height: 999px;
}
#contentbody_gvVillage tr:nth-child(1) {
	display: none;
}
.highcharts-background {
	fill:none !important;
}
.icon a {
	color:#fff;
}
.icon a .fa {
	font-size: 55px !important;
	margin-right: 22px;
}
.small-box {
	cursor:pointer;
}
</style>
</asp:Content>
<asp:Content ID="contentMainBody" ContentPlaceHolderID="contentbody" runat="server">
  <div class="container-fluid bigfacebg" style="margin-top: 10px; margin-bottom: 62px; padding: 10px 15px;">
    <div> </div>
    <div class="row nu12">
      <div class="col-lg-12">
        <div class="row">
          <div class="col-lg-3 col-xs-6 bxtp">
            <div class="small-box bg-aqua bg-aqua-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>';">
              <div class="inner">
                <h3><span class="counter">
                  <label id="LblVillageCounter" runat="server"></label>
                  </span></h3>
                <p>VILLAGE</p>
              </div>
              <div class="icon"> <img src="images/village.png"> </div>
              <!-- <a href="<%=ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--> 
            </div>
          </div>
          <div class="col-lg-3 col-xs-6 bxtp">
            <div class="small-box bg-green bg-green-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/TigerReserve/ViewTigerReserver.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.TigerReserve)  %>';">
              <div class="inner">
                <h3><span class="counter">
                  <label id="LblTigerReserve" runat="server"></label>
                  </span></h3>
                <p>TIGER RESERVE</p>
              </div>
              <div class="icon"> <img src="images/tiger.png"> </div>
              <!--<a href="<%= ResolveUrl("~/auth/adminpanel/TigerReserve/ViewTigerReserver.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.TigerReserve) %>" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--> 
            </div>
          </div>
          <div class="col-lg-3 col-xs-6 bxtp"> 
            <!-- small box -->
            <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/FamilyData/Family_Management.aspx") %>';">
              <div class="inner">
                <h3><span class="counter">
                  <label id="LblFamilyCounter" runat="server"></label>
                  </span></h3>
                <p>FAMILY</p>
              </div>
              <div class="icon"> <img src="images/family.png"> </div>
              <!--<a href="<%=ResolveUrl("~/auth/adminpanel/FamilyData/Family_Management.aspx") %>" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--> 
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-xs-6 bxtp"> 
            <!-- small box -->
            <div class="small-box bg-red bg-red-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/NGO/Ngoreport.aspx") %>';">
              <div class="inner">
                <h3><span class="counter">
                  <label id="LblNgocounter" runat="server"></label>
                  </span></h3>
                <p>NGO (PRE Monitoring ) </p>
              </div>
              <div class="icon"> <img src="images/ngo.png"> </div>
              <!--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--> 
            </div>
          </div>
          <!-- ./col --> 
        </div>
      </div>
      <div class="col-lg-12">
        <div class="row">
          <div class="col-lg-3 col-xs-6 bxtp" style="display:none;"> 
            <!-- small box -->
            <div class="small-box bg-red bg-red-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Banner/AddBanner.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.Banner)  %>';">
              <div class="inner"> <a href="<%= ResolveUrl("~/auth/adminpanel/Banner/AddBanner.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.Banner) %>">
                <h4>Banner Management </h4>
                </a>
                <p></p>
              </div>
              <div class="icon"> <a href="<%= ResolveUrl("~/auth/adminpanel/Banner/AddBanner.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.Banner) %>"> <img src="images/banner-management.png"></a> </div>
              <%--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
            </div>
          </div>
          <div class="col-lg-3 col-xs-6 bxtp" style="display: none;"> 
            <!-- small box -->
            <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" >
              <div class="inner"> <a href="#">
                <h4>Photo Gallery</h4>
                </a>
                <p></p>
              </div>
              <div class="icon"> <a href="#"> <img src="images/photo-gallery.png"></a> </div>
              <%--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
            </div>
          </div>
          <div class="col-lg-3 col-xs-6 bxtp" style="display:none;"> 
            <!-- small box -->

            <div class="small-box bg-aqua bg-aqua-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/CDP/CDP_Management.aspx") %>';">
              <div class="inner"> <a href="<%=ResolveUrl("~/auth/adminpanel/CDP/CDP_Management.aspx") %>">
                <h4>CDP Management</h4>
                </a>
                <p></p>
              </div>
              <div class="icon"> <a href="<%=ResolveUrl("~/auth/adminpanel/CDP/CDP_Management.aspx") %>"> <img src="images/cdp-management.png"></a> </div>
              <%--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
            </div>
          </div>

            <div class="col-lg-3 col-xs-6 bxtp"> 
            <!-- small box -->
            <div class="small-box bg-red bg-red-shadow hvr-grow-shadow" onclick="window.location='<%=ResolveUrl("~/auth/adminpanel/NGO/PostNgoreport.aspx") %>';">
              <div class="inner">
                <h3><span class="counter">
                  <label id="Labelpost" runat="server"></label>
                  </span></h3>
                <p>NGO (POST Monitoring ) </p>
              </div>
              <div class="icon"> <img src="images/ngo.png"> </div>
              <!--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--> 
            </div>
          </div>
          <!--<div class="col-lg-3 col-xs-6 bxtp">
				<div class="small-box bg-green bg-green-shadow hvr-grow-shadow" >
					<div class="inner">
						<a href="<%= ResolveUrl("~/auth/adminpanel/CMS/AddContent.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.cms) %>">
							<h4>CMS</h4>
						</a>
						<p></p>
					</div>
					<div class="icon">
						<a href="<%= ResolveUrl("~/auth/adminpanel/CMS/AddContent.aspx?Moduleid=")%><%= Convert.ToInt16( Module_ID_Enum.Project_Module_ID.cms) %>">
							<img src="images/cms.png"></a>
					</div>
					<%--<a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>--%>
				</div>
			</div>--> 
          <!-- ./col -->
          <div class="col-lg-3 col-xs-6 bxtp" style="display:none;"> 
            <!-- small box -->
            <div class="small-box bg-green bg-green-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/ProcessManegment/NtcaUser/ViewProcessReserve.aspx") %>';">
              <div class="inner"> <a href="<%= ResolveUrl("~/auth/adminpanel/ProcessManegment/NtcaUser/ViewProcessReserve.aspx") %>">
                <h4>Process Management</h4>
                </a> </div>
              <div class="icon"> <a href="<%= ResolveUrl("~/auth/adminpanel/ProcessManegment/NtcaUser/ViewProcessReserve.aspx") %>"><i class="fa fa-edit"></i></a> </div>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-xs-6 bxtp"> 
            <!-- small box -->
            <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/MisReportDashBoard.aspx") %>';">
              <div class="inner"> <a href="<%= ResolveUrl("~/auth/adminpanel/MisReportDashBoard.aspx") %>">
                <h4> MIS Reports Generation</h4>
                </a> </div>
              <div class="icon"> <a href="<%= ResolveUrl("~/auth/adminpanel/MisReportDashBoard.aspx") %>"><i class="fa fa-file"></i></a> </div>
            </div>
          </div>
          <!-- ./col --> 
          <!--pre-post-form-->
          <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 bxtp"> 
            <!-- small box -->
            <div class="small-box bg-yellow bg-yellow-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>';">
              <div class="inner"> <a href="<%= ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>">
                <h4> Pre-Voluntary village Relocation</h4>
                </a> </div>
              <div class="icon"> <a href="<%= ResolveUrl("~/auth/adminpanel/VILLAGE/Village_Management.aspx") %>"><i class="fa fa-file"></i></a> </div>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-6 col-xs-6 bxtp"> 
            <!-- small box -->
            <div class="small-box bg-aqua bg-aqua-shadow hvr-grow-shadow" onclick="window.location='<%= ResolveUrl("~/auth/adminpanel/Post/survey-details.aspx") %>';">
              <div class="inner"> <a href="<%= ResolveUrl("~/auth/adminpanel/Post/survey-details.aspx") %>">
                <h4> Post-Voluntary Village Relocation Monitoring form</h4>
                </a> </div>
              <div class="icon"> <a href="<%= ResolveUrl("~/auth/adminpanel/Post/survey-details.aspx") %>"><i class="fa fa-file"></i></a> </div>
            </div>
          </div>
          <!-- ./col --> 
          <!--pre-post-form-end--> 
        </div>
        <div class="row"> </div>
      </div>
    </div>
    <div class="row">
      <div class="col-lg-9">
        <div class="restbodr">
          <div class="panel panel-green">
            <div class="rest1">
              <div class="panel-heading "> <i class="fa fa-bar-chart-o fa-fw"></i>INDIA MAP </div>
            </div>
            <!-- /.panel-heading -->
            <div class="panel-body bigfacebg">
              <label id="ball_footballbox"></label>
              <label id="LblTigerReserveShow"></label>
              <label id="txt"></label>
              <label style="display: none;" id="LblstateID"></label>
              <label style="display: none;" id="LblMapStatID"></label>
              <label style="display: none;" id="LblMapDistricID"></label>
              <%--  <div id="container" style="height: 700px; min-width: 310px; max-width: 1000px; margin: 0 auto"></div>--%>
              <%--  //start show back button--%>
              <%-- <div style=" float:right;"><button type="submit" id="BtnBack"  value="Back">Back</button></div>
					<label id="BtnBackValues" style="display:none;"></label>--%>
              <%-- //start show back button--%>
              <div id="container" style="height: 950px; min-width: 310px; max-width: 1200px; margin: 0 auto"></div>              
              <!-- /.panel-body --> 
            </div>
          </div>
        </div>
      </div>
      <!-- /.col-lg-8 start naren--> 
      <!-- /.col-lg-8 -->
      <div class="col-lg-3">
        <div class="restbodr">
          <div class="panel panel-green">
            <div class="rest1">
              <div class="panel-heading"> <i class="fa fa-bell fa-fw"></i>Tiger reserve list
                [
                <asp:Label ID="lblcount" runat="server" Font-Bold="True"></asp:Label>
                ] </div>
            </div>
            <!-- /.panel-heading -->
            <div class="panel-body villist bigfacebg">
              <div>
                <asp:Label ID="lblnorecord" runat="server" Text=""></asp:Label>
                <asp:GridView ID="gvVillage" AutoGenerateColumns="False" DataKeyNames="TigerReserveid" runat="server" CssClass="table table-bordered table-hover "
                                    OnRowCommand="gvVillage_RowCommand"
                                    OnRowCreated="gvVillage_RowCreated" BackColor="transparent" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                  <AlternatingRowStyle  />
                  <Columns>
                  <asp:TemplateField HeaderText="Tiger Reserve name">
                    <ItemTemplate> <%# Eval("TigerReserveName") %>
                      <%-- <a href="#" id="ViewDetails" ><%# DataBinder.Eval(Container.DataItem, "Village_Name") %></a>--%>
                      <%-- <asp:LinkButton ID="lnkViewDetails" runat="server" Text='<%# Eval("VILL_NM") %>' data-id='<%# Eval("VILL_ID") %>'></asp:LinkButton>--%>
                      <%--  <asp:HyperLink ID="hypVillageName" runat="server"  Text='<%# Eval("Village_Name") %>'> 
							</asp:HyperLink>--%>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Tiger Reserve name">
                    <ItemTemplate>
                      <asp:LinkButton ID="lnkViewDetailss" runat="server" Text='Click here to village list' data-id='<%# Eval("TigerReserveid") %>'></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate> <span style="color: #459300;">Record(s) Not Available.</span> </EmptyDataTemplate>
                  <FooterStyle BackColor="#CCCC99" />
                  <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                  <PagerStyle CssClass="pgr" BackColor="" ForeColor="Black" HorizontalAlign="Right" />
                  <RowStyle CssClass="drow" Wrap="True" BackColor="" />
                  <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                  <SortedAscendingCellStyle BackColor="#FBFBF2" />
                  <SortedAscendingHeaderStyle BackColor="#848384" />
                  <SortedDescendingCellStyle BackColor="#EAEAD3" />
                  <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
              </div>
            </div>
            <!-- /.panel-body --> 
          </div>
        </div>
        <!-- /.panel --> 
      </div>
      <div class="footer">
        <div><strong>Copyright</strong> NTCA ©  2017 </div>
      </div>
    </div>
    <div> 
<script src="<%=ResolveUrl("~/js/HcharNew/1highmaps.js") %>"></script> 
<script src="<%=ResolveUrl("~/js/HcharNew/2data.js") %>"></script> 
<script src="<%=ResolveUrl("~/js/HcharNew/3drilldown.js") %>"></script> 
<script src="<%=ResolveUrl("~/js/HcharNew/4exporting.js") %>"></script> 
<script src="<%=ResolveUrl("~/js/HcharNew/5offline-exporting.js") %>"></script> 
<script src="<%=ResolveUrl("~/js/data/in-all.js") %>"></script>
<link href="<%=ResolveUrl("~/js/HcharNew/6font-awesome.css") %>" rel="stylesheet" />
</div>
<div id="container1">
<style type="text/css">
table, th, td {
	border: 1px solid black;
	border-collapse: collapse;
}
</style>
<script type="text/javascript">
	function DisplayVillage() {

		$('#myModalVillage').modal('show');

		return false;
	}

</script>
	<%--Start India map Icon code--%>
	<label id="LblBihar" style="display: none;"></label>
	<label id="LblAndamanNicobarStateName" style="display: none;"></label>
	<label id="LblAndhraPradeshStateName" style="display: none;"></label>
	<label id="LblArunachalPradeshStateName" style="display: none;"></label>
	<label id="LblAssamStateName" style="display: none;"></label>
	<label id="LblChhattisgarhStateName" style="display: none;"></label>
	<label id="LblChandigarhStateName" style="display: none;"></label>
	<label id="LblDamanDiuStateName" style="display: none;"></label>
	<label id="LblDelhiStateName" style="display: none;"></label>
	<label id="LblDadraHaveliStateName" style="display: none;"></label>
	<label id="LblGoaStateName" style="display: none;"></label>
	<label id="LblGujaratStateName" style="display: none;"></label>
	<label id="LblHimachalPradeshStateName" style="display: none;"></label>
	<label id="LblHaryanaStateName" style="display: none;"></label>
	<label id="LblJammuKashmirStateName" style="display: none;"></label>
	<label id="LblJharkhandStateName" style="display: none;"></label>
	<label id="LblKeralaStateName" style="display: none;"></label>
	<label id="LblKarnatakaStateName" style="display: none;"></label>
	<label id="LblLakshadweepStateName" style="display: none;"></label>
	<label id="LblMeghalayaStateName" style="display: none;"></label>
	<label id="LblMaharashtraStateName" style="display: none;"></label>
	<label id="LblManipurStateName" style="display: none;"></label>
	<label id="LblMadhyaPradeshStateName" style="display: none;"></label>
	<label id="LblMizoramStateName" style="display: none;"></label>
	<label id="LblNagalandStateName" style="display: none;"></label>
	<label id="LblOrissaStateName" style="display: none;"></label>
	<label id="LblPunjabStateName" style="display: none;"></label>
	<label id="LblPuducherryStateName" style="display: none;"></label>
	<label id="LblRajasthanStateName" style="display: none;"></label>
	<label id="LblSikkimStateName" style="display: none;"></label>
	<label id="LblTamilNaduStateName" style="display: none;"></label>
	<label id="LblTripuraStateName" style="display: none;"></label>
	<label id="LblUttarakhandStateName" style="display: none;"></label>
	<label id="LblUttarPradeshStateName" style="display: none;"></label>
	<label id="LblWestBengalStateName" style="display: none;"></label>
	<label id="LblTelenganaStateName" style="display: none;"></label>
	<%--Start India map Icon code--%>
	<%--<asp:LinkButton ID="lnlviewvillageDetails" OnClientClick="return DisplayVillage();"   runat="server" CssClass="btn btn-info btn-mg" ><i class="fa glyphicon glyphicon-th-list">View</i></asp:LinkButton>--%>
      <div id="myModalVillage" class="modal fade" role="dialog">
        <div class="modal-dialog"> 
          
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal">&times;</button>
              <h4 class="modal-title">Details</h4>
            </div>
            <div class="modal-body">
              <table id="tbDetails" cellpadding="0" cellspacing="0" class="table table-bordered">
                <thead style="background-color: #005529; color: White; font-weight: bold">
                  <tr style="border: solid 1px #000000">
                    <%-- <td>S.No</td>--%>
                    <td>Tiger Reserve name</td>
                    <td>State</td>
                    <td style="display: none;">Village list</td>
                    <td style="display: none;">Village relocate</td>
                    <td style="display: none;">Village yet to relocate</td>
                    <td>No of Villages in the notified Core(CTH)</td>
                    <td>No of Families in the notified Core(CTH)</td>
                    <td>No of Villages relocated from the Core(CTH) since the inception of the Project Tiger</td>
                    <td>No of Families relocated from the Core(CTH) since the inception of the Project Tiger</td>
                    <td>No.of Villages remaining inside the notified Core(CTH)</td>
                    <td>No.of Families remaining inside the notified Core(CTH)</td>
                    <td>10 Lakh per family</td>
                    <td>1 Lakh per family</td>
                    <td>Families relocated with any other package</td>
                    <td>Remarks</td>
                  </tr>
                </thead>
                <tbody>
                </tbody>
              </table>
              <label style="display: none;" id="LblMsg"></label>
              <div id="tbDetails11"></div>
            </div>
          </div>
        </div>
      </div>
      <%--start modal popup--%>
      <div class="modal fade" id="demoModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
              <h4 class="modal-title" id="myModalLabel">Village Details</h4>
            </div>
            <div class="modal-body ty23"> </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
            </div>
          </div>
        </div>
      </div>
      <%--end modal popup--%>
      <script>
                //start show back button
                //$(document).ready(function () {
                //    if ($('#BtnBackValues').text() == "") {                   
                //        $('#BtnBack').hide();
                //    }
                //    else {
                //        $('#BtnBack').show();
                //    }
                //});
                $('#BtnBackValues').click(function () {
                    //var d = ("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img id=" + "\"ImgTiger\"" + " src=" + "\"./images/ttt.jpg\"" + " width=" + "\"25px\"" + ">")
                    //$('div.highcharts-drilldown-data-label').find('span').each(function () {
                    //    var ch = ($(this).html());
                    //    console.log(ch);

                    //    // var d=ch
                    //    if (ch == d) {
                    //        $(this).html('');

                    //    }
                    //})
                });
                //end show back button
                // --Start India map Icon code--
              
                //$(window).load(function () {
                //    var d = ("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img id=" + "\"ImgTiger\"" + " src=" + "\"./images/ttt.jpg\"" + " width=" + "\"25px\"" + ">")
                //    $('div.highcharts-drilldown-data-label').find('span').each(function () {
                //        var ch = ($(this).html());
                //        console.log(ch);

                //        // var d=ch
                //        if (ch == d) {
                //            $(this).html('');

                //        }
                //    })
                //});
                //End India map Icon code
                // show all hidden place name --
                function show_all_state() {
                    transform = $('.highcharts-label').attr('transform');
                    var res = transform.slice(-8, -1);
                    var now = res.replace(",", ".");

                    var zoom_area = parseFloat(now);
                    var num = parseFloat(100.000);
                    var nout = parseFloat(240.581);
                    if (num <= zoom_area) {
                        $(".highcharts-label").removeAttr("opacity");
                        $(".highcharts-label").removeAttr("visibility");
                    }
                    if (nout <= zoom_area) {
                        $(".highcharts-label").removeAttr("opacity");
                        $(".highcharts-label").removeAttr("visibility");
                    }
                    $(window).load(function () {
                        show_all_state();
                    });
                }




                /*   $('.suddan').hover(function(){
                show_all_state();
              });*/
                $(document).on('hover', '.suddan', function () {
                    show_all_state();
                });
                $(document).on('mousemove', '.suddan', function () {
                    show_all_state();
                });
                $("text").hide();
                //$('#tbDetails').hide();
                //$('#txt').text('');
                var datawb;
                var nameSet;
                var latSet;
                var lonSet;
                var drilldownSets;
                var stateID;
                var MapStatID;
                var MapDistricID;
                var stateName;
                var HcKey;
                var lock = true;
                var preVal = null;
                var data = Highcharts.geojson(Highcharts.maps['countries/in/in-all']),
                    separators = Highcharts.geojson(Highcharts.maps['countries/in/in-all'], 'mapline'),
                    // Some responsiveness
                    small = $('#container').width() < 400;

                // var datawb;
                // Set drilldown pointers
                $.each(data, function (i) {

                    // this['hc-key'] = this.properties['hc-key'];
                    // this['postal-code'] = this.properties['postal-code'];
                    this.drilldown = this.properties['hc-key'];
                    this.value = i; // Non-random bogus data
                    //Start India map Icon code
                   // alert(this.properties['postal-code']);
                    if (this.properties['postal-code'] == "BR") {
                        //alert(this.properties.name);
                        funCheckStateRecordExistanceBihar(this.properties.name);
                        // alert($('#LblBihar').text());
                        if ($('#LblBihar').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "AP") {
                        funChkRecordExistInStateAndhraPradesh(this.properties.name);
                        if ($('#LblAndhraPradeshStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "AN") {/////////////
                        funChkRecordExistInStateAndamanNicobar(this.properties.name);
                        if ($('#LblAndamanNicobarStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "AR") {
                        funChkRecordExistInStateArunachalPradesh(this.properties.name);
                        if ($('#LblArunachalPradeshStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "AS") {
                        funChkRecordExistInStateAssam(this.properties.name);
                        if ($('#LblAssamStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "CT") {
                        funChkRecordExistInStateChhattisgarh(this.properties.name);
                        if ($('#LblChhattisgarhStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "CH") {

                        funChkRecordExistInStateChandigarh(this.properties.name);
                        if ($('#LblChandigarhStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "3464") {

                        funChkRecordExistInStateDamanDiu(this.properties.name);
                        // alert($('#LblDamanDiuStateName').text());
                        if ($('#LblDamanDiuStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "DL") {
                        funChkRecordExistInStateDelhi(this.properties.name);
                        if ($('#LblDelhiStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "DN") {
                        funChkRecordExistInDadraHaveliStateName(this.properties.name);
                        // alert($('#LblDadraHaveliStateName').text());
                        if ($('#LblDadraHaveliStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "GA") {

                        funChkRecordExistInGoaStateName(this.properties.name);
                        if ($('#LblGoaStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "2984") {
                        // alert(this.properties['postal-code']);
                        funChkRecordExistInGujaratStateName(this.properties.name);
                        if ($('#LblGujaratStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "HP") {
                        funChkRecordExistInHimachalPradeshStateName(this.properties.name);
                        if ($('#LblHimachalPradeshStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "HR") {
                        funChkRecordExistInHaryanaStateName(this.properties.name);
                        if ($('#LblHaryanaStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "JK") {
                        funChkRecordExistInJammuKashmirStateName(this.properties.name);
                        if ($('#LblJammuKashmirStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "JH") {
                        funChkRecordExistInJharkhandStateName(this.properties.name);
                        if ($('#LblJharkhandStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "KL") {/////////////////
                        funChkRecordExistInKeralaStateName(this.properties.name);
                        if ($('#LblKeralaStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "KA") {
                        funChkRecordExistInKarnatakaStateName(this.properties.name);
                        if ($('#LblKarnatakaStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "LD") {///////////////////
                        funChkRecordExistInLakshadweepStateName(this.properties.name);
                        if ($('#LblLakshadweepStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "ML") {
                        funChkRecordExistInMeghalayaStateName(this.properties.name);
                        if ($('#LblMeghalayaStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "MH") {
                        funChkRecordExistInMaharashtraStateName(this.properties.name);
                        if ($('#LblMaharashtraStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "MN") {
                        funChkRecordExistInManipurStateName(this.properties.name);
                        if ($('#LblManipurStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "MP") {
                        funChkRecordExistInMadhyaPradeshStateName(this.properties.name);
                        if ($('#LblMadhyaPradeshStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "MZ") {
                        funChkRecordExistInMizoramStateName(this.properties.name);
                        if ($('#LblMizoramStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "NL") {
                        funChkRecordExistInNagalandStateName(this.properties.name);
                        if ($('#LblNagalandStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "OR") {
                        funChkRecordExistInOrissaStateName(this.properties.name);
                        if ($('#LblOrissaStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "PB") {
                        funChkRecordExistInPunjabStateName(this.properties.name);
                        if ($('#LblPunjabStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "PY") {///////////////////////

                        funChkRecordExistInPuducherryStateName(this.properties.name);

                        if ($('#LblPuducherryStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "RJ") {
                        funChkRecordExistInRajasthanStateName(this.properties.name);
                        if ($('#LblRajasthanStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "SK") {
                        funChkRecordExistInSikkimStateName(this.properties.name);
                        if ($('#LblSikkimStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "TN") {/////////////////

                        funChkRecordExistInTamilNaduStateName(this.properties.name);
                        //  alert($('#LblTamilNaduStateName').text());
                        if ($('#LblTamilNaduStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                        else {
                            // alert(this.properties['DataImage']);
                            this.properties['DataImage'] = "" + "<img id='ImgTiger' src='./images/ttt.jpg' width='25px'  />";
                        }
                    }
                    if (this.properties['postal-code'] == "TR") {
                        funChkRecordExistInTripuraStateName(this.properties.name);
                        if ($('#LblTripuraStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "UT") {
                        funChkRecordExistInUttarakhandStateName(this.properties.name);
                        if ($('#LblUttarakhandStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "UP") {
                        funChkRecordExistInStateUp(this.properties.name);
                        if ($('#LblUttarPradeshStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }

                    if (this.properties['postal-code'] == "WB") {
                        funChkRecordExistInWestBengalStateName(this.properties.name);
                        if ($('#LblWestBengalStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }
                    if (this.properties['postal-code'] == "TL") {
                        funChkRecordExistInTelenganaStateName(this.properties.name);
                        if ($('#LblTelenganaStateName').text() == "") {
                            this.properties['DataImage'] = "";
                        }
                    }

                    //Start India map Icon code


                });
                //  var xyz = { 'name': 'xyz' };
                // Instantiate the map
                Highcharts.mapChart('container', {
                    chart: {
                        events: {
                            drilldown: function (e) {

                                try {
                                    if (!e.seriesOptions) {
                                        var chart = this,
                                                mapKey = e.point.drilldown;
                                        // alert(mapKey);
                                        // debugger;
                                        //start show back button
                                      //  $('#BtnBackValues').text('dfdfdf');
                                        //end show back button
                                      //  $('#BtnBackValues').text(mapKey);
                                       // 
                                       
                                        //-------------------
                                      

                                        if (mapKey == "in-ap" && e.point.name == "Telengana") {
                                            mapKey = "in-tl";

                                        } else if (mapKey == "in-ap" && e.point.name != "Telengana") {
                                            mapKey = "in-ap";
                                        }
                                        getTigerReserves(0, mapKey);
                                        // Handle error, the timeout is cleared on success
                                        fail = setTimeout(function () {
                                            if (!Highcharts.maps[mapKey]) {
                                                chart.showLoading('<i class="icon-frown"></i> Failed loading ' + e.point.name);
                                                fail = setTimeout(function () {
                                                    chart.hideLoading();
                                                }, 1000);
                                            }
                                        }, 3000);

                                        // Show the spinner
                                        chart.showLoading('<i class="icon-spinner icon-spin icon-3x"></i>'); // Font Awesome spinner

                                        // Load the drilldown map
                                        $.getScript('<%=ResolveUrl("~/js/data/") %>' + mapKey + '.js', function () {
                                        data = Highcharts.geojson(Highcharts.maps[mapKey]);


                                        $.each(data, function (i) {
                                            this.value = i;
                                            this.DistID = this.properties['ID_2'];


                                            if (typeof this.properties.ID_2 != 'undefined') {
                                                //  $('#tbDetails tbody').remove();
                                                $('#LblTigerReserveShow').html('');
                                                $('#ball_footballbox').html('');

                                                var getStatID = $('#LblstateID').text();
                                                var getMapStatID = $('#LblMapStatID').text();
                                                getTigerReservesByDistricIDOnShow(getStatID, getMapStatID, this.properties.ID_2);


                                                this.Remarks = $('#LblTigerReserveShow').html();
                                                this.DistrictIconImage = $('#ball_footballbox').html();

                                            }
                                        });
                                        // Hide loading and add series
                                        chart.hideLoading();
                                        clearTimeout(fail);
                                        chart.addSeriesAsDrilldown(e.point, {
                                            name: e.point.name,
                                            data: data,
                                            dataLabels: {
                                                enabled: true,
                                                useHTML: true,
                                                format: '<br>{point.Remarks}{point.DistrictIconImage}'
                                            }, tooltip: {
                                                enabled: true,
                                                headerFormat: '',
                                                // pointFormat: '{point.Remarks}'
                                            }
                                        });
                                    });
                                }
                                this.setTitle(null, { text: e.point.name });
                            } catch (err) {
                                alert(err)
                            }
                        },
                        drillup: function () {
                            this.setTitle(null, { text: '' });
                            $(".state-info-con").css("display", "none");
                            this.series.borderColor = '#000000';
                        },
                        load: function () {
                            show_all_state();
                        }
                    }
                },
                legend: {
                    enabled: false
                }, tooltip: {
                    enabled: false,
                },
                lang: {
                    drillUpText: "Back"
                },
                title: {
                    text: '',
                    floating: true,
                    align: 'left',
                    y: 2,
                    style: {
                        fontSize: '16px'
                    }
                },
                subtitle: {
                    text: '',
                    floating: true,
                    align: 'center',
                    y: 5,
                    style: {
                        fontSize: '16px'
                    }
                },
                legend: small ? {} : {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },
                colorAxis: {

                    min: 0,
                    minColor: '#005629',
                    maxColor: '#f7b000'
                },
                mapNavigation: {
                    enabled: false,//zooming code 
                    buttonOptions: {
                        verticalAlign: 'bottom'
                    }

                },
                plotOptions: {
                    map: {
                        states: {
                            hover: {
                                color: '#008000'
                            }
                        }
                    },
                    series: {
                        point: {
                            events: {
                                click: function () {

                                    //click
                                    if (typeof this.properties.ID_2 != 'undefined') {
                                       

                                        $('#tbDetails tbody').remove();
                                        var getStatID = $('#LblstateID').text();
                                        var getMapStatID = $('#LblMapStatID').text();
                                        getTigerReservesByDistricID(getStatID, getMapStatID, this.properties.ID_2);
                                        return DisplayVillage();
                                    }


                                }, mouseOver: function () {
                                    //if (typeof this.properties.ID_2 != 'undefined') {
                                    //    if (preVal != null && preVal != this.properties.ID_2) {
                                    //        lock = true;
                                    //    }
                                    //    if (lock) {
                                    //        preVal = this.properties.ID_2;

                                    //        $('#tbDetails tbody').remove();
                                    //        var getStatID = $('#LblstateID').text();
                                    //        var getMapStatID = $('#LblMapStatID').text();
                                    //        getTigerReservesByDistricID(getStatID, getMapStatID, this.properties.ID_2);
                                    //        return DisplayVillage();

                                    //        lock = false;
                                    //    }

                                    // } // if close;
                                    show_all_state();
                                },
                                mouseOut: function () {
                                    show_all_state();
                                },
                                show: function () {

                                    show_all_state();
                                }
                            }
                        }
                    }
                },
                series: [{
                    data: data,
                    name: 'India',
                    borderColor: '#000000',
                    dataLabels: {
                        enabled: true,
                        useHTML: true,//India map Icon code
                        //format: '{point.properties.postal-code}'
                        format: '{point.name}{point.properties.DataImage}'//India map Icon code
                    }
                }],
                drilldown: {
                    activeDataLabelStyle: {
                        color: '#FFFFFF',
                        textDecoration: 'none',
                        textOutline: '1px #000000'
                    },
                    drillUpButton: {
                        relativeTo: 'spacingBox',
                        position: {
                            x: 0,
                            y: 60
                        }
                    }
                }
            });

                //start First function--GetTigerReserveByStateID
            function getTigerReserves(stateID, vmapStatID) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/GetTigerReserveByStateIDgetTigerReserves",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblstateID').text('');
                        $('#LblMapStatID').text('');

                        //start show back button
                        //if ($('#BtnBackValues').text() == "") {
                        //    alert('fdf');
                        //    $('#BtnBack').hide();
                        //}
                        //else {
                        //    $('#BtnBack').show();
                        //}
                        //end show back button

                        // alert(JSON.stringify(data));
                        for (var i = 0; i < data.d.length; i++) {
                            // $("#tbDetails").append("<tr><td>" + data.d[i].name + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");

                            $('#LblstateID').text(data.d[i].StateID);

                            $('#LblMapStatID').text(data.d[i].mapStatID);


                            // alert();
                            // debugger;
                            // alert(response.d);
                            //  datawb = response.d;
                            //$.each(JSON.parse(response.d), function (idx, obj) {

                            //    //radio = obj.status_id;
                            //    //comment = obj.comment;
                            //    nameSet = obj.name;
                            //    latSet = parseFloat(obj.lat).toFixed(5);
                            //    lonSet = parseFloat(obj.lon).toFixed(5);
                            //    drilldownSets = obj.drilldown;


                            //});
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            //end First function
            //second First function
            function getTigerReservesByDistricID(stateID, vmapStatID, ImapDistricID) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/GetTigerReserveByDistrictID",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",mapDistricid:"' + ImapDistricID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        // debugger;
                        $('#tbDetails11').text('');
                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                            $('#tbDetails11').text('');
                            for (var i = 0; i < data.d.length; i++) {

                                //  $("#tbDetails").append("<tr><td>" + "<a href='DashboardNTCA.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");
                                // $("#tbDetails").append("<tr><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].VillageList + "</td><td><b></b>" + data.d[i].RelocateVillageList + "</td><td><b></b>" + data.d[i].RelocateyetVillageList + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td></tr>");
                                // $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + "<a href='DashboardNTCA.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $("#tbDetails").append("<tr><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                // $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + data.d[i].name + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");
                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {
                           
                            $('#tbDetails11').text('');
                            $("#tbDetails11").append("Please Login from tiger reserve!.");

                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            //end second function
                //Start third function --GetTigerReserveByDistrictID
            function getTigerReservesByDistricIDOnShow(stateID, vmapStatID, ImapDistricID) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/GetTigerReserveByDistrictIDgetTigerReservesByDistricIDOnShow",
                    async: false,
                    data: '{StateID: "' + stateID + '",mapStatID:"' + vmapStatID + '",mapDistricid:"' + ImapDistricID + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        // debugger;

                        // alert(JSON.stringify(data));
                        if (data.d.length > 0) {
                            $('#LblMsg').hide();
                            $('#LblMapDistricID').text('');
                            $('#LblTigerReserveid').text('');
                            $('#LblDataOperatorUserID').text('');
                          
                            for (var i = 0; i < data.d.length; i++) {

                                //  $("#tbDetails").append("<tr><td>" + "<a href='DashboardNTCA.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td>" + data.d[i].drilldown + "</td><td>" + data.d[i].VillageList + "</td><td>" + data.d[i].RelocateVillageList + "</td><td>" + data.d[i].RelocateyetVillageList + "</td></tr>");
                                //  $("#tbDetails").append("<tr><td><b></b>" + data.d[i].SNO + "</td><td><b></b>" + "<a href='index.aspx?StateID=" + data.d[i].StateID + "&MapStatID=" + data.d[i].mapStatID + "&MapDistricID=" + data.d[i].MapDistrictID + "&TigerReserveid=" + data.d[i].TigerReserveid + "&DataOperatorUserID=" + data.d[i].DataOperatorUserID + "'>" + data.d[i].name + "</a>" + "</td><td><b></b>" + data.d[i].drilldown + "</td><td><b></b>" + data.d[i].Village + "</td><td><b></b>" + data.d[i].Family + "</td><td><b></b>" + data.d[i].RelocatedVill + "</td><td><b></b>" + data.d[i].RelocateFam + "</td><td><b></b>" + data.d[i].RemainVill + "</td><td><b></b>" + data.d[i].RemainFam + "</td><td><b></b>" + data.d[i].MoneyPerfam + "</td><td><b></b>" + data.d[i].landAndMoney + "</td><td><b></b>" + data.d[i].VillRelocOtherPack + "</td><td><b></b>" + data.d[i].Remarks + "</td></tr>");

                                $("#LblTigerReserveShow").append(data.d[i].name + "<br>");
                                $("#ball_footballbox").append(data.d[i].DistrictIconImage + "<br>");

                                $('#LblstateID').text(data.d[i].StateID);

                                $('#LblMapStatID').text(data.d[i].mapStatID);
                                // alert(data.d[i].MapDistrictID);
                                $('#LblMapDistricID').text(data.d[i].MapDistrictID);
                                $('#LblTigerReserveid').text(data.d[i].TigerReserveid);
                                $('#LblDataOperatorUserID').text(data.d[i].DataOperatorUserID);
                            }
                        }
                        else {

                           
                            $('#tbDetails tbody').remove();
                            //alert('No record found');
                            $('#LblMsg').show();
                            $('#LblMsg').html('No record found!!');
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            //End third function
            //$(document).on('click', '.close,.modal', function () {
            //    lock = true;
            //});
            // Start India map Icon code
            function funCheckStateRecordExistanceBihar(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateBihar",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblBihar').text('');

                        for (var i = 0; i < data.d.length; i++) {

                            // alert(JSON.stringify(data.d));
                            //alert(JSON.stringify(data.d[i].AndamanNicobarStateName));

                            $('#LblBihar').text(data.d[i].BiharStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateUp(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateUp",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        //$('#LblUttarPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblUttarPradeshStateName').text(data.d[i].UttarPradeshStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateAndamanNicobar(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateAndamanNicobar",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblAndamanNicobarStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblAndamanNicobarStateName').text(data.d[i].AndamanNicobarStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateAndhraPradesh(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateAndhraPradesh",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblAndhraPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {

                            $('#LblAndhraPradeshStateName').text(data.d[i].AndhraPradeshStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateArunachalPradesh(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateArunachalPradesh",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblArunachalPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblArunachalPradeshStateName').text(data.d[i].ArunachalPradeshStateName);

                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateAssam(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateAssam",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblBihar').text('');

                        $('#LblAssamStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblAssamStateName').text(data.d[i].AssamStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateChhattisgarh(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateChhattisgarh",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblChhattisgarhStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblChhattisgarhStateName').text(data.d[i].ChhattisgarhStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateChandigarh(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateChandigarh",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblChandigarhStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblChandigarhStateName').text(data.d[i].ChandigarhStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateDamanDiu(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateDamanDiu",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblDamanDiuStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblDamanDiuStateName').text(data.d[i].DamanDiuStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInStateDelhi(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInStateDelhi",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblDelhiStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblDelhiStateName').text(data.d[i].DelhiStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInDadraHaveliStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInDadraHaveliStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblDadraHaveliStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblDadraHaveliStateName').text(data.d[i].DadraHaveliStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInGoaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInGoaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblGoaStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblGoaStateName').text(data.d[i].GoaStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInGujaratStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInGujaratStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblGujaratStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblGujaratStateName').text(data.d[i].GujaratStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInHimachalPradeshStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInHimachalPradeshStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblHimachalPradeshStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblHimachalPradeshStateName').text(data.d[i].HimachalPradeshStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInHaryanaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInHaryanaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        $('#LblHaryanaStateName').text('');

                        for (var i = 0; i < data.d.length; i++) {


                            $('#LblHaryanaStateName').text(data.d[i].HaryanaStateName);


                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInJammuKashmirStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInJammuKashmirStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblJammuKashmirStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblJammuKashmirStateName').text(data.d[i].JammuKashmirStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInJharkhandStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInJharkhandStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblJharkhandStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblJharkhandStateName').text(data.d[i].JharkhandStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInKeralaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInKeralaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblKeralaStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblKeralaStateName').text(data.d[i].KeralaStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInKarnatakaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInKarnatakaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblKarnatakaStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblKarnatakaStateName').text(data.d[i].KarnatakaStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInLakshadweepStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInLakshadweepStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblLakshadweepStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblLakshadweepStateName').text(data.d[i].LakshadweepStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInMeghalayaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInMeghalayaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblMeghalayaStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblMeghalayaStateName').text(data.d[i].MeghalayaStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInMaharashtraStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInMaharashtraStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblMaharashtraStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblMaharashtraStateName').text(data.d[i].MaharashtraStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInManipurStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInManipurStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblManipurStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblManipurStateName').text(data.d[i].ManipurStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInMadhyaPradeshStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInMadhyaPradeshStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblMadhyaPradeshStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblMadhyaPradeshStateName').text(data.d[i].MadhyaPradeshStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInMizoramStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInMizoramStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblMizoramStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblMizoramStateName').text(data.d[i].MizoramStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInNagalandStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInNagalandStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblNagalandStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblNagalandStateName').text(data.d[i].NagalandStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
			function funChkRecordExistInOrissaStateName(ParmStateName) {
				$.ajax({
					type: "POST",
					url: "DashboardNTCA.aspx/ChkRecordExistInOrissaStateName",
					async: false,
					data: '{StateName: "' + ParmStateName + '"}',
					contentType: "application/json; charset=utf-8",
					dataType: "json",
					success: function (data) {
						$('#LblOrissaStateName').text('');
						for (var i = 0; i < data.d.length; i++) {
							$('#LblOrissaStateName').text(data.d[i].OrissaStateName);
						}
					},
					failure: function (request, error) {
						alert(" Can't do because: " + error);
					}
				});
			}
            function funChkRecordExistInPunjabStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInPunjabStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblPunjabStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblPunjabStateName').text(data.d[i].PunjabStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInPuducherryStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInPuducherryStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblPuducherryStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblPuducherryStateName').text(data.d[i].PuducherryStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInRajasthanStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInRajasthanStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblRajasthanStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblRajasthanStateName').text(data.d[i].RajasthanStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInSikkimStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInSikkimStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblSikkimStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblSikkimStateName').text(data.d[i].SikkimStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInTamilNaduStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInTamilNaduStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblTamilNaduStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblTamilNaduStateName').text(data.d[i].TamilNaduStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInTripuraStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInTripuraStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblTripuraStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblTripuraStateName').text(data.d[i].TripuraStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInUttarakhandStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInUttarakhandStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblUttarakhandStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblUttarakhandStateName').text(data.d[i].UttarakhandStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInWestBengalStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInWestBengalStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblWestBengalStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblWestBengalStateName').text(data.d[i].WestBengalStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            function funChkRecordExistInTelenganaStateName(ParmStateName) {
                $.ajax({
                    type: "POST",
                    url: "DashboardNTCA.aspx/ChkRecordExistInTelenganaStateName",
                    async: false,
                    data: '{StateName: "' + ParmStateName + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        $('#LblTelenganaStateName').text('');
                        for (var i = 0; i < data.d.length; i++) {
                            $('#LblTelenganaStateName').text(data.d[i].TelenganaStateName);
                        }
                    },
                    failure: function (request, error) {
                        alert(" Can't do because: " + error);
                    }
                });
            }
            //End India map Icon code
		</script>
    </div>
  </div>
</asp:Content>
