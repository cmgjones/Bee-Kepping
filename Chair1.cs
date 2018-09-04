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
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidGroundComponent))]
    public partial class Chair1Object :
        WorldObject
    {
        public override string FrienadfdlyName { get { return "Chair1"; } } 


        protected override void Initialize()
        {
            this.GetComponent<HousingComponent>().Set(Chair1Item.HousingVal);


        }

        public override void Destroy()
        {
            base.Destroy();
        }

    }

    [Serialized]
    public partial class Chair1Item :
        WorldObjectItem<Chair1Object>
    {
        public override string FriendlyName { get { return "Chair1"; } }
        public override string Description  { get { return  "A raised surface supported by legs. Without the back, it might be a stool."; } }

        static Chair1Item()
        {

        }

        [TooltipChildren] public HousingValue HousingTooltip { get { return HousingVal; } }
        [TooltipChildren] public static HousingValue HousingVal { get { return new HousingValue()
                                                {
                                                    Category = "General",
                                                    Val = 0.5f,
                                                    TypeForRoomLimit = "Seating",
                                                    DiminishingReturnPercent = 0.9f
        };}}
    }


    [RequiresSkill(typeof(WoodworkingSkill), 2)]
    public partial class Chair1Recipe : Recipe
    {
        public Chair1Recipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<Chair1Item>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(WoodworkingEfficiencySkill), 20, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<BoardItem>(typeof(WoodworkingEfficiencySkill), 20, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<PlantFibersItem>(typeof(WoodworkingEfficiencySkill), 30, WoodworkingEfficiencySkill.MultiplicativeStrategy),
            };
            SkillModifiedValue value = new SkillModifiedValue(5, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(Chair1Recipe), Item.Get<Chair1Item>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<Chair1Item>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("Chair1", typeof(Chair1Recipe));
            CraftingComponent.AddRecipe(typeof(ModbenchObject), this);
        }
    }
}
