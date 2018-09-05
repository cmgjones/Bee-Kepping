namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;

    [RequiresSkill(typeof(FarmingSkill), 3)]
    public partial class JarOfHoneyRecipe : Recipe
    {
        public JarOfHoneyRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<JarOfHoneyItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassJarsItem>(typeof(FarmingEfficiencySkill), 2, FarmingEfficiencySkill.MultiplicativeStrategy),

            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(JarOfHoneyRecipe), Item.Get<JarOfHoneyItem>().UILink(), 2, typeof(FarmingSpeedSkill));
            this.Initialize("JarOfHoney", typeof(JarOfHoneyRecipe));

            CraftingComponent.AddRecipe(typeof(BeeHiveObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]
    [Currency]
    public partial class JarOfHoneyItem :
    Item
    {
        public override string FriendlyName { get { return "JarOfHoney"; } }
        public override string Description { get { return "A base ingridient"; } }

    }

}
