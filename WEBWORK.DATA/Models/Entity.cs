using System;
using System.Collections.Generic;
using System.Text;

namespace WEBWORK.DATA.Models
{
    public class Entity
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
