using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseSolution.DTO.DataTransferObjects.Category
{
    public class NewCategoryDTO
    {
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
        //public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
