using BusinessLayer.Interfaces;
using System.Drawing;

namespace BusinessLayer.Models
{
    public class Symbol : ISymbol
    {
        private int id;

        private string name;

        private Image image;

        public int Id { get => id; set => id = value; }

        public string Name
        {
            get => name;
        }

        public Image Image { get => image; set => image = value; }

        public Symbol(string name, Image image)
        {
            this.name = name;

            this.image = image;
        }
    }
}
