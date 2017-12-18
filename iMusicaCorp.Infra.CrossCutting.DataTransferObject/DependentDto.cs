using System;

namespace iMusicaCorp.Infra.CrossCutting.DataTransferObject
{
    public class DependentDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Excluido { get; set; }
    }
}
