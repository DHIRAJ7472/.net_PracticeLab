using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
     public enum Relation
    {
        FATHER,
        MOTHER,
        BROTHER,
        SISTER,
        COUSIN,
        UNCLE,
        AUNT,
        SON,
        DAUTER,
        FREIND

    }
    public class Guest
    {


        public int Id { get; set; }
        public string Name { get; set; }

        public Relation Relationship { get; set; }

        public string ContactNumber { get; set; }


        public Guest() { }

    }
}
