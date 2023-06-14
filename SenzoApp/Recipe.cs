using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SenzoApp
{
    class Recipe
    {

        public string Name { get; set; }
        public int TotCalories { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }

        delegate void RecipeExceedsCaloriesHandler(string recipeName);
        private int CalculateTotCalories()
        {
            int totCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totCalories += ingredient.Calories;
            }
            return totCalories;
        }

        public void NotifyCalorieExceeded()
        {
            if (CalculateTotCalories() > 300)
            {
                Console.WriteLine("Total calories exceed 300!");
            }
        }

                public Recipe(string name)
        {
            TotCalories = 0;
            Name = name;
            Ingredients= new List<Ingredient>();
            Steps = new List<Step>();
        }

        public void AddIngredient(string name, string unitOfMeasure, string foodgroup,
                                  double quantity, int calories)
        {
            Ingredient ingredient = new Ingredient
            {
                Name = name,
                UnitOfMeasure = unitOfMeasure,
                Foodgroup = foodgroup,
                Quantity = quantity,
                Calories = calories
            };
            Ingredients.Add(ingredient);
            TotCalories += calories;
        }
        public void AddStep(string descriptions)
        {
            Step step = new Step
            {
                Descriptions = descriptions
            };
            Steps.Add(step);
        }
        public void ScaleFactor(double factor)
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
            TotCalories = CalculateTotCalories();
        }
        private void Reset()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.Quantity = 0;
            }
            TotCalories = CalculateTotCalories();
        }

        internal void ResetQuantity()
        {
            throw new NotImplementedException();
        }
    }
        

        
        
        
    }

