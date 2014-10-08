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
      {        
        var emailIsSent = SendEmail(model);
        if (emailIsSent)
        {
          return View("RsvpSubmitted", model);
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
        var body = String.Format("RSVP: {0} \n\nFirst Name: {1} \nLast Name: {2}", model.IsAttending == 1 ? "Yes" : "No", model.FirstName, model.LastName);

        if (model.IsAttending == 1)
        {
          body += String.Format("\n\nAdults Attending: {0} \nChildren Attending: {1}", model.AdultsAttending,
            model.ChildrenAttending);
          
          if (model.AdultsAttending != 1 || model.ChildrenAttending != 0)
          {
            body += String.Format("\n\nOther Travelers: {0}", model.OtherNames);
          }

          body += String.Format("\n\nTravel Information: {0}", model.TravelDates);
        }

        var mailMsg = new MailMessage("noreply@canamcup.com", 
                                      "kerrjon@yahoo.com",
                                      String.Format("Wedding RSVP {0}", model.IsAttending == 1 ? "Yes" : "No"), 
                                      body) {DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure};
        ss.Send(mailMsg);

        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
