using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamburgerMenuDemo.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HamburgerMenuDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
        // 向 MainPage 传递控件
        public ListView primaryListView { get { return PrimaryListView; } }
        public ListView secondaryListView { get { return SecondaryListView; } }

        public MasterPage()
        {
            InitializeComponent();

            // 设置不同平台的字体路径
            string fontFamily;
            switch (Device.RuntimePlatform)
            {
                case "Android":
                    fontFamily = "segmdl2.ttf#Segoe MDL2 Assets";
                    break;

                case "iOS":
                    fontFamily = "Segoe MDL2 Assets";
                    break;

                case "Windows":
                    fontFamily = "/Assets/segmdl2.ttf#Segoe MDL2 Assets";
                    break;

                case "WinPhone":
                    fontFamily = "/Assets/segmdl2.ttf#Segoe MDL2 Assets";
                    break;

                default:
                    fontFamily = "segmdl2.ttf#Segoe MDL2 Assets";
                    break;
            }

            // 列表项
            var primaryItems = new List<MasterPageItem>() {
                new MasterPageItem
                {
                    Title = "Page1",
                    FontFamily = fontFamily,
                    Icon = "\xE10F",
                    Color = Color.DeepSkyBlue,
                    Selected = true,
                    DestPage = typeof(Page1)
                },
                new MasterPageItem
                {
                    Title = "Page2",
                    FontFamily = fontFamily,
                    Icon = "\xE11F",
                    Color = Color.Black,
                    Selected = false,
                    DestPage = typeof(Page2)
                },
                new MasterPageItem
                {
                    Title = "Page3",
                    FontFamily = fontFamily,
                    Icon = "\xE12F",
                    Color = Color.Black,
                    Selected = false,
                    DestPage = typeof(Page2)
                }
            };

            var secondaryItems = new List<MasterPageItem>() {
                new MasterPageItem
                {
                    Title = "设置",
                    FontFamily = fontFamily,
                    Icon = "\xE713",
                    Color = Color.Black,
                    Selected = false,
                    DestPage = typeof(SettingPage)
                },
                new MasterPageItem
                {
                    Title = "关于",
                    FontFamily = fontFamily,
                    Icon = "\xE783",
                    Color = Color.Black,
                    Selected = false,
                    DestPage = typeof(AboutPage)
                }
            };

            // ListView 数据绑定
            PrimaryListView.ItemsSource = primaryItems;
            SecondaryListView.ItemsSource = secondaryItems;

            // 设置二级菜单高度
            SecondaryListView.HeightRequest = 48 * secondaryItems.Count;
        }
    }
}