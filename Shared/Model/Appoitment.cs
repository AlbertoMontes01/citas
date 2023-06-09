﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citas.Shared.Model
{
    public class Appoitment
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int PacientId { get; set; }
        public virtual Pacient? Pacient { get; set; }
        
        public int DoctorId { get; set; }
        public virtual Doctors? Doctor { get; set; }
    }
}
