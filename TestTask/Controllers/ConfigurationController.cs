using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using TestTask.Data;
using TestTask.Models;

namespace TestTask.Controllers
{

    public class ConfigurationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ConfigurationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DisplayData()
        {
            List<ConfigurationItem> configurationItems = _context.ConfigurationItems.ToList();
            return View(configurationItems);
        }
        [HttpPost]
        public IActionResult UpdateConfiguration([FromBody] string data)
        {
            Console.WriteLine($"JSON uploaded: {data}");

            try
            {
                dynamic dynamicObject = JsonConvert.DeserializeObject<dynamic>(data);
                ProcessDynamicObject(dynamicObject);

                _context.SaveChanges();

                string redirectUrl = Url.Action("DisplayData", "Configuration");
                return Json(new { redirectUrl });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating configuration: {ex.Message}");
                return BadRequest(new { success = false, message = "Помилка при оновленні конфігурації." });
            }
        }

        private void ProcessDynamicObject(dynamic dynamicObject, List<ConfigurationItem> children = null)
        {
            foreach (var property in dynamicObject)
            {
                ConfigurationItem configurationItem = new ConfigurationItem
                {
                    Name = property.Name,
                    Value = Convert.ToString(property.Value),
                    Children = new List<ConfigurationItem>()
                };

                if (children != null)
                {
                    children.Add(configurationItem);
                }

                if (property.Value is Newtonsoft.Json.Linq.JObject nestedObject)
                {
                    configurationItem.Value = null;
                    ProcessDynamicObject(nestedObject, configurationItem.Children);
                }

                _context.ConfigurationItems.Add(configurationItem);
            }
        }
    }
}
