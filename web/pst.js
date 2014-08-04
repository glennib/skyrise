window.onload  = initSite;
var map = null; // For map
var chart = null; // For chart
var dataview = null; // data overlay for charts
var data = null; // data for chart
var pins = {};
var infoWindow = {};
var button = {};


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
  var pinImage = '//skyrise.hit.no/wp-content/plugins/pst/pin.png';
  
  var i = 0;
  for (var site in sites) {
  
	  // Set options
  	  var centerLatLon = new google.maps.LatLng(sites[i].lat, sites[i].lon);
  
	  var pinOptions = {
		  map: map,
		  icon: pinImage,
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

  // Create the data table.
  data = new google.visualization.DataTable();
  data.addColumn('datetime', 'Time');
  data.addColumn('number', 'Altitude');
  data.addColumn('number', 'TempOut');
  
  // Add each row
  for (i = 0; i < psttimes.length; i++) { 
	data.addRow([new Date(psttimes[i]), pstalts[i], psttempouts[i]]);
  }

  
  // DataView
  dataview = new google.visualization.DataView(data)
  dataview.setColumns([0,1]);
  
  // Set chart options
  var options = {'title':'Altitude',
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
  
  // Buttons for changing values
  button[1] = document.getElementById('button1');
  button[1].onclick = function() {
    dataview.setColumns([0,1]);
    chart.draw(dataview, options);
  }
  
  button[2] = document.getElementById('button2');
  button[2].onclick = function() {
    dataview.setColumns([0,2]);
    chart.draw(dataview, options);
  }
  
}

