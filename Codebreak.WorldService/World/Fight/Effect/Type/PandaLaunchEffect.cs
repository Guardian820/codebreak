﻿using Codebreak.WorldService.World.Map;
using Codebreak.WorldService.World.Spell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.WorldService.World.Fight.Effect.Type
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PandaLaunchEffect : EffectBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CastInfos"></param>
        /// <returns></returns>
        public override FightActionResultEnum ApplyEffect(CastInfos CastInfos)
        {
            var infos = CastInfos.Caster.StateManager.FindState(FighterStateEnum.STATE_CARRIER);

            if (infos != null)
            {
                var target = infos.Target;

                if (target.StateManager.HasState(FighterStateEnum.STATE_CARRIED))
                {
                    var cell = target.Fight.GetCell(CastInfos.CellId);
                    if (cell.CanWalk)
                    {
                        var sleepTime = 1 + (200 * Pathfinding.GoalDistance(target.Fight.Map, target.Cell.Id, CastInfos.CellId));

                        target.Fight.Dispatch(WorldMessage.GAME_ACTION(EffectEnum.PandaLaunch, CastInfos.Caster.Id, CastInfos.CellId.ToString()));

                        target.Fight.SetSubAction(() =>
                        {
                            return target.SetCell(cell);
                        }, sleepTime);
                    }
                }
            }

            return FightActionResultEnum.RESULT_NOTHING;
        }
    }
}
