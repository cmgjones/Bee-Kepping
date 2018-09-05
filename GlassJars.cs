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

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class GlassJarsRecipe : Recipe
    {
        public GlassJarsRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<GlassJarsItem>(),
            };
            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<GlassItem>(typeof(GlassProduction EfficiencySkill), 4, GlassProductionEfficiencySkill.MultiplicativeStrategy),

            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(GlassJarsRecipe), Item.Get<GlassJarsItem>().UILink(), 2, typeof(GlassProductionSpeedSkill));
            this.Initialize("GlassJars", typeof(GlassJarsRecipe));

            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }


    [Serialized]
    [Weight(1000)]
    [Currency]
    public partial class GlassJarsItem :
    Item
    {
        public override string FriendlyName { get { return "GlassJars"; } }
        public override string Description { get { return "simple jars"; } }

    }

}
