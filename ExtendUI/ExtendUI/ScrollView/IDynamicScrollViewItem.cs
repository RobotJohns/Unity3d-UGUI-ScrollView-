using System;
using System.Collections;

namespace ExtendUI.ScrollView
{
    /// <summary>
    /// DynamicScrollView Item interface
    /// </summary>
    public interface IDynamicScrollViewItem
    {
        void onUpdateItem(int index, IList Date);
    }
}
