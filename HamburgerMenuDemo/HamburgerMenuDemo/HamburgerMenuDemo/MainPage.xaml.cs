using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HamburgerMenuDemo
{
	public partial class MainPage : MasterDetailPage
	{
        public MainPage()
        {
            InitializeComponent();

            // ListView 点击事件
            masterPage.primaryListView.ItemSelected += MasterPageItemSelected;
            masterPage.secondaryListView.ItemSelected += MasterPageItemSelected;

            // 设置 Windows 平台的“大纲”显示模式为折叠
            if (Device.RuntimePlatform == Device.Windows)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }

        private void MasterPageItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;

            if (item != null)
            {
                // 遍历 ListView 数据源，将选中项矩形显示，字体颜色设置成未选中
                foreach (MasterPageItem mpi in masterPage.primaryListView.ItemsSource)
                {
                    mpi.Selected = false;
                    mpi.Color = Color.Black;
                }
                foreach (MasterPageItem mpi in masterPage.secondaryListView.ItemsSource)
                {
                    mpi.Selected = false;
                    mpi.Color = Color.Black;
                }

                // 设置选中项
                item.Selected = true;
                item.Color = Color.DeepSkyBlue;

                // 跳转
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.DestPage));

                // 取消 ListView 默认选中样式
                masterPage.primaryListView.SelectedItem = null;
                masterPage.secondaryListView.SelectedItem = null;

                // 关闭“大纲”
                IsPresented = false;
            }
        }
    }
}
