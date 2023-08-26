using Microsoft.JSInterop;

namespace BlazorFirstServerApp.Utils
{
    public static class FileUtils
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>(
                "saveAsFile",
                filename,
                Convert.ToBase64String(data));
    }
}
