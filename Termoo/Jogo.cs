using System.Collections;

namespace Termoo {
    public class Jogo {
        public string PalavraSecreta { get; set; }
        public int QtdeDeChances { get; set; }
        public List<string> PalavrasChutadas = new List<string>();
        public List<char> LetrasQueNaoPertecem = new List<char>();
        public char[] Tab { get; set;} 

        
        public Status Jogar(string chute) {
            if(chute.Length > PalavraSecreta.Length) {
                return Status.CHUTE_INVALIDO;
            }
            if(AcertouPalavraSecreta(chute)) {
                PalavrasChutadas.Add(chute);
                return Status.VENCEU;
            } else {
                PalavrasChutadas.Add(chute);
                Console.WriteLine(PalavrasChutadas.Count);
                if(PalavrasChutadas.Count >= QtdeDeChances) {
                    return Status.PERDEU;
                }
                VerificaLetrasQueNaoPertecemAPalavra(chute);
                return Status.NOJOGO;
            }
        }
        public void GerarPalavraSecreta() {
            PalavraSecreta = "TERMO";
        }

        public void ImprimirLetrasQueNaoPertencem() {
            Console.Write("[");
            foreach(char letra in LetrasQueNaoPertecem) {
                Console.Write(" " + letra + " ");
            }
            Console.Write("]");
        }

        public void ImprimirChutes() {
            for(int i = 0; i < PalavrasChutadas.Count; i++) {
                int index = 0;
                foreach (char letra in PalavrasChutadas[i])
                {
                    if(MatchLetraEPosicao(letra, index)) {
                        ConsoleColor aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(letra + " ");
                        Console.ForegroundColor = aux;
                    } else if(MatchLetra(letra)) {
                        ConsoleColor aux = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(letra + " ");
                        Console.ForegroundColor = aux;
                    } else {
                        Console.Write(letra + " ");
                    }
                    index++;
                }
                Console.WriteLine();
            }
        }


        public bool AcertouPalavraSecreta(string chute) => chute.ToUpper() == PalavraSecreta;


        public char[] VerificaLetrasQueAcertou(string chute)
        {
            return PalavraSecreta.Where(x => chute.Contains(x)).ToArray();
        }

        public bool MatchLetraEPosicao(char letra, int posicao) => PalavraSecreta[posicao] == letra;

        public bool MatchLetra(char letra) => PalavraSecreta.Contains(letra);

        public void VerificaLetrasQueNaoPertecemAPalavra(string chute) {
            foreach(char letra in chute) {
                if(!PalavraSecreta.Contains(letra)) {
                    LetrasQueNaoPertecem.Add(letra);
                }
            }
        }
    }
}