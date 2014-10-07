using System.Web.Mvc;
using kerrwed.Models;

namespace kerrwed.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      var model = new RsvpModel();
      return View(model);
    }


    [HttpPost]
    public ActionResult Index(RsvpModel model)
    {
      if (ModelState.IsValid)
      {
        //send emails
        return View("Success");
      }
      else
      {
        return View(model);
      }
    }
  }
}
