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
           
            subsReader.read();
            rgReader.read();
            admReader.read();
            //kontakteReader.read();
            //mailReader.read();
        }
    }

}