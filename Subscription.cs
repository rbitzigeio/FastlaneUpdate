using System;

namespace Fastlane
{
    public class Subscription {
        
        static private Dictionary<String, Subscription> ListOfSubscriptions = new Dictionary<String, Subscription>();

        private String        _id;
        private String        _name;
        private String        _almid;
        private String        _ls;
        private List<Kontakt> _ListOfKontakte = new List<Kontakt>(); 
        private List<String>  _ListOfResourceGroups = new List<String>();

        public Subscription() {
        }

        public Subscription(String id) {
            setId(id);
        }

        public Subscription(String id, String name) {
            setId(id);
            setName(name);
        }

        public Subscription(String id, String name, String almid) {
            setId(id);
            setName(name);
            setAlmId(almid);
        }

        public Subscription(String id, String name, String almid, String ls) {
            setId(id);
            setName(name);
            setAlmId(almid);
            setLS(ls);
        }

        public String getId() {
            return _id;
        }

        public void setId(String id) {
            _id = id;
            if (!ListOfSubscriptions.ContainsKey(_id)) {
                ListOfSubscriptions.Add(_id, this);
            } 
        }

        public String getName() {
            return _name;
        }

        public void setName(String name) {
            _name = name;
        }

        public String getAlmId() {
            return _almid;
        }

        public void setAlmId(String almid) {
            if (_almid != null && _almid.Length == 0) {
                _almid = almid;
            }         
        }

        public String getLS() {
            return _ls;
        }

        public void setLS(String ls) {
            if (_ls != null && _ls.Length == 0) {
                _ls = ls;
            }       
        }

        public List<String> getListOfResourceGroups() {
            return _ListOfResourceGroups;
        }

        public void addResourceGroup(String rg) {
            if (!_ListOfResourceGroups.Contains(rg)) {
                _ListOfResourceGroups.Add(rg);
            }
        }

        public List<Kontakt> getListOfKontakte() {
            return _ListOfKontakte;
        }

        public void addKontakt(Kontakt kontakt) {
            if (!_ListOfKontakte.Contains(kontakt)) {
                _ListOfKontakte.Add(kontakt);
            }
        }

        static public Dictionary<String, Subscription> getSubscriptions() {
            return ListOfSubscriptions;
        }

        static public Subscription getSubscriptionById(String id) {
            Subscription sub;
            if (ListOfSubscriptions.TryGetValue(id, out sub)) {

            }
            return sub;
        }
    }
}