using FromGoldenCombs.Blocks.Langstroth;
using System;
using System.Collections.Generic;
using System.Text;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace VFromGoldenCombs.Blocks.Langstroth
{
    class LangstrothBase : LangstrothCore
    {
        public override ItemStack OnPickBlock(IWorldAccessor world, BlockPos pos)
        {
            ItemStack stack = base.OnPickBlock(world, pos);

            return stack;
        }
    }
}
