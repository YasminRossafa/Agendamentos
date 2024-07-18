using Moq;
using Agendamentos.Negocio.Negocios;
using Agendamentos.Entidade.DTO;
using Agendamentos.Negocio.Interface.INegocios;
using Agendamentos.Repositorio.Interface.IRepositorios;

namespace Agendamentos.TestesUnitarios
{
    public class PacienteNegocioTeste : TesteUnitarioBase
    {
        private IPacienteNegocio _negocio;
        private Mock<IPacienteRepositorio> _moqPacienteRepositorio;

        [SetUp]
        public void SetUp()
        {
            Registrar<IPacienteNegocio, PacienteNegocio>();
            _moqPacienteRepositorio = RegistrarMock<IPacienteRepositorio>();
            _negocio = ObterServico<IPacienteNegocio>();
        }

        [Test]
        public async Task FiltrarPaciente_Sucesso()
        {
            var nome = "Paciente Teste";
            var listaPacientes = new List<PacienteDTO>
            {
                new PacienteDTO { dsc_nome = "Paciente Teste" }
            };

            _moqPacienteRepositorio.Setup(r => r.ListarPacientes(nome))
                                   .ReturnsAsync(listaPacientes);

            var result = await _negocio.FiltrarPaciente(nome);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Paciente Teste", result[0].dsc_nome);
        }

        [Test]
        public async Task FiltrarPaciente_NenhumPacienteEncontrado()
        {
            var nome = "Paciente Inexistente";

            _moqPacienteRepositorio.Setup(r => r.ListarPacientes(nome))
                                   .ReturnsAsync(new List<PacienteDTO>());

            var result = await _negocio.FiltrarPaciente(nome);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}

