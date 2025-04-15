using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Delete
{
    public class DeleteUserRequest
    {
        public int Id { get; set; }
        public DeleteMode Mode { get; set; }
    }

    public enum DeleteMode
    {
        Logical = 1,
        Physical = 2
    }


}
