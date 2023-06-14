using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SenzoApp
{
class Program
    { 
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
        }
        private BuildRecipeLists buildRecipeLists;
        public Program()
        {
            buildRecipeLists = new BuildRecipeLists();
        }
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Add Your Recipe!!!");
                Console.WriteLine("1. Add A Recipe!");
                Console.WriteLine("2. Display All Recipes!");
                Console.WriteLine("3. Choose Which Recipe To Display!");
                Console.WriteLine("4. Clear Everything!");
                Console.WriteLine("5. Request Scaled Recipe!");
                Console.WriteLine("6. Reset Quantities Inserted!");
                Console.WriteLine("7. Exit!");

                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        DisplayRecipe();
                        break;
                    case 3:
                        DisplayChosenRecipe();
                        break;
                    case 4:
                        Clear();
                        break;
                    case 5:
                        ScaleRequest();
                        break;
                    case 6:
                        ResetQuantity();
                        break;
                    case 7:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid!");
                        break;
                }
                Console.WriteLine();
            }
        }
        private void AddRecipe()
        {
            List<Recipe> list = new List<Recipe>();

            while (true)
            {
                Console.WriteLine("Please enter the name of your recipe 'exit' when done!:");
                string name = Console.ReadLine();

                if (name == "exit")
                    break;

                Recipe recipe = new Recipe(name);

                Console.Write("Please enter the number of ingredients:");
                int numOfIngre = int.Parse(Console.ReadLine());

                for (int i = 0; i < numOfIngre; i++)
                {
                    Console.Write($"Please enter the name of the ingredient {i + 1}:");
                    string nameOfIngre = Console.ReadLine();
                    Console.Write($"Quantity of that ingredient(for example, 2) {i + 1}: ");
                    double quantity = double.Parse(Console.ReadLine());
                    Console.Write($"Please indicate the unit of measurement(for example, two cups of sugar) {i + 1}: ");
                    string unitOfMeasure = Console.ReadLine();
                    Console.Write($"Please indicate the amount of calories {i + 1}:");
                    int calories = int.Parse(Console.ReadLine());
                    Console.Write($"Which food group does the ingredient belong to? {i + 1}:");
                    string foodgroup = Console.ReadLine();
                    recipe.AddIngredient(nameOfIngre, unitOfMeasure, foodgroup,
                        quantity, calories);
                }
                Console.WriteLine("Please enter the number of steps needed to complete the recipe:");
                int steps = int.Parse(Console.ReadLine());

                for (int i = 0; i < steps; i++)
                {
                    Console.Write($"Please explain how to do the step {i + 1}: ");
                    string descriptions = Console.ReadLine();
                    recipe.AddStep(descriptions);
                }
                buildRecipeLists.AddRecipe(recipe); Console.WriteLine($"Recipe '{name}' added successfully!");
            }
        }
        private void DisplayRecipe()
        {
            List<Recipe> recipes = buildRecipeLists.GetListAlphabetically();
            if (recipes.Count > 0)
            {
                Console.WriteLine("Enjoy This Step, By Step, Recipe");
                foreach (Recipe recipe in recipes)
                {
                    Console.WriteLine(recipe.Name);
                }
            }
            else
            {
                Console.WriteLine("There are no recipes to display!");
            }
        }
        private void DisplayChosenRecipe()
        {
            Console.WriteLine("Please enter the recipe name that you would like to display:");
            string name = Console.ReadLine();
            Recipe recipe = buildRecipeLists.GetRecipeSorted(name);

            if (recipe != null)
            {
                Console.WriteLine($"Recipe '{name}' details:");
                Console.WriteLine($"Ingredients:");

                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"- {ingredient.Name}: {ingredient.UnitOfMeasure} {ingredient.UnitOfMeasure},{ingredient.Calories} calories, {ingredient.Foodgroup} food group");
                }
                Console.WriteLine($"Steps:");

                foreach (Step step in recipe.Steps)
                {
                    Console.WriteLine($"- {step.Descriptions}");
                }
                Console.WriteLine($"Total Calories: {recipe.TotCalories}");

                if (recipe.TotCalories > 300)
                {
                    Console.WriteLine("WARNING: Recipe exceeds 300 calories!");
                }
            }
            else
            {
                Console.WriteLine($"Recipe '{name}' not found!");
            }
        }
        private void Clear()
        {
            Console.WriteLine("Are you sure you would like to clear your data and start a new recipe? (Y/N)");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                buildRecipeLists.Clear();
                Console.WriteLine("Your data has been cleared");
            }
            else
            {
                Console.WriteLine("Cancelled");
            }
        }
        private void ScaleRequest()
        {
            Console.WriteLine("Please enter the name of the recipe that you would like to scale:");
            string name = Console.ReadLine();

            Recipe recipe = buildRecipeLists.GetRecipeSorted(name);

            if (recipe != null)
            {
                Console.WriteLine($"Recipe '{name}' current scale factor: {recipe.ScaleFactor}");
                Console.Write("\nPlease enter a scale factor of 0.5 (half), 2 (double) or 3 (triple:\t).");
                double newScaleFactor = double.Parse(Console.ReadLine());

                recipe.ScaleFactor(newScaleFactor);
                Console.WriteLine($"Recipe '{name}' scaled successfully!");
                DisplayChosenRecipe();
            }
            else
            {
                Console.WriteLine($"Recipe '{name}' not found!");
            }
        }
        private void ResetQuantity()
        {
            Console.WriteLine("Which recipe would you like to reset?");
            string name = Console.ReadLine();
            Recipe recipe = buildRecipeLists.GetRecipeSorted(name);
            if (recipe != null)
            {
                recipe.ResetQuantity();
                Console.WriteLine($"Recipe '{name}' quantities reset successfully!");
            }
            else
            {
                Console.WriteLine($"Recipe '{name}' not found!");
            }
        }
        private void ListAlphabetically()
        {
            List<Recipe> recipes = buildRecipeLists.GetListAlphabetically();

            if (recipes.Count > 0)
            {
                Console.WriteLine("Recipe list (Alphabetical Order):");

                recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name));

                foreach (Recipe recipe in recipes)
                {
                    Console.WriteLine(recipe.Name);
                }
            }
            else
            {
                Console.WriteLine("No recipes found!");
            }
        }
       
    }
   }



    


