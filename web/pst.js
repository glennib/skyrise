window.onload  = initSite;
var map = null; // For map
var chart = null; // For chart
var dataview = null; // data overlay for charts
var data = null; // data for chart
var newdata = null; // data for chart
var pins = {};
var infoWindow = {};
var button = {};
var variables = {};
var pullDataUrl = 'http://skyrise.hit.no/wp-content/plugins/pst/pulldata.php';


// Initialize site
function initSite() {

	var element =  document.getElementById('map-canvas');
	if (typeof(element) != 'undefined' && element != null)
	{
	  // Map exists.
	  gmLoadScript();
	}
	
	var element =  document.getElementById('chart-canvas');
	if (typeof(element) != 'undefined' && element != null)
	{
	  // Graph exists.
	  gcLoadScript();
	}
	
}

//
// / Google maps
//

function gmLoadScript() {
  var script = document.createElement('script');
  script.type = 'text/javascript';
  script.src = 'https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&' +
	  'callback=gmInitialize';
  document.body.appendChild(script);
  
}

function gmInitialize() {

  var zoomlevel = 6;
  var initLat = 59.325;
  var initLon = 8.67;


  // Set map options
  var mapOptions = {
	zoom: zoomlevel,
	center: new google.maps.LatLng(initLat, initLon),
	panControl: false,
	mapTypeControl: false,
	scaleControl: false,
	streetViewControl: false,
	overviewMapControl: false,
	scrollwheel: true,
	backgroundColor : "#850E23",
	zoomControl: true,
	
	zoomControlOptions: {
	  //buttonSize: new google.maps.Point(100, 0),
      style: google.maps.ZoomControlStyle.SMALL,
	  //position: google.maps.ControlPosition.RIGHT_TOP
	  
	  
    },
  };
  
  // Create new map
  map = new google.maps.Map(document.getElementById('map-canvas'),	mapOptions);
  
  // Define styling
  var styling = [];
  
  // Set styling
  map.setOptions({styles: styling});
  
  
  // Define markers and circles based on data
  //var pinImage = '//skyrise.hit.no/wp-content/plugins/pst/pin.png';
  
  var i = 0;
  for (var site in sites) {
  
	  // Set options
  	  var centerLatLon = new google.maps.LatLng(sites[i].lat, sites[i].lon);
  
	  var pinOptions = {
		  map: map,
		  position: centerLatLon,
		  title: sites[i].location,
		  id: i,
		  
	  }
	  
	  // Add pins
      pins[i] = new google.maps.Marker(pinOptions);
	  
	  // Add infowindow content
	  infoWindow[i] = new google.maps.InfoWindow({
		content: sites[i].info,
	  });
	  
	  // Add event listener for infoWindow
	  google.maps.event.addListener(pins[i], 'click', function() {
			infoWindow[this.id].open(map,pins[this.id]);
	  });
	  
	  // Increment counter
	  i = i + 1;
  }

  //
  // /	Add flight
  //
  
  var flightCoordinates = [];
  
  for (i = 0; i < pstlats.length; i++) { 
    flightCoordinates[i] = new google.maps.LatLng(pstlats[i], pstlons[i]);
  }
  
  var flightPath = new google.maps.Polyline({
    path: flightCoordinates,
    geodesic: true,
    strokeColor: '#FF0000',
    strokeOpacity: 1.0,
    strokeWeight: 3
  });
  
  flightPath.setMap(map);
}

//
// // Google Charts
//

function gcLoadScript() {
  // Load chart
  var options = {packages: ['corechart'], callback : gcDrawChart};
  google.load('visualization', '1.0', options);  
}

function gcDrawChart() {

  // Create the data table. 'alt','pressure','tempin','tempout','heading','accel','humidity','spin','voltage'
  data = new google.visualization.DataTable();
  data.addColumn('datetime', 'Time');
  data.addColumn('number', 'Altitude');
  data.addColumn('number', 'Pressure');
  data.addColumn('number', 'Temperature Inside');
  data.addColumn('number', 'Temperature Outside');
  data.addColumn('number', 'Heading');
  data.addColumn('number', 'Acceleration');
  data.addColumn('number', 'Humidity');
  data.addColumn('number', 'Spin');
  data.addColumn('number', 'Voltage');


  
  // Add each row
  for (i = 0; i < psttimes.length; i++) { 
	data.addRow([new Date(psttimes[i]), pstalts[i], pstpressures[i], psttempins[i], psttempouts[i], pstheadings[i], pstaccels[i], psthumiditys[i], pstspins[i], pstvoltages[i]]);
  }

  
  // DataView - a view of the table..
  dataview = new google.visualization.DataView(data)
  dataview.setColumns([0,1]);
  
  // Set chart options
  var options = {'title':'Time series data',
                 'width':642,
                 'height':400,
				 animation: {
                     duration: 1000,
                     easing: 'out',
                 }
	  };

  // Instantiate and draw our chart, passing in some options.
  chart = new google.visualization.LineChart(document.getElementById('chart-canvas'));
  
  chart.draw(dataview, options);
  
  /* Set varables an titles
  variables = {   'alt':'Altitude',
                      'pressure':'Pressure',
                      'tempout':'Temperature Outside',
                      'tempin':'Temperature Inside',
                      'heading':'Heading',
                      'accel':'Acceleration',
                      'humidity':'Humidity',
                      'spin':'Spin',
                      'voltage':'Battery voltage'}; */

  // Set varables an titles
  variables = {   'alt':'Altitude',
                      'pressure':'Pressure',
                      'tempout':'Temperature Outside',
                      'tempin':'Temperature Inside',
                      'heading':'Heading',
                      'accel':'Acceleration',
                      'humidity':'Humidity',
                      'spin':'Spin',
                      'voltage':'Battery voltage'}; 

  // Buttons for changing values

  var ii = 1;
  var buttonID = '';


  for(var key in variables) {

    buttonID = 'button'+key; 

    if(document.getElementById(buttonID)) {
      button[ii] = document.getElementById(buttonID);

      button[ii].setAttribute('data-key',ii);
      button[ii].onclick = function() {
        var j = this.getAttribute("data-key");
        dataview.setColumns([0,parseInt(j)]);
        chart.draw(dataview, options);

        /* Ajax load - replaced by dataview
        var xmlhttp;
        if (window.XMLHttpRequest) { // code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        }
        else { // code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function() {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

                // data is here
                if((xmlhttp.responseText != '')) {
                  var values = xmlhttp.responseText.split(',');
                  var i,value;

                  newdata = new google.visualization.DataTable();
                  newdata.addColumn('datetime', 'Time');
                  newdata.addColumn('number', variables[localkey]);


                  for(i = 0; i < values.length; ++i) {
                    value = values[i].split('|');
                    newdata.addRow([new Date(value[0]), parseFloat(value[1]) ]);
                    chart.draw(newdata, options);
                  }
                }
                
            }
        }

        xmlhttp.open("GET", pullDataUrl + '?var=' + localkey, true);
        xmlhttp.send(); */
      }
    }
    ii=ii+1; //increment ii
  }
}

