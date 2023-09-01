namespace CrudConteiners.Models
{
    public class Relatorio
    {
        public class RelatorioViewModel
        {
            public List<DetalheRelatorio> Detalhes { get; set; }
            public List<SumarioRelatorio> Sumario { get; set; }
        }

        public class DetalheRelatorio 
        {
            public string Cliente { get; set; }
            public string Categoria { get; set; }
            public string TipoMovimentacao { get; set; }
            public int TotalMovimentacoes { get; set; } 
        }
        public class SumarioRelatorio 
        {
            public string Categoria { get; set; }
            public int TotalMovimentacoes { get; set; }
        }
    }
}
