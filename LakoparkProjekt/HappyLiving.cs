using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LakoparkProjekt
{
    internal class HappyLiving
    {
        List<Lakopark> lakoparkok;

        internal List<Lakopark> Lakoparkok { get => lakoparkok; set => lakoparkok = value; }

        public HappyLiving(List<Lakopark> lakoparkok)
        {
            Lakoparkok = lakoparkok;
        }
    }
}
