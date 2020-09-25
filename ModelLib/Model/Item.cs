using System;

namespace ModelLib.Model
{
    public class Item
    {
        public Item()
        {

        }

        public Item(int id, string name, /*QualityOfItem*/string quality, double quantity)
        {
            Id = id;
            Name = name;
            Quality = quality;
            Quantity = quantity;
        }

        //public enum QualityOfItem
        //{
        //    Thrash,
        //    Ehh,
        //    Meh,
        //    Deece,
        //    Good,
        //    Great,
        //    Awesome
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public string Quality { get; set; }
        public double Quantity { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Quality)}: {Quality}, {nameof(Quantity)}: {Quantity}";
        }
    }
}
