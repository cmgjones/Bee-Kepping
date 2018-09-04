namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(MinimapComponent))]
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(CraftingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    [RequireComponent(typeof(RoomRequirementsComponent))]

    public partial class RiceMilkChurnObject :
        WorldObject
    {
        public override string FriendlyName { get { return "Rice Milk Churn"; } }


        protected override void Initialize()
        {
            this.GetComponent<MinimapComponent>().Initialize("Crafting");


        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    public partial class RiceMilkChurnItem :
        WorldObjectItem<RiceMilkChurnObject>
    {
        public override string FriendlyName { get { return "Rice Milk Churn"; } }
        public override string Description  { get { return  "Turn rice into milk!!"; } }

        static RiceMilkChurnItem()
        {

        }

    }


    [RequiresSkill(typeof(WoodworkingSkill), 0)]
    public partial class RiceMilkChurnRecipe : Recipe
    {
        public RiceMilkChurnRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<RiceMilkChurnItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                
                new CraftingElement<StoneItem>(typeof(WoodworkingEfficiencySkill), 20, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 20, MetalworkingEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(1, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(RiceMilkChurnRecipe), Item.Get<RiceMilkChurnItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<RiceMilkChurnItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("RiceMilkChurn", typeof(RiceMilkChurnRecipe));
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }
    }
}
