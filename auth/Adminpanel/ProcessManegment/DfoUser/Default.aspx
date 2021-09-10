<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="auth_Adminpanel_ProcessManegment_DfoUser_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../style.css" rel="stylesheet" />
    <script src="../multi_step_form.js"></script>
	<style>
		th{
		vertical-align:middle;
		}
		.mt20{
			margin-top:20px;
		}
		.ml10{margin-left:10px !important;}
		.frmheading{color: #ffffff;
    padding: 5px 12px;
    background: #005529;margin-left:10px;}
		.frmsubheading{color: #474545;
    background: #f7b000;
    padding: 2px 6px;}
		.red-text{color:red;}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
<div class="container-fluid" style="margin-top: 10px; margin-bottom: 62px; padding: 10px; background:#fff;"> 
    <div class="wrapper-content" style="padding-top:0px; min-height:550px;">
	<div class="row">
	<div class="col-md-12">
    <!-- multistep form -->
    <div class="col-md-12 main">
       
            <!-- progressbar -->
            <ul id="progressbar">
                <li class="active">Create Account</li>
                <li>Educational Profiles</li>
                <li>Personal Details</li>
            </ul>

            <!-- fieldsets -->
            <fieldset id="first">
                <h2 class="title">Create your account</h2>
                <p class="subtitle">Step 1</p>
				<div class="col-md-12 mt20" >
					<div class="row">
						<div class="col-md-10">
                           <label class="col-sm-4 control-label" style="padding-left:0;">  Select Village Name:
						   </label>
                           <div class="form-group col-md-5">
                                  <select name="" id="" class="form-control">
                                                    <option value="0">Select</option>
													<option value="1">2</option>
													<option value="2">3</option>
								  </select>
                           </div>
						</div>
						<div class="col-md-12">
							<span >Please fill the following mandatory form to proceed further.</span><br/>
							<span><strong>Compliance of the Wildlife (Protection) Act, 1972 and the Scheduled Tribes & Other Traditional Forest Dwellers (Recognition of Forest Rights) Act, 2006.</strong></span>
						</div>
						
						<div class="">
							<div class="col-md-12 mt20">
								<div class="row">
									<span class="frmheading"><strong>Core or Critical Tiger Habitat (CTH)</strong></span>
								</div>
								<div class="row">
									<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Notified<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select>
									   </div>
									 </div>
									 
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Date of Notification<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="date">
									   </div>
									 </div>
									  <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Area(Ha.)<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="text">
									   </div>
									 </div>
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Compliance of section 38V of the Wildlife	(Protection) Act, 1972<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="text">
									   </div>
									 </div>
								 </div>
								 
								 
								 
								 <div class="row mt20">
									<span class="frmheading"><strong>Buffer or Peripheral Area</strong></span>
								</div>
								<div class="row">
									<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Notified<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select>
									   </div>
									 </div>
									 
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Date of Notification<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="date">
									   </div>
									 </div>
									  <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Area(Ha.)<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="text">
									   </div>
									 </div>
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label"> 	Expert Committee (Constituted)<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select>
									   </div>
									 </div>
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Date of Notification<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="date">
									   </div>
									 </div>
									  <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Consultation With Gram Sabha<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select>
									   </div>
									 </div>
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Name of Gram Sabha<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="text">
									   </div>
									 </div>
									 
									 
						      </div>
							  <!--END OF ROW-->
							  <div class="row">
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label"><strong>Map of CTH & Buffer or Peripheral Area.(jpg or .pdf files only)</strong>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="file">
									   </div>
									 </div>
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label"><strong>Upload file:</strong>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="file">
									   </div>
									 </div>
									 <div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label"><strong>Upload file:</strong>
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="file">
									   </div>
									 </div>
							  </div>
							 <!--END OF ROW-->
							  <div class="row mt20">
									<span class="frmheading"><strong>Recognition / Determination/ Acquisition / Vesting of Forest Rights of Schedule Tribes & such other Traditional Forest Dwellers</strong></span>
							  </div>
						     <!--END OF ROW-->
							 <div class="row">
								<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Completed <span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											 <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select> <br/>
											  <input name="" id="" class=" form-control" type="file">
									   </div>
									 </div>
							 </div>
							 <!--END OF ROW-->
							 <div class="row mt20">
									<span class="frmheading"><strong>Re-settlement or Alternative Package</strong></span>
							  </div>
						     <!--END OF ROW-->
							 <div class="row">
								<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Provided <span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											 <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select> 
									   </div>
									 </div>
							 </div>
							 <!--END OF ROW-->
							 <div class="row mt20">
									<span class="frmheading"><strong>Free informed consent of Gram Sabha to the Resettlement Programme</strong></span>
							  </div>
						     <!--END OF ROW-->
							 <div class="row">
								<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Obtained <span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											 <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select> 
									   </div>
									 </div>
							 </div>
							 <!--END OF ROW-->
							  <div class="row mt20">
									<span class="frmheading"><strong>Voluntary consent of individuals affected</strong></span>
							  </div>
						     <!--END OF ROW-->
							 <div class="row">
								<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Obtained <span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											 <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select> <br/>
											  <input name="" id="" class=" form-control" type="file">
									   </div>
									 </div>
							 </div>
							 <!--END OF ROW-->
							 
							 
							  <div class="row mt20">
									<span class="frmheading"><strong>Facilities & Land Allocation At The Resettlement Location</strong></span>
							  </div>
						     <!--END OF ROW-->
							 <div class="row">
								<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label"> 	Provided <span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											 <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select> <br/>
											  <input name="" id="" class=" form-control" type="file">
									   </div>
									 </div>
							 </div>
							 <!--END OF ROW-->
							 <div class="row mt20">
									<span class="frmheading"><strong>Sub- divisional, District and State – level committees for monitoring of village relocation process & grievance redressal</strong></span>
							  </div>
						     <!--END OF ROW-->
							 <div class="row">
								<div class="col-md-12 mt20">
									<span class="frmsubheading"><strong>Sub Divisional Level Committee</strong></span>
								</div>
								<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label"> Constituted<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											 <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select> <br/>
											  <input name="" id="" class=" form-control" type="file">
									   </div>
									 </div>
									<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Date of constitution
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="date">
									   </div>
									 </div>	
									 
									 <div class="col-md-12 mt20">
									<span class="frmsubheading"><strong>State Level Monitoring Committee</strong></span>
								</div>
								<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label"> Constituted<span class="red-text">*</span>
									   </label>
									   <div class="form-group col-md-5">
											 <select name="" id="" class="form-control">
																<option value="0">Select</option>
																<option value="1">Yes</option>
																<option value="2">No</option>
											  </select> <br/>
											  <input name="" id="" class=" form-control" type="file">
									   </div>
									 </div>
									<div class="col-md-10 mt20">								
									   <label class="col-sm-4 control-label">Date of constitution
									   </label>
									   <div class="form-group col-md-5">
											  <input name="" id="" class=" form-control" type="date">
									   </div>
									 </div>	
									 
									 
							 </div>
							 <!--END OF ROW-->
							  
							  
							  
							</div>
						</div>
						
					</div>
				</div>
                <input type="button" name="next" class="next_btn btn-primary ml10" value="Next" />
            </fieldset>
            <fieldset>
                <h2 class="title">Educational Profiles</h2>
                <p class="subtitle">Step 2</p>
                <div class="col-md-12 mt20">
					<table class="table table-bordered table-striped">
						<thead>
							<tr>
								<th>S.No.</th>
								<th>Check Items</th>
								<th>Result Deduced- Yes/No</th>
							</tr>
						</thead>
						<tbody>
							<tr>
							<td>1</td>
							<td>Whtether core/critical tiger habitat has been notified by the State as per Section 38V of the Wildlife Act? (If so, please enclose a copy of the notification)</td>
							<td></td>
							</tr>
							
							<tr>
								<td>2</td>
								<td>Whether consent of villages obtained?</td>
								<td></td>
							</tr>
							
							<tr>
								<td>3</td>
								<td>Whether process of recognition and determination of rights and acquisition of land or forests rights of the ST and other forests dwelling person is complete? The lists are to be certified by Collectors.</td>
								<td></td>
							</tr>
							
							<tr>
								<td>4</td>
								<td>Whether provisions of the ST & OFD (Recognition of Forests Rights) Act have been compiled with?</td>
								<td></td>
							</tr>
							
							<tr>
								<td>5</td>
								<td>Whether District Level & State Level Monitoring Committees have been constituted?</td>
								<td></td>
							</tr>
							
							<tr>
								<td>6</td>
								<td>What is the cut of date as decided by the Competent Authority?</td>
								<td></td>
							</tr>
							
							
							<tr>
								<td>7</td>
								<td>Whether clearance under the Forest (Conservation) Act obtained in case of resettlement to forest land?</td>
								<td></td>
							</tr>
						</tbody>
					</table>
				</div>
                <input type="button" name="previous" class="pre_btn btn-primary ml10" value="Previous" />
                <input type="button" name="next" class="next_btn btn-primary" value="Next" />
            </fieldset>
            <fieldset>
                <h2 class="title">Edit Process Management</h2>
                <p class="subtitle">Step 3</p>
				<div class="col-md-12 mt20" style="padding-left:0;">
					<div class="row">
					
					<div class="col-md-10">
                           <label class="col-sm-4 control-label">
                            <asp:Label id="Lblmsg" runat="server"></asp:Label>
                           </label>
					</div>	   
                    <div class="col-md-10">
                           <label class="col-sm-4 control-label">Token/Ticket Id(Generate automatic):
						   </label>
                           <div class="form-group col-md-5">
                              <span id="" style="color:Green;font-weight:bold;">gffgfgggggggggggggggggggggggg</span>
                           </div>
                    </div>
					<div class="col-md-10">
                           <label class="col-sm-4 control-label">  Select Village Name:
						   </label>
                           <div class="form-group col-md-5">
                                  <select name="" id="" class="form-control">
                                                    <option value="0">Select</option>
													<option value="1">2</option>
													<option value="2">3</option>
								  </select>
                           </div>
                    </div>
					<div class="col-md-10">
                            <label class="col-sm-4 control-label">Amount:
							</label>
                            <div class="form-group col-md-5">
                                <input type="text" class="form-control" name="" placeholder="" />        
                           </div>
                    </div>
					<div class="col-md-10">
                            <label class="col-sm-4 control-label">
                                        Description:</label>
                            <div class="form-group col-md-5">
                                        <textarea name="" placeholder="" class="form-control"></textarea>
                                        
                            </div>
                    </div>
                  </div>
				
					
				</div>
                <input type="button" class="pre_btn btn-primary ml10" value="Previous" />
                <input type="submit" class="submit_btn btn-primary" value="Submit" />
            </fieldset>
   
    </div>
	<!-- multistep form----end -->
 </div>
 </div>
 
 </div>
 </div>
</asp:Content>

