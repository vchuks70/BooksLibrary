using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests
{
   public class BookToFavoriteRequest
    {
        [Required]
        public int BookId { get; set; }
    }
}
