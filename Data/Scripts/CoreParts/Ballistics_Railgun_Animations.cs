﻿using System.Collections.Generic;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.AnimationDef;
using static Scripts.Structure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove;

namespace Scripts
{ // Don't edit above this line
    partial class Parts
    {
        private AnimationDef AryxRailgunAnims => new AnimationDef
        {

            EventParticles = new Dictionary<PartAnimationSetDef.EventTriggers, EventParticle[]>
            {
                [PreFire] = new[]{
                       new EventParticle
                       {
                           EmptyNames = Names("muzzle_projectile_1"),
                           MuzzleNames = Names("muzzle_projectile_1"),
                           StartDelay = 0, //ticks 60 = 1 second
                           LoopDelay = 0, //ticks 60 = 1 second
                           ForceStop = false,
                           Particle = new ParticleDef
                           {
                               Name = "Aryx_Railgun_windup_effect",
                               Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                               Extras = new ParticleOptionDef
                               {
                                   Loop = true,
                                   Restart = false,
                                   MaxDistance = 1000, //meters
                                   MaxDuration = 120, //ticks 60 = 1 second
                                   Scale = 1,
                               }
                           }
                       },
                   },
            },

        };
    }
}