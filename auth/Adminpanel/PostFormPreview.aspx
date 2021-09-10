<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="PostFormPreview.aspx.cs" Inherits="auth_Adminpanel_PostFormPreview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
   
}
.hts{background:#005529; color:#fff;}
    </style>
 <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
       <%-- ***************nw****** --%>
        <div class="wrapper-content" style="padding-top: 0px; padding-bottom:0; min-height:550px; ">
            <div class="row">
                <div class="col-lg-12">
                    <div class="widgets-container">

                        <div class="box box-primary1" style="margin-bottom: 25px;">
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Form Preview </h3>
                            </div>

                        </div>
                        <div class="form-horizontal">
							<div class="col-md-12">
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
										</tr>
									</thead>
									<tbody>
										<tr>
											<td>1</td>
											<td><a href="">(Name & Details)</a></td>
											<td><a href="">5</a></td>
											<td>1,50,000</td>
											<td><a href="" >6</a></td>
											<td>2,50,000</td>
											<td>Yes</td>
											<td><a href="" >Map Link</a></td>
										</tr>
									</tbody>
								</table>
								
							</div>
						
                            <div class="col-md-8">
                                <div class="form-group">
                                    <div class="col-md-6">
                                   </div>
                                </div>
                            </div>
                           

                            
							<div class="col-md-8">
                                <div class="form-group">
                                    <div class="col-sm-6">
										<!--<a href="" class="btn btn-primary">Edit</a>-->
										<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/VILLAGE/Village_Management.aspx" class="btn btn-primary">Final Submit</a>
                                    </div>
                                </div>
                            </div>
							
							<div class="col-md-12">
								
								
							</div>


                             





                            
                            
							
							

                        </div>
                    </div>
                </div>
            </div>
        </div>
       
         <%-- *******************end nw --%> 
               


               

             
                           
    </div>
</asp:Content>

