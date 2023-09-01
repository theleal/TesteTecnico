using System.ComponentModel;

namespace CrudConteiners.Enums
{
    public class Enums
    {
        public enum TipoConteiner 
        {
            [Description("20")]
            C20 = 1,

            [Description("40")]
            C40 = 2,
        }

        public enum Status 
        {
            [Description("Cheio")]
            Cheio = 1,

            [Description("Vazio")]
            Vazio = 2,
        }

        public enum Categoria
        {
            [Description("Importação")]
            Importacao = 1,

            [Description("Exportação")]
            Exportacao = 2,
        }

        public enum TipoMovimentacao
        {
            [Description("Embarque")]
            Embarque = 1,

            [Description("Descarga")]
            Descarga = 2,

            [Description("GateIn")]
            GateIn = 3,

            [Description("GateOut")]
            GateOut = 4,

            [Description("Reposicionamento")]
            Reposicionamento = 5,

            [Description("Pesagem")]
            Pesagem = 6,

            [Description("Scanner")]
            Scanner = 7,
        }
    }
}
