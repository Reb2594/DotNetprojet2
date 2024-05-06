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
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return new List<CartLine>();
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method
            List<CartLine> cartLines = GetCartLineList();
            CartLine line = new CartLine();
           
            line.Product = product;
            line.Quantity = quantity;
            if (Lines.Any(x => x.Product == product))
            {
                foreach (CartLine line1 in Lines.Where(x => x.Product == product))
                {
                    line1.Quantity += quantity;
                }
            }
            else
            {
                cartLines.Add(line);
                //this.Lines.Append<CartLine>(line);
            }

        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            // TODO implement the method
            
            List<CartLine> cartLines = GetCartLineList();
            double total = 0.0;
            foreach (CartLine cartline in cartLines)
            {
                
                double price = cartline.Product.Price;
                int quantity = cartline.Quantity;
                double lineTotal = price * quantity;
                total += lineTotal;                
                
            }
            return total;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method
            List<CartLine> cartLines = GetCartLineList();                       
            return GetTotalValue() / cartLines.Count;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method                   
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
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
