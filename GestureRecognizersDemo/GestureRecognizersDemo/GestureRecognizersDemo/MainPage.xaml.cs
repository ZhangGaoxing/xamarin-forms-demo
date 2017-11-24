using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GestureRecognizersDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            // 设置触发点击数
            tapGestureRecognizer.NumberOfTapsRequired = 1;
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (s is Label)
                {
                    Device.OpenUri(new Uri("mailto:zhangyuexin121@live.cn"));
                }
                else if (s is Image)
                {
                    Device.OpenUri(new Uri("http://www.weibo.com/279639933"));
                }
            };

            Email.GestureRecognizers.Add(tapGestureRecognizer);
            Weibo.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Label label = sender as Label;

            string val = label.Text;
            switch (val)
            {
                case "0":
                    label.Text = "1";
                    label.TextColor = Color.FromHex("#2196F3");
                    break;
                case "1":
                    label.Text = "0";
                    label.TextColor = Color.Black;
                    break;
                default:
                    break;
            }
        }
    }
}
