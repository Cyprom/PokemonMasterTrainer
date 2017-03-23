using System.Collections.Generic;
using System.Linq;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data.Properties;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class ChipLoader
    {
        public static List<Chip> LoadChips(Rarity rarity)
        {
            switch (rarity)
            {
                case Rarity.Starter: return LoadStarterChips();
                case Rarity.Pink: return LoadPinkChips();
                case Rarity.Green: return LoadGreenChips();
                case Rarity.Blue: return LoadBlueChips();
                case Rarity.Red: return LoadRedChips();
                case Rarity.Yellow: return LoadYellowChips();
                default: return LoadStarterChips().Concat(LoadPinkChips()).Concat(LoadGreenChips()).Concat(LoadBlueChips()).Concat(LoadRedChips()).Concat(LoadYellowChips()).ToList();
            }
        }

        private static List<Chip> LoadStarterChips()
        {
            return new List<Chip>
            {
                new Chip(1,"Bulbasaur", "Leech Seed", 5, 4, new int[0], Rarity.Starter, Resources.Bulbasaur, Resources.Starter),
                new Chip(4,"Charmander", "Ember", 5, 4, new int[0], Rarity.Starter, Resources.Charmander, Resources.Starter),
                new Chip(7, "Squirtle", "Water Gun", 5, 4, new int[0], Rarity.Starter, Resources.Squirtle, Resources.Starter)
            };
        }

        private static List<Chip> LoadPinkChips()
        {
            return new List<Chip>
            {
                new Chip(69, "Bellsprout", "Wrap", 2, 2, new[] { 3, 4, 5, 6 }, Rarity.Pink, Resources.Bellsprout, Resources.Pink),
                new Chip(10, "Caterpie", "String Shot", 2, 1, new[] { 3, 4, 5, 6 }, Rarity.Pink, Resources.Caterpie, Resources.Pink),
                new Chip(35, "Clefairy", "Stomp", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Clefairy, Resources.Pink),
                new Chip(104, "Cubone", "Bone Club", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Cubone, Resources.Pink),
                new Chip(50, "Diglett", "Headbutt", 2, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Diglett, Resources.Pink),
                new Chip(84, "Doduo", "Peck", 2, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Doduo, Resources.Pink),
                new Chip(96, "Drowzee", "Confusion", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Drowzee, Resources.Pink),
                new Chip(23, "Ekans", "Poison Sting", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Ekans, Resources.Pink),
                new Chip(118, "Goldeen", "Peck", 2, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Goldeen, Resources.Pink),
                new Chip(88, "Grimer", "Poison Gas", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Grimer, Resources.Pink),
                new Chip(116, "Horsea", "Bubble", 2, 1, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Horsea, Resources.Pink),
                new Chip(39, "Jigglypuff", "Sing", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Jigglypuff, Resources.Pink),
                new Chip(109, "Koffing", "Poison Gas", 2, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Koffing, Resources.Pink),
                new Chip(98, "Krabby", "Vice Grip", 2, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Krabby, Resources.Pink),
                new Chip(129, "Magikarp", "Splash", 1, 0, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Magikarp, Resources.Pink),
                new Chip(81, "Magnemite", "Thundershock", 2, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Magnemite, Resources.Pink),
                new Chip(56, "Mankey", "Karate Chop", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Mankey, Resources.Pink),
                new Chip(52, "Meowth", "Bite", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Meowth, Resources.Pink),
                new Chip(29, "Nidoran Female", "Horn Attack", 2, 2, new[] { 3, 4, 5, 6 }, Rarity.Pink, Resources.NidoranF, Resources.Pink),
                new Chip(32, "Nidoran Male", "Double Kick", 2, 2, new[] { 3, 4, 5, 6 }, Rarity.Pink, Resources.NidoranM, Resources.Pink),
                new Chip(43, "Oddish", "Absorb", 2, 2, new[] { 3, 4, 5, 6 }, Rarity.Pink, Resources.Oddish, Resources.Pink),
                new Chip(46, "Paras", "Scratch", 3, 1, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Paras, Resources.Pink),
                new Chip(16, "Pidgey", "Gust", 2, 2, new[] { 3, 4, 5, 6 }, Rarity.Pink, Resources.Pidgey, Resources.Pink),
                new Chip(25, "Pikachu", "Thundershock", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Pikachu, Resources.Pink),
                new Chip(60, "Poliwag", "Bubble", 2, 2, new[] { 3, 4, 5, 6 }, Rarity.Pink, Resources.Poliwag, Resources.Pink),
                new Chip(54, "Psyduck", "Scratch", 3, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Psyduck, Resources.Pink),
                new Chip(19, "Rattata", "Quick Attack", 2, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Rattata, Resources.Pink),
                new Chip(27, "Sandshrew", "Sand Attack", 3, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Sandshrew, Resources.Pink),
                new Chip(86, "Seel", "Water Gun", 2, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Seel, Resources.Pink),
                new Chip(90, "Shellder", "Clamp", 3, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Shellder, Resources.Pink),
                new Chip(79, "Slowpoke", "Confusion", 3, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Slowpoke, Resources.Pink),
                new Chip(21, "Spearow", "Peck", 2, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Spearow, Resources.Pink),
                new Chip(120, "Staryu", "Rapid Spin", 3, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Staryu, Resources.Pink),
                new Chip(72, "Tentacool", "Constrict", 2, 1, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Tentacool, Resources.Pink),
                new Chip(48, "Venonat", "Tackle", 2, 2, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Venonat, Resources.Pink),
                new Chip(100, "Voltorb", "Sonicboom", 3, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Voltorb, Resources.Pink),
                new Chip(13, "Weedle", "Poison Sting", 2, 1, new[] { 3, 4, 5, 6 }, Rarity.Pink, Resources.Weedle, Resources.Pink),
                new Chip(41, "Zubat", "Leech Life", 2, 3, new[] { 1, 2, 3, 4 }, Rarity.Pink, Resources.Zubat, Resources.Pink)
            };
        }

        private static List<Chip> LoadGreenChips()
        {
            return new List<Chip>
            {
                new Chip(63, "Abra", "Teleport", 4, 3, new[] { 2, 3, 4 }, Rarity.Green, Resources.Abra, Resources.Green),
                new Chip(36, "Clefable", "Double Edge", 5, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Clefable, Resources.Green),
                new Chip(91, "Cloyster", "Icicle Cannon", 4, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Cloyster, Resources.Green),
                new Chip(85, "Dodrio", "Tri-Attack", 5, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Dodrio, Resources.Green),
                new Chip(147, "Dratini", "Wrap", 5, 5, new[] { 2, 3, 4 }, Rarity.Green, Resources.Dratini, Resources.Green),
                new Chip(51, "Dugtrio", "Dig", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Dugtrio, Resources.Green),
                new Chip(133, "Eevee", "Quick Attack", 5, 3, new[] { 2, 3, 4 }, Rarity.Green, Resources.Eevee, Resources.Green),
                new Chip(101, "Electrode", "Explosion", 4, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Electrode, Resources.Green),
                new Chip(102, "Exeggcute", "Egg Bomb", 4, 3, new[] { 2, 3, 4 }, Rarity.Green, Resources.Exeggcute, Resources.Green),
                new Chip(83, "Farfetch'd", "Rage", 4, 4, new[] { 2, 3, 4 }, Rarity.Green, Resources.Farfetch_d, Resources.Green),
                new Chip(92, "Gastly", "Lick", 4, 3, new[] { 2, 3, 4 }, Rarity.Green, Resources.Gastly, Resources.Green),
                new Chip(74, "Geodude", "Tackle", 3, 4, new[] { 2, 3, 4 }, Rarity.Green, Resources.Geodude, Resources.Green),
                new Chip(44, "Gloom", "Acid", 4, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Gloom, Resources.Green),
                new Chip(42, "Golbat", "Confuse Ray", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Golbat, Resources.Green),
                new Chip(58, "Growlithe", "Ember", 4, 3, new[] { 2, 3, 4 }, Rarity.Green, Resources.Growlithe, Resources.Green),
                new Chip(14, "Kakuna", "Harden", 4, 3, new[] { 3, 4, 5 }, Rarity.Green, Resources.Kakuna, Resources.Green),
                new Chip(99, "Kingler", "Crabhammer", 4, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Kingler, Resources.Green),
                new Chip(66, "Machop", "Karate Chop", 3, 4, new[] { 2, 3, 4 }, Rarity.Green, Resources.Machop, Resources.Green),
                new Chip(82, "Magneton", "Thunder Wave", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Magneton, Resources.Green),
                new Chip(11, "Metapod", "Harden", 4, 3, new[] { 3, 4, 5 }, Rarity.Green, Resources.Metapod, Resources.Green),
                new Chip(89, "Muk", "Sludge", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Muk, Resources.Green),
                new Chip(30, "Nidorina", "Bite", 5, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Nidorina, Resources.Green),
                new Chip(33, "Nidorino", "Rage", 5, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Nidorino, Resources.Green),
                new Chip(47, "Parasect", "Spore", 5, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Parasect, Resources.Green),
                new Chip(17, "Pidgeotto", "Whirlwind", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Pidgeotto, Resources.Green),
                new Chip(61, "Poliwhirl", "Double Punch", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Poliwhirl, Resources.Green),
                new Chip(77, "Ponyta", "Stomp", 4, 3, new[] { 2, 3, 4 }, Rarity.Green, Resources.Ponyta, Resources.Green),
                new Chip(20, "Raticate", "Hyper Fang", 4, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Raticate, Resources.Green),
                new Chip(111, "Rhyhorn", "Horn Attack", 4, 5, new[] { 2, 3, 4 }, Rarity.Green, Resources.Rhyhorn, Resources.Green),
                new Chip(117, "Seadra", "Bubblebeam", 4, 5, new[] { 3, 4, 5 }, Rarity.Green, Resources.Seadra, Resources.Green),
                new Chip(119, "Seaking", "Waterfall", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Seaking, Resources.Green),
                new Chip(80, "Slowbro", "Water Gun", 5, 3, new[] { 3, 4, 5 }, Rarity.Green, Resources.Slowbro, Resources.Green),
                new Chip(121, "Starmie", "Bubblebeam", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Starmie, Resources.Green),
                new Chip(114, "Tangela", "Bind", 4, 3, new[] { 2, 3, 4 }, Rarity.Green, Resources.Tangela, Resources.Green),
                new Chip(73, "Tentacruel", "Acid", 4, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Tentacruel, Resources.Green),
                new Chip(37, "Vulpix", "Ember", 4, 3, new[] { 2, 3, 4 }, Rarity.Green, Resources.Vulpix, Resources.Green),
                new Chip(70, "Weepinbell", "Razor Leaf", 4, 3, new[] { 3, 4, 5 }, Rarity.Green, Resources.Weepinbell, Resources.Green),
                new Chip(40, "Wigglytuff", "Disable", 5, 4, new[] { 3, 4, 5 }, Rarity.Green, Resources.Wigglytuff, Resources.Green)
            };
        }

        private static List<Chip> LoadBlueChips()
        {
            return new List<Chip>
            {
                new Chip(24, "Arbok", "Glare", 6, 5, new[] { 4, 5 }, Rarity.Blue, Resources.Arbok, Resources.Blue),
                new Chip(15, "Beedrill", "Fury Attack", 6, 5, new[] { 2, 3 }, Rarity.Blue, Resources.Beedrill, Resources.Blue),
                new Chip(12, "Butterfree", "Sleep Powder", 6, 5, new[] { 2, 3 }, Rarity.Blue, Resources.Butterfree, Resources.Blue),
                new Chip(5, "Charmeleon", "Flamethrower", 7, 7, new[] { 3, 4 }, Rarity.Blue, Resources.Charmeleon, Resources.Blue),
                new Chip(87, "Dewgong", "Aurora Beam", 6, 6, new[] { 4, 5 }, Rarity.Blue, Resources.Dewgong, Resources.Blue),
                new Chip(132, "Ditto", "Transform", 5, 5, new[] { 1, 2 }, Rarity.Blue, Resources.Ditto, Resources.Blue),
                new Chip(148, "Dragonair", "Dragon Rage", 6, 7, new[] { 4, 5 }, Rarity.Blue, Resources.Dragonair, Resources.Blue),
                new Chip(22, "Fearow", "Drill Peck", 6, 5, new[] { 4, 5 }, Rarity.Blue, Resources.Fearow, Resources.Blue),
                new Chip(136, "Flareon", "Flamethrower", 7, 6, new[] { 2, 3 }, Rarity.Blue, Resources.Flareon, Resources.Blue),
                new Chip(55, "Golduck", "Confusion", 6, 5, new[] { 4, 5 }, Rarity.Blue, Resources.Golduck, Resources.Blue),
                new Chip(75, "Graveler", "Rock Throw", 5, 6, new[] { 3, 4 }, Rarity.Blue, Resources.Graveler, Resources.Blue),
                new Chip(93, "Haunter", "Night Shade", 5, 6, new[] { 3, 4 }, Rarity.Blue, Resources.Haunter, Resources.Blue),
                new Chip(107, "Hitmonchan", "Mega Punch", 6, 7, new[] { 1, 2 }, Rarity.Blue, Resources.Hitmonchan, Resources.Blue),
                new Chip(106, "Hitmonlee", "Mega Kick", 6, 7, new[] { 1, 2 }, Rarity.Blue, Resources.Hitmonlee, Resources.Blue),
                new Chip(97, "Hypno", "Hypnosis", 6, 6, new[] { 4, 5 }, Rarity.Blue, Resources.Hypno, Resources.Blue),
                new Chip(2, "Ivysaur", "Razor Leaf", 7, 7, new[] { 3, 4 }, Rarity.Blue, Resources.Ivysaur, Resources.Blue),
                new Chip(135, "Jolteon", "Thunderbolt", 7, 6, new[] { 2, 3 }, Rarity.Blue, Resources.Jolteon, Resources.Blue),
                new Chip(124, "Jynx", "Ice Punch", 6, 5, new[] { 1, 2 }, Rarity.Blue, Resources.Jynx, Resources.Blue),
                new Chip(140, "Kabuto", "Scratch", 7, 5, new[] { 2, 3 }, Rarity.Blue, Resources.Kabuto, Resources.Blue),
                new Chip(64, "Kadabra", "Psybeam", 5, 6, new[] { 3, 4 }, Rarity.Blue, Resources.Kadabra, Resources.Blue),
                new Chip(108, "Lickitung", "Slam", 5, 4, new[] { 1, 2 }, Rarity.Blue, Resources.Lickitung, Resources.Blue),
                new Chip(67, "Machoke", "Low Kick", 5, 6, new[] { 3, 4 }, Rarity.Blue, Resources.Machoke, Resources.Blue),
                new Chip(105, "Marowak", "Bonemerang", 6, 6, new[] { 4, 5 }, Rarity.Blue, Resources.Marowak, Resources.Blue),
                new Chip(122, "Mr. Mime", "Confusion", 7, 5, new[] { 1, 2 }, Rarity.Blue, Resources.MrMime, Resources.Blue),
                new Chip(138, "Omanyte", "Horn Attack", 7, 5, new[] { 2, 3 }, Rarity.Blue, Resources.Omanyte, Resources.Blue),
                new Chip(95, "Onix", "Rock Throw", 6, 7, new[] { 1, 2 }, Rarity.Blue, Resources.Onix, Resources.Blue),
                new Chip(53, "Persian", "Fury Attack", 6, 6, new[] { 4, 5 }, Rarity.Blue, Resources.Persian, Resources.Blue),
                new Chip(18, "Pidgeot", "Wing Attack", 6, 6, new[] { 2, 3 }, Rarity.Blue, Resources.Pidgeot, Resources.Blue),
                new Chip(127, "Pinsir", "Seismic Toss", 6, 6, new[] { 1, 2 }, Rarity.Blue, Resources.Pinsir, Resources.Blue),
                new Chip(137, "Porygon", "Tri-Attack", 5, 5, new[] { 1, 2 }, Rarity.Blue, Resources.Porygon, Resources.Blue),
                new Chip(57, "Primeape", "Seismic Toss", 6, 7, new[] { 4, 5 }, Rarity.Blue, Resources.Primeape, Resources.Blue),
                new Chip(26, "Raichu", "Thunderbolt", 6, 6, new[] { 4, 5 }, Rarity.Blue, Resources.Raichu, Resources.Blue),
                new Chip(28, "Sandslash", "Slash", 6, 5, new[] { 4, 5 }, Rarity.Blue, Resources.Sandslash, Resources.Blue),
                new Chip(123, "Scyther", "Slash", 6, 6, new[] { 1, 2 }, Rarity.Blue, Resources.Scyther, Resources.Blue),
                new Chip(134, "Vaporeon", "Surf", 7, 6, new[] { 2, 3 }, Rarity.Blue, Resources.Vaporeon, Resources.Blue),
                new Chip(49, "Venomoth", "Psybeam", 6, 5, new[] { 4, 5 }, Rarity.Blue, Resources.Venomoth, Resources.Blue),
                new Chip(8, "Wartortle", "Skull Bash", 7, 7, new[] { 3, 4 }, Rarity.Blue, Resources.Wartortle, Resources.Blue),
                new Chip(110, "Weezing", "Smog", 6, 5, new[] { 4, 5 }, Rarity.Blue, Resources.Weezing, Resources.Blue)
            };
        }

        private static List<Chip> LoadRedChips()
        {
            return new List<Chip>
            {
                new Chip(142, "Aerodactyl", "Rock Slide", 6, 7, new[] { 4 }, Rarity.Red, Resources.Aerodactyl, Resources.Red),
                new Chip(65, "Alakazam", "Psychic", 7, 7, new[] { 5 }, Rarity.Red, Resources.Alakazam, Resources.Red),
                new Chip(59, "Arcanine", "Take Down", 6, 7, new[] { 4 }, Rarity.Red, Resources.Arcanine, Resources.Red),
                new Chip(9, "Blastoise", "Hydro pump", 7, 8, new[] { 5 }, Rarity.Red, Resources.Blastoise, Resources.Red),
                new Chip(113, "Chansey", "Egg Bomb", 7, 7, new[] { 3 }, Rarity.Red, Resources.Chansey, Resources.Red),
                new Chip(6, "Charizard", "Fireball", 7, 8, new[] { 5 }, Rarity.Red, Resources.Charizard, Resources.Red),
                new Chip(149, "Dragonite", "Hyper Beam", 7, 8, new[] { 5 }, Rarity.Red, Resources.Dragonite, Resources.Red),
                new Chip(125, "Electabuzz", "Thunderpunch", 6, 8, new[] { 3 }, Rarity.Red, Resources.Electabuzz, Resources.Red),
                new Chip(103, "Exeggutor", "Barrage", 6, 7, new[] { 4 }, Rarity.Red, Resources.Exeggutor, Resources.Red),
                new Chip(94, "Gengar", "Dream Eater", 7, 7, new[] { 5 }, Rarity.Red, Resources.Gengar, Resources.Red),
                new Chip(76, "Golem", "Earthquake", 7, 7, new[] { 5 }, Rarity.Red, Resources.Golem, Resources.Red),
                new Chip(130, "Gyarados", "Dragon Fury", 7, 8, new[] { 4 }, Rarity.Red, Resources.Gyarados, Resources.Red),
                new Chip(141, "Kabutops", "Quillotine", 6, 7, new[] { 4 }, Rarity.Red, Resources.Kabutops, Resources.Red),
                new Chip(115, "Kangaskhan", "Dizzy Punch", 6, 7, new[] { 3 }, Rarity.Red, Resources.Kangaskhan, Resources.Red),
                new Chip(131, "Lapras", "Ice Beam", 6, 7, new[] { 3 }, Rarity.Red, Resources.Lapras, Resources.Red),
                new Chip(68, "Machamp", "Submission", 7, 7, new[] { 5 }, Rarity.Red, Resources.Machamp, Resources.Red),
                new Chip(126, "Magmar", "Fire Punch", 6, 7, new[] { 3 }, Rarity.Red, Resources.Magmar, Resources.Red),
                new Chip(34, "Nidoking", "Thrash", 7, 6, new[] { 5 }, Rarity.Red, Resources.Nidoking, Resources.Red),
                new Chip(31, "Nidoqueen", "Body Slam", 7, 6, new[] { 5 }, Rarity.Red, Resources.Nidoqueen, Resources.Red),
                new Chip(38, "Ninetales", "Quick Attack", 7, 6, new[] { 4 }, Rarity.Red, Resources.Ninetales, Resources.Red),
                new Chip(139, "Omastar", "Hydro Pump", 6, 7, new[] { 4 }, Rarity.Red, Resources.Omastar, Resources.Red),
                new Chip(62, "Poliwrath", "Water Gun", 6, 7, new[] { 5 }, Rarity.Red, Resources.Poliwrath, Resources.Red),
                new Chip(78, "Rapidash", "Quick Attack", 7, 6, new[] { 4 }, Rarity.Red, Resources.Rapidash, Resources.Red),
                new Chip(112, "Rhydon", "Horn Drill", 6, 8, new[] { 4 }, Rarity.Red, Resources.Rhydon, Resources.Red),
                new Chip(143, "Snorlax", "Body slam", 7, 7, new[] { 3 }, Rarity.Red, Resources.Snorlax, Resources.Red),
                new Chip(128, "Tauros", "Take Down", 7, 8, new[] { 3 }, Rarity.Red, Resources.Tauros, Resources.Red),
                new Chip(3, "Venusaur", "Solar Beam", 7, 8, new[] { 5 }, Rarity.Red, Resources.Venusaur, Resources.Red),
                new Chip(71, "Victreebel", "Acid", 6, 6, new[] { 4 }, Rarity.Red, Resources.Victreebel, Resources.Red),
                new Chip(45, "Vileplume", "Petal Dance", 6, 6, new[] { 4 }, Rarity.Red, Resources.Vileplume, Resources.Red)
            };
        }

        private static List<Chip> LoadYellowChips()
        {
            return new List<Chip>
            {
                new Chip(144, "Articuno", "Blizzard", 8, 9, new[] { 6 }, Rarity.Yellow, Resources.Articuno, Resources.Yellow),
                new Chip(151, "Mew", "Psywave", 10, 9, new[] { 1 }, Rarity.Yellow, Resources.Mew, Resources.Yellow),
                new Chip(150, "Mewtwo", "Psychic", 9, 9, new[] { 6 }, Rarity.Yellow, Resources.Mewtwo, Resources.Yellow),
                new Chip(146, "Moltres", "Fireblast", 8, 9, new[] { 6 }, Rarity.Yellow, Resources.Moltres, Resources.Yellow),
                new Chip(145, "Zapdos", "Thunder", 8, 9, new[] { 6 }, Rarity.Yellow, Resources.Zapdos, Resources.Yellow)
            };
        }
    }
}
