using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using NicePlayTestTask.UI.Windows;
using NicePlayTestTask.StaticData.Ingredients;

namespace NicePlayTestTask.Meta.CombinationsList
{
    public class CombinationsWindow : OneButtonWindow
    {
        private List<IngredientStaticData> _ingredients;
        
        [SerializeField] private TMP_InputField combinationsText;
        private bool _initialized = false;

        public override TaskCompletionSource<bool> InitAndShow<T>(T data, string titleText = "")
        {
            if (_initialized == false)
            {
                _ingredients = data as List<IngredientStaticData>;
                CalculateCombinations();
                _initialized = true;
            }
            return base.InitAndShow(data, titleText);
        }

        private void CalculateCombinations()
        {
            var result = string.Empty;
            
            for (var i = 0; i < _ingredients.Count; i++)
            {
                result += $"{_ingredients[i].Key} ({_ingredients[i].Cost}) \n";
            }

            combinationsText.text = result;
        }
    }
}