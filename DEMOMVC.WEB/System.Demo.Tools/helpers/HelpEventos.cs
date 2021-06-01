using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.helpers
{
    public static class HelpEventos
    {

        public enum Process
        {
            NEW,
            EDIT,
            DELETE,
            FIND,
            PRINT,
            EXPORT,
            PRINT_FMT,
            VIEW,
            VIEW_DETAIL,
            EXIT,
            SAVE,
            REFRESH,
            UNDO,
            DEPENDENCIA,
            PERS_ASISTENCIA,
            PERS_AGENDA,
            ANNULLED,

            GC_DOCUM_SERIES,
            GC_DOCUM_SELECT,
            GC_DOCUM_PAGOS,
            GC_DOCUM_LETRAS,
            GC_DOCUM_GASTOADUANERO,
            GC_DOCUM_COPIAR,
            GC_DOCUM_DESHACER,
            GC_DOCUM_ANULAR,
            GC_DOCUM_ELIMINAR,
            GC_DOCUM_ARCHIVAR,
            GC_DOCUM_DEVOLVER,

            GC_DOCUM_ITEM_ADD,
            GC_DOCUM_ITEM_DELETE,
            GC_DOCUM_ITEM_EDIT,

            DOC_RECEIVABLE,
            DOC_PAYMENTS,
            DOC_RELEASE,
            ENTRY,
            OUTPUT
        }


        public static string MessageEvento(HelpEventos.Process p_Evento)
        {
            string MESSAGE = string.Empty;
            switch (p_Evento)
            {
                case HelpEventos.Process.NEW:
                    MESSAGE = ConstantMESSAGES.MESSAGE_NEW;
                    break;
                case HelpEventos.Process.EDIT:
                    MESSAGE = ConstantMESSAGES.MESSAGE_EDIT;
                    break;
                case HelpEventos.Process.DELETE:
                    MESSAGE = ConstantMESSAGES.MESSAGE_DELETE;
                    break;
                //case HelpEventos.Process.DEPENDENCIA:
                //    MESSAGE = "¡ Registro tiene dependencia con otro nivel en la tabla !";
                //    break;
                //case HelpEventos.Process.GC_DOCUM_ANULAR:
                //    MESSAGE = "¡ Documento o Item ya se ha anulado satisfactoriamente. !";
                //    break;
                case HelpEventos.Process.FIND:
                    MESSAGE = ConstantMESSAGES.MESSAGE_NO_FOUND;
                    break;
            }
            return MESSAGE;
        }


    }

    public static class ConstantMESSAGES
    {

        public const string MESSAGE_NEW = "¡ Registro insertado satisfactoriamente !";

        public const string MESSAGE_EDIT = "¡ Registro actualizado satisfactoriamente !";

        public const string MESSAGE_DELETE = "¡ Registro eliminado satisfactoriamente !";

        public const string MESSAGE_NO_FOUND = "Registro de {0} no existe.";

        public const string MESSAGE_TIPO_CAMBIO = "¡ Registro de tipo de cambio para hoy ya existe !";

        public const string GeneralAPP_MensajeErrorUser = "Estimado usuario a ocurrido un error. Por favor contactese con el admnistrador del sistema para que verifique el LOG del sistema.";

        public const string GeneralWSERVICE_NoComunicacion = "No se encuentra habilitado el servicio. Error interno!";

    }
}
