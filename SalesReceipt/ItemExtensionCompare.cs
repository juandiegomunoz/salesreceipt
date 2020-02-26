namespace Lastminute.SalesReceipt
{
    public partial class Item
    {
        // override object.Equals
        public override bool Equals(object obj)
        {
            //
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // Get object
            Item item = obj as Item;

            // Not convertible
            if (item == null) return false;

            // Different Name
            if (this.Name != item.Name) return false;

            // Different Price
            if (this.Price != item.Price) return false;

            // Different Quantity
            if (this.Quantity != item.Quantity) return false;

            // Equals
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            return base.GetHashCode();
        }
    }
}