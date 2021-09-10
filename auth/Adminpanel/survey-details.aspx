<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="funds-required.aspx.cs" Inherits="auth_Adminpanel_funds_required" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" Runat="Server">
<style type="text/css">
        

        .table-2 td {
            border-top: none !important;
        }

        .control-label {
            text-align: left !important;
        }
		.red-text{color:red;}
		.form-group {
    margin-bottom: 0;
}
a {
    color: #337ab7;
    text-decoration: none;
}
.stp{
			color: #000000;
			text-align: left;
			font-weight: bold;
			background: #f7b000;
			padding: 5px;
			}
			.stp1{
			color: #fff;
			text-align: left;
			font-weight: bold;
			background: #005529;
			padding: 5px;
			}
		.stpdiv{
			padding:0 0 30px 0;
		}
    </style>
 <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
       <%-- ***************nw****** --%>
        <div class="wrapper-content" style="padding-top: 0px; padding-bottom:0; min-height:550px; ">
            <div class="row">
                <div class="col-lg-12">
                    <div class="widgets-container">

                        <div class="box box-primary1" style="margin-bottom: 25px;">
							<div class="stpdiv">
								<span class="box-title stp1" style="">Step-1</span>
								<span class="box-title stp" style="color: #005529; float:right;">Total Steps - 4</span>
							</div>
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Survey Details</h3>
                            </div>

                        </div>
                        <div class="form-horizontal">
                            <div class="col-md-10">
                                <div class="form-group">                                   
                                    <label class="col-md-2 control-label">
                                            Village Name :
                                     </label>
                                    <div class="col-md-3">
                                        <input name="" type="text" maxlength="100" id="" class="form-control"  >
                                    </div>
									<div class="col-sm-3">
													
										<a href="" class="btn btn-primary">Search</a>
                                    </div>
                                </div>
                            </div>
                           

                            
							<div class="col-md-2">
                                <div class="">
                                   <a class="btn btn-primary pull-right" href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/SurveyForm.aspx">Add Post Survey Form</a>
                                    
                                </div>
                            </div>
							
							<div class="col-md-12">
								
								
							</div>
							<div class="col-md-12 mt30">
								<table class="table table-bordered table-stripped">
									<thead>
										<tr>
											<th>S.No</th>
											<th>Scheme Name</th>
											<th>Village</th>
											<th>Amount Spent(In Rs)</th>
											<th>NGO</th>
											<th>Amount Used (In Rs)</th>
											<th>Relocation Status</th>
											<th>Relocation Map</th>
											<th>Status</th>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td>1</td>
											<td><a href="" target="_blank">(Name &amp; Details)</a></td>
											<td><a href="" target="_blank">Basana</a></td>
											<td>1,50,000</td>
											<td><a href="" target="_blank">6</a></td>
											<td>2,50,000</td>
											<td>Yes</td>
											<td><a href="" class="btn btn-primary btn-xs">view</a></td>
											<td><a href="" class="btn btn-primary btn-xs">Submitted</a></td>
										</tr>
										<tr>
											<td>1</td>
											<td><a href="" target="_blank">(Name &amp; Details)</a></td>
											<td><a href="" target="_blank">Bhandar</a></td>
											<td>1,50,000</td>
											<td><a href="" target="_blank"></a></td>
											<td></td>
											<td></td>
											<td></td>
											<td><a href="" class="btn btn-danger btn-xs">Pending</a></td>
										</tr>
									</tbody>
								</table>
								
							</div>


                             





                            
                            
							
							

                        </div>
                    </div>
                </div>
            </div>
        </div>
       
         <%-- *******************end nw --%> 
               


               

             
                           
    </div>
</asp:Content>

