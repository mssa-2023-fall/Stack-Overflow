using Restaurant;

namespace LearnImmutable
{
    [TestClass]
    public class ProteinSelection
    {
        RestaurantMenu menu;

        [TestInitialize]
        public void TestSetup()
        {
            menu = new RestaurantMenu();
        }
        [TestMethod]
        [DataRow("Beef", "hamburger")]
        [DataRow("Pepperoni", "pepperoni pizza")]
        [DataRow("Pork", "Sorry we do not serve that protein.")]
        public void TestMethod1(string proteinChoice, string menuItem)
        {
            string dish = menu.MealForProtein(proteinChoice);
            Assert.AreEqual(menuItem, dish, true);
        }
    }
}