using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PoiString;
using PoiString.AttTypes;
using PoiString.AttTypes.Components.ValueTypes;
using PoiString.Knowledge;
using PoiString.AttTypes.Components;

namespace Poistring_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //this just sets up stuff needed to associate binary hashes with component structures
            //dont worry about just know that it is needed before anything else runs
            KnowledgeManager.InitializeStructure();
            //replace this with the example you want to run
            Console.WriteLine(WeaponExample4());
            //this stops the console window from instantly closing when everything executes
            while (true)
            {

            }

        }
        //COMPLETE
        static string ConcoctionCrateExample()
        {

            NetworkPrefab prefab = new NetworkPrefab()
            {
                //within this context you use a comma instead of semicolon 
                PrefabHash = 23304,
                //ahh scale, my first major contribution to the string scene, hidden in plain sight no one noticed for ages
                Scale = 1,
                //these arent needed but you can use them if you want to spawn stuff via spawn string-raw, spawn string (playername) ignores these values
                positonX = 0,
                positonY = 0,
                positonZ = 0,
                //now rotation, this is stored in quaternion so if you want to edit it... good luck
                RotationX = 0,
                RotationY = 0,
                RotationZ = 0,
                RotationW = 0,
                Components = new List<ATTSerializableComponent>()
                {
                    //you dont need the PoiString.AttTypes.Components. part but if you are looking for compoent names it can help to add that to the start
                    new PoiString.AttTypes.Components.LiquidContainer()
                    {
                        PresetHash = (int)Knowledge.LiquidDefinition.TeleportPotion,
                        hasContent = true
                    }
                }

            };
            //convert from prefab to att string
            return PoiStentions.GetAsATTString(prefab);
        }

        //INCOMPLETE
        static string StringDecompileExample()
        {
            //this will accept most strings from the game and other string generators - unless they are old strings that dont have versioning (or do because i havent implemented handling for versioning yet :sweat:)
            //strings that have "fallbackserializedtype" components are components i havent added yet, most arent super important i.e. heatpointcollection is... really kinda useless for string modification
            string StringToDecompile = "23304,89,23304,3288776246,1124961034,1118129539,0,0,0,1065353216,1065353216,4179293747,69,1610612736,536873716,2319744848,3489660930,134217728,151445504,0,243,1744830464,2248146944,0,0,|131,3801256786,2,272188517,1,237360636,2,391977879,2,277505782,1,22446553,2,2617495528,1,2978042925,1,2801168996,2,2495475500,2,1176706580,2,1001395212,2,1874870249,1,2498617949,1,1714180166,1,3109677933,1,320224849,1,2272630171,1,1217391130,1,276353327,1,1823429789,1,3402094521,1,751359624,1,3608460219,1,1390862571,1,1085701614,1,3445325106,1,2126500253,1,2624099526,1,1871432223,1,3373651539,1,654225716,1,1454441398,1,3704379512,1,3257374625,1,2262399392,2,3146178080,1,661497638,1,2293737711,1,2190886200,1,3920618075,1,3665939353,1,3901697682,1,1211178616,1,2951515968,1,1588536425,1,2127962967,1,70871065,1,1063725326,1,3101665521,1,2815374842,1,4081488368,1,3820454400,2,1624211074,1,7704646,1,1651678475,1,2400796504,1,910018632,2,4144776006,3,566175523,1,2975913730,1,875684520,1,2169673426,1,3450348902,1,1233775263,1,43510150,2,1645673210,2,3431876266,1,4095875831,1,2314081177,1,2590537994,2,2443660852,1,967932020,1,3751351177,1,1257282635,1,2700376822,1,3188272159,1,3245685963,1,2120963769,1,392344172,1,1391720462,1,2610542999,1,1081247904,1,2880587164,1,2563434699,1,2814234626,1,1964978567,1,1228539097,1,2026743731,1,3538443740,1,634164392,5,3642863935,2,1931537627,1,259381630,1,3932346318,1,2978388169,1,1431397437,2,3070493599,2,3588929783,1,3640332570,1,1787084913,3,1454955908,1,788405183,1,2563567105,2,766675725,1,2882590463,1,1499506132,1,205333986,1,4179293747,1,3236280681,3,902024186,1,2450553269,1,2629079826,1,963907309,1,1753993206,2,1923918202,2,1776498660,1,3638500874,2,1098050191,3,3084373371,1,4163873252,1,1587058252,1,2592242915,2,34507654,1,1962842866,1,4282337604,1,3561515449,1,2290978823,1,3674519521,1,4109360768,2,3457519710,2,";
            NetworkPrefab prefab = PoiDecoder.GetPrefabFromString(StringToDecompile);
            //convert from prefab to att string
            return PoiStentions.GetAsATTString(prefab);
        }

        //INCOMPLETE
        static string StringDecompileAndEditExample1()
        {
            //in this example a string is provided for a concoction crate of water then it is modified to instead contain teleport potion 
            string StringToDecompile = "23304,89,23304,3288776246,1124961034,1118129539,0,0,0,1065353216,1065353216,4179293747,69,1610612736,536873716,2319744848,3489660930,134217728,151445504,0,243,1744830464,2248146944,0,0,|131,3801256786,2,272188517,1,237360636,2,391977879,2,277505782,1,22446553,2,2617495528,1,2978042925,1,2801168996,2,2495475500,2,1176706580,2,1001395212,2,1874870249,1,2498617949,1,1714180166,1,3109677933,1,320224849,1,2272630171,1,1217391130,1,276353327,1,1823429789,1,3402094521,1,751359624,1,3608460219,1,1390862571,1,1085701614,1,3445325106,1,2126500253,1,2624099526,1,1871432223,1,3373651539,1,654225716,1,1454441398,1,3704379512,1,3257374625,1,2262399392,2,3146178080,1,661497638,1,2293737711,1,2190886200,1,3920618075,1,3665939353,1,3901697682,1,1211178616,1,2951515968,1,1588536425,1,2127962967,1,70871065,1,1063725326,1,3101665521,1,2815374842,1,4081488368,1,3820454400,2,1624211074,1,7704646,1,1651678475,1,2400796504,1,910018632,2,4144776006,3,566175523,1,2975913730,1,875684520,1,2169673426,1,3450348902,1,1233775263,1,43510150,2,1645673210,2,3431876266,1,4095875831,1,2314081177,1,2590537994,2,2443660852,1,967932020,1,3751351177,1,1257282635,1,2700376822,1,3188272159,1,3245685963,1,2120963769,1,392344172,1,1391720462,1,2610542999,1,1081247904,1,2880587164,1,2563434699,1,2814234626,1,1964978567,1,1228539097,1,2026743731,1,3538443740,1,634164392,5,3642863935,2,1931537627,1,259381630,1,3932346318,1,2978388169,1,1431397437,2,3070493599,2,3588929783,1,3640332570,1,1787084913,3,1454955908,1,788405183,1,2563567105,2,766675725,1,2882590463,1,1499506132,1,205333986,1,4179293747,1,3236280681,3,902024186,1,2450553269,1,2629079826,1,963907309,1,1753993206,2,1923918202,2,1776498660,1,3638500874,2,1098050191,3,3084373371,1,4163873252,1,1587058252,1,2592242915,2,34507654,1,1962842866,1,4282337604,1,3561515449,1,2290978823,1,3674519521,1,4109360768,2,3457519710,2,";
            NetworkPrefab prefab = PoiDecoder.GetPrefabFromString(StringToDecompile);
            //to find what number to use for the component array place a break point on a line after this one then hover over prefab
            //the ide will give you a dropdown you can navigate, easiest example is to put a break point on the return line below



            //prefab.Components[0]


            //convert from prefab to att string
            return PoiStentions.GetAsATTString(prefab);
        }

        //INCOMPLETE
        static string StringDecompileAndEditExample2()
        {
            //in this example a prefab is edited that has a compoent within an embeded entity, to better understand embedded entities refer to

            return "";
        }
        //COMPLETE
        static string CustomPotionExample()
        {
            NetworkPrefab prefab = new NetworkPrefab()
            {
                //potion medium
                PrefabHash = 23644,
                Components = new List<ATTSerializableComponent>()
                {
                    new LiquidContainer()
                    {
                        //probably set this logically
                        hasContent = true,
                        //yes you can use this to make a potion flask with 100 charges
                        contentLevel = 1,
                        //true if using custom data false if taking from presethash
                        isCustom = true,
                        //idk with these probably set them how it makes sense but meh
                        canAddTo = false,
                        canRemoveFrom = true,
                        PresetHash = 0,
                        //this can be null
                        customData = new CustomData()
                        {
                            color = new Color()
                            {
                                r = 1,
                                g = 0,
                                b = 0,
                                a = 1
                            },
                            effects = new Effect[]
                            {
                               //thse can not be here if you want... colored water?
                               new Effect()
                               {
                                   //these are self explanitory i hope
                                   EffectHash = (int)Knowledge.EffectDefinition.Heal,
                                   strengthMultiplier = 2f
                               },
                               new Effect()
                               {
                                   EffectHash = (int)Knowledge.EffectDefinition.DamageProtectionIndirecteffect,
                                   strengthMultiplier = 3.5f
                               }
                            },
                            foodChunks = new uint[]
                            {
                                //this array can be empty but must exist or else stuff breks

                            },
                            isConsumableThroughSkin = true,
                            visualDataHash = (int)Knowledge.LiquidVisualData.NonRecipeStewRawLiquidVisualData,
                        }
                    }
                }
            };
            return PoiStentions.GetAsATTString(prefab);
        }
        //COMPLETE
        static string WeaponExample1()
        {
            //now for what you probably downloaded this for in the first place, custom weapons
            NetworkPrefab prefab = new NetworkPrefab()
            {
                PrefabHash = Prefabs.HandleShortCool.Hash,

                Children = new List<ChildNetworkPrefab>()
                {
                    new ChildNetworkPrefab()
                    {
                        //this has to be the hash of the slot for the prefab used by the parent (woo strange words!)
                        parentHash = Prefabs.HandleShortCool.Embeds.SlotMulti_48480.Hash,
                        Prefab = new NetworkPrefab()
                        {
                            PrefabHash = Prefabs.LargeGuardRectangle.Hash,
                            Components = new List<PoiString.AttTypes.Components.ATTSerializableComponent>()
                            {
                                new PoiString.AttTypes.Components.PhysicalMaterialPart()
                                {
                                    Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                                }
                            },
                            Children = new List<ChildNetworkPrefab>()
                            {
                                new ChildNetworkPrefab()
                                {
                                    parentHash = Prefabs.LargeGuardRectangle.Embeds.InsertLargeSwordTypeCraft_51894.Hash,
                                    Prefab = new NetworkPrefab()
                                    {
                                        PrefabHash = Prefabs.LargeLongswordBlade.Hash,
                                        Components = new List<ATTSerializableComponent>()
                                        {
                                            new PhysicalMaterialPart()
                                            {
                                                Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            return PoiStentions.GetAsATTString(prefab);
        }

        //COMPLETE
        static string WeaponExample2()
        {
            //now you dont have to make weapons all in one big block, you can spread it out

            NetworkPrefab GuardAndBlade = new NetworkPrefab
            {

                PrefabHash = Prefabs.LargeGuardRectangle.Hash,
                Components = new List<PoiString.AttTypes.Components.ATTSerializableComponent>()
                {
                    new PoiString.AttTypes.Components.PhysicalMaterialPart()
                    {
                        Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                    }
                },
                Children = new List<ChildNetworkPrefab>()
                {
                    new ChildNetworkPrefab()
                    {
                        //make sure you use SLOTS not INSERTS
                        parentHash = Prefabs.LargeGuardRectangle.Embeds.SlotLargeSwordType_51896.Hash,
                        Prefab = new NetworkPrefab()
                        {
                            PrefabHash = Prefabs.LargeLongswordBlade.Hash,
                            Components = new List<ATTSerializableComponent>()
                            {
                                new PhysicalMaterialPart()
                                {
                                    Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                                }
                            }
                        }
                    }

                }
            };

            NetworkPrefab prefab = new NetworkPrefab()
            {
                PrefabHash = Prefabs.HandleShortCool.Hash,

                Children = new List<ChildNetworkPrefab>()
                {
                    new ChildNetworkPrefab()
                    {
                        //this has to be the hash of the slot for the prefab used by the parent (woo strange words!)
                        parentHash = Prefabs.HandleShortCool.Embeds.SlotMulti_48480.Hash,
                        Prefab = GuardAndBlade

                    }
                }
            };
            return PoiStentions.GetAsATTString(prefab);
        }
        //COMPLETE
        static string WeaponExample3()
        {
            //using variables is more useful when you are using branching adapters 
            //this is also a slightly different way to use varialbes that is likely more useful
            NetworkPrefab prefab = new NetworkPrefab()
            {
                PrefabHash = Prefabs.HandleShortCool.Hash,

                Children = new List<ChildNetworkPrefab>()
                {
                    new ChildNetworkPrefab()
                    {
                        //this has to be the hash of the slot for the prefab used by the parent (woo strange words!)
                        parentHash = Prefabs.HandleShortCool.Embeds.SlotMulti_48480.Hash,
                        Prefab = new NetworkPrefab()
                        {
                            PrefabHash = Prefabs.CraftPieceSideFlat2Way.Hash,
                            Components = new List<PoiString.AttTypes.Components.ATTSerializableComponent>()
                            {
                                new PoiString.AttTypes.Components.PhysicalMaterialPart()
                                {
                                    Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                                }
                            },
                            Children = new List<ChildNetworkPrefab>()
                        }
                    }
                }
            };
            NetworkPrefab blade = new NetworkPrefab()
            {
                PrefabHash = Prefabs.ShortSwordBlade.Hash,
                Components = new List<ATTSerializableComponent>()
                {
                    new PhysicalMaterialPart()
                    {
                        Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                    }
                }
            };

            //prefab - get the first child object(the guard) - get that children object and add to it 
            prefab.Children[0].Prefab.Children.Add(new ChildNetworkPrefab
            {
                //with this its kind of hard to know what slot is where sooo... good luuuuck!
                parentHash = Prefabs.CraftPieceSideFlat2Way.Embeds.SlotEdgeType_39368.Hash,
                Prefab = blade
            });
            prefab.Children[0].Prefab.Children.Add(new ChildNetworkPrefab
            {
                parentHash = Prefabs.CraftPieceSideFlat2Way.Embeds.SlotEdgeType_51672.Hash,
                Prefab = blade
            });

            return PoiStentions.GetAsATTString(prefab);
        }
        //COMPLETE
        static string WeaponExample4()
        {
            //now something barely anyone knows about is the fact you can use loops to make stuff
            //so i am about to singlehandedly mess up stringed weapons for a few weeks because i know everyone is going to do this till yall settle down a bit

            NetworkPrefab HandleAndGuard = new NetworkPrefab()
            {
                PrefabHash = Prefabs.HandleShortCool.Hash,
                Children = new List<ChildNetworkPrefab>()
                {
                    new ChildNetworkPrefab()
                    {
                        parentHash = Prefabs.HandleShortCool.Embeds.SlotMulti_48480.Hash,
                        Prefab = new NetworkPrefab()
                        {
                            PrefabHash = Prefabs.LargeGuardRectangle.Hash,
                            Components = new List<PoiString.AttTypes.Components.ATTSerializableComponent>()
                            {
                                new PoiString.AttTypes.Components.PhysicalMaterialPart()
                                {
                                    Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                                }
                            }
                        }
                    }
                }
            };
            //this is a variable targeting where we want to work on the prefab
            //stuff might be getting a little confusing by here eh? 
            NetworkPrefab pointer = HandleAndGuard.Children[0].Prefab;
            //repeat 10 times
            for (int i = 0; i < 10; i++)
            {
                pointer.Children.Add(new ChildNetworkPrefab
                {
                    parentHash = Prefabs.LargeGuardRectangle.Embeds.SlotLargeSwordType_51896.Hash,
                    Prefab = new NetworkPrefab()
                    {
                        PrefabHash = Prefabs.LargeGuardRectangle.Hash,
                        Components = new List<ATTSerializableComponent>()
                        {
                            new PhysicalMaterialPart()
                            {
                                Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                            }
                        }
                    }
                });
                pointer = pointer.Children[0].Prefab;
            }
            pointer.Children.Add(new ChildNetworkPrefab
            {
                parentHash = Prefabs.LargeGuardRectangle.Embeds.SlotLargeSwordType_51896.Hash,
                Prefab = new NetworkPrefab()
                {
                    PrefabHash = Prefabs.LargeLongswordBlade.Hash,
                    Components = new List<ATTSerializableComponent>()
                        {
                            new PhysicalMaterialPart()
                            {
                                Hash = (int)Knowledge.PhysicalMaterial.EvinonSteelAlloy
                            }
                        }
                }
            });



            return PoiStentions.GetAsATTString(HandleAndGuard);
        }













    }
}
