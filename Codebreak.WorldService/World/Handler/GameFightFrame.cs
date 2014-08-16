﻿using Codebreak.Framework.Network;
using Codebreak.WorldService.World.Entity;
using Codebreak.WorldService.World.Fight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.WorldService.World.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GameFightFrame : FrameBase<GameFightFrame, EntityBase, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public override Action<EntityBase, string> GetHandler(string message)
        {
            if (message.Length < 2)
                return null;

            switch (message[0])
            {
                case 'G':
                    switch (message[1])
                    {
                        case 't':
                            return FightTurnPass;

                        case 'T':
                            return FightTurnReady;

                        case 'Q':
                            return FightQuit;
                    }
                    break;
                case 'f':
                    switch (message[1])
                    {
                        case 'S':
                            return FightOption;
                    }
                    break;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="message"></param>
        private void FightOption(EntityBase entity, string message)
        {
            var fighter = (FighterBase)entity;

            if (!fighter.IsLeader)
            {
                Logger.Debug("GameFight::Option non leader player wants to lock : " + entity.Name);
                fighter.Dispatch(WorldMessage.BASIC_NO_OPERATION());
                return;
            }

            fighter.Team.OptionLock(FightOptionTypeEnum.TYPE_SPECTATOR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="message"></param>
        private void FightTurnReady(EntityBase entity, string message)
        {
            var fighter = (FighterBase)entity;

            if (fighter.Spectating)
            {
                Logger.Debug("GameFight::TurnReady spectator player cant be ready : " + entity.Name);            
                fighter.Dispatch(WorldMessage.BASIC_NO_OPERATION());                
                return;
            }

            fighter.TurnReady = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="message"></param>
        private void FightTurnPass(EntityBase entity, string message)
        {
            var fighter = (FighterBase)entity;

            if (fighter.Spectating)
            {
                Logger.Debug("GameFight::TurnPass spectator player cant pass turn : " + entity.Name);
                fighter.Dispatch(WorldMessage.BASIC_NO_OPERATION());  
                return;
            }
                
            if(fighter.Fight.CurrentFighter != fighter)
            {
                Logger.Debug("GameFight::TurnPass not the turn of this player : " + entity.Name);
                fighter.Dispatch(WorldMessage.BASIC_NO_OPERATION());  
                return;
            }

            fighter.TurnPass = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="message"></param>
        private void FightQuit(EntityBase entity, string message)
        {
            var fighter = (FighterBase)entity;

            fighter.Fight.AddMessage(() => fighter.Fight.FightQuit(fighter));
        }        
    }
}
