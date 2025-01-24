using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime
{
    public class CraftingSystem : MonoBehaviour
    {
        [SerializeField] private List<CraftingRecipe> _recipes;

        public bool TryToCombine(string inputA, string inputB, out GameObject output)
        {
            output = _recipes.FirstOrDefault(recipe => (recipe.InputA == inputA && recipe.InputB == inputB) || (recipe.InputA == inputB && recipe.InputB == inputA))?.Output;  
            return output != null;
        }
    }
}