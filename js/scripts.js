$('document').ready(function(){
  $('.list-group-item').click(function(){
  	var index = $(this).text();
  	var array = index.replace("|", " v ").split(" v ");
  	$('.slidedown').text(array[0] + " vs " + array[1]);
    $('#fela').slideToggle();
  });
});

$('.list-group-item').click(function(e){
	e.preventDefault();
});