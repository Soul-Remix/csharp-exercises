using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WebAPIClient;
class MyProgram
{
    static async Task Main()
    {
        var repos = await MakeRequest();

        foreach (var repo in repos)
        {
            Console.WriteLine(repo.Name);
            Console.WriteLine(repo.Description);
            Console.WriteLine(repo.GitHubHomeUrl);
            Console.WriteLine(repo.Homepage);
            Console.WriteLine(repo.Watchers);
            Console.WriteLine(repo.LastPush);
            Console.WriteLine();
        }
    }

    private static async Task<List<ApiResponse>> MakeRequest()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        var req = await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        var json = await JsonSerializer.DeserializeAsync<List<ApiResponse>>(req);

        return json;
    }
}