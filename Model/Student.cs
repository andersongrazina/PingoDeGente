using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingoDeGenteAppApi.Model
{
    public class Student
    {
        [BsonId]
        //public ObjectId _id { get; set; }
        public string _Id { get; set; }
        public bool paymentOk { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public List<Class> classes { get; set; }

        public Student()
        {
            classes = new List<Class>();
        }
    }
}
