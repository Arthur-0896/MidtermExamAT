namespace LaptopDiscount.nunittests
{
    public class Tests
    {
        EmployeeDiscount? employeeDiscount { get; set; } = null;
        [SetUp]
        public void Setup()
        {
            employeeDiscount = new EmployeeDiscount();
            employeeDiscount.Price = 100;
        }

        // Check whether discounts are getting calculated correctly depending on the Employee Type.
        [TestCase(EmployeeType.PartTime)]
        [TestCase(EmployeeType.FullTime)]
        [TestCase(EmployeeType.PartialLoad)]
        [TestCase(EmployeeType.CompanyPurchasing)]
        public void EmployeeDiscount_CalculateDiscountedPrice_validateDiscountbasedOnEmployeeType(EmployeeType employeeType)
        {
            if (EmployeeType.PartTime == employeeType)
            {
                employeeDiscount.EmployeeType = employeeType;
                decimal price = employeeDiscount.Price;
                decimal discount = price - (price * 0);

                Assert.That(discount, Is.EqualTo(employeeDiscount.CalculateDiscountedPrice()));
            }
            else if (EmployeeType.FullTime == employeeType)
            {
                employeeDiscount.EmployeeType = employeeType;
                decimal price = employeeDiscount.Price;
                decimal discount = price - (price * 0.10m);

                Assert.That(discount, Is.EqualTo(employeeDiscount.CalculateDiscountedPrice()));
            }
            else if (EmployeeType.PartialLoad == employeeType)
            {
                employeeDiscount.EmployeeType = employeeType;
                decimal price = employeeDiscount.Price;
                decimal discount = price - (price * 0.05m);

                Assert.That(discount, Is.EqualTo(employeeDiscount.CalculateDiscountedPrice()));
            }
            else if (EmployeeType.CompanyPurchasing == employeeType)
            {
                employeeDiscount.EmployeeType = employeeType;
                decimal price = employeeDiscount.Price;
                decimal discount = price - (price * 0.20m);

                Assert.That(discount, Is.EqualTo(employeeDiscount.CalculateDiscountedPrice()));
            }
        }

        // Check valid enum values
        [TestCase(EmployeeType.PartTime)]
        [TestCase(EmployeeType.FullTime)]
        [TestCase(EmployeeType.PartialLoad)]
        [TestCase(EmployeeType.CompanyPurchasing)]
        public void EmployeeDiscount_CalculateDiscountedPrice_validateEmployeeTypeField(EmployeeType employeeType)
        {
            Assert.That(employeeType, Is.AnyOf(EmployeeType.PartTime, EmployeeType.FullTime, EmployeeType.PartialLoad, EmployeeType.CompanyPurchasing));
        }
    }
}