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

    [RequiresSkill(typeof(HomeCookingSkill), 3)]
    public partial class RiceMilkRecipe : Recipe
    {
        public RiceMilkRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RiceMilkItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<RiceItem>(typeof(HomeCookingEfficiencySkill), 20, HomeCookingEfficiencySkill.MultiplicativeStrategy),

            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(RiceMilkRecipe), Item.Get<RiceMilkItem>().UILink(), 2, typeof(HomeCookingSpeedSkill));
            this.Initialize("RiceMilk", typeof(RiceMilkRecipe));

            CraftingComponent.AddRecipe(typeof(RiceMilkChurnObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]
    [Currency]
    public partial class RiceMilkItem :
    Item
    {
        public override string FriendlyName { get { return "RiceMilk"; } }
        public override string Description { get { return "A base ingridient"; } }

    }

}
