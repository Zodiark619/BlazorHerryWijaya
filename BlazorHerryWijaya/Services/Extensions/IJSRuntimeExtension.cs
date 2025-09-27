using Microsoft.JSInterop;

namespace BlazorHerryWijaya.Services.Extensions
{
    public static class IJSRuntimeExtension
    {
        public static async Task ToastrSuccess(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("ShowToastr", "success", message);
        }
        public static async Task ToastrError(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("ShowToastr", "error", message);
        }
        public static async Task InitDataTable(this IJSRuntime js, string tableId)
        {
            await js.InvokeVoidAsync("DataTableInterop.init",  tableId);
        }




    }
}
