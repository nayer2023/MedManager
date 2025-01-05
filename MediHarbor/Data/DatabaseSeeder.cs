using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediHarbor.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using MediHarbor.Data;

public class DatabaseSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public DatabaseSeeder(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task SeedDataAsync()
    {
        // Seed Doctor data
        if (!_context.Doctors.Any())
        {
            var doctorUser1 = await CreateUserAsync("doctor1@example.com", "Doctor1");
            var doctorUser2 = await CreateUserAsync("doctor2@example.com", "Doctor2");
            var doctorUser3 = await CreateUserAsync("doctor3@example.com", "Doctor3");
            var doctorUser4 = await CreateUserAsync("doctor4@example.com", "Doctor4");
            var doctorUser5 = await CreateUserAsync("doctor5@example.com", "Doctor5");

            await _context.Doctors.AddRangeAsync(
                new Doctor
                {
                    FullName = "Dr. John Smith",
                    Specialization = "Cardiology",
                    PhoneNumber = "555-123-4567",
                    Location = "Hospital A",
                    UserId = doctorUser1.Id,
                    User = doctorUser1
                },
                new Doctor
                {
                    FullName = "Dr. Jane Doe",
                    Specialization = "Neurology",
                    PhoneNumber = "555-234-5678",
                    Location = "Hospital B",
                    UserId = doctorUser2.Id,
                    User = doctorUser2
                },
                new Doctor
                {
                    FullName = "Dr. Alan Brown",
                    Specialization = "Orthopedics",
                    PhoneNumber = "555-345-6789",
                    Location = "Hospital C",
                    UserId = doctorUser3.Id,
                    User = doctorUser3
                },
                new Doctor
                {
                    FullName = "Dr. Emily Johnson",
                    Specialization = "Pediatrics",
                    PhoneNumber = "555-456-7890",
                    Location = "Hospital D",
                    UserId = doctorUser4.Id,
                    User = doctorUser4
                },
                new Doctor
                {
                    FullName = "Dr. Robert Lee",
                    Specialization = "Dermatology",
                    PhoneNumber = "555-567-8901",
                    Location = "Hospital E",
                    UserId = doctorUser5.Id,
                    User = doctorUser5
                }
            );
            await _context.SaveChangesAsync();
        }

        // Seed Scan data
        if (!_context.Scans.Any())
        {
            await _context.Scans.AddRangeAsync(
                new Scan
                {
                    ScanType = "CT Scan",
                    BodyPart = "Head",
                    Location = "Radiology Department",
                    AvailableDate = DateTime.Now.AddDays(1),
                    Price = 500.00m,
                    Duration = 30,
                    Description = "Head CT scan for brain imaging"
                },
                new Scan
                {
                    ScanType = "MRI Scan",
                    BodyPart = "Spine",
                    Location = "Radiology Department",
                    AvailableDate = DateTime.Now.AddDays(2),
                    Price = 700.00m,
                    Duration = 45,
                    Description = "Spinal MRI for back pain diagnosis"
                },
                new Scan
                {
                    ScanType = "X-Ray",
                    BodyPart = "Chest",
                    Location = "Radiology Department",
                    AvailableDate = DateTime.Now.AddDays(3),
                    Price = 100.00m,
                    Duration = 15,
                    Description = "Chest X-ray for lung issues"
                },
                new Scan
                {
                    ScanType = "Ultrasound",
                    BodyPart = "Abdomen",
                    Location = "Ultrasound Room",
                    AvailableDate = DateTime.Now.AddDays(4),
                    Price = 200.00m,
                    Duration = 20,
                    Description = "Abdominal ultrasound for organ examination"
                },
                new Scan
                {
                    ScanType = "X-Ray",
                    BodyPart = "Knee",
                    Location = "Radiology Department",
                    AvailableDate = DateTime.Now.AddDays(5),
                    Price = 120.00m,
                    Duration = 10,
                    Description = "Knee X-ray for joint examination"
                }
            );
            await _context.SaveChangesAsync();
        }

        // Seed Patient data
        if (!_context.Patients.Any())
        {
            var patientUser1 = await CreateUserAsync("patient1@example.com", "Patient1");
            var patientUser2 = await CreateUserAsync("patient2@example.com", "Patient2");
            var patientUser3 = await CreateUserAsync("patient3@example.com", "Patient3");
            var patientUser4 = await CreateUserAsync("patient4@example.com", "Patient4");
            var patientUser5 = await CreateUserAsync("patient5@example.com", "Patient5");

            await _context.Patients.AddRangeAsync(
                new Patient
                {
                    FullName = "John Doe",
                    DateOfBirth = new DateTime(1985, 5, 15),
                    Gender = "Male",
                    PhoneNumber = "555-123-4567",
                    Address = "123 Main St, City, Country",
                    UserId = patientUser1.Id,
                    User = patientUser1
                },
                new Patient
                {
                    FullName = "Jane Doe",
                    DateOfBirth = new DateTime(1990, 7, 30),
                    Gender = "Female",
                    PhoneNumber = "555-987-6543",
                    Address = "456 Elm St, City, Country",
                    UserId = patientUser2.Id,
                    User = patientUser2
                },
                new Patient
                {
                    FullName = "Alice Johnson",
                    DateOfBirth = new DateTime(1980, 11, 10),
                    Gender = "Female",
                    PhoneNumber = "555-111-2222",
                    Address = "789 Oak St, City, Country",
                    UserId = patientUser3.Id,
                    User = patientUser3
                },
                new Patient
                {
                    FullName = "Bob Smith",
                    DateOfBirth = new DateTime(1995, 2, 20),
                    Gender = "Male",
                    PhoneNumber = "555-333-4444",
                    Address = "101 Pine St, City, Country",
                    UserId = patientUser4.Id,
                    User = patientUser4
                },
                new Patient
                {
                    FullName = "Charlie Brown",
                    DateOfBirth = new DateTime(2000, 9, 5),
                    Gender = "Male",
                    PhoneNumber = "555-555-6666",
                    Address = "202 Maple St, City, Country",
                    UserId = patientUser5.Id,
                    User = patientUser5
                }
            );
            await _context.SaveChangesAsync();
        }
    }

    private async Task<IdentityUser> CreateUserAsync(string email, string userName)
    {
        var user = new IdentityUser
        {
            UserName = userName,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, "Test@123");
        if (result.Succeeded)
        {
            return user;
        }

        throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
    }
}
