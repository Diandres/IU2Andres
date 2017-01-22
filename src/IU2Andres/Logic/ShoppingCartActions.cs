//using IU2Andres.Data;
//using IU2Andres.Models.WebShopModels;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IU2Andres.Logic
//{
//    public class ShoppingCartActions : IDisposable
//    {
//        public string ShoppingCartId { get; set; }

//        private ApplicationDbContext _context;

//        public const string CartSessionKey = "CartId";



//        public void AddToCart(int id)
//        {
//            // Retrieve the product from the database.           
//            ShoppingCartId = GetCartId();

//            var cartItem = _context.ShoppingCartItems.SingleOrDefault(
//                c => c.CartId == ShoppingCartId
//                && c.ProductId == id);
//            if (cartItem == null)
//            {
//                // Create a new cart item if no cart item exists.                 
//                cartItem = new CartItem
//                {
//                    ItemId = Guid.NewGuid().ToString(),
//                    ProductId = id,
//                    CartId = ShoppingCartId,
//                    Product = _context.Products.SingleOrDefault(
//                    p => p.ProductID == id),
//                    Quantity = 1,
//                    DateCreated = DateTime.Now
//                };

//                _context.ShoppingCartItems.Add(cartItem);
//            }
//            else
//            {
//                // If the item does exist in the cart,                  
//                // then add one to the quantity.                 
//                cartItem.Quantity++;
//            }
//            _context.SaveChanges();
//        }

//        public void Dispose()
//        {
//            if (_context != null)
//            {
//                _context.Dispose();
//                _context = null;
//            }
//        }

//        public string GetCartId()
//        {
//            if (HttpContext.Current.Session[CartSessionKey] == null)
//            {
//                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
//                {
//                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
//                }
//                else
//                {
//                    // Generate a new random GUID using System.Guid class.     
//                    Guid tempCartId = Guid.NewGuid();
//                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
//                }
//            }
//            return HttpContext.Current.Session[CartSessionKey].ToString();
//        }

//        public List<CartItem> GetCartItems()
//        {
//            ShoppingCartId = GetCartId();

//            return _context.ShoppingCartItems.Where(
//                c => c.CartId == ShoppingCartId).ToList();
//        }
//    }
//}
