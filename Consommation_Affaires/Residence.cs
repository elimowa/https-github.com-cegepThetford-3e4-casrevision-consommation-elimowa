using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consommation_Affaires
{
    public class Residence
    {
        private decimal _coutKWh;

        public decimal CoutKWh
        {
            get { return _coutKWh; }
            set { _coutKWh = value; }
        }
        private List<Utilisation> _utilisations;

        public List<Utilisation> Utilisations
        {
            get { return _utilisations; }
            set { _utilisations = value; }
        }
        public Residence(decimal coutKWh)
        {
            _coutKWh = coutKWh;
            _utilisations = new List<Utilisation>();
        }
        public void ajouterUtilisation(int nbMinutes, Appareil appareil)
        {
            Utilisation nouv= new Utilisation(nbMinutes, appareil);
            _utilisations.Add(nouv);
        }
        public double calculerConsommationTotale()
        {
            double total = 0.0;
            foreach (Utilisation uneUtilisation in _utilisations)
                total += uneUtilisation.calculerConsommation();
            return total;
        }
        public decimal calculerCoutConsommation()
        {
            return (decimal) this.calculerConsommationTotale() * _coutKWh;
        }
        public List<Appareil> extraireAppareils(double nbHeuresMin)
        {
            List<Appareil> liste = new List<Appareil>();
            foreach(Utilisation uneUtilisation in _utilisations)
            {
                if (uneUtilisation.NbHeures >= nbHeuresMin)
                    if (! liste.Contains(uneUtilisation.Appareil))
                        liste.Add(uneUtilisation.Appareil);

            }
            return liste;
        }


    }
}
