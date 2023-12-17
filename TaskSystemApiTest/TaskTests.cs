using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Runtime.CompilerServices;
using TaskSystemApi.Data;
using TaskSystemApi.Enums;
using TaskSystemApi.Models;
using TaskSystemApi.Repository;
using TaskSystemApi.Repository.Interface;

namespace TaskSystemApiTest
{
    [TestFixture]
    public class DatabaseTests
    {
        private TasksSystemDBContext _context;
        private ITaskRepository _taskRepository;


        [SetUp]
        public void Setup() 
        {
            // Configurar o contexto para testes (usando um banco de dados em memória)
            var options = new DbContextOptionsBuilder<TasksSystemDBContext>()                
                .UseInMemoryDatabase(databaseName: "SIMONELI")
                .Options;

            // Criar instância do DbContext usando as opções configuradas para testes
            _context = new TasksSystemDBContext(options);
            _taskRepository = new TaskRepository(_context);

            _context.Add(new TaskModel { Name = "test", Description= "testing", Status = TaskStatusEnum.ToDo });

        }

        [Test]
        public void AddTest()
        {
            _taskRepository.AddTask(new TaskModel { Name = "test", Description = "testing", Status = TaskStatusEnum.ToDo });
            _context.SaveChanges();
            var teste = _context.Tasks.FirstOrDefault();
            Assert.IsNotNull(teste);
        }

        [Test]
        public void GetTestById()
        {
            var teste = _taskRepository.GetById(2).Result;
            Assert.IsNotNull(teste.Name);
        }



        [Test]
        public void GetAllTest()
        {
            var teste = _taskRepository.GetAll().Result.Count;
            Assert.GreaterOrEqual(teste, 1);
        }

        [Test]
        public void UpdateTest()
        {
            var teste = _taskRepository.UpdateTask(new TaskModel { Name = "updateTest" }, 2).Result;
            _context.SaveChanges();
            Assert.That(teste.Name, Is.EqualTo("updateTest"));
        }

        [Test]
        public void DeleteTest()
        {
            var teste = _taskRepository.DeleteTask(1).Result;
            _context.SaveChanges();
            Assert.IsTrue(teste);
        }

    }

}