using System;
using System.Security;
using System.Text;

namespace Fastlane {
    
//
// Main Program 
// - Zusammenstellung von IT-AM Daten zur Aktualisierung der Zugriffe auf Azure Subscriptions über Fastlane
// - Lesen der IT-AM Daten für ADM und ADM-Vertreter
// - Lesen der exportierten Subscriptions aus Azure
// - Lesen der exportierten ResourceGroups aus Azure
// - Lesen der E-Mail-Daten der ADMs
// - Schreiben eine CSV Datei mit den Subscriptions, ALM-ID, ADM und ADM-Vertreter
//
    class Program {
        
        private static Properties props = null;

        static void Main(string[] args) {
            Console.WriteLine("Fastlane - Update IT-AM");
            props = new Properties();

            initialize();
        }

        static void initialize() {
            Console.WriteLine("- Initialize");
            String folder         = props.getFastlaneFolder();
            Reader subsReader     = new Reader(folder + "\\" + props.getSubscriptionsFileName());
            Reader rgReader       = new Reader(folder + "\\" + props.getResourcegroupsFileName());
            Reader admReader      = new Reader(folder + "\\" + props.getAdmFileName());
            Reader kontakteReader = new Reader(folder + "\\" + props.getKontakteFileName());
            Reader mailReader     = new Reader(folder + "\\" + props.getMailFileName());
            Console.WriteLine("- Read Subscriptions");
            subsReader.read();
            Console.WriteLine("- Read ResourceGroups");
            rgReader.read();
            Console.WriteLine("- Read ADM");
            admReader.read();
            Console.WriteLine("- Read ADM-Vertreter");
            kontakteReader.read();
            Console.WriteLine("- Read Mail Mapping");
            //mailReader.read();
            String output = props.getUpdateFileName();
            StreamWriter sw = new StreamWriter(folder + "\\" + output);
            StringBuilder lineOut = new StringBuilder();
            lineOut.Append("ID; Name; ALMID; ADM; ADM-Vertreter; LS");
            sw.WriteLine(lineOut.ToString());
            Dictionary<String, Subscription> los = Subscription.getSubscriptions();
            int size = 0;
            Console.WriteLine("- Write Update File");
            foreach (String key in los.Keys) {
                size++;
                Subscription sub = los[key];
                IList<Kontakt> listOfKontakte = sub.getListOfKontakte();
                if (listOfKontakte != null) {
                    foreach (Kontakt kontakt in listOfKontakte) {
                        lineOut.Clear();   
                        String adm = sub.getADM();
                        String admvertreter = null;
                        if (kontakt.isAdmVertreter()) {
                            admvertreter = kontakt.getEMail();
                            adm = "";
                        } else {
                            admvertreter = "";
                        }
                        lineOut.Append(sub.getId() + "; " + sub.getName() + "; " + sub.getAlmId() + "; " + adm + "; " + admvertreter + "; " + sub.getLS());
                        sw.WriteLine(lineOut.ToString());
                    }  
                }  else {
                    lineOut.Clear();
                    lineOut.Append(sub.getId() + "; " + sub.getName() + "; " + sub.getAlmId() + "; " + sub.getADM() + "; ;" + sub.getLS());
                    sw.WriteLine(lineOut.ToString());
                }                
                
            }
            sw.Close();
            Console.WriteLine("Anzahl Subscriptions : " + size);
        }
    }

}