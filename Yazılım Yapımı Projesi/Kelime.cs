using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazılım_Yapımı_Projesi
{
    public class Kelime
    {
        public int kelimeId { get; set; }
        public string ingKelime { get; set; }
        public string turkceKelime { get; set; }
        public string ornekCumle { get; set; }
        public string kelimeTuru { get; set; }
        public string seviye { get; set; }
        public string tarih { get; set; }
        public List<Kelime> kelimeler;
    }
}
