<?php 
session_start();
if(!isset($_SESSION["login"])){
	if(isset($_GET["mode"])){
		if($_GET["mode"] == "confirm"){
			$name = $_GET["username"];
			$code = $_GET["code"];
			header("Location: index.php?mode=openLogIn&username=$name&code=$code");
			return;
		}
	}
	header("Location: index.html");
	return;
}else{
	if($_SESSION["login"] == false){
		header("Location: index.html");
		return;
	}
	$code = $_GET["code"];
	$username = $_GET["username"];
	$control = 0;
	$connection = mysqli_connect("217.160.177.122", "pacman", "9DkNXtfAFCqHp3wF", "programs");
	$query = "SELECT * FROM pacmanTable WHERE Username ='$username' AND VerifyCode = '$code'";
	$result = mysqli_query($connection, $query);
	if ($result) {
	    while ($row = $result->fetch_assoc()) {
	        if($row['Verified'] == 0){
	        	$setQuery = "UPDATE pacmanTable SET Verified = '1' WHERE Username = '$username' AND VerifyCode = '$code'";
	            mysqli_query($connection, $setQuery);
				header("Location: verified_loading.html");
	        } else {
				header("Location: alreadyVerified_loading.html");
	        }
	    }
	}
}
?>
<!DOCTYPE html>
<html>
<head>
	<title>The Pacman Project</title>

	<link href="https://fonts.googleapis.com/css?family=Roboto:100,300,700,900" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="css/register_layout.css">
	<link rel="icon" href="http://i.imgur.com/bmegGME.png">

	<script src="js/jquery.js"></script>
</head>
<body>
</body>
</html>