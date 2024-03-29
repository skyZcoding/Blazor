﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieManagement.Client.Helpers
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient httpClient;
        private JsonSerializerOptions defaultJsonSerialzierOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public HttpService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Macht eine Get request an den gewünschten Controller
        /// </summary>
        /// <typeparam name="T">Datentyp von dem Objekt</typeparam>
        /// <param name="url">URL von dem Controller</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            HttpResponseMessage responseHTTP = await httpClient.GetAsync(url);

            if (responseHTTP.IsSuccessStatusCode)
            {
                T response = await Deserialize<T>(responseHTTP, defaultJsonSerialzierOptions);

                return new HttpResponseWrapper<T>(response, true, responseHTTP);
            }

            return new HttpResponseWrapper<T>(default, false, responseHTTP);
        }

        /// <summary>
        /// Macht Delete request an den gewünschten Controller
        /// </summary>
        /// <param name="url">URL von dem Controller</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            var response = await httpClient.DeleteAsync(url);

            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        /// <summary>
        /// Macht eine Put Request an den gewünschten Controller
        /// </summary>
        /// <typeparam name="T">Datentyp von dem Objekt</typeparam>
        /// <param name="url">URL von dem Controller</param>
        /// <param name="data">Das Objekt für die Put Request</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<object>> Put<T>(string url, T data)
        {
            string dataJson = JsonSerializer.Serialize(data);
            StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, stringContent);

            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        /// <summary>
        /// Macht eine Post Request an den gewünschten Controller
        /// </summary>
        /// <typeparam name="T">Datentyp von dem Objekt</typeparam>
        /// <param name="url">URL von dem Controller</param>
        /// <param name="data">Das Objekt für die Post Request</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<object>> Post<T>(string url, T data)
        {
            string dataJson = JsonSerializer.Serialize(data);
            StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, stringContent);

            return new HttpResponseWrapper<object>(null, response.IsSuccessStatusCode, response);
        }

        /// <summary>
        /// Macht eine Post Request an den gewünschten Controller
        /// </summary>
        /// <typeparam name="T">Datentyp von dem Objekt</typeparam>
        /// <typeparam name="TResponse">Datentyp von dem zurückbekommenen Objekt</typeparam>
        /// <param name="url">URL von dem Controller</param>
        /// <param name="data">Das Objekt für die Post Request</param>
        /// <returns></returns>
        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            string dataJson = JsonSerializer.Serialize(data);
            StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent);

            if (response.IsSuccessStatusCode)
            {
                TResponse responseDeserialized = await Deserialize<TResponse>(response, defaultJsonSerialzierOptions);

                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            }

            return new HttpResponseWrapper<TResponse>(default, response.IsSuccessStatusCode, response);
        }

        /// <summary>
        /// Deserialisiert das bekommene Objekt
        /// </summary>
        /// <typeparam name="T">Datentyp von dem Objekt</typeparam>
        /// <param name="httpResponse">Enthält das Objekt</param>
        /// <param name="options">JsonSerializerOptions welche gesetzt werden z.B. PropertyNameCaseInsensitive</param>
        /// <returns></returns>
        public async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            string responseString = await httpResponse.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(responseString, options);
        }
    }
}
