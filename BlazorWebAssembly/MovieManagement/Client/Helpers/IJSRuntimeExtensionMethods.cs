using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        /// <summary>
        /// Js confirm Funktion
        /// </summary>
        /// <param name="js"></param>
        /// <param name="message">Meldung die bei der Bestätigung angezeigt werden soll</param>
        /// <returns></returns>
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            return await js.InvokeAsync<bool>("confirm", message);
        }

        /// <summary>
        /// JS consolelog Funktion
        /// </summary>
        /// <param name="js"></param>
        /// <param name="message">Meldung die gelogt werden soll</param>
        /// <returns></returns>
        public static async ValueTask ConsoleLog(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("consoleLog", message);
        }
    }
}
