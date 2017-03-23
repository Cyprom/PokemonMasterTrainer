using System;
using System.Collections.Generic;
using Cyprom.PokemonMasterTrainer.Controls;
using Cyprom.PokemonMasterTrainer.Data.Properties;
using Cyprom.PokemonMasterTrainer.Enums;

namespace Cyprom.PokemonMasterTrainer.Data.Loaders
{
    public static class SpaceLoader
    {
        public static Tuple<List<Space>, Space, Space, Space> LoadSpaces()
        {
            var id = 1;
            var space01 = new CityTown(id++, "Pallet Town", Resources.Space, SpaceType.Nothing, Rarity.None, 343, 1100, 300, 1105, 386, 1105, 343, 1075);
            var space02 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 269, 983, 194, 970);
            var space03 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Pink, 268, 881);
            var space04 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 194, 816, 136, 849);
            var space05 = new CityTown(id++, "Viridian City", Resources.Space, SpaceType.Item2, Rarity.None, 327, 762, 284, 766, 370, 766, 327, 736);
            var space06 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Pink, 311, 643);
            var space07 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 207, 566, 135, 580);
            var space08 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 327, 518, 363, 460);
            var space09 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Pink, 239, 456);
            var space10 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 116, 454, 44, 472);
            var space11 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 116, 341, 44, 297);
            var space12 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 236, 278, 194, 205);
            var space13 = new CityTown(id++, "Pewter City", Resources.Space, SpaceType.Item2, Rarity.None, 375, 287, 332, 292, 418, 292, 375, 262);
            var space14 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Pink, 359, 186);
            var space15 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 401, 79, 333, 20);
            var space16 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Pink, 512, 122);
            var space17 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 611, 122, 631, 50);
            var space18 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 610, 251, 557, 296);
            var space19 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 741, 263, 742, 316);
            var space20 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 773, 141);
            var space21 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 895, 123, 851, 50);
            var space22 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 1011, 122, 1044, 53);
            var space23 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 1059, 218);
            var space24 = new CityTown(id++, "Cerulean City", Resources.Space, SpaceType.Revive, Rarity.None, 1198, 230, 1155, 234, 1241, 234, 1198, 204);
            var space25 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 1305, 122, 1274, 43);
            var space26 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 1417, 140);
            var space27 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 1528, 134, 1502, 53);
            var space28 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 1618, 197, 1592, 253);
            var space29 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 1721, 230);
            var space30 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 1802, 309, 1835, 250);
            var space31 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 1802, 424);
            var space32 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 1241, 328);
            var space33 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 1140, 374, 1060, 357);
            var space34 = new CityTown(id++, "Saffron City", Resources.Space, SpaceType.Item2, Rarity.None, 1198, 493, 1155, 498, 1241, 498, 1198, 468);
            var space35 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 1021, 494, 963, 533);
            var space36 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 873, 488);
            var space37 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 1334, 488);
            var space38 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 1437, 489, 1438, 407);
            var space39 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 1529, 482);
            var space40 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1139, 593);
            var space41 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1241, 644, 1276, 580);
            var space42 = new CityTown(id++, "Vermilion City", Resources.Space, SpaceType.Revive, Rarity.None, 1199, 762, 1156, 766, 1242, 766, 1199, 736);
            var space43 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1338, 751);
            var space44 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1437, 670);
            var space45 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1561, 672, 1581, 599);
            var space46 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1449, 824, 1392, 868);
            var space47 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1573, 829);
            var space48 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1682, 753);
            var space49 = new CityTown(id++, "Lavender Town", Resources.Space, SpaceType.Item2, Rarity.None, 1661, 493, 1618, 498, 1704, 498, 1661, 468);
            var space50 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1783, 566, 1835, 586);
            var space51 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1753, 670);
            var space52 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1816, 747, 1868, 767);
            var space53 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1784, 863, 1835, 882);
            var space54 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1650, 964);
            var space55 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1527, 1073, 1562, 1109);
            var space56 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1482, 1187, 1484, 1240);
            var space57 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1337, 1184);
            var space58 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1211, 1185, 1172, 1109);
            var space59 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 1102, 1199, 1094, 1253);
            var space60 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 997, 1185);
            var space61 = new CityTown(id++, "Celadon City", Resources.Space, SpaceType.Item2, Rarity.None, 698, 497, 655, 501, 741, 501, 698, 471);
            var space62 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Red, 547, 546, 466, 521);
            var space63 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Red, 547, 657, 466, 631);
            var space64 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Red, 547, 766, 466, 740);
            var space65 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Red, 527, 875);
            var space66 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Red, 525, 996, 447, 951);
            var space67 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Red, 524, 1105);
            var space68 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Red, 591, 1184, 611, 1234);
            var space69 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Red, 727, 1185);
            var space70 = new CityTown(id++, "Fuchsia City", Resources.Space, SpaceType.Item2, Rarity.None, 863, 1194, 820, 1199, 906, 1199, 863, 1169);
            var space71 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Red, 895, 1294, 937, 1325);
            var space72 = new CatchSpace(id++, Resources.Space, SpaceType.Catch, Rarity.Red, 792, 1359, 747, 1285);
            var space73 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Red, 611, 1358);
            var space74 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Red, 492, 1358);
            var space75 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Red, 402, 1343);
            var space76 = new CityTown(id++, "Cinnabar Island", Resources.Space, SpaceType.PowerPoint, Rarity.None, 418, 1257, 375, 1261, 461, 1261, 418, 1231);
            var space77 = new Space(id++, Resources.Space, SpaceType.Nothing, Rarity.None, 691, 948);
            var space78 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Pink, 654, 886);
            var space79 = new Space(id++, Resources.Space, SpaceType.Item1, Rarity.None, 658, 815);
            var space80 = new Space(id++, Resources.Space, SpaceType.FinalBattle, Rarity.None, 692, 752);
            var space81 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Green, 724, 687);
            var space82 = new Space(id++, Resources.Space, SpaceType.Catch, Rarity.Pink, 806, 654);
            var space83 = new Space(id++, Resources.Space, SpaceType.Catch, Rarity.Green, 895, 654);
            var space84 = new Space(id++, Resources.Space, SpaceType.Item2, Rarity.None, 975, 695);
            var space85 = new Space(id++, Resources.Space, SpaceType.Return, Rarity.None, 1007, 758);
            var space86 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Blue, 1042, 817);
            var space87 = new Space(id++, Resources.Space, SpaceType.Item2, Rarity.None, 1042, 888);
            var space88 = new Space(id++, Resources.Space, SpaceType.FinalBattle, Rarity.None, 1006, 949);
            var space89 = new Space(id++, Resources.Space, SpaceType.Event, Rarity.Red, 974, 1014);
            var space90 = new Space(id++, Resources.Space, SpaceType.Catch, Rarity.Blue, 894, 1050);
            var space91 = new Space(id++, Resources.Space, SpaceType.Catch, Rarity.Red, 806, 1050);
            var space92 = new Space(id, Resources.Space, SpaceType.Item3, Rarity.None, 722, 1013);

            //Pallet Town
            Link(space01, space02);
            //Viridian City
            Link(space05, space04, space06);
            //Pewter City
            Link(space13, space12, space14);
            //Cerulean City
            Link(space24, space23, space25, space32);
            //Saffron City
            Link(space34, space33, space35, space37, space40);
            //Vermilion City
            Link(space42, space41, space43);
            //Lavender Town
            Link(space49, space31, space39, space50);
            //Celadon City
            Link(space61, space36, space62);
            //Fuchsia City
            Link(space70, space60, space69, space71);
            //Cinnabar Island
            Link(space76, space75);
            
            //Pallet -> Viridian
            Link(space02, space01, space03);
            Link(space03, space02, space04);
            Link(space04, space03, space05);

            //Viridian -> Pewter
            Link(space06, space05, space07);
            Link(space07, space06, space08);
            Link(space08, space07, space09);
            Link(space09, space08, space10);
            Link(space10, space09, space11);
            Link(space11, space10, space12);
            Link(space12, space11, space13);

            //Pewter -> Cerulean
            Link(space14, space13, space15);
            Link(space15, space14, space16);
            Link(space16, space15, space17);
            Link(space17, space16, space18);
            Link(space18, space17, space19);
            Link(space19, space18, space20);
            Link(space20, space19, space21);
            Link(space21, space20, space22);
            Link(space22, space21, space23);
            Link(space23, space22, space24);
            
            //Cerulean -> Lavender
            Link(space25, space24, space26);
            Link(space26, space25, space27);
            Link(space27, space26, space28);
            Link(space28, space27, space29);
            Link(space29, space28, space30);
            Link(space30, space29, space31);
            Link(space31, space30, space49);

            //Cerulean -> Saffron
            Link(space32, space24, space33);
            Link(space33, space32, space34);

            //Saffron -> Celadon
            Link(space35, space34, space36);
            Link(space36, space35, space61);

            //Saffron -> Lavender
            Link(space37, space34, space38);
            Link(space38, space37, space39);
            Link(space39, space38, space49);

            //Saffron -> Vermilion
            Link(space40, space34, space41);
            Link(space41, space40, space42);

            //Vermilion -> Merge
            Link(space43, space42, space44, space46);
            Link(space44, space43, space45);
            Link(space45, space44, space48);
            Link(space46, space43, space47);
            Link(space47, space46, space48);
            Link(space48, space45, space47, space52);

            //Lavender -> Merge
            Link(space50, space49, space51);
            Link(space51, space50, space52);

            //Merge -> Fuchsia
            Link(space52, space48, space51, space53);
            Link(space53, space52, space54);
            Link(space54, space53, space55);
            Link(space55, space54, space56);
            Link(space56, space55, space57);
            Link(space57, space56, space58);
            Link(space58, space57, space59);
            Link(space59, space58, space60);
            Link(space60, space59, space70);

            //Celadon -> Fuchsia
            Link(space62, space61, space63);
            Link(space63, space62, space64);
            Link(space64, space63, space65);
            Link(space65, space64, space66);
            Link(space66, space65, space67);
            Link(space67, space66, space68);
            Link(space68, space67, space69);
            Link(space69, space68, space70);

            //Fuchsia -> Cinnabar
            Link(space71, space70, space72);
            Link(space72, space71, space73);
            Link(space73, space72, space74);
            Link(space74, space73, space75);
            Link(space75, space74, space76);

            //Indigo Plateau
            Link(space77, space78);
            Link(space78, space79);
            Link(space79, space80);
            Link(space80, space81);
            Link(space81, space82);
            Link(space82, space83);
            Link(space83, space84);
            Link(space84, space85);
            Link(space85, space86);
            Link(space86, space87);
            Link(space87, space88);
            Link(space88, space89);
            Link(space89, space90);
            Link(space90, space91);
            Link(space91, space92);
            Link(space92, space77);

            return new Tuple<List<Space>, Space, Space, Space>(
                new List<Space>
                {
                    space01, space02, space03, space04, space05, space06, space07, space08, space09, space10,
                    space11, space12, space13, space14, space15, space16, space17, space18, space19, space20,
                    space21, space22, space23, space24, space25, space26, space27, space28, space29, space30,
                    space31, space32, space33, space34, space35, space36, space37, space38, space39, space40,
                    space41, space42, space43, space44, space45, space46, space47, space48, space49, space50,
                    space51, space52, space53, space54, space55, space56, space57, space58, space59, space60,
                    space61, space62, space63, space64, space65, space66, space67, space68, space69, space70,
                    space71, space72, space73, space74, space75, space76, space77, space78, space79, space80,
                    space81, space82, space83, space84, space85, space86, space87, space88, space89, space90,
                    space91, space92
                }, space01, space76, space77);
        }

        private static void Link(Space current, params Space[] neighbors)
        {
            current.Neighbors.AddRange(neighbors);
        }
    }
}
