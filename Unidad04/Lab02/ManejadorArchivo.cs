using System;
using System.Collections.Generic;
using System.Data;

namespace Lab02
{
    internal class ManejadorArchivo
    {
        protected DataTable misContactos;
        protected Dictionary<string, string> mapearColumnas; // para normalizar los textos y evitar caracteres raros (ï»¿ID: 3)

        public ManejadorArchivo()
        {
            this.misContactos = this.GetTabla();
            this.mapearColumnas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            
            //Normalizar columnas para evitar problemas de mapeo (e.g. "ï»¿ID" -> "Id", "E-mail" -> "Email")
            NormalizaYMapeaColumnas(this.misContactos);
        }
                
        private void NormalizaYMapeaColumnas(DataTable tabla) 
        {
           
            var usados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DataColumn col in tabla.Columns)
            {
                string original = col.ColumnName ?? string.Empty;
                string normalizada = Normalizar(original) ?? original;

                string unificada = normalizada; 

                //Evito que haya dos columnas con el mismo nombre despues de normalizadas   
                int sufijo = 1;
                while (usados.Contains(unificada))
                {
                    unificada = normalizada + (++sufijo).ToString(); // si ya fue usado, le agrego un numero al final para hacerlo unico (e.g. "Email" -> "Email2")
                }
                usados.Add(unificada);
                mapearColumnas[unificada] = original; // guardo el mapeo del nombre unificado -> nombre original del header del archivo (e.g. "Email" -> "E-mail")
                col.ColumnName = unificada; // cambio el nombre de la columna en memoria al unificado (e.g. "E-mail" -> "Email")
            }
        }

        private static string Normalizar(string raw)
        {
            if(string.IsNullOrWhiteSpace(raw)) {  return raw; }
            raw = raw.TrimStart('\uFEFF', '\u00EF', '\u00BB', '\u00BF'); // Saco los BOM (Byte Order Mark) comunes que aparecen en archivos UTF-8 (ï»¿)
            // https://stackoverflow.com/questions/1317700/strip-the-byte-order-mark-from-string-in-c-sharp
            string normalizado = raw.Replace("-", "").Replace(" ", "").Replace("_", "").Trim();
            if (normalizado.Length == 0) return raw; // Si queda vacío después de limpiar, devuelvo el original para evitar columnas sin nombre

            return char.ToUpperInvariant(normalizado[0]) + (normalizado.Length > 1 ? normalizado.Substring(1).ToLowerInvariant() : string.Empty); // Title-case el resultado (e.g. "nombre" -> "Nombre")
        }

        public virtual DataTable GetTabla()
        {
            return new DataTable();
        }

        public virtual void AplicaCambios()
        {

        }

        public void Listar()
        {
            foreach (DataRow fila in this.misContactos.Rows)
            {
                if (fila.RowState != DataRowState.Deleted)
                {
                    foreach (DataColumn col in this.misContactos.Columns)
                    {
                        Console.WriteLine("{0}: {1}", col.ColumnName, fila[col]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public void NuevaFila()
        {
            DataRow fila = this.misContactos.NewRow();
            foreach (DataColumn column in this.misContactos.Columns)
            {
                Console.Write("Ingrese {0}:", column.ColumnName);
                fila[column] = Console.ReadLine(); 
            }
            this.misContactos.Rows.Add(fila);
        }

        public void EditarFila()
        {
            Console.WriteLine("Ingrese el nro de fila a editar");
            int nroFila = int.Parse(Console.ReadLine());
            DataRow fila = this.misContactos.Rows[nroFila - 1];
            for (int nroCol = 0; nroCol < this.misContactos.Columns.Count; nroCol++)
            {
                DataColumn col = this.misContactos.Columns[nroCol];
                Console.WriteLine("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();
            }
        }

        public void EliminarFila()
        {
            Console.WriteLine("Ingrese el nro de fila a eliminar");
            int fila = int.Parse(Console.ReadLine());
            this.misContactos.Rows[fila - 1].Delete();
        }

    }
}
