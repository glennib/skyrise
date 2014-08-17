<?php
/*
Posisjon: latitude, longitude, altitude (grader. F.eks. vil 59 grader og 10 minutter representeres som 59.1667. Altitude blir meter.)
Temperatur i boksen (Celsius)
Trykk (mbar). Konverter gjerne til altitude, så man kan sammenlikne med GPS.
Temperatur utenfor boksen (Celsius)
Heading (orientering av boksen) (Grader)
Akselerasjon i X-, Y- og Z-retning.
Fuktighet (Tror det vil være relativ fuktighet i %).*/

//
///	Echo data for gmaps
//

function pst_gmaps_vars($latest) {

	// Start generating codestring
	$codestring = "var sites = {};\n";

	// Variables for launch
	$options = get_option( 'pst_option' );
	$location = $options['pst_start_title'];
	$lat = $options['pst_start_lat'];;
	$lon = $options['pst_start_lon'];;
	
		
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
};

//
/// Get the latest data that has position
//


function pst_get_latest() {
	global $pstconfig;

	//connection to the database
	$dbhandle = mysql_connect($pstconfig['dbserver'], $pstconfig['dbuser'], $pstconfig['dbpass']) 
	 or die("Unable to connect to MySQL");

	//select a database to work with
	$selected = mysql_select_db($pstconfig['dbname'],$dbhandle) 
	  or die("Could not select database");

	  
	//get latest input id
	$latest = mysql_query("SELECT MAX(id) FROM " . $pstconfig['dbtable'] . " WHERE lat IS NOT NULL AND lon IS NOT NULL");
	$latest = mysql_fetch_array($latest);
	$latest = $latest[0];

	//execute the SQL query and return records
	$latest = mysql_query("SELECT * FROM " . $pstconfig['dbtable'] . " WHERE id = " . $latest );
	$latest = mysql_fetch_array($latest);
	

	//close the connection
	mysql_close($dbhandle);
	
	//return the latest data
	return $latest;
}

//
//// Echo html with of all lat/lon/alt coordinates for google maps and graph
// 

function pst_load_vars() {

	global $pstconfig;

	//connection to the database
	$dbhandle = mysql_connect($pstconfig['dbserver'], $pstconfig['dbuser'], $pstconfig['dbpass']) 
	 or die("Unable to connect to MySQL");

	//select a database to work with
	$selected = mysql_select_db($pstconfig['dbname'],$dbhandle) 
	  or die("Could not select database");

	  
	//get latest input id
	//execute the SQL query and return records
	$result = mysql_query("SELECT lat, lon, alt, time, tempout FROM " . $pstconfig['dbtable'] . " WHERE lat IS NOT NULL AND lon IS NOT NULL" );
	
	//
	/// Add strings for lat/lon
	//
	
	// Strings
	$times = "var psttimes = [ ";
	$lats = "var pstlats = [ ";
	$lons = "var pstlons = [ ";
	$alts = "var pstalts = [ ";
	$tempouts = "var psttempouts = [ ";
	
	while ($row = mysql_fetch_array($result)) {
		// Add values
		$times .= "'".$row['time'] . "',";
		$lats .= $row['lat'] . ",";
		$lons .= $row['lon'] . ",";
		$alts .= $row['alt'] . ",";
		$tempouts .= $row['tempout'] . ",";
	}
	
	// N
	$times .= "];\n";
	$lats .= "];\n";
	$lons .= "];\n";
	$alts .= "];\n";
	$tempouts .= "];\n";
?>

	<script type="text/javascript">
		<?php echo $lats; ?>
		<?php echo $lons; ?>
		<?php echo $alts; ?>
		<?php echo $tempouts; ?>
		<?php echo $times; ?>
	</script>
	
<?php
	
	//close the connection
	mysql_close($dbhandle);
	
	//return the latest data
	return;

}; //End pst load vars


function pst_get_data($variable) {

	global $pstconfig;

	// List array of all know variables
	$okVars = array('lat','lon','alt','pressure','tempin','tempout','heading','accelx','accely','accelz','humidity','spin','voltage');

	// Check if its ok, else choose alt
	if (!in_array($variable, $okVars)) {
		$variable = 'alt';
	}

	//connection to the database
	$dbhandle = mysql_connect($pstconfig['dbserver'], $pstconfig['dbuser'], $pstconfig['dbpass']) 
	 or die("ERROR3");

	//select a database to work with
	$selected = mysql_select_db($pstconfig['dbname'],$dbhandle) 
	  or die("ERROR4");

	  
	//get latest input id
	//execute the SQL query and return records
	$result = mysql_query("SELECT time, " . $variable . " FROM " . $pstconfig['dbtable'] . " WHERE " . $variable . " IS NOT NULL" );

	while ($row = mysql_fetch_array($result)) {
		// Add values
		$output .= "". $row['time'] . "|" .$row[$variable] . ",";
	}

	return $output;
}

// Delete all data in table
function pst_truncate_data() {
	global $pstconfig;

	//connection to the database
	$dbhandle = mysql_connect($pstconfig['dbserver'], $pstconfig['dbuser'], $pstconfig['dbpass']) 
	 or die("Unable to connect to MySQL");

	//select a database to work with
	$selected = mysql_select_db($pstconfig['dbname'],$dbhandle) 
	  or die("Could not select database");

	  
	//get latest input id
	$latest = mysql_query("TRUNCATE TABLE " . $pstconfig['dbtable'] );
	//close the connection
	mysql_close($dbhandle);
	
	//return
	return;

}
?>