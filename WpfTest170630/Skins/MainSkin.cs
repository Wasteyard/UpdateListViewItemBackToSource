using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfTest170630.Skins
{
    public partial class MainSkin
    {
        private void eventSetter_OnHandler(object sender, KeyEventArgs e)
        {
            var tb = e.OriginalSource as TextBox;
            if (tb == null || tb.Name != "ItemText" || tb.Text == (string) tb.DataContext) return;
            var lv = sender as ListView;
            if (lv == null) return;
            var index = lv.Items.IndexOf(tb.DataContext);
            if (lv.ItemsSource is IList<string> src) src[index] = tb.Text;
        }
    }
}