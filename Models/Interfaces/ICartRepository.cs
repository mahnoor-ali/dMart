using DMART.Models.ViewModels;
namespace DMART.Models.Interfaces
{
    public interface ICartRepository
    {
        public void AddtoCart(ProductCartModel cart);
        public List<ProductCartModel> GetCart();
    }
}