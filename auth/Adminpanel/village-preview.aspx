<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="village-preview.aspx.cs" Inherits="auth_Adminpanel_village_preview" %>

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
.mt20{margin-top:20px;}
.table > thead > tr > th {
    border-bottom: 0 solid #ddd;
	vertical-align:middle !important;
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
                                <h3 class="box-title" style="color: #005529;">Village Preview </h3>
                            </div>

                        </div>
                        <div class="form-horizontal">
							<div class="col-md-12" style="overflow-x:auto;">
								<table class="table table-bordered table-stripped">
									<thead>
										<tr>
											<th>S.No</th>
											<th>Tiger Reserve name</th>
											<th>Village Name</th>
											<th>Population</th>
											<th>Total Land Area(Ha)</th>
											<th>Total Agriculture Land Area(Ha)</th>
											<th>Total Non Agriculture Land Area(Ha)</th>
											<th>Other Land Area(Ha)</th>
											<th>Value of Agriculture land</th>
											<th>Value Residential Land</th>
											<th>Total Cow</th>
											<th>Total Buffalo</th>
											<th>Total Sheep</th>
											<th>Total Goat</th>
											<th>Other Animal</th>
											<th>Relocated Families</th>
											<th>Non- Relocated Families</th>
											<th>Status</th>
											<th>NGO</th>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td>1</td>
											<td>Valmiki Tiger Reserve</td>
											<td><a href="http://45.115.99.199/NTCA_MIS/AUTH/adminpanel/REPORT/FamilyDetail2.aspx?V_ID=10037" target="_blank">Patna</a></td>
											<td>4</td>
											<td>3.00</td>
											<td>1.00</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>0</td>
											<td>0</td>
											<td>Relocated</td>
											<td>0</td>
										</tr>
										<tr>
											<td>2</td>
											<td>Valmiki Tiger Reserve</td>
											<td><a href="">Patna</a></td>
											<td>4</td>
											<td>3.00</td>
											<td>1.00</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>0</td>
											<td>0</td>
											<td>Relocated</td>
											<td>0</td>
										</tr>
										<tr>
											<td>3</td>
											<td>Valmiki Tiger Reserve</td>
											<td><a href="">Patna</a></td>
											<td>4</td>
											<td>3.00</td>
											<td>1.00</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>1</td>
											<td>0</td>
											<td>0</td>
											<td>Relocated</td>
											<td>0</td>
										</tr>
									</tbody>
								</table>
								
							</div>
							
						
                            
                           
							<div class="col-md-8 mt20">
                                <div class="form-group">
                                    <div class="col-sm-6">
										<a href="" class="btn btn-primary">Edit</a>			
										<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/form-preview.aspx" class="btn btn-primary">Back</a>
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

