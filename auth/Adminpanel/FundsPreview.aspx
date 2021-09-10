<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="FundsPreview.aspx.cs" Inherits="auth_Adminpanel_FundsPreview" %>

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
    </style>
 <div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background: #fff;">
       <%-- ***************nw****** --%>
        <div class="wrapper-content" style="padding-top: 0px; padding-bottom:0; min-height:550px; ">
            <div class="row">
                <div class="col-lg-12">
                    <div class="widgets-container">

                        <div class="box box-primary1" style="margin-bottom: 25px;">
                            <div class="box-header with-border">
                                <h3 class="box-title" style="color: #005529;">Funds Preview </h3>
                            </div>

                        </div>
                        <div class="form-horizontal">
                            <div class="col-md-8">
                                <div class="form-group">
                                   
                                    <label class="col-md-4 control-label">
                                            Select Village Name <span class="red-text">*</span>:
                                     </label>
                                    <div class="col-md-6">
                                        <select name="ctl00$contentbody$ddlselectname" id="contentbody_ddlselectname" class="form-control" style="width:250px;" disabled="disabled">
												<option value="0">--Select--</option>
												<option value="20049">VILLAGE NAME: PATNA  [VILLAG CODE: V6K9Y0N9I5 ]</option>
												<option value="10040">VILLAGE NAME: PAUNA  [VILLAG CODE: V5N7Q7S2T9 ]</option>
												<option value="10036">VILLAGE NAME: PIRO  [VILLAG CODE: V6H3V7T1B2 ]</option>
												<option value="10037">VILLAGE NAME: RAMPUR VILLAGE  [VILLAG CODE: V6H3V7T1B3 ]</option>
												<option value="10044">VILLAGE NAME: RANNI  [VILLAG CODE: V3B4Q1J0N3 ]</option>
												<option value="10047">VILLAGE NAME: RATNARH  [VILLAG CODE: V0M1G2P3A5 ]</option>
												<option value="10049">VILLAGE NAME: RUDARPUR  [VILLAG CODE: V2X7I5T8F2 ]</option>
												<option value="10038">VILLAGE NAME: SASARAM VILLAGE  [VILLAG CODE: V6H3V7T1B6 ]</option>
												<option value="20050">VILLAGE NAME: SEOTHARA  [VILLAG CODE: V0O49M9D0U ]</option>
												<option value="20051">VILLAGE NAME: SEWANTHA  [VILLAG CODE: V9H5X9B4P4 ]</option>
												<option value="10045">VILLAGE NAME: SONVARSA  [VILLAG CODE: V8N8Q6Q4Y6 ]</option>

											</select>
                                            
                                   </div>
                                </div>
                            </div>
                           

                            <div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label"  >
                                        Amount <span class="red-text">*</span>:
                                    </label>
                                    <div class="col-sm-6">
										<input name="" type="text" maxlength="100" id="" disabled="disabled" value="2323" class="form-control"  style="width:250px;">
                                    </div>
                                </div>
                            </div> 
							
							<div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label"  >
                                        Description <span class="red-text">*</span>:
                                    </label>
                                    <div class="col-sm-6">
										<textarea name="" rows="2" cols="20" id="" vlaue="egwhe dsfsdf" disabled="disabled" class="form-control" style="width:250px;"></textarea>
                                    </div>
                                </div>
                            </div>
							<!--<div class="col-md-8">
                                <div class="form-group">
                                    <label class="col-sm-4 control-label"  >
                                        
                                    </label>
                                    <div class="col-sm-6">
										<a href="" class="btn btn-primary">Save</a>			
								<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/form-preview.aspx" class="btn btn-primary">Next</a>
                                    </div>
                                </div>
                            </div>-->
							<div class="col-md-12">
							<hr/>					
								</div>
							<div class="col-md-12 mt20">
                                <div class="form-group">
                                    <div class="col-sm-6">
										<a href="" class="btn btn-primary">Edit</a>			
										<a href="http://45.115.99.199/NTCA_MIS/auth/adminpanel/form-preview.aspx" class="btn btn-primary">Back</a>
                                    </div>
                                </div>
                            </div>


                             





                            
                            
							
							

                        </div>
                    </div>
                </div>
            </div>
        </div>
       
         <%-- *******************end nw --%> 
               


               

             
                           
    </div>
</asp:Content>

