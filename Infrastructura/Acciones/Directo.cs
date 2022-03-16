#region Usos
using System;
using System.IO;
using System.Linq;
using System.Text;
using Dominio.Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;
#endregion

namespace Infrastructura.Acciones
{
    public class Directo : BaseM
    {
        private BinaryWriter binaryWriter;

        public Directo()
        {

        }
        public void Add(string texto, string ruta)
        {
            try
            {
                using (FileStream fileStream = new FileStream(ruta, FileMode.Append, FileAccess.Write))
                {
                    binaryWriter = new BinaryWriter(fileStream);
                    binaryWriter.Write(texto);
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public string Guardar(string text)
        {
            throw new NotImplementedException();
        }

        public string Read(string t)
        {
            string text = string.Empty;

            try
            {
                text = File.ReadAllText(t);

                return text;
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}