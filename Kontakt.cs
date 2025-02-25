using System;

namespace Fastlane
{
    public class Kontakt {
        
        private static List<Kontakt> ListOfKontakte = new List<Kontakt>();

        private String _name;
        private String _email;
        private bool   _isAdm = false;
        private bool   _isAdmVertreter = false;

        public Kontakt() {
        }

        public Kontakt(String name) {
            setName(name);
        }

        public void setName(String name) {
            _name = name;
        }

        public String getName() {
            return _name;
        }

        public void setEMail(String email) {
            _email = email;
        }

        public String getEMail() {
            return _email;
        }

        public void isAdm(bool isAdm) {
            _isAdm = isAdm;
        }

        public void isAdmVertreter(bool isAdmVertreter) {
            _isAdmVertreter = isAdmVertreter;
        }

        public static List<Kontakt> getListOfKontakte() {
            return ListOfKontakte;
        } 

    }
}