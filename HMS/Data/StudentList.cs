using HMS.Models;
using System.Collections.Generic;

namespace HMS.Data
{
    public class Parentlist
    {
        public IList<Parents> Parent { get; set; }
        public Parentlist()
        {
            Parent = new List<Parents>();
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
            Parent.Add(new Parents
            {
                Name = "Mr. Navin Sehgal",
                Parentof = "Sanu Sehgal",
                contactno = "9988776655"
            });
        }
    }
}
