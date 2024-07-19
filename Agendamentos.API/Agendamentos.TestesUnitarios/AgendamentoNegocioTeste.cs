using Agendamentos.Entidade.DTO;
using Agendamentos.Entidade.Entidades;
using Agendamentos.Entidade.Models;
using Agendamentos.Negocio.Interface.INegocios;
using Agendamentos.Negocio.Negocios;
using Agendamentos.Repositorio.Interface.IAgendamentoRepositorio;
using Agendamentos.Repositorio.Interface.IRepositorios;
using Agendamentos.Utilitarios.Exceptions;
using Agendamentos.Utilitarios.Messages;
using Moq;

namespace Agendamentos.TestesUnitarios
{
    public class AgendamentoNegocioTeste : TesteUnitarioBase
    {
        private IAgendamentoNegocio _negocio;
        private Mock<IAgendamentoRepositorio> _moqAgendamentoRepositorio;
        private Mock<IPacienteRepositorio> _moqPacienteRepositorio;

        [SetUp]
        public void SetUp()
        {
            Registrar<IAgendamentoNegocio, AgendamentoNegocio>();
            _moqAgendamentoRepositorio = RegistrarMock<IAgendamentoRepositorio>();
            _moqPacienteRepositorio = RegistrarMock<IPacienteRepositorio>();
            _negocio = ObterServico<IAgendamentoNegocio>();
        }

        [Test]
        public void InserirAgendamento_Sucesso()
        {
            var novoAg = new CadastroAgendamentoModel()
            {
                dat_agendamento = It.IsAny<DateTime>(),
                hor_agendamento = It.IsAny<TimeSpan>(),
                pc = new CadastroPacienteModel()
                {
                    dat_nascimento = It.IsAny<DateTime>(),
                    dsc_nome = It.IsAny<string>(),
                }
            };

            _moqAgendamentoRepositorio.Setup(e => e.ObterAg(It.IsAny<DateTime>(), It.IsAny<TimeSpan>()))
                        .Returns(() => Task.FromResult(new List<Agendamento>()));

            _moqPacienteRepositorio.Setup(e => e.ObterPc(It.IsAny<string>()))
                        .Returns(() => Task.FromResult<Paciente>(null));

            async Task action() => await _negocio.InserirAgendamentos(novoAg);
            Assert.DoesNotThrowAsync(action);
        }

        [Test]
        public void InserirAgendamentos_NumeroMaximoExcedido()
        {
            var novoAg = new CadastroAgendamentoModel()
            {
                dat_agendamento = DateTime.Now.Date,
                hor_agendamento = TimeSpan.FromHours(10),
                pc = new CadastroPacienteModel()
                {
                    dat_nascimento = DateTime.Now.AddYears(-30),
                    dsc_nome = "Teste Paciente",
                }
            };

            _moqAgendamentoRepositorio.Setup(r => r.ObterAg(novoAg.dat_agendamento, novoAg.hor_agendamento))
                                      .ReturnsAsync(new List<Agendamento> { new Agendamento(), new Agendamento() });

            var ex = Assert.ThrowsAsync<BusinessException>(() => _negocio.InserirAgendamentos(novoAg));
            Assert.AreEqual(string.Format(BusinessMessages.NumeroMaximo), ex.Message);
        }

        [Test]
        public async Task AlterarAgendamentos_Sucesso()
        {
            var data = DateTime.Now.Date;
            var hora = TimeSpan.FromHours(10);
            var status = "Confirmado";

            var agendamento = new Agendamento
            {
                dat_agendamento = data,
                hor_agendamento = hora,
                dsc_status = "Pendente"
            };

            _moqAgendamentoRepositorio.Setup(r => r.ObterAg(data, hora))
                                      .ReturnsAsync(new List<Agendamento> { agendamento });
            _moqAgendamentoRepositorio.Setup(r => r.Atualizar(It.IsAny<Agendamento>()))
                                      .ReturnsAsync(agendamento); // Retorna o próprio agendamento atualizado
            _moqAgendamentoRepositorio.Setup(r => r.ListarTudo())
                                      .ReturnsAsync(new List<AgendamentoDTO> { new AgendamentoDTO() });

            var result = await _negocio.AlterarAgendamentos(data, hora, status);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(status, agendamento.dsc_status);
            _moqAgendamentoRepositorio.Verify(r => r.Atualizar(It.IsAny<Agendamento>()), Times.Once);
            _moqAgendamentoRepositorio.Verify(r => r.ListarTudo(), Times.Once);
        }

        [Test]
        public void AlterarAgendamentos_AgendamentoInexistente()
        {
            var data = DateTime.Now.Date;
            var hora = TimeSpan.FromHours(10);
            var status = "Confirmado";

            _moqAgendamentoRepositorio.Setup(r => r.ObterAg(data, hora))
                                      .ReturnsAsync(new List<Agendamento>());

            var ex = Assert.ThrowsAsync<BusinessException>(() => _negocio.AlterarAgendamentos(data, hora, status));
            Assert.AreEqual(string.Format(BusinessMessages.AgendamentoInexistente, "ag"), ex.Message);
        }

        [Test]
        public async Task ListarAgendamentos_Sucesso()
        {
            var datas = new List<DateTime> { DateTime.Now.Date };

            _moqAgendamentoRepositorio.Setup(r => r.ListarAgendamentos(datas))
                                      .ReturnsAsync(new List<AgendamentoDTO> { new AgendamentoDTO() });

            var result = await _negocio.ListarAgendamentos(datas);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public async Task ListarAgendamentos_ListarTudo()
        {
            _moqAgendamentoRepositorio.Setup(r => r.ListarTudo())
                                      .ReturnsAsync(new List<AgendamentoDTO> { new AgendamentoDTO() });

            var result = await _negocio.ListarAgendamentos(null);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public async Task DeletarAgendamentos_Sucesso()
        {
            var data = DateTime.Now.Date;
            var hora = TimeSpan.FromHours(10);

            var agendamento = new Agendamento
            {
                dat_agendamento = data,
                hor_agendamento = hora
            };

            _moqAgendamentoRepositorio.Setup(r => r.ObterAg(data, hora))
                                      .ReturnsAsync(new List<Agendamento> { agendamento });

            _moqAgendamentoRepositorio.Setup(r => r.Deletar(It.IsAny<Agendamento>()))
                                      .Returns(Task.CompletedTask);

            _moqAgendamentoRepositorio.Setup(r => r.ListarTudo())
                                      .ReturnsAsync(new List<AgendamentoDTO> { new AgendamentoDTO() });

            var result = await _negocio.DeletarAgendamentos(data, hora);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            _moqAgendamentoRepositorio.Verify(r => r.Deletar(It.IsAny<Agendamento>()), Times.Once);
            _moqAgendamentoRepositorio.Verify(r => r.ListarTudo(), Times.Once);
        }

        [Test]
        public void DeletarAgendamentos_AgendamentoInexistente()
        {
            var data = DateTime.Now.Date;
            var hora = TimeSpan.FromHours(10);

            _moqAgendamentoRepositorio.Setup(r => r.ObterAg(data, hora))
                                      .ReturnsAsync(new List<Agendamento>());

            var ex = Assert.ThrowsAsync<BusinessException>(() => _negocio.DeletarAgendamentos(data, hora));
            Assert.AreEqual(string.Format(BusinessMessages.AgendamentoInexistente, "ag"), ex.Message);
            _moqAgendamentoRepositorio.Verify(r => r.ObterAg(data, hora), Times.Once);
        }

    }
}

