using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restoran.models
{
    public class TablePosition
    {
        [Key]
        public int TPId { get; set; }

        public string Name { get; set; }

        public List<Table> Tables { get; set; }
    }
}
