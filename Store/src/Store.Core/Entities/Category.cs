using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Description is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { set; get; }
        public ICollection<Item> Items { set; get; }
    }
}
