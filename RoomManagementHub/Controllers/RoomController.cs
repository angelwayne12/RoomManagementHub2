using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoomManagementHub.Models;
using System.Text;

namespace RoomManagementHub.Controllers
{
    public class RoomController : Controller
    {
        // GET: RoomController
        public async Task<ActionResult> Index()
        {
            string apiUrl = "https://localhost:7082/api/rooms";

            List<Room> rooms = new List<Room>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                var result = await response.Content.ReadAsStringAsync();
                rooms = JsonConvert.DeserializeObject<List<Room>>(result);
            }

            return View(rooms);
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Room room)
        {
            string apiUrl = "https://localhost:7082/api/rooms";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(room);
        }


        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
