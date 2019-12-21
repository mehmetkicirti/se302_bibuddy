using BiBuddy.Entities.Abstract;
using BiBuddy.Entities.ValidationRules.FluentValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BiBuddy.Entities.Concrete
{
    public class booklet :BaseEntity,IEntity, INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly BookletValidate _bookletValidator;
        private string _author;
        private string _title;
        public booklet()
        {
            _bookletValidator = new BookletValidate();
        }


        [Required]
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
        [Required]
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

        private int? _year { get; set; }
        private int? _month { get; set; }
        public int? year
        {
            get
            {
                return _year;
            }
            set
            {
                _year = value.HasValue ? value.Value : null as int?;
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


        public string howpublished { get; set; }
        public string address { get; set; }

        public string Error
        {
            get
            {
                if (_bookletValidator != null)
                {
                    var results = _bookletValidator.Validate(this);
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
                var firstError = _bookletValidator.Validate(this).Errors.FirstOrDefault(e => e.PropertyName == columnName);
                if (firstError != null)
                    return _bookletValidator  != null ? firstError.ErrorMessage : "";
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
