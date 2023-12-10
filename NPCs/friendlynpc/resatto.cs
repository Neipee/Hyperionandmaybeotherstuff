using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Personalities;
using Terraria.Audio;
using Hyperionandmaybeotherstuff.Items.armor.lapis_armor;
using Hyperionandmaybeotherstuff.Items.armor.resatto_armor;
using Hyperionandmaybeotherstuff.Items.armor.Squire_armor;
using Hyperionandmaybeotherstuff.Items.armor.Mercenary_armor;
using Hyperionandmaybeotherstuff.Items.armor.Celeste_Set;
using Hyperionandmaybeotherstuff.Items.armor.Starlight_Set;
using Microsoft.CodeAnalysis.CSharp.Syntax;




namespace Hyperionandmaybeotherstuff.NPCs.friendlynpc
{
	[AutoloadHead]
	
	public class resatto : ModNPC
	{
		public const string ShopName1 = "Shop";
		public const string ShopName2 = "Shop";
		public const string ShopName3 = "Shop";
		public const string ShopName4 = "Shop";
		public const string ShopName5 = "Shop";

		public int NumberOfTimesTalkedTo = 0;
		private static Profiles.StackedNPCProfile NPCProfile;
		 private int currentShopIndex = 0;
        private string[] shopNames = { "Shop1", "Shop2", "Shop3", "Shop4", "Shop5" }; // Add more shop names as needed

        public override void SetStaticDefaults()
        {
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Steampunker]; // Utilise les frames du Guide
			NPCID.Sets.ActsLikeTownNPC[Type] = true;


			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
			{
				Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
				Direction = -1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
							  // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
							  // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }
        public override void SetDefaults()
        {
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;

			AnimationType = NPCID.Steampunker;
        }
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				//new FlavorTextBestiaryInfoElement("Hailing from a mysterious greyscale cube world, the Example Person is here to help you understand everything about tModLoader."),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				//new FlavorTextBestiaryInfoElement("Mods.ExampleMod.Bestiary.ExamplePerson")
			});
		}
				public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			/*
			// This code slowly rotates the NPC in the bestiary
			// (simply checking NPC.IsABestiaryIconDummy and incrementing NPC.Rotation won't work here as it gets overridden by drawModifiers.Rotation each tick)
			if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(Type, out NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers))
			{
				drawModifiers.Rotation += 0.001f;

				// Replace the existing NPCBestiaryDrawModifiers with our new one with an adjusted rotation
				NPCID.Sets.NPCBestiaryDrawOffset.Remove(Type);
				NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
			}
			*/
			return true;
		}
		public override ITownNPCProfile TownNPCProfile()
		{
			return NPCProfile;
		}
		/*public override bool CanTownNPCSpawn(int numTownNPCs)
		{
			for (int k = 0; k < Main.maxPlayers; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				// After defeating Vagrant
				if (player.HasItemInAnyInventory(ItemID.DirtBlock))
				{
					ModLoader.GetMod("Hyperionandmaybeotherstuff").Logger.Info("NPC can spawn! Player has a Dirt Block in their inventory.");
					return true;
				}
			}

			ModLoader.GetMod("Hyperionandmaybeotherstuff").Logger.Info("NPC cannot spawn! No player has a Dirt Block in their inventory.");
			return false;
		}*/
		public override float SpawnChance(NPCSpawnInfo spawnInfo) 
		{
			//If any player is underground and has an example item in their inventory, the example bone merchant will have a slight chance to spawn.
			if (spawnInfo.Player.ZoneOverworldHeight && !NPC.AnyNPCs(Type)) {
				return 0.34f;
			}

			//Else, the example bone merchant will not spawn if the above conditions are not met.
			return 0f;
		}
		public override List<string> SetNPCNameList()
        {
            return new List<string> {
				"Resatto"
				//"autre nom", <- ne pas oublier la virgule après les ("")
				}; // Set the NPC's default name
        }




		public override void HitEffect(NPC.HitInfo hit) {
			int num = NPC.life > 0 ? 1 : 5;

			for (int k = 0; k < num; k++) {
				//Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Sparkle>());
			}

			// Create gore when the NPC is killed.
			if (Main.netMode != NetmodeID.Server && NPC.life <= 0) {
				// Retrieve the gore types. This NPC has shimmer and party variants for head, arm, and leg gore. (12 total gores)
				string variant = "";
				if (NPC.IsShimmerVariant) variant += "_Shimmer";
				if (NPC.altTexture == 1) variant += "_Party";
				int hatGore = NPC.GetPartyHatGore();
				int headGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Head").Type;
				int armGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Arm").Type;
				int legGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Leg").Type;

				// Spawn the gores. The positions of the arms and legs are lowered for a more natural look.
				if (hatGore > 0) {
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
				}
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, headGore, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
			}
		}




		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4)) {
				chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.PartyGirlDialogue", Main.npc[partyGirl].GivenName));
			}
			// These are things that the NPC has a chance of telling you when you talk to it.
			chat.Add("Hello, im selling some beginner stuff. Wanna take a look ?");

			NumberOfTimesTalkedTo++;
			if (NumberOfTimesTalkedTo >= 10) {
				//This counter is linked to a single instance of the NPC, so if ExamplePerson is killed, the counter will reset.
				chat.Add("again bro");
			}

			string chosenChat = chat; // chat is implicitly cast to a string. This is where the random choice is made.

			// Here is some additional logic based on the chosen chat line. In this case, we want to display an item in the corner for StandardDialogue4.
			return chosenChat;
		}
  public override void SetChatButtons(ref string button, ref string button2)
    {
        button = Language.GetTextValue("LegacyInterface.28");
        button2 = "Cycle Shop";
		if (currentShopIndex == 0) 
		{
			button = "resatto armor";
		}
		else if (currentShopIndex == 1)
		{
			button = "squire armor";
		}
				else if (currentShopIndex == 2)
		{
			button = "Mercenary armor";
		}
    }

    public override void OnChatButtonClicked(bool firstButton, ref string shop)
    {
        if (firstButton)
        {
			if  (currentShopIndex == 0)
			{
				shop = shopNames[currentShopIndex];
			}
			else if  (currentShopIndex == 1) 
			{
				shop = shopNames[currentShopIndex];
			}
			else if  (currentShopIndex == 2) 
			{
				shop = shopNames[currentShopIndex];
			}
			else if  (currentShopIndex == 3) 
			{
				shop = shopNames[currentShopIndex];
			}
			else if  (currentShopIndex == 4) 
			{
				shop = shopNames[currentShopIndex];
			}

        }
        else
        {
            // Cycle to the next shop
            currentShopIndex = (currentShopIndex + 1) % shopNames.Length;
            Main.NewText($"Switched to {shopNames[currentShopIndex]}");
			Main.NewText($"{currentShopIndex}");
        }
    }

