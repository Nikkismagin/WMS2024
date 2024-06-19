using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS2024
{
    class Item
    {

        private string name; // Наименование
        private int articleId; // ID товара
        private int qty; // количество товара
        public static int NextArticleId = 0;



        public Item(string name, int GetQty) // конструктор товара (имя, ID из генератора, количество)
        {
            this.name = name;
            this.articleId = GetNextArticleId();
            this.qty = GetQty;
 
        }

        public int GetNextArticleId() // генератор ID
        {
            NextArticleId += 1;
            return NextArticleId;
        }

        public int GetArticleId // Метод получения ID
        {
            get => this.articleId;
        }

        public int GetQty // Метод количества товара
        {
            set => this.qty = value;
            get => this.qty;
        }
        public override string ToString()
        {
            return "Наименование: " + this.name + "; ID: " + this.GetArticleId + "; кол-во: " + this.qty;
        }


    }
}
