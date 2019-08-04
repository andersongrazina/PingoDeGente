using PingoDeGenteAppApi.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentbookAppApi.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> GetStudent(string id);

        Task AddStudent(Student item);

        Task<bool> RemoveStudent(string id);

        Task<bool> UpdateStudent(string id, Student item);

        Task<bool> RemoveAllStudents();
    }
}
