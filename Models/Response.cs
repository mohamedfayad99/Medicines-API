namespace EMedicineBE.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Users> listusers { get; set; }
        public Users user { get; set; }
        public List<Medicines> listmedicines { get; set; }
        public Medicines medicine { get; set; }
        public List<Orders> listorders { get; set; }
        public Orders order { get; set; }
        public List<Cart> Carts { get; set; }
        public List<OrderItems> listorderitems { get; set; }
        public OrderItems OrderItem { get; set; }



    }
}
