using Microsoft.EntityFrameworkCore;
using OnlineCourse.Models;

namespace OnlineCourse.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; } // Nếu dùng

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var fk in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasData(
                    new Role { RoleId = 1, RoleName = "Admin" },
                    new Role { RoleId = 2, RoleName = "Teacher" },
                    new Role { RoleId = 3, RoleName = "Student" }
                );
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        UserId = 1,
                        UserName = "admin",
                        Email = "admin@gmail.com",
                        Password = "123",
                        FullName = "Đào Quang Biên",
                        DateOfBirth = new DateTime(2004, 6, 16),
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    },
                    new User
                    {
                        UserId = 2,
                        UserName = "user",
                        Email = "user@gmail.com",
                        Password = "123",
                        FullName = "Đào Quang Triển",
                        DateOfBirth = new DateTime(2008, 6, 16),
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    }
                );

            modelBuilder.Entity<Permission>()
                .HasData(
                    new Permission
                    {
                        PermissionId = 1,
                        PermissionName = "ViewUsers",
                        Description = "Allows viewing user list"
                    },
                    new Permission
                    {
                        PermissionId = 2,
                        PermissionName = "EditUsers",
                        Description = "Allows editing user information"
                    }
                );

            modelBuilder.Entity<RolePermission>()
                .HasData(
                    new RolePermission
                    {
                        RolePermissionId = 1,
                        RoleId = 1, // Admin
                        PermissionId = 1 // ViewUsers
                    },
                    new RolePermission
                    {
                        RolePermissionId = 2,
                        RoleId = 1, // Admin
                        PermissionId = 2 // EditUsers
                    },
                    new RolePermission
                    {
                        RolePermissionId = 3,
                        RoleId = 2, // Teacher
                        PermissionId = 1 // ViewUsers
                    }
                );
            modelBuilder.Entity<UserRole>()
                .HasData(
                    new UserRole
                    {
                        UserRoleId = 1,
                        UserId = 1, // Admin User
                        RoleId = 1 // Admin
                    },
                    new UserRole
                    {
                        UserRoleId = 2,
                        UserId = 2, // User 
                        RoleId = 2 // Teacher
                    }
                );
        }
    }
}
