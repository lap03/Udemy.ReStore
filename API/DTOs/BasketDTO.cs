namespace API.DTOs
{
    public class BasketDTO
    {
        public int Id { get; set; }
        public string BuyerID { get; set; }
        public List<BasketItemDTO> Items { get; set; }
    }
}
