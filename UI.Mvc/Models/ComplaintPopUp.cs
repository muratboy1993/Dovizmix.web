using Infrastructure.ServiceManager.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.Mvc.Models
{
    [ViewComponent(Name = "ComplaintPopUp")]
    public class ComplaintPopUp : ViewComponent
    {
        private readonly IComplaintManager _complaintManager;

        public ComplaintPopUp(IComplaintManager complaintManager)
        {
            _complaintManager = complaintManager;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Topic = _complaintManager.GetComplaintTopics();
            return View();
        }
    }
}
