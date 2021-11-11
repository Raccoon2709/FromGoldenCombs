﻿using FromGoldenCombs.BlockEntities;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace FromGoldenCombs.Blocks.Langstroth
{
    class LangstrothStack : LangstrothCore
    {
        public override void OnLoaded(ICoreAPI api)
        {
            base.OnLoaded(api);
            // Todo: Add interaction help
        }

        public override bool OnBlockInteractStart(IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel)
        {

            BELangstrothStack belangstrothstack = world.BlockAccessor.GetBlockEntity(blockSel.Position) as BELangstrothStack;
            if (belangstrothstack != null) return belangstrothstack.OnInteract(byPlayer);
            
            return base.OnBlockInteractContinue(world, byPlayer, blockSel);
        }

    }
}
