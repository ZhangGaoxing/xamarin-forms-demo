using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ShortcutDemo.Droid
{
    [Activity(Label = "ShortcutDemo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class ShortcutContainerActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           
            Intent intent = Intent;
            // 获取传进来的页面名称
            string pageName = intent.GetStringExtra("PageName");

            var app = new App();
            // 设置显示的页面
            switch (pageName)
            {
                case "Page1":
                    app.MainPage = new ShortcutDemo.Views.Page1();
                    break;
                case "Page2":
                    app.MainPage = new ShortcutDemo.Views.Page2();
                    break;
                default:
                    break;
            }

            LoadApplication(app);
        }
    }
}