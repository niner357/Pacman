
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>The Pacman Project</title>

	<link href="https://fonts.googleapis.com/css?family=Roboto:100,300,700,900" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="css/register_layout.css">
	<link rel="icon" href="http://i.imgur.com/bmegGME.png">

	<script src="js/jquery.js"></script>
</head>

<body>

	<div id="ud_button" class="ud_button">
		<div id="ud_content">
			<form action="register.php?page=2" method="post">
				<h3>Register</h3>
				<p>
					<label>Name</label>
					<input type="text" name="name" id="ud_name" class=
					<?php 
						if(isset($_GET["iv"])){
							if($_GET["iv"] == "name"){
								echo 'ud_invalid';
							}else{
								echo '';
							}
						}else{
							echo '';
						}
					?>>
				</p>
				<p>
					<label>Email</label>
					<input type="text" name="email" id="ud_email">
				</p>
				<p>
					<label>Password</label>
					<input type="password" name="password" id="ud_pw">
				</p>
				<p>
					<label>Repeat Password</label>
					<input type="password" name="repeatPassword" id="ud_pwRe">
				</p>
				<p>
					<input id="ud_send" type="submit" name="Send" placeholder="Login">
				</p>
				<p id="ud_register"><a id="ud_registerHref" href="index.php">Already an Account? Login here</a></p>
			</form>
		</div>
	</div>

	<?php 
	if(isset($_GET["page"])){
		if($_GET["page"] == "2"){
			$name = strtolower($_POST["name"]);
			$normalName = $_POST["name"];
			if(strlen($name) <= 0){
				header("Location: register.php?iv=name");
				return;
			}
			if(strlen($_POST["password"]) < 6){
				return;
			}
			$pw = md5($_POST["password"]);
			if(strlen($_POST["repeatPassword"]) < 6){
				return;
			}
			if(strlen($_POST["email"]) < 2){
				return;
			}
			if(!strpos($_POST["email"], '@')){
				return;
			}
			if(!strpos($_POST["email"], '.')){
				return;
			}
			$email = $_POST["email"];
			$rePw = md5($_POST["repeatPassword"]);
			if($pw != $rePw){
				header("Location: pwWrong_loading.html");
			}else{
				$control = 0;
				$connection = mysqli_connect("217.160.177.122", "pacman", "9DkNXtfAFCqHp3wF", "programs");
				$query = "SELECT Username FROM pacmanTable WHERE Username ='$name'";
				$result = mysqli_query($connection, $query);
				while($row = mysqli_fetch_object($result)){
					$control++;
				}
				if($control != 0){
					header("Location: userExists_loading.html");
				}else{
					$highscore = 0;
					$deaths = 0;
					$verified = false;
					$lvlRow = 0;
					$characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
					$length = 25;
				    $charactersLength = strlen($characters);
				    $randomString = '';
				    $banned = false;
				    $banReason = '';
				    $admin = false;
				    for ($i = 0; $i < $length; $i++) {
				        $randomString .= $characters[rand(0, $charactersLength - 1)];
				    }
					$insert = "INSERT INTO pacmanTable (Username, Password, Email, Verified, VerifyCode, Highscore, MostLevelInRow, Deaths, Banned, BanReason, Admin) VALUES ('$name', '$pw', '$email', '$verified', '$randomString', '$highscore', '$lvlRow', '$deaths', '$banned', '$banReason', '$admin')";
					$insertResult = mysqli_query($connection, $insert);
					if($insertResult == true){

						if(($Content = file_get_contents("email_template.html")) === false) {
					        $Content = "";
					    }
						
						$Zero = "";
						$Content0 = strtr($Content, array('Â' => $Zero));

						$Content1 = strtr($Content0, array('§normalName§' => $normalName));
						$Content2 = strtr($Content1, array('§randomString§' => $randomString));
						$Content3 = strtr($Content2, array('§name§' => $name));

					    $FromEmail = "noreply@dasdarki.de";

					    $Subject = "Pacman: Verification";

					    $Headers  = "MIME-Version: 1.0\n";
					    $Headers .= "Content-Type: text/html; charset=UTF-8\r\n";
					    $Headers .= "From: ".$FromName." <".$FromEmail.">\n";
					    $Headers .= "X-Sender: <".$FromEmail.">\n";
					    $Headers .= "X-Mailer: PHP\n"; 
					    $Headers .= "X-Priority: 1\n"; 
					    $Headers .= "Return-Path: <".$FromEmail.">\n";  

					    if(mail($email, $Subject, $Content3, $Headers) == false) {
							header("Location: notSuccessfully_loading.html");
					    }
						header("Location: successfully_loading.html");
					}else{
						header("Location: notSuccessfully_loading.html");
					}
				}
			}
		}
	}
	?>

</body>
</html>
