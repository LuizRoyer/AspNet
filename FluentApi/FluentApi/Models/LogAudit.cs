using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Models
{
    public class LogAudit
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Modificado { get; set; }
    }
}
