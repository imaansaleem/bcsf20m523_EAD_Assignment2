﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DbModels

{
    public class StudentSubjectDbDto
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double marks { get; set; }

        public StudentDbDto Student { get; set; }
        public SubjectDbDto Subject { get; set; }
    }
}
