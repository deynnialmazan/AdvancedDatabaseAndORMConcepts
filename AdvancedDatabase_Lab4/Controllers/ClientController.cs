using Microsoft.AspNetCore.Mvc;
using AdvancedDatabase_Lab4.Data;
using AdvancedDatabase_Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedDatabase_Lab4.Controllers
{
    public class ClientController : Controller
    {
        private readonly HotelMVCAppContext _db;

        // Injecting the context
        public ClientController(HotelMVCAppContext db)
        {
            _db = db;
        }

        // GET: Clients
        public IActionResult Index()
        {
            if (_db.Client == null)
            {
                return NotFound();
            }
            else
            {
                HashSet<Client> allClients = _db.Client.ToHashSet();
                return View(allClients);
            }
        }

        // Create GET: Client
        // GET method returns HTML
        public IActionResult Create()
        {
            return View();
        }

        // Create POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName, LastName, PhoneNumber")] Client client)
        {
            // ModelState: Validation in the server side
            if (ModelState.IsValid)
            {
                _db.Add(client);
                 _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client client = _db.Client.Find(id);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Client/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(client);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        private bool ClientExists(int id)
        {
            return _db.Client.Any(c => c.Id == id);
        }
    }
}
