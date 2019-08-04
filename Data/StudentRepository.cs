using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PingoDeGenteAppApi.Data;
using PingoDeGenteAppApi.Model;
using StudentbookAppApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentbookAppApi.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PingoDeGenteContext _context = null;

        public StudentRepository(IOptions<Settings> settings)
        {
            _context = new PingoDeGenteContext(settings);
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            try
            {
                return await _context.Students.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after Id or InternalId (BSonId value)
        //
        public async Task<Student> GetStudent(string id)
        {
            try
            {
                //ObjectId internalId = GetInternalId(id);
                return await _context.Students
                                .Find(Student => Student._Id == id)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // Try to convert the Id to a BSonId value
        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task AddStudent(Student item)
        {
            try
            {
                await _context.Students.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveStudent(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Students.DeleteOneAsync(
                     Builders<Student>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged 
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> UpdateStudent(string id, Student item)
        {
            try
            {
                ReplaceOneResult actionResult = await _context.Students
                                                .ReplaceOneAsync(n => n._Id.Equals(id)
                                                                , item
                                                                , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllStudents()
        {
            try
            {
                DeleteResult actionResult = await _context.Students.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
