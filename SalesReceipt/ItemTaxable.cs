namespace Lastminute.SalesReceipt
{
    using System.Collections.Generic;
    public class ItemTaxable : Item, ITaxable
    {
        private static List<Tax> taxes = new List<Tax>();
        public static bool ApplyTax(Tax tax)
        {
            return true;
        }
    }
}