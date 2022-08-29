using Microsoft.AspNetCore.Mvc;
using Puc.Molic.Model;
using Puc.Molic.Web.Models;
using System.Diagnostics;
using System.Text;
using System.Xml.Serialization;

namespace Puc.Molic.Web.Controllers
{
    public class MolicController : Controller
    {
        private readonly ILogger<MolicController> _logger;

        public MolicController(ILogger<MolicController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Molic");
        }

        //loading action
        public IActionResult Molic()
        {
            FlowModel flowModel = new FlowModel();
            flowModel.Diagram = GetDiagramFromSession();

            return View(flowModel);
        }

        //search action
        [HttpPost]
        public IActionResult Molic(FlowModel flowModel)
        {
            if (flowModel.ElementoInicial == 0 || flowModel.ElementoFinal == 0)
            {
                return RedirectToAction("Molic");
            }
            DiagramService diagramService = new DiagramService();
            Diagram diagram = GetDiagramFromSession();
            flowModel.DiagramPaths = diagramService.GetDiagramPaths(diagram, flowModel.ElementoInicial, flowModel.ElementoFinal);
            flowModel.Diagram = diagram;

            return View(flowModel);
        }

        //error handling

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //upload method to save XML in the session
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

        //Session object - diagram uploaded in session
        private Diagram GetDiagramFromSession()
        {
            Diagram diagram = HttpContext.Session.GetObject<Diagram>("molic_diagram");
            
            return diagram;
        }
    }
}