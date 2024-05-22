using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public List<CartLine> Lines;

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return new List<CartLine>();
        }

        public Cart()
        {
            Lines = GetCartLineList();
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // DONE implement the method           

            CartLine line = Lines.FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                Lines.Add(new CartLine { Product = product, Quantity = quantity });

            }
            else
            {
                if (line.Quantity < line.Product.Stock)
                {
                    line.Quantity += quantity;
                }
                
            }

        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            Lines.RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // DONE implement the method            
            
            double total = 0.0;
            if (Lines != null)
            {
                foreach (CartLine cartLine in Lines)
                {

                    total += (cartLine.Product.Price * cartLine.Quantity);                                    

                }

                return total;
            }
            else
            {
                return total;
            }
            
            
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // DONE implement the method
            if (Lines != null && Lines.Count>0 )
            {
                int totalQuantity = 0;
                foreach (CartLine cartLine in Lines)
                {
                   totalQuantity += cartLine.Quantity;
                }
                return GetTotalValue() / totalQuantity;
            }
            else
            {
                return 0.0;
            }
           
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // DONE implement the method                   
            CartLine cartLine = new CartLine();
            if (cartLine.Product.Id == productId)
            {
                return cartLine.Product;
            }
            else
            {
                return null;
            }            
            
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            Lines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
