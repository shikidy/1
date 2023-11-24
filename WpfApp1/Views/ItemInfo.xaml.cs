using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using WpfApp1.Utils;


namespace WpfApp1.Views
{
    /// <summary>
    /// Логика взаимодействия для ItemInfo.xaml
    /// </summary>
    public partial class ItemInfo : Window
    {
        private int _id = 0;
        public ItemInfo()
        {
            InitializeComponent();
            add_item_info();
        }

        private void add_item_info()
        {
            if (!DataHolder.IfEditItem)
            {
                return;
            }
            this._id = DataHolder.ItemId;
            var ItemInfo = DBworker.get_product_by_id(DataHolder.ItemId);

            PRname.Text = ItemInfo.Name;
            PRunit.Text = ItemInfo.UnitMeasurement.ToString();
            PRprice.Text = ItemInfo.Cost.ToString();
            PRmaxdisc.Text = ItemInfo.MaxDiscount.ToString();
            PRmanufacter.Text = ItemInfo.Manufacturer.ToString();
            PRsupplier.Text = ItemInfo.Supplier.ToString();
            PRcategory.Text = ItemInfo.Category.ToString();
            PRdiscamount.Text = ItemInfo.DiscountAmount.ToString();
            PRquality.Text = ItemInfo.QuantityInStock.ToString();
            PRdescription.Text = ItemInfo.Description.ToString();
            PRphoto.Text = ItemInfo.Photo.ToString();
            PRarticle.Text = ItemInfo.ArticleNumber;

        }

        private void save(object sender, RoutedEventArgs e)
        {
            try
            {
                var obj = this.generate_object();
                if (obj == null) { return; }
                DBworker.update_item(obj);
                MessageBox.Show("Сохранено");
                this.Close();

            }
            catch
            {
                MessageBox.Show("При сохранении произошла ошибка. Проверьте вводимые данные");
            }
         
        }

        private Database.Product generate_object()
        {
            var ItemInfo = new Database.Product();

            ItemInfo.Name = PRname.Text;
            ItemInfo.UnitMeasurement = PRunit.Text;

            var cost = Decimal.Parse(PRprice.Text);
            ItemInfo.Cost = cost;



            var max_discount = byte.Parse(PRmaxdisc.Text);


                ItemInfo.MaxDiscount = max_discount;
            

            ItemInfo.Manufacturer = PRmanufacter.Text;
            ItemInfo.Supplier = PRsupplier.Text;
            ItemInfo.Category = PRcategory.Text;
            ItemInfo.DiscountAmount = byte.Parse(PRdiscamount.Text);
            ItemInfo.QuantityInStock = int.Parse(PRquality.Text);
            ItemInfo.Description = PRdescription.Text;
            ItemInfo.Photo = PRphoto.Text;
            ItemInfo.ArticleNumber = PRarticle.Text;

            if (this._id  != 0) 
            {
                ItemInfo.id = this._id;
            }

            return ItemInfo;

        }
    }
}
