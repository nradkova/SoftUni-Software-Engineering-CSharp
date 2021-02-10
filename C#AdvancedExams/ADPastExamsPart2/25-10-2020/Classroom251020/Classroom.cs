using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
       
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(capacity);

        }
        public int Capacity { get; set; }
      
        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Capacity > students.Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} { student.LastName}";
            }
            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = students
                .FirstOrDefault(x => x.FirstName == firstName
              && x.LastName == lastName);
            if (student != null)
            {
                students.Remove(student);
                return $"Dissmissed student {firstName} {lastName}";
            }
            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            if (students.Any(x => x.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in students)
                {
                    if (student.Subject == subject)
                    {
                        sb.AppendLine($"{student.FirstName} {student.LastName}");
                    }
                }
                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students
                 .FirstOrDefault(x => x.FirstName == firstName
                 && x.LastName == lastName);
        }
    }
}
