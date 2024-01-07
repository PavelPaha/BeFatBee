namespace BeeFat;

using Microsoft.JSInterop;
using System.Threading.Tasks;

public class BrowserService
{
    private readonly IJSRuntime _js;

    public BrowserService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<BrowserDimension> GetDimensions()
    {
        return await _js.InvokeAsync<BrowserDimension>("getDimensions");
    }
    
    public async Task<int> GetElemWidth()
    {
        return await _js.InvokeAsync<int>("getProgressBarWidth");
    }
}

public class BrowserDimension
{
    public int Width { get; set; }
    public int Height { get; set; }
}