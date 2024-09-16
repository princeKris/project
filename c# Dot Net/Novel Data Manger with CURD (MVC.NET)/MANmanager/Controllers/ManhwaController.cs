using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MANmanager.Controllers
{
    public class ManhwaController : Controller
    {
        // GET: Manhwa
        manmanagermvcContext _context = new manmanagermvcContext();
        [Route("Manhwa/Index")]
        public ActionResult Index()
        {
            var listofdata = _context.manhwadatas.OrderByDescending(c => c.Id).ToList();
            return View(listofdata);
        }
        [HttpGet]
        [Route("Manhwa/search")]
        public ActionResult search(string q)
        {
            var dataa = _context.manhwadatas.OrderByDescending(c => c.Id).Where(s => s.name.ToUpper().Contains(q.ToUpper())).ToList();
            return View(dataa);
        }

        [Route("Manhwa/Tablelist")]
        public ActionResult Tablelist()
        {
            var listofdata = _context.manhwadatas.ToList();
            return View(listofdata);
        }

        [HttpGet]
        [Route("Manhwa/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Manhwa/Create")]
        public ActionResult Create(manhwadata Model, HttpPostedFileBase pic)
        {
            var fileName = Path.GetFileName(pic.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
            pic.SaveAs(path);
            Model.pic = fileName.ToString();
            _context.manhwadatas.Add(Model);
            _context.SaveChanges();
            ViewBag.Message = "data inserted successfully";
            return View();
        }

        [HttpGet]
        [Route("Manhwa/Edit")]
        public ActionResult Edit(int id)
        {
            var data = _context.manhwadatas.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        [Route("Manhwa/Edit")]
        public ActionResult Edit(manhwadata Model, HttpPostedFileBase pic)
        {
            var data = _context.manhwadatas.Where(x => x.Id == Model.Id).FirstOrDefault();
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
                data.name = Model.name;
                data.status = Model.status;
                data.ustatus = Model.ustatus;
                data.noc = Model.noc;
                data.unoc = Model.unoc;
                data.pic = Model.pic;
                data.genre = Model.genre;
                data.author = Model.author;
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

        [Route("Manhwa/Detial")]
        public ActionResult Detial(int id)
        {
            var data = _context.manhwadatas.Where(x => x.Id == id).FirstOrDefault();
            var dataa = _context.characterdatas.Where(x => x.typeid == id && x.type.ToString()=="manhwa").ToList();
            if (dataa != null)
            {
                ViewBag.cd = dataa;
            }
            return View(data);
        }
        [Route("Manhwa/Delete")]
        public ActionResult Delete(int id)
        {
            var data = _context.manhwadatas.Where(x => x.Id == id).FirstOrDefault();
            _context.manhwadatas.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "data successfully deleted";
            return RedirectToAction("/Index");
        }
    }
}