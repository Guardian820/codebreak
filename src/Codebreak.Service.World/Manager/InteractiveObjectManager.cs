﻿using Codebreak.Framework.Generic;
using Codebreak.Service.World.Game.Interactive;
using Codebreak.Service.World.Game.Interactive.Type;
using Codebreak.Service.World.Game.Map;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.Service.World.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class InteractiveObjectManager : Singleton<InteractiveObjectManager>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<int, Func<MapInstance, int, InteractiveObject>> m_interactiveById;

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<int, int> m_interactiveByGfx;

        /// <summary>
        /// 
        /// </summary>
        public InteractiveObjectManager()
        {
            m_interactiveById = new Dictionary<int, Func<MapInstance, int, InteractiveObject>>();
            m_interactiveByGfx = new Dictionary<int, int>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            // Autre
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ZAAP, (map, cellId) => new Waypoint(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_POUBELLE, (map, cellId) => new TrashCan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PHOENIX, (map, cellId) => new Pheonix(map, cellId));

            // Craft
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_SCIE, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ENCLUME, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_MACHINE_A_COUDRE, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_MACHINE_A_COUDRE_1, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ATELIER, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ETABLI, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ETABLI_EN_BOIS, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ENCLUME_A_BOUCLIERS, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PLAN_DE_TRAVAIL, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PLAN_DE_TRAVAIL_1, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PLAN_DE_TRAVAIL_2, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PLAN_DE_TRAVAIL_3, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ALAMBIC, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ATELIER_DE_BRICOLAGE, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_CONCASSEUR, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ETABLI_PYROTECHNIQUE, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_FILEUSE, (map, cellId) => new CraftPlan(map, cellId));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_FOUR, (map, cellId) => new CraftPlan(map, cellId));

            // Alchemiste
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_LIN, (map, cellId) => new HarvestableResource(map, cellId, 421, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_CHANVRE, (map, cellId) => new HarvestableResource(map, cellId, 428, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_TREFLE_A_5_FEUILLES, (map, cellId) => new HarvestableResource(map, cellId, 395, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_MENTHE_SAUVAGE, (map, cellId) => new HarvestableResource(map, cellId, 380, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ORCHIDEE_FREYESQUE, (map, cellId) => new HarvestableResource(map, cellId, 593, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_EDELWEISS, (map, cellId) => new HarvestableResource(map, cellId, 594, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PANDOUILLE, (map, cellId) => new HarvestableResource(map, cellId, 7059, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));

            // Bois
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_FRENE, (map, cellId) => new HarvestableResource(map, cellId, 303, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_CHATAIGNIER, (map, cellId) => new HarvestableResource(map, cellId, 473, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_IF, (map, cellId) => new HarvestableResource(map, cellId, 461, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ERABLE, (map, cellId) => new HarvestableResource(map, cellId, 471, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_CHARME, (map, cellId) => new HarvestableResource(map, cellId, 472, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_CHENE, (map, cellId) => new HarvestableResource(map, cellId, 460, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_NOYER, (map, cellId) => new HarvestableResource(map, cellId, 476, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_EBENE, (map, cellId) => new HarvestableResource(map, cellId, 449, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_KALIPTUS, (map, cellId) => new HarvestableResource(map, cellId, 303, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_MERISIER, (map, cellId) => new HarvestableResource(map, cellId, 474, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ORME, (map, cellId) => new HarvestableResource(map, cellId, 470, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_BAMBOU_SACRE, (map, cellId) => new HarvestableResource(map, cellId, 7014, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_BAMBOU_SOMBRE, (map, cellId) => new HarvestableResource(map, cellId, 7016, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_BAMBOU, (map, cellId) => new HarvestableResource(map, cellId, 7013, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_BOMBU, (map, cellId) => new HarvestableResource(map, cellId, 2358, 1000 * 60 * 1, 1000 * 60 * 5, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_OLIVIOLET, (map, cellId) => new HarvestableResource(map, cellId, 2357, 1000 * 60 * 1, 1000 * 60 * 5, 10));

            // Paysan
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_BLE, (map, cellId) => new HarvestableResource(map, cellId, 289, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ORGE, (map, cellId) => new HarvestableResource(map, cellId, 400, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_AVOINE, (map, cellId) => new HarvestableResource(map, cellId, 533, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_HOUBLON, (map, cellId) => new HarvestableResource(map, cellId, 401, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_RIZ, (map, cellId) => new HarvestableResource(map, cellId, 7018, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_SEIGLE, (map, cellId) => new HarvestableResource(map, cellId, 532, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_MALT, (map, cellId) => new HarvestableResource(map, cellId, 405, 1000 * 60 * 1, 1000 * 60 * 1, 10, true));

            // Pêcheur
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PETITS_POISSONS_MER, (map, cellId) => new HarvestableResource(map, cellId, 289, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_POISSONS_RIVIERE, (map, cellId) => new HarvestableResource(map, cellId, 289, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PETITS_POISSONS_RIVIERE, (map, cellId) => new HarvestableResource(map, cellId, 1782, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_GROS_POISSONS_RIVIERE, (map, cellId) => new HarvestableResource(map, cellId, 289, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_POISSONS_MER, (map, cellId) => new HarvestableResource(map, cellId, 289, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_GROS_POISSONS_MER, (map, cellId) => new HarvestableResource(map, cellId, 289, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_POISSONS_GEANTS_RIVIERE, (map, cellId) => new HarvestableResource(map, cellId, 289, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_POISSONS_GEANTS_MER, (map, cellId) => new HarvestableResource(map, cellId, 289, 1000 * 60 * 1, 1000 * 60 * 1, 10));

            // Mineur
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_FER, (map, cellId) => new HarvestableResource(map, cellId, 312, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PIERRE_CUIVREE, (map, cellId) => new HarvestableResource(map, cellId, 441, 1000 * 60 * 1, 1000 * 60 * 1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_BRONZE, (map, cellId) => new HarvestableResource(map, cellId, 442, 1000 *  60 *  1, 1000 *  60 *  1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PIERRE_DE_KOBALTE, (map, cellId) => new HarvestableResource(map, cellId, 443, 1000 *  60 *  1, 1000 *  60 *  1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ARGENT, (map, cellId) => new HarvestableResource(map, cellId, 350, 1000 *  60 *  1, 1000 *  60 *  1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_OR, (map, cellId) => new HarvestableResource(map, cellId, 313, 1000 *  60 *  1, 1000 *  60 *  1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PIERRE_DE_BAUXITE, (map, cellId) => new HarvestableResource(map, cellId, 446, 1000 *  60 *  1, 1000 *  60 *  1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ETAIN, (map, cellId) => new HarvestableResource(map, cellId, 444, 1000 *  60 * 1, 1000 *  60 *  1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_MANGANESE, (map, cellId) => new HarvestableResource(map, cellId, 445, 1000 *  60 *  1, 1000 *  60 *  1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_DOLOMITE, (map, cellId) => new HarvestableResource(map, cellId, 7033, 1000 *  60 *  1, 1000 *  60 *  1, 10));
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_SILICATE, (map, cellId) => new HarvestableResource(map, cellId, 7032, 1000 *  60 *  1, 1000 *  60 *  1, 10));

            // Enclos 
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_ENCLOS, (map, cellId) => new PaddockDoor(map, cellId));

            // Porte
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_PORTE, (map, cellId) => new HouseDoor(map, cellId));

            // Coffre
            AddInteractive(InteractiveObjectIdEnum.INTERACTIVE_COFFRE, (map, cellId) => new Chest(map, cellId));

            // GFX
            AddInteractiveGfx(7500, InteractiveObjectIdEnum.INTERACTIVE_FRENE);
            AddInteractiveGfx(7003, InteractiveObjectIdEnum.INTERACTIVE_SCIE);
            AddInteractiveGfx(7503, InteractiveObjectIdEnum.INTERACTIVE_CHENE);
            AddInteractiveGfx(7011, InteractiveObjectIdEnum.INTERACTIVE_TABLE_DE_CONFECTION);
            AddInteractiveGfx(7008, InteractiveObjectIdEnum.INTERACTIVE_ATELIER);
            AddInteractiveGfx(7009, InteractiveObjectIdEnum.INTERACTIVE_ATELIER);
            AddInteractiveGfx(7010, InteractiveObjectIdEnum.INTERACTIVE_ATELIER);
            AddInteractiveGfx(7013, InteractiveObjectIdEnum.INTERACTIVE_ETABLI);
            AddInteractiveGfx(7000, InteractiveObjectIdEnum.INTERACTIVE_ZAAP);
            AddInteractiveGfx(7026, InteractiveObjectIdEnum.INTERACTIVE_ZAAP);
            AddInteractiveGfx(7029, InteractiveObjectIdEnum.INTERACTIVE_ZAAP);
            AddInteractiveGfx(4287, InteractiveObjectIdEnum.INTERACTIVE_ZAAP);
            AddInteractiveGfx(7520, InteractiveObjectIdEnum.INTERACTIVE_FER);
            AddInteractiveGfx(7001, InteractiveObjectIdEnum.INTERACTIVE_FOUR);
            AddInteractiveGfx(7526, InteractiveObjectIdEnum.INTERACTIVE_ARGENT);
            AddInteractiveGfx(7527, InteractiveObjectIdEnum.INTERACTIVE_OR);
            AddInteractiveGfx(7528, InteractiveObjectIdEnum.INTERACTIVE_PIERRE_DE_BAUXITE);
            AddInteractiveGfx(7002, InteractiveObjectIdEnum.INTERACTIVE_MOULE);
            AddInteractiveGfx(7505, InteractiveObjectIdEnum.INTERACTIVE_IF);
            AddInteractiveGfx(7507, InteractiveObjectIdEnum.INTERACTIVE_EBENE);
            AddInteractiveGfx(7509, InteractiveObjectIdEnum.INTERACTIVE_ORME);
            AddInteractiveGfx(7504, InteractiveObjectIdEnum.INTERACTIVE_ERABLE);
            AddInteractiveGfx(7508, InteractiveObjectIdEnum.INTERACTIVE_CHARME);
            AddInteractiveGfx(7501, InteractiveObjectIdEnum.INTERACTIVE_CHATAIGNIER);
            AddInteractiveGfx(7502, InteractiveObjectIdEnum.INTERACTIVE_NOYER);
            AddInteractiveGfx(7506, InteractiveObjectIdEnum.INTERACTIVE_MERISIER);
            AddInteractiveGfx(7525, InteractiveObjectIdEnum.INTERACTIVE_PIERRE_DE_KOBALTE);
            AddInteractiveGfx(7511, InteractiveObjectIdEnum.INTERACTIVE_BLE);
            AddInteractiveGfx(7512, InteractiveObjectIdEnum.INTERACTIVE_HOUBLON);
            AddInteractiveGfx(7005, InteractiveObjectIdEnum.INTERACTIVE_MEULE);
            AddInteractiveGfx(7513, InteractiveObjectIdEnum.INTERACTIVE_LIN);
            AddInteractiveGfx(7515, InteractiveObjectIdEnum.INTERACTIVE_ORGE);
            AddInteractiveGfx(7516, InteractiveObjectIdEnum.INTERACTIVE_SEIGLE);
            AddInteractiveGfx(7517, InteractiveObjectIdEnum.INTERACTIVE_AVOINE);
            AddInteractiveGfx(7514, InteractiveObjectIdEnum.INTERACTIVE_CHANVRE);
            AddInteractiveGfx(7518, InteractiveObjectIdEnum.INTERACTIVE_MALT);
            AddInteractiveGfx(7510, InteractiveObjectIdEnum.INTERACTIVE_TAS_DE_PATATES);
            AddInteractiveGfx(7006, InteractiveObjectIdEnum.INTERACTIVE_TABLE_A_PATATES);
            AddInteractiveGfx(7007, InteractiveObjectIdEnum.INTERACTIVE_CONCASSEUR);
            AddInteractiveGfx(7521, InteractiveObjectIdEnum.INTERACTIVE_ETAIN);
            AddInteractiveGfx(7522, InteractiveObjectIdEnum.INTERACTIVE_PIERRE_CUIVREE);
            AddInteractiveGfx(7524, InteractiveObjectIdEnum.INTERACTIVE_MANGANESE);
            AddInteractiveGfx(7523, InteractiveObjectIdEnum.INTERACTIVE_BRONZE);
            AddInteractiveGfx(7004, InteractiveObjectIdEnum.INTERACTIVE_SOURCE_DE_JOUVENCE);
            AddInteractiveGfx(7012, InteractiveObjectIdEnum.INTERACTIVE_ENCLUME);
            AddInteractiveGfx(7014, InteractiveObjectIdEnum.INTERACTIVE_MACHINE_A_COUDRE_1);
            AddInteractiveGfx(7016, InteractiveObjectIdEnum.INTERACTIVE_MACHINE_A_COUDRE_1);
            AddInteractiveGfx(7017, InteractiveObjectIdEnum.INTERACTIVE_MARMITE);
            AddInteractiveGfx(7536, InteractiveObjectIdEnum.INTERACTIVE_EDELWEISS);
            AddInteractiveGfx(7534, InteractiveObjectIdEnum.INTERACTIVE_MENTHE_SAUVAGE);
            AddInteractiveGfx(7533, InteractiveObjectIdEnum.INTERACTIVE_TREFLE_A_5_FEUILLES);
            AddInteractiveGfx(7535, InteractiveObjectIdEnum.INTERACTIVE_ORCHIDEE_FREYESQUE);
            AddInteractiveGfx(6700, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6701, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6702, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6703, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6704, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6705, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6706, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6707, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6708, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6709, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6710, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6711, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6713, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6714, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6715, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6716, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6717, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6718, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6719, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6720, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6721, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6722, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6723, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6724, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6725, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6726, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6729, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6730, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6731, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6732, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6733, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6734, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6735, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6736, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6737, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6738, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6739, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6740, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6741, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6742, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6743, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6744, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6745, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6746, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6747, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6748, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6753, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6749, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6750, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6751, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6752, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6754, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6756, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6755, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6757, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6758, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6764, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6765, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6768, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6759, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6760, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6761, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6762, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6769, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6770, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(4516, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6773, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6774, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6775, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(6776, InteractiveObjectIdEnum.INTERACTIVE_PORTE);
            AddInteractiveGfx(7530, InteractiveObjectIdEnum.INTERACTIVE_PETITS_POISSONS_MER);
            AddInteractiveGfx(7532, InteractiveObjectIdEnum.INTERACTIVE_POISSONS_RIVIERE);
            AddInteractiveGfx(7529, InteractiveObjectIdEnum.INTERACTIVE_PETITS_POISSONS_RIVIERE);
            AddInteractiveGfx(7537, InteractiveObjectIdEnum.INTERACTIVE_GROS_POISSONS_RIVIERE);
            AddInteractiveGfx(7531, InteractiveObjectIdEnum.INTERACTIVE_POISSONS_MER);
            AddInteractiveGfx(7538, InteractiveObjectIdEnum.INTERACTIVE_GROS_POISSONS_MER);
            AddInteractiveGfx(7539, InteractiveObjectIdEnum.INTERACTIVE_POISSONS_GEANTS_RIVIERE);
            AddInteractiveGfx(7540, InteractiveObjectIdEnum.INTERACTIVE_POISSONS_GEANTS_MER);
            AddInteractiveGfx(7519, InteractiveObjectIdEnum.INTERACTIVE_PUITS);
            AddInteractiveGfx(7350, InteractiveObjectIdEnum.INTERACTIVE_COFFRE);
            AddInteractiveGfx(7351, InteractiveObjectIdEnum.INTERACTIVE_COFFRE);
            //AddInteractiveGfx(7352, InteractiveObjectIdEnum.INTERACTIVE_COFFRE);
            AddInteractiveGfx(7353, InteractiveObjectIdEnum.INTERACTIVE_COFFRE);
            AddInteractiveGfx(7015, InteractiveObjectIdEnum.INTERACTIVE_MACHINE_A_COUDRE);
            AddInteractiveGfx(7018, InteractiveObjectIdEnum.INTERACTIVE_ETABLI_EN_BOIS);
            AddInteractiveGfx(7019, InteractiveObjectIdEnum.INTERACTIVE_ALAMBIC);
            AddInteractiveGfx(7020, InteractiveObjectIdEnum.INTERACTIVE_ENCLUME_MAGIQUE);
            AddInteractiveGfx(7021, InteractiveObjectIdEnum.INTERACTIVE_CONCASSEUR_MUNSTER);
            AddInteractiveGfx(7022, InteractiveObjectIdEnum.INTERACTIVE_PLAN_DE_TRAVAIL_2);
            AddInteractiveGfx(7025, InteractiveObjectIdEnum.INTERACTIVE_PLAN_DE_TRAVAIL);
            AddInteractiveGfx(7024, InteractiveObjectIdEnum.INTERACTIVE_PLAN_DE_TRAVAIL_1);
            AddInteractiveGfx(7023, InteractiveObjectIdEnum.INTERACTIVE_PLAN_DE_TRAVAIL_3);
            AddInteractiveGfx(7541, InteractiveObjectIdEnum.INTERACTIVE_BOMBU);
            AddInteractiveGfx(7543, InteractiveObjectIdEnum.INTERACTIVE_OMBRE_ETRANGE);
            AddInteractiveGfx(7544, InteractiveObjectIdEnum.INTERACTIVE_PICHON);
            AddInteractiveGfx(7542, InteractiveObjectIdEnum.INTERACTIVE_OLIVIOLET);
            AddInteractiveGfx(7546, InteractiveObjectIdEnum.INTERACTIVE_MACHINE_DE_FORCE);
            AddInteractiveGfx(7547, InteractiveObjectIdEnum.INTERACTIVE_MACHINE_DE_FORCE);
            AddInteractiveGfx(7028, InteractiveObjectIdEnum.INTERACTIVE_ETABLI_PYROTECHNIQUE);
            AddInteractiveGfx(7549, InteractiveObjectIdEnum.INTERACTIVE_KOINKOIN);
            AddInteractiveGfx(7352, InteractiveObjectIdEnum.INTERACTIVE_POUBELLE);
            AddInteractiveGfx(7030, InteractiveObjectIdEnum.INTERACTIVE_ZAAPI);
            AddInteractiveGfx(7031, InteractiveObjectIdEnum.INTERACTIVE_ZAAPI);
            AddInteractiveGfx(7027, InteractiveObjectIdEnum.INTERACTIVE_ENCLUME_A_BOUCLIERS);
            AddInteractiveGfx(7553, InteractiveObjectIdEnum.INTERACTIVE_BAMBOU);
            AddInteractiveGfx(7554, InteractiveObjectIdEnum.INTERACTIVE_BAMBOU_SOMBRE);
            AddInteractiveGfx(7552, InteractiveObjectIdEnum.INTERACTIVE_BAMBOU_SACRE);
            AddInteractiveGfx(7550, InteractiveObjectIdEnum.INTERACTIVE_RIZ);
            AddInteractiveGfx(7551, InteractiveObjectIdEnum.INTERACTIVE_PANDOUILLE);
            AddInteractiveGfx(7555, InteractiveObjectIdEnum.INTERACTIVE_DOLOMITE);
            AddInteractiveGfx(7556, InteractiveObjectIdEnum.INTERACTIVE_SILICATE);
            AddInteractiveGfx(7036, InteractiveObjectIdEnum.INTERACTIVE_MACHINE_A_COUDRE_MAGIQUE);
            AddInteractiveGfx(7038, InteractiveObjectIdEnum.INTERACTIVE_ATELIER_MAGIQUE);
            AddInteractiveGfx(7037, InteractiveObjectIdEnum.INTERACTIVE_TABLE_MAGIQUE);
            AddInteractiveGfx(7035, InteractiveObjectIdEnum.INTERACTIVE_LISTE_DES_ARTISANS);
            AddInteractiveGfx(6766, InteractiveObjectIdEnum.INTERACTIVE_ENCLOS);
            AddInteractiveGfx(6767, InteractiveObjectIdEnum.INTERACTIVE_ENCLOS);
            AddInteractiveGfx(6763, InteractiveObjectIdEnum.INTERACTIVE_ENCLOS);
            AddInteractiveGfx(6772, InteractiveObjectIdEnum.INTERACTIVE_ENCLOS);
            AddInteractiveGfx(7557, InteractiveObjectIdEnum.INTERACTIVE_KALIPTUS);
            AddInteractiveGfx(7039, InteractiveObjectIdEnum.INTERACTIVE_ATELIER_DE_BRICOLAGE);
            AddInteractiveGfx(7041, InteractiveObjectIdEnum.INTERACTIVE_LEVIER);
            AddInteractiveGfx(7042, InteractiveObjectIdEnum.INTERACTIVE_LEVIER);
            AddInteractiveGfx(7043, InteractiveObjectIdEnum.INTERACTIVE_LEVIER);
            AddInteractiveGfx(7044, InteractiveObjectIdEnum.INTERACTIVE_LEVIER);
            AddInteractiveGfx(7045, InteractiveObjectIdEnum.INTERACTIVE_LEVIER);
            AddInteractiveGfx(1853, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1854, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1855, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1856, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1857, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1858, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1859, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1860, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1861, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1862, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(1845, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);
            AddInteractiveGfx(2319, InteractiveObjectIdEnum.INTERACTIVE_STATUE_DE_CLASSE);

            AddInteractiveGfx(4638, InteractiveObjectIdEnum.INTERACTIVE_PHOENIX);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fun"></param>
        private void AddInteractive(InteractiveObjectIdEnum id, Func<MapInstance, int, InteractiveObject> fun)
        {
            m_interactiveById.Add((int)id, fun);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gfxId"></param>
        /// <param name="interactiveId"></param>
        private void AddInteractiveGfx(int gfxId, InteractiveObjectIdEnum interactiveId)
        {
            m_interactiveByGfx.Add(gfxId, (int)interactiveId);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gfx"></param>
        /// <returns></returns>
        public bool Exists(int gfx)
        {
            return m_interactiveByGfx.ContainsKey(gfx) && m_interactiveById.ContainsKey(m_interactiveByGfx[gfx]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gfx"></param>
        /// <param name="map"></param>
        /// <param name="cellId"></param>
        /// <returns></returns>
        public InteractiveObject Generate(int gfx, MapInstance map, int cellId)
        {
            return m_interactiveById[m_interactiveByGfx[gfx]](map, cellId);
        }
    }
}
