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


$conn->close();
?>
