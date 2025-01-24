using UnityEngine;

namespace Runtime
{
    [CreateAssetMenu(fileName = "Crafting Recipe", menuName = "Game/Crafting/Recipe", order = 0)]
    public class CraftingRecipe : ScriptableObject
    {
        [SerializeField] private string _inputTagA, _inputTagB;
        [SerializeField] private GameObject _output;

        public string InputA => _inputTagA;
        public string InputB => _inputTagB;
        public GameObject Output => _output;
    }
}