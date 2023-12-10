using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Hyperionandmaybeotherstuff.projectiles;

namespace Hyperionandmaybeotherstuff.Items.weapon
{
    public class Hyperion : ModItem
    {
        private int _healCooldownTimer;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hyperion");
            /* Tooltip.SetDefault("Item Ability: Wither Impact RIGHT CLICK\n"
                + "Teleports 10 blocks ahead of you. Then implode dealing 2225 damage to nearby enemies.\n"
                + "Also applies the wither shield scroll ability reducing damage taken and granting\n"
                + "an ❤ Absorption shield for 5 seconds.\n"
                + "✎ Mana cost: none bro it's a melee weapon"); */
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.damage = 2225;
            Item.width = 40;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(gold: 69);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            _healCooldownTimer = 0;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (_healCooldownTimer > 0) // Check if cooldown is active
                {
                    //Item.CloneDefaults(ItemID.RodofDiscord);
                    Item.useStyle = ItemUseStyleID.Swing;
                    Item.useTime = 15;
                    Item.useAnimation = 15;
                    Item.shootSpeed = 1f;
                    Item.damage = 2225;

                    // Teleport 10 tiles ahead in the direction the player is facing
                    Vector2 targetPosition = player.MountedCenter + player.DirectionTo(Main.MouseWorld) * 320;
                    TeleportPlayer(player, targetPosition);

                    Item.shoot = Mod.Find<ModProjectile>("ExplosionProjectile").Type; // Spawn the explosion projectile
                    Item.UseSound = SoundID.Item8;
                    
                }
                else
                {
                    //Item.CloneDefaults(ItemID.RodofDiscord);.
                    Item.useStyle = ItemUseStyleID.Swing;
                    Item.useTime = 15;
                    Item.useAnimation = 15;
                    Item.shootSpeed = 1f;
                    Item.damage = 2225;

                    // Teleport 10 tiles ahead in the direction the player is facing
                    Vector2 targetPosition = player.MountedCenter + player.DirectionTo(Main.MouseWorld) * 320;
                    TeleportPlayer(player, targetPosition);

                    Item.shoot = Mod.Find<ModProjectile>("ExplosionProjectile2").Type; // Spawn the explosion projectile
                    player.AddBuff(ModContent.BuffType<buffs.HealingCooldown>(), 300); // 300 frames = 5 seconds
                    //player.AddBuff(8, 30);
                    player.statLife += 100; // Heal 100 HP
                    if (player.statLife > player.statLifeMax2) // Make sure the player's HP doesn't exceed their max HP
                    {
                        player.statLife = player.statLifeMax2;
                    }
                    Item.UseSound = SoundID.Item122;
                    _healCooldownTimer = 300;
                }
            }
            else
            {
                Item.useStyle = ItemUseStyleID.Rapier;
                Item.CloneDefaults(ItemID.LastPrism);
                Item.useTime = 1;
                Item.useAnimation = 20;
                Item.shootSpeed = 50f;
                Item.damage = 125;
                Item.shoot = ModContent.ProjectileType<ExampleLastPrismHoldout>();/*89 c'est le projectile d'avant*/;
                //Item.UseSound = SoundID.Item40;
            }
            return base.CanUseItem(player);
        }

        private void TeleportPlayer(Player player, Vector2 targetPosition)
        {
            if (Collision.CanHitLine(player.MountedCenter, 0, 0, targetPosition, 0, 0))
            {
                player.Teleport(targetPosition, 31);
                player.AddBuff(8, 30);
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (_healCooldownTimer > 0) // Decrease heal cooldown timer if active
            {
                _healCooldownTimer--;
            }
        }

        /*public override void AddRecipes()
        {
            Mod CalamityMod = ModLoader.GetMod("CalamityMod");
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RodofDiscord, 2);
            recipe.AddIngredient(ItemID.LifeCrystal, 20);
            recipe.AddIngredient(ItemID.FeatherfallPotion, 1);
            recipe.AddIngredient(ItemID.MiniNukeII, 420);

            if (CalamityMod != null && CalamityMod.TryFind<ModItem>("ShadowspecBar", out ModItem ShadowspecBar))
            {
                recipe.AddIngredient(ShadowspecBar.Type, 6);
            }
            if (CalamityMod != null && CalamityMod.TryFind<ModTile>("DraedonsForge", out ModTile DraedonsForge))
            {
                recipe.AddTile(DraedonsForge.Type);
            }
            recipe.Register();
        }*/
    }
}






