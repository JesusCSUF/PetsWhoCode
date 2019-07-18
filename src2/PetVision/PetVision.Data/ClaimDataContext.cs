using PetVision.Data.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetVision.Data
{
    public class ClaimDataContext : DbContext
    {
        public DbSet<Condition> Conditions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Condition>().Map(m =>
            {
                m.ToTable("Conditions");
                m.Property(x => x.Breed).HasColumnName("Breed_Desc");
                m.Property(x => x.ClaimCode).HasColumnName("Claim_Diagnosis_Code");
                m.Property(x => x.DiagnosisCodeDesc).HasColumnName("Diagnosis_Code_Desc");
                m.Property(x => x.State).HasColumnName("Written_State");
                m.Property(x => x.ClaimAmount).HasColumnName("Claimed_Amt");
                m.Property(x => x.PaidAmount).HasColumnName("Paid_Amt");
                m.Property(x => x.Rank).HasColumnName("Rank");
            }).HasKey(x => x.ClaimCode);
        }
    }
}
