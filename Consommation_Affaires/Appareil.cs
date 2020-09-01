using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consommation_Affaires
{
    public class Appareil
    {
        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        private int _puissanceWatts;
        public int PuissanceWatts
        {
            get { return _puissanceWatts; }
            set { _puissanceWatts = value; }
        }


        public Appareil(string nom, int puissanceWatts)
        {
            _nom = nom;
            _puissanceWatts = puissanceWatts;
        }
        public double calculerPuissanceKW()
        {
            return _puissanceWatts / 1000.0;
        }
    }

}
