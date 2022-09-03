using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEWAtypen.Models
{
    internal class JEWATypenModel : INotifyPropertyChanged
    {
        private int _seconden;
        private int _minuten;

        public event PropertyChangedEventHandler PropertyChanged;
        public int Seconden
        {
            get => _seconden;
            set
            {
                _seconden = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Seconden)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tijd)));
            }
        }
        public int Minuten
        {
            get => _minuten; set
            {
                _minuten = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Minuten)));
            }
        }
        public string Tijd
        {
            get
            {
                //TODO: De tijd teruggeven in minuten:seconden bv 01:05
                return "";
            }
        }
        public string OrigineleTekst { get; set; }
        public string GetypteTekst { get; set; }

        public void SecondeToevoegen()
        {
            //TODO: een seconde toevoegen; als we aan 60seconden zitten, een minuut toevoegen
        }
    }
}
