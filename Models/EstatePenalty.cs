using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.DynamicData;
using System.Security.Cryptography.X509Certificates;

namespace PenanltySystem.Models
{
    public class EstatePenalty
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PenaltyID { get; set; }
        public virtual Owner Owner { get; set; }    

        public int OwnerID { get; set; }
        public virtual Area Area { get; set; }
        public int AreaCode { get; set; }
        public virtual Violation Violation { get; set; }
        public int ViolationCode { get; set; }

        public double TotalPenaltyCost { get; set; }
        public double CalcAreaPenaltyCost()
        {
            DataContext db = new DataContext();

            var violation = ( from r in db.Violations
                            where ViolationCode == r.ViolationCode
                            select r.ViolationCost).FirstOrDefault();
            
            var Area = (from a in db.Areas
                        where a.AreaCode == AreaCode
                        select a.AreaRate).FirstOrDefault();

            double cost = 0;
            cost = violation * (Area / 100.0);
            return cost;
        }


        public double calcAgePenalty()
        {
            DataContext db = new DataContext();

            var violation = (from r in db.Violations
                             where ViolationCode == r.ViolationCode
                             select r.ViolationCost).FirstOrDefault();

            var age = (from a in db.Owners
                       where OwnerID == a.OwnerId
                       select a.OwnerAge).FirstOrDefault();
            
            double cost = 0;

            if (age < 26)
            {
                cost = violation * (5 / 100.0);
            }
            else if (age > 25)
            {
                cost = violation * (3 / 100.0);
            }
            return cost;
        }

        public double CalcTotalPenaltyCost()
        {
            double cost = 0;
            cost=CalcAreaPenaltyCost()+calcAgePenalty();
            return cost;
        }
        public int CalcPointsToDeduct()
        {
            DataContext db = new DataContext();

            var violation = (from r in db.Violations
                             where ViolationCode == r.ViolationCode
                             select r.ViolationCost).FirstOrDefault();
            int points = 0;

            int cost= 0;
            cost = (int)violation;//converting double to int
            points = (int)(cost * 1 / 100.0);
            return points;
        }
    }


}