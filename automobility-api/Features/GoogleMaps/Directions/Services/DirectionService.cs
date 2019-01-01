using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using automobility_api.Features.GoogleMaps.Directions.Models;
using automobility_api.Features.GoogleMaps.Directions.Models.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace automobility_api.Features.GoogleMaps.Directions.Services
{
    public class DirectionService : IDirectionService
    {
        private const string ApiUrl = "https://maps.googleapis.com/maps/api/directions/json?";

        public DirectionResponseDTO GetDirection(Location location)
        {
            var requestString = this.BuildRequestString(location);

            var requestMessage = this.BuildRequestMessage(requestString);

            var responseMessage = this.SendRequest(requestMessage);

            var response = this.ParseResponse(responseMessage);

            return response;
        }

        private string BuildRequestString(Location location) 
        {
            var origin = HttpUtility.UrlEncode(location.Origin);
            var destination = HttpUtility.UrlEncode(location.Destination);

            return $"origin={origin}&destination={destination}&key=AIzaSyDw0JGrFo95wDD_kIxumP9KByo67I1Pzh8";
        }
    
        private HttpRequestMessage BuildRequestMessage(string requestString)
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new System.Uri($"{ApiUrl}{requestString}")
            };

            return requestMessage;
        }
    
        private HttpResponseMessage SendRequest(HttpRequestMessage requestMessage)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var result = client.SendAsync(requestMessage).Result;

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while sending the request to Google Maps. Error: {ex.Message}", ex);
            }
        }
    
        private DirectionResponseDTO ParseResponse(HttpResponseMessage responseMessage)
        {
            try
            {
                var responseString = responseMessage.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<DirectionResponseDTO>(responseString);
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred while parsing the response from Google Maps. Error: {ex.Message}", ex);
            }
        }
    }
}