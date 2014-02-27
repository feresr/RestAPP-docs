using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestApp.Core;
using RestApp.Web.Models.Security;
using RestApp.Services.Security;

namespace RestApp.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseApController
    {
        #region Fields

        private readonly IPermissionService gPermissionService;

        #endregion

        #region Constructors

        public HomeController(IPermissionService permissionService)
        { 
            this.gPermissionService=permissionService;
        }

        #endregion

        public ActionResult Index()
        {
            var homePanelSecurity = new HomePanelSecurityModel();

            homePanelSecurity.PanelAdministration = gPermissionService.Authorize(StandardPermissionProvider.AccessPanelAdministration);
            homePanelSecurity.PanelSedronar = gPermissionService.Authorize(StandardPermissionProvider.AccessPanelSedronar);
            homePanelSecurity.PanelRenar = false;
            homePanelSecurity.PanelBank = false;

            return View(homePanelSecurity);
        }

        public ActionResult Administration()
        {
            return View();
        }
    }
}
