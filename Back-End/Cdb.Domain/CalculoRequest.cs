namespace Domain
{
    public class CalculoRequest
    {
        /// <summary>
        /// valor inicial do investimento enviado pelo usuario
        /// </summary>
        public decimal InitialValue { get; set; }
        /// <summary>
        /// prazo em meses para o resgate do investimento
        /// </summary>
        public int RescueTime { get; set; }
    }
}
