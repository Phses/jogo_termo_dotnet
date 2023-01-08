namespace Termoo {
    public class Letras {
        public char Representação { get; set; }

        public Estado Estado;

        public Letras(char representação, Estado estado) {
            this.Representação = representação;
            this.Estado = estado;
        }

    }
}