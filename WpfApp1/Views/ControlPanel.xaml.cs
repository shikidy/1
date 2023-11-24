using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using WpfApp1.Database;
using WpfApp1.Utils;

namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {
        public ControlPanel()
        {
            InitializeComponent();
            // default
            //DataHolder.UserID = 1;
            update_categs();
            update_items();
            hide_elements();
        }

        private void hide_elements()
        {
            var role_id = DBworker.get_role_id_by_user(DataHolder.UserID);

            if (role_id > 1)
            {
                edit_button.Visibility = Visibility.Hidden;
            }
            if (role_id > 2)
            {
                add_button.Visibility = Visibility.Hidden;
            }
        }

        private void update_items()
        {

            #region  PriceOrderSettings
            int price_order = 0;
            // 0 = off
            // 1 = desc
            // 2 = def 
            ComboBoxItem typeItem = (ComboBoxItem)OrderByPriceCombo.SelectedItem;
            string value = "Выкл";
            if (typeItem != null && typeItem.Content != null ) { 
                value = typeItem.Content.ToString();
            }
  
            switch (value)
            {
                case "По возрастанию":
                    price_order = 2;
                    break;
                case "По убыванию":
                    price_order = 1;
                    break;

            }
            #endregion

            #region SelectByCateg

            string categvalue = "Выкл";
            try
            {
                categvalue = (string)SelectByCategs.SelectedItem;

            }
            catch
            {
            }
            #endregion

            #region TitleSettins
            string titledata = SelectByName.Text;
            #endregion
            var items = DBworker.Select_Items(price_order, categvalue, titledata);
            DataTableOf.ItemsSource = items;
        }

        private void proxy_update_items(object sender, RoutedEventArgs e)
        {
            update_items();
        }

        private void update_categs()
        {
            var categs = DBworker.get_categs_name();
            foreach (var categ in categs)
            {
                SelectByCategs.Items.Add(categ);
            }
            
        }

        private void delete_object(object sender, RoutedEventArgs e)
        {
            return;
            Database.Product data = (Database.Product)DataTableOf.SelectedItem;
            DBworker.delete_by_article(data.ArticleNumber);
            update_items();

        }

        private void update_object(object sender, RoutedEventArgs e)
        {
            var selected_item = DataTableOf.SelectedItem;
            if (selected_item == null)
            {
                MessageBox.Show("Выберите объект в таблице, который хотите отредактировать.");
                return;
            }
            var product_object = (Database.Product)selected_item;
            DataHolder.IfEditItem = true;
            DataHolder.ItemId = product_object.id;

            var win = new Views.ItemInfo();
            win.Show();
            DataHolder.IfEditItem = false;
            DataHolder.ItemId = -1;
        }

        private void add_object(object sender, RoutedEventArgs e)
        {
            DataHolder.IfEditItem = false;
            var win = new Views.ItemInfo();
            win.Show();
        }

    }
}
