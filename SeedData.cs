using b3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Policy;

namespace b3.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new b3Context(
            serviceProvider.GetRequiredService<DbContextOptions<b3Context>>()))
            {
                context.Database.EnsureCreated();

                // Kiểm tra dữ liệu có sv nào ko, có thể && thêm có lớp, có học phần...
                if (context.Student.Any())
                {
                    return;
                }

                var classes = new Class[]
                {
                    new Class{Title="ĐH19PM"},
                    new Class{Title="ĐH19TH1"},
                    new Class{Title="ĐH19TH2"}
                };

                context.Class.AddRange(classes);
                context.SaveChanges();

                var students = new Student[]
                {
                    new Student{Code="DPM185156",Name="Lê Công Hậu",Birth=DateTime.Parse("2000-01-01"),Email="lchau_19pm@student.agu.edu.vn",ClassID=1},
                    new Student{Code="DPM185143",Name="Trương Thị Mỹ Duyên",Birth=DateTime.Parse("2000-01-01"),Email="ttmduyen_19pm@student.agu.edu.vn",ClassID=1},
                    new Student{Code="DTH185374",Name="Đặng Thị Phương Thanh",Birth=DateTime.Parse("2000-01-01"),Email="dtpthanh_19th2@student.agu.edu.vn",ClassID=3},
                    new Student{Code="DTH185282",Name="Trần Thanh Khan",Birth=DateTime.Parse("2000-01-01"),Email="ttkhan_19th2@student.agu.edu.vn",ClassID=3},
                    new Student{Code="DTH185391",Name="Đào Hữu Thắng",Birth=DateTime.Parse("2000-01-01"),Email="dhthang_19th1@student.agu.edu.vn",ClassID=2},
                    new Student{Code="DTH185331",Name="Nguyễn Thị Yến Nhi",Birth=DateTime.Parse("2000-01-01"),Email="ntynhi_19th1@student.agu.edu.vn",ClassID=2}

                };

                context.Student.AddRange(students);
                context.SaveChanges();

                var courses = new Course[]
                {
                    new Course{Code="CON501",Title="Lập trình web",Credits=3},
                    new Course{Code="SEE517",Title="Công nghệ web ASP.NET",Credits=3},
                    new Course{Code="SEE518",Title="Công nghệ web PHP",Credits=3}
                };

                context.Course.AddRange(courses);
                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                    new Enrollment{StudentID=1,CourseID=1,Grade=Grade.A},
                    new Enrollment{StudentID=2,CourseID=1,Grade=Grade.A},
                    new Enrollment{StudentID=3,CourseID=1,Grade=Grade.B},
                    new Enrollment{StudentID=4,CourseID=1,Grade=Grade.B},
                    new Enrollment{StudentID=5,CourseID=1,Grade=Grade.A},
                    new Enrollment{StudentID=6,CourseID=1,Grade=Grade.A},
                    new Enrollment{StudentID=1,CourseID=2,Grade=Grade.A},
                    new Enrollment{StudentID=2,CourseID=2,Grade=Grade.A},
                    new Enrollment{StudentID=3,CourseID=3,Grade=Grade.B},
                    new Enrollment{StudentID=4,CourseID=3,Grade=Grade.B},
                    new Enrollment{StudentID=5,CourseID=2,Grade=Grade.A},
                    new Enrollment{StudentID=6,CourseID=2,Grade=Grade.A}
                };

                context.Enrollment.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}
