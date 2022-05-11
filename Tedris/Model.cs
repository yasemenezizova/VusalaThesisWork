using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedris
{
    public class Model
    {
        public int ID { get; set; }
        public string muellim  { get; set; }
        public string qrup { get; set; }
        public string fenn { get; set; }
        public int muhazire_payiz_saat { get; set; }
        public int muhazire_yaz_saat { get; set; }
        public int seminar_payiz_saat { get; set; }
        public int seminar_yaz_saat { get; set; }
        public int laboratoriya_payiz_saat { get; set; }
        public int laboratoriya_yaz_saat { get; set; }
    }
}
