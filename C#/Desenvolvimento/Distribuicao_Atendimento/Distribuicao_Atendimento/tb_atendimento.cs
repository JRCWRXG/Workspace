//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Distribuicao_Atendimento
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_atendimento
    {
        public int id { get; set; }
        public System.DateTime entrada { get; set; }
        public Nullable<System.DateTime> saida { get; set; }
        public int prioridade { get; set; }
        public string senha { get; set; }
        public int status_atendimento { get; set; }
        public string cliente { get; set; }
    }
}
