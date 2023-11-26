using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ResponseModels
{
    public class StudentSubjectsResponseDto
    {
        public int Id;
        public int? StudentId;
        public int? SubjectId;
        public double? Marks;
    }
}
