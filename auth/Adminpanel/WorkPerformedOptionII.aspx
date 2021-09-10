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
								<span class="box-title stp1" style="">Step-2</span>
								<span class="box-title stp" style="color: #005529; float:right;">Total Steps - 4</span>
							</div>
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Work performed under option (II)</h3>
                            </div>

                        </div>
                        <div class="form-horizontal">
                            <div class="col-md-8">
                                <div class="form-group">
                                   
                                    <label class="col-md-4 control-label">
                                            S.no:
                                     </label>
                                    <div class="col-md-6">
                                        <input name="" type="text" maxlength="100" id="" class="form-control"  style="width:250px;">
                                    </div>
                                </div>
                            </div>
                           

                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label"  >
                                        Executive/State Authority Name <span class="red-text">*</span>:
                                    </label>
                                    <div class="col-sm-6">
										<input name="" type="text" maxlength="100" id="" class="form-control"  style="width:250px;">
                                    </div>
                                </div>
                            </div> 
							
							<div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label"  >
                                        Amount spent <span class="red-text">*</span>:
                                    </label>
                                    <div class="col-sm-6">
										<input name="" type="text" maxlength="100" id="" class="form-control"  style="width:250px;">
                                    </div>
                                </div>
                            </div>
							<div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label"  >
                                        Remaining balance <span class="red-text">*</span>:
                                    </label>
                                    <div class="col-sm-6">
										<input name="" type="text" maxlength="100" id="" class="form-control"  style="width:250px;">
                                    </div>
                                </div>
                            </div>
							<div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label"  >
                                        Task done <span class="red-text">*</span>:
                                    </label>
                                    <div class="col-sm-6">
										<input name="" type="text" maxlength="100" id="" class="form-control"  style="width:250px;">
                                    </div>
                                </div>
                            </div>
							<div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label"  >
                                        
                                    </label>
                                    <div class="col-sm-6">
										<a href="" class="btn btn-primary">Save</a>			
								<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/ConversionScheme/AddConversionScheme.aspx" class="btn btn-primary">Next</a>
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

