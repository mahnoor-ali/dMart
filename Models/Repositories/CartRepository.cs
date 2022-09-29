using DMART.Models.Interfaces;

namespace DMART.Models.Repositories
{
    public class CartRepository: ICartRepository
    {
        private readonly DMARTContext context;
        public CartRepository()
        {
            context = new DMARTContext();
        }

        public void AddtoCart(CartModel cart) 
        {
              //  context.Carts.Add(cart);
              //  context.SaveChanges();
        }
        public List<CartModel> GetCart()
        {
            List<CartModel> items = new List<CartModel>();
            //...... add functn call

            return items;
        }
    }
}
