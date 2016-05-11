$('document').ready(function(){
  $('.list-group-item').click(function(){
  	var index = $(this).text();
  	var array = index.replace(" | ", " v ").split(" v ");
  	$('.jsleikir').text(array[0] + " vs " + array[1]);
    //$('#fela').slideToggle();
    $('.jsdate').text(array[2]);
    $('.btnlid1').text(array[0]);
    $('.btnlid2').text(array[1]);
    $('.chcklid2').prop('checked', false)
    $('.chcklid1').prop('checked', false)
  });
  $('.btnlid1').click(function(){
  	$('.chcklid1').trigger('click');
  	$('.chcklid2').prop('checked', false)
  });
    $('.btnlid2').click(function(){
  	$('.chcklid2').trigger('click');
  	$('.chcklid1').prop('checked', false)
  });
});

$('.list-group-item').click(function(e){
	e.preventDefault();
});