using Microsoft.EntityFrameworkCore;

using Entities;

namespace WebApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentContext(
                serviceProvider.GetRequiredService<DbContextOptions<StudentContext>>()))
            {
                // Look for any students.
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                context.Students.AddRange(
                    new Student
                    {
                        Name = "Carson",
                        Programme = "Alexander"
                    },
                    new Student
                    {
                        Name = "Meredith",
                        Programme = "Alonso"
                    },
                    new Student
                    {
                        Name = "Arturo",
                        Programme = "Anand"
                    },
                    new Student
                    {
                        Name = "Gytis",
                        Programme = "Barzdukas"
                    },
                    new Student
                    {
                        Name = "Yan",
                        Programme = "Li"
                    },
                    new Student
                    {
                        Name = "Peggy",
                        Programme = "Justice"
                    },
                    new Student
                    {
                        Name = "Laura",
                        Programme = "Norman"
                    },
                    new Student
                    {
                        Name = "Nino",
                        Programme = "Olivetto"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
