using BiBuddy.Entities.Abstract;
using BiBuddy.Entities.ValidationRules.FluentValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BiBuddy.Entities.Concrete
{
    public class book : BaseEntity,IEntity
    {

        private readonly BookValidate _bookValidator;
        private string _author;
        private string _title;
        private int? _volume;
        private string _publisher;
        public book()
        {
            _bookValidator = new BookValidate();
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
        //[Required
        public int? volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;
                OnPropertyChanged("volume");
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



        public int? series { get; set; }
        public string address { get; set; }
        public int? edition { get; set; }
        public string url { get; set; }

        public string Error
        {
            get
            {
                if (_bookValidator != null)
                {
                    var results = _bookValidator.Validate(this);
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
                var firstError = _bookValidator.Validate(this).Errors.FirstOrDefault(e => e.PropertyName == columnName);
                if (firstError != null)
                    return _bookValidator != null ? firstError.ErrorMessage : "";
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
