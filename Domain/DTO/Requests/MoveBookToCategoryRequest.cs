using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.Requests
{
   public class MoveBookToCategoryRequest
    {
        [Required]
        public int CurrentBookCateogryId { get; set; }
        [Required]
        public int NewBookCategoryId { get; set; }
    }
}
