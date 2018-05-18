using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreEntityFramework.Model
{
    public partial class Users : ModelBase
    {
        private string _Application;
        public string Application
        {
            get { return _Application; }
            set
            {
                if (_Application == value)
                    return;
                _Application = value;
            }
        }

        private String _Name;
        public String Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value)
                    return;
                _Name = value;
            }
        }

        private string _AddressId;
        public string AddressId
        {
            get { return _AddressId; }
            set
            {
                if (_AddressId == value)
                    return;
                _AddressId = value;
            }
        }

        private string _Info;
        public string Info
        {
            get { return _Info; }
            set
            {
                if (_Info == value)
                    return;
                _Info = value;
            }
        }
    }
}
