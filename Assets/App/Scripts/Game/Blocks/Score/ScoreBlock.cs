﻿using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Blocks.Score.BlockHalf.HalvesProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Score
{
    public class ScoreBlock : Block
    {
        [SerializeField] private HalvesProvider halvesProvider;
        
        [SerializeField] private Shared.ParticleProvider.ParticleProvider particleProvider;
        
        public override void Init()
        {
            particleProvider.Init();

            OnChop += (x) =>
            {
                halvesProvider.CreateHalves(x);
                particleProvider.PlayParticles();
            }; 
        }
    }
}