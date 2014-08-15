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

// Display functions
include_once('display.php');

// Register scripts
wp_register_script('pstcustom', '/wp-content/plugins/pst/pst.js',array(),'0.1',true);
wp_register_script('gcharts', '//www.google.com/jsapi',array(),'1.0',true);

// Register icon font
add_action( 'wp_enqueue_scripts', 'pst_register_plugin_styles' );
function pst_register_plugin_styles() {
	wp_register_style('fontastic', '//fontastic.s3.amazonaws.com/nPJXzizDbj2MwBNG7A8Eti/icons.css', array(), '1.0', false);
	wp_enqueue_style('fontastic');
};


// Output data into js vars
function pst_js_data() {

    pst_gmaps_vars(pst_get_latest()); // latest data
	pst_load_vars(); // all data
	
}

//
/// Shortcode for displaying live-track data
//
function pstlive_display( $atts ){
	// enqueue scripts
	wp_enqueue_script('pstcustom');
	wp_enqueue_script('gcharts');
	
	// Add javascript data areas
	add_action('wp_footer', 'pst_js_data');
	
	// Build html
	$html = pst_display_gm()."\n";
	$html .= pst_display_gc()."\n";
	
	// Add buttons
	$html .= '<a id="button1">Altitude</a>'."\n";
	$html .= '<a id="button2">TempOut</a>'."\n";
	$html .= '<a id="button3">Humidity</a>'."\n";

	// Add all latest data
	$html .= pst_display_latest();

	return $html;
}

add_shortcode( 'pstlive', 'pstlive_display' );
