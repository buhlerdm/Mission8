using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstoreProject.Models
{
    public class Cart
    {
        public List<PurchaseLineItem> Items { get; set; } = new List<PurchaseLineItem>();

        public void AddItem(Book boo, int qty)
        {
            PurchaseLineItem line = Items
                .Where(b => b.Book.BookId == boo.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Items.Add(new PurchaseLineItem
                {
                    Book = boo,
                    Quantity = qty

                });
            }
            else
            {
                line.Quantity = line.Quantity + qty;
            }
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * 5);

            return sum;
        }
    }

   

    public class PurchaseLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
