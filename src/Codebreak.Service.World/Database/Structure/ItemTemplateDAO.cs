﻿using System;
using System.Linq;
using System.Collections.Generic;
using Codebreak.Framework.Database;
using Codebreak.Service.World.Game;
using Codebreak.Service.World.Game.Spell;
using Codebreak.Service.World.Game.Stats;
using Codebreak.Service.World.Network;
using Codebreak.Service.World.Database.Repository;
using PropertyChanged;

namespace Codebreak.Service.World.Database.Structure
{
    /// <summary>
    /// 
    /// </summary>
    public enum ItemTypeEnum
    {
        TYPE_AMULETTE = 1,
        TYPE_ARC = 2,
        TYPE_BAGUETTE = 3,
        TYPE_BATON = 4,
        TYPE_DAGUES = 5,
        TYPE_EPEE = 6,
        TYPE_MARTEAU = 7,
        TYPE_PELLE = 8,
        TYPE_ANNEAU = 9,
        TYPE_CEINTURE = 10,
        TYPE_BOTTES = 11,
        TYPE_POTION = 12,
        TYPE_APRCHO_EXP = 13,
        TYPE_DONS = 14,
        TYPE_RESSOURCE = 15,
        TYPE_COIFFE = 16,
        TYPE_CAPE = 17,
        TYPE_FAMILIER = 18,
        TYPE_HACHE = 19,
        TYPE_OUTIL = 20,
        TYPE_PIOCHE = 21,
        TYPE_FAUX = 22,
        TYPE_DOFUS = 23,
        TYPE_QUETES = 24,
        TYPE_DOCUMENT = 25,
        TYPE_FM_POTION = 26,
        TYPE_TRANSFORM = 27,
        TYPE_BOOST_FOOD = 28,
        TYPE_BENEDICTION = 29,
        TYPE_MALEDICTION = 30,
        TYPE_RP_BUFF = 31,
        TYPE_PERSO_SUIVEUR = 32,
        TYPE_PAIN = 33,
        TYPE_CEREALE = 34,
        TYPE_FLEUR = 35,
        TYPE_PLANTE = 36,
        TYPE_BIERE = 37,
        TYPE_BOIS = 38,
        TYPE_MINERAIS = 39,
        TYPE_ALLIAGE = 40,
        TYPE_POISSON = 41,
        TYPE_BONBON = 42,
        TYPE_POTION_OUBLIE = 43,
        TYPE_POTION_METIER = 44,
        TYPE_POTION_SORT = 45,
        TYPE_FRUIT = 46,
        TYPE_OS = 47,
        TYPE_POUDRE = 48,
        TYPE_COMESTI_POISSON = 49,
        TYPE_PIERRE_PRECIEUSE = 50,
        TYPE_PIERRE_BRUTE = 51,
        TYPE_FARINE = 52,
        TYPE_PLUME = 53,
        TYPE_POIL = 54,
        TYPE_ETOFFE = 55,
        TYPE_CUIR = 56,
        TYPE_LAINE = 57,
        TYPE_GRAINE = 58,
        TYPE_PWater = 59,
        TYPE_HUILE = 60,
        TYPE_PELUCHE = 61,
        TYPE_POISSON_VIDE = 62,
        TYPE_VIANDE = 63,
        TYPE_VIANDE_CONSERVEE = 64,
        TYPE_QUEUE = 65,
        TYPE_METARIA = 66,
        TYPE_LEGUME = 68,
        TYPE_VIANDE_COMESTIBLE = 69,
        TYPE_TEINTURE = 70,
        TYPE_EQUIP_ALCHIMIE = 71,
        TYPE_OEUF_FAMILIER = 72,
        TYPE_MAITRISE = 73,
        TYPE_FEE_ARTIFICE = 74,
        TYPE_APRCHEMIN_SORT = 75,
        TYPE_APRCHEMIN_CARAC = 76,
        TYPE_CERTIFICAT_CHANIL = 77,
        TYPE_RUNE_FORGEMAGIE = 78,
        TYPE_BOISSON = 79,
        TYPE_OBJET_MISSION = 80,
        TYPE_SAC_DOS = 81,
        TYPE_BOUCLIER = 82,
        TYPE_PIERRE_AME = 83,
        TYPE_CLEFS = 84,
        TYPE_PIERRE_AME_PLEINE = 85,
        TYPE_POPO_OUBLI_PERCEP = 86,
        TYPE_APRCHO_RECHERCHE = 87,
        TYPE_PIERRE_MAGIQUE = 88,
        TYPE_CADEAUX = 89,
        TYPE_FANTOME_FAMILIER = 90,
        TYPE_DRAGODINDE = 91,
        TYPE_BOUFTOU = 92,
        TYPE_OBJET_ELEVAGE = 93,
        TYPE_OBJET_UTILISABLE = 94,
        TYPE_PLANCHE = 95,
        TYPE_ECORCE = 96,
        TYPE_CERTIF_MONTURE = 97,
        TYPE_RACINE = 98,
        TYPE_FILET_CAPTURE = 99,
        TYPE_SAC_RESSOURCE = 100,
        TYPE_ARBALETE = 102,
        TYPE_APTTE = 103,
        TYPE_AILE = 104,
        TYPE_OEUF = 105,
        TYPE_OREILLE = 106,
        TYPE_CARAAPCE = 107,
        TYPE_BOURGEON = 108,
        TYPE_OEIL = 109,
        TYPE_GELEE = 110,
        TYPE_COQUILLE = 111,
        TYPE_PRISME = 112,
        TYPE_OBJET_VIVANT = 113,
        TYPE_ARME_MAGIQUE = 114,
        TYPE_FRAGM_AME_SHUSHU = 115,
        TYPE_POTION_FAMILIER = 116,
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum ItemSlotEnum
    {
        SLOT_INVENTORY = -1,
        SLOT_AMULET = 0,
        SLOT_WEAPON = 1,
        SLOT_LEFT_RING = 2,
        SLOT_BELT = 3,
        SLOT_RIGHT_RING = 4,
        SLOT_BOOTS = 5,
        SLOT_HAT = 6,
        SLOT_CAPE = 7,
        SLOT_PET = 8,
        SLOT_DOFUS_1 = 9,
        SLOT_DOFUS_2 = 10,
        SLOT_DOFUS_3 = 11,
        SLOT_DOFUS_4 = 12,
        SLOT_DOFUS_5 = 13,
        SLOT_DOFUS_6 = 14,
        SLOT_SHIELD = 15,
        SLOT_MOUNT = 16,

        SLOT_BOOST_MUTATION = 20,
        SLOT_BOOST_FOOD = 21,
        SLOT_BOOST_BENEDICTION = 22,
        SLOT_BOOST_BENEDICTION_1 = 23,
        SLOT_BOOST_MALEDICTION = 24,
        SLOT_BOOST_MALEDICTION_1 = 25,
        SLOT_BOOST_ROLEPLAY_BUFF = 26,
        SLOT_BOOST_FOLLOWER = 27,

        SLOT_ITEMBAR_1 = 35,
        SLOT_ITEMBAR_2 = 36, 
        SLOT_ITEMBAR_3 = 37,
        SLOT_ITEMBAR_4 = 38,
        SLOT_ITEMBAR_5 = 39,
        SLOT_ITEMBAR_6 = 40,
        SLOT_ITEMBAR_7 = 41,
        SLOT_ITEMBAR_8 = 42,
        SLOT_ITEMBAR_9 = 43,
        SLOT_ITEMBAR_10 = 44,
        SLOT_ITEMBAR_11 = 45,
        SLOT_ITEMBAR_12 = 46,
        SLOT_ITEMBAR_13 = 47,
        SLOT_ITEMBAR_14 = 48,

        //SLOT_BOOST = SLOT_BOOST_FOOD | SLOT_BOOST_BENEDICTION |SLOT_BOOST_BENEDICTION_1 | SLOT_BOOST_MALEDICTION 
        //| SLOT_BOOST_MALEDICTION_1 | SLOT_BOOST_MUTATION | SLOT_BOOST_FOLLOWER | SLOT_BOOST_ROLEPLAY_BUFF,

        //SLOT_EQUIPPED = SLOT_AMULET | SLOT_WEAPON | SLOT_LEFT_RING | SLOT_BELT | SLOT_RIGHT_RING | SLOT_BOOTS | SLOT_HAT
        //| SLOT_CAPE | SLOT_PET | SLOT_DOFUS_1 | SLOT_DOFUS_2 | SLOT_DOFUS_3 | SLOT_DOFUS_4 | SLOT_DOFUS_5 | SLOT_DOFUS_6
        //| SLOT_SHIELD | SLOT_BOOST_FOOD | SLOT_BOOST_BENEDICTION |SLOT_BOOST_BENEDICTION_1 | SLOT_BOOST_MALEDICTION 
        //| SLOT_BOOST_MALEDICTION_1 | SLOT_BOOST_MUTATION | SLOT_BOOST_FOLLOWER | SLOT_BOOST_ROLEPLAY_BUFF,
    }

