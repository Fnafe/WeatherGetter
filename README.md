# WeatherGetter
(Project for WSEI) Weather Getter allows you to get real-time info about the current weather in a choosen city and also get a real-time forecast for the next day.

**Available functions description:**
___
## WeatherAPI.GetWeatherAsync(string \<city name\>)
It takes city name as a param and sets *WeatherAPI.wc* to store current weather in a choosen city.

If there was an error while fetching the weather (no such city or no connection to the server) it sets *WeatherAPI.requestSuccesfull* to false, otherwise sets it to true.

Ideally every city should have been searched by its english name - national names of foreign cities may not always be found.
For example:
- New York -> Request succesfull there is pretty big city with this name
- Nowy Jork (in Polish) -> Request failed cause there is no such city

But it isn't always true - for bigger cities Warszawa and Warsow is going to work fine.
___
## WeatherAPI.GetWeatherForecastAsync()
It **requires** *WeatherAPI.wc* to be set so *WeatherAPI.GetWeatherAsync()* always needs to be invoked with a choosen city name before you invoke this function.

Sets *WeatherAPI.wcf* to store current weather forecast for the next day.

If there was an error while fetching the weather it sets *WeatherAPI.requestSuccesfull* to false, otherwise sets it to true.
