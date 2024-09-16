using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MANmanager.Controllers
{
    public class CharacterController : Controller
    {
        // GET: Character
        manmanagermvcContext _context = new manmanagermvcContext();

        [Route("Character/Index")]
        public ActionResult Index()
        {
            var listofdata = _context.characterdatas.OrderByDescending(c => c.Id).ToList();
            return View(listofdata);
        }
        [HttpGet]
        [Route("Character/search")]
        public ActionResult search(string q)
        {
            var dataa = _context.characterdatas.OrderByDescending(c => c.Id).Where(s => s.name.ToUpper().Contains(q.ToUpper())).ToList();
            return View(dataa);
        }
        [Route("Character/Tablelist")]
        public ActionResult Tablelist()
        {
            var listofdata = _context.characterdatas.ToList();
            return View(listofdata);
        }

        [HttpGet]
        [Route("Character/Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Character/Create")]
        public ActionResult Create(characterdata Model, HttpPostedFileBase pic)
        {
            if (Model.pic != null)
            {
                var fileName = Path.GetFileName(pic.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/img/"), fileName);
                pic.SaveAs(path);
                Model.pic = fileName.ToString();
            }
            else
            {
                Model.pic = "novel.png";
            }       
            _context.characterdatas.Add(Model);
            _context.SaveChanges();
            ViewBag.Message = "data inserted successfully";
            return View();
        }

        [HttpGet]
        [Route("Character/Edit")]
        public ActionResult Edit(int id)
        {
            var data = _context.characterdatas.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        [Route("Character/Edit")]
        public ActionResult Edit(characterdata Model, HttpPostedFileBase pic)
        {
            var data = _context.characterdatas.Where(x => x.Id == Model.Id).FirstOrDefault();
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
                data.type = Model.type;
                data.typeid = Model.typeid;
                data.bio = Model.bio;
                data.plot = Model.plot;
                data.pic = Model.pic;
                _context.SaveChanges();
            }
            return RedirectToAction("/Index");
        }
        [Route("Character/Detial")]
        public ActionResult Detial(int id)
        {
            var data = _context.characterdatas.Where(x => x.Id == id).FirstOrDefault();
            if(data.type != null &&  data.typeid != null)
            {
                if (data.type.ToString() == "novel")
                {
                    var dataa = _context.noveldatas.Where(x => x.Id == data.typeid).FirstOrDefault();
                    ViewBag.animename = dataa.name.ToString();
                    ViewBag.animeid = dataa.Id.ToString();
                }
                else if (data.type.ToString() == "manhwa")
                {
                    var dataa = _context.manhwadatas.Where(x => x.Id == data.typeid).FirstOrDefault();
                    ViewBag.animename = dataa.name.ToString();
                    ViewBag.animeid = dataa.Id.ToString();
                }
                else if (data.type.ToString() == "anime")
                {
                    var dataa = _context.animedatas.Where(x => x.Id == data.typeid).FirstOrDefault();
                    ViewBag.animename = dataa.name.ToString();
                    ViewBag.animeid = dataa.Id.ToString();
                }
            }           
            return View(data);
        }
        [Route("Character/Delete")]
        public ActionResult Delete(int id)
        {
            var data = _context.characterdatas.Where(x => x.Id == id).FirstOrDefault();
            _context.characterdatas.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "data successfully deleted";
            return RedirectToAction("/Index");
        }
    }
}