using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NpcGen.Constants;
using NpcGen.ControllerHelpers;
using NpcGen.Models;
using NpcGen.Extensions;
using NpcGen.Enums;

namespace NpcGen.Controllers
{
    public class ImportController : Controller
    {
        [HttpGet]
        public ActionResult Index(ImportModel model)
        {
            model.Message = model.Message.IsNullOrEmpty() ? "<p><b>Nothing to report</b></p>" : model.Message;
            return View(model);
        }

        [HttpPost]
        public ActionResult Import(ImportModel model)
        {
            var helper = new ImportHelper(model.Csv);

            switch (model.ImportType)
            {
                case ImportType.Abilities:
                    helper.ClassAbilityImport();
                    break;
                case ImportType.Classes:
                    helper.ClassesImport();
                    break;
            }

            model.Message = helper.Report;

            return View("~/Views/Import/Index.cshtml", model);
        }

        public ActionResult Seed(ImportModel model)
        {
            var abs = ClassAbilityDefinitions.CsvAbilities();
            var absHelper = new ImportHelper(abs);
            absHelper.ClassAbilityImport();

            var cls = ClassDefinitions.CsvClasses();
            var clsHelper = new ImportHelper(cls);
            clsHelper.ClassesImport();

            model.Message = absHelper.Report + clsHelper.Report;

            return View("~/Views/Import/Index.cshtml", model);
        }
    }
}
