# WeatherGetter
(Project for WSEI) Weather Getter allows you to get real-time info about the current weather in a choosen city and also get a real-time forecast for the next day.

**Available functions description:**

## WeatherAPI.GetWeatherAsync(string \<city name\>)
It takes city name as a param and sets *WeatherAPI.wc* to store current weather in a choosen city.

If there was an error while fetching the weather (no such city or no connection to the server) it sets *WeatherAPI.requestSuccesfull* to false, otherwise sets it to true.

Ideally every city should have been searched by its english name - national names of foreign cities may not always be found.
For example:
- New York -> Request succesfull there is pretty big city with this name
- Nowy Jork (in Polish) -> Request failed cause there is no such city

But it isn't always true - for bigger cities Warszawa and Warsaw is going to work fine.

## WeatherAPI.GetWeatherForecastAsync()
Sets *WeatherAPI.wcf* to store current weather forecast for the next day.

It **requires** *WeatherAPI.wc* to be set so *WeatherAPI.GetWeatherAsync()* always needs to be invoked with a choosen city name before you invoke this function.

If there was an error while fetching the weather it sets *WeatherAPI.requestSuccesfull* to false, otherwise sets it to true.

## WeatherAPI.DisplayCurrentWeather()
Prints current weather information to the console.

It **requires** *WeatherAPI.wc* to be set so *WeatherAPI.GetWeatherAsync()* always needs to be invoked with a choosen city name before you invoke this function.

## WeatherAPI.DisplayForecastWeather()
Prints current weather forecast for tommorow to the console.

It **requires** *WeatherAPI.wcf* to be set so *WeatherAPI.GetWeatherForecastAsync()* always needs to be invoked before you invoke this function.
