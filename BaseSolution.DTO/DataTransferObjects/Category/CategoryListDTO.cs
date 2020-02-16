using BaseSolution.DTO.Filter;
using System;

namespace BaseSolution.DTO.DataTransferObjects.Category
{
    public class CategoryListDTO:IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
