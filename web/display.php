<?php
/* Display methods for PST plugin */


?>

<?php function pst_display_latest(){ 
	$latest = pst_get_latest();
?>

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
	
<?php }; //end pst_display_latest?>

<?php
function pst_display_gm(){ ?>
	<div id="map-canvas" style="width:500px; height:400px"></div>
<?php
};

function pst_display_gc(){ ?>
	<div id="chart-canvas" style="width:600; height:400"></div>
<?php
};

?>