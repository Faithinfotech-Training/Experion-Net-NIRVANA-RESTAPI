using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicalManagementSystemNirvana.Models
{
    public partial class CMSDBContext : DbContext
    {
        public CMSDBContext()
        {
        }

        public CMSDBContext(DbContextOptions<CMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<DoctorNotes> DoctorNotes { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<LabReport> LabReport { get; set; }
        public virtual DbSet<LabTests> LabTests { get; set; }
        public virtual DbSet<MedPrescriptions> MedPrescriptions { get; set; }
        public virtual DbSet<MedicineBilling> MedicineBilling { get; set; }
        public virtual DbSet<MedicineInventory> MedicineInventory { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
                See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source= BIDHUM\\SQLEXPRESS; Initial Catalog= CMSDB; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PK__Appointm__8ECDFCC2DA7C38E7");

                entity.Property(e => e.DateOfAppointment).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__33D4B598");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__Patie__32E0915F");

                entity.HasOne(d => d.Receptionist)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ReceptionistId)
                    .HasConstraintName("FK__Appointme__Recep__34C8D9D1");
            });

            modelBuilder.Entity<DoctorNotes>(entity =>
            {
                entity.Property(e => e.Notes).IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.DoctorNotes)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__DoctorNot__Appoi__4AB81AF0");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorNotes)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__DoctorNot__Docto__49C3F6B7");
            });

            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.DoctorId)
                    .HasName("PK__Doctors__2DC00EBF27E1F821");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Doctors__StaffId__29572725");
            });

            modelBuilder.Entity<LabReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__LabRepor__D5BD4805DCBD5016");

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabReport)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__LabReport__Appoi__3F466844");
            });

            modelBuilder.Entity<LabTests>(entity =>
            {
                entity.HasKey(e => e.LabTestId)
                    .HasName("PK__LabTests__64D33925FECBE51D");

                entity.Property(e => e.TestDesc)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TestNormalRange).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.TestUnit)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedPrescriptions>(entity =>
            {
                entity.HasKey(e => e.PrescriptionId)
                    .HasName("PK__MedPresc__401308328B79B82C");

                entity.Property(e => e.PrescriptionDate).HasColumnType("date");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedPrescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedPrescr__Docto__38996AB5");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedPrescriptions)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__MedPrescr__Patie__37A5467C");
            });

            modelBuilder.Entity<MedicineBilling>(entity =>
            {
                entity.HasKey(e => e.MedBillId)
                    .HasName("PK__Medicine__75B06D8CDE93FB04");

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.HasOne(d => d.Med)
                    .WithMany(p => p.MedicineBilling)
                    .HasForeignKey(d => d.MedId)
                    .HasConstraintName("FK__MedicineB__MedId__46E78A0C");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.MedicineBilling)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__MedicineB__Presc__45F365D3");
            });

            modelBuilder.Entity<MedicineInventory>(entity =>
            {
                entity.HasKey(e => e.MedInvId)
                    .HasName("PK__Medicine__C4B68A759C008891");

                entity.Property(e => e.MedDesc).IsUnicode(false);

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.MedicineInventory)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK__MedicineI__Admin__2C3393D0");
            });

            modelBuilder.Entity<Medicines>(entity =>
            {
                entity.HasKey(e => e.MedId)
                    .HasName("PK__Medicine__EB77FC56816FF6AC");

                entity.HasOne(d => d.MedInv)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.MedInvId)
                    .HasConstraintName("FK__Medicines__MedIn__3C69FB99");

                entity.HasOne(d => d.Presccription)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.PresccriptionId)
                    .HasConstraintName("FK__Medicines__Presc__3B75D760");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__Patients__970EC36622394B6B");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientDob)
                    .HasColumnName("PatientDOB")
                    .HasColumnType("date");

                entity.Property(e => e.PatientGender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PatientPhoneNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Roles__8AFACE1A3556C23E");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__Staffs__96D4AB178CA55219");

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StaffAddr)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StaffDob).HasColumnType("date");

                entity.Property(e => e.StaffIsActive)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.StaffPassword)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Staffs__RoleId__267ABA7A");
            });

            modelBuilder.Entity<Tests>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__Tests__8CC33160A466BFAB");

                entity.HasOne(d => d.LabTest)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.LabTestId)
                    .HasConstraintName("FK__Tests__LabTestId__4316F928");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Tests)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK__Tests__ReportId__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
