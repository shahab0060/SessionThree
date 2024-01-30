using Microsoft.EntityFrameworkCore;
using SessionThree.Model;
using SQLitePCL;
using Xamarin.Forms;

namespace SessionThree.Context
{
    public class InsuranceDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<InsuranceRequest> InsuranceRequests { get; set; }
        public DbSet<HospitalSelectedInsuranceRequest> HospitalSelectedInsuranceRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public InsuranceDbContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
            //AddDefaultHospitals();
            //AddDefaultDoctors();
        }

        #region seed datas

        void AddDefaultDoctors()
        {
            Doctor firstDoctor = new Doctor()
            {
                DoctorId = 1,
                Address = "qom is here",
                FullName = " for isntance shahab bakhtiari",
                Major = "chest dr",
                PhoneNumber = "09026150241"
            };
            Doctor secondDoctor = new Doctor()
            {
                DoctorId = 2,
                PhoneNumber = "09932641316",
                Major = " software is here",
                FullName = "another guy that develoeps app",
                Address = "Dubai is there"
            };

            Doctors.Add(firstDoctor);
            Doctors.Add(secondDoctor);
            SaveChanges();
        }

        void AddDefaultHospitals()
        {
            Hospital firstHospital = new Hospital()
            {
                HospitalId = 1,
                Address = "qom is here",
                Title = "shahid beheshti is here",
                Type = "hospital",
                City = "qom",
            };
            Hospital secondHospital = new Hospital()
            {
                HospitalId = 2,
                Address = "Dubai is there",
                City = "dubai",
                Title = "DDDDDUbai",
                Type = "no type"
            };

            Hospitals.Add(firstHospital);
            Hospitals.Add(secondHospital);
            SaveChanges();
        }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbFullPath = DependencyService.Get<IContext>().GetDbPath("InsuranceDb.db3");
            optionsBuilder.UseSqlite($"FileName={dbFullPath}");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(new Doctor()
            {
                DoctorId = 1,
                Address = "qom is here",
                FullName = " for isntance shahab bakhtiari",
                Major = "chest dr",
                PhoneNumber = "09026150241"
            },
            new Doctor()
            {
                DoctorId = 2,
                PhoneNumber = "09932641316",
                Major = " software is here",
                FullName = "another guy that develoeps app",
                Address = "Dubai is there"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
