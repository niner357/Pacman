<?php 
if(isset($_GET["page"])){
	if($_GET["page"] == "log"){
		if(isset($_GET["mode"])){
			if($_GET["mode"] == "openLogIn"){
				$name = $_GET["username"];
				$code = $_GET["code"];
				header("Location: http://www.dasdarki.de/pacman/email_confirm.php?mode=confirm&username=$name&code=$code");
			}
		}
	}
}
?>
<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>The Pacman Project</title>

	<link href="https://fonts.googleapis.com/css?family=Roboto:100,300,700,900" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="css/login_layout.css">
	<link rel="icon" href="http://i.imgur.com/bmegGME.png">

	<script src="js/jquery.js"></script>
</head>

<body>

	<div id="ud_header">
		<img src="http://i.imgur.com/lORTspq.png" id="titleImg">
	</div>

	<div id="ud_site"></div>

	<div id="ud_button" class="ud_button">
		<div id="ud_content">
			<form action=
			<?php 
				if(isset($_GET["mode"])){
					if($_GET["mode"] == "openLogIn"){
						echo 'index.php?page=log&mode=openLogIn&username=' . $_GET["username"] . '&code=' . $_GET["code"];
					}else{
						echo 'index.php?page=log';
					}
				}else{
					echo 'index.php?page=log';
				}
			?> method="post">
				<h3>Login <span id="ud_close">Close</span></h3>
				<p>
					<label>Name</label>
					<input type="text" name="name">
				</p>
				<p>
					<label>Password</label>
					<input type="password" name="password">
				</p>
				<p>
					<input id="send" type="submit" name="send" placeholder="Login">
				</p>
				<p id="ud_register"><a id="ud_registerHref" href="register.php">No Account? Register here</a></p>
			</form>
		</div>
		<?php 
			session_start();
			if(!isset($_SESSION["login"])){
				?>
					<h3 id="ud_click">Login</h3>
				<?php
			}else{
				if($_SESSION["login"] == false){
				?>
					<h3 id="ud_click">Login</h3>
				<?php
				}else{
				?>
					<h3 id="ud_logged">Log-In Area</h3>
				<?php
				}
			}
		?>
	</div>

	<?php 
		session_start();
		if(isset($_GET["page"])){
			if($_GET["page"] == "log"){
				$username = strtolower($_POST["name"]);
				$pw = md5($_POST["password"]);
				$control = 0;
				$connection = mysqli_connect("217.160.177.122", "pacman", "9DkNXtfAFCqHp3wF", "programs");
				$query = "SELECT * FROM pacmanTable WHERE Username ='$username' AND Password = '$pw'";
				$result = mysqli_query($connection, $query);
				while($row = mysqli_fetch_object($result)){
					$control++;
				}
				if($control !== 0){
					$_SESSION["login"] = true;
					$_SESSION["name"] = $username;
					$_SESSION["pw"] = $pw;
					if(isset($_GET["mode"])){
						echo $_GET["mode"];
						return;
						if($_GET["mode"] == "openLogIn"){
							$name = $_GET["username"];
							$code = $_GET["code"];
							header("Location: http://www.dasdarki.de/pacman/email_confirm.php?mode=confirm&username=$name&code=$code");
						}
					}else{
						header("Location: loginSuccess_loading.html");
					}
				}else{
					header("Location: loginFailed_loading.html");
				}
			}
		}
	?>

	<script>

		$(document).ready(function(){

			var ud_status = false;

			$('#ud_click').stop().on('click',function(){
				$(this).fadeOut(300);
				if(ud_status == false) {
					$('#ud_button').addClass('ud_active_1');
					setTimeout(function(){
						$('#ud_button').addClass('ud_active');
						$('#ud_header').addClass('ud_login');
						$('#ud_site').addClass('ud_login');
					},250);
					ud_status = true;
				}
			});

			$('#ud_logged').stop().on('click',function(){
				window.location = "index_logged.php";
			});

			$('#ud_close').stop().on('click',function(){
				if(ud_status == true) {
					$('#ud_button').removeClass('ud_active');
					$('#ud_header').removeClass('ud_login');
					$('#ud_click').fadeIn(300);
					setTimeout(function(){
						$('#ud_button').removeClass('ud_active_1');
						$('#ud_site').removeClass('ud_login');
					},250);
					ud_status = false;
				}
			});

		});

	</script>

</body>
</html>
