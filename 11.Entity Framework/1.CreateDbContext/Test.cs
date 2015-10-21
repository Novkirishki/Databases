namespace _1.CreateDbContext
{
    using System;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Linq;

    public class Test
    {
        public static void Main()
        {
            DatabaseAccess.InsertCustomer("AAAAA", "Telerik", "aaa", "bbb", "Mladost 1", "Sofia", "Mladost", "2506", "Bulgaria", "0885555555", "094-2132-12");

            Customer customer;
            using (var db = new NorthwindEntities())
            {
                customer = db.Customers.Where(c => c.CompanyName == "Telerik").First();
            }

            DatabaseAccess.UpdateCustomerPhone(customer.CustomerID, "0886666666");            

            DatabaseAccess.DeleteCustomer(customer.CustomerID);

            DatabaseAccess.CustomersWithOrdersShippedToCanadaIn1997();

            DatabaseAccess.CustomersWithOrdersShippedToCanadaIn1997NativeSQL();

            DatabaseAccess.GetSalesBetween(new DateTime(1997, 6, 1), new DateTime(1997, 7, 15));

            //When we try to make concurrent changes with two database context the last one to call save changes wins :)
            DatabaseAccess.MakeConcurrentChanges();
        }
    }
}
