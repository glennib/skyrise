<?php
/* 
	Kristoffer Lorentsen for Project Skyrise Telemark 2014
	To push data to the mysql database 
	
	Interface:
	http://skyrise.hit.no/datahandle/pushdata.php?pass=simplepassword&time=1406803997&lat=60.000&lon=-2&alt=1002&pressure=500&tempin=12&tempout=-30&heading=-40&accelx=1.001&accely=0.4421&accelz=-0.51325&humidity=25&spin=5&voltage=5.6
	
*/
// Include config file
include_once('config.php');

//connection to the database
$dbhandle = mysql_connect($pstconfig['dbserver'], $pstconfig['dbuser'], $pstconfig['dbpass']) 
 or die("ERROR4");

//select a database to work with
$selected = mysql_select_db($pstconfig['dbname'],$dbhandle) 
  or die("ERROR4");

// Check that all variables exist
if(isset($_GET["pass"])):
	if( $_GET["pass"] == $pstconfig['dbpushpass'] ):
		if(isset($_GET["time"],$_GET["lat"],$_GET["lon"],$_GET["alt"],$_GET["pressure"],$_GET["tempin"],$_GET["tempout"],$_GET["heading"],$_GET["accelx"],$_GET["accely"],$_GET["accelz"],$_GET["humidity"],$_GET["spin"],$_GET["voltage"])):
		  
			// Build sql query
			$query = 	"INSERT INTO " . $pstconfig['dbtable'] . " VALUES ( DEFAULT, "
						. "FROM_UNIXTIME('" . htmlspecialchars($_GET["time"]) . "'), "
						. htmlspecialchars($_GET["lat"]) . ", "
						. htmlspecialchars($_GET["lon"]) . ", "
						. htmlspecialchars($_GET["alt"]) . ", "
						. htmlspecialchars($_GET["pressure"]) . ", "
						. htmlspecialchars($_GET["tempin"]) . ", "
						. htmlspecialchars($_GET["tempout"]) . ", "
						. htmlspecialchars($_GET["heading"]) . ", "
						. htmlspecialchars($_GET["accelx"]) . ", "
						. htmlspecialchars($_GET["accely"]) . ", "
						. htmlspecialchars($_GET["accelz"]) . ", "
						. htmlspecialchars($_GET["humidity"]). ", "
						. htmlspecialchars($_GET["spin"]). ", "
						. htmlspecialchars($_GET["voltage"]) . " ) ";
						
			//execute the SQL query
			$result = mysql_query($query);
			
			// Validate
			if ($result) {
				echo "OK";
			} else {
				echo "ERROR0"; // Failed inserting data
			}
		
		else:
			echo "ERROR1"; // Not all values
		endif;
	else:
		echo "ERROR2"; // Wrong pass
	endif;
else:
	echo "ERROR3"; // No pass
endif;
// Close db
mysql_close($dbhandle);



?>