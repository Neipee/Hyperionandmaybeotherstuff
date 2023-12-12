using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace Hyperionandmaybeotherstuff.Items.weapon
{
    public class testsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sword");
            // Tooltip.SetDefault("Throws a projectile");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("testswordpro").Type;
            Item.shootSpeed = 12f;
            Item.healLife = 100;
            Item.buffType = 2;
            Item.buffTime = 300;
        }

    }
}
