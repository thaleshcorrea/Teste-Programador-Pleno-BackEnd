using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tarefa_02.Controllers;
using tarefa_02.Dtos;
using tarefa_02.Models;
using tarefa_02.Repositories;
using tarefa_02.Services;

namespace tarefa_02.Tests
{
    [TestClass]
    public class CidadeTests
    {
        private readonly ICidadeService _cidadeService;
        private readonly Mock<ICidadeRepository> _mockRepository;

        private GetCidadeDto getCidadeDto = new()
        {
            IdCidade = Guid.NewGuid(),
            NomeCidade = "Três Pontas",
            CodigoIbge = 11111,
        };

        public CidadeTests()
        {
            _mockRepository = new Mock<ICidadeRepository>();
            _cidadeService = new CidadeService(_mockRepository.Object);
        }

        [TestMethod]
        public async Task Add_ValidCidade_ShouldReturnSucess()
        {
            AddCidadeDto validCidadeDto = new()
            {
                NomeCidade = "Três Pontas",
                IdEstado = Guid.NewGuid(),
                CodigoIbge = 1234567,
            };

            // Act
            var actual = await _cidadeService.Add(validCidadeDto);

            Assert.AreEqual(true, actual.Succeeded);
        }

        [TestMethod]
        public async Task AddCidade_EmptyName_ShouldReturnFalse()
        {
            AddCidadeDto invalidCidadeDto = new()
            {
                NomeCidade = "",
                IdEstado = Guid.NewGuid(),
                CodigoIbge = 1234567,
            };

            var response = await _cidadeService.Add(invalidCidadeDto);

            Assert.AreEqual(false, response.Succeeded);
        }

        [TestMethod]
        public async Task Update_ValidCidade_ShouldReturnTrue()
        {
            var idCidade = Guid.NewGuid();
            _mockRepository.Setup(x => x.GetById(idCidade))
                .ReturnsAsync(new Cidade(
                    idCidade,
                    111111,
                    "Três Pontas",
                    Guid.NewGuid()));


            UpdateCidadeDto updateCidadeDto = new()
            {
                IdCidade = idCidade,
                IdEstado = Guid.NewGuid(),
                NomeCidade = "Varginha",
                CodigoIbge = 456789
            };

            var response = await _cidadeService.Update(updateCidadeDto);

            Assert.AreEqual(true, response.Succeeded);
        }

        [TestMethod]
        public async Task GetCidadeByEstado_ShouldCount10()
        {
            var idEstado = It.IsAny<Guid>();
            _mockRepository.Setup(x => x.GetByEstado(idEstado))
                .ReturnsAsync(new List<GetCidadeDto>
                {
                    getCidadeDto,
                    getCidadeDto,
                    getCidadeDto,
                    getCidadeDto,
                    getCidadeDto,
                    getCidadeDto,
                    getCidadeDto,
                    getCidadeDto,
                    getCidadeDto,
                    getCidadeDto,
                });

            var response = await _cidadeService.GetByEstado(idEstado);

            Assert.AreEqual(10, response.Data.Count);
        }
    }
}