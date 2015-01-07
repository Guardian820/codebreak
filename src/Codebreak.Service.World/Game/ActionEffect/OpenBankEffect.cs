﻿using Codebreak.Service.World.Game.Entity;
using Codebreak.Service.World.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.Service.World.Game.ActionEffect
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class OpenBankEffect : ActionEffectBase<OpenBankEffect>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="item"></param>
        /// <param name="effect"></param>
        /// <param name="targetId"></param>
        /// <param name="targetCell"></param>
        /// <returns></returns>
        public override bool ProcessItem(Entity.EntityBase entity, Database.Structure.InventoryItemDAO item, Stats.GenericStats.GenericEffect effect, long targetId, int targetCell)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override bool Process(EntityBase entity, Dictionary<string, string> parameters)
        {
            var character = (CharacterEntity)entity;
            if(!character.CanGameAction(Action.GameActionTypeEnum.EXCHANGE))
            {
                character.Dispatch(WorldMessage.INFORMATION_MESSAGE(InformationTypeEnum.ERROR, InformationEnum.ERROR_YOU_ARE_AWAY));
                return false;
            }

            var taxe = character.Bank.Items.GroupBy(item => item.TemplateId).Count();
            if(character.Inventory.Kamas < taxe)
            {
                character.Dispatch(WorldMessage.INFORMATION_MESSAGE(InformationTypeEnum.ERROR, InformationEnum.ERROR_NOT_ENOUGH_KAMAS, taxe));
                return false;
            }

            character.Inventory.SubKamas(taxe);
            character.Dispatch(WorldMessage.INFORMATION_MESSAGE(InformationTypeEnum.INFO, InformationEnum.INFO_KAMAS_LOST, taxe));
            character.ExchangeStorage(character.Bank);

            return true;
        }
    }
}
