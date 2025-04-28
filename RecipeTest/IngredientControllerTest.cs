using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeManagementSyst.Controllers;
using RecipeManagementSyst.Data;
using RecipeManagementSyst.Models;

namespace RecipeTest
{
    [TestClass]
    public class IngredientControllerTest
    {
        private readonly RecipeDbContext _context;
        private readonly IngredientController _ingredientController;
        public IngredientControllerTest()
        {
            _ingredientController = new IngredientController(_context);
        }

        [TestMethod]
        public void TestIndexSuccess()
        {
            //Arrange

            //Act
            var index = _ingredientController.Index();

            //Assert
            Assert.IsInstanceOfType<Task>(index);

        }

        [TestMethod]
        public void TestCreateSuccess()
        {
            //Arrange
            var ingredient = new Ingredient();

            //Act
            var create = _ingredientController.Create(ingredient);

            //Assert
            Assert.IsInstanceOfType<Task>(create);

        }

        [TestMethod]
        public void TestEditSuccess()
        {
            //Arrange
            var id = 1;

            //Act
            var edit = _ingredientController.Edit(id);

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
            var delete = _ingredientController.Delete(id);

            //Assert
            Assert.IsInstanceOfType<Task>(delete);
            Assert.AreNotEqual(id, delete.Id);

        }
    }
}
