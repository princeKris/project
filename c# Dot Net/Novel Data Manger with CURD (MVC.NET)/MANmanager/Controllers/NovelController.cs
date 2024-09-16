using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MANmanager.Controllers
{
    public class NovelController : Controller
    {
        // GET: Novel
        manmanagermvcContext _context = new manmanagermvcContext();

        [Route("Novel/Index")]
        [Route("Novel")]
        [Route("")]
        public ActionResult Index()
        {
            var listofdata = _context.noveldatas.OrderByDescending(c => c.Id).ToList();
            return View(listofdata);
        }


        [HttpGet]
        [Route("Novel/search")]
        public ActionResult search(string q)
        {
            var dataa = _context.noveldatas.OrderByDescending(c => c.Id).Where(s => s.name.ToUpper().Contains(q.ToUpper())).ToList();
            return View(dataa);  
        }

        [Route("Novel/Tablelist")]
        public ActionResult Tablelist()
        {
            var listofdata = _context.noveldatas.ToList();
            return View(listofdata);
        }

        [HttpGet]
        [Route("Novel/Create")]
        public ActionResult Create() {
            return View(); 
        }

        [HttpPost]
        [Route("Novel/Create")]
        public ActionResult Create(noveldata Model, HttpPostedFileBase pic)
        {
            var fileName = Path.GetFileName(pic.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
            pic.SaveAs(path);
            Model.pic = fileName.ToString();
            _context.noveldatas.Add(Model);
            _context.SaveChanges();
            ViewBag.Message = "data inserted successfully";
            return View();
        }

        [HttpGet]
        [Route("Novel/Edit")]
        [Route("{id:int:min(1)}")]
        public ActionResult Edit(int id)
        {
            var data = _context.noveldatas.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        [Route("Novel/Edit")]
        public ActionResult Edit(noveldata Model, HttpPostedFileBase pic)
        {
            var data = _context.noveldatas.Where(x => x.Id == Model.Id).FirstOrDefault();
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
                data.name = Model.name;
                data.status = Model.status;
                data.ustatus = Model.ustatus;
                data.noc = Model.noc;
                data.unoc = Model.unoc;
                data.pic = Model.pic;
                data.genre = Model.genre;
                data.authorname = Model.authorname;
                data.releasedate = Model.releasedate;
                data.weblink = Model.weblink;
                if(Model.noveldes == null)
                {
                    Model.noveldes=data.noveldes;
                }
                data.noveldes = Model.noveldes;
                data.rating = Model.rating;
                data.urating = Model.urating;
                data.aname = Model.aname;
                _context.SaveChanges();
            }
            return RedirectToAction("/Index");
        }

        [Route("{id:int:min(1)}")]
        [Route("Novel/Detial")]
        public ActionResult Detial(int id)
        {
            var data = _context.noveldatas.Where(x => x.Id == id).FirstOrDefault();
            var dataa = _context.characterdatas.Where(x => x.typeid == id && x.type.ToString()=="novel").ToList();
            if (dataa != null)
            {
                ViewBag.cd = dataa;
            }
            return View(data);
        }

        [Route("{id:int:min(1)}")]
        [Route("Novel/Delete")]
        public ActionResult Delete(int id)
        {
            var data = _context.noveldatas.Where(x => x.Id == id).FirstOrDefault();
            _context.noveldatas.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "data successfully deleted";
            return RedirectToAction("/Index");
        }
    }
}