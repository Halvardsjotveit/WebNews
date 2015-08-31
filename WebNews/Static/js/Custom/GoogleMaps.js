var map;

function initMap() {
    var htmlHandle = document.getElementById('map');
    var position = { lat: parseFloat(htmlHandle.dataset.lat), lng: parseFloat(htmlHandle.dataset.lng) };

    map = new google.maps.Map(htmlHandle, {
        center: position,
        zoom: 12
    });
    var marker = new google.maps.Marker({
        position: position,
        map: map,
        title: 'Event Location'
    });

}