    /// <summary>
    /// 
    /// </summary>
    [Table("itemtemplate")]
    public sealed class ItemTemplateDAO : DataAccessObject<ItemTemplateDAO>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsWeaponEffect(EffectEnum type)
        {
            switch (type)
            {
                case EffectEnum.StealEarth:
                case EffectEnum.StealFire:
                case EffectEnum.StealWater:
                case EffectEnum.StealAir:
                case EffectEnum.StealNeutral:
                case EffectEnum.DamageEarth:
                case EffectEnum.DamageNeutral:
                case EffectEnum.DamageFire:
                case EffectEnum.DamageWater:
                case EffectEnum.DamageAir:
                case EffectEnum.SubAPDodgeable:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public static bool CanPlaceInSlot(ItemTypeEnum type, ItemSlotEnum slot)
        {
            if (slot < ItemSlotEnum.SLOT_AMULET || slot > ItemSlotEnum.SLOT_BOOST_FOLLOWER)
                return false;

            return ((GetSlotByType(type) | ItemSlotEnum.SLOT_INVENTORY) & slot) == slot;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ItemSlotEnum GetSlotByType(ItemTypeEnum type)
        {
            switch (type)
            {
                case ItemTypeEnum.TYPE_TRANSFORM:
                    return ItemSlotEnum.SLOT_BOOST_MUTATION;

                case ItemTypeEnum.TYPE_PERSO_SUIVEUR:
                    return ItemSlotEnum.SLOT_BOOST_FOLLOWER;

                case ItemTypeEnum.TYPE_BENEDICTION:
                    return ItemSlotEnum.SLOT_BOOST_BENEDICTION | ItemSlotEnum.SLOT_BOOST_BENEDICTION_1;

                case ItemTypeEnum.TYPE_MALEDICTION:
                    return ItemSlotEnum.SLOT_BOOST_MALEDICTION | ItemSlotEnum.SLOT_BOOST_MALEDICTION_1;

                case ItemTypeEnum.TYPE_RP_BUFF:
                    return ItemSlotEnum.SLOT_BOOST_ROLEPLAY_BUFF;

                case ItemTypeEnum.TYPE_BOOST_FOOD:
                    return ItemSlotEnum.SLOT_BOOST_FOOD;

                case ItemTypeEnum.TYPE_AMULETTE:
                    return ItemSlotEnum.SLOT_AMULET;

                case ItemTypeEnum.TYPE_ARC:
                case ItemTypeEnum.TYPE_BAGUETTE:
                case ItemTypeEnum.TYPE_BATON:
                case ItemTypeEnum.TYPE_DAGUES:
                case ItemTypeEnum.TYPE_EPEE:
                case ItemTypeEnum.TYPE_MARTEAU:
                case ItemTypeEnum.TYPE_PELLE:
                case ItemTypeEnum.TYPE_HACHE:
                case ItemTypeEnum.TYPE_OUTIL:
                case ItemTypeEnum.TYPE_PIOCHE:
                case ItemTypeEnum.TYPE_FAUX:
                case ItemTypeEnum.TYPE_PIERRE_AME:
                    return ItemSlotEnum.SLOT_WEAPON;

                case ItemTypeEnum.TYPE_ANNEAU:
                    return ItemSlotEnum.SLOT_RIGHT_RING | ItemSlotEnum.SLOT_LEFT_RING;

                case ItemTypeEnum.TYPE_CEINTURE:
                    return ItemSlotEnum.SLOT_BELT;

                case ItemTypeEnum.TYPE_BOTTES:
                    return ItemSlotEnum.SLOT_BOOTS;

                case ItemTypeEnum.TYPE_COIFFE:
                    return ItemSlotEnum.SLOT_HAT;

                case ItemTypeEnum.TYPE_CAPE:
                    return ItemSlotEnum.SLOT_CAPE;

                case ItemTypeEnum.TYPE_FAMILIER:
                    return ItemSlotEnum.SLOT_PET;

                case ItemTypeEnum.TYPE_DOFUS:
                    return ItemSlotEnum.SLOT_DOFUS_1
                    | ItemSlotEnum.SLOT_DOFUS_2
                    | ItemSlotEnum.SLOT_DOFUS_3
                    | ItemSlotEnum.SLOT_DOFUS_4
                    | ItemSlotEnum.SLOT_DOFUS_5
                    | ItemSlotEnum.SLOT_DOFUS_6;

                case ItemTypeEnum.TYPE_BOUCLIER:
                    return ItemSlotEnum.SLOT_SHIELD;
            }

            return ItemSlotEnum.SLOT_INVENTORY;
        }

        [Key]
        /// <summary>        
        /// 
        /// </summary>
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Type
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Level
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Weight
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool TwoHands
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Ethereal
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Forgemageable
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Buff
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Usable
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Targetable
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int Price
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Conditions
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Effects
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int SetId
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int CSBonus
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int APCost
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int POMin
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int POMax
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int CSRate
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int CFRate
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        private List<CraftEntryDAO> m_ingredients;

        /// <summary>
        /// 
        /// </summary>
        [Write(false)]
        public List<CraftEntryDAO> Ingredients
        {
            get
            {
                if (m_ingredients == null)
                    m_ingredients = new List<CraftEntryDAO>();
                return m_ingredients;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ItemSetDAO m_set;

        /// <summary>
        /// 
        /// </summary>
        [Write(false)]
        [DoNotNotify]
        public ItemSetDAO Set
        {
            get
            {
                if (m_set == null)
                    m_set = ItemSetRepository.Instance.GetSetById(SetId);
                return m_set;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private RandomStatistics m_effects;
        private string m_rangeType;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Write(false)]
        [DoNotNotify]
        public string RangeType
        {
            get
            {
                if (m_rangeType == null)
                {
                    switch ((ItemTypeEnum)Type)
                    {
                        case ItemTypeEnum.TYPE_MARTEAU:
                            m_rangeType = "Xb";
                            break;
                        case ItemTypeEnum.TYPE_BATON:
                            m_rangeType = "Tb";
                            break;
                        case ItemTypeEnum.TYPE_ARBALETE:
                            m_rangeType = "Lc";
                            break;
                        default:
                            m_rangeType = "Pa";
                            break;
                    }
                }

                return m_rangeType;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Write(false)]
        [DoNotNotify]
        public RandomStatistics RandomEffects
        {
            get
            {
                if (m_effects == null)
                    m_effects = RandomStatistics.Deserialize(Effects);
                return m_effects;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GenericStats GenerateStats(bool max = false)
        {
            var generatedStats = new GenericStats();
            foreach (var effect in RandomEffects)
            {
                if (Usable || IsWeaponEffect(effect.Type))                
                    generatedStats.AddEffect(effect.Type, effect.Minimum, effect.Maximum);                
                else if (effect.Type == EffectEnum.AddBoost)                
                    generatedStats.AddEffect(effect.Type, 0, 0, max ? effect.Maximum : effect.Random);                
                else
                    generatedStats.AddEffect(effect.Type, max ? effect.Maximum : effect.Random);                
            }
            return generatedStats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="slot"></param>
        /// <param name="maxJet"></param>
        /// <returns></returns>
        public ItemDAO Create(int quantity = 1, ItemSlotEnum slot = ItemSlotEnum.SLOT_INVENTORY, bool maxJet = false)
        {
            return InventoryItemRepository.Instance.Create(Id, -1, quantity, GenerateStats(maxJet), slot);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templateIds"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool MatchCraft(Dictionary<int, long> templates)
        {
            return Ingredients.All(ingredient => templates.Any(template => ingredient.RequiredId == template.Key && ingredient.RequiredQuantity == template.Value))
                && templates.All(template => Ingredients.Any(ingredient => ingredient.RequiredId == template.Key && ingredient.RequiredQuantity == template.Value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Id + " ( " + Name + " ) ";
        }
    }
}
