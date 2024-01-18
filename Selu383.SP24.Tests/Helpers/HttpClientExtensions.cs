using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Selu383.SP24.Tests.Helpers;

public static class HttpClientExtensions
{
    public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
    {
        var dataAsString = JsonConvert.SerializeObject(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return httpClient.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJsonAsync<T>(this HttpClient httpClient, string url, T data)
    {
        var dataAsString = JsonConvert.SerializeObject(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return httpClient.PutAsync(url, content);
    }

    public static async Task<T?> ReadAsJsonAsync<T>(this HttpContent content)
    {
        var dataAsString = await content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<T?>(dataAsString);
    }
}
