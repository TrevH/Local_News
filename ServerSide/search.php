<?php
$servername = "";
$username = "";
$password = "";
$dbname = "";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if (mysqli_connect_errno($con))
{
   echo '{"query_result":"ERROR"}';
}
 
$result = mysqli_query($conn,"TRUNCATE TABLE site");

if($result == true) {
    echo '{"query_result":"SUCCESS"}';
}
else{
    echo '{"query_result":"FAILURE"}';
}
$conn->close();
?>