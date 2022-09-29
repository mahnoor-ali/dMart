namespace DMART.Models.Interfaces
{
    public interface ICartRepository
    {
        public void AddtoCart(CartModel cart);
        public List<CartModel> GetCart();
    }
}