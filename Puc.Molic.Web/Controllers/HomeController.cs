using Microsoft.AspNetCore.Mvc;
using Puc.Molic.Model;
using Puc.Molic.Web.Models;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;

namespace Puc.Molic.Web.Controllers
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
            return RedirectToAction("Molic");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FlowModel flowModel)
        {
            DiagramService diagramService = new DiagramService();
            flowModel.DiagramPaths = diagramService.ObterCaminhosDeDiagrama(flowModel.ElementoInicial, flowModel.ElementoFinal);
            flowModel.Diagram = GetDiagram();
            return View(flowModel);
        }



        public IActionResult Molic()
        {
            DiagramService diagramService = new DiagramService();
            FlowModel flowModel = new FlowModel();
            flowModel.Diagram = GetDiagram();

            return View(flowModel);
        }

        [HttpPost]
        public IActionResult Molic(FlowModel flowModel)
        {
            DiagramService diagramService = new DiagramService();
            flowModel.DiagramPaths = diagramService.ObterCaminhosDeDiagrama(flowModel.ElementoInicial, flowModel.ElementoFinal);
            flowModel.Diagram = GetDiagram();

            return View(flowModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            string xml;
            using (var stream = file.OpenReadStream())
            using (var reader = new StreamReader(stream))
            {
                xml = reader.ReadToEndAsync().Result;
            }

            Diagram result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Diagram));
            using (TextReader reader = new StringReader(xml))
            {
                result = (Diagram)serializer.Deserialize(reader);
            }

            if (string.IsNullOrWhiteSpace(result.FileName))
            {
                result.FileName = file.FileName;
            }

            HttpContext.Session.SetObject("molic_diagram", result);

            return RedirectToAction("Molic");
        }

        private Diagram GetDiagram()
        {
            Diagram diagram = HttpContext.Session.GetObject<Diagram>("molic_diagram");
            
            return diagram;
        }
    }
}