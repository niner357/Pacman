<?php
session_start();
session_destroy();
?>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>The Pacman Project</title>

	<link href="https://fonts.googleapis.com/css?family=Roboto:100,300,700,900" rel="stylesheet">
	<style type="text/css">
		html, body{
			margin:0;
		  	padding:0;
		  	width:100%;
		  	height:160%;
		  	background: #64f4fc;
		  	font-family: 'Roboto', sans-serif;
		  	font-weight: 300;
		}

		.loader {
			position: absolute;
			top: calc(25% - 60px);
			left: calc(50% - 60px);
		    border: 16px solid #f3f3f3; /* Light grey */
		    border-top: 16px solid #0044ff; 
		    border-radius: 50%;
		    width: 120px;
		    height: 120px;
		    animation: spin 2s linear infinite;
		}

		p{
			color: #999;
			top: calc(50% + 70px);
			left: calc(50% - 60px);
			text-align: center;

		}

		@keyframes spin {
		    0% { transform: rotate(0deg); }
		    100% { transform: rotate(360deg); }
		}
	</style>
	<link rel="icon" href="http://i.imgur.com/bmegGME.png">

	<script src="js/jquery.js"></script>
</head>

<body>

	<div class="loader">
		
	</div>

	<p>Successfully logged out! Redirecting in 5 Seconds...</p>

	<script type="text/javascript">
		$(document).ready(function () {
		    window.setTimeout(function () {
		        location.href = "index.php";
		    }, 5000);
		});
	</script>

</body>
</html>