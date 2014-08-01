window.onload  = initSite;
var map = null;
var pins = {};
var infoWindow = {};

// Initialize site
function initSite() {

	console.log('init');
	var element =  document.getElementById('map-canvas');
	if (typeof(element) != 'undefined' && element != null)
	{
	  // Map exists.
	  gmLoadScript();
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

  var zoomlevel = 4;
  var initLat = 68.05660;
  var initLon = -1;


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
  var styling = [
  	{
		"featureType": "landscape",
		"stylers": 
			[ 
			{ "color": "#B1132F" }
			] 
	},
	{	
		"featureType": "water",
		"stylers": 
			[ 
			{ "color": "#850E23" }
			] 
		
	},
	{ 	
		"featureType": "poi", 
		"stylers":
			[ 
			{ "visibility": "off" },
			/* {"color": "#b1132f" },
			{ "saturation": 56 },
			{ "lightness": -14} */ 
			]
	},
	{ 	
		"featureType": "transit.station.airport",
		"stylers":
			[
			{ "color": "#ff8c89" },
			{ "gamma": 0.33 },
			{ "lightness": -1 },
			{ "saturation": -19 }
			]
	},
  ]
  
  // Set styling
  map.setOptions({styles: styling});
  
  
  // Define markers and circles based on data
  var pinImage = 'pin.png';
  
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