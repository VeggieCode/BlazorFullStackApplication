using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWebAssemblyCrud.Client.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        //Se necesita encapsular los registros obtenidos del indexDB en una clase
        public static async ValueTask<RegistersDBLocal> GetPendingRegister(this IJSRuntime js)
        {
            return await js.InvokeAsync<RegistersDBLocal>("getPendingRegisters");
        }

        public static async ValueTask<int> GetPendingRegistersCount(this IJSRuntime js)
        {
            return await js.InvokeAsync<int>("getPendingRegistersCount");
        }
        public static async ValueTask DeleteRegister(this IJSRuntime js, string table, int id)
        {
            await js.InvokeVoidAsync("deleteRegister", table, id);
        }

        public static async ValueTask SaveRegisterForCreate<T>(this IJSRuntime js, string url, T entity)
        {
            var body = JsonSerializer.Serialize(entity);
            await js.InvokeVoidAsync("saveRegisterForCreate", url, body);
        }

        public static async ValueTask SaveRegisterForUpdate<T>(this IJSRuntime js, string url, T entity)
        {
            var body = JsonSerializer.Serialize(entity);
            await js.InvokeVoidAsync("saveRegisterForUpdate", url, body);
        }
        public static async ValueTask SaveRegisterForDelete(this IJSRuntime js, string url)
        {
            await js.InvokeVoidAsync("saveRegisterForDelete", url);
        }


    }
}
