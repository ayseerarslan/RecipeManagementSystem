using RecipeManagementSyst.Controllers;
using RecipeManagementSyst.Data;
using RecipeManagementSyst.Models;

namespace RecipeTest
{
    [TestClass]
    public class RecipeControllerTest
    {
        private readonly RecipeDbContext _context;
        private readonly RecipeController _recipeController;
        public RecipeControllerTest()
        {
            _recipeController = new RecipeController(_context);
        }

        [TestMethod]
        public void TestIndexSuccess()
        {
            //Arrange

            //Act
            var index = _recipeController.Index();

            //Assert
            Assert.IsInstanceOfType<Task>(index);

        }

        [TestMethod]
        public void TestDetailsSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var detail = _recipeController.Details(id);

            //Assert
            Assert.IsInstanceOfType<Task>(detail);
            Assert.AreNotEqual(id, detail.Id);

        }

        [TestMethod]
        public void TestCreateSuccess()
        {
            //Arrange
            var recipe = new Recipe();

            //Act
            var create = _recipeController.Create(recipe);

            //Assert
            Assert.IsInstanceOfType<Task>(create);

        }

        [TestMethod]
        public void TestEditSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var edit = _recipeController.Edit(id);

            //Assert
            Assert.IsInstanceOfType<Task>(edit);
            Assert.AreEqual(id, edit.Id);

        }

        [TestMethod]
        public void TestDeleteSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var delete = _recipeController.Delete(id);

            //Assert
            Assert.IsInstanceOfType<Task>(delete);
            Assert.AreNotEqual(id, delete.Id);

        }

    }
}
