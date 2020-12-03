using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CurriculumRepository.CORE.Data
{
    public partial class CurriculumDatabaseContext : DbContext
    {
        public CurriculumDatabaseContext()
        {
        }

        public CurriculumDatabaseContext(DbContextOptions<CurriculumDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<La> La { get; set; }
        public virtual DbSet<Lacollaboration> Lacollaboration { get; set; }
        public virtual DbSet<Laperformance> Laperformance { get; set; }
        public virtual DbSet<LastrategyMethod> LastrategyMethod { get; set; }
        public virtual DbSet<LateachingAid> LateachingAid { get; set; }
        public virtual DbSet<Latype> Latype { get; set; }
        public virtual DbSet<LearningOutcomeCt> LearningOutcomeCt { get; set; }
        public virtual DbSet<LearningOutcomeSubject> LearningOutcomeSubject { get; set; }
        public virtual DbSet<Ls> Ls { get; set; }
        public virtual DbSet<LscorrelationInterdisciplinarity> LscorrelationInterdisciplinarity { get; set; }
        public virtual DbSet<Lskeyword> Lskeyword { get; set; }
        public virtual DbSet<Lsla> Lsla { get; set; }
        public virtual DbSet<Lstype> Lstype { get; set; }
        public virtual DbSet<StrategyMethod> StrategyMethod { get; set; }
        public virtual DbSet<StrategyMethodType> StrategyMethodType { get; set; }
        public virtual DbSet<TeachingAid> TeachingAid { get; set; }
        public virtual DbSet<TeachingAidType> TeachingAidType { get; set; }
        public virtual DbSet<TeachingSubject> TeachingSubject { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.Idkeyword)
                    .HasName("PK_KljucniPojam");

                entity.Property(e => e.Idkeyword).HasColumnName("IDKeyword");

                entity.Property(e => e.KeywordName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<La>(entity =>
            {
                entity.HasKey(e => e.Idla)
                    .HasName("PK_Aktivnost");

                entity.ToTable("LA");

                entity.Property(e => e.Idla).HasColumnName("IDLA");

                entity.Property(e => e.CooperationId).HasColumnName("CooperationID");

                entity.Property(e => e.Laacknowledgment)
                    .HasColumnName("LAAcknowledgment")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ladescription)
                    .IsRequired()
                    .HasColumnName("LADescription");

                entity.Property(e => e.Laduration).HasColumnName("LADuration");

                entity.Property(e => e.Lagrade).HasColumnName("LAGrade");

                entity.Property(e => e.Laname)
                    .IsRequired()
                    .HasColumnName("LAName")
                    .HasMaxLength(200);

                entity.Property(e => e.LastrategiesId).HasColumnName("LAStrategiesID");

                entity.Property(e => e.LatypeId).HasColumnName("LATypeID");

                entity.Property(e => e.Lsid).HasColumnName("LSID");

                entity.Property(e => e.PerformanceId).HasColumnName("PerformanceID");

                entity.HasOne(d => d.Cooperation)
                    .WithMany(p => p.La)
                    .HasForeignKey(d => d.CooperationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LA_LACooperation");

                entity.HasOne(d => d.Latype)
                    .WithMany(p => p.La)
                    .HasForeignKey(d => d.LatypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LA_LAType");

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.La)
                    .HasForeignKey(d => d.PerformanceId)
                    .HasConstraintName("FK_LA_LAPerformance");
            });

            modelBuilder.Entity<Lacollaboration>(entity =>
            {
                entity.HasKey(e => e.Idcollaboration)
                    .HasName("PK_RazinaSuradnje");

                entity.ToTable("LACollaboration");

                entity.Property(e => e.Idcollaboration).HasColumnName("IDCollaboration");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CollaborationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Laperformance>(entity =>
            {
                entity.HasKey(e => e.Idperformance);

                entity.ToTable("LAPerformance");

                entity.Property(e => e.Idperformance).HasColumnName("IDPerformance");

                entity.Property(e => e.PerformanceName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<LastrategyMethod>(entity =>
            {
                entity.HasKey(e => e.IdlastrategyMethod);

                entity.ToTable("LAStrategyMethod");

                entity.Property(e => e.IdlastrategyMethod).HasColumnName("IDLAStrategyMethod");

                entity.Property(e => e.Laid).HasColumnName("LAID");

                entity.Property(e => e.StrategyMethodId).HasColumnName("StrategyMethodID");

                entity.HasOne(d => d.La)
                    .WithMany(p => p.LastrategyMethod)
                    .HasForeignKey(d => d.Laid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LAStrategyMethod_LA");

                entity.HasOne(d => d.StrategyMethod)
                    .WithMany(p => p.LastrategyMethod)
                    .HasForeignKey(d => d.StrategyMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LAStrategyMethod_StrategyMethod");
            });

            modelBuilder.Entity<LateachingAid>(entity =>
            {
                entity.HasKey(e => e.IdlateachingAid);

                entity.ToTable("LATeachingAid");

                entity.Property(e => e.IdlateachingAid).HasColumnName("IDLATeachingAid");

                entity.Property(e => e.Laid).HasColumnName("LAID");

                entity.Property(e => e.LateachingAidUser)
                    .HasColumnName("LATeachingAidUser")
                    .HasComment("Atribut definira hoće li se nastavnim sredstvom služiti nastavnik ili učenik. Npr. 0 za nastavnika, a 1 za učenika.");

                entity.Property(e => e.TeachingAidId).HasColumnName("TeachingAidID");

                entity.HasOne(d => d.La)
                    .WithMany(p => p.LateachingAid)
                    .HasForeignKey(d => d.Laid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LATeachingAid_LA");

                entity.HasOne(d => d.TeachingAid)
                    .WithMany(p => p.LateachingAid)
                    .HasForeignKey(d => d.TeachingAidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LATeachingAid_TeachingAid");
            });

            modelBuilder.Entity<Latype>(entity =>
            {
                entity.HasKey(e => e.Idlatype)
                    .HasName("PK_NacinIzvodenja");

                entity.ToTable("LAType");

                entity.Property(e => e.Idlatype).HasColumnName("IDLAType");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LatypeName)
                    .IsRequired()
                    .HasColumnName("LATypeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LearningOutcomeCt>(entity =>
            {
                entity.HasKey(e => e.IdlearningOutcomeCt)
                    .HasName("PK_IshodUcenjaRR");

                entity.ToTable("LearningOutcomeCT");

                entity.Property(e => e.IdlearningOutcomeCt).HasColumnName("IDLearningOutcomeCT");

                entity.Property(e => e.LearningOutcomeCtstatement)
                    .IsRequired()
                    .HasColumnName("LearningOutcomeCTStatement");
            });

            modelBuilder.Entity<LearningOutcomeSubject>(entity =>
            {
                entity.HasKey(e => e.IdlearningOutcomeSubject)
                    .HasName("PK_IshodUcenjaPredmet");

                entity.Property(e => e.IdlearningOutcomeSubject).HasColumnName("IDLearningOutcomeSubject");

                entity.Property(e => e.LearningOutcomeSubjectStatement).IsRequired();
            });

            modelBuilder.Entity<Ls>(entity =>
            {
                entity.HasKey(e => e.Idls)
                    .HasName("PK_ScenarijUcenja");

                entity.ToTable("LS");

                entity.Property(e => e.Idls).HasColumnName("IDLS");

                entity.Property(e => e.LearningOutcomeCtid).HasColumnName("LearningOutcomeCTID");

                entity.Property(e => e.LearningOutcomeSubjectId).HasColumnName("LearningOutcomeSubjectID");

                entity.Property(e => e.Lsacknowledgment)
                    .HasColumnName("LSAcknowledgment")
                    .HasMaxLength(100);

                entity.Property(e => e.Lsdescription)
                    .IsRequired()
                    .HasColumnName("LSDescription");

                entity.Property(e => e.Lsduration).HasColumnName("LSDuration");

                entity.Property(e => e.Lsgrade).HasColumnName("LSGrade");

                entity.Property(e => e.Lsname)
                    .IsRequired()
                    .HasColumnName("LSName")
                    .HasMaxLength(100);

                entity.Property(e => e.LstypeId).HasColumnName("LSTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");

                entity.HasOne(d => d.LearningOutcomeCt)
                    .WithMany(p => p.Ls)
                    .HasForeignKey(d => d.LearningOutcomeCtid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LS_LearningOutcomeCTID");

                entity.HasOne(d => d.LearningOutcomeSubject)
                    .WithMany(p => p.Ls)
                    .HasForeignKey(d => d.LearningOutcomeSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LS_LearningOutcomeSubjectID");

                entity.HasOne(d => d.Lstype)
                    .WithMany(p => p.Ls)
                    .HasForeignKey(d => d.LstypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LS_LSType");

                entity.HasOne(d => d.TeachingSubject)
                    .WithMany(p => p.Ls)
                    .HasForeignKey(d => d.TeachingSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LS_TeachingSubjectID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LS_UserID");
            });

            modelBuilder.Entity<LscorrelationInterdisciplinarity>(entity =>
            {
                entity.HasKey(e => e.IdlscorrelationInterdisciplinarity);

                entity.ToTable("LSCorrelationInterdisciplinarity");

                entity.Property(e => e.IdlscorrelationInterdisciplinarity).HasColumnName("IDLSCorrelationInterdisciplinarity");

                entity.Property(e => e.Lsid).HasColumnName("LSID");

                entity.Property(e => e.TeachingSubjectId).HasColumnName("TeachingSubjectID");

                entity.HasOne(d => d.Ls)
                    .WithMany(p => p.LscorrelationInterdisciplinarity)
                    .HasForeignKey(d => d.Lsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LSCorrelationInterdisciplinarity_LS");

                entity.HasOne(d => d.TeachingSubject)
                    .WithMany(p => p.LscorrelationInterdisciplinarity)
                    .HasForeignKey(d => d.TeachingSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LSCorrelationInterdisciplinarity_TeachingSubject");
            });

            modelBuilder.Entity<Lskeyword>(entity =>
            {
                entity.HasKey(e => e.Idlskeyword);

                entity.ToTable("LSKEYWORD");

                entity.HasIndex(e => e.Keywordid);

                entity.HasIndex(e => e.Lsid);

                entity.Property(e => e.Idlskeyword).HasColumnName("IDLSKEYWORD");

                entity.Property(e => e.Keywordid).HasColumnName("KEYWORDID");

                entity.Property(e => e.Lsid).HasColumnName("LSID");

                entity.HasOne(d => d.Keyword)
                    .WithMany(p => p.Lskeyword)
                    .HasForeignKey(d => d.Keywordid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LSKEYWORD_KEYWORD");

                entity.HasOne(d => d.Ls)
                    .WithMany(p => p.Lskeyword)
                    .HasForeignKey(d => d.Lsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LSKEYWORD_LS");
            });

            modelBuilder.Entity<Lsla>(entity =>
            {
                entity.HasKey(e => e.Idlsla);

                entity.ToTable("LSLA");

                entity.Property(e => e.Idlsla).HasColumnName("IDLSLA");

                entity.Property(e => e.Laid).HasColumnName("LAID");

                entity.Property(e => e.Lsid).HasColumnName("LSID");

                entity.HasOne(d => d.La)
                    .WithMany(p => p.Lsla)
                    .HasForeignKey(d => d.Laid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LSLA_LA");

                entity.HasOne(d => d.Ls)
                    .WithMany(p => p.Lsla)
                    .HasForeignKey(d => d.Lsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LSLA_LS");
            });

            modelBuilder.Entity<Lstype>(entity =>
            {
                entity.HasKey(e => e.Idlstype)
                    .HasName("PK_VrstaScenarija");

                entity.ToTable("LSType");

                entity.Property(e => e.Idlstype).HasColumnName("IDLSType");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LstypeName)
                    .IsRequired()
                    .HasColumnName("LSTypeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StrategyMethod>(entity =>
            {
                entity.HasKey(e => e.IdstrategyMethod)
                    .HasName("PK_StrategijeIMetode");

                entity.Property(e => e.IdstrategyMethod).HasColumnName("IDStrategyMethod");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrategyMethodName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StrategyMethodPicture).HasColumnType("image");

                entity.Property(e => e.StrategyMethodTypeId).HasColumnName("StrategyMethodTypeID");

                entity.HasOne(d => d.StrategyMethodType)
                    .WithMany(p => p.StrategyMethod)
                    .HasForeignKey(d => d.StrategyMethodTypeId)
                    .HasConstraintName("FK_StrategyMethod_StrategyMethodType");
            });

            modelBuilder.Entity<StrategyMethodType>(entity =>
            {
                entity.HasKey(e => e.IdstrategyMethodType)
                    .HasName("PK_VrstaStrategijeIMetode");

                entity.Property(e => e.IdstrategyMethodType).HasColumnName("IDStrategyMethodType");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StrategyMethodTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TeachingAid>(entity =>
            {
                entity.HasKey(e => e.IdteachingAid);

                entity.Property(e => e.IdteachingAid).HasColumnName("IDTeachingAid");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TeachingAidName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TeachingAidPicture).HasColumnType("image");

                entity.Property(e => e.TeachingAidTypeId).HasColumnName("TeachingAidTypeID");

                entity.HasOne(d => d.TeachingAidType)
                    .WithMany(p => p.TeachingAid)
                    .HasForeignKey(d => d.TeachingAidTypeId)
                    .HasConstraintName("FK_TeachingAid_TeachingAidType");
            });

            modelBuilder.Entity<TeachingAidType>(entity =>
            {
                entity.HasKey(e => e.IdteachingAidType);

                entity.Property(e => e.IdteachingAidType).HasColumnName("IDTeachingAidType");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TeachingAidTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TeachingSubject>(entity =>
            {
                entity.HasKey(e => e.IdteachingSubject)
                    .HasName("PK_NastavniPredmet");

                entity.Property(e => e.IdteachingSubject).HasColumnName("IDTeachingSubject");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TeachingSubjectName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PK_Korisnik");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePicture).HasColumnType("image");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("FK_User_UserType");

                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.IduserType);

                entity.Property(e => e.IduserType).HasColumnName("IDUserType");

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            return await base.SaveChangesAsync(true, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}
