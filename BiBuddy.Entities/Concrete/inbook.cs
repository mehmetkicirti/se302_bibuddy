using BiBuddy.Entities.Abstract;
using BiBuddy.Entities.ValidationRules.FluentValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BiBuddy.Entities.Concrete
{
    public class inbook:BaseEntity,IEntity, INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly InBookValidate _inbookValidator;
        private string _author;
        private string _title;
        private string _publisher;
        private int? _chapter;
        public inbook()
        {
            _inbookValidator = new InBookValidate();
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
        //[Required]
        public int? chapter
        {
            get
            {
                return _chapter;
            }
            set
            {
                _chapter = value.HasValue ? value.Value : null as int?;
                OnPropertyChanged("chapter");
            }
        }
        //[Required]
        public string publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                _publisher = value;
                OnPropertyChanged("publisher");
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


        public int? volume { get; set; }
        public int? series { get; set; }
        public string address { get; set; }
        public int? edition { get; set; }
        public string type{ get; set; }

        public string Error
        {
            get
            {
                if (_inbookValidator != null)
                {
                    var results = _inbookValidator.Validate(this);
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
                var firstError = _inbookValidator.Validate(this).Errors.FirstOrDefault(e => e.PropertyName == columnName);
                if (firstError != null)
                    return _inbookValidator != null ? firstError.ErrorMessage : "";
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
