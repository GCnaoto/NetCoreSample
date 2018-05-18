using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreEntityFramework.Model
{
    public partial class ModelBase
    {
        [Key]
        public int Id { get; set; }

        private DateTime _UpDate;
        public DateTime UpDate
        {
            get { return _UpDate; }
            set
            {
                if (_UpDate == value)
                    return;
                _UpDate = value;
            }
        }
    }
}
