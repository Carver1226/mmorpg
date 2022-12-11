using Models;
using UnityEngine;

namespace Managers
{
    class MiniMapManager : Singleton<MiniMapManager>
    {
        public UIMiniMap miniMap; 
        private Collider miniMapBoundingBox;
        public Collider MiniMapBoundingBox
        {
            get { return miniMapBoundingBox; }
        }
        public Transform PlayerTransform
        {
            get
            {
                if (User.Instance.CurrentCharacterObject == null)
                    return null;
                return User.Instance.CurrentCharacterObject.transform;
            }
        }
        public Sprite LoadCurrentMiniMap()
        {
            return Resloader.Load<Sprite>("UI/Minimap/" + User.Instance.CurrentMapData.MiniMap);
        }

        public void UpdateMiniMap(Collider miniMapBoundingBox)
        {
            this.miniMapBoundingBox = miniMapBoundingBox;
            if (this.miniMap != null)
                this.miniMap.UpdateMap();
        }
    }
}
