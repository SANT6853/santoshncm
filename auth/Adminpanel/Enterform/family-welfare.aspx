<%@ Page Title="" Language="C#" MasterPageFile="~/auth/Adminpanel/Adminmaster.master" AutoEventWireup="true" CodeFile="family-welfare.aspx.cs" Inherits="auth_Adminpanel_Enterform_family_welfare" %>
<%@ Register src="../../../UserControl/HeadingControl.ascx" tagname="HeadingControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentbody" runat="Server">
    <div class="col-lg-12 top20">
        <div class="tabs-container">
            <div class="bg_white">
                
                <uc1:HeadingControl ID="heading1" runat="server" Heading="Family Welfare" />
                

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Select Tiger Reserves</label>
                            <select class="form-control" id="exampleFormControlSelect1">
                                <option>Select Tiger Reserves</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="exampleFormControlSelect1">Select Village Name</label>
                            <select class="form-control" id="exampleFormControlSelect1">
                                <option>Select Village Name</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="villageName">Family Head Name</label>
                            <input type="text" class="form-control" id="villageName" placeholder="Enter Family Head Name">
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="villageName">No. of family members </label>
                            <div class="row">
                                <div class="col-md-6">
                                    <input type="number" class="form-control" id="villageName" placeholder="Male">
                                </div>
                                <div class="col-md-6">
                                    <input type="number" class="form-control" id="villageName" placeholder="Female">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="villageName">Agriculture Land (Ha)</label>
                            <input type="text" class="form-control" id="villageName" placeholder="Enter Agriculture Land (Ha)">
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="villageName">Residential property (Ha)</label>
                            <input type="text" class="form-control" id="villageName" placeholder="Residential property (Ha)">
                        </div>
                    </div>
                    <div class="col-md-4 min-height100">
                        <div class="form-group">
                            <label for="villageName">Total Livestock</label>
                            <input type="text" class="form-control" id="villageName" placeholder="Enter Total Livestock">
                        </div>
                    </div>

                    <div class="col-md-4 min-height100">
                        <div class="form-group">
                            <label for="villageName">Total Sheep & Goat</label>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-6">
                                    <input type="text" class="form-control" id="villageName" placeholder="Enter Total Livestock">
                                </div>
                                <div class="col-md-6">
                                    <input type="text" class="form-control" id="villageName" placeholder="Enter Total Livestock">
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="exampleFormControlTextarea1">Other Assets</label>
                            <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                        </div>
                    </div>

                    <!-- <div class="col-md-4">
	<div class="form-group">
	<label for="villageName">Total Cows & Buffalo</label>
	<div class="clearfix"></div>
	<div class="row">
	<div class="col-md-6">
	<input type="text" class="form-control" id="villageName" placeholder="Enter Total Cows">
	</div>
	<div class="col-md-6">
	<input type="text" class="form-control" id="villageName" placeholder="Enter Total Buffalo">
	</div>
	</div>
	</div>
  </div> -->
                    <div class="col-md-4">
                        <div class="form-group multiple-form-group" data-max="3">
                            <label>Other Animels</label>

                            <div class="form-group input-group">
                                <div class="row">
                                    <div class="col-md-7">
                                        <select class="form-control" id="exampleFormControlSelect1">
                                            <option>Cows</option>
                                            <option>Buffalo</option>
                                            <option>3</option>
                                            <option>4</option>
                                            <option>5</option>
                                        </select>
                                    </div>
                                    <div class="col-md-7">
                                        <input type="text" class="form-control" id="villageName" placeholder="Enter Total Buffalo">
                                    </div>
                                </div>
                                <span class="input-group-btn">
                                    <button type="button" class="btn btn-primary btn-add">
                                        Add More
                                    </button>
                                </span>
                            </div>
                        </div>
                    </div>

                    <!-- <div class="col-md-4">
	<div class="form-group multiple-form-group">
				<label>Other Animels</label>

				<div class="form-group input-group">
					<input type="text" name="multiple[]" class="form-control">
						<span class="input-group-btn"><button type="button" class="btn btn-default btn-add">+
						</button></span>
				</div>
			</div>
  </div> -->

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="exampleInputFile">Upload Sanction letter</label>
                            <input type="file" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp">
                        </div>
                    </div>

                    <div class="clearfix"></div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="villageName">GPS coordinates of relocated from</label>
                            <input type="text" class="form-control" id="villageName" placeholder="Enter Total Livestock">
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="villageName">GPS coordinates of relocated place</label>
                            <input type="text" class="form-control" id="villageName" placeholder="Enter Total Livestock">
                        </div>
                    </div>
                    <div class="col-md-12 text-center">
                        <button type="submit" name="" class="btn btn-success">Submit</button>
                    </div>

                    <!-- <div class="col-md-4">
  <div class="form-group">
    <label for="exampleFormControlSelect2">Example multiple select</label>
    <select multiple class="form-control" id="exampleFormControlSelect2">
      <option>1</option>
      <option>2</option>
      <option>3</option>
      <option>4</option>
      <option>5</option>
    </select>
  </div>
  </div> -->




                </form>
            </div>
        </div>
    </div>
    <!-- Go top --> 
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) --> 
<script src="../assets/js/vendor/jquery.min.js"></script> 
<!-- bootstrap js --> 
<script src="../assets/js/vendor/bootstrap.min.js"></script> 
<!--  morris Charts  -->
<!-- js for print and download -->
<script type="text/javascript" src="../assets/js/vendor/vfs_fonts.js"></script>
<script src="../assets/js/vendor/chartJs/Chart.bundle.js"></script> 
<script src="../assets/js/dashboard1.js"></script> 
<!-- slimscroll js --> 
<script type="text/javascript" src="../assets/js/vendor/jquery.slimscroll.js"></script> 
<!-- main js --> 
<script src="../assets/js/main.js"></script> 
<script type="text/javascript">
(function ($) {
    $(function () {

        var addFormGroup = function (event) {
            event.preventDefault();

            var $formGroup = $(this).closest('.form-group');
            var $multipleFormGroup = $formGroup.closest('.multiple-form-group');
            var $formGroupClone = $formGroup.clone();

            $(this)
                .toggleClass('btn-default btn-add btn-danger btn-remove')
                .html('Remove');

            $formGroupClone.find('input').val('');
            $formGroupClone.insertAfter($formGroup);

            var $lastFormGroupLast = $multipleFormGroup.find('.form-group:last');
            if ($multipleFormGroup.data('max') <= countFormGroup($multipleFormGroup)) {
                $lastFormGroupLast.find('.btn-add').attr('disabled', false);
            }
        };

        var removeFormGroup = function (event) {
            event.preventDefault();

            var $formGroup = $(this).closest('.form-group');
            var $multipleFormGroup = $formGroup.closest('.multiple-form-group');

            var $lastFormGroupLast = $multipleFormGroup.find('.form-group:last');
            if ($multipleFormGroup.data('max') >= countFormGroup($multipleFormGroup)) {
                $lastFormGroupLast.find('.btn-add').attr('disabled', false);
            }

            $formGroup.remove();
        };

        var countFormGroup = function ($form) {
            return $form.find('.form-group').length;
        };

        $(document).on('click', '.btn-add', addFormGroup);
        $(document).on('click', '.btn-remove', removeFormGroup);

    });
})(jQuery);
</script>
</asp:Content>

