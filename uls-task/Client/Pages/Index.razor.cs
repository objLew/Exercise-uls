using System.Net;

namespace uls_task.Client.Pages
{
    public partial class Index
    {
        string input = "";
        string result = "";

        HttpClient client = new HttpClient();

        bool error = false;

        protected override void OnInitialized()
        {
            client.DefaultRequestHeaders.Add("ShhhhThisIsASecret", "secret");
        }

        private async Task GetValue()
        {


            string getWhiteboardURL = $"https://localhost:7152/api/calculator/CalculateString?CalculateThis={WebUtility.UrlEncode(input)}";
            var response =
                await client.GetAsync(getWhiteboardURL);

            if (response.IsSuccessStatusCode)
            {
                error = false;

                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                error = true;
            }
        }

    }
}
