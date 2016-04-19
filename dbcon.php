<?php
$servername = "tsuts.tskoli.is";
$username = "GRU_H9";
$password = "mypassword";

// Create connection
$conn = new mysqli($servername, $username, $password);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
echo "Tenging tókst";
?> 
