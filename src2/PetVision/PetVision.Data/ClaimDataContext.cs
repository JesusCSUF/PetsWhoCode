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
        public DbSet<PetsInfo> PetInfos { get; set; }
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



            modelBuilder.Entity<PetsInfo>().Map(m =>
            {
                m.ToTable("PetsInfo");
                m.Property(x => x.Id).HasColumnName("Id");
                m.Property(x => x.Breed).HasColumnName("Breed_Desc");
                m.Property(x => x.Traits).HasColumnName("Traits");
                m.Property(x => x.Issues).HasColumnName("Issues");
                m.Property(x => x.AccordingTo).HasColumnName("AccordingTo");
                m.Property(x => x.Link).HasColumnName("Link");
                m.Property(x => x.Originated).HasColumnName("Originated");
                m.Property(x => x.BreedCode).HasColumnName("BM_Breed_Code");
                m.Property(x => x.SpecieCode).HasColumnName("BM_Species_Code");
            }).HasKey(x => x.Id);
        }
    }
}
