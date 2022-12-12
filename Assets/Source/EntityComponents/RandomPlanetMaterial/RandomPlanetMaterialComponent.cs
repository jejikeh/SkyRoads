using Source.Core;
using UnityEngine;

namespace Source.EntityComponents.RandomPlanetMaterial
{
    public class RandomPlanetMaterialComponent : EntityComponent<RandomPlanetMaterialComponentConfig>
    {
        public RandomPlanetMaterialComponent(RandomPlanetMaterialComponentConfig config) : base(config)
        {
            var mainColor = Shader.PropertyToID(ComponentConfig.MainColor);
            var secondColor = Shader.PropertyToID(ComponentConfig.SecondColor);
            var thirdColor = Shader.PropertyToID(ComponentConfig.ThirdColor);
            var emissionColor = Shader.PropertyToID(ComponentConfig.EmissiveColor);
            var rimColor = Shader.PropertyToID(ComponentConfig.RimColor);
            var rimFalloff = Shader.PropertyToID(ComponentConfig.RimFalloff);
            
            ComponentConfig.Material.SetColor(mainColor, Random.ColorHSV());
            ComponentConfig.Material.SetColor(secondColor, Random.ColorHSV());
            ComponentConfig.Material.SetColor(thirdColor, Random.ColorHSV());
            ComponentConfig.Material.SetColor(emissionColor, Random.ColorHSV());
            ComponentConfig.Material.SetColor(rimColor, Random.ColorHSV());
            ComponentConfig.Material.SetFloat(rimFalloff, Random.Range(0.1f, 5f));
        }

        public override void Update(float timeScale) { }
    }
}