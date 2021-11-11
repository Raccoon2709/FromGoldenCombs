using FromGoldenCombs.BlockEntities;
using System;
using System.Collections.Generic;
using System.Text;
using VFromGoldenCombs.Blocks.Langstroth;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace FromGoldenCombs.Blocks.Langstroth
{
    class LangstrothCore : BlockContainer
    {
        //Enable selectionbox interaction
        public override bool DoParticalSelection(IWorldAccessor world, BlockPos pos)
        {
            return true;
        }

        //TODO: OnBlockInteractStart should check to see if the block being interacted with is a LangstrothStack.
        //If it is, send the check to OnBlockInteractContinue.
        //If the target is a base or a super, and the player is holding a base, super, or brood box, convert to a LangstrothStack
        //If the target block is a brood box, and what the player is holding is a brood box, fail interaction.
        //Else, pass to OnBlockInteractContinue for that block.

        public override bool OnBlockInteractStart(IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel)
        {
            System.Diagnostics.Debug.WriteLine("Checkpoint Alpha-Start Reached");
            Block block = api.World.BlockAccessor.GetBlock(blockSel.Position);
            ItemSlot slot = byPlayer.InventoryManager.ActiveHotbarSlot;
            if (!slot.Empty &&
                     ((slot.Itemstack.Block is LangstrothSuper && block.Variant["open"] == "closed") 
                     || slot.Itemstack.Block is LangstrothBase))
            {
                ItemStack groundBlock = block.OnPickBlock(api.World, blockSel.Position);
                api.World.BlockAccessor.SetBlock(api.World.GetBlock(new AssetLocation("fromgoldencombs", "langstrothstack-two-" + block.LastCodePart())).BlockId, blockSel.Position);
                BELangstrothStack lStack = (BELangstrothStack)api.World.BlockAccessor.GetBlockEntity(blockSel.Position);
                System.Diagnostics.Debug.WriteLine("Checkpoint Beta-Start Reached");
                lStack.InitializePut(groundBlock, slot);
                return true;
            } else if (block is LangstrothBrood || block is LangstrothBase)
            {
                byPlayer.InventoryManager.TryGiveItemstack(block.OnPickBlock(api.World, blockSel.Position));
                api.World.BlockAccessor.SetBlock(0, blockSel.Position);
                return true;
            }

            return base.OnBlockInteractStart(world, byPlayer, blockSel);
        }

        public bool OnBlockInteractContinue(IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel)
        {
            return false;
        }
    }
}
