using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rankin.Entity
{
   public class Electeurs
    {
     public   string nom { get; set; }
        public string prenom { get; set; }
        public string photo { get; set; }
        public  string matricule { get; set; }
        public int age { get; set; }
        public int IsVoted { get; set; }

        public Electeurs(string nom, string prenom, string photo, string matricule, int age, int isVoted)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.photo = photo;
            this.matricule = matricule;
            this.age = age;
            IsVoted = isVoted;
        }
    }
}
