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


// Get variables from db
$latest = pst_get_latest();
pst_get_path($lat,$lon);

?>

<!DOCTYPE html>
<html>
<head>
	<title>PST</title>
	
	<!-- Google maps variables -->
	<?php pst_gmaps_vars($latest, $lat, $lon) ?>
	
	
	<style>
			html, body {
				height: 100%;
			}
			#map_canvas {
				width: 500px;
				height: 400px;
			}
    </style>
</head>
<body>

	<h1>pst</h1>

	<div id="map-canvas" style="width:500px; height:400px"></div>
	<h2>Latest data at <?php echo $latest['time']; ?></h2>
	<ul>
		<li>Altitude: <?php echo $latest['alt']; ?> m</li>
		<li>Latitude: <?php echo $latest['lat']; ?> deg</li>
		<li>Longitude: <?php echo $latest['lon']; ?> deg</li>
		<li>Pressure: <?php echo $latest['pressure']; ?> mbar</li>
		<li>Temperature inside: <?php echo $latest['tempin']; ?> C</li>
		<li>Temperature outside: <?php echo $latest['tempout']; ?> C</li>
		<li>Heading: <?php echo $latest['heading']; ?> deg</li>
		<li>Acceleration X: <?php echo $latest['accelx']; ?> m/s^2</li>
		<li>Acceleration Y: <?php echo $latest['accely']; ?>m/s^2</li>
		<li>Acceleration Z: <?php echo $latest['accelz']; ?>m/s^2</li>
		<li>Humidity: <?php echo $latest['humidity']; ?> %</li>
		<li>Spin: <?php echo $latest['spin']; ?> deg/s</li>
		<li>Voltage: <?php echo $latest['voltage']; ?> V</li>
	</ul>

	

	<!-- Custom javascript -->
	<script src="pst.js"></script>
</body>
</html>