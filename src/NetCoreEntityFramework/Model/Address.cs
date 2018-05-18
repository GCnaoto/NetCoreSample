using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreEntityFramework.Model
{
    public partial class Addresses : ModelBase
    {
        private string _AddressName;
        public string AddressName
        {
            get { return _AddressName; }
            set
            {
                if (_AddressName == value)
                    return;
                _AddressName = value;
            }
        }
    }
}
