<?php
/*
	Kristoffer Lorentsen for Project Skyrise Telemark 2014
	
	For displaying data in realtime on the web during launch.

	

*/
// Include config file and variables
include_once('config.php');

// Include getdata functions/script
include_once('getdata.php');

// Google maps related code
include_once('gm.php');

?>

<!DOCTYPE html>
<html>
<head>
	<title>PST</title>
	

	
	
	<style>
			html, body {
				height: 100%;
			}
			#map_canvas {
				width: 500px;
				height: 400px;
			}
    </style>
	
	<script type="text/javascript" src="https://www.google.com/jsapi"></script>
</head>
<body>

	<h1>pst</h1>
	

	


	

	<!-- Custom javascript -->
	<script src="pst.js"></script>
</body>
</html>