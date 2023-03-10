using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApp.Data.Models
{
    public class Student
    {
        private string _fullName;

        [Required(ErrorMessage = "ФИО не может быть пустым, должно содержать от 5 до 100 букв, не может содержать цифры и спецсимволы")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "ФИО должно содержать быть от 5 до 100 символов")]
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (value != null && value != "" && value != " " && !value.Any(char.IsDigit) && !value.Any(char.IsSymbol))
                {
                    _fullName = value;
                }
                else
                {
                    _fullName = "";
                }
            }
        }
        public int ClassId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public int Id { get; set; }

        public virtual Class Class { get; set; }
    }
}
