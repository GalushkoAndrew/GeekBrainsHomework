using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicService.Data
{
    [Table("Consultations")]
    public class Consultation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultationId { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [ForeignKey(nameof(Pet))]
        public int PetId { get; set; }

        [Column]
        public DateTime ConsultationDate { get; set; }

        [Column]
        public string Description { get; set; }

        public virtual Client Client { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
