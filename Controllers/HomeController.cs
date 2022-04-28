using MachineInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MachineInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            String query = "select machineName,managerName,temperature,power,runTime from tbl_machine";
            List<MachineCensor> list = DBManager.selectDB(query);
            
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}