namespace iMusicaCorp.Infra.CrossCutting.DataTransferObject
{
    public class IndexEmployee
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimeto { get; set; }
        public string Cargo { get; set; }
        public int QtdDependentes { get; set; }
        public int Rows { get; set; }
    }
}
