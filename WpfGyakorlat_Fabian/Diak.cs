using System;

namespace WpfGyakorlat
{
    
    public class Diak
    {
        public string Nev { get; set; }
        public string Osztaly { get; set; }
        public int Matek { get; set; }
        public int Fizika { get; set; }

        
        public double Atlag => (Matek + Fizika) / 2.0;
    }
}