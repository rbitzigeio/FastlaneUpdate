using System;
using System.Collections.Generic;
using System.IO;
using static System.Collections.Generic.Dictionary<string, string>;

namespace Fastlane
{
    public class Properties {

        static private String     PROPFILE = ".Fastlane.properties";
        static public  Properties PROPS    = null; 
        private String FastlaneFolder;
        private String AdmFileName;
        private String KontakteFileName;
        private String MailFileName;
        private String SubscriptionsFileName;
        private String ResourcegroupsFileName;
        
        public Properties() {
            string   homePath = Environment.GetEnvironmentVariable("USERPROFILE");
            if (File.Exists(homePath + "\\" + PROPFILE)) {
                string[] lines = File.ReadAllLines(homePath + "\\" + PROPFILE);
                foreach (string line in lines) {
                    if (!line.StartsWith("#")) {
                        String[] s = line.Split('=');
                        if (s.Length==2) {
                            if (s[0].Equals("FASTLANE_DATA_FOLDER")) {
                                FastlaneFolder = s[1];
                            } else if (s[0].Equals("ADM")) {
                                AdmFileName = s[1];
                            } else if (s[0].Equals("KONTAKTE")) { 
                                KontakteFileName = s[1];
                            } else if (s[0].Equals("MAIL")) { 
                                MailFileName = s[1];
                            } else if (s[0].Equals("SUBSCRIPTIONS")) {
                                SubscriptionsFileName = s[1];
                            } else if (s[0].Equals("RESOURCEGROUPS")) {
                                ResourcegroupsFileName = s[1];
                            }
                        }
                    }
                }
            } else {
                throw new FileNotFoundException(homePath + "\\" + PROPFILE + " existiert nicht!");
            }
            PROPS = this;
        }

        public static Properties getFastlaneProperties() {
            return PROPS;
        }

        public String getFastlaneFolder() {
            return FastlaneFolder;
        }

        public void setFastlaneFolderString (String flf) {
            FastlaneFolder = flf;
        }

        public String getAdmFileName() {
            return AdmFileName;
        }

        public void setAdmFileName(String fileName) {
            AdmFileName = fileName;
        }

        public String getKontakteFileName() {
            return KontakteFileName;
        }

        public void setKontakteFileName(String fileName) {
            KontakteFileName = fileName;
        }

        public String getMailFileName() {
            return MailFileName;
        }

        public void setMailFileName(String fileName) {
            MailFileName = fileName;
        }

        public String getSubscriptionsFileName() {
            return SubscriptionsFileName;
        }

        public void setSubscriptionsFileName(String fileName) {
            SubscriptionsFileName = fileName;
        }

         public String getResourcegroupsFileName() {
            return ResourcegroupsFileName;
        }

        public void setResourcegroupsFileName(String fileName) {
            ResourcegroupsFileName = fileName;
        }

    }
}