using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class Item : BaseEntity
    {
        [Required(ErrorMessage = "Code is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Code")]
        public string Code { set; get; }
        [Required(ErrorMessage = "Name is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Price")]
        public double Price { set; get; }
        [Required(ErrorMessage = "Quantity is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public int Quantity { set; get; }
        [Required(ErrorMessage = "Image is required.")]
        [Display(Name = "Image")]
        public string Image { set; get; }
        [DataType(DataType.Text)]
        [Display(Name = "Factory")]
        public string Factory { set; get; }
        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        public string Description { set; get; }
        [DataType(DataType.Text)]
        public bool IsOffer { set; get; }
        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Category")]
        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public ICollection<ItemUniqueSpec> ItemUniqueSpecs { set; get; }
    }
}
