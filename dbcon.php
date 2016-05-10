<?php
$servername ="tsuts.tskoli.is";
$username ="GRU_H9";
$password ="mypassword";
$dbname ="gru_h9_gru";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT lid1_lid2, date, bo FROM leikir";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "id: " . $row["lid1_lid2"]. " - Name: " . $row["date"]. " " . $row["bo"]. "<br>";
    }
} else {
    echo "0 results";
}
$conn->close();
?>
