using Application.Interfaces.Services;
using Domain.Entities;
using Infrastructure.MessageQueue;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.ExternalServices.OpenStreetMaps
{
    public class OpenStreetMapService : IGeoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public OpenStreetMapService(ILogger<OpenStreetMapService> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("andrani", "1.0"));
            _logger = logger;
        }
        public async Task<GeoResponseMessage> CompleteCoordinatesAsync(GeoRequestMessage request)
        {
            var builder = new UriBuilder(@"https://nominatim.openstreetmap.org/search");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["street"] = request.Street + " " + request.Number;
            query["city"] = request.City;
            query["country"] = request.Country;
            query["postalcode"] = request.PostalCode;
            query["state"] = request.State;
            query["format"] = "json";
            builder.Query = query.ToString();
            string url = builder.ToString();
            var call = await _httpClient.GetAsync(url);
            var res = await call.Content.ReadAsStringAsync();

            _logger.LogWarning(res);

            OpenStreetMapsResponse res2 = JsonSerializer.Deserialize<List<OpenStreetMapsResponse>>(res)[0];

            GeoResponseMessage result = new GeoResponseMessage()
            {
                Id = request.Id,
                Latitude = res2.Latitude,
                Longitude = res2.Longitude
            };



            return result;
        }
    }
}
