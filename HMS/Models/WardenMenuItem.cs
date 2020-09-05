using System;
using System.ComponentModel;
using System.Drawing;

namespace HMS.Models
{
    public class WardenMenuItem : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public Color ItemColor { get; set; }
        public bool Selected { get; set; }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public WardenMenuItem()
        {

        }
    }
}
