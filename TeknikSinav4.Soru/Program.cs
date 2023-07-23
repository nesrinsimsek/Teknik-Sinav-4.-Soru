/* bu program url'den json formatında veri çekerek objelere çevirir ve objelerin özelliklerini ekrana basar */

using System.Net.Http.Headers;

string URL = "https://gorest.co.in/public/v2/users";

HttpClient client = new HttpClient();
client.BaseAddress = new Uri(URL);

// json formatında accept header ekliyor
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = client.GetAsync("").Result;  
if (response.IsSuccessStatusCode)
{
    // response'u Person tipinde bir liste olarak çekiyor
    var personList = response.Content.ReadAsAsync<IEnumerable<Person>>().Result;
    // tüm objelerin özelliklerini ekrana basıyor
    foreach (var person in personList)
    {
        Console.WriteLine("ID: " + person.id);
        Console.WriteLine("Name: " + person.name);
        Console.WriteLine("Email: " + person.email);
        Console.WriteLine("Gender: " + person.gender);
        Console.WriteLine("Status: " + person.status + "\n");
    }
}

// objelerin türetildiği class
public class Person
{
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string gender { get; set; }
    public string status { get; set; }
}
