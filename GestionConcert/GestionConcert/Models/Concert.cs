using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDisque.Models
{
    public class Concert
    {
        public int id { get; set; }

        [MaxLength(150)]
        public String nom { get; set; }

        [MaxLength(100)]
        public String salle { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }

    }
}
