using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TaskSystemApi.Data;
using TaskSystemApi.Models;
using TaskSystemApi.Repository;
using TaskSystemApi.Repository.Interface;

namespace TaskSystemApiTest
{
    [TestFixture]
    public class UserTests
    {
        private TasksSystemDBContext _context;
        private IUserRepository _userRepository;


        [SetUp]
        public void Setup()
        {
            // Configurar o contexto para testes (usando um banco de dados em memória)
            var options = new DbContextOptionsBuilder<TasksSystemDBContext>()
                .UseInMemoryDatabase(databaseName: "SIMONELI")
                .Options;

            // Criar instância do DbContext usando as opções configuradas para testes
            _context = new TasksSystemDBContext(options);
            _userRepository = new UserRepository(_context);

            _context.Add(new UserModel { Name = "test", Email = "test@test.com" });

        }

        [Test]
        public void AddTest()
        {
            _userRepository.AddUser(new UserModel { Name = "test", Email = "test@test.com" });
            _context.SaveChanges();
            var teste = _context.Users.FirstOrDefault();
            Assert.IsNotNull(teste);
        }

        [Test]
        public void GetTestById()
        {
            var teste = _userRepository.GetById(2).Result;
            Assert.IsNotNull(teste.Name);
        }



        [Test]
        public void GetAllTest()
        {
            var teste = _userRepository.GetAll().Result.Count;
            Assert.GreaterOrEqual(teste, 1);
        }

        [Test]
        public void UpdateTest()
        {
            var teste = _userRepository.UpdateUser(new UserModel { Name = "updateTest" }, 2).Result;
            _context.SaveChanges();
            Assert.That(teste.Name, Is.EqualTo("updateTest"));
        }

        [Test]
        public void DeleteTest()
        {
            var teste = _userRepository.DeleteUser(1).Result;
            _context.SaveChanges();
            Assert.IsTrue(teste);
        }

    }

}