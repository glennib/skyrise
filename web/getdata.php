<?php
/*
Posisjon: latitude, longitude, altitude (grader. F.eks. vil 59 grader og 10 minutter representeres som 59.1667. Altitude blir meter.)
Temperatur i boksen (Celsius)
Trykk (mbar). Konverter gjerne til altitude, så man kan sammenlikne med GPS.
Temperatur utenfor boksen (Celsius)
Heading (orientering av boksen) (Grader)
Akselerasjon i X-, Y- og Z-retning.
Fuktighet (Tror det vil være relativ fuktighet i %).*/


function pst_get_latest() {
	global $pstconfig;

	//connection to the database
	$dbhandle = mysql_connect($pstconfig['dbserver'], $pstconfig['dbuser'], $pstconfig['dbpass']) 
	 or die("Unable to connect to MySQL");

	//select a database to work with
	$selected = mysql_select_db($pstconfig['dbname'],$dbhandle) 
	  or die("Could not select database");

	  
	//get latest input id
	$latest = mysql_query("SELECT MAX(id) FROM " . $pstconfig['dbtable']);
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
// get array of all lat/lon coordinates
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
	$result = mysql_query("SELECT lat, lon, alt, time, tempout FROM " . $pstconfig['dbtable'] );
	
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

};
?>