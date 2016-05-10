<!DOCTYPE html>
<html lang="en">

<head>
    <?php
    require ('dbcon.php')
     ?>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>CSGOJungle</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.6.1/css/font-awesome.min.css">
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css">
    <link href='https://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css'>
    <link href="css/scrolling-nav.css" rel="stylesheet">

</head>

<!-- The #page-top ID is part of the scrolling feature - the data-spy and data-target are part of the built-in Bootstrap scrollspy function -->

<body id="page-top" data-spy="scroll" data-target=".navbar-fixed-top">

    <!-- Navigation -->
    <nav class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header page-scroll">
                <a href="#" class="pull-left logo"><img src="csgojungle.png" alt="" /></a>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
              <!--  <a href="#" class="pull-left logo"><img src="csgojungle.png" alt="" /></a>-->
                <a class="navbar-brand page-scroll pull-right" href="#page-top">  Heim</a>
                <img class="collogo" src="csgojungle.png" alt="" />
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse navbar-ex1-collapse">

                <ul class="nav navbar-nav">
                  <li>
                    <!--<a href="#" class="pull-left logo"><img src="csgojungle.png" alt="" /></a></li>-->
                    <!-- Hidden li included to remove active class from about link when scrolled up past about section -->
                    <li class="hidden">
                        <a class="page-scroll" href="#page-top"></a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#contact">Leikir</a>
                    </li>

                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>


    <section id="intro" class="intro-section">
        <div class="container">
            <div class="row">
                <div class="">
                    <div class="carousel slide" data-ride="carousel" id="myCarousel">
                      <ol class="carousel-indicators">
                        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                        <li data-target="#myCarousel" data-slide-to="1"></li>

                      </ol>

                      <div class="carousel-inner" role="listbox">
                        <div class="item active">
                          <img src="myndir/csgo1.jpg" alt="" class="myCarouselImg"/>
                          <div class="carousel-caption">
                          	<h2>CS:GO</h2>
                          </div>
                        </div>


                        <div class="item">
                          <img src="myndir/csgo1.jpg" alt="" class="myCarouselImg" />
                        </div>
                    </div>
                      <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                        <span class="sr-only">Previous</span>
                      </a>
                      <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                        <span class="sr-only">Next</span>
                      </a>

                </div>
                <p>Hér getur þú lagt pening undir hvor þú heldur að muni vinna.</p>
            </div>
        </div>
    </section>



    <section id="contact" class="contact-section">
        <div class="container">
            <div class="row">
				<div class="col-lg-6 vcenter" id="leikir">
                <h1>Uppkomandi Leikir</h1>
				<div class="panel panel-leikir">
					<div class="panel-heading">
						Leikir
					</div>
                    <?php
                    if ($result->num_rows > 0) {
                        
                        while($row = $result->fetch_assoc()) {
                            echo '<a href="#" class="list-group-item">' . $row["lid1_lid2"]. ' | ' . $row["date"]. ' | Best Of ' . $row["bo"]. '</a>';
                        }
                      } else {
                          echo "0 results";
                      }
                    ?>
				</div>
	              </div><!--
                  -->
	            <div class="col-lg-6 vcenter">
                <h1>Búnir leikir</h1>
                <div class="panel panel-bunirleikir" id="leikir">
                    <div class="panel-heading">
                        Leikir
                    </div>

                    <?php
                    if ($result2->num_rows > 0) {
                        
                        while($row = $result2->fetch_assoc()) {
                            echo '<a href="#" class="list-group-item">'. "<i class='fa fa-check'>  </i>" . $row["lid1_lid2"]. ' | ' . $row["date"]. ' | Best Of ' . $row["bo"]. ' | Sigurvegari ' . $row["winner"].  '</a>';
                        }
                      } else {
                          echo "0 results";
                      }
                      
                    ?>
                </div>
	             </div>
                    </div>
                    </div>
                    </div>
    </section>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Scrolling Nav JavaScript -->
    <script src="js/jquery.easing.min.js"></script>
    <script src="js/scrolling-nav.js"></script>
    <script type="text/javascript" src="js/scripts.js">

    </script>
<footer>Gert af Stebba og Hávari</footer>
</body>

</html>
