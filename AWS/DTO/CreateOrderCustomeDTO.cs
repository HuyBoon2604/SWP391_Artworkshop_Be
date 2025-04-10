namespace AWS.DTO
{
    public class CreateOrderCustomeDTO
    {
        public string UserID { get; set; }
        public string ArtwokCustomeID { get; set; }
        public decimal  Money { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
