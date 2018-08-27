using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Biblioteek.Types
{
    public enum Genres
    {
        Fiksie,
        Nie_fiksie
    }

    public class Genre : NotifyPropertyChangedBase, IVlaue<Genres>
    {
        public Genre()
            :this(default)
        { }

        public Genre(Genres genre)
        {
            this.NameValues = new List<GenreNameValue>();
            this.Value = genre;            

            foreach (var g in Enum.GetValues(typeof(Genres)).Cast<Genres>())
            {
                var valuePare = new GenreNameValue()
                {
                    Genre = g,
                    Name = g.ToString().Replace('_', ' '),
                    Set = g == Value
                };

                valuePare.GenreSet += GenreSet;
                this.NameValues.Add(valuePare);
            }
        }

        public void GenreSet(object sender, Genres genres)
        {
            if (!updatingValue)
                Value = genres;
        }

        public List<GenreNameValue> NameValues { get; }

        private Genres value;

        private bool updatingValue;

        public Genres Value
        {
            get => this.value;
            set
            {
                this.updatingValue = true;
                this.value = value;
                this.NameValues
                    .Where(nv => nv.Genre == this.value )
                    .ToList()
                    .ForEach(nv => nv.Set = true);
                this.updatingValue = false;
                this.NotifyPropertyChanged();
            }
        }

        public void Reset() => this.Value = default;

    }

    public class GenreNameValue : NotifyPropertyChangedBase
    {
        private bool set;

        public event EventHandler<Genres> GenreSet;

        public string Name { get; set; }

        public bool Set
        {
            get { return set; }
            set
            {
                set = value;
                NotifyPropertyChanged();
                if (value)
                {
                    GenreSet?.Invoke(this, Genre);
                }
            }
        }

        public Genres Genre { get; set; }
    }
}