using System.ComponentModel.DataAnnotations;

namespace MeeshoClone.Models.Product
{
    public class Size
    {
        [Key]
        public long Id { get; set; }
        public long SizeId { get; set; }
    }
}
