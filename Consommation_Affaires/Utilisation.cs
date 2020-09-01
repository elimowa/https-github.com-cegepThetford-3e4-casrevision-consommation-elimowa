using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consommation_Affaires
{
    public class Utilisation
    {
        private double _nbHeures;

        public double NbHeures
        {
            get { return _nbHeures; }
            set { _nbHeures = value; }
        }
        private Appareil _appareil;

        public Appareil Appareil
        {
            get { return _appareil; }
            set { _appareil = value; }
        }

        public Utilisation(int nbMinutes, Appareil appareil)
        {
            _nbHeures = nbMinutes / 60.0;
            _appareil = appareil;
        }
        public double calculerConsommation()
        {
            return _appareil.calculerPuissanceKW()*_nbHeures;
        }


    }
}
