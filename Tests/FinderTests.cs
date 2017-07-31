using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finder;

namespace Tests
{
    [TestClass]
    public class FinderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sql = @"SELECT EMP_ID, LAST_NAME
FROM EMPLOYEE_TBL
WHERE CITY = 'INDIANAPOLIS'
ORDER BY EMP_ID, LAST_NAME DESC;";
            var sut = new KnownStringFinder(new[] { "EMPLOYEE_TBL", "ELEMENTARY", "INVENTORY_TBL" });
            var results = sut.Find(sql);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sql = @"SELECT Orders.OrderID, Customers.CustomerName, Shippers.ShipperName
FROM ((Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID)
INNER JOIN Shippers ON Orders.ShipperID = Shippers.ShipperID);";
            var sut = new KnownStringFinder(new[] { "EMPLOYEE_TBL", "ELEMENTARY", "INVENTORY_TBL", "Customers", "Shippers", "Ship" });
            var results = sut.Find(sql);
        }
    }
}
