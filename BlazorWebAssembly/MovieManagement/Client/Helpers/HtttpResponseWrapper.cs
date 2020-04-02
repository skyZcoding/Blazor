using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieManagement.Client.Helpers
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool success, HttpResponseMessage httpResponseMessage)
        {
            Success = success;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        /// <summary>
        /// Gibt zurück ob die Request erfolgreich war
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gibt den das Objekt welches man von der Request erhalten hat zurück
        /// </summary>
        public T Response { get; set; }

        /// <summary>
        /// Beinhaltet den Status Code etc. von der Response
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }

        /// <summary>
        /// Holt den Inhalt von der HttpResponseMessage
        /// </summary>
        /// <returns>Gibt den Inhalt zurück</returns>
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}
