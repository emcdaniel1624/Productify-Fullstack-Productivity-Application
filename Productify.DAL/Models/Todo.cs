using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productify.DAL.Models
{
    [Table("Todo", Schema="obj")]
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

    }
}
