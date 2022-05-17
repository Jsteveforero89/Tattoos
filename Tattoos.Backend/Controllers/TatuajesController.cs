using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tattoos.Backend.Models;
using Tattoos.Common.Models;

namespace Tattoos.Backend.Controllers
{
    public class TatuajesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Tatuajes
        public async Task<ActionResult> Index()
        {
            return View(await db.Tatuajes.ToListAsync());
        }

        // GET: Tatuajes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tatuajes tatuajes = await db.Tatuajes.FindAsync(id);
            if (tatuajes == null)
            {
                return HttpNotFound();
            }
            return View(tatuajes);
        }

        // GET: Tatuajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tatuajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TattooId,Description,Price,Type,IsAvailable,PublishOn")] Tatuajes tatuajes)
        {
            if (ModelState.IsValid)
            {
                db.Tatuajes.Add(tatuajes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tatuajes);
        }

        // GET: Tatuajes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tatuajes tatuajes = await db.Tatuajes.FindAsync(id);
            if (tatuajes == null)
            {
                return HttpNotFound();
            }
            return View(tatuajes);
        }

        // POST: Tatuajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TattooId,Description,Price,Type,IsAvailable,PublishOn")] Tatuajes tatuajes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tatuajes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tatuajes);
        }

        // GET: Tatuajes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tatuajes tatuajes = await db.Tatuajes.FindAsync(id);
            if (tatuajes == null)
            {
                return HttpNotFound();
            }
            return View(tatuajes);
        }

        // POST: Tatuajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tatuajes tatuajes = await db.Tatuajes.FindAsync(id);
            db.Tatuajes.Remove(tatuajes);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
