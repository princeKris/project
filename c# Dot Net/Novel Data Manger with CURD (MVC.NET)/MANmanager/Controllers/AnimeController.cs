using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MANmanager.Controllers
{
    public class AnimeController : Controller
    {
        // GET: Anime
        manmanagermvcContext _context = new manmanagermvcContext();

        [Route("Anime/Index")]
        public ActionResult Index()
        {
            var listofdata = _context.animedatas.OrderByDescending(c => c.Id).ToList();
            return View(listofdata);
        }
        [HttpGet]
        [Route("Anime/search")]
        public ActionResult search(string q)
        {
            var dataa = _context.animedatas.OrderByDescending(c => c.Id).Where(s => s.name.ToUpper().Contains(q.ToUpper())).ToList();
            return View(dataa);
        }
        [Route("Anime/Tablelist")]
        public ActionResult Tablelist()
        {
            var listofdata = _context.animedatas.ToList();
            return View(listofdata);
        }

        [HttpGet]
        [Route("Anime/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Anime/Create")]
        public ActionResult Create(animedata Model, HttpPostedFileBase pic)
        {
            var fileName = Path.GetFileName(pic.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
            pic.SaveAs(path);
            Model.pic = fileName.ToString();
            _context.animedatas.Add(Model);
            _context.SaveChanges();
            ViewBag.Message = "data inserted successfully";
            return View();
        }

        [HttpGet]
        [Route("Anime/Edit")]
        public ActionResult Edit(int id)
        {
            var data = _context.animedatas.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        [Route("Anime/Edit")]
        public ActionResult Edit(animedata Model, HttpPostedFileBase pic)
        {
            var data = _context.animedatas.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                if (pic != null)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                    pic.SaveAs(path);
                    Model.pic = fileName.ToString();
                }
                else
                {
                    Model.pic = data.pic;
                }
                if(Model.novelid != null)
                {
                    data.novelid = Model.novelid;
                }
                if(Model.manhwaid != null)
                {
                    data.manhwaid = Model.manhwaid;
                }
                data.name = Model.name;
                data.status = Model.status;
                data.ustatus = Model.ustatus;
                data.ep = Model.ep;
                data.uep = Model.uep;
                data.pic = Model.pic;
                data.genre = Model.genre;
                data.studio = Model.studio;
                data.releasedate = Model.releasedate;
                data.weblink = Model.weblink;
                if (Model.desc == null)
                {
                    Model.desc = data.desc;
                }
                data.desc = Model.desc;
                data.rating = Model.rating;
                data.urating = Model.urating;
                data.aname = Model.aname;
                _context.SaveChanges();
            }
            return RedirectToAction("/Index");
        }

        [Route("Anime/Detial")]
        public ActionResult Detial(int id)
        {
            var data = _context.animedatas.Where(x => x.Id == id).FirstOrDefault();
            var dataa = _context.characterdatas.Where(x => x.typeid == id && x.type.ToString()=="anime").ToList();
            if(dataa != null)
            {
                ViewBag.cd = dataa;
            }
            return View(data);
        }
        [Route("Anime/Delete")]
        public ActionResult Delete(int id)
        {
            var data = _context.animedatas.Where(x => x.Id == id).FirstOrDefault();
            _context.animedatas.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "data successfully deleted";
            return RedirectToAction("/Index");
        }
    }
}