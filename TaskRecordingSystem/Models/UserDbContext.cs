using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using TaskRecordingSystem.Models.ViewModel;


namespace TaskRecordingSystem.Models
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project>  Projects { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Login> Logins { get; set; }

        //public DbSet<TaskRecordingSystem.Models.ViewModel.UserViewModel> UserViewModel { get; set; }







    }
}
