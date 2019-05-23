using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    /// <summary>
    /// Classe para comparar reservas
    /// </summary>
    class ReservaComp : IComparer<Reserva>
    {
        public int Compare(Reserva x, Reserva y)
        {
            
                return DateTime.Compare(x.Horario,y.Horario);
          
        }
    }
}
