using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("BasketItems")]
    public class BaskeyItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        //navigation prop
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int BasketID { get; set; }
        public Basket Basket { get; set; }

    }
}