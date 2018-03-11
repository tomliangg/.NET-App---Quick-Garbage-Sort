using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Quick_Garbage_Sort
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //Add array from garbage sort data base

    public partial class MainWindow : Window
    {
        //events and functions here
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_green_Click(object sender, RoutedEventArgs e)
        {
            
            var window = new WindowGreen { Owner = this };
            window.Show();
        }

        private void button_blue_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowBlue { Owner = this };
            window.Show();
        }

        private void button_black_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowBlack { Owner = this };
            window.Show();
        }

        private void button_red_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowRed { Owner = this };
            window.Show();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var Searchitem = SearchBox.Text;
            SearchBox.Text = "Search";
            bool found = false;
            string current_path = Environment.CurrentDirectory; //get the directory of the executable
            string exe_path = current_path;
            string root_path = System.IO.Path.GetFullPath(System.IO.Path.Combine(current_path, @"..\..\"));
            //when test the app in Visual studio, use root_path; when publish the app, use exe_path
            String[] OrganicsList = System.IO.File.ReadAllLines(exe_path + "/Resources/Organic.txt");
            String[] RecycleList = System.IO.File.ReadAllLines(exe_path + "/Resources/Recycle.txt");
            String[] GarbageList = System.IO.File.ReadAllLines(exe_path + "/Resources/Garbage.txt");

            //Perform the searching here
            foreach (var Listitem in OrganicsList)
            {
                if (Searchitem == Listitem)
                {
                    MessageBox.Show("Organics");
                    found = true;
                    break;
                } 
            }

            if (!found)
            {
                foreach (var Listitem in RecycleList)
                {
                    if (Searchitem == Listitem)
                    {
                        MessageBox.Show("Recycle");
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                foreach (var Listitem in GarbageList)
                {
                    if (Searchitem == Listitem)
                    {
                        MessageBox.Show("Garbage");
                        found = true;
                        break;
                    }
                }
            }
            
            if (!found)
            {
                MessageBox.Show("Item is not found");
            }
            Keyboard.ClearFocus();

        }

        private void SearchBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchBox.Text == "Search" || SearchBox.Text.Contains("Search") )
            {
                SearchBox.Text = "";
            }
        }

        private void SearchBox_MouseEnter(object sender, MouseEventArgs e)
        {
            SearchBox.ToolTip = "Enter item to be sorted";
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                SearchBox.Text = "Search";
            }
            Keyboard.ClearFocus();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if(etr == "Return")
            {
                SearchButton_Click(sender, e);
            }

        }

    }
}
