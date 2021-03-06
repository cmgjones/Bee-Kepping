namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    
    [Serialized]
    [Weight(300)]                                          
    public partial class HuckleBerryCreamsItem : //Name of the item in unity @DO NOT CHANGE USE A DIFFERENT NAME FROM THE UNITY VERSION
        FoodItem            
    {
        public override string FriendlyName                     { get { return " Huckle Berry honey creams"; } }  // name given and seen when scrolling through the ingame menus
        public override string Description                      { get { return "A fresh mixtures of huckleberries and honey ground up and frozen to make these delicous treats!"; } } // item description upon hovering over an item

        private static Nutrients nutrition = new Nutrients()    { Carbs = 5, Fat = 20, Protein = 1, Vitamins = 0}; // The effects of eating the item for example mashed potatoe would have more carbs than protein where as steak would be the reverse !!Balance is vital!!
        public override float Calories                          { get { return 700; } } // Number of calories the food will give you >> thew more complicated and resources intesive the recipe the more ballanced and more calories it should give 
        public override Nutrients Nutrition                     { get { return nutrition; } } //Dont touch this :)
    }

    [RequiresSkill(typeof(HomeCookingSkill), 2)]     // use the wiki to identify the different skill lines and put here what they will need for exmaple the more complicated the recipe and more resource intensive the higher the level that should be required.

    public partial class HuckleBerryCreamsRecipe : Recipe // "HuckleBerryCreamsRecipe : Recipe" labels the name of the recipe that will be displayed in the workbench. 
    {
        public HuckleBerryCreamsRecipe() // include the same name as the food you are attempting to create before recipe eg, yourfoodrecipe()
        {
            this.Products = new CraftingElement[] // dont touch this 
            {
                new CraftingElement<HuckleBerryCreamsItem>(), //This is what the recipe will produce this one should be the name of your fooditem
               //things that will be produced 
                
            };
            this.Ingredients = new CraftingElement[] // This is where you will decide what the ingriedients are  to create your food item
            {
                new CraftingElement<HuckleberriesItem>(typeof(HomeCookingEfficiencySkill), 6, HomeCookingEfficiencySkill.MultiplicativeStrategy),  //this is 1 element of crafting see below for more acurate annotation
            //  new , ingriedient , Rawsausage  , what skill its associated with , (4) amount of that ingridient, this is where it counts in the efficiencies leave this here.
            // If you require more ingridients copy and paste the line above and edit it to include another ingridient see below for example
            //copied & Pasted
                new CraftingElement<SugarItem>(typeof(HomeCookingEfficiencySkill), 8, HomeCookingEfficiencySkill.MultiplicativeStrategy),
				new CraftingElement<RiceMilkItem>(typeof(HomeCookingEfficiencySkill), 4, HomeCookingEfficiencySkill.MultiplicativeStrategy),
				
            };
            this.CraftMinutes = CreateCraftTimeValue(typeof(HuckleBerryCreamsRecipe), Item.Get<HuckleBerryCreamsItem>().UILink(), 15, typeof(HomeCookingSpeedSkill)); // check below for annotation
            // how long it will take to craft the item , the recipe name again ,           change this to recipe name     (time taken)
            this.Initialize("HuckleBerryCreams", typeof(HuckleBerryCreamsRecipe));
            //       how its seen in the workbench   , Your recipe name
            CraftingComponent.AddRecipe(typeof(StoveObject), this);
            // add the recipe to craftin table . (workbench needed)
        }
    }
}