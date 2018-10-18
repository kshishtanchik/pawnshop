using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeInChilThings.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Thing product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.Id == product.Id)
            .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Thing product)
        {
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e =>decimal.Parse(e.Product.Price.ToString()) * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
    public class CartLine
    {
        public Thing Product { get; set; }
        public int Quantity { get; set; }
    }
}