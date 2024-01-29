using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Models
{
    public class Devise
    {

        private int id;
        private string? nomDevise;
        private double taux;

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string? NomDevise
        {
            get { return this.nomDevise; }
            set { this.nomDevise = value; }
        }

        public double Taux
        {
            get { return this.taux; }
            set { this.taux = value; }
        }

        public Devise(int id, string? nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public Devise() { }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                   Id == devise.Id &&
                   NomDevise == devise.NomDevise &&
                   Taux == devise.Taux;
        }
    }
}
