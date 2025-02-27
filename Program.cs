using System;

namespace Fastlane {
    
//
// Main Program 
// - Zusammenstellung von IT-AM Daten zur Aktualisierung der Zugriffe auf AZure Subscriptions über Fastlane
// 
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
            //kontakteReader.read();
            Console.WriteLine("- Read Mail Mapping");
            //mailReader.read();

            Dictionary<String, Subscription> los = Subscription.getSubscriptions();
            int size = 0;
            foreach (String key in los.Keys) {
                size++;
                Subscription sub = los[key];
                Console.WriteLine(sub.getId() + "; " + sub.getName() + "; " + sub.getAlmId() + "; " + sub.getADM() + "; " + sub.getLS());
            }
            Console.WriteLine("Anzahl Subscriptions : " + size);
        }
    }

}