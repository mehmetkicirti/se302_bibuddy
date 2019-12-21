using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bibuddy.Entities.ValidationRules.FluentValidation;
using BiBuddy.Entities.Abstract;

namespace BiBuddy.Entities.Concrete
{
    public class article:BaseEntity,IEntity,INotifyPropertyChanged,IDataErrorInfo
    {
        private readonly ArticleValidate _articleValidator;
        private string _author;
        private string _title;
        private string _journal;
        public article()
        {
            _articleValidator = new ArticleValidate();
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

        //Why we do not use DataAnnatotions => because it is a contradiction for Solid Principle S
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
        public string journal 
        {
            get
            {
                return _journal;
            }
            set
            {
                _journal = value;
                OnPropertyChanged("journal");
            }
        }



        public int? volume { get; set; }
        public int? number { get; set; }
        public string pages { get; set; }
        public string doi{ get; set; }

        public string Error 
        {
            get
            {
                if (_articleValidator!=null)
                {
                    var results = _articleValidator.Validate(this);
                    if (results!=null && results.Errors.Any())
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
                var firstError = _articleValidator.Validate(this).Errors.FirstOrDefault(e => e.PropertyName == columnName);
                if (firstError!=null)
                    return _articleValidator!=null ? firstError.ErrorMessage:"";
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
