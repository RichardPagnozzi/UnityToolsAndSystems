using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UTS
{
    public class ObjectGridGenerator : MonoBehaviour
    {
        #region Classes and Variables
        [System.Serializable]
        public class GridSettings
        {
            public string gridName;
            public int collumns, rows;
            public float originX, originZ;
            public float spacingX, spacingZ;
            public GameObject gridPrefab;
            public int getGridSsize() { return gridSize; }

            private int gridSize => collumns * rows;
        }

        [SerializeField]
        private GridSettings gridSettings;
        #endregion


        [ContextMenu("Generate Grid")]
        public void GenerateGrid()
        {
            // Create a Parent for the Grid Objects 
            GameObject gridParentObject = new GameObject();
            gridParentObject.transform.parent = this.transform;
            gridParentObject.gameObject.name = gridSettings.gridName;

            // Instantiate the grid Objects 
            for (int i = 0; i < gridSettings.getGridSsize(); i++)
            {
                GameObject go =
                Instantiate(
                    gridSettings.gridPrefab,

                    new Vector3
                    (gridSettings.originX + (gridSettings.spacingX * (i % gridSettings.collumns)),
                    0,
                    gridSettings.originZ + (gridSettings.spacingZ * (i / gridSettings.collumns))),

                    Quaternion.identity,
                    gridParentObject.transform);
            }
        }
    }
}
