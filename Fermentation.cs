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
    [RequireRoomContainment]
    [RequireRoomVolume(25)]                              
    public partial class FermentationObject : 
        WorldObject    
    {
        public override string FriendlyName { get { return "Cjs mod crafting bench"; } } 


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
    public partial class FermentationItem :
        WorldObjectItem<FermentationObject> 
    {
        public override string FriendlyName { get { return "Cj's Mod bench"; } } 
        public override string Description  { get { return  "Craft all the coolest items from Cj's modpack with this thing!"; } }

        static FermentationItem()
        {
            
        }

    }


    [RequiresSkill(typeof(WoodworkingSkill), 0)]
    public partial class FermentationRecipe : Recipe
    {
        public FermentationRecipe()
        {
            this.Products = new CraftingElement[]
            {
                new CraftingElement<FermentationItem>(),
            };

            this.Ingredients = new CraftingElement[]
            {
                new CraftingElement<LogItem>(typeof(WoodworkingEfficiencySkill), 30, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<StoneItem>(typeof(WoodworkingEfficiencySkill), 20, WoodworkingEfficiencySkill.MultiplicativeStrategy),
                new CraftingElement<IronIngotItem>(typeof(MetalworkingEfficiencySkill), 10, MetalworkingEfficiencySkill.MultiplicativeStrategy),				
            };
            SkillModifiedValue value = new SkillModifiedValue(1, WoodworkingSpeedSkill.MultiplicativeStrategy, typeof(WoodworkingSpeedSkill), Localizer.DoStr("craft time"));
            SkillModifiedValueManager.AddBenefitForObject(typeof(FermentationRecipe), Item.Get<FermentationItem>().UILink(), value);
            SkillModifiedValueManager.AddSkillBenefit(Item.Get<FermentationItem>().UILink(), value);
            this.CraftMinutes = value;
            this.Initialize("CjsFermentation", typeof(FermentationRecipe));
            CraftingComponent.AddRecipe(typeof(RiceMilkChurnObject), this);
        }
    }
}