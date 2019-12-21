using BiBuddy.Entities.Abstract;
using BiBuddy.Entities.ValidationRules.FluentValidation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BiBuddy.Entities.Concrete
{
    public class conference:BaseEntity,IEntity
    {
        private readonly ConferenceValidate _conferenceValidator;
        private string _author;
        private string _title;
        private string _booktitle;
        public conference()
        {
            _conferenceValidator = new ConferenceValidate();
        }


        //[ Required]
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
        public string booktitle
        {
            get
            {
                return _booktitle;
            }
            set
            {
                _booktitle = value;
                OnPropertyChanged("booktitle");
            }
        }



        public string editor { get; set; }
        public int? volume { get; set; }
        public int? series { get; set; }
        public string pages { get; set; }
        public string address { get; set; }
        public string organization { get; set; }
        public string publisher { get; set; }

        public string Error
        {
            get
            {
                if (_conferenceValidator != null)
                {
                    var results = _conferenceValidator.Validate(this);
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
                var firstError = _conferenceValidator.Validate(this).Errors.FirstOrDefault(e => e.PropertyName == columnName);
                if (firstError != null)
                    return _conferenceValidator != null ? firstError.ErrorMessage : "";
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
