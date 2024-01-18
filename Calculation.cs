using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuschlagskalkulation {
    internal class Calculation {

        public string rechneNetto(string fertigungsmaterial, string materialgemeinkosten, string fertigungslöhne, string fertigungsgemeinkosten, string verwaltungsgemeinkosten, string vertriebsgemeinkosten, string gewinnzuschlag, string skonto, string rabatt) {

            double herstellerkosten = ((Convert.ToDouble(fertigungsmaterial) * Convert.ToDouble(materialgemeinkosten) / 100 + Convert.ToDouble(fertigungsmaterial)) + Convert.ToDouble(fertigungslöhne) + (Convert.ToDouble(fertigungslöhne) * Convert.ToDouble(fertigungsgemeinkosten) / 100));
            double selbstkosten = (herstellerkosten * Convert.ToDouble(verwaltungsgemeinkosten) / 100) + (herstellerkosten * Convert.ToDouble(vertriebsgemeinkosten) / 100) + herstellerkosten;
            double barverkaufspreis = selbstkosten * Convert.ToDouble(gewinnzuschlag) / 100 + selbstkosten;
            double zielverkaufspreis = barverkaufspreis * Convert.ToDouble(skonto) / (100 - Convert.ToDouble(skonto)) + barverkaufspreis;
            double netto = zielverkaufspreis * Convert.ToDouble(rabatt) / (100 - Convert.ToDouble(rabatt)) + zielverkaufspreis;
           
            string ergebnis = Math.Round(netto, 2).ToString();
            return ergebnis;
        }

        public string rechneMwst(string mwst2, string netto) {

            double mwst1 = Convert.ToDouble(mwst2) / 100;
            double mwst = Convert.ToDouble(netto) * mwst1;
            string ergebnis = Math.Round(mwst, 2).ToString();
            return ergebnis;
        }
    }
}
