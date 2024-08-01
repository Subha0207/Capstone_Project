// const apiKey = '560ebb85ebc34726b89ebc6102628531'; // Replace with your OpenCage API key

// document.getElementById('find-location-btn').addEventListener('click', () => {
//     if (navigator.geolocation) {
//         navigator.geolocation.getCurrentPosition(showPosition, handleGeolocationError);
//     } else {
//         alert('Geolocation is not supported by this browser.');
//     }
// });

// function showPosition(position) {
//     const latitude = position.coords.latitude;
//     const longitude = position.coords.longitude;

//     // Call the reverse geocoding API to get the place name
//     const apiUrl = `https://api.opencagedata.com/geocode/v1/json?q=${latitude},${longitude}&key=${apiKey}`;

//     fetch(apiUrl)
//         .then(response => response.json())
//         .then(data => {
//             if (data.results && data.results.length > 0) {
//                 const result = data.results[0].components;
//                 const district = result.suburb || result.town || result.city || result.county || result.state_district;
//                 const postcode = result.postcode;

//                 if (district && postcode) {
//                     const placeName = `${district}, ${postcode}`;
//                     document.getElementById('location-search').value = placeName;
//                 } else {
//                     alert('District or postcode not found.');
//                 }
//             } else {
//                 alert('Place name not found.');
//             }
//         })
//         .catch(error => {
//             console.error('Error fetching the place name:', error);
//             alert('Error fetching the place name.');
//         });
// }

// function handleGeolocationError(error) {
//     switch (error.code) {
//         case error.PERMISSION_DENIED:
//             alert('User denied the request for Geolocation.');
//             break;
//         case error.POSITION_UNAVAILABLE:
//             alert('Location information is unavailable.');
//             break;
//         case error.TIMEOUT:
//             alert('The request to get user location timed out.');
//             break;
//         case error.UNKNOWN_ERROR:
//             alert('An unknown error occurred.');
//             break;
//     }
// }

// document.addEventListener('DOMContentLoaded', function () {
//     const locationInput = document.getElementById('location-search');
//     const suggestionsContainer = document.getElementById('suggestions');

//     locationInput.addEventListener('input', function () {
//         const query = locationInput.value.trim();

//         // Clear previous suggestions
//         suggestionsContainer.innerHTML = '';

//         if (query.length > 0) {
//             // Fetch suggestions from OpenCage API
//             const apiUrl = `https://api.opencagedata.com/geocode/v1/json?q=${encodeURIComponent(query)}&key=${apiKey}`;

//             fetch(apiUrl)
//                 .then(response => response.json())
//                 .then(data => {
//                     if (data.results && data.results.length > 0) {
//                         data.results.forEach(result => {
//                             const div = document.createElement('div');
//                             div.classList.add('suggestion-item');
//                             div.textContent = result.formatted;
//                             div.addEventListener('click', function () {
//                                 locationInput.value = result.formatted;
//                                 suggestionsContainer.innerHTML = ''; // Clear suggestions
//                             });
//                             suggestionsContainer.appendChild(div);
//                         });
//                     }
//                 })
//                 .catch(error => {
//                     console.error('Error fetching suggestions:', error);
//                 });
//         }
//     });

//     // Close suggestions container when clicking outside
//     document.addEventListener('click', function (event) {
//         if (!event.target.closest('.location-search-container')) {
//             suggestionsContainer.innerHTML = '';
//         }
//     });
// });
const apiKey = '560ebb85ebc34726b89ebc6102628531';

document.getElementById('find-location-btn').addEventListener('click', () => {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition, handleGeolocationError);
    } else {
        alert('Geolocation is not supported by this browser.');
    }
});

function showPosition(position) {
    const latitude = position.coords.latitude;
    const longitude = position.coords.longitude;

    // Call the reverse geocoding API to get the place name
    const apiUrl = `https://api.opencagedata.com/geocode/v1/json?q=${latitude}+${longitude}&key=${apiKey}`;

    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            if (data.results && data.results.length > 0) {
                const result = data.results[0].components;
                const district = result.suburb || result.town || result.city || result.county || result.state_district;
                const postcode = result.postcode;

                if (district && postcode) {
                    const placeName = `${district}, ${postcode}`;
                    document.getElementById('location-search').value = placeName;
                } else {
                    alert('District or postcode not found.');
                }
            } else {
                alert('Place name not found.');
            }
        })
        .catch(error => {
            console.error('Error fetching the place name:', error);
            alert('Error fetching the place name.');
        });
}

function handleGeolocationError(error) {
    switch (error.code) {
        case error.PERMISSION_DENIED:
            alert('User denied the request for Geolocation.');
            break;
        case error.POSITION_UNAVAILABLE:
            alert('Location information is unavailable.');
            break;
        case error.TIMEOUT:
            alert('The request to get user location timed out.');
            break;
        case error.UNKNOWN_ERROR:
            alert('An unknown error occurred.');
            break;
    }
}

document.addEventListener('DOMContentLoaded', function () {
    const locationInput = document.getElementById('location-search');
    const suggestionsContainer = document.getElementById('suggestions');

    locationInput.addEventListener('input', function () {
        const query = locationInput.value.trim();

        // Clear previous suggestions
        suggestionsContainer.innerHTML = '';

        if (query.length > 0) {
            // Fetch suggestions from OpenCage API
            const apiUrl = `https://api.opencagedata.com/geocode/v1/json?q=${encodeURIComponent(query)}&key=${apiKey}`;

            fetch(apiUrl)
                .then(response => response.json())
                .then(data => {
                    if (data.results && data.results.length > 0) {
                        data.results.forEach(result => {
                            const div = document.createElement('div');
                            div.classList.add('suggestion-item');
                            div.textContent = result.formatted;
                            div.addEventListener('click', function () {
                                locationInput.value = result.formatted;
                                suggestionsContainer.innerHTML = ''; // Clear suggestions
                            });
                            suggestionsContainer.appendChild(div);
                        });
                    }
                })
                .catch(error => {
                    console.error('Error fetching suggestions:', error);
                });
        }
    });

    // Close suggestions container when clicking outside
    document.addEventListener('click', function (event) {
        if (!event.target.closest('.location-search-container')) {
            suggestionsContainer.innerHTML = '';
        }
    });
});
