<?php

/*

	PST Options page
	Kristoffer Lorentsen - for Project Skyrise Telemark 2014
	Based on: http://www.paulund.co.uk/theme-options-page

*/

// Register the page
function pst_options_menu() {
  add_theme_page( 'PST Option', 'PST Options', 'manage_options', 'pst_options_page', 'pst_options_page');  
};
add_action('admin_menu', 'pst_options_menu');

// Create the page
function pst_options_page()
{
?>
    <div class="section panel">
      <h1>PST Options</h1>
      <form method="post" enctype="multipart/form-data" action="options.php">
        <?php 
          settings_fields('pst_options'); 
        
          do_settings_sections('pst_options_page');
        ?>
            <p class="submit">  
                <input type="submit" class="button-primary" value="<?php _e('Save Changes') ?>" />  
            </p>  
            
      </form>
    </div>
    <?php
};

//
//// Register settings
//

function pst_register_settings(){ 
    // Register the settings with Validation callback
    register_setting( 'pst_options', 'pst_option', 'pst_validate_settings' );

    // Add settings section
    add_settings_section( 'pst_text_section', 'PST Live Track Settings', 'pst_display_section', 'pst_options_page' );

    // Create textbox fields


    $field_args = array(
      'type'      => 'text',
      'id'        => 'pst_start_title',
      'desc'      => 'Title for Start location'
    );
    add_settings_field( 'pst_start_title', 'Start location title', 'pst_display_setting', 'pst_options_page', 'pst_text_section', $field_args );

    $field_args = array(
      'type'      => 'text',
      'id'        => 'pst_start_lat',
      'desc'      => 'Latitude for Start location'
    );
    add_settings_field( 'pst_start_lat', 'Start location latitude', 'pst_display_setting', 'pst_options_page', 'pst_text_section', $field_args );

    $field_args = array(
      'type'      => 'text',
      'id'        => 'pst_start_lon',
      'desc'      => 'Longitude for Start location'
    );
    add_settings_field( 'pst_start_lon', 'Start location longitude', 'pst_display_setting', 'pst_options_page', 'pst_text_section', $field_args ); 

    $field_args = array(
      'type'      => 'checkbox',
      'id'        => 'pst_empty_sql',
      'desc'      => 'Empty SQL database'
    );
    add_settings_field( 'pst_empty_sql', 'Empty SQL database', 'pst_display_setting', 'pst_options_page', 'pst_text_section', $field_args ); 

};
add_action( 'admin_init', 'pst_register_settings' );

// For adding extra sections HTML
function pst_display_section($section){ 
	//echo "<h3>" . $section[title] ."</h3>";
}

// For displaying option
function pst_display_setting($args)
{
    extract( $args );

    $option_name = 'pst_option';

    $options = get_option( $option_name );



    switch ( $type ) {  
          case 'text':  
              $options[$id] = stripslashes($options[$id]);
              $options[$id] = esc_attr( $options[$id]);
              echo "<input class='regular-text $class' type='text' id='$id' name='" . $option_name . "[$id]' value='$options[$id]' />";  
              echo ($desc != '') ? "<br /><span class='description'>$desc</span>" : "";
              break;
          case 'checkbox':
              echo "<input class='regular-checkbox $class' type='checkbox' id='$id' name='" . $option_name . "[$id]' value='truncate'/>";
              echo ($desc != '') ? "<br /><span class='description'>$desc</span>" : "";
              break;  
    }
}

// Sanitizing input

function pst_validate_settings($input)
{

  // Single out the empty 
  foreach($input as $key => $value)
  {
    if ($key == "pst_empty_sql") {
      if ($value == "truncate") {
        pst_truncate_data();
      }
    }
  }
    
    /* Check the input is a letter or a number
    if(!preg_match('/^[A-Z0-9 _]*$/i', $v)) {
      $newinput[$k] = '';
    }*
  }

  return $newinput;*/
  return $input;
}
?>