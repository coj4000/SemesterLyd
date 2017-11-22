using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemesterLyd
{
    public class Lyd
    {
        

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int lydmal;

        public int Lydmal
        {
            get { return lydmal; }
            set { lydmal = value; }
        }

        public Lyd()
        {
            
        }

        public Lyd(int id, int lydmal)
        {
            this.id = id;
            this.lydmal = lydmal;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Lydmal)}: {Lydmal}";
        }
    }
}