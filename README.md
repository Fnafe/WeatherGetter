# WeatherGetter
(Project for WSEI) Weather Getter allows you to get real-time info about the current weather in a choosen city and also get a real-time forecast for the next day.

**WeatherAPI:**

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

## DisplayErrorMessage()
Writes to the console that there was no city of such name found or there is no connection to the internet.


___
**Controller:**

## Controller.ExecuteUserCommand(string \<command\>)
Takes a full line of a command given by the user and invokes corresponding function.

Example:
jutro Kraków -> Invokes *ShowTommorowWeatherForCity()* with a *Kraków* parameter.

## Controller.ShowHelp()
Writes availeble commands to the console.
Invokes WeatherAPI.GetWeatherAsync()

## ShowCurrentWeatherForCity(string \<city name\>)
Invokes *WeatherAPI.GetWeatherAsync(city name)*, waits for it to finish and if there was no error invokes *WeatherAPI.DisplayCurrentWeather()*.

## ShowCurrentWeatherForCity(string \<city name\>)
Invokes *WeatherAPI.GetWeatherAsync(city name)*, waits for it to finish, if there was no error then invokes *WeatherAPI.GetWeatherForecastAsync()* and if again there was no error invokes *WeatherAPI.DisplayCurrentWeather()*.

## DisplayCommandNotFound()
Writes "Command not found" text in the console.

## ChangeLanguage(string \<language name\>)
Changes language field to the choosen language and by this - changes program output language.


___
**Tutorial:**

## Tutorial.ShowTutorial()
Prints initial tutorial and information about the app to the user.

## PrintSlowly(string \<text\>)
Prints text letter by letter with 30-milisecond interval.


___
**Data-storage Classes:**

## WeatherCity class
Stores information received from the API about the weather in a choosen city.

## WeatherCityForecast class
Stores forecast received from the API for a choosen city
- Tommorow -> Returns *WeatherCity* object filled with weather forecast for the next day (tommorow).


