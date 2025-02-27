using System;

namespace Fastlane
{
    public class Subscription {
        
        static private Dictionary<String, Subscription> _ListOfSubscriptions = new Dictionary<String, Subscription>();

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
            if (!_ListOfSubscriptions.ContainsKey(_id)) {
                _ListOfSubscriptions.Add(_id, this);
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
            if (_almid == null && almid.Length > 0) {
                _almid = almid;
            }         
        }

        public String getLS() {
            return _ls;
        }

        public void setLS(String ls) {
            if (_ls == null && ls.Length > 0) {
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

        public String getADM() {
            String name = null;
            foreach (Kontakt k in _ListOfKontakte) {
                if (k.isAdm()) {
                    name = k.getName();
                }              
            }
            return name;
        }

        static public Dictionary<String, Subscription> getSubscriptions() {
            return _ListOfSubscriptions;
        }

        static public IList<Subscription> getSubscriptionByAlmId(String id) {
            IList<Subscription> listOfSubs = new List<Subscription>();
            foreach (String key in _ListOfSubscriptions.Keys) {
                Subscription sub = _ListOfSubscriptions[key];
                if (sub != null && sub.getAlmId() != null && sub.getAlmId().Equals(id)) {
                    listOfSubs.Add(sub);
                }
            }
            return listOfSubs;
        }

        static public Subscription getSubscriptionById(String id) {
            Subscription target = null;
            foreach (String key in _ListOfSubscriptions.Keys) {
                Subscription sub = _ListOfSubscriptions[key];
                if (sub != null && sub.getId() != null && sub.getId().Equals(id)) {
                    target = sub;
                }
                if (target != null) {
                    break;
                }
            }
            return target;
        }
    }
}