using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Shared.Entities
{
        public class City
        {
            public int Id { get; set; }

            [Display(Name = "Ciudad")]
            [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string Name { get; set; }

            public int StateId { get; set; }


        [JsonIgnore]
        public State State { get; set; }

        }
    }


