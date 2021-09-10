<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="NGOPreview.aspx.cs" Inherits="auth_Adminpanel_NGOPreview" %>

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
                                <h3 class="box-title" style="color: #005529;">NGO Preview </h3>
                            </div>

                        </div>
                        <div class="form-horizontal">
							<div class="col-md-12" style="overflow-x:auto;">
								<table class="table table-bordered table-stripped">
									<thead>
										<tr>
											<th>S.No</th>
											<th>NGO name</th>
											<th>Details</th>
											
											
										</tr>
									</thead>
									<tbody>
										<tr>
											<td>1</td>
											<td>Wild Life Trust of India,New Delhi</td>
											<td><a href="http://45.115.99.199/NTCA_MIS/AUTH/adminpanel/REPORT/NgoListDetails.aspx?F_ID=1&s_ID=1&Resv=Valmiki%20Tiger%20Reserve&villid=10035&ConsoldateStateName=5&ConsoldateMode=Creport&ReserveID=You%20have%20not%20selected.&VillageID=You%20have%20not%20selected.&StateID=5&VillageName=You%20have%20not%20selected.&ReserveName=You%20have%20not%20selected.&NgoName=Wild%20Life%20Trust%20of%20India" target="_blank" class="btn btn-primary btn-xs">view</a></td>
											
										</tr>
										<tr>
											<td>2</td>
											<td>Wild Life Trust of India,New Delhi</td>
											<td><a href="http://45.115.99.199/NTCA_MIS/AUTH/adminpanel/REPORT/NgoListDetails.aspx?F_ID=1&s_ID=1&Resv=Valmiki%20Tiger%20Reserve&villid=10035&ConsoldateStateName=5&ConsoldateMode=Creport&ReserveID=You%20have%20not%20selected.&VillageID=You%20have%20not%20selected.&StateID=5&VillageName=You%20have%20not%20selected.&ReserveName=You%20have%20not%20selected.&NgoName=Wild%20Life%20Trust%20of%20India" target="_blank" class="btn btn-primary btn-xs">view</a></td>
											
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

