using Microsoft.AspNetCore.Mvc;
using AdvancedDatabase_Lab4.Data;
using AdvancedDatabase_Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedDatabase_Lab4.Controllers
{
    public class RoomController : Controller
    {
        private readonly HotelMVCAppContext _db;

        public RoomController(HotelMVCAppContext db)
        {
            _db = db;
        }

        // GET: Rooms
        public IActionResult Index()
        {
            if (_db.Room == null)
            {
                return NotFound();
            }
            else
            {
                HashSet<Room> allRooms = _db.Room.ToHashSet();
                return View(allRooms);
            }
        }

        // Create : Room
        public IActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RoomNumber,Capacity,Section")] Room room)
        {
            if (ModelState.IsValid)
            {
                _db.Add(room);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: Room/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room room = _db.Room.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("RoomNumber,Capacity,Section")] Room room)
        {
            if (id != room.RoomNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(room);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.RoomNumber))
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
            return View(room);
        }

        private bool RoomExists(int id)
        {
            return _db.Room.Any(e => e.RoomNumber == id);
        }
    }
}
