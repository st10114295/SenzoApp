using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenzoApp
{
    class BuildRecipeLists
    {
        private List<Recipe> recipes = new List<Recipe>();
        public BuildRecipeLists()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }
        public void Clear()
        {
            recipes.Clear();
        }
        public List<Recipe> GetListAlphabetically()
        {
            return recipes.OrderBy(r => r.Name).ToList();
        }
        public Recipe GetRecipeSorted(string name)
        { 
            return recipes.FirstOrDefault(r => r.Name == name);
        }
    }
}

   
