using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApp.Data.Models
{
    public class AcademicYear
    {
        public AcademicYear()
        {
            Classes = new HashSet<Class>();
        }
        private string _year;

        [Required(ErrorMessage = "Введите корректный год (от 1980 до 2023)")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Введите корректный год (от 1980 до 2023)")]
        public string Year 
        {
            get { return _year; }
            set
            {
                if (value != null && value != "" && value != " " && value.All(char.IsDigit) && 1980 <= int.Parse(value) && DateTime.Now.Year >= int.Parse(value))
                {
                    _year = value;
                }
                else
                {
                    _year = "";
                }
            }
        }
        public int Id { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Class> Classes { get; set; }

    }
}
