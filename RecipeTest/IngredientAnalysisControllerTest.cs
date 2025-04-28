using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using RecipeManagementSyst.Controllers;
using RecipeManagementSystemAPI.Controllers;
using RecipeManagementSystemAPI.Models;

namespace RecipeTest
{
    [TestClass]
    public class IngredientAnalysisControllertest
    {
        private readonly RecipeDbContext _context;
        private readonly ILogger<IngredientAnalysisController> _logger;
        private readonly IngredientAnalysisController _ingredientAnalysisController;
        public IngredientAnalysisControllertest()
        {
            _ingredientAnalysisController = new IngredientAnalysisController(_context, _logger);
        }

        [TestMethod]
        public void TestGetPopularIngredientSuccess()
        {
            //Arrange

            //Act
            var get = _ingredientAnalysisController.GetPopularIngredients();

            //Assert
            Assert.IsInstanceOfType<Task>(get);

        }
    }

}
