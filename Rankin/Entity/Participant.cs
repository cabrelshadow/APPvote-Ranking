using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rankin.Entity
{
    public  class Participant
    {
       public  string Nom { get; set; }
        public string Prenom { get; set; }
        public int age { get; set; }    
        public  string photo { get; set; }  
        public string slogan { get; set; }
        public int nobreVois { get; set; }

        public Participant(string nom, string prenom, int age, string photo, string slogan, int nobreVois)
        {
            Nom = nom;
            Prenom = prenom;
            this.age = age;
            this.photo = photo;
            this.slogan = slogan;
            this.nobreVois = nobreVois;
        }
    }
}
