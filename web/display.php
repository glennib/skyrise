<?php
/* Display methods for PST plugin */

function pst_display_latest(){ 
	$latest = pst_get_latest();

	ob_start(); // For capturing echo 
	?>
	<h2 data-icon="a">Latest data at <?php echo $latest['time']; ?></h2>
	<ul>
		<li data-icon="d">Altitude: <?php echo $latest['alt']; ?> m</li>
		<li data-icon="b">Latitude: <?php echo $latest['lat']; ?> deg</li>
		<li data-icon="b">Longitude: <?php echo $latest['lon']; ?> deg</li>
		<li data-icon="g">Pressure: <?php echo $latest['pressure']; ?> mbar</li>
		<li data-icon="f">Temperature inside: <?php echo $latest['tempin']; ?> C</li>
		<li data-icon="f">Temperature outside: <?php echo $latest['tempout']; ?> C</li>
		<li data-icon="c">Heading: <?php echo $latest['heading']; ?> deg</li>
		<li data-icon="e">Acceleration X: <?php echo $latest['accelx']; ?> m/s^2</li>
		<li data-icon="e">Acceleration Y: <?php echo $latest['accely']; ?>m/s^2</li>
		<li data-icon="e">Acceleration Z: <?php echo $latest['accelz']; ?>m/s^2</li>
		<li data-icon="j">Humidity: <?php echo $latest['humidity']; ?> %</li>
		<li data-icon="k">Spin: <?php echo $latest['spin']; ?> deg/s</li>
		<li data-icon="l">Voltage: <?php echo $latest['voltage']; ?> V</li>
	</ul>
	
	<?php 

	return ob_get_clean(); // Return the output
}; //end pst_display_latest

function pst_display_gm(){
	return '<div id="map-canvas" style="width:642px; height:400px"></div>';
};

function pst_display_gc(){
	return'<div id="chart-canvas" style="width:642; height:400"></div>';
};

?>