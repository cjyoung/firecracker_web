using firecracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace firecracker_web.Controllers
{
    public class FirecrackerController : Controller
    {
        // GET: Firecracker/Details/5
        public ActionResult Execute(string houseInput, string moduleInput, string moduleAction)
        {
            FirecrackerSerialPort.House houseId;
            Enum.TryParse<FirecrackerSerialPort.House>(houseInput, true, out houseId);

            int moduleNumber;
            int.TryParse(moduleInput, out moduleNumber);

            FirecrackerSerialPort.ModuleState moduleState;
            Enum.TryParse<FirecrackerSerialPort.ModuleState>(moduleAction, true, out moduleState);

            FirecrackerSerialPort fc = new FirecrackerSerialPort("COM3");
            fc.Initialize();
            fc.SendCommand(houseId, moduleNumber, moduleState);
            System.Threading.Thread.Sleep(1000);
            //Console.ReadKey();
            fc.Close();

            return PartialView();
        }
    }
}
