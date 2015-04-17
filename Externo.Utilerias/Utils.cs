using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Externo.Utilerias
{
    public class Utils
    {
        public Utils()
        { }

        public int RegresaNumeroMes(string Mes)
        {
            int numMes = 0;
            List<string> Meses =new List<string> { "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
            foreach (var m in Meses)
            {
                numMes++;
                if (m == Mes)
                    break;
            }
            return numMes;
        }
    }
}
