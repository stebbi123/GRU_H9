$('document').ready(function(){
  $('.list-group-item').click(function(){
  	var index = $(this).text();
  	var array = index.replace(" | ", " v ").split(" v ");
  	$('.jsleikir').text(array[0] + " vs " + array[1]);
    //$('#fela').slideToggle();
    $('.jsdate').text(array[2]);
    $('.btnlid1').text(array[0]);
    $('.btnlid2').text(array[1]);
  });
  $('.btnlid1').click(function(){
  	alert("Val móttekið");
  });
    $('.btnlid2').click(function(){
  	alert("Val móttekið");
  });
});

$('.list-group-item').click(function(e){
	e.preventDefault();
});