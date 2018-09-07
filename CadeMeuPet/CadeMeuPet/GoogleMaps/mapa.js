
$(document).ready(function () {

	initialize();
	
	function carregarNoMapa(endereco) {
		geocoder.geocode({ 'address': endereco + ', Brasil', 'region': 'BR' }, function (results, status) {
			if (status == google.maps.GeocoderStatus.OK) {
				if (results[0]) {
				    var latitude = results[0].geometry.location.lat();
				    var longitude = results[0].geometry.location.lng();
		
					$('#Logradouro').val(results[0].formatted_address);
					$('#Latitude').val(latitude);
					$('#Longitude').val(longitude);
		
					var location = new google.maps.LatLng(latitude, longitude );
					marker.setPosition(location);
					map.setCenter(location);
					map.setZoom(16);
				}
			}
		})
	}
	
	$("#btnEndereco").click(function() {
		if($(this).val() != "")
			carregarNoMapa($("#txtEndereco").val());
	})
	
	$("#txtEndereco").blur(function() {
		if($(this).val() != "")
			carregarNoMapa($(this).val());
	})

	$("#Logradouro").blur(function () {
	    if ($(this).val() != "")
	        carregarNoMapa($(this).val());
	})


	
	google.maps.event.addListener(marker, 'drag', function () {
		geocoder.geocode({ 'latLng': marker.getPosition() }, function (results, status) {
			if (status == google.maps.GeocoderStatus.OK) {
			    if (results[0]) {

			        $('#Logradouro').val(results[0].formatted_address);
			        $('#Latitude').val(marker.getPosition().lat());
			        $('#Longitude').val(marker.getPosition().lng());

					$('#txtEndereco').val(results[0].formatted_address);
					$('#txtLatitude').val(marker.getPosition().lat());
					$('#txtLongitude').val(marker.getPosition().lng());
				}
			}
		});
	});
	
	$("#Logradouro").autocomplete({
		source: function (request, response) {
			geocoder.geocode({ 'address': request.term + ', Brasil', 'region': 'BR' }, function (results, status) {
				response($.map(results, function (item) {
					return {
						label: item.formatted_address,
						value: item.formatted_address,
						latitude: item.geometry.location.lat(),
          				longitude: item.geometry.location.lng()
					}
				}));
			})
		},
		select: function (event, ui) {

		    $("#Latitude").val(ui.item.latitude);
		    $("#Longitude").val(ui.item.longitude);

			$("#txtLatitude").val(ui.item.latitude);
    		$("#txtLongitude").val(ui.item.longitude);
			var location = new google.maps.LatLng(ui.item.latitude, ui.item.longitude);
			marker.setPosition(location);
			map.setCenter(location);
			map.setZoom(16);
		}
	});
	
	$("btnEnviar").click(function() {
		
		var endereco = $("#txtEndereco").val();
		var latitude = $("#txtLatitude").val();
		var longitude = $("#txtLongitude").val();
		
		alert("Endereço: " + endereco + "\nLatitude: " + latitude + "\nLongitude: " + longitude);
	});

});