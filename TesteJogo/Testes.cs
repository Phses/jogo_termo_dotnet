namespace TestesJogo ;

    [TestClass]
    public class Testes {

        [TestMethod]
        public void TestePalavraSecreta() {
            Jogo jogo = new Jogo();
            jogo.GerarPalavraSecreta();
            Assert.AreEqual("TERMO", jogo.PalavraSecreta);
        }
        [TestMethod]
        public void TesteAcertouPalavraSecreta() {
            Jogo jogo = new Jogo();
            jogo.GerarPalavraSecreta();
            Assert.AreEqual(Status.VENCEU, jogo.Jogar("TErMO"));
        }

        [TestMethod]
        public void TestaChuteForaDoLimite() {
            Jogo jogo = new Jogo();
            jogo.GerarPalavraSecreta();
            Assert.AreEqual(Status.CHUTE_INVALIDO, jogo.Jogar("COMPUTADOR"));
        }


        [TestMethod]
        public void TestaLetraNaPosicao() {
            Jogo jogo = new Jogo();
            jogo.GerarPalavraSecreta();
            Assert.AreEqual(true, jogo.MatchLetraEPosicao('E', 1));
            Assert.AreEqual(false, jogo.MatchLetraEPosicao('T', 2));
        }

        [TestMethod]
        public void TestaLetraEmQualquerPosicao() {
            Jogo jogo = new Jogo();
            jogo.GerarPalavraSecreta();
            Assert.AreEqual(true, jogo.MatchLetra('E'));
            Assert.AreEqual(true, jogo.MatchLetra('T'));
        }

         [TestMethod]
        public void TestaLetrasErradas() {
            Jogo jogo = new Jogo();
            jogo.QtdeDeChances = 3;
            jogo.GerarPalavraSecreta();
            jogo.Jogar("TOTAL");
            CollectionAssert.AreEqual(new List<char> {'A', 'L'}, jogo.LetrasQueNaoPertecem);
        }
        [TestMethod]
        public void TestaPalavrasChutadas() {
            Jogo jogo = new Jogo();
            jogo.GerarPalavraSecreta();
            jogo.Jogar("TOTAL");
            jogo.Jogar("NORTE");
            CollectionAssert.AreEqual(new List<string> {"TOTAL", "NORTE"}, jogo.PalavrasChutadas);
        }
         [TestMethod]
        public void TestaQuantidadeDeChances() {
            Jogo jogo = new Jogo();
            jogo.QtdeDeChances = 3;
            jogo.GerarPalavraSecreta();
            jogo.Jogar("TOTAL");
            jogo.Jogar("NORTE");
            Assert.AreEqual(Status.PERDEU, jogo.Jogar("LIVRO"));
        }
}
