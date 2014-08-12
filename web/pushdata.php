<?php
/* 
	Kristoffer Lorentsen for Project Skyrise Telemark 2014
	To push data to the mysql database 
	
	Interface:
	http://skyrise.hit.no/wp-content/plugins/pst/pushdata.php?pass=simplepassword&time=1406803997&lat=60.000&lon=-2&alt=1002&pressure=500&tempin=12&tempout=-30&heading=-40&accelx=1.001&accely=0.4421&accelz=-0.51325&humidity=25&spin=5&voltage=5.6
	
*/
// Include config file
include_once('config.php');

//connection to the database
$dbhandle = mysql_connect($pstconfig['dbserver'], $pstconfig['dbuser'], $pstconfig['dbpass']) 
 or die("ERROR4");

//select a database to work with
$selected = mysql_select_db($pstconfig['dbname'],$dbhandle) 
  or die("ERROR4");

// Check that the password exist and that is is correct
if(isset($_GET["pass"])):
	if( $_GET["pass"] == $pstconfig['dbpushpass'] ):

		// If there is a timestamp, store whatevers there into the db
		if(isset($_GET["time"])):
		  
			// Build sql query
			$query = 	"INSERT INTO " . $pstconfig['dbtable'] . " VALUES ( DEFAULT, "
						. "FROM_UNIXTIME('" . htmlspecialchars($_GET["time"]) . "'), "
						. (isset($_GET["lat"]) ? htmlspecialchars($_GET["lat"]) : 'DEFAULT') . ", "
						. (isset($_GET["lon"]) ? htmlspecialchars($_GET["lon"]) : 'DEFAULT') . ", "
						. (isset($_GET["alt"]) ? htmlspecialchars($_GET["alt"]) : 'DEFAULT') . ", "
						. (isset($_GET["pressure"]) ? htmlspecialchars($_GET["pressure"]) : 'DEFAULT') . ", "
						. (isset($_GET["tempin"]) ? htmlspecialchars($_GET["tempin"]) : 'DEFAULT') . ", "
						. (isset($_GET["tempout"]) ? htmlspecialchars($_GET["tempout"]) : 'DEFAULT') . ", "
						. (isset($_GET["heading"]) ? htmlspecialchars($_GET["heading"]) : 'DEFAULT') . ", "
						. (isset($_GET["accelx"]) ? htmlspecialchars($_GET["accelx"]) : 'DEFAULT') . ", "
						. (isset($_GET["accely"]) ? htmlspecialchars($_GET["accely"]) : 'DEFAULT') . ", "
						. (isset($_GET["accelz"]) ? htmlspecialchars($_GET["accelz"]) : 'DEFAULT') . ", "
						. (isset($_GET["humidity"]) ? htmlspecialchars($_GET["humidity"]) : 'DEFAULT'). ", "
						. (isset($_GET["spin"]) ? htmlspecialchars($_GET["spin"]) : 'DEFAULT'). ", "
						. (isset($_GET["voltage"]) ? htmlspecialchars($_GET["voltage"]) : 'DEFAULT') . " ) ";
						
			//execute the SQL query
			$result = mysql_query($query);
			
			// Validate
			if ($result) {
				echo "OK";
			} else {
				echo "ERROR0"; // Failed inserting data
			}
		
		else:
			echo "ERROR1"; // Time is missing
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