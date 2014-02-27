using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestApp.Services.Localization;
using RestApp.Services.Security;
using RestApp.Core;
using RestApp.Services.Banks;
using RestApp.Web.Models.Banks;
using RestApp.Core.Domain.Banks;
using System.Data;
using RestApp.Common.Utility;

namespace RestApp.Web.Controllers
{
    [Authorize]
    public class BankController : BaseApController
    {
		#region Fields

        private readonly ILocalizationService gLocalizationService;
        private readonly IPermissionService gPermissionService;
        private readonly IWorkContext gWorkContext;
        private readonly IBankService gBankService;

        #endregion

		#region Constructors

        public BankController(ILocalizationService localizationService, IPermissionService permissionService, IWorkContext WorkContext, IBankService bankService)
        { 
            this.gLocalizationService = localizationService;
            this.gPermissionService = permissionService;
            this.gWorkContext = WorkContext;
            this.gBankService = bankService;
        }

        #endregion

		#region Bank

		public ActionResult Index()
        {
            return RedirectToAction("List");
        }

		// GET: /Bank/
        public ActionResult List(string q = "")
        {
            if (!gPermissionService.Authorize(StandardPermissionProvider.ManageBanks))
            {
                return AccessDeniedView();
            }

            List<ListBankModel> listModel = new List<ListBankModel>();

            foreach (var bank in gBankService.GetFilteredBanks(q))
            {
                listModel.Add(PrepareBankModelForList(bank));
            }

            return View(listModel);
        }

		// GET: /Bank/Create
        public ActionResult Create()
        {
            if (!gPermissionService.Authorize(StandardPermissionProvider.ManageBanks))
            {
                return AccessDeniedView();
            }

            var bank = new BankModel();

            return View(bank);
        }

        // POST: /Bank/Create
        [HttpPost]
        public ActionResult Create(BankModel model)
        {
            if (!gPermissionService.Authorize(StandardPermissionProvider.ManageBanks))
            {
                return AccessDeniedView();
            }

            if (ModelState.IsValid)
            {
                var bank = new Bank()
                {
                    Name = model.Name,
                    Code = model.Code,
                    Account = model.Account,
                    Enabled = model.Enabled,

                    CreateBy = gWorkContext.CurrentUser.Id,
                    EditBy = gWorkContext.CurrentUser.Id,
                    DateCreateOn = DateTime.UtcNow,
                    DateEditOn = DateTime.UtcNow
                };

                gBankService.InsertBank(bank);

                SuccessNotification(gLocalizationService.GetResource("Controller.Success.Bank.Insert"));

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Bank/Edit/
        public ActionResult Edit(int id = 0)
        {
            if (!gPermissionService.Authorize(StandardPermissionProvider.ManageBanks))
            {
                return AccessDeniedView();
            }

            Bank bank = gBankService.GetBankById(id);
            if (bank == null)
            {
                return HttpNotFound();
            }

            var customModel = new BankModel();

            customModel.Id = bank.Id;
            customModel.Code = bank.Code;
            customModel.Name = bank.Name;
            customModel.Account = bank.Account;
            customModel.Enabled = bank.Enabled;

            return View(customModel);
        }

        // POST: /Bank/Edit/
        [HttpPost]
        public ActionResult Edit(BankModel model)
        {
            if (!gPermissionService.Authorize(StandardPermissionProvider.ManageBanks))
            {
                return AccessDeniedView();
            }

            var custom = gBankService.GetBankById(model.Id);

            if (custom == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    custom.Code = model.Code;
                    custom.Name = model.Name;
                    custom.Account = model.Account;
                    custom.Enabled = model.Enabled;

                    custom.CreateBy = gWorkContext.CurrentUser.Id;
                    custom.EditBy = gWorkContext.CurrentUser.Id;
                    custom.DateCreateOn = DateTime.UtcNow;
                    custom.DateEditOn = DateTime.UtcNow;

                    gBankService.UpdateBank(custom);

                    SuccessNotification(gLocalizationService.GetResource("Controller.Success.Bank.Update"));

                    return RedirectToAction("Index");

                }
                catch (Exception exc)
                {
                    ModelState.AddModelError("", exc.ToString());
                }

            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            if (!gPermissionService.Authorize(StandardPermissionProvider.ManageBanks))
            {
                return AccessDeniedView();
            }

            var bank = gBankService.GetBankById(id);
            if (bank == null)
            {
                return HttpNotFound();
            }

            gBankService.DeleteBank(bank);

            SuccessNotification(gLocalizationService.GetResource("Controller.Success.Bank.Delete"));

            return RedirectToAction("Index");
        }

        public ActionResult ExportToExcel(string q)
        {
            if (!gPermissionService.Authorize(StandardPermissionProvider.ManageBanks))
            {
                return AccessDeniedView();
            }

            // Create new DataTable to hold the data
            DataTable data = new DataTable();

            // Create the columns to export
            data.Columns.Add("Code", Type.GetType("System.String"));
            data.Columns.Add("Name", Type.GetType("System.String"));
            data.Columns.Add("Account", Type.GetType("System.String"));

            // Get the data
            foreach (var localeString in gBankService.GetFilteredBanks(q))
            {
                // Create new row with the table schema
                DataRow row = data.NewRow();

                // Add the data to each cell in row
                row[0] = localeString.Code;
                row[1] = localeString.Name;
                row[2] = localeString.Account;

                // Add the new row to the rows collection
                data.Rows.Add(row);
            }

            // return the file to download
            return File(ExportUtility.ExportToExcel(data).ToArray(), // The binary data of the XLS file
                "application/vnd.ms-excel",                          // MIME type of Excel files
                "Export.xls");                                       // Suggested file name in the "Save as" dialog which will be displayed to the end user
        }

		#endregion

		#region Utilities        

        [NonAction]
        protected ListBankModel PrepareBankModelForList(Bank bank)
        {
            return new ListBankModel()
            {
                Id = bank.Id,
                Code = bank.Code,
                Name = bank.Name,
                Account = bank.Account,
                Enabled = bank.Enabled
            };
        }

        #endregion
    }
}
