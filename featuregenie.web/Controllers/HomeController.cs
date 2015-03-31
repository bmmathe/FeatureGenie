using System.Web.Mvc;
using featuregenie.web.Data;
using featuregenie.web.Models;

namespace featuregenie.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly FeaturesData _repository;

        public HomeController()
        {
            _repository = new FeaturesData();    
        }

        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Feature feature)
        {
            _repository.Create(feature);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Feature feature)
        {
            _repository.Update(feature);
            return RedirectToAction("Index");
        }
        

        protected override void Dispose(bool disposing)
        {
            if(disposing)
                _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}