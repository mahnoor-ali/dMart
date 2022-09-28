using DMART.Models.Interfaces;
using DMART.Models.ViewModels;

namespace DMART.Models.Repositories
{
    public class CartRepository: ICartRepository
    {
        private readonly DMARTContext context;
        public CartRepository()
        {
            context = new DMARTContext();
        }

        public void AddtoCart(ProductCartModel cart) 
        {
              //  context.Carts.Add(cart);
              //  context.SaveChanges();
        }
        public List<ProductCartModel> GetCart()
        {
            List<ProductCartModel> items = new List<ProductCartModel>();
            //...... add functn call

            return items;
        }
    }
}
