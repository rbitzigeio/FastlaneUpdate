using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static System.Collections.Generic.Dictionary<string, string>;

namespace Fastlane
{
    public class Reader {
        
        static  Properties props      = Properties.getFastlaneProperties();
        static  String[]   NAMES      = {"", "ADM", "ADM-Vertreter", "MAIL", "SUBSCRIPTION", "RESOURCEGROUPS"};

        private const int  ADMID      = 1;
        private const int  KONTAKTEID = 2;
        private const int  MAILID     = 3;
        private const int  SUBSID     = 4;
        private const int  RGID       = 5;
        
        private int        _readId     = 0;
        private String     _fileName;

        public Reader(String fileName) {
            //Console.WriteLine("- Reader : " + fileName);
            _fileName = fileName;
            if (fileName.EndsWith(props.getAdmFileName())) {
                _readId = ADMID;
            } else if (fileName.EndsWith(props.getKontakteFileName())) {
                _readId = KONTAKTEID;
            } else if (fileName.EndsWith(props.getMailFileName())) {
                _readId = MAILID;
            } else if (fileName.EndsWith(props.getSubscriptionsFileName())) {
                _readId = SUBSID;
            } else if (fileName.EndsWith(props.getResourcegroupsFileName())) {
                _readId = RGID;
            }
        }

        public int getReadId() {
            return _readId;
        }

        public String getFileName() {
            return _fileName;
        }

        public void read() {
            // Console.WriteLine("- Reader : " + _fileName + " Art: " + NAMES[_readId]);
            StreamReader sr = new StreamReader(_fileName);
            String lineIn = sr.ReadLine();
            int i = 0;
            while (lineIn != null) {
                if (i>0) {
                    if (_readId == ADMID && i == 1180) {
                        Console.WriteLine(lineIn);
                    }
                    String line = lineIn.Replace('"',' ');
                    switch(_readId) {
                        case ADMID      : readAdm(line);           break;
                        case KONTAKTEID : readKontakt(line);       break;
                        case MAILID     : readMail(line);          break;
                        case SUBSID     : readSubscription(line);  break;
                        case RGID       : readResourceGroup(line); break;
                        default         : Console.WriteLine("Unknown Status"); break;
                    } 
                }
                i++;
                lineIn = sr.ReadLine();
            }
            sr.Close();
        }

        private void readAdm(String line) {
            //Console.WriteLine("  - Read ADM :" + line);
            String[] array = line.Split(';');
            if (array.Length == 4) {
                IList<Subscription> listOfSubs = Subscription.getSubscriptionByAlmId(array[0].Trim());
                foreach(Subscription sub in listOfSubs) {
                    if (sub != null) {
                        Kontakt adm =new Kontakt(array[3]);
                        adm.isAdm(true);
                        sub.addKontakt(adm);
                    }
                }
            }
        }
        private void readKontakt(String line) {
            Console.WriteLine("  - Read Kontakt ");
        }

        private void readMail(String line) {
            Console.WriteLine("  - Read Mail ");
        }

        private void readSubscription(String line) {
            //Console.WriteLine("  - Read Subscription :" + line);
            String[]     array = line.Split(',');
            Subscription sub   = new Subscription(array[0].Trim());
            sub.setName(array[1].Trim());
            if (array[3].Trim().Length > 0) {
                sub.setAlmId(array[3].Trim());
            }
            if (array[4].Trim().Length > 0) {
                sub.setLS(array[4].Trim());
            }
        }

        private void readResourceGroup(String line) {
            //Console.WriteLine("  - Read ResourceGroup " + line);
            String[] array = line.Split(',');
            Subscription sub = Subscription.getSubscriptionById(array[0].Trim());
            if (sub != null) {
                sub.addResourceGroup(array[2].Trim());
                sub.setAlmId(array[3].Trim());
                sub.setLS(array[4].Trim());
            }
        }
    }    
}