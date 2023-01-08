namespace Termoo {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Regras do jogo:");
            Console.WriteLine("Verde: Acertou letra e posicao");
            Console.WriteLine("Amarelo: Acertou letra");
            Console.WriteLine("Branco: Letra não pertence a palavra secreta");
            Console.WriteLine("Chute uma palavra com 5 letras");
            Jogo jogo = new Jogo();
            Status status = Status.NOJOGO;
            jogo.QtdeDeChances = 4;
            jogo.GerarPalavraSecreta();
            do {

                string chute = Console.ReadLine();

                status = jogo.Jogar(chute);

                if(status == Status.CHUTE_INVALIDO) {
                    Console.WriteLine("Chute contem mais letras que a palavra secreta, chute outra palavra");
                    continue;
                }

                jogo.ImprimirChutes();
                Console.WriteLine("Letras que não pertencem a palavra secreta.");
                jogo.ImprimirLetrasQueNaoPertencem();

                Console.WriteLine();

                switch(status) {
                    case Status.NOJOGO:
                    Console.WriteLine("Esta não é a palavra secreta, chute outra palavra.");
                    break;
                    case Status.PERDEU:
                    Console.WriteLine("Que pena, suas chances acabaram");
                    break;
                    case Status.VENCEU:
                    Console.WriteLine("Parabéns você acertou!!");
                    break;
                };

            } while(status != Status.PERDEU || status != Status.VENCEU);
        }
    }
}