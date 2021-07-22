<?php

$servername = "localhost";
$username = "id17285563_root";
$password = "hB2|?~@uvsD*/6zJ";
$database = "id17285563_supermarket";

// Create connection
$conn = mysqli_connect($servername, $username, $password, $database);

// Check connection
if (!$conn) {
    die("Connection failed: " . mysqli_connect_error());
}

echo "Connected successfully";
?>