using BiBuddy.Entities.Abstract;
using BiBuddy.Entities.ValidationRules.FluentValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BiBuddy.Entities.Concrete
{
    public class manual:BaseEntity,IEntity, INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly ManualValidate _manualValidator;
        private string _author;
        private string _title;
        private int? _year;
        private int? _month;
        public manual()
        {
            _manualValidator = new ManualValidate();
        }


        //[Required]
        public string author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged("author");
            }
        }
        //[Required]
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("title");
            }
        }
        
        public int? year 
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value.HasValue ? value.Value: null as int?;
                OnPropertyChanged("year");
            }
        }
        public int? month
        {
            get
            {
                return _month;
            }
            set
            {
                _month = value.HasValue ? value.Value : null as int?;
                OnPropertyChanged("month");
            }
        }

        public string organization { get; set; }
        public string address { get; set; }
        public int? edition { get; set; }

        public string Error
        {
            get
            {
                if (_manualValidator != null)
                {
                    var results = _manualValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(Environment.NewLine, results.Errors.Select(e => e.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string this[string columnName]
        {
            get
            {
                var firstError = _manualValidator.Validate(this).Errors.FirstOrDefault(e => e.PropertyName == columnName);
                if (firstError != null)
                    return _manualValidator != null ? firstError.ErrorMessage : "";
                return "";
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
