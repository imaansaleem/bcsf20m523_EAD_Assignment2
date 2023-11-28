using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.RequestModels
{
    public class StudentSubjectsRequestDto
    {
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }
        public double? Marks { get; set; }
    }
}
