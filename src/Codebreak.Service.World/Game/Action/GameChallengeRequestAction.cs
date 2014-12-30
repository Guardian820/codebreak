﻿using Codebreak.Service.World.Game.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codebreak.Service.World.Manager;
using Codebreak.Service.World.Network;

namespace Codebreak.Service.World.Game.Action
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class GameChallengeRequestAction : GameActionBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override bool CanAbort
        {
            get 
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CharacterEntity Defender
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        public GameChallengeRequestAction(CharacterEntity attacker, CharacterEntity defender)
            : base(GameActionTypeEnum.CHALLENGE_REQUEST, attacker)
        {
            Defender = defender;

            attacker.Map.Dispatch(WorldMessage.GAME_ACTION(GameActionTypeEnum.CHALLENGE_REQUEST, attacker.Id, SerializeAs_GameAction()));            
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Stop(params object[] args)        
        {
            IsFinished = true;
            if (int.Parse(args[0].ToString()) == Entity.Id)
                Defender.StopAction(GameActionTypeEnum.CHALLENGE_REQUEST);
            else
                Entity.StopAction(GameActionTypeEnum.CHALLENGE_REQUEST);

            var message = WorldMessage.GAME_ACTION(GameActionTypeEnum.CHALLENGE_ACCEPT, Entity.Id, Defender.Id.ToString());
            Entity.Dispatch(message);
            Defender.Dispatch(message);

            Entity.Map.FightManager.StartChallenge((CharacterEntity)Entity, Defender);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public override void Abort(params object[] args)
        {
            IsFinished = true;
            if (int.Parse(args[0].ToString()) == Entity.Id)
                Defender.AbortAction(GameActionTypeEnum.CHALLENGE_REQUEST);
            else
                Entity.AbortAction(GameActionTypeEnum.CHALLENGE_REQUEST);
            
            var message = WorldMessage.GAME_ACTION(GameActionTypeEnum.CHALLENGE_DECLINE, Entity.Id, Defender.Id.ToString());
            Entity.Dispatch(message);
            Defender.Dispatch(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string SerializeAs_GameAction()
        {
            return Defender.Id.ToString();
        }
    }
}
