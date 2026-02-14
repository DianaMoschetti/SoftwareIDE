using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class ManejadorArchivoXml : ManejadorArchivo
    {
        protected DataSet ds;

        public override DataTable GetTabla()
        {
            ds = new DataSet();
            ds.ReadXml("agenda.xml");
            return ds.Tables["contactos"];
        }

        public override void AplicaCambios()
        {
            ds.WriteXml("agenda.xml");
            ds.WriteXml("agendaconschema.xml", XmlWriteMode.WriteSchema);
        }
    }
}
