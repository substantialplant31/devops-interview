using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using BradyWeather.Application.UseCases.Weather.Models;
using BradyWeather.Application.UseCases.Weather.Handlers;
using BradyWeather.Application.Interfaces;
using Moq;
using BradyWeather.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit;
using NUnit.Framework;

namespace BradyWeather.TestService
{
    public class Tests
    {
        private Mock<IWeatherClient> _weatherClient;
        private Mock<IOptionsMonitor<WeatherSettings>> _weatherSettings;
        private Mock<ILogger<GetLocationsSearchHandler>> _logger;
        private Mock<ILogger<GetWeatherForecastHandler>> _logger1;


        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<GetLocationsSearchHandler>>();
            _logger1 = new Mock<ILogger<GetWeatherForecastHandler>>();

            _weatherClient = new Mock<IWeatherClient>();

        }

        [Test]
        public void Check_GetLocationName()
        {
            WeatherMonitor obj = new WeatherMonitor(new WeatherSettings { ApiKey = "sdfsdfsdf" });


            var service = new GetLocationsSearchHandler(_logger.Object, _weatherClient.Object, obj);

            GetLocationsByTextRequest request = new GetLocationsByTextRequest() { Search = "London" };

            var testResult = service.Handle(request, CancellationToken.None);

            Assert.AreEqual(0, testResult.Result.Length);

            //Assert.Pass();
        }

        [Test]
        public void Check_GetWeather()
        {
            WeatherMonitor obj = new WeatherMonitor(new WeatherSettings { ApiKey = "sdfsdfsdf" });

            var service = new GetWeatherForecastHandler(_logger1.Object, _weatherClient.Object, obj);

            GetWeatherForecastRequest request = new GetWeatherForecastRequest();

            var testResult = service.Handle(request, CancellationToken.None);

            Assert.AreEqual(0, testResult.Result.Pressure);
        }
    }

    public class WeatherMonitor : IOptionsMonitor<WeatherSettings>
    {
        public WeatherMonitor(WeatherSettings currentValue)
        {
            CurrentValue = currentValue;
        }

        public WeatherSettings Get(string name)
        {
            return CurrentValue;
        }

        public IDisposable OnChange(Action<WeatherSettings, string> listener)
        {
            throw new NotImplementedException();
        }

        public WeatherSettings CurrentValue { get; }
    }
}