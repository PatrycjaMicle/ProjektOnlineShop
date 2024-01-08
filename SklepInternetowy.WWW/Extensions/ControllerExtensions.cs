using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SklepInternetowy.WWW.Models;

namespace SklepInternetowy.WWW.Extensions;

public static class ControllerExtensions
{
    public static void SetNotification(this Controller controller, string message,string type = "success")
    { 
        var notification = new Notification(type, message); 
        controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
    }
}