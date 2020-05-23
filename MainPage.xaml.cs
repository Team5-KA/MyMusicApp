using MyMusicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyMusicApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> Musics;
        private List<MenuItem> MenuItems;

        public MainPage()
        {
            this.InitializeComponent();
            Musics = new ObservableCollection<Music>();
            MusicManager.GetAllMusics(Musics);

            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/Instrumental.png", Category = MusicCategory.Instrumental });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/SleepMusic.png", Category = MusicCategory.SleepMusic });

           // MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/Instrumental.png", Category = MusicCategory.Instrumental });
            //MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/SleepMusic.png", Category = MusicCategory.SleepMusic });

            BackButton.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CategoryTextBlock.Text = menuItem.Category.ToString();
            MusicManager.GetMusicsByCategory(Musics, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;

        }

        private void MusicGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Music)e.ClickedItem;
            MyMediaElement.Source = new Uri(BaseUri, sound.AudioFile);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MusicManager.GetAllMusics(Musics);
            CategoryTextBlock.Text = "Music Album";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }
    }
}
