(function($){ //create closure so we can safely use $ as alias for jQuery

$(document).ready(function(){

// initialise plugin
var example = $('#example, #example1').superfish({
//add options here if required
});

// buttons to demonstrate Superfish's public methods
$('.destroy').on('click', function(){
example.superfish('destroy');
});

$('.init').on('click', function(){
example.superfish();
});

$('.open').on('click', function(){
example.children('li:first').superfish('show');
});

$('.close').on('click', function(){
example.children('li:first').superfish('hide');
});
});

})(jQuery);



$(function () {
    $('#myCarousel').carousel({
        interval:2500,
        pause: "false"
    });
    $('#playButton').click(function () {
        $('#myCarousel').carousel('cycle');
    });
    $('#pauseButton').click(function () {
        $('#myCarousel').carousel('pause');
    });
});



$(document).ready(function () {
		$("#respMenu").aceResponsiveMenu({
			resizeWidth: '1600', // Set the same in Media query       
			animationSpeed: 'fast', //slow, medium, fast
			accoridonExpAll: false //Expands all the accordion menu on click
		});
});


/* scrollTop() >= 240
   Should be equal the the height of the header
 */
 
$(window).scroll(function(){
    if ($(window).scrollTop() >= 195) {
       $('.navigation-bg').addClass('fixed-header');
    }
    else {
       $('.navigation-bg').removeClass('fixed-header');
    }
});

/* scrollTop() >= 240
   Should be equal the the height of the header
 */