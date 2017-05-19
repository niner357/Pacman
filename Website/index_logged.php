<?php 
session_start();
if(!isset($_SESSION["login"])){
	header("Location: index.html");
	return;
}else{
	if($_SESSION["login"] == false){
		header("Location: index.html");
		return;
	}
	if(isset($_GET["cmd"])){
		if($_GET["cmd"] == "verify"){
			$code = $_POST["key"];
			$name = $_SESSION["name"];
			if(strlen($code) == 25){
				header("Location: email_confirm.php?username=$name&code=$code");
			}else{
				//TODO
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
	<link rel="stylesheet" type="text/css" href="css/logged_layout.css">
	<link rel="icon" href="http://i.imgur.com/bmegGME.png">
	<meta charset="UTF-8">

	<script src="js/jquery.js"></script>
</head>
<body>
<div id="header">
	<h1 id="back">←</h1>
	<h2 id="logout">Logout</h2>
	<img src="http://i.imgur.com/lORTspq.png" id="titleImg">
	<?php 
		$connection = mysqli_connect("217.160.177.122", "pacman", "9DkNXtfAFCqHp3wF", "programs");
		$pw = $_SESSION["pw"];
		$username = $_SESSION["name"];
		$query = "SELECT * FROM pacmanTable WHERE Username ='$username' AND Password = '$pw'";
		$result = mysqli_query($connection, $query);
		if ($result) {
		    while ($row = $result->fetch_assoc()) {
		        if($row['Verified'] == 0){
		        	?>
		        	<form method="post" action="index_logged.php?mod=verification">
		        		<p>
							<input id="verify" type="submit" name="send" value="Verify">
						</p>
		        	</form>
		        	<?php
		        }else{
		        	?>
		        	<form method="post" action="index_logged.php?mod=download">
		        		<p>
							<input id="download" type="submit" name="send" value="Download">
						</p>
		        	</form>
		        	<?php
		        }
		    }
		}
	?>
	<form method="post" action="index_logged.php?mod=top5">
		<p>
			<input id="top10" type="submit" name="send" value="Top 5">
		</p>
	</form>
	<?php 
		$control = 0;
		$connection = mysqli_connect("217.160.177.122", "pacman", "9DkNXtfAFCqHp3wF", "programs");
		$pw = $_SESSION["pw"];
		$username = $_SESSION["name"];
		$query = "SELECT * FROM pacmanTable WHERE Username ='$username' AND Password = '$pw'";
		$result = mysqli_query($connection, $query);
		if ($result) {
		    while ($row = $result->fetch_assoc()) {
		        if($row['Admin'] == 1){
		        	?>
		        	<form method="post" action="index_logged.php?mod=admin">
		        		<p>
							<input id="admin" type="submit" name="send" value="Admin">
						</p>
		        	</form>
		        	<?php
		        }
		    }
		}
	?>
</div>
<div id="siteBody">
<?php 
	if(isset($_GET["mod"])){
		if($_GET["mod"] == "verification"){
			?>
				<h1>Verification</h1>
				<p>You are still not verified yet. Please verify your Account. Otherwise we will delete your Account. 
				<br>Time remaining: <?php ?>
				<br>
				<br>If you haven't got an Verification-E-Mail yet, please click <a href="index_logged.php?mod=showCode">here</a>!
				<br>
				<br>If the Verification doesn't work then anymore contact and Pacman-Admin under pacman-admin@dasdarki.de
				<br>or contact the Site Admin under admin@dasdarki.de
				<br>
				<br>Key-Verification:
				</p>
				<form method="post" action="index_logged.php?cmd=verify">
					<p>
						<input type="text" name="key" placeholder="25-Digit Key" id="keyTextBox">
					</p>
					<p>
						<input type="submit" name="send" value="Verify Key" id="verifyButton">
					</p>
				</form>
			<?php
		}else if($_GET["mod"] == "showCode"){
			?>
				<h1>Verification</h1>
				<p>You are still not verified yet. Please verify your Account. Otherwise we will delete your Account. 
				<br>Time remaining: <?php ?>
				<br>
				<br>Key: 
				<strong>
					<?php 
					$connection = mysqli_connect("217.160.177.122", "pacman", "9DkNXtfAFCqHp3wF", "programs");
					$pw = $_SESSION["pw"];
					$username = $_SESSION["name"];
					$query = "SELECT * FROM pacmanTable WHERE Username ='$username' AND Password = '$pw'";
					$result = mysqli_query($connection, $query);
					if ($result) {
		    			while ($row = $result->fetch_assoc()) {
		    				$code = $row["VerifyCode"];
		    				echo $code;
		    			}
		    		}
					?>
				</strong>
				<br>Hide Key by clicking <a href="index_logged.php?mod=verification">here</a>!
				<br>
				<br>If the Verification doesn't work then anymore contact and Pacman-Admin under pacman-admin@dasdarki.de
				<br>or contact the Site Admin under admin@dasdarki.de
				<br>
				<br>Key-Verification:
				</p>
				<form method="post" action="index_logged.php?cmd=verify">
					<p>
						<input type="text" name="key" placeholder="25-Digit Key" id="keyTextBox">
					</p>
					<p>
						<input type="submit" name="send" value="Verify Key" id="verifyButton">
					</p>
				</form>
			<?php
		}else if($_GET["mod"] == "top5"){
			?>
				<img src="http://i.imgur.com/yinMEGA.png" id="top10Img">
				<p id="topText">This are the Top 5 Players. If you want to be one of them beat one of their Scores!</p>
			<?php
			##############################
			$count = 5; #----# Can Be Edit
			##############################
			$connection = mysqli_connect("217.160.177.122", "pacman", "9DkNXtfAFCqHp3wF", "programs");
			$query = "SELECT Highscore, Username FROM pacmanTable ORDER BY Highscore DESC LIMIT $count";
			$result = mysqli_query($connection, $query);
			if ($result) {
				$results = array();
		    	while ($row = $result->fetch_assoc()) {
   					$results[] = $row;
		    	}
		    	?>
		    	<ul>
				    <?php $index = 1;
				    foreach( $results as $row): ?>
				    <li><?=$index . "."?></li>
				    <li id="marginDown"><?=
				    " <strong>" . strtoupper($row['Username']) . "</strong>: " . $row['Highscore'] . " Points";
				    ?></li>
				    <?php 
				    	$index += 1;
				    ?>
				    <?php endforeach; ?>
				</ul>
		    	<?php
		    }
		}else if($_GET["mod"] == "admin"){
			?>
				
			<?php
		}else if($_GET["mod"] == "download"){
			?>
				<h1>Download</h1>
				<p>Pacman is written in C# so you need the .NET Framework. You can download it on the Microsoft Site.
				<br>Just click the Button under the .NET Framework Picture.<br>
				<img src="http://i.imgur.com/TVlxPGq.png" id="netImg" style="width: 64; height: 64;"><br>
				<a href="https://www.microsoft.com/en-gb/download/details.aspx?id=48130">To Site</a><br>
				<br>Because it's written in C# you need an OS thats compatible with .NET Framework. To Download the Game just click the Button under the Windows Symbol<br>
				<img src="http://i.imgur.com/VbJ6T1V.png" id="winImg" style="width: 64; height: 64;"><br>
				<a href="">Download</a>
				</p>
			<?php
		}
	}else{
	}
?>
</div>
<script type="text/javascript">
	$('#back').stop().on('click', function(){
				window.location = "index.php";
	});
	$('#logout').stop().on('click', function(){
				window.location = "logout.php";
	});
</script>
</body>
</html>
