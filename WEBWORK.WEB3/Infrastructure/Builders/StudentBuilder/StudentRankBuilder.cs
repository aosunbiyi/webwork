using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;

namespace WEBWORK.WEB3.Infrastructure.Builders.StudentBuilder
{
    public class StudentRankBuilder : StudentBuilder
    {
        public StudentRankBuilder(Student st): base(st)
        {
            this.student = st;
        }

        public StudentRankBuilder At(string position)
        {
            this.student.Position = position;
            return this;
        }

        public StudentRankBuilder AsA(string rankName)
        {
            this.student.RankName = rankName;
            return this;
        }
    }
}
