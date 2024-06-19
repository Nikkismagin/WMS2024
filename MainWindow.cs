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

namespace WMS2024
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Items_ListBox.ItemsSource = ItemsStock;
        }

        public int itemChoiseIndex;
        private Item choiseItem;
        List<Item> ItemsStock = new List<Item>();

        private void ButtonItemIncome_Click(object sender, RoutedEventArgs e) // Добавление нового товара в список. 
        {
            if (TextBox_Item_Name.Text == "")
            {
                MessageBox.Show("Введите название товара"); // Отсев пуcтой строки Item_Name
            }
            else if (TextBox_Item_Qty.Text == "")
            {
                MessageBox.Show("Введите количество"); // Отсев пустой строки Item_Qty
            }
            else if (Convert.ToInt32(TextBox_Item_Qty.Text) <= 0)
            {
                MessageBox.Show("Количество должно быть больше нуля");
            }
            else
            {
                ItemsStock.Add(new Item(TextBox_Item_Name.Text, Convert.ToInt32(TextBox_Item_Qty.Text))); // Добавление товара в список
                Items_ListBox.Items.Refresh();
                TextBox_Item_Name.Clear();
                TextBox_Item_Qty.Clear();
            }
        }

        
        private void Button_Item_Outcome_Click(object sender, RoutedEventArgs e) // Выдача товара
        {
            if (Items_ListBox.SelectedIndex != -1)
            {
                choiseItem = ItemsStock[Items_ListBox.SelectedIndex];
                itemChoiseIndex = choiseItem.GetArticleId;
                ChangeItemQtyByIndex();
                Items_ListBox.Items.Refresh();
                TextBox_Item_Qty.Clear();
            }
            else
            {
                MessageBox.Show("Выберите товар из списка");
            }

        }

        private void Button_Clear_All_Click(object sender, RoutedEventArgs e) // Очистка полей ввода
        {
            TextBox_Item_Qty.Clear();
            TextBox_Item_Name.Clear();
        }

        public void ChangeItemQtyByIndex() // Изменение количества товара по индексу
        {
            foreach (var Item in ItemsStock)
            {
                if (Item.GetArticleId == itemChoiseIndex)
                {
                    if (Item.GetQty - Convert.ToInt32(TextBox_Item_Qty.Text) >= 0)
                    {
                        Item.GetQty -= Convert.ToInt32(TextBox_Item_Qty.Text);
                    }
                    else
                    {
                        MessageBox.Show("Можно выдать только " + Item.GetQty);
                        Item.GetQty = 0;
                    }
                }
            }
        }

        /*
        private void TextBox_Item_Qty_PreviewTextInput(object sender, TextCompositionEventArgs e) // проверка ввода чисел, которая не работает
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
         */

    }
}

