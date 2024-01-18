using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zuschlagskalkulation {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
                     
            Calculation calculation = new Calculation();

            string[,] kosten = {{fertigungsmaterial.Text,materialgemeinkosten.Text, fertigungslöhne.Text, fertigungsgemeinkosten.Text,
                              verwaltungsgemeinkosten.Text, vertriebsgemeinkosten.Text, gewinnzuschlag.Text, skonto.Text, rabatt.Text},{
                                fertigungsmaterial2.Text,materialgemeinkosten2.Text, fertigungslöhne2.Text, fertigungsgemeinkosten2.Text,
                              verwaltungsgemeinkosten2.Text, vertriebsgemeinkosten2.Text, gewinnzuschlag2.Text, skonto2.Text, rabatt2.Text },{
                                fertigungsmaterial3.Text,materialgemeinkosten3.Text, fertigungslöhne3.Text, fertigungsgemeinkosten3.Text,
                              verwaltungsgemeinkosten3.Text, vertriebsgemeinkosten3.Text, gewinnzuschlag3.Text, skonto3.Text, rabatt3.Text } };
            
            for(int i = 0; i < 3; i++) {
                for (int j = 0; j < 9; j++) {
                    try {
                        double test = Convert.ToDouble(kosten[i,j]);
                    } catch {
                        kosten[i,j] = "0";
                    }
                }          
            }

            tb_netto.Text = calculation.rechneNetto(kosten[0, 0], kosten[0, 1], kosten[0, 2], kosten[0, 3], kosten[0, 4], kosten[0, 5], kosten[0, 6], kosten[0, 7], kosten[0, 8]) + "€";
            tb_mwst.Text = calculation.rechneMwst(mwst.Text, tb_netto.Text.Split("€")[0]) + "€";
            double brutto = Convert.ToDouble(tb_netto.Text.Split("€")[0]) + Convert.ToDouble(tb_mwst.Text.Split("€")[0]);
            tb_brutto.Text = Convert.ToString(Math.Round(brutto, 2)) + "€";

            tb_netto2.Text = calculation.rechneNetto(kosten[1, 0], kosten[1, 1], kosten[1, 2], kosten[1, 3], kosten[1, 4], kosten[1, 5], kosten[1, 6], kosten[1, 7], kosten[1, 8]) + "€";
            tb_mwst2.Text = calculation.rechneMwst(mwst2.Text, tb_netto2.Text.Split("€")[0]) + "€";
            brutto = Convert.ToDouble(tb_netto2.Text.Split("€")[0]) + Convert.ToDouble(tb_mwst2.Text.Split("€")[0]);
            tb_brutto2.Text = Convert.ToString(Math.Round(brutto, 2)) + "€";

            tb_netto3.Text = calculation.rechneNetto(kosten[2, 0], kosten[2, 1], kosten[2, 2], kosten[2, 3], kosten[2, 4], kosten[2, 5], kosten[2, 6], kosten[2, 7], kosten[2, 8]) + "€";
            tb_mwst3.Text = calculation.rechneMwst(mwst3.Text, tb_netto3.Text.Split("€")[0]) + "€";
            brutto = Convert.ToDouble(tb_netto3.Text.Split("€")[0]) + Convert.ToDouble(tb_mwst3.Text.Split("€")[0]);
            tb_brutto3.Text = Convert.ToString(Math.Round(brutto, 2)) + "€";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {

            double netto1 = Convert.ToDouble(tb_netto.Text.Split("€")[0]);
            double netto2 = Convert.ToDouble(tb_netto2.Text.Split("€")[0]);
            double netto3 = Convert.ToDouble(tb_netto3.Text.Split("€")[0]);
            double prozent, ergebnis;

            if(netto1 > netto2) {
                ergebnis = netto1 - netto2;
                prozent = ergebnis * 100 / netto2;
                prozent12.Text = Convert.ToString(Math.Round(prozent,2)) + "%";
                angebot12.Text = Convert.ToString(Math.Round(ergebnis, 2)) + "€";
            }
            else if(netto1 < netto2) {
                ergebnis = netto2 - netto1;
                prozent = ergebnis * 100 / netto1;
                prozent12.Text = Convert.ToString(Math.Round(prozent, 2)) + "%";
                angebot12.Text = Convert.ToString(Math.Round(ergebnis, 2)) + "€";
            }

            if (netto2 > netto3) {
                ergebnis = netto2 - netto3;
                prozent = ergebnis * 100 / netto2;
                prozent23.Text = Convert.ToString(Math.Round(prozent, 2)) + "%";
                angebot23.Text = Convert.ToString(Math.Round(ergebnis, 2)) + "€";
            } else if (netto2 < netto3) {
                ergebnis = netto3 - netto2;
                prozent = ergebnis * 100 / netto2;
                prozent23.Text = Convert.ToString(Math.Round(prozent, 2)) + "%";
                angebot23.Text = Convert.ToString(Math.Round(ergebnis, 2)) + "€";
            }
        }
    }
}