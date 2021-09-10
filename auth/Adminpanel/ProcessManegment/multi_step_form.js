$(document).ready(function ()
{
var chk = 1;
    /*---------------------------------------------------------*/
   

$(".next_btn").click(function ()
    {
        var checkid=$(this).parent().attr('id');
		console.log("one"+checkid);
        if (chk == 1)
        {
            var checkststus = true;
            if (checkid == 'first')
            {               
                if (!Page_ClientValidate('ADDMember')) {
                    alert('Please fill all the mandatory fields.');
                    checkststus = false;
                    return false;
                }
                
            }
            if (checkid == 'second') {
               // debugger;
                var abc = $('#contentbody_DdlNotified2_a').val();
                if (abc == "No")
                {
                    ValidatorEnable(document.getElementById('contentbody_RequiredFieldValidator11'), false);
                }
                else {
                    ValidatorEnable(document.getElementById('contentbody_RequiredFieldValidator11'), true);
                }
                var def = $('#contentbody_DdlExpertCommittee2_d').val();
                if (def == "No") {
                    ValidatorEnable(document.getElementById('contentbody_RequiredFieldValidator13'), false);
                }
                else {
                    ValidatorEnable(document.getElementById('contentbody_RequiredFieldValidator13'), true);
                }
                var ghi = $('#contentbody_DdlConsultationGramSabha2_f').val();
                if (ghi == "No") {
                    ValidatorEnable(document.getElementById('contentbody_RequiredFieldValidator14'), false);
                }
                else {
                    ValidatorEnable(document.getElementById('contentbody_RequiredFieldValidator14'), true);
                }
                
                if (!Page_ClientValidate('ADDMember2')) {
                    alert('Please fill all the mandatory fields.');
                    checkststus = false;
                    return false;
                }

            }
            
            $(this).parent().next().fadeIn('slow');
            $(this).parent().css({ 'display': 'none' });
            //Adding class active to show steps forward;
			
			// $(".progressbar li").each(function(){
				// $(this).removeClass("active");
			// });
			
			$('.active').next().addClass('active');
			$('.active:last').prev().removeClass('active');
            
			//$('.active').next().addClass('active');
			//  return true;
        }
        else
        {
            $(this).parent().next().fadeIn('slow');
            $(this).parent().css({'display': 'none'});
            //Adding class active to show steps forward;
            $('.active').next().addClass('active');
			$('.active:last').prev(".active").removeClass('active');
        }
       
       // return true;

    });

        $(".pre_btn").click(function () {
        //Function runs on PREVIOUS button click
        // debugger;
        $(this).parents('fieldset').prev().fadeIn('slow');
        $(this).parents('fieldset').css({ 'display': 'none' });
        //Removing class active to show steps backward;
		$('.active:last').prev().addClass("active");
        $('.active:last').removeClass('active');
    });


});
