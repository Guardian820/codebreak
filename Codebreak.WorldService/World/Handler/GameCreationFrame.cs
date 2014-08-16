﻿using Codebreak.Framework.Network;
using Codebreak.WorldService.World.Action;
using Codebreak.WorldService.World.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.WorldService.World.Handler
{
    public sealed class GameCreationFrame : FrameBase<GameCreationFrame, EntityBase, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public override Action<EntityBase, string> GetHandler(string message)
        {
            if(message.StartsWith("GC"))
                return GameCreation;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void GameCreation(EntityBase entity, string message)
        {
            entity.FrameManager.RemoveFrame(GameCreationFrame.Instance);
            entity.FrameManager.AddFrame(GameInformationFrame.Instance);

            var map = entity.Map;
            entity.Dispatch(WorldMessage.GAME_CREATION_SUCCESS());
            entity.Dispatch(WorldMessage.GAME_DATA_MAP(map.Id, map.CreateTime, map.DataKey));
            entity.Dispatch(WorldMessage.ACCOUNT_STATS((CharacterEntity)entity));
        }
    }
}
