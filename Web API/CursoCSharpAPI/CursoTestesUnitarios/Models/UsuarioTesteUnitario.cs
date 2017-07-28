using CursoRepositorio.Models;
using NUnit.Framework;

namespace CursoTestesUnitarios.Models
{
    [TestFixture]
    public class UsuarioTesteUnitario
    {
        [Test]
        public void VerificaSeUsuarioEValido()
        {
            var suv = new Usuario("guilherme@gmail.com", "122312", "23");

            Assert.That(suv.UsuarioValido, Is.True);
        }

        [Test]
        public void VerificaSenhasSaoIguais()
        {
            var suv = new Usuario("guilherme@gmail.com", "122312", "122313");

            Assert.AreEqual(suv.Senha, suv.SenhaConfirmacao);
        }
    }
}
