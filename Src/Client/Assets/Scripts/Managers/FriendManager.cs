using Common.Data;
using Models;
using SkillBridge.Message;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    class FriendManager : Singleton<FriendManager>
    {
        public List<NFriendInfo> allFriends;

        public void Init(List<NFriendInfo> friends)
        {
            this.allFriends = friends;
        }
    }
}
