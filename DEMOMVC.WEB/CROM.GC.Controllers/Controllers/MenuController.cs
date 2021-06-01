namespace CROM.GC.Controllers
{
    using CROM.GC.Models;

    using System;
    using System.Demo.BusinessLogic.maestros;
    using System.Demo.Tools.config;
    using System.Demo.Tools.helpers;
    using System.IO;
    using System.Reflection;
    using System.Web.Mvc;

    public class MenuController : Controller
    {

        [ChildActionOnly]
        public ActionResult _VersionPartial()
        {
            VersionModels version = new VersionModels();
            string fileVersion = @"CROM.GC.web.application.dll";
            string strPath = string.Empty;
            string strFileVersion = string.Empty;
            try
            {
                strPath = Server.MapPath(@"~/bin");
                strFileVersion = Path.Combine(strPath, fileVersion);
                FileInfo fileInfo = new FileInfo(strFileVersion);
                version.strFecha = HelpTime.ConvertYYYYMMDD(fileInfo.LastWriteTime) + "-" + fileInfo.LastWriteTime.ToShortTimeString();
                Assembly assembly = Assembly.GetExecutingAssembly();
                AssemblyName assemblyName = assembly.GetName();
                version.strVersion = string.Format("Ver: {0}.{1}.{2}.{3}"
                                                    , assemblyName.Version.Major
                                                    , assemblyName.Version.Minor
                                                    , assemblyName.Version.Revision
                                                    , assemblyName.Version.MajorRevision);
                version.strNombre = assemblyName.Name;
            }
            catch (Exception ex)
            {
                version.strNombre = ex.Message;
            }
            return PartialView(version);
        }

        [ChildActionOnly]
        public ActionResult _SistemaPartial()
        {
            SistemaModels sistema = new SistemaModels();
            ConfiguracionLogic cnf = new ConfiguracionLogic();
            try
            {
                sistema.strLogotipo = ConfigCROM.AppConfig(0, ConfigTool.DEFAULT_Logo_Web);
                sistema.strTitulo = ConfigCROM.AppConfig(0, ConfigTool.DEFAULT_Titulo_Web);
            }
            catch (Exception ex)
            {
                sistema.strTitulo = ex.Message;
            }
            return PartialView(sistema);
        }
    }
}
