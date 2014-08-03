<?php
/**
 * Plugin Name: PST Plugin
 * Plugin URI: http://skyrise.hit.no
 * Description: Wordpress plugin for displaying live balloon data. 
 * Version: 0.1
 * Author: Kristoffer Lorentsen
 * Author URI: http://www.lorut.no
 * Licence: GPL2
 */
 
 // Include config file and variables
include_once('config.php');

// Include getdata functions/script
include_once('getdata.php');

// Google maps related code
include_once('gm.php');

// Display functions
include_once('display.php');

// Sqripts
wp_enqueue_script('pstcustom', plugins_url('/pst/pst.js'__FILE__));
wp_enqueue_script('gcharts', '//www.google.com/jsapi'__FILE__,array(),'1.0',true);

// Shortcode for display

function pstlive_display( $atts ){
	echo"TESTETESTETET";
	return;
}
add_shortcode( 'pstlive', 'pstlive_display' );
?>
	<!-- Google maps variables -->
	<?php //pst_gmaps_vars(pst_get_latest()); ?>
	
	<!-- All variables JS output -->
	<?php //pst_load_vars(); ?> 