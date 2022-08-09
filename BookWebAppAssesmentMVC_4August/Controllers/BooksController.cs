using BookWebAppAssesmentMVC_4August.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookWebAppAssesmentMVC_4August.Controllers
{
    public class BooksController : Controller
    {

        
        
        Uri baseAddress = new Uri("https://localhost:7054/api");

        HttpClient httpClient = new HttpClient();
        public BooksController()
        {
            httpClient.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<Books> book = new List<Books>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Books").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                book = JsonConvert.DeserializeObject<List<Books>>(data);
            }
            return View(book);
        }


        public IActionResult AddNewBook()
        {
            return View();
        }

       // POST: BooksController/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public IActionResult AddNewBook(Books book)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage();
                var data = JsonConvert.SerializeObject(book);
                var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(baseAddress + "/Books", contentData).Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Content("ohhh");
            }
        }
        
       
        [HttpGet("ID")]
        public IActionResult DeleteBook(int ID)
        {
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(baseAddress + $"/Books/" + ID).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));

        }


        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            //Books book = new Books();
            HttpResponseMessage response = httpClient.GetAsync(baseAddress + $"/Books/id?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Books books = JsonConvert.DeserializeObject<Books>(data);
                return View(books);
            }

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBook(Books book)
        {
            try
            {

                string stringData = JsonConvert.SerializeObject(book);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PutAsync(baseAddress + "/Books/" + book.ID.ToString(), contentData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return RedirectToAction(nameof(UpdateBook));
                }


            }
            catch
            {
                return RedirectToAction(nameof(UpdateBook));

            }
           
            
        }


        
        [HttpGet]
        public ActionResult Details(int id)
        {

            HttpResponseMessage response = httpClient.GetAsync(baseAddress + "/Books/id?id=" + id).Result;
            string data = response.Content.ReadAsStringAsync().Result;
            Books book = JsonConvert.DeserializeObject<Books>(data);
            return View(book);
            
            
        }
        
        [HttpPost]
        public ActionResult Search(string searchString)
        {
            List<Books> books = new List<Books>();
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Books/" + searchString).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Books>>(data);
            }
            return View("Index", books);
        }

        public ActionResult Cart()
        {
            return View();
        }

    }
}

