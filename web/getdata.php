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
function pst_get_path( &$lat, &$lon ) {

	global $pstconfig;

	//connection to the database
	$dbhandle = mysql_connect($pstconfig['dbserver'], $pstconfig['dbuser'], $pstconfig['dbpass']) 
	 or die("Unable to connect to MySQL");

	//select a database to work with
	$selected = mysql_select_db($pstconfig['dbname'],$dbhandle) 
	  or die("Could not select database");

	  
	//get latest input id
	//execute the SQL query and return records
	$result = mysql_query("SELECT lat, lon FROM " . $pstconfig['dbtable'] );
	
	
	// Arrays
	$lat = [];
	$lon = [];
	
	while ($row = mysql_fetch_array($result)) {
		// Add values to arrays
		$lat[] = $row['lat'];
		$lon[] = $row['lon'];
	}
	
	//close the connection
	mysql_close($dbhandle);
	
	//return the latest data
	return;
	

}
?>