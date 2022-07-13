var longitude
var latitude

$(document).ready(function () {
    $("#cities button:first-child").trigger("click")
});

function loadData(city) {


    $.ajax({
        type: "GET",
        url: "/Home/LoadWeather",
        data: {
            'city': city
        },
        success: function (result) {
            $('#weather_data span').empty()
            $('#location').text(result.name + " ( " + result.coord.lon + ", " + result.coord.lat + " )")
            $('#time').text(new Date(result.dt * 1000).toLocaleDateString("en-GB") + " " + new Date(result.dt * 1000).toLocaleTimeString("en-GB") + " UTC")
            $('#sunrise').text(new Date(result.sys.sunrise * 1000).toLocaleDateString("en-GB") + " " + new Date(result.sys.sunrise * 1000).toLocaleTimeString("en-GB") + " UTC")
            $('#sunset').text(new Date(result.sys.sunset * 1000).toLocaleDateString("en-GB") + " " + new Date(result.sys.sunset * 1000).toLocaleTimeString("en-GB") + " UTC")
            $('#weather').text(result.weather[0].main + " ( " + result.weather[0].description + " )")
            $('#temperature').text(Math.round((result.main.temp - 273.15)) + "°C")
            $('#wind').text(Math.round(result.wind.speed * 3.6) + "km/h ( " + result.wind.deg + "° )")
            $('#humidity').text(result.main.humidity + "%")
            $('#pressure').text(result.main.pressure + " hPa")
            longitude = result.coord.lon.toString()
            latitude = result.coord.lat.toString()
            loadAirPollution()
        }
    });

    $.ajax({
        type: "GET",
        url: "/Home/LoadForecast",
        data: {
            'city': city
        },
        success: function (result) {
            $('#forecast_body').empty()
            result.list.forEach(element =>
                $('#forecast_body').append("<tr>"
                    + "<td>" + element.dt_txt + "</td>"
                    + "<td > " + Math.round((element.main.temp - 273.15)) + "°C</td>"
                    + "<td > " + element.weather[0].main + " ( " + element.weather[0].description + " )</td>"
                    + "<td > " + element.main.humidity + "%</td>"
                    + "<td > " + element.main.pressure + " hPa</td>"
                    + "<td > " + Math.round(element.wind.speed * 3.6) + "km/h ( " + element.wind.deg + "° )</td>"
                    + "</tr>")
            );
        }
    });


}

function loadAirPollution() {
    $.ajax({
        type: "GET",
        url: "/Home/LoadAirPollution",
        data: {
            lon: longitude, lat: latitude
        },
        success: function (result) {
            $('#air_polution_data span').empty()
            $('#CO').text(result.list[0].components.co + " μg/m3")
            $('#NO').text(result.list[0].components.no + " μg/m3")
            $('#NO2').text(result.list[0].components.no2 + " μg/m3")
            $('#O3').text(result.list[0].components.o3 + " μg/m3")
            $('#SO2').text(result.list[0].components.so2 + " μg/m3")
            $('#PM2_5').text(result.list[0].components.pm2_5 + " μg/m3")
            $('#PM10').text(result.list[0].components.pm10 + " μg/m3")
            $('#NH3').text(result.list[0].components.nh3 + " μg/m3")
            $('#quality').text(result.list[0].main.aqi)
        }
    });
}
