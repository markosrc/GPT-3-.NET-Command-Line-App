using System.Text;
using Newtonsoft.Json;


if(args.Length > 0)
{
    HttpClient client = new HttpClient();

    string key = "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"; //https://platform.openai.com/account/api-keys
    client.DefaultRequestHeaders.Add($"authorization", "Bearer " + key);
    var content = new StringContent("{\"model\": \"text-davinci-001\", \"prompt\": \""+ args[0] +"\",\"temperature\": 1,\"max_tokens\": 100}", Encoding.UTF8, "application/json");

    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);

    string responseString = await response.Content.ReadAsStringAsync();

    //Console.WriteLine(responseString);
    
 try
    {
        var dynamicObj = JsonConvert.DeserializeObject<dynamic>(responseString);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"---> API response: {dynamicObj!.choices[0].text}");
        Console.ResetColor();
    }
    catch(Exception ex)
    {
        Console.WriteLine($"---> deserializing JSON failed: {ex.Message}");
    }

}
else
{
    Console.WriteLine("---> You need to provide input");
}