/*using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Hyperionandmaybeotherstuff.Items
{
    public class Hyperion : ModItem
    {
        private int _healCooldownTimer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hyperion");
            Tooltip.SetDefault("Item Ability: Wither Impact RIGHT CLICK\n"
                                +"Teleports 10 blocks ahead of you. Then implode dealing 2225 damage to nearby enemies.\n"
                                +"Also applies the wither shield scroll ability reducing damage taken and granting\n"
                                +"an ❤ Absorption shield for 5 seconds.\n"
                                +"✎ Mana cost: none bro it's a melee weapon");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.damage = 2225 ;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            _healCooldownTimer = 0;
            //Item.buffType = ModContent.BuffType<Buffs.ExampleCrateBuff>(); // Specify an existing buff to be applied when used.
			//Item.buffTime = 3 * 60 * 60
            
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {

            if (player.altFunctionUse == 2)
            {
                if (_healCooldownTimer > 0) // Check if cooldown is active
                {
                    Item.useTime = 10;
                    Item.useAnimation = 10;
                    Item.shootSpeed = 1f;
                    Item.damage = 2225 ;
                    // Teleport 20 tiles away in the direction of the cursor
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - player.position;
                    direction.Normalize();
                    player.Teleport(player.position + direction * 320, 31);
                    Item.shoot = Mod.Find<ModProjectile>("ExplosionProjectile").Type; // Spawn the explosion projectile
                    Item.UseSound = SoundID.Item8;
                    player.AddBuff(8, 30);

                }
                else
                {
                    Item.useTime = 10;
                    Item.useAnimation = 10;
                    Item.shootSpeed = 1f;
                    Item.damage = 2225 ;
                    // Teleport 20 tiles away in the direction of the cursor
                    Vector2 targetPosition = Main.MouseWorld;
                    Vector2 direction = targetPosition - player.position;
                    direction.Normalize();
                    player.Teleport(player.position + direction * 320, 31);
                    Item.shoot = Mod.Find<ModProjectile>("ExplosionProjectile2").Type; // Spawn the explosion projectile
                    //player.AddBuff(ModContent.BuffType<buffs.HealingCooldown>(), 300); // 300 frames = 5 seconds
                    player.AddBuff(ModContent.BuffType<buffs.HealingCooldown>(), 300); // 300 frames = 5 seconds
                    player.AddBuff(8, 30);
                    player.statLife += 100; // Heal 100 HP
                    if (player.statLife > player.statLifeMax2) // Make sure the player's HP doesn't exceed their max HP
                    {
                        player.statLife = player.statLifeMax2;
                    }
                    Item.UseSound = SoundID.Item122;
                    _healCooldownTimer = 300;
                }
            }
            else
            {
                Item.useTime = 1;
                Item.useAnimation = 20;
                Item.shootSpeed = 50f;
                Item.damage = 125 ;
                //Item.shoot = ProjectileID.None;
                Item.shoot = 89;
                Item.UseSound = SoundID.Item40;
            }
            return base.CanUseItem(player);
        }
        public override void UpdateInventory(Player player)
        {
            if (_healCooldownTimer > 0) // Decrease heal cooldown timer if active
            {
                _healCooldownTimer--;
            }
        }
        public override void AddRecipes() 
        {
            Mod CalamityMod = ModLoader.GetMod("CalamityMod");
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RodofDiscord, 2);
            recipe.AddIngredient(ItemID.LifeCrystal, 20);
            recipe.AddIngredient(ItemID.FeatherfallPotion, 1);
            recipe.AddIngredient(ItemID.MiniNukeII, 420);
            //recipe.AddTile(TileID.Anvils);
            if (CalamityMod != null && CalamityMod.TryFind<ModItem>("ShadowspecBar", out ModItem ShadowspecBar)) 
            {
            recipe.AddIngredient(ShadowspecBar.Type, 6);
            }
            if (CalamityMod != null && CalamityMod.TryFind<ModTile>("DraedoncForge", out ModTile DraedoncForge)) 
            {
            recipe.AddTile(DraedoncForge.Type);
            }
            recipe.Register();
		}
    }
}*/
