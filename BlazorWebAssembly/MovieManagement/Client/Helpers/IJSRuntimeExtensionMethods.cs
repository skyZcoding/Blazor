using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string message)
        {
            return await js.InvokeAsync<bool>("confirm", message);
        }

        public static async ValueTask ConsoleLog(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("consoleLog", message);
        }
    }
}
