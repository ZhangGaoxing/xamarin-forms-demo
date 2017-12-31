using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics.Drawables;

namespace ShortcutDemo.Droid
{
    [Activity(Label = "ShortcutDemo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetShortcut();

            StartActivity(typeof(FormsActivity));
        }

        private void SetShortcut()
        {
            List<ShortcutInfo> shortcutInfoList = new List<ShortcutInfo>();

            Intent page1 = new Intent();
            page1.SetClass(this, typeof(ShortcutContainerActivity));
            page1.SetAction(Intent.ActionMain);
            page1.PutExtra("PageName", "Page1");
            ShortcutInfo page1Info = new ShortcutInfo.Builder(this, "Page1")
                .SetRank(0)
                .SetIcon(Icon.CreateWithResource(this, Resource.Drawable.Page1))
                .SetShortLabel("Page1")
                .SetLongLabel("Page1")
                .SetIntent(page1)
                .Build();
            shortcutInfoList.Add(page1Info);

            Intent page2 = new Intent();
            page2.SetClass(this, typeof(ShortcutContainerActivity));
            page2.SetAction(Intent.ActionMain);
            page2.PutExtra("PageName", "Page2");
            ShortcutInfo page2Info = new ShortcutInfo.Builder(this, "Page2")
                .SetRank(1)
                .SetIcon(Icon.CreateWithResource(this, Resource.Drawable.Page2))
                .SetShortLabel("Page2")
                .SetLongLabel("Page2")
                .SetIntent(page2)
                .Build();
            shortcutInfoList.Add(page2Info);

            ShortcutManager shortcutManager = (ShortcutManager)GetSystemService(Context.ShortcutService);
            shortcutManager.SetDynamicShortcuts(shortcutInfoList);
        }
    }
}

