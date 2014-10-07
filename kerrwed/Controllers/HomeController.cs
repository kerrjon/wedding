using System;
using System.Net;
using System.Net.Mail;
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
      {        var emailIsSent = SendEmail(model);
        if (emailIsSent)
        {
          return View("RsvpSubmitted");
        }
        TempData["MessageType"] = "optionsError";
        TempData["SessionOptionsMessage"] =
          "Oops, something went wrong!  We did not get your RSVP.  Please try again or email your RSVP to sara.sylvester@gmail.com if you continue to have problems.";
      }
      return View(model);
    }

    private bool SendEmail(RsvpModel model)
    {
      var ss = new SmtpClient();

      try
      {
        ss.Host = "smtpout.secureserver.net";
        ss.Port = 25;
        ss.Timeout = 10000;
        ss.DeliveryMethod = SmtpDeliveryMethod.Network;
        ss.UseDefaultCredentials = false;
        ss.Credentials = new NetworkCredential("noreply@canamcup.com", "xx184533");

        var mailMsg = new MailMessage("noreply@canamcup.com", 
                                      "jkerr@markarch.com",
                                      "test subject here", 
                                      "test body goes here") {DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure};
        ss.Send(mailMsg);

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public ActionResult RsvpSubmitted()
    {
      return View();
    }
  }
}
