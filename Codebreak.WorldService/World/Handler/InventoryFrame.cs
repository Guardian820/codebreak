﻿using Codebreak.Framework.Network;
using Codebreak.WorldService.World.Database.Structure;
using Codebreak.WorldService.World.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.WorldService.World.Handler
{
    public sealed class InventoryFrame : FrameBase<InventoryFrame, EntityBase, string>
    {
        public override Action<EntityBase, string> GetHandler(string message)
        {
            if (message.Length < 2)
                return null;

            switch(message[0])
            {
                case 'O':
                    switch (message[1])
                    {
                        case 'M':
                            return ObjectMove;

                        case 'U':
                            return ObjectUse;

                        case 'd':
                            return ObjectDelete;

                        default:
                            return null;
                    }

                default:
                    return null;
            }
        }

        private void ObjectMove(EntityBase entity, string message)
        {            
            var data = message.Substring(2).Split('|');

            long itemId = -1;
            if(!long.TryParse(data[0], out itemId))
            {
                entity.Dispatch(WorldMessage.OBJECT_MOVE_ERROR());
                return;
            }

            int slotId = -1;
            if(!int.TryParse(data[1], out slotId))
            {
                entity.Dispatch(WorldMessage.OBJECT_MOVE_ERROR());
                return;
            }

            if(!Enum.IsDefined(typeof(ItemSlotEnum), slotId))
            {
                entity.Dispatch(WorldMessage.OBJECT_MOVE_ERROR());
                return;
            }

            entity.AddMessage(() =>
                {
                    var item = entity.Inventory.Items.Find(x => x.Id == itemId);
                    if(item == null)
                    {
                        entity.Dispatch(WorldMessage.OBJECT_MOVE_ERROR());
                        return;
                    }

                    entity.Inventory.MoveItem(item, (ItemSlotEnum)slotId);
                });
        }

        private void ObjectUse(EntityBase entity, string message)
        {

        }

        private void ObjectDelete(EntityBase entity, string message)
        {
           
        }
    }
}
