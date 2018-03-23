namespace ExtendUI.ScrollView
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// Dynamic Vertical Scroll View
    /// </summary>
    [AddComponentMenu("UI/Dynamic V Scroll View")]
    public class DynamicVScrollView : DynamicScrollView
    {

        protected override float contentAnchoredPosition { get { return -this._contentRect.anchoredPosition.y; } set { this._contentRect.anchoredPosition = new Vector2(this._contentRect.anchoredPosition.x, -value); } }
        protected override float contentSize { get { return this._contentRect.rect.height; } }
        protected override float viewportSize { get { return this._viewportRect.rect.height; } }
        protected override void Awake()
        {
            base.Awake();
            this._direction = Direction.Vertical;
            this._itemSize = this.itemPrototype.rect.height + intervalSize;
        }


        public void SetDate(IList collection)
        {
            this.totalItemCount = collection;
            this.OnInit();
        }


        #region [ Editor ]

#if UNITY_EDITOR

        [UnityEditor.MenuItem("GameObject/UI/Dynamic V Scroll View")]
        public static void CreateVertical() {

            var go = new GameObject( "Vertical Scroll View", typeof(RectTransform) );
            go.transform.SetParent( UnityEditor.Selection.activeTransform, false );
            go.AddComponent<DynamicVScrollView>();
        }

        protected override void Reset() {
            this._direction = Direction.Vertical;
            base.Reset();
        }
#endif

        #endregion [ Editor ]
    }
}
