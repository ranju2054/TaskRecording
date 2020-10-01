using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using TaskRecordingSystem.Models;
using TaskRecordingSystem.ViewModels;



namespace TaskRecordingSystem.Models
{
    public class UserDbContext:IdentityDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options) { }

        public  DbSet<Employee> Employees { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }
        public DbSet<Project>  Projects { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Priority> Priorities { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            

        }
        

      

       

      

       





    }
}
