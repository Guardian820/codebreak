﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.WorldService.World.Fight.Effect.Type
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class DamageDodgeEffect : EffectBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="castInfos"></param>
        /// <returns></returns>
        public override FightActionResultEnum ApplyEffect(CastInfos castInfos)
        {
            if (castInfos.Target == null)
                return FightActionResultEnum.RESULT_NOTHING;

            castInfos.Target.BuffManager.AddBuff(new DamageDodgeBuff(castInfos, castInfos.Target));

            return FightActionResultEnum.RESULT_NOTHING;
        }
    }
}
