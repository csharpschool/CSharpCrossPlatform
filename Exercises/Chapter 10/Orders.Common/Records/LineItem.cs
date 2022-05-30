namespace Orders.Common;
public record LineItem
{
        public int Id { get; } = default;
        public int OrderId { get; } = default;
        public string Product { get; } = string.Empty;
        public int Quantity { get; } = default;
        public double Price { get; } = default;
        private double _vat = default;
        public double Vat =>
            this switch
            {
                var (vat) when vat >= 1 && vat <= 100 => vat / 100,
                var (vat) when vat > 0 && vat < 1 => vat,
                _ => 0
            };
        public double Total => Quantity * Price * (Vat + 1);
        public double VatCost => Quantity * Price * Vat;

        public LineItem(int orderId, int id, string product, int quantity, double price, double vat)
        {
            try
            {
                if (orderId < 1) throw new ArgumentException("The order id must be greater than 0");
                else if (id < 1) throw new ArgumentException("The id must be greater than 0");
                else if (product.Equals(string.Empty) || product == default)
                    throw new ArgumentException("The product name cannot be empty.");
                else if (quantity < 1)
                    throw new ArgumentException("The quantity must be greater than 0.");
                else if (price <= 0)
                    throw new ArgumentException("The price must be greater than or equal to 0.");
                else if (vat < 0)
                    throw new ArgumentException("he VAT must be greater than 0.");

                OrderId = orderId;
                Id = id;
                Product = product;
                Quantity = quantity;
                Price = price;
                _vat = vat;
            }
            catch(Exception ex)
            {
                ex.Data.Add("Order Id", orderId);
                ex.Data.Add("Line Item Id", id);
                ex.Data.Add("Product", product);
                ex.Data.Add("Quantity", quantity);
                ex.Data.Add("Price", price);
                ex.Data.Add("VAT", vat);
                throw ex;
            }
        }
        
        private void Deconstruct(out double vat) => (vat) = (_vat);
}