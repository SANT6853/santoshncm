$(document).ready(function ()
{

    /*---------------------------------------------------------*/
   

    $(".next_btn").click(function ()
    {
                   
            $(this).parent().next().fadeIn('slow');
            $(this).parent().css({ 'display': 'none' });
            //Adding class active to show steps forward;
            $('.active').next().addClass('active');
        

    });

    $(".pre_btn").click(function () {            //Function runs on PREVIOUS button click 
        $(this).parent().prev().fadeIn('slow');
        $(this).parent().css({ 'display': 'none' });
        //Removing class active to show steps backward;
        $('.active:last').removeClass('active');

     

    });


});
