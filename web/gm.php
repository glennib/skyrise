<?php
/**
 *  Kristoffer Lorentsen for Project Skyrise Telemark 2014
 *	Google maps related code
 *
 */
 
/*------------------------------------------------------------------------------*/
/*		Display google maps														*/
/*------------------------------------------------------------------------------*/

/*
function pst_display_google_maps() {

	// Echo map canvas
	echo '<div id="map-canvas"></div>';
	
	// Add variables to custom hook before wp_footer
	add_action('lorut_before_wp_footer','lorut_gmaps_vars');
	
}*/

/*------------------------------------------------------------------------------*/
/*		Getting google maps variables											*/
/*------------------------------------------------------------------------------*/

function pst_gmaps_vars($latest) {

	// Start generating codestring
	$codestring = "var sites = {};\n";

	// Variables for launch
	$location = 'HiT Rauland';
	$lat = 68.05660;
	$lon = -1;
	
		
	// Create the launchsite
	$codestring .= "sites[0] = {\n";
		
	// Title
	$codestring .= "\t location: '" . $location ."',\n";
	
	// Info
	$codestring .= "\t info: '" . "<b>" . $location . '</b></br>Lat: '.$lat.'</br>Lon: '.$lon."',\n" ;
	
	// Lat and lon
	$codestring .= "\t lat: " . $lat . ",\n";
	$codestring .= "\t lon: " . $lon . ",\n";
	
	// End structure
	$codestring .= "};\n";
	
	//
	/// Create the current site
	//

	$codestring .= "sites[1] = {\n";
		
	// Title
	$codestring .= "\t location: 'Current position',\n";
	$codestring .= "\t altitude: '" . $latest['alt'] ."',\n";
	
	// Info
	$codestring .= "\t info: '" . "<b>Current position</b></br>Alt: ". $latest['alt'] .'</br>Lat: '.$latest['lat'].'</br>Lon: '.$latest['lon']."',\n" ;
	
	// Lat and lon
	$codestring .= "\t lat: " . $latest['lat'] . ",\n";
	$codestring .= "\t lon: " . $latest['lon'] . ",\n";
	
	// End structure
	$codestring .= "};\n";
	
	?>
	<script type="text/javascript">
		<?php echo $codestring; ?>
	</script>

	<?php
}