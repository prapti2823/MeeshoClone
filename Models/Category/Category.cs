using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeeshoClone.Models.Category
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("ParentCategory")]
        public long? parent_category_id { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
