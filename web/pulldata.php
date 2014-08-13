<?php
/* 
	Kristoffer Lorentsen for Project Skyrise Telemark 2014
	To pull data to the mysql database - for use in javascript 
	
	Interface:
	http://skyrise.hit.no/wp-content/plugins/pst/pulldata.php?var=humidity
	
*/
// Include config file
include_once('config.php');
include_once('getdata.php');

echo pst_get_data(htmlspecialchars($_GET["var"]));

?>