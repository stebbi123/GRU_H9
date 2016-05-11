<?php
$servername ="tsuts.tskoli.is";
$username ="GRU_H9";
$password ="mypassword";
$dbname ="gru_h9_gru";


$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT lid1_lid2, date, bo FROM leikir WHERE winner IS NULL";
$result = $conn->query($sql);

$sql2 = "SELECT lid1_lid2, date, bo, winner FROM leikir WHERE winner IS NOT NULL";
$result2 = $conn->query($sql2);


/*$sql3 = "SELECT lid1_lid2 FROM leikir WHERE winner IS NOT NULL";
$result3 = $conn->query($sql3);
$split_to_string = (string)$result3;	

$winner_loser = explode(" v ", $split_to_string);
*/

$nafn = $row['lid1_lid2'];
$conn->close();
?>
