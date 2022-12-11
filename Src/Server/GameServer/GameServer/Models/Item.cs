using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillBridge.Message;

using Common;
using Common.Data;

using Network;
using GameServer.Managers;
using GameServer.Entities;
using GameServer.Services;

namespace GameServer.Models
{
    class Item
    {
        TCharacterItem dbItem;

        public int ItemId;

        public int Count;

        public Item(TCharacterItem item)
        {
            this.dbItem = item;

            this.ItemId = (short)item.ItemID;
            this.Count = (short)item.ItemCount;
        }
       
        public void Add(int count)
        {
            this.Count += count;
            dbItem.ItemCount = this.Count;
        }

        public void Remove(int count)
        {
            this.Count -= count;
            dbItem.ItemCount = this.Count;
        }

        public bool Use(int count = 1)
        {
            return false;
        }

        public override string ToString()
        {
            return string.Format("ID:{0},Count:{1}", this.ItemId, this.Count);
        }
    }
}