/*public override void AddShops() {
    // Onglet pour l'armure Resatto
    var resattoShop = new NPCShop(Type, ShopName1 + " - Resatto Armor")
        .Add<resatto_Helmet>()
        .Add<resatto_Breastplate>()
        .Add<resatto_Leggings>();

    // Onglet pour l'armure Squire
    var squireShop = new NPCShop(Type, ShopName2 + " - Squire Armor")
        .Add<Squire_Helmet>()
        .Add<Squire_Breastplate>()
        .Add<Squire_Leggings>();

    // Onglet pour l'armure Mercenary
    var mercenaryShop = new NPCShop(Type, ShopName3 + " - Mercenary Armor")
        .Add<Mercenary_Helmet>()
        .Add<Mercenary_Breastplate>()
        .Add<Mercenary_Leggings>();

    // Onglet pour l'armure Celeste
    var celesteShop = new NPCShop(Type, ShopName4 + " - Celeste Armor")
        .Add<Celeste_Helmet>()
        .Add<Celeste_Breastplate>()
        .Add<Celeste_Leggings>();

    // Onglet pour l'armure Starlight
    var starlightShop = new NPCShop(Type, ShopName5 + " - Starlight Armor")
        .Add<Starlight_Helmet>()
        .Add<Starlight_Breastplate>()
        .Add<Starlight_Leggings>();

    // Enregistrez tous les onglets
    resattoShop.Register();
    squireShop.Register();
    mercenaryShop.Register();
    celesteShop.Register();
    starlightShop.Register();
}*/
    public override void AddShops()
    {
        var npcShop = new NPCShop(Type, shopNames[currentShopIndex]);

        switch (currentShopIndex)
        {
            case 0:
                AddShop1(npcShop);
                break;
            case 1:
                AddShop2(npcShop);
                break;
            case 2:
                AddShop3(npcShop);
                break;
            // Add more cases as needed
        }

        npcShop.Register();
    }

    private void AddShop1(NPCShop npcShop)
    {
        npcShop
            .Add<resatto_Helmet>()
            .Add<resatto_Breastplate>()
            .Add<resatto_Leggings>();
    }

    private void AddShop2(NPCShop npcShop)
    {
        npcShop
            .Add<Squire_Helmet>()
            .Add<Squire_Breastplate>()
            .Add<Squire_Leggings>();
    }

    private void AddShop3(NPCShop npcShop)
    {
        npcShop
            .Add<Mercenary_Helmet>()
            .Add<Mercenary_Breastplate>()
            .Add<Mercenary_Leggings>();
    }
		/*public override void SetChatButtons(ref string button, ref string button2) { // What the chat buttons are when you open up the chat UI
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "cycle shop";
		}


		public override void OnChatButtonClicked(bool firstButton, ref string shop) {
			if (firstButton) {
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.

				/*if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack)) {
					SoundEngine.PlaySound(SoundID.Item37); // Reforge/Anvil sound

					Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.HiveBackpack)} to a {Lang.GetItemNameValue(ModContent.ItemType<WaspNest>())}";

					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
					var entitySource = NPC.GetSource_GiftOrReward();

					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(entitySource, ModContent.ItemType<WaspNest>());

					return;
				}*

				shop = ShopName; // Name of the shop tab we want to open.
			}
		}
		public override void AddShops() {
			var npcShop = new NPCShop(Type, ShopName)
				.Add<resatto_Helmet>()
				.Add<resatto_Breastplate>()
				.Add<resatto_Leggings>()
				.Add<Squire_Helmet>()
				.Add<Squire_Breastplate>()
				.Add<Squire_Leggings>()
				.Add<Mercenary_Helmet>()
				.Add<Mercenary_Breastplate>()
				.Add<Mercenary_Leggings>()
				.Add<Celeste_Helmet>()
				.Add<Celeste_Breastplate>()
				.Add<Celeste_Leggings>()
				.Add<Starlight_Helmet>()
				.Add<Starlight_Breastplate>()
				.Add<Starlight_Leggings>();

			npcShop.Register(); // Name of this shop tab
		}

		*/
		public override bool CanGoToStatue(bool toKingStatue) => true;

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		public override void OnGoToStatue(bool toKingStatue) {
		}

		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}

				Dust.NewDustPerfect(NPC.Center + position, DustID.Adamantite, Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileID.FireArrow;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
			// SparklingBall is not affected by gravity, so gravityCorrection is left alone.
		}

		public override void LoadData(TagCompound tag) {
			NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
		}

		public override void SaveData(TagCompound tag) {
			tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
		}
    }
}