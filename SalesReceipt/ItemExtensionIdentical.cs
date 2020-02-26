namespace Lastminute.SalesReceipt
{
    public static class ItemExtensionCompare
    {
        // override object.Equals
        public static bool IsIdentical(this Item item, Item itemOther)
        {

            // Different Name
            if (item.Name != itemOther.Name) return false;

            // Different Price
            if (item.Price != itemOther.Price) return false;

            // Different Quantity
            if (item.Quantity != itemOther.Quantity) return false;

            // Equals
            return true;
        }
    }
}