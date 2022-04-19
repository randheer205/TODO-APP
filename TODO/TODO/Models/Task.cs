using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TODO.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public String Name { get; set; }
        public String Priority { get; set; }
        public String DueDate { get; set; }
        public String CategoryName { get; set; }
        public Boolean IsDeleted { get; set; }
        public Boolean Favourite { get; set; }

        [Display(Name = "Category")]
        public virtual int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }
    }
}
