using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace AuthorApiTests
{
    public class AuthorApiTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("http://localhost:5002/");
        }

        [Test]
        public async Task CreateAuthor_ShouldReturn201()
        {
            // יצירת אובייקט JSON לבקשה
            var author = new
            {
                id = "sdjk",
                first = "John",
                last = "Doe",
                email = "orl.malik@gmail.com",
                birth = "01-01-2001",
                contents = new string[] { }
            };

            var content = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");

            // יצירת URL באמצעות UriBuilder
            var uriBuilder = new UriBuilder(_client.BaseAddress)
            {
                Path = "author"
            };

            // שליחה של בקשת POST
            var response = await _client.PostAsync(uriBuilder.Uri, content);

            // לוודא שהתשובה היא 201 Created
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
        }

        [Test]
        public async Task GetAuthorByEmail_ShouldReturn200()
        {
            // יצירת URL באמצעות UriBuilder עבור GET לפי email
            var uriBuilder = new UriBuilder(_client.BaseAddress)
            {
                Path = "author",
                Query = "type=email&value=john.doe@example.com"
            };

            // שליחה של בקשת GET
            var response = await _client.GetAsync(uriBuilder.Uri);

            // לוודא שהתשובה היא 200 OK
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task GetAuthorByFirstName_ShouldReturn200()
        {
            // יצירת URL באמצעות UriBuilder עבור GET לפי שם פרטי
            var uriBuilder = new UriBuilder(_client.BaseAddress)
            {
                Path = "author",
                Query = "type=first&value=John"
            };

            // שליחה של בקשת GET
            var response = await _client.GetAsync(uriBuilder.Uri);

            // לוודא שהתשובה היא 200 OK
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task GetAuthorByBirthDate_ShouldReturn200()
        {
            // יצירת URL באמצעות UriBuilder עבור GET לפי תאריך לידה
            var uriBuilder = new UriBuilder(_client.BaseAddress)
            {
                Path = "author",
                Query = "type=birth&value=01-01-2001"
            };

            // שליחה של בקשת GET
            var response = await _client.GetAsync(uriBuilder.Uri);

            // לוודא שהתשובה היא 200 OK
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }

        [Test]
        public async Task DeleteAuthor_ShouldReturn405()
        {
            // יצירת URL באמצעות UriBuilder עבור DELETE
            var uriBuilder = new UriBuilder(_client.BaseAddress)
            {
                Path = "author"
            };

            // שליחה של בקשת DELETE (בהנחה שאין תמיכה ב-DELETE)
            var response = await _client.DeleteAsync(uriBuilder.Uri);

            // לוודא שהתשובה היא 405 Method Not Allowed (אם אין תמיכה ב-DELETE)
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.MethodNotAllowed));
        }

        [TearDown]
        public void TearDown()
        {
            
            _client.Dispose();
        }
    }
}
